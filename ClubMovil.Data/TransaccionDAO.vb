Imports System.Data.Common
Imports System.Text

Public Class TransaccionDAO
    Inherits BaseDAO


    Public Function AddTransaccion(ByVal idSuscripcion As Integer, ByVal transId As String, ByVal srsRatingId As Integer, _
                                   ByVal telefono As String, ByVal idContenido As Integer, ByVal contenidoNombre As String, _
                                   ByVal urlOk As String, ByVal urlCancel As String, ByVal urlError As String, _
                                   ByVal urlUnsusc As String, ByVal extraParam As String, ByVal currEstatus As Integer) As Integer
        Dim query As StringBuilder = New StringBuilder
        With query
            .Append("INSERT INTO Transaccion")
            .Append("(transactionId,SRSRatingId,Telefono,IdContenido,ContenidoNombre,UrlOK, UrlCancel, UrlError, UrlUnsusc, ExtraParam, Fecha, Estatus, IdSuscripcion) ")
            .Append(" VALUES ")
            .Append("(@transactionId,@SRSRatingId,@Telefono,@IdContenido,@ContenidoNombre,@UrlOK,@UrlCancel,@UrlError,@UrlUnsusc,@ExtraParam,NOW(),@Estatus,@IdSuscripcion) ")
        End With

        Dim cmd As DbCommand = GetSqlStringCommand(query.ToString())
        AddInParameter(cmd, "@transactionId", DbType.String, 0)
        AddInParameter(cmd, "@SRSRatingId", DbType.Int32, srsRatingId)
        AddInParameter(cmd, "@Telefono", DbType.String, telefono)
        AddInParameter(cmd, "@IdContenido", DbType.Int32, idContenido)
        AddInParameter(cmd, "@ContenidoNombre", DbType.String, contenidoNombre)
        AddInParameter(cmd, "@UrlOK", DbType.String, urlOk)
        AddInParameter(cmd, "@UrlCancel", DbType.String, urlCancel)
        AddInParameter(cmd, "@UrlError", DbType.String, urlError)
        AddInParameter(cmd, "@UrlUnsusc", DbType.String, urlUnsusc)
        AddInParameter(cmd, "@ExtraParam", DbType.String, extraParam)
        AddInParameter(cmd, "@Estatus", DbType.Int32, currEstatus)
        AddInParameter(cmd, "@IdSuscripcion", DbType.Int32, idSuscripcion)
        Return ExecuteNonQueryIdentity(cmd)
    End Function

    Public Function GetUUIDShort() As String
        Return CStr(ExecuteDataRow(GetSqlStringCommand("SELECT UUID_SHORT()"))(0))
    End Function

    Public Enum Estatus
        Aceptacion
        Pendiente
        Aprobada
        Descargada
        Cancelada
        [Error]
    End Enum

End Class
