Imports System.Data.Common
Imports System.Text

Public Class ProductDAO
    Inherits BaseDAO

    Public Function ListProducts() As DataSet
        Dim cmd As DbCommand = GetSqlStringCommand("SELECT IdProduct, Name, Description, Image, [Order], Visible, Status FROM Product WHERE Status=@Status AND Visible=@Visible")
        AddInParameter(cmd, "@Status", DbType.Boolean, True)
        AddInParameter(cmd, "@Visible", DbType.Boolean, True)
        Return ExecuteDataSet(cmd)
    End Function

    Public Function GetProductsByIdCategory(ByVal idCategory As Integer) As DataSet
        Dim query As StringBuilder = New StringBuilder
        With query
            .Append("SELECT A.IdProduct, A.Name, A.Description, A.Image, A.[Order], A.Visible, ")
            .Append("B.IdProductCategory, B.IdCategory ")
            .Append("FROM Product AS A INNER JOIN ProductCategory AS B ON (A.IdProduct=B.IdProduct) ")
            .Append("WHERE B.IdCategory=@IdCategory AND A.Status=@Status AND B.Status=@Status ")
        End With
        Dim cmd As DbCommand = GetSqlStringCommand(query.ToString)
        AddInParameter(cmd, "@IdCategory", DbType.Int32, idCategory)
        AddInParameter(cmd, "@Status", DbType.Boolean, True)
        Return ExecuteDataSet(cmd)
    End Function

    Public Function GetProduct(ByVal idProduct As Integer) As DataSet
        Dim cmd As DbCommand = GetSqlStringCommand("SELECT IdProduct, Name, Description, Image, [Order], Visible, Status FROM Product WHERE IdProduct=@IdProduct")
        AddInParameter(cmd, "@IdProduct", DbType.Int32, idProduct)
        Return ExecuteDataSet(cmd)
    End Function

    Public Function GetCategory(ByVal idCategory As Integer) As DataRow
        Dim cmd As DbCommand = GetSqlStringCommand("SELECT IdCategory, Name, Description, IdParent, [Order], Status FROM Category WHERE IdCategory = @IdCategory")
        AddInParameter(cmd, "@IdCategory", DbType.Int32, idCategory)
        Return ExecuteDataRow(cmd)
    End Function




End Class
