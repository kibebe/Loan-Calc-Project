@ModelType LEMS.Profile

@Code
    Layout=Nothing
End Code
<html>
<head>
<title>Edit Profile</title>
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
<div id="edit-profile">


@Using Html.BeginForm()
    @Html.ValidationSummary(True)
    @<fieldset>
        <legend>Profile</legend>

        @Html.HiddenFor(Function(model) model.ID)

        <div class="editor-label">
            @Html.LabelFor(Function(model) model.AccountNo)
        </div>
        <div class="editor-field">
            @Html.EditorFor(Function(model) model.AccountNo)
            @Html.ValidationMessageFor(Function(model) model.AccountNo)
        </div>

        <div class="editor-label">
            @Html.LabelFor(Function(model) model.FirstName)
        </div>
        <div class="editor-field">
            @Html.EditorFor(Function(model) model.FirstName)
            @Html.ValidationMessageFor(Function(model) model.FirstName)
        </div>

        <div class="editor-label">
            @Html.LabelFor(Function(model) model.LastName)
        </div>
        <div class="editor-field">
            @Html.EditorFor(Function(model) model.LastName)
            @Html.ValidationMessageFor(Function(model) model.LastName)
        </div>

        <div class="editor-label">
            @Html.LabelFor(Function(model) model.DateCreated)
        </div>
        <div class="editor-field">
            @Html.EditorFor(Function(model) model.DateCreated)
            @Html.ValidationMessageFor(Function(model) model.DateCreated)
        </div>

        <div class="editor-label">
            @Html.LabelFor(Function(model) model.ShareDeposit)
        </div>
        <div class="editor-field">
            @Html.EditorFor(Function(model) model.ShareDeposit)
            @Html.ValidationMessageFor(Function(model) model.ShareDeposit)
        </div>

        <p>
            <input type="submit" value="Save" />
        </p>
    </fieldset>
End Using

<div>
    @Html.ActionLink("Back", "Index")
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