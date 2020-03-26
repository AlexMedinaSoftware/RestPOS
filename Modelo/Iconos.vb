Module Iconos

    Public IconosVectores As New List(Of String) From {
        "Cocktail",
        "Beer",
        "Hamburger",
        "Baguette",
        "Pizza",
        "Papas_fritas",
        "Wine_bottle",
        "Star",
        "Bread",
        "Cutlery"
        }

    Public Colores As New List(Of String) From {
        "Color1",
        "Color2",
        "Color3",
        "Color4",
        "Color5"
        }


    Function CambiarColorImagen(img As DrawingImage, color As Brush) As DrawingImage
        Dim newImage As New DrawingImage
        Try
            newImage.Drawing = img.Drawing.Clone
            newImage.Drawing.SetValue(GeometryDrawing.BrushProperty, color)
        Catch ex As Exception
            LogError(ex)
        End Try
        Return newImage
    End Function

End Module
