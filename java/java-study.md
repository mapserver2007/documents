# Java基礎知識

## 参考サイト
* [開発者が知っておくべきJavaと仮想マシンの歴史 - ＠IT](http://www.atmarkit.co.jp/fjava/column/andoh/andoh42.html)  
* [Java - Wikipedia](http://ja.wikipedia.org/wiki/Java)  
* [OpenJDK - Wikipedia](http://ja.wikipedia.org/wiki/OpenJDK)  
* [コラム: HotSpotとJRockitって何が違うの？ ～ VisualVM vs MissionControl](https://www.acroquest.co.jp/webworkshop/JavaTroubleshooting/column_006Main.html)  
* [アプリケーション実行基盤としてのOpenJDKの評価 調査報告書](http://ossipedia.ipa.go.jp/nfs/pdf_pub/1007/208/671/671.pdf)  
* [Project HotRockit](http://www.slideshare.net/OracleMiddleJP/project-hotrockit)  
* [Java 8でPermGenのOutOfMemoryError問題は解決されるのか？](http://www.infoq.com/jp/news/2013/03/java-8-permgen-metaspace)  
* [Java: PermGen はヒープの外 - sardineの日記](http://d.hatena.ne.jp/sardine/20100716/p2)  
* [Javaのヒープ・メモリ管理の仕組みについて](http://promamo.com/?p=2828)  
* [Java8のHotSpotVMからPermanent領域が消えた理由とその影響 | ギークを目指して](http://equj65.net/tech/java8hotspot/)  
* [メモリ管理(コンピュータの基礎知識)](http://ufcpp.net/study/computer/MemoryManagement.html)  
* [Java入門](http://bluesky117.web.fc2.com/cases/java/cases100101.html)  
* [A.02. Java の文法の基礎 · mixi-inc/AndroidTraining Wiki](https://github.com/mixi-inc/AndroidTraining/wiki/A.02.-Java-%E3%81%AE%E6%96%87%E6%B3%95%E3%81%AE%E5%9F%BA%E7%A4%8E)  
* [Java：意外と教わる機会の少ないメモリ管理のお話(4) - omotenashi-mind](http://www.omotenashi-mind.com/index.php/Java%EF%BC%9A%E6%84%8F%E5%A4%96%E3%81%A8%E6%95%99%E3%82%8F%E3%82%8B%E6%A9%9F%E4%BC%9A%E3%81%AE%E5%B0%91%E3%81%AA%E3%81%84%E3%83%A1%E3%83%A2%E3%83%AA%E7%AE%A1%E7%90%86%E3%81%AE%E3%81%8A%E8%A9%B1(4))  
* [しがないSEのブログ: JavaVMのメモリ管理（Permanent領域編）](http://n-arabesque.blogspot.jp/2014/01/javavmpermanent.html)  
* [Javaクラスローダー - Wikipedia](http://ja.wikipedia.org/wiki/Java%E3%82%AF%E3%83%A9%E3%82%B9%E3%83%AD%E3%83%BC%E3%83%80%E3%83%BC)  
* [Java8のHotSpotVMからPermanent領域が消えた理由とその影響 | ギークを目指して](http://equj65.net/tech/java8hotspot/)

## Javaの歴史
* 1995年5月: SunがJava発表
* 1996年2月: JDK1.0
* 1997年2月: JDK1.1
* 1998年2月: J2SE1.2(JDK1.2)
    * エディション名がJDKからJ2SE(Java 2 Platform Standard Edition)に変更
* 1998年4月: JITコンパイラ
* 1999年4月: HotSpot
* 2000年5月: J2SE1.3(JDK1.3)
* 2002年3月: J2SE1.4(JDK1.4)
* 2004年9月: J2SE5.0(JDK5.0)
    * バージョンのナンバリング変更
* 2006年11月: JavaSE,JavaMEをOSS化
* 2006年12月: JavaSE6(JDK6)
    * JavaSE6から`J2SE`という名称をJavaSEに変更
    * バージョンのナンバリングを変更(.0を廃止)
* 2011年7月: JavaSE7(JDK7(OpenJDK)), OracleがSun買収後の初リリース。
* 2014年3月: JavaSE8(JDK8)
* 2016年?: JavaSE9(JDK9)

## JDK
* コンパイラ、Javadoc、デバッガ、JREを同梱
* 呼び名が何度か変わっている
    * J2SE1.2.2_004までは`JDK`
    * J2SE1.4までは`Java 2 SDK`
    * J2SE5.0からは再び`JDK`
* JDKの変遷
    * Sun JDK→OpenJDK→Java7 (OSS路線)
    * Sun JDK→OracleJDK(HotRockit化) (OracleJDK路線)
    * Oracle JRockit→そのまま(JavaSE1.4～6 メンテナンスOnly)
* Oracle

## JVM
### なぜJVMはたくさんあるのか
* 2006年11月にJavaSE、JavaMEがOSS化するまでは、各企業が特殊プラットフォーム(CPU)に対応するため、またはSunのJVMが大きくなりすぎ(支配が高すぎる)による反発のために乱立。

* JRockit
    * Oracle製JVM(もともとBEA製)
    * HotSpotより高速(ただしIntelCPUのみ)
    * `Java Mission Control`、`Java Flight Recorder`など強力なツールが使える
    * BEA→Oracleに移管
    * 2011年にOpenJDKベースになった＝HotRockit
    * 現在はOracle Fusion Middlewareの一部になっている
    * UNIX(Solaris)、MaxOSでは動かない
* HotSpot
    * OpenJDKのJVM(もともとSun製)
    * VirtualVMが付属
        * JRockitより機能が少ない
    * 利用者はJRockitより多い
* HotRockit
    * HotSpotにJRockitを統合(現在進行中)
        * Java7u4には[入ってるっぽい](http://www.oracle.com/technetwork/java/javase/7u4-relnotes-1575007.html)
        * Java7u40から本格的に使える
        * JRockitでしか使えなかった`Java Mission Control`や`Java Flight Recorder`が使えるようになる
* DarvikVM
    * TODO

### メモリ領域
* JVMのメモリ領域は以下の様な構成である
<pre>
    JVM
        - JVM固有領域
            - New領域(ヒープ領域)
                - Eden領域
                - Survivor領域
                    - From領域
                    - To領域
            - Old領域(ヒープ領域)
                - Tenured領域
            - Parmanent領域(スタック領域)
        - OS固有領域
            - Cヒープ領域
            - スタック領域
</pre>

* New領域
    * new演算子によって作成されたオブジェクトが格納される領域
    * Eden領域にはオブジェクトが作成された時に最初に配置される。Eden領域がいっぱいになるとScavengeGCが実行される
        * ScavengeGCはNew領域のみを対象としたGCで、短時間で終了し、使用頻度が高い
        * 使用中のオブジェクトはGC時にEden→To領域へ移動される
        * その後さらにEden領域がいっぱいになったとき、To領域のオブジェクトはFrom領域へ移動する。Eden、From領域に対してScavengeGCが実行され、生き残ったものはTo領域へ移動する。これを繰り返す。
        * To領域に移動したオブジェクトには移動回数が振られる(1からカウントアップ)。MaxTenuringThreshold(デフォルト32)を超えると「寿命の長いオブジェクト＝Tenured object」として扱われ、Old領域へ移動される
* Old領域
    * New領域から移動してきたTenured objectを格納する領域
    * Old領域がいっぱいになったとき、FullGCが実行される。FullGCはNew、Old領域全体＋Parmanent領域を対象としたGC
    * FullGCは非常に重く、実行中はシステムが一時停止する

* Permanent領域
    * クラスローダによりクラスファイル(.classファイル)を読み込む領域
    * クラスローダは以下のとおり
        * ブートストラップローダ：ネイティブコード(機械語=OSが直接実行可能)のライブラリをロード。%JAVA_HOME%/lib配下の中核ライブラリ。
        * 拡張クラスローダ：%JAVA_HOME%/lib/ext、java.ext.dirsに指定したパス配下のライブラリをロードする
        * システムクラスローダ：CLASSPATH変数で記述したクラスをロードする
        * ユーザ定義クラスローダ：ユーザが定義したClassLoaderクラスによってロードする
    * Permanent領域がいっぱいになるとフルGCが走る。さらにフルGCでも空きができない場合はPermanent領域を拡張する。拡張サイズは-XX:MaxPermSizeで指定したサイズ
        * JDK8からはPermanent領域がなくなり、Metaspace領域が使用されるようになった
        * MetaspaceはCヒープ(ネイティブヒープ)領域に確保されるため制限がない(プロセッサが利用できるメモリ資源の上限まで使用可能)

* Cヒープ領域
    * JVM自身が格納される領域

* スタック領域
    * Parmanent領域のクラス情報からメソッド内容を読み込み、スタック領域に展開して実行する
        * プリミティブ型の場合、直接スタック領域に格納される
        * 参照型の場合、スタック領域にはヒープのアドレスが格納される
    * スタック領域はスレッド制御のために利用される領域で、スレッドごとに独立している
    * 各スコープで定義した変数を格納したりする。スコープ単位で積み上げていくため効率がいい
    * メソッドが呼ばれた時にヒープのPermGen/Metaspaceに格納されているインスタンス(クラス情報)からメソッドを読み込み、メソッドのローカル変数をスタック領域に展開する
    * 格納される単位はスコープ(if,for等)
    * スコープが明確になっていないと使えない、大きな領域の確保ができない
    * スコープを抜けると情報が削除される。スコープを抜けるとソースコード内で変数の参照ができなくなるのはこのスタック領域の管理仕様によるため

### メモリを意識したコーディング
* オブジェクトは使いまわし過ぎないこと
    * オブジェクトの寿命が長くなり、Old領域へ追いやられる。そうなるとScavengeGCでは削除されなくなり、FullGCが発生しやすくなる
* staticメソッドを多用しすぎないこと
    * Parmanent領域にロードされる情報が多くなるためFullGCが発生しやすくなる

## 関連項目

### レジスタマシン
* Darvikはレジスタマシン
* アクセススピードが速い
* ハードウェアに依存

### スタックマシン
* メモリがスタック形式
* JVM(HotSpot、JRockitなど)はスタックマシン
* アクセススピードがレジスタマシンよりは遅い
* ハードウェア非依存

## 以下φ(｀д´)ﾒﾓﾒﾓ...
* GlassFish商用版→WebLogic。ちなみにWebLogicはOracle。