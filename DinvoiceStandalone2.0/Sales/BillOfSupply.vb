Public Class BillOfSupply
    Dim obj As New ObjClass
    Dim S As New SharedData
    Dim itemdatatable As New DataTable

    Private Sub BillOfSupply_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed

        If S.GetSupplyno() <> "" Then
            S.ClearSupplyno()
        Else

        End If

    End Sub
    Private Sub BillOfSupply_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtClientName.Focus()
        If S.GetSupplyno() <> "" Then
            EditFunction()
        Else
            OnloadFunction()
        End If

       

    End Sub
    Sub EditFunction()
        Onloadfunction()
        Dim dtsupitems As New DataTable

        dtsupitems = obj.getdatatable("select item_no, item_desc, item_qty, item_uom, item_rate, item_disc, item_amount from supply_dtl where supply_no='" + S.GetSupplyno + "'")
        Dim itemname As String
        For i = 0 To dtsupitems.Rows.Count - 1
            itemname = obj.GetOneValueFromQuery("select item_name from item_tbl where item_no='" + dtsupitems.Rows(i).Item(0).ToString + "'")
            itemdatatable.Rows.Add(itemname, dtsupitems.Rows(i).Item(0).ToString, dtsupitems.Rows(i).Item(1).ToString,
                                   dtsupitems.Rows(i).Item(2).ToString, dtsupitems.Rows(i).Item(3).ToString,
                                   dtsupitems.Rows(i).Item(4).ToString, dtsupitems.Rows(i).Item(5).ToString,
                                   dtsupitems.Rows(i).Item(6).ToString)
        Next

        GridInvoice.DataSource = itemdatatable
        If GridInvoice.Columns.Count = 10 Then
        Else
            Dim btn As New DataGridViewButtonColumn
            btn.Name = "edit"
            btn.HeaderText = ""
            btn.Text = "EDIT"
            btn.UseColumnTextForButtonValue = True
            GridInvoice.Columns.Add(btn)

            Dim btn1 As New DataGridViewButtonColumn
            btn1.Name = "delete"
            btn1.HeaderText = ""
            btn1.Text = "DELETE"
            btn1.UseColumnTextForButtonValue = True
            GridInvoice.Columns.Add(btn1)
        End If
        GridInvoice.AutoGenerateColumns = False
        GridInvoice.AllowUserToAddRows = False
        GridInvoice.Columns(1).Visible = False
        txtDesc.Text = ""
        txtQty.Text = ""
        cmbUom.Refresh()
        Me.txtRate.Text = "0"
        Me.txtItmDisc.Text = "0"
        txtItemNm.Text = ""
        lblstock.Text = "0"


        Dim GrandAmt As Double
        Dim totamt, totamtwithdisc As Double

        GrandAmt = 0

        For i = 0 To GridInvoice.Rows.Count - 1
            totamt = CDbl(GridInvoice.Rows(i).Cells(7).Value.ToString())
            totamtwithdisc = (totamt) ' - obj.FdPercCalc(totamt, discpercent))

            GrandAmt = GrandAmt + totamtwithdisc 
        Next
        lbloriamt.Text = GrandAmt

        Dim getdata As New List(Of String)

        getdata = obj.GetMoreValueFromQuery("select user_supply_no, contact_no, ref_no, supply_dt," & _
                                            " place_supply, account_id, indent_flg, " & _
                                            "advance_flg, overall_disc_flg, overall_disc_percent, " & _
                                            "overall_disc_amt, shpcost_flg, shpcost_amt, roundoff_flg," & _
                                            " roundoff_amt, payment_status,credit_days, customer_notes, internal_notes," & _
                                            " sub_total, grand_total from supply_hdr where" & _
                                            " supply_no='" + S.GetSupplyno + "'", 21)



        Me.txtInvoiceno.Text = getdata(0)
        Dim subgetdata1 As New List(Of String)
        subgetdata1 = obj.GetMoreValueFromQuery("select company_name,billing_address from contact_tbl where contact_no='" + getdata(1) + "'", 2)

        Me.txtClientName.Text = subgetdata1(0)
        Me.txtClientAddress.Text = subgetdata1(1)
        Me.lblcuscode.Text = getdata(1)
        Me.txtRefNo.Text = getdata(2)
        Me.txtInvDt.Text = Format(CDate(getdata(3)), "dd/MM/yyyy")
        Me.txtplsupply.Text = getdata(4)
        Me.cmbAccType.Text = obj.GetOneValueFromQuery("select account_type from account_tbl where ID=" + getdata(5) + "")
        cmbaccname.DataSource = Nothing
        Dim acclist As New DataTable
        acclist = obj.getdatatable("select account_head,ID from account_tbl where account_type='" + cmbAccType.Text + "'")
        cmbaccname.DisplayMember = "account_head"
        cmbaccname.ValueMember = "ID"
        cmbaccname.DataSource = acclist
        Me.cmbaccname.Text = obj.GetOneValueFromQuery("select account_head from account_tbl where ID=" + getdata(5) + "")
        If getdata(6) = "1" Then
            chkbxAddIndent.Checked = True
            

                Dim dtnew, dtold As New DataTable
                dtnew.Columns.Add("check", GetType(Boolean))
                dtnew.Columns.Add("ItemName", GetType(String))
                dtnew.Columns.Add("Description", GetType(String))
                dtnew.Columns.Add("Qty", GetType(String))
                dtnew.Columns.Add("intend_no", GetType(String))
                dtnew.Columns.Add("ID", GetType(String))
            Dim intendno As String = obj.GetOneValueFromQuery("select distinct indent_no from indent_dtl where bill_no='" + S.GetInvoiceno + "'")

            dtold = obj.getdatatable("" & _
                                     "select item_name as ItemName,	item_desc as Description,qty," & _
                                     "a.indent_no,a.ID,a.bill_flg  from indent_dtl a,indent_hdr " & _
                                     "b where a.indent_no=b.indent_no and b.contact_no=" & _
                                     "'" + lblcuscode.Text + "' and a.indent_no='" + intendno + "'")

            txtIntendNo.Text = intendno
            'dtold = obj.getdatatable("select item_name as ItemName,	item_desc as Description,qty" & _
            '                         ",a.indent_no,a.ID,a.bill_flg  from indent_dtl a,indent_hdr " & _
            '                         "b where a.indent_no=b.indent_no and b.contact_no=" & _
            '                         "'" + lblcuscode.Text + "' and a.bill_no='" + S.GetSupplyno + "'")


                For i = 0 To dtold.Rows.Count - 1
                dtnew.Rows.Add(If(dtold.Rows(i).Item(5).ToString = "1", True, False), dtold.Rows(i).Item(0).ToString, dtold.Rows(i).Item(1).ToString, dtold.Rows(i).Item(2).ToString, dtold.Rows(i).Item(3).ToString, dtold.Rows(i).Item(4).ToString)
                Next
                gridIndent.DataSource = dtnew
                gridIndent.AutoGenerateColumns = False
                gridIndent.AllowUserToAddRows = False
                gridIndent.Columns(1).ReadOnly = True
                gridIndent.Columns(2).ReadOnly = True
                gridIndent.Columns(3).ReadOnly = True
                gridIndent.Columns(4).Visible = False
                gridIndent.Columns(5).Visible = False
        Else
            chkbxAddIndent.Checked = False
        End If
        If getdata(7) = "1" Then
            chkAddadvance.Checked = True

        Else
            chkAddadvance.Checked = False
        End If
        If getdata(8) = "1" Then
            chkOvralDisc.Checked = True
            Me.txtOvralDisc.Text = getdata(9)
            Me.txtOvralDisc.Visible = True

        Else
            chkOvralDisc.Checked = False
            Me.txtOvralDisc.Visible = False
        End If

        If getdata(11) = "1" Then
            chkShpCost.Checked = True
            Me.txtShpCost.Text = getdata(12)
            Me.txtShpCost.Visible = True

        Else
            chkShpCost.Checked = False
            Me.txtShpCost.Visible = False
        End If
        If getdata(13) = "1" Then
            chkRndOff.Checked = True
            Me.txtRndof.Text = getdata(14)
            Me.txtRndof.Visible = True

        Else
            chkRndOff.Checked = False
            Me.txtRndof.Visible = False
        End If

        RbtUnpaid.Checked = True
        Label28.Visible = False
        Label38.Visible = False
        cmbPaymode.Visible = False
        pnlCreditDays.Visible = True
        txtCrdtDays.Text = getdata(16)

        Me.txtClientNotes.Text = getdata(17)
        Me.txtInternalNotes.Text = getdata(18)






        lblSubTotal.Text = getdata(19)
       
        lblGrandTot.Text = getdata(20)






        lstbxItemName.Visible = False
        lstbxClientNm.Visible = False
    End Sub
    Sub Onloadfunction()
        MaximizeBox = False
        MinimizeBox = False
        txtClientName.Focus()
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
        pnlAdvance.Visible = False
        pnlIndent.Visible = False
        lstbxItemName.Visible = False
        lstbxClientNm.Visible = False
        Panel3.Visible = False
        pnlGatepass.Visible = False
        pnlCreditDays.Visible = True
        Label28.Visible = False
        Label40.Visible = False
        cmbPaymode.Visible = False
        Label17.Visible = False
        lblcuscode.Text = ""
        cmbUom.Items.Clear()
        cmbAccType.Items.Clear()
        cmbaccname.DataSource = Nothing
        cmbaccname.Items.Clear()
        obj.TodayDate(txtInvDt)

        itemdatatable.Rows.Clear()
        GridInvoice.DataSource = itemdatatable
        lblAdvanceTot.Text = ""
        lblSubTotal.Text = ""
        lblGrandTot.Text = ""
        RbtUnpaid.Checked = True

        Dim uomlist, acctype As New List(Of String)
        uomlist = obj.getcolumndatafromquery("select unit_desc from uom_tbl")
        For i = 0 To uomlist.Count - 1
            cmbUom.Items.Add(uomlist(i))
        Next
        acctype = obj.getcolumndatafromquery("select distinct account_type from account_tbl")
        For i = 0 To acctype.Count - 1
            cmbAccType.Items.Add(acctype(i))
        Next

       

        txtInvoiceno.Text = obj.GetOneValueFromQuery("select supply_frmt&''&supply_no from control_tbl where company_id=" + SharedData.companyid + "")

        Try


            itemdatatable.Columns.Add("Item Name".ToString())
            itemdatatable.Columns.Add("Item No".ToString())
            itemdatatable.Columns.Add("Desc".ToString())
            itemdatatable.Columns.Add("Qty".ToString())
            itemdatatable.Columns.Add("UOM".ToString())
            itemdatatable.Columns.Add("Rate".ToString())
            itemdatatable.Columns.Add("Disc".ToString())
            itemdatatable.Columns.Add("Value".ToString())

        Catch ex As Exception

        End Try
        GridInvoice.ColumnHeadersDefaultCellStyle.Font = New Font("Century Gothic", 7, FontStyle.Bold)


    End Sub
    Private Sub chkAddadvance_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkAddadvance.CheckedChanged
        Try

            Select Case chkAddadvance.Checked
                Case True
                    pnlAdvance.Visible = True
                    Panel3.Visible = True


                    Dim dtnew, dtold As New DataTable
                    dtnew.Columns.Add("check", GetType(Boolean))
                    dtnew.Columns.Add("Advance no", GetType(String))
                    dtnew.Columns.Add("ContactName", GetType(String))
                    dtnew.Columns.Add("Advance", GetType(String))
                    dtnew.Columns.Add("", GetType(String))
                    If S.GetSupplyno <> "" Then
                        dtold = obj.getdatatable("select user_advance_no,total_amt,advance_no,bill_flg from advance_tbl" & _
                                                 " where contact_no='" + lblcuscode.Text + "' and bill_flg=0 union " & _
                                                 "select user_advance_no,total_amt,advance_no,bill_flg from advance_tbl" & _
                                                 " where bill_no='" + S.GetSupplyno + "'")
                    Else
                        dtold = obj.getdatatable("select user_advance_no,total_amt,advance_no,bill_flg from advance_tbl where contact_no='" + lblcuscode.Text + "' and bill_flg=0")
                       

                    End If
                    For i = 0 To dtold.Rows.Count - 1
                        dtnew.Rows.Add(If(dtold.Rows(i).Item(3).ToString = "1", True, False), dtold.Rows(i).Item(0).ToString, obj.GetOneValueFromQuery("select company_name from contact_tbl where contact_no='" + lblcuscode.Text + "'"), dtold.Rows(i).Item(1).ToString, dtold.Rows(i).Item(2).ToString)
                    Next
                    gridAdvance.DataSource = dtnew
                    gridAdvance.AutoGenerateColumns = False
                    gridAdvance.AllowUserToAddRows = False
                    gridAdvance.Columns(1).ReadOnly = True
                    gridAdvance.Columns(2).ReadOnly = True
                    gridAdvance.Columns(3).ReadOnly = True
                    gridAdvance.Columns(4).Visible = False


                Case False
                    pnlAdvance.Visible = False
                    Panel3.Visible = False
            End Select

        Catch ex As Exception

        End Try
        GetGrandAmt()
    End Sub

    Private Sub chkbxAddIndent_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkbxAddIndent.CheckedChanged
        Select Case chkbxAddIndent.Checked
            Case True
                pnlIndent.Visible = True
                chkbxAddIndent.Checked = True
                gridIndent.DataSource = Nothing
                
            Case False
                pnlIndent.Visible = False
        End Select
    End Sub

   


    Private Sub panel2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles panel2.Click
        pnlAdvance.Visible = False
        pnlIndent.Visible = False
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
    End Sub
    Private Sub chkRndOff_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkRndOff.CheckedChanged
        Select Case chkRndOff.Checked
            Case True
                txtRndof.Visible = True
            Case False
                txtRndof.Visible = False
        End Select
    End Sub

    Private Sub chkShpCost_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkShpCost.CheckedChanged
        Select Case chkShpCost.Checked
            Case True
                txtShpCost.Visible = True
            Case False
                txtShpCost.Visible = False
        End Select
    End Sub

    Private Sub cmbPaymode_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbPaymode.SelectedIndexChanged
        Select Case cmbPaymode.Text
            Case Is = "Cheque"
                pnlBankdtls.Visible = True
                pnlCreditDays.Visible = False
                Dim listbank As New DataTable
                lstbxClientNm.DataSource = Nothing
                    cmbBankname.DataSource = Nothing
                    cmbBankname.Items.Clear()
                    listbank = obj.getdatatable("select bank_name & ' - ' & acc_no as bankdtls,ID from bank_tbl where company_id =" + SharedData.companyid + "")
                    cmbBankname.DisplayMember = "bankdtls"
                    cmbBankname.ValueMember = "ID"
                    cmbBankname.DataSource = listbank

            Case Is = "Credit"
                pnlCreditDays.Visible = True
                pnlBankdtls.Visible = False
            Case Else
                pnlBankdtls.Visible = False
                pnlCreditDays.Visible = False
        End Select
    End Sub

    Private Sub btnMakBil_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMakBil.Click

        Dim supply_no, user_supply_no, contact_no, supply_dt, place_supply,
            ref_no, account_id, indent_flg, indent_no, advance_flg, overall_disc_flg,
            overall_disc_percent, overall_disc_amt, shpcost_flg, shpcost_amt, roundoff_flg,
            roundoff_amt, payment_status, payment_method, cheque_no, cheque_dt, credit_bank_name,
            credit_days, customer_notes, cash_paid, internal_notes, sub_total, advance_amt,
            grand_total, company_id, user_name As String



        Try


            If S.GetSupplyno() <> "" Then
                supply_no = S.GetSupplyno()
                contact_no = Me.lblcuscode.Text
                Dim b As Boolean = BeforeUpdateSupply()
                If b = False Then
                    MsgBox("Error")
                    Exit Sub
                End If
            Else
                supply_no = obj.GetOneValueFromQuery("select supply_frmt&''&supply_no from control_tbl  where company_id=" + SharedData.companyid + "")
                contact_no = Me.lblcuscode.Text

            End If
            user_supply_no = Me.txtInvoiceno.Text

            ref_no = Me.txtRefNo.Text
            supply_dt = Format(CDate(Me.txtInvDt.Text), "dd/MM/yyyy")
            account_id = Me.cmbaccname.SelectedValue


            If rbtPaid.Checked = True Then
                payment_method = Me.cmbPaymode.Text
                payment_status = 1
                If payment_method = "Cheque" Then
                    cheque_no = Me.txtChqno.Text
                    cheque_dt = Format(CDate(Me.txtChqdt.Text), "dd/MM/yyyy")
                    credit_bank_name = Me.cmbBankname.SelectedValue
                    credit_days = 0
                    cash_paid = 0
                Else
                    cheque_no = ""
                    cheque_dt = "01/01/1900"
                    credit_bank_name = ""
                    credit_days = 0
                    cash_paid = Me.lblGrandTot.Text
                End If

            ElseIf RbtUnpaid.Checked = True Then
                payment_status = 0
                payment_method = "Credit"
                cheque_no = ""
                cheque_dt = "01/01/1900"
                credit_bank_name = ""
                credit_days = Val(Me.txtCrdtDays.Text)
                cash_paid = 0
            Else
                Exit Sub
            End If

            place_supply = Me.txtplsupply.Text
            customer_notes = Me.txtClientNotes.Text
            internal_notes = Me.txtInternalNotes.Text
            company_id = SharedData.companyid
            user_name = SharedData.userid
            overall_disc_flg = If(chkOvralDisc.Checked = True, 1, 0)
            shpcost_flg = If(chkShpCost.Checked = True, 1, 0)
            roundoff_flg = If(chkRndOff.Checked = True, 1, 0)
            overall_disc_percent = If(Me.txtOvralDisc.Text = "", 0, Me.txtOvralDisc.Text)
            overall_disc_amt = obj.FdPercCalc(CDbl(Me.lbloriamt.Text), overall_disc_percent)
            shpcost_amt = If(txtShpCost.Text = "", 0, txtShpCost.Text)
            roundoff_amt = If(txtRndof.Text = "", 0, txtRndof.Text)

            sub_total = lblSubTotal.Text
            grand_total = lblGrandTot.Text
            advance_amt = 0
            advance_flg = 0
            indent_flg = 0
            indent_no = ""
            Dim uncheckcountadv As Integer = 0
            Dim uncheckcountind As Integer = 0
            If chkAddadvance.Checked = True Then
                advance_flg = 1
                For i = 0 To gridAdvance.Rows.Count - 1
                    If CBool(gridAdvance.Rows(i).Cells(0).Value) = True Then
                        advance_amt = advance_amt + CDbl(gridAdvance.Rows(i).Cells(3).Value)
                        uncheckcountadv = uncheckcountadv + 1
                    End If
                Next
                If uncheckcountadv = 0 Then
                    MsgBox("Advance not Selected")
                    Exit Sub
                End If
            End If
          
            If chkbxAddIndent.Checked = True Then
                indent_flg = 1
                For i = 0 To gridIndent.Rows.Count - 1
                    If CBool(gridIndent.Rows(i).Cells(0).Value) = True Then
                        indent_no = gridIndent.Rows(i).Cells(5).Value
                        uncheckcountind = uncheckcountind + 1
                    End If
                    Exit For
                Next
                If uncheckcountind = 0 Then
                    MsgBox("Indent not selected")
                    Exit Sub
                End If
            End If


            Dim txt As New List(Of String)
            txt.Add(contact_no)
            txt.Add(user_supply_no)
            txt.Add(supply_dt)
            txt.Add(account_id)
            If rbtPaid.Checked = True Then
                txt.Add(payment_method)
                If payment_method = "Cheque" Then
                    txt.Add(payment_method)
                    txt.Add(cheque_no)
                    txt.Add(credit_bank_name)
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
            If GridInvoice.Rows.Count = 0 Then
                MsgBox("Please Add Item!!!", MsgBoxStyle.Exclamation)
                Exit Sub
            End If

            Dim voucher_no, voucher_user_no, voucher_dt, voucher_type As String
            voucher_no = obj.GetOneValueFromQuery("select voucher_frmt&''&voucher_no from control_tbl")
            voucher_user_no = voucher_no
            voucher_dt = supply_dt
            voucher_type = "B2B"
            Dim item_no, item_desc, item_uom As String
            Dim item_qty, item_rate, item_disc, item_amount, disc_amt As Double
            Dim QueryCollection As New List(Of String)
            Dim customer_savings As Double
            For i = 0 To GridInvoice.Rows.Count - 1
                item_no = GridInvoice.Rows(i).Cells(1).Value.ToString()
                item_desc = GridInvoice.Rows(i).Cells(2).Value.ToString()
                item_qty = GridInvoice.Rows(i).Cells(3).Value.ToString()
                item_uom = GridInvoice.Rows(i).Cells(4).Value.ToString()
                item_rate = GridInvoice.Rows(i).Cells(5).Value.ToString()
                item_disc = GridInvoice.Rows(i).Cells(6).Value.ToString()
                item_amount = GridInvoice.Rows(i).Cells(7).Value.ToString()
                disc_amt = obj.FdPercCalc(item_amount, item_disc)
                customer_savings = customer_savings + CDbl(obj.GetOneValueFromQuery("select mrp-sale_rate from item_tbl where item_no='" + item_no + "'"))
                QueryCollection.Add("insert into supply_dtl(supply_no,item_no, item_desc, item_uom, item_qty,item_rate," & _
                               " item_disc, item_amount, disc_amt) values(" & _
                               "'" + supply_no + "','" + item_no + "','" + item_desc + "','" + item_uom + "'," & _
                               "" & item_qty & "," & item_rate & "," & item_disc & "," & _
                               "" & item_amount & "," & disc_amt & ")")
                QueryCollection.Add("update stock_tbl set  qty=qty-" & item_qty & "	where item_no='" + item_no + "' and company_id=" + company_id + "")

            Next






            If payment_method = "Cash" Then
                QueryCollection.Add("update bank_tbl set  pettycash_closingBalance=pettycash_closingBalance+" & cash_paid & "	where  company_id=" + company_id + "")
            ElseIf payment_method = "Cheque" Then
                QueryCollection.Add("update bank_tbl set  bank_closeBalance=bank_closeBalance+" & grand_total & "	where  ID=" + credit_bank_name + "")
            Else
            End If

            If payment_status = 1 Then
                QueryCollection.Add("insert into voucher_tbl (voucher_no,voucher_user_no,contact_no	,voucher_dt,voucher_type," & _
                              "	account_id,	vouchercpt_flg,	voucherpaymt_flg,	" & _
                              "payment_type,	credit_debit_bank,	cheque_no,	" & _
                              "cheque_dt,	voucher_amt,	tds_percent,	total_amt,	" & _
                              "notes,	company_id,	user_name) values('" + voucher_no + "','" + voucher_user_no + "','" + contact_no + "'," & _
                              "'" + voucher_dt + "','" + voucher_type + "'," + account_id + "," & _
                              "1,0,'" + payment_method + "','" + credit_bank_name + "','" + cheque_no + "'" & _
                              ",'" + cheque_dt + "'," & grand_total & ",0," & grand_total & "" & _
                              ",''" & _
                              "," + company_id + ",'" + user_name + "'" & _
                              ")")
                QueryCollection.Add("update control_tbl set voucher_no=voucher_no+1 where company_id=" + company_id + "")
            End If


            If S.GetSupplyno() <> "" Then
                QueryCollection.Add("update supply_hdr set user_supply_no='" + user_supply_no + "', " & _
                                    " contact_no='" + contact_no + "', supply_dt='" + supply_dt + "'," & _
                                    "  place_supply='" + place_supply + "'," & _
                                    " ref_no='" + ref_no + "', account_id=" + account_id + "," & _
                                    "  indent_flg=" & indent_flg & ", indent_no='" + indent_no + "'," & _
                                    "  advance_flg=" & advance_flg & ", overall_disc_flg=" & overall_disc_flg & ", " & _
                                    "overall_disc_percent=" & overall_disc_percent & ", overall_disc_amt=" & overall_disc_amt & "," & _
                                    "  shpcost_flg=" & shpcost_flg & ", shpcost_amt=" & shpcost_amt & "," & _
                                    "  roundoff_flg=" & roundoff_flg & "," & _
                                    " roundoff_amt=" & roundoff_amt & ", payment_status=" & payment_status & "," & _
                                    "  payment_method='" + payment_method + "', cheque_no='" + cheque_no + "', " & _
                                    " cheque_dt='" + cheque_dt + "', credit_bank_name='" + credit_bank_name + "'," & _
                                    " credit_days=" & credit_days & ", customer_notes='" + obj.inapos(customer_notes) + "', " & _
                                    " internal_notes='" + obj.inapos(internal_notes) + "', sub_total=" & sub_total & "," & _
                                    " advance_amt=" & advance_amt & ", grand_total=" & grand_total & ", " & _
                                    "company_id=" & company_id & ", user_name='" + user_name + "'," & _
                                    " cash_paid=" & cash_paid & ",voucher_flg=" & payment_status & "," & _
                                    " voucher_no='" + If(payment_status = 1, voucher_no, "") + "',customer_savings=" & customer_savings & "" & _
                                    " where supply_no='" + supply_no + "'")
            Else
                QueryCollection.Add("insert into supply_hdr(supply_no, user_supply_no, contact_no, supply_dt, place_supply," & _
                                    " ref_no, account_id, indent_flg, indent_no, advance_flg, overall_disc_flg, " & _
                                    "overall_disc_percent, overall_disc_amt, shpcost_flg, shpcost_amt, roundoff_flg," & _
                                    " roundoff_amt, payment_status, payment_method, cheque_no, cheque_dt, credit_bank_name," & _
                                    " credit_days, customer_notes, internal_notes, sub_total, advance_amt, grand_total, " & _
                                    "company_id, user_name,cash_paid,voucher_flg,voucher_no,customer_savings,supplytype) values('" + supply_no + "','" + user_supply_no + "'," & _
                               "'" + contact_no + "','" + supply_dt + "','" + place_supply + "','" + ref_no + "'," & _
                               "" + account_id + "," & indent_flg & ",'" + indent_no + "'," & advance_flg & "," & overall_disc_flg & "," & _
                               "" & overall_disc_percent & "," & overall_disc_amt & "," & shpcost_flg & "," & _
                               "" & shpcost_amt & "," & roundoff_flg & "," & roundoff_amt & "," & _
                               "" & payment_status & ",'" + payment_method + "','" + cheque_no + "'," & _
                               "'" + cheque_dt + "','" + credit_bank_name + "'," & credit_days & "," & _
                               "'" + obj.inapos(customer_notes) + "','" + obj.inapos(internal_notes) + "'," & sub_total & "," & _
                               "" & advance_amt & "," & grand_total & "," & _
                               "" + company_id + ",'" + user_name + "'," & cash_paid & "," & payment_status & ",'" + If(payment_status = 1, voucher_no, "") + "'," & customer_savings & ",'SUPPLY')")

                QueryCollection.Add("update control_tbl set supply_no=supply_no+1 where company_id=" + company_id + "")


            End If


            If chkAddadvance.Checked = True Then

                For i = 0 To gridAdvance.Rows.Count - 1
                    If CBool(gridAdvance.Rows(i).Cells(0).Value) = True Then
                        QueryCollection.Add("Update advance_tbl set bill_type='SUPPLY', bill_flg=1,	bill_no='" + supply_no + "'," & _
                                            "	voucher_no='" + If(payment_status = 1, voucher_no, "") + "'," & _
                                            "	receipt_flg=" & payment_status & " where " & _
                                            "advance_no='" + gridAdvance.Rows(i).Cells(1).Value + "'")
                    End If
                Next
            End If
            Dim checkcount As Integer = 0
            If chkbxAddIndent.Checked = True Then

                For i = 0 To gridIndent.Rows.Count - 1
                    If CBool(gridIndent.Rows(i).Cells(0).Value) = True Then
                        checkcount = checkcount + 1
                        QueryCollection.Add("update indent_dtl set bill_flg=1,bill_no='" + supply_no + "'," & _
                                            "gatepass_no='" + If(chkGatepass.Checked = True, txtgatepass.Text, "") + "'," & _
                                            " gatepass_flg=" & If(chkGatepass.Checked = True, 1, 0) & "" & _
                                            " where ID=" + gridIndent.Rows(i).Cells(5).Value + "")


                    End If
                Next
                If chkGatepass.Checked = True Then
                    QueryCollection.Add("update control_tbl set gatepass_no=gatepass_no+1 where company_id=" + company_id + "")
                End If

                If gridIndent.Rows.Count = checkcount Then
                    QueryCollection.Add("update indent_hdr set fully_delivered=1 where indent_no='" + indent_no + "'")
                End If
            End If


            Dim result As Boolean = obj.TransactionInsert(QueryCollection)
            Select Case result
                Case True
                    MsgBox("Supply details updated!!", MessageBoxIcon.Information)
                    'S.SetReportsupplyno(supply_no)
                    'ReportScreen.Show()
                    'ReportScreen.BringToFront()
                    If obj.GetOneValueFromQuery("select supplytype from supply_hdr where supply_no='" + supply_no + "'") = "SUPPLY" Then
                        S.SetReportsupplyno(supply_no)
                        ReportScreen.Show()
                        ReportScreen.BringToFront()
                        'ReportScreen.TopMost = True
                    Else
                        S.SetPOSReportSupplyno(supply_no)
                        POSReportScreen.Show()
                        POSReportScreen.BringToFront()
                        'ReportScreen.TopMost = True
                    End If

                Case False
                    MsgBox("Something Went Wrong!!", MessageBoxIcon.Exclamation)
                    Exit Sub
            End Select
            S.ClearSupplyno()
            Me.Controls.Clear()
            InitializeComponent()
            BillOfSupply_Load(e, e)
            
        Catch ex As Exception
            MsgBox("Exception:Caution!!  " + ex.Message + "", MessageBoxIcon.Exclamation)
            Exit Sub
        End Try





      
    End Sub
    Function BeforeUpdateSupply() As Boolean
        Dim InitialTransaction, getdata As New List(Of String)
        Dim dtsupdt, dtbank As New DataTable
        Dim companyid As String = obj.GetOneValueFromQuery("select company_id from supply_hdr where supply_no='" + S.GetSupplyno() + "'")
        dtsupdt = obj.getdatatable("select item_no, item_qty from supply_dtl where supply_no='" + S.GetSupplyno + "'")
        For i = 0 To dtsupdt.Rows.Count - 1
            InitialTransaction.Add("update stock_tbl set qty=qty+" + dtsupdt.Rows(i).Item(1).ToString + " where item_no='" + dtsupdt.Rows(i).Item(0).ToString + "' and company_id=" + companyid + "")
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
                Dim i As Integer = obj.QueryExecution("delete from supply_dtl where supply_no='" + S.GetSupplyno + "'")
                Return If(i >= 1, True, False)
            Case False
                Return False
        End Select
    End Function
    Private Sub chkGatepass_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkGatepass.CheckedChanged
        Select Case chkGatepass.Checked
            Case True
                pnlGatepass.Visible = True
                Me.txtgatepass.Text = obj.GetOneValueFromQuery("select gatepass_frmt&''&gatepass_no from control_tbl where company_id=" + SharedData.companyid + "")
            Case False
                pnlGatepass.Visible = False
        End Select
    End Sub

    Private Sub rbtPaid_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbtPaid.CheckedChanged
        Select Case rbtPaid.Checked
            Case True
                pnlCreditDays.Visible = False
                Label28.Visible = True
                Label40.Visible = True
                cmbPaymode.Visible = True
            Case False
                pnlCreditDays.Visible = True
                Label28.Visible = False
                Label40.Visible = False
                cmbPaymode.Visible = False
                pnlBankdtls.Visible = False
        End Select
    End Sub
    Private Sub txtClientName_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtClientName.KeyPress
        lstbxClientNm.Visible = True
    End Sub

    Private Sub txtItemNm_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtItemNm.KeyPress
        lstbxItemName.Visible = True
    End Sub

 

   
    Private Sub txtCusname_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtClientName.KeyUp
        Dim listvendorname As New DataTable
        lstbxClientNm.DataSource = Nothing
        lblcuscode.Text = ""
        If txtClientName.Text = "" Then
            lstbxClientNm.Visible = False
        Else

            listvendorname = obj.getdatatable("select top 1 'Add New' as company_name,'0' as contact_no from contact_tbl union select company_name,contact_no from contact_tbl where company_name like '%" + txtClientName.Text + "%'")
            lstbxClientNm.DisplayMember = "company_name"
            lstbxClientNm.ValueMember = "contact_no"
            lstbxClientNm.DataSource = listvendorname
            lstbxClientNm.Visible = True
        End If
    End Sub
    Private Sub lstbxClientNm_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lstbxClientNm.MouseClick
        lstbxClientNm.Visible = False
        If lstbxClientNm.Text = "Add New" Then
            Contacts.Show()
            Contacts.BringToFront()
            Contacts.Focus()
        Else
            Try
                lblcuscode.Text = lstbxClientNm.SelectedValue
                txtClientAddress.Text = obj.GetOneValueFromQuery("select ship_address from contact_tbl where contact_no='" + lstbxClientNm.SelectedValue + "'")
                txtplsupply.Text = obj.GetOneValueFromQuery("select place_supply from contact_tbl where contact_no='" + lstbxClientNm.SelectedValue + "'")
               
                lstbxClientNm.Visible = False
                txtClientName.Text = lstbxClientNm.Text

            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub txtItmName_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtItemNm.KeyUp
        Dim listitemname As New DataTable
        lstbxItemName.DataSource = Nothing
        If txtItemNm.Text = "" Then
            lstbxItemName.Visible = False
        Else
            listitemname = obj.getdatatable("select top 1 'Add New' as item_name,'0' as item_no from item_tbl union select item_name,item_no from item_tbl where item_name like '%" + txtItemNm.Text + "%'")

            lstbxItemName.DisplayMember = "item_name"
            lstbxItemName.ValueMember = "item_no"
            lstbxItemName.DataSource = listitemname
            lstbxItemName.Visible = True

        End If
    End Sub
    Private Sub lstItmName_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lstbxItemName.MouseClick
        lstbxItemName.Visible = False
        If lstbxItemName.Text = "Add New" Then
            Items.Show()
            Items.BringToFront()
            Items.Focus()
        Else
            Try
                If lblcuscode.Text = "" Then
                    MsgBox("Please Select Customer Name")
                    Exit Sub
                End If
                txtItemNm.Text = lstbxItemName.Text
                Dim itemdata As New List(Of String)
                itemdata = obj.GetMoreValueFromQuery("select uom,sale_rate,cess,igst from item_tbl where item_no='" + lstbxItemName.SelectedValue + "'", 4)
                cmbUom.Text = itemdata(0)
                txtRate.Text = itemdata(1)
                txtQty.Text = "1"
                txtItmDisc.Text = "0"


                lblstock.Text = obj.GetOneValueFromQuery("select qty from stock_tbl where item_no='" + lstbxItemName.SelectedValue + "' and company_id=" & SharedData.companyid & "")
                lblstock.Visible = True
                lbldspstock.Visible = True
                lstbxItemName.Visible = False
            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub dtpInvDt_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpInvDt.ValueChanged
        txtInvDt.Text = Me.dtpInvDt.Value.Date.ToString("dd/MM/yyyy")
    End Sub

    Private Sub btnAddToGrid_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddToGrid.Click
        GridInvoice.ClearSelection()
        Try
            Dim Amount As Double
            Amount = CDbl(txtQty.Text) * CDbl(txtRate.Text)
            Amount = Amount - obj.FdPercCalc(Amount, Me.txtItmDisc.Text)
            itemdatatable.Rows.Add(Me.txtItemNm.Text, lstbxItemName.SelectedValue, txtDesc.Text,
                                   txtQty.Text, cmbUom.Text, Me.txtRate.Text, Me.txtItmDisc.Text, Amount )
            GridInvoice.DataSource = itemdatatable
            If GridInvoice.Columns.Count = 10 Then
            Else
                Dim btn As New DataGridViewButtonColumn
                btn.Name = "edit"
                btn.HeaderText = ""
                btn.Text = "EDIT"
                btn.UseColumnTextForButtonValue = True
                GridInvoice.Columns.Add(btn)

                Dim btn1 As New DataGridViewButtonColumn
                btn1.Name = "delete"
                btn1.HeaderText = ""
                btn1.Text = "DELETE"
                btn1.UseColumnTextForButtonValue = True
                GridInvoice.Columns.Add(btn1)
            End If
            GridInvoice.AutoGenerateColumns = False
            GridInvoice.AllowUserToAddRows = False
            GridInvoice.Columns(1).Visible = False
            GridInvoice.Columns(0).ReadOnly = True
            GridInvoice.Columns(2).ReadOnly = True
            GridInvoice.Columns(3).ReadOnly = True
            GridInvoice.Columns(4).ReadOnly = True
            GridInvoice.Columns(5).ReadOnly = True
            GridInvoice.Columns(6).ReadOnly = True
            GridInvoice.Columns(7).ReadOnly = True
           

            txtDesc.Text = ""
            txtQty.Text = ""
            cmbUom.Refresh()
            Me.txtRate.Text = "0"
            Me.txtItmDisc.Text = "0"
            txtItemNm.Text = ""
            lblstock.Text = "0"
            GetGrandAmt()
        Catch ex As Exception

        End Try
    End Sub
    Sub CalculationArea()
        Dim SubTotal, GrandAmt As Double
        Dim totamt, discpercent, totamtwithdisc As Double
        SubTotal = 0
      
        GrandAmt = 0

        For i = 0 To GridInvoice.Rows.Count - 1
            totamt = CDbl(GridInvoice.Rows(i).Cells(7).Value.ToString())
            discpercent = CDbl(GridInvoice.Rows(i).Cells(6).Value.ToString())
           
            totamtwithdisc = (totamt) ' - obj.FdPercCalc(totamt, discpercent))
            SubTotal = SubTotal + totamtwithdisc
            GrandAmt = GrandAmt + totamtwithdisc 
        Next
        lblSubTotal.Text = obj.twopt(SubTotal)
        lblGrandTot.Text = obj.twopt(GrandAmt)
        lbloriamt.Text = obj.twopt(GrandAmt)
    End Sub
    Sub GetGrandAmt()
        CalculationArea()
        Dim calcgrandamt As Double = 0
        'If chkRvrsChrg.Checked = True Then
        '    calcgrandamt = Me.lblSubTotal.Text
        'Else
        '    calcgrandamt = Me.lbloriamt.Text
        'End If
        calcgrandamt = lbloriamt.Text
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
        Dim Advanceamt As Double = 0
        If chkAddadvance.Checked = True Then
            For i = 0 To gridAdvance.Rows.Count - 1
                If CBool(gridAdvance.Rows(i).Cells(0).Value) = True Then
                    Advanceamt = Advanceamt + CDbl(gridAdvance.Rows(i).Cells(3).Value)
                End If
            Next
            calcgrandamt = calcgrandamt - Advanceamt
        End If

        Me.lblGrandTot.Text = obj.twopt(calcgrandamt)
        Me.lblAdvanceTot.Text = obj.twopt(Advanceamt)
    End Sub

    Private Sub txtIntendNo_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtIntendNo.KeyUp
        Try

      
        Dim listitemname As New DataTable
            lstbxItemName.DataSource = Nothing
            If Me.lblcuscode.Text = "" Then
                MsgBox("Customer Name is required !!!")
                Exit Sub
            End If
        If txtIntendNo.Text = "" Then
            gridIndent.DataSource = Nothing
        Else

            Dim dtnew, dtold As New DataTable
            dtnew.Columns.Add("check", GetType(Boolean))
            dtnew.Columns.Add("ItemName", GetType(String))
            dtnew.Columns.Add("Description", GetType(String))
            dtnew.Columns.Add("Qty", GetType(String))
            dtnew.Columns.Add("intend_no", GetType(String))
            dtnew.Columns.Add("ID", GetType(String))
              
                'dtold = obj.getdatatable("select item_name as ItemName,	item_desc as Description,qty as Qty,indent_no,ID  from indent_dtl where indent_no like '%" + txtIntendNo.Text + "%' and bill_flg=0 and gatepass_flg=0")

                dtold = obj.getdatatable("select a.item_name as ItemName,a.item_desc as Description,a.qty as Quantity," & _
                                             "a.indent_no,a.ID,a.bill_flg from indent_dtl a,indent_hdr b" & _
                                             " where a.indent_no=b.indent_no and  b.contact_no = '" + lblcuscode.Text + "' " & _
                                             "and a.bill_flg=0 and a.gatepass_flg=0 and a.indent_no like '%" + txtIntendNo.Text + "%'")


                For i = 0 To dtold.Rows.Count - 1
                    dtnew.Rows.Add(False, dtold.Rows(i).Item(0).ToString, dtold.Rows(i).Item(1).ToString, dtold.Rows(i).Item(2).ToString, dtold.Rows(i).Item(3).ToString, dtold.Rows(i).Item(4).ToString)
                Next
                gridIndent.DataSource = dtnew
                gridIndent.AutoGenerateColumns = False
                gridIndent.AllowUserToAddRows = False
                gridIndent.Columns(1).ReadOnly = True
                gridIndent.Columns(2).ReadOnly = True
                gridIndent.Columns(3).ReadOnly = True
                gridIndent.Columns(4).Visible = False
                gridIndent.Columns(5).Visible = False


            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub gridAdvance_CellContentClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridAdvance.CellContentClick
        gridAdvance.CommitEdit(DataGridViewDataErrorContexts.Commit)
        If e.ColumnIndex = 0 Then
            GetGrandAmt()
        End If
    End Sub

    Private Sub KeyUpCalculation(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtRndof.KeyUp, txtShpCost.KeyUp, txtOvralDisc.KeyUp
        GetGrandAmt()
    End Sub
    Private Sub KeyPresevent(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtRndof.KeyPress, txtShpCost.KeyPress, txtOvralDisc.KeyPress
        obj.OnlyNoS(e)
    End Sub


   
    Private Sub GridInvoice_CellContentClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GridInvoice.CellContentClick
        If e.ColumnIndex = 8 Then
            Me.txtItemNm.SelectedText = GridInvoice.Rows(e.RowIndex).Cells(0).Value.ToString()
            lstbxItemName.SelectedValue = GridInvoice.Rows(e.RowIndex).Cells(1).Value.ToString()
            txtDesc.Text = GridInvoice.Rows(e.RowIndex).Cells(2).Value.ToString()
            txtQty.Text = GridInvoice.Rows(e.RowIndex).Cells(3).Value.ToString()
            cmbUom.Text = GridInvoice.Rows(e.RowIndex).Cells(4).Value.ToString()
            Me.txtRate.Text = GridInvoice.Rows(e.RowIndex).Cells(5).Value.ToString()
            Me.txtItmDisc.Text = GridInvoice.Rows(e.RowIndex).Cells(6).Value.ToString()


            lblstock.Text = obj.GetOneValueFromQuery("select qty from stock_tbl where item_no='" + GridInvoice.Rows(e.RowIndex).Cells(1).Value.ToString() + "' and company_id=" & SharedData.companyid & "")
            Dim index As Integer
            index = e.RowIndex
            GridInvoice.Rows.RemoveAt(index)
            GetGrandAmt()
        End If
        If e.ColumnIndex = 9 Then
            Dim index As Integer
            index = e.RowIndex
            GridInvoice.Rows.RemoveAt(index)
            GetGrandAmt()
        End If
    End Sub

    
    Private Sub cmbAccType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbAccType.SelectedIndexChanged
        'cmbaccname.Items.Clear()
        cmbaccname.DataSource = Nothing
        Dim acclist As New DataTable
        acclist = obj.getdatatable("select account_head,ID from account_tbl where account_type='" + cmbAccType.Text + "'")
        cmbaccname.DisplayMember = "account_head"
        cmbaccname.ValueMember = "ID"
        cmbaccname.DataSource = acclist
    End Sub

    Private Sub dtpChqDt_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpChqDt.ValueChanged
        txtChqdt.Text = Me.dtpChqDt.Value.Date.ToString("dd/MM/yyyy")
    End Sub

    Private Sub lnklblEditAddress_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnklblEditAddress.LinkClicked
        obj.ContactOpen()
    End Sub
    Private Sub txtquotno_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtInvoiceno.KeyPress, txtRefNo.KeyPress
        obj.NoApos(e)
    End Sub
End Class