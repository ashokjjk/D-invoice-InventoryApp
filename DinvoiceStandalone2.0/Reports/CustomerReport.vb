Public Class CustomerReport

    Private Sub CustomerReport_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        MaximizeBox = False
        MinimizeBox = False
        Panel2.Visible = False
        txtSearchKeyword.Focus()
        lstbxDetails.Visible = False
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        Panel2.Visible = True
        Dim getdata = obj.GetMoreValueFromQuery("SELECT contact_type, company_name, contact_name,phone_no," & _
                                                " email_id, gst_treatment, place_supply, billing_address, ship_address," & _
                                                " gst_no FROM contact_tbl where contact_no='" + lblcuscode.Text + "'", 10)

        lblType.Text = getdata(0)
        lblCmpNm.Text = getdata(1)
        lblName.Text = getdata(2)
        lblPhno.Text = getdata(3)
        lblEmailid.Text = getdata(4)
        lblgsttreat.Text = getdata(5)
        lblPlaceofSupply.Text = getdata(6)
        lblbillingadr.Text = getdata(7)
        lblshippingadr.Text = getdata(8)
        lblgstno.Text = getdata(9)

    End Sub
    Private Sub lstClientName_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lstbxDetails.MouseClick
        lstbxDetails.Visible = False
        If lstbxDetails.Text = "Add New" Then
            Contacts.Show()
            Contacts.BringToFront()
            Contacts.Focus()
        Else
            Try
                lstbxDetails.Visible = False
                txtSearchKeyword.Text = lstbxDetails.Text
                lblcuscode.Text = lstbxDetails.SelectedValue
            Catch ex As Exception

            End Try
        End If
    End Sub
    Dim obj As New ObjClass
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
End Class