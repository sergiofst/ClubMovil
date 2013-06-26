Imports NLog

<HandleError()> _
Public Class TarifasController
    Inherits BaseController

    Private Shared Log As Logger = LogManager.GetCurrentClassLogger()

    Function Index() As ActionResult
        Return View()
    End Function

End Class
