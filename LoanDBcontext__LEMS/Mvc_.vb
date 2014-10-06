Imports System.Data.Entity
Namespace LoanDBcontext__LEMS
    Public Class Mvc_
        Inherits DbContext
        ' You can add custom code to this file. Changes will not be overwritten.
        ' 
        ' If you want Entity Framework to drop and regenerate your database
        ' automatically whenever you change your model schema, add the following
        ' code to the Application_Start method in your Global.asax file.
        ' Note: this will destroy and re-create your database with every model change.
        ' 
        ' System.Data.Entity.Database.SetInitializer(New System.Data.Entity.DropCreateDatabaseIfModelChanges(Of LoanDBcontext__LEMS.Mvc_)())

        Public Property Loans As DbSet(Of Loan)
    End Class


End Namespace


