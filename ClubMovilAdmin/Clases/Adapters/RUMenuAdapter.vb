Imports System.Web.UI.WebControls.Adapters

Namespace Adapters

    Public Class RUMenuAdapter
        Inherits MenuAdapter

        Protected Overrides Sub OnInit(ByVal e As System.EventArgs)
            'MyBase.OnInit(e)
        End Sub

        Protected Overrides Sub RenderBeginTag(ByVal writer As System.Web.UI.HtmlTextWriter)
            'MyBase.RenderBeginTag(writer)
        End Sub

        Protected Overrides Sub RenderEndTag(ByVal writer As System.Web.UI.HtmlTextWriter)
            'MyBase.RenderEndTag(writer)
        End Sub

        Protected Overrides Sub RenderContents(ByVal writer As System.Web.UI.HtmlTextWriter)

            If Control.Items.Count > 0 Then
                If Control.Items(0).ChildItems.Count > 0 Then
                    BuildItems(Control.Items(0).ChildItems, True, writer)
                End If
            End If

        End Sub

        Private Sub BuildItems(ByVal items As MenuItemCollection, ByVal isRoot As Boolean, ByVal writer As HtmlTextWriter)
            If items.Count > 0 Then

                writer.WriteBeginTag("ul")

                If isRoot Then
                    writer.WriteAttribute("class", "nav")
                ElseIf Not isRoot Then
                    writer.WriteAttribute("class", "dropdown-menu")
                End If

                writer.Write(HtmlTextWriter.TagRightChar)
                writer.Indent += 1

                For Each item As MenuItem In items
                    BuildItem(item, writer)
                Next

                writer.Indent -= 1
                writer.WriteEndTag("ul")
                writer.WriteLine()

            End If
        End Sub

        Private Sub BuildItem(ByVal item As MenuItem, ByVal writer As HtmlTextWriter)
            Dim menuCtrl As Menu = CType(Control, Menu)

            If menuCtrl IsNot Nothing And item IsNot Nothing And writer IsNot Nothing Then
                If item.ChildItems Is Nothing Or item.ChildItems.Count = 0 Then
                    writer.WriteLine()
                    writer.WriteBeginTag("li")
                    writer.Write(HtmlTextWriter.TagRightChar)
                    writer.Indent += 1
                    writer.WriteBeginTag("a")
                    If item.NavigateUrl.Length > 0 Then
                        writer.WriteAttribute("href", Page.ResolveUrl(item.NavigateUrl))
                    Else
                        writer.WriteAttribute("href", "#")
                    End If
                    writer.Write(HtmlTextWriter.TagRightChar)
                    writer.Indent += 1
                    writer.Write(item.Text)
                    writer.WriteEndTag("a")

                    writer.Indent -= 1
                    writer.WriteEndTag("li")

                ElseIf item.ChildItems.Count > 0 Then
                    writer.WriteLine()
                    writer.WriteBeginTag("li")
                    writer.WriteAttribute("class", "dropdown")
                    writer.Write(HtmlTextWriter.TagRightChar)
                    writer.Indent += 1

                    writer.WriteBeginTag("a")
                    writer.WriteAttribute("class", "dropdown-toggle")
                    writer.WriteAttribute("data-toggle", "dropdown")
                    'writer.WriteAttribute("href", "#")
                    If item.NavigateUrl.Length > 0 Then
                        writer.WriteAttribute("href", Page.ResolveUrl(item.NavigateUrl))
                    Else
                        writer.WriteAttribute("href", "#")
                    End If

                    writer.Write(HtmlTextWriter.TagRightChar)
                    writer.Indent += 1
                    writer.Write(item.Text)

                    writer.WriteBeginTag("b")
                    writer.WriteAttribute("class", "caret")
                    writer.Write(HtmlTextWriter.TagRightChar)
                    writer.WriteEndTag("b")

                    writer.WriteEndTag("a")

                    BuildItems(item.ChildItems, False, writer)

                    writer.Indent -= 1
                    writer.WriteEndTag("li")


                End If


            End If
        End Sub

    End Class

End Namespace