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
if [ -d $HOME/.anyenv ] ; then
    export PATH="$HOME/.anyenv/bin:$PATH"
    eval "$(anyenv init - --no-rehash)"
fi
```


## rbenv、phpenvインストール
```bash
$> anyenv install rbenv
$> anyenv install phpenv
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
