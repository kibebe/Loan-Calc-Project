@ModelType LEMS.Admin

@Code
    ViewData("Title") = "Details"
End Code

<h2>Details</h2>

<fieldset>
    <legend>Admin</legend>

    <div class="display-label">
        @Html.DisplayNameFor(Function(model) model.FirstName)
    </div>
    <div class="display-field">
        @Html.DisplayFor(Function(model) model.FirstName)
    </div>

    <div class="display-label">
        @Html.DisplayNameFor(Function(model) model.LastName)
    </div>
    <div class="display-field">
        @Html.DisplayFor(Function(model) model.LastName)
    </div>

    <div class="display-label">
        @Html.DisplayNameFor(Function(model) model.Email)
    </div>
    <div class="display-field">
        @Html.DisplayFor(Function(model) model.Email)
    </div>

    <div class="display-label">
        @Html.DisplayNameFor(Function(model) model.Username)
    </div>
    <div class="display-field">
        @Html.DisplayFor(Function(model) model.Username)
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

    <div class="display-label">
        @Html.DisplayNameFor(Function(model) model.DateCreated)
    </div>
    <div class="display-field">
        @Html.DisplayFor(Function(model) model.DateCreated)
    </div>
</fieldset>
<p>

    @Html.ActionLink("Edit", "Edit", New With {.id = Model.ID}) |
    @Html.ActionLink("Back to List", "Index")
</p>
