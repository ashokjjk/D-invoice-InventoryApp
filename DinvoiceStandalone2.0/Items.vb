Public Class Items
    Dim obj As New ObjClass
    Dim so As New SharedData

    Private Sub Items_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If obj.GetCountItem = False Then
            MsgBox("You cant create another Item, Buy premium version")
            Me.Close()
            Exit Sub
        End If
        If so.getsoftwaretype() = "FREE" Then
            skupanel.Enabled = False
        Else
            skupanel.Enabled = True
        End If


        Try
            MaximizeBox = False
            MinimizeBox = False
            txtItemname.Focus()
            Dim cesslist, gstratelist, uomlist As New List(Of String)
            cesslist = obj.getcolumndatafromquery("select distinct cess from gst_tbl")
            gstratelist = obj.getcolumndatafromquery("select distinct gst_rate from gst_tbl")
            uomlist = obj.getcolumndatafromquery("select unit_desc from uom_tbl")
            For i = 0 To cesslist.Count - 1
                cmbCessPercent.Items.Add(cesslist(i))
            Next
            For i = 0 To gstratelist.Count - 1
                cmbGSTpercent.Items.Add(gstratelist(i))
            Next
            For i = 0 To uomlist.Count - 1
                cmbUom.Items.Add(uomlist(i))
            Next
            BindGridViewItem("")
        Catch ex As Exception
            MsgBox(ex.Message, MessageBoxIcon.Warning)
        End Try
    End Sub
    Private Sub BindGridViewItem(ByVal p1 As String)
        Try
            gridItem.ColumnCount = 7
            gridItem.Columns(0).Name = "Name"
            gridItem.Columns(1).Name = "GST No"
            gridItem.Columns(2).Name = "Sales Rate"
            gridItem.Columns(3).Name = ""
            gridItem.Columns(4).Name = "Item code"
            gridItem.Columns(5).Name = "Item Type"
            gridItem.Columns(6).Name = "companyid"
            gridItem.Rows.Clear()
            Dim dt1 As New DataTable
            If rbtName.Checked = True Then
                dt1 = obj.getdatatable("select item_name,gst_id,sale_rate,item_no,item_code,item_type,company_id	 from item_tbl where item_name like '%" + p1 + "%' and company_id=" + SharedData.companyid + "")

            ElseIf rbtcriteriaGstCode.Checked = True Then
                dt1 = obj.getdatatable("select item_name,gst_id,sale_rate,item_no,item_code,item_type,company_id	 from item_tbl where gst_id like '%" + p1 + "%' and company_id=" + SharedData.companyid + "")

            Else
                dt1 = obj.getdatatable("select item_name,gst_id,sale_rate,item_no,item_code,item_type,company_id	 from item_tbl where company_id=" + SharedData.companyid + "")
            End If



            For i = 0 To dt1.Rows.Count - 1
                gridItem.Rows.Add(dt1.Rows(i).Item(0).ToString, dt1.Rows(i).Item(1).ToString, dt1.Rows(i).Item(2).ToString, dt1.Rows(i).Item(3).ToString, dt1.Rows(i).Item(4).ToString, dt1.Rows(i).Item(5).ToString, dt1.Rows(i).Item(6).ToString)
            Next
            'gridAddCmp.DataSource = dt1
            Dim btn As New DataGridViewButtonColumn
            btn.Name = "edit"
            btn.HeaderText = ""
            btn.Text = "EDIT"
            btn.UseColumnTextForButtonValue = True
            gridItem.Columns.Add(btn)

            Dim btn1 As New DataGridViewButtonColumn
            btn1.Name = "delete"
            btn1.HeaderText = ""
            btn1.Text = "DELETE"
            btn1.UseColumnTextForButtonValue = True
            gridItem.Columns.Add(btn1)


            gridItem.Refresh()
            gridItem.ReadOnly = True
            gridItem.AutoGenerateColumns = False
            gridItem.AllowUserToAddRows = False
            gridItem.DefaultCellStyle.Font = New Font("Arial", 8)
            gridItem.ColumnHeadersDefaultCellStyle.Font = New Font("Century Gothic", 9, FontStyle.Bold)
            ' Me.DataGridView1.FirstDisplayedScrollingRowIndex = Me.DataGridView1.Rows.Count - 1
            gridItem.Columns(3).Visible = False
            gridItem.Columns(6).Visible = False
            gridItem.ClearSelection()
        Catch ex As Exception
            MsgBox(ex.Message, MessageBoxIcon.Warning)
        End Try
    End Sub
    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try


            Dim item_no, item_type, item_name, item_code, uom, barcode_no, gst_id, tax_desc_gst, tax_desc_igst As String
            Dim sale_rate, mrp,
                purchase_rate, cgst, sgst, igst, cess, sku_qty As Double
            Dim exempt_flg, nilrate_flg, company_id, skualert_flg As Integer

            item_type = ""
            If rbtGoods.Checked = True Then
                item_type = "Goods"
            End If
            If rbtServices.Checked = True Then
                item_type = "Services"
            End If
            item_name = txtItemname.Text
            item_code = txtItmCode.Text
            uom = cmbUom.Text
            gst_id = txtHsnsacCode.Text
            sale_rate = txtSaleRate.Text
            mrp = txtMrp.Text
            purchase_rate = txtPurcRate.Text


            If item_type = "" Then
                MsgBox("Please select Item Type (Goods/ Services)?", MessageBoxIcon.Error)
                Exit Sub
            End If
            If item_name = "" Then
                MsgBox("Please Enter Item Name!!", MessageBoxIcon.Error)
                txtItemname.Focus()
                Exit Sub
            End If
            If item_code = "" Then
                MsgBox("Please Enter Item Code!!", MessageBoxIcon.Error)
                txtItmCode.Focus()
                Exit Sub
            End If
            If uom = "" Then
                MsgBox("Please select UOM!!", MessageBoxIcon.Error)
                cmbUom.Focus()
                Exit Sub
            End If

            If chkExempted.Checked = True And chkNillRated.Checked = True Then
                MsgBox("Please check either Nil Rated or Excempted!!!", MessageBoxIcon.Exclamation)
                Exit Sub
            End If

            If chkExempted.Checked = True Then
                exempt_flg = 1
                nilrate_flg = 0
                cgst = 0
                sgst = 0
                igst = 0
                cess = 0
                tax_desc_gst = "NonTax"
                tax_desc_igst = "NonTax"
            ElseIf chkNillRated.Checked = True Then
                exempt_flg = 0
                nilrate_flg = 1
                cgst = 0
                sgst = 0
                igst = 0
                cess = 0
                tax_desc_gst = "GST-" + igst.ToString + "%"
                tax_desc_igst = "IGST-" + igst.ToString + "%"
                If gst_id = "" Then
                    MsgBox("Please Enter HSN SAC Code!!", MessageBoxIcon.Error)
                    Exit Sub
                End If
            Else
                exempt_flg = 0
                nilrate_flg = 0
                cgst = CDbl(cmbGSTpercent.Text) / 2
                sgst = CDbl(cmbGSTpercent.Text) / 2
                igst = CDbl(cmbGSTpercent.Text)
                cess = CDbl(cmbCessPercent.Text)
                tax_desc_gst = "GST-" + igst.ToString + "%"
                tax_desc_igst = "IGST-" + igst.ToString + "%"
                If gst_id = "" Then
                    MsgBox("Please Enter HSN/SAC Code!!", MessageBoxIcon.Error)
                    txtHsnsacCode.Focus()
                    Exit Sub
                End If
                If cmbGSTpercent.Text = "" Then
                    MsgBox("Please select GST Percent!!", MessageBoxIcon.Error)
                    cmbGSTpercent.Focus()
                    Exit Sub
                End If
                If cmbCessPercent.Text = "" Then
                    MsgBox("Please select Cess Percent!!", MessageBoxIcon.Error)
                    cmbCessPercent.Focus()
                    Exit Sub
                End If
            End If

            If skuyes.Checked = True Then
                skualert_flg = 1
                sku_qty = txtskuqty.Text
            Else
                skualert_flg = 0
                sku_qty = 0.0
            End If


            Dim QueryCollection As New List(Of String)

            Select Case btnSave.Text
                Case Is = "Save"
                    company_id = Val(SharedData.companyid)
                    item_no = obj.GetOneValueFromQuery("select item_no from control_tbl where company_id=" & company_id & "")
                    barcode_no = obj.GetOneValueFromQuery("select barcode_no from control_tbl where company_id=" & company_id & "")
                    QueryCollection.Add("insert into item_tbl(item_no,	item_type,	item_name,	" & _
                               "item_code,	uom,	gst_id,	sale_rate,	mrp	,purchase_rate	,cgst,	sgst," & _
                               "	igst	,cess,	exempt_flg,	nilrate_flg,	barcode_no,tax_desc_gst,tax_desc_igst,skualert_flg,sku_qty,company_id) " & _
                               "values(" & _
                               "'" + item_no + "','" + item_type + "','" + item_name + "','" + item_code + "'," & _
                               "'" + uom + "','" + gst_id + "'," & sale_rate & "," & mrp & "," & purchase_rate & "," & _
                               "" & cgst & "," & sgst & "," & igst & "," & cess & "," & exempt_flg & "," & _
                               "" & nilrate_flg & "," & barcode_no & ",'" + tax_desc_gst + "','" + tax_desc_igst + "'," & skualert_flg & "," & sku_qty & "," & company_id & ")")
                    If item_type = "Goods" Then
                        QueryCollection.Add("insert into stock_tbl(item_no,qty,company_id) values('" + item_no + "',0," & company_id & ")")
                    End If


                    QueryCollection.Add("update control_tbl set item_no=item_no+1 where company_id=" & company_id & "")
                    QueryCollection.Add("update control_tbl set barcode_no=barcode_no+1 where company_id=" & company_id & "")
                Case Is = "Update"
                    company_id = lblcompid.Text
                    item_no = lblitemcode.Text
                    QueryCollection.Add("update item_tbl set 	item_type='" + item_type + "',	item_name='" + item_name + "',	" & _
                               "item_code='" + item_code + "',	uom='" + uom + "'," & _
                               "	gst_id='" + gst_id + "',	sale_rate=" & sale_rate & ",	mrp=" & mrp & "	" & _
                               ",purchase_rate=" & purchase_rate & "	,cgst=" & cgst & ",	sgst=" & sgst & "," & _
                               "	igst=" & igst & "	,cess=" & cess & ",	exempt_flg=" & exempt_flg & "," & _
                               "	nilrate_flg=" & nilrate_flg & ",tax_desc_gst='" + tax_desc_gst + "'" & _
                               ",tax_desc_igst ='" + tax_desc_igst + "',skualert_flg=" & skualert_flg & ",sku_qty =" & sku_qty & "  where item_no='" + item_no + "' and company_id=" & company_id & "")
                    btnSave.Text = "Update"
                    lblitemcode.Text = ""
            End Select

            Dim result As Boolean = obj.TransactionInsert(QueryCollection)
            Select Case result
                Case True
                    Dim resultimg As Integer = obj.saveimage(PictureBox1.Image, "update item_tbl set item_picture=@image where item_no='" + item_no + "' and company_id=" & company_id & "")

                    MsgBox("Item Details Updated!!", MessageBoxIcon.Information)
                Case False
                    MsgBox("Something Went Wrong!!", MessageBoxIcon.Exclamation)
            End Select
            Me.Controls.Clear()
            InitializeComponent()
            Me.Items_Load(e, e)
        Catch ex As Exception
            MsgBox(ex.Message, MessageBoxIcon.Warning)
        End Try
    End Sub
    Private Sub LogoClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            Dim filename As String
            Dim od As New OpenFileDialog
            od.ShowDialog()
            od.Filter = "Image Files(*.BMP;*.JPG;*.GIF;*.PNG)|*.BMP;*.JPG;*.GIF;*.PNG"
            filename = od.FileName
            Dim img As Image = Image.FromFile(filename)
            PictureBox1.Image = img
        Catch ex As Exception
            MsgBox("Image not uploaded", MessageBoxIcon.Warning)
            'MsgBox(ex.Message)
            Exit Sub
        End Try
    End Sub
    Private Sub txtgstSearch_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtgstSearch.TextChanged
        Try
            Dim search As String = txtgstSearch.Text
            If search = "" Then
                lstGSTDesc.DataSource = Nothing
                lstGSTDesc.Items.Clear()
                Exit Sub
            Else
            End If
            lstGSTDesc.DataSource = Nothing
            lstGSTDesc.Items.Clear()
            Dim query As String
            If rbtGoods.Checked = True Then  'goods
                If rbtGSTcode.Checked = True Then  'gstcode
                    query = "select top 10 desc,ID from gst_tbl where gst_type='hsn' and hsn_sac_code like '%" + search + "%'"
                ElseIf rbtGSTdesc.Checked = True Then 'description
                    query = "select top 10 desc,ID from gst_tbl where gst_type='hsn' and desc like '%" + search + "%'"
                Else
                End If

            ElseIf rbtServices.Checked = True Then  ' services
                If rbtGSTcode.Checked = True Then 'gstcode
                    query = "select top 10 desc ,ID from gst_tbl where gst_type='sac' and hsn_sac_code like '%" + search + "%'"
                ElseIf rbtGSTdesc.Checked = True Then 'description
                    query = "select top 10 desc ,ID from gst_tbl where gst_type='sac' and desc like '%" + search + "%'"
                Else
                End If
            Else
                Exit Sub
            End If
            Dim gstcode As New DataTable
            gstcode = obj.getdatatable(query)
            lstGSTDesc.DisplayMember = "desc"
            lstGSTDesc.ValueMember = "ID"
            lstGSTDesc.DataSource = gstcode

        Catch ex As Exception
            MsgBox(ex.Message, MessageBoxIcon.Warning)
            Exit Sub
        End Try
    End Sub

    Private Sub lstGSTDesc_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstGSTDesc.SelectedIndexChanged
        Try
            Dim getdata As New List(Of String)
           
            Dim key As Integer = lstGSTDesc.SelectedValue ' DirectCast(lstGSTDesc.SelectedValue, KeyValuePair(Of String, String)).Key
            If lstGSTDesc.Text = "" Then

            Else
                getdata = obj.GetMoreValueFromQuery("select hsn_sac_code,gst_rate,cess from gst_tbl where ID=" & key & "", 3)
                Me.txtHsnsacCode.Text = getdata(0)
                Me.cmbGSTpercent.Text = getdata(1)
                Me.cmbCessPercent.Text = getdata(2)
                    gstid.Text = key

            End If
        Catch ex As Exception
            MsgBox(ex.Message, MessageBoxIcon.Warning)
            Exit Sub
        End Try
    End Sub
    Private Sub gridItem_CellContentClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridItem.CellContentClick
        Try

       
        If e.ColumnIndex = 7 Then
            Dim Listdata As New List(Of String)
            Listdata = obj.GetMoreValueFromQuery("select item_type,	item_name," & _
                            "item_code,	uom,gst_id,	sale_rate,	mrp	,purchase_rate," & _
                            "igst,cess,exempt_flg,nilrate_flg,skualert_flg,sku_qty from " & _
                    "item_tbl where item_no=" & _
                    "'" + gridItem.Rows(e.RowIndex).Cells(3).Value + "' and company_id=" + gridItem.Rows(e.RowIndex).Cells(6).Value + "", 14)
            If Listdata(0) = "Goods" Then
                rbtGoods.Checked = True
            End If
            If Listdata(0) = "Services" Then
                rbtServices.Checked = True
            End If

            txtItemname.Text = Listdata(1)
            txtItmCode.Text = Listdata(2)
            cmbUom.Text = Listdata(3)
            txtHsnsacCode.Text = Listdata(4)
            txtSaleRate.Text = Listdata(5)
            txtMrp.Text = Listdata(6)
            txtPurcRate.Text = Listdata(7)
            cmbGSTpercent.Text = Listdata(8)
            cmbCessPercent.Text = Listdata(9)

            If Listdata(10) = "1" Then
                chkExempted.Checked = True
            Else
                chkExempted.Checked = False
            End If
            If Listdata(11) = "1" Then
                chkNillRated.Checked = True
            Else
                chkNillRated.Checked = False
            End If
            If Listdata(12) = "1" Then
                skuyes.Checked = True
                skuchildpanel.Visible = True
                txtskuqty.Text = Listdata(13)
            Else
                skuno.Checked = True
                skuchildpanel.Visible = False
                txtskuqty.Text = "0.0"
            End If


            btnSave.Text = "Update"
            lblitemcode.Text = gridItem.Rows(e.RowIndex).Cells(3).Value
            lblcompid.Text = gridItem.Rows(e.RowIndex).Cells(6).Value
            Me.PictureBox1.Image = Image.FromStream(New System.IO.MemoryStream(obj.retrievephotofromDB("select item_picture from item_tbl where  item_no=" & _
                    "'" + gridItem.Rows(e.RowIndex).Cells(3).Value + "' and company_id=" + gridItem.Rows(e.RowIndex).Cells(6).Value + "")))

        End If
        If e.ColumnIndex = 8 Then
            Dim result As Integer = MessageBox.Show("Are you sure want to Delete??" & vbCrLf & "Careful Item Stock also will be Deleted!!!!", "Caution !!!", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information)
            If result = DialogResult.Cancel Then

            ElseIf result = DialogResult.No Then

            ElseIf result = DialogResult.Yes Then
                obj.QueryExecution("delete from item_tbl where item_no='" + gridItem.Rows(e.RowIndex).Cells(3).Value + "' and company_id=" + gridItem.Rows(e.RowIndex).Cells(6).Value + "")
                obj.QueryExecution("delete from stock_tbl where item_no='" + gridItem.Rows(e.RowIndex).Cells(3).Value + "' and company_id=" + gridItem.Rows(e.RowIndex).Cells(6).Value + "")
            End If
            Items_Load(e, e)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtSearchKeyword_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSearchKeyword.TextChanged
        If txtSearchKeyword.Text = "" Then
            BindGridViewItem("")
        Else
            BindGridViewItem(txtSearchKeyword.Text)
        End If
    End Sub

  
    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        Me.Controls.Clear()
        InitializeComponent()

        Items_Load(e, e)
    End Sub

    Private Sub RadioButton1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles skuyes.CheckedChanged
        If skuyes.Checked = True Then
            skuchildpanel.Visible = True
        Else
            skuchildpanel.Visible = False
        End If
    End Sub
End Class