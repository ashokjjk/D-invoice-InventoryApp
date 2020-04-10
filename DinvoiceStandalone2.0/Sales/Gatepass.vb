Public Class Gatepass
    Dim obj As New ObjClass
    Private Sub Gatepass_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        MaximizeBox = False
        MinimizeBox = False
        lstbxNo.Visible = False
        lstbxInvNo.Visible = False
        rbtIndentNo.Checked = True
        txtSearch.Focus()
        lblinvoiceno.Text = ""
        gridgatepass.DataSource = Nothing
        gridgatepass.Rows.Clear()
        txtGatepassNo.Text = obj.GetOneValueFromQuery("select gatepass_frmt&''&gatepass_no from control_tbl where company_id=" + SharedData.companyid + "")

    End Sub

    Private Sub lstbxNo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles lstbxNo.KeyPress, lstbxInvNo.KeyPress
        lstbxNo.Visible = True
    End Sub

    Private Sub txtInvoiceNo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtInvoiceNo.KeyPress
        lstbxInvNo.Visible = True
    End Sub

    Private Sub txtInvoiceNo_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtInvoiceNo.KeyUp
        Dim listinvno As New DataTable
        lstbxNo.DataSource = Nothing
        If txtInvoiceNo.Text = "" Then
            lstbxInvNo.Visible = False
        Else

            listinvno = obj.getdatatable("select user_invoice_no,invoice_no from invoice_hdr where user_invoice_no like '%" + txtInvoiceNo.Text + "%'")
            lstbxInvNo.DisplayMember = "user_invoice_no"
            lstbxInvNo.ValueMember = "invoice_no"
            lstbxInvNo.DataSource = listinvno
            lstbxInvNo.Visible = True
        End If
    End Sub
    Private Sub lstbxInvNo_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lstbxInvNo.MouseClick
          Try
                lstbxInvNo.Visible = False
                txtInvoiceNo.Text = lstbxInvNo.Text
            lblinvoiceno.Text = lstbxInvNo.SelectedValue
            Select Case obj.FindDuplicate("select count(*) from indent_dtl where bill_no='" + txtInvoiceNo.Text + "'")
                Case Is = 0
                    txtGatepassNo.Text = obj.GetOneValueFromQuery("select gatepass_frmt&''&gatepass_no from control_tbl where company_id=" + SharedData.companyid + "")

                Case Else
                    txtGatepassNo.Text = obj.GetOneValueFromQuery("select gatepass_no from indent_dtl where bill_no='" + txtInvoiceNo.Text + "'")

            End Select
            Catch ex As Exception

            End Try
    End Sub
    Private Sub txtSearch_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtSearch.MouseClick, txtGatepassNo.MouseClick, txtInvoiceNo.MouseClick
        lstbxNo.Visible = False
    End Sub

    
    Private Sub btnMkGatepass_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMkGatepass.Click
     
        Dim invoice_no As String
        Dim tempindentlist, indentlist, QueryCollection As New List(Of String)
        invoice_no = lblinvoiceno.Text
        For i = 0 To gridgatepass.Rows.Count - 1
            If CBool(gridgatepass.Rows(i).Cells(0).Value) = True Then
                tempindentlist.Add(gridgatepass.Rows(i).Cells(3).Value)
            End If
        Next

        If tempindentlist.Count <= 0 Then
            MsgBox("No Indent is selected!!!!", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        If invoice_no <> "" Then
            indentlist = tempindentlist.Distinct.ToList
            Select Case obj.GetOneValueFromQuery("select distinct bill_no from indent_dtl where indent_no='" + indentlist(0) + "' and bill_flg=1") = txtInvoiceNo.Text
                Case Is = True

                Case Else
                    MsgBox("It Should be linked only to Invoice No " + obj.GetOneValueFromQuery("select distinct bill_no from indent_dtl where indent_no='" + indentlist(0) + "' and bill_flg=1") + "", MsgBoxStyle.Exclamation)
                    Exit Sub
            End Select
            If indentlist.Count = 1 Then
                For i = 0 To gridgatepass.Rows.Count - 1
                    If CBool(gridgatepass.Rows(i).Cells(0).Value) = True Then
                        QueryCollection.Add("update indent_dtl set	gatepass_flg=1,	gatepass_no='" + txtGatepassNo.Text + "',	bill_flg=1,	bill_no='" + invoice_no + "' where ID=" + gridgatepass.Rows(i).Cells(5).Value + "")
                    End If
                Next
            Else
                MsgBox("Only One Indent should be selected for invoice!!!", MsgBoxStyle.Exclamation)
                Exit Sub
            End If

        Else
            For i = 0 To gridgatepass.Rows.Count - 1
                If CBool(gridgatepass.Rows(i).Cells(0).Value) = True Then
                    QueryCollection.Add("update indent_dtl set	gatepass_flg=1,	gatepass_no='" + txtGatepassNo.Text + "',	bill_flg=0,	bill_no='' where ID=" + gridgatepass.Rows(i).Cells(5).Value + "")
                End If
            Next

            QueryCollection.Add("update control_tbl set gatepass_no=gatepass_no+1 where company_id=" + SharedData.companyid + "")

        End If


        Dim result As Boolean = obj.TransactionInsert(QueryCollection)
        Select Case result
            Case True
                MsgBox("GatePass details updated!!", MessageBoxIcon.Information)
            Case False
                MsgBox("Something Went Wrong!!", MessageBoxIcon.Exclamation)
                Exit Sub
        End Select
        Me.Controls.Clear()
        InitializeComponent()
        Me.Gatepass_Load(e, e)
        lblinvoiceno.Text = ""

        'ReportScreen.Show()
        'ReportScreen.BringToFront()
        'ReportScreen.TopMost = True
    End Sub

   
    Private Sub txtClientName_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSearch.KeyUp
        Dim listvendorname As New DataTable
        lstbxNo.DataSource = Nothing
        If txtSearch.Text = "" Then
            lstbxNo.Visible = False
        Else

            If rbtcustomer.Checked = True Then
                listvendorname = obj.getdatatable("select  distinct b.company_name as srch" & _
                                       " from indent_dtl a,contact_tbl b,indent_hdr c where c.contact_no=b.contact_no" & _
                                       " and a.indent_no=c.indent_no  and  b.company_name like '%" + txtSearch.Text + "%' and a.gatepass_flg=0")

            ElseIf rbtIndentNo.Checked = True Then
                listvendorname = obj.getdatatable("select distinct a.indent_no as srch" & _
                                       " from indent_dtl a,contact_tbl b,indent_hdr c where c.contact_no=b.contact_no" & _
                                       " and a.indent_no=c.indent_no  and  a.indent_no like '%" + txtSearch.Text + "%' and a.gatepass_flg=0")

            ElseIf rbtInvNo.Checked = True Then
                listvendorname = obj.getdatatable("select distinct a.bill_no as srch" & _
                                       " from indent_dtl a,contact_tbl b,indent_hdr c where c.contact_no=b.contact_no" & _
                                       " and a.indent_no=c.indent_no  and  a.bill_no like '%" + txtSearch.Text + "%' and a.gatepass_flg=0")

            End If
            lstbxNo.DisplayMember = "srch"
            lstbxNo.ValueMember = "srch"
            lstbxNo.DataSource = listvendorname
            lstbxNo.Visible = True
        End If
    End Sub
    Private Sub lstClientName_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lstbxNo.MouseClick
        lstbxNo.Visible = False
        If lstbxNo.Text = "Add New" Then
            Contacts.Show()
            Contacts.BringToFront()
            Contacts.Focus()
        Else
            Try
                lstbxNo.Visible = False
                txtSearch.Text = lstbxNo.Text
            Catch ex As Exception

            End Try
        End If
    End Sub
    Sub BindGridViewIndent(ByVal s As String)
        Try
            Dim dtnew As New DataTable
            dtnew.Columns.Add("check", GetType(Boolean))
            dtnew.Columns.Add("Customer", GetType(String))
            dtnew.Columns.Add("Indent Date", GetType(String))
            dtnew.Columns.Add("Indent No", GetType(String))
            dtnew.Columns.Add("Item", GetType(String))
            dtnew.Columns.Add("ID", GetType(String))
            gridgatepass.DataSource = Nothing
            gridgatepass.Rows.Clear()
            Dim dt1 As New DataTable
            If rbtcustomer.Checked = True Then
                dt1 = obj.getdatatable("select b.company_name as Client,c.indent_dt as IndentDt,a.indent_no As IndentNo,a.item_name As Item,a.ID" & _
                                       " from indent_dtl a,contact_tbl b,indent_hdr c where c.contact_no=b.contact_no" & _
                                       " and a.indent_no=c.indent_no  and  b.company_name like '%" + s + "%' and a.gatepass_flg=0")

            ElseIf rbtIndentNo.Checked = True Then
                dt1 = obj.getdatatable("select b.company_name as Client,c.indent_dt as IndentDt,a.indent_no As IndentNo,a.item_name As Item,a.ID" & _
                                       " from indent_dtl a,contact_tbl b,indent_hdr c where c.contact_no=b.contact_no" & _
                                       " and a.indent_no=c.indent_no  and  a.indent_no like '%" + s + "%' and a.gatepass_flg=0")

            ElseIf rbtInvNo.Checked = True Then
                dt1 = obj.getdatatable("select  b.company_name as Client,c.indent_dt as IndentDt,a.indent_no As IndentNo,a.item_name As Item,a.ID" & _
                                       " from indent_dtl a,contact_tbl b,indent_hdr c where c.contact_no=b.contact_no" & _
                                       " and a.indent_no=c.indent_no  and  a.bill_no like '%" + s + "%' and a.gatepass_flg=0")

            End If

            For i = 0 To dt1.Rows.Count - 1
                dtnew.Rows.Add(False, dt1.Rows(i).Item(0).ToString, Format(CDate(dt1.Rows(i).Item(1).ToString), "dd/MM/yyyy"), dt1.Rows(i).Item(2).ToString, dt1.Rows(i).Item(3).ToString, dt1.Rows(i).Item(4).ToString)
            Next
            gridgatepass.DataSource = dtnew
          


            gridgatepass.Refresh()

            gridgatepass.AutoGenerateColumns = False
            gridgatepass.AllowUserToAddRows = False
            gridgatepass.Columns(5).Visible = False

            gridgatepass.Columns(1).ReadOnly = True
            gridgatepass.Columns(2).ReadOnly = True
            gridgatepass.Columns(3).ReadOnly = True
            gridgatepass.Columns(4).ReadOnly = True

            gridgatepass.ClearSelection()
        Catch ex As Exception
            MsgBox(ex.Message, , MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        BindGridViewIndent(txtSearch.Text)
    End Sub
End Class