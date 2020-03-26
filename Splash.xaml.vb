Imports System.Windows.Threading

Public Class Splash

    Dim Timer As New DispatcherTimer With {.Interval = New TimeSpan(0, 0, 4)}
    Private Sub Splash_Loaded(sender As Object, e As RoutedEventArgs) Handles Me.Loaded
        AddHandler Timer.Tick, AddressOf Iniciar
        Timer.Start()
    End Sub

    Sub Iniciar()
        Timer.Stop()
        General.Main_()
        Me.Close()
    End Sub

End Class
