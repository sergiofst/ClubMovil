Imports ClubMovil.Data
Imports NLog

Public Class upd_usuario
    Inherits BasePage

    Private Shared Log As Logger = LogManager.GetCurrentClassLogger()

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack Then
            Return
        End If

        If String.IsNullOrEmpty(CStr(Context.Items("IdUsuario"))) Then
            Throw New ArgumentNullException("IdUsuario")
        End If

        CurrIdUsuario = CInt(Context.Items("IdUsuario"))

        Dim drUsuario As DataRow = New UsuarioDAO().GetUsuario(CurrIdUsuario)

        litIdUsuario.Text = CStr(drUsuario("IdUsuario"))
        tbUsuario.Text = CStr(drUsuario("Usuario"))
        tbNombre.Text = CStr(drUsuario("Nombre"))

    End Sub

    Public Property CurrIdUsuario() As Integer
        Get
            Return CInt(ViewState("__currIdUsuario"))
        End Get
        Set(ByVal value As Integer)
            ViewState("__currIdUsuario") = value
        End Set
    End Property

    Private Sub btnRegresar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRegresar.Click
        Response.Redirect("~/Admin/lst_usuarios.aspx")
    End Sub


    Private Sub btnEliminar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
        Dim dumy As Integer = New UsuarioDAO().DelUsuario(CurrIdUsuario)
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
                If CInt(drUsuario("IdUsuario")) = CurrIdUsuario Then
                    AddErrorMessage("La clave de usuario ya existe")
                End If
            End If

            Dim dumy As Integer = daoUsuario.UpdUsuario(tbUsuario.Text, tbNombre.Text, CurrIdUsuario)

            Response.Redirect("~/Admin/lst_usuarios.aspx")
        Catch ex As Exception
            If Log.IsErrorEnabled Then
                Log.Error(ex.ToString())
            End If
        End Try
    End Sub
End Class