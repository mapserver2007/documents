# phpenvでpdo

# pdo_pgsql
* peclから落としてくる
* phpizeを実行する(phpenvのパスにすること)
* ./configure --with-php-config=/Users/stay/.phpenv/shims/php-config --with-pdo-pgsql=/opt/local/lib/postgresql93/bin (これが重要)
* make
* make test (ここでModuleバージョンとPHPバージョンが不一致のWarningがでなければOK)
* sudo make install
* php.iniにextension=pdo_pgsql.soを追加
* apache再起動してphpinfo();を見るか、php -i | grep pdo_pgsqlで確認。

