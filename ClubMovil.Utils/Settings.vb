Imports System.ComponentModel
Imports System.Configuration

Namespace ResponsiveImages
    Public Class Settings
        Inherits ConfigurationSection

        Private Shared m_resolutionBreakPoints As ConfigurationProperty
        Private Shared browserCacheTimeInSeconds As ConfigurationProperty
        Private Shared m_cookieKey As ConfigurationProperty

        Public Sub New()
            m_resolutionBreakPoints = New ConfigurationProperty("resolutionBreakPoints", GetType(Integer()), New Integer() {1382, 992, 768, 480}, New CommaDelimitedStringCollectionConverter(), New DefaultValidator(), ConfigurationPropertyOptions.None)

            browserCacheTimeInSeconds = New ConfigurationProperty("browserCacheTimeInSeconds", GetType(Integer), 604800, New Int32Converter(), New IntegerValidator(0, Integer.MaxValue), ConfigurationPropertyOptions.None)
            m_cookieKey = New ConfigurationProperty("cookieKey", GetType(String), "resolution", ConfigurationPropertyOptions.None)
        End Sub

        Public ReadOnly Property ResolutionBreakPoints() As Integer()
            Get
                Return DirectCast(MyBase.Item(m_resolutionBreakPoints), Integer())
            End Get
        End Property

        Public ReadOnly Property BrowserCacheTime() As Integer
            Get
                Return CInt(MyBase.Item(browserCacheTimeInSeconds))
            End Get
        End Property

        Public ReadOnly Property CookieKey() As String
            Get
                Return DirectCast(MyBase.Item(m_cookieKey), String)
            End Get
        End Property

    End Class
End Namespace
