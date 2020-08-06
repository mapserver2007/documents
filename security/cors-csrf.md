# SPAにおけるCSRF

* SPAでは通常のWebページのようにトークンをhiddenに仕込んで照合する方法が取りにくい
* どうやってCSRFの対策をするべきか

## CORS(Corss Origin Resource Sharing)
### CORSとは
* SPAではform(x-www-form-urlencoded)ではなくXHR,fetchで非同期通信する
* 異なるオリジンに対しての非同期通信には必ずCORSを入れることになる。このCORSがSPAでトークンを使わないCSRF対策の根幹となる
    * オリジン：スキーム、ホスト、ポートの組み合わせのこと
* CORSはAccess-Control-Allow-Originレスポンスヘッダを使ってアクセスを許可するサーバ側が設定する
    * Cross-Origin-Resource-Sharing＝「リソースの読み込み」を制御するだけであり、アクセス自体はできる

### CORSだけでは不十分な理由
* 


## プリフライトリクエスト
* クロスドメインなリソースへのアクセスについて、通信手順は2つある
    1. 直接クロスドメインのリソースにアクセスする通信を実行する
    2. クロスドメインアクセスが可能かどうかチェック用の通信を行い、その後改めてリソースアクセスの通信を実行する(プリフライトリクエスト)
* プリフライトリクエストは「Option」メソッドで実行する
* プリフライトリクエストを自分で書く必要はなく、ブラウザが勝手に実行する
* プリフライトリクエストが送られる条件は以下の通り
    * HTTPメソッドがGET/POST/HEAD以外の場合
    * HTTPヘッダにAccept、Accept-Language、Content-Language、Content-Type以外のヘッダが指定された場合
    * Content-Typeがapplication/-www-form-urlencoded, multipart/form-data, text/plainのいずれか以外が指定された場合



## 参考サイト
* https://numb86-tech.hatenablog.com/entry/2019/02/13/221458