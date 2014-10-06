Imports System.Data.Entity
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.Mvc
Imports System.Net.Mail
Namespace LEMS
    Public Class UserLoginController
        Inherits System.Web.Mvc.Controller

        Private db As New LemsDataEntities
        Dim m_hashPassword As HashPassword = New HashPassword()
        '
        ' GET: /UserLogin/
        <AllowAnonymous()>
        Function Index() As ViewResult
            Return View(db.UserTables.ToList())
        End Function

        '
        ' GET: /UserLogin/Details/5

        Function Details(ByVal id As Integer) As ViewResult
            Dim usertable As UserTable = db.UserTables.Single(Function(u) u.ID = id)
            Return View(usertable)
        End Function

        '
        ' GET: /UserLogin/Create
        <AllowAnonymous()>
        Function Register() As ViewResult
            Return View()
        End Function

        '
        ' POST: /UserLogin/Register
        <AllowAnonymous()>
        <HttpPost()>
        Function Register(ByVal usertable As UserTable) As ActionResult
            If ModelState.IsValid Then
                Dim pword As String = usertable.Password
                Dim cpword As String = usertable.ConfirmPassword

                usertable.Password = m_hashPassword.GetPasswordHash(pword)
                usertable.ConfirmPassword = m_hashPassword.GetPasswordHash(cpword)
                Dim account As String = usertable.AccountNo
                Dim emailuser As String = usertable.Email
                Dim cred = From m In db.Profiles
                           Where m.AccountNo = account
                           Select m.AccountNo

                Dim cred1 = From m In db.UserTables
                           Where m.AccountNo = account
                           Select m.AccountNo

                Dim cred2 = From m In db.UserTables
                           Where m.Email = emailuser
                           Select m.Email

                If Not cred.Any() Then
                    ModelState.AddModelError("", "Account number not valid!")
                    Return View("Register")
                End If
                If cred1.Any() Then
                    ModelState.AddModelError("", "That account number is already registered!")
                    Return View("Register")
                End If
                If cred2.Any() Then
                    ModelState.AddModelError("", "That Email Account is already registered!")
                    Return View("Register")
                End If
                db.UserTables.AddObject(usertable)
                db.SaveChanges()
                Return RedirectToAction("LogOn")
            End If

            Return View(usertable)
        End Function
        '
        ' GET: /UserLogin/LogOn
        <AllowAnonymous()>
        Function LogOn(Optional ByVal success As Integer = 0) As ViewResult
            ViewBag.Success = success
            Return View()
        End Function
        '
        'POST: Account/LogOn
        <AllowAnonymous()>
        <HttpPost()>
        Function LogOn(ByVal useraccount As UserTable, Optional ByVal returnUrl As String = "") As ActionResult


            Dim email As String = useraccount.Email
            Dim pass As String = useraccount.Password
            Dim account As Integer = useraccount.AccountNo
            pass = m_hashPassword.GetPasswordHash(pass)
            Dim cred = From m In db.UserTables
                     Where m.Email = email And m.Password = pass And m.AccountNo = account
                     Select m

            If cred.Any() Then

                FormsAuthentication.SetAuthCookie(useraccount.Email, False)
              
                Return RedirectToAction("Index", "Home")


            Else
                    ModelState.AddModelError("", "Invalid Email, Account Number or password")
                    Return View("LogOn")
                End If

        End Function
        '
        ' GET: /UserLogin/Edit/5
 
        Function Edit(ByVal id As Integer) As ViewResult
            Dim usertable As UserTable = db.UserTables.Single(Function(u) u.ID = id)
            Return View(usertable)
        End Function

        '
        ' POST: /UserLogin/Edit/5

        <HttpPost()>
        Function Edit(ByVal usertable As UserTable) As ActionResult
            If ModelState.IsValid Then
                db.UserTables.Attach(usertable)
                db.ObjectStateManager.ChangeObjectState(usertable, EntityState.Modified)
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If

            Return View(usertable)
        End Function

        '
        ' GET: /UserLogin/Delete/5
 
        Function Delete(ByVal id As Integer) As ViewResult
            Dim usertable As UserTable = db.UserTables.Single(Function(u) u.ID = id)
            Return View(usertable)
        End Function

        '
        ' POST: /UserLogin/Delete/5

        <HttpPost()>
        <ActionName("Delete")>
        Function DeleteConfirmed(ByVal id As Integer) As RedirectToRouteResult
            Dim usertable As UserTable = db.UserTables.Single(Function(u) u.ID = id)
            db.UserTables.DeleteObject(usertable)
            db.SaveChanges()
            Return RedirectToAction("Index")
        End Function

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            db.Dispose()
            MyBase.Dispose(disposing)
        End Sub
        <AllowAnonymous()>
        Public Function LostPassword(Optional ByVal success As Integer = 3) As ActionResult
            ViewBag.Success = success
            Return View()
        End Function
        <AllowAnonymous()>
        <HttpPost()>
        Public Function LostPassword(ByVal model As LostPassword, Optional ByVal success As Integer = 0) As ActionResult
            If ModelState.IsValid Then

                Dim foundUserName = From m In db.UserTables
                                  Where m.Email = model.Email
                                  Select m.Email
                If foundUserName.Any() Then
                    Dim accno = (From m In db.UserTables
                               Where (m.Email = model.Email)
                               Select m.AccountNo).Single()
                    Dim useremail = (From m In db.UserTables
                                 Where (m.Email = model.Email)
                                 Select m.Email).Single()
                    Dim token As Guid = Guid.NewGuid()
                    Dim reset As New Token With _
                        {.Tokenid = token,
                         .AccountNo = accno,
                         .TimeStamp = DateTime.Now
                        }
                    db.Tokens.AddObject(reset)
                    db.SaveChanges()
                    Dim resetlink As String = "<a href='" & Url.Action("ResetPassword", "UserLogin", _
                                                                      New With {.rt = token} _
                                                                      , "http") & "'>Reset Password</a>"
                    Dim subject As String = "Password reset link"
                    Dim body As String = "Please find the reset link " & resetlink
                    Try
                        SendEmail(useremail, subject, body)
                        ViewBag.Success = 1
                        Return View()
                    Catch ex As Exception
                        ViewBag.Success = 0
                        Return View()
                    End Try
                Else
                    ViewBag.Success = 1
                    Return View()
                End If

            End If
            Return View()
        End Function
        <AllowAnonymous()>
        Public Function ResetPassword(ByVal rt As Guid) As ActionResult
            Dim resetime = (From m In db.Tokens
                         Where m.Tokenid = rt
                         Select m.TimeStamp).Single()
            Dim timenow As DateTime = DateTime.Now
            Dim timedifference As TimeSpan = timenow - resetime
            Dim minutes_elapsed = timedifference.Hours * 60 + timedifference.Minutes
            If minutes_elapsed > 30 Then
                Dim suc As Integer = 2
                Return RedirectToAction("LostPassword", New With {.success = suc})
            End If
           
            Return View()
        End Function
        <AllowAnonymous()>
        <HttpPost()>
        Public Function ResetPassword(ByVal rt As Guid, ByVal model As UserTable) As ActionResult
            Dim useraccnt = (From m In db.Tokens
                           Where m.Tokenid = rt
                           Select m.AccountNo).Single()
            Dim pass As String = m_hashPassword.GetPasswordHash(model.Password)
            Dim qry = From m In db.UserTables
                     Where m.AccountNo = useraccnt
                     Select m

            For Each m In qry
                m.Password = pass
            Next
            db.SaveChanges()
            Dim success As Integer = 1
            Return RedirectToAction("LogOn", New With {.success = success})
        End Function
        Private Sub SendEmail(ByVal emailid As String, ByVal subject As String, ByVal body As String)
            Dim client As SmtpClient = New SmtpClient()
            client.DeliveryMethod = SmtpDeliveryMethod.Network
            client.EnableSsl = True
            client.Host = "smtp.gmail.com"
            client.Port = 587
            Dim credentials As System.Net.NetworkCredential = New System.Net.NetworkCredential _
                                                              ("cik.cir@gmail.com", "mzukafullha")
            client.UseDefaultCredentials = False
            client.Credentials = credentials

            Dim msg As MailMessage = New MailMessage()
            msg.From = New MailAddress("cik.cir@gmail.com")
            msg.To.Add(New MailAddress(emailid))

            msg.Subject = subject
            msg.IsBodyHtml = True
            msg.Body = body

            client.Send(msg)
            msg.Dispose()
        End Sub
    End Class
End Namespace