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
Partial Public Class Audit
    #Region "Primitive Properties"

    Public Overridable Property AuditID As Integer
    <Display(Name:="Full Names")>
    Public Overridable Property Name As String
    <Display(Name:="User Email")>
    Public Overridable Property UserName As String

    Public Overridable Property IPAddress As String
    <Display(Name:="Area Accessed")>
    Public Overridable Property AreaAccessed As String

    Public Overridable Property Timestamp As Date

    #End Region
End Class
