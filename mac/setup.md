# Macセットアップ

## 基本設定

### キーバインド変更
* システム環境設定 -> キーボード -> 修飾キー
    * ControlとCommandを入れ替える

## 開発系設定

### brew
そのままアップデートすると、
```sh
xcrun: error: invalid active developer path (/Library/Developer/CommandLineTools), missing xcrun at: /Library/Developer/CommandLineTools/usr/bin/xcrun
Error: Failure while executing; `git config --local --replace-all homebrew.analyticsmessage true` exited with 1.
```
になったので、
```sh
$> xcode-select --install
```
を実行する。

```sh
$> brew update
$> brew -v
Homebrew 2.0.5
Homebrew/homebrew-core (git revision 5cb6e; last commit 2019-03-19)
Homebrew/homebrew-cask (git revision 751d; last commit 2019-03-19)
```

### Homebrew Cask
```sh
$> brew tap caskroom/cask
$> brew tap caskroom/versions
```

### Node.js
公式サイトから落としてインストール。

### nvm
インストールはアップデートを考慮するとgitからが良い。

```sh
export NVM_DIR="$HOME/.nvm" && (
  git clone https://github.com/creationix/nvm.git "$NVM_DIR"
  cd "$NVM_DIR"
  git checkout `git describe --abbrev=0 --tags --match "v[0-9]*" $(git rev-list --tags --max-count=1)`
) && \. "$NVM_DIR/nvm.sh"
```

nvmのアップデート。
```sh
export NVM_DIR="$HOME/.nvm" && (
  cd "$NVM_DIR"
  git fetch --tags origin
  git checkout `git describe --abbrev=0 --tags --match "v[0-9]*" $(git rev-list --tags --max-count=1)`
) && \. "$NVM_DIR/nvm.sh"
```

```sh
$> nvm --version
$> 0.33.11
```

nvmでnode.jsをインストール。  
nvmのnodeのパスが有効になっていることを確認する。

```sh
$> nvm install stable
$> nvm alias default stable
$> which node
/Users/mapserver2007/.nvm/versions/node/v10.12.0/bin/node
$> nvm list
         v5.7.1
->     v10.12.0
         system
default -> v5.7.1
node -> stable (-> v10.12.0) (default)
stable -> 10.12 (-> v10.12.0) (default)
iojs -> N/A (default)
lts/* -> lts/carbon (-> N/A)
lts/argon -> v4.9.1 (-> N/A)
lts/boron -> v6.14.4 (-> N/A)
lts/carbon -> v8.12.0 (-> N/A)
```

## インストールするbrewパッケージ
* gibo
  * gitignore自動生成

## インストールするアプリ

### 開発系
* Visual Studio Code
* Intellj IDEA
* iTerm
* MongoDB Compass
* MySQL WorkBench
* DBeaver
* Sourcetree

### 一般系
* CLCL
    * キーボードショートカット。2つしか割り当てできない。
* Clipy
    * クリップボード履歴
    * Shift+Control+vを割り当て
* CotEditor
    * Terapad, サクラエディタの代替
    * CLCL割当
* Chrome
* Gom Player 