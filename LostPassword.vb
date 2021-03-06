'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated from a template.
'
'     Changes to this file may cause incorrect behavior and will be lost if
'     the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------
Imports System
Imports System.Collections
Imports System.Collections.Generic
Imports System.Collections.ObjectModel
Imports System.Collections.Specialized
Imports System.ComponentModel.DataAnnotations
Partial Public Class LostPassword
    #Region "Primitive Properties"

    Public Overridable Property ID As Integer
    <Required(ErrorMessage:="We need your email to send you a reset link!")>
    <DataType(DataType.EmailAddress)>
    <RegularExpression("^([0-9a-zA-Z]([\+\-_\.][0-9a-zA-Z]+)*)+@(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]*\.)+[a-zA-Z0-9]{2,3})$",
        ErrorMessage:="Provide valid email address")>
    Public Overridable Property Email As String
    #End Region
End Class
