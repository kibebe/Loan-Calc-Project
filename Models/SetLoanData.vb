Imports System.Data.Entity
Imports LEMS.DetailDBcontext
Public Class SetLoanData
    Private db As New DetailDBcontext
    Private loanValue As Integer
    Private loanValue1 As Integer
    Private loanValueDec As Decimal
    Property monthval() As Integer
        Get
            Return loanValue
        End Get
        Set(ByVal Value As Integer)

            loanValue = Value

        End Set
    End Property
    Property principleval() As Integer
        Get
            Return loanValue1
        End Get
        Set(ByVal Value As Integer)
            loanValue1 = Value
        End Set
    End Property

    Property rateval() As Decimal
        Get
            Return loanValueDec
        End Get
        Set(ByVal Value As Decimal)
            loanValueDec = Value
        End Set
    End Property
    Sub InsertDetail(ByVal irateVal As Decimal, ByVal principleVal As Integer, _
                     ByVal monthsVal As Integer, ByVal type As Integer)


        Dim i As Integer
        Dim reducingPrinciple As Single = principleVal
        Dim monthlyInterest As Single = irateVal / 12
        Dim interest As Single = monthlyInterest / 100 * reducingPrinciple
        Dim monthlyPrinciple As Single = reducingPrinciple / monthsVal
        Dim monthlyInstalments As Single = monthlyPrinciple + interest
        If type = 2 Then
            For i = 1 To monthsVal
                Dim det As New Detail With _
                    {.Month = i,
                     .Principle = reducingPrinciple,
                     .InterestRate = monthlyInterest,
                     .Interest = interest,
                     .MonthlyPrinciple = monthlyPrinciple,
                     .MonthlyInstalments = monthlyInstalments
        }
                reducingPrinciple = reducingPrinciple - monthlyPrinciple
                interest = monthlyInterest / 100 * reducingPrinciple
                monthlyInstalments = monthlyPrinciple + interest
                db.Details.Add(det)
                db.SaveChanges()
            Next
        ElseIf type = 3 Then
            For i = 1 To monthsVal
                Dim det As New Detail With _
                    {.Month = i,
                     .Principle = reducingPrinciple,
                     .InterestRate = monthlyInterest,
                     .Interest = interest,
                     .MonthlyPrinciple = monthlyPrinciple,
                     .MonthlyInstalments = monthlyInstalments
        }
                db.Details.Add(det)
                db.SaveChanges()
            Next
        Else
            monthlyInstalments = reducingPrinciple * (monthlyInterest / 100 / _
                                                      (1 - (1 + monthlyInterest / 100) ^ -monthsVal))
            monthlyPrinciple = monthlyInstalments - interest
            For i = 1 To monthsVal
                Dim det As New Detail With _
                    {.Month = i,
                     .Principle = reducingPrinciple,
                     .InterestRate = monthlyInterest,
                     .Interest = interest,
                     .MonthlyPrinciple = monthlyPrinciple,
                     .MonthlyInstalments = monthlyInstalments
        }
                reducingPrinciple = reducingPrinciple - monthlyPrinciple
                interest = monthlyInterest / 100 * reducingPrinciple
                monthlyPrinciple = monthlyInstalments - interest

                db.Details.Add(det)
                db.SaveChanges()
            Next
        End If
    End Sub
    Sub Delete()
        Dim detail As Detail = New Detail
        If Not (detail Is Nothing) Then
            Dim detRem = From m In db.Details
                              Select m
            For Each item In detRem
                db.Details.Remove(item)
            Next
            db.SaveChanges()
        End If

    End Sub

End Class
