Public Class _Default
    Inherits BasePage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If User.IsInRole("Administrador") Then
            Response.Redirect("~/Admin/Default.aspx")
        End If
    End Sub

End Class