Imports System.Data.Common

Public Class ContenidoFondoDAO
    Inherits BaseDAO

    Public Function GetContenidoFondo(ByVal idContenidoFondo As Integer) As DataRow
        Dim cmd As DbCommand = GetSqlStringCommand("SELECT IdContenidoFondo,IdContenido,AnchoImagen,Archivo FROM Contenido_Fondo WHERE IdContenidoFondo=@IdContenidoFondo")
        AddInParameter(cmd, "@IdContenidoFondo", DbType.Int32, idContenidoFondo)
        Return ExecuteDataRow(cmd)
    End Function

    Public Function GetContenidoFondo(ByVal idContenido As Integer, ByVal anchoImagen As Integer) As DataRow
        Dim cmd As DbCommand = GetSqlStringCommand("SELECT IdContenidoFondo,IdContenido,AnchoImagen,Archivo FROM Contenido_Fondo WHERE IdContenido=@IdContenido AND AnchoImagen=@AnchoImagen AND Estatus=@Estatus")
        AddInParameter(cmd, "@IdContenido", DbType.Int32, idContenido)
        AddInParameter(cmd, "@AnchoImagen", DbType.Int32, anchoImagen)
        AddInParameter(cmd, "@Estatus", DbType.Boolean, True)
        Return ExecuteDataRow(cmd)
    End Function

    Public Function ListContenidoFondo(ByVal idContenido As Integer) As DataSet
        Dim cmd As DbCommand = GetSqlStringCommand("SELECT IdContenidoFondo,IdContenido,AnchoImagen,Archivo FROM Contenido_Fondo WHERE IdContenido=@IdContenido AND Estatus=@Estatus")
        AddInParameter(cmd, "@IdContenido", DbType.Int32, idContenido)
        AddInParameter(cmd, "@Estatus", DbType.Boolean, True)
        Return ExecuteDataSet(cmd)
    End Function

    Public Function DelContenidoFondo(ByVal idContenidoFondo As Integer) As Integer
        Dim cmd As DbCommand = GetSqlStringCommand("UPDATE Contenido_Fondo SET Estatus=@Estatus WHERE IdContenidoFondo=@IdContenidoFondo")
        AddInParameter(cmd, "@IdContenidoFondo", DbType.Int32, idContenidoFondo)
        AddInParameter(cmd, "@Estatus", DbType.Boolean, False)
        Return CInt(ExecuteNonQuery(cmd))
    End Function

    Public Function AddContenidoFondo(ByVal idContenido As Integer, ByVal anchoImagen As Integer, ByVal archivo As String) As Integer
        Dim cmd As DbCommand = GetSqlStringCommand("INSERT INTO Contenido_Fondo (IdContenido,AnchoImagen,Archivo,Estatus) VALUES (@IdContenido,@AnchoImagen,@Archivo,@Estatus)")
        AddInParameter(cmd, "@IdContenido", DbType.Int32, idContenido)
        AddInParameter(cmd, "@AnchoImagen", DbType.Int32, anchoImagen)
        AddInParameter(cmd, "@Archivo", DbType.String, archivo)
        AddInParameter(cmd, "@Estatus", DbType.Boolean, True)
        Return CInt(ExecuteNonQuery(cmd))
    End Function



End Class
