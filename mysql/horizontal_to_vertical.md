# データの横→縦変換

## 問題点
マイグレーション時にカンマ区切りのデータを分割しないとリレーションできないため、バラす必要がある。プログラムは極力書きたくないのでSQLで解決したい。

name | applicationId
-----|-----------------
hoge | 1,2,3,4,5

↓

name | applicationId
-----|--------------
hoge | 1
hoge | 2
hoge | 3
hoge | 4
hoge | 5

こうしたい。

## 解決方法
SUBSTRING_INDEXを使うと縦持ちに変換できる。あとはこれをJOINしたりすればOK。

```
select
    id,
    name,
    SUBSTRING_INDEX(SUBSTRING_INDEX(applicationIds, ",", L.`index`), ",", -1) AS applicationId
from users
cross join (
    SELECT 1 AS `index`
     UNION SELECT 2
     UNION SELECT 3
     UNION SELECT 4
     UNION SELECT 5
     UNION SELECT 6
     UNION SELECT 7
     UNION SELECT 8
     UNION SELECT 9
     UNION SELECT 10
) L
group by
    id, name, applicationId
```

UNON SELECT N のところは、カンマ区切りの最大数分静的に持っておく必要がある。
(さすがに可変でやってはくれない)
最後にgroup byをかけているのは、この場合必ず10レコードに分割してしまうため、重複データをカットするために指定。1,2,3と3つしかない場合でも10レコードできる。



## SUBSTRING_INDEXの説明
SUBSTRING_INDEX(SUBSTRING_INDEX(applicationIds, ",", L.`index`), ",", -1)　について。

### (SUBSTRING_INDEX(applicationIds, ",", L.`index`)

name | applicationId
-----|--------------
hoge | 1,2,3

↓

name | applicationId
-----|--------------
hoge | 1
hoge | 1,2
hoge | 1,2,3

にする。

### SUBSTRING_INDEX(SUBSTRING_INDEX(applicationIds, ",", L.`index`), ",", -1)
https://dev.mysql.com/doc/refman/5.6/ja/string-functions.html#function_substring-index

L.`index`に1-10までのインデックス値が入っているので、「,」で分割した値がそれぞれそのインデックスの場所の値に切り出される。つまり、1,2,3であればそれぞれカンマごとに区切られた値が順番に切り出されていき、UNIONで合体されるため縦持ち変換になる。

name | applicationId
-----|--------------
hoge | 1
hoge | 2
hoge | 3
hoge | 3
hoge | 3
(UNION分、合計10個続く)

最後にgroup byでグルーピングして重複データをカットすれば縦持ち完了。

name | applicationId
-----|--------------
hoge | 1
hoge | 2
hoge | 3

SUBSTRING_INDEXはデリミタがなんであっても使えるので、アンダースコア区切りのデータを分割してなにかするなど用途はある。