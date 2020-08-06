# AWS Site to Site VPN

* AWS側
    * 172.*.0.0/* のように切っておく
    * AWS側のIP体系とローカルネットワークのIP体系は重複しないようにする

## VPNの概要
* VPNはIPSecというプロトコルで通信する
* IPSecmは通信相手(ピア)との間でSA(Security Association)という論理的コネクションを確立する必要がある
* SAはVPN通信のコネクション単位で確立される
* SAはトラフィック情報、暗号、認証などの情報が含まれる

## IKE(Internet Key Exchange)
* IKEフェーズ1, 2がある
* IKEフェーズ1
    * 鍵交換のためのトンネリング
    * 確立すると1日は切断されない
* IKEフェーズ2
    * IPSec SA
    * データ通信用のトンネリング
    * 確立すると一定時間で切断される

## AWS側のVPN設定
* Pre-Shared-Key
    * ランダム文字列。こちらで指定する
* トンネリングに使用するIP
    * 入り口、出口でそれぞれ1つ
    * CIDRは/30(4つ)でOK