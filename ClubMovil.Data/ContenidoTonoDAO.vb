Imports System.Data.Common

Public Class ContenidoTonoDAO
    Inherits BaseDAO

    Public Function GetContenidoTono(ByVal idContenidoTono As Integer) As DataRow
        Dim cmd As DbCommand = GetSqlStringCommand("SELECT IdContenidoTono,IdContenido,Formato,Archivo,Estatus FROM Contenido_Tono WHERE IdContenidoTono=@IdContenidoTono")
        AddInParameter(cmd, "@IdContenidoTono", DbType.Int32, idContenidoTono)
        Return ExecuteDataRow(cmd)
    End Function

    Public Function GetContenidoTono(ByVal idContenido As Integer, ByVal formato As String) As DataRow
        Dim cmd As DbCommand = GetSqlStringCommand("SELECT IdContenidoTono,IdContenido,Formato,Archivo,Estatus FROM Contenido_Tono WHERE IdContenido=@IdContenido AND Formato=@Formato AND Estatus=@Estatus")
        AddInParameter(cmd, "@IdContenido", DbType.Int32, idContenido)
        AddInParameter(cmd, "@Formato", DbType.String, formato)
        AddInParameter(cmd, "@Estatus", DbType.Boolean, True)
        Return ExecuteDataRow(cmd)
    End Function

End Class
