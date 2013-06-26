Imports System.Runtime.CompilerServices

Namespace HtmlHelpers
    Public Module MenuHelper

        <Extension()> _
        Public Function MenuLink(ByVal helper As HtmlHelper, ByVal url As String, ByVal name As String, ByVal imageUrl As String) As MvcHtmlString
            Dim urlHelper As UrlHelper = New UrlHelper(helper.ViewContext.RequestContext)
            Dim linkTag As TagBuilder = New TagBuilder("a")

            Dim imgTag As TagBuilder = New TagBuilder("img")
            imgTag.MergeAttribute("src", BaseHelper.ResolveContentUrl(helper, imageUrl))

            linkTag.MergeAttribute("href", urlHelper.Content(url))
            linkTag.InnerHtml = imgTag.ToString(TagRenderMode.Normal) & name

            Return MvcHtmlString.Create(linkTag.ToString(TagRenderMode.Normal))
        End Function

    End Module
End Namespace