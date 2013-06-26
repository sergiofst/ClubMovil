Imports System.Runtime.CompilerServices

Namespace HtmlHelpers
    Public Module ProductHelper

        <Extension()> _
        Public Function ProductPreviewLink(ByVal helper As HtmlHelper, ByVal idContenido As Integer, ByVal name As String, ByVal imageUrl As String) As MvcHtmlString
            Dim routeVal As RouteValueDictionary = New RouteValueDictionary
            routeVal.Add("controller", "Contenido")
            routeVal.Add("action", "Contenido")
            routeVal.Add("id", idContenido)

            Dim urlHelper As UrlHelper = New UrlHelper(helper.ViewContext.RequestContext)
            Dim linkTag As TagBuilder = New TagBuilder("a")

            Dim imgTag As TagBuilder = New TagBuilder("img")
            imgTag.MergeAttribute("src", BaseHelper.ResolveContentUrl(helper, imageUrl))

            linkTag.MergeAttribute("href", urlHelper.RouteUrl(routeVal))
            linkTag.InnerHtml = imgTag.ToString(TagRenderMode.Normal) & name

            Return MvcHtmlString.Create(linkTag.ToString(TagRenderMode.Normal))
        End Function

        <Extension()> _
        Public Function ProductImage(ByVal helper As HtmlHelper, ByVal imageUrl As String) As MvcHtmlString
            Dim imgTag As TagBuilder = New TagBuilder("img")
            imgTag.MergeAttribute("src", BaseHelper.ResolveContentUrl(helper, imageUrl))

            Return MvcHtmlString.Create(imgTag.ToString(TagRenderMode.Normal))
        End Function

    End Module
End Namespace

