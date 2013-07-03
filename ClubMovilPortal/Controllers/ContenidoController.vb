Imports ClubMovil.Data
Imports NLog
Imports Telcel.SIA
Imports Wurfl
Imports ClubMovil.Utils
Imports System.IO

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
        Dim tipoContenido As Integer = CInt(drContenido("TipoContenido"))
        Dim srsRatingId As Integer = CInt(ConfigurationManager.AppSettings("TipoContenido.SRSRatingId." & tipoContenido))
        Dim creditos As Integer = CInt(ConfigurationManager.AppSettings("TipoContenido.Creditos." & tipoContenido))

        ' Si no tiene suficientes creditos
        If CInt(drSuscripcion("Creditos")) < creditos Then
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

    Public Function Download(ByVal id As String) As FileResult
        If Log.IsDebugEnabled Then
            Log.Debug("Descarga de contenido: " & id)
        End If

        ' Verificar el cobro
        Dim reqTransaction As TransactionService = New TransactionService(ConfigurationManager.AppSettings("SIA.TransactionService"))

        Dim transResponse As String = reqTransaction.getStatus(GetSIAUser(), GetSIAPassword(), CStr(id))

        If Log.IsDebugEnabled Then
            Log.Debug(transResponse)
        End If

        ' Cobrado
        If transResponse.Equals("0|4") Then
            ' Guardo la descarga del archivo
            Dim drTransaccion As DataRow = New TransaccionDAO().GetTransaccionByTransactionId(id)
            Dim idDescarga As Integer = New DescargaDAO().AddDescarga(CInt(drTransaccion("IdContenido")), _
                                                                           CInt(drTransaccion("IdTransaccion")))

            Dim daoContenido As ContenidoDAO = New ContenidoDAO()

            ' Entrego el contenido
            Dim drContenido As DataRow = daoContenido.GetContenido(CInt(drTransaccion("IdContenido")))

            Dim tipoContenido As Integer = CInt(drContenido("IdTipoContenido"))

            Dim archivo As String = String.Empty

            If tipoContenido = 1 Then
                ' Contenido Fondo
                archivo = GetContenidoFondo(drContenido)
            ElseIf tipoContenido = 2 Then
                ' Contenido Fondo
                archivo = GetContenidoTono(drContenido)
            End If

            If Log.IsDebugEnabled Then
                Log.Debug("Archivo: " & archivo)
            End If

            Return File(archivo, "application/octet-stream", Path.GetFileName(archivo))
        Else
            If Log.IsErrorEnabled Then
                Log.Error(transResponse)
            End If
        End If

        Return Nothing
    End Function

    Private Function GetContenidoFondo(ByVal drContenido As DataRow) As String
        Dim device As IDevice = GetDeviceInfo()

        Dim daoContenidoFondo As ContenidoFondoDAO = New ContenidoFondoDAO
        Dim anchoDevice As Integer = Integer.Parse(device.GetCapability("resolution_width"))

        If Log.IsDebugEnabled Then
            Log.Debug("Ancho: " & anchoDevice)
        End If

        Dim drContenidoFondo As DataRow = daoContenidoFondo.GetContenidoFondo(CInt(drContenido("IdContenido")), anchoDevice)
        Dim contenidoFondoDir As String = New PropiedadDAO().GetPropiedad("ContenidoFondo.Dir")

        Return Path.Combine(contenidoFondoDir, CStr(drContenidoFondo("Archivo")))
    End Function

    Private Function GetContenidoTono(ByVal drContenido As DataRow) As String
        Dim device As IDevice = GetDeviceInfo()

        Dim formato As String = Nothing

        If CBool(device.GetCapability("ringtone_mp3")) Then
            formato = "mp3"
        ElseIf CBool(device.GetCapability("ringtone_wav")) Then
            formato = "wav"
        ElseIf CBool(device.GetCapability("ringtone_aac")) Then
            formato = "acc"
        ElseIf CBool(device.GetCapability("ringtone_awb")) Then
            formato = "awb"
        ElseIf CBool(device.GetCapability("ringtone_amr")) Then
            formato = "amr"
        End If

        If Log.IsDebugEnabled Then
            Log.Debug("Formato: " & formato)
        End If

        Dim drContenidoFondo As DataRow = New ContenidoTonoDAO().GetContenidoTono(CInt(drContenido("IdContenido")), formato)
        Dim contenidoFondoDir As String = New PropiedadDAO().GetPropiedad("ContenidoTono.Dir")

        Return Path.Combine(contenidoFondoDir, CStr(drContenidoFondo("Archivo")))
    End Function

    Private Function BuscaGrupo(ByVal tipoContenido As Integer) As String
        Dim device As IDevice = GetDeviceInfo()

        If tipoContenido = CInt(ConfigurationManager.AppSettings("TipoContenido.Imagenes")) Then
            Dim width As Integer = Integer.Parse(device.GetCapability("resolution_width"))
            If width < 132 Then
                Return "tiny"
            ElseIf width < 176 Then
                Return "small"
            ElseIf width < 240 Then
                Return "medium"
            ElseIf width < 480 Then
                Return "large"
            End If
        End If

        Return Nothing
    End Function

End Class
