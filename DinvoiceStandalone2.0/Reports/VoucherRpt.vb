Public Class VoucherRpt
    Dim obj As New ObjClass
    Private Sub VoucherpaymentRpt_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        MaximizeBox = False
        MinimizeBox = False
        lstbxDetails.Visible = False
        txtSearchKeyword.Focus()
        '  FillDataGridView()
    End Sub

    Private Sub txtSearchKeyword_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSearchKeyword.KeyUp
        lstbxDetails.Visible = True
        Dim listvendorname As New DataTable
        lstbxDetails.DataSource = Nothing
        If txtSearchKeyword.Text = "" Then
            lstbxDetails.Visible = False
            '  FillDataGridView()
        Else
            If rbtCusName.Checked = True Then
                listvendorname = obj.getdatatable("select company_name as displaytext,contact_no as valuetext from contact_tbl where company_name like '%" + txtSearchKeyword.Text + "%'")

            End If
            If rbtInvoiceno.Checked = True Then
                listvendorname = obj.getdatatable("select user_invoice_no as displaytext,invoice_no as valuetext from SearchInvoiceNo where user_invoice_no like '%" + txtSearchKeyword.Text + "%'")
            End If
            If rbtVoucherno.Checked = True Then
                listvendorname = obj.getdatatable("select voucher_user_no as displaytext,voucher_user_no as valuetext from voucher_tbl where voucher_user_no like '%" + txtSearchKeyword.Text + "%'")
            End If
            'If rbtAccnam.Checked = True Then
            '    listvendorname = obj.getdatatable("select user_invoice_no as displaytext,user_invoice_no as valuetext from invoice_hdr where payment_status=1")
            'End If
            If rbtChequeno.Checked = True Then
                listvendorname = obj.getdatatable("select cheque_no as displaytext,cheque_no as valuetext from voucher_tbl where cheque_no like '%" + txtSearchKeyword.Text + "%'")
            End If
            lstbxDetails.DisplayMember = "displaytext"
            lstbxDetails.ValueMember = "valuetext"
            lstbxDetails.DataSource = listvendorname
            lstbxDetails.Visible = True



        End If
    End Sub

    Private Sub lstbxDetails_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lstbxDetails.MouseClick
        lstbxDetails.Visible = False

        Try
            lstbxDetails.Visible = False
            txtSearchKeyword.Text = lstbxDetails.Text
            lblcuscode.text = lstbxDetails.SelectedValue
        Catch ex As Exception

        End Try

    End Sub

    Private Sub FillDataGridView()
        Try
            gridInvoice.Rows.Clear()
            Dim invoicenolist As New List(Of String)
            If rbtCusName.Checked = True Then
                ' invoicenolist = obj.getcolumndatafromquery("select voucher_no, voucher_user_no, company_name, contact_no, voucher_type, payment_type,  voutype, bank_name, cheque_no, cheque_dt, total_amt from VoucherRptGridview where contact_no='" + p1 + "'")
                If txtfromdate.Text <> "" And txttodate.Text <> "" Then
                    invoicenolist = obj.getcolumndatafromquery("select voucher_no from VoucherRptGridview where contact_no='" + lblcuscode.Text + "' and voucher_dt between #" + obj.ConvDtFrmt(txtfromdate.Text, "MM/dd/yyyy") + "# and #" + obj.ConvDtFrmt(txttodate.Text, "MM/dd/yyyy") + "#")
                Else
                    invoicenolist = obj.getcolumndatafromquery("select voucher_no from VoucherRptGridview where contact_no='" + lblcuscode.Text + "'")

                End If
            End If
            If rbtInvoiceno.Checked = True Then

                If txtfromdate.Text <> "" And txttodate.Text <> "" Then
                    invoicenolist = obj.getcolumndatafromquery("select voucher_no from VoucherRptInvGridView where invoice_no='" + lblcuscode.Text + "' and voucher_dt between #" + obj.ConvDtFrmt(txtfromdate.Text, "MM/dd/yyyy") + "# and #" + obj.ConvDtFrmt(txttodate.Text, "MM/dd/yyyy") + "#")
                Else
                    invoicenolist = obj.getcolumndatafromquery("select voucher_no from VoucherRptInvGridView where invoice_no='" + lblcuscode.Text + "'")

                End If

            End If
            If rbtVoucherno.Checked = True Then
                If txtfromdate.Text <> "" And txttodate.Text <> "" Then
                    invoicenolist = obj.getcolumndatafromquery("select voucher_no from VoucherRptGridview where voucher_user_no='" + lblcuscode.Text + "' and voucher_dt between #" + obj.ConvDtFrmt(txtfromdate.Text, "MM/dd/yyyy") + "# and #" + obj.ConvDtFrmt(txttodate.Text, "MM/dd/yyyy") + "#")
                Else
                    invoicenolist = obj.getcolumndatafromquery("select voucher_no from VoucherRptGridview where voucher_user_no='" + lblcuscode.Text + "'")

                End If
            End If
            If rbtChequeno.Checked = True Then
                If txtfromdate.Text <> "" And txttodate.Text <> "" Then
                    invoicenolist = obj.getcolumndatafromquery("select voucher_no from VoucherRptGridview where cheque_no='" + lblcuscode.Text + "' and voucher_dt between #" + obj.ConvDtFrmt(txtfromdate.Text, "MM/dd/yyyy") + "# and #" + obj.ConvDtFrmt(txttodate.Text, "MM/dd/yyyy") + "#")
                Else
                    invoicenolist = obj.getcolumndatafromquery("select voucher_no from VoucherRptGridview where cheque_no='" + lblcuscode.Text + "'")
                End If
            End If
            gridInvoice.ColumnCount = 10
            gridInvoice.Columns(0).Name = "Customer"
            gridInvoice.Columns(1).Name = ""
            gridInvoice.Columns(2).Name = "Date"
            gridInvoice.Columns(3).Name = "PayType"
            gridInvoice.Columns(4).Name = "PayMode"
            gridInvoice.Columns(5).Name = "VoucherType"
            gridInvoice.Columns(6).Name = "Bank"
            gridInvoice.Columns(7).Name = "ChequeNo"
            gridInvoice.Columns(8).Name = "ChequeDate"
            gridInvoice.Columns(9).Name = "GrandTotal"

            Dim getdata As New List(Of String)
            ' Dim chequedate As String
            For i = 0 To invoicenolist.Count - 1
                getdata = obj.GetMoreValueFromQuery("select voucher_no, voucher_user_no, company_name, contact_no,voucher_dt, " & _
                                                    "voucher_type, payment_type,  voutype, credit_debit_bank, cheque_no, Format(cheque_dt,'dd/mm/yyyy')," & _
                                                    " total_amt from VoucherRptGridview" & _
                                                    " where voucher_no='" + invoicenolist(i) + "'", 12)
                ' chequedate = If(getdata(10) = "01/01/1900", "-", getdata(10))
                gridInvoice.Rows.Add(getdata(2), invoicenolist(i), getdata(4), If(getdata(5) = "B2B", "BillWise", "OnAccount"),
                                      getdata(6), getdata(7), If(getdata(8) = "", "", obj.GetOneValueFromQuery("select bank_name from bank_tbl where ID=" + getdata(8) + "")),
                                      getdata(9), getdata(10), getdata(11))

            Next



            If gridInvoice.ColumnCount = 11 Then
            Else
                Dim btn As New DataGridViewButtonColumn
                btn.Name = "view"
                btn.HeaderText = ""
                btn.Text = "VIEW"
                btn.UseColumnTextForButtonValue = True
                gridInvoice.Columns.Add(btn)

            End If

            gridInvoice.Refresh()
            gridInvoice.ReadOnly = True
            gridInvoice.AutoGenerateColumns = False
            gridInvoice.AllowUserToAddRows = False
            gridInvoice.Columns(1).Visible = False
            gridInvoice.ClearSelection()

            For i = 0 To gridInvoice.Rows.Count - 1
                If CDate(gridInvoice.Rows(i).Cells(8).Value) = Today Then
                    gridInvoice.Rows(i).Cells(8).Style.ForeColor = Color.Red
                End If
                gridInvoice.Rows(i).Cells(8).Value = If(getdata(10) = "01/01/1900", "-", getdata(10))
            Next

          
        Catch ex As Exception
            MsgBox(ex.Message, , MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub dtpfromdt_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpfromdate.ValueChanged
        Me.txtfromdate.Text = Me.dtpfromdate.Value.Date.ToString("dd/MM/yyyy")
    End Sub

    Private Sub dtptodt_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtptodate.ValueChanged
        Me.txttodate.Text = Me.dtptodate.Value.Date.ToString("dd/MM/yyyy")
    End Sub

    
    Private Sub gridInvoice_CellContentClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridInvoice.CellContentClick
        Try

       
            If e.ColumnIndex = 10 Then
                Dim s As New SharedData


                s.SetReportVoucherno(gridInvoice.Rows(e.RowIndex).Cells(1).Value, If(gridInvoice.Rows(e.RowIndex).Cells(5).Value = "Income", "Sale", "Purchase"), If(gridInvoice.Rows(e.RowIndex).Cells(3).Value = "BillWise", "B2B", "WS"))
                ReportScreen.Show()
                ReportScreen.BringToFront()
                'ReportScreen.TopMost = True
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        FillDataGridView()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        Try
            Dim path As String
            If (FolderBrowserDialog1.ShowDialog() = DialogResult.OK) Then
                path = FolderBrowserDialog1.SelectedPath() + "\VoucherRpt.xls"
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

