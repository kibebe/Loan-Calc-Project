@Code
    Layout=Nothing
End Code
<h2>Loan Application Details</h2>
<form action="/LoanApplication/Create" method="post" id="loan-form">
<table style="width: 100%;">
    <tr>
    <td>
      <label for="fname">First Name</label></td>
      <td><input type="text" id="FirstName" name="FirstName" value="@ViewBag.FirstName" /></td>
       
    </tr>
    <tr>
     <td><label for="lname">Last Name</label></td>
      <td><input type="text" id="LastName" name="LastName" value="@ViewBag.LastName" /></td>   
      
    </tr>
        <tr>
     <td><label for="email">Email</label></td>
      <td><input type="text" id="Email" name="Email" value="@ViewBag.Email" /></td>   
      
    </tr>
    <tr>
     <td><label for="acc-no">Account Number</label></td>
      <td><input type="text" id="AccountNo" name="AccountNo" value="@ViewBag.AccNo" /></td>
    </tr>
        <tr>
     <td><label for="loan-definition">Loan Type</label></td>
      <td><input type="text" id="LoanType" name="LoanType" value="@ViewBag.LoanType" /></td>
    </tr>
    <tr>
     <td><label for="loan-principle">Amount to Apply</label></td>
      <td><input type="text" id="Principle" name="Principle" value="@ViewBag.AmountRequested" /></td>
    </tr>
     <tr>
     <td><label for="loan-rate">Rate(per/month)</label></td>
      <td><input type="text" id="InterestRate" name="InterestRate"  value="@ViewBag.Rate" /></td>
    </tr>
     <tr>
     <td><label for="loan-interest">Total Interest</label></td>
      <td><input type="text" id="TotalInterest" name="TotalInterest" value="@ViewBag.TotalInterest" /></td>
    </tr>
     <tr>
     <td><label for="loan-instalments">Total Repayment</label></td>
      <td><input type="text" id="TotalInstalents" name="TotalInstalments" value="@ViewBag.Instalments" /></td>
    </tr>
    <tr>
     <td><label for="loan-date">Date</label></td>
      <td><input type="text" id="loan-date" name="Date"  /></td>
    </tr>
    <tr><td><input type="submit" value="Submit Details" id="submit-loan"/></td></tr>
</table>
</form>
