Imports System.Collections.Generic

Imports System

Imports System.Data.Entity

Namespace LEMS.Models
    Public Class LoanInitializer
        Inherits DropCreateDatabaseIfModelChanges(Of LoanDBcontext)
        
    End Class
End Namespace
