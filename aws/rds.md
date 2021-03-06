# Amazon RDS

## インスタンスクラス
* バースト可能インスタンス
    * https://dev.classmethod.jp/cloud/aws/rds_gp2_iocreditbarance/
    * t2.microなどが該当
    * バーストとは、利用しているボリュームのベースラインパフォーマンスを超えたI/O性能を発揮させること
    * ベースラインパフォーマンスを超えたI/Oが発生した場合、超過分のI/Oクレジットが消費されるタイプのインスタンス
        * 540万I/Oが初期値
    * ベースラインを下回った場合、クレジットは補充される

## レプリケーション
* https://dev.classmethod.jp/cloud/amazon-rds-replication/

## フェイルオーバーについて
* Masterがクラッシュした場合、下記が実行される
    * Masterへの書き込み停止
    * SlaveのIPアドレスの付替え
    * SlaveがMasterへ昇格
* 大体3,4分程度
* 「Reboot DB Instances」で強制的にフェイルオーバーを起こせるらしいのでテストはできる

## MultiAZのレプリケーション
* いわゆるMaster-SlaveのSlave(パフォーマンス)ではなく、耐障害性のレプリカ
* 待機系を用意している
    * 待機しているDBへのアクセスは不可
* 同期レプリケーション
    * 非同期に比べてパフォーマンスは落ちる(十分高速)
* 自動フェイルオーバー
    * インスタンスが落ちたとき
    * ハードウェア障害時
    * AWSのメンテナンス
    * 手動再起動時に強制フェイルオーバー設定しているとき

## リードレプリカ
* 読み込み専用のDB
    * これがいわゆる書き込み不可のSlaveと同じ役割
    * 非同期レプリケーション
    * MultiAZ構成のSlaveは利用者アクセス不可だがリードレプリカは可能
    * パフォーマンス目的

## MultiAZ、レプリカのマスタ昇格について
* MultiAZはAZ自体に障害が起きたときにAZ1を放棄してAZ2にまるごと切り替える
    * なのでAZごとに同じ構成が作られている
    * RDSについてはメインのAZ1の同期がAZ2になっている
    * DRだけでなく、単純なバックアップ、メンテナンス時に備えられる


## Master, Slave, Replica
* Master
    * マスタ
* Slave
    * いわゆるオンプレでのSlaveとは違い、待機系のマスタという意味
    * Slaveはデータ同期、自動フェイルオーバーのために用意する
* Replica
    * いわゆるオンプレでのSlaveに相当で、書き込み不可
    * 5台までデフォルト可


## DBのアップデート
* リードレプリカのマスタ昇格を利用する
* インスタンスA(M)、インスタンスB(R)がいたとき、
    * インスタンスB


## レプリカのマスタ昇格
* https://qiita.com/shigure_onishi/items/577a56ae80c68f5ae05c
* 