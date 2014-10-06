
Public Class frmReportViewer
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim dsDataSet As New DataSet
        Dim dtDataTable As New DataTable("Detail")
        Dim drNewRow As DataRow
        Dim newContext As New DetailDBcontext
        Dim dsdetail As dsDetail
        Dim crNewReport As New crDetail

        dtDataTable.Columns.Add("Month")
        dtDataTable.Columns.Add("Principle")
        dtDataTable.Columns.Add("InterestRate")
        dtDataTable.Columns.Add("Interest")
        dtDataTable.Columns.Add("MonthlyPrinciple")
        dtDataTable.Columns.Add("MonthlyInstalments")

        dsDataSet.Tables.Add(dtDataTable)
        Dim det = From m In newContext.Details
                  Select m

        For Each item In det
            drNewRow = dsDataSet.Tables(0).NewRow
            drNewRow("Month") = item.Month
            drNewRow("Principle") = item.Principle
            drNewRow("InterestRate") = item.InterestRate
            drNewRow("Interest") = item.Interest
            drNewRow("MonthlyPrinciple") = item.MonthlyPrinciple
            drNewRow("MonthlyInstalments") = item.MonthlyInstalments
            dsDataSet.Tables(0).Rows.Add(drNewRow)
        Next
        crNewReport.Load("crDetail.rpt")



        crNewReport.SetDataSource(dsDataSet.Tables(0))
        CrystalReportViewer1.ReportSource = crNewReport
    End Sub

    Protected Sub CrystalReportViewer1_Init(sender As Object, e As EventArgs) Handles CrystalReportViewer1.Init

    End Sub
End Class