Imports System.Data.Entity
Imports System.ComponentModel.DataAnnotations
Public Class UserAccount
    Public Property ID() As Integer
    <Required(ErrorMessage:="First name requried")>
    Public Property FirstName() As String
    <Required(ErrorMessage:="Last name requried")>
    Public Property LastName() As String
    <DataType(DataType.EmailAddress)>
    <RegularExpression("^([0-9a-zA-Z]([\+\-_\.][0-9a-zA-Z]+)*)+@(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]*\.)+[a-zA-Z0-9]{2,3})$",
        ErrorMessage:="Provide valid email address")>
    Public Property Email() As String
    <Required(ErrorMessage:="Username requried")>
    Public Property Username As String
    <DataType(DataType.Password)>
    <Required(ErrorMessage:="Enter password")>
    <Remote("isExists", "Account", ErrorMessage:="Password Exists! ")>
    Public Property Password() As String
    <Compare("Password", ErrorMessage:="Password don't match")>
    <DataType(DataType.Password)>
    Public Property ConfirmPassword As String
    Public Property DateCreated As Date
End Class
Public Class UserAccountDBcontext
    Inherits DbContext
    Public Property UserAccounts As DbSet(Of UserAccount)
End Class
