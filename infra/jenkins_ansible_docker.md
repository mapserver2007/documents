# Jenkins+Docker+Ansibleで全自動テスト環境を作る

## やりたいこと
* ホストは汚さない
    * Jenkinsは仮想環境内で動かす
* テスト対象ソースをgitで持ってくる
* テスト実行環境はdocker内に閉じ込める
    * Jenkinsが動く仮想環境でdockerを動かす
    * テスト開始時にdockerコンテナを作成する
    * テストが終わったらdockerコンテナは破棄する
* テスト結果をJenkinsで集計
    * JUnit形式のXMLをdockerからJenkins仮想環境へ転送
    * テスト結果はJenkinsから読める形式のファイルで出力する(JUnit形式XML等)
* Jenkinsのバックアップファイルをホストへ転送
    * 定期/任意でジョブなどの情報をバックアップし、仮想環境外へ転送

## 得られること
* テスト環境の復元、破棄が楽
    * テストを実行する環境、管理する環境が仮想環境なので、ポータビリティが高い
    * コマンド一発で破棄、復元できる
* 「疎」なテスト環境
    * データベースなど特定のテストデータが必要でもテスト対象アプリケーションごとに用意できて互いに影響を与えない
    * 同じソースコードに対して異なるミドルウェアを使うことができる
    * コンテナ間で通信はできるので、必要に応じてデータのやり取りができる
* 手順が少なくて済む
    * 開発環境構築の手順をansible playbookまたはDockerfileに閉じ込めているため基本的にコマンドを1つ実行するだけで終わる

## CI用の仮想環境を作る
* https://github.com/mapserver2007/infrastructure/blob/master/ci/Vagrantfile
* VagrantでCentOS7をインストール
* `vagrant up`、`vagrant provision`で環境を自動構築
    * git、ansible、dockerなどをインストール
    * jenkins、jenkins-pluginをインストール
* `http://192.168.0.207:8080`でJenkinsにアクセス

## テスト対象プロジェクトについて
* テスト対象(https://github.com/webstream-framework)
    * PHP製の自作フレームワーク
    * PHPUnitのテストコードがある
    * 本体、テストコード、実行環境(ansible+dockerで構成)は別リポジトリ
* ローカルでのテスト方法(PHPUnit/Phing)
    * `git clone https://github.com/webstream-framework/infrastructure.git`
    * `dev/Vagrantfile`を`vagrant up`する
        * CI環境に相当する仮想環境を起動
    * sshログインし、`sudo docker ps`でdockerコンテナが起動しているを確認
    * `sudo docker exec -it webstream bash`でdockerコンテナに入り、`cd /mnt/docker/apache/www/webstream-framework/Test`に移動する
    * `vendor/bin/phpunit Test/Hoge.php`でPHPUnitの単体テスト、`vender/bin/phing -f build.xml`でPhingによる一括テストが実行可能
    * テストプロジェクトの環境構築の内部動作については[こちら]

## テストを実行する
* Jenkinsで新規ジョブを作成する
* `Git`で`https://github.com/webstream-framework/infrastructure.git`の`*/master`を指定
* シェルスクリプト実行で以下を指定

```bash
sudo ansible-playbook -i "localhost," ansible/setup.yml
sudo docker exec webstream bash -c "cd /mnt/docker/apache/www/webstream-framework/Test/ && vendor/bin/phing -f build.xml"
sudo docker cp webstream:/mnt/docker/apache/www/webstream-framework/Test/reports/phpunit.xml .
```

* テスト結果の集計で`phpunit.xml`を指定

## Jenkinsのジョブのバックアップ
* https://wiki.jenkins-ci.org/display/JENKINS/thinBackup
* バックアップファイルはホストへ同期させる必要があるので、Vagrantfileにsynced_folderを設定する
    * ホスト側に持ってきたバックアップファイルは適当なクラウドサービスにでも保存しておけばよい

## テストプロジェクトの環境構築の内部動作
テスト対象プロジェクトをテストするには`vagrant up`してdockerコンテナに入ってコマンドを叩くだけだが、それを構築するまでに相当の手間がかかってるんので解説する。

### 内部動作概要
* ソースコード全体は以下の3つで構成
    * 本体プロジェクト
    * テストコードプロジェクト
    * インフラ環境プロジェクト
* はじめにインフラ構築用のプロジェクトを`git clone`してくる
    * ローカルで実行する場合、Vagrant仮想環境を作り、そこに対してプロビジョニングする
    * 本番(CI)で実行する場合、localhostに対してプロビジョニングする
* `ansible`を使って実行環境構築を行う
    * `vagrant up`または`vagrant provision`により、ansible playbookが実行される
* dockerコンテナを作成する
    * データ格納専用コンテナ(Data only container)
    * MySQLコンテナ(Data only containerを使用)
    * PostgreSQLコンテナ(Data only containerを使用)
    * SQLiteコンテナ
    * PHP+Apacheコンテナ
        * PHPとApacheは分離できなかった
* テスト対象プロジェクト(以下、WebStreamコンテナ)用コンテナを作成
    * PHP+Apacheコンテナをベースのコンテナにする
    * PHP+ApacheコンテナとMySQL,PostgreSQLコンテナをlinkで接続(TCP)
        * MySQL,PostgreSQLはTCPでアクセスできる
    * PHP+Apacheコンテナに対してSQLiteコンテナをマウント
        * SQLiteは物理的なファイルとしてしか参照できない
    * 80番ポートを開けて`docker run`
* WebStreamコンテナをプロビジョニング
    * WebStreamコンテナにプロビジョニング用ansible playbookを送信(`docker exec`経由で送信)
    * 送信したansible playbookを実行(`docker exec`経由で実行)
        * MySQLの初期設定、DB、テーブル作成
        * PostgreSQLの初期設定、DB、テーブル作成
        * SQLiteの初期設定、DB、テーブル作成
        * WebStreamテストプロジェクトを`git clone`
            * テストプロジェクト内で本体が自動的に`git clone`される
        * WebStreamの初期設定(`composer install`)

上記が完了すると、`docker exec`経由でテストが実行可能となる

### 使い捨ての環境
原則的にテストを実行する度に環境を再構築する。
従って、常にクリーンな環境(ゴミファイルが残っていない環境)でのテストとなるので、常に同じ環境下でテストができる。

### この方式のメリット
* プロビジョニングを全面的にansibleに委譲しているので、プロビジョニング内容の見通しが良い
* ansibleを使用するので冪等性が確保できる
* Dockerfileがシンプルで済む
* データベースを含めてコンテナ化できていて、データ部分だけは分離(バックアップ・リストア可能)

### この方式のデメリット
* `docker run`時のコストが高い
    * 毎回動的にプロビジョニングするため
    * 本来は`docker build`が高コストで`docker run`は低コスト
* Dockerfileの「継承」ができない
    * dockerのメリット一つであるDockerfileの再利用性が失われている
    * 今回の環境を継承して、ということが難しい

### 所感
* Dockerfileの編集が非常に辛い
    * これが根底にある
    * 対してansible playbookの編集の簡単さ
    * そもそもコンテナをつなぎあわせたり複雑なことをやっているのでDockerfileだけではもともとできない点も多い
* ビルド、テストの時間がある程度かかってもいいならこのやり方はあり
    * ミドルウェアを使いまくらないテストであればそこまで複雑ではない

### 苦労した点
* ansibleのプロビジョニングは結構時間が掛かる
    * `vagrant destroy`を繰り返してまっさらにすると都度ソースを取ってくる
    * `docker build`、`docker run`もそれなりに時間が掛かる
    * なので、`vagrant provision`したらしばらく放置してアニメでもみてればいいと思う
        * さすがに30分はかからない(いまのところ)
* 秘伝のタレになる
    * 複雑な構成(コンテナの結合、設定ファイル動的書き換え)をplaybookに書くので、だんだんと秘伝のタレと化してくる
    * それでもansibleはこの手の最良解に近いと思う
    * これが手動で手順書見ながらの設定とかさすがに考えられない
* `shell`、`command`は冪等性の保証がされないので注意
    * ansibleのdocker設定はしょぼくてほとんど使えない
    * 結局複雑な操作はみんなshell経由で`sudo docker`することになるが、冪等性もクソもない
        * 解決策あるのこれ
