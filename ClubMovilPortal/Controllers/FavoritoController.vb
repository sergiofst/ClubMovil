Imports Telcel.SIA
Imports ClubMovil.Data
Imports NLog

Public Class FavoritoController
    Inherits BaseController

    Private Shared Log As Logger = LogManager.GetCurrentClassLogger()

    Public Function Index() As ActionResult
        Return View()
    End Function

    Public Function Agregar() As ActionResult
        Try
            Dim service As FavoritesService = New FavoritesService(ConfigurationManager.AppSettings("SIA.FavoritesService"))
            Dim daoFavorito As FavoritoDAO = New FavoritoDAO()

            Dim idFavorito As Integer = daoFavorito.AddFavorito(GetMSISDN(), FavoritoDAO.FavoritoEstatus.Inactivo)
            Dim urlClubMovil As String = New Uri(Request.Url, VirtualPathUtility.ToAbsolute("~/")).AbsoluteUri

            Dim response As String = service.askFav(GetSIAUser(), _
                                                    GetSIAPassword(), _
                                                    GetMSISDN(), _
                                                    urlClubMovil, _
                                                    GetPortalTitulo())

            Dim respArray() As String = response.Split("|"c)

            ' Verifica la respuesta
            If respArray(0) = "0" Then  ' Todo perfecto
                daoFavorito.UpdFavoritoEstatus(idFavorito, FavoritoDAO.FavoritoEstatus.Activo)

                ' Redirecciono a la pagina del sia para que confirme el usuario
                Me.Response.Redirect(ConfigurationManager.AppSettings("SIA.Redireccion.Favorites") & "?id=" & GetSIAUser())
            Else
                ViewData("Mensaje") = "Hubo un problema al efectuar la operacion"
                If Log.IsErrorEnabled Then
                    Log.Error(response)
                End If
            End If

        Catch ex As Exception
            ViewData("Mensaje") = "Hubo un problema al efectuar la operacion"
            If Log.IsErrorEnabled Then
                Log.Error(ex.ToString())
            End If
        End Try

        Return View()
    End Function

End Class
