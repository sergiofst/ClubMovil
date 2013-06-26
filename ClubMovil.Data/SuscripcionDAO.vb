Imports System.Data.Common

Public Class SuscripcionDAO
    Inherits BaseDAO

    Public Function GetSuscripcion(ByVal idSuscripcion As Integer) As DataRow
        Dim cmd As DbCommand = GetSqlStringCommand("SELECT IdSuscripcion,Telefono,Creditos,FechaSuscripcion,FechaRenovacion,Estatus FROM Suscripcion WHERE IdSuscripcion=@IdSuscripcion")
        AddInParameter(cmd, "@IdSuscripcion", DbType.Int32, idSuscripcion)
        Return ExecuteDataRow(cmd)
    End Function

    Public Function GetSuscripcionByTelefono(ByVal telefono As String) As DataRow
        Dim cmd As DbCommand = GetSqlStringCommand("SELECT IdSuscripcion,Telefono,Creditos,FechaSuscripcion,FechaRenovacion,Estatus FROM Suscripcion WHERE Telefono=@Telefono AND Estatus=@Estatus")
        AddInParameter(cmd, "@Telefono", DbType.String, telefono)
        AddInParameter(cmd, "@Estatus", DbType.Int32, CInt(Estatus.Activa))
        Return ExecuteDataRow(cmd)
    End Function

    Public Function AddSuscripcion(ByVal telefono As String, ByVal creditos As Integer, ByVal currStatus As Estatus) As Integer
        Dim cmd As DbCommand = GetSqlStringCommand("INSERT INTO Suscripcion (Telefono,Creditos,FechaSuscripcion,FechaRenovacion,Estatus) VALUES (@Telefono,@Creditos,NOW(),DATE_ADD(NOW(), INTERVAL 7 DAY),@Estatus)")
        AddInParameter(cmd, "@Telefono", DbType.String, telefono)
        AddInParameter(cmd, "@Creditos", DbType.Int32, creditos)
        AddInParameter(cmd, "@Estatus", DbType.Int32, CInt(currStatus))
        Return ExecuteNonQueryIdentity(cmd)
    End Function

    Public Function UpdSuscripcionEstatus(ByVal currStatus As Estatus, ByVal idSuscripcion As Integer) As Integer
        Dim cmd As DbCommand = GetSqlStringCommand("UPDATE Suscripcion SET Estatus=@Estatus WHERE IdSuscripcion=@IdSuscripcion")
        AddInParameter(cmd, "@IdSuscripcion", DbType.Int32, idSuscripcion)
        AddInParameter(cmd, "@Estatus", DbType.Int32, CInt(currStatus))
        Return CInt(ExecuteNonQuery(cmd))
    End Function

    Public Function ListSuscripciones() As DataSet
        Dim cmd As DbCommand = GetSqlStringCommand("SELECT IdSuscripcion,Telefono,Creditos,FechaSuscripcion,FechaRenovacion,Estatus FROM Suscripcion")
        Return ExecuteDataSet(cmd)
    End Function

    Public Enum Estatus
        'Inicio
        'Nueva
        Cancelada
        Baja
        Pendiente
        Activa
        'Cobro
    End Enum

End Class
