Public Class NavBarControl
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack Then
            Return
        End If

    End Sub

    Public Function GetUserName() As String
        Dim currPage As BasePage = CType(Me.Page, BasePage)
        Return CStr(currPage.GetUsuario("Nombre"))
    End Function



End Class