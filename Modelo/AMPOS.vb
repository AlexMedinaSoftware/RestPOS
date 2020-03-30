'Creado por Alex Carcamo Medina
'Para un Punto de Venta Restaurant
'Febrero 2020
'Alexcarcamomedina@hotmail.com

'Se programo con LinqConnect y una base de datos local SQLite

Imports System.IO

Module AMPOS

    Structure ConfigStructure
        Dim Key As String
        Dim Value As String
    End Structure

    Structure TotalesCierre
        Dim numeroVentas As Integer
        Dim dineroTotal As Double
        Dim dineroEfectivo As Double
        Dim dineroTBK As Double
        Dim dineroTransferencia As Double
        Dim propinas As Double
    End Structure

    Enum TiposDePago
        Efectivo = 1
        TBK = 2
        Transferencia = 3
    End Enum

    Public TotalCierre As TotalesCierre
    Public MainConfig As List(Of ConfigStructure)
    Public context As New MainContext.MainDataContext("data source=pos.db;failifmissing=False")
    'Public context As New MainContext.MainDataContext("user id=simplefa_posUser;password=membrillar_447;host=201.148.104.162;database=simplefa_pos;persist security info=True")

#Region "ITEMS"

    Function GetItems(categoryId As Integer) As List(Of MainContext.Item)
        Dim tempList As New List(Of MainContext.Item)
        Dim query = From it In context.Items
                    Select it
                    Where it.CategoryId = categoryId
                    Order By it.SortOrder

        For Each item In query
            tempList.Add(item)
        Next

        Return tempList
    End Function

    Function GetItems(search As String) As List(Of MainContext.Item)
        Dim tempList As New List(Of MainContext.Item)
        Dim query = From it In context.Items
                    Select it
                    Where it.Name.Contains(search) Or it.Barcode = search Or it.Tag.Contains(search)
                    Order By it.SortOrder

        For Each item In query
            tempList.Add(item)
        Next

        Return tempList
    End Function

    Function GetItems() As List(Of MainContext.Item)
        Dim tempList As New List(Of MainContext.Item)
        Dim query = From it In context.Items
                    Select it
                    Order By it.SortOrder

        For Each item In query
            tempList.Add(item)
        Next

        Return tempList
    End Function

    Function AddNewItem(newItem As MainContext.Item) As Boolean
        Try
            context.Items.InsertOnSubmit(newItem)
            context.SubmitChanges()
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Function DeleteItem(itemID As Integer) As Boolean
        Try
            Dim item As MainContext.Item = context.Items _
                .Where(Function(o) o.Id = itemID) _
                .SingleOrDefault()
            context.Items.DeleteOnSubmit(item)
            context.SubmitChanges()
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Function GetItemObject(itemID As Integer) As MainContext.Item
        Dim tempItem As New MainContext.Item
        Try
            Dim query = From it In context.Items
                        Select it
                        Where it.Id = itemID

            If query.Any Then
                For Each item As MainContext.Item In query
                    tempItem = item
                Next
            End If

            Return tempItem
        Catch ex As Exception
            Return tempItem
        End Try
    End Function

    Function EditItem(itemID As Integer, newItem As MainContext.Item) As Boolean
        Try
            Dim query = From it In context.Items
                        Select it
                        Where it.Id = itemID

            For Each item As MainContext.Item In query
                With item
                    .Barcode = newItem.Barcode
                    .BtnColor = newItem.BtnColor
                    .BuyPrice = newItem.BuyPrice
                    .CategoryId = newItem.CategoryId
                    .Description = newItem.Description
                    .LblColor = newItem.LblColor
                    .Name = newItem.Name
                    .SellPrice = newItem.SellPrice
                    .SortOrder = newItem.SortOrder
                    .StockAmount = newItem.StockAmount
                    .Tag = newItem.Tag
                    .Visible = newItem.Visible
                End With
            Next

            context.SubmitChanges()
            Return True
        Catch ex As Exception
            Return False
        End Try

    End Function

#End Region

#Region "TICKET ITEMS"

    Function AddItemToTicket(ticket As MainContext.Ticket, item As MainContext.TicketsItem) As Boolean
        Try
            item.TicketId = ticket.Id
            context.TicketsItems.InsertOnSubmit(item)
            Dim query = From it In context.Tickets
                        Select it
                        Where it.Id = ticket.Id

            For Each item_ As MainContext.Ticket In query
                item_.ItemsCount += item.Count
                item_.Total += (item.Price * item.Count)
            Next
            context.SubmitChanges()
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Function DelItemFromTicket(ticketitemID As Integer) As Boolean
        Try
            Dim ticketItem As MainContext.TicketsItem = context.TicketsItems _
                .Where(Function(o) o.Id = ticketitemID) _
                .SingleOrDefault()

            context.TicketsItems.DeleteOnSubmit(ticketItem)
            Dim query = From it In context.Tickets
                        Select it
                        Where it.Id = ticketItem.TicketId

            For Each item_ As MainContext.Ticket In query
                item_.ItemsCount -= ticketItem.Count
                item_.Total -= (ticketItem.Price * ticketItem.Count)
            Next
            context.SubmitChanges()
            Return True
        Catch ex As Exception
            LogError(ex.Message)
            Return False
        End Try
    End Function

    Function GetTicketItemObject(ticketItemID) As MainContext.TicketsItem
        Dim tempItem As New MainContext.TicketsItem
        Try
            Dim query = From it In context.TicketsItems
                        Select it
                        Where it.Id = ticketItemID

            If query.Any Then
                For Each item As MainContext.TicketsItem In query
                    tempItem = item
                Next
            End If

            Return tempItem
        Catch ex As Exception
            Return tempItem
        End Try
    End Function

    Function GetTicketItems(ticketID As Integer) As List(Of MainContext.TicketsItem)
        Dim tempList As New List(Of MainContext.TicketsItem)
        Dim query = From it In context.TicketsItems
                    Select it
                    Where it.TicketId = ticketID

        For Each item In query
            tempList.Add(item)
        Next

        Return tempList
    End Function

#End Region

#Region "CATEGORIES"
    Function GetCategories() As List(Of MainContext.Category)
        Dim tempList As New List(Of MainContext.Category)
        Dim query = From it In context.Categories
                    Select it
                    Order By it.SortOrder


        For Each cat In query
            tempList.Add(cat)
        Next

        Return tempList
    End Function

    Function EditCategory(categoryID As Integer, newCategory As MainContext.Category) As Boolean
        Try
            Dim query = From it In context.Categories
                        Select it
                        Where it.Id = categoryID

            For Each item As MainContext.Category In query
                With item
                    .BtnColor = newCategory.BtnColor
                    .Description = newCategory.Description
                    .LblColor = newCategory.LblColor
                    .Name = newCategory.Name
                    .SortOrder = newCategory.SortOrder
                    .Tag = newCategory.Tag
                    .Visible = newCategory.Visible
                    .Icon = newCategory.Icon
                    .IsLiquid = newCategory.IsLiquid
                End With
            Next

            context.SubmitChanges()
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Function GetCategoryObject(categoryID As Integer) As MainContext.Category
        Dim tempCategory As New MainContext.Category
        Try

            Dim query = From it In context.Categories
                        Select it
                        Where it.Id = categoryID

            If query.Any Then
                For Each Category As MainContext.Category In query
                    tempCategory = Category
                Next
            End If

            Return tempCategory
        Catch ex As Exception
            LogError(ex)
            Return tempCategory
        End Try
    End Function

    Function AddNewCategory(newCategory As MainContext.Category) As Boolean
        Try
            context.Categories.InsertOnSubmit(newCategory)
            context.SubmitChanges()
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Function DeleteCategory(categoryID As Integer) As Boolean
        Try
            Dim category As MainContext.Category = context.Categories _
                .Where(Function(o) o.Id = categoryID) _
                .SingleOrDefault()

            context.Categories.DeleteOnSubmit(category)
            context.SubmitChanges()
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

#End Region

#Region "TICKETS"

    Function GetTicketID(tableid As Integer) As Integer
        Dim tempTicketID As Integer = -1
        Try
            Dim query = From it In context.Tickets
                        Select it
                        Where it.TableId = tableid And it.IsOpen = 1

            If query.Any Then
                For Each ticket As MainContext.Ticket In query
                    tempTicketID = ticket.Id
                Next
            End If
            Return tempTicketID
        Catch ex As Exception
            Return tempTicketID
        End Try
    End Function

    Function CloseTicket(TicketID As Integer) As Boolean
        Dim nowDate As String = Date.Now.ToString(cultureChile)
        Try
            Dim query = From it In context.Tickets
                        Select it
                        Where it.Id = TicketID

            For Each ticket As MainContext.Ticket In query
                ticket.IsOpen = 0
                ticket.CloseTime = nowDate
            Next

            context.SubmitChanges()
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Function CreateTicket(tableId As Integer) As Integer
        If GetTicketID(tableId) = -1 Then
            Dim tempId As Integer
            Dim nowDate As String = Date.Now.ToString(cultureChile)
            Dim tempTicket As New MainContext.Ticket With {
            .TableId = tableId,
            .IsOpen = 1,
            .IsDayOut = 0,
            .Total = 0,
            .Propina = 0,
            .Paid = 0,
            .ItemsCount = 0,
            .Canceled = 0,
            .PaidType = 0,
            .OpenTime = nowDate,
            .TerminalId = GetConfig("terminal")
        }
            context.Tickets.InsertOnSubmit(tempTicket)
            context.SubmitChanges()

            Dim query = From it In context.Tickets
                        Where it.OpenTime = nowDate And it.TableId = tableId And it.IsOpen = 1

            For Each ticket As MainContext.Ticket In query
                tempId = ticket.Id
            Next
            Return tempId
        Else
            Return -1
        End If
    End Function

    Function CloseAllTickets() As Boolean
        Dim nowDate As String = Date.Now.ToString(cultureChile)
        Try
            Dim query = From it In context.Tickets
                        Select it

            For Each ticket As MainContext.Ticket In query
                ticket.IsOpen = 0
                ticket.CloseTime = nowDate
            Next

            context.SubmitChanges()

            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Function PagarTicket(ticketid As Integer, pagado As Double, paidType As TiposDePago) As Boolean
        Dim nowDate As String = Date.Now.ToString(cultureChile)
        Dim tempreturn As Boolean = False
        Try
            Dim query = From it In context.Tickets
                        Select it
                        Where it.Id = ticketid

            Dim ticket As MainContext.Ticket

            For Each ticket In query
                If (ticket.Total + ticket.Propina) <= pagado Then
                    ticket.Paid = pagado
                    ticket.IsOpen = 0
                    ticket.CloseTime = nowDate
                    ticket.PaidType = paidType
                    context.SubmitChanges()
                    tempreturn = True
                Else
                    SendDebug("Total = " & (ticket.Total + ticket.Propina) & " Pagado = " & pagado)
                End If
            Next
        Catch ex As Exception
            tempreturn = False
        End Try
        Return tempreturn
    End Function

    Sub SendDebug(message As String)
        Try
            Dim ruta As String = "debug.txt"
            Dim escritor As StreamWriter
            escritor = File.AppendText(ruta)
            escritor.Write(message)
            escritor.Flush()
            escritor.Close()
        Catch ex As Exception
        End Try
    End Sub

    Function GetTicketObject(ticketID As Integer) As MainContext.Ticket
        If ticketID = -1 Then
            Return Nothing
        Else
            Dim tempticket As New MainContext.Ticket
            Try
                Dim query = From it In context.Tickets
                            Select it
                            Where it.Id = ticketID

                If query.Any Then
                    For Each ticket As MainContext.Ticket In query
                        tempticket = ticket
                    Next
                End If
                Return tempticket
            Catch ex As Exception
                Return tempticket
            End Try
        End If
    End Function

    Function GetTickets(isOpen As Boolean, isDayOut As Boolean, Optional tipoPago As TiposDePago = -1) As List(Of MainContext.Ticket)
        Dim templist As New List(Of MainContext.Ticket)
        If tipoPago = -1 Then
            Dim query = From it In context.Tickets
                        Select it
                        Where it.IsOpen = isOpen And it.IsDayOut = isDayOut

            If query.Any Then
                For Each ticket As MainContext.Ticket In query
                    templist.Add(ticket)
                Next
            End If
        Else
            Dim query = From it In context.Tickets
                        Select it
                        Where it.IsOpen = isOpen And it.IsDayOut = isDayOut And it.PaidType = tipoPago

            If query.Any Then
                For Each ticket As MainContext.Ticket In query
                    templist.Add(ticket)
                Next
            End If
        End If
        Return templist
    End Function

    Function GetAllTickets() As List(Of MainContext.Ticket)
        Dim templist As New List(Of MainContext.Ticket)

        Dim query = From it In context.Tickets
                    Select it

        If query.Any Then
            For Each ticket As MainContext.Ticket In query
                templist.Add(ticket)
            Next
        End If

        Return templist
    End Function

#End Region

#Region "MODIFIERS"

    Function GetModifiers() As List(Of MainContext.Modifier)
        Dim tempList As New List(Of MainContext.Modifier)
        Dim query = From it In context.Modifiers
                    Select it

        For Each item As MainContext.Modifier In query
            tempList.Add(item)
        Next
        Return tempList
    End Function

    Function GetModifiers(categoryID As Integer) As List(Of MainContext.Modifier)
        Dim tempList As New List(Of MainContext.Modifier)
        Dim query = From it In context.Modifiers
                    Select it
                    Where it.CategoryId = categoryID

        For Each item As MainContext.Modifier In query
            tempList.Add(item)
        Next
        Return tempList
    End Function

    Function GetModifierObject(modifierID As Integer) As MainContext.Modifier
        Dim tempModifier As New MainContext.Modifier
        Try
            Dim query = From it In context.Modifiers
                        Select it
                        Where it.Id = modifierID

            If query.Any Then
                For Each Modifier As MainContext.Modifier In query
                    tempModifier = Modifier
                Next
            End If
            Return tempModifier
        Catch ex As Exception
            Return tempModifier
        End Try
    End Function

    Function AddNewModifier(newModifier As MainContext.Modifier) As Boolean
        Try
            context.Modifiers.InsertOnSubmit(newModifier)
            context.SubmitChanges()
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Function DeleteModifier(modifierID As Integer) As Boolean
        Try
            Dim modifier As MainContext.Modifier = context.Modifiers _
                .Where(Function(o) o.Id = modifierID) _
                .SingleOrDefault()

            context.Modifiers.DeleteOnSubmit(modifier)
            context.SubmitChanges()
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Function EditModifier(modifierID As Integer, newCategory As MainContext.Modifier) As Boolean
        Try
            Dim query = From it In context.Modifiers
                        Select it
                        Where it.Id = modifierID

            For Each item As MainContext.Modifier In query
                With item
                    .CategoryId = newCategory.CategoryId
                    .Name = newCategory.Name
                    .Price = newCategory.Price
                End With
            Next

            context.SubmitChanges()
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

#End Region

#Region "TABLES"

    Function GetTables() As List(Of MainContext.Table)
        Dim tempList As New List(Of MainContext.Table)
        Dim query = From it In context.Tables
                    Select it

        For Each table In query
            tempList.Add(table)
        Next
        Return tempList
    End Function

    Function GetTableObject(tableID As Integer) As MainContext.Table
        Dim tempTable As New MainContext.Table
        Try
            Dim query = From it In context.Tables
                        Select it
                        Where it.Id = tableID

            If query.Any Then
                For Each Table As MainContext.Table In query
                    tempTable = Table
                Next
            End If
            Return tempTable
        Catch ex As Exception
            Return tempTable
        End Try
    End Function

    Function AddNewTable(newTable As MainContext.Table) As Boolean
        Try
            context.Tables.InsertOnSubmit(newTable)
            context.SubmitChanges()
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Function DeleteTable(tableID As Integer) As Boolean
        Try
            Dim table As MainContext.Table = context.Tables _
                .Where(Function(o) o.Id = tableID) _
                .SingleOrDefault()

            context.Tables.DeleteOnSubmit(table)
            context.SubmitChanges()
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Function TableIsActive(tableID As Integer) As Boolean
        Dim tempReturn As Boolean
        Dim query = From it In context.Tickets
                    Select it
                    Where it.TableId = tableID And it.IsOpen = 1

        If query.Any Then
            tempReturn = True
        Else
            tempReturn = False
        End If
        Return tempReturn
    End Function

    Sub ChangeTable(ticketid As Integer, tableid As Integer)
        Try
            GetTicketObject(ticketid).TableId = tableid
            context.SubmitChanges()
        Catch ex As Exception
            LogError(ex)
        End Try
    End Sub

    Function GetTableName(tableID As Integer) As String
        Dim tempTable As String = ""
        Try
            Dim query = From it In context.Tables
                        Select it
                        Where it.Id = tableID

            If query.Any Then
                For Each item As MainContext.Table In query
                    tempTable = item.Name
                Next
            End If
            Return tempTable
        Catch ex As Exception
            Return tempTable
        End Try
    End Function

    Function EditTable(tableID As Integer, newTable As MainContext.Table) As Boolean
        Try
            Dim query = From it In context.Tables
                        Select it
                        Where it.Id = tableID

            For Each item As MainContext.Table In query
                With item
                    .Name = newTable.Name
                    .Capacity = newTable.Capacity
                    .Color = newTable.Color
                    .Description = newTable.Description
                    .Visible = newTable.Visible
                End With
            Next

            context.SubmitChanges()
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

#End Region

#Region "PERSONAL"

    Function GetPersonal() As List(Of MainContext.Personal)
        Dim tempList As New List(Of MainContext.Personal)
        Dim query = From it In context.Personals
                    Select it

        For Each item As MainContext.Personal In query
            tempList.Add(item)
        Next
        Return tempList
    End Function

    Function GetPersonalObject(personalID As Integer) As MainContext.Personal
        Dim tempPersonal As New MainContext.Personal
        Try
            Dim query = From it In context.Personals
                        Select it
                        Where it.Id = personalID

            If query.Any Then
                For Each Personal As MainContext.Personal In query
                    tempPersonal = Personal
                Next
            End If
            Return tempPersonal
        Catch ex As Exception
            Return tempPersonal
        End Try
    End Function

    Function AddNewPersonal(newPersonal As MainContext.Personal) As Boolean
        Try
            context.Personals.InsertOnSubmit(newPersonal)
            context.SubmitChanges()
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Function DeletePersonal(personalID As Integer) As Boolean
        Try
            Dim personal As MainContext.Personal = context.Personals _
                .Where(Function(o) o.Id = personalID) _
                .SingleOrDefault()

            context.Personals.DeleteOnSubmit(personal)
            context.SubmitChanges()
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Function EditPersonal(personalID As Integer, newPersonal As MainContext.Personal) As Boolean
        Try
            Dim query = From it In context.Personals
                        Select it
                        Where it.Id = personalID

            For Each item As MainContext.Personal In query
                With item
                    .Color = newPersonal.Color
                    .Icon = newPersonal.Icon
                    .IsAdmin = newPersonal.IsAdmin
                    .Name = newPersonal.Name
                    .Pass = newPersonal.Pass
                End With
            Next

            context.SubmitChanges()
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

#End Region

#Region "ADMINISTRACION"

    Function GetCierreObject(cierreID) As MainContext.Cierre
        context.SubmitChanges()
        Dim tempCierre As New MainContext.Cierre
        Try
            Dim query = From it In context.Cierres
                        Select it
                        Where it.Id = cierreID

            If query.Any Then
                For Each Cierre As MainContext.Cierre In query
                    tempCierre = Cierre
                Next
            End If
            Return tempCierre
        Catch ex As Exception
            MsgBox(ex.Message)
            Return tempCierre
        End Try
    End Function

    Function GetConfig(Key As String) As String
        Dim tempString As String = String.Empty
        Try
            Dim query = From it In context.Configs
                        Select it

            Dim config As MainContext.Config
            For Each config In query
                If config.Property = Key Then
                    tempString = config.Value
                End If
            Next
            Return tempString
        Catch ex As Exception
            Return tempString
        End Try
    End Function

    Function GetAllConfigs() As List(Of ConfigStructure)
        Dim tempList As New List(Of ConfigStructure)
        Try
            Dim query = From it In context.Configs
                        Select it

            For Each config As MainContext.Config In query
                Dim a As New ConfigStructure With {
                    .Key = config.Property,
                    .Value = config.Value
                }
                tempList.Add(a)
            Next

            Return tempList
        Catch ex As Exception
            Return tempList
        End Try
    End Function

    Function SetConfig(Key As String, Value As String) As Boolean
        Try
            Dim query = From it In context.Configs
                        Select it
                        Where it.Property = Key

            For Each config As MainContext.Config In query
                config.Value = Value
            Next

            context.SubmitChanges()
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Function CloseDay() As Boolean
        Dim tempList As New List(Of MainContext.Ticket)
        Dim nowDate As String = Date.Now.ToString(cultureChile)
        CloseAllTickets()
        TotalCierre = CalcularTotales()
        AddCierreToDB(nowDate)

        Try
            Dim query = From it In context.Tickets
                        Select it
                        Where it.IsDayOut = 0

            For Each ticket As MainContext.Ticket In query
                tempList.Add(ticket)
                ticket.IsDayOut = 1
            Next

            context.SubmitChanges()

            Dim query2 = From it In context.Cierres
                         Where it.Fecha = nowDate

            For Each cierre As MainContext.Cierre In query2
                ImprimirVoucherCierre(tempList, cierre)
            Next

            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Function AddCierreToDB(nowDate As String) As Boolean

        Dim newCierre As New MainContext.Cierre With {
            .Fecha = nowDate,
            .Propina = TotalCierre.propinas,
            .TotalEfectivo = TotalCierre.dineroEfectivo,
            .Total = TotalCierre.dineroTotal,
            .TotalTBK = TotalCierre.dineroTBK,
            .TotalTransferencia = TotalCierre.dineroTransferencia
        }
        Try
            context.Cierres.InsertOnSubmit(newCierre)
            context.SubmitChanges()
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Function CalcularTotales() As TotalesCierre
        Dim temp As New TotalesCierre
        Try
            Dim query = From it In context.Tickets
                        Select it
                        Where it.IsDayOut = 0 And it.IsOpen = 0

            Dim ticket As MainContext.Ticket
            For Each ticket In query
                temp.numeroVentas += 1
                temp.dineroTotal += ticket.Paid - ticket.Propina
                Select Case ticket.PaidType
                    Case TiposDePago.Efectivo
                        temp.dineroEfectivo += ticket.Paid
                    Case TiposDePago.TBK
                        temp.dineroTBK += ticket.Paid
                    Case TiposDePago.Transferencia
                        temp.dineroTransferencia += ticket.Paid
                End Select
                temp.propinas += ticket.Propina
            Next
            Return temp
        Catch ex As Exception
            Return temp
        End Try
    End Function

    Function GetErrors() As Devart.Data.Linq.SubmitErrorCollection
        Return context.Errors
    End Function

    Function CalcularPropina(total As Double) As Long
        Return Math.Round((total * 0.1) / 10) * 10
    End Function

    Sub LogError(ex As Exception)
        Try
            Dim ruta As String = "log.txt"
            Dim escritor As StreamWriter
            escritor = File.AppendText(ruta)
            escritor.Write("[" & Date.Now & "] " & ex.Message & " (" & ex.StackTrace & ")" & vbNewLine)
            escritor.Flush()
            escritor.Close()
        Catch exTemp As Exception
        End Try
    End Sub

    Sub LogError(ex As String)
        Try
            Dim ruta As String = "log.txt"
            Dim escritor As StreamWriter
            escritor = File.AppendText(ruta)
            escritor.Write("[" & Date.Now & "] " & ex)
            escritor.Flush()
            escritor.Close()
        Catch exTemp As Exception
        End Try
    End Sub

#End Region

End Module
