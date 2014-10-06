@ModelType LEMS.Loan
@Code
    Layout = Nothing
End Code
<div id="intrate">@Html.DisplayTextFor(Function(model) model.InterestRate)</div>
<div id="multi-factor">@Html.DisplayTextFor(Function(model) model.Factor)</div>
<div id="max-period">@Html.DisplayTextFor(Function(model) model.MaxPeriod)</div>
<div id="loan-id">@Html.DisplayTextFor(Function(model) model.ID)</div>
