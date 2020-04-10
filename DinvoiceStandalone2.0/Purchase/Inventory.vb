Public Class Inventory
    Dim obj As New ObjClass
    Private Sub Inventory_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        MaximizeBox = False
        MinimizeBox = False
        lstbxItmNm.Visible = False
        lstbxManItemNm.Visible = False
        txtSearchKeyword.Focus()
        cmbUom.Items.Clear()
        Dim uomlist As New List(Of String)
       uomlist = obj.getcolumndatafromquery("select unit_desc from uom_tbl")
        For i = 0 To uomlist.Count - 1
            cmbUom.Items.Add(uomlist(i))
        Next

        Try
            txtSearchKeyword.Text = lstbxItmNm.Text
            Dim itemdata As New DataTable
            itemdata = obj.getdatatable("select item_name as ItemName,qty as Quantity from InventoryTbl where company_id=" + SharedData.companyid + " and item_type='Goods'")
            gridItem.DataSource = itemdata
            gridItem.ReadOnly = True
            gridItem.AutoGenerateColumns = False
            gridItem.AllowUserToAddRows = False
        Catch ex As Exception

        End Try
        GridViewColor()
        gridItem.ClearSelection()
    End Sub
    Sub GridViewColor()
        Dim qty As Double
        For i = 0 To gridItem.Rows.Count - 1
            qty = gridItem.Rows(i).Cells(1).Value
            If qty > 200 Then
            ElseIf (qty <= 200) And (qty > 100) Then
                gridItem.Rows(i).Cells(1).Style.BackColor = Color.LawnGreen
            ElseIf (qty <= 100) And (qty > 50) Then
                gridItem.Rows(i).Cells(1).Style.BackColor = Color.Yellow
            ElseIf qty <= 50 Then
                gridItem.Rows(i).Cells(1).Style.BackColor = Color.Red
            End If

        Next
    End Sub
    Private Sub txtManItemNm_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtManItemNm.KeyUp
        Dim listitemname As New DataTable
        lstbxManItemNm.DataSource = Nothing
        If txtManItemNm.Text = "" Then
            lstbxManItemNm.Visible = False
        Else
            listitemname = obj.getdatatable("select item_name,item_no from item_tbl where item_name like '%" + txtManItemNm.Text + "%'  and item_type='Goods'")
            ' listitemname = obj.getdatatable("select top 1 'Add New' as item_name,'0' as item_no from item_tbl union select a.item_name& '|' & b.qty,a.item_no from item_tbl a,stock_tbl b where a.item_no=b.item_no and  a.item_name like '%" + txtItemNm.Text + "%'")

            lstbxManItemNm.DisplayMember = "item_name"
            lstbxManItemNm.ValueMember = "item_no"
            lstbxManItemNm.DataSource = listitemname
            lstbxManItemNm.Visible = True

        End If
    End Sub

  
    Private Sub lstbxManItemNm_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lstbxManItemNm.MouseClick

        lstbxManItemNm.Visible = False
        If lstbxManItemNm.Text = "Add New" Then
            Items.Show()
            Items.BringToFront()
            Items.Focus()
        Else
            Try
                txtManItemNm.Text = lstbxManItemNm.Text
                txtCurrentStk.Text = obj.GetOneValueFromQuery("select qty from stock_tbl where company_id=" + SharedData.companyid + "  and item_no='" + lstbxManItemNm.SelectedValue + "'")
                cmbUom.Text = obj.GetOneValueFromQuery("select uom from item_tbl where item_no='" + lstbxManItemNm.SelectedValue + "'")
                txtCurrentStk.ReadOnly = True
            Catch ex As Exception

            End Try
        End If

    End Sub

    Private Sub txtSearchKeyword_Keyup(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSearchKeyword.KeyUp


        Dim listitemname As New DataTable
        lstbxItmNm.DataSource = Nothing
        If txtSearchKeyword.Text = "" Then
            lstbxItmNm.Visible = False
        Else
            listitemname = obj.getdatatable("select item_name,item_no from item_tbl where item_name like '%" + txtSearchKeyword.Text + "%' and item_type='Goods'")
            ' listitemname = obj.getdatatable("select top 1 'Add New' as item_name,'0' as item_no from item_tbl union select a.item_name& '|' & b.qty,a.item_no from item_tbl a,stock_tbl b where a.item_no=b.item_no and  a.item_name like '%" + txtItemNm.Text + "%'")

            lstbxItmNm.DisplayMember = "item_name"
            lstbxItmNm.ValueMember = "item_no"
            lstbxItmNm.DataSource = listitemname
            lstbxItmNm.Visible = True

        End If
        BindGridViewinven1(txtSearchKeyword.Text)
        GridViewColor()
    End Sub

    Private Sub lstbxItmNm_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lstbxItmNm.MouseClick
        lstbxItmNm.Visible = False
            Try
            txtSearchKeyword.Text = lstbxItmNm.Text
            Dim itemdata As New DataTable
            itemdata = obj.getdatatable("select item_name as ItemName,qty as Quantity from InventoryTbl where company_id=" + SharedData.companyid + " and item_type='Goods' and item_no='" + lstbxItmNm.SelectedValue + "'")
            gridItem.DataSource = itemdata
            gridItem.ReadOnly = True
            gridItem.AutoGenerateColumns = False
            gridItem.AllowUserToAddRows = False

            GridViewColor()
            Catch ex As Exception

            End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim item_no, current_stock, UOM, Type, qty, reason, company_id, user_name As String
        item_no = lstbxManItemNm.SelectedValue
        current_stock = txtCurrentStk.Text
        UOM = cmbUom.Text
        If rbtIncrease.Checked = True Then
            Type = "+"
        ElseIf rbtDecrease.Checked = True Then
            Type = "-"
        End If
        qty = txtQty.Text
        reason = txtReason.Text
        company_id = SharedData.companyid
        user_name = SharedData.userid
        Dim txt As New List(Of String)
        txt.Add(item_no)
        txt.Add(qty)
        If obj.TextBoxValidate(txt) = False Then
            MsgBox("All * value  Required", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        If obj.validItem(item_no) = False Then
            MsgBox("Item is not Valid!!", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
      
        Dim queryCollection As New List(Of String)
        queryCollection.Add("insert into manage_inventory(item_no, current_stock, UOM, Type, qty, reason, company_id, user_name)" & _
                            " values('" + item_no + "'," + current_stock + ",'" + UOM + "','" + Type + "'," + qty + ",'" + obj.inapos(reason) + "'," + company_id + ",'" + user_name + "')")
        queryCollection.Add("update stock_tbl set qty=qty" + Type + "" + qty + " where item_no='" + item_no + "' and company_id=" + company_id + "")
        Dim result As Boolean = obj.TransactionInsert(queryCollection)
        Select Case result
            Case True
                MsgBox("Inventory details updated!!", MessageBoxIcon.Information)

            Case False
                MsgBox("Something Went Wrong!!", MessageBoxIcon.Exclamation)
        End Select
        Me.Inventory_Load(e, e)
        lstbxManItemNm.DataSource = Nothing
        obj.ClearTextBox(Me)

    End Sub



    Private Sub txtQty_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtQty.KeyPress
        obj.OnlyNoS(e)
    End Sub

    Private Sub BindGridViewinven1(ByVal p1 As String)
        Try
            'txtSearchKeyword.Text = lstbxItmNm.Text
            Dim itemdata As New DataTable
            itemdata = obj.getdatatable("select b.item_name as ItemName,a.qty as Quantity from stock_tbl a,item_tbl b where a.item_no=b.item_no " & _
                                        " and a.company_id=" + SharedData.companyid + " and b.item_type='Goods' and b.item_name like '%" + p1 + "%'")
            gridItem.DataSource = itemdata
            gridItem.ReadOnly = True
            gridItem.AutoGenerateColumns = False
            gridItem.AllowUserToAddRows = False
        Catch ex As Exception

        End Try

    End Sub

    Private Sub PictureBox2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox2.Click
        Dim itemdata As New DataTable
        itemdata = obj.getdatatable("select b.item_name as ItemName,a.qty as Quantity from stock_tbl a,item_tbl b where a.item_no=b.item_no " & _
                                    " and a.company_id=" + SharedData.companyid + " and b.item_type='Goods'")
        obj.ExportToExcel(itemdata, "D:\Inventory.xls")
        MessageBox.Show("File created in D: Folder")
    End Sub
End Class