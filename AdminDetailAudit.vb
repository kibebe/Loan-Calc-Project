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
Partial Public Class AdminDetailAudit
    #Region "Primitive Properties"

    Public Overridable Property ID As Integer

    <Display(Name:="Full Names")>
    Public Overridable Property Name As String

    Public Overridable Property Email As String

    Public Overridable Property UserName As String
    <Display(Name:="Time Created")>
    Public Overridable Property Timestamp As Date
    <Display(Name:="Roles Administered")>
    Public Overridable Property Roles As String

    #End Region
End Class
