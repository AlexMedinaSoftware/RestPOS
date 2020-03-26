Imports System.Globalization

Module NewMenuModule

    Private CodigoProductoActual As String

#Region "Procesos para añadir categorias y productos"

    Sub AddCategory(nombre As String, Cards_ As Primitives.UniformGrid, Icon As Object, code As String, color_ As String)

        Dim Grid_ As Grid = New Grid With {
            .Margin = New Thickness(5, 3, 5, 3),
            .Width = 80,
            .Height = 120,
            .Style = GetResource("HoverCats"),
            .Tag = code
        }

        Dim Icon_ As Image = New Image() With {
            .Source = Icon,
            .Margin = New Thickness(0, 25, 0, 0),
            .HorizontalAlignment = HorizontalAlignment.Center,
            .VerticalAlignment = VerticalAlignment.Top,
            .Width = 40,
            .IsManipulationEnabled = False,
            .IsHitTestVisible = False
        }

        Dim Name_ As Label = New Label() With {
            .VerticalAlignment = VerticalAlignment.Bottom,
            .HorizontalAlignment = HorizontalAlignment.Stretch,
            .HorizontalContentAlignment = HorizontalAlignment.Center,
            .VerticalContentAlignment = VerticalAlignment.Center,
            .Height = 40,
            .Content = nombre,
            .FontSize = 10,
            .Foreground = GetResource("TextColor"),
            .FontFamily = New FontFamily("/RestPOS;component/Fonts/#Roboto")
        }

        Dim Card As Border = New Border() With {
            .VerticalAlignment = VerticalAlignment.Top,
            .Margin = New Thickness(0, 10, 0, 0),
            .Background = GetResource(color_),
            .Width = 70,
            .Height = 70,
            .Tag = code,
            .CornerRadius = New CornerRadius(3, 3, 3, 3)
        }

        Grid_.Children.Add(Card)
        Grid_.Children.Add(Icon_)
        Grid_.Children.Add(Name_)
        AddHandler Card.MouseDown, AddressOf Categoria_Click
        Cards_.Children.Add(Grid_)
    End Sub

    Sub AddTableMod(nombre As String, Cards_ As Primitives.UniformGrid, Icon As Object, id As String, color_ As String)

        Dim Grid_ As Grid = New Grid With {
            .Margin = New Thickness(5, 3, 5, 3),
            .MaxWidth = 80,
            .MinWidth = 60,
            .Height = 120,
            .Style = GetResource("HoverCats"),
            .Tag = id
        }

        Dim Icon_ As Image = New Image() With {
            .Source = Icon,
            .Margin = New Thickness(0, 25, 0, 0),
            .HorizontalAlignment = HorizontalAlignment.Center,
            .VerticalAlignment = VerticalAlignment.Top,
            .MaxWidth = 40,
            .IsManipulationEnabled = False,
            .IsHitTestVisible = False
        }

        Dim Name_ As Label = New Label() With {
            .VerticalAlignment = VerticalAlignment.Bottom,
            .HorizontalAlignment = HorizontalAlignment.Stretch,
            .HorizontalContentAlignment = HorizontalAlignment.Center,
            .VerticalContentAlignment = VerticalAlignment.Center,
            .Height = 40,
            .Content = nombre,
            .FontSize = 10,
            .Foreground = GetResource("TextColor"),
            .FontFamily = New FontFamily("/RestPOS;component/Fonts/#Roboto")
        }

        Dim Card As Border = New Border() With {
            .VerticalAlignment = VerticalAlignment.Top,
            .HorizontalAlignment = HorizontalAlignment.Stretch,
            .Margin = New Thickness(5, 10, 5, 0),
            .Background = GetResource(color_),
            .MaxWidth = 70,
            .Height = 70,
            .Tag = id,
            .CornerRadius = New CornerRadius(3, 3, 3, 3)
        }

        Grid_.Children.Add(Card)
        Grid_.Children.Add(Icon_)
        Grid_.Children.Add(Name_)
        AddHandler Card.MouseDown, AddressOf ModTable_Click
        Cards_.Children.Add(Grid_)
    End Sub

    Sub AddProduct(nombre As String, Cards_ As Primitives.UniformGrid, Precio As String, code As String, color_ As String)

        Dim Grid_ As Grid = New Grid With {
            .Margin = New Thickness(5, 5, 5, 5),
            .Width = 95,
            .Height = 120,
            .Tag = code
        }

        Dim Name_ As TextBlock = New TextBlock() With {
            .Margin = New Thickness(5, 5, 5, 0),
            .TextAlignment = TextAlignment.Left,
            .VerticalAlignment = VerticalAlignment.Top,
            .HorizontalAlignment = HorizontalAlignment.Stretch,
            .TextWrapping = TextWrapping.Wrap,
            .Height = 80,
            .Text = nombre,
            .FontSize = 15,
            .IsHitTestVisible = False,
            .Foreground = GetResource("TextColor"),
            .FontFamily = New FontFamily("/RestPOS;component/Fonts/#Roboto")
        }

        Dim Price_ As Label = New Label() With {
            .IsHitTestVisible = False,
            .Content = FormatCurrency(Precio),
            .VerticalContentAlignment = VerticalAlignment.Bottom,
            .VerticalAlignment = VerticalAlignment.Bottom,
            .HorizontalContentAlignment = HorizontalAlignment.Right,
            .HorizontalAlignment = HorizontalAlignment.Stretch,
            .Margin = New Thickness(3, 3, 3, 0),
            .Foreground = GetResource("TextColor"),
            .FontFamily = New FontFamily("/RestPOS;component/Fonts/#Roboto")
        }

        Dim Code_ As Label = New Label() With {
            .IsHitTestVisible = False,
            .Content = code,
            .VerticalContentAlignment = VerticalAlignment.Bottom,
            .VerticalAlignment = VerticalAlignment.Bottom,
            .HorizontalContentAlignment = HorizontalAlignment.Left,
            .HorizontalAlignment = HorizontalAlignment.Stretch,
            .Margin = New Thickness(3, 3, 3, 0),
            .Foreground = GetResource("TextColor"),
            .FontFamily = New FontFamily("/RestPOS;component/Fonts/#Roboto")
        }

        Dim Card As Border = New Border() With {
            .VerticalAlignment = VerticalAlignment.Top,
            .Background = GetResource(color_),
            .Width = 95,
            .Height = 120,
            .Tag = code,
            .Style = GetResource("HoverSimple"),
            .CornerRadius = New CornerRadius(3, 3, 3, 3)
        }

        Grid_.Children.Add(Card)
        Grid_.Children.Add(Name_)
        Grid_.Children.Add(Price_)
        Grid_.Children.Add(Code_)
        AddHandler Card.MouseDown, AddressOf Producto_Click
        Cards_.Children.Add(Grid_)
    End Sub

    Private Sub Categoria_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        Dim Cat As String = (TryCast(sender, Border)).Tag
        For Each item As Grid In Page_Mesas_Detalle.Categories.Children
            item.Style = GetResource("HoverCats")
            If item.Tag = Cat Then
                item.Style = GetResource("SelectCats")
            End If
        Next
        LoadProducts(Cat)
    End Sub

    Private Sub Producto_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        CodigoProductoActual = (TryCast(sender, Border)).Tag
        Dim productoActual As MainContext.Item = GetItemObject(CodigoProductoActual)
        Cargar_Modificaciones(productoActual.CategoryId)
        Select Case ModSelected
            Case "Mod_Cantidad"
                Page_Mesas_Detalle.PopUpQnty.IsOpen = True
            Case "Mod_Precio"
                Page_Mesas_Detalle.PopUpPrice.IsOpen = True
            Case "Mod_Modificar"
                Page_Mesas_Detalle.PopUpModificar.IsOpen = True
            Case Else
                If TableIsActive(CodigoMesaActual) Then
                    Dim tempItem As New MainContext.TicketsItem With {
                        .Count = 1,
                        .Name = productoActual.Name,
                        .Price = productoActual.BuyPrice,
                        .IsSended = 0,
                        .SectorId = productoActual.CategoryId
                    }
                    AddItemToTicket(GetTicketObject(GetTicketID(CodigoMesaActual)), tempItem)
                Else
                    CreateTicket(CodigoMesaActual)
                    Dim tempItem As New MainContext.TicketsItem With {
                        .Count = 1,
                        .Name = productoActual.Name,
                        .Price = productoActual.BuyPrice,
                        .IsSended = 0,
                        .SectorId = productoActual.CategoryId
                    }
                    AddItemToTicket(GetTicketObject(GetTicketID(CodigoMesaActual)), tempItem)
                End If
                LoadPedido(CodigoMesaActual)
        End Select
        CalcularTotal()
    End Sub

    Private Sub ModTable_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        Dim selectedTable As Border = sender
        ChangeTable(GetTicketID(CodigoMesaActual), CLng(selectedTable.Tag))
        LoadCats()
        Page_Mesas_Detalle.ActualizarMesa(CLng(selectedTable.Tag))
    End Sub

#End Region

#Region "Añadir productos al pedido con modificaciones"

    Sub Add_Producto_Mod_Qnty(cant As String)
        Dim productoActual As MainContext.Item = GetItemObject(CodigoProductoActual)
        If TableIsActive(CodigoMesaActual) Then
            Dim tempItem As New MainContext.TicketsItem With {
                        .Count = cant,
                        .Name = productoActual.Name,
                        .Price = productoActual.BuyPrice,
                        .IsSended = 0,
                        .SectorId = productoActual.CategoryId
                    }
            AddItemToTicket(GetTicketObject(GetTicketID(CodigoMesaActual)), tempItem)
        Else
            CreateTicket(CodigoMesaActual)
            Dim tempItem As New MainContext.TicketsItem With {
                        .Count = cant,
                        .Name = productoActual.Name,
                        .Price = productoActual.BuyPrice,
                        .IsSended = 0,
                        .SectorId = productoActual.CategoryId
                    }
            AddItemToTicket(GetTicketObject(GetTicketID(CodigoMesaActual)), tempItem)
        End If
        LoadPedido(CodigoMesaActual)
    End Sub

    Sub Add_Producto_Mod_Price(price As String)
        Dim productoActual As MainContext.Item = GetItemObject(CodigoProductoActual)
        If TableIsActive(CodigoMesaActual) Then
            Dim tempItem As New MainContext.TicketsItem With {
                        .Count = 1,
                        .Name = productoActual.Name,
                        .Price = price,
                        .IsSended = 0,
                        .SectorId = productoActual.CategoryId
                    }
            AddItemToTicket(GetTicketObject(GetTicketID(CodigoMesaActual)), tempItem)
        Else
            CreateTicket(CodigoMesaActual)
            Dim tempItem As New MainContext.TicketsItem With {
                        .Count = 1,
                        .Name = productoActual.Name,
                        .Price = price,
                        .IsSended = 0,
                        .SectorId = productoActual.CategoryId
                    }
            AddItemToTicket(GetTicketObject(GetTicketID(CodigoMesaActual)), tempItem)
        End If
        LoadPedido(CodigoMesaActual)
    End Sub

    Sub Add_Producto_Mod_Modificar(name As String, extraprice As String)
        Dim productoActual As MainContext.Item = GetItemObject(CodigoProductoActual)
        If TableIsActive(CodigoMesaActual) Then
            Dim tempItem As New MainContext.TicketsItem With {
                        .Count = 1,
                        .Name = productoActual.Name & name,
                        .Price = (productoActual.BuyPrice + CDbl(extraprice)),
                        .IsSended = 0,
                        .SectorId = productoActual.CategoryId
                    }
            AddItemToTicket(GetTicketObject(GetTicketID(CodigoMesaActual)), tempItem)
        Else
            CreateTicket(CodigoMesaActual)
            Dim tempItem As New MainContext.TicketsItem With {
                        .Count = 1,
                        .Name = productoActual.Name & name,
                        .Price = (productoActual.BuyPrice + CDbl(extraprice)),
                        .IsSended = 0,
                        .SectorId = productoActual.CategoryId
                    }
            AddItemToTicket(GetTicketObject(GetTicketID(CodigoMesaActual)), tempItem)
        End If
        LoadPedido(CodigoMesaActual)
    End Sub

#End Region

#Region "Cargar Pedidos, Productos y Categorias"

    Sub LoadCats()
        Page_Mesas_Detalle.Categories.Children.Clear()
        For Each Cat_ In GetCategories()
            AddCategory(Cat_.Name, Page_Mesas_Detalle.Categories, GetResource(Cat_.Icon), Cat_.Id, Cat_.BtnColor)
        Next
    End Sub

    Sub LoadModMesas()
        Page_Mesas_Detalle.Categories.Children.Clear()
        For Each table In GetTables()
            If Not TableIsActive(table.Id) Then
                AddTableMod(table.Name, Page_Mesas_Detalle.Categories, GetResource("Mesa"), table.Id, table.Color)
            End If
        Next
    End Sub

    Sub LoadProducts(CatCode As Integer)
        Page_Mesas_Detalle.Productos.Children.Clear()
        For Each item In GetItems(CatCode)
            AddProduct(item.Name, Page_Mesas_Detalle.Productos, item.BuyPrice, item.Id, item.BtnColor)
        Next
    End Sub

    Sub LoadPedido(Mesa As Integer)
        Page_Mesas_Detalle.ListaPedido.Items.Clear()
        For Each item In GetTicketItems(GetTicketID(Mesa))
            Dim newItem As New Item_Pedido With {
                .P_Item_ID = item.Id,
                .P_Item_Cantidad = item.Count,
                .P_Item_Nombre = item.Name,
                .P_Item_Precio = String.Format(cultureChile, "{0:C}", item.Price),
                .P_Item_Total = String.Format(cultureChile, "{0:C}", (item.Price * item.Count))
            }
            Page_Mesas_Detalle.ListaPedido.Items.Add(newItem)
        Next
        CalcularTotal()
    End Sub

#End Region

    Sub CalcularTotal()
        Dim datagrid As DataGrid = Page_Mesas_Detalle.ListaPedido
        Dim total As Double = 0
        For Each item As Item_Pedido In datagrid.Items
            total += item.P_Item_Total.Replace("$", String.Empty).Replace(".", String.Empty)
        Next
        Page_Mesas_Detalle.LabelTotal.Content = String.Format(cultureChile, "{0:C}", total)
    End Sub

End Module
