Imports Wurfl

<HandleError()> _
Public Class BaseController
    Inherits System.Web.Mvc.Controller

    Protected Function GetMSISDN() As String
        If Not String.IsNullOrEmpty(ConfigurationManager.AppSettings("MSISDN.Default")) Then
            Return ConfigurationManager.AppSettings("MSISDN.Default")
        End If
        Return Me.Request.Headers(ConfigurationManager.AppSettings("SIA.MSISDN"))
    End Function

    Protected Function GetSIAUser() As String
        Return ConfigurationManager.AppSettings("SIA.user")
    End Function

    Protected Function GetSIAPassword() As String
        Return ConfigurationManager.AppSettings("SIA.password")
    End Function

    'Protected ReadOnly Property SIAHost() As String
    '    Get
    '        Return ConfigurationManager.AppSettings("SIA.host")
    '    End Get
    'End Property

    Protected Function GetPortalTitulo() As String
        Return ConfigurationManager.AppSettings("Portal.Titulo")
    End Function

    Public Function GetDeviceInfo() As IDevice
        Return MvcApplication.GetWurflManager.GetDeviceForRequest(Me.Request.UserAgent)
    End Function

End Class

