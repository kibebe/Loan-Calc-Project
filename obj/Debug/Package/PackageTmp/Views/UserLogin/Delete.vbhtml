@ModelType LEMS.UserTable

@Code
    ViewData("Title") = "Delete"
End Code

<h2>Delete</h2>

<h3>Are you sure you want to delete this?</h3>
<fieldset>
    <legend>UserTable</legend>

    <div class="display-label">
        @Html.DisplayNameFor(Function(model) model.AccountNo)
    </div>
    <div class="display-field">
        @Html.DisplayFor(Function(model) model.AccountNo)
    </div>

    <div class="display-label">
        @Html.DisplayNameFor(Function(model) model.Email)
    </div>
    <div class="display-field">
        @Html.DisplayFor(Function(model) model.Email)
    </div>

    <div class="display-label">
        @Html.DisplayNameFor(Function(model) model.Password)
    </div>
    <div class="display-field">
        @Html.DisplayFor(Function(model) model.Password)
    </div>

    <div class="display-label">
        @Html.DisplayNameFor(Function(model) model.ConfirmPassword)
    </div>
    <div class="display-field">
        @Html.DisplayFor(Function(model) model.ConfirmPassword)
    </div>
</fieldset>
@Using Html.BeginForm()
    @<p>
        <input type="submit" value="Delete" /> |
        @Html.ActionLink("Back to List", "Index")
    </p>
End Using
