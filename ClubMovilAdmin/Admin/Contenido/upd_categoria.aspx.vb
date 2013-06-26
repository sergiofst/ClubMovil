Imports NLog
Imports ClubMovil.Data

Public Class upd_categoria
    Inherits BasePage

    Private Shared Log As Logger = LogManager.GetCurrentClassLogger()

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack Then
            Return
        End If

        If String.IsNullOrEmpty(CStr(Context.Items("IdCategoria"))) Then
            Throw New ArgumentNullException("IdCategoria")
        End If

        IdCategoria = CInt(Context.Items("IdCategoria"))

        Dim daoContenido As ContenidoDAO = New ContenidoDAO()

        Dim drCategoria As DataRow = daoContenido.GetCategoria(IdCategoria)

        litIdCategoria.Text = CStr(drCategoria("IdCategoria"))
        tbNombre.Text = CStr(drCategoria("Nombre"))
        tbDescripcion.Text = CStr(drCategoria("Descripcion"))

        ddlPadre.DataSource = daoContenido.ListCategorias()
        ddlPadre.DataBind()

        ddlPadre.SelectedValue = CStr(drCategoria("IdCategoriaPadre"))
    End Sub

    Private Property IdCategoria() As Integer
        Get
            Return CInt(ViewState("__IdCategoria"))
        End Get
        Set(ByVal value As Integer)
            ViewState("__IdCategoria") = value
        End Set
    End Property

    Private Sub btnRegresar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRegresar.Click
        Response.Redirect("~/Admin/lst_categorias.aspx", True)
    End Sub

    Private Sub btnGuardar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        If Not IsValid Then
            Return
        End If

        Try

            Dim daoContenido As ContenidoDAO = New ContenidoDAO()

            daoContenido.UpdCategoria(tbNombre.Text, _
                                        tbDescripcion.Text, _
                                        CInt(ddlPadre.SelectedValue),
                                        IdCategoria)

            Response.Redirect("~/Admin/lst_categorias.aspx", True)
        Catch ex As Exception
            If Log.IsErrorEnabled Then
                Log.Error(ex.ToString)
            End If

            AddErrorMessage("Hubo un problema al procesar el registro")
        End Try
    End Sub

End Class