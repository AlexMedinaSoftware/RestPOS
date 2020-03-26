Imports System.IO
Imports System.Text
Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.Drawing.Printing
Imports Microsoft.Reporting.WebForms

Module PrintModule

    Private m_currentPageIndex As Integer
    Private m_streams As IList(Of Stream)
    Private printdoc As PrintDocument

    ''' <summary>
    ''' Print rdlc report with custom page width and height
    ''' </summary>
    ''' <param name="report"></param>
    ''' <param name="islandscap"></param>
    ''' <param name="printer_name">Ignore this parameter to use default printer</param>
    ''' <remarks></remarks>
    Public Sub print_microsoft_report(ByRef report As LocalReport, Optional ByVal islandscap As Boolean = False, Optional ByVal printer_name As String = Nothing)
        printdoc = New PrintDocument()
        If printer_name <> Nothing Then printdoc.PrinterSettings.PrinterName = printer_name
        If Not printdoc.PrinterSettings.IsValid Then ' detecate is the printer is exist
            Throw New Exception("Cannot find the specified printer")
        Else
            printdoc.DefaultPageSettings.PaperSize = report.GetDefaultPageSettings.PaperSize
            printdoc.PrinterSettings.DefaultPageSettings.PaperSize = report.GetDefaultPageSettings.PaperSize
            printdoc.DefaultPageSettings.Landscape = islandscap
            Export(report)
            Print()
        End If
    End Sub

    ' Routine to provide to the report renderer, in order to
    ' save an image for each page of the report.
    Private Function CreateStream(ByVal name As String, ByVal fileNameExtension As String, ByVal encoding As Encoding, ByVal mimeType As String, ByVal willSeek As Boolean) As Stream
        Dim stream As Stream = New MemoryStream()
        m_streams.Add(stream)
        Return stream
    End Function
    ' Export the given report as an EMF (Enhanced Metafile) file.
    Private Sub Export(ByVal report As LocalReport)
        Dim w As Integer
        Dim h As Integer
        If printdoc.DefaultPageSettings.Landscape = True Then
            w = report.GetDefaultPageSettings.PaperSize.Height
            h = report.GetDefaultPageSettings.PaperSize.Width
        Else
            w = report.GetDefaultPageSettings.PaperSize.Width
            h = report.GetDefaultPageSettings.PaperSize.Height
        End If
        Dim deviceInfo As String = "<DeviceInfo>" &
                "<OutputFormat>EMF</OutputFormat>" &
                "<PageWidth>" & w / 100 & "in</PageWidth>" &
                "<PageHeight>" & h / 100 & "in</PageHeight>" &
                "<MarginTop>0in</MarginTop>" &
                "<MarginLeft>0in</MarginLeft>" &
                "<MarginRight>0in</MarginRight>" &
                "<MarginBottom>0in</MarginBottom>" &
                "</DeviceInfo>"
        Dim warnings As Warning()
        m_streams = New List(Of Stream)()
        report.Render("Image", deviceInfo, AddressOf CreateStream, warnings)
        For Each stream As Stream In m_streams
            stream.Position = 0
        Next
    End Sub

    ' Handler for PrintPageEvents
    Private Sub PrintPage(ByVal sender As Object, ByVal ev As PrintPageEventArgs)
        Dim pageImage As New Metafile(m_streams(m_currentPageIndex))

        ' Adjust rectangular area with printer margins.
        Dim adjustedRect As New Rectangle(ev.PageBounds.Left - CInt(ev.PageSettings.HardMarginX),
                                              ev.PageBounds.Top - CInt(ev.PageSettings.HardMarginY),
                                              ev.PageBounds.Width,
                                              ev.PageBounds.Height)

        ' Draw a white background for the report
        ev.Graphics.FillRectangle(Brushes.White, adjustedRect)

        ' Draw the report content
        ev.Graphics.DrawImage(pageImage, adjustedRect)

        ' Prepare for the next page. Make sure we haven't hit the end.
        m_currentPageIndex += 1
        ev.HasMorePages = (m_currentPageIndex < m_streams.Count)

        pageImage.Dispose()
    End Sub
    Private Sub Print()
        If m_streams Is Nothing OrElse m_streams.Count = 0 Then
            Throw New Exception("Error: no stream to print.")
        End If
        AddHandler printdoc.PrintPage, AddressOf PrintPage
        m_currentPageIndex = 0
        printdoc.Print()
    End Sub

End Module
