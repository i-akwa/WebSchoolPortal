<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="comingsoon.aspx.cs" Inherits="WebSchoolPortal.App_Resources.Pages.Teachers.comingsoon" %>

<!DOCTYPE html>
<!--[if lt IE 7]>      <html class="no-js lt-ie9 lt-ie8 lt-ie7"> <![endif]-->
<!--[if IE 7]>         <html class="no-js lt-ie9 lt-ie8"> <![endif]-->
<!--[if IE 8]>         <html class="no-js lt-ie9"> <![endif]-->
<!--[if gt IE 8]><!-->
<html class="no-js" xmlns="http://www.w3.org/1999/xhtml">
	<!--<![endif]-->

<head id="Head1" runat="server">
    <meta charset="utf-8"/>
		<meta http-equiv="X-UA-Compatible" content="IE=edge"/>
		<title>Automated SchoolS</title>
		<meta name="description" content=""/>
		<meta name="viewport" content="width=device-width, initial-scale=1"/>

		<link href="favicon.ico" rel="shortcut icon" type="image/x-icon" />
		<link href='http://fonts.googleapis.com/css?family=Open+Sans:300italic,400italic,600italic,700italic,400,600,700,300' rel='stylesheet' type='text/css'/>
		<link href='http://fonts.googleapis.com/css?family=Exo+2:400,100,100italic,200,200italic,300,300italic,400italic,500,500italic,700,700italic,600,600italic' rel='stylesheet' type='text/css'/>
		<link href='http://fonts.googleapis.com/css?family=Josefin+Sans:100,300,400,600' rel='stylesheet' type='text/css'/>
    <link href="../AllGeneral/comingsoon/css/normalize.css" rel="stylesheet" />
    <link href="../AllGeneral/comingsoon/css/component.css" rel="stylesheet" />
    <link href="../AllGeneral/comingsoon/css/bg-slider.css" rel="stylesheet" />
    <link href="../AllGeneral/comingsoon/clock/css/clock.css" rel="stylesheet" />
    <link href="../AllGeneral/comingsoon/css/main.css" rel="stylesheet" />
    <link href="../AllGeneral/comingsoon/css/responsive.css" rel="stylesheet" />
    <script src="../AllGeneral/comingsoon/js/vendor/modernizr-2.6.2.min.js"></script>

		
</head>

<body class="rain-bg">
    <form id="form1" runat="server">
         <div class="clearfix" style="height:300px;"></div>
		
		<section class="main-menu-container">


           

          
			<div class="show_toggle"> <asp:LinkButton ID="LinkButton2" ToolTip="click to go back to dashboard" runat="server" PostBackUrl="~/App_Resources/Pages/Teachers/Teachersdashboard.aspx" ></asp:LinkButton></div>
			<ul class="main-menu">
				<li>
                    <asp:LinkButton ID="LinkButton1"  runat="server" PostBackUrl="~/App_Resources/Pages/Teachers/Teachersdashboard.aspx">Home</asp:LinkButton>
					
				</li>
                <!--
				<li>
					<a href="#" data-page="services">Services</a>
				</li>
				<li>
					<a href="#" data-page="about">About</a>
				</li>
				<li>
					<a href="#" data-page="contacts">Contacts</a>
				</li>-->
			</ul>
		</section>
		<section class="twitter-container">
        <div class="twitter">
            <ul class="tweet_list" id="tweet_list">
                <li class="tweet_first tweet_odd">
                    <span class="tweet_text">Automated School Management System
						
                        <br>
                        Check our latest <a href="../../../../features.html">New Features</a></span><span class="tweet_time"><a href="#" title="view tweet on twitter">just now</a></span>
                </li>
                <li class="tweet_even">
                    <span class="tweet_text"><span class="at">@</span><a href="../../../../index.html">Automatedschools</a> <span class="at">@</span><a href="#">teamAlbizzia</a> Greetings :)</span><span class="tweet_time"><a href="http://twitter.com/pixelthrone/status/466325405507387392" title="view tweet on twitter">about an hour ago</a></span>
                </li>
                <li class="tweet_odd">
                    <span class="tweet_text"><span class="at">@</span><a href="http://twitter.com/geeks_in_motion">geeks_in_motion</a> ,hi for a better support please visit our website.we have a great team able to help you. → <a href="../../../../index.html">Automated school management system</a></span><span class="tweet_time"><a href="#" title="view tweet on twitter">about 2 days ago</a></span>
                </li>
            </ul>
        </div>
    </section>

		<section class="mainarea">
			<div id="clock" class="active">
				<div class="clock-container">
					<div id="time-container-wrap">
						<div id="time-container">
							<div class="numbers-container"></div>
							<span id="ticker" class="clock-label">AutoSchools</span>
							<span id="timelable" class="clock-label">TIME LEFT</span>
							<span id="timeleft" class="clock-label">COUNTDOWN</span>
							<figure id="canvas"></figure>
						</div>
					</div>
				</div>
				<h3>This Feature Is Coming Soon</h3>
				<!--<form action="#" class="subscribe" id="subscribe">
					<input type="email" placeholder="Enter your email" class="email form_item requiredField" name="subscribe_email" />
					<input type="submit" class='form_submit' value="subscribe" />
					<div id="form_results"></div>
				</form>-->
			</div>
			<!--<div class="mainarea-content">
				<div id="services" data-page="services" class="side-page side-left went-left">
					<div class="container">
						<h2 class="title">What we do</h2>
						<ul class="services">
							<li>
								<img src="img/icons/promotion-icon.png" alt="" />
								<p>
									Promotion
								</p>
							</li>
							<li>
								<img src="img/icons/web-desing-icon.png" alt="" />
								<p>
									Web Design
								</p>
							</li>
							<li>
								<img src="img/icons/photography-icon.png" alt="" />
								<p>
									Photography
								</p>
							</li>
						</ul>
						<p>
							Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.
						</p>
						<p>
							Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. <a href="#">Excepteur sint occaecat</a> cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum. Sed ut perspiciatis unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam, eaque ipsa quae ab illo inventore veritatis et quasi architecto beatae.
						</p>
					</div>
				</div>
				<div id="about" data-page="about" class="side-page active">
					<div class="container">
						<h2 class="title">Who we are</h2>
						<p>
							Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nulla eget nibh at libero fringilla adipiscing nec ut leo. Etiam nec purus arcu. Morbi sollicitudin at risus id malesuada. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Etiam sed tincidunt arcu. Donec molestie ante sapien, sed molestie est euismod eget. Maecenas ac metus accumsan, scelerisque massa sed, porta est. Aliquam ut mollis mi. Cras id vulputate purus, ac sollicitudin ante.
						</p>
						<p>
							Integer condimentum eu lectus quis semper. Sed id metus magna. Morbi ultrices magna id euismod hendrerit. Pellentesque nec mattis odio, vitae laoreet metus. Sed eget sollicitudin est, vitae accumsan nisi. Fusce consequat imperdiet venenatis. Integer mollis hendrerit facilisis. Praesent vel mattis enim. Integer fringilla et urna vitae rutrum.
						</p>
					</div>
				</div>
				<div id="contacts" data-page="contacts" class="side-page side-right went-right">
					<div class="container">
						<h2 class="title">Get in touch</h2>
						<p>
							Lexington Avenue · New York, NY
							<br>
							P: (123) - 456 789 · email@domain.com
						</p>
						<form id='contacts_form' action="#" class="contact-list">
							<div class="field-row">
								<input class="form_item" type="text" id="name" name="name" placeholder="Name" />
							</div>
							<div class="field-row">
								<input class="form_item" type="email" id="email" name="email" placeholder="E-mail" />
							</div>
							<div class="field-row">
								<input class="form_item" type="text" id="message" name="message" placeholder="Message" />
							</div>
							<div class="field-row">
								<input type="submit" class="form_submit" value="Send Message" />
							</div>
							<div id="contact_results"></div>
						</form>
					</div>
				</div>
			</div>-->
			<a class="close" href="#"><img alt="" src="../AllGeneral/comingsoon/img/close.png" /></a>
		</section>
		<section class="social-container">
			<ul class="social">
				<li>
					<a href="#"><img src="../AllGeneral/comingsoon/img/icons/twitter-icon.png"  alt="" /></a>
				</li>
				<li>
					<a href="#"><img src="../AllGeneral/comingsoon/img/icons/youtube-icon.png" alt="" /></a>
				</li>
				<li>
					<a href="#"><img src="../AllGeneral/comingsoon/img/icons/facebook-icon.png" alt="" /></a>
				</li>
			</ul>
		</section>
        <script src="../AllGeneral/comingsoon/js/vendor/jquery-1.11.1.min.js" charset="utf-8"></script>
        <script src="../AllGeneral/comingsoon/js/vendor/classie.js" charset="utf-8"></script>
        <script src="../AllGeneral/comingsoon/js/vendor/jquery.easing.1.3.js" charset="utf-8"></script>
        <script src="../AllGeneral/comingsoon/js/vendor/jquery.tubular.1.0.js" charset="utf-8"></script>
        <script src="../AllGeneral/comingsoon/js/vendor/jquery.cycle.min.js" charset="utf-8"></script>
        <script src="../AllGeneral/comingsoon/js/plugins.js" charset="utf-8"></script>
        <script src="../AllGeneral/comingsoon/js/main.js" charset="utf-8"></script>


        <script src="../AllGeneral/comingsoon/clock/js/svg.min.js"></script>
        <script src="../AllGeneral/comingsoon/clock/js/svg.easing.min.js"></script>
        <script src="../AllGeneral/comingsoon/clock/js/svg.clock.min.js"></script>
        <script src="../AllGeneral/comingsoon/js/vendor/ThreeWebGL.js"></script>
        <script src="../AllGeneral/comingsoon/js/vendor/ThreeExtras.js"></script>
        <script src="../AllGeneral/comingsoon/clock/js/jquery.timers.min.js"></script>
        <script src="../AllGeneral/comingsoon/clock/js/clock.js"></script>




<script>
    (function (i, s, o, g, r, a, m) {
        i['GoogleAnalyticsObject'] = r; i[r] = i[r] || function () {
            (i[r].q = i[r].q || []).push(arguments)
        }, i[r].l = 1 * new Date(); a = s.createElement(o),
        m = s.getElementsByTagName(o)[0]; a.async = 1; a.src = g; m.parentNode.insertBefore(a, m)
    })(window, document, 'script', '../../www.google-analytics.com/analytics.js', 'ga');

    ga('create', 'UA-68970184-5', 'auto');
    ga('send', 'pageview');
    ga('require', 'linkid');
</script>


<script type="text/javascript">
    (function (d, w, c) {
        (w[c] = w[c] || []).push(function () {
            try {
                w.yaCounter33300115 = new Ya.Metrika({
                    id: 33300115,
                    clickmap: true,
                    trackLinks: true,
                    accurateTrackBounce: true,
                    webvisor: true
                });
            } catch (e) { }
        });

        var n = d.getElementsByTagName("script")[0],
            s = d.createElement("script"),
            f = function () { n.parentNode.insertBefore(s, n); };
        s.type = "text/javascript";
        s.async = true;
        s.src = "../../mc.yandex.ru/metrika/watch.js";

        if (w.opera == "[object Opera]") {
            d.addEventListener("DOMContentLoaded", f, false);
        } else { f(); }
    })(document, window, "yandex_metrika_callbacks");
</script>
<!--<noscript><div><img src="https://mc.yandex.ru/watch/33300115" style="position:absolute; left:-9999px;" alt="" /></div></noscript>-->
</form>
	</body>

</html>
