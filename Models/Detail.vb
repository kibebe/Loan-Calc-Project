Imports System.Data.Entity
Imports System.ComponentModel.DataAnnotations

Public Class Detail
    Public Property ID() As Integer
    Public Property Month() As Integer
    Public Property Principle() As Single
    Public Property InterestRate() As Single
    Public Property Interest() As Integer
    Public Property MonthlyPrinciple() As Single
    Public Property MonthlyInstalments() As Single
End Class
Public Class DetailDBcontext
    Inherits DbContext
    Public Property Details As DbSet(Of Detail)
End Class