Imports System.IO

Public Class ContenidoUtils

    Public Shared Function GetRandomFileName(ByVal fileName As String) As String
        Dim newFileName As String = Path.GetRandomFileName
        newFileName = Path.ChangeExtension(newFileName, Path.GetExtension(fileName))
        Return newFileName
    End Function

End Class
