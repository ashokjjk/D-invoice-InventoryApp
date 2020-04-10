Imports System.IO

Public Class Settings
    Dim obj As New ObjClass
    Dim sd As New SharedData
    Private Sub Settings_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtAddCmpCompanyname.Focus()
        Dim softtype As String = sd.getsoftwaretype
        Select Case softtype
            Case Is = ""
                ' MsgBox("Activation Pending!!! " & vbCrLf & "Contact Dara Corp", MsgBoxStyle.Critical)
                MessageBox.Show("Activation Pending!!! " & vbCrLf & "Contact Dara Corp", "Activation", MessageBoxButtons.OK, MessageBoxIcon.None,
                                MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification, False)
                Me.Close()
                Splash.Close()
                Exit Sub
            Case Else

        End Select


        TabControl1.TabPages(0).Text = "Add Company"
        TabControl1.TabPages(1).Text = "Add User"
        TabControl1.TabPages(2).Text = "Tax Rate"
        TabControl1.TabPages(3).Text = "Stock Adjustment"
        TabControl1.TabPages(4).Text = "Invoice Deletion"
        TabControl1.TabPages(5).Text = "Format Control"
        TabControl1.TabPages(6).Text = "Email Configuration"
        TabControl1.TabPages(7).Text = "Add Bank"
        TabControl1.TabPages(8).Text = "Assign Roles"







        If softtype = "FREE" Or softtype = "STD" Then

            Dim p1 As TabPage = TabControl1.TabPages(3)
            p1.Enabled = False
            Dim p2 As TabPage = TabControl1.TabPages(4)
            p2.Enabled = False
            Dim p3 As TabPage = TabControl1.TabPages(5)
            p3.Enabled = False
            Dim p4 As TabPage = TabControl1.TabPages(6)
            p4.Enabled = False
            Dim p5 As TabPage = TabControl1.TabPages(8)
            p5.Enabled = False
        Else
            Dim p1 As TabPage = TabControl1.TabPages(3)
            p1.Enabled = True
            Dim p2 As TabPage = TabControl1.TabPages(4)
            p2.Enabled = True
            Dim p3 As TabPage = TabControl1.TabPages(5)
            p3.Enabled = True
            Dim p4 As TabPage = TabControl1.TabPages(6)
            p4.Enabled = True
            Dim p5 As TabPage = TabControl1.TabPages(8)
            p5.Enabled = True
        End If

       

        MaximizeBox = False
        MinimizeBox = False
        TabControl1.Focus()
        Dim dt As New DataTable
        Dim collection As New AutoCompleteStringCollection
        dt = obj.getdatatable("select distinct company_name from company_tbl")
        For i = 0 To dt.Rows.Count - 1
            cmbCmpNmAddUser.Items.Add(dt.Rows(i).Item(0).ToString)
            cmbBankCmpNm.Items.Add(dt.Rows(i).Item(0).ToString)
            cmbFrmtCntrlCmpNm.Items.Add(dt.Rows(i).Item(0).ToString)
            cmbEmailCmpName.Items.Add(dt.Rows(i).Item(0).ToString)
            collection.Add(dt.Rows(i).Item(0).ToString)
            cmbAssignrolesOrganame.Items.Add(dt.Rows(i).Item(0).ToString)
            cmbstockcmpname.Items.Add(dt.Rows(i).Item(0).ToString)
        Next
        Dim liststate As New List(Of String)
        liststate = obj.getcolumndatafromquery("select indian_state from state_tbl")
        For i = 0 To liststate.Count - 1
            cmbState.Items.Add(liststate(i))
        Next
        BindCompanyGridView("")
        BindBankGridView("")
        BindUserGridView("")
        BindFormatCntrlGridView("")
        BindMailGridView("")
        BindUserRolesGridView("")

        gridTax.DataSource = obj.getdatatable("select ID,tax_type as TaxType,tax_rate as TaxRate,tax_group as TaxGroup,tax_desc as Description from taxgroup_tbl ")
        gridTax.AutoGenerateColumns = False
        gridTax.AllowUserToAddRows = False
        gridTax.Columns(0).ReadOnly = True

        txtSrchCmpAddCmp.AutoCompleteMode = AutoCompleteMode.Suggest
        txtSrchCmpAddCmp.AutoCompleteSource = AutoCompleteSource.CustomSource
        txtSrchCmpAddCmp.AutoCompleteCustomSource = collection
        txtSrchcmpNmAddUser.AutoCompleteMode = AutoCompleteMode.Suggest
        txtSrchcmpNmAddUser.AutoCompleteSource = AutoCompleteSource.CustomSource
        txtSrchcmpNmAddUser.AutoCompleteCustomSource = collection
        txtFrmtCntrlCmpNmSearch.AutoCompleteMode = AutoCompleteMode.Suggest
        txtFrmtCntrlCmpNmSearch.AutoCompleteSource = AutoCompleteSource.CustomSource
        txtFrmtCntrlCmpNmSearch.AutoCompleteCustomSource = collection




    End Sub
    Sub BindUserRolesGridView(ByVal s As String)
        gridUserroles.ColumnCount = 3
        gridUserroles.Columns(0).Name = "Company name"
        gridUserroles.Columns(1).Name = "User Name"
        gridUserroles.Columns(2).Name = ""
        gridUserroles.Rows.Clear()
        Dim dt1 As New DataTable
        dt1 = obj.getdatatable("select distinct a.company_name, b.user_name,a.company_id from company_tbl a,user_roles b where a.company_id=b.company_id " & _
                                              "and  b.user_name like '%" + s + "%'")
        For i = 0 To dt1.Rows.Count - 1
            gridUserroles.Rows.Add(dt1.Rows(i).Item(0).ToString, dt1.Rows(i).Item(1).ToString, dt1.Rows(i).Item(2).ToString)
        Next
        'gridAddCmp.DataSource = dt1
        Dim btn As New DataGridViewButtonColumn
        btn.Name = "edit"
        btn.HeaderText = ""
        btn.Text = "EDIT"
        btn.UseColumnTextForButtonValue = True
        gridUserroles.Columns.Add(btn)

        Dim btn1 As New DataGridViewButtonColumn
        btn1.Name = "delete"
        btn1.HeaderText = ""
        btn1.Text = "DELETE"
        btn1.UseColumnTextForButtonValue = True
        gridUserroles.Columns.Add(btn1)


        gridUserroles.Refresh()
        gridUserroles.ReadOnly = True
        gridUserroles.AutoGenerateColumns = False
        gridUserroles.AllowUserToAddRows = False
        gridUserroles.Columns(2).Visible = False
        gridUserroles.ClearSelection()
        gridUserroles.DefaultCellStyle.Font = New Font("Arial", 8)

    End Sub

    Sub BindBankGridView(ByVal s As String)
        gridBank.ColumnCount = 3
        gridBank.Columns(0).Name = "Bank name"
        gridBank.Columns(1).Name = "Branch Name"
        gridBank.Columns(2).Name = ""
        gridBank.Rows.Clear()
        Dim dt1 As New DataTable
        dt1 = obj.getdatatable("select bank_name,branch_name, ID from bank_tbl where bank_name like '%" + s + "%'")
        For i = 0 To dt1.Rows.Count - 1
            gridBank.Rows.Add(dt1.Rows(i).Item(0).ToString, dt1.Rows(i).Item(1).ToString, dt1.Rows(i).Item(2).ToString)
        Next
        'gridAddCmp.DataSource = dt1
        Dim btn As New DataGridViewButtonColumn
        btn.Name = "edit"
        btn.HeaderText = ""
        btn.Text = "EDIT"
        btn.UseColumnTextForButtonValue = True
        gridBank.Columns.Add(btn)

        Dim btn1 As New DataGridViewButtonColumn
        btn1.Name = "delete"
        btn1.HeaderText = ""
        btn1.Text = "DELETE"
        btn1.UseColumnTextForButtonValue = True
        gridBank.Columns.Add(btn1)


        gridBank.Refresh()
        gridBank.ReadOnly = True
        gridBank.AutoGenerateColumns = False
        gridBank.AllowUserToAddRows = False
        gridBank.Columns(2).Visible = False
        gridBank.ClearSelection()
        gridBank.DefaultCellStyle.Font = New Font("Arial", 8)
    End Sub
    Sub BindUserGridView(ByVal s As String)
        gridUser.ColumnCount = 3
        gridUser.Columns(0).Name = "User name"
        gridUser.Columns(1).Name = "Company Name"
        gridUser.Columns(2).Name = ""
        gridUser.Rows.Clear()
        Dim dt1 As New DataTable
        dt1 = obj.getdatatable("select b.user_name,a.company_name,b.ID from company_tbl a,user_tbl b  where a.company_id=b.company_id and  a.company_name like '%" + s + "%'")
        For i = 0 To dt1.Rows.Count - 1
            gridUser.Rows.Add(dt1.Rows(i).Item(0).ToString, dt1.Rows(i).Item(1).ToString, dt1.Rows(i).Item(2).ToString)
        Next
        'gridAddCmp.DataSource = dt1
        Dim btn As New DataGridViewButtonColumn
        btn.Name = "edit"
        btn.HeaderText = ""
        btn.Text = "EDIT"
        btn.UseColumnTextForButtonValue = True
        gridUser.Columns.Add(btn)

        Dim btn1 As New DataGridViewButtonColumn
        btn1.Name = "delete"
        btn1.HeaderText = ""
        btn1.Text = "DELETE"
        btn1.UseColumnTextForButtonValue = True
        gridUser.Columns.Add(btn1)


        gridUser.Refresh()
        gridUser.ReadOnly = True
        gridUser.AutoGenerateColumns = False
        gridUser.AllowUserToAddRows = False
        gridUser.Columns(2).Visible = False
        gridUser.ClearSelection()
        gridUser.DefaultCellStyle.Font = New Font("Arial", 8)
    End Sub
    Sub BindFormatCntrlGridView(ByVal s As String)
        gridFrmtCntrl.ColumnCount = 2
        gridFrmtCntrl.Columns(0).Name = "Company name"
        gridFrmtCntrl.Columns(1).Name = ""
        gridFrmtCntrl.Rows.Clear()
        Dim dt1 As New DataTable
        dt1 = obj.getdatatable("select a.company_name, b.company_id from company_tbl a,control_tbl b where a.company_id=b.company_id and a.company_name like '%" + s + "%'")
        For i = 0 To dt1.Rows.Count - 1
            gridFrmtCntrl.Rows.Add(dt1.Rows(i).Item(0).ToString, dt1.Rows(i).Item(1).ToString)
        Next
        Dim btn As New DataGridViewButtonColumn
        btn.Name = "edit"
        btn.HeaderText = ""
        btn.Text = "EDIT"
        btn.UseColumnTextForButtonValue = True
        gridFrmtCntrl.Columns.Add(btn)

        Dim btn1 As New DataGridViewButtonColumn
        btn1.Name = "delete"
        btn1.HeaderText = ""
        btn1.Text = "DELETE"
        btn1.UseColumnTextForButtonValue = True
        gridFrmtCntrl.Columns.Add(btn1)


        gridFrmtCntrl.Refresh()
        gridFrmtCntrl.ReadOnly = True
        gridFrmtCntrl.AutoGenerateColumns = False
        gridFrmtCntrl.AllowUserToAddRows = False
        ' Me.DataGridView1.FirstDisplayedScrollingRowIndex = Me.DataGridView1.Rows.Count - 1
        gridFrmtCntrl.Columns(1).Visible = False
        gridFrmtCntrl.ClearSelection()
        gridFrmtCntrl.DefaultCellStyle.Font = New Font("Arial", 8)
    End Sub
    Sub BindCompanyGridView(ByVal s As String)
        gridAddCmp.ColumnCount = 3
        gridAddCmp.Columns(0).Name = "Company name"
        gridAddCmp.Columns(1).Name = "Company year"
        gridAddCmp.Columns(2).Name = ""
        gridAddCmp.Rows.Clear()
        Dim dt1 As New DataTable
        dt1 = obj.getdatatable("select company_name,company_yr, company_id from company_tbl where company_name like '%" + s + "%'")
        For i = 0 To dt1.Rows.Count - 1
            gridAddCmp.Rows.Add(dt1.Rows(i).Item(0).ToString, dt1.Rows(i).Item(1).ToString, dt1.Rows(i).Item(2).ToString)
        Next
        'gridAddCmp.DataSource = dt1
        Dim btn As New DataGridViewButtonColumn
        btn.Name = "edit"
        btn.HeaderText = ""
        btn.Text = "EDIT"
        btn.UseColumnTextForButtonValue = True
        gridAddCmp.Columns.Add(btn)

        Dim btn1 As New DataGridViewButtonColumn
        btn1.Name = "delete"
        btn1.HeaderText = ""
        btn1.Text = "DELETE"
        btn1.UseColumnTextForButtonValue = True
        gridAddCmp.Columns.Add(btn1)


        gridAddCmp.Refresh()
        gridAddCmp.ReadOnly = True
        gridAddCmp.AutoGenerateColumns = False
        gridAddCmp.AllowUserToAddRows = False
        ' Me.DataGridView1.FirstDisplayedScrollingRowIndex = Me.DataGridView1.Rows.Count - 1
        gridAddCmp.Columns(2).Visible = False
        gridAddCmp.ClearSelection()
        gridAddCmp.DefaultCellStyle.Font = New Font("Arial", 8)
    End Sub
    Sub BindMailGridView(ByVal s As String)
        gridMail.ColumnCount = 3
        gridMail.Columns(0).Name = "Mail ID"
        gridMail.Columns(1).Name = "Mail User"
        gridMail.Columns(2).Name = ""
        gridMail.Rows.Clear()
        Dim dt1 As New DataTable
        dt1 = obj.getdatatable("select mail_id,mail_user, ID from email_tbl where mail_id like '%" + s + "%'")
        For i = 0 To dt1.Rows.Count - 1
            gridMail.Rows.Add(dt1.Rows(i).Item(0).ToString, dt1.Rows(i).Item(1).ToString, dt1.Rows(i).Item(2).ToString)
        Next
        'gridAddCmp.DataSource = dt1
        Dim btn As New DataGridViewButtonColumn
        btn.Name = "edit"
        btn.HeaderText = ""
        btn.Text = "EDIT"
        btn.UseColumnTextForButtonValue = True
        gridMail.Columns.Add(btn)

        Dim btn1 As New DataGridViewButtonColumn
        btn1.Name = "delete"
        btn1.HeaderText = ""
        btn1.Text = "DELETE"
        btn1.UseColumnTextForButtonValue = True
        gridMail.Columns.Add(btn1)


        gridMail.Refresh()
        gridMail.ReadOnly = True
        gridMail.AutoGenerateColumns = False
        gridMail.AllowUserToAddRows = False
        ' Me.DataGridView1.FirstDisplayedScrollingRowIndex = Me.DataGridView1.Rows.Count - 1
        gridMail.Columns(2).Visible = False
        gridMail.ClearSelection()
        gridMail.DefaultCellStyle.Font = New Font("Arial", 8)
    End Sub
    Private Sub gridAddCmp_CellContentClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridAddCmp.CellContentClick
        If e.ColumnIndex = 3 Then
            Try


                Dim Listcmpdata As New List(Of String)
                Listcmpdata = obj.GetMoreValueFromQuery("Select company_name,	gst_no,	pan_no," & _
                        "	billing_address,	billing_state,	billing_city	,billing_pincode,	phone_no," & _
                        "	composite_flg,	company_yr_fromdt,	company_yr_todt	,company_yr from " & _
                        "company_tbl where company_id=" & _
                        "" & Val(gridAddCmp.Rows(e.RowIndex).Cells(2).Value) & "", 12)
                txtAddCmpCompanyname.Text = Listcmpdata(0)
                txtGstNo.Text = Listcmpdata(1)
                txtPanno.Text = Listcmpdata(2)
                txtBillingAddr.Text = Listcmpdata(3)
                cmbState.Text = Listcmpdata(4)
                txtCity.Text = Listcmpdata(5)
                txtPincode.Text = Listcmpdata(6)
                txtPhoneno.Text = Listcmpdata(7)
                txtCmpFromdt.Text = obj.ConvDtFrmt(Listcmpdata(9), "dd-MM-yyyy")
                txtCmpTodt.Text = obj.ConvDtFrmt(Listcmpdata(10), "dd-MM-yyyy")
                If (Listcmpdata(8) = "0") Then
                    chkComposite.Checked = False
                Else
                    chkComposite.Checked = True
                End If
                btnAddCmp.Text = "Update"
                lbluserid.Text = gridAddCmp.Rows(e.RowIndex).Cells(2).Value
                Me.pcbLogo.Image = Image.FromStream(New System.IO.MemoryStream(obj.retrievephotofromDB("select company_logo from company_tbl where company_id=" & Val(gridAddCmp.Rows(e.RowIndex).Cells(2).Value) & "")))
            Catch ex As Exception

            End Try
        End If

        If e.ColumnIndex = 4 Then
            Dim result As Integer = MessageBox.Show("Are you sure want to Delete??", "Caution !!!", MessageBoxButtons.YesNoCancel)
            If result = DialogResult.Cancel Then

            ElseIf result = DialogResult.No Then

            ElseIf result = DialogResult.Yes Then
                obj.QueryExecution("delete from company_tbl where company_id=" & Val(gridAddCmp.Rows(e.RowIndex).Cells(2).Value) & "")
            End If
        End If
    End Sub
    Private Sub TabControl1_DrawItem(ByVal sender As Object, ByVal e As System.Windows.Forms.DrawItemEventArgs) Handles TabControl1.DrawItem
        Dim g As Graphics = e.Graphics
        Dim _textBrush As Brush
        Dim _tabPage As TabPage = TabControl1.TabPages(e.Index)
        Dim _tabBounds As Rectangle = TabControl1.GetTabRect(e.Index)
        If e.State = DrawItemState.Selected Then
            _textBrush = New SolidBrush(Color.Black)
            g.FillRectangle(Brushes.Aqua, e.Bounds)
        Else
            _textBrush = New System.Drawing.SolidBrush(e.ForeColor)
            e.DrawBackground()
        End If

        Dim _tabFont As Font = New Font("Arial", CSng(10), FontStyle.Bold, GraphicsUnit.Pixel)
        Dim _stringFlags As StringFormat = New StringFormat()
        _stringFlags.Alignment = StringAlignment.Center
        _stringFlags.LineAlignment = StringAlignment.Center
        g.DrawString(_tabPage.Text, _tabFont, _textBrush, _tabBounds, New StringFormat(_stringFlags))
    End Sub

    Private Sub btnAddCmp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddCmp.Click
        Dim CompanyName, GSTNo, PanNo, BillingAddr, State, City, Pincode, PhoneNo, CompanyYr,
            AccountFromDate, AccountToDate, Strfromdate, strtodate As String
        Dim CompositeFlg, companyid As Integer

        Dim softtype As String = sd.getsoftwaretype

        If softtype = "FREE" Or softtype = "STD" Then
            Dim i As Integer = obj.FindDuplicate("select count(*) from company_tbl")
            If i >= 1 Then
                MsgBox("You cant create another company, Buy premium version")
                Exit Sub
            End If
        End If

        Try


            CompanyName = txtAddCmpCompanyname.Text
            GSTNo = txtGstNo.Text
            PanNo = txtPanno.Text
            BillingAddr = txtBillingAddr.Text
            State = cmbState.Text
            City = txtCity.Text
            Pincode = txtPincode.Text
            PhoneNo = txtPhoneno.Text
            Strfromdate = obj.ConvDtFrmt(txtCmpFromdt.Text, "dd-MM-yyyy")
            strtodate = obj.ConvDtFrmt(txtCmpTodt.Text, "dd-MM-yyyy")
            CompanyYr = Strfromdate + " to " + strtodate
            AccountFromDate = obj.ConvDtFrmt(txtCmpFromdt.Text, "MM-dd-yyyy")
            AccountToDate = obj.ConvDtFrmt(txtCmpTodt.Text, "MM-dd-yyyy")
            CompositeFlg = If(chkComposite.Checked = True, 1, 0)
            Dim QueryCollection As New List(Of String)
           

            Select Case btnAddCmp.Text
                Case Is = "Save"
                    companyid = obj.FindDuplicate("select count(*) from company_tbl") + 1
                    Dim companyfrmt As String = CompanyName.Substring(0, 3)
                    Select Case obj.FindDuplicate("select count(*) from company_tbl where company_name like '" + companyfrmt + "%'")
                        Case Is >= 1
                            MsgBox("The First three character of comapny name cannot be same," & vbCrLf & " Please Enter Different Company Name!!", MsgBoxStyle.Information)
                            Exit Sub
                        Case Else
                    End Select
                    Select Case obj.FindDuplicate("select count(*) from company_tbl where company_name='" + CompanyName + "' and company_yr_fromdt=#" + AccountFromDate + "# and company_yr_todt=#" + AccountToDate + "#")
                        Case Is = 0


                            QueryCollection.Add("insert into control_tbl(company_id,contact_no,item_no,purchase_frmt,purchase_no," & _
                       "supply_frmt,supply_no,invoice_frmt,invoice_no,quotation_frmt,quotation_no,indent_frmt,indent_no," & _
                       "advance_frmt,advance_no,voucher_frmt,voucher_no,credit_debit_frmt,credit_debit_no,barcode_no,gatepass_frmt," & _
                       "gatepass_no,employee_no, salarygroup_no, payslip_no) values(" & companyid & ",2,1" & _
                       ",'" + companyfrmt + "/PUR/',1,'" + companyfrmt + "/SUP/',1,'" + companyfrmt + "/INV/',1," & _
                       "'" + companyfrmt + "/QUO/',1,'" + companyfrmt + "/INT/',1,'" + companyfrmt + "/ADV/',1," & _
                       "'" + companyfrmt + "/VOU/',1,'" + companyfrmt + "/CD/',1,1123,'" + companyfrmt + "/GP/',1,1,1,1)")


                            QueryCollection.Add("insert into company_tbl(company_id,company_name,gst_no,	pan_no," & _
                                "	billing_address,	billing_state,	billing_city	,billing_pincode,	phone_no," & _
                                "	composite_flg,	company_yr_fromdt,	company_yr_todt	,company_yr) values(" & _
                                "" & companyid & ",'" + CompanyName + "','" + GSTNo + "','" + PanNo + "'," & _
                                "'" + BillingAddr + "','" + State + "','" + City + "','" + Pincode + "'," & _
                                "'" + PhoneNo + "'," & CompositeFlg & ",'" + AccountFromDate + "','" + AccountToDate + "'," & _
                                "'" + CompanyYr + "')")
                            QueryCollection.Add("insert into bank_tbl(company_id,	bank_name	,branch_name, " & _
           "	acc_no	,acc_name	,acc_type,	bank_openBalance,	bank_closeBalance,	 " & _
           "pettycash_openingBalance,	pettycash_closingBalance) values(" & companyid & "," & _
           "'BANKNAME','','',''," & _
           "'',0, 0 ,0," & _
           "0)")
                        Case Else
                            MsgBox("Company Name and Account Year are already present!!!", MessageBoxIcon.Warning)
                            Exit Sub
                    End Select
                Case Is = "Update"
                    companyid = lbluserid.Text
                    QueryCollection.Add("update company_tbl set	company_name='" + CompanyName + "'" & _
                            ",	gst_no='" + GSTNo + "',	pan_no='" + PanNo + "'," & _
                            "	billing_address='" + BillingAddr + "',	billing_state='" + State + "'," & _
                            "	billing_city='" + City + "'	,billing_pincode='" + Pincode + "',	" & _
                            "phone_no='" + PhoneNo + "'," & _
                            "	composite_flg=" & CompositeFlg & ",	" & _
                            "company_yr_fromdt='" + AccountFromDate + "',	" & _
                            "company_yr_todt='" + AccountToDate + "'	,company_yr='" + CompanyYr + "' " & _
                            "where company_id=" & companyid & "")
                    btnAddCmp.Text = "Save"
                    lbluserid.Text = ""
            End Select


            Dim result As Boolean = obj.TransactionInsert(QueryCollection)
            Select Case result
                Case True
                    MsgBox("Company Details Updated!!", MessageBoxIcon.Information)
                    Dim resultimg As Integer = obj.saveimage(pcbLogo.Image, "update company_tbl set company_logo=@image where company_id=" & companyid & "")

                    Select Case resultimg
                        Case Is = 1
                        Case Else
                            MsgBox("Company Logo not uploaded!!", MessageBoxIcon.Information)
                    End Select

                Case False
                    MsgBox("Something Went Wrong!!", MessageBoxIcon.Exclamation)
            End Select

            formLoad(e, e)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub LogoClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button13.Click
        Try
            Dim filename As String
            OpenFileDialog1.ShowDialog()
            OpenFileDialog1.Filter = "Image Files(*.BMP;*.JPG;*.GIF;*.PNG)|*.BMP;*.JPG;*.GIF;*.PNG"
            filename = OpenFileDialog1.FileName
            Dim img As Image = Image.FromFile(filename)
            pcbLogo.Image = img
        Catch ex As Exception
            MsgBox("Image not uploaded", MessageBoxIcon.Warning)
            'MsgBox(ex.Message)
            Exit Sub
        End Try
    End Sub

    Private Sub btnAddUser_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddUser.Click
        Dim username, password, companyid As String
        username = txtusernameAdduser.Text
        password = txtPasswordAduser.Text
        companyid = obj.GetOneValueFromQuery("select company_id from company_tbl where company_name='" + cmbCmpNmAddUser.Text + "' and company_yr='" + cmbcompanyyr.Text + "'")


        Dim QueryCollection As New List(Of String)
        Select Case btnAddUser.Text
            Case Is = "Save"
                QueryCollection.Add("insert into user_tbl(company_id,	user_name,	pass_word,status) values(" & _
           "" & companyid & ",'" + username + "','" + password + "',1)")
            Case Is = "Update"
                QueryCollection.Add("update user_tbl set company_id=" & companyid & ",	user_name='" + username + "',	pass_word='" + username + "'" & _
           " where ID=" & Val(lbluserid.Text) & "")
                btnAddUser.Text = "Save"
                lbluserid.Text = ""
        End Select


        Dim result As Boolean = obj.TransactionInsert(QueryCollection)

        Select Case result
            Case True
                MsgBox("User Details Updated!!", MessageBoxIcon.Information)
            Case False
                MsgBox("Something Went Wrong!!", MessageBoxIcon.Exclamation)
        End Select
        formLoad(e, e)
    End Sub

    Private Sub cmbCmpNmAddUser_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCmpNmAddUser.SelectedIndexChanged

        Dim value As String = cmbCmpNmAddUser.Text
        Dim lstcmpyr As New List(Of String)
        lstcmpyr = obj.getcolumndatafromquery("select company_yr from company_tbl where company_name='" + value + "'")
        cmbcompanyyr.Items.Clear()
        For i = 0 To lstcmpyr.Count - 1
            cmbcompanyyr.Items.Add(lstcmpyr(i))
        Next
    End Sub
    Private Sub cmbBankCmpNm_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbBankCmpNm.SelectedIndexChanged

        Dim value As String = cmbBankCmpNm.Text
        Dim lstcmpyr As New List(Of String)
        lstcmpyr = obj.getcolumndatafromquery("select company_yr from company_tbl where company_name='" + value + "'")
        cmbBankCmpYr.Items.Clear()
        For i = 0 To lstcmpyr.Count - 1
            cmbBankCmpYr.Items.Add(lstcmpyr(i))
        Next
    End Sub
    Private Sub cmbFrmtCntrlCmpNm_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbFrmtCntrlCmpNm.SelectedIndexChanged

        Dim value As String = cmbFrmtCntrlCmpNm.Text
        Dim lstcmpyr As New List(Of String)
        lstcmpyr = obj.getcolumndatafromquery("select company_yr from company_tbl where company_name='" + value + "'")
        cmbFrmtCmpYr.Items.Clear()
        For i = 0 To lstcmpyr.Count - 1
            cmbFrmtCmpYr.Items.Add(lstcmpyr(i))
        Next
    End Sub


    Private Sub gridBank_CellContentClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridBank.CellContentClick
        If e.ColumnIndex = 3 Then
            Dim Listcmpdata As New List(Of String)
            Listcmpdata = obj.GetMoreValueFromQuery("Select 	bank_name	,branch_name, " & _
            "	acc_no	,acc_name	,acc_type,	bank_openBalance,	 " & _
            "pettycash_openingBalance,company_id from " & _
                    "bank_tbl where ID=" & _
                    "" & Val(gridBank.Rows(e.RowIndex).Cells(2).Value) & "", 8)
            txtBankName.Text = Listcmpdata(0)
            txtBranchNm.Text = Listcmpdata(1)
            txtAccNo.Text = Listcmpdata(2)
            txtAccNm.Text = Listcmpdata(3)
            cmbAccType.Text = Listcmpdata(4)
            txtOpeningBalance.Text = Listcmpdata(5)
            txtPettyCash.Text = Listcmpdata(6)
            Dim cmpdts As New List(Of String)
            cmpdts = obj.GetMoreValueFromQuery("select company_name,company_yr from company_tbl where company_id=" & Listcmpdata(7) & "", 2)
            cmbBankCmpNm.Text = cmpdts(0)
            cmbBankCmpYr.Text = cmpdts(1)
            btnBankSave.Text = "Update"
            lblbankid.Text = gridBank.Rows(e.RowIndex).Cells(2).Value
        End If
        If e.ColumnIndex = 4 Then
            Dim result As Integer = MessageBox.Show("Are you sure want to Delete??", "Caution !!!", MessageBoxButtons.YesNoCancel)
            If result = DialogResult.Cancel Then

            ElseIf result = DialogResult.No Then

            ElseIf result = DialogResult.Yes Then
                obj.QueryExecution("delete from bank_tbl where ID=" & Val(gridBank.Rows(e.RowIndex).Cells(2).Value) & "")
            End If
        End If
    End Sub
    Private Sub btnBankSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBankSave.Click
        Dim company_id, bank_name, branch_name, acc_no, acc_name, acc_type As String
        Dim bank_openBalance, bank_closeBalance, pettycash_openingBalance, pettycash_closingBalance As Double

        bank_name = txtBankName.Text
        branch_name = txtBranchNm.Text
        acc_no = txtAccNo.Text
        acc_name = txtAccNm.Text
        acc_type = cmbAccType.Text
        company_id = obj.GetOneValueFromQuery("select company_id from company_tbl where company_name='" + cmbBankCmpNm.Text + "' and company_yr='" + cmbBankCmpYr.Text + "'")



        Dim QueryCollection As New List(Of String)
        Select Case btnBankSave.Text
            Case Is = "Save"
                bank_openBalance = txtOpeningBalance.Text
                bank_closeBalance = bank_openBalance
                pettycash_openingBalance = txtPettyCash.Text
                pettycash_closingBalance = pettycash_openingBalance
                QueryCollection.Add("insert into bank_tbl(company_id,	bank_name	,branch_name, " & _
            "	acc_no	,acc_name	,acc_type,	bank_openBalance,	bank_closeBalance,	 " & _
            "pettycash_openingBalance,	pettycash_closingBalance) values(" & company_id & "," & _
            "'" + bank_name + "','" + branch_name + "','" + acc_no + "','" + acc_name + "'," & _
            "'" + acc_type + "'," & bank_openBalance & "," & bank_closeBalance & "," & pettycash_openingBalance & "," & _
            "" & pettycash_closingBalance & ")")
            Case Is = "Update"
                Dim id As Integer = lblbankid.Text
                Dim cashflowdetails As New List(Of String)
                cashflowdetails = obj.GetMoreValueFromQuery("select bank_openBalance,	bank_closeBalance,	 " & _
            "pettycash_openingBalance,	pettycash_closingBalance from bank_tbl where ID=" & id & "", 4)
                bank_openBalance = txtOpeningBalance.Text
                bank_openBalance = bank_openBalance + CDbl(cashflowdetails(0))
                'bank_closeBalance = bank_openBalance
                bank_closeBalance = CDbl(txtOpeningBalance.Text) + CDbl(cashflowdetails(1))
                pettycash_openingBalance = txtPettyCash.Text
                pettycash_openingBalance = pettycash_openingBalance + CDbl(cashflowdetails(2))
                ' pettycash_closingBalance = pettycash_openingBalance
                pettycash_closingBalance = CDbl(txtPettyCash.Text) + CDbl(cashflowdetails(3))

                QueryCollection.Add("update bank_tbl set company_id=" & company_id & "," & _
            "	bank_name='" + bank_name + "'	,branch_name='" + branch_name + "', " & _
            "	acc_no='" + acc_no + "'	,acc_name='" + acc_name + "'	,acc_type='" + acc_type + "',	" & _
            "bank_openBalance=" & bank_openBalance & ",	bank_closeBalance=" & bank_closeBalance & ",	 " & _
            "pettycash_openingBalance=" & pettycash_openingBalance & ",	" & _
            "pettycash_closingBalance=" & pettycash_closingBalance & " where ID=" & id & "")

                btnBankSave.Text = "Save"
                lblbankid.Text = ""
        End Select

        Dim result As Boolean = obj.TransactionInsert(QueryCollection)
        Select Case result
            Case True
                MsgBox("Bank Details Updated!!", MessageBoxIcon.Information)
            Case False
                MsgBox("Something Went Wrong!!", MessageBoxIcon.Exclamation)
        End Select
        formLoad(e, e)
    End Sub

    Private Sub btnFrmtCntrlSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFrmtCntrlSave.Click
        Dim Format, Keyword, company_id, Query As String
        company_id = obj.GetOneValueFromQuery("select company_id from company_tbl where company_name='" + cmbFrmtCntrlCmpNm.Text + "' and company_yr='" + cmbFrmtCmpYr.Text + "'")
        Keyword = txtFrmtCntrlWord.Text
        If rbtFrmtCntrlInv.Checked = True Then
            Query = "update control_tbl set invoice_frmt='" + Keyword + "' where company_id=" & company_id & ""
        End If
        If rbtFrmtCntrlQuot.Checked = True Then
            Query = "update control_tbl set quotation_frmt='" + Keyword + "' where company_id=" & company_id & ""
        End If
        If rbtFrmtCntrlAdv.Checked = True Then
            Query = "update control_tbl set advance_frmt='" + Keyword + "' where company_id=" & company_id & ""
        End If
        If rbtFrmtCntrlIntend.Checked = True Then
            Query = "update control_tbl set indent_frmt='" + Keyword + "' where company_id=" & company_id & ""
        End If
        If rbtFrmtCntrlPurch.Checked = True Then
            Query = "update control_tbl set purchase_frmt='" + Keyword + "' where company_id=" & company_id & ""
        End If


        Dim QueryCollection As New List(Of String)
        QueryCollection.Add(Query)
        Dim result As Boolean = obj.TransactionInsert(QueryCollection)
        Select Case result
            Case True
                MsgBox("Format Details Updated!!", MessageBoxIcon.Information)
            Case False
                MsgBox("Something Went Wrong!!", MessageBoxIcon.Exclamation)
        End Select
    End Sub

    Private Sub btnEmailSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEmailSave.Click
        Dim company_name, mail_id, mail_user, mail_pass, pop, smtp, pop_port, smtp_port As String
        company_name = cmbEmailCmpName.Text
        mail_id = txtmailaddr.Text
        mail_user = txtmailusr.Text
        mail_pass = txtmailpwd.Text
        pop = txtpop.Text
        smtp = txtSmtp.Text
        pop_port = txtPopPort.Text
        smtp_port = txtSmtpPort.Text
        Dim QueryCollection As New List(Of String)


        Select Case btnEmailSave.Text
            Case Is = "Save"
                QueryCollection.Add("insert into email_tbl(company_name, mail_id, mail_user, mail_pass, pop, smtp, pop_port, smtp_port) values('" + company_name + "'," & _
        "'" + mail_id + "','" + mail_user + "','" + mail_pass + "','" + pop + "'," & _
        "'" + smtp + "','" + pop_port + "','" + smtp_port + "')")
            Case Is = "Update"
                QueryCollection.Add("update email_tbl set  mail_id='" + mail_id + "', " & _
                                    "mail_user='" + mail_user + "', mail_pass='" + mail_pass + "'," & _
                                    " pop='" + pop + "', smtp='" + smtp + "', " & _
                                    "pop_port='" + pop_port + "', smtp_port='" + smtp_port + "'," & _
                                    "company_name='" + company_name + "' where ID =" + emailsettingsid.Text + "")
                emailsettingsid.Text = ""
                btnEmailSave.Text = "Save"
        End Select



        Dim result As Boolean = obj.TransactionInsert(QueryCollection)
        Select Case result
            Case True
                MsgBox("Email Details Updated!!", MessageBoxIcon.Information)
            Case False
                MsgBox("Something Went Wrong!!", MessageBoxIcon.Exclamation)
        End Select
        formLoad(e, e)
    End Sub

    Private Sub btnSearchCmpAddCmp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearchCmpAddCmp.Click
        Dim Searchterm As String = txtSrchCmpAddCmp.Text
    End Sub


    Private Sub dtpCmpyrfrom_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpCmpyrfrom.ValueChanged
        Me.txtCmpFromdt.Text = Me.dtpCmpyrfrom.Value.Date.ToString("dd/MM/yyyy")
    End Sub

    Private Sub dtpCmpYrto_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpCmpYrto.ValueChanged
        Me.txtCmpTodt.Text = Me.dtpCmpYrto.Value.Date.ToString("dd/MM/yyyy")
    End Sub

    Private Sub txtSrchCmpAddCmp_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSrchCmpAddCmp.TextChanged
        If txtSrchCmpAddCmp.Text = "" Then
            BindCompanyGridView("")
        Else
            BindCompanyGridView(txtSrchCmpAddCmp.Text)
        End If
    End Sub

    Private Sub txtSrchcmpNmAddUser_TextChanged1(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSrchcmpNmAddUser.TextChanged
        If txtSrchcmpNmAddUser.Text = "" Then
            BindUserGridView("")
        Else
            BindUserGridView(txtSrchcmpNmAddUser.Text)
        End If
    End Sub

    Private Sub gridUser_CellContentClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridUser.CellContentClick
        If e.ColumnIndex = 3 Then
            Dim Listcmpdata As New List(Of String)
            Listcmpdata = obj.GetMoreValueFromQuery("Select user_name,	pass_word,	company_id from " & _
                    "user_tbl where ID=" & _
                    "" & Val(gridUser.Rows(e.RowIndex).Cells(2).Value) & "", 3)

            txtusernameAdduser.Text = Listcmpdata(0)
            txtPasswordAduser.Text = Listcmpdata(1)

            Dim cmpdts As New List(Of String)
            cmpdts = obj.GetMoreValueFromQuery("select company_name,company_yr from company_tbl where company_id=" & Listcmpdata(2) & "", 2)

            cmbCmpNmAddUser.Text = cmpdts(0)
            cmbcompanyyr.Text = cmpdts(1)


            btnAddUser.Text = "Update"
            lbluserid.Text = gridUser.Rows(e.RowIndex).Cells(2).Value

        End If
        If e.ColumnIndex = 4 Then
            Dim result As Integer = MessageBox.Show("Are you sure want to Delete??", "Caution !!!", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information)
            If result = DialogResult.Cancel Then

            ElseIf result = DialogResult.No Then

            ElseIf result = DialogResult.Yes Then
                obj.QueryExecution("delete from user_tbl where ID=" & Val(gridUser.Rows(e.RowIndex).Cells(2).Value) & "")
            End If
        End If
    End Sub

    Private Sub txtFrmtCntrlCmpNmSearch_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFrmtCntrlCmpNmSearch.TextChanged
        If txtFrmtCntrlCmpNmSearch.Text = "" Then
            BindFormatCntrlGridView("")
        Else
            BindFormatCntrlGridView(txtFrmtCntrlCmpNmSearch.Text)
        End If
    End Sub

    Private Sub gridFrmtCntrl_CellContentClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridFrmtCntrl.CellContentClick
        If e.ColumnIndex = 2 Then
            Dim cmpdts As New List(Of String)
            cmpdts = obj.GetMoreValueFromQuery("select company_name,company_yr from company_tbl where company_id=" & Val(gridFrmtCntrl.Rows(e.RowIndex).Cells(1).Value) & "", 2)
            cmbFrmtCntrlCmpNm.Text = cmpdts(0)
            cmbFrmtCmpYr.Text = cmpdts(1)
            btnFrmtCntrlSave.Text = "Update"
            formatid.Text = gridFrmtCntrl.Rows(e.RowIndex).Cells(1).Value
        End If
        If e.ColumnIndex = 3 Then

        End If
    End Sub

    Private Sub gridMail_CellContentClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridMail.CellContentClick
        If e.ColumnIndex = 3 Then
            Dim Listcmpdata As New List(Of String)
            Listcmpdata = obj.GetMoreValueFromQuery("select  mail_id, mail_user, mail_pass, pop, smtp, pop_port, smtp_port,company_name from email_tbl where ID=" & _
                    "" & Val(gridMail.Rows(e.RowIndex).Cells(2).Value) & "", 8)

            txtmailaddr.Text = Listcmpdata(0)
            txtmailusr.Text = Listcmpdata(1)
            txtmailpwd.Text = Listcmpdata(2)
            txtpop.Text = Listcmpdata(3)
            txtSmtp.Text = Listcmpdata(4)
            txtPopPort.Text = Listcmpdata(5)
            txtSmtpPort.Text = Listcmpdata(6)
            cmbEmailCmpName.Text = Listcmpdata(7)

            btnEmailSave.Text = "Update"
            emailsettingsid.Text = gridMail.Rows(e.RowIndex).Cells(2).Value

        End If
        If e.ColumnIndex = 4 Then
            Dim result As Integer = MessageBox.Show("Are you sure want to Delete??", "Caution !!!", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information)
            If result = DialogResult.Cancel Then

            ElseIf result = DialogResult.No Then

            ElseIf result = DialogResult.Yes Then
                obj.QueryExecution("delete from email_tbl where ID=" & Val(gridMail.Rows(e.RowIndex).Cells(2).Value) & "")
            End If
        End If
    End Sub

    Private Sub txtMailSrch_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMailSrch.TextChanged
        If txtMailSrch.Text = "" Then
            BindMailGridView("")
        Else
            BindMailGridView(txtMailSrch.Text)
        End If
    End Sub

    Private Sub btnsave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsave.Click
        Dim user_name As String
        Dim company_id As Integer = obj.GetOneValueFromQuery("select " & _
                                              "company_id from company_tbl where company_name=" & _
                                              "'" + cmbAssignrolesOrganame.Text + "' and " & _
                                              "company_yr='" + cmbcompanyyrassignroles.Text + "'")
        user_name = cmbUserNameAssignRoles.Text
        Dim user_roles, Querycollection As New List(Of String)
        If chkContacts.Checked = True Then
            user_roles.Add(chkContacts.Text)
        End If
        If rbtitems.Checked = True Then
            user_roles.Add(rbtitems.Text)
        End If
        If chkPurBills.Checked = True Then
            user_roles.Add(chkPurBills.Text)
        End If
        If chkAdvance.Checked = True Then
            user_roles.Add(chkAdvance.Text)
        End If
        If chkIndent.Checked = True Then
            user_roles.Add(chkIndent.Text)
        End If
        If chkInventory.Checked = True Then
            user_roles.Add(chkInventory.Text)
        End If
        If chkQuotation.Checked = True Then
            user_roles.Add(chkQuotation.Text)
        End If
        If chkBillofSupply.Checked = True Then
            user_roles.Add(chkBillofSupply.Text)
        End If
        If chkInvoice.Checked = True Then
            user_roles.Add(chkInvoice.Text)
        End If
        If chkPos.Checked = True Then
            user_roles.Add(chkPos.Text)
        End If
        If chkGatepass.Checked = True Then
            user_roles.Add(chkGatepass.Text)
        End If
        If chkFinance.Checked = True Then
            user_roles.Add(chkFinance.Text)
        End If
        If chkAccheads.Checked = True Then
            user_roles.Add(chkAccheads.Text)
        End If
        If chkReciept.Checked = True Then
            user_roles.Add(chkReciept.Text)
        End If
        If chkPayment.Checked = True Then
            user_roles.Add(chkPayment.Text)
        End If
        If chkCreditDebit.Checked = True Then
            user_roles.Add(chkCreditDebit.Text)
        End If
        If chkReport.Checked = True Then
            user_roles.Add(chkReport.Text)
        End If
        If chkGst.Checked = True Then
            user_roles.Add(chkGst.Text)
        End If
        If chkSetting.Checked = True Then
            user_roles.Add(chkSetting.Text)
        End If
        Select Case btnsave.Text
            Case Is = "Save"
            Case Is = "Update"
                obj.QueryExecution("delete from user_roles where company_id=" & company_id & " and user_name='" + user_name + "'")
                btnsave.Text = "Save"
        End Select

        For i = 0 To user_roles.Count - 1
            Querycollection.Add("insert into user_roles(company_id,user_name,	menus) values(" & company_id & ",'" + user_name + "','" + user_roles(i) + "')")
        Next

        Dim result As Boolean = obj.TransactionInsert(Querycollection)
        Select Case result
            Case True
                MsgBox("User roles Details Updated!!", MessageBoxIcon.Information)
            Case False
                MsgBox("Something Went Wrong!!", MessageBoxIcon.Exclamation)
        End Select
        formLoad(e, e)
        ' Me.Settings_Load(e, e)

    End Sub

    Private Sub gridUserroles_CellContentClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridUserroles.CellContentClick

        If e.ColumnIndex = 3 Then
            'Dim Listcmpdata As New List(Of String)
            'Listcmpdata = obj.GetMoreValueFromQuery("select  distinct  user_name from user_tbl where company_id=" & _
            '        "" & Val(gridUserroles.Rows(e.RowIndex).Cells(2).Value) & " and user_nsa", 1)

            obj.ClearCheckBox(Me)

            Dim cmpdts As New List(Of String)
            cmpdts = obj.GetMoreValueFromQuery("select company_name,company_yr from company_tbl where company_id=" & Val(gridUserroles.Rows(e.RowIndex).Cells(2).Value) & "", 2)
            cmbAssignrolesOrganame.Text = cmpdts(0)
            cmbcompanyyrassignroles.Text = cmpdts(1)
            Dim userlist As New List(Of String)
            userlist = obj.getcolumndatafromquery("select user_name from company_tbl a,user_tbl b where a.company_id=b.company_id " & _
                                                  "and  a.company_name='" + cmbAssignrolesOrganame.Text + "'")
            For i = 0 To userlist.Count - 1
                cmbUserNameAssignRoles.Items.Add(userlist(i))
            Next
            cmbUserNameAssignRoles.Text = gridUserroles.Rows(e.RowIndex).Cells(1).Value
            btnsave.Text = "Update"
            Dim listmenus As New List(Of String)
            listmenus = obj.getcolumndatafromquery("select menus from user_roles where company_id=" + gridUserroles.Rows(e.RowIndex).Cells(2).Value + " and  user_name='" + gridUserroles.Rows(e.RowIndex).Cells(1).Value + "'")
            For i = 0 To listmenus.Count - 1
                If chkContacts.Text = listmenus(i) Then
                    chkContacts.Checked = True
                End If
                If rbtitems.Text = listmenus(i) Then
                    rbtitems.Checked = True
                End If
                If chkPurBills.Text = listmenus(i) Then
                    chkPurBills.Checked = True
                End If
                If chkAdvance.Text = listmenus(i) Then
                    chkAdvance.Checked = True
                End If
                If chkIndent.Text = listmenus(i) Then
                    chkContacts.Checked = True
                End If
                If chkInventory.Text = listmenus(i) Then
                    chkInventory.Checked = True
                End If
                If chkQuotation.Text = listmenus(i) Then
                    chkQuotation.Checked = True
                End If
                If chkBillofSupply.Text = listmenus(i) Then
                    chkBillofSupply.Checked = True
                End If
                If chkInvoice.Text = listmenus(i) Then
                    chkInvoice.Checked = True
                End If
                If chkPos.Text = listmenus(i) Then
                    chkPos.Checked = True
                End If
                If chkGatepass.Text = listmenus(i) Then
                    chkGatepass.Checked = True
                End If
                If chkFinance.Text = listmenus(i) Then
                    chkFinance.Checked = True
                End If
                If chkAccheads.Text = listmenus(i) Then
                    chkAccheads.Checked = True
                End If
                If chkReciept.Text = listmenus(i) Then
                    chkReciept.Checked = True
                End If
                If chkPayment.Text = listmenus(i) Then
                    chkPayment.Checked = True
                End If
                If chkCreditDebit.Text = listmenus(i) Then
                    chkCreditDebit.Checked = True
                End If
                If chkReport.Text = listmenus(i) Then
                    chkGst.Checked = True
                End If
                If chkGst.Text = listmenus(i) Then
                    chkContacts.Checked = True
                End If
                If chkSetting.Text = listmenus(i) Then
                    chkSetting.Checked = True
                End If
            Next
        End If
        If e.ColumnIndex = 4 Then

        End If
    End Sub

    Private Sub btnSaveTax_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveTax.Click
        Dim QueryCollection As New List(Of String)
        For i = 0 To gridTax.Rows.Count - 1
            QueryCollection.Add("update taxgroup_tbl set tax_type='" + gridTax.Rows(i).Cells(1).Value + "',tax_rate=" & gridTax.Rows(i).Cells(2).Value & ",tax_group='" + gridTax.Rows(i).Cells(3).Value + "',tax_desc='" + gridTax.Rows(i).Cells(4).Value + "' where ID=" & gridTax.Rows(i).Cells(0).Value & "")
        Next
        Dim result As Boolean = obj.TransactionInsert(QueryCollection)
        Select Case result
            Case True
                MsgBox("Tax Details Updated!!", MessageBoxIcon.Information)
            Case False
                MsgBox("Something Went Wrong!!", MessageBoxIcon.Exclamation)
        End Select
        gridTax.DataSource = obj.getdatatable("select ID,tax_type as TaxType,tax_rate as TaxRate,tax_group as TaxGroup,tax_desc as Description from taxgroup_tbl ")
        gridTax.AutoGenerateColumns = False
        gridTax.AllowUserToAddRows = False
        gridTax.Columns(0).ReadOnly = True
        formLoad(e, e)
    End Sub

    Private Sub btnStkAdj_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStkAdj.Click
        'Select   ID	item_no	qty from stock_tbl where 	company_id=''

        Dim QueryCollection As New List(Of String)
        For i = 0 To gridStock.Rows.Count - 1
            QueryCollection.Add("update stock_tbl set qty=" & gridStock.Rows(i).Cells(2).Value & " where ID=" & gridStock.Rows(i).Cells(0).Value & "")
        Next
        Dim result As Boolean = obj.TransactionInsert(QueryCollection)
        Select Case result
            Case True
                MsgBox("Stocks Details Updated!!", MessageBoxIcon.Information)
            Case False
                MsgBox("Something Went Wrong!!", MessageBoxIcon.Exclamation)
        End Select
        formLoad(e, e)
    End Sub

    Private Sub cmbstockcmpname_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbstockcmpname.SelectedIndexChanged
        Dim value As String = cmbstockcmpname.Text
        Dim lstcmpyr As New List(Of String)
        lstcmpyr = obj.getcolumndatafromquery("select company_yr from company_tbl where company_name='" + value + "'")
        cmbstockcompyr.Items.Clear()
        For i = 0 To lstcmpyr.Count - 1
            cmbstockcompyr.Items.Add(lstcmpyr(i))
        Next
    End Sub

    Private Sub cmbstockcompyr_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbstockcompyr.SelectedIndexChanged
        Dim company_id As Integer = obj.GetOneValueFromQuery("select company_id from company_tbl where company_name='" + cmbstockcmpname.Text + "' and company_yr='" + cmbstockcompyr.Text + "'")
        Dim dt As New DataTable
        dt = obj.getdatatable("Select a.ID as SrNo,b.item_name As ItemName,a.qty as CurrentStock from stock_tbl a,item_tbl b where a.item_no=b.item_no and b.item_type='Goods' and a.company_id=" & company_id & "")
        gridStock.DataSource = dt
        gridStock.AutoGenerateColumns = False
        gridStock.AllowUserToAddRows = False
        gridStock.Columns(0).ReadOnly = True
        gridStock.Columns(1).ReadOnly = True
    End Sub

    Private Sub txtAssignUser_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAssignUser.TextChanged
        If txtAssignUser.Text = "" Then
            BindUserRolesGridView("")
        Else
            BindUserRolesGridView(txtAssignUser.Text)
        End If
    End Sub

    Private Sub txtBankCmpNmSrch_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtBankCmpNmSrch.TextChanged
        If txtBankCmpNmSrch.Text = "" Then
            BindUserGridView("")
        Else
            BindBankGridView(txtBankCmpNmSrch.Text)
        End If
    End Sub

    Private Sub formLoad(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Controls.Clear()
        InitializeComponent()
        Me.Settings_Load(e, e)
    End Sub

    Private Sub txtPanno_KeyUp(ByVal sender As System.Object, ByVal e As KeyPressEventArgs) Handles txtPanno.KeyPress
        obj.AllCaps(e, txtPanno)

    End Sub
    Private Sub txtAddCmpCompanyname_KeyUp(ByVal sender As System.Object, ByVal e As KeyPressEventArgs) Handles txtAddCmpCompanyname.KeyPress
        obj.AllCaps(e, txtAddCmpCompanyname)

    End Sub
    Private Sub txtGstNo_KeyUp(ByVal sender As System.Object, ByVal e As KeyPressEventArgs) Handles txtGstNo.KeyPress

        obj.AllCaps(e, txtGstNo)
    End Sub

    Private Sub cmbAssignrolesOrganame_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbAssignrolesOrganame.SelectedIndexChanged

        Dim value As String = cmbAssignrolesOrganame.Text
        Dim lstcmpyr As New List(Of String)
        lstcmpyr = obj.getcolumndatafromquery("select company_yr from company_tbl where company_name='" + value + "'")
        cmbcompanyyrassignroles.Items.Clear()
        For i = 0 To lstcmpyr.Count - 1
            cmbcompanyyrassignroles.Items.Add(lstcmpyr(i))
        Next
    End Sub

    Private Sub cmbcompanyyrassignroles_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbcompanyyrassignroles.SelectedIndexChanged
        Dim value As String = cmbcompanyyrassignroles.Text
        Dim lstcmpyr As New List(Of String)
        lstcmpyr = obj.getcolumndatafromquery("select user_name from user_tbl where " & _
                                              "company_id=" + obj.GetOneValueFromQuery("select " & _
                                              "company_id from company_tbl where company_name=" & _
                                              "'" + cmbAssignrolesOrganame.Text + "' and " & _
                                              "company_yr='" + value + "'") + "")
        cmbUserNameAssignRoles.Items.Clear()
        For i = 0 To lstcmpyr.Count - 1
            cmbUserNameAssignRoles.Items.Add(lstcmpyr(i))
        Next
    End Sub


End Class