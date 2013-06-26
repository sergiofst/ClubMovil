
Imports System.IO
Imports ClubMovil.Data

Public Class BasePage
    Inherits System.Web.UI.Page


    ''' <summary>
    ''' Agrega un mensaje de error al ValidationSummary
    ''' </summary>
    ''' <param name="texto"></param>
    ''' <remarks></remarks>
    Protected Sub AddErrorMessage(ByVal texto As String)
        ErrorSummary.AddError(texto, Me)
    End Sub

    ''' <summary>
    ''' Regresa la informacion del usuario activo
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetUsuario() As DataRow
        Return New UsuarioDAO().GetUsuario(Integer.Parse(User.Identity.Name))
    End Function

    ''' <summary>
    ''' Regresa el Id del usuario actual
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property IdUsuarioActual() As Integer
        Get
            Return Integer.Parse(User.Identity.Name)
        End Get
    End Property

    Protected Function JSDisableButtonPostBack(ByVal btn As Control, ByVal mensaje As String) As String
        Dim sb As New System.Text.StringBuilder()
        'sb.Append("alert($(this));")
        'sb.Append("return false;")
        sb.Append("if (typeof Page_ClientValidate == 'function') { ")
        sb.Append("if (Page_ClientValidate()) { ")
        sb.AppendFormat("if (Page_IsValid && confirm('{0}')) {{ ", mensaje)
        sb.Append("$(this).AddClass('disabled'); ")
        sb.Append("this.disabled = true;")
        'sb.Append(ClientScript.GetPostBackEventReference(btn, Nothing) & ";")
        sb.Append(" return false; ")
        sb.Append("} else { return false; } ")
        sb.Append("} ")
        sb.Append("} else { ")
        sb.Append("$(this).AddClass('disabled'); ")
        sb.Append("this.disabled = true;")
        sb.Append("alert('OK');")
        sb.Append(" return false; ")
        sb.Append("} ")
        Return sb.ToString()
    End Function
    Protected Function JSDisableButtonPostBack(ByVal btn As Control) As String
        Dim sb As New System.Text.StringBuilder()
        sb.Append("if (Page_ClientValidate()) { ")
        sb.Append("$(this).AddClass('disabled'); ")
        sb.Append("this.disabled = true; ")
        'sb.AppendLine("alert('wait'); ")
        'sb.Append(ClientScript.GetPostBackEventReference(btn, Nothing) & "; ")
        sb.Append("} ")
        Return sb.ToString()
    End Function


#Region "CompressViewState"
    Private _formatter As New ObjectStateFormatter()

    Protected Overrides Sub SavePageStateToPersistenceMedium(ByVal viewState As Object)
        Dim ms As New MemoryStream()
        _formatter.Serialize(ms, viewState)
        Dim viewStateArray As Byte() = ms.ToArray()
        ClientScript.RegisterHiddenField("__COMPRESSEDVIEWSTATE", Convert.ToBase64String(CompressViewState.Compress(viewStateArray)))
    End Sub
    Protected Overrides Function LoadPageStateFromPersistenceMedium() As Object
        Dim vsString As String = Request.Form("__COMPRESSEDVIEWSTATE")
        Dim bytes As Byte() = Convert.FromBase64String(vsString)
        bytes = CompressViewState.Decompress(bytes)
        Return _formatter.Deserialize(Convert.ToBase64String(bytes))
    End Function
#End Region

End Class
