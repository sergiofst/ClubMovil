Imports System.IO
Imports System.Configuration

Public Class ContenidoImagenUtils


    Public Shared Function GetNewFileName(ByVal fileName As String) As String
        Dim pathBase As String = ConfigurationManager.AppSettings("Imagenes.Directorio")
        Dim newFileName As String = Path.GetRandomFileName
        newFileName = Path.ChangeExtension(newFileName, Path.GetExtension(fileName))

        Return Path.Combine(pathBase, newFileName)
    End Function

    Public Shared Function ResolveFileName(ByVal fileName As String) As String
        Dim pathBase As String = ConfigurationManager.AppSettings("Imagenes.Directorio")
        Return Path.Combine(pathBase, fileName)
    End Function


End Class
