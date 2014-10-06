@ModelType IEnumerable(Of LEMS.Audit)

@Code
    Layout = Nothing
End Code

<!DOCTYPE html>

<html>
<head runat="server">
    <meta name="viewport" content="width=device-width" />
    <title>Audit Records</title>
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
<div id="action-trails">
<h3>Tracking User Actions</h3>
<ul class="trail-list">
<li>@Html.ActionLink("Home", "Index")</li>
<li><a href="\trackUserActions.aspx?">Report</a></li>
</ul> 
    <table id="actions">
        <tr>
             <th>
             @Html.DisplayNameFor(Function(model) model.Name)
             </th>
            <th>
                @Html.DisplayNameFor(Function(model) model.UserName)
            </th>
            <th>
                @Html.DisplayNameFor(Function(model) model.IPAddress)
            </th>
            <th>
                @Html.DisplayNameFor(Function(model) model.AreaAccessed)
            </th>
            <th>
                @Html.DisplayNameFor(Function(model) model.Timestamp)
            </th>
           
        </tr>
    
    @For Each item In Model
        Dim currentItem = item
        @<tr>
        <td>
             @Html.DisplayFor(Function(modelItem) currentItem.Name)
            </td>
            <td>
                @Html.DisplayFor(Function(modelItem) currentItem.UserName)
            </td>
            <td>
            &nbsp; &nbsp; &nbsp;
                @Html.DisplayFor(Function(modelItem) currentItem.IPAddress)
            </td>
            <td>
                @Html.DisplayFor(Function(modelItem) currentItem.AreaAccessed)
            </td>
            <td>
                @Html.DisplayFor(Function(modelItem) currentItem.Timestamp)
            </td>
            
        </tr>
    Next
    
    </table>
    </div>
</body>
</html>
