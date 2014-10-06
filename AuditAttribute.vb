
Public Class AuditAttribute
    Inherits ActionFilterAttribute
    Dim db As LemsDataEntities = New LemsDataEntities()
    Public Overrides Sub OnActionExecuting(filterContext As System.Web.Mvc.ActionExecutingContext)
        Dim request = filterContext.HttpContext.Request
        Dim accno As Integer
        Dim user As String
        Dim names As String
        If request.IsAuthenticated Then
            user = filterContext.HttpContext.User.Identity.Name
            accno = (From m In db.UserTables
                            Where m.Email = user
                            Select m.AccountNo).Single()
            Dim fname = (From m In db.Profiles
                        Where (m.AccountNo = accno)
                        Select m.FirstName).Single()
            Dim lname = (From m In db.Profiles
                        Where (m.AccountNo = accno)
                        Select m.LastName).Single()
            fname = fname.Trim()
            lname = lname.Trim()
            names = fname & " " & lname
        Else
            user = "Anonymous"
            names = user
        End If
        Dim audit As New Audit With _
            {
                .Name = names,
                .UserName = user,
                .IPAddress = If(request.ServerVariables("HTTP_X_FORWARDED_FOR"), request.UserHostAddress),
                .AreaAccessed = request.RawUrl,
                .Timestamp = DateTime.Now
            }

        db.Audits.AddObject(audit)
        db.SaveChanges()
        MyBase.OnActionExecuting(filterContext)
    End Sub
End Class
