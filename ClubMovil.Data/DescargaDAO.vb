Imports System.Data.Common
Imports System.Text

Public Class DescargaDAO
    Inherits BaseDAO

    Public Function AddDescarga(ByVal idContenido As Integer, ByVal idTransaccion As Integer) As Integer
        Dim cmd As DbCommand = GetSqlStringCommand("INSERT INTO Descarga (IdContenido,IdTransaccion,Fecha) VALUES (@IdContenido,@IdTransaccion, NOW())")
        AddInParameter(cmd, "@IdContenido", DbType.Int32, idContenido)
        AddInParameter(cmd, "@IdTransaccion", DbType.Int32, idTransaccion)
        Return ExecuteNonQueryIdentity(cmd)
    End Function


End Class
