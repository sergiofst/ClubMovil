Imports ClubMovil.Data
Imports NLog
Imports Telcel.SIA

Public Class ContenidoController
    Inherits BaseController

    Private Shared Log As Logger = LogManager.GetCurrentClassLogger()

    <Authorize()> _
    Public Function Categoria(ByVal id As Integer) As ActionResult
        Dim daoContenido As ContenidoDAO = New ContenidoDAO()
        ViewData("Categoria") = daoContenido.GetCategoria(id)
        ViewData("ContenidoList") = daoContenido.ListContenidoByCategoria(id)
        Return View()
    End Function

    <Authorize()> _
    Public Function Contenido(ByVal id As Integer) As ActionResult
        Dim daoContenido As ContenidoDAO = New ContenidoDAO()
        ViewData("Contenido") = daoContenido.GetContenido(id)
        ViewData("ContenidoImagenes") = daoContenido.ListContenidoImagenes(id)
        ViewData("ContenidoInfo") = daoContenido.ListContenidoInfo(id)
        Return View()
    End Function

    Public Function Comprar(ByVal id As Integer) As ActionResult

        ' Busco el contenido
        Dim drContenido As DataRow = New ContenidoDAO().GetContenido(id)

        ' Busco la suscripcion
        Dim drSuscripcion As DataRow = (New SuscripcionDAO().GetSuscripcionByTelefono(GetMSISDN()))

        ' Busco el tipo de contenido 
        Dim drTipoContenido As DataRow = New ContenidoDAO().GetTipoContenido(CInt(drContenido("IdTipoContenido")))
        Dim srsRatingId As Integer = CInt(drTipoContenido("SRSRatingId"))

        ' Si no tiene suficientes creditos
        If CInt(drSuscripcion("Creditos")) < CInt(drTipoContenido("Creditos")) Then
            ' Redirecciono a la pagina para comprar mas creditos
            Return Me.RedirectToAction("Index", "Creditos", New With {.id = id})
        End If

        Dim daoTransaccion As TransaccionDAO = New TransaccionDAO

        ' Genero el registro de la transaccion
        'Dim idTransaccion As Integer = daoTransaccion.AddTransaccion(CInt(drSuscripcion("IdSuscripcion")), _
        '                                                                                     id, GetMSISDN(), _
        '                                                                                     TransaccionDAO.Estatus.Pendiente)

        ' 1) Solicitud de transaccion
        Dim reqTransaction As TransactionService = New TransactionService(ConfigurationManager.AppSettings("SIA.TransactionService"))

        Dim transactionId As String = daoTransaccion.GetUUIDShort()

        Dim urlDownload As String = Url.Action("Download", "Contenido", New With {.id = transactionId}, "http")
        Dim urlCancel As String = Url.Action("Cancel", "Contenido", New With {.id = transactionId}, "http")
        Dim urlError As String = Url.Action("Error", "Contenido", New With {.id = transactionId}, "http")


        ' Genero la transaccion
        Dim transResponse As String = reqTransaction.requestTransaction(GetSIAUser(), _
                                                                        GetSIAPassword(), _
                                                                        transactionId, _
                                                                        srsRatingId, _
                                                                        GetMSISDN(), _
                                                                        id.ToString(), _
                                                                        CStr(drContenido("Nombre")), _
                                                                        Url.Action("Download", "Contenido", New With {.id = transactionId}, "http"), _
                                                                        Url.Action("Cancel", "Contenido", New With {.id = transactionId}, "http"), _
                                                                        Url.Action("Error", "Contenido", New With {.id = transactionId}, "http"), _
                                                                        Nothing, _
                                                                        "")

        If Log.IsDebugEnabled Then
            Log.Debug("TransResponse: " & transResponse)
        End If

        Dim idTransaccion As Integer = 0

        ' Verifico la respuesta
        If transResponse.Split("|"c)(0).Equals("1") Then
            ' La transacción fué registrada exitosamente pero se requiere la aceptación del cargo por parte del usuario final.

            idTransaccion = daoTransaccion.AddTransaccion(CInt(drSuscripcion("IdSuscripcion")), _
                                                             transactionId, _
                                                             srsRatingId, _
                                                             GetMSISDN(),
                                                             CInt(drContenido("IdContenido")),
                                                             CStr(drContenido("nombre")), _
                                                             urlDownload, _
                                                             urlCancel, _
                                                             urlError, _
                                                             String.Empty, _
                                                             String.Empty, _
                                                             TransaccionDAO.Estatus.Aceptacion)

            Dim responseTransactionId As String = transResponse.Split("|"c)(1)

            If Log.IsDebugEnabled Then
                Log.Debug("TransactionId: " & transactionId)
            End If

            ' Redirecciono a la pagina de confirmar compra
            Dim urlRedirect As String = ConfigurationManager.AppSettings("SIA.Redireccion.Transaction") & "?id=" & transactionId

            If Log.IsDebugEnabled Then
                Log.Debug("Redirect: " & urlRedirect)
            End If

            Me.Response.Redirect(urlRedirect)
        Else
            ViewData("Mensaje") = "Hubo un problema al efectuar la operacion"

            idTransaccion = daoTransaccion.AddTransaccion(CInt(drSuscripcion("IdSuscripcion")), _
                                                 transactionId, _
                                                 srsRatingId, _
                                                 GetMSISDN(),
                                                 0,
                                                 "Suscripcion", _
                                                 urlDownload, _
                                                 urlCancel, _
                                                 urlError, _
                                                 String.Empty, _
                                                 String.Empty, _
                                                 TransaccionDAO.Estatus.Error)
        End If

        Return View()
    End Function

    'Public Function Download(ByVal id As Integer) As FileResult
    '    return File(filename, contentType,"Report.pdf");
    'End Function

End Class
