Imports ClubMovil.Data
Imports NLog

Partial Public Class Login
    Inherits BasePage

    Private Shared Log As Logger = LogManager.GetCurrentClassLogger()

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack Then
            Return
        End If

        btnIniciar.OnClientClick = JSDisableButtonPostBack(btnIniciar)
    End Sub

    Private Sub btnIniciar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnIniciar.Click
        If Not IsValid Then
            Return
        End If

        ' Valida el usuario
        Dim daoUsuario As UsuarioDAO = New UsuarioDAO()

        'Dim encPass As String = EncryptUtil.GetEncryptedCode(tbPassword.Text.Trim())
        Dim drUsuario As DataRow = daoUsuario.GetUsuario(tbUsuario.Text, tbPassword.Text)
        If drUsuario Is Nothing Then
            AddErrorMessage("Usuario invalido")
            Return
        End If

        If Log.IsInfoEnabled Then
            Log.Info("Inicio de sesion: " & tbUsuario.Text)
        End If

        ' Autentifica y redirecciona
        FormsAuthentication.RedirectFromLoginPage(CStr(drUsuario("IdUsuario")), False)
    End Sub

End Class