Class Detalle_Productos



    Private Enum TiposItems
        Producto = 1
        Categoria = 2
        Modificacion = 3
    End Enum

    Private Enum TiposEdicion
        Add = 1
        Edit = 2
        Del = 3
    End Enum

    Private CategorySelected As Integer = -1
    Private ProductSelected As Integer = -1
    Private ModSelected As Integer = -1
    Private ItemType As TiposItems
    Private EditType As TiposEdicion

#Region "Productos"

    Sub ShowProducts(items As List(Of MainContext.Item))
        ItemType = TiposItems.Producto
        Page_Admin_Dash.DashActual = Page_Dash_Detalle_Productos
        Grid_Prods.Children.Clear()
        If Not items Is Nothing Then
            For Each item In items
                AddProductToGrid(item)
            Next
        End If
    End Sub

    Sub AddProductToGrid(item As MainContext.Item, Optional Index As Integer = -1)
        If Not item Is Nothing Then

            Dim grid As New Grid With {
                .Margin = New Thickness(5 * ScreenMultiplicator())
                }

            Dim border As New Border With {
                .BorderBrush = GetResource(item.BtnColor),
                .Style = GetResource("Dash_Item_Border"),
                .BorderThickness = New Thickness(3),
                .CornerRadius = New CornerRadius(10),
                .Width = 110 * ScreenMultiplicator(),
                .Height = 110 * ScreenMultiplicator(),
                .Margin = New Thickness(10),
                .Tag = item.Id
            }

            Dim name As New TextBlock With {
                .VerticalAlignment = VerticalAlignment.Top,
                .HorizontalAlignment = HorizontalAlignment.Left,
                .Foreground = GetResource(item.BtnColor),
                .Text = item.Name,
                .FontSize = 15 * ScreenMultiplicator(),
                .TextWrapping = TextWrapping.Wrap,
                .FontFamily = New FontFamily("/RestPOS;component/Fonts/#Roboto")
            }

            Dim price As New TextBlock With {
                .VerticalAlignment = VerticalAlignment.Bottom,
                .HorizontalAlignment = HorizontalAlignment.Right,
                .Foreground = GetResource(item.BtnColor),
                .Text = String.Format(cultureChile, "{0:C}", item.BuyPrice),
                .FontSize = 12 * ScreenMultiplicator(),
                .TextWrapping = TextWrapping.Wrap,
                .FontFamily = New FontFamily("/RestPOS;component/Fonts/#Roboto")
            }

            grid.Children.Add(name)
            grid.Children.Add(price)
            border.Child = grid
            AddHandler border.MouseUp, AddressOf Item_Click
            AddHandler border.MouseUp, AddressOf Product_Click
            If Index = -1 Then
                Grid_Prods.Children.Add(border)
            Else
                Grid_Prods.Children.Insert(Index, border)
            End If
        End If
    End Sub

#End Region

#Region "Modificadores"
    Sub ShowMods(items As List(Of MainContext.Modifier))
        ItemType = TiposItems.Modificacion
        Page_Admin_Dash.DashActual = Page_Dash_Detalle_Productos
        Grid_Prods.Children.Clear()
        If Not items Is Nothing Then
            For Each item In items
                AddModToGrid(item)
            Next
        End If
    End Sub

    Sub AddModToGrid(item As MainContext.Modifier, Optional Index As Integer = -1)
        If Not item Is Nothing Then

            Dim grid As New Grid With {
                .Margin = New Thickness(5 * ScreenMultiplicator())
                }

            Dim border As New Border With {
                .BorderBrush = GetResource("Color4"),
                .Style = GetResource("Dash_Item_Border"),
                .BorderThickness = New Thickness(3),
                .CornerRadius = New CornerRadius(10),
                .Width = 110 * ScreenMultiplicator(),
                .Height = 110 * ScreenMultiplicator(),
                .Margin = New Thickness(10),
                .Tag = item.Id
            }

            Dim name As New TextBlock With {
                .VerticalAlignment = VerticalAlignment.Top,
                .HorizontalAlignment = HorizontalAlignment.Left,
                .Foreground = GetResource("Color4"),
                .Text = item.Name,
                .FontSize = 15 * ScreenMultiplicator(),
                .TextWrapping = TextWrapping.Wrap,
                .FontFamily = New FontFamily("/RestPOS;component/Fonts/#Roboto")
            }

            Dim price As New TextBlock With {
                .VerticalAlignment = VerticalAlignment.Bottom,
                .HorizontalAlignment = HorizontalAlignment.Right,
                .Foreground = GetResource("Color4"),
                .Text = String.Format(cultureChile, "{0:C}", item.Price),
                .FontSize = 12 * ScreenMultiplicator(),
                .TextWrapping = TextWrapping.Wrap,
                .FontFamily = New FontFamily("/RestPOS;component/Fonts/#Roboto")
            }

            Dim category As New TextBlock With {
                .VerticalAlignment = VerticalAlignment.Bottom,
                .HorizontalAlignment = HorizontalAlignment.Left,
                .Foreground = GetResource("Color4"),
                .Text = GetCategoryObject(item.CategoryId).Name,
                .Margin = New Thickness(0, 0, 0, 15 * ScreenMultiplicator()),
                .FontSize = 12 * ScreenMultiplicator(),
                .TextWrapping = TextWrapping.Wrap,
                .FontFamily = New FontFamily("/RestPOS;component/Fonts/#Roboto")
            }

            grid.Children.Add(name)
            grid.Children.Add(price)
            grid.Children.Add(category)
            border.Child = grid
            AddHandler border.MouseUp, AddressOf Item_Click
            AddHandler border.MouseUp, AddressOf Modification_Click
            If Index = -1 Then
                Grid_Prods.Children.Add(border)
            Else
                Grid_Prods.Children.Insert(Index, border)
            End If
        End If
    End Sub

#End Region

#Region "Categorias"

    Sub ShowCategories(items As List(Of MainContext.Category))
        ItemType = TiposItems.Categoria
        Page_Admin_Dash.DashActual = Page_Dash_Detalle_Productos
        Grid_Prods.Children.Clear()
        If Not items Is Nothing Then
            For Each item In items
                AddCategoryToGrid(item)
            Next
        End If
    End Sub

    Sub AddCategoryToGrid(item As MainContext.Category, Optional Index As Integer = -1)
        If Not item Is Nothing Then
            Dim border As New Border With {
                .BorderBrush = GetResource(item.BtnColor),
                .Style = GetResource("Dash_Item_Border"),
                .BorderThickness = New Thickness(3),
                .CornerRadius = New CornerRadius(10),
                .Width = 110 * ScreenMultiplicator(),
                .Height = 110 * ScreenMultiplicator(),
                .Margin = New Thickness(10),
                .Tag = item.Id
            }

            Dim grid As New Grid With {
                .Margin = New Thickness(5 * ScreenMultiplicator())
            }

            Dim img As New Image With {
                .Source = CambiarColorImagen(GetResource(item.Icon), GetResource(item.BtnColor)),
                .Width = 50 * ScreenMultiplicator(),
                .Height = Width,
                .HorizontalAlignment = HorizontalAlignment.Center,
                .VerticalAlignment = VerticalAlignment.Top,
                .Margin = New Thickness(0, 10 * ScreenMultiplicator(), 0, 0)
            }

            Dim text As New TextBlock With {
                .VerticalAlignment = VerticalAlignment.Bottom,
                .HorizontalAlignment = HorizontalAlignment.Center,
                .Foreground = GetResource(item.BtnColor),
                .Text = item.Name,
                .TextAlignment = TextAlignment.Center,
                .FontSize = 12 * ScreenMultiplicator(),
                .TextWrapping = TextWrapping.Wrap,
                .FontFamily = New FontFamily("/RestPOS;component/Fonts/#Roboto")
            }

            grid.Children.Add(text)
            grid.Children.Add(img)
            border.Child = grid
            AddHandler border.MouseUp, AddressOf Item_Click
            AddHandler border.MouseUp, AddressOf Category_Click
            If Index = -1 Then
                Grid_Prods.Children.Add(border)
            Else
                Grid_Prods.Children.Insert(Index, border)
            End If
        End If
    End Sub

#End Region

    Private Sub Item_Click(sender As Object, e As EventArgs)
        For Each item As Border In Grid_Prods.Children
            item.Style = GetResource("Dash_Item_Border")
        Next
        Dim b As Border = sender
        b.Style = GetResource("Dash_Item_Border_Selected")
    End Sub
    Private Sub Product_Click(sender As Object, e As EventArgs)
        Dim b As Border = sender
        ProductSelected = b.Tag
    End Sub
    Private Sub Category_Click(sender As Object, e As EventArgs)
        Dim b As Border = sender
        CategorySelected = b.Tag
    End Sub
    Private Sub Modification_Click(sender As Object, e As EventArgs)
        Dim b As Border = sender
        ModSelected = b.Tag
    End Sub
    Private Sub AddItem_MouseUp(sender As Object, e As MouseButtonEventArgs) Handles AddItem.MouseUp
        EditType = TiposEdicion.Add
        LoadPopUpProduct()
        Select Case ItemType
            Case TiposItems.Categoria
                PopUp_Title.Text = "Nueva categoría"
                PopUp_Barcode.IsEnabled = False
                PopUp_Compra.IsEnabled = False
                PopUp_Stock.IsEnabled = False
                PopUp_Venta.IsEnabled = False
                PopUp_Tag.IsEnabled = False
                PopUp_Stock.IsEnabled = False
                CategorySelector.IsEnabled = False
            Case TiposItems.Modificacion
                PopUp_Title.Text = "Nueva modificación"
                PopUp_Barcode.IsEnabled = False
                PopUp_Compra.IsEnabled = False
                PopUp_Stock.IsEnabled = False
                PopUp_Tag.IsEnabled = False
                PopUp_Stock.IsEnabled = False
                IconoSelector.IsEnabled = False
                ColorSelector.IsEnabled = False
                PopUp_Check_Barra.IsEnabled = False
            Case TiposItems.Producto
                PopUp_Title.Text = "Nuevo producto"
                IconoSelector.IsEnabled = False
                PopUp_Check_Barra.IsEnabled = False
        End Select

        If Popup_Product.Visibility = Visibility.Hidden Then
            Popup_Product.Visibility = Visibility.Visible
        Else
            Popup_Product.Visibility = Visibility.Hidden
        End If
    End Sub
    Sub LoadPopUpProduct()
        CategorySelector.IsEnabled = True
        IconoSelector.IsEnabled = True
        ColorSelector.IsEnabled = True
        PopUp_Venta.IsEnabled = True
        PopUp_Tag.IsEnabled = True
        PopUp_Stock.IsEnabled = True
        PopUp_Orden.IsEnabled = True
        PopUp_Name.IsEnabled = True
        PopUp_Compra.IsEnabled = True
        PopUp_Barcode.IsEnabled = True
        PopUp_Check_Barra.IsEnabled = True

        If Not CategorySelector.Items.Count > 0 Then

            CategorySelector.Items.Clear()
            IconoSelector.Items.Clear()
            ColorSelector.Items.Clear()

            For Each cat As MainContext.Category In GetCategories()
                CategorySelector.Items.Add(cat.Id & " - " & cat.Name)
            Next

            For Each ic As String In IconosVectores
                IconoSelector.Items.Add(ic)
            Next

            For Each co As String In Colores
                ColorSelector.Items.Add(co)
            Next
        End If

        Try
            PopUp_Venta.Text = 0
            PopUp_Tag.Text = ""
            PopUp_Stock.Text = 0
            PopUp_Orden.Text = 9999
            PopUp_Name.Text = ""
            PopUp_Compra.Text = 0
            PopUp_Barcode.Text = ""
            PopUp_Check_Barra.IsChecked = False
            ColorPreview.Background = Brushes.Transparent
            IconoPreview.Source = Nothing
        Catch ex As Exception
            LogError(ex)
        End Try


        Select Case EditType
            Case TiposEdicion.Edit
                Select Case ItemType
                    Case TiposItems.Producto
                        Try
                            With GetItemObject(ProductSelected)
                                PopUp_Venta.Text = .BuyPrice
                                PopUp_Tag.Text = .Tag
                                PopUp_Stock.Text = .StockAmount
                                PopUp_Orden.Text = .SortOrder
                                PopUp_Name.Text = .Name
                                PopUp_Compra.Text = .SellPrice
                                PopUp_Barcode.Text = .Barcode
                                CategorySelector.SelectedIndex = GetCategoryIndexFromSelector(.CategoryId)
                                ColorSelector.SelectedIndex = GetColorIndexFromSelector(.BtnColor)
                            End With
                        Catch ex As Exception
                            LogError(ex)
                        End Try
                    Case TiposItems.Modificacion
                        Try
                            With GetModifierObject(ModSelected)
                                PopUp_Name.Text = .Name
                                PopUp_Venta.Text = .Price
                                CategorySelector.SelectedIndex = GetCategoryIndexFromSelector(.CategoryId)
                            End With
                        Catch ex As Exception
                            LogError(ex)
                        End Try
                    Case TiposItems.Categoria
                        Try
                            With GetCategoryObject(CategorySelected)
                                PopUp_Name.Text = .Name
                                PopUp_Orden.Text = .SortOrder
                                PopUp_Tag.Text = .Tag
                                ColorSelector.SelectedIndex = GetColorIndexFromSelector(.BtnColor)
                                IconoSelector.SelectedIndex = GetIconIndexFromSelector(.Icon)
                                PopUp_Check_Barra.IsChecked = .IsLiquid
                            End With
                        Catch ex As Exception
                            LogError(ex)
                        End Try
                End Select
        End Select


    End Sub

    Private Sub IconoSelector_SelectionChanged(sender As Object, e As SelectionChangedEventArgs) Handles IconoSelector.SelectionChanged
        Try
            IconoPreview.Source = CambiarColorImagen(GetResource(IconoSelector.SelectedItem), Brushes.Black)
        Catch ex As Exception
            LogError(ex)
        End Try
    End Sub

    Private Sub ColorSelector_SelectionChanged(sender As Object, e As SelectionChangedEventArgs) Handles ColorSelector.SelectionChanged
        Try
            ColorPreview.Background = GetResource(ColorSelector.SelectedItem)
        Catch ex As Exception
            LogError(ex)
        End Try
    End Sub

    Private Sub Popup_Product_Close_MouseUp(sender As Object, e As MouseButtonEventArgs) Handles Popup_Product_Close.MouseUp
        Popup_Product.Visibility = Visibility.Hidden
    End Sub

    Private Sub PopUp_Cancel_MouseUp(sender As Object, e As MouseButtonEventArgs) Handles PopUp_Cancel.MouseUp
        Popup_Product.Visibility = Visibility.Hidden
    End Sub

    Private Sub PopUp_Ok_MouseUp(sender As Object, e As MouseButtonEventArgs) Handles PopUp_Ok.MouseUp
        Select Case EditType
            Case TiposEdicion.Add
                Select Case ItemType
                    Case TiposItems.Categoria
                        Dim newCat As New MainContext.Category With {
                            .BtnColor = ColorSelector.SelectedItem,
                            .Description = "",
                            .Icon = IconoSelector.SelectedItem,
                            .IsLiquid = PopUp_Check_Barra.IsChecked,
                            .LblColor = .BtnColor,
                            .Name = PopUp_Name.Text,
                            .SortOrder = PopUp_Orden.Text,
                            .Tag = PopUp_Tag.Text,
                            .Visible = 1
                        }
                        If AMPOS.AddNewCategory(newCat) Then
                            Popup_Product.Visibility = Visibility.Hidden
                            AddCategoryToGrid(newCat, 0)
                        End If
                    Case TiposItems.Modificacion
                        Dim newMod As New MainContext.Modifier With {
                            .CategoryId = Split(CategorySelector.SelectedItem, "-")(0),
                            .Name = PopUp_Name.Text,
                            .Price = PopUp_Venta.Text
                        }
                        If AMPOS.AddNewModifier(newMod) Then
                            Popup_Product.Visibility = Visibility.Hidden
                            AddModToGrid(newMod, 0)
                        End If
                    Case TiposItems.Producto
                        Dim item As New MainContext.Item With {
                            .Barcode = PopUp_Barcode.Text,
                            .BtnColor = ColorSelector.SelectedItem,
                            .BuyPrice = PopUp_Venta.Text,
                            .CategoryId = Split(CategorySelector.SelectedItem, "-")(0),
                            .Name = PopUp_Name.Text,
                            .SellPrice = PopUp_Compra.Text,
                            .SortOrder = PopUp_Orden.Text,
                            .StockAmount = PopUp_Stock.Text,
                            .Tag = PopUp_Tag.Text,
                            .Visible = 1,
                            .LblColor = .BtnColor,
                            .Description = ""
                        }
                        If AMPOS.AddNewItem(item) Then
                            Popup_Product.Visibility = Visibility.Hidden
                            AddProductToGrid(item, 0)
                        End If
                End Select
            Case TiposEdicion.Edit
                Select Case ItemType
                    Case TiposItems.Categoria
                        Dim newCat As New MainContext.Category With {
                            .BtnColor = ColorSelector.SelectedItem,
                            .Description = "",
                            .Icon = IconoSelector.SelectedItem,
                            .IsLiquid = PopUp_Check_Barra.IsChecked,
                            .LblColor = .BtnColor,
                            .Name = PopUp_Name.Text,
                            .SortOrder = PopUp_Orden.Text,
                            .Tag = PopUp_Tag.Text,
                            .Visible = 1
                        }
                        If AMPOS.EditCategory(CategorySelected, newCat) Then
                            Popup_Product.Visibility = Visibility.Hidden
                            AddCategoryToGrid(GetCategoryObject(CategorySelected), DelItemVista(CategorySelected))
                        End If

                    Case TiposItems.Modificacion
                        Dim newMod As New MainContext.Modifier With {
                            .CategoryId = Split(CategorySelector.SelectedItem, "-")(0),
                            .Name = PopUp_Name.Text,
                            .Price = PopUp_Venta.Text
                        }
                        If AMPOS.EditModifier(ModSelected, newMod) Then
                            Popup_Product.Visibility = Visibility.Hidden
                            AddModToGrid(GetModifierObject(ModSelected), DelItemVista(ModSelected))
                        End If
                    Case TiposItems.Producto
                        Dim item As New MainContext.Item With {
                            .Barcode = PopUp_Barcode.Text,
                            .BtnColor = ColorSelector.SelectedItem,
                            .BuyPrice = PopUp_Venta.Text,
                            .CategoryId = Split(CategorySelector.SelectedItem, "-")(0),
                            .Name = PopUp_Name.Text,
                            .SellPrice = PopUp_Compra.Text,
                            .SortOrder = PopUp_Orden.Text,
                            .StockAmount = PopUp_Stock.Text,
                            .Tag = PopUp_Tag.Text,
                            .Visible = 1,
                            .LblColor = .BtnColor,
                            .Description = ""
                        }
                        If AMPOS.EditItem(ProductSelected, item) Then
                            Popup_Product.Visibility = Visibility.Hidden
                            AddProductToGrid(GetItemObject(ProductSelected), DelItemVista(ProductSelected))
                        End If
                End Select
        End Select
    End Sub

    Private Sub EditItem_MouseUp(sender As Object, e As MouseButtonEventArgs) Handles EditItem.MouseUp
        EditType = TiposEdicion.Edit
        LoadPopUpProduct()
        Select Case ItemType
            Case TiposItems.Categoria
                PopUp_Title.Text = "Editar categoría - " & CategorySelected
                PopUp_Barcode.IsEnabled = False
                PopUp_Compra.IsEnabled = False
                PopUp_Stock.IsEnabled = False
                PopUp_Venta.IsEnabled = False
                PopUp_Tag.IsEnabled = False
                PopUp_Stock.IsEnabled = False
                CategorySelector.IsEnabled = False
            Case TiposItems.Modificacion
                PopUp_Title.Text = "Editar modificación - " & ModSelected
                PopUp_Barcode.IsEnabled = False
                PopUp_Compra.IsEnabled = False
                PopUp_Stock.IsEnabled = False
                PopUp_Tag.IsEnabled = False
                PopUp_Stock.IsEnabled = False
                IconoSelector.IsEnabled = False
                ColorSelector.IsEnabled = False
                PopUp_Check_Barra.IsEnabled = False
            Case TiposItems.Producto
                PopUp_Title.Text = "Editar producto - " & ProductSelected
                IconoSelector.IsEnabled = False
                PopUp_Check_Barra.IsEnabled = False
        End Select

        If Popup_Product.Visibility = Visibility.Hidden Then
            Popup_Product.Visibility = Visibility.Visible
        Else
            Popup_Product.Visibility = Visibility.Hidden
        End If
    End Sub

    Function GetCategoryIndexFromSelector(catid As Integer) As Integer
        Dim tempindex As Integer = 0
        For i = 0 To CategorySelector.Items.Count - 1
            If CategorySelector.Items(i).ToString.Contains(catid) Then
                tempindex = i
                Exit For
            End If
        Next
        Return tempindex
    End Function

    Function GetColorIndexFromSelector(name As String) As Integer
        Dim tempindex As Integer = 0
        For i = 0 To ColorSelector.Items.Count - 1
            If ColorSelector.Items(i).ToString.Contains(name) Then
                tempindex = i
                Exit For
            End If
        Next
        Return tempindex
    End Function

    Function GetIconIndexFromSelector(name As String) As Integer
        Dim tempindex As Integer = 0
        For i = 0 To IconoSelector.Items.Count - 1
            If IconoSelector.Items(i).ToString.Contains(name) Then
                tempindex = i
                Exit For
            End If
        Next
        Return tempindex
    End Function

    Private Sub DelItem_MouseUp(sender As Object, e As MouseButtonEventArgs) Handles DelItem.MouseUp
        Popup_ProductPopup_DelConfirm.Visibility = Visibility.Visible
    End Sub

    Private Sub Popup_ProductPopup_DelConfirm_Close_MouseUp(sender As Object, e As MouseButtonEventArgs) Handles Popup_ProductPopup_DelConfirm_Close.MouseUp
        Popup_ProductPopup_DelConfirm.Visibility = Visibility.Hidden
    End Sub

    Private Sub Popup_ProductPopup_DelConfirm_Cancel_MouseUp(sender As Object, e As MouseButtonEventArgs) Handles Popup_ProductPopup_DelConfirm_Cancel.MouseUp
        Popup_ProductPopup_DelConfirm.Visibility = Visibility.Hidden
    End Sub

    Private Sub Popup_ProductPopup_DelConfirm_Aceptar_MouseUp(sender As Object, e As MouseButtonEventArgs) Handles Popup_ProductPopup_DelConfirm_Aceptar.MouseUp
        Select Case ItemType
            Case TiposItems.Categoria
                AMPOS.DeleteCategory(CategorySelected)
                DelItemVista(CategorySelected)
            Case TiposItems.Modificacion
                AMPOS.DeleteModifier(ModSelected)
                DelItemVista(ModSelected)
            Case TiposItems.Producto
                AMPOS.DeleteItem(ProductSelected)
                DelItemVista(ProductSelected)
        End Select
        Popup_ProductPopup_DelConfirm.Visibility = Visibility.Hidden
    End Sub

    Function DelItemVista(tag As Integer) As Integer
        Dim todel As Integer = -1
        For Each sub_child As Border In Grid_Prods.Children
            If sub_child.Tag = tag Then
                todel = Grid_Prods.Children.IndexOf(sub_child)
                Exit For
            End If
        Next

        Try
            Grid_Prods.Children.RemoveAt(todel)
        Catch ex As Exception
            LogError(ex)
        End Try

        Return todel
    End Function
End Class
