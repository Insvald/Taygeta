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


�������� �������� � ����������
����� ����� ������
1) �������� �������� �� ��������� ���������
2) ������ � ������ ���������, ��������� ������, ��������� � �.�.

���-����������
1) ���-���� �������������
2) ���-���� ����������������
3) ���-������

�����������
1) ������ � ������ (DataAccessLayer)
2) ������ (log4net?)
3) ���� (WebCrawler)
4) ����������� (mshtml or Awesomium or HAP (without JavaScript!))

web -> Repo -> DbContext

���������� ����������� � ����� � ���������� �� log4net

undo

http://www.hanselman.com/blog/WorkingWithSSLAtDevelopmentTimeIsEasierWithIISExpress.aspx
netsh http delete sslcert ipport=0.0.0.0:443
netsh http delete urlacl url=http://alphajobs.co.il:80/
netsh http delete urlacl url=https://alphajobs.co.il:443/