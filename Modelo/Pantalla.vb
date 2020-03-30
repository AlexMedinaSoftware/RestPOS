Module Pantalla
    Sub AjustarEscalaProductos()
        If Page_Mesas_Detalle.Productos.ActualWidth \ 108 > 0 Then
            Page_Mesas_Detalle.Productos.Columns = Page_Mesas_Detalle.Productos.ActualWidth \ 108
        End If
    End Sub
    Function ScreenMultiplicator() As Double
        Dim screenWidth As Integer = SystemParameters.PrimaryScreenWidth
        Dim screenHeight As Integer = SystemParameters.PrimaryScreenHeight
        Return ((screenWidth / 1366) + (screenHeight / 768)) / 2
    End Function

End Module
