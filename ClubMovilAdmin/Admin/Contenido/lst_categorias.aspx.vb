Imports ClubMovil.Data

Public Class lst_categorias
    Inherits BasePage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack Then
            Return
        End If

        gvCategorias.DataSource = GetDatos()
        gvCategorias.DataBind()
    End Sub

    Private Function GetDatos() As DataView
        Return New ContenidoDAO().ListCategorias().Tables(0).DefaultView
    End Function

    Private Sub gvIssuers_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gvCategorias.PageIndexChanging
        gvCategorias.PageIndex = e.NewPageIndex
        gvCategorias.DataSource = GetDatos()
        gvCategorias.DataBind()
    End Sub

    Private Sub gvIssuers_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gvCategorias.RowCommand
        Me.Context.Items.Add("IdCategoria", e.CommandArgument)
        If e.CommandName.Equals("Editar") Then
            Server.Transfer("~/Admin/upd_categoria.aspx", False)
        ElseIf e.CommandName.Equals("Eliminar") Then
            Dim dumy As Integer = New ContenidoDAO().DelCategoria(CInt(e.CommandArgument))
            gvCategorias.DataSource = GetDatos()
            gvCategorias.DataBind()
        End If
    End Sub

    Private Sub gvIssuers_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvCategorias.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim IdCategoria As String = CStr(DataBinder.Eval(e.Row.DataItem, "IdCategoria"))
            CType(e.Row.FindControl("lnkEditar"), LinkButton).CommandArgument = IdCategoria
            CType(e.Row.FindControl("lnkEliminar"), LinkButton).CommandArgument = IdCategoria
        End If
    End Sub

    Private Sub btnNuevo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        Response.Redirect("~/Admin/add_categoria.aspx", True)
    End Sub

End Class