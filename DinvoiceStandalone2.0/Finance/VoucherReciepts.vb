Public Class VoucherReciepts

    Dim obj As New ObjClass
    Private Sub VoucherReciepts_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        MaximizeBox = False
        MinimizeBox = False
        'pnlBills.Visible = False
        lstClientName.Visible = False
        pnlCheque.Visible = False
        pnlrecievebank.Visible = False
        Panel5.Visible = False
        txtClientName.Focus()
        obj.TodayDate(txtDate)
       Dim acctype As New List(Of String)
        acctype = obj.getcolumndatafromquery("select distinct account_type from account_tbl")
        For i = 0 To acctype.Count - 1
            cmbAcctype.Items.Add(acctype(i))
        Next
        BindGridViewVoucher("")
        txtVouNo.Text = obj.GetOneValueFromQuery("select voucher_frmt&''&voucher_no from control_tbl where company_id=" + SharedData.companyid + "")

    End Sub
    Private Sub cmbAcctype_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbAcctype.SelectedIndexChanged
        cmbAccName.DataSource = Nothing
        Dim acclist As New DataTable
        acclist = obj.getdatatable("select account_head,ID from account_tbl where account_type='" + cmbAcctype.Text + "'")
        cmbAccName.DisplayMember = "account_head"
        cmbAccName.ValueMember = "ID"
        cmbAccName.DataSource = acclist
    End Sub
    Private Sub cmbPayType_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbPayType.SelectedIndexChanged
        Select Case cmbPayType.Text
            Case Is = "Cash"

                pnlrecievebank.Visible = False
                pnlCheque.Visible = False
            Case Is = "Cheque"
                pnlrecievebank.Visible = True
                pnlCheque.Visible = True
                ' pnlCheque.BackColor = Color.Aqua
                
                Dim listbank As New DataTable

                CmbCompanyBank.DataSource = Nothing
                CmbCompanyBank.Items.Clear()
                listbank = obj.getdatatable("select bank_name & ' - ' & acc_no as bankdtls,ID from bank_tbl where company_id =" + SharedData.companyid + "")
                CmbCompanyBank.DisplayMember = "bankdtls"
                CmbCompanyBank.ValueMember = "ID"
                CmbCompanyBank.DataSource = listbank
        End Select
    End Sub

    Private Sub rbtBill2Bill_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtBill2Bill.CheckedChanged
        Select Case rbtBill2Bill.Checked
            Case True
                pnlBills.Visible = True
            Case False
                pnlBills.Visible = False
        End Select
    End Sub

    Private Sub rbtDate_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtDate.CheckedChanged, rdnvouno.CheckedChanged
        Select Case rbtDate.Checked
            Case True
                Panel5.Visible = True
            Case False
                Panel5.Visible = False
        End Select


    End Sub

    'Private Sub lstClientName_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lstClientName.MouseClick
    '    lstClientName.Visible = False
    'End Sub

    Private Sub txtClientName_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtClientName.KeyPress
        lstClientName.Visible = True
        lstClientName.BringToFront()

    End Sub
    '-----------------------------------------
    Private Sub btnList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnList.Click
        Dim dtnew, dtinv, dtsup As New DataTable
        dtnew.Columns.Add("Check", GetType(Boolean))
        dtnew.Columns.Add("InvoiceNo", GetType(String))
        dtnew.Columns.Add("ContactName", GetType(String))
        dtnew.Columns.Add("Date", GetType(String))
        dtnew.Columns.Add("contact_no", GetType(String))
        dtnew.Columns.Add("invoice_no", GetType(String))
        dtnew.Columns.Add("type", GetType(String))
        dtnew.Columns.Add("SubTotal", GetType(String))
        dtnew.Columns.Add("GrandAmt", GetType(String))

        dtinv = obj.getdatatable("select a.user_invoice_no,b.company_name,a.invoice_dt,a.contact_no," & _
                                 "a.invoice_no,'INVOICE',a.sub_total,a.grand_total from invoice_hdr a ,contact_tbl b where a.contact_no=b.contact_no" & _
                                 " and a.payment_status=0 and a.contact_no='" + lblcuscode.Text + "' and " & _
                                 "a.invoice_dt between #" + Format(CDate(Me.txtFromDt.Text), "MM/dd/yyyy") + "# " & _
                                 "and #" + Format(CDate(Me.txtToDt.Text), "MM/dd/yyyy") + "#")
        For i = 0 To dtinv.Rows.Count - 1
            dtnew.Rows.Add(False, dtinv.Rows(i).Item(0).ToString, dtinv.Rows(i).Item(1).ToString,
                           dtinv.Rows(i).Item(2).ToString, dtinv.Rows(i).Item(3).ToString,
                           dtinv.Rows(i).Item(4).ToString, dtinv.Rows(i).Item(5).ToString,
                           dtinv.Rows(i).Item(6).ToString, dtinv.Rows(i).Item(7).ToString)
        Next
        dtsup = obj.getdatatable("select a.user_supply_no,b.company_name,a.supply_dt,a.contact_no," & _
                                "a.supply_no,'SUPPLY',a.sub_total,a.grand_total from supply_hdr a ,contact_tbl b where a.contact_no=b.contact_no" & _
                                " and a.payment_status=0 and a.contact_no='" + lblcuscode.Text + "' and " & _
                                "a.supply_dt between #" + Format(CDate(Me.txtFromDt.Text), "MM/dd/yyyy") + "# " & _
                                "and #" + Format(CDate(Me.txtToDt.Text), "MM/dd/yyyy") + "#")
        For i = 0 To dtsup.Rows.Count - 1
            dtnew.Rows.Add(False, dtsup.Rows(i).Item(0).ToString, dtsup.Rows(i).Item(1).ToString,
                           dtsup.Rows(i).Item(2).ToString, dtsup.Rows(i).Item(3).ToString,
                           dtsup.Rows(i).Item(4).ToString, dtsup.Rows(i).Item(5).ToString,
                           dtsup.Rows(i).Item(6).ToString, dtsup.Rows(i).Item(7).ToString)
        Next
        gridBills.DataSource = dtnew
        gridBills.AutoGenerateColumns = False
        gridBills.AllowUserToAddRows = False
        gridBills.Columns(1).ReadOnly = True
        gridBills.Columns(2).Visible = False
        gridBills.Columns(3).ReadOnly = True
        gridBills.Columns(4).Visible = False
        gridBills.Columns(5).Visible = False
        gridBills.Columns(6).Visible = False

    End Sub
    Private Sub gridBills_CellContentClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridBills.CellContentClick
        If e.ColumnIndex = 0 Then
            Me.txtClientName.Text = gridBills.Rows(e.RowIndex).Cells(2).Value.ToString
            Me.lblcuscode.Text = gridBills.Rows(e.RowIndex).Cells(4).Value.ToString

            Me.txtDate.Text = obj.ConvDtFrmt(gridBills.Rows(e.RowIndex).Cells(3).Value.ToString, "dd/MM/yyyy")
            gridBills.CommitEdit(DataGridViewDataErrorContexts.Commit)
            CalculationArea()
        End If
    End Sub
    Sub CalculationArea()
        If rbtBill2Bill.Checked = True Then
            Dim subtotal, grandtotal As Double
            subtotal = 0
            grandtotal = 0
            Dim invoicenolist, supplynolist As New List(Of String)
            For i = 0 To gridBills.Rows.Count - 1
                If Convert.ToBoolean(gridBills.Rows(i).Cells(0).Value.ToString) = True Then
                    If gridBills.Rows(i).Cells(6).Value.ToString() = "INVOICE" Then
                        invoicenolist.Add(gridBills.Rows(i).Cells(5).Value.ToString())
                    End If
                    If gridBills.Rows(i).Cells(6).Value.ToString() = "SUPPLY" Then
                        supplynolist.Add(gridBills.Rows(i).Cells(5).Value.ToString())
                    End If

                End If
            Next
            Dim getdata As New List(Of String)
            For i = 0 To invoicenolist.Count - 1
                getdata = obj.GetMoreValueFromQuery("select sub_total,grand_total from invoice_hdr where invoice_no='" + invoicenolist(i) + "'", 2)
                subtotal = subtotal + CDbl(getdata(0))
                grandtotal = grandtotal + CDbl(getdata(1))
            Next
            For i = 0 To supplynolist.Count - 1
                getdata = obj.GetMoreValueFromQuery("select sub_total,grand_total from supply_hdr where supply_no='" + supplynolist(i) + "'", 2)
                subtotal = subtotal + CDbl(getdata(0))
                grandtotal = grandtotal + CDbl(getdata(1))
            Next
            txtAmount.Text = grandtotal
        End If
        If rbtWholesum.Checked = True Then

            Dim grandtotal As Double
            Try
                grandtotal = txtAmount.Text
            Catch ex As Exception
                Exit Sub

            End Try
            txtAmount.Text = grandtotal
        End If
    End Sub
  

    Private Sub lstClientName_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lstClientName.MouseClick
        lstClientName.Visible = False
        If lstClientName.Text = "Add New" Then
            Contacts.Show()
            Contacts.BringToFront()
            Contacts.Focus()
        Else
            Try
                lstClientName.Visible = False
                txtClientName.Text = lstClientName.Text
                lblcuscode.Text = lstClientName.SelectedValue
            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub txtClientName_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtClientName.KeyUp
        lblcuscode.Text = ""
        lstClientName.Visible = True
        lstClientName.BringToFront()
        Dim listclientname As New DataTable
        lstClientName.DataSource = Nothing
        If txtClientName.Text = "" Then
            lstClientName.Visible = False
        Else
            listclientname = obj.getdatatable("select company_name,contact_no from contact_tbl where company_name like '%" + txtClientName.Text + "%'")
            lstClientName.DisplayMember = "company_name"
            lstClientName.ValueMember = "contact_no"
            lstClientName.DataSource = listclientname
            lstClientName.Visible = True
        End If
    End Sub

    Private Sub dtpDate_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpDate.ValueChanged
        Me.txtDate.Text = Me.dtpDate.Value.Date.ToString("dd/MM/yyyy")
    End Sub

    Private Sub dtpChequeDt_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpChequeDt.ValueChanged
        Me.txtChequeDt.Text = Me.dtpChequeDt.Value.Date.ToString("dd/MM/yyyy")
    End Sub

    Private Sub dtpFromdt_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpFromdt.ValueChanged
        Me.txtFromDt.Text = Me.dtpFromdt.Value.Date.ToString("dd/MM/yyyy")
    End Sub

    Private Sub dtpTodt_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpTodt.ValueChanged
        Me.txtToDt.Text = Me.dtpTodt.Value.Date.ToString("dd/MM/yyyy")
    End Sub
    Sub BindGridViewVoucher(ByVal s As String)
        Try
            gridVoucher.ColumnCount = 6
            gridVoucher.Columns(0).Name = "Vch No"
            gridVoucher.Columns(1).Name = "Contact Name"
            gridVoucher.Columns(2).Name = "Vch Dt"
            gridVoucher.Columns(3).Name = "Vch Amt"
            gridVoucher.Columns(4).Name = ""
            gridVoucher.Columns(5).Name = ""


            gridVoucher.Rows.Clear()
            Dim dt1 As New DataTable
            Dim datefrom, dateto As String

            If rbtName.Checked = True Then
                dt1 = obj.getdatatable("select top 50 a.voucher_user_no, b.company_name," & _
                                       "a.voucher_dt,a.voucher_amt,a.voucher_no,a.contact_no " & _
                                       "from voucher_tbl a,contact_tbl b where a.contact_no=b.contact_no" & _
                                       " and a.vouchercpt_flg=1  and  b.company_name like '%" + s + "%'")

            ElseIf rbtDate.Checked = True Then
                If Me.txtSearchfromdt.Text = "" Or Me.txtSearchtodt.Text = "" Then
                    Exit Sub
                Else
                    datefrom = Format(CDate(Me.txtSearchfromdt.Text), "MM/dd/yyyy")
                    dateto = Format(CDate(Me.txtSearchtodt.Text), "MM/dd/yyyy")
                    dt1 = obj.getdatatable("select top 50 a.voucher_user_no, b.company_name,a.voucher_dt," & _
                                       "a.voucher_amt,a.voucher_no,a.contact_no from voucher_tbl a,contact_tbl b" & _
                                       " where a.contact_no=b.contact_no and a.vouchercpt_flg=1 and  " & _
                                       "a.voucher_dt between #" + datefrom + "# and #" + dateto + "#")

                End If
            ElseIf rdnvouno.Checked = True Then
                dt1 = obj.getdatatable("select top 50 a.voucher_user_no, b.company_name," & _
                                     "a.voucher_dt,a.voucher_amt,a.voucher_no,a.contact_no " & _
                                     "from voucher_tbl a,contact_tbl b where a.contact_no=b.contact_no" & _
                                     " and a.vouchercpt_flg=1  and  b.voucher_user_no like '%" + s + "%'")
            End If

            For i = 0 To dt1.Rows.Count - 1
                gridVoucher.Rows.Add(dt1.Rows(i).Item(0).ToString, dt1.Rows(i).Item(1).ToString, obj.ConvDtFrmt(dt1.Rows(i).Item(2).ToString, "dd/MM/yyyy"), dt1.Rows(i).Item(3).ToString, dt1.Rows(i).Item(4).ToString, dt1.Rows(i).Item(5).ToString)
            Next


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
            gridVoucher.Columns(5).Visible = False
            gridVoucher.ClearSelection()



        Catch ex As Exception
            MsgBox(ex.Message, , MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try
            Dim voucher_no, voucher_user_no, voucher_dt, voucher_type, account_id,
                 payment_type, credit_debit_bank, cheque_no,
                cheque_dt, voucher_amt, total_amt, cash_paid, contact_no, notes, company_id, user_name As String

            voucher_no = obj.GetOneValueFromQuery("select voucher_frmt&''&voucher_no from control_tbl where company_id=" + SharedData.companyid + "")
            voucher_user_no = voucher_no
            contact_no = lblcuscode.Text
            voucher_dt = Format(CDate(Me.txtDate.Text), "dd/MM/yyyy")
            voucher_type = ""
            If rbtBill2Bill.Checked = True Then
                voucher_type = "B2B"
            ElseIf rbtWholesum.Checked = True Then
                voucher_type = "WS"
            End If
            account_id = cmbAccName.SelectedValue
            payment_type = cmbPayType.Text
            If payment_type = "Cheque" Then
                cheque_no = Me.txtChequeNo.Text
                cheque_dt = Format(CDate(Me.txtChequeDt.Text), "dd/MM/yyyy")
                credit_debit_bank = Me.CmbCompanyBank.SelectedValue
                cash_paid = 0
            Else
                cheque_no = ""
                cheque_dt = "01/01/1900"
                credit_debit_bank = ""
                cash_paid = txtAmount.Text
            End If
            total_amt = txtAmount.Text
            voucher_amt = txtAmount.Text
            company_id = SharedData.companyid
            user_name = SharedData.userid
            notes = txtNotes.Text

            Dim txt As New List(Of String)
            txt.Add(contact_no)
            txt.Add(voucher_user_no)
            txt.Add(voucher_dt)
            txt.Add(account_id)
            txt.Add(payment_type)

            If obj.TextBoxValidate(txt) = False Then
                MsgBox("All * value  Required", MsgBoxStyle.Exclamation)
                Exit Sub
            End If
            If obj.validContact(contact_no) = False Then
                MsgBox("ContactName is not Valid!!", MsgBoxStyle.Exclamation)
                Exit Sub
            End If
            Dim checkcount As Integer = 0
            If voucher_type = "B2B" Then
                For i = 0 To gridBills.Rows.Count - 1
                    If Convert.ToBoolean(gridBills.Rows(i).Cells(0).Value.ToString) = True Then
                        checkcount = checkcount + 1
                    End If
                Next
                If checkcount = 0 Then
                    MsgBox("Select Invoice No!!!", MsgBoxStyle.Exclamation)
                    Exit Sub
                End If
            End If


            Dim QueryCollection As New List(Of String)
            QueryCollection.Add("insert into voucher_tbl (voucher_no,voucher_user_no,contact_no	,voucher_dt,voucher_type," & _
                                "	account_id,	vouchercpt_flg,	voucherpaymt_flg,	" & _
                                "payment_type,	credit_debit_bank,	cheque_no,	" & _
                                "cheque_dt,	voucher_amt,	tds_percent,	total_amt,	" & _
                                "notes,	company_id,	user_name,cash_paid) values('" + voucher_no + "','" + voucher_user_no + "','" + contact_no + "'," & _
                                "'" + voucher_dt + "','" + voucher_type + "','" + account_id + "'," & _
                                "1,0,'" + payment_type + "','" + credit_debit_bank + "','" + cheque_no + "'" & _
                                ",'" + cheque_dt + "'," & voucher_amt & ",0," & total_amt & "" & _
                                ",'" + obj.inapos(notes) + "'" & _
                                "," + company_id + ",'" + user_name + "'," + cash_paid + "" & _
                                ")")

            If voucher_type = "B2B" Then

                For i = 0 To gridBills.Rows.Count - 1
                    If Convert.ToBoolean(gridBills.Rows(i).Cells(0).Value.ToString) = True Then
                        If gridBills.Rows(i).Cells(6).Value.ToString() = "INVOICE" Then
                            QueryCollection.Add("update invoice_hdr set " & _
                                      "payment_status=1,	payment_method='" + payment_type + "',	" & _
                                      "cheque_no='" + cheque_no + "',	cheque_dt='" + cheque_dt + "',	" & _
                                      "credit_bank_name='" + credit_debit_bank + "',	credit_days=0, " & _
                                      " cash_recieved=" & cash_paid & ",voucher_no='" + voucher_no + "'," & _
                                      "voucher_flg=1 where invoice_no='" + gridBills.Rows(i).Cells(5).Value.ToString() + "'")
                        End If
                        If gridBills.Rows(i).Cells(6).Value.ToString() = "SUPPLY" Then
                            QueryCollection.Add("update supply_hdr set " & _
                                      "payment_status=1,	payment_method='" + payment_type + "',	" & _
                                      "cheque_no='" + cheque_no + "',	cheque_dt='" + cheque_dt + "',	" & _
                                      "credit_bank_name='" + credit_debit_bank + "',	credit_days=0, " & _
                                      " cash_paid=" & cash_paid & ",voucher_no='" + voucher_no + "'," & _
                                      "voucher_flg=1 where supply_no='" + gridBills.Rows(i).Cells(5).Value.ToString() + "'")
                        End If
                    End If
                Next
              
            End If


            If payment_type = "Cash" Then
                QueryCollection.Add("update bank_tbl set  pettycash_closingBalance=pettycash_closingBalance+" & cash_paid & "	where  company_id=" + company_id + "")
            ElseIf payment_type = "Cheque" Then
                QueryCollection.Add("update bank_tbl set  bank_closeBalance=bank_closeBalance+" & voucher_amt & "	where  ID=" + credit_debit_bank + "")
            Else
            End If
            QueryCollection.Add("update control_tbl set voucher_no=voucher_no+1 where company_id=" + company_id + "")
            Dim result As Boolean = obj.TransactionInsert(QueryCollection)
            Select Case result
                Case True
                    MsgBox("Voucher details updated!!", MessageBoxIcon.Information)
                    s.SetReportVoucherno(voucher_no, "Sale", voucher_type)
                    ReportScreen.Show()
                Case False
                    MsgBox("Something Went Wrong!!", MessageBoxIcon.Exclamation)
                    Exit Sub
            End Select
            Me.Controls.Clear()
            InitializeComponent()
            Me.VoucherReciepts_Load(e, e)

        Catch ex As Exception
            MsgBox("Exception:Caution!!  " + ex.Message + "", MessageBoxIcon.Exclamation)
            Exit Sub
        End Try
        ReportScreen.BringToFront()
        ReportScreen.Focus()
    End Sub
    Dim s As New SharedData
    Private Sub txtAmount_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtAmount.KeyPress
        obj.OnlyNoS(e)
    End Sub
    Private Sub txtAmount_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtAmount.KeyUp
        CalculationArea()
    End Sub

    Private Sub dtpSearchfromdt_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpSearchfromdt.ValueChanged
        Me.txtSearchfromdt.Text = Me.dtpSearchfromdt.Value.Date.ToString("dd/MM/yyyy")
    End Sub

    Private Sub dtpSearchtodt_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpSearchtodt.ValueChanged
        Me.txtSearchtodt.Text = Me.dtpSearchtodt.Value.Date.ToString("dd/MM/yyyy")
    End Sub

    Private Sub txtSearchKeyword_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSearchKeyword.TextChanged
        If txtSearchKeyword.Text = "" Then
            BindGridViewVoucher("")
        Else
            BindGridViewVoucher(txtSearchKeyword.Text)
        End If
    End Sub

    Private Sub gridVoucher_CellContentClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridVoucher.CellContentClick
        'ID	voucher_no	voucher_user_no	voucher_dt	voucher_type	account_id	vouchercpt_flg	voucherpaymt_flg	payment_type	credit_debit_bank	cheque_no	cheque_dt	voucher_amt	tds_percent	total_amt	notes	company_id	user_name	timestamp
        Try
            If e.ColumnIndex = 6 Then
                Dim result As Integer = MessageBox.Show("Are you sure want to Delete??", "Caution !!!", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning)
                If result = DialogResult.Cancel Then

                ElseIf result = DialogResult.No Then

                ElseIf result = DialogResult.Yes Then
                    Dim getdata, QueryCollection, invnolist, supplynolist As New List(Of String)
                    getdata = obj.GetMoreValueFromQuery("select voucher_type,payment_type ,voucher_amt,credit_debit_bank,cash_paid from voucher_tbl where voucher_no='" + gridVoucher.Rows(e.RowIndex).Cells(4).Value + "'", 5)

                    Dim type As String = obj.GetOneValueFromQuery("select payment_type from voucher_tbl where voucher_no='" + gridVoucher.Rows(e.RowIndex).Cells(4).Value + "'")

                    If getdata(0) = "B2B" Then
                        invnolist = obj.getcolumndatafromquery("select invoice_no from invoice_hdr where voucher_no='" + gridVoucher.Rows(e.RowIndex).Cells(4).Value + "'")
                        For i = 0 To invnolist.Count - 1
                            QueryCollection.Add("update invoice_hdr set " & _
                                                     "payment_status=0,	payment_method='',	cheque_no='',cheque_dt='01/01/1900'," & _
                                                     "credit_bank_name='',	credit_days=0,  cash_recieved=0,voucher_no='',voucher_flg=0 where invoice_no='" + invnolist(i) + "'")

                        Next
                        supplynolist = obj.getcolumndatafromquery("select supply_no from supply_hdr where voucher_no='" + gridVoucher.Rows(e.RowIndex).Cells(4).Value + "'")
                        For i = 0 To supplynolist.Count - 1
                            QueryCollection.Add("update supply_hdr set " & _
                                                     "payment_status=0,	payment_method='',	cheque_no='',cheque_dt='01/01/1900'," & _
                                                     "credit_bank_name='',	credit_days=0,  cash_paid=0,voucher_no='',voucher_flg=0 where supply_no='" + supplynolist(i) + "'")

                        Next
                    End If
                    If getdata(1) = "Cash" Then
                        QueryCollection.Add("update bank_tbl set  pettycash_closingBalance=pettycash_closingBalance-" & getdata(4) & "	where  company_id=" + SharedData.companyid + "")
                    ElseIf getdata(1) = "Cheque" Then
                        QueryCollection.Add("update bank_tbl set  bank_closeBalance=bank_closeBalance-" & getdata(2) & " where  ID=" + getdata(3) + "")
                    Else
                    End If
                    Dim result1 As Boolean = obj.TransactionInsert(QueryCollection)
                    Select Case result1
                        Case True
                            MsgBox("Voucher details Deleted!!", MessageBoxIcon.Information)
                        Case False
                            MsgBox("Something Went Wrong!!", MessageBoxIcon.Exclamation)
                            Exit Sub
                    End Select
                    obj.QueryExecution("delete from voucher_tbl where voucher_no='" + gridVoucher.Rows(e.RowIndex).Cells(4).Value + "'")
                    'obj.QueryExecution("delete from indent_dtl where indent_no='" + GridItem.Rows(e.RowIndex).Cells(2).Value + "'")
                End If
                BindGridViewVoucher("")
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MessageBoxIcon.Exclamation)
        End Try
    End Sub
   
End Class