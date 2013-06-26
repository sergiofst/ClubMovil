Imports ClubMovil.Data
Imports NLog
Imports Telcel.SIA

Public Class SuscripcionController
    Inherits BaseController

    Private Shared Log As Logger = LogManager.GetCurrentClassLogger()

    Public Function SuscripcionOk(ByVal id As Integer) As ActionResult
        Dim dumy As Integer = New SuscripcionDAO().UpdSuscripcionEstatus(SuscripcionDAO.Estatus.Activa, id)

        Return View()
    End Function

    Public Function SuscripcionCancel(ByVal id As Integer) As ActionResult
        Dim dumy As Integer = New SuscripcionDAO().UpdSuscripcionEstatus(SuscripcionDAO.Estatus.Cancelada, id)

        Return View()
    End Function

    Public Function SuscripcionBaja(ByVal id As Integer) As ActionResult
        Dim dumy As Integer = New SuscripcionDAO().UpdSuscripcionEstatus(SuscripcionDAO.Estatus.Baja, id)

        Return View()
    End Function






End Class
