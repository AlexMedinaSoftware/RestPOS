Imports System.Globalization

Module ModsModule
    Sub Cargar_Mod_Cantidad()
        Try
            Page_Mesas_Detalle.PopUpQntyGrid.Children.Clear()
        Catch ex As Exception
        End Try

        For i = 1 To 9
            Dim Name_ As Label = New Label() With {
                .VerticalAlignment = VerticalAlignment.Stretch,
                .HorizontalAlignment = HorizontalAlignment.Stretch,
                .HorizontalContentAlignment = HorizontalAlignment.Center,
                .VerticalContentAlignment = VerticalAlignment.Center,
                .Content = i,
                .FontSize = 20,
                .Foreground = GetResource("TextColor"),
                .FontFamily = New FontFamily("/RestPOS;component/Fonts/#Roboto")
            }

            Dim Card As Border = New Border() With {
                .VerticalAlignment = VerticalAlignment.Stretch,
                .Margin = New Thickness(3, 3, 3, 3),
                .Background = GetResource("DarkColor1"),
                .Tag = i,
                .CornerRadius = New CornerRadius(3, 3, 3, 3)
            }


            Card.Child = Name_
            AddHandler Card.MouseDown, AddressOf Mod_Cantidad_Click
            Page_Mesas_Detalle.PopUpQntyGrid.Children.Add(Card)
        Next
    End Sub

    Sub Cargar_Mod_Precio()
        Try
            Page_Mesas_Detalle.PopUpPriceGrid.Children.Clear()
        Catch ex As Exception
        End Try

        Dim botones As New List(Of String) From {
            "7",
            "8",
            "9",
            "4",
            "5",
            "6",
            "1",
            "2",
            "3",
            "OK",
            "0",
            "Borrar"
        }
        For Each boton In botones
            Select Case boton

                Case "Borrar", "OK"

                    Dim Name_ As Label = New Label() With {
                    .VerticalAlignment = VerticalAlignment.Stretch,
                    .HorizontalAlignment = HorizontalAlignment.Stretch,
                    .HorizontalContentAlignment = HorizontalAlignment.Center,
                    .VerticalContentAlignment = VerticalAlignment.Center,
                    .Content = boton,
                    .FontSize = 15,
                    .Foreground = GetResource("TextColor"),
                    .FontFamily = New FontFamily("/RestPOS;component/Fonts/#Roboto")
                    }

                    Dim Card As Border = New Border() With {
                        .VerticalAlignment = VerticalAlignment.Stretch,
                        .Margin = New Thickness(3, 3, 3, 3),
                        .Background = GetResource("DarkColor1"),
                        .Tag = boton,
                        .CornerRadius = New CornerRadius(3, 3, 3, 3)
                    }

                    Card.Child = Name_
                    AddHandler Card.MouseDown, AddressOf Mod_Precio_Click
                    Page_Mesas_Detalle.PopUpPriceGrid.Children.Add(Card)

                Case Else
                    Dim Name_ As Label = New Label() With {
                        .VerticalAlignment = VerticalAlignment.Stretch,
                        .HorizontalAlignment = HorizontalAlignment.Stretch,
                        .HorizontalContentAlignment = HorizontalAlignment.Center,
                        .VerticalContentAlignment = VerticalAlignment.Center,
                        .Content = boton,
                        .FontSize = 20,
                        .Foreground = GetResource("TextColor"),
                        .FontFamily = New FontFamily("/RestPOS;component/Fonts/#Roboto")
                    }

                    Dim Card As Border = New Border() With {
                        .VerticalAlignment = VerticalAlignment.Stretch,
                        .Margin = New Thickness(3, 3, 3, 3),
                        .Background = GetResource("DarkColor1"),
                        .Tag = boton,
                        .CornerRadius = New CornerRadius(3, 3, 3, 3)
                    }

                    Card.Child = Name_
                    AddHandler Card.MouseDown, AddressOf Mod_Precio_Click
                    Page_Mesas_Detalle.PopUpPriceGrid.Children.Add(Card)
            End Select

        Next
    End Sub

    Sub Cargar_Modificaciones(categoria As String)
        Try
            Page_Mesas_Detalle.PopUpModificarGrid.Children.Clear()
        Catch ex As Exception
        End Try

        For Each mod_ As MainContext.Modifier In GetModifiers(categoria)
            Dim Name_ As TextBlock = New TextBlock() With {
            .VerticalAlignment = VerticalAlignment.Stretch,
            .HorizontalAlignment = HorizontalAlignment.Stretch,
            .TextAlignment = TextAlignment.Center,
            .Margin = New Thickness(5, 5, 5, 5),
            .TextWrapping = TextWrapping.WrapWithOverflow,
            .Text = mod_.Name,
            .FontSize = 15,
            .Foreground = GetResource("TextColor"),
            .FontFamily = New FontFamily("/RestPOS;component/Fonts/#Roboto")
            }

            Dim Price_ As TextBlock = New TextBlock() With {
            .VerticalAlignment = VerticalAlignment.Bottom,
            .HorizontalAlignment = HorizontalAlignment.Stretch,
            .TextAlignment = TextAlignment.Right,
            .Margin = New Thickness(5, 5, 5, 5),
            .TextWrapping = TextWrapping.WrapWithOverflow,
            .Text = String.Format(cultureChile, "{0:C}", mod_.Price),
            .FontSize = 10,
            .Foreground = GetResource("TextColor"),
            .FontFamily = New FontFamily("/RestPOS;component/Fonts/#Roboto")
            }

            Dim Card As Border = New Border() With {
                    .VerticalAlignment = VerticalAlignment.Stretch,
                    .HorizontalAlignment = HorizontalAlignment.Stretch,
                    .Background = GetResource("DarkColor1"),
                    .CornerRadius = New CornerRadius(3, 3, 3, 3),
                    .Name = "MOD" & mod_.Id,
                    .Tag = mod_.Id
                }

            Dim Grid_ As Grid = New Grid() With {
                .Width = 94,
                .Height = 94,
                .Tag = mod_.Id,
                .Margin = New Thickness(3, 3, 3, 3)
            }

            Grid_.Children.Add(Card)
            Grid_.Children.Add(Name_)
            Grid_.Children.Add(Price_)
            AddHandler Grid_.MouseDown, AddressOf Mod_Modificar_Click
            Page_Mesas_Detalle.PopUpModificarGrid.Children.Add(Grid_)

        Next
    End Sub

    Private Sub Mod_Cantidad_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        Dim n As String = (TryCast(sender, Border)).Tag
        Add_Producto_Mod_Qnty(n)
        Page_Mesas_Detalle.PopUpQnty.IsOpen = False
        ModSelected = ""
    End Sub

    Private Sub Mod_Modificar_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        Dim modifier_ As Grid = sender
        Dim n As String = (TryCast(sender, Grid)).Tag

        For Each item In modifier_.Children
            If item.GetType.ToString = "System.Windows.Controls.Border" Then
                If item.Background.ToString = GetResource("DarkColor1").ToString Then
                    item.Background = GetResource("Color1")
                Else
                    item.Background = GetResource("DarkColor1")
                End If
            End If
        Next
    End Sub

    Sub Mod_Modificar_Unselect()
        For Each grid As Grid In Page_Mesas_Detalle.PopUpModificarGrid.Children
            For Each item In grid.Children
                If item.GetType.ToString = "System.Windows.Controls.Border" Then
                    Dim check As Border = item
                    check.Background = GetResource("DarkColor1")
                    check.Tag = 0
                End If
            Next
        Next
    End Sub

    Private Sub Mod_Precio_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        Dim n As String = (TryCast(sender, Border)).Tag
        If n = "OK" Then
            If IsNumeric(Page_Mesas_Detalle.PopUpPriceText.Text) Then
                Add_Producto_Mod_Price(Page_Mesas_Detalle.PopUpPriceText.Text)
            End If
            Page_Mesas_Detalle.PopUpPriceText.Text = ""
            Page_Mesas_Detalle.PopUpPrice.IsOpen = False
            Page_Mesas_Detalle.UnSelectAll()
        ElseIf n = "Borrar" Then
            If Page_Mesas_Detalle.PopUpPriceText.Text.Length > 0 Then
                Page_Mesas_Detalle.PopUpPriceText.Text = Page_Mesas_Detalle.PopUpPriceText.Text.Substring(0, Page_Mesas_Detalle.PopUpPriceText.Text.Length - 1)
            Else
                Page_Mesas_Detalle.UnSelectAll()
            End If
        Else
            If Page_Mesas_Detalle.PopUpPriceText.Text = "0" Then
                Page_Mesas_Detalle.PopUpPriceText.Text = ""
            End If
            Page_Mesas_Detalle.PopUpPriceText.Text &= n
        End If
        ModSelected = ""
    End Sub

End Module
