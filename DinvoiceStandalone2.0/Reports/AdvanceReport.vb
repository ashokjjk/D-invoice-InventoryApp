Public Class AdvanceReport

    Private Sub AdvanceReport_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        MaximizeBox = False
        MinimizeBox = False
        lstbxDetails.Visible = False
        txtClientName.Focus()
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
        Try
            lstbxDetails.Visible = False
            txtClientName.Text = lstbxDetails.Text
            lblcuscode.Text = lstbxDetails.SelectedValue
        Catch ex As Exception

        End Try

    End Sub

    Private Sub txtClientName_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtClientName.KeyUp
        lblcuscode.Text = ""
        lstbxDetails.Visible = True
        lstbxDetails.BringToFront()
        Dim listclientname As New DataTable
        lstbxDetails.DataSource = Nothing
        If txtClientName.Text = "" Then
            lstbxDetails.Visible = False
        Else
            listclientname = obj.getdatatable("select company_name,contact_no from contact_tbl where company_name like '%" + txtClientName.Text + "%'")
            lstbxDetails.DisplayMember = "company_name"
            lstbxDetails.ValueMember = "contact_no"
            lstbxDetails.DataSource = listclientname
            lstbxDetails.Visible = True
        End If
    End Sub
    Private Sub FillDataGridView()
        Try
            gridAdvances.Rows.Clear()
            Dim invoicenolist As New List(Of String)
          

                If txtfromdate.Text <> "" And txttodate.Text <> "" Then

                invoicenolist = obj.getcolumndatafromquery("select advance_no from AdvanceGridView " & _
                                                               "where contact_no='" + lblcuscode.Text + "' and " & _
                                                               "advance_dt between #" + obj.ConvDtFrmt(txtfromdate.Text, "MM/dd/yyyy") + "# and #" + obj.ConvDtFrmt(txttodate.Text, "MM/dd/yyyy") + "# " & _
                                                               "and company_id=" + SharedData.companyid + "")
                Else

                invoicenolist = obj.getcolumndatafromquery("select advance_no from AdvanceGridView where " & _
                                                           " contact_no='" + lblcuscode.Text + "'" & _
                                                           " " & _
                                                           "and company_id=" + SharedData.companyid + "")
                End If

          
            gridAdvances.ColumnCount = 10
            gridAdvances.Columns(0).Name = "Advance No"
            gridAdvances.Columns(1).Name = "Customer"
            gridAdvances.Columns(2).Name = "Date"
            gridAdvances.Columns(3).Name = "Advance Amt"
            gridAdvances.Columns(4).Name = "Item Name"
            gridAdvances.Columns(5).Name = "GST(%)"
            gridAdvances.Columns(6).Name = "Cess(%)"
            gridAdvances.Columns(7).Name = "TotalAdvance"
            gridAdvances.Columns(8).Name = "InvoiceNo"
            gridAdvances.Columns(9).Name = "Status"

            Dim getdata As New List(Of String)
          
            For i = 0 To invoicenolist.Count - 1
                getdata = obj.GetMoreValueFromQuery("select advance_no, company_name, advance_dt, advance_amt, item_name, tax_percent, cess_percent, total_amt,  billno,  status from AdvanceGridView " & _
                                                    " where advance_no='" + invoicenolist(i) + "'", 10)
               
                gridAdvances.Rows.Add(getdata(0), getdata(1), getdata(2),
                                      getdata(3), getdata(4), getdata(5), getdata(6),
                                       getdata(7), getdata(8), getdata(9))

            Next
            If gridAdvances.ColumnCount = 11 Then
            Else
                Dim btn As New DataGridViewButtonColumn
                btn.Name = "view"
                btn.HeaderText = ""
                btn.Text = "VIEW"
                btn.UseColumnTextForButtonValue = True
                gridAdvances.Columns.Add(btn)

            End If
            gridAdvances.Refresh()
            gridAdvances.ReadOnly = True
            gridAdvances.AutoGenerateColumns = False
            gridAdvances.AllowUserToAddRows = False
            gridAdvances.ClearSelection()

          
        Catch ex As Exception
            MsgBox(ex.Message, , MessageBoxIcon.Error)
        End Try


    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        FillDataGridView()
    End Sub
    Private Sub gridInvoice_CellContentClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridAdvances.CellContentClick
        Try
            If e.ColumnIndex = 10 Then
                Dim s As New SharedData
                s.SetReportAdvanceno(gridAdvances.Rows(e.RowIndex).Cells(0).Value)
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
                path = FolderBrowserDialog1.SelectedPath() + "\AdvanceRpt.xls"
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


            For i = 0 To gridAdvances.RowCount - 1
                For j = 0 To gridAdvances.ColumnCount - 1
                    For k As Integer = 1 To gridAdvances.Columns.Count
                        xlWorkSheet.Cells(1, k) = gridAdvances.Columns(k - 1).HeaderText
                        xlWorkSheet.Cells(i + 2, j + 1) = gridAdvances(j, i).Value.ToString()
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