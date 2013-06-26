<ValidationPropertyAttribute("Value")> _
Partial Public Class PopupButton
    Inherits System.Web.UI.UserControl
    Implements IPostBackEventHandler

    Public Event OnChange As EventHandler

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack Then
            Return
        End If

        Dim callScript As String = "{0}_popup('{1}?{2}')"
        callScript = String.Format(callScript, Me.ClientID, Me.ResolveUrl(Url), HashtableToQueryString(Me.Parameters))
        button.Attributes.Add("onclick", callScript)
        button.Attributes.Add("class", CssClass)
        button.Value = Text

    End Sub

    Private Function HashtableToQueryString(ByVal hash As Hashtable) As String
        Dim result As List(Of String) = New List(Of String)
        For Each key As String In hash.Keys
            result.Add(key & "=" & Server.HtmlEncode(CStr(hash(key))))
        Next
        ' Para evitar el cache
        result.Add("anticache=" & Date.Now.ToOADate)
        Return String.Join("&", result.ToArray)
    End Function

    Public Property Value() As String
        Get
            Return ValueField.Text
        End Get
        Set(ByVal value As String)
            ValueField.Text = value
        End Set
    End Property
    Public ReadOnly Property Data() As String
        Get
            Return DataField.Text
        End Get
    End Property
    Public Property Text() As String
        Get
            Return CStr(ViewState("Text"))
        End Get
        Set(ByVal value As String)
            ViewState("Text") = value
        End Set
    End Property

    Public Property Url() As String
        Get
            Return CStr(ViewState("__Url"))
        End Get
        Set(ByVal value As String)
            ViewState("__Url") = value
        End Set
    End Property

    Public Property CssClass() As String
        Get
            Return CStr(ViewState("CssClass"))
        End Get
        Set(ByVal value As String)
            ViewState("CssClass") = value
        End Set
    End Property

    Public ReadOnly Property Parameters() As Hashtable
        Get
            Dim params As Hashtable = CType(ViewState("__Parameters"), Hashtable)
            If params Is Nothing Then
                params = New Hashtable
                ViewState("__Parameters") = params
            End If
            Return params
        End Get
    End Property

    Public Sub RaisePostBackEvent(ByVal eventArgument As String) Implements System.Web.UI.IPostBackEventHandler.RaisePostBackEvent
        If eventArgument = "on_change" Then
            RaiseEvent OnChange(Me, Nothing)
        End If
    End Sub

End Class