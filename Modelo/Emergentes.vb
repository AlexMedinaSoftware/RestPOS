Module EmergentesModule
    Sub MostrarPopUp(titulo As String, buttons As MsgBoxStyle, Optional Contenido_1 As String = "", Optional Contenido_2 As String = "", Optional Footer As String = "")
        'borrar esto solo suprime una advertencia temporal
        Dim a As String = Contenido_1 & Contenido_2 & Footer
        If buttons = MsgBoxStyle.OkCancel Then
            Page_MainWindow.PCenterBtn.Visibility = Visibility.Hidden
            Page_MainWindow.PYesBtn.Visibility = Visibility.Visible
            Page_MainWindow.PNoBtn.Visibility = Visibility.Visible
        ElseIf buttons = MsgBoxStyle.OkOnly Then
            Page_MainWindow.PCenterBtn.Visibility = Visibility.Visible
            Page_MainWindow.PYesBtn.Visibility = Visibility.Hidden
            Page_MainWindow.PNoBtn.Visibility = Visibility.Hidden
        End If
        Page_MainWindow.PopupTitle.Content = titulo
        Page_MainWindow.PopupWindow.IsOpen = True
    End Sub

End Module
