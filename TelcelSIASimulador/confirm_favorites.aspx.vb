Public Class confirm_favorites
    Inherits BasePage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack Then
            Return
        End If

        Dim favorito As Favorito = FavoritosManager.GetInstance().GetFavorito(GetMSISDN)
        litId.Text = favorito.UserId
        litUrl.Text = favorito.URL
        litMSISDN.Text = favorito.Telefono
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        FavoritosManager.GetInstance().ConfirmFavorito(GetMSISDN)

        Response.Redirect(FavoritosManager.GetInstance().GetFavorito(GetMSISDN()).URL)
    End Sub

End Class