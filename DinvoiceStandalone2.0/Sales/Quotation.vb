Public Class Quotation
    Dim obj As New ObjClass
    Dim S As New SharedData
    Dim itemdatatable As New DataTable
    Private Sub Quotation_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtCusname.Focus()
        If S.GetQuotationno() <> "" Then
            EditFunction()
        Else
            OnloadFunction()
        End If
    End Sub
    Sub EditFunction()
        MaximizeBox = False
        MinimizeBox = False
        lstbxCusName.Visible = False
        lstItmName.Visible = False
        txtRndof.Visible = False
        txtOvralDisc.Visible = False
        txtShpCost.Visible = False

        itemdatatable.Rows.Clear()
        GridPurchaseData.DataSource = itemdatatable
        Me.lblSubTotal.Text = ""
        Me.lblTotax.Text = ""
        Me.lblTotCess.Text = ""
        Me.lblGrantTot.Text = ""
        Me.lbloriamt.Text = ""
        Me.lblcuscode.Text = ""

        cmbUom.Items.Clear()
        cmbItemTax.Items.Clear()



        Dim uomlist, taxdesc As New List(Of String)
        uomlist = obj.getcolumndatafromquery("select unit_desc from uom_tbl")
        taxdesc = obj.getcolumndatafromquery("select distinct gst_rate from gst_tbl")


        For i = 0 To uomlist.Count - 1
            cmbUom.Items.Add(uomlist(i))
        Next
        For i = 0 To taxdesc.Count - 1
            cmbItemTax.Items.Add(taxdesc(i))
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
        Dim dtQuotitems As New DataTable

        dtQuotitems = obj.getdatatable("select item_no, item_desc, item_qty, item_uom, item_rate, item_disc, item_amount, item_tax, item_cess from quotation_dtl where quotation_no='" + S.GetQuotationno + "'")
        Dim itemname As String
        For i = 0 To dtQuotitems.Rows.Count - 1
            itemname = obj.GetOneValueFromQuery("select item_name from item_tbl where item_no='" + dtQuotitems.Rows(i).Item(0).ToString + "'")
            itemdatatable.Rows.Add(itemname, dtQuotitems.Rows(i).Item(0).ToString, dtQuotitems.Rows(i).Item(1).ToString,
                                   dtQuotitems.Rows(i).Item(2).ToString, dtQuotitems.Rows(i).Item(3).ToString,
                                   dtQuotitems.Rows(i).Item(4).ToString, dtQuotitems.Rows(i).Item(5).ToString,
                                   dtQuotitems.Rows(i).Item(6).ToString, dtQuotitems.Rows(i).Item(7).ToString,
                                   dtQuotitems.Rows(i).Item(8).ToString)
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
        Dim getdata As New List(Of String)
        getdata = obj.GetMoreValueFromQuery("select user_quotation_no,contact_no,quotation_dt," & _
                                            "validuntil_dt,place_supply,ref_no,overall_disc_flg," & _
                                            "overall_disc_percent,shpcost_flg,shpcost_amt,roundoff_flg," & _
                                            "roundoff_amt,customer_notes,internal_notes,sub_total,total_tax,total_cess," & _
                                            "grand_total from quotation_hdr where quotation_no='" + S.GetQuotationno() + "'", 18)
        txtquotno.Text = getdata(0)
        lblcuscode.Text = getdata(1)
        Dim subgetdata1 As New List(Of String)
        subgetdata1 = obj.GetMoreValueFromQuery("select company_name,billing_address from contact_tbl where contact_no='" + getdata(1) + "'", 2)

        Me.txtCusname.Text = subgetdata1(0)
        Me.txtVendorAddress.Text = subgetdata1(1)

        txtPurDt.Text = Format(CDate(getdata(2)), "dd/MM/yyyy")
        txtquotvaliddt.Text = Format(CDate(getdata(3)), "dd/MM/yyyy")
        txtplsupply.Text = getdata(4)
        txtrefno.Text = getdata(5)



        Me.txtVendorNotes.Text = getdata(12)
        Me.txtInternalNotes.Text = getdata(13)


        If getdata(6) = "1" Then
            chkOvralDisc.Checked = True
        Else
            chkOvralDisc.Checked = False
        End If
        If getdata(8) = "1" Then
            chkShpCost.Checked = True
        Else
            chkShpCost.Checked = False
        End If
        If getdata(10) = "1" Then
            chkRndOff.Checked = True
        Else
            chkRndOff.Checked = False
        End If
        Me.txtOvralDisc.Text = getdata(7)
        txtShpCost.Text = getdata(9)
        txtRndof.Text = getdata(11)
        lblSubTotal.Text = getdata(14)
        lblTotax.Text = getdata(15)
        lblTotCess.Text = getdata(16)
        lblGrantTot.Text = getdata(17)

        lstbxCusName.Visible = False
        lstItmName.Visible = False


    End Sub
    Sub OnloadFunction()
        MaximizeBox = False
        MinimizeBox = False
        lstbxCusName.Visible = False
        lstItmName.Visible = False
        txtRndof.Visible = False
        txtOvralDisc.Visible = False
        txtShpCost.Visible = False
        txtCusname.Focus()
        itemdatatable.Rows.Clear()
        GridPurchaseData.DataSource = itemdatatable
        Me.lblSubTotal.Text = ""
        Me.lblTotax.Text = ""
        Me.lblTotCess.Text = ""
        Me.lblGrantTot.Text = ""
        Me.lbloriamt.Text = ""
        Me.lblcuscode.Text = ""

        cmbUom.Items.Clear()
        cmbItemTax.Items.Clear()
        obj.TodayDate(txtPurDt)


        Dim uomlist, taxdesc As New List(Of String)
        uomlist = obj.getcolumndatafromquery("select unit_desc from uom_tbl")
        taxdesc = obj.getcolumndatafromquery("select distinct gst_rate from gst_tbl")


        For i = 0 To uomlist.Count - 1
            cmbUom.Items.Add(uomlist(i))
        Next
        For i = 0 To taxdesc.Count - 1
            cmbItemTax.Items.Add(taxdesc(i))
        Next



        txtquotno.Text = obj.GetOneValueFromQuery("select quotation_frmt&''&quotation_no from control_tbl where company_id=" + SharedData.companyid + "")

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
    Private Sub txtCusname_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCusname.KeyPress
        lstbxCusName.Visible = True
    End Sub



    Private Sub txtItmName_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtItmName.KeyPress
        lstItmName.Visible = True
    End Sub



    Private Sub btnMakBil_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMakBil.Click

        Dim quotation_no, user_quotation_no, contact_no, quotation_dt, validuntil_dt, place_supply, ref_no, account_id, overall_disc_flg, overall_disc_percent, overall_disc_amt, shpcost_flg, shpcost_amt, roundoff_flg, roundoff_amt, customer_notes, internal_notes, sub_total, total_tax, total_cess, grand_total, company_id, user_name As String

        Dim item_no, item_desc, item_qty, item_uom, item_rate, item_disc, item_tax, item_cess As String

        Try


            If S.GetQuotationno() <> "" Then
                quotation_no = S.GetQuotationno()
                Dim b As Boolean = BeforeUpdateQuotation()
                If b = False Then
                    MsgBox("Error while Updating")
                    Exit Sub
                End If
            Else
                quotation_no = obj.GetOneValueFromQuery("select quotation_frmt&''&quotation_no from control_tbl where company_id=" + SharedData.companyid + "")

            End If

            user_quotation_no = txtquotno.Text
            contact_no = lblcuscode.Text

            quotation_dt = Format(CDate(Me.txtPurDt.Text), "dd/MM/yyyy")
            Try
                validuntil_dt = Format(CDate(Me.txtquotvaliddt.Text), "dd/MM/yyyy")
            Catch ex As Exception
                validuntil_dt = "01/01/1900"
            End Try

            place_supply = txtplsupply.Text
            ref_no = txtrefno.Text



            customer_notes = Me.txtVendorNotes.Text
            internal_notes = Me.txtInternalNotes.Text
            company_id = SharedData.companyid
            user_name = SharedData.userid

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
            txt.Add(user_quotation_no)
            txt.Add(quotation_dt)


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


            Dim item_amount, cess_amt, tax_amt, disc_amt As Double
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
                QueryCollection.Add("insert into quotation_dtl(quotation_no,item_no, item_desc, item_qty, item_uom, item_rate, item_disc, item_tax, item_cess, item_amount, cess_amt, tax_amt, disc_amt) values" & _
                               "('" + quotation_no + "','" + item_no + "','" + item_desc + "'," & item_qty & ",'" + item_uom + "'" & _
    "," & item_rate & "," & item_disc & "," & item_tax & "," & item_cess & "" & _
    "," & item_amount & "," & cess_amt & "," & tax_amt & "," & disc_amt & ")")

            Next
            If S.GetQuotationno() <> "" Then
                QueryCollection.Add("update quotation_hdr set  user_quotation_no='" + user_quotation_no + "'," & _
                                " contact_no='" + contact_no + "', quotation_dt='" + quotation_dt + "', " & _
                                "validuntil_dt='" + validuntil_dt + "', place_supply='" + place_supply + "'," & _
                                " ref_no='" + ref_no + "', overall_disc_flg=" & overall_disc_flg & ",  " & _
                                "overall_disc_percent=" & overall_disc_percent & "," & _
                                " overall_disc_amt=" & overall_disc_amt & ", shpcost_flg=" & shpcost_flg & "," & _
                                " shpcost_amt=" & shpcost_amt & ",  " & _
                                "roundoff_flg=" & roundoff_flg & ", roundoff_amt=" & roundoff_amt & ", " & _
                                "customer_notes='" + obj.inapos(customer_notes) + "', internal_notes='" + obj.inapos(internal_notes) + "'," & _
                                " sub_total=" & sub_total & ", " & _
                                " total_tax=" & total_tax & ", total_cess=" & total_cess & "," & _
                                " grand_total=" & grand_total & ", company_id=" & company_id & ", " & _
                                "user_name='" + user_name + "'  where quotation_no='" + quotation_no + "'")


            Else
                QueryCollection.Add("insert into quotation_hdr(quotation_no, user_quotation_no, contact_no, quotation_dt, " & _
                               "validuntil_dt, place_supply, ref_no, account_id, overall_disc_flg,  " & _
                               "overall_disc_percent, overall_disc_amt, shpcost_flg, shpcost_amt,  " & _
                               "roundoff_flg, roundoff_amt, customer_notes, internal_notes, sub_total, " & _
                               " total_tax, total_cess, grand_total, company_id, user_name) values( " & _
                               "'" + quotation_no + "','" + user_quotation_no + "'," & _
                          "'" + contact_no + "','" + quotation_dt + "','" + validuntil_dt + "'," & _
                          "'" + place_supply + "','" + ref_no + "',''," & overall_disc_flg & "," & _
                          "" & overall_disc_percent & "," & overall_disc_amt & "," & shpcost_flg & "," & _
                          "" & shpcost_amt & "," & roundoff_flg & "," & roundoff_amt & ",'" + obj.inapos(customer_notes) + "','" + obj.inapos(internal_notes) + "'," & sub_total & "," & _
                          "" & total_tax & "," & total_cess & "," & grand_total & "," & _
                          "" + company_id + ",'" + user_name + "')")

                QueryCollection.Add("update control_tbl set quotation_no=quotation_no+1 where company_id=" + company_id + "")
            End If

            Dim result As Boolean = obj.TransactionInsert(QueryCollection)
            Select Case result
                Case True
                    MsgBox("Quotation created successfully!! with Quotation no : " + user_quotation_no + "", MessageBoxIcon.Information)
                    S.SetReportQuotationno(quotation_no)
                    ReportScreen.Show()
                    ReportScreen.BringToFront()

                Case False
                    MsgBox("Something Went Wrong!!", MessageBoxIcon.Exclamation)
                    Exit Sub
            End Select
            S.ClearQuotationno()
            Me.Controls.Clear()
            InitializeComponent()
            Me.Quotation_Load(e, e)
            ReportScreen.BringToFront()
            ReportScreen.Focus()
        Catch ex As Exception
            MsgBox("Check the Input", MessageBoxIcon.Exclamation)
        End Try

    End Sub
    Function BeforeUpdateQuotation() As Boolean

        Dim i As Integer = obj.QueryExecution("delete from quotation_dtl where quotation_no='" + S.GetQuotationno + "'")
        Return If(i >= 1, True, False)


    End Function
    Private Sub chkRndOff_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkRndOff.CheckedChanged
        Select Case chkRndOff.Checked
            Case True
                txtRndof.Visible = True
            Case False
                txtRndof.Visible = False
        End Select
        GetGrandAmt()
    End Sub

    Private Sub chkShpCost_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkShpCost.CheckedChanged
        Select Case chkShpCost.Checked
            Case True
                txtShpCost.Visible = True
            Case False
                txtShpCost.Visible = False
        End Select
        GetGrandAmt()
    End Sub

    Private Sub chkOvralDisc_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkOvralDisc.CheckedChanged
        Select Case chkOvralDisc.Checked
            Case True
                txtOvralDisc.Visible = True
            Case False
                txtOvralDisc.Visible = False
        End Select
        GetGrandAmt()
    End Sub


    Private Sub dtpPurDt_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpPurDt.ValueChanged
        txtPurDt.Text = Me.dtpPurDt.Value.Date.ToString("dd/MM/yyyy")
    End Sub
    Private Sub DateTimePicker1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpquotvaliddt.ValueChanged
        txtquotvaliddt.Text = Me.dtpquotvaliddt.Value.Date.ToString("dd/MM/yyyy")
    End Sub

    Private Sub txtCusname_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCusname.KeyUp
        Dim listvendorname As New DataTable
        lblcuscode.Text = ""
        lstbxCusName.DataSource = Nothing
        If txtCusname.Text = "" Then
            lstbxCusName.Visible = False
        Else

            listvendorname = obj.getdatatable("select top 1 'Add New' as company_name,'0' as contact_no from contact_tbl union select company_name,contact_no from contact_tbl where company_name like '%" + txtCusname.Text + "%'")
            lstbxCusName.DisplayMember = "company_name"
            lstbxCusName.ValueMember = "contact_no"
            lstbxCusName.DataSource = listvendorname
            lstbxCusName.Visible = True
        End If
    End Sub
    Private Sub lstbxCusName_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lstbxCusName.MouseClick
        lstbxCusName.Visible = False
        If lstbxCusName.Text = "Add New" Then
            Contacts.Show()
            Contacts.BringToFront()
            Contacts.Focus()
        Else
            Try
                lblcuscode.Text = lstbxCusName.SelectedValue
                txtVendorAddress.Text = obj.GetOneValueFromQuery("select ship_address from contact_tbl where contact_no='" + lstbxCusName.SelectedValue + "'")
                txtplsupply.Text = obj.GetOneValueFromQuery("select place_supply from contact_tbl where contact_no='" + lstbxCusName.SelectedValue + "'")

                lstbxCusName.Visible = False
                txtCusname.Text = lstbxCusName.Text

            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub txtItmName_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtItmName.KeyUp
        Dim listitemname As New DataTable
        lstItmName.DataSource = Nothing
        If txtItmName.Text = "" Then
            lstItmName.Visible = False
        Else
            listitemname = obj.getdatatable("select top 1 'Add New' as item_name,'0' as item_no from item_tbl union select item_name,item_no from item_tbl where item_name like '%" + txtItmName.Text + "%'")

            lstItmName.DisplayMember = "item_name"
            lstItmName.ValueMember = "item_no"
            lstItmName.DataSource = listitemname
            lstItmName.Visible = True

        End If
    End Sub
    Private Sub lstItmName_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lstItmName.MouseClick
        lstItmName.Visible = False
        If lstItmName.Text = "Add New" Then
            Items.Show()
            Items.BringToFront()
            Items.Focus()
        Else
            Try

                If lblcuscode.Text = "" Then
                    MsgBox("Please Select Customer Name")
                    Exit Sub
                End If
                txtItmName.Text = lstItmName.Text
                Dim itemdata As New List(Of String)
                itemdata = obj.GetMoreValueFromQuery("select uom,sale_rate,cess,igst from item_tbl where item_no='" + lstItmName.SelectedValue + "'", 4)
                cmbUom.Text = itemdata(0)
                txtRate.Text = itemdata(1)
                txtItmCess.Text = itemdata(2)
                cmbItemTax.Text = itemdata(3)
                txtQty.Text = "1"
                txtItmDisc.Text = "0"

                Select Case obj.GetOneValueFromQuery("select billing_state from company_tbl " & _
                                                     "where company_id=" & SharedData.companyid & "") =
                                                 obj.GetOneValueFromQuery("select place_supply  from contact_tbl " & _
                                                     "where contact_no='" + lstbxCusName.SelectedValue + "'")
                    Case True
                        lblitemtaxtype.Text = "GST"
                    Case False
                        lblitemtaxtype.Text = "IGST"
                End Select
                lblstock.Text = obj.GetOneValueFromQuery("select qty from stock_tbl where item_no='" + lstItmName.SelectedValue + "' and company_id=" & SharedData.companyid & "")
                lblstock.Visible = True
                lbldspstock.Visible = True
                lstItmName.Visible = False
            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub btnAddToGrid_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddToGrid.Click
        GridPurchaseData.ClearSelection()
        Try
            Dim Amount As Double
            Amount = CDbl(txtQty.Text) * CDbl(txtRate.Text)
            Amount = Amount - obj.FdPercCalc(Amount, Me.txtItmDisc.Text)
            itemdatatable.Rows.Add(Me.txtItmName.Text, lstItmName.SelectedValue, txtDesc.Text,
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

            GridPurchaseData.Columns(0).ReadOnly = True
            GridPurchaseData.Columns(2).ReadOnly = True
            GridPurchaseData.Columns(3).ReadOnly = True
            GridPurchaseData.Columns(4).ReadOnly = True
            GridPurchaseData.Columns(5).ReadOnly = True
            GridPurchaseData.Columns(6).ReadOnly = True
            GridPurchaseData.Columns(7).ReadOnly = True
            GridPurchaseData.Columns(8).ReadOnly = True
            GridPurchaseData.Columns(9).ReadOnly = True

            txtDesc.Text = ""
            txtQty.Text = ""
            cmbUom.Refresh()
            Me.txtRate.Text = "0"
            Me.txtItmDisc.Text = "0"
            txtItmName.Text = ""
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
            Dim value As Double = If(txtOvralDisc.Text = "", 0, txtOvralDisc.Text)
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

    Private Sub GridPurchaseData_CellContentClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GridPurchaseData.CellContentClick
        If e.ColumnIndex = 10 Then
            Me.txtItmName.Text = GridPurchaseData.Rows(e.RowIndex).Cells(0).Value.ToString()
            lstbxCusName.SelectedValue = GridPurchaseData.Rows(e.RowIndex).Cells(1).Value.ToString()
            txtDesc.Text = GridPurchaseData.Rows(e.RowIndex).Cells(2).Value.ToString()
            txtQty.Text = GridPurchaseData.Rows(e.RowIndex).Cells(3).Value.ToString()
            cmbUom.Text = GridPurchaseData.Rows(e.RowIndex).Cells(4).Value.ToString()
            Me.txtRate.Text = GridPurchaseData.Rows(e.RowIndex).Cells(5).Value.ToString()
            Me.txtItmDisc.Text = GridPurchaseData.Rows(e.RowIndex).Cells(6).Value.ToString()
            Me.cmbItemTax.Text = GridPurchaseData.Rows(e.RowIndex).Cells(8).Value.ToString()
            Me.txtItmCess.Text = GridPurchaseData.Rows(e.RowIndex).Cells(9).Value.ToString()

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

    Private Sub txtOvralDisc_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtRndof.KeyPress, txtOvralDisc.KeyPress, txtShpCost.KeyPress
        obj.OnlyNoS(e)
    End Sub

    Private Sub txtOvralDisc_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtOvralDisc.KeyUp
        GetGrandAmt()
    End Sub

    Private Sub txtRndof_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtRndof.KeyUp
        GetGrandAmt()
    End Sub

    Private Sub txtShpCost_Keyup(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtShpCost.KeyUp
        GetGrandAmt()
    End Sub

    Private Sub lnklblEditAddress_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnklblEditAddress.LinkClicked
        obj.ContactOpen()
    End Sub

    Private Sub txtquotno_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtquotno.KeyPress, txtrefno.KeyPress
        obj.NoApos(e)
    End Sub
End Class