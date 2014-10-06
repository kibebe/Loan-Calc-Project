@ModelType LEMS.UserTable

@Code
    
    Layout=Nothing
End Code
<html>
<head>
<title>Login</title>

<link href="@Url.Content("~/Content/css/bootstrap.min.css")" rel="stylesheet" type="text/css" />

 <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.11.1/jquery.min.js" type="text/javascript"></script>
<script language="JavaScript" type="text/javascript" src="@Url.Content("~/Scripts/bootstrap.min.js")"></script>
<script language="JavaScript" type="text/javascript" src="@Url.Content("~/Scripts/notify.mini.js")"></script>
<script src="@Url.Content("~/Scripts/jquery.validate.min.js")" type="text/javascript"></script>
<script src="@Url.Content("~/Scripts/jquery.validate.unobtrusive.min.js")" type="text/javascript"></script>
<style type="text/css">
    body
    {
        background-color:#e0e0eb;
        }
     fieldset,div a,p
    {
     
      margin-left:350px;
      margin-right:250px;
    
        }
        table td
        {
            padding:5px;
         
            }
            .activities
            {
           background-color:#29293d;
           padding:50px;
           margin-left:70px;
           margin-right:70px;
           text-align:center;
           color:Blue;
                }
                .field-validation-error
{
    color: #ff0000;
}

.field-validation-valid
{
    display: none;
}

.input-validation-error
{
    border: 1px solid #ff0000;
    background-color: #ffeeee;
}

.validation-summary-errors
{
    font-weight: bold;
    color: #ff0000;
    margin-left:300px;
    margin-right:300px;
}

.validation-summary-valid
{
    display: none;
}

</style>

<script type="text/javascript">
    $(document).ready(function () {
        $('form').attr({ 'role': 'form', 'id': 'login-form' });
        $('input:text').addClass('form-control')
        $('input:submit').addClass('btn btn-info');
        var success = parseInt($('#success-reset').html(), 10);
        if (success == 1) {
            $.notify.defaults({ autoHideDelay: 25000 });
            $('input:submit').notify('You have succesfully reset your password, \n use your new pasword to login.. ', 'success');
        }
    });
</script>
</head>
<body>
<div class='activities'>
<h2>Log on</h2>
</div>
@Using Html.BeginForm()
    @<div class="form-group">
    @Html.ValidationSummary(True)
    <fieldset>
        <legend>Login</legend>
        <table>
        <tr><td>
        <div class="editor-label">
            @Html.LabelFor(Function(model) model.AccountNo)
        </div>
        </td>
        <td>
        <div class="editor-label">
            @Html.LabelFor(Function(model) model.Email)
        </div>
        </td>
        </tr>
        <tr><td>
        <div class="editor-field">
            @Html.EditorFor(Function(model) model.AccountNo)
            @Html.ValidationMessageFor(Function(model) model.AccountNo)
        </div>
        </td>
        
        <td>
        <div class="editor-field">
        
            @Html.EditorFor(Function(model) model.Email)
         
            @Html.ValidationMessageFor(Function(model) model.Email)
        </div>
        </td></tr>
        <tr><td>
        <div class="editor-label">
            @Html.LabelFor(Function(model) model.Password)
        </div>
        </td>
        <td>
         &nbsp;
        </td>
        </tr>
        <tr><td>
        <div class="editor-field">
            @Html.EditorFor(Function(model) model.Password)
            @Html.ValidationMessageFor(Function(model) model.Password)
        </div>
        </td>
       
        <td>
        
            <input type="submit" value="Login" />
         </td></tr>
        
        </table>
    </fieldset>
    </div>
End Using
<p><em>Don't have an account?</em> @Html.ActionLink("Create Account", "Register")</p>
<p><em>Forgot Password?</em> @Html.ActionLink("Recover", "LostPassword")</p>
<div>
    @Html.ActionLink("Back", "Index","Start")
</div>
<div id="success-reset" style="display:none">@ViewBag.Success</div>
</body>
</html>