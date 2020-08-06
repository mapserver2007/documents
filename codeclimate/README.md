# Code Climate

インストール
$> gem install travis

ログイン
$> travis login

TravisCIのアカウント確認
$> travis accounts

codeclimateからトークンを取得する
Test CoverageのPHPタブに以下がある
CODECLIMATE_REPO_TOKEN=dcf3bf1f7d2e9354299b83e8c590947c9d6b804f841e2054289052f2e8f11379 ./vendor/bin/test-reporter

$> travis encrypt dcf3bf1f7d2e9354299b83e8c590947c9d6b804f841e2054289052f2e8f11379

結果を.travis.ymlに貼り付ける


$>
