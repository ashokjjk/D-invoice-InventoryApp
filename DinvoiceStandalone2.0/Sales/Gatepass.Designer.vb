<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Gatepass
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Gatepass))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblinvoiceno = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.lstbxInvNo = New System.Windows.Forms.ListBox()
        Me.lstbxNo = New System.Windows.Forms.ListBox()
        Me.gridgatepass = New System.Windows.Forms.DataGridView()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.rbtInvNo = New System.Windows.Forms.RadioButton()
        Me.rbtcustomer = New System.Windows.Forms.RadioButton()
        Me.rbtIndentNo = New System.Windows.Forms.RadioButton()
        Me.btnMkGatepass = New System.Windows.Forms.Button()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.txtInvoiceNo = New System.Windows.Forms.TextBox()
        Me.txtGatepassNo = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtSearch = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        CType(Me.gridgatepass, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel4.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.AutoScroll = True
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Controls.Add(Me.lblinvoiceno)
        Me.Panel1.Controls.Add(Me.Label19)
        Me.Panel1.Controls.Add(Me.lstbxInvNo)
        Me.Panel1.Controls.Add(Me.lstbxNo)
        Me.Panel1.Controls.Add(Me.gridgatepass)
        Me.Panel1.Controls.Add(Me.Panel4)
        Me.Panel1.Controls.Add(Me.btnMkGatepass)
        Me.Panel1.Controls.Add(Me.btnSearch)
        Me.Panel1.Controls.Add(Me.txtInvoiceNo)
        Me.Panel1.Controls.Add(Me.txtGatepassNo)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.txtSearch)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label14)
        Me.Panel1.Controls.Add(Me.Label11)
        Me.Panel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(699, 677)
        Me.Panel1.TabIndex = 2
        '
        'lblinvoiceno
        '
        Me.lblinvoiceno.AutoSize = True
        Me.lblinvoiceno.Location = New System.Drawing.Point(346, 604)
        Me.lblinvoiceno.Name = "lblinvoiceno"
        Me.lblinvoiceno.Size = New System.Drawing.Size(51, 17)
        Me.lblinvoiceno.TabIndex = 34
        Me.lblinvoiceno.Text = "Label4"
        Me.lblinvoiceno.Visible = False
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.BackColor = System.Drawing.Color.Transparent
        Me.Label19.Font = New System.Drawing.Font("Arial Rounded MT Bold", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.ForeColor = System.Drawing.Color.Red
        Me.Label19.Location = New System.Drawing.Point(119, 643)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(10, 12)
        Me.Label19.TabIndex = 33
        Me.Label19.Text = "*"
        '
        'lstbxInvNo
        '
        Me.lstbxInvNo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lstbxInvNo.FormattingEnabled = True
        Me.lstbxInvNo.ItemHeight = 16
        Me.lstbxInvNo.Location = New System.Drawing.Point(135, 400)
        Me.lstbxInvNo.Name = "lstbxInvNo"
        Me.lstbxInvNo.Size = New System.Drawing.Size(188, 212)
        Me.lstbxInvNo.TabIndex = 8
        '
        'lstbxNo
        '
        Me.lstbxNo.FormattingEnabled = True
        Me.lstbxNo.ItemHeight = 16
        Me.lstbxNo.Location = New System.Drawing.Point(83, 104)
        Me.lstbxNo.Name = "lstbxNo"
        Me.lstbxNo.Size = New System.Drawing.Size(188, 212)
        Me.lstbxNo.TabIndex = 8
        '
        'gridgatepass
        '
        Me.gridgatepass.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gridgatepass.BackgroundColor = System.Drawing.SystemColors.Info
        Me.gridgatepass.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gridgatepass.Location = New System.Drawing.Point(24, 122)
        Me.gridgatepass.Name = "gridgatepass"
        Me.gridgatepass.RowHeadersVisible = False
        Me.gridgatepass.Size = New System.Drawing.Size(649, 475)
        Me.gridgatepass.TabIndex = 7
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.rbtInvNo)
        Me.Panel4.Controls.Add(Me.rbtcustomer)
        Me.Panel4.Controls.Add(Me.rbtIndentNo)
        Me.Panel4.Location = New System.Drawing.Point(428, 82)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(245, 23)
        Me.Panel4.TabIndex = 6
        '
        'rbtInvNo
        '
        Me.rbtInvNo.AutoSize = True
        Me.rbtInvNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbtInvNo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(53, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(147, Byte), Integer))
        Me.rbtInvNo.Location = New System.Drawing.Point(84, 2)
        Me.rbtInvNo.Name = "rbtInvNo"
        Me.rbtInvNo.Size = New System.Drawing.Size(77, 17)
        Me.rbtInvNo.TabIndex = 1
        Me.rbtInvNo.TabStop = True
        Me.rbtInvNo.Text = "Invoice No"
        Me.rbtInvNo.UseVisualStyleBackColor = True
        '
        'rbtcustomer
        '
        Me.rbtcustomer.AutoSize = True
        Me.rbtcustomer.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbtcustomer.ForeColor = System.Drawing.Color.FromArgb(CType(CType(53, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(147, Byte), Integer))
        Me.rbtcustomer.Location = New System.Drawing.Point(172, 2)
        Me.rbtcustomer.Name = "rbtcustomer"
        Me.rbtcustomer.Size = New System.Drawing.Size(69, 17)
        Me.rbtcustomer.TabIndex = 2
        Me.rbtcustomer.TabStop = True
        Me.rbtcustomer.Text = "Customer"
        Me.rbtcustomer.UseVisualStyleBackColor = True
        '
        'rbtIndentNo
        '
        Me.rbtIndentNo.AutoSize = True
        Me.rbtIndentNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbtIndentNo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(53, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(147, Byte), Integer))
        Me.rbtIndentNo.Location = New System.Drawing.Point(6, 2)
        Me.rbtIndentNo.Name = "rbtIndentNo"
        Me.rbtIndentNo.Size = New System.Drawing.Size(72, 17)
        Me.rbtIndentNo.TabIndex = 0
        Me.rbtIndentNo.TabStop = True
        Me.rbtIndentNo.Text = "Indent No"
        Me.rbtIndentNo.UseVisualStyleBackColor = True
        '
        'btnMkGatepass
        '
        Me.btnMkGatepass.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnMkGatepass.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(109, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.btnMkGatepass.FlatAppearance.BorderSize = 0
        Me.btnMkGatepass.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnMkGatepass.ForeColor = System.Drawing.Color.White
        Me.btnMkGatepass.Location = New System.Drawing.Point(553, 614)
        Me.btnMkGatepass.Name = "btnMkGatepass"
        Me.btnMkGatepass.Size = New System.Drawing.Size(116, 41)
        Me.btnMkGatepass.TabIndex = 2
        Me.btnMkGatepass.Text = "Make Gatepass"
        Me.btnMkGatepass.UseVisualStyleBackColor = False
        '
        'btnSearch
        '
        Me.btnSearch.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(109, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.btnSearch.FlatAppearance.BorderSize = 0
        Me.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSearch.ForeColor = System.Drawing.Color.White
        Me.btnSearch.Location = New System.Drawing.Point(278, 81)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(75, 24)
        Me.btnSearch.TabIndex = 5
        Me.btnSearch.Text = "Search"
        Me.btnSearch.UseVisualStyleBackColor = False
        '
        'txtInvoiceNo
        '
        Me.txtInvoiceNo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtInvoiceNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtInvoiceNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtInvoiceNo.Location = New System.Drawing.Point(135, 612)
        Me.txtInvoiceNo.Name = "txtInvoiceNo"
        Me.txtInvoiceNo.Size = New System.Drawing.Size(188, 23)
        Me.txtInvoiceNo.TabIndex = 0
        '
        'txtGatepassNo
        '
        Me.txtGatepassNo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtGatepassNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtGatepassNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtGatepassNo.Location = New System.Drawing.Point(135, 641)
        Me.txtGatepassNo.Name = "txtGatepassNo"
        Me.txtGatepassNo.Size = New System.Drawing.Size(188, 23)
        Me.txtGatepassNo.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial Narrow", 11.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(53, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(147, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(291, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(132, 20)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Gatepass For Indent"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(53, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(147, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(31, 614)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(74, 17)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "Invoice No"
        '
        'txtSearch
        '
        Me.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSearch.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSearch.Location = New System.Drawing.Point(83, 81)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(188, 23)
        Me.txtSearch.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(53, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(147, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(31, 643)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(91, 17)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Gatepass No"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.ForeColor = System.Drawing.Color.FromArgb(CType(CType(53, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(147, Byte), Integer))
        Me.Label14.Location = New System.Drawing.Point(369, 85)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(61, 17)
        Me.Label14.TabIndex = 1
        Me.Label14.Text = "Criteria :"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.ForeColor = System.Drawing.Color.FromArgb(CType(CType(53, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(147, Byte), Integer))
        Me.Label11.Location = New System.Drawing.Point(20, 84)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(62, 17)
        Me.Label11.TabIndex = 1
        Me.Label11.Text = "Keyword"
        '
        'Gatepass
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(699, 677)
        Me.Controls.Add(Me.Panel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Gatepass"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Gatepass"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.gridgatepass, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents gridgatepass As System.Windows.Forms.DataGridView
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents rbtInvNo As System.Windows.Forms.RadioButton
    Friend WithEvents rbtcustomer As System.Windows.Forms.RadioButton
    Friend WithEvents rbtIndentNo As System.Windows.Forms.RadioButton
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtSearch As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents lstbxNo As System.Windows.Forms.ListBox
    Friend WithEvents btnMkGatepass As System.Windows.Forms.Button
    Friend WithEvents txtGatepassNo As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtInvoiceNo As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lstbxInvNo As System.Windows.Forms.ListBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents lblinvoiceno As System.Windows.Forms.Label
End Class
