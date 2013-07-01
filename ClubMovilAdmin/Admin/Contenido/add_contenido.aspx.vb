Imports NLog
Imports ClubMovil.Data

Public Class add_contenido
    Inherits BasePage

    Private Shared Log As Logger = LogManager.GetCurrentClassLogger()

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack Then
            Return
        End If
    End Sub

    Private Sub btnRegresar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRegresar.Click
        Response.Redirect("~/Admin/lst_contenidos.aspx", True)
    End Sub

    Private Sub btnGuardar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        If Not IsValid Then
            Return
        End If

        Try
            Dim daoContenido As ContenidoDAO = New ContenidoDAO()

            daoContenido.AddContenido(CType(ddlTipoContenido.SelectedValue, ContenidoDAO.TipoContenido), _
                                      tbNombre.Text, _
                                        tbDescripcion.Text, _
                                        tbImagen.Text, _
                                        0, _
                                        chkVisible.Checked)

            Response.Redirect("~/Admin/lst_contenidos.aspx", True)
        Catch ex As Exception
            If Log.IsErrorEnabled Then
                Log.Error(ex.ToString)
            End If

            AddErrorMessage("Hubo un problema al procesar el registro")
        End Try
    End Sub

End Class