Public Class InvoiceRpt
    Dim obj As New ObjClass
    Dim S As New SharedData
    Private Sub InvoiceRpt_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        MaximizeBox = False
        MinimizeBox = False
        lstbxDetails.Visible = False
        Panel5.Visible = False
        Panel3.Visible = False
        txtSearchKeyword.Focus()
        FillDataGridView("")
    End Sub

    
    Private Sub rbtDate_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtDate.CheckedChanged
        Select Case rbtDate.Checked
            Case True
                Panel5.Visible = True
            Case False
                Panel5.Visible = False
        End Select
    End Sub

    Private Sub rbtPayStatus_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtPayStatus.CheckedChanged
        Select Case rbtPayStatus.Checked
            Case True
                Panel3.Visible = True
                cmpPaidStatus.Text = "Unpaid"
            Case False
                Panel3.Visible = False
        End Select
    End Sub

    Private Sub txtSearchKeyword_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSearchKeyword.KeyPress
        lstbxDetails.Visible = True
    End Sub

    ' Private Sub lstbxDetails_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lstbxDetails.MouseClick
    '  lstbxDetails.Visible = False
    ' End Sub

    Private Sub DateTimePicker4_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpfromdt.ValueChanged
        txtfromdate.Text = Me.dtpfromdt.Value.Date.ToString("dd/MM/yyyy")
    End Sub

    Private Sub DateTimePicker3_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtptodt.ValueChanged
        txttodate.Text = Me.dtptodt.Value.Date.ToString("dd/MM/yyyy")
    End Sub

    Private Sub gridBills_CellContentClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridAccounts.CellContentClick
        Try
            If e.ColumnIndex = 12 Then
                Dim s As New SharedData

                If obj.GetOneValueFromQuery("select invoice_type from invoice_hdr where invoice_no='" + gridAccounts.Rows(e.RowIndex).Cells(1).Value + "'") = "Invoice" Then
                    s.SetReportinvoiceno(gridAccounts.Rows(e.RowIndex).Cells(1).Value)
                    ReportScreen.Show()
                    ReportScreen.BringToFront()
                    'ReportScreen.TopMost = True

                Else
                    s.SetPOSReportInvoiceno(gridAccounts.Rows(e.RowIndex).Cells(1).Value)
                    POSReportScreen.Show()
                    POSReportScreen.BringToFront()
                    'ReportScreen.TopMost = True
                End If




            End If
            If e.ColumnIndex = 13 Then
                If obj.GetOneValueFromQuery("select payment_status from invoice_hdr where invoice_no='" + gridAccounts.Rows(e.RowIndex).Cells(1).Value + "'") = "0" Then

                    If obj.GetOneValueFromQuery("select invoice_type from invoice_hdr where invoice_no='" + gridAccounts.Rows(e.RowIndex).Cells(1).Value + "'") = "Invoice" Then
                        S.SetInvoiceno(gridAccounts.Rows(e.RowIndex).Cells(1).Value)
                        Invoice.Show()
                        Invoice.BringToFront()
                        Invoice.Focus()
                    Else
                        S.SetPOSno(gridAccounts.Rows(e.RowIndex).Cells(1).Value)
                        Pos.Show()
                        Pos.BringToFront()
                        Pos.Focus()
                    End If



                Else
                    MsgBox("You can't Edit this bill!!!!")
                End If

            End If
            If e.ColumnIndex = 14 Then
                If obj.GetOneValueFromQuery("select payment_status from invoice_hdr where invoice_no='" + gridAccounts.Rows(e.RowIndex).Cells(1).Value + "'") = "0" Then
                    S.SetSupplyno(gridAccounts.Rows(e.RowIndex).Cells(1).Value)



                    Dim result1 As Integer = MessageBox.Show("Are you sure want to Delete??", "Caution !!!", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning)
                    If result1 = DialogResult.Cancel Then

                    ElseIf result1 = DialogResult.No Then

                    ElseIf result1 = DialogResult.Yes Then
                        Dim result As Boolean = BeforeDeleteSupply()
                        Select Case result
                            Case True
                                MsgBox("Bill details Deleted!!", MessageBoxIcon.Information)
                                S.ClearSupplyno()
                                gridAccounts.Rows.RemoveAt(e.RowIndex)
                            Case False
                                MsgBox("Something Went Wrong!!", MessageBoxIcon.Exclamation)
                                Exit Sub
                        End Select
                    End If


                  


                Else
                    MsgBox("You can't Delete this Bill!!!!")
                End If
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MessageBoxIcon.Exclamation)
        End Try
    End Sub
    Function BeforeDeleteSupply() As Boolean
        Dim InitialTransaction, getdata As New List(Of String)
        Dim dtpurdt, dtbank As New DataTable
        Dim companyid As String = obj.GetOneValueFromQuery("select company_id from invoice_hdr where invoice_no='" + S.GetInvoiceno() + "'")
        dtpurdt = obj.getdatatable("select item_no, item_qty from invoice_dtl where invoice_no='" + S.GetInvoiceno + "'")
        For i = 0 To dtpurdt.Rows.Count - 1
            InitialTransaction.Add("update stock_tbl set qty=qty-" + dtpurdt.Rows(i).Item(1).ToString + " where item_no='" + dtpurdt.Rows(i).Item(0).ToString + "' and company_id=" + companyid + "")
        Next
        Dim result As Boolean = obj.TransactionInsert(InitialTransaction)
        Select Case result
            Case True
                Dim i As Integer = obj.QueryExecution("delete from invoice_dtl where invoice_no='" + S.GetInvoiceno + "'") * obj.QueryExecution("delete from invoice_hdr where invoice_no='" + S.GetInvoiceno + "'")
                Return If(i >= 1, True, False)
            Case False
                Return False
        End Select
    End Function
    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        If rbtDate.Checked = True Then
            FillDataGridView("")
        End If
    End Sub

    Private Sub txtSearchKeyword_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSearchKeyword.KeyUp
        lstbxDetails.Visible = True
        Dim listvendorname As New DataTable
        lstbxDetails.DataSource = Nothing
        If txtSearchKeyword.Text = "" Then
            lstbxDetails.Visible = False
            FillDataGridView("")
        Else
            If rbtCusName.Checked = True Then
                listvendorname = obj.getdatatable("select company_name as displaytext,contact_no as valuetext from contact_tbl where company_name like '%" + txtSearchKeyword.Text + "%'")

            End If
            If rbtInvno.Checked = True Then
                listvendorname = obj.getdatatable("select user_invoice_no as displaytext,user_invoice_no as valuetext from invoice_hdr where user_invoice_no like '%" + txtSearchKeyword.Text + "%'")
            End If
            If rbtDate.Checked = True Then
                MsgBox("Vendor and Purchase no only work in this criteria, click Search button")
                Exit Sub
            End If
            If rbtPayStatus.Checked = True Then
                listvendorname = obj.getdatatable("select user_invoice_no as displaytext,user_invoice_no as valuetext from invoice_hdr where payment_status=1")
            End If
            lstbxDetails.DisplayMember = "displaytext"
            lstbxDetails.ValueMember = "valuetext"
            lstbxDetails.DataSource = listvendorname
            lstbxDetails.Visible = True



        End If
    End Sub

    Private Sub lstbxDetails_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lstbxDetails.MouseClick
        lstbxDetails.Visible = False
        If lstbxDetails.Text = "Add New" Then
            Contacts.Show()
            Contacts.BringToFront()
            Contacts.Focus()
        Else
            Try
                lstbxDetails.Visible = False
                txtSearchKeyword.Text = lstbxDetails.Text
                FillDataGridView(lstbxDetails.SelectedValue)
            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub FillDataGridView(ByVal p1 As String)
        Try
            gridAccounts.Rows.Clear()
            Dim invoicenolist As New List(Of String)
            If rbtCusName.Checked = True Then
                Select Case p1
                    Case Is = ""
                        invoicenolist = obj.getcolumndatafromquery("select invoice_no from invoice_hdr where company_id=" + SharedData.companyid + "")

                    Case Else
                        invoicenolist = obj.getcolumndatafromquery("select invoice_no from invoice_hdr where contact_no='" + p1 + "' and company_id=" + SharedData.companyid + "")

                End Select
               
            ElseIf rbtInvno.Checked = True Then
                 Select p1
                    Case Is = ""
                        invoicenolist = obj.getcolumndatafromquery("select invoice_no from invoice_hdr where company_id=" + SharedData.companyid + "")

                    Case Else
                        invoicenolist = obj.getcolumndatafromquery("select invoice_no from invoice_hdr where user_invoice_no='" + p1 + "' and company_id=" + SharedData.companyid + "")
                End Select
            ElseIf rbtDate.Checked = True Then
                invoicenolist = obj.getcolumndatafromquery("select invoice_no from invoice_hdr where invoice_dt between #" + Format(CDate(txtfromdate.Text), "MM/dd/yyyy") + "# and #" + Format(CDate(txttodate.Text), "MM/dd/yyyy") + "#")
            ElseIf rbtPayStatus.Checked = True Then
                invoicenolist = obj.getcolumndatafromquery("select invoice_no from invoice_hdr where payment_status=" & If(p1 = "Paid", 1, 0) & "")

            End If
            gridAccounts.ColumnCount = 12
            gridAccounts.Columns(0).Name = "Invoice No"
            gridAccounts.Columns(1).Name = ""
            gridAccounts.Columns(2).Name = "Date"
            gridAccounts.Columns(3).Name = "Customer"
            gridAccounts.Columns(4).Name = "RefNo"
            gridAccounts.Columns(5).Name = "Total"
            gridAccounts.Columns(6).Name = "Tax"
            gridAccounts.Columns(7).Name = "GrandTotal"
            gridAccounts.Columns(8).Name = "Status"
            gridAccounts.Columns(9).Name = "CreditDays"
            gridAccounts.Columns(10).Name = "VoucherDate"
            gridAccounts.Columns(11).Name = "VoucherNo"
            Dim getdata As New List(Of String)
            Dim contactname, voucherdt, purchasedt As String
            For i = 0 To invoicenolist.Count - 1
                getdata = obj.GetMoreValueFromQuery("select user_invoice_no, contact_no,invoice_dt, sub_total, " & _
                                                    "total_tax + total_cess, grand_total, payment_status," & _
                                                    " credit_days, voucher_no,ref_no from invoice_hdr" & _
                                                    " where invoice_no='" + invoicenolist(i) + "'", 10)
                contactname = obj.GetOneValueFromQuery("select company_name from contact_tbl where contact_no='" + getdata(1) + "'")
                voucherdt = obj.GetOneValueFromQuery("select voucher_dt from voucher_tbl where voucher_no='" + getdata(8) + "'")
                voucherdt = If(voucherdt = "", "-", voucherdt)
                purchasedt = obj.ConvDtFrmt(getdata(2), "dd/MM/yyyy")
                gridAccounts.Rows.Add(getdata(0), invoicenolist(i), purchasedt, contactname,
                                      getdata(9), getdata(3), getdata(4),
                                      getdata(5), getdata(6), getdata(7), voucherdt, getdata(8))

            Next



            If gridAccounts.RowCount = 15 Then
            Else
                Dim btn As New DataGridViewButtonColumn
                btn.Name = "view"
                btn.HeaderText = ""
                btn.Text = "VIEW"
                btn.UseColumnTextForButtonValue = True
                gridAccounts.Columns.Add(btn)
                Dim btn1 As New DataGridViewButtonColumn
                btn1.Name = "edit"
                btn1.HeaderText = ""
                btn1.Text = "EDIT"
                btn1.UseColumnTextForButtonValue = True
                gridAccounts.Columns.Add(btn1)

                Dim btn2 As New DataGridViewButtonColumn
                btn2.Name = "delete"
                btn2.HeaderText = ""
                btn2.Text = "DELETE"
                btn2.UseColumnTextForButtonValue = True
                gridAccounts.Columns.Add(btn2)
            End If

            gridAccounts.Refresh()
            gridAccounts.ReadOnly = True
            gridAccounts.AutoGenerateColumns = False
            gridAccounts.AllowUserToAddRows = False
            gridAccounts.Columns(1).Visible = False
            gridAccounts.ClearSelection()

            For i = 0 To gridAccounts.Rows.Count - 1
                If gridAccounts.Rows(i).Cells(8).Value = 1 Then
                    gridAccounts.Rows(i).Cells(8).Style.ForeColor = Color.Green
                    gridAccounts.Rows(i).Cells(8).Value = "Paid"
                Else
                    gridAccounts.Rows(i).Cells(8).Style.ForeColor = Color.Red
                    gridAccounts.Rows(i).Cells(8).Value = "Un Paid"
                End If

            Next
        Catch ex As Exception
            MsgBox(ex.Message, , MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub dtpfromdt_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpfromdt.ValueChanged
        Me.txtfromdate.Text = Me.dtpfromdt.Value.Date.ToString("dd/MM/yyyy")
    End Sub

    Private Sub dtptodt_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtptodt.ValueChanged
        Me.txttodate.Text = Me.dtptodt.Value.Date.ToString("dd/MM/yyyy")
    End Sub

   
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            Dim path As String
            If (FolderBrowserDialog1.ShowDialog() = DialogResult.OK) Then
                path = FolderBrowserDialog1.SelectedPath() + "\InvoiceRpt.xls"
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


            For i = 0 To gridAccounts.RowCount - 1
                For j = 0 To gridAccounts.ColumnCount - 1
                    For k As Integer = 1 To gridAccounts.Columns.Count
                        xlWorkSheet.Cells(1, k) = gridAccounts.Columns(k - 1).HeaderText
                        xlWorkSheet.Cells(i + 2, j + 1) = gridAccounts(j, i).Value.ToString()
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

    Private Sub cmpPaidStatus_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmpPaidStatus.SelectedIndexChanged
        FillDataGridView(cmpPaidStatus.Text)
    End Sub
End Class