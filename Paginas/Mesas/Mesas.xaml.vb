Class Mesas

    Private Sub BackKey_MouseUp(sender As Object, e As MouseButtonEventArgs) Handles BackKey.MouseUp
        PaginaActual = Page_Login
    End Sub

    Private Sub Mesas_Loaded(sender As Object, e As RoutedEventArgs) Handles Me.Loaded
        SetTitulo("Mesas")
        LoadMesas()
    End Sub

End Class