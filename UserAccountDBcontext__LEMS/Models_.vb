Imports System.Data.Entity
Namespace UserAccountDBcontext__LEMS
    Public Class Models_
        Inherits DbContext
        ' You can add custom code to this file. Changes will not be overwritten.
        ' 
        ' If you want Entity Framework to drop and regenerate your database
        ' automatically whenever you change your model schema, add the following
        ' code to the Application_Start method in your Global.asax file.
        ' Note: this will destroy and re-create your database with every model change.
        ' 
        ' System.Data.Entity.Database.SetInitializer(New System.Data.Entity.DropCreateDatabaseIfModelChanges(Of UserAccountDBcontext__LEMS.Models_)())

        Public Property UserAccounts As DbSet(Of UserAccount)
    End Class


End Namespace


