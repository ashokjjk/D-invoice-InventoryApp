Public Class CmpyProfile
    Dim obj As New ObjClass
    Private Sub CmpyProfile_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        MaximizeBox = False
        MinimizeBox = False
        Dim getdata = obj.GetMoreValueFromQuery("select company_name, gst_no, pan_no, billing_address," & _
                                                " billing_state, billing_city, billing_pincode,phone_no, company_yr" & _
                                                " from company_tbl where company_id=" + SharedData.companyid + "", 9)

        lblcompanyname.Text = getdata(0)
        lblgstno.Text = getdata(1)
        lblpanno.Text = getdata(2)
        lblbilladdress.Text = getdata(3)

        lblstate.Text = getdata(4)
        lblcity.Text = getdata(5)
        lblpincode.Text = getdata(6)
        lblphoneno.Text = getdata(7)
        lblcompyr.Text = getdata(8)

        Me.PictureBox1.Image = Image.FromStream(New System.IO.MemoryStream(obj.retrievephotofromDB("Select company_logo from company_tbl where company_id=" + SharedData.companyid + "")))


    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Settings.Show()
        Settings.TopMost = True
        Settings.BringToFront()
        Me.Close()
    End Sub
End Class