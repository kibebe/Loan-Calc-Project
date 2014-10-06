@ModelType LEMS.UserTable

@Code
    Layout = Nothing
End Code

<!DOCTYPE html>

<html>
<head runat="server">
    <meta name="viewport" content="width=device-width" />
    <title>Reset Password</title>

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
     fieldset,div a
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
        $('form').attr({ 'role': 'form', 'id': 'reset1-form' });
        $('input:text').addClass('form-control')
        $('input:submit').addClass('btn btn-info');
       
    });
</script>
</head>
<body>
    <div class='activities'>
<h2>Reset Password</h2>
</div>
    @Using Html.BeginForm()
        @Html.ValidationSummary(True)
        @<fieldset>
            <legend>Reset password</legend>
                <table>
                    <tr>
                        <td>
                            <div class="editor-label">
                                @Html.LabelFor(Function(model) model.Password)
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <div class="editor-field">
                                @Html.EditorFor(Function(model) model.Password)
                                @Html.ValidationMessageFor(Function(model) model.Password)
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <div class="editor-label">
                                @Html.LabelFor(Function(model) model.ConfirmPassword)
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <div class="editor-field">
                                @Html.EditorFor(Function(model) model.ConfirmPassword)
                                @Html.ValidationMessageFor(Function(model) model.ConfirmPassword)
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <input type="submit" value="Reset Password" id="reset-submit" />
                        </td>
                    </tr>
                </table>
        </fieldset>
    End Using
    
    <div>
        @Html.ActionLink("Back", "LogOn")
    </div>
    
</body>
</html>
