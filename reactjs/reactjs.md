# React.jsの勉強メモ

## 現時点での所感
* [これ](http://qiita.com/icoxfog417/items/5d79b3336226aa51e30d)を見る限り、中途半端(サーバサイドテンプレートエンジンと同居)な適用はきつそう
* 極限まで使うとHTMLが空の状態で、全部JS(JSX)にVirtualDOMが記述されるので、でかいHTMLになったとききつくね？
* テンプレートに記述していた内容がすべてJSコードになったとき、保守できる？
* SPAみたいなのなら使うほうがいいとは思う

## VirtualDOMについて
* [Tutorial | React](http://facebook.github.io/react/docs/tutorial.html)
    * 本家のチュートリアル
* [JavaScript - なぜ仮想DOMという概念が俺達の魂を震えさせるのか - Qiita](http://qiita.com/mizchi/items/4d25bc26def1719d52e6)
    * 概念的なのをざっとわかりやすく解説
* [VirtualDOM Advent Calendar 2014 - Qiita](http://qiita.com/advent-calendar/2014/virtual-dom)
* [一人React.js Advent Calendar 2014 - Qiita](http://qiita.com/advent-calendar/2014/reactjs)
    * これを追っていけば基本は多分OK
* [JavaScript - React.js 実戦投入への道 - Qiita](http://qiita.com/icoxfog417/items/5d79b3336226aa51e30d)
    * HTMLテンプレートを捨て去るという選択
    * サーバサイドでJSX→HTML変換をする仕組みがある(PHPなど)

## Reactの考え方
[Separation of concerns?](http://qiita.com/koba04/items/4f874e0da8ebd7329701#separation-of-concerns)

```
ところで、React.jsではComponentとして、マークアップとViewのロジックをcreateClassの中に書いていくのですが、他のフレームワークのようにマークアップはHTMLやmustacheで書いてViewのロジックをJSで書くみたいに分かれてなくて気持ち悪い！という人もいるのではないでしょうか？
それに対して、React.jsの開発者であるPete Huntはそれは「関心の分離(Separation of concerns)」ではなくて「技術の分離(Separation of technologies)」だとしていて、マークアップとViewのロジックは密であるべきとしています。
```


## JSX

```js
var Hello = React.createClass({
  render() { // render: function() と同じ
    return (
      <div>Hello {this.props.name}</div>
    )
  }
})
```

* `<div>～</div>`はHTMLではない
* `<div className="hoge"></div>`みたいに、class属性はつかえない(JavaScript予約語はつかえない)
* JSXTransformerを使うと.jsxファイルのまま実行することができる(http://qiita.com/cortyuming/items/9e7c30224ff3e4671019)
    * が、明らかに遅いので開発でしか使わない方がいい
* Productionでちゃんと使う場合はjsxを変換する必要がある(npm run react)

## Component
* Componentは独自のVirtualDOMのタグを定義する方法

[http://qiita.com/koba04/items/bc13d1f42964278ae14e#基本的な使い方](http://qiita.com/koba04/items/bc13d1f42964278ae14e#基本的な使い方)

```js
var Avatar = React.createClass({
  render() {
    var avatarImg = `/img/avatar_${this.props.user.id}.png`;
    return(
      <div>
        <span>{this.props.user.name}</span>
        <img src={avatarImg} />
      </div>
    );
  };
});

var user = {
  id: 10,
  name: "Hoge"
};
```

* `<Avatar user={hoge}/>`で画像表示

## Prop
* PropはImmutable
* Propは上位コンポーネント(親)から下位コンポーネント(自分)に渡される(逆はありえない)
* [PropTypes](http://qiita.com/koba04/items/bc13d1f42964278ae14e#proptypes)を使うとバリデーションできる
    * JSでそこまでやる必要あるのかは分からないが

## State
* StateはMutable
* 自分自身の状態を表すもの
* [サンプル](http://qiita.com/koba04/items/63267bcc918d76ac8767#基本的な使い方)
    * これを見るとReactって便利って少し思える
* 値の更新処理は必ず`setState`を経由しないといけない(VirtualDOM)


## その他
* https://github.com/reactjs/sublime-react
    * SublimeText用プラグイン
