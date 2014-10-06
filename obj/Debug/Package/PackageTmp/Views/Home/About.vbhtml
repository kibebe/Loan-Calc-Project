@Code
    ViewData("Title") = "About"
End Code

<h3>About</h3>
<div id="about">

This loan calculator allows you to get a payment schedule on loans available under three calculation
methods, Namely:<ol><li>Reducing balance on fixed principle</li>
<li>Reducing balance on fixed instalments</li>
<li>Flat rate</li>
</ol> 
<p>You can also apply for a loan on details based on your loan repayment schedule.</p>
<p>@Html.ActionLink("Calculate Loan","Index","Home")</p>
</div>