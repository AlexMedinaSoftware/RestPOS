Imports System.Globalization

Class Dash_Config



    Private Sub AgregarConfig(Key As String, Value As String)

        Dim GridPrincipal As New Grid With {
            .Width = 500,
            .Height = 50,
            .Margin = New Thickness(5)
        }

        Dim Fondo As New Border With {
            .Background = GetResource("DarkColor2"),
            .Opacity = 0.1,
            .CornerRadius = New CornerRadius(10)
        }

        Dim NombreConfig As New TextBlock With {
            .Margin = New Thickness(10, 0, 0, 0),
            .VerticalAlignment = VerticalAlignment.Center,
            .HorizontalAlignment = HorizontalAlignment.Stretch,
            .Text = UppercaseFirst(Key) & ":",
            .FontSize = 20,
            .Foreground = GetResource("DarkColor2"),
            .FontFamily = New FontFamily("/RestPOS;component/Fonts/#Roboto")
        }

        Dim TextBoxConfig As New TextBox With {
            .Width = 200,
            .Height = 40,
            .HorizontalAlignment = HorizontalAlignment.Left,
            .Margin = New Thickness(165, 0, 0, 0),
            .Style = GetResource("RoundTextBox"),
            .Tag = Key,
            .Text = Value
        }

        Dim GridBoton As New Grid With {
            .Width = 120,
            .Height = 40,
            .HorizontalAlignment = HorizontalAlignment.Left,
            .Margin = New Thickness(375, 0, 0, 0),
            .IsEnabled = False,
            .Style = GetResource("ConfigEnable"),
            .Tag = Key
        }

        Dim FondoBoton As New Border With {
            .Width = 120,
            .Height = 40,
            .CornerRadius = New CornerRadius(10),
            .Background = GetResource("Color5"),
            .Style = GetResource("HoverPass"),
            .Tag = Key
        }

        Dim TextoBoton As New TextBlock With {
            .IsHitTestVisible = False,
            .VerticalAlignment = VerticalAlignment.Center,
            .HorizontalAlignment = HorizontalAlignment.Center,
            .Text = "Aplicar",
            .FontSize = 15,
            .Foreground = GetResource("DarkColor2"),
            .FontFamily = New FontFamily("/RestPOS;component/Fonts/#Roboto")
        }

        AddHandler TextBoxConfig.TextChanged, AddressOf OnEditConfig
        AddHandler GridBoton.MouseUp, AddressOf Apply_Click

        GridBoton.Children.Add(FondoBoton)
        GridBoton.Children.Add(TextoBoton)

        GridPrincipal.Children.Add(Fondo)
        GridPrincipal.Children.Add(NombreConfig)
        GridPrincipal.Children.Add(TextBoxConfig)
        GridPrincipal.Children.Add(GridBoton)

        Configs_Grid.Children.Add(GridPrincipal)
    End Sub

    Private Sub Dash_Config_Loaded(sender As Object, e As RoutedEventArgs) Handles Me.Loaded
        Configs_Grid.Children.Clear()
        For Each item As ConfigStructure In GetAllConfigs()
            AgregarConfig(item.Key, item.Value)
        Next
    End Sub

    Private Shared Function UppercaseFirst(ByVal s As String) As String
        If String.IsNullOrEmpty(s) Then
            Return String.Empty
        End If

        Return Char.ToUpper(s(0), cultureChile) & s.Substring(1)
    End Function

    Private Sub OnEditConfig(sender As TextBox, e As EventArgs)
        If StringsIguales(sender.Text, GetConfig(sender.Tag)) Then
            CambiarEstadoBoton(sender.Tag, False)
        Else
            CambiarEstadoBoton(sender.Tag, True)
        End If
    End Sub

    Private Sub Apply_Click(sender As Grid, e As EventArgs)
        If AMPOS.SetConfig(sender.Tag, GetConfigText(sender.Tag)) Then
            CambiarEstadoBoton(sender.Tag, False)
        End If
    End Sub

    Private Function StringsIguales(string1 As String, string2 As String) As Boolean
        Dim tempbool As Boolean = True
        Try
            If string1.Length = string2.Length Then
                For i = 0 To string1.Length - 1
                    If Not Asc(string1.Substring(i, 1)) = Asc(string2.Substring(i, 1)) Then
                        tempbool = False
                        Exit For
                    End If
                Next
            Else
                tempbool = False
            End If
        Catch ex As Exception
            LogError(ex)
        End Try
        Return tempbool
    End Function

    Private Sub CambiarEstadoBoton(key As String, estado As Boolean)
        For Each grid_ As Grid In Configs_Grid.Children
            For Each item In grid_.Children
                If item.GetType = GetType(Grid) Then
                    Dim gridboton As Grid = item
                    If gridboton.Tag = key Then
                        gridboton.IsEnabled = estado
                    End If
                End If
            Next
        Next
    End Sub

    Private Function GetConfigText(key As String) As String
        Dim tempvalue As String = String.Empty
        For Each grid_ As Grid In Configs_Grid.Children
            If tempvalue = String.Empty Then
                For Each item In grid_.Children
                    If item.GetType = GetType(TextBox) Then
                        Dim TextBoxConfig As TextBox = item
                        If TextBoxConfig.Tag = key Then
                            tempvalue = TextBoxConfig.Text
                            Exit For
                        End If
                    End If
                Next
            Else
                Exit For
            End If
        Next
        Return tempvalue
    End Function

End Class
