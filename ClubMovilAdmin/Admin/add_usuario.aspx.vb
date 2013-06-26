Imports NLog
Imports ClubMovil.Data

Public Class add_usuario
    Inherits BasePage

    Private Shared Log As Logger = LogManager.GetCurrentClassLogger()

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack Then
            Return
        End If

    End Sub

    Private Sub btnRegresar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRegresar.Click
        Response.Redirect("~/Admin/lst_usuarios.aspx")
    End Sub

    Private Sub btnGuardar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        If Not IsValid Then
            Return
        End If

        Try
            Dim daoUsuario As UsuarioDAO = New UsuarioDAO

            Dim drUsuario As DataRow = daoUsuario.GetUsuarioByUsuario(tbUsuario.Text)

            If drUsuario IsNot Nothing Then
                AddErrorMessage("El nombre de usuario ya existe")
                Return
            End If


            Dim id As Integer = daoUsuario.AddUsuario(tbUsuario.Text, tbNombre.Text, tbPassword.Text)

            Response.Redirect("~/Admin/lst_usuarios.aspx")
        Catch ex As Exception
            If Log.IsErrorEnabled Then
                Log.Error(ex.ToString)
            End If
            AddErrorMessage("Hubo un problema al efectuar la operacion")
        End Try

    End Sub

End Class