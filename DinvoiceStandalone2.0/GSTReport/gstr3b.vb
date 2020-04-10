Imports Microsoft.Office.Interop
Imports ExcelAutoFormat = Microsoft.Office.Interop.Excel.XlRangeAutoFormat
Public Class gstr3b

    Private Sub gstr3b_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        MaximizeBox = False
        MinimizeBox = False
        'cmbCmpNm.Focus()
        dtpfromdate.Focus()
    End Sub
    Private Sub DateTimePicker4_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpfromdate.ValueChanged
        Me.txtfromdate.Text = Me.dtpfromdate.Value.Date.ToString("dd/MM/yyyy")
    End Sub

    Private Sub dtptodate_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtptodate.ValueChanged
        Me.txttodate.Text = Me.dtptodate.Value.Date.ToString("dd/MM/yyyy")
    End Sub
    Dim obj As New ObjClass
    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try

       
        Dim fromdate, todate As String
        fromdate = obj.ConvDtFrmt(txtfromdate.Text, "MM/dd/yyyy")
        todate = obj.ConvDtFrmt(txttodate.Text, "MM/dd/yyyy")
        Cursor.Current = Cursors.WaitCursor
            ' QUERY TO FETCH RECORDS FROM THE DATABASE.
            Dim lst As New List(Of String)
            lst.Add("(a) Outward Taxable supplies(other than zero rated,nil rated and exempted)")
            lst.Add("(b) Outward Taxable supplies(zero rated)")
            lst.Add("(c) Other Outward Taxable supplies(Nil rated and Exempted)")
            lst.Add("(d) Inward  supplies(liable to reverse charge)")
            lst.Add("(e) Non GST Outward supplies")
            Dim sSql = "SELECT 'a',sum(item_amount),sum(igst),sum(cgst),sum(sgst),sum(cess_amt) FROM " & _
                "31GSTR3BabcVIEW where taxflg=1 and nilrate_flg=0 and exempt_flg=0 and invoice_dt between #" + fromdate + "# and #" + todate + "# union " & _
                "SELECT 'b',sum(item_amount),sum(igst),sum(cgst),sum(sgst),sum(cess_amt) FROM 31GSTR3BabcVIEW" & _
                " where taxflg=0 and invoice_dt between #" + fromdate + "# and #" + todate + "# union " & _
               "SELECT 'c',sum(item_amount),sum(igst),sum(cgst),sum(sgst),sum(cess_amt) FROM 31GSTR3BabcVIEW" & _
                " where (nilrate_flg=1 or exempt_flg=1) and invoice_dt between #" + fromdate + "# and #" + todate + "# union " & _
               "SELECT 'd',sum(item_amount),sum(igst),sum(cgst),sum(sgst),sum(cess_amt) FROM 31GSTR3BdVIEW" & _
                " where reverse_flg=1 and purchase_dt between #" + fromdate + "# and #" + todate + "# union " & _
               "SELECT 'e',sum(item_amount),'0','0','0','0' FROM 31GSTR3BeVIEW" & _
                " where supply_dt between #" + fromdate + "# and #" + todate + "#"
        Dim xlAppToUpload As New Excel.Application
        xlAppToUpload.Workbooks.Add()
        Dim xlWorkSheetToUpload As Excel.Worksheet
        xlWorkSheetToUpload = xlAppToUpload.Sheets("Sheet1")
        ' SHOW EXCEL APPLICATION. 

        ' (ALSO, SET IT TRUE WHEN THE DATA IS EXPORTED TO THE EXCEL SHEET.) 
        xlAppToUpload.Visible = True
        Dim iRowCnt As Integer
        Dim dt = obj.getdatatable(sSql)
        Try

            iRowCnt = 4         ' ROW AT WHICH PRINT WILL START.

            With xlWorkSheetToUpload
                ' SHOW AN HEADER.
                .Cells(1, 1).value = "Details of Outward Supplies and inward supplies liable to reverge charge"
                '.Cells(1, 1).FONT.NAME = "Calibri"
                '.Cells(1, 1).Font.Bold = True
                '.Cells(1, 1).Font.Size = 20


                .Range("A1:F1").MergeCells = True   ' MERGE CELLS OF THE HEADER.





                ' SHOW COLUMNS ON THE TOP.
                    .Cells(iRowCnt - 1, 1).value = "Nature of Supplies"
                    .Cells(iRowCnt - 1, 1).Font.Bold = True
                    .Cells(iRowCnt - 1, 2).value = "Total Taxable Value"
                    .Cells(iRowCnt - 1, 2).Font.Bold = True
                    .Cells(iRowCnt - 1, 3).value = "Integrated Tax"
                    .Cells(iRowCnt - 1, 3).Font.Bold = True
                    .Cells(iRowCnt - 1, 4).value = "Central tax"
                    .Cells(iRowCnt - 1, 4).Font.Bold = True
                    .Cells(iRowCnt - 1, 5).value = "State/UT Tax"
                    .Cells(iRowCnt - 1, 5).Font.Bold = True
                    .Cells(iRowCnt - 1, 6).value = "Cess"
                    .Cells(iRowCnt - 1, 6).Font.Bold = True

                    
                    
                    For i = 0 To dt.Rows.Count - 1
                       
                        .Cells(iRowCnt, 1).value = lst(i)
                        .Cells(iRowCnt, 2).value = If(dt.Rows(i).Item(1).ToString = "", "0", dt.Rows(i).Item(1).ToString)
                        .Cells(iRowCnt, 3).value = If(dt.Rows(i).Item(2).ToString = "", "0", dt.Rows(i).Item(2).ToString)
                        .Cells(iRowCnt, 4).value = If(dt.Rows(i).Item(3).ToString = "", "0", dt.Rows(i).Item(3).ToString)
                        .Cells(iRowCnt, 5).value = If(dt.Rows(i).Item(4).ToString = "", "0", dt.Rows(i).Item(4).ToString)
                        .Cells(iRowCnt, 6).value = If(dt.Rows(i).Item(5).ToString = "", "0", dt.Rows(i).Item(5).ToString)
                        iRowCnt = iRowCnt + 1
                    Next

                    iRowCnt = iRowCnt + 2

                    .Cells(iRowCnt, 1).value = "5. Value of exempt,Nil-rated and non-GST inward supplies"
                    '.Cells(1, 1).FONT.NAME = "Calibri"
                    '.Cells(1, 1).Font.Bold = True
                    '.Cells(1, 1).Font.Size = 20


                    .Range("A" & iRowCnt & ":C" & iRowCnt & "").MergeCells = True   ' MERGE CELLS OF THE HEADER.





                    ' SHOW COLUMNS ON THE TOP.
                    .Cells(iRowCnt + 1, 1).value = "Nature of Supplies"
                    .Cells(iRowCnt + 1, 1).Font.Bold = True
                    .Cells(iRowCnt + 1, 2).value = "Inter-State Supplies"
                    .Cells(iRowCnt + 1, 2).Font.Bold = True
                    .Cells(iRowCnt + 1, 3).value = "Intra-State Supplies"
                    .Cells(iRowCnt + 1, 3).Font.Bold = True
                    iRowCnt = iRowCnt + 1

                    Dim get5data As New List(Of String)
                    get5data = obj.GetMoreValueFromQuery("SELECT 'From a supplier under composition scheme,exempt and nil rated supply',sum(igst),sum(cgst+sgst) FROM 31GSTR3BdVIEW " & _
                " where (nilrate_flg=1 or exempt_flg=1) and purchase_dt between #" + fromdate + "# and #" + todate + "# and gst_treatment='Composite Taxable Person'", 3)
                    .Cells(iRowCnt + 1, 1).value = get5data(0)
                    .Cells(iRowCnt + 1, 2).value = If(get5data(1) = "", "0", get5data(1))
                    .Cells(iRowCnt + 1, 3).value = If(get5data(2) = "", "0", get5data(2))
                    iRowCnt = iRowCnt + 1
                    .Cells(iRowCnt + 1, 1).value = "Non GST supply"
                    .Cells(iRowCnt + 1, 2).value = "0"
                    .Cells(iRowCnt + 1, 3).value = "0"
                    iRowCnt = iRowCnt + 1
                    .Cells(iRowCnt + 1, 1).value = "Total"
                    .Cells(iRowCnt + 1, 2).value = If(get5data(1) = "", "0", get5data(1))
                    .Cells(iRowCnt + 1, 3).value = If(get5data(2) = "", "0", get5data(2))
                    iRowCnt = iRowCnt + 1


                    iRowCnt = iRowCnt + 2

                    .Cells(iRowCnt, 1).value = "3.2 Of the supplies shown in 3.1(a), details of inter-state supplies made to unregistered persons,composition taxable person and UIN holders"
                    '.Cells(1, 1).FONT.NAME = "Calibri"
                    '.Cells(1, 1).Font.Bold = True
                    '.Cells(1, 1).Font.Size = 20


                    .Range("A" & iRowCnt & ":G" & iRowCnt & "").MergeCells = True
                    .Range("A" & (iRowCnt + 1) & ":A" & (iRowCnt + 2) & "").MergeCells = True
                    .Range("B" & (iRowCnt + 1) & ":C" & (iRowCnt + 1) & "").MergeCells = True
                    .Range("D" & (iRowCnt + 1) & ":E" & (iRowCnt + 1) & "").MergeCells = True
                    .Range("F" & (iRowCnt + 1) & ":G" & (iRowCnt + 1) & "").MergeCells = True

                    .Cells(iRowCnt + 1, 1).value = "Place Of Supply(State/UT)"
                    .Cells(iRowCnt + 1, 1).Font.Bold = True
                    .Cells(iRowCnt + 1, 2).value = "Supplies made to Unregistered Persons"
                    .Cells(iRowCnt + 1, 2).Font.Bold = True
                    .Cells(iRowCnt + 1, 4).value = "Supplies made to Composite Taxable Persons"
                    .Cells(iRowCnt + 1, 4).Font.Bold = True
                    .Cells(iRowCnt + 1, 6).value = "Supplies made to UIN Holders"
                    .Cells(iRowCnt + 1, 6).Font.Bold = True

                    iRowCnt = iRowCnt + 1

                    .Cells(iRowCnt + 1, 2).value = "Total Taxable Value"
                    .Cells(iRowCnt + 1, 2).Font.Bold = True
                    .Cells(iRowCnt + 1, 3).value = "Amount of Integrated Tax"
                    .Cells(iRowCnt + 1, 3).Font.Bold = True
                    .Cells(iRowCnt + 1, 4).value = "Total Taxable Value"
                    .Cells(iRowCnt + 1, 4).Font.Bold = True
                    .Cells(iRowCnt + 1, 5).value = "Amount of Integrated Tax"
                    .Cells(iRowCnt + 1, 5).Font.Bold = True
                    .Cells(iRowCnt + 1, 6).value = "Total Taxable Value"
                    .Cells(iRowCnt + 1, 6).Font.Bold = True
                    .Cells(iRowCnt + 1, 7).value = "Amount of Integrated Tax"
                    .Cells(iRowCnt + 1, 7).Font.Bold = True

                    iRowCnt = iRowCnt + 1



                    Dim getps = obj.getcolumndatafromquery("select distinct(place_supply) from 32GSTR3BVIEW where invoice_dt between #" + fromdate + "# and #" + todate + "# and gsttype='IGST'")

                    If getps.Count = 0 Then


                    Else
                        For i = 0 To getps.Count - 1
                            .Cells(iRowCnt + 1, 1).value = getps(i)
                            Dim dt32up = obj.GetMoreValueFromQuery("select sum(subtotal),sum(taxamt)  from 32GSTR3BVIEW where invoice_dt" & _
                                                                  " between #" + fromdate + "# and #" + todate + "# and gsttype='IGST' and" & _
                                                                  " place_supply='" + getps(i) + "' and gst_treatment='UnRegistered Business'", 2)
                            .Cells(iRowCnt + 1, 2).value = If(dt32up(0) = "", "0", dt32up(0))
                            .Cells(iRowCnt + 1, 3).value = If(dt32up(1) = "", "0", dt32up(1))


                            Dim dt32ctp = obj.GetMoreValueFromQuery("select sum(subtotal),sum(taxamt)  from 32GSTR3BVIEW where invoice_dt" & _
                                                               " between #" + fromdate + "# and #" + todate + "# and gsttype='IGST' and" & _
                                                               " place_supply='" + getps(i) + "' and gst_treatment='Composite Taxable Person'", 2)
                            .Cells(iRowCnt + 1, 4).value = If(dt32ctp(0) = "", "0", dt32ctp(0))
                            .Cells(iRowCnt + 1, 5).value = If(dt32ctp(1) = "", "0", dt32ctp(1))
                            Dim dt32rp = obj.GetMoreValueFromQuery("select sum(subtotal),sum(taxamt)  from 32GSTR3BVIEW where invoice_dt" & _
                                                               " between #" + fromdate + "# and #" + todate + "# and gsttype='IGST' and" & _
                                                               " place_supply='" + getps(i) + "' and gst_treatment='Registered Business'", 2)
                            .Cells(iRowCnt + 1, 6).value = If(dt32rp(0) = "", "0", dt32rp(0))
                            .Cells(iRowCnt + 1, 7).value = If(dt32rp(1) = "", "0", dt32rp(1))

                        Next
                    End If
                   

                    ' SHOW COLUMNS ON THE TOP.


                End With

            ' FINALLY, FORMAT THE EXCEL SHEET USING EXCEL'S AUTOFORMAT FUNCTION.
                'xlAppToUpload.ActiveCell.Worksheet.Cells(4, 1).AutoFormat(ExcelAutoFormat.xlRangeAutoFormatList3)


        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            xlAppToUpload = Nothing : xlWorkSheetToUpload = Nothing
        End Try

            Cursor.Current = Cursors.Default


        Catch ex As Exception

        End Try
    End Sub
End Class