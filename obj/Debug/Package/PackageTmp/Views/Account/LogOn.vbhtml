@ModelType LEMS.UserAccount

@Code
    ViewData("Title") = "Login"
End Code






@Using Html.BeginForm()
    @Html.ValidationSummary(True)
    @<fieldset>
        <legend>Login</legend>

       
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
        <div class="editor-field" id="pass-field">
            @Html.EditorFor(Function(model) model.Password)
            @Html.ValidationMessageFor(Function(model) model.Password)
        </div>

        

        <p>
            <input type="submit" value="Login" />
        </p>
    </fieldset>
End Using
<p>Don't have an account Register @Html.ActionLink("Here","Register")</p>
<div>
    @Html.ActionLink("Back", "Index","Start")
</div>
