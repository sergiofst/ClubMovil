Public Class TransactionManager
    Private Shared m_instance As TransactionManager
    Private Shared m_lock As Object = New Object
    Private m_data As Hashtable = Nothing

    Private Sub New()
        m_data = New Hashtable
    End Sub

    Public Shared Function GetInstance() As TransactionManager
        SyncLock m_lock
            If m_instance Is Nothing Then
                m_instance = New TransactionManager
            End If
        End SyncLock

        Return m_instance
    End Function

    Public Sub AddTransaction(ByVal id As String, ByVal trans As Transaction)
        SyncLock m_lock
            m_data.Add(id, trans)
        End SyncLock
    End Sub

    Public Function GetTransaction(ByVal id As String) As Transaction
        Dim result As Transaction = Nothing
        SyncLock m_lock
            result = CType(m_data(id), Transaction)
        End SyncLock
        Return result
    End Function



End Class

Public Class Transaction
    Public userTransactionId As String
    Public srsRatingId As Long
    Public msisdn As String
    Public contentId As String
    Public contentName As String
    Public urlOk As String
    Public urlCancel As String
    Public urlError As String
    Public urlUnsusc As String
    Public extraParam As String

End Class