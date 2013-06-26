Imports System.IO

Public Class ContenidoArchivoResolver

    Private Shared m_instance As ContenidoArchivoResolver
    Private Shared m_lock As Object = New Object()

    Public Shared Function GetInstance() As ContenidoArchivoResolver
        SyncLock m_lock
            If m_instance Is Nothing Then
                m_instance = New ContenidoArchivoResolver
            End If
        End SyncLock

        Return m_instance
    End Function

    Private Sub New()

    End Sub

    Public Function GetNewFileName(ByVal fileName As String) As String
        Dim pathBase As String = ConfigurationManager.AppSettings("Archivos.Directorio")
        Dim newFileName As String = Path.GetRandomFileName
        newFileName = Path.ChangeExtension(newFileName, Path.GetExtension(fileName))

        Return Path.Combine(pathBase, newFileName)
    End Function

    Public Function ResolveFileName(ByVal fileName As String) As String
        Dim pathBase As String = ConfigurationManager.AppSettings("Archivos.Directorio")
        Return Path.Combine(pathBase, fileName)
    End Function


End Class
