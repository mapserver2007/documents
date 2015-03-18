# docker

## インストール
```vim
brew update
sudo brew install docker
sudo brew link docker
```

# boot2docker
```vim
# isoイメージDL、VMの作成
sudo brew install boot2docker
boot2docker init
# 起動
boot2docker up
# ログイン
# ID/PWなしでログインできる。rootはdocker/tcuser
boot2docker ssh
```

[boot2dockerでdockerを試す - @znz blog](http://blog.n-z.jp/blog/2014-02-23-boot2docker.html)

# Dockerfile


## ビルド
```vim
# Dockerfileがカレントにいる状態で
docker build -t webstream/test:0.4 .
docker build --no-cache --rm -t webstream/test:0.4 .
docker run -it webstream/test:0.4 /bin/bash
docker run -it -p 8080:80 webstream/test:0.4 /bin/bash

docker run -p 8080:80 -d webstream/test:0.4
docker run -p 8080:80 -d webstream/test:0.4 /etc/init.d/apache2 start && /usr/bin/tail -f /dev/null
docker run -it --name webstream -v "$(pwd)":/usr/src/WebStream -w /usr/src/WebStream php:5.4.36-apache php -v


docker run -d -p 8080:80 --name webstream-test-0.4 php:5.4.36-apache

# dockerコンテナにIPアドレスを設定
pipework br1 cfe81a8c1cc8 192.168.0.220
docker ps -l 1 | awk 'NR>1 {print $1}' | xargs -i{} pipework br1 {} 192.168.0.220


コンテナを一気に削除
docker rm `docker ps -a -q`
docker rmi $(docker images | grep '<none>' | awk '{print$3}')

TSLうんぬん言い始めたら
$(boot2docker shellinit)

 boot2docker ip

```
## イメージを確認
```vim
docker images
```


# fig

docker inspect `dl` | jq '.[] .NetworkSettings |{IPAddress}'

# command
