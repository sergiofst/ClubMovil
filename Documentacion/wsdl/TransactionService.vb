﻿'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated by a tool.
'     Runtime Version:2.0.50727.4927
'
'     Changes to this file may cause incorrect behavior and will be lost if
'     the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict Off
Option Explicit On

Imports System
Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.Xml.Serialization

'
'This source code was auto-generated by wsdl, Version=2.0.50727.4927.
'

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "1.0.3705.0"),  _
 System.Web.Services.WebServiceAttribute([Namespace]:="http://192.168.1.120:8088/sia/services/Transaction"),  _
 System.Web.Services.WebServiceBindingAttribute(Name:="TransactionSoapBinding", [Namespace]:="http://192.168.1.120:8088/sia/services/Transaction")>  _
Partial Public MustInherit Class TransactionService
    Inherits System.Web.Services.WebService
    
    '''<remarks/>
    <System.Web.Services.WebMethodAttribute(),  _
     System.Web.Services.Protocols.SoapRpcMethodAttribute("", RequestNamespace:="http://webservice.sia.sm.com", ResponseNamespace:="http://192.168.1.120:8088/sia/services/Transaction")>  _
    Public MustOverride Function requestTransaction(ByVal userId As String, ByVal passwd As String, ByVal userTransactionId As String, ByVal srsRatingId As Long, ByVal msisdn As String, ByVal contentId As String, ByVal contentName As String, ByVal urlOk As String, ByVal urlCancel As String, ByVal urlError As String, ByVal urlUnsusc As String, ByVal extraParam As String) As <System.Xml.Serialization.SoapElementAttribute("requestTransactionReturn")> String
    
    '''<remarks/>
    <System.Web.Services.WebMethodAttribute(),  _
     System.Web.Services.Protocols.SoapRpcMethodAttribute("", RequestNamespace:="http://webservice.sia.sm.com", ResponseNamespace:="http://192.168.1.120:8088/sia/services/Transaction")>  _
    Public MustOverride Function requestTransactionInt(ByVal userId As String, ByVal passwd As String, ByVal userTransactionId As String, ByVal srsRatingId As String, ByVal msisdn As String, ByVal contentId As String, ByVal contentName As String, ByVal urlOk As String, ByVal urlCancel As String, ByVal urlError As String, ByVal urlUnsusc As String, ByVal extraParam As String) As <System.Xml.Serialization.SoapElementAttribute("requestTransactionIntReturn")> String
    
    '''<remarks/>
    <System.Web.Services.WebMethodAttribute(),  _
     System.Web.Services.Protocols.SoapRpcMethodAttribute("", RequestNamespace:="http://webservice.sia.sm.com", ResponseNamespace:="http://192.168.1.120:8088/sia/services/Transaction")>  _
    Public MustOverride Function getStatus(ByVal userId As String, ByVal passwd As String, ByVal transactionId As String) As <System.Xml.Serialization.SoapElementAttribute("getStatusReturn")> String
End Class
