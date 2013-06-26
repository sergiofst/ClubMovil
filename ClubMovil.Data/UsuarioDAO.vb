Imports System.Text
Imports System.Data.Common

Public Class UsuarioDAO
    Inherits BaseDAO

    Public Function GetUsuario(ByVal idUsuario As Integer) As DataRow
        Dim cmd As DbCommand = GetSqlStringCommand("SELECT IdUsuario, Nombre, Usuario, Password FROM Usuario WHERE IdUsuario=@IdUsuario")
        AddInParameter(cmd, "@IdUsuario", DbType.Int32, idUsuario)
        Return ExecuteDataRow(cmd)
    End Function

    Public Function GetUsuario(ByVal usuario As String, ByVal password As String) As DataRow
        Dim cmd As DbCommand = GetSqlStringCommand("SELECT IdUsuario, Nombre, Usuario, Password FROM Usuario WHERE Usuario=@Usuario AND Password=@Password AND Estatus=@Estatus")
        AddInParameter(cmd, "@Usuario", DbType.String, usuario)
        AddInParameter(cmd, "@Password", DbType.String, password)
        AddInParameter(cmd, "@Estatus", DbType.Boolean, True)
        Return ExecuteDataRow(cmd)
    End Function

    Public Function GetUsuarioByUsuario(ByVal usuario As String) As DataRow
        Dim cmd As DbCommand = GetSqlStringCommand("SELECT IdUsuario, Nombre, Usuario, Password FROM Usuario WHERE Usuario=@Usuario AND Estatus=@Estatus")
        AddInParameter(cmd, "@Usuario", DbType.String, usuario)
        AddInParameter(cmd, "@Estatus", DbType.Boolean, True)
        Return ExecuteDataRow(cmd)
    End Function

    Public Function ListRolesUsuario(ByVal idUsuario As Integer) As DataSet
        Dim query As StringBuilder = New StringBuilder()
        With query
            .Append("SELECT A.IdRol,A.Rol FROM Rol AS A ")
            .Append("INNER JOIN UsuarioRol AS B ON (A.IdRol=B.IdRol AND B.Estatus=@Estatus) ")
            .Append("INNER JOIN Usuario AS C ON (B.IdUsuario=C.IdUsuario AND C.Estatus=@Estatus) ")
            .Append("WHERE C.IdUsuario=@IdUsuario AND A.Estatus=@Estatus ")
        End With
        Dim cmd As DbCommand = GetSqlStringCommand(query.ToString())
        AddInParameter(cmd, "@IdUsuario", DbType.Int32, idUsuario)
        AddInParameter(cmd, "@Estatus", DbType.Boolean, True)
        Return ExecuteDataSet(cmd)
    End Function

    Public Function IsUsuarioEnRol(ByVal idUsuario As Integer, ByVal rol As String) As Boolean
        Dim query As StringBuilder = New StringBuilder()
        With query
            .Append("SELECT COUNT(IdUsuario) as Conteo FROM Usuario AS A ")
            .Append("INNER JOIN UsuarioRol AS B ON (A.IdUsuario=B.IdUsuario AND B.Estatus=@Estatus) ")
            .Append("INNER JOIN Rol AS C ON (B.IdRol=C.IdRol AND C.Estatus=@Estatus) ")
            .Append("WHERE C.IdUsuario=@IdUsuario AND C.Rol=@Rol AND A.Estatus=@Estatus ")
        End With
        Dim cmd As DbCommand = GetSqlStringCommand(query.ToString())
        AddInParameter(cmd, "@IdUsuario", DbType.Int32, idUsuario)
        AddInParameter(cmd, "@Rol", DbType.String, rol)
        AddInParameter(cmd, "@Estatus", DbType.Boolean, True)
        If CInt(ExecuteDataRow(cmd)("Conteo")) = 0 Then
            Return False
        End If
        Return True
    End Function

    Public Function ListUsuarios() As DataSet
        Dim cmd As DbCommand = GetSqlStringCommand("SELECT IdUsuario, Nombre, Usuario, Password FROM Usuario WHERE Estatus=@Estatus")
        AddInParameter(cmd, "@Estatus", DbType.Boolean, True)
        Return ExecuteDataSet(cmd)
    End Function

    Public Function UpdUsuario(ByVal nombre As String, ByVal usuario As String, ByVal idUsuario As Integer) As Integer
        Dim cmd As DbCommand = GetSqlStringCommand("UPDATE Usuario SET Nombre=@Nombre, Usuario=@Usuario WHERE IdUsuario=@IdUsuario")
        AddInParameter(cmd, "@IdUsuario", DbType.Int32, idUsuario)
        AddInParameter(cmd, "@Nombre", DbType.String, nombre)
        AddInParameter(cmd, "@Usuario", DbType.String, usuario)
        Return CInt(ExecuteNonQuery(cmd))
    End Function

    Public Function AddUsuario(ByVal nombre As String, ByVal usuario As String, ByVal password As String) As Integer
        Dim cmd As DbCommand = GetSqlStringCommand("INSERT Usuario (Nombre,Usuario,Password,Estatus) VALUES (@Nombre,@Usuario,@Password,@Estatus)")
        AddInParameter(cmd, "@Nombre", DbType.String, nombre)
        AddInParameter(cmd, "@Usuario", DbType.String, usuario)
        AddInParameter(cmd, "@Estatus", DbType.Boolean, True)
        Return ExecuteNonQueryIdentity(cmd)
    End Function

    Public Function DelUsuario(ByVal idUsuario As Integer) As Integer
        Dim cmd As DbCommand = GetSqlStringCommand("UPDATE Usuario SET Estatus=@Estatus WHERE IdUsuario=@IdUsuario")
        AddInParameter(cmd, "@Estatus", DbType.Boolean, False)
        AddInParameter(cmd, "@IdUsuario", DbType.Int32, idUsuario)
        Return CInt(ExecuteNonQuery(cmd))
    End Function

    Public Function AddUsuarioRol(ByVal idUsuario As Integer, ByVal idRol As Integer) As Integer
        Dim cmd As DbCommand = GetSqlStringCommand("INSERT UsuarioRol (IdUsuario,IdRol,Estatus) VALUES (@IdUsuario,@IdRol,@Estatus)")
        AddInParameter(cmd, "@IdUsuario", DbType.Int32, idUsuario)
        AddInParameter(cmd, "@IdRol", DbType.Int32, idRol)
        AddInParameter(cmd, "@Estatus", DbType.Boolean, True)
        Return ExecuteNonQueryIdentity(cmd)
    End Function

    Public Function DelUsuarioRol(ByVal idUsuarioRol As Integer) As Integer
        Dim cmd As DbCommand = GetSqlStringCommand("UPDATE UsuarioRol SET Estatus=@Estatus WHERE IdUsuarioRol=@IdUsuarioRol")
        AddInParameter(cmd, "@IdUsuarioRol", DbType.Int32, idUsuarioRol)
        AddInParameter(cmd, "@Estatus", DbType.Boolean, True)
        Return ExecuteNonQueryIdentity(cmd)
    End Function

    Public Function ListRoles() As DataSet
        Dim cmd As DbCommand = GetSqlStringCommand("SELECT IdRol, Rol, Descripcion FROM Rol WHERE Estatus=@Estatus")
        AddInParameter(cmd, "@Estatus", DbType.Boolean, True)
        Return ExecuteDataSet(cmd)
    End Function

    Public Function IsPasswordValido(ByVal password As String, ByVal idUsuario As Integer) As Boolean
        Dim cmd As DbCommand = GetSqlStringCommand("SELECT COUNT(IdUsuario) AS Conteo FROM Usuario WHERE IdUsuario=@IdUsuario AND Password=@Password AND Estatus=@Estatus ")
        AddInParameter(cmd, "@IdUsuario", DbType.Int32, idUsuario)
        AddInParameter(cmd, "@Password", DbType.String, password)
        AddInParameter(cmd, "@Estatus", DbType.Boolean, True)
        If CInt(ExecuteDataRow(cmd)("Conteo")) = 0 Then
            Return False
        End If
        Return True
    End Function

    Public Function UpdPassword(ByVal password As String, ByVal idUsuario As Integer) As Integer
        Dim cmd As DbCommand = GetSqlStringCommand("UPDATE Usuario SET Password=@Password WHERE IdUsuario=@IdUsuario")
        AddInParameter(cmd, "@Password", DbType.String, password)
        AddInParameter(cmd, "@IdUsuario", DbType.Int32, idUsuario)
        Return CInt(ExecuteNonQuery(cmd))
    End Function

End Class
