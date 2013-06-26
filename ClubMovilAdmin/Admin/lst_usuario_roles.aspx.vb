Imports NLog
Imports ClubMovil.Data

Public Class lst_usuario_roles
    Inherits BasePage

    Private Shared Log As Logger = LogManager.GetCurrentClassLogger()

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack Then
            Return
        End If

        If String.IsNullOrEmpty(CStr(Context.Items("IdUsuario"))) Then
            Throw New ArgumentNullException("IdUsuario")
        End If

        gvDatos.DataSource = GetDatos()
        gvDatos.DataBind()

        gvRoles.DataSource = GetDatos()
        gvRoles.DataBind()
    End Sub

    Public Property CurrIdUsuario() As Integer
        Get
            Return CInt(ViewState("__currIdUsuario"))
        End Get
        Set(ByVal value As Integer)
            ViewState("__currIdUsuario") = value
        End Set
    End Property

    Private Function GetDatos() As DataView
        Dim dsResult As DataView = New UsuarioDAO().ListRolesUsuario(CurrIdUsuario).Tables(0).DefaultView

        Return dsResult
    End Function

    Private Function GetRoles() As DataView
        Dim dsResult As DataView = New UsuarioDAO().ListRoles().Tables(0).DefaultView
        Return dsResult
    End Function

    Private Sub gvIssuers_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gvDatos.PageIndexChanging
        gvDatos.PageIndex = e.NewPageIndex
        gvDatos.DataSource = GetDatos()
        gvDatos.DataBind()
    End Sub

    Private Sub gvRoles_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gvRoles.PageIndexChanging
        gvRoles.PageIndex = e.NewPageIndex
        gvRoles.DataSource = GetRoles()
        gvRoles.DataBind()
    End Sub

    Private Sub gvIssuers_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gvDatos.RowCommand
        If e.CommandName.Equals("Eliminar") Then
            Dim dumy As Integer = New UsuarioDAO().DelUsuarioRol(CInt(e.CommandArgument))
        End If
    End Sub

    Private Sub gvRoles_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gvRoles.RowCommand
        If e.CommandName.Equals("Agregar") Then
            Dim dumy As Integer = New UsuarioDAO().AddUsuarioRol(CInt(e.CommandArgument), CurrIdUsuario)

            gvRoles.PageIndex = 0
            gvRoles.DataSource = GetRoles()
            gvRoles.DataBind()
        End If
    End Sub

    Private Sub gvDatos_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvDatos.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim IdUsuarioRol As String = CStr(DataBinder.Eval(e.Row.DataItem, "IdUsuarioRol"))
            CType(e.Row.FindControl("lnkEliminar"), LinkButton).CommandArgument = IdUsuarioRol
        End If
    End Sub

    Private Sub gvRoles_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvRoles.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim IdRol As String = CStr(DataBinder.Eval(e.Row.DataItem, "IdRol"))
            CType(e.Row.FindControl("lnkAgregar"), LinkButton).CommandArgument = IdRol
        End If
    End Sub

End Class