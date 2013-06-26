Imports NLog
Imports ClubMovil.Data

Public Class add_categoria
    Inherits BasePage

    Private Shared Log As Logger = LogManager.GetCurrentClassLogger()

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack Then
            Return
        End If

        ddlPadre.DataSource = New ContenidoDAO().ListCategorias()
        ddlPadre.DataBind()

    End Sub

    Private Sub btnRegresar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRegresar.Click
        Response.Redirect("~/Admin/lst_categorias.aspx", True)
    End Sub

    Private Sub btnGuardar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        If Not IsValid Then
            Return
        End If

        Try
            Dim daoContenido As ContenidoDAO = New ContenidoDAO()

            daoContenido.AddCategoria(tbNombre.Text, _
                                        tbDescripcion.Text, _
                                        CInt(ddlPadre.SelectedValue))

            Response.Redirect("~/Admin/lst_categorias.aspx", True)
        Catch ex As Exception
            If Log.IsErrorEnabled Then
                Log.Error(ex.ToString)
            End If

            AddErrorMessage("Hubo un problema al procesar el registro")
        End Try
    End Sub

End Class