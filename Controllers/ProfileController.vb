Imports System.Data.Entity

Namespace LEMS
    <Authorize(Roles:="admin,admin1")>
    Public Class ProfileController
        Inherits System.Web.Mvc.Controller

        Private db As New LemsDataEntities

        '
        ' GET: /Profile/

        Function Index() As ViewResult
            Return View(db.Profiles.ToList())
        End Function

        '
        ' GET: /Profile/Details/5

        Function Details(ByVal id As Integer) As ViewResult
            Dim profile As Profile = db.Profiles.Single(Function(p) p.ID = id)
            Return View(profile)
        End Function

        '
        ' GET: /Profile/Create

        Function Create() As ViewResult
            Return View()
        End Function

        '
        ' POST: /Profile/Create

        <HttpPost()>
        Function Create(ByVal profile As Profile) As ActionResult

            If ModelState.IsValid Then
                Dim acc As Integer = profile.AccountNo
                Dim available = From m In db.Profiles
                               Where m.AccountNo = acc
                               Select m.AccountNo

                If available.Any() Then
                    ModelState.AddModelError("", "Account Number Exists!")
                    Return View()
                End If
                db.Profiles.AddObject(profile)
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If

            Return View(profile)
        End Function

        '
        ' GET: /Profile/Edit/5

        Function Edit(ByVal id As Integer) As ViewResult
            Dim profile As Profile = db.Profiles.Single(Function(p) p.ID = id)
            Return View(profile)
        End Function

        '
        ' POST: /Profile/Edit/5

        <HttpPost()>
        Function Edit(ByVal profile As Profile) As ActionResult
            If ModelState.IsValid Then
                db.Profiles.Attach(profile)
                db.ObjectStateManager.ChangeObjectState(profile, EntityState.Modified)
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If

            Return View(profile)
        End Function

        '
        ' GET: /Profile/Delete/5

        Function Delete(ByVal id As Integer) As ViewResult
            Dim profile As Profile = db.Profiles.Single(Function(p) p.ID = id)
            Return View(profile)
        End Function

        '
        ' POST: /Profile/Delete/5

        <HttpPost()>
        <ActionName("Delete")>
        Function DeleteConfirmed(ByVal id As Integer) As RedirectToRouteResult
            Dim profile As Profile = db.Profiles.Single(Function(p) p.ID = id)
            db.Profiles.DeleteObject(profile)
            db.SaveChanges()
            Return RedirectToAction("Index")
        End Function

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            db.Dispose()
            MyBase.Dispose(disposing)
        End Sub

    End Class
End Namespace