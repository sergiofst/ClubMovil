Public Class ConnectionStringHelper

    Public Shared Function GetConnectionString(ByVal name As String) As ConnectionStringSettings
        Return ConfigurationManager.ConnectionStrings(name)
    End Function

End Class
