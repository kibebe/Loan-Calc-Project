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
Partial Public Class StateAudit
    #Region "Primitive Properties"

    Public Overridable Property ID As Integer
    <Display(Name:="Full Names")>
    Public Overridable Property Name As String
    <Display(Name:="Type of Loan")>
    Public Overridable Property LoanType As String
    <Display(Name:="Action Taken")>
    Public Overridable Property Status As String

    Public Overridable Property TimeStamp As Date

    #End Region
End Class
