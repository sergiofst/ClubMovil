Imports ClubMovil.Data
Imports NLog

Public Class lst_suscripciones
    Inherits BasePage

    Private Shared Log As Logger = LogManager.GetCurrentClassLogger()

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack Then
            Return
        End If

        gvDatos.DataSource = GetDatos()
        gvDatos.DataBind()
    End Sub

    Private Function GetDatos() As DataView
        Return New SuscripcionDAO().ListSuscripciones().Tables(0).DefaultView
    End Function

    Private Sub gvDatos_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gvDatos.PageIndexChanging
        gvDatos.PageIndex = e.NewPageIndex
        gvDatos.DataSource = GetDatos()
        gvDatos.DataBind()
    End Sub

    Private Sub gvDatos_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gvDatos.RowCommand
        Me.Context.Items.Add("IdSuscripcion", e.CommandArgument)
        If e.CommandName.Equals("Editar") Then
            Server.Transfer("~/Admin/Cliente/upd_suscripcion.aspx", False)
        End If
    End Sub

    Private Sub gvDatos_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvDatos.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim idSuscripcion As String = CStr(DataBinder.Eval(e.Row.DataItem, "IdSuscripcion"))
            CType(e.Row.FindControl("btnEditar"), Button).CommandArgument = idSuscripcion
        End If
    End Sub

End Class