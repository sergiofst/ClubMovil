﻿Imports System.Web
Imports System.Web.Services
Imports System.IO
Imports NLog

Public Class ContenidoResizeImagen
    Implements System.Web.IHttpHandler


    Private Shared Log As Logger = LogManager.GetCurrentClassLogger()

    Sub ProcessRequest(ByVal context As HttpContext) Implements IHttpHandler.ProcessRequest
        Dim filePath As String = ContenidoImagenResolver.GetInstance().ResolveFileName(context.Request("id"))
        Dim largo As String = ContenidoImagenResolver.GetInstance().ResolveFileName(context.Request("h"))
        Dim ancho As String = ContenidoImagenResolver.GetInstance().ResolveFileName(context.Request("w"))

        If Log.IsDebugEnabled Then
            Log.Debug("FilePath: " & filePath)
            Log.Debug("Largo: " & largo)
            Log.Debug("Ancho: " & ancho)
        End If

        If Not File.Exists(filePath) Then
            context.Response.StatusCode = 404
            Return
        End If

        Dim fileName As String = Path.GetFileName(filePath)

        context.Response.ContentType = "application/octet-stream"
        context.Response.AddHeader("content-disposition", "attachment; filename='" & fileName & "'")
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