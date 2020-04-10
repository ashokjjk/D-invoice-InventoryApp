Imports System.IO
Imports ClosedXML.Excel
Imports Microsoft.Office.Interop

Public Class CustomerWiseSale

    Private Sub CustomerWiseSale_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        MaximizeBox = False
        MinimizeBox = False
        Panel3.Visible = False
        lstbxDetails.Visible = False
        cmbstate.Items.Clear()
        txtSearchKeyword.Focus()
        Dim state = obj.getcolumndatafromquery("select indian_state from state_tbl")
        For i = 0 To state.Count - 1
            cmbstate.Items.Add(state(i))
        Next
    End Sub


    Private Sub rbtPlaceofSupply_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtPlaceofSupply.CheckedChanged
        Select Case rbtPlaceofSupply.Checked
            Case True
                Panel3.Visible = True
            Case False
                Panel3.Visible = False
        End Select
    End Sub

    Private Sub rbtPaymode_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtPaymode.CheckedChanged
        Select Case rbtPaymode.Checked
            Case True
                Panel4.Visible = True
            Case False
                Panel4.Visible = False
        End Select
    End Sub
    Dim obj As New ObjClass
    Private Sub DateTimePicker2_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtptodate.ValueChanged
        obj.dtpick(txttodate, dtptodate)
    End Sub
    Private Sub DateTimePicker1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpfromdate.ValueChanged
        obj.dtpick(txtfromdate, dtpfromdate)
    End Sub
    Private Sub lstClientName_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lstbxDetails.MouseClick
        lstbxDetails.Visible = False
        If lstbxDetails.Text = "Add New" Then
            Contacts.Show()
            Contacts.BringToFront()
            Contacts.Focus()
        Else
            Try
                lstbxDetails.Visible = False
                txtSearchKeyword.Text = lstbxDetails.Text
                lblcuscode.Text = lstbxDetails.SelectedValue
            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub txtClientName_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSearchKeyword.KeyUp
        lblcuscode.Text = ""
        lstbxDetails.Visible = True
        lstbxDetails.BringToFront()
        Dim listclientname As New DataTable
        lstbxDetails.DataSource = Nothing
        If txtSearchKeyword.Text = "" Then
            lstbxDetails.Visible = False
        Else
            listclientname = obj.getdatatable("select company_name,contact_no from contact_tbl where company_name like '%" + txtSearchKeyword.Text + "%'")
            lstbxDetails.DisplayMember = "company_name"
            lstbxDetails.ValueMember = "contact_no"
            lstbxDetails.DataSource = listclientname
            lstbxDetails.Visible = True
        End If
    End Sub
    Private Sub FillDataGridView()
        Try
            gridInvoice.Rows.Clear()
            Dim invoicenolist As New List(Of String)
            If rbtPlaceofSupply.Checked = True Then
                If txtfromdate.Text <> "" And txttodate.Text <> "" Then
                    invoicenolist = obj.getcolumndatafromquery("select invoice_no from invoice_hdr where contact_no='" + lblcuscode.Text + "' " & _
                                                         "and place_supply='" + cmbstate.Text + "' and invoice_dt " & _
                                                         "between #" + obj.ConvDtFrmt(txtfromdate.Text, "MM/dd/yyyy") + "# and #" + obj.ConvDtFrmt(txttodate.Text, "MM/dd/yyyy") + "# " & _
                                                         "and company_id=" + SharedData.companyid + "")
                Else
                    invoicenolist = obj.getcolumndatafromquery("select invoice_no from invoice_hdr where contact_no='" + lblcuscode.Text + "' " & _
                                                                 "and place_supply='" + cmbstate.Text + "' and company_id=" + SharedData.companyid + "")
                End If
              
            ElseIf rbtPaymode.Checked = True Then
                If txtfromdate.Text <> "" And txttodate.Text <> "" Then

                    invoicenolist = obj.getcolumndatafromquery("select invoice_no from invoice_hdr where contact_no='" + lblcuscode.Text + "' " & _
                                                               "and payment_status=" & If(cmpPaidStatus.Text = "Paid", 1, 0) & " and " & _
                                                               "invoice_dt between #" + obj.ConvDtFrmt(txtfromdate.Text, "MM/dd/yyyy") + "# and #" + obj.ConvDtFrmt(txttodate.Text, "MM/dd/yyyy") + "# " & _
                                                               "and company_id=" + SharedData.companyid + "")
                Else

                    invoicenolist = obj.getcolumndatafromquery("select invoice_no from invoice_hdr where contact_no='" + lblcuscode.Text + "' " & _
                                                               "and payment_status=" & If(cmpPaidStatus.Text = "Paid", 1, 0) & " " & _
                                                               "and company_id=" + SharedData.companyid + "")
                End If

            Else
                invoicenolist = obj.getcolumndatafromquery("select invoice_no from invoice_hdr where contact_no='" + lblcuscode.Text + "' " & _
                                                           "and invoice_dt between #" + obj.ConvDtFrmt(txtfromdate.Text, "MM/dd/yyyy") + "# and" & _
                                                           " #" + obj.ConvDtFrmt(txttodate.Text, "MM/dd/yyyy") + "#  and company_id=" + SharedData.companyid + "")

            End If
            gridInvoice.ColumnCount = 11
            gridInvoice.Columns(0).Name = "Invoice No"
            gridInvoice.Columns(1).Name = "RefNo"
            gridInvoice.Columns(2).Name = "Date"
            gridInvoice.Columns(3).Name = "Place Of Supply"
            gridInvoice.Columns(4).Name = "Sub Total"
            gridInvoice.Columns(5).Name = "IGST"
            gridInvoice.Columns(6).Name = "SGST"
            gridInvoice.Columns(7).Name = "CGST"
            gridInvoice.Columns(8).Name = "GrandTotal"
            gridInvoice.Columns(9).Name = "VoucherNo"
            gridInvoice.Columns(10).Name = "PayMode"
            Dim getdata As New List(Of String)
            Dim gsttype As String
            Dim cgst, sgst, igst As String
            For i = 0 To invoicenolist.Count - 1
                getdata = obj.GetMoreValueFromQuery("select user_invoice_no,contact_no,ref_no,invoice_dt,place_supply ,sub_total, " & _
                                                    "total_tax , grand_total," & _
                                                    " voucher_no,payment_status from invoice_hdr" & _
                                                    " where invoice_no='" + invoicenolist(i) + "'", 10)
                gsttype = If(obj.GetOneValueFromQuery("select place_supply from contact_tbl where contact_no='" + getdata(1) + "'") = obj.GetOneValueFromQuery("select billing_state from company_tbl where company_id=" + SharedData.companyid + ""), "GST", "IGST")
                If gsttype = "GST" Then
                    cgst = (CDbl(getdata(6)) / 2).ToString
                    sgst = (CDbl(getdata(6)) / 2).ToString
                    igst = "0"
                Else
                    cgst = "0"
                    sgst = "0"
                    igst = getdata(6)
                End If

                gridInvoice.Rows.Add(getdata(0), getdata(2), getdata(3),
                                      getdata(4), getdata(5), igst, sgst,
                                      cgst, getdata(7), getdata(8), getdata(9))

            Next

            gridInvoice.Refresh()
            gridInvoice.ReadOnly = True
            gridInvoice.AutoGenerateColumns = False
            gridInvoice.AllowUserToAddRows = False

            gridInvoice.ClearSelection()

            For i = 0 To gridInvoice.Rows.Count - 1
                If gridInvoice.Rows(i).Cells(10).Value = "1" Then
                    gridInvoice.Rows(i).Cells(10).Style.ForeColor = Color.Green
                    gridInvoice.Rows(i).Cells(10).Value = "Paid"
                Else
                    gridInvoice.Rows(i).Cells(10).Style.ForeColor = Color.Red
                    gridInvoice.Rows(i).Cells(10).Value = "Un Paid"
                End If

            Next
        Catch ex As Exception
            MsgBox(ex.Message, , MessageBoxIcon.Error)
        End Try


    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        FillDataGridView()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        'Try
        '    Dim DTB = New DataTable, RWS As Integer, CLS As Integer

        '    For CLS = 0 To gridInvoice.ColumnCount - 1 ' COLUMNS OF DTB
        '        DTB.Columns.Add(gridInvoice.Columns(CLS).Name.ToString)
        '    Next

        '    Dim DRW As DataRow

        '    For RWS = 0 To gridInvoice.Rows.Count - 1 ' FILL DTB WITH DATAGRIDVIEW
        '        DRW = DTB.NewRow

        '        For CLS = 0 To gridInvoice.ColumnCount - 1
        '            Try
        '                DRW(DTB.Columns(CLS).ColumnName.ToString) = gridInvoice.Rows(RWS).Cells(CLS).Value.ToString
        '            Catch ex As Exception

        '            End Try
        '        Next

        '        DTB.Rows.Add(DRW)
        '    Next

        '    DTB.AcceptChanges()

        '    Dim DST As New DataSet
        '    DST.Tables.Add(DTB)
        '    Dim FLE As String = "D:\excel\rpt.xml" ' PATH AND FILE NAME WHERE THE XML WIL BE CREATED (EXEMPLE: C:\REPS\XML.xml)
        '    DTB.WriteXml(FLE)
        '    Dim EXL As String = "C:\Program Files\Microsoft Office\Office15\EXCEL.exe" ' PATH OF/ EXCEL.EXE IN YOUR MICROSOFT OFFICE
        '    Shell(Chr(34) & EXL & Chr(34) & " " & Chr(34) & FLE & Chr(34), vbNormalFocus) ' OPEN XML WITH EXCEL

        'Catch ex As Exception
        '    MsgBox(ex.ToString)
        'End Try
        Try
            Dim path As String
            If (FolderBrowserDialog1.ShowDialog() = DialogResult.OK) Then
                path = FolderBrowserDialog1.SelectedPath() + "\CustomerWiseSaleRpt.xls"
            Else
                Exit Sub
            End If
        Dim xlApp As Microsoft.Office.Interop.Excel.Application
        Dim xlWorkBook As Microsoft.Office.Interop.Excel.Workbook
        Dim xlWorkSheet As Microsoft.Office.Interop.Excel.Worksheet
        Dim misValue As Object = System.Reflection.Missing.Value
        Dim i As Integer
        Dim j As Integer

        xlApp = New Microsoft.Office.Interop.Excel.Application
        xlWorkBook = xlApp.Workbooks.Add(misValue)
        xlWorkSheet = xlWorkBook.Sheets("sheet1")


            For i = 0 To gridInvoice.RowCount - 1
                For j = 0 To gridInvoice.ColumnCount - 1
                    For k As Integer = 1 To gridInvoice.Columns.Count
                        xlWorkSheet.Cells(1, k) = gridInvoice.Columns(k - 1).HeaderText
                        xlWorkSheet.Cells(i + 2, j + 1) = gridInvoice(j, i).Value.ToString()
                    Next
                Next
            Next

            xlWorkSheet.SaveAs(path)
        xlWorkBook.Close()
        xlApp.Quit()
        releaseObject(xlApp)
        releaseObject(xlWorkBook)
            releaseObject(xlWorkSheet)
            MsgBox("Excel Created Successfully!!!")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub releaseObject(ByVal obj As Object)
        Try
            System.Runtime.InteropServices.Marshal.ReleaseComObject(obj)
            obj = Nothing
        Catch ex As Exception
            obj = Nothing
        Finally
            GC.Collect()
        End Try


    End Sub
End Class