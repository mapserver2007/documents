# PHPのtraitの調査
WebStreamでtraitを使う(使ってる)のでその調査φ(｀д´)ﾒﾓﾒﾓ...。

## 同じメソッドを定義
```php
trait QueryEntityTrait1
{
    private $name;

    public function getName()
    {
        return $this->name;
    }
}

trait QueryEntityTrait2
{
    private $name;

    public function getName()
    {
        return $this->name;
    }
}

class QueryEntity6
{
    use QueryEntityTrait1, QueryEntityTrait2;
}
```

結果

```
Fatal error: Trait method getName has not been applied, because there are collisions with other trait methods on WebStream\Test\TestData\Sample\App\Entity\QueryEntity6 in /Users/mapserver2007/Dropbox/workspace/WebStream/core/WebStream/Test/Sample/app/entities/QueryEntity6.php on line 7
```
同じメソッドはダメなのね。
解決するには、`insteadof`か`as`を使う。

```php
trait QueryEntityTrait1
{
    private $name;

    public function getName()
    {
        return $this->name;
    }
}

trait QueryEntityTrait2
{
    private $name;

    public function getName()
    {
        return $this->name;
    }
}

class QueryEntity6
{
    use QueryEntityTrait1, QueryEntityTrait2;
}
```