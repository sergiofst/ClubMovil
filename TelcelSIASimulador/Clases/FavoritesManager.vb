Public Class FavoritosManager

    Private Shared m_instance As FavoritosManager
    Private Shared m_lock As Object = New Object
    Private m_data As Hashtable = Nothing

    Private Sub New()
        m_data = New Hashtable
    End Sub

    Public Shared Function GetInstance() As FavoritosManager
        SyncLock m_lock
            If m_instance Is Nothing Then
                m_instance = New FavoritosManager
            End If
        End SyncLock

        Return m_instance
    End Function

    Public Sub AddFavorito(ByVal fav As Favorito)
        SyncLock m_data
            fav.Estatus = Favorito.FavoritoEstatus.Inactivo
            m_data.Add(fav.Telefono, fav)
        End SyncLock
    End Sub

    Public Function GetFavorito(ByVal telefono As String) As Favorito
        Return CType(m_data(telefono), Favorito)
    End Function

    Public Sub ConfirmFavorito(ByVal telefono As String)
        SyncLock m_data
            Dim curFav As Favorito = CType(m_data(telefono), Favorito)
            curFav.Estatus = Favorito.FavoritoEstatus.Activo
        End SyncLock
    End Sub

    Public Sub ClearFavoritos()
        SyncLock m_data
            m_data.Clear()
        End SyncLock
    End Sub

    Public Sub DelFavorito(ByVal telefono As String)
        SyncLock m_data
            m_data.Remove(telefono)
        End SyncLock
    End Sub

End Class

Public Class Favorito
    Public Telefono As String
    Public URL As String
    Public Titulo As String
    Public UserId As String
    Public Estatus As FavoritoEstatus

    Public Enum FavoritoEstatus
        Inactivo
        Activo
    End Enum

End Class


