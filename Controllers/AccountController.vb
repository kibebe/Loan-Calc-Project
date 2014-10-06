Imports System.Data.Entity
Imports LEMS.UserAccountDBcontext__LEMS

Namespace LEMS
    Public Class AccountController
        Inherits System.Web.Mvc.Controller

        Private db As New Models_

        '
        ' GET: /Account/

        Function Index() As ViewResult
            Return View(db.UserAccounts.ToList())
        End Function

        '
        ' GET: /Account/Details/5

        Function Details(ByVal id As Integer) As ViewResult
            Dim useraccount As UserAccount = db.UserAccounts.Find(id)
            Return View(useraccount)
        End Function

        '
        ' GET: /Account/Create
        <AllowAnonymous()>
        Function Register() As ViewResult
            Return View()
        End Function

       

        '
        ' POST: /Account/Create
        <AllowAnonymous()>
        <HttpPost()>
        Function Register(ByVal useraccount As UserAccount) As ActionResult
            If ModelState.IsValid Then
                db.UserAccounts.Add(useraccount)
                db.SaveChanges()
                Return RedirectToAction("LogOn")
            End If

            Return View(useraccount)
        End Function
        '
        ' GET: /Account/LogOn
        <AllowAnonymous()>
        Function LogOn() As ViewResult
            Return View()
        End Function
        '
        'POST: Account/LogOn

        <HttpPost()>
        Function LogOn(ByVal useraccount As UserAccount) As ActionResult

            Dim CredLst = New List(Of String)()
            Dim user As String = useraccount.Username
            Dim pass As String = useraccount.Password
            Dim cred = From m In db.UserAccounts
                     Where m.Username = user And m.Password = pass
                     Select m.Password
            CredLst.AddRange(cred)

            If CredLst.Count > 0 Then
                FormsAuthentication.SetAuthCookie(useraccount.Username, False)
                Return RedirectToAction("Index", "Home")
            Else
                ModelState.AddModelError("", "Invalid username or password")
                Return View("LogOn")
            End If

        End Function
        <AllowAnonymous()>
        Function isExists(ByVal pass As String) As Boolean
            Dim pword As UserAccount = db.UserAccounts.Find(pass)
            If pword Is Nothing Then
                Return False
            Else
                Return True
            End If
        End Function
        '
        ' GET: /Account/Edit/5
 
        Function Edit(ByVal id As Integer) As ViewResult
            Dim useraccount As UserAccount = db.UserAccounts.Find(id)
            Return View(useraccount)
        End Function

        '
        ' POST: /Account/Edit/5

        <HttpPost()>
        Function Edit(ByVal useraccount As UserAccount) As ActionResult
            If ModelState.IsValid Then
                db.Entry(useraccount).State = EntityState.Modified
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If

            Return View(useraccount)
        End Function

        '
        ' GET: /Account/Delete/5
 
        Function Delete(ByVal id As Integer) As ViewResult
            Dim useraccount As UserAccount = db.UserAccounts.Find(id)
            Return View(useraccount)
        End Function

        '
        ' POST: /Account/Delete/5

        <HttpPost()>
        <ActionName("Delete")>
        Function DeleteConfirmed(ByVal id As Integer) As RedirectToRouteResult
            Dim useraccount As UserAccount = db.UserAccounts.Find(id)
            db.UserAccounts.Remove(useraccount)
            db.SaveChanges()
            Return RedirectToAction("Index")
        End Function

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            db.Dispose()
            MyBase.Dispose(disposing)
        End Sub

    End Class
End Namespace