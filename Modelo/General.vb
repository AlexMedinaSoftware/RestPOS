Imports System.Globalization

Module General
    Structure Tienda
        Dim Nombre As String
        Dim Eslogan As String
        Dim Logo As String
        Dim Direccion As String
        Dim Horario As String
        Dim Telefono As String
        Dim Correo As String

        Public Sub New(new_ As Boolean)
            If new_ Then
                Nombre = "Simple."
                Eslogan = ""
                Logo = ""
                Direccion = "Membrillar 447"
                Horario = ""
                Telefono = "+56 9 0000 0000"
                Correo = "carlos@simplefastfood.cl"
            End If
        End Sub
    End Structure

    Structure Item_Pedido
        Public Property P_Item_ID As String
        Public Property P_Item_Cantidad As String
        Public Property P_Item_Nombre As String
        Public Property P_Item_Precio As String
        Public Property P_Item_Total As String
        Public Property P_Item_Sended As Boolean
        Public Property P_Item_Cant_Sended As Integer
        Public Property P_Item_Category As String

        Public ReadOnly Property P_Item_Details As String
            Get
                Return P_Item_Nombre.Replace("+", "EXTRAS -").Replace("-", vbNewLine & "-")
            End Get
        End Property
    End Structure

    Public cultureChile As New CultureInfo("es-CL")

    Public Tienda_Data As New Tienda(True)

    Property CodigoTrabajadorActual As String
    Property NombreTrabajadorActual As String
    Property AdminPassActual As String
    Property CodigoMesaActual As String
    Property ModSelected As String

    Private Property PaginaActual_ As Object

    Public Property PaginaActual
        Set(Pagina)
            CType(Page_MainWindow, MainWindow).MainFrame.Navigate(Pagina)
            PaginaActual_ = Pagina
        End Set
        Get
            Return PaginaActual_.ToString.Replace("MisterFiesta.", "")
        End Get
    End Property

    Public Sub Main_()
        SetTitulo(Tienda_Data.Nombre)
        Page_MainWindow.Show()
    End Sub

    Sub SetTitulo(titulo As String)
        Page_MainWindow.Titulo.Content = titulo
    End Sub

    Sub ShutDownRestAPP()
        System.Windows.Application.Current.Shutdown()
    End Sub

    Function GetResource(Search As String) As Object
        Try
            Return Page_MainWindow.Recursos(Search)
        Catch ex As Exception
            Return New Object
        End Try
    End Function

    Function RandomIcon() As Object
        Randomize()
        Dim Rnd_ As Integer = CInt(Math.Ceiling(Rnd() * 5)) + 1
        Select Case Rnd_
            Case 1
                Return GetResource("Cocktail")
            Case 2
                Return GetResource("Beer")
            Case 3
                Return GetResource("Hamburger")
            Case 4
                Return GetResource("Pizza")
            Case 5
                Return GetResource("Wine_bottle")
            Case Else
                Return GetResource("Cocktail")
        End Select
    End Function

    Function RandomColor() As Object
        Randomize()
        Dim Rnd_ As Integer = CInt(Math.Ceiling(Rnd() * 5)) + 1
        Select Case Rnd_
            Case 1
                Return GetResource("Color1")
            Case 2
                Return GetResource("Color2")
            Case 3
                Return GetResource("Color3")
            Case 4
                Return GetResource("Color4")
            Case 5
                Return GetResource("Color5")
            Case Else
                Return GetResource("Color1")
        End Select
    End Function

End Module
