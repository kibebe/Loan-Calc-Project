Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports CrystalDecisions.ReportSource
Public Class applicationReportViewer
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim report As ReportDocument = New ReportDocument()
        report.Load(Server.MapPath("crApplication.rpt"))
        CrystalReportViewer1.ReportSource = report
        CrystalReportViewer1.RefreshReport()
    End Sub

End Class