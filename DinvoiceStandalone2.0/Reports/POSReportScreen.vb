Imports Microsoft.Reporting.WinForms
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Drawing.Printing
Imports System.IO
Imports System.Drawing.Imaging

Public Class POSReportScreen
    Dim obj As New ObjClass
    Dim S As New SharedData


    Private Sub ReportScreen_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed

    End Sub
    Private Sub ReportScreen_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        MaximizeBox = False
        MinimizeBox = False
        Me.BringToFront()
        Me.Focus()
        If S.GetPOSReportInvoiceno() <> "" Then
            InvoiceReport(S.GetPOSReportInvoiceno())
            S.ClearPOSReportInvoiceno()
        End If
        If S.GetPOSReportSupplyno() <> "" Then
            SupplyReport(S.GetPOSReportSupplyno())
            S.ClearPOSReportSupplyno()
        End If
        Me.ReportViewer1.RefreshReport()
    End Sub




    Sub InvoiceReport(ByVal p1 As String)
        Try
            Dim dssub As New SubReport
            Dim logoimg As New Logo
            Dim listdata As New List(Of String)
            Dim dr1 As Data.DataRow
            Dim dtsubreport, dtlogo As New DataTable
            dtsubreport = obj.getdatatable("select item_name & '-' & item_desc, gst_id, unit_format, item_qty, item_rate, item_disc, item_amount,item_tax,item_cess,tax_amt,cess_amt from InvoiceSubReport where invoice_no='" + p1 + "'")
            For i = 0 To dtsubreport.Rows.Count - 1
                dr1 = dssub.Tables("InvoiceTail").NewRow()
                dr1("No") = i + 1
                dr1("Name") = dtsubreport.Rows(i).Item(0).ToString
                dr1("HSNSAC") = dtsubreport.Rows(i).Item(1).ToString
                dr1("UOM") = dtsubreport.Rows(i).Item(2).ToString
                dr1("Qty") = dtsubreport.Rows(i).Item(3).ToString
                dr1("Rate") = dtsubreport.Rows(i).Item(4).ToString
                dr1("discpercent") = dtsubreport.Rows(i).Item(5).ToString
                dr1("Amount") = dtsubreport.Rows(i).Item(6).ToString
                dr1("taxpercent") = dtsubreport.Rows(i).Item(7).ToString
                dr1("TotalAmt") = (CDbl(dtsubreport.Rows(i).Item(6).ToString) + CDbl(dtsubreport.Rows(i).Item(9).ToString) + CDbl(dtsubreport.Rows(i).Item(10).ToString)).ToString
                dssub.Tables("InvoiceTail").Rows.Add(dr1)
            Next
            listdata = obj.GetMoreValueFromQuery("select user_invoice_no, invoice_dt, " & _
                                               "ref_no,  billing_state," & _
                                               " pan_no, comp_company_name, " & _
                                               "comp_billing_address, billing_city, " & _
                                               "billing_state, comp_phone_no," & _
                                               "  comp_gst_no, company_name," & _
                                               "  cont_billing_address,ship_address, " & _
                                               " cont_gst_no, cont_place_supply, " & _
                                               "cont_phone_no, email_id, customer_savings," & _
                                               " sub_total, overall_disc_percent,total_tax," & _
                                               " shpcost_amt,advance_flg, roundoff_amt," & _
                                               " grand_total,reverse_flg,company_id," & _
                                               " invoice_no, contact_no,total_cess,counter_no,user_name  " & _
                                               "from InvoiceMainReport where invoice_no='" + p1 + "'", 33)


            Dim rptDataSource1 As ReportDataSource
            Try
                rptDataSource1 = New ReportDataSource("DataSet2", dssub.Tables("InvoiceTail"))
                ReportViewer1.ProcessingMode = ProcessingMode.Local

                ReportViewer1.LocalReport.ReportPath = "" + Application.StartupPath + "\PosRpt.rdlc"


                Dim myParam1 As New ReportParameter("invoiceno", listdata(0))
                ReportViewer1.LocalReport.SetParameters(myParam1)
                Dim myParam2 As New ReportParameter("invoicedt", listdata(1))
                ReportViewer1.LocalReport.SetParameters(myParam2)

                Dim myParam4 As New ReportParameter("companyname", listdata(5))
                ReportViewer1.LocalReport.SetParameters(myParam4)
                Dim myParam5 As New ReportParameter("companyaddr", listdata(6))
                ReportViewer1.LocalReport.SetParameters(myParam5)
                Dim myParam6 As New ReportParameter("companyphoneno", listdata(9))
                ReportViewer1.LocalReport.SetParameters(myParam6)



                Dim myParam12 As New ReportParameter("subtotal", listdata(19))
                ReportViewer1.LocalReport.SetParameters(myParam12)

                Dim myParam14 As New ReportParameter("grandtotal", listdata(25))
                ReportViewer1.LocalReport.SetParameters(myParam14)


                Dim myParam16 As New ReportParameter("companygstno", listdata(10))
                ReportViewer1.LocalReport.SetParameters(myParam16)



                Dim myParam20 As New ReportParameter("discpercent", listdata(20))
                ReportViewer1.LocalReport.SetParameters(myParam20)

                Dim myParam22 As New ReportParameter("roundoff", listdata(24))
                ReportViewer1.LocalReport.SetParameters(myParam22)

                Dim myParam23 As New ReportParameter("cgst", CDbl(listdata(21)) / 2)
                ReportViewer1.LocalReport.SetParameters(myParam23)
                Dim myParam24 As New ReportParameter("sgst", CDbl(listdata(21)) / 2)
                ReportViewer1.LocalReport.SetParameters(myParam24)

                Dim myParam28 As New ReportParameter("cussave", listdata(18))
                ReportViewer1.LocalReport.SetParameters(myParam28)

                Dim myParam29 As New ReportParameter("amountinwords", obj.AmountInWords(listdata(25)))
                ReportViewer1.LocalReport.SetParameters(myParam29)
                Dim cess As Double = listdata(30)
                Dim myParam30 As New ReportParameter("taxinwords", obj.AmountInWords(CDbl(listdata(21)) + cess))
                ReportViewer1.LocalReport.SetParameters(myParam30)


                Dim myParam32 As New ReportParameter("cashiername", listdata(32))
                ReportViewer1.LocalReport.SetParameters(myParam32)

                Dim myParam31 As New ReportParameter("counterno", listdata(31))
                ReportViewer1.LocalReport.SetParameters(myParam31)
                Dim compositeflg As Integer = obj.GetOneValueFromQuery("select composite_flg from company_tbl where company_id=" + SharedData.companyid + "")
                Dim myParam33 As New ReportParameter("compositetax", If(compositeflg = 1, "Compound tax paid under GST", ""))
                ReportViewer1.LocalReport.SetParameters(myParam33)


                ReportViewer1.LocalReport.Refresh()
                ReportViewer1.LocalReport.DataSources.Add(rptDataSource1)
                ReportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.Normal)
                ReportViewer1.PrintDialog()
                'Dim printDoc As New PrintDocument()
                'printDoc.PrinterSettings.PrinterName = "<your default printer name>"
                'Dim ps As New PrinterSettings()
                'ps.PrinterName = printDoc.PrinterSettings.PrinterName
                'printDoc.PrinterSettings = ps

                'printDoc.PrintPage += New PrintPageEventHandler(PrintPage)
                'm_currentPageIndex = 0
                'printDoc.Print()
                'Dim report As New LocalReport()
                'report.ReportEmbeddedResource = "" + Application.StartupPath + "\PosRpt.rdlc"
                'report.DataSources.Add(New ReportDataSource("DataSet2", dssub.Tables("InvoiceTail")))



                'Dim report As New LocalReport()
                'report.ReportPath = "" + Application.StartupPath + "\PosRpt.rdlc"
                'report.DataSources.Add(New ReportDataSource("DataSet2", dssub.Tables("InvoiceTail")))
                'Export(report)
                'Print()

                'PrintDocument1.PrinterSettings.PrinterName = GetDefaultPrinter()
                'PrintDocument1.DocumentName = "" + Application.StartupPath + "\PosRpt.rdlc"
                'PrintDocument1.Print()
                ' PrintDialog1.ShowDialog()
                'ReportViewer1.LocalReport.()



                'ReportViewer1.Clear()
                'ReportViewer1.LocalReport.ReleaseSandboxAppDomain()

                'Dim printerSettings As New PrinterSettings()
                'Dim printDialog As New PrintDialog()
                'printDialog.PrinterSettings = PrinterSettings
                'printDialog.AllowPrintToFile = False
                'printDialog.AllowSomePages = True
                'printDialog.UseEXDialog = True
                'Dim result As DialogResult = printDialog.ShowDialog()

                'If result = DialogResult.Cancel Then
                '    Exit Sub
                'End If
                'Dim report As New LocalReport()
                'report.ReportPath = "" + Application.StartupPath + "\PosRpt.rdlc"
                'report.PrintOptions.PrinterName = printerSettings.PrinterName
                'report.PrintToPrinter(printerSettings.Copies, False, 0, 0)

                ReportViewer1.Focus()


            Catch ex As Exception

            End Try






        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Protected Overrides Function ProcessCmdKey(ByRef msg As System.Windows.Forms.Message, ByVal keyData As Keys) As Boolean
        Select Case msg.Msg
            Case &H100, &H104
                Select Case keyData

                    Case Keys.Enter
                        ReportViewer1.PrintDialog()
                        'ReportViewer1.PrinterSettings.PrinterName = GetDefaultPrinter()
                        'ReportViewer1.DocumentName = "" + Application.StartupPath + "\PosRpt.rdlc"
                        'ReportViewer1.Print()
                        Me.Close()
                End Select
                Exit Select
        End Select
        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function
    Function GetDefaultPrinter() As String
        Dim settings As New PrinterSettings()
        For Each printer As String In PrinterSettings.InstalledPrinters
            settings.PrinterName = printer
            If settings.IsDefaultPrinter Then
                Return printer
            End If
        Next
        Return String.Empty
    End Function
 

  
    Private m_currentPageIndex As Integer
    Private m_streams As IList(Of Stream)

    Private Function LoadSalesData() As DataTable
        ' Create a new DataSet and read sales data file 
        ' data.xml into the first DataTable.
        Dim dataSet As New DataSet()
        dataSet.ReadXml("..\..\data.xml")
        Return dataSet.Tables(0)
    End Function

    ' Routine to provide to the report renderer, in order to
    ' save an image for each page of the report.
    Private Function CreateStream(ByVal name As String, ByVal fileNameExtension As String, ByVal encoding As System.Text.Encoding, ByVal mimeType As String, ByVal willSeek As Boolean) As Stream
        Dim stream As Stream = New MemoryStream()
        m_streams.Add(stream)
        Return stream
    End Function
    Private Sub Export(ByVal report As LocalReport)
        Dim deviceInfo As String = "<DeviceInfo>" & _
            "<OutputFormat>EMF</OutputFormat>" & _
            "<PageWidth>8.5in</PageWidth>" & _
            "<PageHeight>11in</PageHeight>" & _
            "<MarginTop>0.25in</MarginTop>" & _
            "<MarginLeft>0.25in</MarginLeft>" & _
            "<MarginRight>0.25in</MarginRight>" & _
            "<MarginBottom>0.25in</MarginBottom>" & _
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
        Dim adjustedRect As New Rectangle(ev.PageBounds.Left - CInt(ev.PageSettings.HardMarginX), _
                                          ev.PageBounds.Top - CInt(ev.PageSettings.HardMarginY), _
                                          ev.PageBounds.Width, _
                                          ev.PageBounds.Height)

        ' Draw a white background for the report
        ev.Graphics.FillRectangle(Brushes.White, adjustedRect)

        ' Draw the report content
        ev.Graphics.DrawImage(pageImage, adjustedRect)

        ' Prepare for the next page. Make sure we haven't hit the end.
        m_currentPageIndex += 1
        ev.HasMorePages = (m_currentPageIndex < m_streams.Count)
    End Sub

    Private Sub Print()
        If m_streams Is Nothing OrElse m_streams.Count = 0 Then
            Throw New Exception("Error: no stream to print.")
        End If
        Dim printDoc As New PrintDocument()
        If Not printDoc.PrinterSettings.IsValid Then
            Throw New Exception("Error: cannot find the default printer.")
        Else
            AddHandler printDoc.PrintPage, AddressOf PrintPage
            m_currentPageIndex = 0
            printDoc.Print()
        End If
    End Sub

    Private Sub SupplyReport(ByVal p1 As String)
        Try
            Dim dssub As New SubReport
            Dim logoimg As New Logo
            Dim listdata As New List(Of String)
            Dim dr1 As Data.DataRow
            Dim dtsubreport, dtlogo As New DataTable
            dtsubreport = obj.getdatatable("select item_name & '-' & item_desc, gst_id, unit_format, item_qty, item_rate, item_disc, item_amount,0,0,0,0 from SupplySubReport where supply_no='" + p1 + "'")
            For i = 0 To dtsubreport.Rows.Count - 1
                dr1 = dssub.Tables("InvoiceTail").NewRow()
                dr1("No") = i + 1
                dr1("Name") = dtsubreport.Rows(i).Item(0).ToString
                dr1("HSNSAC") = dtsubreport.Rows(i).Item(1).ToString
                dr1("UOM") = dtsubreport.Rows(i).Item(2).ToString
                dr1("Qty") = dtsubreport.Rows(i).Item(3).ToString
                dr1("Rate") = dtsubreport.Rows(i).Item(4).ToString
                dr1("discpercent") = dtsubreport.Rows(i).Item(5).ToString
                dr1("Amount") = dtsubreport.Rows(i).Item(6).ToString
                dr1("taxpercent") = dtsubreport.Rows(i).Item(7).ToString
                dr1("TotalAmt") = (CDbl(dtsubreport.Rows(i).Item(6).ToString) + CDbl(dtsubreport.Rows(i).Item(9).ToString) + CDbl(dtsubreport.Rows(i).Item(10).ToString)).ToString
                dssub.Tables("InvoiceTail").Rows.Add(dr1)
            Next
            listdata = obj.GetMoreValueFromQuery("select user_supply_no, supply_dt, " & _
                                               "ref_no,  billing_state," & _
                                               " pan_no, comp_company_name, " & _
                                               "comp_billing_address, billing_city, " & _
                                               "billing_state, comp_phone_no," & _
                                               "  comp_gst_no, company_name," & _
                                               "  cont_billing_address,ship_address, " & _
                                               " cont_gst_no, cont_place_supply, " & _
                                               "cont_phone_no, email_id, customer_savings," & _
                                               " sub_total, overall_disc_percent,overall_disc_amt," & _
                                               " shpcost_amt,advance_flg, roundoff_amt," & _
                                               " grand_total,0,company_id," & _
                                               " supply_no, contact_no,0,counter_no,user_name  " & _
                                               "from supplyMainReport where supply_no='" + p1 + "'", 33)


            Dim rptDataSource1 As ReportDataSource
            Try
                rptDataSource1 = New ReportDataSource("DataSet2", dssub.Tables("InvoiceTail"))
                ReportViewer1.ProcessingMode = ProcessingMode.Local

                ReportViewer1.LocalReport.ReportPath = "" + Application.StartupPath + "\PosSupplyRpt.rdlc"


                Dim myParam1 As New ReportParameter("invoiceno", listdata(0))
                ReportViewer1.LocalReport.SetParameters(myParam1)
                Dim myParam2 As New ReportParameter("invoicedt", listdata(1))
                ReportViewer1.LocalReport.SetParameters(myParam2)

                Dim myParam4 As New ReportParameter("companyname", listdata(5))
                ReportViewer1.LocalReport.SetParameters(myParam4)
                Dim myParam5 As New ReportParameter("companyaddr", listdata(6))
                ReportViewer1.LocalReport.SetParameters(myParam5)
                Dim myParam6 As New ReportParameter("companyphoneno", listdata(9))
                ReportViewer1.LocalReport.SetParameters(myParam6)



                Dim myParam12 As New ReportParameter("subtotal", listdata(19))
                ReportViewer1.LocalReport.SetParameters(myParam12)

                Dim myParam14 As New ReportParameter("grandtotal", listdata(25))
                ReportViewer1.LocalReport.SetParameters(myParam14)


                Dim myParam16 As New ReportParameter("companygstno", listdata(10))
                ReportViewer1.LocalReport.SetParameters(myParam16)



                Dim myParam20 As New ReportParameter("discpercent", listdata(20))
                ReportViewer1.LocalReport.SetParameters(myParam20)

                Dim myParam22 As New ReportParameter("roundoff", listdata(24))
                ReportViewer1.LocalReport.SetParameters(myParam22)

                Dim myParam23 As New ReportParameter("cgst", "")
                ReportViewer1.LocalReport.SetParameters(myParam23)
                Dim myParam24 As New ReportParameter("sgst", "")
                ReportViewer1.LocalReport.SetParameters(myParam24)

                Dim myParam28 As New ReportParameter("cussave", listdata(18))
                ReportViewer1.LocalReport.SetParameters(myParam28)

                Dim myParam29 As New ReportParameter("amountinwords", obj.AmountInWords(listdata(25)))
                ReportViewer1.LocalReport.SetParameters(myParam29)
                Dim cess As Double = listdata(30)
                Dim myParam30 As New ReportParameter("taxinwords", "")
                ReportViewer1.LocalReport.SetParameters(myParam30)


                Dim myParam32 As New ReportParameter("cashiername", listdata(32))
                ReportViewer1.LocalReport.SetParameters(myParam32)

                Dim myParam31 As New ReportParameter("counterno", listdata(31))
                ReportViewer1.LocalReport.SetParameters(myParam31)
                Dim compositeflg As Integer = obj.GetOneValueFromQuery("select composite_flg from company_tbl where company_id=" + SharedData.companyid + "")
                Dim myParam33 As New ReportParameter("compositetax", If(compositeflg = 1, "Compound tax paid under GST", ""))
                ReportViewer1.LocalReport.SetParameters(myParam33)


                ReportViewer1.LocalReport.Refresh()
                ReportViewer1.LocalReport.DataSources.Add(rptDataSource1)
                ReportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.Normal)
                ReportViewer1.PrintDialog()
                

                ReportViewer1.Focus()


            Catch ex As Exception

            End Try






        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


   

   
   
End Class