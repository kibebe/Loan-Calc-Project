<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width" />
    <title>@ViewData("Title")</title>
    
    
    <link href="@Url.Content("~/Content/Site.css")" rel="stylesheet" type="text/css" />
    <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.11.1/jquery.min.js" type="text/javascript"></script>
    <script src="@Url.Content("~/Scripts/jquery.validate.min.js")" type="text/javascript"></script>
  <script src="@Url.Content("~/Scripts/jquery.unobtrusive-ajax.min.js")" type="text/javascript"></script>
    <script src="@Url.Content("~/Scripts/modernizr-2.0.6-development-only.js")" type="text/javascript"></script>
     <script  type="text/javascript" src="@Url.Content("~/Scripts/jquery.cookie.js")"></script>
     @RenderSection("JS",False) 
     <script  type="text/javascript">jQuery.ready()</script>  
    
</head>

<body>
<div class="main">
<div class="menu">
       <ul id="menuitems">
                    <li>@Html.ActionLink("Home", "Index", "Home")</li>
                    <li>@Html.ActionLink("About", "About", "Home")</li>
                    <li>@Html.ActionLink("Contact us", "Index", "Contact")</li>
                    <li>@Html.ActionLink("Notifications", "Notification", "Home")</li>
                </ul>
</div>
<div class="header">
@Html.ActionLink("Loan Calculator", "Index", "Home")
</div>
</div>
    @RenderBody()
 <script  type="text/javascript" src="@Url.Content("~/Scripts/Lems.js")"></script>
</body>
</html>
