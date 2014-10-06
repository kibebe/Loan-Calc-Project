@ModelType LEMS.Application

@Code
    ViewData("Title") = "Details"
End Code

<h2>Details</h2>

<fieldset>
    <legend>Application</legend>

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
        @Html.DisplayNameFor(Function(model) model.AccountNo)
    </div>
    <div class="display-field">
        @Html.DisplayFor(Function(model) model.AccountNo)
    </div>

    <div class="display-label">
        @Html.DisplayNameFor(Function(model) model.LoanType)
    </div>
    <div class="display-field">
        @Html.DisplayFor(Function(model) model.LoanType)
    </div>

    <div class="display-label">
        @Html.DisplayNameFor(Function(model) model.Principle)
    </div>
    <div class="display-field">
        @Html.DisplayFor(Function(model) model.Principle)
    </div>

    <div class="display-label">
        @Html.DisplayNameFor(Function(model) model.InterestRate)
    </div>
    <div class="display-field">
        @Html.DisplayFor(Function(model) model.InterestRate)
    </div>

    <div class="display-label">
        @Html.DisplayNameFor(Function(model) model.TotalInterest)
    </div>
    <div class="display-field">
        @Html.DisplayFor(Function(model) model.TotalInterest)
    </div>

    <div class="display-label">
        @Html.DisplayNameFor(Function(model) model.TotalInstalments)
    </div>
    <div class="display-field">
        @Html.DisplayFor(Function(model) model.TotalInstalments)
    </div>

    <div class="display-label">
        @Html.DisplayNameFor(Function(model) model.Date)
    </div>
    <div class="display-field">
        @Html.DisplayFor(Function(model) model.Date)
    </div>
</fieldset>
<p>

    @Html.ActionLink("Edit", "Edit", New With {.id = Model.ID}) |
    @Html.ActionLink("Back to List", "Index")
</p>
