# AWS SSHログイン
1. .pemファイルを入手する
2. .pemファイルを~/.sshに移動
3. パーミッションを600にする
4. ssh -i ~/.ssh/HADO-key.pem ec2-user@xxx.xxx.xxx.xxx
    * EC2のデフォルトユーザはec2-user