Public Class StatusAuditAttribute
    Inherits ActionFilterAttribute
    Dim db As LemsDataEntities = New LemsDataEntities()
    Public Overrides Sub OnActionExecuting(filterContext As System.Web.Mvc.ActionExecutingContext)
        Dim request = filterContext.HttpContext.Request
        Dim accno As Integer
        Dim idstate As Integer
        Dim names As String
        Dim state As String
        Dim ltype As String
        If request.IsAuthenticated Then

            idstate = request.Params("idstate")
            accno = request.Params("account")

            Dim fname = (From m In db.Profiles
                        Where (m.AccountNo = accno)
                        Select m.FirstName).Single()
            Dim lname = (From m In db.Profiles
                        Where (m.AccountNo = accno)
                        Select m.LastName).Single()
            ltype = (From m In db.Applications
                        Where (m.AccountNo = accno)
                        Select m.LoanType).Single()
            fname = fname.Trim()
            lname = lname.Trim()
            names = fname & " " & lname
            If idstate = 1 Then
                state = "Loan Accepted"
            Else
                state = "Loan Rejected"
            End If
        Else
            names = "Anonymous"
            ltype = "Unknown"
            state = "Unknown"
        End If
        Dim audit As New StateAudit With _
            {
                .Name = names,
                .LoanType = ltype,
                .Status = state,
                .TimeStamp = DateTime.Now
            }

        db.StateAudits.AddObject(audit)
        db.SaveChanges()
        MyBase.OnActionExecuting(filterContext)
    End Sub
End Class
