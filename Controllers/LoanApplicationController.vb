Imports System.Data.Entity

Namespace LEMS

    Public Class LoanApplicationController
        Inherits System.Web.Mvc.Controller

        Private db As New LemsDataEntities

        '
        ' GET: /LoanApplication/
        <Authorize(Roles:="admin,admin1")>
        Function Index() As ViewResult
            Return View(db.Applications.ToList())
        End Function

        '
        ' GET: /LoanApplication/Details/5
        <Authorize(Roles:="admin,admin1")>
        Function Details(ByVal id As Integer) As ViewResult
            Dim application As Application = db.Applications.Single(Function(a) a.ID = id)
            Return View(application)
        End Function

        '
        ' GET: /LoanApplication/Create

        Function Create() As ViewResult
            Return View()
        End Function

        '
        ' POST: /LoanApplication/Create

        <HttpPost()>
        Function Create(ByVal application As Application) As ActionResult
            If ModelState.IsValid Then
                Dim accnt As Integer = application.AccountNo
                db.Applications.AddObject(application)
                db.SaveChanges()
                Dim succesful As Integer = 1
                Return RedirectToAction("Index", "Home", New With {.accounts = accnt, .success = succesful})
            End If

            Return View(application)
        End Function

        '
        ' GET: /LoanApplication/Edit/5
        <Authorize(Roles:="admin,admin1")>
        Function Edit(ByVal id As Integer) As ViewResult
            Dim application As Application = db.Applications.Single(Function(a) a.ID = id)
            Return View(application)
        End Function

        '
        ' POST: /LoanApplication/Edit/5
        <Authorize(Roles:="admin,admin1")>
        <HttpPost()>
        Function Edit(ByVal application As Application) As ActionResult
            If ModelState.IsValid Then
                db.Applications.Attach(application)
                db.ObjectStateManager.ChangeObjectState(application, EntityState.Modified)
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If

            Return View(application)
        End Function

        '
        ' GET: /LoanApplication/Delete/5
        <Authorize(Roles:="admin,admin1")>
        Function Delete(ByVal id As Integer) As ViewResult
            Dim application As Application = db.Applications.Single(Function(a) a.ID = id)
            Return View(application)
        End Function

        '
        ' POST: /LoanApplication/Delete/5
        <Authorize(Roles:="admin,admin1")>
        <HttpPost()>
        <ActionName("Delete")>
        Function DeleteConfirmed(ByVal id As Integer) As RedirectToRouteResult
            Dim application As Application = db.Applications.Single(Function(a) a.ID = id)
            db.Applications.DeleteObject(application)
            db.SaveChanges()
            Return RedirectToAction("Index")
        End Function

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            db.Dispose()
            MyBase.Dispose(disposing)
        End Sub
        <StatusAudit()>
        Sub LoanStatus(ByVal idstate As Integer, ByVal account As Integer)
            Dim rflag As Integer = 0
            Dim statetb As New Statu With _
                {.AccountNo = account,
                 .State = idstate,
                 .Read = rflag
                    }
            db.Status.AddObject(statetb)
            db.SaveChanges()
            Return
        End Sub
    End Class
End Namespace