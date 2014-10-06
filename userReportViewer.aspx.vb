Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports CrystalDecisions.ReportSource
Public Class userReportViewer
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim report As ReportDocument = New ReportDocument()
        report.Load(Server.MapPath("crUsers.rpt"))
        CrystalReportViewer2.ReportSource = report
        CrystalReportViewer2.RefreshReport()
    End Sub

End Class