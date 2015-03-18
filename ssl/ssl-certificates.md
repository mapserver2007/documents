# SSL証明書について

## 参考サイト
* [OpenSSLについて](http://ash.jp/sec/openssl.htm)
* [node.jsによるHTTPSサーバの作り方 - Node.js/JavaScript入門](http://kaworu.jpn.org/javascript/node.js%E3%81%AB%E3%82%88%E3%82%8BHTTPS%E3%82%B5%E3%83%BC%E3%83%90%E3%81%AE%E4%BD%9C%E3%82%8A%E6%96%B9)

## SSL自己証明書
### 作成コマンド
```text
openssl genrsa -out server.key 2048
openssl req -new -x509 -days 3650 -key server.key -out server.crt -subj '/CN=localhost'
```
* req 証明書の署名要求(CSR)の作成
* -new 新規作成
* -key 入力する秘密鍵のファイル名
* -x509 [X.509証明書](http://ja.wikipedia.org/wiki/X.509)形式の証明書要求ファイルを作成する
* -days 有効な日数
* -out 出力する証明書要求のファイル名


may also be true if this endpoint started the closing handshake since the other endpoint may not simply echo the <code>code</code> but close the connection the same time this endpoint does do but with an other <code>code</code>.
説明  リソース    パス  ロケーション  型
Potentially insecure random numbers on Android 4.3 and older. Read https://android-developers.blogspot.com/2013/08/some-securerandom-thoughts.html for more info.   ConnectionService.java  /imadoko-android-app/src/com/imadoko/service    行 388   Android Lint 問題
