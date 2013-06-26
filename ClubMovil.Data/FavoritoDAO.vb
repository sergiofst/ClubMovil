Imports System.Data.Common

Public Class FavoritoDAO
    Inherits BaseDAO

    Public Function AddFavorito(ByVal telefono As String, ByVal estatus As FavoritoEstatus) As Integer
        Dim cmd As DbCommand = GetSqlStringCommand("INSERT Favorito (Telefono, Fecha, Estatus) VALUES (@Telefono, NOW(), @Estatus)")
        AddInParameter(cmd, "@Telefono", DbType.Int32, telefono)
        AddInParameter(cmd, "@Estatus", DbType.Int32, CInt(estatus))
        Return ExecuteNonQueryIdentity(cmd)
    End Function

    Public Function GetFavorito(ByVal idFavorito As String) As DataRow
        Dim cmd As DbCommand = GetSqlStringCommand("SELECT IdFavorito, Telefono, Fecha, Estatus WHERE IdFavorito=@IdFavorito")
        AddInParameter(cmd, "@IdFavorito", DbType.Int32, idFavorito)
        Return ExecuteDataRow(cmd)
    End Function

    Public Function UpdFavoritoEstatus(ByVal idFavorito As Integer, ByVal estatus As FavoritoEstatus) As Integer
        Dim cmd As DbCommand = GetSqlStringCommand("UPDATE Favorito SET Estatus=@Estatus WHERE IdFavorito=@IdFavorito")
        AddInParameter(cmd, "@IdFavorito", DbType.Int32, idFavorito)
        AddInParameter(cmd, "@Estatus", DbType.Int32, CInt(estatus))
        Return CInt(ExecuteNonQuery(cmd))
    End Function

    Public Function DelFavorito(ByVal idFavorito As Integer) As Integer
        Dim cmd As DbCommand = GetSqlStringCommand("UPDATE Favorito SET Estatus=@Estatus WHERE IdFavorito=@IdFavorito")
        AddInParameter(cmd, "@IdFavorito", DbType.Int32, idFavorito)
        AddInParameter(cmd, "@Estatus", DbType.Int32, CInt(FavoritoEstatus.Eliminado))
        Return CInt(ExecuteNonQuery(cmd))
    End Function

    Public Enum FavoritoEstatus
        Eliminado
        Inactivo
        Activo
    End Enum

End Class
