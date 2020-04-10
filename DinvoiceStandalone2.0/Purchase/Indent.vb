Public Class Indent
    Dim obj As New ObjClass
    Dim S As New SharedData
    Dim itemdatatable As New DataTable
    Private Sub Indent_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        MaximizeBox = False
        MinimizeBox = False
        Panel2.Visible = False
        lstbxclientname.Visible = False
        txtClientNm.Focus()
        obj.TodayDate(txtIndentdt)
        Try
        itemdatatable.Columns.Add("Name".ToString())
        itemdatatable.Columns.Add("Desc".ToString())
        itemdatatable.Columns.Add("Qty".ToString())
            itemdatatable.Columns.Add("Pattern".ToString())
            itemdatatable.Columns.Add("Notes".ToString())
        Catch ex As Exception

        End Try
        txtItmCode.Text = obj.GetOneValueFromQuery("select indent_frmt&''&indent_no from control_tbl where company_id=" + SharedData.companyid + "")
        BindGridViewIndent("")
    End Sub

    Private Sub rbtDate_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbtDate.CheckedChanged
        Select Case rbtDate.Checked
            Case True
                Panel2.Visible = True
            Case Else
                Panel2.Visible = False
        End Select
    End Sub

    Private Sub rbtName_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbtName.CheckedChanged
        Select Case rbtName.Checked
            Case True
                Panel2.Visible = False
            Case Else
                Panel2.Visible = True
        End Select
    End Sub

    Private Sub txtClientNm_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtClientNm.KeyUp
        lstbxclientname.Visible = True

        Dim listclientname As New DataTable
        lstbxclientname.DataSource = Nothing
        If txtClientNm.Text = "" Then
            lstbxclientname.Visible = False
        Else

            listclientname = obj.getdatatable("select top 1 'Add New' as company_name,'0' as contact_no from contact_tbl union select company_name,contact_no from contact_tbl where company_name like '%" + txtClientNm.Text + "%'")
            lstbxclientname.DisplayMember = "company_name"
            lstbxclientname.ValueMember = "contact_no"
            lstbxclientname.DataSource = listclientname
            lstbxclientname.Visible = True
        End If
    End Sub

   
    

    Private Sub lstbxclientname_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lstbxclientname.MouseClick
        lstbxclientname.Visible = False


        If lstbxclientname.Text = "Add New" Then
            Contacts.Show()
            Contacts.BringToFront()
            Contacts.Focus()
        Else
            Try
                lstbxclientname.Visible = False
                txtClientNm.Text = lstbxclientname.Text
                lblcuscode.Text = lstbxclientname.SelectedValue
            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub dtpIndentDt_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpIndentDt.ValueChanged
        txtIndentdt.Text = Me.dtpIndentDt.Value.Date.ToString("dd/MM/yyyy")
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        gridadditem.ClearSelection()
        Try
            itemdatatable.Rows.Add(Me.txtname.Text, Me.txtdesc.Text, txtqty.Text,
                                   txtpattern.Text, txtnotes.Text)
            gridadditem.DataSource = itemdatatable
            If gridadditem.Columns.Count = 5 Then
                Dim btn As New DataGridViewButtonColumn
                btn.Name = "edit"
                btn.HeaderText = ""
                btn.Text = "EDIT"
                btn.UseColumnTextForButtonValue = True
                gridadditem.Columns.Add(btn)

                Dim btn1 As New DataGridViewButtonColumn
                btn1.Name = "delete"
                btn1.HeaderText = ""
                btn1.Text = "DELETE"
                btn1.UseColumnTextForButtonValue = True
                gridadditem.Columns.Add(btn1)
            Else

            End If
            gridadditem.AutoGenerateColumns = False
            gridadditem.AllowUserToAddRows = False
            txtdesc.Text = ""
            txtqty.Text = ""
            Me.txtname.Text = ""
            txtpattern.Text = ""
            txtnotes.Text = ""
        Catch ex As Exception

        End Try
    End Sub

    Private Sub gridadditem_CellContentClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridadditem.CellContentClick
        If e.ColumnIndex = 5 Then
            Me.txtname.Text = gridadditem.Rows(e.RowIndex).Cells(0).Value.ToString()

            txtdesc.Text = gridadditem.Rows(e.RowIndex).Cells(1).Value.ToString()
            txtqty.Text = gridadditem.Rows(e.RowIndex).Cells(2).Value.ToString()
            txtpattern.Text = gridadditem.Rows(e.RowIndex).Cells(3).Value.ToString()
            txtnotes.Text = gridadditem.Rows(e.RowIndex).Cells(4).Value.ToString()

             Dim index As Integer
            index = e.RowIndex
            gridadditem.Rows.RemoveAt(index)


        End If
        If e.ColumnIndex = 6 Then
            Dim index As Integer
            index = e.RowIndex
            gridadditem.Rows.RemoveAt(index)


        End If
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim indent_no, indent_user_no, contact_no, indent_dt, job_no, bill_flg, bill_no, fully_delivered, company_id, user_name As String

        Dim item_name, desc, qty, pattern, notes, gatepass_flg, gatepass_no As String

        contact_no = lblcuscode.Text
        indent_dt = Format(CDate(Me.txtIndentdt.Text), "dd/MM/yyyy")

        job_no = txtJobNo.Text
        indent_user_no = txtItmCode.Text
        bill_flg = "0"
        bill_no = ""
        fully_delivered = "0"
        company_id = SharedData.companyid
        user_name = SharedData.userid

        Dim txt As New List(Of String)
        txt.Add(contact_no)
        txt.Add(indent_user_no)
        txt.Add(indent_dt)
       
        If obj.TextBoxValidate(txt) = False Then
            MsgBox("All * value  Required", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        If obj.validContact(contact_no) = False Then
            MsgBox("ContactName is not Valid!!", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        If gridadditem.Rows.Count = 0 Then
            MsgBox("Please Add Item!!!", MsgBoxStyle.Exclamation)
            Exit Sub
        End If




        Dim QueryCollection As New List(Of String)

        Select Case btnSave.Text
            Case Is = "Save"
                indent_no = obj.GetOneValueFromQuery("select indent_frmt&''&indent_no from control_tbl where company_id=" + SharedData.companyid + "")

                For i = 0 To gridadditem.Rows.Count - 1
                    item_name = gridadditem.Rows(i).Cells(0).Value.ToString()
                    desc = gridadditem.Rows(i).Cells(1).Value.ToString()
                    qty = gridadditem.Rows(i).Cells(2).Value.ToString()
                    pattern = gridadditem.Rows(i).Cells(3).Value.ToString()
                    notes = gridadditem.Rows(i).Cells(4).Value.ToString()
                    gatepass_flg = "0"
                    gatepass_no = ""
                    QueryCollection.Add("insert into indent_dtl(indent_no,item_name, item_desc, qty, pattern, notes, " & _
                                  "gatepass_flg, gatepass_no, bill_flg, bill_no) values" & _
                                   "('" + indent_no + "','" + item_name + "','" + desc + "'," + qty + "," & _
        "'" + pattern + "','" + obj.inapos(notes) + "'," + gatepass_flg + ",'" + gatepass_no + "'," + bill_flg + ",'" + bill_no + "')")

                Next
                QueryCollection.Add("insert into indent_hdr(indent_no, indent_user_no, contact_no, indent_dt, " & _
                                  "job_no, fully_delivered, company_id, user_name) values" & _
                                  "('" + indent_no + "','" + indent_user_no + "','" + contact_no + "','" + indent_dt + "','" + job_no + "'," & _
        "" + fully_delivered + "," + company_id + ",'" + user_name + "')")

                QueryCollection.Add("update control_tbl set indent_no=indent_no+1 where company_id=" + company_id + "")
            Case Is = "Update"
                indent_no = lblcode.Text
                obj.QueryExecution("delete from indent_dtl where indent_no='" + indent_no + "'")
                For i = 0 To gridadditem.Rows.Count - 1
                    item_name = gridadditem.Rows(i).Cells(0).Value.ToString()
                    desc = gridadditem.Rows(i).Cells(1).Value.ToString()
                    qty = gridadditem.Rows(i).Cells(2).Value.ToString()
                    pattern = gridadditem.Rows(i).Cells(3).Value.ToString()
                    notes = gridadditem.Rows(i).Cells(4).Value.ToString()
                    gatepass_flg = "0"
                    gatepass_no = ""
                    QueryCollection.Add("insert into indent_dtl(indent_no,item_name, item_desc, qty, pattern, notes, " & _
                                  "gatepass_flg, gatepass_no) values" & _
                                   "('" + indent_no + "','" + item_name + "','" + desc + "'," + qty + "," & _
        "'" + pattern + "','" + notes + "'," + gatepass_flg + ",'" + gatepass_no + "')")

                Next
                QueryCollection.Add("update indent_hdr set  contact_no='" + contact_no + "', " & _
                                  "indent_dt='" + indent_dt + "', job_no='" + job_no + "',indent_user_no='" + indent_user_no + "' ," & _
                                  "company_id=" + company_id + ", user_name='" + user_name + "' " & _
                                  "where indent_no='" + indent_no + "'")
                lblcode.Text = ""
                btnSave.Text = "Save"
                lblcuscode.Text = ""
        End Select

        Dim result As Boolean = obj.TransactionInsert(QueryCollection)
        Select Case result
            Case True
                MsgBox("Indent details updated!!", MessageBoxIcon.Information)
                S.SetReportIndentno(indent_no)
                ReportScreen.Show()
                
            Case False
                MsgBox("Something Went Wrong!!", MessageBoxIcon.Exclamation)
        End Select
        Me.Controls.Clear()
        InitializeComponent()
        Indent_Load(e, e)
        gridadditem.DataSource = Nothing
        BindGridViewIndent("")
        ReportScreen.BringToFront()
        ReportScreen.Focus()
       

     


    End Sub

    Private Sub gridItem_CellContentClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridItem.CellContentClick
        Try
            If e.ColumnIndex = 4 Then
                Dim Listdata As New List(Of String)

                Listdata = obj.GetMoreValueFromQuery("Select contact_no, indent_dt, job_no,indent_user_no	from " & _
                        "indent_hdr where indent_no=" & _
                        "'" + gridItem.Rows(e.RowIndex).Cells(2).Value + "'", 4)

                txtClientNm.Text = gridItem.Rows(e.RowIndex).Cells(0).Value
                txtIndentdt.Text = Listdata(1)

                lblcuscode.Text = Listdata(0)
                txtJobNo.Text = Listdata(2)
                txtItmCode.Text = Listdata(3)
                Dim dt As DataTable
                dt = obj.getdatatable("select item_name, item_desc, qty, pattern, notes from indent_dtl where indent_no='" + gridItem.Rows(e.RowIndex).Cells(2).Value + "'")
                itemdatatable.Rows.Clear()
                For i = 0 To dt.Rows.Count - 1
                    itemdatatable.Rows.Add(dt.Rows(i).Item(0).ToString, dt.Rows(i).Item(1).ToString, dt.Rows(i).Item(2).ToString, dt.Rows(i).Item(3).ToString, dt.Rows(i).Item(4).ToString)
                Next
                gridadditem.DataSource = itemdatatable
                If gridadditem.Columns.Count = 5 Then
                    Dim btn As New DataGridViewButtonColumn
                    btn.Name = "edit"
                    btn.HeaderText = ""
                    btn.Text = "EDIT"
                    btn.UseColumnTextForButtonValue = True
                    gridadditem.Columns.Add(btn)

                    Dim btn1 As New DataGridViewButtonColumn
                    btn1.Name = "delete"
                    btn1.HeaderText = ""
                    btn1.Text = "DELETE"
                    btn1.UseColumnTextForButtonValue = True
                    gridadditem.Columns.Add(btn1)
                Else

                End If
                gridadditem.AutoGenerateColumns = False
                gridadditem.AllowUserToAddRows = False
               
                txtdesc.Text = ""
                txtqty.Text = ""
                Me.txtname.Text = ""
                txtpattern.Text = ""
                txtnotes.Text = ""
                btnSave.Text = "Update"
                lblcode.Text = gridItem.Rows(e.RowIndex).Cells(2).Value

            End If
            If e.ColumnIndex = 5 Then
                Dim result As Integer = MessageBox.Show("Are you sure want to Delete??", "Caution !!!", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning)
                If result = DialogResult.Cancel Then

                ElseIf result = DialogResult.No Then

                ElseIf result = DialogResult.Yes Then
                    obj.QueryExecution("delete from indent_hdr where indent_no='" + gridItem.Rows(e.RowIndex).Cells(2).Value + "'")
                    obj.QueryExecution("delete from indent_dtl where indent_no='" + gridItem.Rows(e.RowIndex).Cells(2).Value + "'")
                End If
                Indent_Load(e, e)
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MessageBoxIcon.Exclamation)
        End Try
    End Sub
    Sub BindGridViewIndent(ByVal s As String)
        Try
            gridItem.ColumnCount = 4
            gridItem.Columns(0).Name = "Customer"
            gridItem.Columns(1).Name = "Indent Date"
            gridItem.Columns(2).Name = "Indent No"
            gridItem.Columns(3).Name = "Job No"

            gridItem.Rows.Clear()
            Dim dt1 As New DataTable
            Dim datefrom, dateto As String
            If rbtName.Checked = True Then
                dt1 = obj.getdatatable("select company_name,indent_dt,indent_no,job_no from IndentSelect where  company_name like '%" + s + "%'")

            ElseIf rbtDate.Checked = True Then
                If Me.dtfromdtsearch.Text = "" Or Me.dtfromdtsearch.Text = "" Then
                    Exit Sub
                Else
                    datefrom = Format(CDate(Me.dtfromdtsearch.Text), "MM/dd/yyyy")
                    dateto = Format(CDate(Me.dtfromdtsearch.Text), "MM/dd/yyyy")
                    dt1 = obj.getdatatable("select top 50 b.contact_name,a.indent_dt,a.intend_no,a.job_no from indent_hdr a,contact_tbl b where a.contact_no=b.contact_no and a.gatepass_flg=0 and a.bill_flg=0 and  a.indent_dt between #" + datefrom + "# and #" + dateto + "#")

                End If
            End If

            For i = 0 To dt1.Rows.Count - 1
                gridItem.Rows.Add(dt1.Rows(i).Item(0).ToString, Format(CDate(dt1.Rows(i).Item(1).ToString), "dd/MM/yyyy"), dt1.Rows(i).Item(2).ToString, dt1.Rows(i).Item(3).ToString)
            Next
            'gridAddCmp.DataSource = dt1
            Dim btn As New DataGridViewButtonColumn
            btn.Name = "edit"
            btn.HeaderText = ""
            btn.Text = "EDIT"
            btn.UseColumnTextForButtonValue = True
            gridItem.Columns.Add(btn)

            Dim btn1 As New DataGridViewButtonColumn
            btn1.Name = "delete"
            btn1.HeaderText = ""
            btn1.Text = "DELETE"
            btn1.UseColumnTextForButtonValue = True
            gridItem.Columns.Add(btn1)


            gridItem.Refresh()
            gridItem.ReadOnly = True
            gridItem.AutoGenerateColumns = False
            gridItem.AllowUserToAddRows = False
            gridItem.DefaultCellStyle.Font = New Font("Arial", 8)
            gridItem.ColumnHeadersDefaultCellStyle.Font = New Font("Century Gothic", 9, FontStyle.Bold)
            'gridItem.Columns(2).Visible = False
            gridItem.ClearSelection()
        Catch ex As Exception
            MsgBox(ex.Message, , MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub DateTimePicker3_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DateTimePicker3.ValueChanged
        dtfromdtsearch.Text = Me.DateTimePicker3.Value.Date.ToString("dd/MM/yyyy")
    End Sub

    Private Sub DateTimePicker2_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DateTimePicker2.ValueChanged
        dttodtsearch.Text = Me.DateTimePicker2.Value.Date.ToString("dd/MM/yyyy")
    End Sub

    Private Sub txtSearchKeyword_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSearchKeyword.TextChanged
        If txtSearchKeyword.Text = "" Then
            BindGridViewIndent("")
        Else
            BindGridViewIndent(txtSearchKeyword.Text)
        End If
    End Sub

  
    Private Sub btnClear_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClear.Click
        Me.Controls.Clear()
        InitializeComponent()
        Indent_Load(e, e)
    End Sub

  
End Class