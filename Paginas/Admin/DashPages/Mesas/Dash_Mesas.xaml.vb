Class Dash_Mesas

    Sub AddMesaToGrid(mesa As MainContext.Table)
        If Not mesa Is Nothing Then
            Dim border As New Border With {
                .BorderBrush = GetResource(mesa.Color),
                .Style = GetResource("Dash_Item_Border"),
                .BorderThickness = New Thickness(3),
                .CornerRadius = New CornerRadius(10),
                .Width = 110,
                .Height = 110,
                .Margin = New Thickness(10)
            }

            Dim text As New TextBlock With {
                .VerticalAlignment = VerticalAlignment.Center,
                .HorizontalAlignment = HorizontalAlignment.Center,
                .Foreground = GetResource(mesa.Color),
                .Text = mesa.Name,
                .FontSize = 30,
                .FontFamily = New FontFamily("/RestPOS;component/Fonts/#Roboto")
            }

            border.Child = text
            Grid_Mesas.Children.Add(border)
        End If
    End Sub

    Private Sub Dash_Mesas_Loaded(sender As Object, e As RoutedEventArgs) Handles Me.Loaded
        Grid_Mesas.Children.Clear()
        For Each mesa In GetTables()
            AddMesaToGrid(mesa)
        Next
    End Sub
End Class
