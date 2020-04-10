Imports System.IO
Imports ClosedXML.Excel
Public Class ItemwiseSale

    Private Sub ItemwiseSale_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        MaximizeBox = False
        MinimizeBox = False
        Panel3.Visible = False
        lstbxDetails.Visible = False
        txtSearchKeyword.Focus()
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

    Private Sub txtSearchKeyword_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSearchKeyword.KeyPress
        lstbxDetails.Visible = True
    End Sub

    Private Sub lstbxDetails_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lstbxDetails.MouseClick
        lstbxDetails.Visible = False
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
            txtSearchKeyword.Text = lstbxDetails.Text
            lblcuscode.Text = lstbxDetails.SelectedValue
        Catch ex As Exception

        End Try

    End Sub

    Private Sub txtClientName_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSearchKeyword.KeyUp
        lblcuscode.Text = ""
        lstbxDetails.Visible = True
        lstbxDetails.BringToFront()
        Dim listitemname As New DataTable
        lstbxDetails.DataSource = Nothing
        If txtSearchKeyword.Text = "" Then
            lstbxDetails.Visible = False
        Else
            listitemname = obj.getdatatable(" select item_name,item_no from item_tbl where item_name like '%" + txtSearchKeyword.Text + "%'")

            lstbxDetails.DisplayMember = "item_name"
            lstbxDetails.ValueMember = "item_no"
            lstbxDetails.DataSource = listitemname
            lstbxDetails.Visible = True
        End If
    End Sub
    Private Sub FillDataGridView()
        Try
            gridInvoice.Rows.Clear()
            Dim invoicenolist As New List(Of String)
            If rbtPlaceofSupply.Checked = True Then
                If txtfromdate.Text <> "" And txttodate.Text <> "" Then
                    invoicenolist = obj.getcolumndatafromquery("select invoice_no from ItemSalesReport where item_no='" + lblcuscode.Text + "' and invoice_dt between #" + obj.ConvDtFrmt(txtfromdate.Text, "MM/dd/yyyy") + "# and #" + obj.ConvDtFrmt(txttodate.Text, "MM/dd/yyyy") + "# and  company_id=" + SharedData.companyid + "")
                Else
                    invoicenolist = obj.getcolumndatafromquery("select invoice_no from ItemSalesReport where item_no='" + lblcuscode.Text + "' and place_supply='" + cmbstate.Text + "'  and company_id=" + SharedData.companyid + "")
                End If
                Else
                invoicenolist = obj.getcolumndatafromquery("select invoice_no from ItemSalesReport where item_no='" + lblcuscode.Text + "'  and  company_id=" + SharedData.companyid + "")

            End If
            gridInvoice.ColumnCount = 13
            gridInvoice.Columns(0).Name = "Invoice No"
            gridInvoice.Columns(1).Name = "Customer"
            gridInvoice.Columns(2).Name = "RefNo"
            gridInvoice.Columns(3).Name = "Date"
            gridInvoice.Columns(4).Name = "Place Of Supply"
            gridInvoice.Columns(5).Name = "Item Name"
            gridInvoice.Columns(6).Name = "Sub Total"
            gridInvoice.Columns(7).Name = "IGST"
            gridInvoice.Columns(8).Name = "SGST"
            gridInvoice.Columns(9).Name = "CGST"
            gridInvoice.Columns(10).Name = "GrandTotal"
            gridInvoice.Columns(11).Name = "VoucherNo"
            gridInvoice.Columns(12).Name = "PayMode"
            Dim getdata As New List(Of String)
            Dim gsttype, invoicedt As String
            Dim cgst, sgst, igst As String
            For i = 0 To invoicenolist.Count - 1
                getdata = obj.GetMoreValueFromQuery("select company_name, invoice_no," & _
                                                    "user_invoice_no, ref_no, " & _
                                                    " invoice_dt, place_supply," & _
                                                    "  billing_state, item_amount, " & _
                                                    " tax_amt, cess_amt, payment_status,item_name,voucher_no" & _
                                                    "  from ItemSalesReport" & _
                                                    " where invoice_no='" + invoicenolist(i) + "'", 13)
                gsttype = If(getdata(5) = getdata(6), "GST", "IGST")

                If gsttype = "GST" Then
                    cgst = (CDbl(getdata(8)) / 2).ToString
                    sgst = (CDbl(getdata(8)) / 2).ToString
                    igst = "0"
                Else
                    cgst = "0"
                    sgst = "0"
                    igst = getdata(8)
                End If

                invoicedt = obj.ConvDtFrmt(getdata(4), "dd/MM/yyyy")
                gridInvoice.Rows.Add(getdata(2), getdata(0), getdata(3), invoicedt, getdata(5), getdata(11),
                                      getdata(7), igst, sgst,
                                      cgst, CDbl(getdata(7)) + CDbl(getdata(8)) + CDbl(getdata(9)), getdata(12), getdata(10))

            Next

            gridInvoice.Refresh()
            gridInvoice.ReadOnly = True
            gridInvoice.AutoGenerateColumns = False
            gridInvoice.AllowUserToAddRows = False

            gridInvoice.ClearSelection()

            For i = 0 To gridInvoice.Rows.Count - 1
                If gridInvoice.Rows(i).Cells(12).Value = "1" Then
                    gridInvoice.Rows(i).Cells(12).Style.ForeColor = Color.Green
                    gridInvoice.Rows(i).Cells(12).Value = "Paid"
                Else
                    gridInvoice.Rows(i).Cells(12).Style.ForeColor = Color.Red
                    gridInvoice.Rows(i).Cells(12).Value = "Un Paid"
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
        Try
            Dim path As String
            If (FolderBrowserDialog1.ShowDialog() = DialogResult.OK) Then
                path = FolderBrowserDialog1.SelectedPath() + "\ItemWiseSaleRpt.xls"
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