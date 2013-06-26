Namespace Controls

    Public Class IsInRoleControl
        Inherits Panel

        Protected Overrides Sub OnInit(ByVal e As System.EventArgs)
            MyBase.OnInit(e)

        End Sub

        Protected Overrides Sub OnPreRender(ByVal e As System.EventArgs)
            MyBase.OnPreRender(e)

            Me.Visible = False

            If Page.User.Identity.IsAuthenticated Then
                If Page.User.IsInRole(RoleName) Then
                    Me.Visible = True
                End If
            End If

        End Sub

        Public Overrides Sub RenderBeginTag(ByVal writer As HtmlTextWriter)
            'MyBase.RenderBeginTag(writer)
        End Sub

        Public Overrides Sub RenderEndTag(ByVal writer As System.Web.UI.HtmlTextWriter)
            'MyBase.RenderEndTag(writer)
        End Sub

        Public Property RoleName() As String
            Get
                Return CStr(ViewState("__roleName"))
            End Get
            Set(ByVal value As String)
                ViewState("__roleName") = value
            End Set
        End Property

    End Class

End Namespace

