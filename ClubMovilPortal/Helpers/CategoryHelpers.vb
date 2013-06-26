Imports System.Runtime.CompilerServices



Namespace HtmlHelpers
    Public Module CategoryHelpers

        <Extension()> _
        Public Function CategoryLink(ByVal helper As HtmlHelper, ByVal drCategory As DataRow) As MvcHtmlString
            Dim routeVal As RouteValueDictionary = New RouteValueDictionary
            routeVal.Add("controller", CStr(drCategory("CategoryController")))
            routeVal.Add("action", "Index")
            routeVal.Add("id", CInt(drCategory("IdCategory")))

            Dim urlHelper As UrlHelper = New UrlHelper(helper.ViewContext.RequestContext)
            Dim linkTag As TagBuilder = New TagBuilder("a")

            linkTag.MergeAttribute("href", urlHelper.RouteUrl(routeVal))
            linkTag.InnerHtml = CStr(drCategory("Name"))

            Return MvcHtmlString.Create(linkTag.ToString(TagRenderMode.Normal))
        End Function



    End Module
End Namespace

