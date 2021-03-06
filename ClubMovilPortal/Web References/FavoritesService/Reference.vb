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
Namespace FavoritesService
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1"),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code"),  _
     System.Web.Services.WebServiceBindingAttribute(Name:="FavoritesSoapBinding", [Namespace]:="http://189.254.103.147:8088/sia/services/Favorites")>  _
    Partial Public Class FavoritesService
        Inherits System.Web.Services.Protocols.SoapHttpClientProtocol
        
        Private askFavOperationCompleted As System.Threading.SendOrPostCallback
        
        Private useDefaultCredentialsSetExplicitly As Boolean
        
        '''<remarks/>
        Public Sub New()
            MyBase.New
            Me.Url = Global.ClubMovilPortal.My.MySettings.Default.ProtGTPortal_FavoritesService_FavoritesService
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
        Public Event askFavCompleted As askFavCompletedEventHandler
        
        '''<remarks/>
        <System.Web.Services.Protocols.SoapRpcMethodAttribute("", RequestNamespace:="http://webservice.sia.sm.com", ResponseNamespace:="http://189.254.103.147:8088/sia/services/Favorites")>  _
        Public Function askFav(ByVal userId As String, ByVal passwd As String, ByVal msisdn As String, ByVal url As String, ByVal title As String) As <System.Xml.Serialization.SoapElementAttribute("askFavReturn")> String
            Dim results() As Object = Me.Invoke("askFav", New Object() {userId, passwd, msisdn, url, title})
            Return CType(results(0),String)
        End Function
        
        '''<remarks/>
        Public Overloads Sub askFavAsync(ByVal userId As String, ByVal passwd As String, ByVal msisdn As String, ByVal url As String, ByVal title As String)
            Me.askFavAsync(userId, passwd, msisdn, url, title, Nothing)
        End Sub
        
        '''<remarks/>
        Public Overloads Sub askFavAsync(ByVal userId As String, ByVal passwd As String, ByVal msisdn As String, ByVal url As String, ByVal title As String, ByVal userState As Object)
            If (Me.askFavOperationCompleted Is Nothing) Then
                Me.askFavOperationCompleted = AddressOf Me.OnaskFavOperationCompleted
            End If
            Me.InvokeAsync("askFav", New Object() {userId, passwd, msisdn, url, title}, Me.askFavOperationCompleted, userState)
        End Sub
        
        Private Sub OnaskFavOperationCompleted(ByVal arg As Object)
            If (Not (Me.askFavCompletedEvent) Is Nothing) Then
                Dim invokeArgs As System.Web.Services.Protocols.InvokeCompletedEventArgs = CType(arg,System.Web.Services.Protocols.InvokeCompletedEventArgs)
                RaiseEvent askFavCompleted(Me, New askFavCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState))
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
    Public Delegate Sub askFavCompletedEventHandler(ByVal sender As Object, ByVal e As askFavCompletedEventArgs)
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1"),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code")>  _
    Partial Public Class askFavCompletedEventArgs
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
