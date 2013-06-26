Public Class ErrorSummary
    Implements IValidator

    Private m_message As String

    Public Shared Sub AddError(ByVal message As String, ByVal [page] As Page)
        [page].Validators.Add(New ErrorSummary(message))
    End Sub

    Private Sub New(ByVal message As String)
        m_message = message
    End Sub

    Public Property ErrorMessage() As String Implements System.Web.UI.IValidator.ErrorMessage
        Get
            Return m_message
        End Get
        Set(ByVal Value As String)
            m_message = Value
        End Set
    End Property

    Public Property IsValid() As Boolean Implements System.Web.UI.IValidator.IsValid
        Get
            Return False
        End Get
        Set(ByVal Value As Boolean)

        End Set
    End Property

    Public Sub Validate() Implements System.Web.UI.IValidator.Validate

    End Sub


End Class
