Imports System.Data.Entity
Imports LEMS.AdminDBcontext__LEMS

Namespace LEMS
    Public Class AdminController
        Inherits System.Web.Mvc.Controller
        Dim m_hashPassword As HashPassword = New HashPassword()
        Private db As New Mvc_
        '
        ' GET: /Admin/LogOn
        <AllowAnonymous()>
        Function LogOn() As ViewResult
            Return View()
        End Function
        '
        'POST: Admin/LogOn
        <AllowAnonymous()>
        <HttpPost()>
        Function LogOn(ByVal admin As Admin) As ActionResult

            Dim CredLst = New List(Of String)()
            Dim user As String = admin.Username
            Dim pass As String = admin.Password
            If user = String.Empty Or pass = String.Empty Then
                ModelState.AddModelError("", "username or password required")
                Return View("LogOn")
            End If
            pass = m_hashPassword.GetPasswordHash(pass)
            Dim cred = From m In db.Admins
                     Where m.Username = user And m.Password = pass
                     Select m.Password
            CredLst.AddRange(cred)

            If CredLst.Count > 0 Then
                FormsAuthentication.SetAuthCookie(admin.Username, False)
                Return RedirectToAction("Index", "Loan", New With {.username = user})
            Else
                ModelState.AddModelError("", "Invalid username or password")
                Return View("LogOn")
            End If

        End Function
        '
        ' GET: /Admin/
        <Authorize(Roles:="admin")>
        Function Index() As ViewResult
            Return View(db.Admins.ToList())
        End Function

        '
        ' GET: /Admin/Details/5
        <Authorize(Roles:="admin")>
        Function Details(ByVal id As Integer) As ViewResult
            Dim admin As Admin = db.Admins.Find(id)
            Return View(admin)
        End Function

        '
        ' GET: /Admin/Create
        <Authorize(Roles:="admin")>
        Function Create() As ViewResult
            Return View()
        End Function

        '
        ' POST: /Admin/Create
        <AdminDetailAudit()>
        <Authorize(Roles:="admin")>
        <HttpPost()>
        Function Create(ByVal admin As Admin) As ActionResult
            If ModelState.IsValid Then
                Dim pword As String = admin.Password
                Dim cpword As String = admin.ConfirmPassword
                Dim user As String = admin.Username
                Dim useradmin = From m In db.Admins
                               Where m.Username = user
                               Select m.Username

                If useradmin.Any() Then
                    ModelState.AddModelError("", "That username already exists!")
                    Return View("Create")
                End If
                admin.Password = m_hashPassword.GetPasswordHash(pword)
                admin.ConfirmPassword = m_hashPassword.GetPasswordHash(cpword)
                db.Admins.Add(admin)
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If

            Return View(admin)
        End Function
        
        '
        ' GET: /Admin/Edit/5
        <Authorize(Roles:="admin")>
        Function Edit(ByVal id As Integer) As ViewResult
            Dim admin As Admin = db.Admins.Find(id)
            Return View(admin)
        End Function

        '
        ' POST: /Admin/Edit/5
        <Authorize(Roles:="admin")>
        <HttpPost()>
        Function Edit(ByVal admin As Admin) As ActionResult
            If ModelState.IsValid Then
                db.Entry(admin).State = EntityState.Modified
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If

            Return View(admin)
        End Function

        '
        ' GET: /Admin/Delete/5
        <Authorize(Roles:="admin")>
        Function Delete(ByVal id As Integer) As ViewResult
            Dim admin As Admin = db.Admins.Find(id)
            Return View(admin)
        End Function

        '
        ' POST: /Admin/Delete/5
        <Authorize(Roles:="admin")>
        <HttpPost()>
        <ActionName("Delete")>
        Function DeleteConfirmed(ByVal id As Integer) As RedirectToRouteResult
            Dim admin As Admin = db.Admins.Find(id)
            db.Admins.Remove(admin)
            db.SaveChanges()
            Return RedirectToAction("Index")
        End Function

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            db.Dispose()
            MyBase.Dispose(disposing)
        End Sub
        Function LogOut() As ActionResult
            FormsAuthentication.SignOut()
            Return RedirectToAction("LogOn")
        End Function
    End Class
End Namespace