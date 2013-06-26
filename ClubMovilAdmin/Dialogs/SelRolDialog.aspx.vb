Imports ClubMovil.Data

Public Class SelRolDialog
    Inherits BasePage


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack Then
            Return
        End If

        gvData.DataSource = GetDatos()
        gvData.DataBind()
    End Sub

    Private Sub gvData_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvData.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim btn As Button = CType(e.Row.FindControl("btnSeleccionar"), Button)
            btn.Attributes.Add("_id", CStr(DataBinder.Eval(e.Row.DataItem, "IdRol")))
            btn.Attributes.Add("_data", CStr(DataBinder.Eval(e.Row.DataItem, "Nombre")))

            CType(e.Row.FindControl("litNombre"), Literal).Text = CStr(DataBinder.Eval(e.Row.DataItem, "Nombre"))
            CType(e.Row.FindControl("litDescripcion"), Literal).Text = CStr(DataBinder.Eval(e.Row.DataItem, "Descripcion"))
        End If
    End Sub

    Private Function GetDatos() As DataView
        Dim dsResult As DataView = New UsuarioDAO().ListRoles().Tables(0).DefaultView

        Return dsResult
    End Function

    Private Sub gvData_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gvData.PageIndexChanging
        gvData.PageIndex = e.NewPageIndex
        gvData.DataSource = GetDatos()
        gvData.DataBind()
    End Sub


End Class