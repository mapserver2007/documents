# 用語など

## 参考サイト
* https://techblog.kayac.com/migration-gopath-to-go-modules

## GO111MODULE
* Go modulesを使うかどうかの環境変数
  * on: Go modulesを使う (module-aware mode)
  * off: $GOPATHを使う (GOPATH mode)
  * auto: $GOPATH/srcの外にリポジトリがある、かつ、go.modが存在する場合、module-aware mode。そうでない場合、GOPATH mode
* $GO111MODULE=on
  * 依存関係の解決に$GOPATHを使わなくてもいける
* 1.13から

## GOPATH
### 2018年までのGOPATH
* 従来は`GOPATH=$HOME/go`のように設定して、`go get`すると`$GOPATH/src`に依存関係のあるモジュール(ライブラリ)がダウンロード、パスを通す仕組みだった
  * なのでsrc配下が大量の依存ライブラリで埋め尽くされる
  * nodeと同じ
* GO11MODULEの登場により、src配下から逃がすことができるようになった
  * GO11MODULE=onだと依存ライブラリをgit cloneしてくるわけではなくなった(`$GOPATH/pkg/mod`配下に.gitがなくなっている)

## dep
* Go modules以前の依存関係管理ツール
* 古いのでもう使う必要がない

## ディレクトリ構成
* $HOME/{GOのワークスペース}に、`bin`,`pkg`,`src`が自動生成される
* プロジェクトはsrc配下だが、個人のgithubを使う場合、`src/github.com/{username}/{projectname}`となる。
* つまり、プロジェクトを増やしていくのはusername配下になっていく

## gRPC, protobuf
* https://qiita.com/Hiraku/items/7c8f56e8564158c895f9
* .protoファイルをまずは作る