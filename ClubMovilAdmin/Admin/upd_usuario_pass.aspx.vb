Imports NLog
Imports ClubMovil.Data

Public Class upd_usuario_pass
    Inherits BasePage

    Private Shared Log As Logger = LogManager.GetCurrentClassLogger()

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack Then
            Return
        End If

        If String.IsNullOrEmpty(CStr(Context.Items("IdUsuario"))) Then
            Throw New ArgumentNullException("IdUsuario")
        End If

        IdUsuario = CInt(Context.Items("IdUsuario"))

    End Sub

    Public Property IdUsuario As Integer
        Get
            Return CInt(ViewState("__idUsuario"))
        End Get
        Set(ByVal value As Integer)
            ViewState("__idUsuario") = value
        End Set
    End Property

    Private Sub btnGuardar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        If Not IsValid Then
            Return
        End If

        Try
            Dim daoUsuario As UsuarioDAO = New UsuarioDAO()

            ' Actualiza la contraseña
            'encPass = EncryptUtil.GetEncryptedCode(tbNuevoPassword.Text.Trim())
            daoUsuario.UpdPassword(tbNuevoPassword.Text.Trim(), IdUsuario)

            ' Redirecciona a la pagina por default
            Response.Redirect("~/Admin/lst_usuarios.aspx", True)
        Catch ex As Exception
            If Log.IsErrorEnabled Then
                Log.Error(ex.ToString)
            End If
            AddErrorMessage("Hubo un problema al actualizar el registro")
        End Try



    End Sub

    Private Sub btnRegresar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRegresar.Click
        Response.Redirect("~/Admin/lst_usuarios.aspx")
    End Sub

End Class