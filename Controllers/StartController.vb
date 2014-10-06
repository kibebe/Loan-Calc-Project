Namespace LEMS
    Public Class StartController
        Inherits System.Web.Mvc.Controller

        '
        ' GET: /Start
        <AllowAnonymous()>
        Function Index() As ActionResult
            Return View()
        End Function

    End Class
End Namespace