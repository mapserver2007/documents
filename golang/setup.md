# golang setup

## Goインストール
```
$> brew install go
$> $ go version
go version go1.14.4 darwin/amd64
```

## GOPATH設定
.bashrcに以下を追記

```
export GOPATH=$HOME/workspace_go/
export PATH=$GOPATH/bin:$PATH
export GO111MODULE=on
```

## go mod設定
```
$> cd workspace_go
$> go mod init github.com/mapserver2007/golang-example-app
```
go.modが作成される。



