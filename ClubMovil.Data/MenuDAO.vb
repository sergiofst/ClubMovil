Imports System.Data.Common

Public Class MenuDAO
    Inherits BaseDAO

    Public Function GetMenu(ByVal idMenu As Integer) As DataRow
        Dim cmd As DbCommand = GetSqlStringCommand("SELECT IdMenu, Nombre, Descripcion, Imagen, Orden, IdMenuPadre, Url, Visible, Estatus FROM Menu WHERE IdMenu=@IdMenu")
        AddInParameter(cmd, "@IdMenu", DbType.Int32, idMenu)
        Return ExecuteDataRow(cmd)
    End Function

    Public Function ListMenuByPadre(ByVal idMenuPadre As Integer) As DataSet
        Dim cmd As DbCommand = GetSqlStringCommand("SELECT IdMenu, Nombre, Descripcion, Imagen, Orden, IdMenuPadre, Url, Visible, Estatus FROM Menu WHERE Estatus=@Estatus AND IdMenuPadre=@IdMenuPadre")
        AddInParameter(cmd, "@Estatus", DbType.Boolean, True)
        AddInParameter(cmd, "@IdMenuPadre", DbType.Int32, idMenuPadre)
        Return ExecuteDataSet(cmd)
    End Function

End Class
