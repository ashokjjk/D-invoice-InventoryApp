Public Class SalaryGroup
    Dim obj As New ObjClass
    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim salarygroup_no, salarygroup_name As String

        salarygroup_name = txtsalarygrpname.Text
        Dim QueryCollection As New List(Of String)
        Select Case btnSave.Text
            Case Is = "Save"
                salarygroup_no = obj.GetOneValueFromQuery("select salarygroup_no from control_tbl where company_id=" & SharedData.companyid & "")
                QueryCollection.Add("insert into salarygroup_tbl(salarygroup_no,salarygroup_name) values('" + salarygroup_no + "','" + salarygroup_name + "')")
                QueryCollection.Add("update control_tbl set salarygroup_no=salarygroup_no+1 where company_id=" & SharedData.companyid & "")

            Case Is = "Update"
                salarygroup_no = lblid.text
                QueryCollection.Add("update salarygroup_tbl set salarygroup_name ='" + salarygroup_name + "' where salarygroup_no='" + salarygroup_no + "'")
                lblid.Text = ""
                btnSave.Text = "Save"
        End Select

        Dim result As Boolean = obj.TransactionInsert(QueryCollection)
        Select Case result
            Case True
                MsgBox("Salary Group details updated!!", MessageBoxIcon.Information)
            Case False
                MsgBox("Something Went Wrong!!", MessageBoxIcon.Exclamation)
        End Select
        Me.Controls.Clear()
        InitializeComponent()
        Me.SalaryGroup_Load(e, e)
    End Sub

    Private Sub SalaryGroup_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        bindgridview()
    End Sub
    Sub bindgridview()
        Try
            griddata.ColumnCount = 2
            griddata.Columns(0).Name = "Name"
            griddata.Columns(1).Name = "code"

            griddata.Rows.Clear()
            Dim dt1 = obj.getdatatable("select salarygroup_no,salarygroup_name	from salarygroup_tbl")




            For i = 0 To dt1.Rows.Count - 1
                griddata.Rows.Add(dt1.Rows(i).Item(1).ToString, dt1.Rows(i).Item(0).ToString)
            Next
            'gridAddCmp.DataSource = dt1
            If griddata.RowCount = 4 Then
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
            griddata.Columns(1).Visible = False
            griddata.ClearSelection()
        Catch ex As Exception
            MsgBox(ex.Message, , MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub griddata_CellContentClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles griddata.CellContentClick
        Try
            If e.ColumnIndex = 2 Then
                txtsalarygrpname.Text = griddata.Rows(e.RowIndex).Cells(0).Value
                lblid.Text = griddata.Rows(e.RowIndex).Cells(1).Value
                btnSave.Text = "Update"
            End If
            If e.ColumnIndex = 3 Then
                Dim result As Integer = MessageBox.Show("Are you sure want to Delete??", "Caution !!!", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning)
                If result = DialogResult.Cancel Then

                ElseIf result = DialogResult.No Then

                ElseIf result = DialogResult.Yes Then
                    obj.QueryExecution("delete from salarygroup_tbl where salarygroup_no='" + griddata.Rows(e.RowIndex).Cells(1).Value + "'")
                End If
                SalaryGroup_Load(e, e)
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MessageBoxIcon.Exclamation)
        End Try
    End Sub

    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        Me.Controls.Clear()
        InitializeComponent()
        SalaryGroup_Load(e, e)
    End Sub
End Class