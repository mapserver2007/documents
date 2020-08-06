# サブネット設計

## 全環境で統一する
* 開発
* ステージング(任意)
* 本番

## 4つの役割でサブネットを分割(理想形)
* public
    * インターネットに接続したサブネット
    * LB, 踏み台、NAT、Proxy
* private
    * Webサーバ
* protected
    * DBサーバ
* managed
    * バッチ、監視など

## 現実に合わせる
* 現フェーズではprotected, managedはいらない
* public
    * Webサーバ(APサーバ)
* private
    * DBサーバ、バッチ


参考：
https://qiita.com/takuya_tsurumi/items/77f246c0ad4bc8caf234