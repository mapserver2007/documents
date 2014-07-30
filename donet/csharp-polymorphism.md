# C#(ASP.NET MVC)でポリモーフィズム

* [多態性(C# によるプログラミング入門)](http://ufcpp.net/study/csharp/oo_polymorphism.html)

## メソッドの挙動がほんの少しだけ違うケース
例えば、「初期状態の入力画面」と「確認画面からの戻りの入力画面」という場合、殆どの場合画面表示が変わらない。
しかし、完全には同じではない(渡すパラメータが違う、そもそも初期状態ではないが、戻りではPOSTパラメータがあるなど)。
こういう場合どうするべきか。

## 良くないパターン1(別々に作る)
共通化もなにもしない。アクションメソッドを2つ作り、それぞれ別のViewを書き出す。

### FormController.cs
```csharp
    // 入力
    [HttpGet]
    public ActionResult Input()
    {
        InputViewModel viewModel = CreateInputViewModel();
        return View("Input", viewModel);
    }

    // 確認
    [HttpPost]
    public ActionResult Confirm(FormParam param)
    {
        ConfirmViewModel viewModel = CreateConfirmViewModel(param);
        return View("Confirm", viewModel);
    }

    // 戻り
    [HttpPost]
    public ActionResult Input(FormParam param)
    {
        // 入力済みパラメータが入る違いがある
        ReInputViewModel viewModel = CreateReInputViewModel(param);
        return View("ReInput", viewModel);
    }
```
### Input.aspx

    <%@ Page Language="C#" Inherits="System.Web.Mvc.ViewMasterPage<YahooBBEntry.Models.ViewModel.InputViewModel>" %>
    (省略)

### Confirm.aspx

    <%@ Page Language="C#" Inherits="System.Web.Mvc.ViewMasterPage<YahooBBEntry.Models.ViewModel.ConfirmViewModel>" %>
    (省略)

### ReInput.aspx

    <%@ Page Language="C#" Inherits="System.Web.Mvc.ViewMasterPage<YahooBBEntry.Models.ViewModel.ReInputViewModel>" %>
    (省略)

この問題点は、すべて2重に作られている点。ViewModelを作成するメソッドも、入力初期と確認画面からの戻りで「わずかに」違うため、単純な共通化が難しい。そのため別メソッドにしているが保守範囲が広くなる(本質的な処理は殆ど変わらないにもかかわらず)。View書き出しでも同じことで、入力初期と戻りで違うところはデフォルトでフォームに入力値があるかないか程度なのにもかかわらず共通化できていない原因は、参照するViewModelが異なるためである。


## 良くないパターン2(中途半端な共通化)
```csharp
    // 入力
    [HttpGet]
    public ActionResult Input()
    {
        InputViewModel viewModel = CreateViewModel("Input", null);
        return View("Input", viewModel);
    }

    // 確認
    [HttpPost]
    public ActionResult Confirm(FormParam param)
    {
        ConfirmViewModel viewModel = CreateViewModel("Confirm", param);
        return View("Confirm", viewModel);
    }

    // 戻り
    [HttpPost]
    public ActionResult Input(FormParam param)
    {
        // 入力済みパラメータが入る違いがある
        ReInputViewModel viewModel = CreateViewModel("ReInput", param);
        return View("ReInput", viewModel);
    }

    private CreateViewModel(string pageName)
    {
        // ひどすぎて書く気がしない
    }
```
さらにひどくなっている。これでは結局CreateInputViewModelメソッド内で分岐処理が必要になる。パターン2より保守性が悪化しているためより悪い。


## 良いパターン

### FormController.cs
```csharp
    // 入力
    [HttpGet]
    public ActionResult Input()
    {
        InputViewModel viewModel = CreateViewModel();
        return View("Input", viewModel);
    }

    // 確認
    [HttpPost]
    public ActionResult Confirm(FormParam param)
    {
        ConfirmViewModel viewModel = CreateViewModel<ConfirmViewModel>(param);
        return View("Confirm", viewModel);
    }

    // 戻り
    [HttpPost]
    public ActionResult Input(FormParam param)
    {
        InputViewModel viewModel = CreateViewModel<InputViewModel>(param);
        return View("Input", viewModel);
    }

    private InputViewModel CreateViewModel()
    {
        return new InputViewModel();
    }

    private Type CreateViewModel<Type>(FormParam param) where Type : FormViewModel
    {
        // 指定されたViewModel型のインスタンスを生成
        Type viewModel = Activator.createInstance<Type>();

        // ...

        return viewModel;
    }
```
### InputViewModel.cs
```csharp
    public InputViewModel : FormViewModel {}
```
### ConfirmViewModel.cs
```csharp
    public ConfirmViewModel : FormViewModel {}
```
### FormViewModel.cs
```csharp
    abstract public FormViewModel
    {
        // POSTパラメータの各項目がここに定義される
    }
```
### Input.aspx

    <%@ Page Language="C#" Inherits="System.Web.Mvc.ViewMasterPage<YahooBBEntry.Models.ViewModel.InputViewModel>" %>
    (省略)

### Confirm.aspx

    <%@ Page Language="C#" Inherits="System.Web.Mvc.ViewMasterPage<YahooBBEntry.Models.ViewModel.ConfirmViewModel>" %>
    (省略)

初期入力と戻りが同じViewとなり、確認と戻りのViewModelが共通化された。  
Type型を指定することで、複数の型が受けられる様になり、whereでクラスを指定すると、生成したインスタンスがそのクラスから派生したインスタンスとなる。whereで型指定しない場合、Type型のオブジェクトは単なるオブジェクトであるため、作成したインスタンスメソッドにアクセス出来ない(コンパイルエラーになる)。内部的に静的型付けするためにwhereでクラスを指定する。ただし、具象クラス(InputViewModelなど)を指定すると、意味が無いので、抽象クラスかインタフェース(共通の具象クラスでも悪くないが親クラスは抽象度を上げるほうが望ましい)を指定する。  
つまり、渡ってきたType型クラスのメソッドにアクセスできるようになる(FormViewModelのメソッドであればアクセス可)。  
作成されたViewModelクラスは呼び出し元で指定した型のインスタンスなので、入力と戻りで同じViewModelクラス型となる。つまり、入力と戻りで同じView(Index.aspx)を使いまわすことができる。  
もしこの方法をとらないと、同じような処理(わずかに違うだけ)のメソッドが大量にオーバーロードされることとなり保守性は極端に落ちる。  