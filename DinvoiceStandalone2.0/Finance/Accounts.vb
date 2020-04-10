Public Class Accounts
    Dim obj As New ObjClass
    Private Sub Accounts_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        MaximizeBox = False
        MinimizeBox = False
        txtAccName.Focus()
        cmbacctype.Items.Clear()
        Dim acclist As New List(Of String)
        acclist = obj.getcolumndatafromquery("select distinct account_type from account_tbl")
        For i = 0 To acclist.Count - 1
            cmbacctype.Items.Add(acclist(i))
        Next
        BindGridViewAccount("")
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim account_head, account_type, account_desc, BS_Type As String
        account_head = txtAccName.Text
        account_type = cmbacctype.Text
        account_desc = txtDesc.Text
        BS_Type = obj.GetOneValueFromQuery("select BS_Type from account_tbl where account_type='" + account_type + "'")
        Dim txt As New List(Of String)
        txt.Add(account_head)
        txt.Add(account_type)
        If obj.TextBoxValidate(txt) = False Then
            MsgBox("All * value  Required")
            Exit Sub
        End If

        Dim QueryCollection As New List(Of String)
        Select Case btnSave.Text
            Case Is = "Save"
                QueryCollection.Add("insert into account_tbl (account_head, account_type, account_desc,BS_Type)" & _
                          " values('" + account_head + "','" + account_type + "','" + account_desc + "','" + BS_Type + "')")
            Case Is = "Update"
                QueryCollection.Add("update account_tbl set account_head='" + account_head + "'," & _
                          "  account_type='" + account_type + "', account_desc='" + account_desc + "',bs_type='" + BS_Type + "'" & _
                          "  where ID=" + lblcode.Text + "")
                lblcode.Text = ""
                btnSave.Text = "Save"
        End Select

        Dim result As Boolean = obj.TransactionInsert(QueryCollection)
        Select Case result
            Case True
                MsgBox("Account details updated!!", MessageBoxIcon.Information)
            Case False
                MsgBox("Something Went Wrong!!", MessageBoxIcon.Exclamation)
        End Select
        Me.Controls.Clear()
        InitializeComponent()
        Me.Accounts_Load(e, e)

    End Sub

    

    Private Sub BindGridViewAccount(ByVal p1 As String)
        Try
            gridAccounts.ColumnCount = 4
            gridAccounts.Columns(0).Name = "Account Head"
            gridAccounts.Columns(1).Name = "Type"
            gridAccounts.Columns(2).Name = "Description"
            gridAccounts.Columns(3).Name = ""


            gridAccounts.Rows.Clear()
            Dim dt1 As New DataTable

            If rbtAccName.Checked = True Then
                dt1 = obj.getdatatable("select top 50 account_head, account_type, account_desc,ID from account_tbl where account_head like '%" + p1 + "%'")
            ElseIf rbtAccType.Checked = True Then
                dt1 = obj.getdatatable("select top 50 account_head, account_type, account_desc,ID from account_tbl where account_type like '%" + p1 + "%'")
            End If

            For i = 0 To dt1.Rows.Count - 1
                gridAccounts.Rows.Add(dt1.Rows(i).Item(0).ToString, dt1.Rows(i).Item(1).ToString, dt1.Rows(i).Item(2).ToString, dt1.Rows(i).Item(3).ToString)
            Next
            ' gridAccounts.DataSource = dt1
            Dim btn As New DataGridViewButtonColumn
            btn.Name = "edit"
            btn.HeaderText = ""
            btn.Text = "EDIT"
            btn.UseColumnTextForButtonValue = True
            gridAccounts.Columns.Add(btn)

            Dim btn1 As New DataGridViewButtonColumn
            btn1.Name = "delete"
            btn1.HeaderText = ""
            btn1.Text = "DELETE"
            btn1.UseColumnTextForButtonValue = True
            gridAccounts.Columns.Add(btn1)


            gridAccounts.Refresh()
            gridAccounts.ReadOnly = True
            gridAccounts.AutoGenerateColumns = False
            gridAccounts.AllowUserToAddRows = False
            gridAccounts.Columns(3).Visible = False
            gridAccounts.ClearSelection()
        Catch ex As Exception
            MsgBox(ex.Message, , MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub gridAccounts_CellContentClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridAccounts.CellContentClick
        Try
            If e.ColumnIndex = 4 Then
                Dim Listdata As New List(Of String)

              
                txtAccName.Text = gridAccounts.Rows(e.RowIndex).Cells(0).Value
                cmbacctype.Text = gridAccounts.Rows(e.RowIndex).Cells(1).Value
                txtDesc.Text = gridAccounts.Rows(e.RowIndex).Cells(2).Value
                btnSave.Text = "Update"
                lblcode.Text = gridAccounts.Rows(e.RowIndex).Cells(3).Value

            End If
            If e.ColumnIndex = 5 Then
                Dim result As Integer = MessageBox.Show("Are you sure want to Delete??", "Caution !!!", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning)
                If result = DialogResult.Cancel Then

                ElseIf result = DialogResult.No Then

                ElseIf result = DialogResult.Yes Then
                    obj.QueryExecution("delete from account_tbl where ID=" + gridAccounts.Rows(e.RowIndex).Cells(3).Value + "")
                              End If
                Accounts_Load(e, e)
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MessageBoxIcon.Exclamation)
        End Try
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        BindGridViewAccount(txtSearchKeyword.Text)
    End Sub

    Private Sub txtSearchKeyword_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSearchKeyword.TextChanged
        BindGridViewAccount(txtSearchKeyword.Text)
    End Sub

    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        Me.Controls.Clear()
        InitializeComponent()
        Me.Accounts_Load(e, e)
    End Sub
End Class