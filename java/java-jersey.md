# Jerseyサンプル

## Mavenをインストール
    $ brew update
    $ brew install maven
`/user/local/Cellar`に書き込み権限がない場合は与えておく。

## Eclipse Mavenプラグインインストール
* Eclipseの[新規ソフトウェアのインストール]を開く。
* プルダウンの[Luna - http://download.eclipse.org/releases/luna]を選択、[一般用ツール]→[m2e - Eclipse用Maven統合]をインストール。

## Tomcatインストール
    $ brew install tomcat
    $ catalina start

## Tomcat Sysdeoプラグインインストール
* 

## Mavenプロジェクト作成
* アーキタイプはmaven-archetype-webappを選択
* デフォルトではJREが1.5になっているので1.8に切り替える