Imports System.Windows.Threading

Public Class Splash

    Dim Timer As New DispatcherTimer With {.Interval = New TimeSpan(0, 0, 4)}
    Private Sub Splash_Loaded(sender As Object, e As RoutedEventArgs) Handles Me.Loaded
        If SystemParameters.PrimaryScreenWidth >= 1280 And SystemParameters.PrimaryScreenHeight >= 720 Then
            AddHandler Timer.Tick, AddressOf Iniciar
            Timer.Start()
        Else
            MsgBox("Resolucion minima 1280x720.", MsgBoxStyle.Critical, "Error en resolucion")
            Application.Current.Shutdown()
        End If
    End Sub

    Sub Iniciar()
        Timer.Stop()
        General.Main_()
        Me.Close()
    End Sub

End Class
