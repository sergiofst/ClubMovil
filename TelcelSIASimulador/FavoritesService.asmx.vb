Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.ComponentModel

<System.Web.Services.WebService(Namespace:="http://189.254.103.147:8088/sia/services/Favorites")> _
<System.Web.Services.WebServiceBinding(Name:="FavoritesSoapBinding", [Namespace]:="http://189.254.103.147:8088/sia/services/Favorites")> _
<ToolboxItem(False)> _
Public Class FavoritesService
    Inherits BaseFavoritesService

    <WebMethod(), SoapRpcMethodAttribute("", RequestNamespace:="http://webservice.sia.sm.com", ResponseNamespace:="http://189.254.103.147:8088/sia/services/Favorites")> _
    Public Overrides Function askFav(ByVal userId As String, ByVal passwd As String, ByVal msisdn As String, ByVal url As String, ByVal title As String) As String
        FavoritosManager.GetInstance().AddFavorito(New Favorito With {.Telefono = msisdn, _
                                                                      .Titulo = title, _
                                                                      .URL = url, _
                                                                      .Estatus = Favorito.FavoritoEstatus.Inactivo})
        Return "0|OK"
    End Function

    <WebMethod()> _
    Public Sub delFav(ByVal msisdn As String)
        FavoritosManager.GetInstance().DelFavorito(msisdn)
    End Sub

    <WebMethod()> _
    Public Sub ClearFav()
        FavoritosManager.GetInstance().ClearFavoritos()
    End Sub

End Class