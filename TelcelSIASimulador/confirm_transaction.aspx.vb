Public Class confirm_transaction
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack Then
            Return
        End If

        hypConfirmar.NavigateUrl = TransactionManager.GetInstance().GetTransaction(Request("id")).urlOk
    End Sub

End Class