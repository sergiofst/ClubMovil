Imports NLog
Imports ClubMovil.Data

Public Class upd_contenido
    Inherits BasePage

    Private Shared Log As Logger = LogManager.GetCurrentClassLogger()

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack Then
            Return
        End If

        If String.IsNullOrEmpty(CStr(Context.Items("IdContenido"))) Then
            Throw New ArgumentNullException("IdContenido")
        End If

        IdContenido = CInt(Context.Items("IdContenido"))

        Dim daoContenido As ContenidoDAO = New ContenidoDAO()

        Dim drCategoria As DataRow = daoContenido.GetContenido(IdContenido)

        litIdContenido.Text = CStr(drCategoria("IdContenido"))
        tbNombre.Text = CStr(drCategoria("Nombre"))
        tbDescripcion.Text = CStr(drCategoria("Descripcion"))
        tbImagen.Text = CStr(drCategoria("Imagen"))
        chkVisible.Checked = CBool(drCategoria("Visible"))

        ddlTipoContenido.SelectedValue = CStr(drCategoria("IdTipoContenido"))
    End Sub

    Private Property IdContenido() As Integer
        Get
            Return CInt(ViewState("__IdContenido"))
        End Get
        Set(ByVal value As Integer)
            ViewState("__IdContenido") = value
        End Set
    End Property

    Private Sub btnRegresar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRegresar.Click
        Response.Redirect("~/Admin/lst_contenidos.aspx", True)
    End Sub

    Private Sub btnGuardar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        If Not IsValid Then
            Return
        End If

        Try

            Dim daoContenido As ContenidoDAO = New ContenidoDAO()

            daoContenido.UpdContenido(CType(ddlTipoContenido.SelectedValue, ContenidoDAO.TipoContenido), _
                                      tbNombre.Text, _
                                      tbDescripcion.Text, _
                                      tbImagen.Text, _
                                      0, _
                                      chkVisible.Checked, _
                                      IdContenido)

            Response.Redirect("~/Admin/lst_contenidos.aspx", True)
        Catch ex As Exception
            If Log.IsErrorEnabled Then
                Log.Error(ex.ToString)
            End If

            AddErrorMessage("Hubo un problema al procesar el registro")
        End Try
    End Sub


End Class