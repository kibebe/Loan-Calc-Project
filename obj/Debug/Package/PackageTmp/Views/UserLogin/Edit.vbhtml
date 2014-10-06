@ModelType LEMS.UserTable

@Code
    ViewData("Title") = "Edit"
End Code

<h2>Edit</h2>

<script src="@Url.Content("~/Scripts/jquery.validate.min.js")" type="text/javascript"></script>
<script src="@Url.Content("~/Scripts/jquery.validate.unobtrusive.min.js")" type="text/javascript"></script>

@Using Html.BeginForm()
    @Html.ValidationSummary(True)
    @<fieldset>
        <legend>UserTable</legend>

        @Html.HiddenFor(Function(model) model.ID)

        <div class="editor-label">
            @Html.LabelFor(Function(model) model.AccountNo)
        </div>
        <div class="editor-field">
            @Html.EditorFor(Function(model) model.AccountNo)
            @Html.ValidationMessageFor(Function(model) model.AccountNo)
        </div>

        <div class="editor-label">
            @Html.LabelFor(Function(model) model.Email)
        </div>
        <div class="editor-field">
            @Html.EditorFor(Function(model) model.Email)
            @Html.ValidationMessageFor(Function(model) model.Email)
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

        <p>
            <input type="submit" value="Save" />
        </p>
    </fieldset>
End Using

<div>
    @Html.ActionLink("Back to List", "Index")
</div>
