# VSCode PHP設定

## インストールする拡張
* PHP
* PHP Intelephense
* phpcs
    * composer global require squizlabs/php_codesniffer
    * 上記コマンドにより、anyenv配下の.composerのvendorにインストールされる
    * phpcsとphpcbfが入る

## 設定
主にできること：
* Go To Definitionで定義先へジャンプ
* PSR12形式でコード警告、保存時に自動フォーマット
* ある程度のインテリセンス

```json
{
    "[php]": {
        "editor.tabSize": 4,
        "editor.insertSpaces": true
    },
    "php.validate.executablePath": "/Users/rtanaka/.anyenv/envs/phpenv/shims/php",
    "php.suggest.basic": false,
    "phpcs.executablePath": "/Users/rtanaka/.anyenv/envs/phpenv/versions/7.4.8/composer/vendor/squizlabs/php_codesniffer/bin/phpcs",
    "phpcs.standard": "PSR12",
    "phpcbf.enable": true,
    "phpcbf.executablePath": "/Users/rtanaka/.anyenv/envs/phpenv/versions/7.4.8/composer/vendor/squizlabs/php_codesniffer/bin/phpcbf",
    "phpcbf.standard": "PSR12",
    "phpcbf.documentFormattingProvider": true,
    "phpcbf.onsave": true,
}
```