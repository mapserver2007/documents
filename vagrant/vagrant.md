# Vagrant導入メモ
*ドキュメントじゃなくてメモ。*

## ドットインストール動画
[http://dotinstall.com/lessons/basic_vagrant/24101](http://dotinstall.com/lessons/basic_vagrant/24101)

## インストール
### VirtualBox
* [https://www.virtualbox.org/wiki/Downloads](https://www.virtualbox.org/wiki/Downloads)
* 普通にインストールするだけで終了

### Vagrant
* [http://downloads.vagrantup.com/](http://downloads.vagrantup.com/)
* これも普通にインストールするだけ
* ターミナルで`vagrant --version`でバージョンが確認できる

## 設定
### 仮想マシンの設定
* Boxを入手する
    * Boxとはインスタンス生成のためのテンプレート
    * `vagrant box add (Box名)`
    * ~/.vagrantに作成される
    * とりあえずboxは`precise64`で試す
    * `vagrant box add ubuntu-12.04 http://files.vagrantup.com/precise64.box`
    * `vagrant box list`でインストールしたboxが確認できる
    * [Vagrantbox.es](http://www.vagrantbox.es/)
    * vagrant boxがたくさんある
    * Ubuntu12.10を入れてみる
    * `vagrant box add ubuntu-12.10 http://cloud-images.ubuntu.com/quantal/current/quantal-server-cloudimg-vagrant-i386-disk1.box`
        * 13.04もあったが、12.10のブラッシュアップ版かつサポート9ヶ月だったので12.10にした
* 仮想マシン初期化
    * テンプレートと仮想マシンは1対1ではなく、一つのテンプレートから複数の仮想マシンを作ることも可能
    * 仮想マシン用のディレクトリを作る
    * `${HOME}/Vagrant/Ubuntu1210`を作り、移動する
    * `vagrant init ubuntu-12.10`
    * 作成されたVagrantfileはRubyのファイル
    * `vagrant up`で仮想マシンが作成される
        * SSHタイムアウトする場合、config.ssh.timeout設定を変更するか、sshd_configにUseDNS noを追加する
    * VirtualBox上に仮想マシンが追加されている
* 仮想マシンにログイン
    * `vagrant ssh`
    * `192.168.0.5`

## プラグイン
### sahara
スナップショットがとれる。
[http://girigiribauer.com/archives/1003](http://girigiribauer.com/archives/1003)  

* `git clone https://github.com/ryuzee/sahara.git`
* `bundle exec rake build`
* `vagrant plugin install pkg/sahara-0.0.15.gem`
* `vagrant plugin list`
プラグインがインストールされていることを確認する。

### MySQL
* `vagrant sandbox on`でサンドボックスモードにしておく
* `vagrant ssh`でログインし、`sudo apt-get install mysql-server`を実行
* Vagrantfileに`config.vm.network :public_network, ip: "192.168.0.200"`を追加し、Bridgeで接続する
* vagrantのMySQL設定ファイル(my.cnf)に`bind-address  = 0.0.0.0`追加
* MySQLのGRANTで、`GRANT ALL PRIVILEGES ON *.* TO root@'%' IDENTIFIED BY 'root' WITH GRANT OPTION`を実行
* MySQL WorkBenchをダウンロードし、接続する
    * Standard(TCP/IP), 192.168.0.200:3366
* トランザクションを有効にするためInnoDBを有効にする

### PostgreSQL
* `sudo apt-get install postgresql`
* `sudo apt-get install pgadmin3`
* 自動的にpostgresユーザが作られているので、パスワードを変更する。`sudo passwd postgres`
* `su postgres`でpostgresユーザになる
* `createdb T_WebStream`でDB作成





