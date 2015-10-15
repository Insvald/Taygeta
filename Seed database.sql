/* 
	The Taygeta Project
	(c) 2015 Ilya Rovensky
*/

--use Taygeta
declare @LTR nchar(1) = nchar(0x200E);
declare @RTL nchar(1) = nchar(0x200F);

insert Resources (Name, CultureName, Value) values ('vacancyPageTitle', 'en-US', N'work, job, career, vacancy, vacancies')
insert Resources (Name, CultureName, Value) values ('vacancyPageTitle', 'he-IL', N'דרושים, משרות, קריירה')
insert Resources (Name, CultureName, Value) values ('vacancySubjectItem', 'en-US', N'developer, programmer, DBA, director, manager')
insert Resources (Name, CultureName, Value) values ('Description', 'en-US', N'description, responsibilities')
insert Resources (Name, CultureName, Value) values ('Requirements', 'en-US', N'requirements, required, skills, experience, degree, bachelor, advantage, mandatory')
insert Resources (Name, CultureName, Value) values ('Location', 'en-US', N'location, Israel, Tel Aviv')
insert Resources (Name, CultureName, Value) values ('EMail', 'en-US', N'mailto')

insert Resources (Name, CultureName, Value) values ('companyName', 'en-US', N'AlphaJobs')

insert Resources (Name, CultureName, Value) values ('homeString', 'en-US', N'Home')
insert Resources (Name, CultureName, Value) values ('aboutString', 'en-US', N'About')
insert Resources (Name, CultureName, Value) values ('contactString', 'en-US', N'Contact')

insert Resources (Name, CultureName, Value) values ('homeString', 'he-IL', N'דף הבית')
insert Resources (Name, CultureName, Value) values ('aboutString', 'he-IL', N'אודות')
insert Resources (Name, CultureName, Value) values ('contactString', 'he-IL', N'צור קשר')

insert Resources (Name, CultureName, Value) values ('homeString', 'ru-RU', N'Главная')
insert Resources (Name, CultureName, Value) values ('aboutString', 'ru-RU', N'О компании')
insert Resources (Name, CultureName, Value) values ('contactString', 'ru-RU', N'Контакты')

insert Resources (Name, CultureName, Value) values ('registerString', 'en-US', N'Register')
insert Resources (Name, CultureName, Value) values ('loginString', 'en-US', N'Log in')
insert Resources (Name, CultureName, Value) values ('logoutString', 'en-US', N'Log off')
insert Resources (Name, CultureName, Value) values ('helloString', 'en-US', N'Hello {0}!')

insert Resources (Name, CultureName, Value) values ('registerString', 'he-IL', N'הרשמה')
insert Resources (Name, CultureName, Value) values ('loginString', 'he-IL', N'כניסה')
insert Resources (Name, CultureName, Value) values ('logoutString', 'he-IL', N'התנתק')
insert Resources (Name, CultureName, Value) values ('helloString', 'he-IL', N'שלום ' + @RTL + '{0}')

insert Resources (Name, CultureName, Value) values ('registerString', 'ru-RU', N'Регистрация')
insert Resources (Name, CultureName, Value) values ('loginString', 'ru-RU', N'Войти')
insert Resources (Name, CultureName, Value) values ('logoutString', 'ru-RU', N'Выйти')
insert Resources (Name, CultureName, Value) values ('helloString', 'ru-RU', N'Привет, {0}!')

insert Resources (Name, CultureName, Value) values ('errorString', 'en-US', N'Error')
insert Resources (Name, CultureName, Value) values ('errorDescriptionString', 'en-US', N'An error occurred while processing your request.')

insert Resources (Name, CultureName, Value) values ('searchCaption', 'en-US', N'Find your job now')
insert Resources (Name, CultureName, Value) values ('searchJobPlaceholder', 'en-US', N'Vacancy, job or position')
insert Resources (Name, CultureName, Value) values ('searchLocationPlaceholder', 'en-US', N'Location')

insert Resources (Name, CultureName, Value) values ('searchCaption', 'he-IL', N'מצא את העבודה שלך עכשיו')
insert Resources (Name, CultureName, Value) values ('searchJobPlaceholder', 'he-IL', N'משרה, עבודה או תפקיד')
insert Resources (Name, CultureName, Value) values ('searchLocationPlaceholder', 'he-IL', N'מיקום')

insert Resources (Name, CultureName, Value) values ('searchCaption', 'ru-RU', N'Найдите работу немедленно')
insert Resources (Name, CultureName, Value) values ('searchJobPlaceholder', 'ru-RU', N'Вакансия, должность или работа')
insert Resources (Name, CultureName, Value) values ('searchLocationPlaceholder', 'ru-RU', N'Расположение')

insert Resources (Name, CultureName, Value) values ('searchString', 'en-US', N'Search')
insert Resources (Name, CultureName, Value) values ('searchString', 'he-IL', N'חיפוש')
insert Resources (Name, CultureName, Value) values ('searchString', 'ru-RU', N'Поиск')

insert Resources (Name, CultureName, Value) values ('resultString', 'en-US', N'Search Results')
insert Resources (Name, CultureName, Value) values ('resultString', 'he-IL', N'תוצאות חיפוש')
insert Resources (Name, CultureName, Value) values ('resultString', 'ru-RU', N'Результаты поиска')

insert Resources (Name, CultureName, Value) values ('resultsHeader', 'en-US', N'Vacancies found: {0}.')
insert Resources (Name, CultureName, Value) values ('resultsHeader', 'he-IL', N'משרות מצאו: {0}.')
insert Resources (Name, CultureName, Value) values ('resultsHeader', 'ru-RU', N'Найдено вакансий: {0}.')

insert Resources (Name, CultureName, Value) values ('positionString', 'en-US', N'Position')
insert Resources (Name, CultureName, Value) values ('positionString', 'he-IL', N'משרה')
insert Resources (Name, CultureName, Value) values ('positionString', 'ru-RU', N'Вакансия')

insert Resources (Name, CultureName, Value) values ('companyString', 'en-US', N'Company')
insert Resources (Name, CultureName, Value) values ('companyString', 'he-IL', N'חברה')
insert Resources (Name, CultureName, Value) values ('companyString', 'ru-RU', N'Компания')

insert Resources (Name, CultureName, Value) values ('locationString', 'en-US', N'Location')
insert Resources (Name, CultureName, Value) values ('locationString', 'he-IL', N'מיקום')
insert Resources (Name, CultureName, Value) values ('locationString', 'ru-RU', N'Расположение')

insert Resources (Name, CultureName, Value) values ('publishedString', 'en-US', N'Published on')
insert Resources (Name, CultureName, Value) values ('publishedString', 'he-IL', N'תאריך ההופעה')
insert Resources (Name, CultureName, Value) values ('publishedString', 'ru-RU', N'Дата размещения')

insert Resources (Name, CultureName, Value) values ('numberString', 'en-US', N'No.')
insert Resources (Name, CultureName, Value) values ('numberString', 'he-IL', N'מ.')
insert Resources (Name, CultureName, Value) values ('numberString', 'ru-RU', N'№№')

insert Pages (Content, HomePageTitle, LastModified, Url, Wrapped) values (
N'<!DOCTYPE html>


<?xml version="1.0" encoding="utf-8"?>
<html prefix="og: http://ogp.me/ns#" xmlns="http://www.w3.org/1999/xhtml" xml:lang="en-gb" lang="en-gb" dir="ltr" >
	<head>
        <meta name="viewport" content="width=device-width, initial-scale=1">
        <link rel="stylesheet" href="//maxcdn.bootstrapcdn.com/font-awesome/4.3.0/css/font-awesome.min.css">
        <link href="http://fonts.googleapis.com/css?family=Open+Sans:300italic,400italic,600italic,700italic,800italic,400,300,600,700,800" rel="stylesheet" type="text/css">
        <script type="text/javascript" src="//ajax.googleapis.com/ajax/libs/jquery/1.10.2/jquery.min.js"></script>
          <base href="http://www.liveu.tv/careers" />
  <meta http-equiv="content-type" content="text/html; charset=utf-8" />
  <meta property="og:url" content="http://www.liveu.tv/careers" />
  <meta property="og:title" content="Careers" />
  <meta property="og:type" content="website" />
  <meta property="og:image" content="http://www.liveu.tv/media/k2/categories/19.jpg" />
  <meta name="image" content="http://www.liveu.tv/media/k2/categories/19.jpg" />
  <meta property="og:description" content="If you are an enthusiastic and self-motivated person who thrives in a collaborative, entrepreneurial environment, you are invited to join us. Be part..." />
  <meta name="description" content="If you are an enthusiastic and self-motivated person who thrives in a collaborative, entrepreneurial environment, you are invited to join us. Be part..." />
  
  <title>Careers</title>
  
  <link href="/careers/feed?type=rss" rel="alternate" type="application/rss+xml" title="RSS 2.0" />
  <link href="/careers/feed?type=atom" rel="alternate" type="application/atom+xml" title="Atom 1.0" />
  <link href="/templates/joomi/favicon.ico" rel="shortcut icon" type="image/vnd.microsoft.icon" />
  <link rel="stylesheet" href="/components/com_rsform/assets/calendar/calendar.css" type="text/css" />
  <link rel="stylesheet" href="/components/com_rsform/assets/css/front.css" type="text/css" />
  <link rel="stylesheet" href="/media/mod_languages/css/template.css" type="text/css" />
  <script src="/media/system/js/mootools-core.js" type="text/javascript"></script>
  <script src="/media/jui/js/jquery.min.js" type="text/javascript"></script>
  <script src="/media/jui/js/jquery-noconflict.js" type="text/javascript"></script>
  <script src="/media/jui/js/jquery-migrate.min.js" type="text/javascript"></script>
  <script src="/media/system/js/core.js" type="text/javascript"></script>
  <script src="/components/com_k2/js/k2.js?v2.6.9&amp;sitepath=/" type="text/javascript"></script>
  <script src="/components/com_rsform/assets/js/script.js" type="text/javascript"></script>

		<link rel="stylesheet" href="http://www.liveu.tv//templates/joomi/css/template.css" type="text/css" />
		<link rel="stylesheet" href="http://www.liveu.tv//templates/joomi/css/select2.min.css" type="text/css" />
		<script type="text/javascript" src="http://www.liveu.tv//templates/joomi/js/template.js"></script>
		<script type="text/javascript" src="http://www.liveu.tv//templates/joomi/js/select2.min.js"></script>
        <script type="text/javascript" src="http://www.liveu.tv//templates/joomi/js/bootstrap.js"></script>
    	<!-- BEGIN: Custom advanced (www.pluginaria.com) -->
<script>
  (function(i,s,o,g,r,a,m){i["GoogleAnalyticsObject"]=r;i[r]=i[r]||function(){
  (i[r].q=i[r].q||[]).push(arguments)},i[r].l=1*new Date();a=s.createElement(o),
  m=s.getElementsByTagName(o)[0];a.async=1;a.src=g;m.parentNode.insertBefore(a,m)
  })(window,document,"script","//www.google-analytics.com/analytics.js","ga");

  ga("create", "UA-691590-3", "auto");
  ga("send", "pageview");

</script><!-- END: Custom advanced (www.pluginaria.com) -->

        <noscript>LiveU is the pioneer in IP-based live video services and live broadcast solutions for acquisition, management and distribution. LiveU"s award-winning technology enables live video transmission from any location around the world</noscript>
        <meta name="google-site-verification" content="QopGakKKasc8a6po-U5x_H01LUSG944Ewt7sQVYxojk" />
    </head>

	<body >
<!-- Facebook SDK -->
<div id="fb-root"></div>
<script type="text/javascript">

      // Load the SDK Asynchronously
      (function(d){
      var js, id = "facebook-jssdk"; if (d.getElementById(id)) {return;}
      js = d.createElement("script"); js.id = id; js.async = true;
      js.src = "//connect.facebook.net/en_GB/all.js";
      d.getElementsByTagName("head")[0].appendChild(js);
    }(document));

</script>
<!-- End Facebook SDK -->

    
        <div class="header wrapper">
            <div class="container first_menu">
                <div class="container regular">
                    <div class="row">
                        <div class="search col-xs-12 col-sm-12 col-md-60">
                            <div class="arr_down"></div>
                            <div class="mod-languages">

	<form name="lang" method="post" action="http://www.liveu.tv/careers">
	<select class="inputbox" onchange="document.location.replace(this.value);" >
			<option dir="ltr" value="/de/" >
		Deutsch</option>
			<option dir="ltr" value="http://www.liveu.tv/careers" selected="selected">
		English</option>
			<option dir="ltr" value="/es/" >
		Español</option>
			<option dir="ltr" value="/fr/" >
		Français</option>
			<option dir="ltr" value="/pt/" >
		Português </option>
			<option dir="ltr" value="/ru/" >
		Русский</option>
			<option dir="ltr" value="/ja/" >
		日本語</option>
		</select>
	</form>

</div>

                            
<div class="k2SearchBlock">
	<form action="/search" method="get" autocomplete="off" class="k2SearchBlockForm">

		<input type="text" value="Search here" name="searchword" maxlength="20" size="20" alt="  " class="inputbox" onblur="if(this.value=="") this.value="Search here";" onfocus="if(this.value=="Search here") this.value="";" />

						<input type="submit" value="  " class="img_btn button" onclick="this.form.searchword.focus();" >
<!-- src="/--><!--/components/com_k2/images/fugue/search.png" />-->
				
		<input type="hidden" name="categories" value="1,10,11,18,19,36,57,71,72,73,77,81,123,124,125,127,128,129,130,12,13,14,15,20,37,44,22,23,24,25,26,27,28,29,31,32,33,34,42,65,66,67,68,69,70" />
					</form>

	</div>


                            <div class="clear"></div>
                        </div>
                        <div class="header_menu col-xs-12 col-sm-12 col-md-27">
                            <ul class="nav menu">
<li class="item-136"><a href="/blog" >Blog</a></li><li class="item-137"><a href="http://www.liveu.tv/community" target="_blank" >Community</a></li><li class="item-138"><a class="us" href="http://shop.liveu.tv/" onclick="window.open(this.href,"targetWindow","toolbar=no,location=no,status=no,menubar=no,scrollbars=yes,resizable=yes,");return false;" >Store</a></li><li class="item-139"><a href="/services" >Events</a></li></ul>

                        </div>
                        <div class="link col-xs-12 col-sm-12 col-md-13">
                            <!-- BEGIN: Custom advanced (www.pluginaria.com) -->
<ul>
<li><a class="fa fa-twitter" target="_blank" href="https://twitter.com/LiveU"></a></li>
<li><a target="_blank" class="fa fa-google-plus" href="https://plus.google.com/+LiveuTv/posts"></a></li>
<li><a target="_blank" class="fa fa-youtube" href="https://www.youtube.com/user/liveUtv"></a></li>
<li><a target="_blank"  class="fa fa-facebook" href="https://www.facebook.com/LiveU.Fans"></a></li>
</ul><!-- END: Custom advanced (www.pluginaria.com) -->

                        </div>
                    </div>
                </div>
                <div class="row mobile">
				<div class="mod-languages">

	<form name="lang" method="post" action="http://www.liveu.tv/careers">
	<select class="inputbox" onchange="document.location.replace(this.value);" >
			<option dir="ltr" value="/de/" >
		Deutsch</option>
			<option dir="ltr" value="http://www.liveu.tv/careers" selected="selected">
		English</option>
			<option dir="ltr" value="/es/" >
		Español</option>
			<option dir="ltr" value="/fr/" >
		Français</option>
			<option dir="ltr" value="/pt/" >
		Português </option>
			<option dir="ltr" value="/ru/" >
		Русский</option>
			<option dir="ltr" value="/ja/" >
		日本語</option>
		</select>
	</form>

</div>

                    <div class="search">
                        
<div class="k2SearchBlock">
	<form action="/search" method="get" autocomplete="off" class="k2SearchBlockForm">

		<input type="text" value="Search here" name="searchword" maxlength="20" size="20" alt="  " class="inputbox" onblur="if(this.value=="") this.value="Search here";" onfocus="if(this.value=="Search here") this.value="";" />

						<input type="submit" value="  " class="img_btn button" onclick="this.form.searchword.focus();" >
<!-- src="/--><!--/components/com_k2/images/fugue/search.png" />-->
				
		<input type="hidden" name="categories" value="1,10,11,18,19,36,57,71,72,73,77,81,123,124,125,127,128,129,130,12,13,14,15,20,37,44,22,23,24,25,26,27,28,29,31,32,33,34,42,65,66,67,68,69,70" />
					</form>

	</div>

                    </div>
                    <div class="link">
                        <!-- BEGIN: Custom advanced (www.pluginaria.com) -->
<ul>
<li><a class="fa fa-twitter" target="_blank" href="https://twitter.com/LiveU"></a></li>
<li><a target="_blank" class="fa fa-google-plus" href="https://plus.google.com/+LiveuTv/posts"></a></li>
<li><a target="_blank" class="fa fa-youtube" href="https://www.youtube.com/user/liveUtv"></a></li>
<li><a target="_blank"  class="fa fa-facebook" href="https://www.facebook.com/LiveU.Fans"></a></li>
</ul><!-- END: Custom advanced (www.pluginaria.com) -->

                    </div>
                    <button type="button" class="navbar-toggle" data-toggle="collapse" data-target="#bs-navbar-1"></button>
                    <div class="navbar col-xs-12 col-sm-12 col-md-78" role="navigation">
                        <div class="container-fluid">
                            <div class="collapse navbar-collapse" id="bs-navbar-1">
                                <ul class="nav menu">
<li class="item-225"><a href="/" >Home</a></li><li class="item-133 active deeper parent"><a href="/about-liveu" >Company</a><ul class="nav-child unstyled small"><li class="item-144"><a href="/about-liveu" >About LiveU</a></li><li class="item-142"><a href="/the-liveu-advantage" >The LiveU Advantage</a></li><li class="item-343"><a href="/case-study-archive" >Case Studies</a></li><li class="item-327"><a href="/our-distributors" >Our Distributors </a></li><li class="item-166 current active"><a href="/careers" >Careers</a></li></ul></li><li class="item-134 deeper parent"><a href="/products" >Products</a><ul class="nav-child unstyled small"><li class="item-140 divider deeper parent"><span class="separator">
	Field units</span>
<ul class="nav-child unstyled small"><li class="item-168"><a href="/lu500" >LU500 SERIES</a></li><li class="item-346"><a href="/lu200" >LU200 Series</a></li><li class="item-173"><a href="/lu400" >LU400 Series</a></li><li class="item-177"><a href="/lu70" >LU70 Series</a></li><li class="item-176"><a href="/liveu-xtender" >LiveU Xtender</a></li></ul></li><li class="item-141 divider deeper parent"><span class="separator">
	Software</span>
<ul class="nav-child unstyled small"><li class="item-143"><a href="/lu-smart" >LU-Smart</a></li><li class="item-178"><a href="/lu-lite" >LU-Lite Series</a></li></ul></li><li class="item-681 divider deeper parent"><span class="separator">
	Servers</span>
<ul class="nav-child unstyled small"><li class="item-682"><a href="/the-liveu-family-of-products/lu2000" >LU2000</a></li></ul></li><li class="item-685 divider deeper parent"><span class="separator">
	Encoders</span>
<ul class="nav-child unstyled small"><li class="item-174"><a href="/lu700" >LU700 Series</a></li><li class="item-347"><a href="/lu200e" >LU200e</a></li></ul></li></ul></li><li class="item-135 deeper parent"><a href="/ip-services" >IP Services</a><ul class="nav-child unstyled small"><li class="item-179"><a href="/liveu-central" >LiveU Central</a></li><li class="item-687 divider deeper parent"><span class="separator">
	Distribution Solutions</span>
<ul class="nav-child unstyled small"><li class="item-688"><a href="/ip-services/liveu-singlepoint" >LiveU SinglePoint</a></li><li class="item-689"><a href="/ip-services/liveu-interpoint" >LiveU InterPoint</a></li><li class="item-180"><a href="/liveu-mulitpoint" >LiveU MultiPoint</a></li></ul></li><li class="item-182"><a href="/liveu-community" >LiveU Community</a></li><li class="item-171"><a href="/befirst" >Be.First</a></li><li class="item-211"><a href="/ip-services/panasonic-integration" >Panasonic Connectivity </a></li></ul></li><li class="item-183 deeper parent"><a href="/solutions" >Solutions</a><ul class="nav-child unstyled small"><li class="item-196"><a href="/global-events" >Global Events</a></li><li class="item-184"><a href="/broadcast" >Broadcast Television</a></li><li class="item-199"><a href="/vehicle-solutions" >Vehicle Solutions</a></li><li class="item-191"><a href="/satellite-solutions" >Satellite Solutions</a></li><li class="item-189"><a href="/sports" >Sports</a></li><li class="item-190"><a href="/public-safety" >Public Safety</a></li></ul></li><li class="item-145 deeper parent"><a href="/news" >News</a><ul class="nav-child unstyled small"><li class="item-146"><a href="/liveu-news/press-releases" >Press releases</a></li><li class="item-192"><a href="/liveu-news/press-clippings" >Press Clippings</a></li><li class="item-193"><a href="/media-kit" >Media Kit</a></li><li class="item-195"><a href="/liveu-news/trade-shows" >Trade Shows</a></li></ul></li><li class="item-690 deeper parent"><a href="/support" >Support</a><ul class="nav-child unstyled small"><li class="item-691"><a href="/support/usb-modems" >USB Modems</a></li><li class="item-692"><a href="/support/sla" >SLA Operation</a></li></ul></li><li class="item-175"><a href="/contact-us" >Contact Us</a></li></ul>

                                <ul class="nav menu">
<li class="item-136"><a href="/blog" >Blog</a></li><li class="item-137"><a href="http://www.liveu.tv/community" target="_blank" >Community</a></li><li class="item-138"><a class="us" href="http://shop.liveu.tv/" onclick="window.open(this.href,"targetWindow","toolbar=no,location=no,status=no,menubar=no,scrollbars=yes,resizable=yes,");return false;" >Store</a></li><li class="item-139"><a href="/services" >Events</a></li></ul>

                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="s_menu container">
                <div class="row menu_row">
                    <div class="main_menu ">
                        <ul class="nav menu">
<li class="item-225"><a href="/" >Home</a></li><li class="item-133 active parent"><a href="/about-liveu" >Company</a></li><li class="item-134 parent"><a href="/products" >Products</a></li><li class="item-135 parent"><a href="/ip-services" >IP Services</a></li><li class="item-183 parent"><a href="/solutions" >Solutions</a></li><li class="item-145 parent"><a href="/news" >News</a></li><li class="item-690 parent"><a href="/support" >Support</a></li><li class="item-175"><a href="/contact-us" >Contact Us</a></li></ul>

                    </div>
                    <div class="logo ">					
<!--                        <a href="/--><!----><!--">-->
							

<div class="custom"  >
	<p><a href="/"><img src="/images/Logo_AMD.png" alt="LiveU Live Broadcasting" width="135" height="60" /></a></p></div>

<!--						</a>-->
                    </div>
                </div>
            </div>
        </div>
        <div class="container">
            <div id="system-message-container">
	</div>

        </div>
				        <div class="wrapper">
				
            <div class="container">
                <div class="row">
                    <div class="right col-xs-12 col-sm-12 col-lg-9">
													
<div id="k2ModuleBox113" class="k2BreadcrumbsBlock">
	<span class="bcTitle">You are here:</span><a href="http://www.liveu.tv/">HOME PAGE</a><span class="bcSeparator">></span><a href="/about-liveu">Company</a><span class="bcSeparator">></span><a href="/careers">Careers</a></div>

												<div class="component">
							<div class="news careers Careers ">
   <div class="row">
       <div class="title">
           <h1>Careers</h1>
       </div>
       <div class="content">
           <p class="bigtext"><strong>If you are an enthusiastic and self-motivated person who thrives in a collaborative, entrepreneurial environment, you are invited to join us. Be part of the cutting edge in the most exciting segment of entertainment and news creation.</strong></p>
<p>LiveU is the trailblazer in portable “go-live anywhere” video transmission backpacks and the de-facto benchmark for quality of experience and technological performance. As we continue to grow our worldwide presence, we are seeking candidates to join our high-energy, innovative teams. We provide the unique opportunity to aspire to professional fulfillment in a young and creative environment that is genuinely set to make a difference in its field.</p>
<p>We offer competitive compensation and great opportunities for professional growth. Please send your resume, indicating the position you’re applying for, to <a href="mailto:jobs@liveu.tv" class="orange">jobs@liveu.tv</a> (int"l) and <a href="mailto:liat@liveu.tv" class="orange">liat@liveu.tv</a> (US &amp; Americas).</p>
<p>It is the policy of LiveU not to accept unsolicited resumes from third party recruiters.</p>
<p>&nbsp;</p>
<p>LiveU is an Equal Opportunity Employer</p>       </div>
   </div>
        <div class="row">
                                    <div class="col-xs-12 col-sm-12 col-md-12">
				                    <div class="single_category">
                        <div class="section1">
							<div class="wrap_h2">
								<h2>
								  Open Positions in EMEA								</h2>
							</div>
							<div class="cat_desc">
							    							</div>
                        </div>
                        <div class="sub_cat_items">
                                                        <div class="single_item">
                                                                    <div class="item_title plus">
									<span class="open_close ">+</span>
										<h3>Director of Sales - Eastern Europe and Africa</h3>
										
									</div>
									<div class="content">
										<p><em><strong>Location:&nbsp;</strong><span style="font-size: 11pt; line-height: 16.8666667938232px; font-family: Calibri, sans-serif;"><strong>Germany / Israel / Poland / Romania / Hungary / Turkey / Czech Republic&nbsp;</strong>&nbsp;</span></em></p>
<p><span class="bigtext">Responsibilities:</span></p>
<ul>
<li>Responsible for the territory revenue, setting goals and building the sales plan</li>
<li>Assign, manage and work with distribution channels in the region</li>
<li>Develop and implement strategies to increase business</li>
<li>Demand creation through seminars and roadshows presenting the company solutions</li>
<li>Drive short term revenues and establish long-term strategic relationships with customers</li>
<li>Lead product demonstrations, bid preparation and contract negotiations</li>
<li>Work in coordination and collaboration with other departments for product support or technical expertise throughout the sales cycle</li>
</ul>
<p><span class="bigtext">Requirements</span></p>
<ul>
<li>Degree in relevant field</li>
<li>At least 5 years of experience selling solutions in the technology and high-tech market in the Eastern Europe &amp; Africa region</li>
<li>Deep knowledge of the broadcast and/or online market</li>
<li>Experience with distributors and channel management</li>
<li>Demonstrated history of sales achievements including growing sales and development of new business</li>
<li>Good technical understanding and ability to demonstrate complex solutions and discuss technical features in detail</li>
<li>Excellent verbal, written, communication, and presentation skills in English</li>
<li>Independent, self-driven, creative, initiator, “can-do!” attitude</li>
<li>Ability and willingness to travel extensively both domestically and internationally</li>
</ul>
<p class="bigtext"><a href="mailto:jobs@liveu.tv?
&amp;subject=The%20subject%20of%20the%20email">SUBMIT YOUR CV</a></p>									</div>
									                            </div>
                                                        <div class="single_item">
                                                                    <div class="item_title plus">
									<span class="open_close ">+</span>
										<h3>Middle Eastern Presales</h3>
										
									</div>
									<div class="content">
										<p><em><strong>Location: UAE or Europe</strong></em></p>
<p><span class="bigtext">Responsibilities:</span></p>
<ul>
<li>Serve as a technical authority for customers and sales in Middle East territory</li>
<li>Devise Live video solutions for projects and customers in the broadcast domain</li>
<li>Present and demonstrate company solutions in front of a technical and business audiences</li>
<li>Define technical working procedures and standards for all interaction with customers</li>
<li>Train partners to ensure the highest level of professionalism</li>
<li>Collect technical feedback from the partner sand customer and manage priorities for sales activities</li>
</ul>
<p><span class="bigtext">Requirements</span></p>
<ul>
<li>Bachelor degree in Computer-Science or related field or equivalent practical experience from a media company</li>
<li>Experience in video and telecommunication - advantage</li>
<li>Minimum 2 years’ experience in Technical Presales or similar position</li>
<li>Strong presentation skills</li>
<li>Ability to work under pressure and on multiple projects</li>
<li>Excellent communication skills, both verbal and written in English</li>
<li>About 30%- 50%of time will be spent abroad</li>
</ul>
<p><span class="bigtext">Cognitive and interpersonal skills</span></p>
<ul>
<li>Arabic Speaker – advantage</li>
<li>Independent and fast learner</li>
<li>Motivated by achievement and success</li>
<li>Dedication and responsibility</li>
</ul>
<p>If you fit the requirements above– send your CV to <a href="mailto:jobs@liveu.tv">jobs@liveu.tv</a><br />CV’s will be accepted in English only</p>									</div>
									                            </div>
                                                        <div class="single_item">
                                                            </div>
                                                        <div class="single_item">
                                                            </div>
                                                        <div class="single_item">
                                                            </div>
                                                    </div>
                <!--  --><!--  -->
                <!--   <p>--><!--</p>-->
                <!--  -->                    </div>
					                </div>
                            <div class="col-xs-12 col-sm-12 col-md-12">
				                    <div class="single_category">
                        <div class="section1">
							<div class="wrap_h2">
								<h2>
								  Open Positions in APAC								</h2>
							</div>
							<div class="cat_desc">
							    							</div>
                        </div>
                        <div class="sub_cat_items">
                                                        <div class="single_item">
                                                            </div>
                                                        <div class="single_item">
                                                            </div>
                                                        <div class="single_item">
                                                                    <div class="item_title plus">
									<span class="open_close ">+</span>
										<h3>China Country Manager</h3>
										
									</div>
									<div class="content">
										<p><span style="color: #005ba0;"></span></p>
<p><em><strong>Location: Beijing</strong></em></p>
<p><span class="bigtext">Job Description:</span></p>
<ul>
<li>The Country Sales Manager will be local Beijing resident, responsible for the company sales and marketing activities in mainland China</li>
<li>The manager will have overall responsibility for managing the local distributors, developing business and increasing sales for the company</li>
<li>The Country Manager will report directly to the Vice President of Sales APAC.</li>
<li>The position will demand a large amount of travel throughout China.</li>
</ul>
<p><span style="color: #005ba0;"></span></p>
<p><span class="bigtext">Responsibility:</span></p>
<ul>
<li>Meet company quarterly and yearly sales target for the region</li>
<li>Recruitment and management of distribution partners</li>
<li>Oversight of all operations within China including taking responsibility for sales, trade shows, roadshows, and quality targets set by the company</li>
</ul>
<p><br /><span class="bigtext">The Country Manager position demands a broad range of business skills including:</span></p>
<ul>
<li>Vast experience in advanced technology sales – Knowledge and experience in the Broadcasting and or the Satellite industry is preferred</li>
<li>Experience selling to C-Level in the organizations</li>
<li>Excellent networking skills with a proven ability to develop distribution channels and long-lasting relationships with customers</li>
<li>Ability to deliver the highest standards of customer service</li>
<li>Ability to recruit staff and monitor performance</li>
<li>A solid understanding of budgeting and business planning is essential</li>
<li>Must be educated to degree level or equivalent with at least 8-10 years’ experience in sales and business development</li>
<li>Excellent interpersonal skills at all levels, including people-management, leadership and both written and verbal communication skills, both in English and Mandarin Understanding and sensitivity towards cultural differences</li>
</ul>
<p class="bigtext"><a href="mailto:jobs@Liveu.tv?cc=doron@liveu.tv
  &amp;subject=China%20Country%20Manager%20Applicationl">SUBMIT YOUR CV</a></p>									</div>
									                            </div>
                                                        <div class="single_item">
                                                                    <div class="item_title plus">
									<span class="open_close ">+</span>
										<h3>Technical Support - China</h3>
										
									</div>
									<div class="content">
										<p><em><strong>Location: Beijing / Shanghai, China</strong></em></p>
<p><br /><span class="bigtext">Responsibilities:</span></p>
<ul>
<li>Provide exceptional customer service at all times</li>
<li>Deep understanding of all the company"s products SW &amp; HW</li>
<li>Support all Tier 1 cases with a focus on the Chinese market, while staying within the company"s agreed SLA</li>
<li>Be a single POC for all partners in China</li>
<li>Become the company"s technical face in the Chinese market</li>
<li>Act as a cluster and backup for the sales engineer of the region</li>
<li>Support other departments in need of a technical hand in the region</li>
<li>On site visits for Chinese customers and partners when needed</li>
</ul>
<p><span class="bigtext">Education:</span></p>
<p>Technical degree or higher in Software or Electrical Engineering <span class="bigtext"><br /></span></p>
<p><span class="bigtext">Required knowledge and skills:</span></p>
<ul>
<li>At least 1-2 years of experience in technical support Tier 1-2</li>
<li>Excellent communication skills in both Chinese and English</li>
<li>Experience from the IT or Telecom market</li>
<li>Experience in Linux environment</li>
<li>Cognitive and interpersonal skills</li>
<li>Strong technical and problem solving skills</li>
<li>Strong communication skills and excellent team worker</li>
<li>Service oriented approach</li>
<li>Practical thinking</li>
<li>Methodological</li>
<li>Process monitoring and Control</li>
<li>Organization and order, tying up loose ends</li>
<li>System Perspective</li>
<li>Availability to work in shifts in different hours of the day – most of the shifts will be on China local time</li>
<li>Ability to always respond positively when under pressure, multi-task and deal with conflicts</li>
</ul>
<p class="bigtext">Advantages:</p>
<ul>
<li>Experience in video</li>
<li>Experience in Online streaming (CDN)</li>
<li>Knowledge in telecommunication</li>
<li>Experience in dynamic, fast paced, hi-tech environment</li>
</ul>
<p class="bigtext"><a href="mailto:jobs@liveu.tv?
subject=China%20Technical%20Support%20application"> SUBMIT YOUR CV</a></p>									</div>
									                            </div>
                                                        <div class="single_item">
                                                                    <div class="item_title plus">
									<span class="open_close ">+</span>
										<h3>Director of Sales - Japan &amp; Korea</h3>
										
									</div>
									<div class="content">
										<p><em><strong>Location: Tokyo, Japan</strong></em></p>
<p><span class="bigtext">Responsibility:</span></p>
<ul>
<li>Responsible for the territory revenue, setting goals and building the sales plan</li>
<li>Assign, manage and work with distribution channels in the region</li>
<li>Develop and implement strategies to increase business</li>
<li>Demand creation through seminars and roadshows presenting the company solutions</li>
<li>Drive short term revenues and establish long-term strategic relationships with customers</li>
<li>Lead product demonstrations, bid preparation and contract negotiations</li>
<li>Work in coordination and collaboration with other departments for product support or technical expertise throughout the sales cycle</li>
<li>The Director of Sales will report directly to the Vice President of Sales Asia Pacific.</li>
</ul>
<p><span class="bigtext">Requirements:</span></p>
<ul>
<li>Degree in relevant field</li>
<li>At least 5 years of experience selling solutions in the technology and high-tech market in Japan &amp; Korea region</li>
<li>Deep knowledge of the broadcast market</li>
<li>Experience with distributers and channel management</li>
<li>Demonstrated history of sales achievements including growing sales and development of new business – a must!</li>
<li>Good technical understanding and ability to demonstrate complex solutions and discuss technical features in detail</li>
<li>Excellent verbal, written, communication, and presentation skills in both English and Japanese</li>
<li>Independent, self-driven, creative, initiator, “can-do!” attitude</li>
<li>Ability and willingness to travel extensively both domestically and internationally</li>
</ul>
<p class="bigtext"><a href="mailto:jobs@liveu.tv?
&amp;subject=The%20subject%20of%20the%20email"> SUBMIT YOUR CV</a></p>									</div>
									                            </div>
                                                    </div>
                <!--  --><!--  -->
                <!--   <p>--><!--</p>-->
                <!--  -->                    </div>
					                </div>
                            <div class="col-xs-12 col-sm-12 col-md-12">
				                </div>
                        </div>
</div>
<!-- JoomlaWorks "K2" (v2.6.9) | Learn more about K2 at http://getk2.org -->


                            
						</div>
                    </div>
                    <div class="left col-xs-12 col-sm-12 col-lg-3">
                                                                                <div class="side_menu">
                                <ul class="nav menu">
<li class="item-225"><a href="/" >Home</a></li><li class="item-133 active deeper parent"><a href="/about-liveu" >Company</a><ul class="nav-child unstyled small"><li class="item-144"><a href="/about-liveu" >About LiveU</a></li><li class="item-142"><a href="/the-liveu-advantage" >The LiveU Advantage</a></li><li class="item-343"><a href="/case-study-archive" >Case Studies</a></li><li class="item-327"><a href="/our-distributors" >Our Distributors </a></li><li class="item-166 current active"><a href="/careers" >Careers</a></li></ul></li><li class="item-134 deeper parent"><a href="/products" >Products</a><ul class="nav-child unstyled small"><li class="item-140 divider deeper parent"><span class="separator">
	Field units</span>
<ul class="nav-child unstyled small"><li class="item-168"><a href="/lu500" >LU500 SERIES</a></li><li class="item-346"><a href="/lu200" >LU200 Series</a></li><li class="item-173"><a href="/lu400" >LU400 Series</a></li><li class="item-177"><a href="/lu70" >LU70 Series</a></li><li class="item-176"><a href="/liveu-xtender" >LiveU Xtender</a></li></ul></li><li class="item-141 divider deeper parent"><span class="separator">
	Software</span>
<ul class="nav-child unstyled small"><li class="item-143"><a href="/lu-smart" >LU-Smart</a></li><li class="item-178"><a href="/lu-lite" >LU-Lite Series</a></li></ul></li><li class="item-681 divider deeper parent"><span class="separator">
	Servers</span>
<ul class="nav-child unstyled small"><li class="item-682"><a href="/the-liveu-family-of-products/lu2000" >LU2000</a></li></ul></li><li class="item-685 divider deeper parent"><span class="separator">
	Encoders</span>
<ul class="nav-child unstyled small"><li class="item-174"><a href="/lu700" >LU700 Series</a></li><li class="item-347"><a href="/lu200e" >LU200e</a></li></ul></li></ul></li><li class="item-135 deeper parent"><a href="/ip-services" >IP Services</a><ul class="nav-child unstyled small"><li class="item-179"><a href="/liveu-central" >LiveU Central</a></li><li class="item-687 divider deeper parent"><span class="separator">
	Distribution Solutions</span>
<ul class="nav-child unstyled small"><li class="item-688"><a href="/ip-services/liveu-singlepoint" >LiveU SinglePoint</a></li><li class="item-689"><a href="/ip-services/liveu-interpoint" >LiveU InterPoint</a></li><li class="item-180"><a href="/liveu-mulitpoint" >LiveU MultiPoint</a></li></ul></li><li class="item-182"><a href="/liveu-community" >LiveU Community</a></li><li class="item-171"><a href="/befirst" >Be.First</a></li><li class="item-211"><a href="/ip-services/panasonic-integration" >Panasonic Connectivity </a></li></ul></li><li class="item-183 deeper parent"><a href="/solutions" >Solutions</a><ul class="nav-child unstyled small"><li class="item-196"><a href="/global-events" >Global Events</a></li><li class="item-184"><a href="/broadcast" >Broadcast Television</a></li><li class="item-199"><a href="/vehicle-solutions" >Vehicle Solutions</a></li><li class="item-191"><a href="/satellite-solutions" >Satellite Solutions</a></li><li class="item-189"><a href="/sports" >Sports</a></li><li class="item-190"><a href="/public-safety" >Public Safety</a></li></ul></li><li class="item-145 deeper parent"><a href="/news" >News</a><ul class="nav-child unstyled small"><li class="item-146"><a href="/liveu-news/press-releases" >Press releases</a></li><li class="item-192"><a href="/liveu-news/press-clippings" >Press Clippings</a></li><li class="item-193"><a href="/media-kit" >Media Kit</a></li><li class="item-195"><a href="/liveu-news/trade-shows" >Trade Shows</a></li></ul></li><li class="item-690 deeper parent"><a href="/support" >Support</a><ul class="nav-child unstyled small"><li class="item-691"><a href="/support/usb-modems" >USB Modems</a></li><li class="item-692"><a href="/support/sla" >SLA Operation</a></li></ul></li><li class="item-175"><a href="/contact-us" >Contact Us</a></li></ul>

								
                            </div>
                            							
                            
							
                                            </div>
                </div>
            </div>
			        </div>
				<div class="footer">
            <div class="container">
                <div class="row">
                    <div class="Copyright">
                       

<div class="custom"  >
	<p>Copyright©2015 LiveU</p>
<p><a href="/terms-of-use">Terms of Use</a></p>
<p><a href="/privacy-policy">Privacy Policy</a></p>
<p><a href="/patents">Patents</a></p></div>

                    </div>
                    <div class="footer_link">
                        <!-- BEGIN: Custom advanced (www.pluginaria.com) -->
<ul>
<li><a target="_blank"  class="fa fa-facebook" href="https://www.facebook.com/LiveU.Fans"></a></li>
<li><a class="fa fa-twitter" target="_blank" href="https://twitter.com/LiveU"></a></li>
<li><a target="_blank" class="fa fa-youtube" href="https://www.youtube.com/user/liveUtv"></a></li>
<li><a target="_blank" class="fa fa-google-plus" href="https://plus.google.com/+LiveuTv/posts"></a></li>
<li><a target="_blank" class="fa fa-instagram" href="https://instagram.com/liveutv/"></a></li>
<li><a target="_blank" class="fa fa-linkedin" href="https://www.linkedin.com/company/liveu"></a></li>
<li><a target="_blank" class="fa fa-pinterest-p" href="https://www.pinterest.com/Liveutv/"></a></li>
</ul><!-- END: Custom advanced (www.pluginaria.com) -->

                    </div>
                </div>
            </div>
		</div>
                <!-- BEGIN: Custom advanced (www.pluginaria.com) -->
<!-- Google Code for Remarketing Tag -->
<!--------------------------------------------------
Remarketing tags may not be associated with personally identifiable information or placed on pages related to sensitive categories. See more information and instructions on how to setup the tag on: http://google.com/ads/remarketingsetup
--------------------------------------------------->
<script type="text/javascript">
/* <![CDATA[ */
var google_conversion_id = 982392778;
var google_custom_params = window.google_tag_params;
var google_remarketing_only = true;
/* ]]> */
</script>
<script type="text/javascript" src="//www.googleadservices.com/pagead/conversion.js">
</script>
<noscript>
<div style="display:inline;">
<img height="1" width="1" style="border-style:none;" alt="" src="//googleads.g.doubleclick.net/pagead/viewthroughconversion/982392778/?value=0&amp;guid=ON&amp;script=0"/>
</div>
</noscript>
<!-- END: Custom advanced (www.pluginaria.com) -->

    </body>
</html>', 
N'LiveU', getdate(), 'http://www.liveu.tv/careers', null)

/*
select 'new Keyword { Name = "' + Name +  '", CultureName = "' + CultureName + '", Values = "' + Value + '" },' from Resources
*/


