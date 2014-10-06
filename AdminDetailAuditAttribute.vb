Public Class AdminDetailAuditAttribute
    Inherits ActionFilterAttribute
    Dim db As LemsDataEntities = New LemsDataEntities()
    Public Overrides Sub OnActionExecuting(filterContext As System.Web.Mvc.ActionExecutingContext)
        Dim request = filterContext.HttpContext.Request

        Dim fname As String
        Dim lname As String
        Dim email As String
        Dim username As String
        Dim fullname As String
        Dim time As String
        Dim role As String


        fname = request.Form("FirstName")
        lname = request.Form("LastName")
        email = request.Form("Email")
        username = request.Form("Username")
        time = request.Form("DateCreated")
        role = request.Form("Roles")
        fname = fname.Trim()
        lname = lname.Trim()
        email = email.Trim()
        username = username.Trim()
        time.Trim()
        fullname = fname & " " & lname
    
        Dim audit As New AdminDetailAudit With _
            {
                .Name = fullname,
                .Email = email,
                .UserName = username,
                .Timestamp = time,
                .Roles = role
            }
        db.AdminDetailAudits.AddObject(audit)
        db.SaveChanges()
        MyBase.OnActionExecuting(filterContext)
    End Sub
End Class
