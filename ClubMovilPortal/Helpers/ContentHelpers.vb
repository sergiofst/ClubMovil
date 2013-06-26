Imports System.Runtime.CompilerServices

Namespace HtmlHelpers
    Public Module ContentHelpers

        <Extension()> _
        Public Function ResolveContentUrl(ByVal helper As HtmlHelper, ByVal url As String) As String

            Return UrlHelper.GenerateContentUrl("~/Content/" & MobileCapableWebFormViewEngine.GetBaseView(helper.ViewContext.Controller.ControllerContext) & "/" & url, _
                                                helper.ViewContext.HttpContext)
        End Function

    End Module
End Namespace

