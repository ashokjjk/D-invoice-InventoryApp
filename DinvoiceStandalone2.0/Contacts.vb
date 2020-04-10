Public Class Contacts
    Dim obj As New ObjClass
    Private Sub Contacts_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            MaximizeBox = False
            MinimizeBox = False
            txtGstNo.Visible = False
            Label22.Visible = False
            lblGst.Visible = False
            txtName.Focus()
            Dim liststate As New List(Of String)
            cmbPlaceofSup.Items.Clear()
            liststate = obj.getcolumndatafromquery("select indian_state from state_tbl")
            For i = 0 To liststate.Count - 1
                cmbPlaceofSup.Items.Add(liststate(i))
            Next
            BindCustomerGridView("")
        Catch ex As Exception
            MsgBox(ex.Message, MessageBoxIcon.Warning)
        End Try
    End Sub

    Private Sub cmbGSTtreat_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbGSTtreat.SelectedIndexChanged
        Select Case cmbGSTtreat.Text
            Case Is = "Registered Business", "Composite Taxable Person"
                txtGstNo.Visible = True
                Label22.Visible = True
                lblGst.Visible = True
            Case Else
                txtGstNo.Visible = False
                lblGst.Visible = False
                Label22.Visible = False
        End Select
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try

       
        Dim contact_no, contact_type, company_name, contact_name, phone_no, email_id, gst_treatment, gst_no, place_supply, billing_address, ship_address As String
        Dim tds_percent As Double
        Dim company_id As Integer '',,''
        company_id = Val(SharedData.companyid)
            contact_type = ""
        If rbtCustomer.Checked = True Then
            contact_type = "Customer"
        End If
        If rbtVendor.Checked = True Then
            contact_type = "Vendor"
        End If
        If rbtBoth.Checked = True Then
            contact_type = "Both"
        End If
        company_name = txtcompanyname.Text
        contact_name = txtName.Text
        phone_no = txtPhone.Text
        email_id = txtEmailid.Text
        gst_treatment = cmbGSTtreat.Text
            If gst_treatment = "Registered Business" Or gst_treatment = "Composite Taxable Person" Then
                gst_no = txtGstNo.Text
            Else
                gst_no = ""
            End If

        place_supply = cmbPlaceofSup.Text
        billing_address = txtBillingAddr.Text
        ship_address = txtShpAddress.Text
            tds_percent = txttdspercent.Text

            If contact_type = "" Then
                MsgBox("Please Enter Contact Type (Vendor/Customer)??", MessageBoxIcon.Error)
                Exit Sub
            End If
            If contact_name = "" Then
                MsgBox("Please Enter Contact Name!!", MessageBoxIcon.Error)
                txtName.Focus()
                Exit Sub
            End If
            If company_name = "" Then
                MsgBox("Please Enter Company Name!!", MessageBoxIcon.Error)
                txtcompanyname.Focus()
                Exit Sub
            End If
            If gst_treatment = "" Then
                MsgBox("Please Enter GST Treatment!!", MessageBoxIcon.Error)
                cmbGSTtreat.Focus()
                Exit Sub
            ElseIf gst_treatment = "Registered Business" Then
                If gst_no = "" Then
                    MsgBox("Please Enter GST No!!", MessageBoxIcon.Error)
                    txtGstNo.Focus()
                    Exit Sub
                End If
            Else
            End If
            If billing_address = "" Then
                MsgBox("Please Enter Billing Address!!", MessageBoxIcon.Error)
                txtBillingAddr.Focus()
                Exit Sub
            End If
            If ship_address = "" Then
                MsgBox("Please Enter Shipping Address!!", MessageBoxIcon.Error)
                txtShpAddress.Focus()
                Exit Sub
            End If
            If place_supply = "" Then
                MsgBox("Please Enter Place of Supply!!", MessageBoxIcon.Error)
                cmbPlaceofSup.Focus()
                Exit Sub
            End If
        Dim QueryCollection As New List(Of String)
        Select Case btnSave.Text
            Case Is = "Save"
                contact_no = obj.GetOneValueFromQuery("select contact_no from control_tbl where company_id=" & company_id & "")
                QueryCollection.Add("insert into contact_tbl(contact_no	,company_name,	contact_type	" & _
         ",contact_name,	phone_no,	email_id	,gst_treatment,	gst_no,	place_supply	,billing_address," & _
         "	ship_address,	tds_percent) values ('" + contact_no + "','" + company_name + "'," & _
         "'" + contact_type + "','" + contact_name + "','" + phone_no + "','" + email_id + "'," & _
         "'" + gst_treatment + "','" + gst_no + "','" + place_supply + "','" + billing_address + "'," & _
         "'" + ship_address + "'," & tds_percent & ")")
                QueryCollection.Add("update control_tbl set contact_no=contact_no+1   where company_id=" & company_id & "")
            Case Is = "Update"
                contact_no = lblcuscode.Text
                    QueryCollection.Add("update contact_tbl set company_name='" + company_name + "',	contact_type='" + contact_type + "'	" & _
             ",contact_name='" + contact_name + "',	phone_no='" + phone_no + "',	email_id='" + email_id + "'	" & _
             ",gst_treatment='" + gst_treatment + "',	gst_no='" + gst_no + "',	place_supply='" + place_supply + "'" & _
             "	,billing_address='" + billing_address + "'," & _
             "	ship_address='" + ship_address + "',	tds_percent=" & tds_percent & " where contact_no='" + contact_no + "'")
                btnSave.Text = "Save"
                lblcuscode.Text = ""
        End Select
        Dim result As Boolean = obj.TransactionInsert(QueryCollection)
        Select Case result
            Case True
                    MsgBox("Contact details updated!!", MessageBoxIcon.Information)
            Case False
                    MsgBox("Something Went Wrong!!", MessageBoxIcon.Exclamation)
        End Select
            Me.Controls.Clear()
            InitializeComponent()
            Me.Contacts_Load(e, e)

        Catch ex As Exception
            MsgBox(ex.Message, MessageBoxIcon.Exclamation)
        End Try
    End Sub

    Private Sub txtSearch_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSearch.TextChanged
        If txtSearch.Text = "" Then
            BindCustomerGridView("")
        Else
            BindCustomerGridView(txtSearch.Text)
        End If
    End Sub

    Private Sub gridCustomer_CellContentClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridCustomer.CellContentClick
        Try
            If e.ColumnIndex = 6 Then
                Dim Listdata As New List(Of String)
                Listdata = obj.GetMoreValueFromQuery("Select 	company_name,	contact_type	" & _
             ",contact_name,	phone_no,	email_id	,gst_treatment,	gst_no,	place_supply	,billing_address," & _
             "	ship_address,	tds_percent from " & _
                        "contact_tbl where contact_no=" & _
                        "'" + gridCustomer.Rows(e.RowIndex).Cells(3).Value + "'", 11)
                If Listdata(1) = "Customer" Then

                    rbtCustomer.Checked = True
                End If
                If Listdata(1) = "Vendor" Then
                    rbtVendor.Checked = True
                End If
                If Listdata(1) = "Both" Then
                    rbtBoth.Checked = True
                End If
                txtcompanyname.Text = Listdata(0)
                txtName.Text = Listdata(2)
                txtPhone.Text = Listdata(3)
                txtEmailid.Text = Listdata(4)
                cmbGSTtreat.Text = Listdata(5)
                txtGstNo.Text = Listdata(6)
                cmbPlaceofSup.Text = Listdata(7)
                txtBillingAddr.Text = Listdata(8)
                txtShpAddress.Text = Listdata(9)
                txttdspercent.Text = Listdata(10)

                btnSave.Text = "Update"
                lblcuscode.Text = gridCustomer.Rows(e.RowIndex).Cells(3).Value

            End If
            If e.ColumnIndex = 7 Then
                Dim result As Integer = MessageBox.Show("Are you sure want to Delete??", "Caution !!!", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning)
                If result = DialogResult.Cancel Then

                ElseIf result = DialogResult.No Then

                ElseIf result = DialogResult.Yes Then
                    obj.QueryExecution("delete from contact_tbl where contact_no='" + gridCustomer.Rows(e.RowIndex).Cells(3).Value + "'")
                End If
                Contacts_Load(e, e)
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MessageBoxIcon.Exclamation)
        End Try
    End Sub

    Private Sub BindCustomerGridView(ByVal p1 As String)
        Try
            gridCustomer.ColumnCount = 6
            gridCustomer.Columns(0).Name = "Name"
            gridCustomer.Columns(1).Name = "Company"
            gridCustomer.Columns(2).Name = "GST No"
            gridCustomer.Columns(3).Name = ""
            gridCustomer.Columns(4).Name = "Type"
            gridCustomer.Columns(5).Name = "Phone No"
            gridCustomer.Rows.Clear()
            Dim dt1 As New DataTable
            If rbtName.Checked = True Then
                dt1 = obj.getdatatable("select top 50 contact_name	,company_name,gst_no,contact_no,contact_type,phone_no	 from contact_tbl where contact_name like '%" + p1 + "%'")

            ElseIf rbtCmpname.Checked = True Then
                dt1 = obj.getdatatable("select top 50 contact_name	,company_name,gst_no,contact_no,contact_type,phone_no	 from contact_tbl where company_name like '%" + p1 + "%'")

            ElseIf rbtGstNo.Checked = True Then
                dt1 = obj.getdatatable("select top 50 contact_name	,company_name,gst_no,contact_no,contact_type,phone_no	 from contact_tbl where gst_no like '%" + p1 + "%'")
            Else
                dt1 = obj.getdatatable("select top 50 contact_name	,company_name,gst_no,contact_no,contact_type,phone_no	 from contact_tbl")
            End If



            For i = 0 To dt1.Rows.Count - 1
                gridCustomer.Rows.Add(dt1.Rows(i).Item(0).ToString, dt1.Rows(i).Item(1).ToString, dt1.Rows(i).Item(2).ToString, dt1.Rows(i).Item(3).ToString, dt1.Rows(i).Item(4).ToString, dt1.Rows(i).Item(5).ToString)
            Next
            'gridAddCmp.DataSource = dt1
            Dim btn As New DataGridViewButtonColumn
            btn.Name = "edit"
            btn.HeaderText = ""
            btn.Text = "EDIT"
            btn.UseColumnTextForButtonValue = True
            gridCustomer.Columns.Add(btn)

            Dim btn1 As New DataGridViewButtonColumn
            btn1.Name = "delete"
            btn1.HeaderText = ""
            btn1.Text = "DELETE"
            btn1.UseColumnTextForButtonValue = True
            gridCustomer.Columns.Add(btn1)


            gridCustomer.Refresh()
            gridCustomer.ReadOnly = True
            gridCustomer.AutoGenerateColumns = False
            gridCustomer.AllowUserToAddRows = False
            gridCustomer.Columns(3).Visible = False
            gridCustomer.ClearSelection()
        Catch ex As Exception
            MsgBox(ex.Message, , MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        Me.Controls.Clear()
        InitializeComponent()
        Contacts_Load(e, e)
    End Sub
End Class