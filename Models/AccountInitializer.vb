
Imports System.Collections.Generic

Imports System

Imports System.Data.Entity

Namespace LEMS.Models

    Public Class AccountInitializer
        Inherits DropCreateDatabaseIfModelChanges(Of UserAccountDBcontext)
        Protected Overrides Sub Seed(ByVal context As UserAccountDBcontext)

        End Sub
    End Class
End Namespace
