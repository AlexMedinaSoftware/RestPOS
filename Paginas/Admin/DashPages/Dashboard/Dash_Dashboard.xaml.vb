Imports LiveCharts
Imports LiveCharts.Defaults
Imports LiveCharts.Wpf

Class Dash_Dashboard

    Private Sub Dash_Dashboard_Loaded(sender As Object, e As RoutedEventArgs) Handles Me.Loaded
        Dim a As New AxesCollection From {
            New Axis With {
            .Position = AxisPosition.LeftBottom,
            .ShowLabels = False
            }
        }
        Dim b As New AxesCollection From {
            New Axis With {
            .Position = AxisPosition.RightTop,
            .ShowLabels = False,
            .MinValue = 0
            }
        }



        Chrt_GananciasTotales.AxisX = a
        Chrt_GananciasTotales.AxisY = b
        Chrt_Propinas.AxisX = a
        Chrt_Propinas.AxisY = b
        Chrt_Ventas.AxisX = a
        Chrt_Ventas.AxisY = b
        Chrt_Efectivo.AxisX = a
        Chrt_Efectivo.AxisY = b
        Chrt_TBK.AxisX = a
        Chrt_TBK.AxisY = b
        Chrt_Transferencia.AxisX = a
        Chrt_Transferencia.AxisY = b
        CargarVentasEnChart(GetTickets(False, False))
        CargarPropinasEnChart(GetTickets(False, False))
        CargarTotalEnChart(GetTickets(False, False))
        CargarVentasCatEnChart(GetTickets(False, False), Chrt_Efectivo, Lbl_Total_Efectivo, TiposDePago.Efectivo)
        CargarVentasCatEnChart(GetTickets(False, False), Chrt_TBK, Lbl_Total_TBK, TiposDePago.TBK)
        CargarVentasCatEnChart(GetTickets(False, False), Chrt_Transferencia, Lbl_Total_Transferencia, TiposDePago.Transferencia)
    End Sub

    Sub CargarVentasEnChart(lista As List(Of MainContext.Ticket))
        Try
            Dim valores As New ChartValues(Of ObservableValue)
            Dim total As New Long
            If Not lista Is Nothing Then
                For Each item In lista
                    total += item.Total
                    valores.Add(New ObservableValue(item.Total / 1000))
                Next
                Lbl_Total_GananciasTotales.Text = FormatCurrency(total)
                Chrt_GananciasTotales.Series = New SeriesCollection From {
                    New LineSeries With {
                        .Values = valores
                    }
                }
            Else
                LogError("Nothing")
            End If
        Catch ex As Exception
            LogError(ex.Message)
        End Try
    End Sub

    Sub CargarTotalEnChart(lista As List(Of MainContext.Ticket))
        Try
            Dim valores As New ChartValues(Of ObservableValue)
            Dim total As New Long
            If Not lista Is Nothing Then
                valores.Add(New ObservableValue(0))
                For Each item In lista
                    total += item.Total + item.Propina
                    valores.Add(New ObservableValue((item.Total + item.Propina) / 1000))
                Next
                Lbl_Total_Ventas.Text = FormatCurrency(total)
                Chrt_Ventas.Series = New SeriesCollection From {
                    New LineSeries With {
                        .Values = valores
                    }
                }
            Else
                LogError("Nothing")
            End If
        Catch ex As Exception
            LogError(ex.Message)
        End Try
    End Sub

    Sub CargarPropinasEnChart(lista As List(Of MainContext.Ticket))
        Try
            Dim valores As New ChartValues(Of ObservableValue)
            Dim total As New Long
            If Not lista Is Nothing Then
                valores.Add(New ObservableValue(0))
                For Each item In lista
                    total += item.Propina
                    valores.Add(New ObservableValue(item.Propina / 1000))
                Next
                Lbl_Total_Propinas.Text = FormatCurrency(total)
                Chrt_Propinas.Series = New SeriesCollection From {
                    New LineSeries With {
                        .Values = valores
                    }
                }
            Else
                LogError("Nothing")
            End If
        Catch ex As Exception
            LogError(ex.Message)
        End Try
    End Sub

    Shared Sub CargarVentasCatEnChart(lista As List(Of MainContext.Ticket), chart As CartesianChart, lbl As TextBlock, tipoPago As Integer)
        Try
            Dim valores As New ChartValues(Of ObservableValue)
            Dim total As New Long
            If Not lista Is Nothing Then
                If Not chart Is Nothing Then
                    If Not lbl Is Nothing Then
                        valores.Add(New ObservableValue(0))
                        For Each item In lista
                            If item.PaidType = tipoPago Then
                                total += item.Total + item.Propina
                                valores.Add(New ObservableValue((item.Total + item.Propina) / 1000))
                            Else
                                valores.Add(New ObservableValue(0))
                            End If
                        Next
                        lbl.Text = FormatCurrency(total)
                        chart.Series = New SeriesCollection From {
                    New LineSeries With {
                        .Values = valores
                    }
                }
                    Else
                        LogError("Nothing")
                    End If
                End If
            End If
        Catch ex As Exception
            LogError(ex.Message)
        End Try
    End Sub

End Class
