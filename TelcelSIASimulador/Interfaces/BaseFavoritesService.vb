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

Public MustInherit Class BaseFavoritesService
    Inherits System.Web.Services.WebService

    Public MustOverride Function askFav(ByVal userId As String, ByVal passwd As String, ByVal msisdn As String, ByVal url As String, ByVal title As String) As <System.Xml.Serialization.SoapElementAttribute("askFavReturn")> String
End Class
