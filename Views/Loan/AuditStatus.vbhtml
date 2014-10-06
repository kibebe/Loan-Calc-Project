@ModelType IEnumerable(Of LEMS.StateAudit)

@Code
    Layout = Nothing
End Code

<!DOCTYPE html>

<html>
<head runat="server">
    <meta name="viewport" content="width=device-width" />
    <title>Audit Loan Status</title>
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
<div id="loan-state-trails">
<h3>Tracking Actions on Loan Status</h3>
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
                @Html.DisplayNameFor(Function(model) model.LoanType)
            </th>
            <th>
                @Html.DisplayNameFor(Function(model) model.Status)
            </th>
            <th>
                @Html.DisplayNameFor(Function(model) model.TimeStamp)
            </th>
      
        </tr>
    
    @For Each item In Model
        Dim currentItem = item
        @<tr>
            <td>
                @Html.DisplayFor(Function(modelItem) currentItem.Name)
            </td>
            <td>
                @Html.DisplayFor(Function(modelItem) currentItem.LoanType)
            </td>
            <td>
                @Html.DisplayFor(Function(modelItem) currentItem.Status)
            </td>
            <td>
                @Html.DisplayFor(Function(modelItem) currentItem.TimeStamp)
            </td>
   
        </tr>
    Next
    
    </table>
    </div>
</body>
</html>
