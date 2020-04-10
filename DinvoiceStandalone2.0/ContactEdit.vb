Public Class ContactEdit
    Dim obj As New ObjClass

    Private Sub ContactEdit_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
        Catch ex As Exception
            MsgBox(ex.Message, MessageBoxIcon.Warning)
        End Try
    End Sub

    Private Sub cmbGSTtreat_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbGSTtreat.SelectedIndexChanged
        Select Case cmbGSTtreat.Text
            Case Is = "Registered Business"
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
            Dim company_id As Integer
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
            If gst_treatment = "Registered Business" Then
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
            
                    contact_no = obj.GetOneValueFromQuery("select contact_no from control_tbl where company_id=" & company_id & "")
                    QueryCollection.Add("insert into contact_tbl(contact_no	,company_name,	contact_type	" & _
             ",contact_name,	phone_no,	email_id	,gst_treatment,	gst_no,	place_supply	,billing_address," & _
             "	ship_address,	tds_percent) values ('" + contact_no + "','" + company_name + "'," & _
             "'" + contact_type + "','" + contact_name + "','" + phone_no + "','" + email_id + "'," & _
             "'" + gst_treatment + "','" + gst_no + "','" + place_supply + "','" + billing_address + "'," & _
             "'" + ship_address + "'," & tds_percent & ")")
                    QueryCollection.Add("update control_tbl set contact_no=contact_no+1   where company_id=" & company_id & "")
               

            Dim result As Boolean = obj.TransactionInsert(QueryCollection)
            Select Case result
                Case True
                    MsgBox("Contact details updated!!", MessageBoxIcon.Information)
                Case False
                    MsgBox("Something Went Wrong!!", MessageBoxIcon.Exclamation)
                    Exit Sub
            End Select

            Me.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MessageBoxIcon.Exclamation)
            Exit Sub
        End Try

    End Sub

   

   

  


End Class