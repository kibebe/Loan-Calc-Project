@Code
    ViewData("Title") = "Loan Calculator"
End Code

@Section JS
<script type="text/javascript" src="http://cdnjs.cloudflare.com/ajax/libs/jquery-form-validator/2.1.47/jquery.form-validator.min.js"></script>
<script type="text/javascript">
    $(document).ready(function () {
        $('#loans table td:eq(0)')
        .css({ "background-color": "#660033", "font-size": "20px","text-align":"center","color":"white"})
        .removeAttr("cursor", "pointer");

    });
</script>
End Section
<h3>Choose the loan and enter the share deposit to see your the maximum loan eligible(Edit to your preference)<br />
and enter the number of months. Rate is set for you.
</h3>
<ul class="Logout">
<li>@Html.ActionLink("Log Out","Index","LogOut")</li>
</ul>
<div id="loans">
<hr />
<table border="0">
<tr>
<td>Loans</td>
</tr>
<tr>
<td>
    <input id="Button1" type="button" value="Development Loan" /></td>
</tr>
<tr>
<td><input id="Button2" type="button" value="Emergency Loan" /></td>
</tr>
<tr>
<td><input id="Button3" type="button" value="Instant Loan" /></td>
</tr>
<tr>
<td><input id="Button4" type="button" value="SchoolFees Loan" /></td>
</tr>
</table>
</div>
<div id="loan-calculator">
<form method="post" action="" id="form-calculator">
<table border="0">
    <tr>
        <td>
            <label for="share">Share Deposit</label>
        </td>
    
    
        <td>
            <label for="loan-type" id="loan-type" style="color:Red;font-weight:bold">Select Loan Type:</label>
        </td>
    </tr>
    <tr>
        <td>
            <input id="share" type="text" />
        </td>
          <td>
            <select>
            <option value="" selected="selected">Select Type</option>
            <option value="1">Reducing Balance on Fixed Instalments</option>
            <option value="2">Reducing Balance on Fixed Principle</option>
            <option value="3">Reducing Balance on Flat rate</option>
            </select>
        </td>
       </tr>
    <tr>
        <td>
            <label for="max-loan">Maximum Loan:(Edit)</label>
        </td>
        <td>
            <label for="duration">Duration:in months</label>
        </td>
        <td>
            <label for="rate">Interest rate:(Default)</label>
        </td>
    </tr>
    <tr>
        <td>
            <input id="max-loan" type="text" />
        </td>
        <td>
            <input id="duration" type="text" />
        </td>
        <td>
            <input id="rate" type="text" />
        </td>
    </tr>
    <tr>
    <td>
        <input id="Submit1" type="submit" value="Calculate" /></td>
    </tr>
</table>
</form>
</div>