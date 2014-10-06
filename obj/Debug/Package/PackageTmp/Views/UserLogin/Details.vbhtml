@ModelType LEMS.UserTable

@Code
    ViewData("Title") = "Details"
End Code

<h2>Details</h2>

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
<p>

    @Html.ActionLink("Edit", "Edit", New With {.id = Model.ID}) |
    @Html.ActionLink("Back to List", "Index")
</p>
