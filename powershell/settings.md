# PowerShell設定メモ
デフォルトのPowerShellをカスタマイズ。
* デフォルトだと機能が少ないのでスクリプトを足したい
* 色がダサい、フォントがダサい
* タブを複数開けない

## 高機能ターミナルConEmu
以下の点がGOOD。
* ConEmu経由でPowerShellやコマンドプロンプトが開ける
* 見た目を変えられる(色、フォント、透過など)
* 複数タブ開き可能

### ダウンロード・インストール
[http://conemu.github.io/en/Downloads.html](http://conemu.github.io/en/Downloads.html)よりダウンロードしてインストール。

### フォントインストール
MSゴシックやMS明朝は汚いので見栄えのいい日本語等幅フォントを入れる。  
[http://mix-mplus-ipa.sourceforge.jp/migu/](http://mix-mplus-ipa.sourceforge.jp/migu/)よりMiguフォントをインストールする。

### PoserShell4.0インストール
.NET Framework4.5以上が必要。  
入っていなければ[https://www.microsoft.com/ja-jp/download/details.aspx?id=40855]( https://www.microsoft.com/ja-jp/download/details.aspx?id=40855)から「Wndows6.1-KB2819745-x64-MultiPkg.msu」をダウンロードしてインストール。  

以下のPowerShell拡張を入れておく。
* PsGet
    * モジュールを簡単にインストールするために入れる
    * [http://psget.net/](http://psget.net/)
    * `$> (new-object Net.WebClient).DownloadString("http://psget.net/GetPsGet.ps1") | iex`
    * `$> import-module PsGet`
* PSReadLine
    * コマンドラインを強化(ReadLineライクになる)。Ctrl+Spaceで補完してくれたり、Ctrl+Lでクリアしてくれたり
    * [https://github.com/lzybkr/PSReadLine](https://github.com/lzybkr/PSReadLine)
    * `$> Install-Module PSReadline`
    * `$> Import-Module PSReadline`
* PoshGit
    * PowerShell用のGitクライアント拡張
    * [https://github.com/dahlbyk/posh-git](https://github.com/dahlbyk/posh-git)
    * `$> Install-Module posh-git`

### ConEmu設定

| 設定の種類       | 設定箇所                                 | 設定値(例)                                                                                                                                            |
|------------------|------------------------------------------|-------------------------------------------------------------------------------------------------------------------------------------------------------|
| フォント         | Main→Main console font                   | Migu 1M(要別途インストール)                                                                                                                           |
| 文字コード       | Main→Font charset                        | shiftjis                                                                                                                                              |
| デフォルトシェル | StartUp→Specified named task             | {Shells::GitShell}                                                                                                                                    |
| ウインドウサイズ | Main→Size&Pos→Window size                | Full screen                                                                                                                                           |
| ウインドウ透過   | Features→Transparency→Alpha transparency | Active window transparencyにチェック                                                                                                                  |
| キーバインド     | Keys&Macro                               | Create new console or new window：Ctrl+T<br>Switch next console：Ctrl+Shift+←<br>Switch previous console：Ctrl+Shift+→<br>Close current tab：Ctrl+Shift+Delete |

### PowerShell設定
`echo $profile`でファイルパスがわかるので編集する。

```bash
function prompt {
    Import-Module posh-git
    Import-Module PSReadLine

    $idx = $pwd.ProviderPath.LastIndexof("\") + 1
    $cdn = $pwd.ProviderPath.Remove(0, $idx)
    Write-Host "$env:UserName" -NoNewLine -ForegroundColor Magenta
    Write-Host ":" -NoNewLine -ForegroundColor White
    Write-Host $cdn -NoNewLine -ForegroundColor Green
    Write-VcsStatus

    return "> "
}

function CmdWorkspaceHome {
    cd ${env:homedrive}${env:homepath}\Dropbox\workspace
}

function CmdRunBash {
    Invoke-Expression "${env:windir}\system32\bash.exe -cur_console:p"
}

function CmdShow {
    Invoke-Item .
}

Set-Alias -name ll -value ls
Set-Alias -name which -value Get-Command
Set-Alias -name tt -value CmdWorkspaceHome
Set-Alias -name show -value CmdShow
Set-Alias -name bash -value CmdRunBash
```
