Module LoginModule
    Sub LoginAddUser(nombre As String, code As String, Cards_ As Primitives.UniformGrid, active As Boolean, ForeColor As Brush, color_ As String)
        Dim ActiveColor As SolidColorBrush
        If active Then
            ActiveColor = Brushes.LimeGreen
        Else
            ActiveColor = Brushes.Transparent
        End If

        Dim Grid_ As Grid = New Grid With {
            .Margin = New Thickness(10, 0, 10, 0),
            .Width = 180,
            .Height = 250
        }

        Dim Icon_ As Image = New Image() With {
            .Source = RandomIcon(),
            .HorizontalAlignment = HorizontalAlignment.Center,
            .VerticalAlignment = VerticalAlignment.Center,
            .Width = 100,
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
            .FontSize = 24,
            .Foreground = ForeColor,
            .FontFamily = New FontFamily("/RestPOS;component/Fonts/#Roboto")
        }

        Dim Status As Border = New Border() With {
            .Background = ActiveColor,
            .VerticalAlignment = VerticalAlignment.Bottom,
            .Height = 10,
            .Width = 130,
            .Margin = New Thickness(0, 0, 0, 40),
            .CornerRadius = New CornerRadius(0, 0, 10, 10),
            .IsManipulationEnabled = False,
            .IsHitTestVisible = False
        }

        Dim Card As Border = New Border() With {
            .Tag = code,
            .Background = GetResource(color_),
            .Width = 130,
            .Height = 170,
            .CornerRadius = New CornerRadius(10, 10, 10, 10),
            .Style = GetResource("Hover")
        }
        Grid_.Children.Add(Card)
        Grid_.Children.Add(Icon_)
        Grid_.Children.Add(Status)
        Grid_.Children.Add(Name_)
        AddHandler Card.MouseDown, AddressOf Card_Click
        Cards_.Children.Add(Grid_)
    End Sub

    Private Sub Card_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        CodigoTrabajadorActual = (TryCast(sender, Border)).Tag
        Dim tempPersonal As MainContext.Personal = GetPersonalObject(CodigoTrabajadorActual)
        NombreTrabajadorActual = tempPersonal.Name
        If tempPersonal.IsAdmin Then
            AdminPassActual = tempPersonal.Pass
            PaginaActual = Page_Admin_Pass
        Else
            PaginaActual = Page_Mesas
        End If
    End Sub

    Sub LoadUsers()
        Try
            Dim tempAdmin As New MainContext.Personal
            Dim tempUsers As List(Of MainContext.Personal) = GetPersonal()
            Page_Login.Cards.Children.Clear()

            If tempUsers.Count < 6 Then
                Page_Login.Cards.Columns = tempUsers.Count
            End If
            Page_Login.Cards.Rows = Math.Ceiling(tempUsers.Count / 6)

            For Each user In tempUsers
                If user.IsAdmin = 0 Then
                    LoginAddUser(user.Name, user.Id, Page_Login.Cards, True, GetResource("TextColor"), user.Color)
                Else
                    tempAdmin = user
                End If
            Next
            LoginAddUser(tempAdmin.Name, tempAdmin.Id, Page_Login.Cards, True, GetResource("TextColor"), tempAdmin.Color)
        Catch ex As Exception
            LogError(ex.Message)
        End Try

    End Sub

End Module
