Imports System.Data.Entity
Imports LEMS.LoanDBcontext__LEMS

Namespace LEMS
    <Authorize(Roles:="admin, admin1")>
    Public Class LoanController
        Inherits System.Web.Mvc.Controller

        Private db As New Mvc_
        Private db1 As New LemsDataEntities
        '
        ' GET: /Loan/

        Function Index(Optional ByVal username As String = "") As ViewResult
            ViewBag.Username = username
            Dim unreadMsgs = From m In db1.Messages
                       Where m.MarkRead = 0
                       Select m.AccountNo

            Dim names = New List(Of String)
            Dim trackNewlist = New List(Of Integer)
            Dim ids = New List(Of Integer)
            Dim trackCount = New List(Of Integer)
            Dim countNew As Integer

            If unreadMsgs.Any() Then
                countNew = (From m In db1.Messages
                          Where m.[New] = 1
                          Select m.[New]).Count()
                Dim trackaccn = New List(Of Integer)
                Dim i As Integer = 0
                For Each acc In unreadMsgs
                    Dim accno As Integer = acc
                    Dim name = (From m In db1.Profiles
                               Where m.AccountNo = accno
                               Select m.FirstName).Single()

                    If Not trackaccn.Contains(accno) Then
                        names.Add(name)
                        Dim tracknew = From m In db1.Messages
                                     Where m.AccountNo = accno
                                     Select m.[New]

                        Dim indId = (From m In db1.Messages
                                  Where m.AccountNo = accno
                                  Select m.ID).First()

                        For Each item In tracknew
                            Dim currentitem = item
                            If currentitem = 1 Then
                                i = i + 1
                            End If
                        Next
                        If tracknew.Contains(1) Then
                            trackNewlist.Add(1)
                        Else
                            trackNewlist.Add(0)
                        End If
                        'unique identifiers
                        ids.Add(indId)
                        'individual number of new messages
                        trackCount.Add(i)
                        i = 0
                    End If
                    trackaccn.Add(accno)

                Next
            End If

            ViewBag.IndividualNew = trackNewlist
            If countNew <> 0 Then
                ViewBag.NewMsgs = countNew
            Else
                ViewBag.NewMsgs = 0
            End If
            ViewBag.Ids = ids
            ViewBag.IndividualCount = trackCount
            ViewBag.Names = names
            Return View(db.Loans.ToList())
        End Function

        '
        ' GET: /Loan/Details/5

        Function Details(ByVal id As Integer) As ViewResult
            Dim loan As Loan = db.Loans.Find(id)
            Return View(loan)
        End Function

        '
        ' GET: /Loan/Create

        Function Create() As ViewResult
            Return View()
        End Function

        '
        ' POST: /Loan/Create

        <HttpPost()>
        Function Create(ByVal loan As Loan) As ActionResult
            If ModelState.IsValid Then
                db.Loans.Add(loan)
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If

            Return View(loan)
        End Function

        '
        ' GET: /Loan/Edit/5

        Function Edit(ByVal id As Integer) As ViewResult
            Dim loan As Loan = db.Loans.Find(id)
            Return View(loan)
        End Function

        '
        ' POST: /Loan/Edit/5

        <HttpPost()>
        Function Edit(ByVal loan As Loan) As ActionResult
            If ModelState.IsValid Then
                db.Entry(loan).State = EntityState.Modified
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If

            Return View(loan)
        End Function

        '
        ' GET: /Loan/Delete/5

        Function Delete(ByVal id As Integer) As ViewResult
            Dim loan As Loan = db.Loans.Find(id)
            Return View(loan)
        End Function

        '
        ' POST: /Loan/Delete/5

        <HttpPost()>
        <ActionName("Delete")>
        Function DeleteConfirmed(ByVal id As Integer) As RedirectToRouteResult
            Dim loan As Loan = db.Loans.Find(id)
            db.Loans.Remove(loan)
            db.SaveChanges()
            Return RedirectToAction("Index")
        End Function

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            db.Dispose()
            MyBase.Dispose(disposing)
        End Sub
        ''Audit records user hits
        Function AuditRecords() As ViewResult
            Dim auditsrec = New LemsDataEntities().Audits.ToList()
            Return View(auditsrec)
        End Function
        Function AuditStatus() As ViewResult
            Dim audit_state_rec = New LemsDataEntities().StateAudits.ToList()
            Return View(audit_state_rec)
        End Function
        Function AdminDetailAudit() As ViewResult
            Dim admin_audit_rec = New LemsDataEntities().AdminDetailAudits.ToList()
            Return View(admin_audit_rec)
        End Function
    End Class
End Namespace