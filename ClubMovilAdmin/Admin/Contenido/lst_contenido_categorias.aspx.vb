Imports ClubMovil.Data
Imports NLog

Public Class lst_contenido_categorias
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

        gvDatos.DataSource = GetDatos()
        gvDatos.DataBind()

        gvCategorias.DataSource = GetDatosCategorias()
        gvCategorias.DataBind()
    End Sub

    Private Property IdContenido() As Integer
        Get
            Return CInt(ViewState("__IdContenido"))
        End Get
        Set(ByVal value As Integer)
            ViewState("__IdContenido") = value
        End Set
    End Property

    Private Function GetDatos() As DataView
        Return New ContenidoDAO().ListContenidoCategorias(IdContenido).Tables(0).DefaultView
    End Function

    Private Function GetDatosCategorias() As DataView
        Return New ContenidoDAO().ListCategorias().Tables(0).DefaultView
    End Function

    Private Sub gvDatos_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gvDatos.PageIndexChanging
        gvDatos.PageIndex = e.NewPageIndex
        gvDatos.DataSource = GetDatos()
        gvDatos.DataBind()
    End Sub

    Private Sub gvCategorias_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gvCategorias.PageIndexChanging
        gvCategorias.PageIndex = e.NewPageIndex
        gvCategorias.DataSource = GetDatosCategorias()
        gvCategorias.DataBind()
    End Sub

    Private Sub gvDatos_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gvDatos.RowCommand
        Me.Context.Items.Add("IdContenidoCategoria", e.CommandArgument)
        If e.CommandName.Equals("Eliminar") Then
            Dim dumy As Integer = New ContenidoDAO().DelContenidoCategoria(CInt(e.CommandArgument))
            gvDatos.PageIndex = 0
            gvDatos.DataSource = GetDatos()
            gvDatos.DataBind()
        End If
    End Sub

    Private Sub gvCategorias_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gvCategorias.RowCommand
        Me.Context.Items.Add("IdCategoria", e.CommandArgument)
        If e.CommandName.Equals("Agregar") Then
            Dim dumy As Integer = New ContenidoDAO().AddContenidoCategoria(IdContenido, CInt(e.CommandArgument))
            gvDatos.PageIndex = 0
            gvDatos.DataSource = GetDatos()
            gvDatos.DataBind()
        End If
    End Sub

    Private Sub gvDatos_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvDatos.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim IdContenidoCategoria As String = CStr(DataBinder.Eval(e.Row.DataItem, "IdContenidoCategoria"))
            CType(e.Row.FindControl("btnEliminar"), Button).CommandArgument = IdContenidoCategoria
        End If
    End Sub

    Private Sub gvCategorias_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvCategorias.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim IdCategoria As String = CStr(DataBinder.Eval(e.Row.DataItem, "IdCategoria"))
            CType(e.Row.FindControl("btnAgregar"), Button).CommandArgument = IdCategoria
        End If
    End Sub


End Class