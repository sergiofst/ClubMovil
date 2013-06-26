Imports System.Data.Common
Imports System.Text

Public Class PropiedadDAO
    Inherits BaseDAO

    Public Function GetPropiedad(ByVal nombre As String) As String
        Dim cmd As DbCommand = GetSqlStringCommand("SELECT Valor FROM Propiedad WHERE Nombre=@Nombre AND Estatus=@Estatus")
        AddInParameter(cmd, "@Nombre", DbType.String, nombre)
        AddInParameter(cmd, "@Estatus", DbType.Boolean, True)
        Dim result As DataRow = ExecuteDataRow(cmd)
        If result IsNot Nothing Then
            Return CStr(result("Valor"))
        End If
        Return Nothing
    End Function

End Class
