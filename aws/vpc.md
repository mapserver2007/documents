# AWSのネットワークについて

## VPC(Virtual Private Cloud)
* VPCはAWS専用の仮想ネットワーク
* VPCの接続範囲はIPv4アドレスの範囲で指定する
* VPCは同一リージョンのAZ全てに有効、1つのサブネットは複数のAZにまたがることはできない
* VPC間は同一IPの場合、通信できない。そのためVPCごとに同じIPアドレスを作っても動くが、AmazonはIPアドレスを重複させないことを推奨している
    * VPCピア通信という
    * VPC間通信はできたほうがいい(プロジェクトに複数のVPCをもたせた場合、システム間連携が発生したとき厳しい)
    * https://dev.classmethod.jp/cloud/aws/vpc-cidr/
* VPC内部はルーティング可能、VPC間はルーティング不可
    * VPC内でのアクセス制御はACL(アクセスコントロールリスト)を使う

## セキュリティグループ
* 同一グループ外のインスタンスと通信する際のファイアウォール
* セキュリティグループはサブネットレベルではなく、インスタンスレベルで設定する
* インバウンド、アウトバウンドの2種類を設定する
    * 基本的にはインバウンド(外から内)を制限する
* 何も設定しないとデフォルトのセキュリティグループが設定される
    * 同一グループ内通信はすべて許可、グループ外からのインバウンド通信はすべて拒否

## セキュリティグループとACLの違い
* https://dev.classmethod.jp/cloud/amazon-vpc-acl/
* ACLはサブネット単位なので、配下のインスタンス全てに影響する
* セキュリティグループはインスタンス単位


## サブネット
* Web

## ルートテーブル


## 設計メモ
### VPC
* VPCは大システムで1つもてばよさそう
    * 小システムはサブネットで分割
* ただし大システム間連携がありえるのならCIDRは重複しないようにしとく

### サブネット
* パブリックサブネット
    * インターネット公開のWebサーバ
* プライベートサブネット
    * RDS

https://dev.classmethod.jp/cloud/amazon-vpc-security-group/


