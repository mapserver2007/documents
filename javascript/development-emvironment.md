# JavaScript開発環境構築

## Node
* LTSの最新版を入れる

## TypeScript
* `npm install -g typescript`
* `npm install -g tslint`
* `npm install -g ts-node`
    * tsファイルを直接実行できる
* `npm install -g ts-node-dev`
    * ホットリロード
* `npm install -D typescript`
* `npm install -D @types/node`
    * -Dはpackage.jsonのdependenciesに追加するオプション

* VSCodeに`tslint`拡張をインストール


## vue-cli
* `npm install -g @vue/cli`
    * vue cli 3.x系
* `vue create vue-example`


## tsc
* `npx tsc init`
    * tsconfig.jsonを作る
    * 内容についてはテンプレートですでにあるやつをコピペする

## package.json

```
npm install -D typescript \
    @types/node \
    @babel/cli \
    @babel/core \
    @balel/node \
    @babel/plugin-proposal-object-rest-spread \
    @babel/preset-env \
    @vue/cli-plugin-typescript \
    @vue/eslint-config-typescript \
    eslint-config-typescript \
    babel-loader \
    bulma \
    cross-env \
    css-loader \
    eslint \
    eslint-config-standard \
    eslint-plugin-compat \
    eslint-plugin-import \
    eslint-plugin-node \
    eslint-plugin-promise \
    eslint-plugin-standard \
    eslint-plugin-vue \
    file-loader \
    html-loader \
    html-webpack-plugin \
    husky \
    node-sass \
    rimraf \
    sass-loader \
    ts-loader \
    typescript \
    url-loader \
    vue-loader \
    vue-template-compiler \
    webpack \
    webpack-cli \
    webpack-dev-server
```

* @babel/plugin-proposal-object-rest-spread
    * 
* @babel/preset-env
    * 環境に合わせてJSをトランスパイル、プラグイン適用してくれる
* eslint-config-typescript
    * ESLintをTypeScriptに適用
* bulma
    * CSSフレームワーク
* cross-env
    * webpackの設定を環境ごとに分ける
