@ModelType LEMS.LostPassword

@Code
    Layout = Nothing
End Code

<!DOCTYPE html>

<html>
<head runat="server">
    <meta name="viewport" content="width=device-width" />
    <title>Password Recovery</title>

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
#reset-form input[type="text"]
{
    width:145px;
    }
</style>
<script type="text/javascript">
    $(document).ready(function () {
        $('form').attr({ 'role': 'form', 'id': 'reset-form' });
        $('input:text').addClass('form-control')
        $('input:submit').addClass('btn btn-info');
        var reset = parseInt($('#reset-success').html(), 10);
        if (reset == 1) {
            $.notify.defaults({ autoHideDelay: 25000 });
            $('#recover-submit').notify('A reset link have been sent to your email.\n Follow the link to reset your password. \n The link expires in 30 minutes ', 'success');
        }
        else if (reset == 0) {

            $.notify.defaults({ autoHideDelay: 25000 })
            $('#recover-submit').notify('Error in sending email ', 'error');
        }
        else if (reset == 2) {
            $.notify.defaults({ autoHideDelay: 25000 })
            $('#recover-submit').notify('Your link have expired.\n Generate another link by submiting \n your email again. ', 'warn');
        }
    });
</script>
</head>
<body>
    <div class='activities'>
<h2>Recover Password</h2>
</div>
    @Using Html.BeginForm()
        @Html.ValidationSummary(True)
        @<fieldset>
            <legend>Recover Password</legend>
                <table>
                    <tr>
                        <td>
                            <div class="editor-label">
                                @Html.LabelFor(Function(model) model.Email)
                             </div>
                       </td>
                   </tr>
                   <tr>
                       <td>
                           <div class="editor-field">
                               @Html.EditorFor(Function(model) model.Email)
                               @Html.ValidationMessageFor(Function(model) model.Email)
                           </div>
                       </td>
                   </tr>
                   <tr>
                       <td>
                           <input type="submit" value="Recover Password" id="recover-submit" />
                       </td>
                   </tr>
               </table>
        </fieldset>
    End Using
    
    <div>
        @Html.ActionLink("Back", "LogOn")
    </div>
    <div id="reset-success">@Viewbag.Success</div>
</body>
</html>
