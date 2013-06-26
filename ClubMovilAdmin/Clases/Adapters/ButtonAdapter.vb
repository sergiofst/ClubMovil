Imports System.Web.UI.WebControls.Adapters

Public Class ButtonAdapter
    Inherits WebControlAdapter

    Protected Overrides Sub Render(ByVal writer As System.Web.UI.HtmlTextWriter)
        Dim btnControl As Button = CType(Control, Button)

        writer.WriteBeginTag("button")
        writer.WriteAttribute("class", btnControl.CssClass)
        writer.WriteAttribute("type", "submit")
        writer.WriteAttribute("onclick", btnControl.OnClientClick)
        writer.Write(HtmlTextWriter.TagRightChar)
        writer.Write(btnControl.Text)
        writer.WriteEndTag("button")
    End Sub



End Class
