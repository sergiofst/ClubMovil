Imports System.Collections
Imports System.Collections.Generic
Imports System.Globalization
Imports System.IO
Imports System.Linq
Imports System.Text.RegularExpressions
Imports System.Web

Namespace ResponsiveImages

    Public Class myReverserClass
        Implements IComparer
        ' Calls CaseInsensitiveComparer.Compare with the parameters reversed.
        Private Function IComparer_Compare(ByVal x As Object, ByVal y As Object) As Integer Implements IComparer.Compare
            Return (New CaseInsensitiveComparer()).Compare(y, x)
        End Function
    End Class

    Public Class ResponsiveImage

        Public Shared Function IsRecognisedFile(ByVal sourceFilename As String) As Boolean
            Dim filename = sourceFilename.Trim()
            Return (filename.EndsWith(".jpg") OrElse filename.EndsWith(".jpeg") OrElse filename.EndsWith(".png") OrElse filename.EndsWith(".gif")) AndAlso filename.StartsWith("/media/")
        End Function

        Public Shared Function GetContentType(ByVal fileExtension As String) As String
            Dim contentType = "image/jpeg"
            Select Case fileExtension.ToLower()
                Case ".png"
                    contentType = "image/png"
                    Exit Select
                Case ".gif"
                    contentType = "image/gif"
                    Exit Select
            End Select

            Return contentType
        End Function

        Public Shared Function GetBestFitResolution(ByVal browserResolution As String, ByVal defaultWidth As Integer, ByVal resolutions As Integer()) As Integer
            Dim clientWidth = defaultWidth
            ' This should be the highest resolution
            If Not [String].IsNullOrEmpty(browserResolution.Trim()) Then
                Integer.TryParse(browserResolution, clientWidth)
            End If

            Return GetBestFitResolution(clientWidth, resolutions)
        End Function

        Public Shared Function GetBestFitResolution(ByVal browserResolution As Integer, ByVal resolutions As Integer()) As Integer
            ' Sort biggest first
            Array.Sort(resolutions, New myReverserClass())

            Dim resolution As Integer = resolutions(0)

            For Each breakPoint As Object In resolutions.Where(Function(x) browserResolution <= x)
                resolution = breakPoint
            Next

            Return resolution
        End Function

        Public Shared Sub ProcessImage(ByVal context As HttpContext, ByVal settings As Settings)
            Dim filename = context.Request.Url.LocalPath.ToLower()

            ' As this will run for EVERY request we need to find out if we should process this request or not as fast as possible and bale out if need be.
            If Not IsRecognisedFile(filename) Then
                Return
            End If

            Dim browserCache = settings.BrowserCacheTime

            Try
                If Not File.Exists(context.Server.MapPath("~" & filename)) Then
                    context.Response.StatusCode = 404
                    context.Response.Status = "404 File not found"
                    context.Response.[End]()
                End If

                context.Response.ContentType = GetContentType(Path.GetExtension(filename))

                ' Cache controls, ImageGen will add some too
                context.Response.AddHeader("Cache-Control", "public, max-age=" & Convert.ToString(browserCache))
                context.Response.Expires = browserCache

                ' Get the original image size
                Dim resolutionStr = If(context.Request.Cookies(settings.CookieKey) IsNot Nothing, context.Request.Cookies(settings.CookieKey).Value.Trim(), "")

                Dim bestFitResolution = GetBestFitResolution(resolutionStr, settings.ResolutionBreakPoints.Max(), settings.ResolutionBreakPoints)

                ' Constrain = Don't stretch our image
                ' AllowUpSizing = Only shrink if we need it, don't enlarge
                ' Image = the relative url to the image
                ' Width = The width we want to use
                Dim imageGenUrl = [String].Format("~/ImageGen.ashx?Image={0}&Width={1}&{2}", filename, bestFitResolution.ToString(CultureInfo.InvariantCulture), context.Request.QueryString)
                context.Response.AddHeader("ImageGenUrl", imageGenUrl)
                context.RewritePath(imageGenUrl)
            Catch exc As Exception
                context.Response.StatusCode = 500
                context.Response.StatusDescription = "Server Error"
                context.Response.Output.Write(exc.Message)
                context.Response.[End]()
            End Try
        End Sub
    End Class
End Namespace

