Public Class BasePage
    Inherits System.Web.UI.Page

    Public Function GetMSISDN() As String
        Return Me.Request.Headers("msisdn")
    End Function

End Class
