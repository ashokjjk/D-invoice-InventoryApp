<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PurchaseReport
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PurchaseReport))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblid = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.txtfromdate = New System.Windows.Forms.TextBox()
        Me.txttodate = New System.Windows.Forms.TextBox()
        Me.DateTimePicker3 = New System.Windows.Forms.DateTimePicker()
        Me.DateTimePicker4 = New System.Windows.Forms.DateTimePicker()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.rbtno = New System.Windows.Forms.RadioButton()
        Me.rbtdate = New System.Windows.Forms.RadioButton()
        Me.rbtCusName = New System.Windows.Forms.RadioButton()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.txtSearchKeyword = New System.Windows.Forms.TextBox()
        Me.gridBills = New System.Windows.Forms.DataGridView()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lstbxDetails = New System.Windows.Forms.ListBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.Panel1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel4.SuspendLayout()
        CType(Me.gridBills, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.lblid)
        Me.Panel1.Controls.Add(Me.Panel3)
        Me.Panel1.Controls.Add(Me.Panel4)
        Me.Panel1.Controls.Add(Me.Label11)
        Me.Panel1.Controls.Add(Me.Label14)
        Me.Panel1.Controls.Add(Me.btnSearch)
        Me.Panel1.Controls.Add(Me.txtSearchKeyword)
        Me.Panel1.Location = New System.Drawing.Point(9, 44)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1273, 117)
        Me.Panel1.TabIndex = 25
        '
        'lblid
        '
        Me.lblid.AutoSize = True
        Me.lblid.Location = New System.Drawing.Point(399, 48)
        Me.lblid.Name = "lblid"
        Me.lblid.Size = New System.Drawing.Size(39, 13)
        Me.lblid.TabIndex = 14
        Me.lblid.Text = "Label1"
        Me.lblid.Visible = False
        '
        'Panel3
        '
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.txtfromdate)
        Me.Panel3.Controls.Add(Me.txttodate)
        Me.Panel3.Controls.Add(Me.DateTimePicker3)
        Me.Panel3.Controls.Add(Me.DateTimePicker4)
        Me.Panel3.Controls.Add(Me.Label4)
        Me.Panel3.Controls.Add(Me.Label6)
        Me.Panel3.Location = New System.Drawing.Point(511, 32)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(215, 76)
        Me.Panel3.TabIndex = 13
        '
        'txtfromdate
        '
        Me.txtfromdate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtfromdate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtfromdate.Location = New System.Drawing.Point(76, 5)
        Me.txtfromdate.Name = "txtfromdate"
        Me.txtfromdate.ReadOnly = True
        Me.txtfromdate.Size = New System.Drawing.Size(111, 20)
        Me.txtfromdate.TabIndex = 18
        '
        'txttodate
        '
        Me.txttodate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txttodate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txttodate.Location = New System.Drawing.Point(76, 28)
        Me.txttodate.Name = "txttodate"
        Me.txttodate.ReadOnly = True
        Me.txttodate.Size = New System.Drawing.Size(111, 20)
        Me.txttodate.TabIndex = 15
        '
        'DateTimePicker3
        '
        Me.DateTimePicker3.Location = New System.Drawing.Point(185, 28)
        Me.DateTimePicker3.Name = "DateTimePicker3"
        Me.DateTimePicker3.Size = New System.Drawing.Size(19, 20)
        Me.DateTimePicker3.TabIndex = 17
        '
        'DateTimePicker4
        '
        Me.DateTimePicker4.Location = New System.Drawing.Point(184, 5)
        Me.DateTimePicker4.Name = "DateTimePicker4"
        Me.DateTimePicker4.Size = New System.Drawing.Size(19, 20)
        Me.DateTimePicker4.TabIndex = 16
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(53, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(147, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(8, 31)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(52, 13)
        Me.Label4.TabIndex = 13
        Me.Label4.Text = "To Date :"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(53, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(147, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(8, 8)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(62, 13)
        Me.Label6.TabIndex = 14
        Me.Label6.Text = "From Date :"
        '
        'Panel4
        '
        Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel4.Controls.Add(Me.rbtno)
        Me.Panel4.Controls.Add(Me.rbtdate)
        Me.Panel4.Controls.Add(Me.rbtCusName)
        Me.Panel4.Location = New System.Drawing.Point(511, 8)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(215, 24)
        Me.Panel4.TabIndex = 13
        '
        'rbtno
        '
        Me.rbtno.AutoSize = True
        Me.rbtno.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbtno.ForeColor = System.Drawing.Color.FromArgb(CType(CType(53, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(147, Byte), Integer))
        Me.rbtno.Location = New System.Drawing.Point(130, 3)
        Me.rbtno.Name = "rbtno"
        Me.rbtno.Size = New System.Drawing.Size(87, 17)
        Me.rbtno.TabIndex = 0
        Me.rbtno.Text = "Purchase No"
        Me.rbtno.UseVisualStyleBackColor = True
        '
        'rbtdate
        '
        Me.rbtdate.AutoSize = True
        Me.rbtdate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbtdate.ForeColor = System.Drawing.Color.FromArgb(CType(CType(53, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(147, Byte), Integer))
        Me.rbtdate.Location = New System.Drawing.Point(81, 3)
        Me.rbtdate.Name = "rbtdate"
        Me.rbtdate.Size = New System.Drawing.Size(48, 17)
        Me.rbtdate.TabIndex = 0
        Me.rbtdate.Text = "Date"
        Me.rbtdate.UseVisualStyleBackColor = True
        '
        'rbtCusName
        '
        Me.rbtCusName.AutoSize = True
        Me.rbtCusName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbtCusName.ForeColor = System.Drawing.Color.FromArgb(CType(CType(53, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(147, Byte), Integer))
        Me.rbtCusName.Location = New System.Drawing.Point(1, 3)
        Me.rbtCusName.Name = "rbtCusName"
        Me.rbtCusName.Size = New System.Drawing.Size(82, 17)
        Me.rbtCusName.TabIndex = 0
        Me.rbtCusName.Text = "Client Name"
        Me.rbtCusName.UseVisualStyleBackColor = True
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.ForeColor = System.Drawing.Color.FromArgb(CType(CType(53, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(147, Byte), Integer))
        Me.Label11.Location = New System.Drawing.Point(69, 18)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(48, 13)
        Me.Label11.TabIndex = 9
        Me.Label11.Text = "Keyword"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.ForeColor = System.Drawing.Color.FromArgb(CType(CType(53, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(147, Byte), Integer))
        Me.Label14.Location = New System.Drawing.Point(462, 13)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(45, 13)
        Me.Label14.TabIndex = 10
        Me.Label14.Text = "Criteria :"
        '
        'btnSearch
        '
        Me.btnSearch.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(109, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.btnSearch.FlatAppearance.BorderSize = 0
        Me.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSearch.ForeColor = System.Drawing.Color.White
        Me.btnSearch.Location = New System.Drawing.Point(332, 16)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(75, 20)
        Me.btnSearch.TabIndex = 12
        Me.btnSearch.Text = "Search"
        Me.btnSearch.UseVisualStyleBackColor = False
        '
        'txtSearchKeyword
        '
        Me.txtSearchKeyword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSearchKeyword.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSearchKeyword.Location = New System.Drawing.Point(136, 13)
        Me.txtSearchKeyword.Name = "txtSearchKeyword"
        Me.txtSearchKeyword.Size = New System.Drawing.Size(188, 23)
        Me.txtSearchKeyword.TabIndex = 11
        '
        'gridBills
        '
        Me.gridBills.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.gridBills.BackgroundColor = System.Drawing.SystemColors.Info
        Me.gridBills.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gridBills.Location = New System.Drawing.Point(9, 200)
        Me.gridBills.Name = "gridBills"
        Me.gridBills.RowHeadersVisible = False
        Me.gridBills.Size = New System.Drawing.Size(1273, 524)
        Me.gridBills.TabIndex = 23
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial Narrow", 11.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(53, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(147, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(598, 177)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(97, 20)
        Me.Label3.TabIndex = 21
        Me.Label3.Text = "Purchase Bills"
        '
        'lstbxDetails
        '
        Me.lstbxDetails.FormattingEnabled = True
        Me.lstbxDetails.Location = New System.Drawing.Point(146, 81)
        Me.lstbxDetails.Name = "lstbxDetails"
        Me.lstbxDetails.Size = New System.Drawing.Size(188, 95)
        Me.lstbxDetails.TabIndex = 24
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Arial Narrow", 11.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.FromArgb(CType(CType(53, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(147, Byte), Integer))
        Me.Label12.Location = New System.Drawing.Point(588, 9)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(110, 20)
        Me.Label12.TabIndex = 22
        Me.Label12.Text = "Purchase Report"
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.White
        Me.Button1.FlatAppearance.BorderSize = 0
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.ForeColor = System.Drawing.Color.White
        Me.Button1.Image = Global.DinvoiceStandalone2._0.My.Resources.Resources.excel1
        Me.Button1.Location = New System.Drawing.Point(1254, 169)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(28, 28)
        Me.Button1.TabIndex = 26
        Me.ToolTip1.SetToolTip(Me.Button1, "Export to excel")
        Me.Button1.UseVisualStyleBackColor = False
        '
        'PurchaseReport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1294, 736)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.lstbxDetails)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.gridBills)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label12)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "PurchaseReport"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Purchase Report"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        CType(Me.gridBills, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents rbtdate As System.Windows.Forms.RadioButton
    Friend WithEvents rbtCusName As System.Windows.Forms.RadioButton
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents txtSearchKeyword As System.Windows.Forms.TextBox
    Friend WithEvents gridBills As System.Windows.Forms.DataGridView
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lstbxDetails As System.Windows.Forms.ListBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txttodate As System.Windows.Forms.TextBox
    Friend WithEvents DateTimePicker3 As System.Windows.Forms.DateTimePicker
    Friend WithEvents DateTimePicker4 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtfromdate As System.Windows.Forms.TextBox
    Friend WithEvents rbtno As System.Windows.Forms.RadioButton
    Friend WithEvents lblid As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents FolderBrowserDialog1 As System.Windows.Forms.FolderBrowserDialog
End Class
