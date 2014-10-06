@ModelType IEnumerable(Of LEMS.AdminDetailAudit)

@Code
    Layout = Nothing
End Code

<!DOCTYPE html>

<html>
<head runat="server">
    <meta name="viewport" content="width=device-width" />
    <title>Admin Details Audit</title>
<link href="@Url.Content("~/Content/Site.css")" rel="stylesheet" type="text/css" />
     <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.11.1/jquery.min.js" type="text/javascript"></script>
     <script  type="text/javascript" src="@Url.Content("~/Scripts/jquery.cookie.js")"></script>
     <script type="text/javascript" src="http://cdnjs.cloudflare.com/ajax/libs/jquery-form-validator/2.1.47/jquery.form-validator.min.js"></script>
     <script  type="text/javascript" src="@Url.Content("~/Scripts/Lems.js")"></script>
</head>
<body class="admin-page" style="background-color:#B2B2B2">
  <div class="admin-header"><h2>Administration</h2></div>
   <ul class="Logout">
<li>@Html.ActionLink("Log Out","LogOut","Admin")</li>
</ul>
<div id="admin-detail-trails" style="margin-left:200px">
    <h3>Tracking Admin Added To The Site</h3>
    <ul class="trail-list">
<li>@Html.ActionLink("Home", "Index")</li>
<li><a href="\trackActionStatus.aspx?">Report</a></li>
</ul>
    <table>
        <tr>
            <th>
                @Html.DisplayNameFor(Function(model) model.Name)
            </th>
            <th>
                @Html.DisplayNameFor(Function(model) model.Email)
            </th>
            <th>
                @Html.DisplayNameFor(Function(model) model.UserName)
            </th>
            <th>
                @Html.DisplayNameFor(Function(model) model.Timestamp)
            </th>
            <th>
                @Html.DisplayNameFor(Function(model) model.Roles)
            </th>
       
        </tr>
    
    @For Each item In Model
        Dim currentItem = item
        @<tr>
            <td>
                @Html.DisplayFor(Function(modelItem) currentItem.Name)
            </td>
            <td>
                @Html.DisplayFor(Function(modelItem) currentItem.Email)
            </td>
            <td>
                @Html.DisplayFor(Function(modelItem) currentItem.UserName)
            </td>
            <td>
                @Html.DisplayFor(Function(modelItem) currentItem.Timestamp)
            </td>
            <td>
                @Html.DisplayFor(Function(modelItem) currentItem.Roles)
            </td>
      
        </tr>
    Next
    
    </table>
    </div>
</body>
</html>
