Imports System.Windows.Threading

Class AdminPass

    Dim TempAdminPass As String = ""

    Sub NuevoDigito(digit As String)
        If TempAdminPass = "" Then
            NeutralBalls()
        End If
        If TempAdminPass.Length = 3 Then
            TempAdminPass &= digit
            If TempAdminPass = AdminPassActual Then
                GreenBalls()
            Else
                RedBalls()
            End If
        Else
            TempAdminPass &= digit
            PaintBall(TempAdminPass.Length)
        End If
        KeyGet.Focus()
    End Sub

    Sub DelDigit()
        If TempAdminPass.Length > 0 Then
            TempAdminPass = TempAdminPass.Substring(0, TempAdminPass.Length - 1)
            UnpaintBall(TempAdminPass.Length + 1)
        End If
        KeyGet.Focus()
    End Sub

    Sub GreenBalls()
        Dim timer As New DispatcherTimer
        AddHandler timer.Tick, AddressOf toDash
        timer.Interval = New TimeSpan(0, 0, 0, 0, 500)
        timer.Start()
        TempAdminPass = ""
        PassBall_1.Background = Brushes.LimeGreen
        PassBall_1.BorderThickness = New Thickness(0)
        PassBall_2.Background = Brushes.LimeGreen
        PassBall_2.BorderThickness = New Thickness(0)
        PassBall_3.Background = Brushes.LimeGreen
        PassBall_3.BorderThickness = New Thickness(0)
        PassBall_4.Background = Brushes.LimeGreen
        PassBall_4.BorderThickness = New Thickness(0)
    End Sub

    Private Sub toDash(sender As DispatcherTimer, e As EventArgs)
        sender.Stop()
        PaginaActual = Page_Admin_Dash
    End Sub

    Sub PaintBall(ball As String)
        Select Case ball
            Case 1
                PassBall_1.Background = GetResource("ButtonColor")
            Case 2
                PassBall_2.Background = GetResource("ButtonColor")
            Case 3
                PassBall_3.Background = GetResource("ButtonColor")
            Case 4
                PassBall_4.Background = GetResource("ButtonColor")
        End Select
    End Sub

    Sub UnpaintBall(ball As String)
        Select Case ball
            Case 1
                PassBall_1.Background = GetResource("ButtonColorDark")
            Case 2
                PassBall_2.Background = GetResource("ButtonColorDark")
            Case 3
                PassBall_3.Background = GetResource("ButtonColorDark")
            Case 4
                PassBall_4.Background = GetResource("ButtonColorDark")
        End Select
    End Sub

    Sub RedBalls()
        TempAdminPass = ""
        PassBall_1.Background = Brushes.Red
        PassBall_1.BorderThickness = New Thickness(0)
        PassBall_2.Background = Brushes.Red
        PassBall_2.BorderThickness = New Thickness(0)
        PassBall_3.Background = Brushes.Red
        PassBall_3.BorderThickness = New Thickness(0)
        PassBall_4.Background = Brushes.Red
        PassBall_4.BorderThickness = New Thickness(0)
    End Sub

    Sub NeutralBalls()
        PassBall_1.Background = GetResource("ButtonColorDark")
        PassBall_2.Background = GetResource("ButtonColorDark")
        PassBall_3.Background = GetResource("ButtonColorDark")
        PassBall_4.Background = GetResource("ButtonColorDark")
        PassBall_1.BorderThickness = New Thickness(1)
        PassBall_2.BorderThickness = New Thickness(1)
        PassBall_3.BorderThickness = New Thickness(1)
        PassBall_4.BorderThickness = New Thickness(1)
    End Sub

    Private Sub PassButton_0_MouseUp(sender As Object, e As MouseButtonEventArgs) Handles PassButton_0.MouseUp
        NuevoDigito(0)
    End Sub

    Private Sub PassButton_1_MouseUp(sender As Object, e As MouseButtonEventArgs) Handles PassButton_1.MouseUp
        NuevoDigito(1)
    End Sub

    Private Sub PassButton_2_MouseUp(sender As Object, e As MouseButtonEventArgs) Handles PassButton_2.MouseUp
        NuevoDigito(2)
    End Sub

    Private Sub PassButton_3_MouseUp(sender As Object, e As MouseButtonEventArgs) Handles PassButton_3.MouseUp
        NuevoDigito(3)
    End Sub

    Private Sub PassButton_4_MouseUp(sender As Object, e As MouseButtonEventArgs) Handles PassButton_4.MouseUp
        NuevoDigito(4)
    End Sub

    Private Sub PassButton_5_MouseUp(sender As Object, e As MouseButtonEventArgs) Handles PassButton_5.MouseUp
        NuevoDigito(5)
    End Sub

    Private Sub PassButton_6_MouseUp(sender As Object, e As MouseButtonEventArgs) Handles PassButton_6.MouseUp
        NuevoDigito(6)
    End Sub

    Private Sub PassButton_7_MouseUp(sender As Object, e As MouseButtonEventArgs) Handles PassButton_7.MouseUp
        NuevoDigito(7)
    End Sub

    Private Sub PassButton_8_MouseUp(sender As Object, e As MouseButtonEventArgs) Handles PassButton_8.MouseUp
        NuevoDigito(8)
    End Sub

    Private Sub PassButton_9_MouseUp(sender As Object, e As MouseButtonEventArgs) Handles PassButton_9.MouseUp
        NuevoDigito(9)
    End Sub

    Private Sub PassButton_Del2_MouseUp(sender As Object, e As MouseButtonEventArgs) Handles PassButton_Del2.MouseUp
        DelDigit()
    End Sub

    Private Sub AdminPass_KeyUp(sender As Object, e As KeyEventArgs) Handles Me.KeyUp
        If (e.Key + 14) = 16 Then
            DelDigit()
        Else
            If IsNumeric(Chr(e.Key + 14)) Then
                NuevoDigito(Chr(e.Key + 14))
            End If
        End If
        KeyGet.Text = String.Empty
    End Sub

    Private Sub BackKey_MouseUp(sender As Object, e As MouseButtonEventArgs) Handles BackKey.MouseUp
        Page_MainWindow.MainFrame.GoBack()
    End Sub

    Private Sub AdminPass_Loaded(sender As Object, e As RoutedEventArgs) Handles Me.Loaded
        KeyGet.Focus()
        SetTitulo("Admin Login")
    End Sub
End Class
