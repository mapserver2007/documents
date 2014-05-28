# .NET基礎知識

## 参考サイト
* [C#や.NET Frameworkがやっていること](http://www.slideshare.net/ufcpp/cnet-framework)
* [.NET Framework とは(C# によるプログラミング入門)](http://ufcpp.net/study/csharp/ab_dotnet.html)
* [CLR 徹底解剖 : 大きなオブジェクト ヒープの秘密](http://msdn.microsoft.com/ja-jp/magazine/cc534993.aspx)
* [CLRから見たリソースについて - 荒井省三のBlog - Site Home - MSDN Blogs](http://blogs.msdn.com/b/shozoa/archive/2010/09/08/about-resources-on-clr.aspx)
* [C# ガベージコレクション](http://uchukamen.com/Programming/GC/#.NET_Framework_のメモリ管理の内部動作)
* [Microsoft .NET Framework の自動メモリ管理 Part Ⅰ](http://msdn.microsoft.com/ja-jp/library/bb985010.aspx)
* [Microsoft .NET Framework の自動メモリ管理 Part Ⅱ](http://msdn.microsoft.com/ja-jp/library/dd297765.aspx)
* [自動メモリ管理](http://msdn.microsoft.com/ja-jp/library/f144e03t(v=vs.110\).aspx)
* [ガベージ コレクションの基礎](http://msdn.microsoft.com/ja-jp/library/ee787088(v=vs.110\).aspx)
* [マネージリソースとアンマネージリソースの定義 - 憂国のプログラマ Hatena版](http://d.hatena.ne.jp/hilapon/20100904/1283570083)
* [3つの視点でネイティブと.NETの適材適所を考察 － ＠I](http://www.atmarkit.co.jp/fdotnet/chushin/greatblogentry_11/greatblogentry_11_01.html)
* [.NETアプリを軽快にするためのガベージ・コレクション講座 － ＠IT](http://www.atmarkit.co.jp/fdotnet/directxworld/directxworld06/directxworld06_01.html)
* [\[雑記\] スレッド プールとタスク(C# によるプログラミング入門)](http://ufcpp.net/study/csharp/misc_task.html)
* [スレッドの基本 - 猫型エンジニアのブログ](http://alexei-karamazov.hatenablog.com/entry/2014/04/20/105644)
* [Rubyのスレッド周りの話 - Qiita](http://qiita.com/motsat/items/8c9b6bc56152444f50a0)
* [Large Object Heap (LOH)](http://article.higlabo.com/ja/large_object_heap.html)

## .NET Framworkにおけるコードの流れ
* 各種言語(C#/VB.NETなど)のソースコードを記述する
* ソースコードはそれぞれの言語のコンパイラで共通中間言語(CIL:Common Intermediate Language)に変換される
    * CILは「IL」「MSIL(Microsoft IL)」とも呼ばれる
    * Javaのバイトコード(.classファイル)に相当する
* ILを実行するための環境を共通言語基盤(CLI:Common Language Infrastructure)と呼ぶ
    * ILはCLIの仕様に沿った実装であればプラットフォームによらず実行可能となる
    * MicrosoftはCLIの実装として共通言語ランタイム(CLR:Common Language Runtime)を提供している
        * CLRにはGCやJITコンパイラが実装されている
        * Linux版のCLIはMono
        * Mac/FreeBSD版のCLIも開発している
* 共通中間言語(CIL)はCLI(CLR)によりネイティブコードに変換され、実行される

## .NET Frameworkの歴史
* TODO
* http://ja.wikipedia.org/wiki/.NET_Framework

## メモリ管理

### ガベージコレクタ
* 世代別GCで、世代0、世代1、世代2の3つに分類されている
    * 各世代で残ったオブジェクトは次の世代へ昇格
    * 世代0：すべてのオブジェクト(LOH以外)は世代0として生成
        * GC(マイナーGC?)はまず世代0のオブジェクトをガベージコレクトする
        * GC後、コンパクションする
        * 残ったオブジェクトは世代1に昇格させる
    * 世代1：GC実行時に生き残ったオブジェクトの内、比較的短い有効期間のオブジェクトは世代1となる
    * 世代2：GC実行時に生き残ったオブジェクトの内、比較的長い有効期間のオブジェクトは世代2となる
        * 世代2でもゴミと判断されないオブジェクトは、GCで到達できないオブジェクトと判断されない限り残り続ける
            * GCで到達できないオブジェクトであると判断された場合、GCで開放される
            * 世代2のGCはFullGCなのでとても重い
                * 世代2に対してGCが実行されてもLOHは残る
        * JavaではOld領域に相当
<pre>
世代0のGCで空きが十分できるか？
    → [Yes] 世代0のGC実行→残ったオブジェクトを世代1へ
    → [No] 世代1のGCで空きが十分できるか？
            → [Yes] 世代1のGC実行→世代0のGC実行
            → [No] 世代2のGC実行→世代1のGC実行→世代0のGC実行
</pre>
* GCが実行される前に、GCが実行されるスレッド以外のスレッドが中断される
* アンマネージリソースはGC対象外なのでOpen/Closeまたはusing(IDisposableの継承)を使い手動管理・開放する必要がある

### LOH(Large Object Heap)
* .NET FrameworkにはSOH用ヒープ領域とLOHヒープ領域の2つがある
    * 85000バイト以上のオブジェクトならLOHに格納
    * LOHはアロケートされない＝コンパクションされないため断片化が起きる
        * アロケートしないのは、サイズが巨大なためオーバヘッドが大きすぎるため
        * 断片化するとよりメモリを使用することになる(非効率な使用)
* LOHはGCの対象にはならない([参照](http://d.hatena.ne.jp/hilapon/20100904#c))
    * LOHははじめから世代2のヒープとして作成されるため
    * AppDomainがアンロードされるまで開放されない
    * LOHは85KB以上の巨大な配列や画像などのバイナリデータが該当
        * 85KB以上のデータを扱いたい場合、Marshalクラスを使いアンマネージリソースとして手動管理する

## スレッド(一般的内容)
* CPUの数を超えて複数の処理を同時に実行するための仕組み
    * 厳密には本当に並列というわけではなく、一定間隔でOSが処理を奪ってスレッドを高速に切り替えて同時実行しているように見える
    * マルチコアの場合、スレッドはそれぞれ別々のコアに割り当てられて実行されるので、本当の同時実行になる
* スレッドの種類
    * ユーザスレッド
        * ユーザ空間(アプリケーションが稼働しているアドレス空間)で実装されたスレッド機構のこと
        * スレッド管理はユーザ空間上で完結するため、カーネルに影響しない
    * カーネルスレッド(≒ネイティブスレッド)
        * カーネル空間(OSが稼働しているアドレス空間)
        * ライトウェイトプロセス(LWP=軽量プロセス、ひとつのプロセス内でスレッドを複数同時実行するための仕組み)とカーネルスレッドを総称してネイティブスレッドと呼ぶ
    * グリーンスレッド
        * VM上で実行されるユーザスレッドのこと。カーネルスレッドが使えない環境でマルチスレッドを実現できる
        * カーネルスレッドとほぼ同等のパフォーマンスかつOSに依存しないスレッド機構
        * OS標準の並列化機能(マルチコア、マルチプロセッサの利用)が使えない、コンテキストスイッチが重い
* スレッドプール
    * スレッドを再利用する仕組み(スレッドは生成、切替にそれなりのコストがかかる)
    * TODO 追記予定

## 用語
* マネージヒープ
    * GC機能により.NET frameworkの管理下にあるメモリのこと
* マネージリソース
    * ポインタを含むメモリ管理下のリソースすべて
* アンマネージリソース
    * ポインタが指す外部リソース(ポインタそのものは含まない)
* AppDomain
    * .NET Frameworkは1プロセス中に型やセキュリティを管理する単位としてAppDomain(アプリケーションドメイン)という境界を作り、その中で処理を実行する
* コンテキストスイッチ
    * スレッド、プロセスの切り替えのこと

