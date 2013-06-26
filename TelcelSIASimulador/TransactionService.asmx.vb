Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.ComponentModel
Imports NLog

' To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line.
' <System.Web.Script.Services.ScriptService()> _
<System.Web.Services.WebService(Namespace:="http://192.168.1.120:8088/sia/services/Transaction")> _
<System.Web.Services.WebServiceBinding(Name:="TransactionSoapBinding", Namespace:="http://192.168.1.120:8088/sia/services/Transaction")> _
<ToolboxItem(False)> _
Public Class TransactionService
    Inherits BaseTransactionService

    Private Shared Log As Logger = LogManager.GetCurrentClassLogger()

    <WebMethod(), SoapRpcMethodAttribute(RequestNamespace:="http://webservice.sia.sm.com", ResponseNamespace:="http://192.168.1.120:8088/sia/services/Transaction")> _
    Public Overrides Function getStatus(ByVal userId As String, ByVal passwd As String, ByVal transactionId As String) As String
        Return "0|4"
    End Function

    <WebMethod(), SoapRpcMethodAttribute(RequestNamespace:="http://webservice.sia.sm.com", ResponseNamespace:="http://192.168.1.120:8088/sia/services/Transaction")> _
    Public Overrides Function requestTransaction(ByVal userId As String, _
                                                 ByVal passwd As String, _
                                                 ByVal userTransactionId As String, _
                                                 ByVal srsRatingId As Long, _
                                                 ByVal msisdn As String, _
                                                 ByVal contentId As String, _
                                                 ByVal contentName As String, _
                                                 ByVal urlOk As String, _
                                                 ByVal urlCancel As String, _
                                                 ByVal urlError As String, _
                                                 ByVal urlUnsusc As String, _
                                                 ByVal extraParam As String) As String
        If Log.IsDebugEnabled Then
            Log.Debug("userTransactionId: " & userTransactionId)
            Log.Debug("srsRatingId: " & srsRatingId)
            Log.Debug("msisdn: " & msisdn)
            Log.Debug("contentId: " & contentId)
            Log.Debug("contentName: " & contentName)
            Log.Debug("urlOk: " & urlOk)
            Log.Debug("urlCancel: " & urlCancel)
            Log.Debug("urlError: " & urlError)
            Log.Debug("urlUnsusc: " & urlUnsusc)
            Log.Debug("extraParam: " & extraParam)
            Log.Debug("RequestTransaction: " & userTransactionId)
        End If

        TransactionManager.GetInstance().AddTransaction(userTransactionId, New Transaction With {.userTransactionId = userTransactionId, _
                                                                                                 .srsRatingId = srsRatingId, _
                                                                                                 .msisdn = msisdn, _
                                                                                                 .contentId = contentId, _
                                                                                                 .contentName = contentName, _
                                                                                                 .urlOk = urlOk, _
                                                                                                 .urlCancel = urlCancel, _
                                                                                                 .urlError = urlError, _
                                                                                                 .urlUnsusc = urlUnsusc})
        Return "1|" & userTransactionId
    End Function

    <WebMethod()> _
    Public Overrides Function requestTransactionInt(ByVal userId As String, ByVal passwd As String, ByVal userTransactionId As String, ByVal srsRatingId As String, ByVal msisdn As String, ByVal contentId As String, ByVal contentName As String, ByVal urlOk As String, ByVal urlCancel As String, ByVal urlError As String, ByVal urlUnsusc As String, ByVal extraParam As String) As String
        Return "Hola"
    End Function

End Class