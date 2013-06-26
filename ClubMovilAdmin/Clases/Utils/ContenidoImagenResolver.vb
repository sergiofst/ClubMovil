Imports System.IO

Public Class ContenidoImagenResolver

    Private Shared m_instance As ContenidoImagenResolver
    Private Shared m_lock As Object = New Object()

    Public Shared Function GetInstance() As ContenidoImagenResolver
        SyncLock m_lock
            If m_instance Is Nothing Then
                m_instance = New ContenidoImagenResolver
            End If
        End SyncLock

        Return m_instance
    End Function

    Private Sub New()

    End Sub

    Public Function GetNewFileName(ByVal fileName As String) As String
        Dim pathBase As String = ConfigurationManager.AppSettings("Imagenes.Directorio")
        Dim newFileName As String = Path.GetRandomFileName
        newFileName = Path.ChangeExtension(newFileName, Path.GetExtension(fileName))

        Return Path.Combine(pathBase, newFileName)
    End Function

    Public Function ResolveFileName(ByVal fileName As String) As String
        Dim pathBase As String = ConfigurationManager.AppSettings("Imagenes.Directorio")
        Return Path.Combine(pathBase, fileName)
    End Function


End Class
