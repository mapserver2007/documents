# .NET基礎知識

## 参考サイト
* [C#や.NET Frameworkがやっていること](http://www.slideshare.net/ufcpp/cnet-framework)
* [.NET Framework とは(C# によるプログラミング入門)](http://ufcpp.net/study/csharp/ab_dotnet.html)
* [CLR 徹底解剖 : 大きなオブジェクト ヒープの秘密](http://msdn.microsoft.com/ja-jp/magazine/cc534993.aspx)
* [CLRから見たリソースについて - 荒井省三のBlog - Site Home - MSDN Blogs](http://blogs.msdn.com/b/shozoa/archive/2010/09/08/about-resources-on-clr.aspx)
* [C# ガベージコレクション](http://uchukamen.com/Programming/GC/#.NET_Framework_のメモリ管理の内部動作)
* [Microsoft .NET Framework の自動メモリ管理 Part Ⅰ](http://msdn.microsoft.com/ja-jp/library/bb985010.aspx)
* [Microsoft .NET Framework の自動メモリ管理 Part Ⅱ](http://msdn.microsoft.com/ja-jp/library/dd297765.aspx)
* [自動メモリ管理](http://msdn.microsoft.com/ja-jp/library/f144e03t(v=vs.110).aspx)
* [ガベージ コレクションの基礎](http://msdn.microsoft.com/ja-jp/library/ee787088(v=vs.110).aspx)
* [マネージリソースとアンマネージリソースの定義 - 憂国のプログラマ Hatena版](http://d.hatena.ne.jp/hilapon/20100904/1283570083)
* [3つの視点でネイティブと.NETの適材適所を考察 － ＠I](http://www.atmarkit.co.jp/fdotnet/chushin/greatblogentry_11/greatblogentry_11_01.html)
* [.NETアプリを軽快にするためのガベージ・コレクション講座 － ＠IT](http://www.atmarkit.co.jp/fdotnet/directxworld/directxworld06/directxworld06_01.html)
* [\[雑記\] スレッド プールとタスク(C# によるプログラミング入門)](http://ufcpp.net/study/csharp/misc_task.html)
* [スレッドの基本 - 猫型エンジニアのブログ](http://alexei-karamazov.hatenablog.com/entry/2014/04/20/105644)
* [Rubyのスレッド周りの話 - Qiita](http://qiita.com/motsat/items/8c9b6bc56152444f50a0)
* [Large Object Heap (LOH)](http://article.higlabo.com/ja/large_object_heap.html)

## .NET Frameworkにおけるコードの流れ
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
* .NET Framework 1.0(2000年9月～2004年8月)
    * Windows98、NT4.0、2000、XP向け
* .NET Framework 1.1(2003年4月～2009年10月)
    * ASP.NETのモバイル向け機能追加
    * セキュリティ仕様の変更
    * ODBC、Oracle接続を標準対応
    * IPv6対応
    * API変更
* .NET Framework 2.0(2007年1月～2010年11月)
    * VisualStudio 2005以降で開発可能
    * データバインディングの新しいAPI追加
    * ASP.NETのウェブコントロールを追加
    * ネイティブアプリケーションへの新しいホスティングAPI追加
    * CLRのジェネリック対応
    * 64ビットシステムへの対応
    * .NET Micro Framework追加
    * API変更
* .NET Framwork 3.0(2006年11月～2010年11月)
    * Windows Vista、Windows Server 2008に標準搭載、Windows XP以降で動作
    * Windows Presentation Foundation(WPF)追加
        * UIとロジックを分離したプログラミングモデルを提供する
        * デスクトップアプリ開発用(Webも一応できる)
    * Windows Communication Foundation(WCF)追加
    * Windows Workflow Foundation(WF)追加
    * Windows CardSpace(WCS)追加
    * クラスライブラリ、CLRは2.0と変更なし(CLR2)
* .NET Framework 3.5(2008年8月～2010年11月)
    * ASP.NET AJAXの対応
    * LINQ追加
    * C#、VB.NETのコンパイラ変更、J#対応終了
    * CLRは2のまま変更なし
* .NET Framework 4.0(2010年4月～)[[参考](http://www.microsoft.com/ja-jp/net/netfx4/5min.aspx)]
    * CLRのバージョンが4に更新(CLR4)
    * F#対応
    * DLR(動的言語ランタイム)追加
        * 動的型付け(コンパイル時に型情報が未確定なメンバ)が可能(C# 4.0のdynamicキーワード)
        * DLR上に実装された言語(IronRuby、IronPython)との連携も可能
    * MEF(Managed Extensibility Framwork)対応
        * プラグイン、アドインの仕組みを.NET上で簡単に実現するためのフレームワーク
        * Visual Studio 2010のアドインはMEFを使っている
    * Parallel Extensions(並列プログラミング)
        * TPL(Task Parallel Library:タスク並列処理ライブラリ)
            * System.Threading.Parallelクラス等で繰り返し処理を並列化
        * Parallel LINQ(PLINQ)
            * LINQの並列実行
    * Velocity(分散キャッシュAPI)
        * memcachedに似た技術
* .NET Framework 4.5(2012年8月～)
    * CLR4.5
        * CLR4との共存はできない
        * .NET4と.NET4.5は(ほぼ)完全な互換性がある
        * Windows Vista以降が必要(XP非対応)
    * 非同期プログラミング
    * Windows Metroアプリケーションの開発対応

## .NET Framworkの構成
* CLR(Common Language Runtime)
    * JITコンパイラ、GC、メモリ管理、クラスローダ、セキュリティ
* クラスライブラリ
    * System.* の名前空間で提供されるクラス群
* 中間言語(IL=Intermediate Language)
    * ソースコードと機械語の中間にあたる言語。Javaではバイトコードと呼ぶ。JITコンパイラはILを読み、ネイティブコード(機械語)に翻訳して実行する
    * コンパイルすると、exeが生成されるが、IL生成も標準でできる(が、IL生成は黒魔術)
* ASP.NET
    * Webアプリケーションのためのフレームワーク
* Silverlight
    * マルチプラットフォームなRIA。MacOS Xにも対応している
* 分散コンピューティング
    * WCF(Windows Communication Foundation)(=.NET3.0以降)
        * クラスをサービスとして実装する(ServiceContractアノテーションを付与したり)
    * WS-*(Webサービス拡張仕様)
        * メッセージング(WS-Addressing)
        * セキュリティ(WS-Security/WS-SecureConversation/WS-SecurityPolicy/WS-Trust)
        * 高信頼性(WS-ReliableMessaging)
        * トランザクション(WS-Coordination/WS-AtomicTransaction)
        * メタデータ(WS-Policy/WS-PolicyAttachement/WS-MetadataExchange)
    * 基本的なWSDL、SOAPと言ったもの以外の拡張されたWebサービス仕様群だが、仕様が膨大


## .NET Framework 4.0の構成
<pre>
.NET Framework 4.0
    - ASP.NET
        - Web Forms
            - Dynamic Data
            - ASP.NET AJAX
        - ASP.NET MVC
    - WPF
    - WCF
    - WF
    - ADO.NET
        - DataSet
        - LINQ
        - Entity Framework
    - BCL
    - CLR
</pre>

## CLR
TODO?

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

