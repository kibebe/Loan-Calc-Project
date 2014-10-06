@Code
    Layout = Nothing
End Code

<!DOCTYPE html>

<html>
<head runat="server">
    <meta name="viewport" content="width=device-width" />
    <title>Loan Calculator</title>
    <link href="@Url.Content("~/Content/Site.css")" rel="stylesheet" type="text/css" />
     <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.11.1/jquery.min.js" type="text/javascript"></script>
      <script  type="text/javascript">
          $(document).ready(function () {
              $('ul#loglist li').hover(
function () {
    $(this).css("background-color", "#19ff19");
}, function () {
    $(this).css("background-color", "Gray");
});
          });
      </script>
     
</head>
<body>
    <div id="start">
    <ul id="heading">
    
      <li> <h1>Loan Calculator</h1></li>
      <li> <h2>Get Started....</h2></li>
       </ul> 
       <p>Find a convinient way to determine how much you can borrow.<br />
       Based n various methods of loan calculation.
       </p>
       <p>Login @Html.ActionLink("here", "LogOn", "UserLogin") to continue </p>
       <div id="loglink">
       <ul id="loglist">
       <li>@Html.ActionLink("Login", "LogOn", "UserLogin")</li>
       <li>@Html.ActionLink("Register", "Register", "UserLogin")</li>
       <li>@Html.ActionLink("Admin", "LogOn", "Admin")</li>
       </ul>
       </div>
    </div>
    <footer>
            
                <div class="float-left">
                    <p>&copy; Fintech LTD @DateTime.Now.Year </p>
                </div>
                <div class="float-right">
                    <ul id="social">
                        <li><a href="http://facebook.com" class="facebook">Facebook</a></li>
                        <li><a href="http://twitter.com" class="twitter">Twitter</a></li>
                    </ul>
                </div>
           
        </footer>
    <script  type="text/javascript">jQuery.ready()</script>
</body>
</html>
