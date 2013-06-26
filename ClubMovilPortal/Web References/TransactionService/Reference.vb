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
Namespace TransactionService
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1"),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code"),  _
     System.Web.Services.WebServiceBindingAttribute(Name:="TransactionSoapBinding", [Namespace]:="http://189.254.103.147:8088/sia/services/Transaction")>  _
    Partial Public Class TransactionService
        Inherits System.Web.Services.Protocols.SoapHttpClientProtocol
        
        Private requestTransactionOperationCompleted As System.Threading.SendOrPostCallback
        
        Private requestTransactionIntOperationCompleted As System.Threading.SendOrPostCallback
        
        Private getStatusOperationCompleted As System.Threading.SendOrPostCallback
        
        Private useDefaultCredentialsSetExplicitly As Boolean
        
        '''<remarks/>
        Public Sub New()
            MyBase.New
            Me.Url = Global.ClubMovilPortal.My.MySettings.Default.ProtGTPortal_TransactionService_TransactionService
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
        Public Event requestTransactionCompleted As requestTransactionCompletedEventHandler
        
        '''<remarks/>
        Public Event requestTransactionIntCompleted As requestTransactionIntCompletedEventHandler
        
        '''<remarks/>
        Public Event getStatusCompleted As getStatusCompletedEventHandler
        
        '''<remarks/>
        <System.Web.Services.Protocols.SoapRpcMethodAttribute("", RequestNamespace:="http://webservice.sia.sm.com", ResponseNamespace:="http://189.254.103.147:8088/sia/services/Transaction")>  _
        Public Function requestTransaction(ByVal userId As String, ByVal passwd As String, ByVal userTransactionId As String, ByVal srsRatingId As Long, ByVal msisdn As String, ByVal contentId As String, ByVal contentName As String, ByVal urlOk As String, ByVal urlCancel As String, ByVal urlError As String, ByVal urlUnsusc As String, ByVal extraParam As String) As <System.Xml.Serialization.SoapElementAttribute("requestTransactionReturn")> String
            Dim results() As Object = Me.Invoke("requestTransaction", New Object() {userId, passwd, userTransactionId, srsRatingId, msisdn, contentId, contentName, urlOk, urlCancel, urlError, urlUnsusc, extraParam})
            Return CType(results(0),String)
        End Function
        
        '''<remarks/>
        Public Overloads Sub requestTransactionAsync(ByVal userId As String, ByVal passwd As String, ByVal userTransactionId As String, ByVal srsRatingId As Long, ByVal msisdn As String, ByVal contentId As String, ByVal contentName As String, ByVal urlOk As String, ByVal urlCancel As String, ByVal urlError As String, ByVal urlUnsusc As String, ByVal extraParam As String)
            Me.requestTransactionAsync(userId, passwd, userTransactionId, srsRatingId, msisdn, contentId, contentName, urlOk, urlCancel, urlError, urlUnsusc, extraParam, Nothing)
        End Sub
        
        '''<remarks/>
        Public Overloads Sub requestTransactionAsync(ByVal userId As String, ByVal passwd As String, ByVal userTransactionId As String, ByVal srsRatingId As Long, ByVal msisdn As String, ByVal contentId As String, ByVal contentName As String, ByVal urlOk As String, ByVal urlCancel As String, ByVal urlError As String, ByVal urlUnsusc As String, ByVal extraParam As String, ByVal userState As Object)
            If (Me.requestTransactionOperationCompleted Is Nothing) Then
                Me.requestTransactionOperationCompleted = AddressOf Me.OnrequestTransactionOperationCompleted
            End If
            Me.InvokeAsync("requestTransaction", New Object() {userId, passwd, userTransactionId, srsRatingId, msisdn, contentId, contentName, urlOk, urlCancel, urlError, urlUnsusc, extraParam}, Me.requestTransactionOperationCompleted, userState)
        End Sub
        
        Private Sub OnrequestTransactionOperationCompleted(ByVal arg As Object)
            If (Not (Me.requestTransactionCompletedEvent) Is Nothing) Then
                Dim invokeArgs As System.Web.Services.Protocols.InvokeCompletedEventArgs = CType(arg,System.Web.Services.Protocols.InvokeCompletedEventArgs)
                RaiseEvent requestTransactionCompleted(Me, New requestTransactionCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState))
            End If
        End Sub
        
        '''<remarks/>
        <System.Web.Services.Protocols.SoapRpcMethodAttribute("", RequestNamespace:="http://webservice.sia.sm.com", ResponseNamespace:="http://189.254.103.147:8088/sia/services/Transaction")>  _
        Public Function requestTransactionInt(ByVal userId As String, ByVal passwd As String, ByVal userTransactionId As String, ByVal srsRatingId As String, ByVal msisdn As String, ByVal contentId As String, ByVal contentName As String, ByVal urlOk As String, ByVal urlCancel As String, ByVal urlError As String, ByVal urlUnsusc As String, ByVal extraParam As String) As <System.Xml.Serialization.SoapElementAttribute("requestTransactionIntReturn")> String
            Dim results() As Object = Me.Invoke("requestTransactionInt", New Object() {userId, passwd, userTransactionId, srsRatingId, msisdn, contentId, contentName, urlOk, urlCancel, urlError, urlUnsusc, extraParam})
            Return CType(results(0),String)
        End Function
        
        '''<remarks/>
        Public Overloads Sub requestTransactionIntAsync(ByVal userId As String, ByVal passwd As String, ByVal userTransactionId As String, ByVal srsRatingId As String, ByVal msisdn As String, ByVal contentId As String, ByVal contentName As String, ByVal urlOk As String, ByVal urlCancel As String, ByVal urlError As String, ByVal urlUnsusc As String, ByVal extraParam As String)
            Me.requestTransactionIntAsync(userId, passwd, userTransactionId, srsRatingId, msisdn, contentId, contentName, urlOk, urlCancel, urlError, urlUnsusc, extraParam, Nothing)
        End Sub
        
        '''<remarks/>
        Public Overloads Sub requestTransactionIntAsync(ByVal userId As String, ByVal passwd As String, ByVal userTransactionId As String, ByVal srsRatingId As String, ByVal msisdn As String, ByVal contentId As String, ByVal contentName As String, ByVal urlOk As String, ByVal urlCancel As String, ByVal urlError As String, ByVal urlUnsusc As String, ByVal extraParam As String, ByVal userState As Object)
            If (Me.requestTransactionIntOperationCompleted Is Nothing) Then
                Me.requestTransactionIntOperationCompleted = AddressOf Me.OnrequestTransactionIntOperationCompleted
            End If
            Me.InvokeAsync("requestTransactionInt", New Object() {userId, passwd, userTransactionId, srsRatingId, msisdn, contentId, contentName, urlOk, urlCancel, urlError, urlUnsusc, extraParam}, Me.requestTransactionIntOperationCompleted, userState)
        End Sub
        
        Private Sub OnrequestTransactionIntOperationCompleted(ByVal arg As Object)
            If (Not (Me.requestTransactionIntCompletedEvent) Is Nothing) Then
                Dim invokeArgs As System.Web.Services.Protocols.InvokeCompletedEventArgs = CType(arg,System.Web.Services.Protocols.InvokeCompletedEventArgs)
                RaiseEvent requestTransactionIntCompleted(Me, New requestTransactionIntCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState))
            End If
        End Sub
        
        '''<remarks/>
        <System.Web.Services.Protocols.SoapRpcMethodAttribute("", RequestNamespace:="http://webservice.sia.sm.com", ResponseNamespace:="http://189.254.103.147:8088/sia/services/Transaction")>  _
        Public Function getStatus(ByVal userId As String, ByVal passwd As String, ByVal transactionId As String) As <System.Xml.Serialization.SoapElementAttribute("getStatusReturn")> String
            Dim results() As Object = Me.Invoke("getStatus", New Object() {userId, passwd, transactionId})
            Return CType(results(0),String)
        End Function
        
        '''<remarks/>
        Public Overloads Sub getStatusAsync(ByVal userId As String, ByVal passwd As String, ByVal transactionId As String)
            Me.getStatusAsync(userId, passwd, transactionId, Nothing)
        End Sub
        
        '''<remarks/>
        Public Overloads Sub getStatusAsync(ByVal userId As String, ByVal passwd As String, ByVal transactionId As String, ByVal userState As Object)
            If (Me.getStatusOperationCompleted Is Nothing) Then
                Me.getStatusOperationCompleted = AddressOf Me.OngetStatusOperationCompleted
            End If
            Me.InvokeAsync("getStatus", New Object() {userId, passwd, transactionId}, Me.getStatusOperationCompleted, userState)
        End Sub
        
        Private Sub OngetStatusOperationCompleted(ByVal arg As Object)
            If (Not (Me.getStatusCompletedEvent) Is Nothing) Then
                Dim invokeArgs As System.Web.Services.Protocols.InvokeCompletedEventArgs = CType(arg,System.Web.Services.Protocols.InvokeCompletedEventArgs)
                RaiseEvent getStatusCompleted(Me, New getStatusCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState))
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
    Public Delegate Sub requestTransactionCompletedEventHandler(ByVal sender As Object, ByVal e As requestTransactionCompletedEventArgs)
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1"),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code")>  _
    Partial Public Class requestTransactionCompletedEventArgs
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
    Public Delegate Sub requestTransactionIntCompletedEventHandler(ByVal sender As Object, ByVal e As requestTransactionIntCompletedEventArgs)
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1"),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code")>  _
    Partial Public Class requestTransactionIntCompletedEventArgs
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
    Public Delegate Sub getStatusCompletedEventHandler(ByVal sender As Object, ByVal e As getStatusCompletedEventArgs)
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1"),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code")>  _
    Partial Public Class getStatusCompletedEventArgs
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
