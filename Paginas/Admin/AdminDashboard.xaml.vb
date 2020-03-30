Class AdminDashboard

    Enum SubCat
        DashDash = 999911
        DashTotales = 999912
        DashCierre = 999913
        ReportesTickets = 999921
        ReportesHora = 999922
        ReportesDia = 999923
        ReportesSemanal = 999924
        ReportesMensual = 999925
        ReportesProductos = 999926
        ReportesCategorias = 999927
        UsuariosUsuarios = 999931
        ProductosProductos = 999941
        ProductosModificadores = 999942
        ProductosCategorias = 999943
        ProductosPromos = 999944
        MesasMesas = 999951
        ConfigConfig = 999961
    End Enum

    Public Property DashActual As Object
        Get
            Return Dash_Frame.Source
        End Get
        Set(value As Object)
            Dash_Frame.Navigate(value)
        End Set
    End Property

    Dim productsDisplayed As Boolean = False

    Private Sub SeleccionarBoton(btn As Border)
        BtnDash_Config.Style = GetResource("Dash_MainMenu_Unselect")
        BtnDash_Dashboard.Style = GetResource("Dash_MainMenu_Unselect")
        BtnDash_Mesas.Style = GetResource("Dash_MainMenu_Unselect")
        BtnDash_Productos.Style = GetResource("Dash_MainMenu_Unselect")
        BtnDash_Reportes.Style = GetResource("Dash_MainMenu_Unselect")
        BtnDash_Usuarios.Style = GetResource("Dash_MainMenu_Unselect")
        btn.Style = GetResource("Dash_MainMenu_Select")
    End Sub

    Private Sub SeleccionarSubBoton(tag_ As String)
        For Each item As Border In SubMenuGrid.Children
            If Not item.Tag = -1 Then
                If item.Tag = tag_ Then
                    Dim lbl As TextBlock = item.Child
                    lbl.Foreground = GetResource("Color1")
                    item.Child = lbl
                    item.Style = GetResource("Dash_SubMenu_Select")
                Else
                    Dim lbl As TextBlock = item.Child
                    lbl.Foreground = GetResource("DarkColor2")
                    item.Child = lbl
                    item.Style = GetResource("Dash_SubMenu_Unselect")
                End If
            End If
        Next
    End Sub

    Private Sub BtnDash_Config_MouseUp(sender As Object, e As MouseButtonEventArgs) Handles BtnDash_Config.MouseUp
        SeleccionarBoton(sender)
        ClearSubMenu()
        AddSubCat("Configuracion", SubCat.ConfigConfig, True)
        DashActual = Page_Dash_Config
    End Sub

    Private Sub BtnDash_Dashboard_MouseUp(sender As Object, e As MouseButtonEventArgs) Handles BtnDash_Dashboard.MouseUp
        SeleccionarBoton(sender)
        ClearSubMenu()
        AddSubCat("Dashboard", SubCat.DashDash, True)
        AddSubCat("Cerrar Dia", SubCat.DashCierre)
        DashActual = Page_Dash_Dashboard
    End Sub

    Private Sub BtnDash_Mesas_MouseUp(sender As Object, e As MouseButtonEventArgs) Handles BtnDash_Mesas.MouseUp
        SeleccionarBoton(sender)
        ClearSubMenu()
        AddSubCat("Mesas", SubCat.MesasMesas, True)
        DashActual = Page_Dash_Mesas
    End Sub

    Private Sub BtnDash_Productos_MouseUp(sender As Object, e As MouseButtonEventArgs) Handles BtnDash_Productos.MouseUp
        SeleccionarBoton(sender)
        ClearSubMenu()
        AddSubCat("Categorias", SubCat.ProductosCategorias, True)
        AddSubCat("Modificadores", SubCat.ProductosModificadores)
        AddSubCat("Promociones", SubCat.ProductosPromos)
        AddSubCat("Productos", SubCat.ProductosProductos)
        Page_Dash_Detalle_Productos.ShowCategories(GetCategories)
    End Sub

    Private Sub BtnDash_Reportes_MouseUp(sender As Object, e As MouseButtonEventArgs) Handles BtnDash_Reportes.MouseUp
        SeleccionarBoton(sender)
        ClearSubMenu()
        AddSubCat("Tickets", SubCat.ReportesTickets, True)
        AddSubCat("Reporte Hora", SubCat.ReportesHora)
        AddSubCat("Reporte Dia", SubCat.ReportesDia)
        AddSubCat("Reporte Semanal", SubCat.ReportesSemanal)
        AddSubCat("Reporte Mensual", SubCat.ReportesMensual)
        AddSubCat("Productos", SubCat.ReportesProductos)
        AddSubCat("Categorias", SubCat.ReportesCategorias)
    End Sub

    Private Sub BtnDash_Usuarios_MouseUp(sender As Object, e As MouseButtonEventArgs) Handles BtnDash_Usuarios.MouseUp
        SeleccionarBoton(sender)
        ClearSubMenu()
        AddSubCat("Usuarios", SubCat.UsuariosUsuarios, True)
    End Sub

    Private Sub BtnDash_Salir_MouseUp(sender As Object, e As MouseButtonEventArgs) Handles BtnDash_Salir.MouseUp
        PaginaActual = Page_Login
    End Sub

    Sub ClearSubMenu()
        SubMenuGrid.Children.Clear()
        Dim Card As Border = New Border() With {
            .Height = 40,
            .Tag = -1
        }
        SubMenuGrid.Children.Add(Card)
    End Sub

    Sub AddSubCat(nombre As String, type As SubCat, Optional selected As Boolean = False)
        Dim Estilo As Object
        Dim LblEstilo As Object
        If selected Then
            Estilo = GetResource("Dash_SubMenu_Select")
            LblEstilo = GetResource("Color1")
        Else
            Estilo = GetResource("Dash_SubMenu_Unselect")
            LblEstilo = GetResource("DarkColor2")
        End If

        Dim Name_ As TextBlock = New TextBlock() With {
            .TextAlignment = TextAlignment.Center,
            .VerticalAlignment = VerticalAlignment.Center,
            .HorizontalAlignment = HorizontalAlignment.Left,
            .Margin = New Thickness(20, 0, 5, 0),
            .TextWrapping = TextWrapping.Wrap,
            .Text = nombre,
            .FontSize = 15,
            .IsHitTestVisible = False,
            .Foreground = LblEstilo,
            .FontFamily = New FontFamily("Roboto")
        }

        Dim Card As Border = New Border() With {
            .Height = 40,
            .Tag = type,
            .Style = Estilo
        }

        Card.Child = Name_
        AddHandler Card.MouseDown, AddressOf SubMenu_Click
        SubMenuGrid.Children.Add(Card)
    End Sub

    Private Sub SubMenu_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        Dim border_ As Border = sender
        Try
            SeleccionarSubBoton(border_.Tag)
        Catch ex As Exception
        End Try
        Select Case border_.Tag
            Case SubCat.DashDash
                DashActual = Page_Dash_Dashboard
            Case SubCat.DashCierre
                CloseDay()
            Case SubCat.ProductosProductos
                LoadCatsInProductsMenu()
                Page_Dash_Detalle_Productos.ShowProducts(GetItems)
            Case SubCat.ProductosCategorias
                Page_Dash_Detalle_Productos.ShowCategories(GetCategories)
            Case SubCat.ProductosModificadores
                Page_Dash_Detalle_Productos.ShowMods(GetModifiers)
            Case SubCat.ReportesTickets
                DashActual = Page_Dash_Reportes_Items
        End Select
    End Sub

    Private Sub AdminDashboard_Loaded(sender As Object, e As RoutedEventArgs) Handles Me.Loaded
        SeleccionarBoton(BtnDash_Dashboard)
        ClearSubMenu()
        AddSubCat("Dashboard", SubCat.DashDash, True)
        AddSubCat("Cerrar Dia", SubCat.DashCierre)
        DashActual = Page_Dash_Dashboard
    End Sub

    Sub LoadCatsInProductsMenu()
        ClearSubMenu()
        AddSubCat("Categorias", SubCat.ProductosCategorias)
        AddSubCat("Modificadores", SubCat.ProductosModificadores)
        AddSubCat("Promociones", SubCat.ProductosPromos)
        AddSubCat("Productos", SubCat.ProductosProductos, True)
        For Each cat As MainContext.Category In GetCategories()
            Dim Estilo As Object
            Dim LblEstilo As Object
            Estilo = GetResource("Dash_SubMenu_Unselect")
            LblEstilo = GetResource("DarkColor2")

            Dim Name_ As TextBlock = New TextBlock() With {
            .TextAlignment = TextAlignment.Center,
            .VerticalAlignment = VerticalAlignment.Center,
            .HorizontalAlignment = HorizontalAlignment.Left,
            .Margin = New Thickness(30, 0, 5, 0),
            .TextWrapping = TextWrapping.Wrap,
            .Text = cat.Name,
            .FontSize = 15,
            .IsHitTestVisible = False,
            .Foreground = LblEstilo,
            .FontFamily = New FontFamily("Roboto")
        }

            Dim Card As Border = New Border() With {
            .Height = 40,
            .Tag = cat.Id,
            .Style = Estilo
        }

            Card.Child = Name_
            AddHandler Card.MouseDown, AddressOf CategorySubMenu_Click
            SubMenuGrid.Children.Add(Card)
        Next
    End Sub

    Private Sub CategorySubMenu_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        Dim border_ As Border = sender
        Dim catID As Integer = border_.Tag
        SeleccionarSubBoton(catID)
        Page_Dash_Detalle_Productos.ShowProducts(GetItems(catID))
    End Sub

End Class