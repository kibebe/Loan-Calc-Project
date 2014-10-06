Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.Mvc
Imports System.Net.Mail

Namespace LEMS
    Public Class ContactController
        Inherits System.Web.Mvc.Controller
        Private db As New LemsDataEntities
        '
        ' GET: /Contact

        Function Index() As ActionResult
            Dim username As String = _
                       FormsAuthentication.Decrypt _
                       (Request.Cookies(FormsAuthentication.FormsCookieName).Value).Name
            Dim acc = (From m In db.UserTables
                     Where m.Email = username
                     Select m.AccountNo).Single()
            Dim fname = (From m In db.Profiles
                      Where m.AccountNo = acc
                      Select m.FirstName).Single()
            ViewBag.Fname = fname
            ViewBag.Email = username
            Return View()
        End Function
        '
        ' POST: /Contact
        <HttpPost()>
        Function Index(ByVal c As contact) As ActionResult
            If ModelState.IsValid Then
                Dim useremail As String = c.Email
                'Try
                Dim accno = (From m In db.UserTables
                           Where m.Email = useremail
                           Select m.AccountNo).Single()

                'Get submite values
                Dim name As String = c.Name
                Dim subject As String = c.Subject
                Dim comment As String = c.Comment
                Dim msgread As Integer = 0

                'populate message tracking table
                Dim msgnew As Integer = 1
                Dim msgtrack As New Message With
                    {.AccountNo = accno,
                     .MarkRead = msgread,
                     .[New] = msgnew
                    }
                db.Messages.AddObject(msgtrack)

                'populate contact table
                Dim msg As New contact With
                    {
                        .Name = name,
                        .Subject = subject,
                        .Email = useremail,
                        .Comment = comment,
                        .TimeSent = Date.Now
                    }
                db.contacts.AddObject(msg)
                'Save changes to db
                db.SaveChanges()
                ViewBag.Success = 1
                Dim username As String = _
                                        FormsAuthentication.Decrypt _
                                        (Request.Cookies(FormsAuthentication.FormsCookieName).Value).Name
                Dim acc = (From m In db.UserTables
                            Where m.Email = username
                            Select m.AccountNo).Single()
                Dim fname = (From m In db.Profiles
                            Where m.AccountNo = acc
                            Select m.FirstName).Single()
                ViewBag.Fname = fname
                ViewBag.Email = username
                Return View()

            End If
            Return View()
        End Function
        Function Messaging(ByVal uid As Integer) As ActionResult
            Dim ids = New List(Of Integer)
            Dim accno = (From m In db.Messages
                        Where m.ID = uid
                        Select m.AccountNo).Single()

            Dim useremail = (From m In db.UserTables
                        Where m.AccountNo = accno
                        Select m.Email).Single()
            Dim msgcontainer = From m In db.contacts
                              Where m.Email = useremail
                              Order By m.TimeSent Descending
                              Select m
            Dim idcontainer = From m In db.contacts
                              Where m.Email = useremail
                              Order By m.TimeSent Descending
                              Select m.ID

            For Each item In idcontainer
                ids.Add(item)
            Next
            ViewBag.Ids = ids
            Return View(msgcontainer.ToList())
        End Function
        Function ViewDetail(ByVal id As Integer, ByVal puid As Integer) As ActionResult
            Dim msgdetail = (From m In db.contacts
                          Where m.ID = id
                          Select m).Single()

            ViewBag.Puid = puid
            Return View(msgdetail)
        End Function
        Sub NewToOld()
            Dim fieldnew = From m In db.Messages
                           Where m.[New] = 1
                         Select m

            For Each item In fieldnew
                item.[New] = 0
            Next
            db.SaveChanges()
        End Sub
    End Class
End Namespace