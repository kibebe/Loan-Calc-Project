@ModelType LEMS.contact

@Code
    Layout = Nothing
End Code

<!DOCTYPE html>

<html>
<head runat="server">
    <meta name="viewport" content="width=device-width" />
    <title>ViewDetail</title>
<link href="@Url.Content("~/Content/Site.css")" rel="stylesheet" type="text/css" />
     <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.11.1/jquery.min.js" type="text/javascript"></script>
     <script  type="text/javascript" src="@Url.Content("~/Scripts/jquery.cookie.js")"></script>
     <script type="text/javascript" src="http://cdnjs.cloudflare.com/ajax/libs/jquery-form-validator/2.1.47/jquery.form-validator.min.js"></script>
     <script  type="text/javascript" src="@Url.Content("~/Scripts/Lems.js")"></script>
     <style type="text/css">
     th,td
     {
         width:190px;
         }

             .home
             {
                 position:absolute;
                 top:150px;
                 left:305px;
                 font-size:23px;
                 }
                 .container
                 {
                     margin-left:300px;
                     margin-right:200px;
                     }
     </style>
</head>
<body class="admin-page" style="background-color:#B2B2B2">
  <div class="admin-header"><h2>Administration</h2></div>
   <ul class="Logout">
<li>@Html.ActionLink("Log Out","LogOut","Admin")</li>
</ul>
<div class="home">@Html.ActionLink("Home", "Index","Loan")</div>
         <h3>Message Details</h3>
<div class="container">
    <table>
        <tr>
            <td style="color:#333399">
                @Html.DisplayNameFor(Function(model) model.Name):
            </td>
             <td>
                @Html.DisplayFor(Function(model) model.Name)    
            </td>
        </tr>
        <tr>
            <td style="color:#333399">
                @Html.DisplayNameFor(Function(model) model.Email):
            </td>
            <td>
                @Html.DisplayFor(Function(model) model.Email)
            </td>
        </tr>
        <tr>
            <td style="color:#333399">
                @Html.DisplayNameFor(Function(model) model.TimeSent):
            </td>
            <td>
                @Html.DisplayFor(Function(model) model.TimeSent)
            </td>
        </tr>
        <tr>
            <td style="color:#333399">
                @Html.DisplayNameFor(Function(model) model.Subject):
            </td>
            <td>
                @Html.DisplayFor(Function(model) model.Subject)
            </td>
        </tr>
    </table>
              <textarea rows="5" cols="50" readonly="readonly">  @Html.DisplayFor(Function(model) model.Comment)</textarea> 
  

    <p>
    @code
        Dim persId As Integer=ViewBag.Puid
    End Code
        @Html.ActionLink("Back", "Messaging",New With{.uid=persId})
    </p>
</div>
</body>
</html>
