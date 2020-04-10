Public Class QuotationRpt
    Dim obj As New ObjClass
    Dim S As New SharedData
    Private Sub QuotationRpt_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        MaximizeBox = False
        MinimizeBox = False
        lstbxDetails.Visible = False
        Panel3.Visible = False
        txtKeyword.Focus()
        FillDataGridView("")
    End Sub

    Private Sub rbtdate_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtdate.CheckedChanged, rbtno.CheckedChanged
        Select Case rbtdate.Checked
            Case True
                Panel3.Visible = True
            Case False
                Panel3.Visible = False
        End Select
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

    Private Sub gridQuotations_CellContentClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridQuotations.CellContentClick
        Try
            If e.ColumnIndex = 9 Then
                Dim s As New SharedData

                s.SetReportQuotationno(gridQuotations.Rows(e.RowIndex).Cells(1).Value)
                    ReportScreen.Show()
                    ReportScreen.BringToFront()
                'ReportScreen.TopMost = True

               


            End If
            If e.ColumnIndex = 10 Then
                S.SetQuotationno(gridQuotations.Rows(e.RowIndex).Cells(1).Value)
                Quotation.Show()
                Quotation.BringToFront()
                Quotation.Focus()
            End If
            If e.ColumnIndex = 11 Then
                Dim result As Integer = MessageBox.Show("Are you sure want to Delete??" & vbCrLf & "Careful Quotation can't be Reversed!!!!", "Caution !!!", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information)
                If result = DialogResult.Cancel Then

                ElseIf result = DialogResult.No Then

                ElseIf result = DialogResult.Yes Then
                    obj.QueryExecution("delete from Quotation_hdr where quotation_no='" + gridQuotations.Rows(e.RowIndex).Cells(1).Value + "'")
                    obj.QueryExecution("delete from Quotation_dtl where quotation_no='" + gridQuotations.Rows(e.RowIndex).Cells(1).Value + "'")
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
            If rbtno.Checked = True Then
                listvendorname = obj.getdatatable("select user_quotation_no as displaytext,user_quotation_no as valuetext from quotation_hdr where user_quotation_no like '%" + txtKeyword.Text + "%'")
            End If
            If rbtdate.Checked = True Then
                MsgBox("Client and Quotation no will only work in this criteria, click Search button!!")
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
            Dim quotationlist As New List(Of String)
            If rbtCusName.Checked = True Then
                Select Case p1
                    Case Is = ""
                        quotationlist = obj.getcolumndatafromquery("select quotation_no from quotation_hdr where company_id=" + SharedData.companyid + " order by quotation_no,quotation_dt")
                    Case Else
                        quotationlist = obj.getcolumndatafromquery("select quotation_no from quotation_hdr where contact_no='" + p1 + "' and company_id=" + SharedData.companyid + " order by quotation_no,quotation_dt ")
                End Select
            ElseIf rbtno.Checked = True Then
                Select Case p1
                    Case Is = ""
                        quotationlist = obj.getcolumndatafromquery("select quotation_no from quotation_hdr where company_id=" + SharedData.companyid + " order by quotation_no,quotation_dt")
                    Case Else
                        quotationlist = obj.getcolumndatafromquery("select quotation_no from quotation_hdr where user_quotation_no='" + p1 + "' and company_id=" + SharedData.companyid + " order by quotation_no,quotation_dt")
                End Select
            ElseIf rbtdate.Checked = True Then
                quotationlist = obj.getcolumndatafromquery("select quotation_no from quotation_hdr where quotation_dt between #" + Format(CDate(txtfromdate.Text), "MM/dd/yyyy") + "# and #" + Format(CDate(txttodate.Text), "MM/dd/yyyy") + "# order by quotation_no,quotation_dt")

            End If
            gridQuotations.ColumnCount = 9
            gridQuotations.Columns(0).Name = "Quotation No"
            gridQuotations.Columns(1).Name = ""
            gridQuotations.Columns(2).Name = "Date"
            gridQuotations.Columns(3).Name = "Customer"
            gridQuotations.Columns(4).Name = "RefNo"
            gridQuotations.Columns(5).Name = "Total"
            gridQuotations.Columns(6).Name = "Tax"
            gridQuotations.Columns(7).Name = "GrandTotal"
            gridQuotations.Columns(8).Name = "Valid Until"
            Dim getdata As New List(Of String)
            Dim contactname, quotationdt As String
            For i = 0 To quotationlist.Count - 1
                getdata = obj.GetMoreValueFromQuery("select user_quotation_no, quotation_no,quotation_dt, sub_total, " & _
                                                    "total_tax + total_cess, grand_total,ref_no,validuntil_dt,contact_no" & _
                                                    " from quotation_hdr" & _
                                                    " where quotation_no='" + quotationlist(i) + "'", 9)
                contactname = obj.GetOneValueFromQuery("select company_name from contact_tbl where contact_no='" + getdata(8) + "'")
                quotationdt = obj.ConvDtFrmt(getdata(2), "dd/MM/yyyy")
                gridQuotations.Rows.Add(getdata(0), quotationlist(i), quotationdt, contactname, getdata(6), getdata(3), getdata(4), getdata(5), getdata(7))

            Next



            If gridQuotations.RowCount = 12 Then
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
            Dim datedifference As Integer
            For i = 0 To gridQuotations.Rows.Count - 1
                If gridQuotations.Rows(i).Cells(8).Value = "01/01/1900" Then
                    gridQuotations.Rows(i).Cells(8).Value = "-"
                    Continue For

                Else
                    datedifference = (CDate(gridQuotations.Rows(i).Cells(8).Value) - Today).TotalDays
                End If
                If datedifference >= 5 Then
                    gridQuotations.Rows(i).Cells(8).Style.BackColor = Color.LawnGreen
                ElseIf datedifference = 3 Or datedifference = 4 Then
                    gridQuotations.Rows(i).Cells(8).Style.BackColor = Color.Yellow
                ElseIf datedifference = 2 Or datedifference = 1 Then
                    gridQuotations.Rows(i).Cells(8).Style.BackColor = Color.Red
                Else

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
                path = FolderBrowserDialog1.SelectedPath() + "\QuotationRpt.xls"
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
End Class