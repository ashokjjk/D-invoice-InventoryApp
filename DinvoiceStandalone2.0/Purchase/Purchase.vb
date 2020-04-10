Public Class Purchase
    Dim obj As New ObjClass
    Dim S As New SharedData
    Dim itemdatatable As New DataTable
    Private Sub Purchase_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtVendorName.Focus()
        If obj.GetCountPurchase = False Then
            MsgBox("You cant create another Purchase, Buy premium version")
            Me.Close()
            Exit Sub
        End If
        If S.GetPurchaseno() <> "" Then
            EditFunction()
        Else
            OnloadFunction()
        End If

    End Sub
    Private Sub EditFunction()
        MaximizeBox = False
        MinimizeBox = False
        txtPurchaseNo.Focus()
        cmbUom.Items.Clear()
        cmbItemTax.Items.Clear()
        cmbaccname.Items.Clear()
        Dim uomlist, taxdesc, acclist As New List(Of String)
        uomlist = obj.getcolumndatafromquery("select unit_desc from uom_tbl")
        taxdesc = obj.getcolumndatafromquery("select distinct gst_rate from gst_tbl")
        acclist = obj.getcolumndatafromquery("select account_head from account_tbl where account_type='Expense'")
        For i = 0 To uomlist.Count - 1
            cmbUom.Items.Add(uomlist(i))
        Next
        For i = 0 To taxdesc.Count - 1
            cmbItemTax.Items.Add(taxdesc(i))
        Next
        For i = 0 To acclist.Count - 1
            cmbaccname.Items.Add(acclist(i))
        Next
        Try
            itemdatatable.Columns.Add("Item Name".ToString())
            itemdatatable.Columns.Add("Item No".ToString())
            itemdatatable.Columns.Add("Desc".ToString())
            itemdatatable.Columns.Add("Qty".ToString())
            itemdatatable.Columns.Add("UOM".ToString())
            itemdatatable.Columns.Add("Rate".ToString())
            itemdatatable.Columns.Add("Disc".ToString())
            itemdatatable.Columns.Add("Value".ToString())
            itemdatatable.Columns.Add("Tax".ToString())
            itemdatatable.Columns.Add("Cess".ToString())
        Catch ex As Exception

        End Try
        GridPurchaseData.ColumnHeadersDefaultCellStyle.Font = New Font("Century Gothic", 7, FontStyle.Bold)

        Dim dtpuritems As New DataTable

        dtpuritems = obj.getdatatable("select item_no, item_desc, item_qty, item_uom, item_rate, item_disc, item_amount, item_tax, item_cess from purchase_dtl where purchase_no='" + S.GetPurchaseno + "'")
        Dim itemname As String
        For i = 0 To dtpuritems.Rows.Count - 1
            itemname = obj.GetOneValueFromQuery("select item_name from item_tbl where item_no='" + dtpuritems.Rows(i).Item(0).ToString + "'")
            itemdatatable.Rows.Add(itemname, dtpuritems.Rows(i).Item(0).ToString, dtpuritems.Rows(i).Item(1).ToString,
                                   dtpuritems.Rows(i).Item(2).ToString, dtpuritems.Rows(i).Item(3).ToString,
                                   dtpuritems.Rows(i).Item(4).ToString, dtpuritems.Rows(i).Item(5).ToString,
                                   dtpuritems.Rows(i).Item(6).ToString, dtpuritems.Rows(i).Item(7).ToString,
                                   dtpuritems.Rows(i).Item(8).ToString)
        Next

        GridPurchaseData.DataSource = itemdatatable
        If GridPurchaseData.Columns.Count = 12 Then
        Else
            Dim btn As New DataGridViewButtonColumn
            btn.Name = "edit"
            btn.HeaderText = ""
            btn.Text = "EDIT"
            btn.UseColumnTextForButtonValue = True
            GridPurchaseData.Columns.Add(btn)

            Dim btn1 As New DataGridViewButtonColumn
            btn1.Name = "delete"
            btn1.HeaderText = ""
            btn1.Text = "DELETE"
            btn1.UseColumnTextForButtonValue = True
            GridPurchaseData.Columns.Add(btn1)
        End If
        GridPurchaseData.AutoGenerateColumns = False
        GridPurchaseData.AllowUserToAddRows = False
        GridPurchaseData.Columns(1).Visible = False
        txtDesc.Text = ""
        txtQty.Text = ""
        cmbUom.Refresh()
        Me.txtRate.Text = "0"
        Me.txtItmDisc.Text = "0"
        txtItemNm.Text = ""
        Me.cmbItemTax.Text = "0"
        Me.txtItmCess.Text = "0"
        lblstock.Text = "0"


        Dim GrandAmt As Double
        Dim totamt, discpercent, taxpercent, cesspercent, totamtwithdisc As Double

        GrandAmt = 0

        For i = 0 To GridPurchaseData.Rows.Count - 1
            totamt = CDbl(GridPurchaseData.Rows(i).Cells(7).Value.ToString())
            discpercent = CDbl(GridPurchaseData.Rows(i).Cells(6).Value.ToString())
            taxpercent = CDbl(GridPurchaseData.Rows(i).Cells(8).Value.ToString())
            cesspercent = CDbl(GridPurchaseData.Rows(i).Cells(9).Value.ToString())
            totamtwithdisc = (totamt) ' - obj.FdPercCalc(totamt, discpercent))

            GrandAmt = GrandAmt + totamtwithdisc + obj.FdPercCalc(totamtwithdisc, taxpercent) +
                obj.FdPercCalc(totamtwithdisc, cesspercent)
        Next
        lbloriamt.Text = GrandAmt

        Dim getdata As New List(Of String)
        
        getdata = obj.GetMoreValueFromQuery("select user_purchase_no, contact_no, ref_no, " & _
                                            "purchase_dt, account_id, reverse_flg, overall_disc_flg, " & _
                                            "overall_disc_percent, overall_disc_amt, shpcost_flg, " & _
                                            "shpcost_amt, roundoff_flg, roundoff_amt, payment_status, " & _
                                            "payment_method, cheque_no, cheque_dt, bank_name, credit_days," & _
                                            " vendor_notes, internal_notes, sub_total, total_tax, total_cess, " & _
                                            "grand_total, cash_paid from purchase_hdr where" & _
                                            " purchase_no='" + S.GetPurchaseno + "'", 26)


        Me.txtPurchaseNo.Text = getdata(0)
        Dim subgetdata1 As New List(Of String)
        subgetdata1 = obj.GetMoreValueFromQuery("select company_name,billing_address from contact_tbl where contact_no='" + getdata(1) + "'", 2)

        Me.txtVendorName.Text = subgetdata1(0)
        Me.txtVendorAddress.Text = subgetdata1(1)
        Me.lblcuscode.text = getdata(1)
        Me.txtRefno.Text = getdata(2)
        Me.txtPurDt.Text = getdata(3)
        Me.cmbaccname.Text = getdata(4)
        If getdata(5) = "1" Then
            chkRvrsChrg.Checked = True
        Else
            chkRvrsChrg.Checked = False
        End If
        If getdata(6) = "1" Then
            chkOvralDisc.Checked = True
            Me.txtOvralDisc.Text = getdata(7)
            Me.txtOvralDisc.Visible = True

        Else
            chkOvralDisc.Checked = False
            Me.txtOvralDisc.Visible = False
        End If
        If getdata(9) = "1" Then
            chkShpCost.Checked = True
            Me.txtShpCost.Text = getdata(10)
            Me.txtShpCost.Visible = True

        Else
            chkShpCost.Checked = False
            Me.txtShpCost.Visible = False
        End If

        If getdata(11) = "1" Then
            chkRndOff.Checked = True
            Me.txtRndof.Text = getdata(12)
            Me.txtRndof.Visible = True

        Else
            chkRndOff.Checked = False
            Me.txtRndof.Visible = False
        End If
        If getdata(13) = "1" Then
            rbtPaid.Checked = True
            Me.cmbPaymode.Text = getdata(0)
            Label28.Visible = True
            Label38.Visible = True
            cmbPaymode.Visible = True
            pnlCreditDays.Visible = False

            If getdata(14) = "Cash" Then
                pnlCashRcvd.Visible = True
                pnlBankdtls.Visible = False
                pnlCreditDays.Visible = False
                Me.txtCashRcvd.Text = getdata(25)
            Else
                pnlBankdtls.Visible = True
                pnlCreditDays.Visible = False
                Me.txtChqno.Text = getdata(15)
                Me.txtChqdt.Text = Format(CDate(getdata(16)), "dd/MM/yyyy")
                Me.cmbBankname.Text = getdata(17)
            End If
        Else
            RbtUnpaid.Checked = True
            Label28.Visible = False
            Label38.Visible = False
            cmbPaymode.Visible = False
            pnlCreditDays.Visible = True
            txtCrdtDays.Text = getdata(18)

        End If


        pnlBankdtls.Visible = False
        pnlCreditDays.Visible = False
        pnlCashRcvd.Visible = False
       


        Me.txtVendorNotes.Text = getdata(19)
        Me.txtInternalNotes.Text = getdata(20)






        lblSubTotal.Text = getdata(21)
        lblTotax.Text = getdata(22)
        lblTotCess.Text = getdata(23)
        lblGrantTot.Text = getdata(24)






        lstbxItemName.Visible = False
        lstbxVendorNm.Visible = False
    End Sub
    Private Sub OnloadFunction()
        MaximizeBox = False
        MinimizeBox = False
        txtVendorName.Focus()
        Select Case chkRndOff.Checked
            Case True
                txtRndof.Visible = True
            Case False
                txtRndof.Visible = False
        End Select
        Select Case chkShpCost.Checked
            Case True
                txtShpCost.Visible = True
            Case False
                txtShpCost.Visible = False
        End Select
        Select Case chkOvralDisc.Checked
            Case True
                txtOvralDisc.Visible = True
            Case False
                txtOvralDisc.Visible = False
        End Select
        pnlBankdtls.Visible = False
        lstbxVendorNm.Visible = False
        lstbxItemName.Visible = False
        Label17.Visible = False
        Label28.Visible = False
        Label38.Visible = False
        cmbPaymode.Visible = False
        lblstock.Visible = False
        lbldspstock.Visible = False
        pnlCashRcvd.Visible = False

        obj.TodayDate(txtPurDt)
        cmbUom.Items.Clear()
        cmbItemTax.Items.Clear()
        cmbaccname.DataSource = Nothing
        cmbaccname.Items.Clear()
        cmbacctype.Items.Clear()

        Dim uomlist, taxdesc, acctype As New List(Of String)
        uomlist = obj.getcolumndatafromquery("select unit_desc from uom_tbl")
        taxdesc = obj.getcolumndatafromquery("select distinct gst_rate from gst_tbl")

        For i = 0 To uomlist.Count - 1
            cmbUom.Items.Add(uomlist(i))
        Next
        For i = 0 To taxdesc.Count - 1
            cmbItemTax.Items.Add(taxdesc(i))
        Next
        acctype = obj.getcolumndatafromquery("select distinct account_type from account_tbl")
        For i = 0 To acctype.Count - 1
            cmbacctype.Items.Add(acctype(i))
        Next

        txtPurchaseNo.Text = obj.GetOneValueFromQuery("select purchase_frmt&''&purchase_no from control_tbl where company_id=" + SharedData.companyid + "")

        Try


            itemdatatable.Columns.Add("Item Name".ToString())
            itemdatatable.Columns.Add("Item No".ToString())
            itemdatatable.Columns.Add("Desc".ToString())
            itemdatatable.Columns.Add("Qty".ToString())
            itemdatatable.Columns.Add("UOM".ToString())
            itemdatatable.Columns.Add("Rate".ToString())
            itemdatatable.Columns.Add("Disc".ToString())
            itemdatatable.Columns.Add("Value".ToString())
            itemdatatable.Columns.Add("Tax".ToString())
            itemdatatable.Columns.Add("Cess".ToString())
        Catch ex As Exception

        End Try
        GridPurchaseData.ColumnHeadersDefaultCellStyle.Font = New Font("Century Gothic", 7, FontStyle.Bold)

    End Sub

    Private Sub chkOvralDisc_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkOvralDisc.CheckedChanged
        Select Case chkOvralDisc.Checked
            Case True
                txtOvralDisc.Visible = True
                Label17.Visible = True
            Case False
                txtOvralDisc.Visible = False
                Label17.Visible = False
        End Select
        GetGrandAmt()
    End Sub

    Private Sub chkRndOff_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkRndOff.CheckedChanged
        Select Case chkRndOff.Checked
            Case True
                txtRndof.Visible = True
                Me.lblGrantTot.Text = CDbl(lbloriamt.Text) - CDbl(txtRndof.Text)
            Case False
                txtRndof.Visible = False
                Me.lblGrantTot.Text = lbloriamt.Text
        End Select
        GetGrandAmt()
    End Sub

    Private Sub chkShpCost_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkShpCost.CheckedChanged
        Select Case chkShpCost.Checked
            Case True
                txtShpCost.Visible = True

            Case False
                txtShpCost.Visible = False
        End Select
        GetGrandAmt()
    End Sub

    Private Sub cmbPaymode_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbPaymode.SelectedIndexChanged
        Select Case cmbPaymode.Text
            Case Is = "Cash"
                pnlCashRcvd.Visible = True
                pnlBankdtls.Visible = False
                pnlCreditDays.Visible = False
            Case Is = "Cheque"
                pnlBankdtls.Visible = True
                pnlCreditDays.Visible = False
                Dim listbank As New DataTable
                    cmbBankname.DataSource = Nothing
                    cmbBankname.Items.Clear()
                    listbank = obj.getdatatable("select bank_name & ' - ' & acc_no as bankdtls,ID from bank_tbl where company_id =" + SharedData.companyid + "")
                    cmbBankname.DisplayMember = "bankdtls"
                    cmbBankname.ValueMember = "ID"
                    cmbBankname.DataSource = listbank

            Case Else
                pnlBankdtls.Visible = False
                pnlCreditDays.Visible = False
                pnlCashRcvd.Visible = False
        End Select
    End Sub

    Private Sub txtItemNm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtItemNm.KeyDown
        Select Case e.KeyCode
            Case Keys.Down
                lstbxItemName.Focus()
        End Select
    End Sub

    Private Sub txtItemNm_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtItemNm.KeyPress
        lstbxItemName.Visible = True

    End Sub

    Private Sub lstbxItemName_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lstbxItemName.MouseClick
        lstbxItemName.Visible = False
    End Sub

    Private Sub btnMakBil_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMakBil.Click

        Dim purchase_no, user_purchase_no, contact_no, ref_no, purchase_dt, account_id,
            payment_method, cheque_no, cheque_dt, bank_name, credit_days, vendor_notes,
            internal_notes, company_id, user_name As String
        Dim reverse_flg, overall_disc_flg, shpcost_flg, roundoff_flg, payment_status As Integer
        Dim overall_disc_percent, overall_disc_amt, shpcost_amt, roundoff_amt,
          sub_total, total_tax, total_cess, grand_total, cash_paid As Double

        Try
            If S.GetPurchaseno() <> "" Then
                purchase_no = S.GetPurchaseno()

                Dim b As Boolean = BeforeUpdatePurchase()
                If b = False Then
                    MsgBox("Error")
                    Exit Sub
                End If
            Else
                purchase_no = obj.GetOneValueFromQuery("select purchase_frmt&''&purchase_no from control_tbl where company_id=" + SharedData.companyid + "")

               
            End If
            user_purchase_no = Me.txtPurchaseNo.Text
            contact_no = Me.lblcuscode.Text
            ref_no = Me.txtRefno.Text
            purchase_dt = Format(CDate(Me.txtPurDt.Text), "dd/MM/yyyy")
            account_id = Me.cmbaccname.SelectedValue


            If rbtPaid.Checked = True Then
                payment_method = Me.cmbPaymode.Text
                payment_status = 1
                If payment_method = "Cheque" Then
                    cheque_no = Me.txtChqno.Text
                    cheque_dt = Format(CDate(Me.txtChqdt.Text), "dd/MM/yyyy")
                    bank_name = Me.cmbBankname.Text
                    credit_days = 0
                    cash_paid = 0
                Else
                    cheque_no = ""
                    cheque_dt = "01/01/1900"
                    bank_name = ""
                    credit_days = 0
                    cash_paid = Me.lblGrantTot.Text
                End If

            ElseIf RbtUnpaid.Checked = True Then
                payment_status = 0
                payment_method = "Credit"
                cheque_no = ""
                cheque_dt = "01/01/1900"
                bank_name = ""
                credit_days = Val(Me.txtCrdtDays.Text)
                cash_paid = 0
            Else
                Exit Sub
            End If


            vendor_notes = Me.txtVendorNotes.Text
            internal_notes = Me.txtInternalNotes.Text
            company_id = SharedData.companyid
            user_name = SharedData.userid
            reverse_flg = If(chkRvrsChrg.Checked = True, 1, 0)
            overall_disc_flg = If(chkOvralDisc.Checked = True, 1, 0)
            shpcost_flg = If(chkShpCost.Checked = True, 1, 0)
            roundoff_flg = If(chkRndOff.Checked = True, 1, 0)

            overall_disc_percent = Me.txtOvralDisc.Text
            overall_disc_amt = obj.FdPercCalc(CDbl(Me.lbloriamt.Text), overall_disc_percent)
            shpcost_amt = txtShpCost.Text
            roundoff_amt = txtRndof.Text

            sub_total = lblSubTotal.Text
            total_tax = lblTotax.Text
            total_cess = lblTotCess.Text
            grand_total = lblGrantTot.Text

            Dim txt As New List(Of String)
            txt.Add(contact_no)
            txt.Add(user_purchase_no)
            txt.Add(purchase_dt)
            txt.Add(account_id)
            If rbtPaid.Checked = True Then
                txt.Add(payment_method)
                If payment_method = "Cheque" Then
                    txt.Add(payment_method)
                    txt.Add(cheque_no)
                    txt.Add(bank_name)
                Else
                End If
            ElseIf RbtUnpaid.Checked = True Then
            Else
                Exit Sub
            End If
            If obj.TextBoxValidate(txt) = False Then
                MsgBox("All * value  Required", MsgBoxStyle.Exclamation)
                Exit Sub
            End If
            If obj.validContact(contact_no) = False Then
                MsgBox("ContactName is not Valid!!", MsgBoxStyle.Exclamation)
                Exit Sub
            End If
            If GridPurchaseData.Rows.Count = 0 Then
                MsgBox("Please Add Item!!!", MsgBoxStyle.Exclamation)
                Exit Sub
            End If

            Dim voucher_no, voucher_user_no, voucher_dt, voucher_type As String
            voucher_no = obj.GetOneValueFromQuery("select voucher_frmt&''&voucher_no from control_tbl where company_id=" + SharedData.companyid + "")
            voucher_user_no = voucher_no
            voucher_dt = purchase_dt
            voucher_type = "B2B"
            Dim item_no, item_desc, item_uom As String
            Dim item_qty, item_rate, item_disc, item_tax, item_cess, item_amount, cess_amt, tax_amt, disc_amt As Double
            Dim QueryCollection As New List(Of String)

            For i = 0 To GridPurchaseData.Rows.Count - 1
                item_no = GridPurchaseData.Rows(i).Cells(1).Value.ToString()
                item_desc = GridPurchaseData.Rows(i).Cells(2).Value.ToString()
                item_qty = GridPurchaseData.Rows(i).Cells(3).Value.ToString()
                item_uom = GridPurchaseData.Rows(i).Cells(4).Value.ToString()
                item_rate = GridPurchaseData.Rows(i).Cells(5).Value.ToString()
                item_disc = GridPurchaseData.Rows(i).Cells(6).Value.ToString()
                item_tax = GridPurchaseData.Rows(i).Cells(8).Value.ToString()
                item_cess = GridPurchaseData.Rows(i).Cells(9).Value.ToString()
                item_amount = GridPurchaseData.Rows(i).Cells(7).Value.ToString()
                cess_amt = obj.FdPercCalc(item_amount, item_cess)
                tax_amt = obj.FdPercCalc(item_amount, item_tax)
                disc_amt = obj.FdPercCalc(item_amount, item_disc)
                QueryCollection.Add("insert into purchase_dtl(purchase_no,item_no, item_desc, item_uom, item_qty,item_rate," & _
                               " item_disc, item_tax, item_cess, item_amount, cess_amt, tax_amt, disc_amt) values" & _
                               "('" + purchase_no + "','" + item_no + "','" + item_desc + "','" + item_uom + "'," & _
    "" & item_qty & "," & item_rate & "," & item_disc & "," & item_tax & "," & item_cess & "" & _
    "," & item_amount & "," & cess_amt & "," & tax_amt & "," & disc_amt & ")")
                QueryCollection.Add("update stock_tbl set  qty=qty+" & item_qty & "	where item_no='" + item_no + "' and company_id=" + company_id + "")

            Next

           
           



            If payment_method = "Cash" Then
                QueryCollection.Add("update bank_tbl set  pettycash_closingBalance=pettycash_closingBalance-" & cash_paid & "	where  company_id=" + company_id + "")
            ElseIf payment_method = "Cheque" Then
                QueryCollection.Add("update bank_tbl set  bank_closeBalance=bank_closeBalance-" & grand_total & "	where  company_id=" + company_id + " and bank_name='" + bank_name + "'")
            Else
            End If

            If payment_status = 1 Then
                QueryCollection.Add("insert into voucher_tbl (voucher_no,voucher_user_no,contact_no	,voucher_dt,voucher_type," & _
                              "	account_id,	vouchercpt_flg,	voucherpaymt_flg,	" & _
                              "payment_type,	credit_debit_bank,	cheque_no,	" & _
                              "cheque_dt,	voucher_amt,	tds_percent,	total_amt,	" & _
                              "notes,	company_id,	user_name) values('" + voucher_no + "','" + voucher_user_no + "','" + contact_no + "'," & _
                              "'" + voucher_dt + "','" + voucher_type + "'," + account_id + "," & _
                              "0,1,'" + payment_method + "','" + bank_name + "','" + cheque_no + "'" & _
                              ",'" + cheque_dt + "'," & grand_total & ",0," & grand_total & "" & _
                              ",''" & _
                              "," + company_id + ",'" + user_name + "'" & _
                              ")")
                QueryCollection.Add("update control_tbl set voucher_no=voucher_no+1 where company_id=" + company_id + "")
            End If


            If S.GetPurchaseno() <> "" Then
                QueryCollection.Add("Update purchase_hdr set user_purchase_no='" + user_purchase_no + "'," & _
                                "	contact_no='" + contact_no + "',	" & _
                                "ref_no='" + ref_no + "',	purchase_dt='" + purchase_dt + "',	" & _
                                "account_id=" + account_id + ",	reverse_flg=" & reverse_flg & "," & _
                                "	overall_disc_flg=" & overall_disc_flg & ",	" & _
                                "overall_disc_percent=" & overall_disc_percent & ",	" & _
                                "overall_disc_amt=" & overall_disc_amt & ",	" & _
                                "shpcost_flg=" & shpcost_flg & ",	shpcost_amt=" & shpcost_amt & ",	" & _
                                "roundoff_flg=" & roundoff_flg & ",	roundoff_amt=" & roundoff_amt & ",	" & _
                                "payment_status=" & payment_status & ",	" & _
                                "payment_method='" + payment_method + "',	" & _
                                "cheque_no='" + cheque_no + "',	" & _
                                "cheque_dt='" + cheque_dt + "',	" & _
                                "bank_name='" + bank_name + "',	credit_days=" & credit_days & ",	" & _
                                "vendor_notes='" + obj.inapos(vendor_notes) + "',	" & _
                                "internal_notes='" + obj.inapos(internal_notes) + "',	" & _
                                "sub_total=" & sub_total & ",	total_tax=" & total_tax & ",	" & _
                                "total_cess=" & total_cess & "	,grand_total=" & grand_total & ",	" & _
                                "company_id=" & company_id & "," & _
                                "	user_name='" + user_name + "',  cash_paid=" & cash_paid & "," & _
                                "voucher_flg=" & payment_status & ",voucher_no='" + If(payment_status = 1, voucher_no, "") + "'" & _
                                " where purchase_no='" + purchase_no + "'")
            Else
                QueryCollection.Add("insert into purchase_hdr(purchase_no,	user_purchase_no," & _
                               "	contact_no,	ref_no,	purchase_dt,	account_id,	reverse_flg," & _
                               "	overall_disc_flg,	overall_disc_percent,	overall_disc_amt,	" & _
                               "shpcost_flg,	shpcost_amt,	roundoff_flg,	roundoff_amt,	" & _
                               "payment_status,	payment_method,	cheque_no,	cheque_dt,	" & _
                               "bank_name,	credit_days,	vendor_notes,	internal_notes,	" & _
                               "sub_total,	total_tax,	total_cess	,grand_total,	company_id," & _
                               "	user_name,  cash_paid,voucher_flg,voucher_no) values('" + purchase_no + "','" + user_purchase_no + "'," & _
                               "'" + contact_no + "','" + ref_no + "','" + purchase_dt + "'," & _
                               "" + account_id + "," & reverse_flg & "," & overall_disc_flg & "," & _
                               "" & overall_disc_percent & "," & overall_disc_amt & "," & shpcost_flg & "," & _
                               "" & shpcost_amt & "," & roundoff_flg & "," & roundoff_amt & "," & _
                               "" & payment_status & ",'" + payment_method + "','" + cheque_no + "'," & _
                               "'" + cheque_dt + "','" + bank_name + "'," & credit_days & "," & _
                               "'" + obj.inapos(vendor_notes) + "','" + obj.inapos(internal_notes) + "'," & sub_total & "," & _
                               "" & total_tax & "," & total_cess & "," & grand_total & "," & _
                               "" + company_id + ",'" + user_name + "'," & cash_paid & "," & payment_status & ",'" + If(payment_status = 1, voucher_no, "") + "')")

                QueryCollection.Add("update control_tbl set purchase_no=purchase_no+1 where company_id=" + company_id + "")

            End If




            Dim result As Boolean = obj.TransactionInsert(QueryCollection)
            Select Case result
                Case True
                    MsgBox("Purchase details updated!!", MessageBoxIcon.Information)
                    S.SetReportpurchaseno(purchase_no)
                    ReportScreen.Show()
                Case False
                    MsgBox("Something Went Wrong!!", MessageBoxIcon.Exclamation)
                    Exit Sub
            End Select
            Me.Controls.Clear()
            InitializeComponent()
            Purchase_Load(e, e)
            S.ClearPurchaseno()
        Catch ex As Exception
            MsgBox("Exception:Caution!!  " + ex.Message + "", MessageBoxIcon.Exclamation)
            Exit Sub
        End Try
        ReportScreen.BringToFront()
        ReportScreen.Focus()
    End Sub
    Function BeforeUpdatePurchase() As Boolean
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
                Dim i As Integer = obj.QueryExecution("delete from purchase_dtl where purchase_no='" + S.GetPurchaseno + "'")
                Return If(i >= 1, True, False)
            Case False
                Return False
        End Select
    End Function
    Private Sub dtpPurDt_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpPurDt.ValueChanged
        txtPurDt.Text = Me.dtpPurDt.Value.Date.ToString("dd/MM/yyyy")
    End Sub

    Private Sub txtVendorName_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtVendorName.KeyUp
        lblcuscode.Text = ""
        Dim listvendorname As New DataTable
        lstbxVendorNm.DataSource = Nothing
        If txtVendorName.Text = "" Then
            lstbxVendorNm.Visible = False
        Else

            listvendorname = obj.getdatatable("select top 1 'Add New' as company_name,'0' as contact_no from contact_tbl union select company_name,contact_no from contact_tbl where company_name like '%" + txtVendorName.Text + "%'")
            lstbxVendorNm.DisplayMember = "company_name"
            lstbxVendorNm.ValueMember = "contact_no"
            lstbxVendorNm.DataSource = listvendorname
            lstbxVendorNm.Visible = True
        End If
    End Sub

    Private Sub lstbxVendorNm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstbxVendorNm.Click
        If lstbxVendorNm.Text = "Add New" Then
            Contacts.Show()
            Contacts.BringToFront()
            Contacts.Focus()
        Else
            Try
                txtVendorAddress.Text = obj.GetOneValueFromQuery("select ship_address from contact_tbl where contact_no='" + lstbxVendorNm.SelectedValue + "'")
                lstbxVendorNm.Visible = False
                txtVendorName.Text = lstbxVendorNm.Text
                lblcuscode.Text = lstbxVendorNm.SelectedValue
            Catch ex As Exception

            End Try
        End If
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
    Private Sub txtItemNm_KeyUp(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtItemNm.KeyUp
       
        Dim listitemname As New DataTable
        lstbxItemName.DataSource = Nothing
        If txtItemNm.Text = "" Then
            lstbxItemName.Visible = False
        Else
            listitemname = obj.getdatatable("select top 1 'Add New' as item_name,'0' as item_no from item_tbl union select item_name,item_no from item_tbl where item_name like '%" + txtItemNm.Text + "%' and item_type='Goods'")
            ' listitemname = obj.getdatatable("select top 1 'Add New' as item_name,'0' as item_no from item_tbl union select a.item_name& '|' & b.qty,a.item_no from item_tbl a,stock_tbl b where a.item_no=b.item_no and  a.item_name like '%" + txtItemNm.Text + "%'")

            lstbxItemName.DisplayMember = "item_name"
            lstbxItemName.ValueMember = "item_no"
            lstbxItemName.DataSource = listitemname
            lstbxItemName.Visible = True

        End If
    End Sub

    Private Sub lstbxItemName_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstbxItemName.Click
        
        If lstbxItemName.Text = "Add New" Then
            Items.Show()
            Items.BringToFront()
            Items.Focus()
        Else
            Try
                If lblcuscode.Text = "" Then
                    MsgBox("Please Select Vendor Name")
                    Exit Sub
                End If
                txtItemNm.Text = lstbxItemName.Text
                Dim itemdata As New List(Of String)
                itemdata = obj.GetMoreValueFromQuery("select uom,purchase_rate,cess,igst from item_tbl where item_no='" + lstbxItemName.SelectedValue + "'", 4)
                cmbUom.Text = itemdata(0)
                txtRate.Text = itemdata(1)
                txtItmCess.Text = itemdata(2)
                cmbItemTax.Text = itemdata(3)
                txtQty.Text = "1"
                txtItmDisc.Text = "0"

                Select Case obj.GetOneValueFromQuery("select billing_state from company_tbl " & _
                                                     "where company_id=" & SharedData.companyid & "") =
                                                 obj.GetOneValueFromQuery("select place_supply  from contact_tbl " & _
                                                     "where contact_no='" + lstbxVendorNm.SelectedValue + "'")
                    Case True
                        lblitemtaxtype.Text = "GST"
                    Case False
                        lblitemtaxtype.Text = "IGST"
                End Select
                lblstock.Text = obj.GetOneValueFromQuery("select qty from stock_tbl where item_no='" + lstbxItemName.SelectedValue + "' and company_id=" & SharedData.companyid & "")
                lblstock.Visible = True
                lbldspstock.Visible = True
                lstbxItemName.Visible = False
            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub lnklblEditAddress_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnklblEditAddress.LinkClicked
       obj.ContactOpen()
    End Sub

    Private Sub rbtPaid_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtPaid.CheckedChanged
        Select Case rbtPaid.Checked
            Case True
                Label28.Visible = True
                Label38.Visible = True
                cmbPaymode.Visible = True
                pnlCreditDays.Visible = False
                pnlBankdtls.Visible = True
            Case False
                Label28.Visible = False
                Label38.Visible = False
                cmbPaymode.Visible = False
                pnlCreditDays.Visible = True
                pnlBankdtls.Visible = False
        End Select
    End Sub

    Private Sub btnAddToGrid_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddToGrid.Click
        GridPurchaseData.ClearSelection()
        Try
            Dim Amount As Double
            Amount = CDbl(txtQty.Text) * CDbl(txtRate.Text)
            Amount = Amount - obj.FdPercCalc(Amount, Me.txtItmDisc.Text)
            itemdatatable.Rows.Add(Me.lstbxItemName.Text, lstbxItemName.SelectedValue, txtDesc.Text,
                                   txtQty.Text, cmbUom.Text, Me.txtRate.Text, Me.txtItmDisc.Text, Amount,
                                   Me.cmbItemTax.Text, Me.txtItmCess.Text)
            GridPurchaseData.DataSource = itemdatatable
            If GridPurchaseData.Columns.Count = 12 Then
            Else
                Dim btn As New DataGridViewButtonColumn
                btn.Name = "edit"
                btn.HeaderText = ""
                btn.Text = "EDIT"
                btn.UseColumnTextForButtonValue = True
                GridPurchaseData.Columns.Add(btn)

                Dim btn1 As New DataGridViewButtonColumn
                btn1.Name = "delete"
                btn1.HeaderText = ""
                btn1.Text = "DELETE"
                btn1.UseColumnTextForButtonValue = True
                GridPurchaseData.Columns.Add(btn1)
            End If
            GridPurchaseData.AutoGenerateColumns = False
            GridPurchaseData.AllowUserToAddRows = False
            GridPurchaseData.Columns(1).Visible = False
            txtDesc.Text = ""
            txtQty.Text = ""
            cmbUom.Refresh()
            Me.txtRate.Text = "0"
            Me.txtItmDisc.Text = "0"
            txtItemNm.Text = ""
            Me.cmbItemTax.Text = "0"
            Me.txtItmCess.Text = "0"
            lblstock.Text = "0"
            GetGrandAmt()
        Catch ex As Exception

        End Try
    End Sub
    Sub CalculationArea()
        Dim SubTotal, TaxAmt, CessAmt, GrandAmt As Double
        Dim totamt, discpercent, taxpercent, cesspercent, totamtwithdisc As Double
        SubTotal = 0
        TaxAmt = 0
        CessAmt = 0
        GrandAmt = 0

        For i = 0 To GridPurchaseData.Rows.Count - 1
            totamt = CDbl(GridPurchaseData.Rows(i).Cells(7).Value.ToString())
            discpercent = CDbl(GridPurchaseData.Rows(i).Cells(6).Value.ToString())
            taxpercent = CDbl(GridPurchaseData.Rows(i).Cells(8).Value.ToString())
            cesspercent = CDbl(GridPurchaseData.Rows(i).Cells(9).Value.ToString())
            totamtwithdisc = (totamt) ' - obj.FdPercCalc(totamt, discpercent))
            SubTotal = SubTotal + totamtwithdisc
            TaxAmt = TaxAmt + obj.FdPercCalc(totamtwithdisc, taxpercent)
            CessAmt = CessAmt + obj.FdPercCalc(totamtwithdisc, cesspercent)
            GrandAmt = GrandAmt + totamtwithdisc + obj.FdPercCalc(totamtwithdisc, taxpercent) +
                obj.FdPercCalc(totamtwithdisc, cesspercent)
        Next
        lblSubTotal.Text = obj.twopt(SubTotal)
        lblTotax.Text = obj.twopt(TaxAmt)
        lblTotCess.Text = obj.twopt(CessAmt)
        lblGrantTot.Text = obj.twopt(GrandAmt)
        lbloriamt.Text = obj.twopt(GrandAmt)
    End Sub
    Private Sub GridPurchaseData_CellContentClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GridPurchaseData.CellContentClick
        If e.ColumnIndex = 10 Then
            Me.txtItemNm.Text = GridPurchaseData.Rows(e.RowIndex).Cells(0).Value.ToString()
            lstbxItemName.SelectedValue = GridPurchaseData.Rows(e.RowIndex).Cells(1).Value.ToString()
            txtDesc.Text = GridPurchaseData.Rows(e.RowIndex).Cells(2).Value.ToString()
            txtQty.Text = GridPurchaseData.Rows(e.RowIndex).Cells(3).Value.ToString()
            cmbUom.Text = GridPurchaseData.Rows(e.RowIndex).Cells(4).Value.ToString()
            Me.txtRate.Text = GridPurchaseData.Rows(e.RowIndex).Cells(5).Value.ToString()
            Me.txtItmDisc.Text = GridPurchaseData.Rows(e.RowIndex).Cells(6).Value.ToString()
            Me.cmbItemTax.Text = GridPurchaseData.Rows(e.RowIndex).Cells(7).Value.ToString()
            Me.txtItmCess.Text = GridPurchaseData.Rows(e.RowIndex).Cells(8).Value.ToString()

            lblstock.Text = obj.GetOneValueFromQuery("select qty from stock_tbl where item_no='" + GridPurchaseData.Rows(e.RowIndex).Cells(1).Value.ToString() + "' and company_id=" & SharedData.companyid & "")
            Dim index As Integer
            index = e.RowIndex
            GridPurchaseData.Rows.RemoveAt(index)

            GetGrandAmt()
        End If
        If e.ColumnIndex = 11 Then
            Dim index As Integer
            index = e.RowIndex
            GridPurchaseData.Rows.RemoveAt(index)

            GetGrandAmt()
        End If
    End Sub

    Private Sub chkRvrsChrg_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkRvrsChrg.CheckedChanged
        GetGrandAmt()
    End Sub

    Private Sub txtRndof_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtRndof.KeyPress
        obj.OnlyNoS(e)
    End Sub

    Private Sub txtRndof_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtRndof.KeyUp
        GetGrandAmt()
    End Sub

    Private Sub txtShpCost_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtShpCost.KeyPress
        obj.OnlyNoS(e)
    End Sub

    Private Sub txtShpCost_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtShpCost.KeyUp
        GetGrandAmt()
    End Sub

    Sub GetGrandAmt()
      CalculationArea()
        Dim calcgrandamt As Double = 0
        If chkRvrsChrg.Checked = True Then
            calcgrandamt = Me.lblSubTotal.Text
        Else
            calcgrandamt = Me.lbloriamt.Text
        End If
        If chkOvralDisc.Checked = True Then
            Dim value As Double = txtOvralDisc.Text
            calcgrandamt = calcgrandamt - (calcgrandamt * (value / 100))
        Else

        End If
        If chkShpCost.Checked = True Then
            Dim value As Double
            Try
                value = txtShpCost.Text
            Catch ex As Exception
                value = 0
            End Try

            calcgrandamt = calcgrandamt + value
        Else
        End If
        If chkRndOff.Checked = True Then
            Dim value As Double
            Try
                value = txtRndof.Text
            Catch ex As Exception
                value = 0
            End Try
            calcgrandamt = calcgrandamt - value
        End If
        Me.lblGrantTot.Text = obj.twopt(calcgrandamt)
    End Sub

    Private Sub txtOvralDisc_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtOvralDisc.KeyPress
        obj.OnlyNoS(e)
    End Sub

    Private Sub txtOvralDisc_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtOvralDisc.KeyUp
        GetGrandAmt()
    End Sub
    Private Sub txtquotno_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPurchaseNo.KeyPress, txtRefno.KeyPress
        obj.NoApos(e)
    End Sub

    Private Sub pnlBankdtls_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles pnlBankdtls.Paint

    End Sub

    Private Sub Label38_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label38.Click

    End Sub

    Private Sub Label28_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label28.Click

    End Sub
End Class