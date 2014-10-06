Imports System.Data.Entity
Namespace AdminDBcontext__LEMS
    Public Class Mvc_
        Inherits DbContext
        ' You can add custom code to this file. Changes will not be overwritten.
        ' 
        ' If you want Entity Framework to drop and regenerate your database
        ' automatically whenever you change your model schema, add the following
        ' code to the Application_Start method in your Global.asax file.
        ' Note: this will destroy and re-create your database with every model change.
        ' 
        ' System.Data.Entity.Database.SetInitializer(New System.Data.Entity.DropCreateDatabaseIfModelChanges(Of AdminDBcontext__LEMS.Mvc_)())

        Public Property Admins As DbSet(Of Admin)
    End Class


End Namespace


