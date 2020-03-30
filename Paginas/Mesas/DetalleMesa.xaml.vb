Class DetalleMesa

    Private modMesasActive As Boolean = False

    Private Sub BackKey_MouseUp(sender As Object, e As MouseButtonEventArgs) Handles BackKey.MouseUp
        PaginaActual = Page_Mesas
    End Sub

    Private Sub DetalleMesa_Loaded(sender As Object, e As RoutedEventArgs) Handles Me.Loaded
        AjustarEscalaProductos()
        ListaPedido.Items.Clear()
        ListaPedido.BringIntoView()
        LoadCats()
        LoadPedido(CodigoMesaActual)
        Cargar_Mod_Cantidad()
        Cargar_Mod_Precio()
        CalcularTotal()
        NombreTrabajador.Content = NombreTrabajadorActual
        ActualizarMesa(CodigoMesaActual)
        Productos.Children.Clear()
        For Each item In GetItems(1)
            AddProduct(item.Name, Productos, item.BuyPrice, item.Id, item.BtnColor)
        Next
    End Sub

    Sub SelectedMod(tag As String, Optional unselect As Boolean = False)
        Dim Mods() As Object = {Mod_Cantidad, Mod_Detalle, Mod_Modificar, Mod_Precio, Mod_Tiempo}
        If unselect Then
            For Each Mod_ As Grid In Mods
                Mod_.Style = GetResource("HoverActions")
            Next
            ModSelected = String.Empty
        Else
            For Each Mod_ As Grid In Mods
                If Mod_.Tag = tag Then
                    Mod_.Style = GetResource("SelectActions")
                Else
                    Mod_.Style = GetResource("HoverActions")
                End If
            Next
            ModSelected = tag
        End If
    End Sub

    Private Sub Mod_Cantidad_MouseUp(sender As Object, e As MouseButtonEventArgs) Handles Mod_Cantidad.MouseUp
        UnSelectAll()
        SelectedMod(sender.Tag)
    End Sub

    Private Sub Mod_Detalle_MouseUp(sender As Object, e As MouseButtonEventArgs) Handles Mod_Detalle.MouseUp
        UnSelectAll()
        SelectedMod(sender.Tag)
    End Sub

    Private Sub Mod_Modificar_MouseUp(sender As Object, e As MouseButtonEventArgs) Handles Mod_Modificar.MouseUp
        UnSelectAll()
        SelectedMod(sender.Tag)
    End Sub

    Private Sub Mod_Precio_MouseUp(sender As Object, e As MouseButtonEventArgs) Handles Mod_Precio.MouseUp
        UnSelectAll()
        SelectedMod(sender.Tag)
    End Sub

    Private Sub Mod_Tiempo_MouseUp(sender As Object, e As MouseButtonEventArgs) Handles Mod_Tiempo.MouseUp
        UnSelectAll()
        SelectedMod(sender.Tag)
    End Sub

    Sub UnSelectAll()
        SelectedMod("", True)
        PopUpQnty.IsOpen = False
        PopUpPrice.IsOpen = False
        PopUpModificar.IsOpen = False
    End Sub

    Private Sub DetalleMesa_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.Key = 13 Then
            UnSelectAll()
        End If
    End Sub

    Private Sub ListaPedido_BeginningEdit(sender As Object, e As DataGridBeginningEditEventArgs) Handles ListaPedido.BeginningEdit
        e.Cancel = True
    End Sub

    Private Sub PopUpQnty_Closed(sender As Object, e As EventArgs) Handles PopUpQnty.Closed
        ModSelected = ""
        UnSelectAll()
    End Sub

    Private Sub PopUpPrice_Closed(sender As Object, e As EventArgs) Handles PopUpPrice.Closed
        ModSelected = ""
        UnSelectAll()
    End Sub

    Private Sub PopUpModificar_Closed(sender As Object, e As EventArgs) Handles PopUpModificar.Closed
        ModSelected = ""
        UnSelectAll()
    End Sub

    Private Sub PopUpModificarOK_MouseUp(sender As Object, e As MouseButtonEventArgs) Handles PopUpModificarOK.MouseUp
        Dim extras As String = " +"
        Dim extraprice As Long = 0
        Dim selected As New List(Of MainContext.Modifier)
        For Each grid As Grid In Page_Mesas_Detalle.PopUpModificarGrid.Children
            For Each item In grid.Children
                If item.GetType.ToString = "System.Windows.Controls.Border" Then
                    Dim border_ As Border = item
                    If border_.Background.ToString(cultureChile) = GetResource("Color1").ToString Then
                        selected.Add(GetModifierObject(border_.Tag))
                    End If
                End If
            Next
        Next

        For Each item As MainContext.Modifier In selected
            extras &= item.Name & "-"
            extraprice += CLng(item.Price)
        Next
        extras = extras.TrimEnd("-")
        Add_Producto_Mod_Modificar(extras, extraprice)
        PopUpModificar.IsOpen = False
        UnSelectAll()
        Mod_Modificar_Unselect()
    End Sub

    Private Sub PopUpModificarCancelar_MouseUp(sender As Object, e As MouseButtonEventArgs) Handles PopUpModificarCancelar.MouseUp
        UnSelectAll()
        Mod_Modificar_Unselect()
    End Sub

    Private Sub SendToBar_MouseUp(sender As Object, e As MouseButtonEventArgs) Handles SendToBar.MouseUp
        ImprimirVoucherPedido(GetTicketObject(GetTicketID(CodigoMesaActual)), FiltrarItemsBar(GetTicketItems(GetTicketID(CodigoMesaActual))), Lugares.Bar)
    End Sub

    Private Sub Logo_MouseUp(sender As Object, e As MouseButtonEventArgs) Handles Logo.MouseUp
        PaginaActual = Page_Login
    End Sub

    Private Sub SendToKitchen_MouseUp(sender As Object, e As MouseButtonEventArgs) Handles SendToKitchen.MouseUp
        ImprimirVoucherPedido(GetTicketObject(GetTicketID(CodigoMesaActual)), FiltrarItemsCocina(GetTicketItems(GetTicketID(CodigoMesaActual))), Lugares.Cocina)
    End Sub

    Private Sub SendAll_MouseUp(sender As Object, e As MouseButtonEventArgs) Handles SendAll.MouseUp
        ImprimirPedido(GetTicketObject(GetTicketID(CodigoMesaActual)))
        'ImprimirVoucherPedido(GetTicketObject(GetTicketID(CodigoMesaActual)), GetTicketItems(GetTicketID(CodigoMesaActual)), -1)
    End Sub

    Private Sub DelItem_MouseUp(sender As Object, e As MouseButtonEventArgs) Handles DelItem.MouseUp
        For Each item As Item_Pedido In ListaPedido.SelectedItems
            If Not DelItemFromTicket(item.P_Item_ID) Then
                LogError("Error eliminando el producto")
            End If
        Next
        LoadPedido(CodigoMesaActual)
        CalcularTotal()
    End Sub

    Private Sub Pay_MouseUp(sender As Object, e As MouseButtonEventArgs) Handles Pay.MouseUp
        Page_MainWindow.MostrarPopUpPago(GetTicketObject(GetTicketID(CodigoMesaActual)), ListaPedido)
    End Sub

    Private Sub SearchKey_MouseUp(sender As Object, e As MouseButtonEventArgs) Handles SearchKey.MouseUp
        TextBoxBusqueda.Text = ""
        PopUpSearch.IsOpen = True
        TextBoxBusqueda.Focus()
    End Sub

    Private Sub TextBoxBusqueda_TextChanged(sender As Object, e As TextChangedEventArgs) Handles TextBoxBusqueda.TextChanged
        Page_Mesas_Detalle.Productos.Children.Clear()
        For Each item In GetItems(TextBoxBusqueda.Text)
            AddProduct(item.Name, Page_Mesas_Detalle.Productos, item.BuyPrice, item.Id, item.BtnColor)
        Next
    End Sub

    Private Sub TextBoxBusqueda_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBoxBusqueda.KeyDown
        If e.Key = Key.Enter Then
            PopUpSearch.IsOpen = False
        End If
    End Sub

    Private Sub ListaPedido_MouseDoubleClick(sender As Object, e As MouseButtonEventArgs) Handles ListaPedido.MouseDoubleClick
        Try
            Dim row_ As DataGridRow = ListaPedido.ItemContainerGenerator.ContainerFromIndex(ListaPedido.SelectedIndex)
            Dim a As Item_Pedido = ListaPedido.Items(ListaPedido.SelectedIndex)
            If a.P_Item_Nombre.Contains("+") Or a.P_Item_Nombre.Length > 30 Then
                If row_.DetailsVisibility = Visibility.Visible Then
                    row_.DetailsVisibility = Visibility.Collapsed
                Else
                    row_.DetailsVisibility = Visibility.Visible
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub btn_Mesa_MouseUp(sender As Object, e As MouseButtonEventArgs) Handles btn_Mesa.MouseUp
        If modMesasActive Then
            LoadCats()
            modMesasActive = False
        Else
            LoadModMesas()
            modMesasActive = True
        End If
    End Sub

    Sub ActualizarMesa(idmesa As Integer)
        CodigoMesaActual = idmesa
        LabelMesa.Content = GetTableObject(CodigoMesaActual).Name
    End Sub

End Class