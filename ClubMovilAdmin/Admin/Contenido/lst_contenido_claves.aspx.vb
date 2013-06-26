Imports ClubMovil.Data
Imports NLog

Public Class lst_contenido_claves
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
        Return New ContenidoDAO().ListContenidoClaves(IdContenido).Tables(0).DefaultView
    End Function

    Private Sub gvDatos_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gvDatos.PageIndexChanging
        gvDatos.PageIndex = e.NewPageIndex
        gvDatos.DataSource = GetDatos()
        gvDatos.DataBind()
    End Sub

    Private Sub gvDatos_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gvDatos.RowCommand
        Me.Context.Items.Add("IdContenidoClave", e.CommandArgument)
        If e.CommandName.Equals("Eliminar") Then
            Dim dumy As Integer = New ContenidoDAO().DelContenidoClave(CInt(e.CommandArgument))
            gvDatos.PageIndex = 0
            gvDatos.DataSource = GetDatos()
            gvDatos.DataBind()
        End If
    End Sub

    Private Sub gvDatos_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvDatos.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim IdContenidoClave As String = CStr(DataBinder.Eval(e.Row.DataItem, "IdContenidoClave"))
            CType(e.Row.FindControl("btnEliminar"), Button).CommandArgument = IdContenidoClave
        End If
    End Sub

    Private Sub btnAgregarClave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAgregarClave.Click
        Try
            Dim dumy As Integer = New ContenidoDAO().AddContenidoClave(IdContenido, tbNuevaClave.Text)

            gvDatos.PageIndex = 0
            gvDatos.DataSource = GetDatos()
            gvDatos.DataBind()
        Catch ex As Exception
            If Log.IsErrorEnabled Then
                Log.Error(ex.ToString())
            End If
            AddErrorMessage("Hubo un problema al procesar el registro")
        End Try
    End Sub
End Class