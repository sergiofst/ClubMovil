Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.ComponentModel

' To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line.
' <System.Web.Script.Services.ScriptService()> _
<System.Web.Services.WebService(Namespace:="http://192.168.1.120:8088/sia/services/User")> _
<System.Web.Services.WebServiceBinding(Name:="UserSoapBinding", Namespace:="http://192.168.1.120:8088/sia/services/User")> _
<ToolboxItem(False)> _
Public Class UserService
    Inherits BaseUserService


    <WebMethod()> _
    Public Function HelloWorld() As String
        Return "Hello World"
    End Function

    <WebMethod()> _
    Public Overrides Function getMSISDN(ByVal userId As String, ByVal passwd As String, ByVal imsi As String) As String
        Return "Hello World"
    End Function

    <WebMethod()> _
    Public Overrides Function getProfile(ByVal userId As String, ByVal passwd As String, ByVal msisdn As String) As String
        Return "Hello World"
    End Function

End Class