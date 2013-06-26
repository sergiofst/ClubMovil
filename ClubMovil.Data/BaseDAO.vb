Imports System.Data.Common
Imports Microsoft.Practices.EnterpriseLibrary.Data


Public MustInherit Class BaseDAO
    Private m_Database As Database

    Public Sub New()
        m_Database = DatabaseFactory.CreateDatabase
    End Sub
    Public Sub New(ByVal connStr As String)
        m_Database = DatabaseFactory.CreateDatabase(connStr)
    End Sub

    Protected Function ExecuteNonQueryIdentity(ByVal cmd As DbCommand) As Integer
        Dim result As Integer = -1
        Using dbConn As DbConnection = Database.CreateConnection
            cmd.Connection = dbConn
            cmd.Connection.Open()
            cmd.ExecuteNonQuery()
            cmd.CommandText = "SELECT LAST_INSERT_ID()"
            result = CInt(cmd.ExecuteScalar)
            dbConn.Close()
        End Using

        Return result
    End Function

    Private ReadOnly Property Database As Database
        Get
            Return m_Database
        End Get
    End Property

    Protected Function ExecuteDataRow(ByVal cmd As DbCommand) As DataRow
        Dim result As DataSet = Database.ExecuteDataSet(cmd)
        If result.Tables(0).Rows.Count > 0 Then
            Return result.Tables(0).Rows(0)
        End If
        Return Nothing
    End Function
    Protected Function ExecuteDataSet(ByVal cmd As DbCommand) As DataSet
        Return Database.ExecuteDataSet(cmd)
    End Function
    Protected Function ExecuteNonQuery(ByVal cmd As DbCommand) As Object
        Return Database.ExecuteNonQuery(cmd)
    End Function

    Protected Function GetSqlStringCommand(ByVal query As String) As DbCommand
        Return Database.GetSqlStringCommand(query)
    End Function

    Protected Sub AddInParameter(ByVal cmd As DbCommand, ByVal name As String, ByVal type As DbType, ByVal value As Object)
        Database.AddInParameter(cmd, name, type, value)
    End Sub

End Class
