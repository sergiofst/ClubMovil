Imports NLog
Imports ClubMovil.Data
Imports Telcel.SIA


<HandleError()> _
Public Class HomeController
    Inherits BaseController

    Private Shared Log As Logger = LogManager.GetCurrentClassLogger()

    <Authorize()> _
    Function Index() As ActionResult
        Return View()
    End Function

    <Authorize()> _
    Function About() As ActionResult
        Return View()
    End Function


    Public Function Login() As ActionResult
        ' El IIS redirecciona a esta accion al detectar que no tiene sesion para iniciar una
        If Log.IsDebugEnabled Then
            Log.Debug("Buscando suscripcion: " & GetMSISDN())
        End If

        ' Busco si tiene suscripcion
        Dim drSuscripcion As DataRow = New SuscripcionDAO().GetSuscripcionByTelefono(GetMSISDN())
        If drSuscripcion Is Nothing Then

            ' Si no existe la suscripcion redirecciona para crear una suscripcion
            If Log.IsDebugEnabled Then
                Log.Debug("Suscripcion no encontrada: " & GetMSISDN())
            End If
            Return View("NuevaSuscripcion")
        End If

        ' Inicia la sesion
        FormsAuthentication.SetAuthCookie(GetMSISDN(), True)

        ' Va a la pagina de inicio
        Return RedirectToAction("Index", "Menu")
    End Function

    'Public Function CrearNuevaSuscripcion() As ActionResult

    '    Dim daoSuscripcion As SuscripcionDAO = New SuscripcionDAO()

    '    Dim idSuscripcion As Integer = daoSuscripcion.AddSuscripcion(0, IdServicio, GetTelefono, Constantes.SUSC_NUEVA)

    '    Return RedirectToAction("Index", "Menu")
    'End Function

    Function Alta() As ActionResult

        Dim idSuscripcion As Integer = 0

        Dim daoSuscripcion As SuscripcionDAO = New SuscripcionDAO()
        Dim drSuscripcion As DataRow = daoSuscripcion.GetSuscripcionByTelefono(GetMSISDN())

        If Log.IsDebugEnabled Then
            Log.Debug("Buscando suscripcion: {0}", GetMSISDN())
        End If

        '' Si la suscripcion no existe, la creo
        If drSuscripcion Is Nothing Then
            idSuscripcion = daoSuscripcion.AddSuscripcion(GetMSISDN(), 0, SuscripcionDAO.Estatus.Pendiente)
            If Log.IsDebugEnabled Then
                Log.Debug("Suscripcion creada: {0} Estatus: {1}", idSuscripcion, SuscripcionDAO.Estatus.Pendiente)
            End If
        Else
            idSuscripcion = CInt(drSuscripcion("idSuscripcion"))
            If Log.IsDebugEnabled Then
                Log.Debug("Suscripcion encontrada: {0} Estatus: {1}", drSuscripcion("idSuscripcion"), drSuscripcion("Estatus"))
            End If
        End If

        Dim daoTransaccion As TransaccionDAO = New TransaccionDAO()
        Dim daoContenido As ContenidoDAO = New ContenidoDAO()

        Dim transactionId As String = daoTransaccion.GetUUIDShort()

        Dim urlSuscripcionOK As String = Url.Action("SuscripcionOk", "Suscripcion", New With {.id = idSuscripcion}, "http")
        Dim urlSuscripcionCancel As String = Url.Action("SuscripcionCancel", "Suscripcion", New With {.id = idSuscripcion}, "http")
        Dim urlSuscripcionError As String = Url.Action("SuscripcionError", "Suscripcion", New With {.id = idSuscripcion}, "http")
        Dim urlSuscripcionBaja As String = Url.Action("SuscripcionBaja", "Suscripcion", New With {.id = idSuscripcion}, "http")

        If Log.IsDebugEnabled Then
            Log.Debug("URL SuscripcionOk: " & urlSuscripcionOK)
            Log.Debug("URL SuscripcionCancel: " & urlSuscripcionCancel)
            Log.Debug("URL SuscripcionError: " & urlSuscripcionError)
            Log.Debug("URL SuscripcionBaja: " & urlSuscripcionBaja)
        End If

        Dim srsRatingId As Integer = CInt(New PropiedadDAO().GetPropiedad("Suscripcion.SRSRatingId"))

        If Log.IsDebugEnabled Then
            Log.Debug("Efectuando transaccion {0} ...", transactionId)
        End If

        Dim service As TransactionService = New TransactionService(ConfigurationManager.AppSettings("SIA.TransactionService"))
        Dim transResponse As String = Nothing

        transResponse = service.requestTransaction(GetSIAUser(), _
                                                   GetSIAPassword(), _
                                                   transactionId, _
                                                   srsRatingId, _
                                                   GetMSISDN(), _
                                                   "", _
                                                   "", _
                                                   urlSuscripcionOK, _
                                                   urlSuscripcionCancel, _
                                                   urlSuscripcionError, _
                                                   urlSuscripcionBaja, _
                                                   "")

        If Log.IsDebugEnabled Then
            Log.Debug("Transaccion respuesta: " & transResponse)
        End If

        Dim idTransaccion As Integer = 0

        '' Verifico la respuesta
        If transResponse.Split("|"c)(0) = "1" Then
            ' La transacción fué registrada exitosamente pero se requiere la aceptación del cargo por parte del usuario final.

            idTransaccion = daoTransaccion.AddTransaccion(idSuscripcion, _
                                                                         transactionId, _
                                                                         srsRatingId, _
                                                                         GetMSISDN(),
                                                                         0,
                                                                         "Suscripcion", _
                                                                         urlSuscripcionOK, _
                                                                         urlSuscripcionCancel, _
                                                                         urlSuscripcionError, _
                                                                         urlSuscripcionBaja, _
                                                                         String.Empty, _
                                                                         TransaccionDAO.Estatus.Aceptacion)

            Dim responseTransactionId As String = CStr(transResponse.Split("|"c)(1))

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
            ' Actualizo la suscripcion a pendiente

            idTransaccion = daoTransaccion.AddTransaccion(idSuscripcion, _
                                                                         transactionId, _
                                                                         srsRatingId, _
                                                                         GetMSISDN(),
                                                                         0,
                                                                         "Suscripcion", _
                                                                         urlSuscripcionOK, _
                                                                         urlSuscripcionCancel, _
                                                                         urlSuscripcionError, _
                                                                         urlSuscripcionBaja, _
                                                                         String.Empty, _
                                                                         TransaccionDAO.Estatus.Pendiente)


            If Log.IsDebugEnabled Then
                Log.Debug("Transaccion enviada a Pendiente: " & idTransaccion)
            End If

            ViewData("Mensaje") = "Tu suscripcion esta siendo procesada."
        End If

        Return View()
    End Function

End Class
