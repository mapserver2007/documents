# anyenv設定
phpenvとrbenvを同一環境に入れるとうまく読み込めなくなるため、anyenvで管理する。

## rbenv、phpenvを削除
すでに環境に入っている場合は一旦削除する。

```bash
$> rm -f ~/.phpenv
$> rm -f ~/.rbenv
```

## anyenvインストール

```bash
$> git clone https://github.com/riywo/anyenv ~/.anyenv
```

.bashrcを編集して読み込む。

```bash
if [ -d $HOME/.anyenv ] ; then
    export PATH="$HOME/.anyenv/bin:$PATH"
    eval "$(anyenv init - --no-rehash)"
fi
```

## **envインストール
```bash
$> anyenv install rbenv
$> anyenv install phpenv
$> anyenv install jenv
$> exec $SHELL -l
```

## rbenv-updateインストール
```bash
$> git clone https://github.com/rkh/rbenv-update.git "$(rbenv root)/plugins/rbenv-update"
$> rbenv update
```

## Rubyインストール
```bash
$> rbenv install 2.3.6
$> rbenv global 2.3.6
```

## Javaインストール
Homebrew cask経由でインストールする。

```bash
$> brew cask install java
$> /usr/libexec/java_home -V
Matching Java Virtual Machines (4):
    11.0.1, x86_64:	"OpenJDK 11.0.1"	/Library/Java/JavaVirtualMachines/openjdk-11.0.1.jdk/Contents/Home
    1.8.0_11, x86_64:	"Java SE 8"	/Library/Java/JavaVirtualMachines/jdk1.8.0_11.jdk/Contents/Home
    1.8.0, x86_64:	"Java SE 8"	/Library/Java/JavaVirtualMachines/jdk1.8.0.jdk/Contents/Home
    1.7.0_71, x86_64:	"Java SE 7"	/Library/Java/JavaVirtualMachines/jdk1.7.0_71.jdk/Contents/Home
```

インストールしたJavaをjenvに設定する。

```sh
$> jenv add /Library/Java/JavaVirtualMachines/openjdk-11.0.1.jdk/Contents/Home
$> jenv versions
* system (set by /Users/mapserver2007/.anyenv/envs/jenv/version)
  11.0
  11.0.1
  openjdk64-11.0.1
```

任意のJDKをインストールする。http://jdk.java.net/ からJDKをダウンロードし、`/Library/Java/JavaVirtualMachines/`に配置する。  
配置したJDKをjenvで設定する。

```sh
$> sudo mv jdk-10.0.1.jdk/ /Library/Java/JavaVirtualMachines/
$> jenv add /Library/Java/JavaVirtualMachines/jdk-10.0.1.jdk/Contents/Home
$> jenv global 10.0.1
$> java -version
openjdk version "10.0.1" 2018-04-17
OpenJDK Runtime Environment (build 10.0.1+10)
OpenJDK 64-Bit Server VM (build 10.0.1+10, mixed mode)
```

### OpenJDKでSSLHandshakeエラーになる場合
SSL証明書がインストールされていないため発生する。OracleJDKの場合はインストール済み。  
以下の手順で設定する。
* https://github.com/escline/InstallCert をcloneする
* $> javac InstallCert.java
* $> java InstallCert xxxxxxxxxxxxxxx.com:443

## PHPインストール
```bash
$> phpenv install 7.2.3
```

しかし、インストール途中で失敗するので、
```bash
$ echo -e "--with-openssl=$(brew --prefix openssl)\n--with-libxml-dir=$(brew --prefix libxml2)\n--with-mcrypt=$(brew --prefix mcrypt)"
--with-openssl=/usr/local/opt/openssl
--with-libxml-dir=/usr/local/Cellar/libxml2/2.9.7
--with-mcrypt=/usr/local/opt/mcrypt
```
このパスを設定する。
```bash
$> ~/.anyenv/envs/phpenv/plugins/php-build/share/php-build/default_configure_options
```

参考：
https://qiita.com/kawakami-kazuyoshi/items/bd148312815fb75818ee
