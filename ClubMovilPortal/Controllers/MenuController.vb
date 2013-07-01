Imports NLog
Imports ClubMovil.Data


<HandleError()> _
Public Class MenuController
    Inherits BaseController

    Private Shared Log As Logger = LogManager.GetCurrentClassLogger()

    Function Index() As ActionResult
        If Log.IsDebugEnabled Then
            Log.Debug(GetDeviceInfo().NormalizedUserAgent)
        End If
        'For Each key As String In GetDeviceInfo().GetCapabilities().Keys
        '    Log.Debug(key & ":" & GetDeviceInfo().GetCapabilities(key))
        'Next
        If Log.IsDebugEnabled Then
            Log.Debug("Iniciando peticion...")
        End If
        ViewData("MenuList") = New MenuDAO().ListMenuByPadre(0)
        If Log.IsDebugEnabled Then
            Log.Debug("Final peticion")
        End If
        Return View()
    End Function

    Function List(ByVal id As Integer) As ActionResult
        ViewData("Menu") = New MenuDAO().GetMenu(id)
        ViewData("MenuList") = New MenuDAO().ListMenuByPadre(id)
        Return View()
    End Function

End Class
