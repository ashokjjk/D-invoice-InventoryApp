Public Class Payslipprint
    Dim obj As New ObjClass
    Private Sub RadioButton1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtnmonyr.CheckedChanged
        If rbtnmonyr.Checked = True Then
            pnlmonyr.Visible = True
            pnlemployee.Visible = False
        End If

        If rbtnname.Checked = True Then
            pnlmonyr.Visible = False
            pnlemployee.Visible = True
            Dim listvendorname As New DataTable
            cmbname.DataSource = Nothing
            listvendorname = obj.getdatatable("select employee_name,employee_no from employee_tbl")
            cmbname.DisplayMember = "employee_name"
            cmbname.ValueMember = "employee_no"
            cmbname.DataSource = listvendorname
        End If

        
    End Sub

    Private Sub Payslipprint_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        pnlmonyr.Visible = True
        Dim year As Integer = Format(Now, "yyyy")
        cmbyear.Items.Add(year)
        cmbyear.Items.Add(year + 1)
        cmbyear.Items.Add(year + 2)
        bindgridview()
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        bindgridview()
    End Sub
    Sub bindgridview()
        Try
            griddata.ColumnCount = 13
            griddata.Columns(0).Name = "Employee"
            griddata.Columns(1).Name = "Basic"
            griddata.Columns(2).Name = "DA"
            griddata.Columns(3).Name = "HRA"
            griddata.Columns(4).Name = "Others"
            griddata.Columns(5).Name = "Bonus"
            griddata.Columns(6).Name = "ESI"
            griddata.Columns(7).Name = "PF"
            griddata.Columns(8).Name = "TRS"
            griddata.Columns(9).Name = "Others Deduction"
            griddata.Columns(10).Name = "Advance"
            griddata.Columns(11).Name = "Net Salary"
            griddata.Columns(12).Name = "no"
            griddata.Rows.Clear()
            Dim dt1 As New DataTable

            	
            If rbtnmonyr.Checked Then
                dt1 = obj.getdatatable("select employee_no,	basic,	da,	hra,	others,	bonus,	esi	,pf,	trs," & _
"	otherdeduction,	advance,	netsalary,payslip_no	 from payslip_tbl where pMonth='" + cmbmonth.Text + "' and pyear='" + cmbyear.Text + "'")

            End If

            If rbtnname.Checked Then
                dt1 = obj.getdatatable("select employee_no,	basic,	da,	hra,	others,	bonus,	esi	,pf,	trs," & _
"	otherdeduction,	advance,	netsalary,payslip_no	 from payslip_tbl where employee_no='" + cmbname.SelectedValue + "'")
            End If
           
            For i = 0 To dt1.Rows.Count - 1
                griddata.Rows.Add(obj.GetOneValueFromQuery("select employee_name from employee_tbl where employee_no='" + dt1.Rows(i).Item(0).ToString + "'"),
                                  dt1.Rows(i).Item(1).ToString,
                                  dt1.Rows(i).Item(2).ToString,
                                  dt1.Rows(i).Item(3).ToString,
                                  dt1.Rows(i).Item(4).ToString,
                                  dt1.Rows(i).Item(5).ToString,
                                  dt1.Rows(i).Item(6).ToString,
                                  dt1.Rows(i).Item(7).ToString,
                                  dt1.Rows(i).Item(8).ToString,
                                  dt1.Rows(i).Item(9).ToString,
                                  dt1.Rows(i).Item(10).ToString,
                                  dt1.Rows(i).Item(11).ToString,
                                  dt1.Rows(i).Item(12).ToString)
            Next

            If griddata.Rows.Count = 15 Then
            Else
                Dim btn As New DataGridViewButtonColumn
                btn.Name = "view"
                btn.HeaderText = ""
                btn.Text = "View"
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
            griddata.Columns(12).Visible = False
            griddata.ClearSelection()
        Catch ex As Exception
            MsgBox(ex.Message, , MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        bindgridview()
    End Sub
    Dim s As New SharedData
    Private Sub griddata_CellContentClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles griddata.CellContentClick
        Try
            If e.ColumnIndex = 13 Then
                s.SetPayslipNo(griddata.Rows(e.RowIndex).Cells(12).Value)
                ReportScreen.Show()
                ReportScreen.BringToFront()

            End If
            If e.ColumnIndex = 14 Then
                Dim result As Integer = MessageBox.Show("Are you sure want to Delete??", "Caution !!!", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning)
                If result = DialogResult.Cancel Then

                ElseIf result = DialogResult.No Then

                ElseIf result = DialogResult.Yes Then
                    Dim QueryList As New List(Of String)
                    Dim dt = obj.GetMoreValueFromQuery("select payment_method,netsalary,voucher_no,bank_id from payslip_tbl where payslip_no='" + griddata.Rows(e.RowIndex).Cells(12).Value + "'", 4)
                    If dt(0) = "Cash" Then
                        QueryList.Add("update bank_tbl set  pettycash_closingBalance=pettycash_closingBalance+" & dt(1) & "	where  company_id=" + SharedData.companyid + "")
                        QueryList.Add("update voucher_tbl set  voucher_amt=voucher_amt-" & dt(1) & ",total_amt=total_amt-" & dt(1) & "	where  voucher_no='" + dt(2) + "'")
                    Else
                        QueryList.Add("update bank_tbl set  bank_closeBalance=bank_closeBalance+" & dt(1) & "	where  ID=" + dt(3) + "")
                        QueryList.Add("update voucher_tbl set  voucher_amt=voucher_amt-" & dt(1) & ",total_amt=total_amt-" & dt(1) & "	where  voucher_no='" + dt(2) + "'")
                    End If

                    Select Case obj.TransactionInsert(QueryList)
                        Case True
                        Case Else
                            MsgBox("Something went Wrong!!!")
                            Exit Sub
                    End Select

                    obj.QueryExecution("delete from payslip_tbl where payslip_no='" + griddata.Rows(e.RowIndex).Cells(12).Value + "'")
                End If
                Payslipprint_Load(e, e)
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MessageBoxIcon.Exclamation)
        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim dt1 As New DataTable
        If rbtnmonyr.Checked Then
            dt1 = obj.getdatatable("select employee_no,	basic,	da,	hra,	others,	bonus,	esi	,pf,	trs," & _
"	otherdeduction,	advance,	netsalary,payslip_no	 from payslip_tbl where pMonth='" + cmbmonth.Text + "' and pyear='" + cmbyear.Text + "'")

        End If

        If rbtnname.Checked Then
            dt1 = obj.getdatatable("select employee_no,	basic,	da,	hra,	others,	bonus,	esi	,pf,	trs," & _
"	otherdeduction,	advance,	netsalary,payslip_no	 from payslip_tbl where employee_no='" + cmbname.SelectedValue + "'")
        End If
        Dim folder As New FolderBrowserDialog
        Dim pathtostore
        If folder.ShowDialog() = Windows.Forms.DialogResult.OK Then
            pathtostore = folder.SelectedPath & "PaySlipGenerateOn" & Format(Today, "dd-MM-yyyy") & ".csv"
        End If
        obj.ExportToExcel(dt1, pathtostore)
    End Sub
End Class