Imports System.Data.Entity
Imports System.ComponentModel.DataAnnotations
Public Class Loan
    Public Property ID() As Integer
    <Required(ErrorMessage:="Loan requried")>
    <Display(Name:="Type of Loan")>
    Public Property LoanType() As String
    <Required(ErrorMessage:="Interest rate requried")>
    <Display(Name:="Interest Rate")>
    Public Property InterestRate() As Double
    <Required(ErrorMessage:="Enter the maximum period")>
    <Display(Name:="Maximum Repayment Period")>
    Public Property MaxPeriod() As Integer
    <Required(ErrorMessage:="This value is required")>
    <Display(Name:="Pegged On Shares")>
    Public Property PeggedOn() As Boolean
    <Required(ErrorMessage:="Enter the factor")>
    <Display(Name:="Multiplication Factor")>
    Public Property Factor() As Integer
   
End Class
Public Class LoanDBcontext
    Inherits DbContext
    Public Property Loans As DbSet(Of Loan)
End Class

