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
 System.Web.Services.WebServiceAttribute([Namespace]:="http://189.254.103.147:8088/sia/services/Tariff"),  _
 System.Web.Services.WebServiceBindingAttribute(Name:="TariffSoapBinding", [Namespace]:="http://189.254.103.147:8088/sia/services/Tariff")>  _
Partial Public MustInherit Class TariffService
    Inherits System.Web.Services.WebService
    
    '''<remarks/>
    <System.Web.Services.WebMethodAttribute(),  _
     System.Web.Services.Protocols.SoapRpcMethodAttribute("", RequestNamespace:="http://webservice.sia.sm.com", ResponseNamespace:="http://189.254.103.147:8088/sia/services/Tariff")>  _
    Public MustOverride Function getTariff(ByVal userId As String, ByVal passwd As String, ByVal srsRatingId As Long) As <System.Xml.Serialization.SoapElementAttribute("getTariffReturn")> String
    
    '''<remarks/>
    <System.Web.Services.WebMethodAttribute(),  _
     System.Web.Services.Protocols.SoapRpcMethodAttribute("", RequestNamespace:="http://webservice.sia.sm.com", ResponseNamespace:="http://189.254.103.147:8088/sia/services/Tariff")>  _
    Public MustOverride Function getTariffInt(ByVal userId As String, ByVal passwd As String, ByVal srsRatingId As Integer) As <System.Xml.Serialization.SoapElementAttribute("getTariffIntReturn")> String
End Class
