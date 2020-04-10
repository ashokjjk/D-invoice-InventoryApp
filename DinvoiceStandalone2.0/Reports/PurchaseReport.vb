Public Class PurchaseReport
    Dim obj As New ObjClass
    Dim S As New SharedData
    Private Sub PurchaseReport_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        MaximizeBox = False
        MinimizeBox = False
        lstbxDetails.Visible = False
        Panel3.Visible = False
        txtSearchKeyword.Focus()
        lblid.Text = ""
        FillDataGridView()
    End Sub

    Private Sub rbtdate_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtdate.CheckedChanged, rbtno.CheckedChanged
        Select Case rbtdate.Checked
            Case True
                Panel3.Visible = True
            Case False
                Panel3.Visible = False
        End Select
    End Sub

   

    Private Sub DateTimePicker4_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DateTimePicker4.ValueChanged
        txtfromdate.Text = Me.DateTimePicker4.Value.Date.ToString("dd/MM/yyyy")
    End Sub

    Private Sub DateTimePicker3_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DateTimePicker3.ValueChanged
        txttodate.Text = Me.DateTimePicker3.Value.Date.ToString("dd/MM/yyyy")
    End Sub

    Private Sub gridBills_CellContentClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridBills.CellContentClick
        Try
            If e.ColumnIndex = 10 Then

                S.SetReportpurchaseno(gridBills.Rows(e.RowIndex).Cells(1).Value)
                ReportScreen.Show()
                ReportScreen.BringToFront()
                'ReportScreen.TopMost = True

            End If
            If e.ColumnIndex = 11 Then
                If obj.GetOneValueFromQuery("select payment_status from purchase_hdr where purchase_no='" + gridBills.Rows(e.RowIndex).Cells(1).Value + "'") = "0" Then
                    S.SetPurchaseno(gridBills.Rows(e.RowIndex).Cells(1).Value)
                    Purchase.Show()
                    Purchase.BringToFront()
                    Purchase.Focus()

                Else
                    MsgBox("You can't Edit this Purchase!!!!")
                End If
               
            End If
            If e.ColumnIndex = 12 Then
                If obj.GetOneValueFromQuery("select payment_status from purchase_hdr where purchase_no='" + gridBills.Rows(e.RowIndex).Cells(1).Value + "'") = "0" Then
                    S.SetPurchaseno(gridBills.Rows(e.RowIndex).Cells(1).Value)
                    Dim result1 As Integer = MessageBox.Show("Are you sure want to Delete??", "Caution !!!", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning)
                    If result1 = DialogResult.Cancel Then

                    ElseIf result1 = DialogResult.No Then

                    ElseIf result1 = DialogResult.Yes Then
                        Dim result As Boolean = BeforeDeletePurchase()
                        Select Case result
                            Case True
                                MsgBox("Purchase details Deleted!!", MessageBoxIcon.Information)
                                S.ClearPurchaseno()
                                gridBills.Rows.RemoveAt(e.RowIndex)
                            Case False
                                MsgBox("Something Went Wrong!!", MessageBoxIcon.Exclamation)
                                Exit Sub
                        End Select
                    End If
                   


                Else
                    MsgBox("You can't Delete this Purchase!!!!")
                End If
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MessageBoxIcon.Exclamation)
        End Try
    End Sub
    Function BeforeDeletePurchase() As Boolean
        Dim InitialTransaction, getdata As New List(Of String)
        Dim dtpurdt, dtbank As New DataTable
        Dim companyid As String = obj.GetOneValueFromQuery("select company_id from purchase_hdr where purchase_no='" + S.GetPurchaseno() + "'")
        dtpurdt = obj.getdatatable("select item_no, item_qty from purchase_dtl where purchase_no='" + S.GetPurchaseno + "'")
        For i = 0 To dtpurdt.Rows.Count - 1
            InitialTransaction.Add("update stock_tbl set qty=qty-" + dtpurdt.Rows(i).Item(1).ToString + " where item_no='" + dtpurdt.Rows(i).Item(0).ToString + "' and company_id=" + companyid + "")
        Next
        Dim result As Boolean = obj.TransactionInsert(InitialTransaction)
        Select Case result
            Case True
                Dim i As Integer = obj.QueryExecution("delete from purchase_dtl where purchase_no='" + S.GetPurchaseno + "'") * obj.QueryExecution("delete from purchase_hdr where purchase_no='" + S.GetPurchaseno + "'")
                Return If(i >= 1, True, False)
            Case False
                Return False
        End Select
    End Function
    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        FillDataGridView()
    End Sub

    Private Sub txtSearchKeyword_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSearchKeyword.KeyUp
        lstbxDetails.Visible = True
        Dim listvendorname As New DataTable
        lstbxDetails.DataSource = Nothing
        If txtSearchKeyword.Text = "" Then
            lstbxDetails.Visible = False
        Else
            If rbtCusName.Checked = True Then
                listvendorname = obj.getdatatable("select company_name as displaytext,contact_no as valuetext from contact_tbl where company_name like '%" + txtSearchKeyword.Text + "%'")
            End If
            If rbtno.Checked = True Then
                listvendorname = obj.getdatatable("select user_purchase_no as displaytext,user_purchase_no as valuetext from purchase_hdr where user_purchase_no like '%" + txtSearchKeyword.Text + "%'")
            End If
            If rbtdate.Checked = True Then
                MsgBox("Vendor and Purchase no only work in this criteria, click Search button")
                Exit Sub
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
            lblid.Text = lstbxDetails.SelectedValue
            'FillDataGridView(lstbxDetails.SelectedValue)
            Catch ex As Exception

            End Try

    End Sub

    Private Sub FillDataGridView()
        Try
            gridBills.Rows.Clear()
            Dim purchasenolist As New List(Of String)
            If lblid.Text = "" Then
                purchasenolist = obj.getcolumndatafromquery(" select purchase_no from purchase_hdr where  company_id=" + SharedData.companyid + "")
            End If
            If rbtCusName.Checked = True Then
                purchasenolist = obj.getcolumndatafromquery("select purchase_no from purchase_hdr where contact_no='" + lblid.Text + "' and company_id=" + SharedData.companyid + "")

            ElseIf rbtno.Checked = True Then
                purchasenolist = obj.getcolumndatafromquery("select purchase_no from purchase_hdr where user_purchase_no='" + lblid.Text + "' and company_id=" + SharedData.companyid + "")
            ElseIf rbtdate.Checked = True Then
                purchasenolist = obj.getcolumndatafromquery("select purchase_no from purchase_hdr where purchase_dt between #" + Format(CDate(txtfromdate.Text), "MM/dd/yyyy") + "# and #" + Format(CDate(txttodate.Text), "MM/dd/yyyy") + "#")

            End If
            gridBills.ColumnCount = 10
            gridBills.Columns(0).Name = "Purchase No"
            gridBills.Columns(1).Name = ""
            gridBills.Columns(2).Name = "Vendor"
            gridBills.Columns(3).Name = "Date"
            gridBills.Columns(4).Name = "Total"
            gridBills.Columns(5).Name = "Tax"
            gridBills.Columns(6).Name = "GrandTotal"
            gridBills.Columns(7).Name = "Status"
            gridBills.Columns(8).Name = "CreditDays"
            gridBills.Columns(9).Name = "VoucherDate"

            Dim getdata As New List(Of String)
            Dim contactname, voucherdt, purchasedt As String
            For i = 0 To purchasenolist.Count - 1
                getdata = obj.GetMoreValueFromQuery("select user_purchase_no, contact_no,purchase_dt, sub_total, " & _
                                                    "total_tax + total_cess, grand_total, payment_status," & _
                                                    " credit_days, voucher_no from purchase_hdr" & _
                                                    " where purchase_no='" + purchasenolist(i) + "'", 9)
                contactname = obj.GetOneValueFromQuery("select company_name from contact_tbl where contact_no='" + getdata(1) + "'")
                voucherdt = obj.GetOneValueFromQuery("select voucher_dt from voucher_tbl where voucher_no='" + getdata(8) + "'")
                voucherdt = If(voucherdt = "", "-", voucherdt)
                purchasedt = obj.ConvDtFrmt(getdata(2), "dd/MM/yyyy")
                gridBills.Rows.Add(getdata(0), purchasenolist(i), contactname, purchasedt, getdata(3), getdata(4), getdata(5), getdata(6), getdata(7), voucherdt)

            Next



            If gridBills.RowCount = 13 Then
            Else
                Dim btn As New DataGridViewButtonColumn
                btn.Name = "view"
                btn.HeaderText = ""
                btn.Text = "VIEW"
                btn.UseColumnTextForButtonValue = True
                gridBills.Columns.Add(btn)
                Dim btn1 As New DataGridViewButtonColumn
                btn1.Name = "edit"
                btn1.HeaderText = ""
                btn1.Text = "EDIT"
                btn1.UseColumnTextForButtonValue = True
                gridBills.Columns.Add(btn1)

                Dim btn2 As New DataGridViewButtonColumn
                btn2.Name = "delete"
                btn2.HeaderText = ""
                btn2.Text = "DELETE"
                btn2.UseColumnTextForButtonValue = True
                gridBills.Columns.Add(btn2)
            End If



            'gridAddCmp.DataSource = dt1



            gridBills.Refresh()
            gridBills.ReadOnly = True
            gridBills.AutoGenerateColumns = False
            gridBills.AllowUserToAddRows = False
            gridBills.Columns(1).Visible = False
            gridBills.ClearSelection()

            For i = 0 To gridBills.Rows.Count - 1
                If gridBills.Rows(i).Cells(7).Value = 1 Then
                    gridBills.Rows(i).Cells(7).Style.ForeColor = Color.Green
                    gridBills.Rows(i).Cells(7).Value = "Paid"
                Else
                    gridBills.Rows(i).Cells(7).Style.ForeColor = Color.Red
                    gridBills.Rows(i).Cells(7).Value = "Un Paid"
                End If

            Next


        Catch ex As Exception
            MsgBox(ex.Message, , MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            Dim path As String
            If (FolderBrowserDialog1.ShowDialog() = DialogResult.OK) Then
                path = FolderBrowserDialog1.SelectedPath() + "\PurchaseRpt.xls"
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


            For i = 0 To gridBills.RowCount - 1
                For j = 0 To gridBills.ColumnCount - 1
                    For k As Integer = 1 To gridBills.Columns.Count
                        xlWorkSheet.Cells(1, k) = gridBills.Columns(k - 1).HeaderText
                        xlWorkSheet.Cells(i + 2, j + 1) = gridBills(j, i).Value.ToString()
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