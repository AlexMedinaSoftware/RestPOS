﻿#ExternalChecksum("..\..\..\..\..\Paginas\Admin\AdminDashboard.xaml","{8829d00f-11b8-4213-878b-770e8597ac16}","7A387AA19F7A6EB25BA6EB5CB955CE1820D1B54BB90238961EF9B9D730315D8A")
'------------------------------------------------------------------------------
' <auto-generated>
'     Este código fue generado por una herramienta.
'     Versión de runtime:4.0.30319.42000
'
'     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
'     se vuelve a generar el código.
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict Off
Option Explicit On

Imports RestPOS
Imports System
Imports System.Diagnostics
Imports System.Windows
Imports System.Windows.Automation
Imports System.Windows.Controls
Imports System.Windows.Controls.Primitives
Imports System.Windows.Data
Imports System.Windows.Documents
Imports System.Windows.Ink
Imports System.Windows.Input
Imports System.Windows.Markup
Imports System.Windows.Media
Imports System.Windows.Media.Animation
Imports System.Windows.Media.Effects
Imports System.Windows.Media.Imaging
Imports System.Windows.Media.Media3D
Imports System.Windows.Media.TextFormatting
Imports System.Windows.Navigation
Imports System.Windows.Shapes
Imports System.Windows.Shell


'''<summary>
'''AdminDashboard
'''</summary>
<Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>  _
Partial Public Class AdminDashboard
    Inherits System.Windows.Controls.Page
    Implements System.Windows.Markup.IComponentConnector
    
    
    #ExternalSource("..\..\..\..\..\Paginas\Admin\AdminDashboard.xaml",11)
    <System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")>  _
    Friend WithEvents Recursos As System.Windows.ResourceDictionary
    
    #End ExternalSource
    
    
    #ExternalSource("..\..\..\..\..\Paginas\Admin\AdminDashboard.xaml",22)
    <System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")>  _
    Friend WithEvents Logo_Grid As System.Windows.Controls.Grid
    
    #End ExternalSource
    
    
    #ExternalSource("..\..\..\..\..\Paginas\Admin\AdminDashboard.xaml",25)
    <System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")>  _
    Friend WithEvents MainMenu_Grid As System.Windows.Controls.Grid
    
    #End ExternalSource
    
    
    #ExternalSource("..\..\..\..\..\Paginas\Admin\AdminDashboard.xaml",36)
    <System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")>  _
    Friend WithEvents BtnDash_Dashboard As System.Windows.Controls.Border
    
    #End ExternalSource
    
    
    #ExternalSource("..\..\..\..\..\Paginas\Admin\AdminDashboard.xaml",39)
    <System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")>  _
    Friend WithEvents BtnDash_Reportes As System.Windows.Controls.Border
    
    #End ExternalSource
    
    
    #ExternalSource("..\..\..\..\..\Paginas\Admin\AdminDashboard.xaml",42)
    <System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")>  _
    Friend WithEvents BtnDash_Usuarios As System.Windows.Controls.Border
    
    #End ExternalSource
    
    
    #ExternalSource("..\..\..\..\..\Paginas\Admin\AdminDashboard.xaml",45)
    <System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")>  _
    Friend WithEvents BtnDash_Productos As System.Windows.Controls.Border
    
    #End ExternalSource
    
    
    #ExternalSource("..\..\..\..\..\Paginas\Admin\AdminDashboard.xaml",48)
    <System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")>  _
    Friend WithEvents BtnDash_Mesas As System.Windows.Controls.Border
    
    #End ExternalSource
    
    
    #ExternalSource("..\..\..\..\..\Paginas\Admin\AdminDashboard.xaml",51)
    <System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")>  _
    Friend WithEvents BtnDash_Config As System.Windows.Controls.Border
    
    #End ExternalSource
    
    
    #ExternalSource("..\..\..\..\..\Paginas\Admin\AdminDashboard.xaml",54)
    <System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")>  _
    Friend WithEvents BtnDash_Salir As System.Windows.Controls.Border
    
    #End ExternalSource
    
    
    #ExternalSource("..\..\..\..\..\Paginas\Admin\AdminDashboard.xaml",59)
    <System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")>  _
    Friend WithEvents SecondMenu_Grid As System.Windows.Controls.Grid
    
    #End ExternalSource
    
    
    #ExternalSource("..\..\..\..\..\Paginas\Admin\AdminDashboard.xaml",61)
    <System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")>  _
    Friend WithEvents SubMenuGrid As System.Windows.Controls.Primitives.UniformGrid
    
    #End ExternalSource
    
    
    #ExternalSource("..\..\..\..\..\Paginas\Admin\AdminDashboard.xaml",67)
    <System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")>  _
    Friend WithEvents Dash_Frame As System.Windows.Controls.Frame
    
    #End ExternalSource
    
    Private _contentLoaded As Boolean
    
    '''<summary>
    '''InitializeComponent
    '''</summary>
    <System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")>  _
    Public Sub InitializeComponent() Implements System.Windows.Markup.IComponentConnector.InitializeComponent
        If _contentLoaded Then
            Return
        End If
        _contentLoaded = true
        Dim resourceLocater As System.Uri = New System.Uri("/RestPOS;component/paginas/admin/admindashboard.xaml", System.UriKind.Relative)
        
        #ExternalSource("..\..\..\..\..\Paginas\Admin\AdminDashboard.xaml",1)
        System.Windows.Application.LoadComponent(Me, resourceLocater)
        
        #End ExternalSource
    End Sub
    
    <System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0"),  _
     System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never),  _
     System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes"),  _
     System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity"),  _
     System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")>  _
    Sub System_Windows_Markup_IComponentConnector_Connect(ByVal connectionId As Integer, ByVal target As Object) Implements System.Windows.Markup.IComponentConnector.Connect
        If (connectionId = 1) Then
            Me.Recursos = CType(target,System.Windows.ResourceDictionary)
            Return
        End If
        If (connectionId = 2) Then
            Me.Logo_Grid = CType(target,System.Windows.Controls.Grid)
            Return
        End If
        If (connectionId = 3) Then
            Me.MainMenu_Grid = CType(target,System.Windows.Controls.Grid)
            Return
        End If
        If (connectionId = 4) Then
            Me.BtnDash_Dashboard = CType(target,System.Windows.Controls.Border)
            Return
        End If
        If (connectionId = 5) Then
            Me.BtnDash_Reportes = CType(target,System.Windows.Controls.Border)
            Return
        End If
        If (connectionId = 6) Then
            Me.BtnDash_Usuarios = CType(target,System.Windows.Controls.Border)
            Return
        End If
        If (connectionId = 7) Then
            Me.BtnDash_Productos = CType(target,System.Windows.Controls.Border)
            Return
        End If
        If (connectionId = 8) Then
            Me.BtnDash_Mesas = CType(target,System.Windows.Controls.Border)
            Return
        End If
        If (connectionId = 9) Then
            Me.BtnDash_Config = CType(target,System.Windows.Controls.Border)
            Return
        End If
        If (connectionId = 10) Then
            Me.BtnDash_Salir = CType(target,System.Windows.Controls.Border)
            Return
        End If
        If (connectionId = 11) Then
            Me.SecondMenu_Grid = CType(target,System.Windows.Controls.Grid)
            Return
        End If
        If (connectionId = 12) Then
            Me.SubMenuGrid = CType(target,System.Windows.Controls.Primitives.UniformGrid)
            Return
        End If
        If (connectionId = 13) Then
            Me.Dash_Frame = CType(target,System.Windows.Controls.Frame)
            Return
        End If
        Me._contentLoaded = true
    End Sub
End Class

