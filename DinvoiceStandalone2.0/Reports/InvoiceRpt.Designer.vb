<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class InvoiceRpt
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
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(InvoiceRpt))
        Me.gridAccounts = New System.Windows.Forms.DataGridView()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.rbtInvno = New System.Windows.Forms.RadioButton()
        Me.rbtPayStatus = New System.Windows.Forms.RadioButton()
        Me.rbtDate = New System.Windows.Forms.RadioButton()
        Me.rbtCusName = New System.Windows.Forms.RadioButton()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtSearchKeyword = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.cmpPaidStatus = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.txttodate = New System.Windows.Forms.TextBox()
        Me.txtfromdate = New System.Windows.Forms.TextBox()
        Me.dtptodt = New System.Windows.Forms.DateTimePicker()
        Me.dtpfromdt = New System.Windows.Forms.DateTimePicker()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lstbxDetails = New System.Windows.Forms.ListBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        CType(Me.gridAccounts, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel4.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.SuspendLayout()
        '
        'gridAccounts
        '
        Me.gridAccounts.BackgroundColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Century Gothic", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.gridAccounts.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.gridAccounts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.gridAccounts.DefaultCellStyle = DataGridViewCellStyle2
        Me.gridAccounts.Location = New System.Drawing.Point(12, 175)
        Me.gridAccounts.Name = "gridAccounts"
        Me.gridAccounts.RowHeadersVisible = False
        Me.gridAccounts.Size = New System.Drawing.Size(1270, 416)
        Me.gridAccounts.TabIndex = 14
        '
        'Panel4
        '
        Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel4.Controls.Add(Me.rbtInvno)
        Me.Panel4.Controls.Add(Me.rbtPayStatus)
        Me.Panel4.Controls.Add(Me.rbtDate)
        Me.Panel4.Controls.Add(Me.rbtCusName)
        Me.Panel4.Location = New System.Drawing.Point(333, 9)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(215, 49)
        Me.Panel4.TabIndex = 13
        '
        'rbtInvno
        '
        Me.rbtInvno.AutoSize = True
        Me.rbtInvno.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbtInvno.ForeColor = System.Drawing.Color.FromArgb(CType(CType(53, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(147, Byte), Integer))
        Me.rbtInvno.Location = New System.Drawing.Point(111, 2)
        Me.rbtInvno.Name = "rbtInvno"
        Me.rbtInvno.Size = New System.Drawing.Size(77, 17)
        Me.rbtInvno.TabIndex = 0
        Me.rbtInvno.Text = "Invoice No"
        Me.rbtInvno.UseVisualStyleBackColor = True
        '
        'rbtPayStatus
        '
        Me.rbtPayStatus.AutoSize = True
        Me.rbtPayStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbtPayStatus.ForeColor = System.Drawing.Color.FromArgb(CType(CType(53, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(147, Byte), Integer))
        Me.rbtPayStatus.Location = New System.Drawing.Point(111, 27)
        Me.rbtPayStatus.Name = "rbtPayStatus"
        Me.rbtPayStatus.Size = New System.Drawing.Size(99, 17)
        Me.rbtPayStatus.TabIndex = 0
        Me.rbtPayStatus.Text = "Payment Status"
        Me.rbtPayStatus.UseVisualStyleBackColor = True
        '
        'rbtDate
        '
        Me.rbtDate.AutoSize = True
        Me.rbtDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbtDate.ForeColor = System.Drawing.Color.FromArgb(CType(CType(53, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(147, Byte), Integer))
        Me.rbtDate.Location = New System.Drawing.Point(8, 26)
        Me.rbtDate.Name = "rbtDate"
        Me.rbtDate.Size = New System.Drawing.Size(48, 17)
        Me.rbtDate.TabIndex = 0
        Me.rbtDate.Text = "Date"
        Me.rbtDate.UseVisualStyleBackColor = True
        '
        'rbtCusName
        '
        Me.rbtCusName.AutoSize = True
        Me.rbtCusName.Checked = True
        Me.rbtCusName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbtCusName.ForeColor = System.Drawing.Color.FromArgb(CType(CType(53, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(147, Byte), Integer))
        Me.rbtCusName.Location = New System.Drawing.Point(8, 3)
        Me.rbtCusName.Name = "rbtCusName"
        Me.rbtCusName.Size = New System.Drawing.Size(82, 17)
        Me.rbtCusName.TabIndex = 0
        Me.rbtCusName.TabStop = True
        Me.rbtCusName.Text = "Client Name"
        Me.rbtCusName.UseVisualStyleBackColor = True
        '
        'btnSearch
        '
        Me.btnSearch.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(109, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.btnSearch.FlatAppearance.BorderSize = 0
        Me.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSearch.ForeColor = System.Drawing.Color.White
        Me.btnSearch.Location = New System.Drawing.Point(85, 52)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(75, 23)
        Me.btnSearch.TabIndex = 12
        Me.btnSearch.Text = "Search"
        Me.btnSearch.UseVisualStyleBackColor = False
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Arial Narrow", 11.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.FromArgb(CType(CType(53, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(147, Byte), Integer))
        Me.Label12.Location = New System.Drawing.Point(570, 9)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(120, 20)
        Me.Label12.TabIndex = 8
        Me.Label12.Text = "Generated Invoice"
        '
        'txtSearchKeyword
        '
        Me.txtSearchKeyword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSearchKeyword.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSearchKeyword.Location = New System.Drawing.Point(72, 13)
        Me.txtSearchKeyword.Name = "txtSearchKeyword"
        Me.txtSearchKeyword.Size = New System.Drawing.Size(188, 23)
        Me.txtSearchKeyword.TabIndex = 11
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.ForeColor = System.Drawing.Color.FromArgb(CType(CType(53, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(147, Byte), Integer))
        Me.Label14.Location = New System.Drawing.Point(284, 14)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(45, 13)
        Me.Label14.TabIndex = 10
        Me.Label14.Text = "Criteria :"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.ForeColor = System.Drawing.Color.FromArgb(CType(CType(53, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(147, Byte), Integer))
        Me.Label11.Location = New System.Drawing.Point(5, 18)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(48, 13)
        Me.Label11.TabIndex = 9
        Me.Label11.Text = "Keyword"
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.Panel3)
        Me.Panel1.Controls.Add(Me.Panel5)
        Me.Panel1.Controls.Add(Me.Panel4)
        Me.Panel1.Controls.Add(Me.Label11)
        Me.Panel1.Controls.Add(Me.Label14)
        Me.Panel1.Controls.Add(Me.txtSearchKeyword)
        Me.Panel1.Location = New System.Drawing.Point(12, 32)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1270, 111)
        Me.Panel1.TabIndex = 15
        '
        'Panel3
        '
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.cmpPaidStatus)
        Me.Panel3.Controls.Add(Me.Label5)
        Me.Panel3.Location = New System.Drawing.Point(333, 55)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(215, 34)
        Me.Panel3.TabIndex = 13
        '
        'cmpPaidStatus
        '
        Me.cmpPaidStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmpPaidStatus.FormattingEnabled = True
        Me.cmpPaidStatus.Items.AddRange(New Object() {"Paid", "Unpaid"})
        Me.cmpPaidStatus.Location = New System.Drawing.Point(83, 6)
        Me.cmpPaidStatus.Name = "cmpPaidStatus"
        Me.cmpPaidStatus.Size = New System.Drawing.Size(121, 21)
        Me.cmpPaidStatus.TabIndex = 1
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(53, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(147, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(12, 9)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(37, 13)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "Status"
        '
        'Panel5
        '
        Me.Panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel5.Controls.Add(Me.txttodate)
        Me.Panel5.Controls.Add(Me.txtfromdate)
        Me.Panel5.Controls.Add(Me.dtptodt)
        Me.Panel5.Controls.Add(Me.dtpfromdt)
        Me.Panel5.Controls.Add(Me.Label4)
        Me.Panel5.Controls.Add(Me.Label6)
        Me.Panel5.Controls.Add(Me.btnSearch)
        Me.Panel5.Location = New System.Drawing.Point(554, 9)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(211, 80)
        Me.Panel5.TabIndex = 13
        '
        'txttodate
        '
        Me.txttodate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txttodate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txttodate.Location = New System.Drawing.Point(71, 26)
        Me.txttodate.Name = "txttodate"
        Me.txttodate.ReadOnly = True
        Me.txttodate.Size = New System.Drawing.Size(111, 20)
        Me.txttodate.TabIndex = 11
        '
        'txtfromdate
        '
        Me.txtfromdate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtfromdate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtfromdate.Location = New System.Drawing.Point(71, 3)
        Me.txtfromdate.Name = "txtfromdate"
        Me.txtfromdate.ReadOnly = True
        Me.txtfromdate.Size = New System.Drawing.Size(111, 20)
        Me.txtfromdate.TabIndex = 11
        '
        'dtptodt
        '
        Me.dtptodt.Location = New System.Drawing.Point(180, 26)
        Me.dtptodt.Name = "dtptodt"
        Me.dtptodt.Size = New System.Drawing.Size(19, 20)
        Me.dtptodt.TabIndex = 12
        '
        'dtpfromdt
        '
        Me.dtpfromdt.Location = New System.Drawing.Point(179, 3)
        Me.dtpfromdt.Name = "dtpfromdt"
        Me.dtpfromdt.Size = New System.Drawing.Size(19, 20)
        Me.dtpfromdt.TabIndex = 12
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(53, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(147, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(3, 29)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(52, 13)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "To Date :"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(53, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(147, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(3, 6)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(62, 13)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "From Date :"
        '
        'lstbxDetails
        '
        Me.lstbxDetails.FormattingEnabled = True
        Me.lstbxDetails.Location = New System.Drawing.Point(85, 72)
        Me.lstbxDetails.Name = "lstbxDetails"
        Me.lstbxDetails.Size = New System.Drawing.Size(188, 95)
        Me.lstbxDetails.TabIndex = 14
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial Narrow", 11.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(53, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(147, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(595, 149)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(80, 20)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Invoice List"
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.White
        Me.Button1.FlatAppearance.BorderSize = 0
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.ForeColor = System.Drawing.Color.White
        Me.Button1.Image = Global.DinvoiceStandalone2._0.My.Resources.Resources.excel1
        Me.Button1.Location = New System.Drawing.Point(1254, 144)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(28, 28)
        Me.Button1.TabIndex = 16
        Me.ToolTip1.SetToolTip(Me.Button1, "Export to excel")
        Me.Button1.UseVisualStyleBackColor = False
        '
        'InvoiceRpt
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1294, 603)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.lstbxDetails)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.gridAccounts)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label12)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "InvoiceRpt"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Invoice Report"
        CType(Me.gridAccounts, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents gridAccounts As System.Windows.Forms.DataGridView
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents rbtInvno As System.Windows.Forms.RadioButton
    Friend WithEvents rbtDate As System.Windows.Forms.RadioButton
    Friend WithEvents rbtCusName As System.Windows.Forms.RadioButton
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtSearchKeyword As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lstbxDetails As System.Windows.Forms.ListBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmpPaidStatus As System.Windows.Forms.ComboBox
    Friend WithEvents rbtPayStatus As System.Windows.Forms.RadioButton
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents txttodate As System.Windows.Forms.TextBox
    Friend WithEvents txtfromdate As System.Windows.Forms.TextBox
    Friend WithEvents dtptodt As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpfromdt As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents FolderBrowserDialog1 As System.Windows.Forms.FolderBrowserDialog
End Class
