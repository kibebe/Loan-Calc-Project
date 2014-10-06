Imports LEMS.LoanDBcontext__LEMS
Imports LEMS.SetLoanData
Imports CrystalDecisions.CrystalReports.Engine
Namespace LEMS
    Public Class HomeController
        Inherits System.Web.Mvc.Controller
        Private db As New Mvc_
        Private db1 As New LemsDataEntities
        Dim objSetLoan As SetLoanData
        Dim interestType As Integer
        '
        ' GET: /Home
        <Audit()>
        Function Index(Optional ByVal success As Integer = 0) As ActionResult
            Dim username As String = FormsAuthentication.Decrypt _
                                    (Request.Cookies(FormsAuthentication.FormsCookieName).Value).Name
            Dim accounts = (From m In db1.UserTables
                           Where m.Email = username
                           Select m.AccountNo).Single()


            Try
                Dim available = From m In db1.Status
                                Where m.AccountNo = accounts
                                Select m.AccountNo

                Dim states = (From m In db1.Status
                          Where (m.AccountNo = accounts)
                          Order By m.ID Descending
                          Select m.State).First()
                Dim red = (From m In db1.Status
                          Where (m.AccountNo = accounts)
                          Order By m.ID Descending
                          Select m.Read).First()
                ViewBag.State = states
                ViewBag.Read = red
                ViewBag.Available = 1
            Catch ex As Exception

            End Try
            Dim name = (From m In db1.Profiles
                   Where (m.AccountNo = accounts)
                   Select m.FirstName).Single()
            Dim hasAppliedLoan = From m In db1.Applications
                               Where m.AccountNo = accounts
                               Select m.Email

            If hasAppliedLoan.Any() Then
                ViewBag.Applied = 1
            Else
                ViewBag.Applied = 0
            End If
            ViewBag.Name = name


            ViewBag.Accno = accounts
            ViewBag.Success = success
            Return View(db.Loans.ToList())
        End Function
    

        Function GetRate(ByVal id As Integer) As ActionResult
          
            Dim rate As Loan = db.Loans.Find(id)
         
            Return PartialView("_GetRate", rate)
        End Function
        <HttpPost()>
        Function FixedPrinciple(ByVal irate As Decimal, ByVal principle As Integer, ByVal months As Integer) _
 As ActionResult
            interestType = 2
            objSetLoan = New SetLoanData
            objSetLoan.Delete()
            objSetLoan.InsertDetail(irate, principle, months, interestType)
            objSetLoan.rateval = irate
            objSetLoan.principleval = principle
            objSetLoan.monthval = months
            Return PartialView("FixedPrinciple", objSetLoan)
        End Function
        <HttpPost()>
        Function FlatRate(ByVal irate As Decimal, ByVal principle As Integer, ByVal months As Integer) _
 As ActionResult
            interestType = 3
            objSetLoan = New SetLoanData
            objSetLoan.Delete()
            objSetLoan.InsertDetail(irate, principle, months, interestType)
            objSetLoan.rateval = irate
            objSetLoan.principleval = principle
            objSetLoan.monthval = months
            Return PartialView("FlatRate", objSetLoan)
        End Function
        <HttpPost()>
        Function FixedInstalments(ByVal irate As Decimal, ByVal principle As Integer, ByVal months As Integer) _
 As ActionResult
            interestType = 1
            objSetLoan = New SetLoanData
            objSetLoan.Delete()
            objSetLoan.InsertDetail(irate, principle, months, interestType)
            objSetLoan.rateval = irate
            objSetLoan.principleval = principle
            objSetLoan.monthval = months
            Return PartialView("FixedInstalments", objSetLoan)
        End Function
        <Audit()>
        Function LoanForm(ByVal accounts As Integer, ByVal loanid As Integer, ByVal principle As Integer, _
                          ByVal intrate As Single, ByVal totalint As Single, ByVal totalamount As Single) _
    As ActionResult



            Dim fname = (From m In db1.Profiles
                                 Where (m.AccountNo = accounts)
                                 Select m.FirstName).Single()
            Dim lname = (From m In db1.Profiles
                                 Where (m.AccountNo = accounts)
                                 Select m.LastName).Single()
            Dim emailacc = (From m In db1.UserTables
                                 Where (m.AccountNo = accounts)
                                 Select m.Email).Single()
            Dim type = (From m In db.Loans
                                   Where (m.ID = loanid)
                                   Select m.LoanType).Single()
            Dim amount As Integer = principle
            Dim rate As Single = (intrate / 12) / 100
            Dim interest = totalint
            Dim finalRepayment = totalamount
            ViewBag.FirstName = fname
            ViewBag.LastName = lname
            ViewBag.AccNo = accounts
            ViewBag.Email = emailacc
            ViewBag.LoanType = type
            ViewBag.AmountRequested = amount
            ViewBag.Rate = rate
            ViewBag.TotalInterest = interest
            ViewBag.Instalments = finalRepayment

            Return PartialView("LoanForm")

        End Function
        Sub Notification(ByVal acc As Integer)
            Dim update = (From m In db1.Status
                       Where m.AccountNo = acc
                       Order By m.ID Descending
                       Select m).First()
            update.Read = 1
            db1.SaveChanges()


        End Sub
        Function About() As ViewResult
            Return View()
        End Function
    End Class
End Namespace