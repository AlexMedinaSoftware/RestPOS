Imports System.Data
Imports System.Threading
Imports Microsoft.Reporting.WebForms

Module VouchersModule

    Enum Lugares
        Cocina = 1
        Bar = 2
    End Enum

    Function CategoriasCocina() As HashSet(Of String)
        Dim temp As New HashSet(Of String)
        Dim cats As List(Of MainContext.Category) = GetCategories()
        For Each item In cats
            If item.IsLiquid = 0 Then
                temp.Add(item.Id)
            End If
        Next
        Return temp
    End Function

    Function CategoriasBar() As HashSet(Of String)
        Dim temp As New HashSet(Of String)
        Dim cats As List(Of MainContext.Category) = GetCategories()
        For Each item In cats
            If item.IsLiquid = 1 Then
                temp.Add(item.Id)
            End If
        Next
        Return temp
    End Function

    Sub ImprimirVoucherPedido(ticket As MainContext.Ticket, items As List(Of MainContext.TicketsItem), lugar As Lugares)
        Dim tr As Thread = New Thread(Sub() Thread_ImprimirVoucherPedido(ticket, items, lugar))
        tr.Start()
    End Sub

    Sub ImprimirPedido(ticket As MainContext.Ticket)
        Dim tr As Thread = New Thread(Sub() Thread_ImprimirPedido(ticket))
        tr.Start()
    End Sub

    Sub ImprimirVoucherCierre(tickets As List(Of MainContext.Ticket), cierre As MainContext.Cierre)
        Dim tr As Thread = New Thread(Sub() Thread_ImprimirVoucherCierre(tickets, cierre))
        tr.Start()
    End Sub

    Sub Thread_ImprimirVoucherCierre(tickets As List(Of MainContext.Ticket), cierre As MainContext.Cierre)
        Dim lr As New LocalReport
        lr.ReportPath = "Cierre.rdlc"
        lr.DataSources.Clear()
        Dim dt As DataTable = New VoucherCierre.VentasDataTable
        Dim row As DataRow
        If Not tickets Is Nothing Then
            If tickets.Any Then
                For Each item In tickets
                    row = dt.NewRow
                    row("Propina") = item.Propina
                    row("Venta") = item.Total
                    row("tipoPago") = item.PaidType
                    row("Ticket") = item.Id
                    row("Total") = item.Propina + item.Total
                    dt.Rows.Add(row)
                Next
                lr.SetParameters(New ReportParameter("ReportCierreID", "ID: " & cierre.Id))
                lr.SetParameters(New ReportParameter("ReportFecha", "Fecha: " & cierre.Fecha))
                lr.SetParameters(New ReportParameter("ReportTotalVentas", cierre.Total))
                lr.SetParameters(New ReportParameter("ReportPropina", cierre.Propina))
                lr.SetParameters(New ReportParameter("ReportTotal", cierre.Propina + cierre.Total))
                Dim reportSource As New ReportDataSource(dt.TableName, dt)
                lr.DataSources.Clear()
                lr.DataSources.Add(reportSource)
                PrintModule.print_microsoft_report(lr, False, GetConfig("PrinterDef"))
            End If
        End If
        dt.Dispose()
        lr.Dispose()
    End Sub

    Sub Thread_ImprimirVoucherPedido(ticket As MainContext.Ticket, items As List(Of MainContext.TicketsItem), lugar As Lugares)
        Dim lr As New LocalReport
        lr.ReportPath = "Pedido.rdlc"
        lr.DataSources.Clear()
        Dim dt As DataTable = New VoucherPreparacion.PedidoDataTable
        Dim row As DataRow
        If Not items Is Nothing Then
            If items.Any Then
                For Each item In items
                    row = dt.NewRow
                    row("nombre") = item.Name
                    row("cantidad") = item.Count
                    dt.Rows.Add(row)
                Next
                lr.SetParameters(New ReportParameter("ReportTable", "Mesa: " & GetTableObject(ticket.TableId).Name))
                lr.SetParameters(New ReportParameter("ReportTicketID", "Ticket: " & ticket.Id))
                Select Case lugar
                    Case Lugares.Bar
                        lr.SetParameters(New ReportParameter("ReportSector", "BAR"))
                    Case Lugares.Cocina
                        lr.SetParameters(New ReportParameter("ReportSector", "COCINA"))
                    Case Else
                        lr.SetParameters(New ReportParameter("ReportSector", "TODOS"))
                End Select
                Dim reportSource As New ReportDataSource(dt.TableName, dt)
                lr.DataSources.Clear()
                lr.DataSources.Add(reportSource)
                PrintModule.print_microsoft_report(lr, False, GetConfig("PrinterDef"))
            End If
        End If
        dt.Dispose()
        lr.Dispose()
    End Sub

    Function FiltrarItemsBar(items As List(Of MainContext.TicketsItem)) As List(Of MainContext.TicketsItem)
        Dim tempList As New List(Of MainContext.TicketsItem)
        For Each item In items
            If CategoriasBar.Contains(item.SectorId) And item.IsSended = 0 Then
                item.IsSended = True
                tempList.Add(item)
            End If
        Next
        context.SubmitChanges()
        Return tempList
    End Function

    Function FiltrarItemsCocina(items As List(Of MainContext.TicketsItem)) As List(Of MainContext.TicketsItem)
        Dim tempList As New List(Of MainContext.TicketsItem)
        For Each item In items
            If CategoriasCocina.Contains(item.SectorId) And item.IsSended = 0 Then
                item.IsSended = True
                tempList.Add(item)
            End If
        Next
        context.SubmitChanges()
        Return tempList
    End Function

    Sub SetEnviado(item As MainContext.TicketsItem, estado As Boolean)
        item.IsSended = estado
        context.SubmitChanges()
    End Sub

    Sub Thread_ImprimirPedido(ticket As MainContext.Ticket)
        Dim lr As New LocalReport
        lr.ReportPath = "Recibo.rdlc"
        lr.DataSources.Clear()
        Dim dt As DataTable = New VoucherRecibo.ItemsDataTable
        Dim row As DataRow
        If Not ticket Is Nothing Then
            If GetTicketItems(ticket.Id).Any Then
                For Each item In GetTicketItems(ticket.Id)
                    row = dt.NewRow
                    row("nombre") = item.Name
                    row("cantidad") = item.Count
                    row("total") = String.Format(cultureChile, "{0:C}", item.Price * item.Count)
                    dt.Rows.Add(row)
                Next
                lr.SetParameters(New ReportParameter("ReportTable", "Mesa: " & GetTableObject(ticket.TableId).Name))
                lr.SetParameters(New ReportParameter("ReportTicketID", "Ticket: " & ticket.Id))
                lr.SetParameters(New ReportParameter("ReportSubTotal", String.Format(cultureChile, "{0:C}", ticket.Total)))
                lr.SetParameters(New ReportParameter("ReportPropina", String.Format(cultureChile, "{0:C}", CalcularPropina(ticket.Total))))
                lr.SetParameters(New ReportParameter("ReportTotal", String.Format(cultureChile, "{0:C}", ticket.Total + CalcularPropina(ticket.Total))))
                lr.SetParameters(New ReportParameter("ReportTipoDePago", "BancoEstado" & vbNewLine & "Carlos Olivares Loyola" & vbNewLine & "Cta Rut: 19039257" & vbNewLine & "Rut: 19039257-0" & vbNewLine & "pagos@simplefastfood.cl"))
                Dim reportSource As New ReportDataSource(dt.TableName, dt)
                lr.DataSources.Clear()
                lr.DataSources.Add(reportSource)
                PrintModule.print_microsoft_report(lr, False, GetConfig("PrinterDef"))
            End If
        End If
        dt.Dispose()
        lr.Dispose()
    End Sub

    Sub ImprimirPedidoPagado(ticket As MainContext.Ticket)
        Dim lr As New LocalReport
        lr.ReportPath = "Recibo.rdlc"
        lr.DataSources.Clear()
        Dim dt As DataTable = New VoucherRecibo.ItemsDataTable
        Dim row As DataRow
        If Not ticket Is Nothing Then
            If GetTicketItems(ticket.Id).Any Then
                For Each item In GetTicketItems(ticket.Id)
                    row = dt.NewRow
                    row("nombre") = item.Name
                    row("cantidad") = item.Count
                    row("total") = String.Format(cultureChile, "{0:C}", item.Price * item.Count)
                    dt.Rows.Add(row)
                Next
                lr.SetParameters(New ReportParameter("ReportTable", "Mesa: " & GetTableObject(ticket.TableId).Name))
                lr.SetParameters(New ReportParameter("ReportTicketID", "Ticket: " & ticket.Id))
                lr.SetParameters(New ReportParameter("ReportSubTotal", String.Format(cultureChile, "{0:C}", ticket.Total)))
                lr.SetParameters(New ReportParameter("ReportPropina", String.Format(cultureChile, "{0:C}", ticket.Propina)))
                lr.SetParameters(New ReportParameter("ReportTotal", String.Format(cultureChile, "{0:C}", ticket.Total + ticket.Propina)))

                Select Case ticket.PaidType
                    Case TiposDePago.Efectivo
                        lr.SetParameters(New ReportParameter("ReportTipoDePago", "[Pagado Efectivo]"))
                    Case TiposDePago.TBK
                        lr.SetParameters(New ReportParameter("ReportTipoDePago", "[Pagado Transbank]"))
                    Case TiposDePago.Transferencia
                        lr.SetParameters(New ReportParameter("ReportTipoDePago", "[Pagado Transferencia]"))
                    Case Else
                        lr.SetParameters(New ReportParameter("ReportTipoDePago", "[Pagado Efectivo]"))
                End Select

                Dim reportSource As New ReportDataSource(dt.TableName, dt)
                lr.DataSources.Clear()
                lr.DataSources.Add(reportSource)
                PrintModule.print_microsoft_report(lr, False, GetConfig("PrinterDef"))
            End If
        End If
        dt.Dispose()
        lr.Dispose()
    End Sub

End Module
