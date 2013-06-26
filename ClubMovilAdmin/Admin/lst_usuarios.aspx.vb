Imports ClubMovil.Data

Public Class lst_usuarios
    Inherits BasePage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack Then
            Return
        End If
    End Sub

    Private Function GetDatos() As DataView
        Return New UsuarioDAO().ListUsuarios().Tables(0).DefaultView
    End Function

    Private Sub gvDatos_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gvDatos.PageIndexChanging
        gvDatos.PageIndex = e.NewPageIndex
        gvDatos.DataSource = GetDatos()
        gvDatos.DataBind()
    End Sub

    Private Sub gvDatos_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gvDatos.RowCommand
        Me.Context.Items.Add("IdUsuario", e.CommandArgument)
        If e.CommandName.Equals("Editar") Then
            Server.Transfer("~/Admin/upd_usuario.aspx", False)
        ElseIf e.CommandName.Equals("Password") Then
            Server.Transfer("~/Admin/upd_usuario_pass.aspx", False)
        ElseIf e.CommandName.Equals("Roles") Then
            Server.Transfer("~/Admin/lst_usuario_roles.aspx", False)
        End If
    End Sub

    Private Sub gvDatos_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvDatos.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim idUsuario As String = CStr(DataBinder.Eval(e.Row.DataItem, "IdUsuario"))
            CType(e.Row.FindControl("lnkEditar"), LinkButton).CommandArgument = idUsuario
            CType(e.Row.FindControl("lnkPassword"), LinkButton).CommandArgument = idUsuario
            CType(e.Row.FindControl("lnkRoles"), LinkButton).CommandArgument = idUsuario
        End If
    End Sub

End Class