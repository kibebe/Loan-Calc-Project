@ModelType LEMS.Application

@Code
    ViewData("Title") = "Edit"
End Code

<h2>Edit</h2>

<script src="@Url.Content("~/Scripts/jquery.validate.min.js")" type="text/javascript"></script>
<script src="@Url.Content("~/Scripts/jquery.validate.unobtrusive.min.js")" type="text/javascript"></script>

@Using Html.BeginForm()
    @Html.ValidationSummary(True)
    @<fieldset>
        <legend>Application</legend>

        @Html.HiddenFor(Function(model) model.ID)

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
        <div class="editor-field">
            @Html.EditorFor(Function(model) model.Email)
            @Html.ValidationMessageFor(Function(model) model.Email)
        </div>

        <div class="editor-label">
            @Html.LabelFor(Function(model) model.AccountNo)
        </div>
        <div class="editor-field">
            @Html.EditorFor(Function(model) model.AccountNo)
            @Html.ValidationMessageFor(Function(model) model.AccountNo)
        </div>

        <div class="editor-label">
            @Html.LabelFor(Function(model) model.LoanType)
        </div>
        <div class="editor-field">
            @Html.EditorFor(Function(model) model.LoanType)
            @Html.ValidationMessageFor(Function(model) model.LoanType)
        </div>

        <div class="editor-label">
            @Html.LabelFor(Function(model) model.Principle)
        </div>
        <div class="editor-field">
            @Html.EditorFor(Function(model) model.Principle)
            @Html.ValidationMessageFor(Function(model) model.Principle)
        </div>

        <div class="editor-label">
            @Html.LabelFor(Function(model) model.InterestRate)
        </div>
        <div class="editor-field">
            @Html.EditorFor(Function(model) model.InterestRate)
            @Html.ValidationMessageFor(Function(model) model.InterestRate)
        </div>

        <div class="editor-label">
            @Html.LabelFor(Function(model) model.TotalInterest)
        </div>
        <div class="editor-field">
            @Html.EditorFor(Function(model) model.TotalInterest)
            @Html.ValidationMessageFor(Function(model) model.TotalInterest)
        </div>

        <div class="editor-label">
            @Html.LabelFor(Function(model) model.TotalInstalments)
        </div>
        <div class="editor-field">
            @Html.EditorFor(Function(model) model.TotalInstalments)
            @Html.ValidationMessageFor(Function(model) model.TotalInstalments)
        </div>

        <div class="editor-label">
            @Html.LabelFor(Function(model) model.Date)
        </div>
        <div class="editor-field">
            @Html.EditorFor(Function(model) model.Date)
            @Html.ValidationMessageFor(Function(model) model.Date)
        </div>

        <p>
            <input type="submit" value="Save" />
        </p>
    </fieldset>
End Using

<div>
    @Html.ActionLink("Back to List", "Index")
</div>
