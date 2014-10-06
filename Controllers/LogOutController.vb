Imports System.Data.Entity
Imports LEMS.UserAccountDBcontext__LEMS

Namespace LEMS
    Public Class LogOutController
        Inherits System.Web.Mvc.Controller

        Private db As New Mvc_

        '
        ' GET: /LogOut/

        Function Index() As ActionResult
            FormsAuthentication.SignOut()
            Return RedirectToAction("LogOn", "UserLogin")
        End Function

        '
        ' GET: /LogOut/Details/5

        Function Details(ByVal id As Integer) As ViewResult
            Dim useraccount As UserAccount = db.UserAccounts.Find(id)
            Return View(useraccount)
        End Function

        '
        ' GET: /LogOut/Create

        Function Create() As ViewResult
            return View()
        End Function

        '
        ' POST: /LogOut/Create

        <HttpPost()>
        Function Create(ByVal useraccount As UserAccount) As ActionResult
            If ModelState.IsValid Then
                db.UserAccounts.Add(useraccount)
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If

            Return View(useraccount)
        End Function
        
        '
        ' GET: /LogOut/Edit/5
 
        Function Edit(ByVal id As Integer) As ViewResult
            Dim useraccount As UserAccount = db.UserAccounts.Find(id)
            Return View(useraccount)
        End Function

        '
        ' POST: /LogOut/Edit/5

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
        ' GET: /LogOut/Delete/5
 
        Function Delete(ByVal id As Integer) As ViewResult
            Dim useraccount As UserAccount = db.UserAccounts.Find(id)
            Return View(useraccount)
        End Function

        '
        ' POST: /LogOut/Delete/5

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