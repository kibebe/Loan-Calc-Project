@ModelType LEMS.SetLoanData

@Code
    Dim reducingPrinciple As Integer = Model.principleval
    Dim monthlyInterest As Single=Model.rateval/12
    Dim interestRate As Single = (Model.rateval / 100)/12
    Dim months As Integer = Model.monthval
    Dim monthlyPrinciple As Single = reducingPrinciple / months
    Dim interest As Single = interestRate * reducingPrinciple
    Dim monthlyInstalments As Single = monthlyPrinciple + interest
    Dim countInterest As Single = interest * months
    Dim finalAmount As Single =reducingPrinciple+countInterest
    Dim i As Integer
    End Code

     <table class="display" border="1" width="530px">
     <thead>
       <tr>
       <th>Month</th>
       <th>Principle</th>
       <th>Interest Rate</th>
       <th>Interest</th>
       <th>Monthly Principle</th>
       <th>Monthly Instalments</th>
       </tr>
       </thead>
    @For i = 1 To months 
      
       @<tr>
       <td>@i</td>
       <td>@reducingPrinciple</td>
       <td>@monthlyInterest %</td>
       <td>@interest</td>
       <td>@monthlyPrinciple</td>
       <td>@monthlyInstalments</td>
       </tr>
      
      Next
     </table>
   
        <div class="final-amount"><b>Loan Repayment Amount:</b>@finalAmount</div>
        <div class="final-int">@finalAmount</div>
        <div class="total-interest">@countInterest</div>