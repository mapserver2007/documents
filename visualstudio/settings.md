# Visual Studio設定
VisualStudio設定

## 1.全般
* ソリューションエクスプローラーを左側に移動
    * EclipseやSubLimeTextと同じ
* 配色を「濃色」にする
    * [ツール]→[オプション]→[環境]→[全般]の配色テーマを「濃色」

## 2.キーバインド
Eclipse大好き人間向け。

設定内容                     |設定キー
----------------------------|---------
コメントアウト                   |Ctrl+/
コメントアウト解除               |Ctrl+Shift+/
一つ前に戻る                  |Alt+←
一つ後に進む                  |Alt+→
ソリューション全体から検索         |Ctrl+Shift+F
すべての参照の検索              |(検索文字を選択して)Ctrl+Shift+G
using整理、削除および並び替え    |Ctrl+Shift+O
次を検索選択範囲               |(検索文字を選択して)Ctrl+K
前を検索選択範囲               |(検索文字を選択して)Ctrl+Shift+K
指定行へジャンプ                |Ctrl+L
クラスを開く                     |Ctrl+Shift+T
行の削除                      |Ctrl+D

## 3.拡張
* [VSCommands for Visual Studio 2013](https://visualstudiogallery.msdn.microsoft.com/c6d1c265-7007-405c-a68b-5606af238ece)
    * VS2010まではこれだけでも良かったが、2013から設定項目が減った
    * VS2015からインストール不可
* [Productivity Power Tools 2013](https://visualstudiogallery.msdn.microsoft.com/dbcb8670-889e-4a54-a226-a48a15e4cace)
    * VSCommandsで使えなくなった機能を使える
* [Local History for Visual Studio](https://localhistory.codeplex.com/)
    * SublimeTextではおなじみのLocalHistoryが使える
* [C# outline 2015](https://visualstudiogallery.msdn.microsoft.com/9390e08c-d0aa-42f1-b3d2-5134aabf3b9a)
    * ifやforといった構文で開閉可能
* [Configuration Transform](https://visualstudiogallery.msdn.microsoft.com/579d3a78-3bdd-497c-bc21-aa6e6abbc859)
    * App.configのDebub/Release切り替えが楽にできる。2015非対応

## 4.xUnit.NET
インストール手順は以下の通り。
1. テストプロジェクトを作成(クラスライブラリとして作成)
2. Nugetで`xUnit.NET`をインストール
3. 拡張と更新プログラムから`xUnit.net Test Extensions`、`xUnit Test Project Template`をインストール
4. パッケージマネージャコンソールで`xunit.runner.visualstudio`をインストール

テストを書いたら、[テスト]->[ウィンドウ]->[テストエクスプローラー]を表示し、テストを実行する。
