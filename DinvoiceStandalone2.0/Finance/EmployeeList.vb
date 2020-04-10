Public Class EmployeeList
    Dim obj As New ObjClass
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        SalaryGroup.Show()
        SalaryGroup.BringToFront()
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim employee_no, employee_name, DOJ, address,
            state, city, pincode, emailid, DOB, ESI_no, PF_no,
            Aadhar_no, bank_name, account_no, branch_name, IFSC_no,
            account_type, salary_grp, salary

        employee_name = txtempname.Text
        DOJ = txtdoj.Text
        address = txtaddress.Text
        state = cmbstate.Text
        city = txtcity.Text
        pincode = txtpincode.Text
        emailid = txtemailid.Text
        DOB = txtdob.Text
        ESI_no = txtesino.Text
        PF_no = txtpfno.Text
        Aadhar_no = txtaadharno.Text
        bank_name = txtbankname.Text
        account_no = txtaccountno.Text
        branch_name = txtbranchname.Text
        IFSC_no = txtifscno.Text
        account_type = cmbacctype.Text
        salary_grp = cmbsalarygrp.SelectedValue
        salary = txtsalary.Text
        Dim QueryCollection As New List(Of String)
        Select Case btnSave.Text
            Case Is = "Save"
                employee_no = obj.GetOneValueFromQuery("select employee_no from control_tbl where company_id=" & SharedData.companyid & "")

                QueryCollection.Add("insert into employee_tbl(employee_no, employee_name, DOJ, address," & _
            "state, city, pincode, emailid, DOB, ESI_no, PF_no," & _
            "Aadhar_no, bank_name, account_no, branch_name, IFSC_no," & _
            "account_type, salary_grp, salary) values('" + employee_no + "','" + employee_name + "'," & _
            "'" + DOJ + "','" + address + "','" + state + "','" + city + "'," & _
            "'" + pincode + "','" + emailid + "','" + DOB + "','" + ESI_no + "'," & _
            "'" + PF_no + "','" + Aadhar_no + "','" + bank_name + "','" + account_no + "'," & _
            "'" + branch_name + "','" + IFSC_no + "','" + account_type + "','" + salary_grp + "','" + salary + "'" & _
            ")")

                QueryCollection.Add("update control_tbl set employee_no=employee_no+1 where company_id=" & SharedData.companyid & "")

            Case Is = "Update"
                employee_no = lblid.Text
                QueryCollection.Add("update employee_tbl set employee_name='" + employee_name + "', DOJ='" + DOJ + "'," & _
            " address='" + address + "'," & _
            "state='" + state + "', city='" + city + "', pincode='" + pincode + "', " & _
            "emailid='" + emailid + "', DOB='" + DOB + "', ESI_no='" + ESI_no + "', PF_no='" + PF_no + "'," & _
            "Aadhar_no='" + Aadhar_no + "', bank_name='" + bank_name + "', " & _
            "account_no='" + account_no + "', branch_name='" + branch_name + "', IFSC_no='" + IFSC_no + "'," & _
            "account_type='" + account_type + "', salary_grp='" + salary_grp + "'," & _
            " salary=" + salary + "  where employee_no='" + employee_no + "'")
                lblid.Text = ""
                btnSave.Text = "Save"
        End Select

        Dim result As Boolean = obj.TransactionInsert(QueryCollection)
        Select Case result
            Case True
                MsgBox("Employee details updated!!", MessageBoxIcon.Information)
                Me.Controls.Clear()
                InitializeComponent()
                Me.EmployeeList_Load(e, e)
            Case False
                MsgBox("Something Went Wrong!!", MessageBoxIcon.Exclamation)
        End Select
        
    End Sub

   
    Sub bindgridview(ByVal p1 As String)
        Try
            griddata.ColumnCount = 4
            griddata.Columns(0).Name = "Name"
            griddata.Columns(1).Name = "Aadhar Card"
            griddata.Columns(2).Name = "Salary"
            griddata.Columns(3).Name = ""
            griddata.Rows.Clear()
            Dim dt1 As New DataTable

            dt1 = obj.getdatatable("select employee_no, employee_name," & _
            "Aadhar_no, salary	 from employee_tbl where employee_name like '%" + p1 + "%'")

            For i = 0 To dt1.Rows.Count - 1
                griddata.Rows.Add(dt1.Rows(i).Item(1).ToString, dt1.Rows(i).Item(2).ToString, dt1.Rows(i).Item(3).ToString, dt1.Rows(i).Item(0).ToString)
            Next
            'gridAddCmp.DataSource = dt1
            If griddata.Rows.Count = 6 Then
            Else
                Dim btn As New DataGridViewButtonColumn
                btn.Name = "edit"
                btn.HeaderText = ""
                btn.Text = "EDIT"
                btn.UseColumnTextForButtonValue = True
                griddata.Columns.Add(btn)

                Dim btn1 As New DataGridViewButtonColumn
                btn1.Name = "delete"
                btn1.HeaderText = ""
                btn1.Text = "DELETE"
                btn1.UseColumnTextForButtonValue = True
                griddata.Columns.Add(btn1)

            End If


           

            griddata.Refresh()
            griddata.ReadOnly = True
            griddata.AutoGenerateColumns = False
            griddata.AllowUserToAddRows = False
            griddata.Columns(3).Visible = False
            griddata.ClearSelection()
        Catch ex As Exception
            MsgBox(ex.Message, , MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub griddata_CellContentClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles griddata.CellContentClick
        Try
            If e.ColumnIndex = 4 Then
                Dim Listdata As New List(Of String)
                Listdata = obj.GetMoreValueFromQuery("Select 	 employee_name, DOJ, address," & _
            "state, city, pincode, emailid, DOB, ESI_no, PF_no," & _
            "Aadhar_no, bank_name, account_no, branch_name, IFSC_no," & _
            "account_type, salary_grp, salary from " & _
                        "employee_tbl where employee_no=" & _
                        "'" + griddata.Rows(e.RowIndex).Cells(3).Value + "'", 18)

                txtempname.Text = Listdata(0)
                txtdoj.Text = Listdata(1)
                txtaddress.Text = Listdata(2)
                cmbstate.Text = Listdata(3)
                txtcity.Text = Listdata(4)
                txtpincode.Text = Listdata(5)
                txtemailid.Text = Listdata(6)
                txtdob.Text = Listdata(7)
                txtesino.Text = Listdata(8)
                txtpfno.Text = Listdata(9)
                txtaadharno.Text = Listdata(10)
                txtbankname.Text = Listdata(11)
                txtaccountno.Text = Listdata(12)
                txtbranchname.Text = Listdata(13)
                txtifscno.Text = Listdata(14)
                cmbacctype.Text = Listdata(15)
                cmbsalarygrp.SelectedValue = Listdata(16)
                txtsalary.Text = Listdata(17)

                btnSave.Text = "Update"
                lblid.Text = griddata.Rows(e.RowIndex).Cells(3).Value

            End If
            If e.ColumnIndex = 5 Then
                Dim result As Integer = MessageBox.Show("Are you sure want to Delete??", "Caution !!!", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning)
                If result = DialogResult.Cancel Then

                ElseIf result = DialogResult.No Then

                ElseIf result = DialogResult.Yes Then
                    obj.QueryExecution("delete from employee_tbl where employee_no='" + griddata.Rows(e.RowIndex).Cells(3).Value + "'")
                End If
                EmployeeList_Load(e, e)
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MessageBoxIcon.Exclamation)
        End Try
    End Sub

    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        Me.Controls.Clear()
        InitializeComponent()
        EmployeeList_Load(e, e)
    End Sub

    Private Sub dtpdoj_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpdoj.ValueChanged
        obj.dtpick(txtdoj, dtpdoj)
    End Sub

    Private Sub dtpdob_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpdob.ValueChanged
        obj.dtpick(txtdob, dtpdob)
    End Sub

    Private Sub txtsalary_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtsalary.KeyPress
        obj.OnlyNoS(e)
    End Sub

    Private Sub EmployeeList_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim liststate As New List(Of String)
        cmbstate.Items.Clear()
        liststate = obj.getcolumndatafromquery("select indian_state from state_tbl")
        For i = 0 To liststate.Count - 1
            cmbstate.Items.Add(liststate(i))
        Next

        Dim listvendorname As New DataTable
        cmbsalarygrp.DataSource = Nothing
        listvendorname = obj.getdatatable("select salarygroup_name,salarygroup_no from salarygroup_tbl")
        cmbsalarygrp.DisplayMember = "salarygroup_name"
        cmbsalarygrp.ValueMember = "salarygroup_no"
        cmbsalarygrp.DataSource = listvendorname
        cmbsalarygrp.Visible = True

        bindgridview("")
    End Sub

    Private Sub txtsearch_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtsearch.KeyUp
        If txtsearch.Text = "" Then
            bindgridview("")
        Else
            bindgridview(txtsearch.Text)
        End If

    End Sub
End Class