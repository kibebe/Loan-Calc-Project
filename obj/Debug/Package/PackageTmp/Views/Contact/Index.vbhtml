@ModelType LEMS.contact

@Code
    ViewData("Title") = "Contact Us"
End Code

@Section JS
<script type="text/javascript" src="http://cdnjs.cloudflare.com/ajax/libs/jquery-form-validator/2.1.47/jquery.form-validator.min.js"></script>
<script language="JavaScript" type="text/javascript" src="@Url.Content("~/Scripts/notify.mini.js")"></script>
<script src="@Url.Content("~/Scripts/jquery.validate.min.js")" type="text/javascript"></script>
<script src="@Url.Content("~/Scripts/jquery.validate.unobtrusive.min.js")" type="text/javascript"></script>
<script type="text/javascript">
    $(document).ready(function () {
        $('#menuitems li:last').hide();
        var contactSuccess = parseInt($('#contact-success').html(), 10);

        if (contactSuccess == 1) {
            $.notify.defaults({ autoHideDelay: 25000 });
            $('.Logout-user').notify('Your message was sent succesfully, \n We will get back to you soon.\n Thank you.. ', 'success');

        }
        var email = $('#username').html();
        var fname = $('#fname').html();
        $('#Email').val(email).attr('readonly', 'readonly').css('color', 'gray');
        $('#Name').val(fname).attr('readonly', 'readonly').css('color', 'gray');
    });
</script>
End Section
<ul class="Logout-user">

<li>@Html.ActionLink("Log Out","Index","LogOut")</li>
</ul>
<div id="contact-form">

@Using Html.BeginForm()
    @Html.ValidationSummary(True)
    @<fieldset>
        <legend>Contact Us</legend>

        <div class="editor-label">
            @Html.LabelFor(Function(model) model.Name)
        </div>
        <div class="editor-field">
            @Html.EditorFor(Function(model) model.Name)
            @Html.ValidationMessageFor(Function(model) model.Name)
        </div>

        <div class="editor-label">
            @Html.LabelFor(Function(model) model.Subject)
        </div>
        <div class="editor-field">
            @Html.EditorFor(Function(model) model.Subject)
            @Html.ValidationMessageFor(Function(model) model.Subject)
        </div>

        <div class="editor-label">
            @Html.LabelFor(Function(model) model.Email)
        </div>
        <div class="editor-field">
            @Html.EditorFor(Function(model) model.Email)
            @Html.ValidationMessageFor(Function(model) model.Email)
        </div>

        <div class="editor-label">
            @Html.LabelFor(Function(model) model.Comment)
        </div>
        <div class="editor-field">
            @Html.TextAreaFor(Function(model) model.Comment,10,45,vbnull)
            @Html.ValidationMessageFor(Function(model) model.Comment)
        </div>

        <p>
            <input type="submit" value="Send" />
            <input type="reset" value="Reset" />
        </p>
    </fieldset>
End Using

<div>
    @Html.ActionLink("Back", "Index","Home")
</div>
<div id="contact-success" style="display:none">@ViewBag.Success</div>
<div id="username" style="display:none">@ViewBag.Email</div>
<div id="fname" style="display:none">@ViewBag.Fname</div>
</div>