Imports System.Web
Imports System.Web.Services
Imports NLog
Imports ClubMovil.Data
Imports System.IO

Public Class ContenidoFondo
    Implements System.Web.IHttpHandler

    Private Shared Log As Logger = LogManager.GetCurrentClassLogger()

    Sub ProcessRequest(ByVal context As HttpContext) Implements IHttpHandler.ProcessRequest
        Dim archivo As String = context.Request("id")

        Dim contenidoFondoDir As String = New PropiedadDAO().GetPropiedad("ContenidoFondo.Dir")

        Dim archivoPath As String = Path.Combine(contenidoFondoDir, archivo)

        If Log.IsDebugEnabled Then
            Log.Debug("Archivo: " & archivoPath)
        End If

        If Not File.Exists(archivoPath) Then
            context.Response.StatusCode = 404
            Return
        End If

        context.Response.ContentType = "application/octet-stream"
        context.Response.AddHeader("content-disposition", "attachment; filename='" & archivo & "'")
        context.Response.WriteFile(archivoPath)
        context.Response.Flush()
        context.Response.End()

    End Sub

    ReadOnly Property IsReusable() As Boolean Implements IHttpHandler.IsReusable
        Get
            Return False
        End Get
    End Property

End Class