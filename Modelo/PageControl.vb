Module PageControlModule

    Public Page_MainWindow As MainWindow = New MainWindow()
    Public Page_Login As Login = Ventanas.Login_
    Public Page_Mesas As Mesas = Ventanas.Mesas_
    Public Page_Mesas_Detalle As DetalleMesa = Ventanas.Mesas_Detalle_
    Public Page_Admin_Pass As AdminPass = Ventanas.AdminPass_
    Public Page_Admin_Dash As AdminDashboard = Ventanas.AdminDash_
    Public Page_Dash_Dashboard As Dash_Dashboard = Ventanas.Dash_Dashboard_
    Public Page_Dash_Mesas As Dash_Mesas = Ventanas.Dash_Mesas_
    Public Page_Dash_Detalle_Productos As Detalle_Productos = Ventanas.Dash_Productos_Detalle
    Public Page_Dash_Config As Dash_Config = Ventanas.Dash_Config_
    Public Page_Dash_Reportes_Items As Dash_Reportes_Items = Ventanas.Dash_Reportes_Items_

    Class Ventanas
        Public Shared Property Login_ As New Login
        Public Shared Property Mesas_ As New Mesas
        Public Shared Property Mesas_Detalle_ As New DetalleMesa
        Public Shared Property AdminPass_ As New AdminPass
        Public Shared Property AdminDash_ As New AdminDashboard
        Public Shared Property Dash_Dashboard_ As New Dash_Dashboard
        Public Shared Property Dash_Mesas_ As New Dash_Mesas
        Public Shared Property Dash_Productos_Detalle As New Detalle_Productos
        Public Shared Property Dash_Config_ As New Dash_Config
        Public Shared Property Dash_Reportes_Items_ As New Dash_Reportes_Items

    End Class

End Module