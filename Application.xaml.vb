Imports System.Windows.Threading

Class Application
    Private Sub Application_DispatcherUnhandledException(sender As Object, e As DispatcherUnhandledExceptionEventArgs) Handles Me.DispatcherUnhandledException
        LogError(e.Exception.Message)
    End Sub

    Private Sub Application_LoadCompleted(sender As Object, e As NavigationEventArgs) Handles Me.LoadCompleted
        Debug.Listeners.Add(New TextWriterTraceListener("Debug of " & DateTime.Now.ToString(cultureChile) & ".txt"))
    End Sub

    ' Los eventos de nivel de aplicación, como Startup, Exit y DispatcherUnhandledException
    ' se pueden controlar en este archivo.

End Class
