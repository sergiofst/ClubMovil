
Imports NLog
Imports ClubMovil.Data

Public Class upd_suscripcion
    Inherits BasePage

    Private Shared Log As Logger = LogManager.GetCurrentClassLogger()

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack Then
            Return
        End If

        If String.IsNullOrEmpty(CStr(Context.Items("IdSuscripcion"))) Then
            Throw New ArgumentNullException("IdSuscripcion")
        End If

        IdSuscripcion = CInt(Context.Items("IdSuscripcion"))

        Dim daoSuscripcion As SuscripcionDAO = New SuscripcionDAO()

        Dim drSuscripcion As DataRow = daoSuscripcion.GetSuscripcion(IdSuscripcion)

        litIdSuscripcion.Text = CStr(drSuscripcion("IdSuscripcion"))
        litTelefono.Text = CStr(drSuscripcion("Telefono"))
        litFechaSuscripcion.Text = CDate(drSuscripcion("FechaSuscripcion")).ToString("dd/MM/yyyy")
        litFechaRenovacion.Text = CDate(drSuscripcion("FechaRenovacion")).ToString("dd/MM/yyyy")

        ddlEstatus.SelectedValue = CStr(drSuscripcion("Estatus"))
    End Sub

    Private Property IdSuscripcion() As Integer
        Get
            Return CInt(ViewState("IdSuscripcion"))
        End Get
        Set(ByVal value As Integer)
            ViewState("IdSuscripcion") = value
        End Set
    End Property

    Private Sub btnRegresar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRegresar.Click
        Response.Redirect("~/Admin/Cliente/lst_suscripciones.aspx", True)
    End Sub

    Private Sub btnGuardar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        If Not IsValid Then
            Return
        End If

        Try

            Dim daoSuscripciones As SuscripcionDAO = New SuscripcionDAO()

            daoSuscripciones.UpdSuscripcionEstatus(CType(ddlEstatus.SelectedValue, SuscripcionDAO.Estatus), IdSuscripcion)

            Response.Redirect("~/Admin/Cliente/lst_suscripciones.aspx", True)
        Catch ex As Exception
            If Log.IsErrorEnabled Then
                Log.Error(ex.ToString)
            End If

            AddErrorMessage("Hubo un problema al procesar el registro")
        End Try
    End Sub


End Class