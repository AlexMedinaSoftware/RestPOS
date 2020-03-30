Imports System.ComponentModel

Class Dash_Reportes_Items

    Private Structure TempTicket
        Dim Id As Integer
        Dim OpenTime As String
        Dim CloseTime As String
        Dim TableId As String
        Dim ItemsCount As Integer
        Dim Total As String
        Dim Propina As String
        Dim Paid As String
        Dim PaidType As String
    End Structure

    Dim background_ As New BackgroundWorker

    Private Sub CargarTickets(sender As Object, e As DoWorkEventArgs)
        'Dim tempList As New List(Of TempTicket)
        'For Each item As MainContext.Ticket In GetAllTickets()
        '    tempList.Add(New TempTicket With {
        '        .CloseTime = item.CloseTime,
        '        .Id = item.Id,
        '        .ItemsCount = IIf(item.ItemsCount Is Nothing, 9, item.ItemsCount),
        '        .OpenTime = item.OpenTime,
        '        .Paid = item.Paid,
        '        .PaidType = GetTipoDePagoName(item.PaidType),
        '        .Propina = item.Propina,
        '        .TableId = GetTableObject(item.TableId).Name,
        '        .Total = item.Total
        '    })
        'Next
        'e.Result = tempList

        e.Result = GetAllTickets()
    End Sub

    Private Sub Dash_Reportes_Items_Loaded(sender As Object, e As RoutedEventArgs) Handles Me.Loaded
        AddHandler background_.DoWork, AddressOf CargarTickets
        AddHandler background_.RunWorkerCompleted, AddressOf MostrarTickets
        background_.RunWorkerAsync()
    End Sub

    Private Sub MostrarTickets(sender As Object, e As RunWorkerCompletedEventArgs)
        ticketGrid.ItemsSource = e.Result
    End Sub

    Private Function GetTipoDePagoName(id As Integer) As String
        Select Case id
            Case TiposDePago.Efectivo
                Return TiposDePago.Efectivo.ToString
            Case TiposDePago.TBK
                Return TiposDePago.TBK.ToString
            Case TiposDePago.Transferencia
                Return TiposDePago.Transferencia.ToString
            Case Else
                Return ""
        End Select
    End Function
End Class
