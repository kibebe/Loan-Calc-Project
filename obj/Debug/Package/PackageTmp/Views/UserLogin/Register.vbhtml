@ModelType LEMS.UserTable

@Code
   
    Layout=Nothing
End Code

<html>
<head>
<title>Register</title>
<link href="@Url.Content("~/Content/Site.css")" rel="stylesheet" type="text/css" />
<link href="@Url.Content("~/Content/css/bootstrap.min.css")" rel="stylesheet" type="text/css" />

 <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.11.1/jquery.min.js" type="text/javascript"></script>
<script language="JavaScript" type="text/javascript" src="@Url.Content("~/Scripts/bootstrap.min.js")"></script>

<script src="@Url.Content("~/Scripts/jquery.validate.unobtrusive.min.js")" type="text/javascript"></script>

<script type="text/javascript" src="http://cdnjs.cloudflare.com/ajax/libs/jquery-form-validator/2.1.47/jquery.form-validator.min.js"></script>
<script  type="text/javascript" src="@Url.Content("~/Scripts/jquery.cookie.js")"></script>
<script  type="text/javascript" src="@Url.Content("~/Scripts/Lems.js")"></script>
  <script type="text/javascript">
      $(document).ready(function () {

          $('input:text').addClass('form-control')
          $('input:submit').addClass('btn btn-info');
      });
    </script>
<style type="text/css">
  fieldset,div a
    {
     
      margin-left:300px;
      margin-right:300px;
    
        }
        .editor-field input[type="text"]
        {
            width:250px;
            }
</style>
 </head>
 <body>
 <div class="activities">
 Registration Form
 </div>
@Using Html.BeginForm()
    @Html.ValidationSummary(True)
    @<fieldset>
        <legend>Register</legend>

        <div class="editor-label">
            @Html.LabelFor(Function(model) model.AccountNo)
        </div>
        <div class="editor-field">
            @Html.EditorFor(Function(model) model.AccountNo)
            @Html.ValidationMessageFor(Function(model) model.AccountNo)
        </div>

        <div class="editor-label">
            @Html.LabelFor(Function(model) model.Email)
        </div>
        <div class="editor-field">
            @Html.EditorFor(Function(model) model.Email)
            @Html.ValidationMessageFor(Function(model) model.Email)
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

        <div class="submit-login">
            <input type="submit" value="Register" />
            </div>
        
    </fieldset>
End Using

<div id="back-register">
    @Html.ActionLink("Back", "Index","Start")
</div>
</body>
</html>