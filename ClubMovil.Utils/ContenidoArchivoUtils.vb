Imports System.IO
Imports System.Configuration

Public Class ContenidoArchivoUtils
    Const CONFIG_KEY As String = "Archivos.Directorio"

    Public Shared Function GetNewFileName(ByVal fileName As String) As String
        Dim pathBase As String = ConfigurationManager.AppSettings(CONFIG_KEY)
        Dim newFileName As String = Path.GetRandomFileName
        newFileName = Path.ChangeExtension(newFileName, Path.GetExtension(fileName))

        Return newFileName
    End Function

    Public Shared Function ResolveFileName(ByVal fileName As String) As String
        Dim pathBase As String = ConfigurationManager.AppSettings(CONFIG_KEY)

        Return Path.Combine(pathBase, fileName)
    End Function


End Class
