﻿'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated by a tool.
'     Runtime Version:4.0.30319.468
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
'This source code was auto-generated by Microsoft.VSDesigner, Version 4.0.30319.468.
'
Namespace UserService
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1"),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code"),  _
     System.Web.Services.WebServiceBindingAttribute(Name:="UserSoapBinding", [Namespace]:="http://189.254.103.147:8088/sia/services/User")>  _
    Partial Public Class UserService
        Inherits System.Web.Services.Protocols.SoapHttpClientProtocol
        
        Private getMSISDNOperationCompleted As System.Threading.SendOrPostCallback
        
        Private getProfileOperationCompleted As System.Threading.SendOrPostCallback
        
        Private useDefaultCredentialsSetExplicitly As Boolean
        
        '''<remarks/>
        Public Sub New()
            MyBase.New
            Me.Url = Global.ClubMovilPortal.My.MySettings.Default.ProtGTPortal_UserService_UserService
            If (Me.IsLocalFileSystemWebService(Me.Url) = true) Then
                Me.UseDefaultCredentials = true
                Me.useDefaultCredentialsSetExplicitly = false
            Else
                Me.useDefaultCredentialsSetExplicitly = true
            End If
        End Sub
        
        Public Shadows Property Url() As String
            Get
                Return MyBase.Url
            End Get
            Set
                If (((Me.IsLocalFileSystemWebService(MyBase.Url) = true)  _
                            AndAlso (Me.useDefaultCredentialsSetExplicitly = false))  _
                            AndAlso (Me.IsLocalFileSystemWebService(value) = false)) Then
                    MyBase.UseDefaultCredentials = false
                End If
                MyBase.Url = value
            End Set
        End Property
        
        Public Shadows Property UseDefaultCredentials() As Boolean
            Get
                Return MyBase.UseDefaultCredentials
            End Get
            Set
                MyBase.UseDefaultCredentials = value
                Me.useDefaultCredentialsSetExplicitly = true
            End Set
        End Property
        
        '''<remarks/>
        Public Event getMSISDNCompleted As getMSISDNCompletedEventHandler
        
        '''<remarks/>
        Public Event getProfileCompleted As getProfileCompletedEventHandler
        
        '''<remarks/>
        <System.Web.Services.Protocols.SoapRpcMethodAttribute("", RequestNamespace:="http://webservice.sia.sm.com", ResponseNamespace:="http://189.254.103.147:8088/sia/services/User")>  _
        Public Function getMSISDN(ByVal userId As String, ByVal passwd As String, ByVal imsi As String) As <System.Xml.Serialization.SoapElementAttribute("getMSISDNReturn")> String
            Dim results() As Object = Me.Invoke("getMSISDN", New Object() {userId, passwd, imsi})
            Return CType(results(0),String)
        End Function
        
        '''<remarks/>
        Public Overloads Sub getMSISDNAsync(ByVal userId As String, ByVal passwd As String, ByVal imsi As String)
            Me.getMSISDNAsync(userId, passwd, imsi, Nothing)
        End Sub
        
        '''<remarks/>
        Public Overloads Sub getMSISDNAsync(ByVal userId As String, ByVal passwd As String, ByVal imsi As String, ByVal userState As Object)
            If (Me.getMSISDNOperationCompleted Is Nothing) Then
                Me.getMSISDNOperationCompleted = AddressOf Me.OngetMSISDNOperationCompleted
            End If
            Me.InvokeAsync("getMSISDN", New Object() {userId, passwd, imsi}, Me.getMSISDNOperationCompleted, userState)
        End Sub
        
        Private Sub OngetMSISDNOperationCompleted(ByVal arg As Object)
            If (Not (Me.getMSISDNCompletedEvent) Is Nothing) Then
                Dim invokeArgs As System.Web.Services.Protocols.InvokeCompletedEventArgs = CType(arg,System.Web.Services.Protocols.InvokeCompletedEventArgs)
                RaiseEvent getMSISDNCompleted(Me, New getMSISDNCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState))
            End If
        End Sub
        
        '''<remarks/>
        <System.Web.Services.Protocols.SoapRpcMethodAttribute("", RequestNamespace:="http://webservice.sia.sm.com", ResponseNamespace:="http://189.254.103.147:8088/sia/services/User")>  _
        Public Function getProfile(ByVal userId As String, ByVal passwd As String, ByVal msisdn As String) As <System.Xml.Serialization.SoapElementAttribute("getProfileReturn")> String
            Dim results() As Object = Me.Invoke("getProfile", New Object() {userId, passwd, msisdn})
            Return CType(results(0),String)
        End Function
        
        '''<remarks/>
        Public Overloads Sub getProfileAsync(ByVal userId As String, ByVal passwd As String, ByVal msisdn As String)
            Me.getProfileAsync(userId, passwd, msisdn, Nothing)
        End Sub
        
        '''<remarks/>
        Public Overloads Sub getProfileAsync(ByVal userId As String, ByVal passwd As String, ByVal msisdn As String, ByVal userState As Object)
            If (Me.getProfileOperationCompleted Is Nothing) Then
                Me.getProfileOperationCompleted = AddressOf Me.OngetProfileOperationCompleted
            End If
            Me.InvokeAsync("getProfile", New Object() {userId, passwd, msisdn}, Me.getProfileOperationCompleted, userState)
        End Sub
        
        Private Sub OngetProfileOperationCompleted(ByVal arg As Object)
            If (Not (Me.getProfileCompletedEvent) Is Nothing) Then
                Dim invokeArgs As System.Web.Services.Protocols.InvokeCompletedEventArgs = CType(arg,System.Web.Services.Protocols.InvokeCompletedEventArgs)
                RaiseEvent getProfileCompleted(Me, New getProfileCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState))
            End If
        End Sub
        
        '''<remarks/>
        Public Shadows Sub CancelAsync(ByVal userState As Object)
            MyBase.CancelAsync(userState)
        End Sub
        
        Private Function IsLocalFileSystemWebService(ByVal url As String) As Boolean
            If ((url Is Nothing)  _
                        OrElse (url Is String.Empty)) Then
                Return false
            End If
            Dim wsUri As System.Uri = New System.Uri(url)
            If ((wsUri.Port >= 1024)  _
                        AndAlso (String.Compare(wsUri.Host, "localHost", System.StringComparison.OrdinalIgnoreCase) = 0)) Then
                Return true
            End If
            Return false
        End Function
    End Class
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")>  _
    Public Delegate Sub getMSISDNCompletedEventHandler(ByVal sender As Object, ByVal e As getMSISDNCompletedEventArgs)
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1"),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code")>  _
    Partial Public Class getMSISDNCompletedEventArgs
        Inherits System.ComponentModel.AsyncCompletedEventArgs
        
        Private results() As Object
        
        Friend Sub New(ByVal results() As Object, ByVal exception As System.Exception, ByVal cancelled As Boolean, ByVal userState As Object)
            MyBase.New(exception, cancelled, userState)
            Me.results = results
        End Sub
        
        '''<remarks/>
        Public ReadOnly Property Result() As String
            Get
                Me.RaiseExceptionIfNecessary
                Return CType(Me.results(0),String)
            End Get
        End Property
    End Class
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")>  _
    Public Delegate Sub getProfileCompletedEventHandler(ByVal sender As Object, ByVal e As getProfileCompletedEventArgs)
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1"),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code")>  _
    Partial Public Class getProfileCompletedEventArgs
        Inherits System.ComponentModel.AsyncCompletedEventArgs
        
        Private results() As Object
        
        Friend Sub New(ByVal results() As Object, ByVal exception As System.Exception, ByVal cancelled As Boolean, ByVal userState As Object)
            MyBase.New(exception, cancelled, userState)
            Me.results = results
        End Sub
        
        '''<remarks/>
        Public ReadOnly Property Result() As String
            Get
                Me.RaiseExceptionIfNecessary
                Return CType(Me.results(0),String)
            End Get
        End Property
    End Class
End Namespace
