# Windows10セットアップ

## ツール系
* [Classic Shell](http://www.classicshell.net/)
	* スタートメニューなどがWindows7風になる
* [CraftLaunch](https://sites.google.com/site/craftware/clnch)
	* キーボードランチャー
* [CLaunch](http://forest.watch.impress.co.jp/library/software/claunch/)
	* ランチャー
* [Lhaplus](https://lhaplus.softonic.jp/)
	* 解凍圧縮はこれでOK
* [Google日本語入力](https://www.google.co.jp/ime/)
	* IMEはこれ
* [CLISM](http://toro.d.dooo.jp/slwin4.html#clismex3)
	* クリップボードに履歴を持てる

## ブラウザ系
* [Google Chrome](https://www.google.co.jp/chrome/browser/desktop/)
	* Chrome

## エディタ系
* [TeraPad](http://www5f.biglobe.ne.jp/~t-susumu/)
	* 説明不要なエディタ
* [サクラエディタ](http://sakura-editor.sourceforge.net/)
	* 説明不要なエディタ2
* [Atom](https://atom.io/)
	* メインエディタ。詳細設定は[こちら](https://github.com/mapserver2007/my-editor-settings/tree/master/atom)

## 開発系
* [Git for Windows](https://git-for-windows.github.io/)
	* Git
* [Java(JDK)](http://www.oracle.com/technetwork/java/javase/downloads/jdk8-downloads-2133151.html)
    * インストーラで入れる
* [PHP](http://windows.php.net/download#php-7.0)
	* Cドライブ直下にphp70を作り、配置してパスを通す
* [Composer](https://getcomposer.org/doc/00-intro.md#installation-windows)
	* Atom用に入れる
	* php.iniで`extension_dir`、`extension=php_openssl.dll`を有効にする
* [Ruby](https://rubyinstaller.org/)
	* インストーラで入れる
* [node.js](https://nodejs.org/ja/)
	* インストーラで入れる
* [Python](https://www.python.org/downloads/windows/)
	* 開発は特にしないので2系をいれておく
* [ConEmu](https://conemu.github.io/)
	* [詳細設定](https://github.com/mapserver2007/documents/blob/master/powershell/settings.md)
* Visual Studio
	* Professionalを入れる

## 以下未設定

* SQLServer
* VitualBox
* Vagrant
* git
* SourceTree
* ProcessExplorer


--
idea.vmoptions
-Xms512m
-Xmx2048m
-XX:MaxPermSize=512m
