Imports Wurfl.Aspnet.Extensions.Config
Imports Wurfl

' Note: For instructions on enabling IIS6 or IIS7 classic mode, 
' visit http://go.microsoft.com/?LinkId=9394802

Public Class MvcApplication
    Inherits System.Web.HttpApplication

    Shared Sub RegisterRoutes(ByVal routes As RouteCollection)
        routes.IgnoreRoute("{resource}.axd/{*pathInfo}")

        ' MapRoute takes the following parameters, in order:
        ' (1) Route name
        ' (2) URL with parameters
        ' (3) Parameter defaults
        routes.MapRoute( _
            "Default", _
            "{controller}/{action}/{id}", _
            New With {.controller = "Menu", .action = "Index", .id = UrlParameter.Optional} _
        )

    End Sub

    Sub Application_Start()
        AreaRegistration.RegisterAllAreas()

        RegisterRoutes(RouteTable.Routes)
        ViewEngines.Engines.Clear()
        ViewEngines.Engines.Add(New MobileCapableWebFormViewEngine())

        Dim startTime As Date = DateTime.Now
        RegisterWurfl()
        Dim endTime As Date = DateTime.Now
        WurflStartupTime = (endTime - startTime).TotalSeconds.ToString("##.##")
    End Sub

    Public Sub RegisterWurfl()
        Dim conf As ApplicationConfigurer = New ApplicationConfigurer()
        Dim wurflMan As IWURFLManager = WURFLManagerBuilder.Build(conf)
        HttpRuntime.Cache("WurflManagerKey") = wurflMan
    End Sub

    Public Shared Function GetWurflManager() As IWURFLManager
        Return CType(HttpRuntime.Cache("WurflManagerKey"), IWURFLManager)
    End Function


    Public Shared WurflStartupTime As String

End Class
