Public Class CreditDebit
    Dim obj As New ObjClass
    Dim s As New SharedData
    Private Sub CreditDebit_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        MaximizeBox = False
        MinimizeBox = False
        lstbxInvNo.Visible = False
        lstClientName.Visible = False
        Panel5.Visible = False
        txtClientName.Focus()
        rbtName.Checked = True
        cmbAcctype.Items.Clear()
        Dim reasonlist As New List(Of String)
        Dim acctype As New List(Of String)
        acctype = obj.getcolumndatafromquery("select distinct account_type from account_tbl")
        For i = 0 To acctype.Count - 1
            cmbAcctype.Items.Add(acctype(i))
        Next
        reasonlist = obj.getcolumndatafromquery("select distinct reason_issue_note from gst_desc")
        For i = 0 To reasonlist.Count - 1
            cmbReason.Items.Add(reasonlist(i))
        Next
        cmbAccName.DataSource = Nothing
        cmbAccName.Items.Clear()
        obj.TodayDate(txtDate)
        txtVouNo.Text = obj.GetOneValueFromQuery("select credit_debit_frmt&''&credit_debit_no from control_tbl where company_id=" + SharedData.companyid + "")
        BindGridViewCD("")


    End Sub

    Private Sub rbtDate_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtDate.CheckedChanged
        Select Case rbtDate.Checked
            Case True
                Panel5.Visible = True
            Case False
                Panel5.Visible = False
        End Select
    End Sub
    Private Sub cmbAcctype_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbAcctype.SelectedIndexChanged
        cmbAccName.DataSource = Nothing
        Dim acclist As New DataTable
        acclist = obj.getdatatable("select account_head,ID from account_tbl where account_type='" + cmbAcctype.Text + "'")
        cmbAccName.DisplayMember = "account_head"
        cmbAccName.ValueMember = "ID"
        cmbAccName.DataSource = acclist
    End Sub
    Private Sub txtClientName_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtClientName.KeyPress
        lstClientName.Visible = True
    End Sub



    Private Sub txtInvno_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtInvno.KeyPress
        lstbxInvNo.Visible = True

    End Sub

    Private Sub txtInvno_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtInvno.KeyUp
        Dim listinvno As New DataTable
        lstbxInvNo.DataSource = Nothing
        If txtInvno.Text = "" Then
            lstbxInvNo.Visible = False
        Else
            listinvno = obj.getdatatable("select user_invoice_no,invoice_no from invoice_hdr where user_invoice_no like '%" + txtInvno.Text + "%' and voucher_flg=1 and contact_no='" + lstClientName.SelectedValue + "'")
            lstbxInvNo.DisplayMember = "user_invoice_no"
            lstbxInvNo.ValueMember = "invoice_no"
            lstbxInvNo.DataSource = listinvno
            lstbxInvNo.Visible = True
        End If
    End Sub
    Private Sub lstbxInvNo_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lstbxInvNo.MouseClick
        lstbxInvNo.Visible = False
        Try
            Dim invno As String = lstbxInvNo.SelectedValue
            Dim getdata As New List(Of String)
            getdata = obj.GetMoreValueFromQuery("select invoice_dt, place_supply, account_id, sub_total," & _
                                                " total_tax, total_cess, grand_total from invoice_hdr " & _
                                                "where invoice_no='" + invno + "'", 7)

            lstbxInvNo.Visible = False
            txtInvno.Text = lstbxInvNo.Text
            txtinvdate.Text = Format(CDate(getdata(0)), "dd/MM/yyyy")
            txtPlaceofSupply.Text = getdata(1)
            cmbAcctype.Text = getdata(2)
            txtTaxableValue.Text = getdata(3)
            txtTaxRate.Text = getdata(4)
            txtCess.Text = getdata(5)
            txtRefundValue.Text = getdata(6)

        Catch ex As Exception

        End Try

    End Sub

    Private Sub txtClientName_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtClientName.KeyUp
        Dim listvendorname As New DataTable
        lstClientName.DataSource = Nothing
        If txtClientName.Text = "" Then
            lstClientName.Visible = False
        Else

            listvendorname = obj.getdatatable("select company_name,contact_no from contact_tbl where company_name like '%" + txtClientName.Text + "%'")
            lstClientName.DisplayMember = "company_name"
            lstClientName.ValueMember = "contact_no"
            lstClientName.DataSource = listvendorname
            lstClientName.Visible = True
        End If

        lblcuscode.Text = ""
    End Sub
    Private Sub lstClientName_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lstClientName.MouseClick
        lstClientName.Visible = False
        If lstClientName.Text = "Add New" Then
            Contacts.Show()
            Contacts.BringToFront()
            Contacts.Focus()
        Else
            Try
                lblcuscode.Text = lstClientName.SelectedValue
                lstClientName.Visible = False
                txtClientName.Text = lstClientName.Text

            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub dtpDate_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpDate.ValueChanged
        Me.txtDate.Text = Me.dtpDate.Value.Date.ToString("dd/MM/yyyy")
    End Sub


    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim credit_debit_no, contact_no, credit_debit_user_no, voucher_dt,
            voucher_type, voucher_amt, refund_value, account_id,
            invoice_no, invoice_dt, reason, place_supply, taxable_value,
            tax_rate, cess, notes, company_id, user_name As String

        contact_no = lblcuscode.Text
        credit_debit_user_no = txtVouNo.Text
        voucher_dt = txtDate.Text
        voucher_type = cmbVouType.Text
        voucher_amt = txtRefundValue.Text
        refund_value = txtRefundValue.Text
        account_id = cmbAccName.SelectedValue
        invoice_no = txtInvno.Text
        invoice_dt = txtinvdate.Text
        reason = cmbReason.Text
        place_supply = txtPlaceofSupply.Text
        taxable_value = txtTaxableValue.Text
        tax_rate = txtTaxRate.Text
        cess = txtCess.Text
        notes = txtNotes.Text
        company_id = SharedData.companyid
        user_name = SharedData.userid

        If obj.validContact(contact_no) = False Then
            MsgBox("ContactName is not Valid!!", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        Dim txt As New List(Of String)
        txt.Add(credit_debit_user_no)
        txt.Add(voucher_dt)
        txt.Add(voucher_type)
        txt.Add(reason)
        txt.Add(account_id)
        If obj.TextBoxValidate(txt) = False Then
            MsgBox("All * value  Required", MsgBoxStyle.Exclamation)
            Exit Sub
        End If





        Dim QueryCollection As New List(Of String)
        Select Case btnSave.Text
            Case Is = "Save"
                credit_debit_no = obj.GetOneValueFromQuery("select credit_debit_frmt&''&credit_debit_no from control_tbl where company_id=" + SharedData.companyid + "")

                QueryCollection.Add("insert into credit_debit_tbl(credit_debit_no,contact_no," & _
     " credit_debit_user_no, voucher_dt," & _
        " voucher_type, voucher_amt, refund_value, account_id," & _
     "invoice_no, invoice_dt, reason, place_supply, taxable_value, " & _
        " tax_rate, cess, notes, company_id, user_name) values('" + credit_debit_no + "','" + contact_no + "'," & _
        "'" + credit_debit_user_no + "','" + voucher_dt + "','" + voucher_type + "'," & _
        "" + voucher_amt + "," + refund_value + "," + account_id + "," & _
        "'" + invoice_no + "','" + invoice_dt + "','" + reason + "'," & _
        "'" + place_supply + "'," + taxable_value + "," + tax_rate + "," & _
        "" + cess + ",'" + obj.inapos(notes) + "'," + company_id + "," & _
        "'" + user_name + "')")
                QueryCollection.Add("update control_tbl set credit_debit_no=credit_debit_no+1 where company_id=" + company_id + "")

            Case Is = "Update"
                credit_debit_no = lblcode.Text
                QueryCollection.Add("update credit_debit_tbl set contact_no='" + contact_no + "', " & _
        "credit_debit_user_no='" + credit_debit_user_no + "', voucher_dt='" + voucher_dt + "'," & _
        " voucher_type='" + voucher_type + "', voucher_amt=" + voucher_amt + ", " & _
        "refund_value=" + refund_value + ", account_id=" + account_id + "," & _
     "invoice_no='" + invoice_no + "', invoice_dt='" + invoice_dt + "', reason='" + reason + "', " & _
        "place_supply='" + place_supply + "', taxable_value=" + taxable_value + ", " & _
        " tax_rate=" + tax_rate + ", cess=" + cess + ", notes='" + obj.inapos(notes) + "' " & _
        "where credit_debit_no='" + credit_debit_no + "'")
                lblcuscode.Text = ""
                lblcode.Text = ""
                btnSave.Text = "Save"
        End Select
        Dim result As Boolean = obj.TransactionInsert(QueryCollection)
        Select Case result
            Case True
                MsgBox("Credit/Debit details updated!!", MessageBoxIcon.Information)
                s.SetCDData(credit_debit_no)
                ReportScreen.Show()
                ReportScreen.BringToFront()
                ReportScreen.TopMost = True

                Me.Controls.Clear()
                InitializeComponent()
                CreditDebit_Load(e, e)
            Case False
                MsgBox("Something Went Wrong!!", MessageBoxIcon.Exclamation)
        End Select
      

    End Sub

    Private Sub DateTimePicker1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DateTimePicker1.ValueChanged
        Me.txtinvdate.Text = Me.DateTimePicker1.Value.Date.ToString("dd/MM/yyyy")
    End Sub
    Sub BindGridViewCD(ByVal s As String)
        Try
            gridVoucher.ColumnCount = 5
            gridVoucher.Columns(0).Name = "Customer"
            gridVoucher.Columns(1).Name = "Voucher No"
            gridVoucher.Columns(2).Name = "Voucher Date"
            gridVoucher.Columns(3).Name = "Voucher Amt"
            gridVoucher.Columns(4).Name = ""

            gridVoucher.Rows.Clear()
            Dim dt1 As New DataTable
            Dim datefrom, dateto As String
            If rbtName.Checked = True Then
                dt1 = obj.getdatatable("select top 50 b.company_name,a.voucher_dt,a.credit_debit_user_no,a.voucher_amt ,a.credit_debit_no,a.voucher_type from credit_debit_tbl a,contact_tbl b where a.contact_no=b.contact_no  and  b.company_name like '%" + s + "%'")

            ElseIf rbtDate.Checked = True Then
                If Me.dtpSearchfromdt.Text = "" Or Me.dtpSearchtodt.Text = "" Then
                    Exit Sub
                Else
                    datefrom = Format(CDate(Me.dtpSearchfromdt.Text), "MM/dd/yyyy")
                    dateto = Format(CDate(Me.dtpSearchtodt.Text), "MM/dd/yyyy")
                    dt1 = obj.getdatatable("select top 50 b.company_name,a.voucher_dt,a.credit_debit_user_no,a.voucher_amt ,a.credit_debit_no,a.voucher_type from credit_debit_tbl a,contact_tbl b where a.contact_no=b.contact_no  and  a.voucher_dt between #" + datefrom + "# and #" + dateto + "#")

                End If
            End If

            For i = 0 To dt1.Rows.Count - 1
                gridVoucher.Rows.Add(dt1.Rows(i).Item(0).ToString, dt1.Rows(i).Item(2).ToString, Format(CDate(dt1.Rows(i).Item(1).ToString), "dd/MM/yyyy"), dt1.Rows(i).Item(3).ToString, dt1.Rows(i).Item(4).ToString)
            Next
            ' gridVoucher.DataSource = dt1

            Dim btn2 As New DataGridViewButtonColumn
            btn2.Name = "view"
            btn2.HeaderText = ""
            btn2.Text = "VIEW"
            btn2.UseColumnTextForButtonValue = True
            gridVoucher.Columns.Add(btn2)

            Dim btn As New DataGridViewButtonColumn
            btn.Name = "edit"
            btn.HeaderText = ""
            btn.Text = "EDIT"
            btn.UseColumnTextForButtonValue = True
            gridVoucher.Columns.Add(btn)

            Dim btn1 As New DataGridViewButtonColumn
            btn1.Name = "delete"
            btn1.HeaderText = ""
            btn1.Text = "DELETE"
            btn1.UseColumnTextForButtonValue = True
            gridVoucher.Columns.Add(btn1)


            gridVoucher.Refresh()
            gridVoucher.ReadOnly = True
            gridVoucher.AutoGenerateColumns = False
            gridVoucher.AllowUserToAddRows = False
            gridVoucher.Columns(4).Visible = False
            gridVoucher.ClearSelection()
        Catch ex As Exception
            MsgBox(ex.Message, , MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub dtpSearchfromdt_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpSearchfromdt.ValueChanged
        Me.txtSearchfromdt.Text = Me.dtpSearchfromdt.Value.Date.ToString("dd/MM/yyyy")
    End Sub

    Private Sub dtpSearchtodt_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpSearchtodt.ValueChanged
        Me.txtSearchtodt.Text = Me.dtpSearchtodt.Value.Date.ToString("dd/MM/yyyy")
    End Sub

    Private Sub gridVoucher_CellContentClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridVoucher.CellContentClick
        Try
            If (e.ColumnIndex = 5) Then
                s.SetCDData(gridVoucher.Rows(e.RowIndex).Cells(4).Value)
                ReportScreen.Show()
                ReportScreen.BringToFront()
                ReportScreen.TopMost = True
            End If


            If e.ColumnIndex = 6 Then
                Dim Listdata As New List(Of String)

                Listdata = obj.GetMoreValueFromQuery("Select contact_no,credit_debit_user_no, voucher_dt, voucher_type," & _
                                                     " voucher_amt, refund_value, account_id, invoice_no, invoice_dt," & _
                                                     " reason, place_supply, taxable_value, tax_rate, cess, notes " & _
                                                     "from credit_debit_tbl where credit_debit_no=" & _
                                                     "'" + gridVoucher.Rows(e.RowIndex).Cells(4).Value + "'", 15)
                lblcuscode.Text = Listdata(0)
                txtClientName.Text = gridVoucher.Rows(e.RowIndex).Cells(0).Value

                txtVouNo.Text = Listdata(1)
                txtDate.Text = Listdata(2)
                cmbVouType.Text = Listdata(3)
                txtRefundValue.Text = Listdata(4)
                ' txtRefundValue.Text = Listdata(5)
                cmbAcctype.Text = Listdata(6)
                txtInvno.Text = Listdata(7)
                txtinvdate.Text = Listdata(8)
                cmbReason.Text = Listdata(9)
                txtPlaceofSupply.Text = Listdata(10)
                txtTaxableValue.Text = Listdata(11)
                txtTaxRate.Text = Listdata(12)
                txtCess.Text = Listdata(13)
                txtNotes.Text = Listdata(14)
                btnSave.Text = "Update"
                lblcode.Text = gridVoucher.Rows(e.RowIndex).Cells(4).Value

            End If
            If e.ColumnIndex = 7 Then
                Dim result As Integer = MessageBox.Show("Are you sure want to Delete??", "Caution !!!", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning)
                If result = DialogResult.Cancel Then

                ElseIf result = DialogResult.No Then

                ElseIf result = DialogResult.Yes Then
                    obj.QueryExecution("delete from credit_debit_tbl where credit_debit_no='" + gridVoucher.Rows(e.RowIndex).Cells(2).Value + "'")
                End If
                CreditDebit_Load(e, e)
            End If


        Catch ex As Exception
            MsgBox(ex.Message, MessageBoxIcon.Exclamation)
        End Try
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        BindGridViewCD(txtSearchKeyword.Text)
    End Sub

    Private Sub txtSearchKeyword_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSearchKeyword.KeyUp
        BindGridViewCD(txtSearchKeyword.Text)
    End Sub

    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        Me.Controls.Clear()
        InitializeComponent()
        CreditDebit_Load(e, e)
    End Sub
End Class