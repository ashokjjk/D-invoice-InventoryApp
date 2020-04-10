Public Class BillOfSupplyRpt
    Dim obj As New ObjClass
    Dim S As New SharedData
    Private Sub rbtdate_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtdate.CheckedChanged
        Select Case rbtdate.Checked
            Case True
                Panel3.Visible = True
            Case False
                Panel3.Visible = False
        End Select
    End Sub

    Private Sub BillOfSupplyRpt_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        MaximizeBox = False
        MinimizeBox = False
        Panel3.Visible = False
        Panel2.Visible = False
        lstbxDetails.Visible = False
        txtKeyword.Focus()
        FillDataGridView("")
    End Sub

    Private Sub txtKeyword_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtKeyword.KeyPress
        lstbxDetails.Visible = True
    End Sub

    'Private Sub lstbxDetails_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lstbxDetails.MouseClick
    '    lstbxDetails.Visible = False
    'End Sub

    Private Sub DateTimePicker4_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        txtfromdate.Text = Me.dtpfromdt.Value.Date.ToString("dd/MM/yyyy")
    End Sub

    Private Sub DateTimePicker3_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        txttodate.Text = Me.dtptodt.Value.Date.ToString("dd/MM/yyyy")
    End Sub

    Private Sub gridBills_CellContentClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridQuotations.CellContentClick
        Try
            If e.ColumnIndex = 10 Then

                If obj.GetOneValueFromQuery("select supplytype from supply_hdr where supply_no='" + gridQuotations.Rows(e.RowIndex).Cells(1).Value + "'") = "SUPPLY" Then
                    S.SetReportsupplyno(gridQuotations.Rows(e.RowIndex).Cells(1).Value)
                    ReportScreen.Show()
                    ReportScreen.BringToFront()
                    'ReportScreen.TopMost = True

                Else
                    S.SetPOSReportSupplyno(gridQuotations.Rows(e.RowIndex).Cells(1).Value)
                    POSReportScreen.Show()
                    POSReportScreen.BringToFront()
                    'ReportScreen.TopMost = True
                End If


            End If
            If e.ColumnIndex = 11 Then
                If obj.GetOneValueFromQuery("select payment_status from supply_hdr where supply_no='" + gridQuotations.Rows(e.RowIndex).Cells(1).Value + "'") = "0" Then
                    S.SetSupplyno(gridQuotations.Rows(e.RowIndex).Cells(1).Value)
                    BillOfSupply.Show()
                    BillOfSupply.BringToFront()
                    BillOfSupply.Focus()

                Else
                    MsgBox("You can't Edit this bill!!!!")
                End If

            End If
            If e.ColumnIndex = 12 Then
                If obj.GetOneValueFromQuery("select payment_status from Supply_hdr where Supply_no='" + gridQuotations.Rows(e.RowIndex).Cells(1).Value + "'") = "0" Then
                    S.SetSupplyno(gridQuotations.Rows(e.RowIndex).Cells(1).Value)
                    Dim result As Boolean = BeforeDeleteSupply()
                    Select Case result
                        Case True
                            MsgBox("Bill details Deleted!!", MessageBoxIcon.Information)
                            S.ClearSupplyno()
                            gridQuotations.Rows.RemoveAt(e.RowIndex)
                        Case False
                            MsgBox("Something Went Wrong!!", MessageBoxIcon.Exclamation)
                            Exit Sub
                    End Select
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
        Dim companyid As String = obj.GetOneValueFromQuery("select company_id from Supply_hdr where Supply_no='" + S.GetSupplyno() + "'")
        dtpurdt = obj.getdatatable("select item_no, item_qty from Supply_dtl where Supply_no='" + S.GetSupplyno + "'")
        For i = 0 To dtpurdt.Rows.Count - 1
            InitialTransaction.Add("update stock_tbl set qty=qty+" + dtpurdt.Rows(i).Item(1).ToString + " where item_no='" + dtpurdt.Rows(i).Item(0).ToString + "' and company_id=" + companyid + "")
        Next
        InitialTransaction.Add("Update advance_tbl set bill_flg=0,	bill_no=''," & _
                          "	voucher_no=''," & _
                          "	receipt_flg=0 where " & _
                          "bill_no='" + S.GetSupplyno + "' and bill_type='SUPPLY'")

        InitialTransaction.Add("update indent_dtl set bill_flg=0,bill_no=''," & _
                                        "gatepass_no=''," & _
                                        " gatepass_flg=0" & _
                                        " where bill_no='" + S.GetSupplyno + "'")
        Dim result As Boolean = obj.TransactionInsert(InitialTransaction)
        Select Case result
            Case True
                Dim i As Integer = obj.QueryExecution("delete from Supply_dtl where Supply_no='" + S.GetSupplyno + "'") * obj.QueryExecution("delete from Supply_hdr where Supply_no='" + S.GetSupplyno + "'")
                Return If(i >= 1, True, False)
            Case False
                Return False
        End Select
    End Function
    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        If rbtdate.Checked = True Then
            FillDataGridView("")
        End If
    End Sub

    Private Sub txtSearchKeyword_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtKeyword.KeyUp
        lstbxDetails.Visible = True
        Dim listvendorname As New DataTable
        lstbxDetails.DataSource = Nothing
        If txtKeyword.Text = "" Then
            lstbxDetails.Visible = False
            FillDataGridView("")
        Else
            If rbtCusName.Checked = True Then
                listvendorname = obj.getdatatable("select company_name as displaytext,contact_no as valuetext from contact_tbl where company_name like '%" + txtKeyword.Text + "%'")

            End If
            If rbtBillno.Checked = True Then
                listvendorname = obj.getdatatable("select user_Supply_no as displaytext,user_Supply_no as valuetext from Supply_hdr where user_Supply_no like '%" + txtKeyword.Text + "%'")
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
        If lstbxDetails.Text = "Add New" Then
            Contacts.Show()
            Contacts.BringToFront()
            Contacts.Focus()
        Else
            Try
                lstbxDetails.Visible = False
                txtKeyword.Text = lstbxDetails.Text
                FillDataGridView(lstbxDetails.SelectedValue)
            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub FillDataGridView(ByVal p1 As String)
        Try
            gridQuotations.Rows.Clear()
            Dim Supplynolist As New List(Of String)
            If rbtCusName.Checked = True Then
                Select Case p1
                    Case Is = ""
                        Supplynolist = obj.getcolumndatafromquery("select Supply_no from Supply_hdr where company_id=" + SharedData.companyid + " order by Supply_no,Supply_dt")
                    Case Else
                        Supplynolist = obj.getcolumndatafromquery("select Supply_no from Supply_hdr where contact_no='" + p1 + "' and company_id=" + SharedData.companyid + " order by Supply_no,Supply_dt")

                End Select
            ElseIf rbtBillno.Checked = True Then
                Select p1
                    Case Is = ""
                        Supplynolist = obj.getcolumndatafromquery("select Supply_no from Supply_hdr where company_id=" + SharedData.companyid + " order by Supply_no,Supply_dt")
                    Case Else
                        Supplynolist = obj.getcolumndatafromquery("select Supply_no from Supply_hdr where user_Supply_no='" + p1 + "' and company_id=" + SharedData.companyid + " order by Supply_no,Supply_dt")
                End Select
            ElseIf rbtdate.Checked = True Then
                Supplynolist = obj.getcolumndatafromquery("select Supply_no from Supply_hdr where Supply_dt between #" + Format(CDate(txtfromdate.Text), "MM/dd/yyyy") + "# and #" + Format(CDate(txttodate.Text), "MM/dd/yyyy") + "# order by Supply_no,Supply_dt")
            ElseIf rbtStatus.Checked = True Then
                Supplynolist = obj.getcolumndatafromquery("select Supply_no from Supply_hdr where payment_status=" & If(p1 = "Paid", 1, 0) & " order by Supply_no,Supply_dt")

            End If
            gridQuotations.ColumnCount = 10
            gridQuotations.Columns(0).Name = "Supply No"
            gridQuotations.Columns(1).Name = ""
            gridQuotations.Columns(2).Name = "Date"
            gridQuotations.Columns(3).Name = "Customer"
            gridQuotations.Columns(4).Name = "RefNo"
            gridQuotations.Columns(5).Name = "GrandTotal"
            gridQuotations.Columns(6).Name = "Status"
            gridQuotations.Columns(7).Name = "CreditDays"
            gridQuotations.Columns(8).Name = "VoucherDate"
            gridQuotations.Columns(9).Name = "VoucherNo"

            Dim getdata As New List(Of String)
            Dim contactname, voucherdt, purchasedt As String
            For i = 0 To Supplynolist.Count - 1
                getdata = obj.GetMoreValueFromQuery("select user_Supply_no, contact_no,Supply_dt, ref_no, " & _
                                                    " grand_total, payment_status," & _
                                                    " credit_days, voucher_no from Supply_hdr" & _
                                                    " where Supply_no='" + Supplynolist(i) + "'", 8)
                contactname = obj.GetOneValueFromQuery("select company_name from contact_tbl where contact_no='" + getdata(1) + "'")
                voucherdt = obj.GetOneValueFromQuery("select voucher_dt from voucher_tbl where voucher_no='" + getdata(7) + "'")
                voucherdt = If(voucherdt = "", "-", voucherdt)
                purchasedt = obj.ConvDtFrmt(getdata(2), "dd/MM/yyyy")
                gridQuotations.Rows.Add(getdata(0), Supplynolist(i), purchasedt, contactname, getdata(3),
                                        getdata(4), getdata(5), getdata(6), voucherdt, getdata(7))

            Next



            If gridQuotations.RowCount = 13 Then
            Else
                Dim btn As New DataGridViewButtonColumn
                btn.Name = "view"
                btn.HeaderText = ""
                btn.Text = "VIEW"
                btn.UseColumnTextForButtonValue = True
                gridQuotations.Columns.Add(btn)
                Dim btn1 As New DataGridViewButtonColumn
                btn1.Name = "edit"
                btn1.HeaderText = ""
                btn1.Text = "EDIT"
                btn1.UseColumnTextForButtonValue = True
                gridQuotations.Columns.Add(btn1)

                Dim btn2 As New DataGridViewButtonColumn
                btn2.Name = "delete"
                btn2.HeaderText = ""
                btn2.Text = "DELETE"
                btn2.UseColumnTextForButtonValue = True
                gridQuotations.Columns.Add(btn2)
            End If



            'gridAddCmp.DataSource = dt1



            gridQuotations.Refresh()
            gridQuotations.ReadOnly = True
            gridQuotations.AutoGenerateColumns = False
            gridQuotations.AllowUserToAddRows = False
            gridQuotations.Columns(1).Visible = False
            gridQuotations.ClearSelection()

            For i = 0 To gridQuotations.Rows.Count - 1
                If gridQuotations.Rows(i).Cells(6).Value = 1 Then
                    gridQuotations.Rows(i).Cells(6).Style.ForeColor = Color.Green
                    gridQuotations.Rows(i).Cells(6).Value = "Paid"
                Else
                    gridQuotations.Rows(i).Cells(6).Style.ForeColor = Color.Red
                    gridQuotations.Rows(i).Cells(6).Value = "Un Paid"
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

  
    Private Sub rbtStatus_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtStatus.CheckedChanged
        Select Case rbtStatus.Checked
            Case True
                Panel2.Visible = True
            Case False
                Panel2.Visible = False
        End Select
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        Try
            Dim path As String
            If (FolderBrowserDialog1.ShowDialog() = DialogResult.OK) Then
                path = FolderBrowserDialog1.SelectedPath() + "\SupplyRpt.xls"
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


            For i = 0 To gridQuotations.RowCount - 1
                For j = 0 To gridQuotations.ColumnCount - 1
                    For k As Integer = 1 To gridQuotations.Columns.Count
                        xlWorkSheet.Cells(1, k) = gridQuotations.Columns(k - 1).HeaderText
                        xlWorkSheet.Cells(i + 2, j + 1) = gridQuotations(j, i).Value.ToString()
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