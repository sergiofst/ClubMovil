Imports ClubMovil.Data
Imports NLog
Imports ClubMovil.Utils


Public Class lst_contenido_imagenes
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

        rptImagenes.DataSource = GetDatos()
        rptImagenes.DataBind()
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
        Return New ContenidoDAO().ListContenidoImagenes(IdContenido).Tables(0).DefaultView
    End Function

    Private Sub btnAgregarImagen_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAgregarImagen.Click
        If Not IsValid Then
            Return
        End If

        Try
            If fuImagen.HasFile Then
                Dim newFileName As String = ContenidoImagenUtils.GetNewFileName(fuImagen.FileName)
                Dim newPath As String = ContenidoImagenUtils.ResolveFileName(newFileName)

                fuImagen.SaveAs(newPath)

                Dim dumy As Integer = New ContenidoDAO().AddContenidoImagen(IdContenido, newFileName)

                rptImagenes.DataSource = GetDatos()
                rptImagenes.DataBind()
            End If

        Catch ex As Exception
            If Log.IsErrorEnabled Then
                Log.Error(ex.ToString())
            End If
            AddErrorMessage("Hubo un problema al procesar el registro")
        End Try
    End Sub

    Private Sub rptImagenes_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.RepeaterCommandEventArgs) Handles rptImagenes.ItemCommand
        Me.Context.Items.Add("IdContenidoImagen", e.CommandArgument)
        If e.CommandName.Equals("Eliminar") Then
            Dim dumy As Integer = New ContenidoDAO().DelContenidoImagen(CInt(e.CommandArgument))
            rptImagenes.DataSource = GetDatos()
            rptImagenes.DataBind()
        End If
    End Sub

    Private Sub rptImagenes_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.RepeaterItemEventArgs) Handles rptImagenes.ItemDataBound
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            Dim idContenidoImagen As String = CStr(DataBinder.Eval(e.Item.DataItem, "IdContenidoImagen"))
            Dim fileName As String = CStr(DataBinder.Eval(e.Item.DataItem, "FileName"))
            CType(e.Item.FindControl("btnEliminar"), Button).CommandArgument = idContenidoImagen
            CType(e.Item.FindControl("imgImagen"), Image).ImageUrl = "~/Handlers/ContenidoImagen.ashx?id=" & fileName

        End If
    End Sub


End Class