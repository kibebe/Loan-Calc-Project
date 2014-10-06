' Note: For instructions on enabling IIS6 or IIS7 classic mode, 
' visit http://go.microsoft.com/?LinkId=9394802
Imports LEMS.AdminDBcontext__LEMS
Public Class MvcApplication
    Inherits System.Web.HttpApplication
    Private db As New Mvc_
    Shared Sub RegisterGlobalFilters(ByVal filters As GlobalFilterCollection)
        filters.Add(New HandleErrorAttribute())
        filters.Add(New System.Web.Mvc.AuthorizeAttribute())
    End Sub

    Shared Sub RegisterRoutes(ByVal routes As RouteCollection)
        routes.IgnoreRoute("{resource}.axd/{*pathInfo}")
        routes.IgnoreRoute("{resource}.aspx/{*pathInfo}")

        ' MapRoute takes the following parameters, in order:
        ' (1) Route name
        ' (2) URL with parameters
        ' (3) Parameter defaults
        routes.MapRoute( _
            "Default", _
            "{controller}/{action}/{id}", _
            New With {.controller = "Start", .action = "Index", .id = UrlParameter.Optional} _
        )

    End Sub

    Sub Application_Start()
        System.Data.Entity.Database.SetInitializer(Of UserAccountDBcontext)(New LEMS.Models.AccountInitializer())
        System.Data.Entity.Database.SetInitializer(Of LoanDBcontext)(New LEMS.Models.LoanInitializer())
        AreaRegistration.RegisterAllAreas()

        RegisterGlobalFilters(GlobalFilters.Filters)
        RegisterRoutes(RouteTable.Routes)
    End Sub
    Protected Sub Application_PostAuthenticateRequest(ByVal sender As Object, ByVal e As System.EventArgs)
        If FormsAuthentication.CookiesSupported = True Then
            If Not Request.Cookies(FormsAuthentication.FormsCookieName) Is Nothing Then
                Try
                    Dim usernam As String = _
                        FormsAuthentication.Decrypt(Request.Cookies(FormsAuthentication.FormsCookieName).Value).Name
                    Dim role As String = String.Empty
                    db = New AdminDBcontext__LEMS.Mvc_()
                    Dim user = (From m In db.Admins
                               Where (m.Username = usernam)
                               Select m).Single()
                    role = user.Roles
                    HttpContext.Current.User = New System.Security.Principal.GenericPrincipal(
                      New System.Security.Principal.GenericIdentity(usernam, "Forms"), role.Split(";"))

                Catch ex As Exception

                End Try
            End If
        End If
    End Sub
End Class
