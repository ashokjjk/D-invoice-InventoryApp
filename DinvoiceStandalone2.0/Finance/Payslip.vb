Public Class Payslip
    Dim obj As New ObjClass
    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        EmployeeList.Show()
        EmployeeList.BringToFront()



    End Sub

    Private Sub RadioButton1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtnind.CheckedChanged
      checkboxfunction


    End Sub

    Private Sub Payslip_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim year As Integer = Format(Now, "yyyy")
        cmbyear.Items.Add(year)
        cmbyear.Items.Add(year + 1)
        cmbyear.Items.Add(year + 2)

    End Sub



    Private Sub CalculationArea()
        Dim basic, da, hra, others, bonus, esi, pf, trs, otherdeductions, advance, netsalary, wholesalary As Double
        wholesalary = 0
        For i = 0 To griddata.Rows.Count - 1
            If CBool(griddata.Rows(i).Cells(0).Value.ToString) = True Then
                Try
                    basic = griddata.Rows(i).Cells(2).Value.ToString
                    da = griddata.Rows(i).Cells(3).Value.ToString
                    hra = griddata.Rows(i).Cells(4).Value.ToString
                    others = griddata.Rows(i).Cells(5).Value.ToString
                    bonus = griddata.Rows(i).Cells(6).Value.ToString
                    esi = griddata.Rows(i).Cells(7).Value.ToString
                    pf = griddata.Rows(i).Cells(8).Value.ToString
                    trs = griddata.Rows(i).Cells(9).Value.ToString
                    otherdeductions = griddata.Rows(i).Cells(10).Value.ToString
                    advance = griddata.Rows(i).Cells(11).Value.ToString
                Catch ex As Exception
                    MsgBox("Input Is not correct!!", MsgBoxStyle.Exclamation)
                    Exit Sub
                End Try
            End If
            netsalary = (basic + da + hra + others + bonus) - (esi + pf + trs + otherdeductions + advance)
            wholesalary = wholesalary + netsalary
            griddata.Rows(i).Cells(12).Value = netsalary
        Next
        lbltotalsalary.Text = wholesalary
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If validmonth() = False Then
            Exit Sub
        End If


        CalculationArea()

        Dim payslip_no, pMonth, pyear, Monyr, employee_no, basic, da, hra, others, bonus,
            esi, pf, trs, otherdeduction, advance, netsalary, companyid, username As String
        payslip_no = obj.GetOneValueFromQuery("select payslip_no from control_tbl where company_id=" & SharedData.companyid & "")
        pMonth = cmbmonth.Text
        pyear = cmbyear.Text
        Monyr = pMonth.Substring(0, 3) + "-" + pyear
        companyid = SharedData.companyid
        username = SharedData.userid
        Dim count = 0
        Dim oripayno = payslip_no
        Dim payment_method = Me.cmbPaymode.Text
        Dim QueryList As New List(Of String)

        Dim totalsalary As Double = Me.lbltotalsalary.Text
        If payment_method = "" Then
            MsgBox("Payment Method is Mandatory!!")
            Exit Sub
        ElseIf payment_method = "Cash" Then
            Me.cmbBankname.Text = ""
            Me.txtChqno.Text = ""
            Me.txtChqdt.Text = "01/01/1900"
        Else
        End If
        If payment_method = "Cash" Then
            QueryList.Add("update bank_tbl set  pettycash_closingBalance=pettycash_closingBalance-" & totalsalary & "	where  company_id=" + companyid + "")
        ElseIf payment_method = "Cheque" Then
            QueryList.Add("update bank_tbl set  bank_closeBalance=bank_closeBalance-" & totalsalary & "	where ID=" & Me.cmbBankname.SelectedValue & "")
        Else
        End If

        Dim voucher_no, voucher_user_no, voucher_dt, voucher_type As String
        voucher_no = obj.GetOneValueFromQuery("select voucher_frmt&''&voucher_no from control_tbl where company_id=" + SharedData.companyid + "")
        voucher_user_no = voucher_no
        voucher_dt = Format(Now, "dd/MM/yyyy")
        voucher_type = "WS"
        QueryList.Add("insert into voucher_tbl (voucher_no,voucher_user_no,contact_no,voucher_dt,voucher_type," & _
                      "	account_id,	vouchercpt_flg,	voucherpaymt_flg,	" & _
                      "payment_type,	credit_debit_bank,	cheque_no,	" & _
                      "cheque_dt,	voucher_amt,	tds_percent,	total_amt,	" & _
                      "notes,	company_id,	user_name) values('" + voucher_no + "','" + voucher_user_no + "','0'," & _
                      "'" + voucher_dt + "','" + voucher_type + "',37," & _
                      "0,1,'" + payment_method + "','" + Me.cmbBankname.Text + "','" + Me.txtChqno.Text + "','" + Me.txtChqdt.Text + "'" & _
                      "," & totalsalary & ",0," & totalsalary & "" & _
                      ",''" & _
                      "," + companyid + ",'" + username + "'" & _
                      ")")
        QueryList.Add("update control_tbl set voucher_no=voucher_no+1 where company_id=" + companyid + "")


        For i = 0 To griddata.Rows.Count - 1
            If CBool(griddata.Rows(i).Cells(0).Value.ToString) = True Then
                basic = griddata.Rows(i).Cells(2).Value.ToString
                da = griddata.Rows(i).Cells(3).Value.ToString
                hra = griddata.Rows(i).Cells(4).Value.ToString
                others = griddata.Rows(i).Cells(5).Value.ToString
                bonus = griddata.Rows(i).Cells(6).Value.ToString
                esi = griddata.Rows(i).Cells(7).Value.ToString
                pf = griddata.Rows(i).Cells(8).Value.ToString
                trs = griddata.Rows(i).Cells(9).Value.ToString
                otherdeduction = griddata.Rows(i).Cells(10).Value.ToString
                advance = griddata.Rows(i).Cells(11).Value.ToString
                netsalary = griddata.Rows(i).Cells(12).Value.ToString '(basic + da + hra + others + bonus) - (esi + pf + trs + otherdeduction + advance)
                employee_no = griddata.Rows(i).Cells(13).Value.ToString
                QueryList.Add("insert into payslip_tbl (payslip_no, pMonth, pyear, Monyr, employee_no, basic, da, hra, others, bonus," & _
                "esi, pf, trs, otherdeduction, advance, netsalary, companyid, username,payment_method,voucher_no,bank_id) values('" + oripayno + "','" + pMonth + "'" & _
                ",'" + pyear + "','" + Monyr + "','" + employee_no + "','" + basic + "','" + da + "','" + hra + "','" + others + "'" & _
                ",'" + bonus + "','" + esi + "','" + pf + "','" + trs + "','" + otherdeduction + "','" + advance + "','" + netsalary + "'" & _
                ",'" + companyid + "','" + username + "','" + payment_method + "','" + voucher_no + "','" & cmbBankname.SelectedValue & "')")
                oripayno = oripayno + 1
                count = count + 1
            End If
        Next



        QueryList.Add("update control_tbl set payslip_no=payslip_no+" & count & " where company_id=" + companyid + "")

        If obj.FindDuplicate("select count(*) from contact_tbl where contact_type='Employee'") <> 0 Then
        Else
            QueryList.Add("insert into contact_tbl(contact_no	,company_name,	contact_type	" & _
        ",contact_name,	phone_no,	email_id	,gst_treatment,	gst_no,	place_supply	,billing_address," & _
        "	ship_address,	tds_percent) values ('1','Employee Salary'," & _
        "'Employee','','',''," & _
        "'','','',''," & _
        "'',0)")
        End If

        Dim result As Boolean = obj.TransactionInsert(QueryList)
        Select Case result
            Case True
                MsgBox("Pay slip details updated!!", MessageBoxIcon.Information)
                Me.Controls.Clear()
                InitializeComponent()
                Me.Payslip_Load(e, e)
            Case False
                MsgBox("Something Went Wrong!!", MessageBoxIcon.Exclamation)
        End Select
        

    End Sub

    Private Sub cmbPaymode_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbPaymode.SelectedIndexChanged
        Select Case cmbPaymode.Text
            Case Is = "Cash"

                pnlBankdtls.Visible = False

            Case Is = "Cheque"
                pnlBankdtls.Visible = True
                Dim listbank As New DataTable
                cmbBankname.DataSource = Nothing
                cmbBankname.Items.Clear()
                listbank = obj.getdatatable("select bank_name & ' - ' & acc_no as bankdtls,ID from bank_tbl where company_id =" + SharedData.companyid + "")
                cmbBankname.DisplayMember = "bankdtls"
                cmbBankname.ValueMember = "ID"
                cmbBankname.DataSource = listbank



        End Select
    End Sub

    Private Sub dtpChqDt_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpChqDt.ValueChanged
        obj.dtpick(txtChqdt, dtpChqDt)
    End Sub

    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        Me.Controls.Clear()
        InitializeComponent()
        Me.Payslip_Load(e, e)
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            'griddata.ColumnCount = 13
            'griddata.Columns(0).Name = "Employee"
            'griddata.Columns(1).Name = "Basic"
            'griddata.Columns(2).Name = "DA"
            'griddata.Columns(3).Name = "HRA"
            'griddata.Columns(4).Name = "Others"
            'griddata.Columns(5).Name = "Bonus"
            'griddata.Columns(6).Name = "ESI"
            'griddata.Columns(7).Name = "PF"
            'griddata.Columns(8).Name = "TRS"
            'griddata.Columns(9).Name = "Others Deduction"
            'griddata.Columns(10).Name = "Advance"
            'griddata.Columns(11).Name = "Net Salary"
            'griddata.Columns(12).Name = "no"
            griddata.DataSource = Nothing
            griddata.Rows.Clear()
            Dim dt1 As New DataTable
            Dim dtnew As New DataTable
            dtnew.Columns.Add("check", GetType(Boolean))
            dtnew.Columns.Add("Employee", GetType(String))
            dtnew.Columns.Add("Basic", GetType(String))
            dtnew.Columns.Add("DA", GetType(String))
            dtnew.Columns.Add("HRA", GetType(String))
            dtnew.Columns.Add("Others", GetType(String))
            dtnew.Columns.Add("Bonus", GetType(String))
            dtnew.Columns.Add("ESI", GetType(String))
            dtnew.Columns.Add("PF", GetType(String))
            dtnew.Columns.Add("TDS", GetType(String))
            dtnew.Columns.Add("Others Deduction", GetType(String))
            dtnew.Columns.Add("Advance", GetType(String))
            dtnew.Columns.Add("Net Salary", GetType(String))
            dtnew.Columns.Add("no", GetType(String))
            If rbtnind.Checked Then
                dt1 = obj.getdatatable("select employee_name, salary,employee_no	 from employee_tbl where employee_no ='" + cmbname.SelectedValue + "'")
            End If

            If rbtngroup.Checked Then
                dt1 = obj.getdatatable("select employee_name, salary,employee_no	 from employee_tbl where salary_grp ='" + cmbname.SelectedValue + "'")
            End If
            If rbtnall.Checked Then
                dt1 = obj.getdatatable("select  employee_name,salary,employee_no" & _
               "	 from employee_tbl")
            End If
            For i = 0 To dt1.Rows.Count - 1
                dtnew.Rows.Add(True, dt1.Rows(i).Item(0).ToString, dt1.Rows(i).Item(1).ToString, "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", dt1.Rows(i).Item(2).ToString)
            Next
            griddata.DataSource = dtnew

            griddata.Refresh()

            griddata.AutoGenerateColumns = False
            griddata.AllowUserToAddRows = False
            griddata.Columns(13).Visible = False
            griddata.ClearSelection()
        Catch ex As Exception
            MsgBox(ex.Message, , MessageBoxIcon.Error)
        End Try
    End Sub
    Function validmonth() As Boolean
        Try

       
        Dim pMonth = cmbmonth.Text
        Dim pyear = cmbyear.Text
        Dim Monyr = pMonth.Substring(0, 3) + "-" + pyear
        Dim employee_no, employee_name
        Dim msg As String = ""
        Dim count As Integer = 0
        For i = 0 To griddata.Rows.Count - 1
            If CBool(griddata.Rows(i).Cells(0).Value.ToString) = True Then
                employee_no = griddata.Rows(i).Cells(13).Value.ToString
                If obj.FindDuplicate("select count(*) from payslip_tbl where employee_no='" + employee_no + "' and Monyr='" + Monyr + "'") = 0 Then
                Else
                    employee_name = griddata.Rows(i).Cells(1).Value.ToString
                    msg = msg + employee_name + vbCrLf
                    count = count + 1
                End If
            End If
        Next
        If count = griddata.RowCount Then
            MsgBox("Already created salary for all employee this months")
            Return False
        Else
            If msg <> "" Then
                MsgBox(msg + " Already created salary for this month")
                Return True
            Else
                Return True
            End If
        End If
        Catch ex As Exception
            MsgBox("Input is not correct")
            Return False
        End Try


    End Function
    Private Sub rbtnall_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtnall.CheckedChanged
       checkboxfunction
    End Sub
    Sub checkboxfunction()
        If rbtnind.Checked Then
            Panelindgroup.Visible = True
            lblname.Text = "Employee Name"
            Dim listvendorname As New DataTable
            cmbname.DataSource = Nothing
            listvendorname = obj.getdatatable("select employee_name,employee_no from employee_tbl")
            cmbname.DisplayMember = "employee_name"
            cmbname.ValueMember = "employee_no"
            cmbname.DataSource = listvendorname

        End If
        If rbtnall.Checked Then
            Panelindgroup.Visible = False
        End If
        If rbtngroup.Checked Then
            Panelindgroup.Visible = True
            lblname.Text = "Group Name"
            Dim listvendorname As New DataTable
            cmbname.DataSource = Nothing
            listvendorname = obj.getdatatable("select salarygroup_name,salarygroup_no from salarygroup_tbl")
            cmbname.DisplayMember = "salarygroup_name"
            cmbname.ValueMember = "salarygroup_no"
            cmbname.DataSource = listvendorname
        End If
    End Sub

    Private Sub griddata_MouseLeave(sender As Object, e As System.EventArgs) Handles griddata.MouseLeave
        CalculationArea()
    End Sub
End Class