Imports NLog

Public Class AyudaController
    Inherits BaseController

    Private Shared Log As Logger = LogManager.GetCurrentClassLogger()

    Public Function Index() As ActionResult
        Return View()
    End Function

End Class
