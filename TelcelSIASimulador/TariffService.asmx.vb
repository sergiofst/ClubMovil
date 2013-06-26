Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.ComponentModel

' To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line.
' <System.Web.Script.Services.ScriptService()> _
<System.Web.Services.WebService(Namespace:="http://189.254.103.147:8088/sia/services/Tariff")> _
<System.Web.Services.WebServiceBinding(Name:="TariffSoapBinding", Namespace:="http://189.254.103.147:8088/sia/services/Tariff")> _
<ToolboxItem(False)> _
Public Class TariffService
    Inherits BaseTariffService

    <WebMethod()> _
    Public Overrides Function getTariff(ByVal userId As String, ByVal passwd As String, ByVal srsRatingId As Long) As String
        Return "Hola"
    End Function

    <WebMethod()> _
    Public Overrides Function getTariffInt(ByVal userId As String, ByVal passwd As String, ByVal srsRatingId As Integer) As String
        Return "Hola"
    End Function

End Class