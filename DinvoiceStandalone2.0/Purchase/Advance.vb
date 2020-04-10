Public Class Advance
    Dim obj As New ObjClass
    Dim S As New SharedData

    Private Sub Advance_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Panel2.Visible = False
        pnlBankdtls.Visible = False
        MaximizeBox = False
        MinimizeBox = False
        lstbxCusname.Visible = False
        lstbxItemName.Visible = False
        txtCusName.Focus()
        obj.ClearTextBox(Me)
        cmbCessPercent.Items.Clear()
        txtTaxpercent.Items.Clear()
        cmbacctype.Items.Clear()
        obj.TodayDate(txtadvdate)
        cmbaccname.DataSource = Nothing
        cmbaccname.Items.Clear()
        Dim acctype As New List(Of String)
       
        acctype = obj.getcolumndatafromquery("select distinct account_type from account_tbl")
        For i = 0 To acctype.Count - 1
            cmbacctype.Items.Add(acctype(i))
        Next
        Dim cesslist, gstratelist, acclist As New List(Of String)
        cesslist = obj.getcolumndatafromquery("select distinct cess from gst_tbl")
        gstratelist = obj.getcolumndatafromquery("select distinct gst_rate from gst_tbl")
        For i = 0 To cesslist.Count - 1
            cmbCessPercent.Items.Add(cesslist(i))
        Next
        For i = 0 To gstratelist.Count - 1
            txtTaxpercent.Items.Add(gstratelist(i))
        Next
       
        BindGridViewAdvance("")
    End Sub
    Private Sub cmbAccType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbacctype.SelectedIndexChanged
        'cmbaccname.Items.Clear()
        cmbaccname.DataSource = Nothing
        Dim acclist As New DataTable
        acclist = obj.getdatatable("select account_head,ID from account_tbl where account_type='" + cmbAccType.Text + "'")
        cmbaccname.DisplayMember = "account_head"
        cmbaccname.ValueMember = "ID"
        cmbaccname.DataSource = acclist
    End Sub
    Private Sub rbtdate_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtdate.CheckedChanged
        Select Case rbtdate.Checked
            Case True
                Panel2.Visible = True
            Case Else
                Panel2.Visible = False
        End Select
    End Sub

    Private Sub rbtName_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtName.CheckedChanged
        Select Case rbtName.Checked
            Case True
                Panel2.Visible = False
            Case Else
                Panel2.Visible = True
        End Select
    End Sub
    Sub CalculationArea()
        Dim TotAdvAmt, advamt, taxamt, cessamt As Double
        advamt = obj.StrToDouble(Me.txtAdvAmt.Text)
        taxamt = obj.StrToDouble(Me.txtTaxpercent.Text)
        cessamt = obj.StrToDouble(Me.cmbCessPercent.Text)
        TotAdvAmt = advamt + (obj.FdPercCalc(advamt, taxamt)) + (obj.FdPercCalc(advamt, cessamt))
        Me.txtAdvTotal.Text = TotAdvAmt

    End Sub
    Private Sub txtCusName_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCusName.KeyUp
        lstbxCusname.Visible = True
        Dim listvendorname As New DataTable
        lstbxCusname.DataSource = Nothing
        If txtCusName.Text = "" Then
            lstbxCusname.Visible = False
        Else

            listvendorname = obj.getdatatable("select top 1 'Add New' as company_name,'0' as contact_no from contact_tbl union select company_name,contact_no from contact_tbl where company_name like '%" + txtCusName.Text + "%'")
            lstbxCusname.DisplayMember = "company_name"
            lstbxCusname.ValueMember = "contact_no"
            lstbxCusname.DataSource = listvendorname

            lstbxCusname.Visible = True
        End If

    End Sub

    Private Sub lstbxCusname_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lstbxCusname.MouseClick
        lstbxCusname.Visible = False
        If lstbxCusname.Text = "Add New" Then
            Contacts.Show()
            Contacts.BringToFront()
            Contacts.Focus()
        Else
            Try
                lstbxCusname.Visible = False
                txtCusName.Text = lstbxCusname.Text
                lblcuscode.Text = lstbxCusname.SelectedValue

            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub lstbxItemName_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lstbxItemName.MouseClick
        lstbxItemName.Visible = False
        If lstbxItemName.Text = "Add New" Then
            Items.Show()
            Items.BringToFront()
            Items.Focus()
        Else
            Try
                txtItmName.Text = lstbxItemName.Text
                Dim itemdata As New List(Of String)
                itemdata = obj.GetMoreValueFromQuery("select cess,igst from item_tbl where item_no='" + lstbxItemName.SelectedValue + "'", 2)
                lblitemcode.Text = lstbxItemName.SelectedValue
                cmbCessPercent.Text = itemdata(0)
                txtTaxpercent.Text = itemdata(1)
                CalculationArea()
            Catch ex As Exception

            End Try
        End If
    End Sub


    Private Sub txtItmName_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtItmName.KeyUp
        lstbxItemName.Visible = True
        Dim listitemname As New DataTable
        lstbxItemName.DataSource = Nothing
        If txtItmName.Text = "" Then
            lstbxItemName.Visible = False
        Else
            listitemname = obj.getdatatable("select top 1 'Add New' as item_name,'0' as item_no from item_tbl union select item_name,item_no from item_tbl where item_name like '%" + txtItmName.Text + "%'")
            ' listitemname = obj.getdatatable("select top 1 'Add New' as item_name,'0' as item_no from item_tbl union select a.item_name& '|' & b.qty,a.item_no from item_tbl a,stock_tbl b where a.item_no=b.item_no and  a.item_name like '%" + txtItemNm.Text + "%'")

            lstbxItemName.DisplayMember = "item_name"
            lstbxItemName.ValueMember = "item_no"
            lstbxItemName.DataSource = listitemname
            lstbxItemName.Visible = True

        End If
    End Sub

    Private Sub txtAdvAmt_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtAdvAmt.KeyUp
        CalculationArea()
    End Sub

    Private Sub txtTaxpercent_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTaxpercent.SelectedIndexChanged
        CalculationArea()
    End Sub

    Private Sub cmbCessPercent_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbCessPercent.SelectedIndexChanged
        CalculationArea()
    End Sub

    Private Sub dtpAdvDt_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpAdvDt.ValueChanged
        Me.txtadvdate.Text = Me.dtpAdvDt.Value.Date.ToString("dd/MM/yyyy")
    End Sub


    Private Sub DateTimePicker1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DateTimePicker1.ValueChanged
        Me.TextBox1.Text = Me.DateTimePicker1.Value.Date.ToString("dd/MM/yyyy")
    End Sub

    Private Sub DateTimePicker2_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DateTimePicker2.ValueChanged
        Me.TextBox2.Text = Me.DateTimePicker2.Value.Date.ToString("dd/MM/yyyy")
    End Sub

    Private Sub txtSearchKeyword_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSearchKeyword.TextChanged
        If txtSearchKeyword.Text = "" Then
            BindGridViewAdvance("")
        Else
            BindGridViewAdvance(txtSearchKeyword.Text)
        End If

    End Sub

    Private Sub BindGridViewAdvance(ByVal p1 As String)
        Try
            gridAdvance.ColumnCount = 5
            gridAdvance.Columns(0).Name = "Customer"
            gridAdvance.Columns(1).Name = "Date"
            gridAdvance.Columns(2).Name = ""
            gridAdvance.Columns(3).Name = "Item"
            gridAdvance.Columns(4).Name = "Amount"
            gridAdvance.Rows.Clear()
            Dim dt1 As New DataTable
            Dim datefrom, dateto As String
            If rbtName.Checked = True Then
                dt1 = obj.getdatatable("select top 50 b.company_name,a.advance_dt,a.advance_no,c.item_name,a.total_amt from advance_tbl a,contact_tbl b,item_tbl c where a.contact_no=b.contact_no and a.item_no=c.item_no and  b.company_name like '%" + p1 + "%' and bill_flg=0")

            ElseIf rbtdate.Checked = True Then
                If Me.TextBox1.Text = "" Or Me.TextBox2.Text = "" Then
                    Exit Sub
                Else
                    datefrom = Format(CDate(Me.TextBox1.Text), "MM/dd/yyyy")
                    dateto = Format(CDate(Me.TextBox2.Text), "MM/dd/yyyy")
                    dt1 = obj.getdatatable("select top 50 b.contact_name,a.advance_dt,a.advance_no,c.item_name,a.total_amt from advance_tbl a,contact_tbl b,item_tbl c where a.contact_no=b.contact_no and a.item_no=c.item_no and  a.advance_dt between #" + datefrom + "# and #" + dateto + "#  and bill_flg=0")

                End If
            End If

            For i = 0 To dt1.Rows.Count - 1
                gridAdvance.Rows.Add(dt1.Rows(i).Item(0).ToString, obj.ConvDtFrmt(dt1.Rows(i).Item(1).ToString, "dd/MM/yyyy"), dt1.Rows(i).Item(2).ToString, dt1.Rows(i).Item(3).ToString, dt1.Rows(i).Item(4).ToString)
            Next
            'gridAddCmp.DataSource = dt1
            Dim btn As New DataGridViewButtonColumn
            btn.Name = "edit"
            btn.HeaderText = ""
            btn.Text = "EDIT"
            btn.UseColumnTextForButtonValue = True
            gridAdvance.Columns.Add(btn)

            Dim btn1 As New DataGridViewButtonColumn
            btn1.Name = "delete"
            btn1.HeaderText = ""
            btn1.Text = "DELETE"
            btn1.UseColumnTextForButtonValue = True
            gridAdvance.Columns.Add(btn1)


            gridAdvance.Refresh()
            gridAdvance.ReadOnly = True
            gridAdvance.AutoGenerateColumns = False
            gridAdvance.AllowUserToAddRows = False
            gridAdvance.DefaultCellStyle.Font = New Font("Arial", 8)
            gridAdvance.ColumnHeadersDefaultCellStyle.Font = New Font("Century Gothic", 9, FontStyle.Bold)
            gridAdvance.Columns(2).Visible = False
            gridAdvance.ClearSelection()
        Catch ex As Exception
            MsgBox(ex.Message, , MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim advance_no, user_advance_no, contact_no, advance_dt, item_no,
             account_id, bill_no, voucher_no, company_id, user_name, payment_method, cheque_no, cheque_dt, credit_bank_name, adv_voucher_no As String
        Dim bill_flg, receipt_flg As Integer
        Dim advance_amt, tax_percent, cess_percent, tax_amt, cess_amt, total_amt As Double

        contact_no = lblcuscode.Text
        advance_dt = Format(CDate(Me.txtadvdate.Text), "dd/MM/yyyy")

        advance_amt = txtAdvAmt.Text
        item_no = lblitemcode.Text
        tax_percent = txtTaxpercent.Text
        cess_percent = cmbCessPercent.Text
        tax_amt = obj.FdPercCalc(advance_amt, tax_percent)
        cess_amt = obj.FdPercCalc(advance_amt, cess_percent)
        total_amt = Me.txtAdvTotal.Text

        account_id = cmbaccname.SelectedValue
        bill_flg = 0
        bill_no = ""
        voucher_no = ""
        receipt_flg = 0
        company_id = SharedData.companyid
        user_name = SharedData.userid

        Dim txt As New List(Of String)
        txt.Add(contact_no)
        txt.Add(advance_dt)
        txt.Add(account_id)
        If obj.TextBoxValidate(txt) = False Then
            MsgBox("All *  Required")
            Exit Sub
        End If
        If obj.validContact(contact_no) = False Then
            MsgBox("ContactName is not Valid!!", MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        payment_method = If(rbtPettycash.Checked = True, "Cash", "Cheque")

        If payment_method = "Cheque" Then
            cheque_no = Me.txtChequeNo.Text
            cheque_dt = Format(CDate(Me.txtChequedt.Text), "dd/MM/yyyy")
            credit_bank_name = advbankid.Text
        Else
            cheque_no = ""
            cheque_dt = "01/01/1900"
            credit_bank_name = ""
        End If

        Dim voucher_user_no, voucher_dt, voucher_type As String
        adv_voucher_no = obj.GetOneValueFromQuery("select voucher_frmt&''&voucher_no from control_tbl where company_id=" + company_id + "")
        voucher_user_no = adv_voucher_no
        voucher_dt = advance_dt
        voucher_type = "WS"
        Dim QueryCollection As New List(Of String)
        advance_no = ""
        Select Case btnSave.Text
            Case Is = "Save"
                advance_no = obj.GetOneValueFromQuery("select advance_frmt&''&advance_no from control_tbl where company_id=" + SharedData.companyid + "")
                user_advance_no = advance_no
                QueryCollection.Add("insert into advance_tbl (advance_no, user_advance_no, contact_no, advance_dt," & _
                          "  advance_amt, item_no, tax_percent, cess_percent, tax_amt, cess_amt," & _
                          " total_amt,  account_id, bill_flg, bill_no, voucher_no, receipt_flg, " & _
                          "company_id, user_name,adv_voucher_no) values('" + advance_no + "','" + user_advance_no + "'," & _
                          "'" + contact_no + "','" + advance_dt + "'," & advance_amt & ",'" + item_no + "'" & _
                          "," & tax_percent & "," & cess_percent & "," & tax_amt & "," & cess_amt & "," & _
                          "" & total_amt & "," + account_id + "," & bill_flg & ",'" + bill_no + "'," & _
                          "'" + voucher_no + "'," & receipt_flg & "," + company_id + ",'" + user_name + "','" + adv_voucher_no + "')")
                QueryCollection.Add("update control_tbl set advance_no=advance_no+1 where company_id=" + company_id + "")
            Case Is = "Update"
                advance_no = lblcode.Text
                BeforeEditAdvance(advance_no)
                QueryCollection.Add("update advance_tbl set contact_no='" + contact_no + "', advance_dt='" + advance_dt + "'," & _
                      "  advance_amt=" & advance_amt & ", item_no='" + item_no + "', " & _
                      "tax_percent=" & tax_percent & ", cess_percent=" & cess_percent & "," & _
                      " tax_amt=" & tax_amt & ", cess_amt=" & cess_amt & "," & _
                      " total_amt=" & total_amt & ",  account_id=" + account_id + ", " & _
                      "company_id=" + company_id + ", user_name='" + user_name + "',adv_voucher_no='" + adv_voucher_no + "' where advance_no='" + advance_no + "'")

                btnSave.Text = "Save"
                lblcode.Text = ""
                lblcuscode.Text = ""
        End Select

        If payment_method = "Cash" Then
            QueryCollection.Add("update bank_tbl set  pettycash_closingBalance=pettycash_closingBalance+" & total_amt & "	where  company_id=" + company_id + "")
        ElseIf payment_method = "Cheque" Then
            QueryCollection.Add("update bank_tbl set  bank_closeBalance=bank_closeBalance+" & total_amt & "	where  ID=" + credit_bank_name + "")
        Else
        End If


      
        QueryCollection.Add("insert into voucher_tbl (voucher_no,voucher_user_no,contact_no	,voucher_dt,voucher_type," & _
                          "	account_id,	vouchercpt_flg,	voucherpaymt_flg,	" & _
                          "payment_type,	credit_debit_bank,	cheque_no,	" & _
                          "cheque_dt,	voucher_amt,	tds_percent,	total_amt,	" & _
                          "notes,	company_id,	user_name) values('" + adv_voucher_no + "','" + voucher_user_no + "','" + contact_no + "'," & _
                          "'" + voucher_dt + "','" + voucher_type + "'," + account_id + "," & _
                          "1,0,'" + payment_method + "','" + credit_bank_name + "','" + cheque_no + "'" & _
                          ",'" + cheque_dt + "'," & total_amt & ",0," & total_amt & "" & _
                          ",''" & _
                          "," + company_id + ",'" + user_name + "'" & _
                          ")")
        QueryCollection.Add("update control_tbl set voucher_no=voucher_no+1 where company_id=" + company_id + "")
        Dim result As Boolean = obj.TransactionInsert(QueryCollection)
        Select Case result
            Case True
                MsgBox("Advance details updated!!", MessageBoxIcon.Information)
                'MsgBox(advance_no)
                S.SetReportAdvanceno(advance_no)
                ReportScreen.Show()
                ReportScreen.BringToFront()

            Case False
                MsgBox("Something Went Wrong!!", MessageBoxIcon.Exclamation)
        End Select

        Me.Advance_Load(e, e)
        obj.ClearTextBox(Me)
        txtAdvAmt.Text = "0.0"
        ReportScreen.BringToFront()
        ReportScreen.Focus()
    End Sub

    Private Sub gridAdvance_CellContentClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridAdvance.CellContentClick
        Try
            If e.ColumnIndex = 5 Then
                Dim Listdata As New List(Of String)
                Listdata = obj.GetMoreValueFromQuery("Select " & _
                        "	contact_no	,advance_dt,	advance_amt	,item_no	," & _
                        "tax_percent,	cess_percent,total_amt,account_id,adv_voucher_no	" & _
                        "	from " & _
                        "advance_tbl where advance_no=" & _
                        "'" + gridAdvance.Rows(e.RowIndex).Cells(2).Value + "'", 9)

                txtCusName.Text = gridAdvance.Rows(e.RowIndex).Cells(0).Value
                txtItmName.Text = gridAdvance.Rows(e.RowIndex).Cells(3).Value
                lblcuscode.Text = Listdata(0)
                txtadvdate.Text = Listdata(1)
                txtAdvAmt.Text = Listdata(2)
                lblitemcode.Text = Listdata(3)
                txtTaxpercent.Text = Listdata(4)
                cmbCessPercent.Text = Listdata(5)
                txtAdvTotal.Text = Listdata(6)

                Me.cmbacctype.Text = obj.GetOneValueFromQuery("select account_type from account_tbl where ID=" + Listdata(7) + "")
                cmbaccname.DataSource = Nothing
                Dim acclist As New DataTable
                acclist = obj.getdatatable("select account_head,ID from account_tbl where account_type='" + cmbacctype.Text + "'")
                cmbaccname.DisplayMember = "account_head"
                cmbaccname.ValueMember = "ID"
                cmbaccname.DataSource = acclist
                Me.cmbaccname.Text = obj.GetOneValueFromQuery("select account_head from account_tbl where ID=" + Listdata(7) + "")

                Dim getdata = obj.GetMoreValueFromQuery("select payment_type,credit_debit_bank,cheque_no,cheque_dt		" & _
                        " from voucher_tbl where voucher_no='" + Listdata(8) + "'", 4)
                Select Case getdata(0)
                    Case Is = "Cash"
                        rbtPettycash.Checked = True
                        pnlBankdtls.Visible = False
                    Case Is = "Cheque"
                        rbtBank.Checked = True
                        pnlBankdtls.Visible = True
                        txtChequeNo.Text = getdata(2)
                        txtChequedt.Text = getdata(3)
                        cmbBankname.Text = obj.GetOneValueFromQuery("select bank_name & ' - ' & acc_no from bank_tbl where ID=" + getdata(1))
                        advbankid.Text = getdata(1)
                End Select
                btnSave.Text = "Update"
                lblcode.Text = gridAdvance.Rows(e.RowIndex).Cells(2).Value
                ' BeforeEditAdvance(Listdata(8), gridAdvance.Rows(e.RowIndex).Cells(2).Value)
            End If
            If e.ColumnIndex = 6 Then
                Dim result As Integer = MessageBox.Show("Are you sure want to Delete??", "Caution !!!", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning)
                If result = DialogResult.Cancel Then

                ElseIf result = DialogResult.No Then

                ElseIf result = DialogResult.Yes Then
                    BeforeEditAdvance(gridAdvance.Rows(e.RowIndex).Cells(2).Value)
                    obj.QueryExecution("delete from advance_tbl where advance_no='" + gridAdvance.Rows(e.RowIndex).Cells(2).Value + "'")
                End If
                Me.Controls.Clear()
                InitializeComponent()
                Advance_Load(e, e)
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MessageBoxIcon.Exclamation)
        End Try
    End Sub
    Private Function BeforeEditAdvance(ByVal advno As String) As Boolean
        Dim InitialTransaction, getdata As New List(Of String)
        Dim dtsupdt, dtbank As New DataTable
        Dim vouno As String = obj.GetOneValueFromQuery("select adv_voucher_no from advance_tbl where advance_no='" + advno + "'")
        getdata = obj.GetMoreValueFromQuery("select payment_type,	credit_debit_bank,		" & _
                          "total_amt from voucher_tbl where voucher_no='" + vouno + "'", 3)

        If getdata(0) = "Cash" Then
            InitialTransaction.Add("update bank_tbl set  pettycash_closingBalance=pettycash_closingBalance-" & getdata(2) & "	where  company_id=" + SharedData.companyid + "")
        ElseIf getdata(0) = "Cheque" Then
            InitialTransaction.Add("update bank_tbl set  bank_closeBalance=bank_closeBalance-" & getdata(2) & " where  ID=" + getdata(1) + "")
        End If
        InitialTransaction.Add("delete from voucher_tbl where voucher_no='" + vouno + "'")
        Dim result As Boolean = obj.TransactionInsert(InitialTransaction)
        Return result

    End Function
    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        Me.Controls.Clear()
        InitializeComponent()
        Advance_Load(e, e)

    End Sub

   
    Private Sub rbtBank_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtBank.CheckedChanged
        Select Case rbtBank.Checked
            Case True
                pnlBankdtls.Visible = True
                Dim listbank As New DataTable
                cmbBankname.DataSource = Nothing
                cmbBankname.Items.Clear()
                listbank = obj.getdatatable("select bank_name & ' - ' & acc_no as bankdtls,ID from bank_tbl where company_id =" + SharedData.companyid + "")
                cmbBankname.DisplayMember = "bankdtls"
                cmbBankname.ValueMember = "ID"
                cmbBankname.DataSource = listbank
            Case False
                pnlBankdtls.Visible = False
        End Select
    End Sub

  

   
    Private Sub cmbBankname_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbBankname.SelectedIndexChanged
        advbankid.Text = cmbBankname.SelectedValue
    End Sub

    Private Sub DtpChequedt_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DtpChequedt.ValueChanged
        obj.dtpick(txtChequedt, DtpChequedt)
    End Sub
End Class