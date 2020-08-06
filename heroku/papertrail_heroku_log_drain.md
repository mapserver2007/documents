# PaperTrail連携
参考：http://help.papertrailapp.com/kb/hosting-services/heroku

## Addonを使う
HerokuアプリにAdd-on「Papertrail」入れるだけで完了。  
特になんの設定もせずsyslogが自動送信される。  
ただし、複数のHerokuアプリで共用することができない。  
たとえばバッチアプリAとバッチアプリBに対してそれぞれにPaperTrailアドオンをインストールすると、片方にしかログインできない。全く違うアプリであっても同様。

## Heroku Log Drainを使う
Herokuのログドレイン機能を使う。  
Heroku経由ではなく、自身のアカウントでPaperTrailにログインし、ホスト名とポート番号を取得する。  
そして、URIをローカルマシンで指定。複数アプリがある場合はアプリ名だけ変更して実行。

```
heroku drains:add syslog+tls://logs.papertrailapp.com:12345 --app myapp
```

すると、複数のアプリが1つのPaperTrailダッシュボードに集約される。
