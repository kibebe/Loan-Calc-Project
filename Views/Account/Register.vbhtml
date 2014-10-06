@ModelType LEMS.UserAccount

@Code
    ViewData("Title") = "Create"
    Layout= Nothing
End Code
<link href="@Url.Content("~/Content/Site.css")" rel="stylesheet" type="text/css" />
<div class='activities'>
<h2>Create Account</h2>
</div>

 <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.11.1/jquery.min.js" type="text/javascript"></script>
   
  <script src="@Url.Content("~/Scripts/jquery.unobtrusive-ajax.min.js")" type="text/javascript"></script>
    <script src="@Url.Content("~/Scripts/modernizr-2.0.6-development-only.js")" type="text/javascript"></script>
 <script type="text/javascript" src="http://cdnjs.cloudflare.com/ajax/libs/jquery-form-validator/2.1.47/jquery.form-validator.min.js"></script>
 
<script type="text/javascript">
    $(document).ready(function () {
        $('#email-field input:text').attr('data-validation', 'email');
        $('#Password').attr('data-validation-strength', 1);
       
    });
</script> 
<script  type="text/javascript" src="@Url.Content("~/Scripts/Lems.js")"></script>


@Using Html.BeginForm()
    @Html.ValidationSummary(True)
    @<fieldset>
        <legend>UserAccount</legend>
        <div class="form-login">
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
        <div class="editor-field" id="email-field">
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
        <div class="editor-field" id="date-field">
            @Html.EditorFor(Function(model) model.DateCreated)
            @Html.ValidationMessageFor(Function(model) model.DateCreated)
        </div>

        <p>
            <input type="submit" value="Create" />
        </p>
        </div>
    </fieldset>
End Using

<div>
    @Html.ActionLink("Back", "Index","Start")
</div>
