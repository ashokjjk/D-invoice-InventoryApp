Public Class IndentReport

    Private Sub IndentReport_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        MaximizeBox = False
        MinimizeBox = False
        lstbxDetails.Visible = False
        txtVendorName.Focus()
    End Sub

    Dim obj As New ObjClass
    Private Sub DateTimePicker2_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        obj.dtpick(txttodate, dtptodate)
    End Sub
    Private Sub DateTimePicker1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        obj.dtpick(txtfromdate, dtpfromdate)
    End Sub
    Private Sub lstClientName_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lstbxDetails.MouseClick
        lstbxDetails.Visible = False
        Try
            lstbxDetails.Visible = False
            txtVendorName.Text = lstbxDetails.Text
            lblcuscode.Text = lstbxDetails.SelectedValue
        Catch ex As Exception

        End Try

    End Sub

    Private Sub txtClientName_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtVendorName.KeyUp
        lblcuscode.Text = ""
        lstbxDetails.Visible = True
        lstbxDetails.BringToFront()
        Dim listclientname As New DataTable
        lstbxDetails.DataSource = Nothing
        If txtVendorName.Text = "" Then
            lstbxDetails.Visible = False
        Else
            If rbtIndent.Checked = True Then

                listclientname = obj.getdatatable("select distinct indent_no as displaytext from IndentGridView where indent_no like '%" + txtVendorName.Text + "%'")
            End If

            If rbtInvoice.Checked = True Then
                listclientname = obj.getdatatable("select  distinct bill_no  as displaytext from IndentGridView where bill_no like '%" + txtVendorName.Text + "%'")

            End If
            If rbtGatepass.Checked = True Then
                listclientname = obj.getdatatable("select  distinct gatepass_no as displaytext from IndentGridView where gatepass_no like '%" + txtVendorName.Text + "%'")

            End If

            lstbxDetails.DisplayMember = "displaytext"
            lstbxDetails.ValueMember = "displaytext"
            lstbxDetails.DataSource = listclientname
            lstbxDetails.Visible = True
        End If
    End Sub
    Private Sub FillDataGridView()
        Try
            gridBills.Rows.Clear()
            Dim invoicenolist As New List(Of String)
            If rbtIndent.Checked = True Then


                If txtfromdate.Text <> "" And txttodate.Text <> "" Then

                    invoicenolist = obj.getcolumndatafromquery("select ID from IndentGridView where indent_no='" + lblcuscode.Text + "' and " & _
                                                                   "indent_dt between #" + obj.ConvDtFrmt(txtfromdate.Text, "MM/dd/yyyy") + "# and #" + obj.ConvDtFrmt(txttodate.Text, "MM/dd/yyyy") + "# " & _
                                                                   "and company_id=" + SharedData.companyid + "")
                Else
                    invoicenolist = obj.getcolumndatafromquery("select ID from IndentGridView  " & _
                                                               "where indent_no='" + lblcuscode.Text + "'" & _
                                                               " " & _
                                                               "and company_id=" + SharedData.companyid + "")
                End If
            End If

            If rbtInvoice.Checked = True Then


                If txtfromdate.Text <> "" And txttodate.Text <> "" Then

                    invoicenolist = obj.getcolumndatafromquery("select ID from IndentGridView where bill_no='" + lblcuscode.Text + "' and " & _
                                                                   "indent_dt between #" + obj.ConvDtFrmt(txtfromdate.Text, "MM/dd/yyyy") + "# and #" + obj.ConvDtFrmt(txttodate.Text, "MM/dd/yyyy") + "# " & _
                                                                   "and company_id=" + SharedData.companyid + "")
                Else
                    invoicenolist = obj.getcolumndatafromquery("select ID from IndentGridView " & _
                                                               "where bill_no='" + lblcuscode.Text + "'" & _
                                                               " " & _
                                                               "and company_id=" + SharedData.companyid + "")
                End If
            End If
            If rbtGatepass.Checked = True Then


                If txtfromdate.Text <> "" And txttodate.Text <> "" Then

                    invoicenolist = obj.getcolumndatafromquery("select ID from IndentGridView where gatepass_no='" + lblcuscode.Text + "' and " & _
                                                                   "indent_dt between #" + obj.ConvDtFrmt(txtfromdate.Text, "MM/dd/yyyy") + "# and #" + obj.ConvDtFrmt(txttodate.Text, "MM/dd/yyyy") + "# " & _
                                                                   "and company_id=" + SharedData.companyid + "")
                Else
                    invoicenolist = obj.getcolumndatafromquery("select ID from IndentGridView where  " & _
                                                               "where gatepass_no='" + lblcuscode.Text + "'" & _
                                                               " " & _
                                                               "and company_id=" + SharedData.companyid + "")
                End If
            End If


            gridBills.ColumnCount = 8
            gridBills.Columns(0).Name = "Indent No"
            gridBills.Columns(1).Name = "Item Name"
            gridBills.Columns(2).Name = "Desc"
            gridBills.Columns(3).Name = "Pattern"
            gridBills.Columns(4).Name = "Qty"
            gridBills.Columns(5).Name = "Notes"
            gridBills.Columns(6).Name = "Bill No"
            gridBills.Columns(7).Name = "GatePass No"
           

            Dim getdata As New List(Of String)

            For i = 0 To invoicenolist.Count - 1
                getdata = obj.GetMoreValueFromQuery("select indent_no, item_name, item_desc,pattern, qty, notes,bill_no , gatepass_no, bill_flg, gatepass_flg,ID FROM indent_dtl " & _
                                                    " where ID=" + invoicenolist(i) + "", 11)

                gridBills.Rows.Add(getdata(0), getdata(1), getdata(2),
                                      getdata(3), getdata(4), getdata(5), getdata(6),
                                       getdata(7))

            Next
            If gridBills.ColumnCount = 9 Then
            Else
                Dim btn As New DataGridViewButtonColumn
                btn.Name = "view"
                btn.HeaderText = ""
                btn.Text = "VIEW"
                btn.UseColumnTextForButtonValue = True
                gridBills.Columns.Add(btn)

            End If
            gridBills.Refresh()
            gridBills.ReadOnly = True
            gridBills.AutoGenerateColumns = False
            gridBills.AllowUserToAddRows = False
            gridBills.ClearSelection()


        Catch ex As Exception
            MsgBox(ex.Message, , MessageBoxIcon.Error)
        End Try


    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        FillDataGridView()
    End Sub
    Private Sub gridInvoice_CellContentClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridBills.CellContentClick
        Try
            If e.ColumnIndex = 8 Then
                Dim s As New SharedData
                s.SetReportIndentno(gridBills.Rows(e.RowIndex).Cells(0).Value)
                ReportScreen.Show()
                ReportScreen.BringToFront()
                'ReportScreen.TopMost = True
            End If
        Catch ex As Exception

        End Try
    End Sub

  
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            Dim path As String
            If (FolderBrowserDialog1.ShowDialog() = DialogResult.OK) Then
                path = FolderBrowserDialog1.SelectedPath() + "\IndentRpt.xls"
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