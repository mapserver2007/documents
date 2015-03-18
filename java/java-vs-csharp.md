# C#とJava8を比べてみよう

## 参考サイト
* [Java 8のすべて](http://www.infoq.com/jp/news/2013/09/everything-about-java-8)
* [Javaラムダ式メモ(Hishidama's Java Lambda Expression Memo)](http://www.ne.jp/asahi/hishidama/home/tech/java/lambda.html)
* [Java関数型インターフェースメモ(Hishidama's Java Functional Interface Memo)](http://www.ne.jp/asahi/hishidama/home/tech/java/functionalinterface.html)
* [Java 8を関数型っぽく使うためのおまじないをC#でやってみた - ぐるぐる～](http://bleis-tift.hatenablog.com/entry/functionalcs)
* [Java 8を関数型っぽく使うためのおまじない - きしだのはてな](http://d.hatena.ne.jp/nowokay/20130501#1367357873)
* [java.util.function以下の関数インターフェース使い方メモ - Qiita](http://qiita.com/opengl-8080/items/22c4405a38127ed86a31)
* [java.util.function パッケージ　【追記・修正あり】 - 倭マン&#39;s BLOG](http://waman.hatenablog.com/entry/20130313/1363200589)
* [Java8で最もインパクトのある構文拡張、デフォルトメソッド - きしだのはてな](http://d.hatena.ne.jp/nowokay/20130610)
* [C# 使いから見てうらやましい Java8 の default 実装の使い方 - ぐるぐる～](http://bleis-tift.hatenablog.com/entry/java8-default-impl)
* [Java8新機能 ラムダ式とデフォルトメソッドの導入理由 - Yuji Blog](http://blog.yujing.jp/entry/2013/06/29/170337)

## ラムダ式(Java8,C\#)

### Java8
* `->`を使う
* 規定のインタフェースをラムダ式の受け取り元変数の型にする
    * 引数の種類、数によって[インタフェースの使い分け](http://www.ne.jp/asahi/hishidama/home/tech/java/functionalinterface.html#h_API)が必要でC\#と比べて非常に面倒。
    * `java.util.function.Function`
        * `Function`インタフェース以外に[プリミティブ型毎のインタフェース型がある](http://waman.hatenablog.com/entry/20130313/1363200589#function)。そもそもこれらは使う理由があるかどうかも不明。覚えることがだるいので、使いどころがわかってから使うべきかも。
    * `java.util.function.BiFunction`
        * `BiFunction`は引数2つ、戻り値1つ固定のFunction。
* もしくは独自に定義したインタフェース(`@FunctionalInterface`をアノテート)をラムダ式の受け取り元変数の型にする。
* ラムダ式を実行するときに`Function#apply`を使う。
    * applyはインタフェースを独自で定義した時に実装する拡張性のために作られたっぽい。
    * Javaのラムダ式の実体はクラス？(要出典)なので、ラムダ式の戻り値自体はインスタンス変数？(要出典)。C\#とは違う。
* 関数合成ができる＝ラムダ式で受け取った結果を連鎖的に実行。`Function#compose`、`Function#andThen`。違いは実行順序。
* `@FunctionalInterface`を付けたInterfaceを定義する。関数型インタフェースでない場合コンパイルエラー。
    * 抽象メソッドが1つだけ定義可能。
* 式木を扱う機能はない。

### C\#
* `=>`を使う
* `Func`および`Action`を使う。`Func`は戻り値ありのラムダ式、`Action`は戻り値なしのラムダ式。
* ラムダ式を実行するときは直接実行できる。Funcの実体はデリゲートであってインスタンスじゃない(Javaとは違うのだよ！)
* 関数合成機能はない。ほしいなら拡張メソッドで勝手に作れスタンス。
* `Expression`型の変数に代入すると実行可能コードではなく式木(Expression tree＝式の意味を表す木構造データ)になる。
    * メタプログラミングで使える

## NullableとOptional

### Java8
* nullよりも安全に値がないことを表す。

### C\#
* nullよりも安全に値がないことを表す。


## StreamAPI(Java8)、LINQ to Objects(C\#)

### Java8
* TODO

### C\#
* TODO

## Java8にしかない機能
### default実装
* Java8からはインタフェースに実装が持てるようになった。実装を持つには`default`をつけて宣言する。
    * 抽象クラス：多重継承不可、状態を持てる。
    * インタフェース+default：多重継承可能、状態を持てない。

## C\#にしかない機能
### 拡張メソッド
* 静的メソッドをインスタンスメソッドとして呼び出せるように拡張できる。既存の型に対しても後付でメソッドを追加できる。
    * MVCならHelperでよく使うあれ。


## φ(｀д´)ﾒﾓﾒﾓ...
### Java
* interfaceに定義するメソッド、変数は`public`でなければならない。
* interfaceに定義する変数は`static final`でなければならない。ただし省略可(省略時はコンパイル時に勝手に`static final`と解釈される)。
    * `static final`を付けているとEclipseで警告がでる場合あり。
* Java8でラムダ式が導入された一番の理由は、コレクションの処理を複数スレッドで分散処理する要求が高まったから。
    * Java7以前でそういうことがしたい場合、プログラマが責任をもって実装する必要があった。
