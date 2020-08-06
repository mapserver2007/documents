# Vagrant on Windows Subsystem for Linuxで開発環境構築

## インストール・有効化
* Windows 10 Anniversary Update (2017/10)のアップデートでインストール済み
* `$> Enable-WindowsOptionalFeature -Online -FeatureName Microsoft-Windows-Subsystem-Linux`で有効にする
* `PC設定`->`更新とセキュリティ`->`開発者向け`->`開発者モード`を有効にする

## 実行
```
$> bash
```
* bashに切り替わる
* `/mnt/c`がマウントされる

## 設定
### ConEmu
* ConEmuでシェルを実行するとき、矢印での入力が効かない
  * https://github.com/Maximus5/ConEmu/issues/629
* `-cur_console:p`をbash起動コマンドにつけると解決する
* https://github.com/mapserver2007/documents/blob/master/powershell/settings.md

### .bashrc
```
alias vi='vim'
alias tt='cd /mnt/c/Users/tanak/Dropbox/workspace/'

VIRTUAL_BOX="/mnt/c/Program Files/Oracle/VirtualBox"
VAGRANT_WSL_WINDOWS_ACCESS_USER_HOME_PATH=/mnt/c/Users/tanak
VAGRANT_WSL_ENABLE_WINDOWS_ACCESS="1"
```

## Vagrantインストール
* `$> wget https://releases.hashicorp.com/vagrant/2.0.0/vagrant_2.0.0_x86_64.deb`
* `$> sudo dpkg -i vagrant_2.0.0_x86_64.deb`
* apt-getからのインストールだとバージョンが古い

## ansibleインストール
* `$> sudo apt-get install -y ansible`

## Vagrant環境構築
* [https://www.virtualbox.org/](https://www.virtualbox.org/)からVirtualBoxをDLしてインストールする
  * 2017年10月時点ではVagrantはVirtualBox5.1までしか対応していないので注意
* bashからWindowsのVirtualBoxにアクセスするためには環境変数設定をしていく
* VAGRANT_WSL_WINDOWS_ACCESS_USER_HOME_PATHにWindows上のホームディレクトリパスを指定する。Ansibleが読みに行くために必要
  * `VAGRANT_WSL_ENABLE_WINDOWS_ACCESS="1"`
  * `VAGRANT_WSL_WINDOWS_ACCESS_USER_HOME_PATH=/mnt/c/Users/(ユーザ名)`
* Vagrantfile内のパス設定はWindowsで読めるパスにしておく必要がある

## Mac/Windowsでの差異

```
├── env
│   ├── mac
│   │   └── Vagrantfile
│   └── windows
│       └── Vagrantfile
└── setup
    ├── roles
    │   ├── build
    │   │   └── tasks
    │   │       └── main.yml
    │   ├── initialize
    │   │   ├── files
    │   │   │   └── docker.repo
    │   │   └── tasks
    │   │       └── main.yml
    │   ├── pull
    │   │   └── tasks
    │   │       └── main.yml
    │   └── run
    │       ├── files
    │       │   └── docker-compose.yml
    │       ├── tasks
    │       │   └── main.yml
    │       └── vars
    │           └── main.yml
    └── setup.yml
```
* envディレクトリでそれぞれ管理し、それぞれの環境の.vagrantディレクトリで構築する
* ソースコードはDropboxで共有し、それぞれのPCに全く同じ環境を構築できる
