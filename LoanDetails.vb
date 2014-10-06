Module LoanDetails
    Sub EntityToDataSet(Of TEntity)(ByRef ds As DataSet, ByVal MyEntity As TEntity)
        Dim strTableName As String
        Dim drNewRow As DataRow
        Dim EntityFields = GetType(TEntity).GetProperties.Where(Function(a) a.CanRead)

        strTableName = MyEntity.GetType.FullName
        drNewRow = ds.Tables(strTableName).NewRow

        For Each field In EntityFields
            If drNewRow.Table.Columns.Contains(field.Name) Then
                drNewRow(field.Name) = field.GetValue(MyEntity, Nothing)
            End If
        Next
        ds.Tables(strTableName).Rows.Add(drNewRow)
    End Sub
End Module
