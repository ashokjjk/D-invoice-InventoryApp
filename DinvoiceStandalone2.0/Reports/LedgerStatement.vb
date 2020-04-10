Public Class LedgerStatement
    Dim obj As New ObjClass
    Private Sub LedgerStatement_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        MaximizeBox = False
        MinimizeBox = False
        lstbxDetails.Visible = False
        txtSearchKeyword.Focus()
    End Sub

    Private Sub txtSearchKeyword_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSearchKeyword.KeyPress
        lstbxDetails.Visible = True
    End Sub

    Private Sub lstbxDetails_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lstbxDetails.MouseClick
        lstbxDetails.Visible = False
    End Sub

    Private Sub lstClientName_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lstbxDetails.MouseClick
        lstbxDetails.Visible = False

        Try
            lstbxDetails.Visible = False
            txtSearchKeyword.Text = lstbxDetails.Text
            lblcuscode.Text = lstbxDetails.SelectedValue
        Catch ex As Exception

        End Try

    End Sub

    Private Sub txtClientName_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSearchKeyword.KeyUp
        lblcuscode.Text = ""
        lstbxDetails.Visible = True
        lstbxDetails.BringToFront()
        Dim listclientname As New DataTable
        lstbxDetails.DataSource = Nothing
        If txtSearchKeyword.Text = "" Then
            lstbxDetails.Visible = False
        Else
            listclientname = obj.getdatatable("select company_name,contact_no from contact_tbl where company_name like '%" + txtSearchKeyword.Text + "%'")
            lstbxDetails.DisplayMember = "company_name"
            lstbxDetails.ValueMember = "contact_no"
            lstbxDetails.DataSource = listclientname
            lstbxDetails.Visible = True
        End If
    End Sub

    Private Sub DateTimePicker4_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpfromdate.ValueChanged
        Me.txtfromdate.Text = Me.dtpfromdate.Value.Date.ToString("dd/MM/yyyy")
    End Sub

    Private Sub dtptodate_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtptodate.ValueChanged
        Me.txttodate.Text = Me.dtptodate.Value.Date.ToString("dd/MM/yyyy")
    End Sub
    Dim s As New SharedData
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim contact_code, from_date, to_date As String
        contact_code = Me.lblcuscode.Text
        from_date = Me.txtfromdate.Text
        to_date = Me.txttodate.Text
        s.SetLedgerData(contact_code, from_date, to_date)
        ReportScreen.Show()
        ReportScreen.BringToFront()
        'ReportScreen.TopMost = True


    End Sub
End Class