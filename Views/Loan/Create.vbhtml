@ModelType LEMS.Loan

@Code
   Layout=Nothing
End Code

<html>
<head>
<title>Loans</title>
<link href="@Url.Content("~/Content/Site.css")" rel="stylesheet" type="text/css" />
<script src="http://ajax.googleapis.com/ajax/libs/jquery/1.11.1/jquery.min.js" type="text/javascript"></script>
   <script src="@Url.Content("~/Scripts/jquery.validate.min.js")" type="text/javascript"></script>
  <script src="@Url.Content("~/Scripts/jquery.unobtrusive-ajax.min.js")" type="text/javascript"></script>
    <script src="@Url.Content("~/Scripts/modernizr-2.0.6-development-only.js")" type="text/javascript"></script>
 <script type="text/javascript" src="http://cdnjs.cloudflare.com/ajax/libs/jquery-form-validator/2.1.47/jquery.form-validator.min.js"></script>
 <script  type="text/javascript" src="@Url.Content("~/Scripts/jquery.cookie.js")"></script>
<script src="@Url.Content("~/Scripts/jquery.validate.min.js")" type="text/javascript"></script>
   <script  type="text/javascript" src="@Url.Content("~/Scripts/Lems.js")"></script>
</head>
<body class="admin-page" style="background-color:#B2B2B2">
<div class="admin-header"><h2>Administration</h2></div>
<ul class="Logout">
<li>@Html.ActionLink("Log Out","LogOut","Admin")</li>
</ul>
<div id="create-loan">
<h2>Create New Loan Details</h2>
@Using Html.BeginForm()
    @Html.ValidationSummary(True)
    @<fieldset>
        <legend>Loan</legend>

        <div class="editor-label">
            @Html.LabelFor(Function(model) model.LoanType)
        </div>
        <div class="editor-field">
            @Html.EditorFor(Function(model) model.LoanType)
            @Html.ValidationMessageFor(Function(model) model.LoanType)
        </div>

        <div class="editor-label">
            @Html.LabelFor(Function(model) model.InterestRate)
        </div>
        <div class="editor-field">
            @Html.EditorFor(Function(model) model.InterestRate)
            @Html.ValidationMessageFor(Function(model) model.InterestRate)
        </div>

        <div class="editor-label">
            @Html.LabelFor(Function(model) model.MaxPeriod)
        </div>
        <div class="editor-field">
            @Html.EditorFor(Function(model) model.MaxPeriod)
            @Html.ValidationMessageFor(Function(model) model.MaxPeriod)
        </div>

        <div class="editor-label">
            @Html.LabelFor(Function(model) model.PeggedOn)
        </div>
        <div class="editor-field">
            @Html.EditorFor(Function(model) model.PeggedOn)
            @Html.ValidationMessageFor(Function(model) model.PeggedOn)
        </div>

        <div class="editor-label">
            @Html.LabelFor(Function(model) model.Factor)
        </div>
        <div class="editor-field">
            @Html.EditorFor(Function(model) model.Factor)
            @Html.ValidationMessageFor(Function(model) model.Factor)
        </div>

        <p>
            <input type="submit" value="Create" />
        </p>
    </fieldset>
End Using

<div>
    @Html.ActionLink("Back to List", "Index")
</div>
</div>
<nav>
  <ul>
    <li>@Html.ActionLink("View Users","Index","Profile")</li>
    <li>
      @Html.ActionLink("Create Users","Create","Profile")
    </li>
    <li>@Html.ActionLink("Loan Applications","Index","LoanApplication")</li>
    <li><a href="#">Reports</a>
  <ul class="fallback">
  <li><a href="/userReportViewer.aspx?">Users</a></li>
  <li><a href="/applicationReportViewer.aspx?">Loan Applications</a></li>
    <li><a href="/applicationGraph.aspx?">Application Chart</a></li>
  </ul></li>
  </ul>
</nav>
</body>
</html>