# プロビジョニングツールまとめ
プロビジョニングとは

```
複数のサーバやネットワーク、アプリケーション、ストレージなどのリソースを仮想化によって一つのコンピュータリソースとみなし、ユーザから要求があった場合や障害時などに、必要な分だけ、コンピュータリソースを動的に別のシステムに割り当てられるようにすること。
```

要するに、OSインストール後のミドルの設定の自動化、リソースの動的なな割り当てとかそういうことの総称。

## Puppet
* 古いっぽい
* それなりにめんどくさいらしい(http://www.slideshare.net/winebarrel/2013-0720-chefpuppet)
* Puppetは外部DSL(http://blog.kubox.info/2012/12/chefpuppet.html)
    * Chefは内部DSL。だがこのへんはどっちも大してかわらないっぽい
    * 内部DSLとはRails、ActiveRecord、Rake、RSpecなどの独自の記述ができるアレのこと。これができないとかなり面倒


## Chef

## Ansible
### Vagrantで仮想環境作成
* `vagrant box add ubuntu-14.10 https://github.com/kraksoft/vagrant-box-ubuntu/releases/download/14.10/ubuntu-14.10-amd64.box`
* `${HOME}/Vagrant/ubuntu1410`で`vagrant init ubuntu-14.10`を実行
* 192.168.0.202

## Docker

## Packer
* DockerfileがなくてもDockerイメージが作れるツール
* Vagrantの作者が作った(Vagrant専用というわけではない)
* TODO まだメリットがよくわからないのでPackerなしでいろいろやったあとにきたい