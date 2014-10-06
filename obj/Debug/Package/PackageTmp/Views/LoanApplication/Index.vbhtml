@ModelType IEnumerable(Of LEMS.Application)

@Code

    Layout=Nothing
End Code
<html>
<head>
<title>Loan Applications</title>
<link href="@Url.Content("~/Content/Site.css")" rel="stylesheet" type="text/css" />
<script src="http://ajax.googleapis.com/ajax/libs/jquery/1.11.1/jquery.min.js" type="text/javascript"></script>
<script type="text/javascript" src="http://cdnjs.cloudflare.com/ajax/libs/jquery-form-validator/2.1.47/jquery.form-validator.min.js"></script>
<script  type="text/javascript" src="@Url.Content("~/Scripts/jquery.cookie.js")"></script>
<script  type="text/javascript" src="@Url.Content("~/Scripts/Lems.js")"></script>
<style type="text/css">
table tr
{
    font-size:12px;
    }
</style>
</head>
<body>
<div class="admin-header"><h2>Administration</h2></div>
<ul class="Logout">
<li>@Html.ActionLink("Log Out","LogOut","Admin")</li>
</ul>
<nav>
  <ul>
    <li>@Html.ActionLink("View Users","Index","Profile")</li>
    <li>
      @Html.ActionLink("Create Users","Create","Profile")
    </li>
    <li>@Html.ActionLink("Loan Applications","Index","LoanApplication")</li>
    <li><a href="#">Reports</a>
  <ul class="fallback">
  <li><a href="userReportViewer.aspx?">Users</a></li>
  <li><a href="applicationReportViewer.aspx?">Loan Applications</a></li>
  <li><a href="applicationGraph.aspx?">Application Chart</a></li>
  </ul></li>
  </ul>
</nav>

    <h3>Loan Applications</h3>

<table>
    <tr>
        <th>
            @Html.DisplayNameFor(Function(model) model.FirstName)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.LastName)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Email)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.AccountNo)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.LoanType)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Principle)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.InterestRate)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.TotalInterest)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.TotalInstalments)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Date)
        </th>
        <th></th>
    </tr>

@For Each item In Model
    Dim currentItem = item
    @<tr>
        <td>
            @Html.DisplayFor(Function(modelItem) currentItem.FirstName)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) currentItem.LastName)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) currentItem.Email)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) currentItem.AccountNo)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) currentItem.LoanType)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) currentItem.Principle)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) currentItem.InterestRate)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) currentItem.TotalInterest)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) currentItem.TotalInstalments)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) currentItem.Date)
        </td>
        <td><span>
            @Html.ActionLink("Accept", "LoanStatus", New With {.idstate = 1,.account=currentItem.AccountNo}) |
            @Html.ActionLink("Reject", "LoanStatus", New With {.idstate = 0,.account=currentItem.AccountNo})
            </span> |
            @Html.ActionLink("Delete", "Delete", New With {.id = currentItem.ID})
        </td>
    </tr>
Next
<tr><td>@Html.ActionLink("Back","Index","Loan")</td></tr>
</table>

</body>
</html>