﻿Imports System.Web
Imports System.Web.Services
Imports System.IO
Imports NLog
Imports ClubMovil.Utils
Imports ClubMovil.Data

Public Class ContenidoImagen
    Implements System.Web.IHttpHandler

    Private Shared Log As Logger = LogManager.GetCurrentClassLogger()

    Sub ProcessRequest(ByVal context As HttpContext) Implements IHttpHandler.ProcessRequest
        Dim contenidoImagenDir As String = New PropiedadDAO().GetPropiedad("ContenidoImagen.Dir")
        Dim archivo As String = context.Request("id")

        Dim filePath As String = Path.Combine(contenidoImagenDir, archivo)

        If Log.IsDebugEnabled Then
            Log.Debug("FilePath: " & filePath)
        End If

        If Not File.Exists(filePath) Then
            context.Response.StatusCode = 404
            Return
        End If

        context.Response.ContentType = "application/octet-stream"
        context.Response.AddHeader("content-disposition", "attachment; filename='" & archivo & "'")
        context.Response.WriteFile(filePath)
        context.Response.Flush()
        context.Response.End()

    End Sub

    ReadOnly Property IsReusable() As Boolean Implements IHttpHandler.IsReusable
        Get
            Return False
        End Get
    End Property

End Class
