Imports System.Runtime.CompilerServices

Namespace HtmlHelpers
    Public Module ProductHelper

        <Extension()> _
        Public Function ProductImageUrl(ByVal helper As HtmlHelper, ByVal src As String) As String
            Return UrlHelper.GenerateContentUrl(String.Concat("~/Content/", MobileCapableWebFormViewEngine.GetBaseView(helper.ViewContext.Controller.ControllerContext), "/", src), _
                                                helper.ViewContext.HttpContext)
        End Function

        <Extension()> _
        Public Function ProductLink(ByVal helper As HtmlHelper, ByVal drProduct As DataRow) As MvcHtmlString
            Dim routeVal As RouteValueDictionary = New RouteValueDictionary
            routeVal.Add("controller", CStr(drProduct("CategoryController")))
            routeVal.Add("action", "Product")
            routeVal.Add("id", CInt(drProduct("IdProduct")))

            Dim urlHelper As UrlHelper = New UrlHelper(helper.ViewContext.RequestContext)
            Dim linkTag As TagBuilder = New TagBuilder("a")

            linkTag.MergeAttribute("href", urlHelper.RouteUrl(routeVal))
            linkTag.InnerHtml = CStr(drProduct("Name"))

            Return MvcHtmlString.Create(linkTag.ToString(TagRenderMode.Normal))
        End Function

    End Module
End Namespace

