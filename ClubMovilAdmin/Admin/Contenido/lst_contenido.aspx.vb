Imports ClubMovil.Data

Public Class lst_contenido
    Inherits BasePage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack Then
            Return
        End If

        gvDatos.DataSource = GetDatos()
        gvDatos.DataBind()
    End Sub

    Private Function GetDatos() As DataView
        Return New ContenidoDAO().ListContenido().Tables(0).DefaultView
    End Function

    Private Sub gvDatos_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gvDatos.PageIndexChanging
        gvDatos.PageIndex = e.NewPageIndex
        gvDatos.DataSource = GetDatos()
        gvDatos.DataBind()
    End Sub

    Private Sub gvDatos_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gvDatos.RowCommand
        Me.Context.Items.Add("IdContenido", e.CommandArgument)

        Dim drContenido As DataRow = New ContenidoDAO().GetContenido(CInt(e.CommandArgument))

        If e.CommandName.Equals("Editar") Then
            Server.Transfer("~/Admin/Contenido/upd_contenido.aspx", False)

        ElseIf e.CommandName.Equals("Claves") Then
            Server.Transfer("~/Admin/Contenido/lst_contenido_claves.aspx", False)

        ElseIf e.CommandName.Equals("Categorias") Then
            Server.Transfer("~/Admin/Contenido/lst_contenido_categorias.aspx", False)

        ElseIf e.CommandName.Equals("Imagenes") Then
            Server.Transfer("~/Admin/Contenido/lst_contenido_imagenes.aspx", False)

        ElseIf e.CommandName.Equals("Informacion") Then
            Server.Transfer("~/Admin/Contenido/lst_contenido_info.aspx", False)

        ElseIf e.CommandName.Equals("Archivos") Then
            If CInt(drContenido("IdTipoContenido")) = 1 Then
                Server.Transfer("~/Admin/Contenido/lst_contenido_fondos.aspx", False)
            ElseIf CInt(drContenido("IdTipoContenido")) = 2 Then
                Server.Transfer("~/Admin/Contenido/lst_contenido_tonos.aspx", False)
            End If

        ElseIf e.CommandName.Equals("Eliminar") Then
            Dim dumy As Integer = New ContenidoDAO().DelContenido(CInt(e.CommandArgument))
            gvDatos.PageIndex = 0
            gvDatos.DataSource = GetDatos()
            gvDatos.DataBind()
        End If
    End Sub

    Private Sub gvDatos_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvDatos.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim IdContenido As String = CStr(DataBinder.Eval(e.Row.DataItem, "IdContenido"))
            CType(e.Row.FindControl("lnkEditar"), LinkButton).CommandArgument = IdContenido
            CType(e.Row.FindControl("lnkCategorias"), LinkButton).CommandArgument = IdContenido
            CType(e.Row.FindControl("lnkClaves"), LinkButton).CommandArgument = IdContenido
            CType(e.Row.FindControl("lnkArchivos"), LinkButton).CommandArgument = IdContenido
            CType(e.Row.FindControl("lnkImagenes"), LinkButton).CommandArgument = IdContenido
            CType(e.Row.FindControl("lnkEliminar"), LinkButton).CommandArgument = IdContenido
        End If
    End Sub

    Private Sub btnNuevo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        Response.Redirect("~/Admin/Contenido/add_contenido.aspx", True)
    End Sub


End Class