Imports ClubMovil.Data

Public Class ProductController
    Inherits BaseController

    Public Function Category(ByVal id As Integer) As ActionResult
        Dim daoProduct As ProductDAO = New ProductDAO()
        ViewData("Category") = daoProduct.GetCategory(id)
        ViewData("Products") = daoProduct.GetProductsByIdCategory(id)
        Return View()
    End Function

    Public Function Preview(ByVal id As Integer) As ActionResult
        ViewData("Product") = New ProductDAO().GetProduct(id)
        Return View()
    End Function

End Class
