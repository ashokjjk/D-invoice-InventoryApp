
Imports System.Windows.Forms
Imports System.Drawing
Public Class posuser1
    Dim obj As New ObjClass
    Dim S As New SharedData
    Dim itemdatatable As New DataTable

    Private Sub Pos_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        Timer1.Stop()
    End Sub
    Private Sub Pos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Me.Load


        If S.GetPOSno() <> "" Then
            EditFunction()
        Else
            OnloadFunction()

        End If

        Timer1.Start()
    End Sub
    Sub OnloadFunction()

        lstbxitems.Visible = False
        pnlsettings.Visible = False
        txtbxitems.Focus()
        itemdatatable.Rows.Clear()
        gridItems.DataSource = itemdatatable


        cmbUom.Items.Clear()
        cmbItemTax.Items.Clear()
        Dim getdata As New List(Of String)
        getdata = obj.GetMoreValueFromQuery("select cashier_name,counter_no from user_tbl where user_name='" + SharedData.userid + "'", 2)
        Me.txtCounterNo.Text = getdata(1)
        Me.txtcashiername.Text = getdata(0)
        Me.txtsysname.Text = System.Net.Dns.GetHostName()
        Me.txtsysip.Text = System.Net.Dns.GetHostByName(System.Net.Dns.GetHostName()).AddressList(0).ToString()
        Me.txtDate.Text = Format(Today, "dd/MM/yyyy")
        Dim uomlist, taxdesc As New List(Of String)
        uomlist = obj.getcolumndatafromquery("select unit_desc from uom_tbl")
        taxdesc = obj.getcolumndatafromquery("select distinct gst_rate from gst_tbl")
        For i = 0 To uomlist.Count - 1
            cmbUom.Items.Add(uomlist(i))
        Next
        For i = 0 To taxdesc.Count - 1
            cmbItemTax.Items.Add(taxdesc(i))
        Next



        txtInvNo.Text = obj.GetOneValueFromQuery("select invoice_frmt&''&invoice_no from control_tbl where company_id=" + SharedData.companyid + "")

        Try
            itemdatatable.Columns.Add("Item Name".ToString())
            itemdatatable.Columns.Add("Item No".ToString())
            itemdatatable.Columns.Add("Qty".ToString())
            itemdatatable.Columns.Add("UOM".ToString())
            itemdatatable.Columns.Add("Rate".ToString())
            itemdatatable.Columns.Add("Disc".ToString())
            itemdatatable.Columns.Add("Value".ToString())
            itemdatatable.Columns.Add("Tax".ToString())
            itemdatatable.Columns.Add("Cess".ToString())
        Catch ex As Exception

        End Try
        gridItems.ColumnHeadersDefaultCellStyle.Font = New Font("Century Gothic", 7, FontStyle.Bold)

        obj.TodayDate(txtDate)



    End Sub
    Sub EditFunction()
        OnloadFunction()
        Dim dtsupitems As New DataTable
        Dim getdata As New List(Of String)
        dtsupitems = obj.getdatatable("select item_no, item_desc, item_qty, item_uom, item_rate, item_disc, item_amount from invoice_dtl where invoice_no='" + S.GetInvoiceno + "'")
        Dim itemname As String
        For i = 0 To dtsupitems.Rows.Count - 1
            itemname = obj.GetOneValueFromQuery("select item_name from item_tbl where item_no='" + dtsupitems.Rows(i).Item(0).ToString + "'")
            itemdatatable.Rows.Add(itemname, dtsupitems.Rows(i).Item(0).ToString, dtsupitems.Rows(i).Item(1).ToString,
                                   dtsupitems.Rows(i).Item(2).ToString, dtsupitems.Rows(i).Item(3).ToString,
                                   dtsupitems.Rows(i).Item(4).ToString, dtsupitems.Rows(i).Item(5).ToString,
                                   dtsupitems.Rows(i).Item(6).ToString)
        Next

        gridItems.DataSource = itemdatatable
        If gridItems.Columns.Count = 10 Then
        Else
            Dim btn As New DataGridViewButtonColumn
            btn.Name = "edit"
            btn.HeaderText = ""
            btn.Text = "EDIT"
            btn.UseColumnTextForButtonValue = True
            gridItems.Columns.Add(btn)

            Dim btn1 As New DataGridViewButtonColumn
            btn1.Name = "delete"
            btn1.HeaderText = ""
            btn1.Text = "DELETE"
            btn1.UseColumnTextForButtonValue = True
            gridItems.Columns.Add(btn1)
        End If
        gridItems.AutoGenerateColumns = False
        gridItems.AllowUserToAddRows = False
        gridItems.Columns(1).Visible = False

        txtqty.Text = ""
        cmbUom.Refresh()
        Me.txtRate.Text = "0"
        Me.txtDisc.Text = "0"
        txtbxitems.Text = ""
        'lblstock.Text = "0"


        Dim GrandAmt As Double
        Dim totamt, totamtwithdisc As Double

        GrandAmt = 0

        For i = 0 To gridItems.Rows.Count - 1
            totamt = CDbl(gridItems.Rows(i).Cells(7).Value.ToString())
            totamtwithdisc = (totamt) ' - obj.FdPercCalc(totamt, discpercent))

            GrandAmt = GrandAmt + totamtwithdisc
        Next
        lbloriamt.Text = GrandAmt
        getdata = obj.GetMoreValueFromQuery("select user_invoice_no, ref_no, invoice_dt," & _
                                            "system_name,	system_ip,	counter_no , overall_disc_flg, overall_disc_percent, " & _
                                            "overall_disc_amt,  roundoff_flg," & _
                                            " roundoff_amt, payment_status,credit_days customer_notes, internal_notes," & _
                                            " sub_total,tax_amt,cess_amt, grand_total,cash_recieved,customer_savings from invoice_hdr where" & _
                                            " invoice_no='" + S.GetInvoiceno + "'", 21)



        Me.txtInvNo.Text = getdata(0)

        Me.txtClientName.Text = "Cash"

        Me.txtRefno.Text = getdata(1)
        Me.txtDate.Text = Format(CDate(getdata(2)), "dd/MM/yyyy")
        Me.txtsysname.Text = getdata(3)
        Me.txtsysip.Text = getdata(4)
        Me.txtCounterNo.Text = getdata(5)
        Me.txtOverallDisc.Text = getdata(7)
        Me.txtRoundoff.Text = getdata(9)
        'lblSubTot.Text = getdata(19)
        'lblCgst.Text = ""
        'lblSGST.Text = ""
        'lblTax.Text = ""
        'lbloverallDiscAmt.Text = ""
        'lblGrandTot.Text = getdata(20)
        CalculationArea()
        'txtbxitems.Visible = False
    End Sub





    Private Sub txtbx_keyup(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtbxitems.KeyUp
        txtbxitems.Visible = True
        Dim listitemname As New DataTable
        lstbxitems.DataSource = Nothing
        If txtbxitems.Text = "" Then
            'txtbxitems.Visible = False
        Else
            listitemname = obj.getdatatable("select item_name,item_no from item_tbl where item_name like '%" + txtbxitems.Text + "%' and item_type='Goods'")
            lstbxitems.DisplayMember = "item_name"
            lstbxitems.ValueMember = "item_no"
            lstbxitems.DataSource = listitemname
            txtbxitems.Visible = True
            lstbxitems.Visible = True
            lstbxitems.ClearSelected()
            If e.KeyCode = Keys.Up Then
                lstbxitems.Focus()
            ElseIf e.KeyCode = Keys.Down Then
                lstbxitems.Focus()
            ElseIf e.KeyCode = Keys.Enter Then

                Try
                    Dim itemdata As New List(Of String)
                    itemdata = obj.GetMoreValueFromQuery("select uom,sale_rate,cess,igst,item_name from item_tbl where barcode_no='" + Me.txtbxitems.Text + "'", 5)
                    cmbUom.Text = itemdata(0)
                    txtRate.Text = itemdata(1)
                    txtCess.Text = itemdata(2)
                    cmbItemTax.Text = itemdata(3)
                    lstbxitems.Text = itemdata(4)
                    txtqty.Text = "1"
                    txtDisc.Text = "0"
                    btnAdd.Focus()
                    lstbxitems.Visible = False

                    '            Exit Sub
                Catch ex As Exception

                End Try

            End If
        End If

    End Sub



    Private Sub lstbxitems_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles lstbxitems.KeyDown
        If e.KeyCode = Keys.Enter Then

            Try
                txtbxitems.Text = lstbxitems.SelectedValue
                Dim itemdata As New List(Of String)
                itemdata = obj.GetMoreValueFromQuery("select uom,sale_rate,cess,igst,item_name from item_tbl where item_no='" + lstbxitems.SelectedValue + "'", 5)
                cmbUom.Text = itemdata(0)
                txtRate.Text = itemdata(1)
                txtCess.Text = itemdata(2)
                cmbItemTax.Text = itemdata(3)
                txtqty.Text = "1"
                txtDisc.Text = "0"
                txtbxitems.Text = itemdata(4)
                lstbxitems.Visible = False
                btnAdd.Focus()
                Me.PictureBox1.Image = Image.FromStream(New System.IO.MemoryStream(obj.retrievephotofromDB("select item_picture from item_tbl where  item_no=" & _
                  "'" + lstbxitems.SelectedValue + "' and company_id=" + SharedData.companyid + "")))
            Catch ex As Exception

            End Try
        End If


    End Sub

    Private Sub lstbxItems_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lstbxitems.MouseClick
        Try
            txtbxitems.Text = lstbxitems.Text
            Dim itemdata As New List(Of String)
            itemdata = obj.GetMoreValueFromQuery("select uom,sale_rate,cess,igst from item_tbl where item_no='" + lstbxitems.SelectedValue + "'", 4)
            cmbUom.Text = itemdata(0)
            txtRate.Text = itemdata(1)
            txtCess.Text = itemdata(2)
            cmbItemTax.Text = itemdata(3)
            txtqty.Text = "1"
            txtDisc.Text = "0"
            lstbxitems.Visible = False
            Me.PictureBox1.Image = Image.FromStream(New System.IO.MemoryStream(obj.retrievephotofromDB("select item_picture from item_tbl where  item_no=" & _
                   "'" + lstbxitems.SelectedValue + "' and company_id=" + SharedData.companyid + "")))
        Catch ex As Exception

        End Try

    End Sub




    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        pnlsettings.Visible = True
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim i As Integer
        i = obj.QueryExecution("update user_tbl set counter_no ='" + addcounterno.Text + "',cashier_name='" + addcashier.Text + "' where user_name='" + SharedData.userid + "' and company_id=" + SharedData.companyid + "")
        pnlsettings.Visible = False
        Pos_Load(e, e)
    End Sub
    Sub addfunction()
        gridItems.ClearSelection()

        Try
            Dim Amount As Double
            Amount = CDbl(txtqty.Text) * CDbl(txtRate.Text)
            Amount = Amount - obj.FdPercCalc(Amount, Me.txtDisc.Text)
            itemdatatable.Rows.Add(Me.lstbxitems.Text, lstbxitems.SelectedValue,
                                   txtqty.Text, cmbUom.Text, Me.txtRate.Text, Me.txtDisc.Text, Amount,
                                   Me.cmbItemTax.Text, Me.txtCess.Text)
            gridItems.DataSource = itemdatatable
            If gridItems.Columns.Count = 10 Then
            Else
                Dim btn1 As New DataGridViewButtonColumn
                btn1.Name = "delete"
                btn1.HeaderText = ""
                btn1.Text = "DELETE"
                btn1.UseColumnTextForButtonValue = True
                gridItems.Columns.Add(btn1)
            End If
            gridItems.AutoGenerateColumns = False
            gridItems.AllowUserToAddRows = False
            gridItems.Columns(1).Visible = False


            gridItems.Columns(0).ReadOnly = True
            gridItems.Columns(2).ReadOnly = True
            gridItems.Columns(3).ReadOnly = True
            gridItems.Columns(4).ReadOnly = True
            gridItems.Columns(5).ReadOnly = True
            gridItems.Columns(6).ReadOnly = True
            gridItems.Columns(7).ReadOnly = True
            gridItems.Columns(8).ReadOnly = True

            txtqty.Text = ""
            cmbUom.Refresh()
            Me.txtRate.Text = "0"
            Me.txtDisc.Text = "0"
            txtbxitems.Text = ""
            Me.cmbItemTax.Text = "0"
            Me.txtCess.Text = "0"
            CalculationArea()
            gridItems.ClearSelection()
            txtbxitems.Focus()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnAdd_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles btnAdd.KeyDown
        If e.KeyCode = Keys.Enter Then
            addfunction()
        End If
    End Sub




    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        addfunction()
    End Sub

    Private Sub CalculationArea()
        Try
            Dim SubTotal, TaxAmt, CessAmt, GrandAmt, totqty, mrprate, cussave As Double
            Dim totamt, discpercent, taxpercent, cesspercent, totamtwithdisc As Double
            SubTotal = 0
            TaxAmt = 0
            CessAmt = 0
            GrandAmt = 0
            totqty = 0
            cussave = 0
            Dim compositeflg As Integer = obj.GetOneValueFromQuery("select composite_flg from company_tbl where company_id=" + SharedData.companyid + "")
            For i = 0 To gridItems.Rows.Count - 1
                mrprate = If(obj.GetOneValueFromQuery("select mrp from item_tbl where item_no='" + gridItems.Rows(i).Cells(1).Value.ToString() + "'") = "", "0", obj.GetOneValueFromQuery("select mrp from item_tbl where item_no='" + gridItems.Rows(i).Cells(1).Value.ToString() + "'"))
                cussave = (mrprate * CDbl(gridItems.Rows(i).Cells(2).Value.ToString())) - CDbl(gridItems.Rows(i).Cells(6).Value.ToString())
                totamt = CDbl(gridItems.Rows(i).Cells(6).Value.ToString())
                discpercent = CDbl(gridItems.Rows(i).Cells(5).Value.ToString())
                taxpercent = CDbl(gridItems.Rows(i).Cells(7).Value.ToString())
                cesspercent = CDbl(gridItems.Rows(i).Cells(8).Value.ToString())
                totamtwithdisc = (totamt)
                SubTotal = SubTotal + totamtwithdisc
                TaxAmt = TaxAmt + obj.FdPercCalc(totamtwithdisc, taxpercent)
                CessAmt = CessAmt + obj.FdPercCalc(totamtwithdisc, cesspercent)
                GrandAmt = GrandAmt + totamtwithdisc + obj.FdPercCalc(totamtwithdisc, taxpercent) +
                    obj.FdPercCalc(totamtwithdisc, cesspercent)
                totqty = totqty + CDbl(gridItems.Rows(i).Cells(2).Value.ToString())
            Next
            lblTotQty.Text = totqty
            lblTotItm.Text = gridItems.Rows.Count
            lblSubTot.Text = SubTotal
            lblCgst.Text = TaxAmt / 2
            lblSGST.Text = TaxAmt / 2
            lblTax.Text = TaxAmt + CessAmt
            GrandAmt = If(compositeflg = 1, SubTotal, GrandAmt)
            lbloriamt.Text = GrandAmt
            GrandAmt = GrandAmt - obj.FdPercCalc(lbloriamt.Text, txtOverallDisc.Text)
            lbloverallDiscAmt.Text = obj.FdPercCalc(lbloriamt.Text, txtOverallDisc.Text)
            GrandAmt = GrandAmt - CDbl(txtRoundoff.Text)
            lblGrandTot.Text = GrandAmt
            lblBoldGranTotal.Text = GrandAmt
            lblBalanceAmt.Text = CDbl(txtCashRcvd.Text) - GrandAmt
            lblCusSaving.Text = cussave
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtOverallDisc_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtOverallDisc.KeyUp, txtRoundoff.KeyUp, txtCashRcvd.KeyUp
        CalculationArea()
    End Sub
    Private Sub txtOverallDisc_keypress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtOverallDisc.KeyPress, txtRoundoff.KeyPress, txtCashRcvd.KeyPress
        obj.OnlyNoS(e)
    End Sub
    Protected Overrides Function ProcessCmdKey(ByRef msg As System.Windows.Forms.Message, ByVal keyData As Keys) As Boolean
        Select Case msg.Msg
            Case &H100, &H104
                Select Case keyData
                    Case Keys.Alt Or Keys.S
                        ' SaveorPrint("Save")
                        btnSave.PerformClick()
                    Case Keys.Alt Or Keys.P
                        ' SaveorPrint("Print")
                        btnPrint.PerformClick()
                    Case Keys.Alt Or Keys.L
                        Dim listinvoice_no = obj.GetMoreValueFromQuery("select invoice_frmt,invoice_no from control_tbl where company_id=" & SharedData.companyid & "", 2)
                        Dim invoice_no = listinvoice_no(0) + (CInt(listinvoice_no(1)) - 1).ToString
                        S.SetPOSReportInvoiceno(invoice_no)
                        POSReportScreen.Show()
                        POSReportScreen.BringToFront()
                    Case Keys.Alt Or Keys.M
                        gridItems.Rows.Clear()
                        CalculationArea()
                    Case Keys.Alt Or Keys.C
                        btnClear.PerformClick()
                    Case Keys.Alt Or Keys.N
                        Dim f As New Pos
                        f.Show()
                    Case Keys.F7
                        txtRoundoff.Focus()
                    Case Keys.F9
                        txtCashRcvd.Focus()
                    Case Keys.F1
                        txtbxitems.Focus()
                End Select
                Exit Select
        End Select
        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function
    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        SaveorPrint("Print")
        Me.Controls.Clear()
        InitializeComponent()
        Me.Pos_Load(e, e)
        Me.SendToBack()
        POSReportScreen.BringToFront()
        POSReportScreen.Focus()
    End Sub
    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        SaveorPrint("Save")
        Me.Controls.Clear()
        InitializeComponent()
        Me.Pos_Load(e, e)
    End Sub
    Sub SaveorPrint(ByVal type As String)
        Dim invoice_no, user_invoice_no, contact_no, invoice_dt, account_id, place_supply, ref_no, advance_amt, overall_disc_flg, overall_disc_percent, overall_disc_amt, shpcost_flg, shpcost_amt, roundoff_flg, roundoff_amt, customer_notes, internal_notes, sub_total, total_tax, total_cess, grand_total, company_id, user_name As String
        Dim system_name, system_ip, counter_no, indent_flg, indent_no, advance_flg, reverse_flg As String
        Dim item_no, item_desc, item_qty, item_uom, item_rate, item_disc, item_tax, item_cess As String

        Dim payment_status,
 payment_method, cheque_no, cheque_dt, credit_bank_name,
credit_days, cash_recieved, customer_savings As String

        If S.GetPOSno() <> "" Then
            invoice_no = S.GetPOSno()
            Dim b As Boolean = BeforeUpdateInvoice()
            If b = False Then
                MsgBox("Error")
                Exit Sub
            End If
        Else
            invoice_no = obj.GetOneValueFromQuery("select invoice_frmt&''&invoice_no from control_tbl where company_id=" + SharedData.companyid + "")
        End If
        user_invoice_no = invoice_no
        contact_no = "0"

        invoice_dt = Format(CDate(Me.txtDate.Text), "dd/MM/yyyy")
        place_supply = obj.GetOneValueFromQuery("select billing_state from company_tbl where company_id=" + SharedData.companyid + "")
        ref_no = txtRefno.Text
        customer_notes = Me.txtNotes.Text
        internal_notes = ""
        company_id = SharedData.companyid
        user_name = SharedData.userid
        account_id = "13"
        overall_disc_flg = 1
        shpcost_flg = 0
        roundoff_flg = 1

        overall_disc_percent = Me.txtOverallDisc.Text


        advance_flg = 1
        advance_amt = 0
        overall_disc_amt = lbloverallDiscAmt.Text
        shpcost_amt = "0"
        roundoff_amt = txtRoundoff.Text

        sub_total = lblSubTot.Text
        total_tax = CDbl(lblCgst.Text) + CDbl(lblSGST.Text)
        total_cess = CDbl(lblTax.Text) - total_tax
        grand_total = lblGrandTot.Text


        system_name = Me.txtsysname.Text
        system_ip = txtsysip.Text
        counter_no = txtCounterNo.Text

        payment_method = "Cash"
        payment_status = 1
        cheque_no = ""
        cheque_dt = "01/01/1900"
        credit_bank_name = "0"
        credit_days = 0
        cash_recieved = Me.txtCashRcvd.Text
        reverse_flg = 0
        customer_savings = Me.lblCusSaving.Text
        advance_flg = 0
        indent_flg = 0
        indent_no = ""

        Dim voucher_no, voucher_user_no, voucher_dt, voucher_type As String
        voucher_no = obj.GetOneValueFromQuery("select voucher_frmt&''&voucher_no from control_tbl where company_id=" + SharedData.companyid + "")
        voucher_user_no = voucher_no
        voucher_dt = invoice_dt
        voucher_type = "B2B"

        Dim item_amount, cess_amt, tax_amt, disc_amt As Double
        Dim QueryCollection As New List(Of String)
        For i = 0 To gridItems.Rows.Count - 1

            item_no = gridItems.Rows(i).Cells(1).Value.ToString()
            item_qty = gridItems.Rows(i).Cells(2).Value.ToString()
            item_uom = gridItems.Rows(i).Cells(3).Value.ToString()
            item_rate = gridItems.Rows(i).Cells(4).Value.ToString()
            item_disc = gridItems.Rows(i).Cells(5).Value.ToString()
            item_tax = gridItems.Rows(i).Cells(7).Value.ToString()
            item_cess = gridItems.Rows(i).Cells(8).Value.ToString()
            item_amount = gridItems.Rows(i).Cells(6).Value.ToString()
            cess_amt = obj.FdPercCalc(item_amount, item_cess)
            tax_amt = obj.FdPercCalc(item_amount, item_tax)
            disc_amt = obj.FdPercCalc(item_amount, item_disc)

            QueryCollection.Add("insert into invoice_dtl(invoice_no,item_no, item_desc, item_qty, item_uom, item_rate, item_disc, item_tax, item_cess, item_amount, cess_amt, tax_amt, disc_amt) values" & _
                           "('" + invoice_no + "','" + item_no + "','" + item_desc + "'," & item_qty & ",'" + item_uom + "'" & _
"," & item_rate & "," & item_disc & "," & item_tax & "," & item_cess & "" & _
"," & item_amount & "," & cess_amt & "," & tax_amt & "," & disc_amt & ")")
            QueryCollection.Add("update stock_tbl set  qty=qty-" & item_qty & "	where item_no='" + item_no + "' and company_id=" + company_id + "")

        Next
        QueryCollection.Add("update bank_tbl set  pettycash_closingBalance=pettycash_closingBalance+" & cash_recieved & "	where  company_id=" + company_id + "")

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
        If S.GetPOSno() <> "" Then
            QueryCollection.Add("update invoice_hdr set user_invoice_no='" + user_invoice_no + "', " & _
                               " contact_no='" + contact_no + "', invoice_dt='" + invoice_dt + "'," & _
                               "  place_supply='" + place_supply + "'," & _
                               " ref_no='" + ref_no + "', account_id='" + account_id + "'," & _
                               "  indent_flg=" & indent_flg & ", indent_no='" + indent_no + "'," & _
                               "  advance_flg=" & advance_flg & ", overall_disc_flg=" & overall_disc_flg & ", " & _
                               "overall_disc_percent=" & overall_disc_percent & ", overall_disc_amt=" & overall_disc_amt & "," & _
                               "  shpcost_flg=" & shpcost_flg & ", shpcost_amt=" & shpcost_amt & "," & _
                               "  roundoff_flg=" & roundoff_flg & "," & _
                               " roundoff_amt=" & roundoff_amt & ", payment_status=" & payment_status & "," & _
                               "  payment_method='" + payment_method + "', cheque_no='" + cheque_no + "', " & _
                               " cheque_dt='" + cheque_dt + "', credit_bank_name='" + credit_bank_name + "'," & _
                               " credit_days=" & credit_days & ", customer_notes='" + obj.inapos(customer_notes) + "', " & _
                               " internal_notes='" + internal_notes + "', sub_total=" & sub_total & "," & _
                               " advance_amt=" & advance_amt & ", grand_total=" & grand_total & ", " & _
                               "company_id=" & company_id & ", user_name='" + user_name + "'," & _
                               " cash_paid=" & grand_total & ",voucher_flg=" & payment_status & "," & _
                               " voucher_no='" + If(payment_status = 1, voucher_no, "") + "'," & _
                               "total_tax=" & total_tax & ",	total_cess=" & total_cess & "" & _
                               " where invoice_no='" + invoice_no + "'")
        Else
            QueryCollection.Add("insert into invoice_hdr(invoice_no,	user_invoice_no,	contact_no,	invoice_dt,	place_supply,	ref_no,	account_id,	" & _
"invoice_type,	system_name,	system_ip,	counter_no	,indent_flg,	indent_no,	advance_flg,	reverse_flg," & _
"overall_disc_flg,	overall_disc_percent,	overall_disc_amt,	" & _
"shpcost_flg,	shpcost_amt,	roundoff_flg,	roundoff_amt,	payment_status," & _
"payment_method,	cheque_no,	cheque_dt,	credit_bank_name,	" & _
"credit_days,	customer_notes,	internal_notes	,sub_total,	total_tax,	total_cess," & _
"	grand_total,	cash_recieved,	customer_savings,	company_id,	user_name,voucher_no) values( " & _
                           "'" + invoice_no + "','" + user_invoice_no + "'," & _
                      "'" + contact_no + "','" + invoice_dt + "'," & _
                      "'" + place_supply + "','" + ref_no + "','" + account_id + "','POS','" + system_name + "'," & _
                      "'" + system_ip + "','" + counter_no + "'," + indent_flg + ",'" + indent_no + "'," & _
                      "" + advance_flg + "," + reverse_flg + "," & overall_disc_flg & "," & _
                      "" & overall_disc_percent & "," & overall_disc_amt & "," & shpcost_flg & "," & _
                      "" & shpcost_amt & "," & roundoff_flg & "," & roundoff_amt & "," + payment_status + "," & _
                      "'" + payment_method + "','" + cheque_no + "','" + cheque_dt + "'," & _
                      "'" + credit_bank_name + "'," + credit_days + ",'" + obj.inapos(customer_notes) + "','" + internal_notes + "'," & sub_total & "," & _
                      "" & total_tax & "," & total_cess & "," & grand_total & "," + cash_recieved + "," + customer_savings + "," & _
                      "" + company_id + ",'" + user_name + "','" + If(payment_status = 1, voucher_no, "") + "')")
            QueryCollection.Add("update control_tbl set invoice_no=invoice_no+1 where company_id=" + company_id + "")
        End If


        Dim result As Boolean = obj.TransactionInsert(QueryCollection)
        Select Case result
            Case True
                If (type = "Print") Then
                    S.SetPOSReportInvoiceno(invoice_no)
                    POSReportScreen.Show()
                    POSReportScreen.BringToFront()
                End If

                If (type = "Save") Then
                    MsgBox("Bill details updated!!", MessageBoxIcon.Information)
                End If
            Case False
                MsgBox("Something Went Wrong!!", MessageBoxIcon.Exclamation)
                Exit Sub
        End Select


    End Sub
    Function BeforeUpdateInvoice() As Boolean
        Dim InitialTransaction, getdata As New List(Of String)
        Dim dtsupdt, dtbank As New DataTable
        Dim companyid As String = obj.GetOneValueFromQuery("select company_id from invoice_hdr where invoice_no='" + S.GetPOSno() + "'")
        dtsupdt = obj.getdatatable("select item_no, item_qty from invoice_dtl where invoice_no='" + S.GetPOSno + "'")
        For i = 0 To dtsupdt.Rows.Count - 1
            InitialTransaction.Add("update stock_tbl set qty=qty+" + dtsupdt.Rows(i).Item(1).ToString + " where item_no='" + dtsupdt.Rows(i).Item(0).ToString + "' and company_id=" + companyid + "")
        Next
        Dim result As Boolean = obj.TransactionInsert(InitialTransaction)
        Select Case result
            Case True
                Dim i As Integer = obj.QueryExecution("delete from invoice_dtl where invoice_no='" + S.GetPOSno + "'")
                Return If(i >= 1, True, False)
            Case False
                Return False
        End Select
    End Function


    Private Sub gridItems_CellContentClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridItems.CellContentClick

        If e.ColumnIndex = 9 Then
            Dim index As Integer
            index = e.RowIndex
            gridItems.Rows.RemoveAt(index)
            CalculationArea()
        End If
    End Sub

    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        Me.Controls.Clear()
        InitializeComponent()
        Me.Pos_Load(e, e)

        'S.SetPOSReportInvoiceno("DAR/INV/6")
        'POSReportScreen.Show()
        'POSReportScreen.BringToFront()
        'POSReportScreen.TopMost = True
    End Sub

    Private Sub btnRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemove.Click
        Try


            gridItems.Rows.Clear()
            CalculationArea()
        Catch ex As Exception

        End Try
    End Sub



    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        lbldttime.Text = Now
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim listinvoice_no = obj.GetMoreValueFromQuery("select invoice_frmt,invoice_no from control_tbl where company_id=" & SharedData.companyid & "", 2)
        Dim invoice_no = listinvoice_no(0) + (CInt(listinvoice_no(1)) - 1).ToString
        S.SetPOSReportInvoiceno(invoice_no)
        POSReportScreen.Show()
        POSReportScreen.BringToFront()
    End Sub


    Private Sub Add_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Add.Click
        Dim f As New Pos
        f.Show()
    End Sub


End Class
