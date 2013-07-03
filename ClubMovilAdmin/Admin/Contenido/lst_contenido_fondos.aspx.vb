Imports ClubMovil.Data
Imports NLog
Imports ClubMovil.Utils
Imports System.IO

Public Class lst_contenido_fondos
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

        ddlAnchoImagen.DataSource = New PropiedadDAO().ListPropiedades("ContenidoFondo.AnchoImagenes")
        ddlAnchoImagen.DataBind()

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
        Return New ContenidoFondoDAO().ListContenidoFondo(IdContenido).Tables(0).DefaultView
    End Function

    Private Sub gvDatos_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gvDatos.PageIndexChanging
        gvDatos.PageIndex = e.NewPageIndex
        gvDatos.DataSource = GetDatos()
        gvDatos.DataBind()
    End Sub

    Private Sub gvDatos_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gvDatos.RowCommand
        Me.Context.Items.Add("IdContenidoFondo", e.CommandArgument)
        If e.CommandName.Equals("Eliminar") Then
            Dim dumy As Integer = New ContenidoFondoDAO().DelContenidoFondo(CInt(e.CommandArgument))
            gvDatos.PageIndex = 0
            gvDatos.DataSource = GetDatos()
            gvDatos.DataBind()
        End If
    End Sub

    Private Sub gvDatos_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvDatos.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim IdContenidoFondo As String = CStr(DataBinder.Eval(e.Row.DataItem, "IdContenidoFondo"))
            CType(e.Row.FindControl("btnEliminar"), Button).CommandArgument = IdContenidoFondo
            CType(e.Row.FindControl("imgArchivo"), Image).ImageUrl = "~/Handlers/ContenidoFondo.ashx?id=" & CStr(DataBinder.Eval(e.Row.DataItem, "Archivo"))
        End If
    End Sub

    Private Sub btnAgregar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAgregar.Click
        If Not IsValid Then
            Return
        End If

        Try
            If fuArchivo.HasFile Then
                Dim archivoRandom As String = ContenidoUtils.GetRandomFileName(fuArchivo.FileName)
                Dim contenidoFondoDir As String = New PropiedadDAO().GetPropiedad("ContenidoFondo.Dir")

                Dim archivoPath As String = Path.Combine(contenidoFondoDir, archivoRandom)
                fuArchivo.SaveAs(archivoPath)

                Dim dumy As Integer = New ContenidoFondoDAO().AddContenidoFondo(IdContenido, _
                                                                                CInt(ddlAnchoImagen.SelectedValue), _
                                                                                archivoRandom)

                gvDatos.PageIndex = 0
                gvDatos.DataSource = GetDatos()
                gvDatos.DataBind()
            End If

        Catch ex As Exception
            If Log.IsErrorEnabled Then
                Log.Error(ex.ToString())
            End If
            AddErrorMessage("Hubo un problema al procesar el registro")
        End Try
    End Sub
End Class