@ModelType LEMS.Admin

@Code
    Layout=Nothing
End Code
<html>
<head>
<title>New Admin</title>
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
<div id="create-admin">
<h2>Create New Admin</h2>
@Using Html.BeginForm()
    @Html.ValidationSummary(True)
    @<fieldset>
        <legend>Admin</legend>

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
            @Html.LabelFor(Function(model) model.Email)
        </div>
        <div class="editor-field">
            @Html.EditorFor(Function(model) model.Email)
            @Html.ValidationMessageFor(Function(model) model.Email)
        </div>

        <div class="editor-label">
            @Html.LabelFor(Function(model) model.Username)
        </div>
        <div class="editor-field">
            @Html.EditorFor(Function(model) model.Username)
            @Html.ValidationMessageFor(Function(model) model.Username)
        </div>

        <div class="editor-label">
            @Html.LabelFor(Function(model) model.Password)
        </div>
        <div class="editor-field">
            @Html.EditorFor(Function(model) model.Password)
            @Html.ValidationMessageFor(Function(model) model.Password)
        </div>

        <div class="editor-label">
            @Html.LabelFor(Function(model) model.ConfirmPassword)
        </div>
        <div class="editor-field">
            @Html.EditorFor(Function(model) model.ConfirmPassword)
            @Html.ValidationMessageFor(Function(model) model.ConfirmPassword)
        </div>

        <div class="editor-label">
            @Html.LabelFor(Function(model) model.DateCreated)
        </div>
        <div class="editor-field">
            @Html.EditorFor(Function(model) model.DateCreated)
            @Html.ValidationMessageFor(Function(model) model.DateCreated)
        </div>
          <div class="editor-label">
            @Html.LabelFor(Function(model) model.Roles)
        </div>
        <div class="editor-field">
            @Html.EditorFor(Function(model) model.Roles)
            @Html.ValidationMessageFor(Function(model) model.Roles)
        </div>
        <p>
            <input type="submit" value="Create" />
        </p>
    </fieldset>
End Using

<div>
    @Html.ActionLink("Back", "Index","Loan")
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
