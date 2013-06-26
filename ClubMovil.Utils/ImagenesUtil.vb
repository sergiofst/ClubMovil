Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.Drawing.Drawing2D

Public Class ImagenesUtil

    ''' <summary>
    ''' Resizes and rotates an image, keeping the original aspect ratio. Does not dispose the original
    ''' Image instance.
    ''' </summary>
    ''' <param name="image">Image instance</param>
    ''' <param name="width">desired width</param>
    ''' <param name="height">desired height</param>
    ''' <param name="rotateFlipType">desired RotateFlipType</param>
    ''' <returns>new resized/rotated Image instance</returns>
    Public Shared Function Resize(ByVal image As Image, ByVal width As Integer, ByVal height As Integer, ByVal rotateFlipType As RotateFlipType) As Image
        ' clone the Image instance, since we don't want to resize the original Image instance
        Dim rotatedImage = TryCast(image.Clone(), Image)
        rotatedImage.RotateFlip(rotateFlipType)
        Dim newSize = CalculateResizedDimensions(rotatedImage, width, height)

        Dim resizedImage = New Bitmap(newSize.Width, newSize.Height, PixelFormat.Format24bppRgb)
        resizedImage.SetResolution(72, 72)

        Using graphics__1 = Graphics.FromImage(resizedImage)
            ' set parameters to create a high-quality thumbnail
            graphics__1.InterpolationMode = InterpolationMode.HighQualityBicubic
            graphics__1.SmoothingMode = SmoothingMode.AntiAlias
            graphics__1.CompositingQuality = CompositingQuality.HighQuality
            graphics__1.PixelOffsetMode = PixelOffsetMode.HighQuality

            ' use an image attribute in order to remove the black/gray border around image after resize
            ' (most obvious on white images), see this post for more information:
            ' http://www.codeproject.com/KB/GDI-plus/imgresizoutperfgdiplus.aspx
            Using attribute = New ImageAttributes()
                attribute.SetWrapMode(WrapMode.TileFlipXY)

                ' draws the resized image to the bitmap
                graphics__1.DrawImage(rotatedImage, New Rectangle(New Point(0, 0), newSize), 0, 0, rotatedImage.Width, rotatedImage.Height, _
                 GraphicsUnit.Pixel, attribute)
            End Using
        End Using

        Return resizedImage
    End Function

    ''' <summary>
    ''' Calculates resized dimensions for an image, preserving the aspect ratio.
    ''' </summary>
    ''' <param name="image">Image instance</param>
    ''' <param name="desiredWidth">desired width</param>
    ''' <param name="desiredHeight">desired height</param>
    ''' <returns>Size instance with the resized dimensions</returns>
    Private Shared Function CalculateResizedDimensions(ByVal image As Image, ByVal desiredWidth As Integer, ByVal desiredHeight As Integer) As Size
        Dim widthScale = CDbl(desiredWidth) / image.Width
        Dim heightScale = CDbl(desiredHeight) / image.Height

        ' scale to whichever ratio is smaller, this works for both scaling up and scaling down
        Dim scale = If(widthScale < heightScale, widthScale, heightScale)

        Return New Size() With { _
         .Width = CInt(scale * image.Width), _
         .Height = CInt(scale * image.Height) _
        }
    End Function

End Class
