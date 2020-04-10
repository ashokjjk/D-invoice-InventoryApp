Public Class ItemsReport

   

    Private Sub ItemsReport_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        MaximizeBox = False
        MinimizeBox = False
        lstbxDetails.Visible = False
        Panel2.Visible = False
        txtSearchKeyword.Focus()
    End Sub
    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        Panel2.Visible = True
        Try

       
        Dim getdata = obj.GetMoreValueFromQuery("SELECT  item_name, item_code, uom, item_type, gst_id, sale_rate, mrp, purchase_rate, tax_desc_gst, cess,exempt_flg, nilrate_flg" & _
                                                " FROM item_tbl where item_no='" + lblcuscode.Text + "'", 12)

        lblType.Text = getdata(3)
        lblcode.Text = getdata(1)
        lblName.Text = getdata(0)
        lbuom.Text = getdata(2)
        lblhsnsac.Text = getdata(4)
        lblsalerate.Text = getdata(5)
        lblmrp.Text = getdata(6)
        lblpurchaserate.Text = getdata(7)
        lblgstpercent.Text = getdata(8)
        lblcesspercent.Text = getdata(9)
        lblexempt.Text = If(getdata(10) = "0", "No", "Yes")
        lblnilrated.Text = If(getdata(11) = "0", "No", "Yes")
            Me.PictureBox1.Image = Image.FromStream(New System.IO.MemoryStream(obj.retrievephotofromDB("select item_picture from item_tbl where  item_no=" & _
                   "'" + lblcuscode.Text + "' and company_id=" + SharedData.companyid + "")))
        Catch ex As Exception

        End Try
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
            listclientname = obj.getdatatable("select item_name,item_no from item_tbl where item_name like '%" + txtSearchKeyword.Text + "%'")
            lstbxDetails.DisplayMember = "item_name"
            lstbxDetails.ValueMember = "item_no"
            lstbxDetails.DataSource = listclientname
            lstbxDetails.Visible = True
        End If
    End Sub
End Class