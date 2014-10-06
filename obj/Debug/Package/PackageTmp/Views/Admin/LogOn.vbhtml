@ModelType LEMS.Admin

@Code
    Layout = Nothing
End Code

<!DOCTYPE html>

<html>
<head runat="server">
    <meta name="viewport" content="width=device-width" />
    <title>LogOn</title>
    <link href="@Url.Content("~/Content/Site.css")" rel="stylesheet" type="text/css" />
    <link href="@Url.Content("~/Content/css/bootstrap.min.css")" rel="stylesheet" type="text/css" />
    <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.11.1/jquery.min.js" type="text/javascript"></script>
    <script language="JavaScript" type="text/javascript" src="@Url.Content("~/Scripts/bootstrap.min.js")"></script>
    <script type="text/javascript">
        $(document).ready(function () {
        
            $('input:text').addClass('form-control')
            $('input:submit').addClass('btn btn-info');
        });
    </script>
    <style type="text/css">
    fieldset,#back a
    {
         margin-left:400px;
         margin-right:400px;
        }
        .editor-field
        {
            width:150px;
            }
        
    </style>
</head>
<body id="admin">
    <div class='activities'>
Admin Logon
</div>
    <div id="admin-form">
    @Using Html.BeginForm()
        @Html.ValidationSummary(True)
        @<fieldset>
            <legend>Admin Login</legend>
    
            
    
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
    
    
            <div class="submit-login">
                <input type="submit" value="Login" />
            </div>
        </fieldset>
    End Using
    
    <div id="back">
        @Html.ActionLink("Back", "Index","Start")
    </div>
    </div>
</body>
</html>
