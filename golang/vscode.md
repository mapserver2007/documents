# VS Code拡張

## vscode-go
* Goで検索すると出てくるやつ
* インストール後、コマンドパレットで`GO: Install/Update Tools`を検索し、すべてアップグレードしておく

# コード補完
* https://qiita.com/akinobufujii/items/50d605ecf22daa3309cb

## LSP(Language Server Protocol)
* goplsインストール
* Shift+Control+p -> "setting.json"で設定を開く

## golangci-lint
* golintがデフォルトのようだが、つらい
* vscodeのsettings.jsonに`go.lintTool: "golangci-lint"`を足すとgo getでインストールを促されるので従う
* .golangci-lint.yamlを作っておくと詳細ルールを決められる
  * 置き場所はプロジェクトルートあたりが良さそう
  * https://yyh-gl.github.io/tech-blog/blog/golangci-lint-custom-settings/


## settings.json
```
    "editor.suggestSelection": "first",
    "editor.tabSize": 2,
    "go.gopath": "/Users/ryuichitanaka/workspace_go",
    "go.goroot": "/usr/local/Cellar/go/1.14.4/libexec",
    "[go]": {
        "editor.snippetSuggestions": "none",
        "editor.formatOnSave": true,
        "editor.codeActionsOnSave": {
            "source.organizeImports": true
        },
    },
    "go.docsTool": "gogetdoc",
    "go.lintTool": "golangci-lint",
    "go.autocompleteUnimportedPackages": true,
    "go.useLanguageServer": true,
    "go.alternateTools": {
        "go-langserver": "gopls"
    }
```

## golangci.yml
```
linters-settings:
  depguard:
    list-type: blacklist
    packages:
      # logging is allowed only by logutils.Log, logrus
      # is allowed to use only in logutils package
      - github.com/sirupsen/logrus
    packages-with-error-message:
      - github.com/sirupsen/logrus: "logging is allowed only by logutils.Log"
  dupl:
    threshold: 100
  exhaustive:
    default-signifies-exhaustive: false
  funlen:
    lines: 100
    statements: 50
  goconst:
    min-len: 2
    min-occurrences: 2
  gocritic:
    enabled-tags:
      - diagnostic
      - experimental
      - opinionated
      - performance
      - style
    disabled-checks:
      - dupImport # https://github.com/go-critic/go-critic/issues/845
      - ifElseChain
      - octalLiteral
      - whyNoLint
      - wrapperFunc
  gocyclo:
    min-complexity: 15
  goimports:
    local-prefixes: github.com/mapserver2007
  golint:
    min-confidence: 1.1
  gomnd:
    settings:
      mnd:
        # don't include the "operation" and "assign"
        checks: argument,case,condition,return
  govet:
    check-shadowing: true
    settings:
      printf:
        funcs:
          - (github.com/golangci/golangci-lint/pkg/logutils.Log).Infof
          - (github.com/golangci/golangci-lint/pkg/logutils.Log).Warnf
          - (github.com/golangci/golangci-lint/pkg/logutils.Log).Errorf
          - (github.com/golangci/golangci-lint/pkg/logutils.Log).Fatalf
  lll:
    line-length: 140
  maligned:
    suggest-new: true
  misspell:
    locale: US
  nolintlint:
    allow-leading-space: true # don't require machine-readable nolint directives (i.e. with no leading space)
    allow-unused: false # report any unused nolint directives
    require-explanation: false # don't require an explanation for nolint directives
    require-specific: false # don't require nolint directives to be specific about which linter is being skipped

linters:
  # please, do not use `enable-all`: it's deprecated and will be removed soon.
  # inverted configuration with `enable-all` and `disable` is not scalable during updates of golangci-lint
  disable-all: true
  enable:
    - bodyclose
    - deadcode
    - depguard
    - dogsled
    - dupl
    - errcheck
    - exhaustive
    - funlen
    - gochecknoinits
    - goconst
    - gocritic
    - gocyclo
    - gofmt
    - goimports
    - golint
    - gomnd
    - goprintffuncname
    - gosec
    - gosimple
    - govet
    - ineffassign
    - interfacer
    - lll
    - misspell
    - nakedret
    - noctx
    - nolintlint
    - rowserrcheck
    - scopelint
    - staticcheck
    - structcheck
    # - stylecheck
    - typecheck
    - unconvert
    - unparam
    - unused
    - varcheck
    - whitespace

  # don't enable:
  # - asciicheck
  # - gochecknoglobals
  # - gocognit
  # - godot
  # - godox
  # - goerr113
  # - maligned
  # - nestif
  # - prealloc
  # - testpackage
  # - wsl

issues:
  # Excluding configuration per-path, per-linter, per-text and per-source
  exclude-rules:
    - path: _test\.go
      linters:
        - gomnd

    # https://github.com/go-critic/go-critic/issues/926
    - linters:
        - gocritic
      text: "unnecessaryDefer:"

run:
  skip-dirs:
    - test/testdata_etc
    - internal/cache
    - internal/renameio
    - internal/robustio
    - openapi

# golangci.com configuration
# https://github.com/golangci/golangci/wiki/Configuration
service:
  golangci-lint-version: 1.23.x # use the fixed version to not introduce new linters unexpectedly
  prepare:
    - echo "here I can run custom commands, but no preparation needed for this repo"
```