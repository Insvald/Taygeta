dependencies

Entity Framework 6.1.3 => 7.0.0-alpha
Abot Crawler 1.5.0.122 (?)
 log4net 2.0.3
 CsQuery
 NRobots
 HtmlAgilityPack
- CRC32C.Net 1.0.5
- Awesomium
AutoMapper
+ MSHtml
+ xxHash


добавить копирайт к исходникам
какие нужны методы
1) получить вакансии по указанным критериям
2) работа с личным кабинетом, шаблонами поиска, избранным и т.д.

веб-приложения
1) веб-сайт пользователей
2) веб-сайт административный
3) веб-служба

зависимости
1) доступ к данным (DataAccessLayer)
2) логгер (log4net?)
3) паук (WebCrawler)
4) вебрендерер (mshtml or Awesomium or HAP (without JavaScript!))

web -> Repo -> DbContext

переделать логирование в Аботе и избавиться от log4net

undo

http://www.hanselman.com/blog/WorkingWithSSLAtDevelopmentTimeIsEasierWithIISExpress.aspx
netsh http delete sslcert ipport=0.0.0.0:443
netsh http delete urlacl url=http://alphajobs.co.il:80/
netsh http delete urlacl url=https://alphajobs.co.il:443/