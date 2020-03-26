Module MesasModule
    Sub AddMesa(nombre As String, code As String, active As Boolean, color As String, Cards_ As Primitives.UniformGrid)
        Dim ActiveColor As SolidColorBrush
        If active Then
            ActiveColor = Brushes.LimeGreen
        Else
            ActiveColor = Brushes.Transparent
        End If

        Dim Grid_ As Grid = New Grid() With {
            .Height = 145,
            .Width = 165,
            .Margin = New Thickness(10, 10, 10, 10)
        }

        Dim Name_ As Label = New Label() With {
            .VerticalAlignment = VerticalAlignment.Center,
            .HorizontalAlignment = HorizontalAlignment.Stretch,
            .HorizontalContentAlignment = HorizontalAlignment.Center,
            .VerticalContentAlignment = VerticalAlignment.Center,
            .Content = nombre,
            .FontSize = 50,
            .Foreground = GetResource("TextColor"),
            .FontFamily = New FontFamily("/RestPOS;component/Fonts/#Roboto"),
            .IsHitTestVisible = False
        }

        Dim Status As Border = New Border() With {
            .Background = ActiveColor,
            .VerticalAlignment = VerticalAlignment.Bottom,
            .Height = 10,
            .CornerRadius = New CornerRadius(0, 0, 10, 10),
            .IsManipulationEnabled = False,
            .IsHitTestVisible = False
        }

        Dim Card As Border = New Border() With {
            .Tag = code,
            .Background = GetResource(color),
            .CornerRadius = New CornerRadius(10, 10, 10, 10),
            .Style = GetResource("Hover")
        }
        Grid_.Children.Add(Card)
        Grid_.Children.Add(Status)
        Grid_.Children.Add(Name_)
        AddHandler Card.MouseDown, AddressOf Card_Click
        Cards_.Children.Add(Grid_)
    End Sub

    Private Sub Card_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        'MostrarPopUp("Usuario", MsgBoxStyle.OkOnly, String.Format("You clicked on the {0}. button.", (TryCast(sender, Border)).Tag), "", "Creado por Alex Carcamo Medina.")
        CodigoMesaActual = (TryCast(sender, Border)).Tag
        SetTitulo("")
        PaginaActual = Page_Mesas_Detalle
    End Sub

    Sub LoadMesas()
        Dim tempTable As List(Of MainContext.Table) = GetTables()
        Page_Mesas.Cards.Children.Clear()
        If tempTable.Count < 6 Then
            Page_Mesas.Cards.Columns = tempTable.Count
        End If
        Page_Mesas.Cards.Rows = Math.Ceiling(tempTable.Count / 6)

        For Each mesa_ In tempTable
            AddMesa(mesa_.Name, mesa_.Id, TableIsActive(mesa_.Id), mesa_.Color, Page_Mesas.Cards)
        Next
    End Sub

End Module
