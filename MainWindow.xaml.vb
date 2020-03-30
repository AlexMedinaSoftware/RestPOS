Imports System.Globalization
Imports System.Threading
Imports System.Windows.Media.Animation
Imports System.Windows.Threading

Class MainWindow

    Dim Timer As DispatcherTimer = New DispatcherTimer()
    Private TicketIDActual As Integer
    Private TicketTipoPago As TiposDePago = TiposDePago.Efectivo
    Private withPropina As Boolean = False

    Private Sub PopupClose_MouseLeftButtonDown(sender As Object, e As MouseButtonEventArgs) Handles PopupClose.MouseLeftButtonDown
        PopupWindow.IsOpen = False
    End Sub

    Private Sub ShutDown_btn_MouseUp(sender As Object, e As MouseButtonEventArgs) Handles ShutDown_btn.MouseUp
        ShutDownRestAPP()
    End Sub

    Private Sub MainWindow_Initialized(sender As Object, e As EventArgs) Handles Me.Initialized
        Windows.Application.Current.MainWindow = Me
    End Sub

    Private Sub MainWindow_Loaded(sender As Object, e As RoutedEventArgs) Handles Me.Loaded
        PaginaActual = Page_Login
        Timer.Interval = TimeSpan.FromSeconds(1)
        AddHandler Timer.Tick, AddressOf Timer_Tick
        Timer.Start()
    End Sub

    Private Sub Timer_Tick(sender As Object, e As EventArgs)
        Dim HoraCompleta As String = DateTime.Now.ToLongTimeString
        TextoReloj.Content = HoraCompleta
    End Sub

    Private Sub ShutDown_btn_MouseEnter(sender As Object, e As MouseEventArgs) Handles ShutDown_btn.MouseEnter
        ShutdownIcon.Source = Recursos("PowerShutdownHover")
    End Sub

    Private Sub ShutDown_btn_MouseLeave(sender As Object, e As MouseEventArgs) Handles ShutDown_btn.MouseLeave
        ShutdownIcon.Source = Recursos("PowerShutdown")
    End Sub

    Private Sub TextoReloj_MouseUp(sender As Object, e As MouseButtonEventArgs) Handles TextoReloj.MouseUp
        'FinalizarMesa(CodigoMesaActual)
    End Sub

    Private Sub PCenterBtn_MouseDown(sender As Object, e As MouseButtonEventArgs) Handles PCenterBtn.MouseDown
        PopupWindow.IsOpen = False
    End Sub


    Private Sub PopupPagoClose_MouseDown(sender As Object, e As MouseButtonEventArgs) Handles PopupPagoClose.MouseDown
        PopupPago.IsOpen = False
        PopUpPago_ListaPedido.Items.Clear()
        TicketTipoPago = TiposDePago.Efectivo
        PopUpPago_lblMesa.Text = "Mesa: "
        PopUpPago_lblPropina.Text = "Propina: $0"
        PopUpPago_lblTotal.Text = "Total: $0"
        LoadPedido(GetTicketObject(TicketIDActual).TableId)
    End Sub

    Sub MostrarPopUpPago(ticket As MainContext.Ticket, items As DataGrid)
        If Not (ticket Is Nothing) Then
            TicketIDActual = ticket.Id
            CargarDatos(ticket, items)
            withPropina = False
            lbl_Propina.Text = "Aplicar Propina"
        End If
    End Sub

    Sub CargarDatos(ByRef ticket As MainContext.Ticket, items As DataGrid)
        TicketTipoPago = TiposDePago.Efectivo
        PopUpPago_ListaPedido.Items.Clear()
        Try
            If Not items Is Nothing Then
                If Not ticket Is Nothing Then
                    For Each item In items.Items
                        PopUpPago_ListaPedido.Items.Add(item)
                    Next
                    PopUpPago_lblMesa.Text = "Mesa: " & GetTableName(ticket.TableId)
                    PopUpPago_lblSubtotal.Text = "Subtotal: " & String.Format(cultureChile, "{0:C}", ticket.Total)
                    PopUpPago_lblPropina.Text = "Propina: " & String.Format(cultureChile, "{0:C}", ticket.Propina)
                    PopupPago.IsOpen = True
                End If
            End If
        Catch ex As ArgumentNullException
            LogError("No se encuentra el ticket")
        End Try
        MostrarTotal(ticket)
    End Sub

    Private Sub PopUpPago_ListaPedido_BeginningEdit(sender As Object, e As DataGridBeginningEditEventArgs) Handles PopUpPago_ListaPedido.BeginningEdit
        e.Cancel = True
    End Sub

    Private Sub PopUpPago_AddPropina_MouseUp(sender As Object, e As MouseButtonEventArgs) Handles PopUpPago_AddPropina.MouseUp
        Dim propina As Long
        If withPropina Then
            propina = 0
            withPropina = False
            lbl_Propina.Text = "Aplicar Propina"
        Else
            propina = CalcularPropina(GetTicketObject(GetTicketID(CodigoMesaActual)).Total)
            withPropina = True
            lbl_Propina.Text = "Quitar Propina"
        End If
        PopUpPago_lblPropina.Text = "Propina: " & String.Format(cultureChile, "{0:C}", propina)
        GetTicketObject(GetTicketID(CodigoMesaActual)).Propina = propina
        context.SubmitChanges()
        MostrarTotal(GetTicketObject(TicketIDActual))
    End Sub

    Private Sub PopUpPago_AddDelivery_MouseUp(sender As Object, e As MouseButtonEventArgs) Handles PopUpPago_AddDelivery.MouseUp
        Dim a As New MainContext.TicketsItem With {
            .Name = "Cargo Delivery",
            .Price = 1000,
            .Count = 1,
            .SectorId = -1
        }
        AddItemToTicket(GetTicketObject(TicketIDActual), a)
        LoadPedido(GetTicketObject(TicketIDActual).TableId)
        CargarDatos(GetTicketObject(TicketIDActual), Page_Mesas_Detalle.ListaPedido)
    End Sub

    Sub MostrarTotal(ticket As MainContext.Ticket)
        If Not ticket Is Nothing Then
            PopUpPago_lblTotal.Text = "Total: " & String.Format(cultureChile, "{0:C}", ticket.Total + ticket.Propina)
        End If
    End Sub

    Private Sub PopUpPago_btnEfectivo_MouseUp(sender As Object, e As MouseButtonEventArgs) Handles PopUpPago_btnEfectivo.MouseUp
        GetTicketObject(GetTicketID(CodigoMesaActual)).PaidType = TiposDePago.Efectivo
        TicketTipoPago = TiposDePago.Efectivo
        PopUpPago_lblTipoPago.Text = "Tipo: Efectivo"
    End Sub

    Private Sub PopUpPago_btnTBK_MouseUp(sender As Object, e As MouseButtonEventArgs) Handles PopUpPago_btnTBK.MouseUp
        GetTicketObject(GetTicketID(CodigoMesaActual)).PaidType = TiposDePago.TBK
        TicketTipoPago = TiposDePago.TBK
        PopUpPago_lblTipoPago.Text = "Tipo: Transbank"
    End Sub

    Private Sub PopUpPago_btnTransferencia_MouseUp(sender As Object, e As MouseButtonEventArgs) Handles PopUpPago_btnTransferencia.MouseUp
        GetTicketObject(GetTicketID(CodigoMesaActual)).PaidType = TiposDePago.Transferencia
        TicketTipoPago = TiposDePago.Transferencia
        PopUpPago_lblTipoPago.Text = "Tipo: Transferencia"
    End Sub

    Private Sub PopUpPago_Pay_MouseUp(sender As Object, e As MouseButtonEventArgs) Handles PopUpPago_Pay.MouseUp
        ImprimirPedidoPagado(GetTicketObject(GetTicketID(CodigoMesaActual)))
        PagarTicket(TicketIDActual, GetTicketObject(GetTicketID(CodigoMesaActual)).Propina + GetTicketObject(GetTicketID(CodigoMesaActual)).Total, TicketTipoPago)
        PopupPago.IsOpen = False
        TicketTipoPago = TiposDePago.Efectivo
        PaginaActual = Page_Mesas
    End Sub

    Private Sub PrintRecibo_MouseUp(sender As Object, e As MouseButtonEventArgs) Handles PrintRecibo.MouseUp
        ImprimirPedido(GetTicketObject(GetTicketID(CodigoMesaActual)))
    End Sub

    Private Sub MainWindow_Deactivated(sender As Object, e As EventArgs) Handles Me.Deactivated
        Topmost = False
    End Sub

    Private Sub MainWindow_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        'Topmost = True
    End Sub

    Private Sub MainFrame_OnNavigating(ByVal sender As Object, ByVal e As NavigatingCancelEventArgs)
        Dim ta As New ThicknessAnimation With {
            .Duration = TimeSpan.FromMilliseconds(300),
            .DecelerationRatio = 0.7
        }

        If e.NavigationMode = NavigationMode.[New] Then
            ta.From = New Thickness(2000, 0, -2000, 0)
            ta.To = New Thickness(0, 0, 0, 0)
        ElseIf e.NavigationMode = NavigationMode.Back Then
            ta.From = New Thickness(-2000, 0, 2000, 0)
            ta.To = New Thickness(0, 0, 0, 0)
        End If

        TryCast(e.Content, Page).BeginAnimation(MarginProperty, ta)
    End Sub

    Private _allowDirectNavigation As Boolean = False
    Private _navArgs As NavigatingCancelEventArgs = Nothing
    Private _duration As Duration = New Duration(TimeSpan.FromMilliseconds(300))
    Private ScreenMargin As Double = SystemParameters.PrimaryScreenWidth

    Private Sub frame_Navigating(ByVal sender As Object, ByVal e As NavigatingCancelEventArgs)
        Try
            If GetConfig("AnimacionesActivas") = 1 Then
                ScreenMargin = SystemParameters.PrimaryScreenWidth
                If Content IsNot Nothing AndAlso Not _allowDirectNavigation Then
                    e.Cancel = True
                    _navArgs = e
                    Dim animation0 As ThicknessAnimation = New ThicknessAnimation()
                    animation0.From = New Thickness(0, 0, 0, 0)
                    animation0.[To] = New Thickness(-ScreenMargin, 0, ScreenMargin, 0)
                    animation0.Duration = _duration
                    animation0.DecelerationRatio = 0.7
                    AddHandler animation0.Completed, AddressOf SlideCompleted
                    MainFrame.BeginAnimation(MarginProperty, animation0)
                End If

                _allowDirectNavigation = False
            ElseIf GetConfig("AnimacionesActivas") = 2 Then
                MainFrame_OnNavigating(sender, e)
            End If
        Catch ex As Exception
            LogError(ex)
        End Try
    End Sub

    Private Sub SlideCompleted(ByVal sender As Object, ByVal e As EventArgs)
        _allowDirectNavigation = True

        Select Case _navArgs.NavigationMode
            Case NavigationMode.[New]

                If _navArgs.Uri Is Nothing Then
                    MainFrame.Navigate(_navArgs.Content)
                Else
                    MainFrame.Navigate(_navArgs.Uri)
                End If

            Case NavigationMode.Back
                MainFrame.GoBack()
            Case NavigationMode.Forward
                MainFrame.GoForward()
            Case NavigationMode.Refresh
                MainFrame.Refresh()
        End Select

        Dispatcher.BeginInvoke(DispatcherPriority.Loaded, CType(Function()
                                                                    Dim animation0 As ThicknessAnimation = New ThicknessAnimation With {
                                                                        .From = New Thickness(ScreenMargin, 0, -ScreenMargin, 0),
                                                                        .To = New Thickness(0, 0, 0, 0),
                                                                        .Duration = _duration,
                                                                        .DecelerationRatio = 0.7
                                                                    }
                                                                    MainFrame.BeginAnimation(MarginProperty, animation0)
                                                                End Function, ThreadStart))
    End Sub

    Private Sub MainWindow_SizeChanged(sender As Object, e As SizeChangedEventArgs) Handles Me.SizeChanged
        AjustarEscalaProductos()
    End Sub

    Private Sub MainWindow_StateChanged(sender As Object, e As EventArgs) Handles Me.StateChanged
        AjustarEscalaProductos()
    End Sub


End Class
