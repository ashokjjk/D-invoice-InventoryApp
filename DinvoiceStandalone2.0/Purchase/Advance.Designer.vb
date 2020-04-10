<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Advance
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
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Advance))
        Me.gridAdvance = New System.Windows.Forms.DataGridView()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.advbankid = New System.Windows.Forms.Label()
        Me.lblitemcode = New System.Windows.Forms.Label()
        Me.lblcuscode = New System.Windows.Forms.Label()
        Me.PictureBox8 = New System.Windows.Forms.PictureBox()
        Me.pcbhelp = New System.Windows.Forms.PictureBox()
        Me.lblcode = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.DateTimePicker2 = New System.Windows.Forms.DateTimePicker()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.rbtdate = New System.Windows.Forms.RadioButton()
        Me.rbtName = New System.Windows.Forms.RadioButton()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.lstbxCusname = New System.Windows.Forms.ListBox()
        Me.lstbxItemName = New System.Windows.Forms.ListBox()
        Me.pnlBankdtls = New System.Windows.Forms.Panel()
        Me.txtChequeNo = New System.Windows.Forms.TextBox()
        Me.txtChequedt = New System.Windows.Forms.TextBox()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.cmbBankname = New System.Windows.Forms.ComboBox()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.DtpChequedt = New System.Windows.Forms.DateTimePicker()
        Me.rbtBank = New System.Windows.Forms.RadioButton()
        Me.rbtPettycash = New System.Windows.Forms.RadioButton()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.dtpAdvDt = New System.Windows.Forms.DateTimePicker()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmbCessPercent = New System.Windows.Forms.ComboBox()
        Me.txtTaxpercent = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtAdvTotal = New System.Windows.Forms.TextBox()
        Me.txtAdvAmt = New System.Windows.Forms.TextBox()
        Me.txtItmName = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtCusName = New System.Windows.Forms.TextBox()
        Me.txtadvdate = New System.Windows.Forms.TextBox()
        Me.cmbaccname = New System.Windows.Forms.ComboBox()
        Me.cmbacctype = New System.Windows.Forms.ComboBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtSearchKeyword = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        CType(Me.gridAdvance, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pcbhelp, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.pnlBankdtls.SuspendLayout()
        Me.SuspendLayout()
        '
        'gridAdvance
        '
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.LightSteelBlue
        Me.gridAdvance.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle2
        Me.gridAdvance.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gridAdvance.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.gridAdvance.BackgroundColor = System.Drawing.SystemColors.Info
        Me.gridAdvance.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gridAdvance.Location = New System.Drawing.Point(7, 406)
        Me.gridAdvance.Name = "gridAdvance"
        Me.gridAdvance.RowHeadersVisible = False
        Me.gridAdvance.Size = New System.Drawing.Size(649, 279)
        Me.gridAdvance.TabIndex = 7
        '
        'Panel1
        '
        Me.Panel1.AutoScroll = True
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Controls.Add(Me.advbankid)
        Me.Panel1.Controls.Add(Me.lblitemcode)
        Me.Panel1.Controls.Add(Me.lblcuscode)
        Me.Panel1.Controls.Add(Me.PictureBox8)
        Me.Panel1.Controls.Add(Me.pcbhelp)
        Me.Panel1.Controls.Add(Me.lblcode)
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Controls.Add(Me.gridAdvance)
        Me.Panel1.Controls.Add(Me.Panel4)
        Me.Panel1.Controls.Add(Me.Panel3)
        Me.Panel1.Controls.Add(Me.Label12)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.txtSearchKeyword)
        Me.Panel1.Controls.Add(Me.Label14)
        Me.Panel1.Controls.Add(Me.Label11)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(664, 688)
        Me.Panel1.TabIndex = 3
        '
        'advbankid
        '
        Me.advbankid.AutoSize = True
        Me.advbankid.Location = New System.Drawing.Point(112, 308)
        Me.advbankid.Name = "advbankid"
        Me.advbankid.Size = New System.Drawing.Size(59, 17)
        Me.advbankid.TabIndex = 51
        Me.advbankid.Text = "Label21"
        Me.advbankid.Visible = False
        '
        'lblitemcode
        '
        Me.lblitemcode.AutoSize = True
        Me.lblitemcode.Location = New System.Drawing.Point(25, 341)
        Me.lblitemcode.Name = "lblitemcode"
        Me.lblitemcode.Size = New System.Drawing.Size(59, 17)
        Me.lblitemcode.TabIndex = 51
        Me.lblitemcode.Text = "Label21"
        Me.lblitemcode.Visible = False
        '
        'lblcuscode
        '
        Me.lblcuscode.AutoSize = True
        Me.lblcuscode.Location = New System.Drawing.Point(25, 358)
        Me.lblcuscode.Name = "lblcuscode"
        Me.lblcuscode.Size = New System.Drawing.Size(59, 17)
        Me.lblcuscode.TabIndex = 51
        Me.lblcuscode.Text = "Label21"
        Me.lblcuscode.Visible = False
        '
        'PictureBox8
        '
        Me.PictureBox8.Image = Global.DinvoiceStandalone2._0.My.Resources.Resources.question
        Me.PictureBox8.Location = New System.Drawing.Point(417, 5)
        Me.PictureBox8.Name = "PictureBox8"
        Me.PictureBox8.Size = New System.Drawing.Size(26, 22)
        Me.PictureBox8.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox8.TabIndex = 50
        Me.PictureBox8.TabStop = False
        Me.ToolTip1.SetToolTip(Me.PictureBox8, resources.GetString("PictureBox8.ToolTip"))
        '
        'pcbhelp
        '
        Me.pcbhelp.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pcbhelp.Image = CType(resources.GetObject("pcbhelp.Image"), System.Drawing.Image)
        Me.pcbhelp.Location = New System.Drawing.Point(631, 3)
        Me.pcbhelp.Name = "pcbhelp"
        Me.pcbhelp.Size = New System.Drawing.Size(26, 22)
        Me.pcbhelp.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pcbhelp.TabIndex = 49
        Me.pcbhelp.TabStop = False
        Me.ToolTip1.SetToolTip(Me.pcbhelp, "Hower on any text will provide details about it")
        '
        'lblcode
        '
        Me.lblcode.AutoSize = True
        Me.lblcode.Location = New System.Drawing.Point(25, 375)
        Me.lblcode.Name = "lblcode"
        Me.lblcode.Size = New System.Drawing.Size(59, 17)
        Me.lblcode.TabIndex = 9
        Me.lblcode.Text = "Label20"
        Me.lblcode.Visible = False
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.DateTimePicker2)
        Me.Panel2.Controls.Add(Me.DateTimePicker1)
        Me.Panel2.Controls.Add(Me.TextBox2)
        Me.Panel2.Controls.Add(Me.TextBox1)
        Me.Panel2.Controls.Add(Me.Label8)
        Me.Panel2.Controls.Add(Me.Label6)
        Me.Panel2.Location = New System.Drawing.Point(555, 303)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(101, 100)
        Me.Panel2.TabIndex = 8
        '
        'DateTimePicker2
        '
        Me.DateTimePicker2.Location = New System.Drawing.Point(79, 73)
        Me.DateTimePicker2.Name = "DateTimePicker2"
        Me.DateTimePicker2.Size = New System.Drawing.Size(16, 23)
        Me.DateTimePicker2.TabIndex = 3
        Me.ToolTip1.SetToolTip(Me.DateTimePicker2, "Select to date")
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Location = New System.Drawing.Point(79, 25)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(16, 23)
        Me.DateTimePicker1.TabIndex = 3
        Me.ToolTip1.SetToolTip(Me.DateTimePicker1, "Select from date")
        '
        'TextBox2
        '
        Me.TextBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBox2.Location = New System.Drawing.Point(3, 73)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.ReadOnly = True
        Me.TextBox2.Size = New System.Drawing.Size(76, 23)
        Me.TextBox2.TabIndex = 2
        '
        'TextBox1
        '
        Me.TextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBox1.Location = New System.Drawing.Point(3, 25)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ReadOnly = True
        Me.TextBox1.Size = New System.Drawing.Size(76, 23)
        Me.TextBox1.TabIndex = 2
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(53, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(147, Byte), Integer))
        Me.Label8.Location = New System.Drawing.Point(3, 53)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(25, 17)
        Me.Label8.TabIndex = 1
        Me.Label8.Text = "To"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(53, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(147, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(3, 5)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(40, 17)
        Me.Label6.TabIndex = 1
        Me.Label6.Text = "From"
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.rbtdate)
        Me.Panel4.Controls.Add(Me.rbtName)
        Me.Panel4.Location = New System.Drawing.Point(419, 375)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(130, 23)
        Me.Panel4.TabIndex = 6
        '
        'rbtdate
        '
        Me.rbtdate.AutoSize = True
        Me.rbtdate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbtdate.ForeColor = System.Drawing.Color.FromArgb(CType(CType(53, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(147, Byte), Integer))
        Me.rbtdate.Location = New System.Drawing.Point(72, 4)
        Me.rbtdate.Name = "rbtdate"
        Me.rbtdate.Size = New System.Drawing.Size(48, 17)
        Me.rbtdate.TabIndex = 1
        Me.rbtdate.Text = "Date"
        Me.ToolTip1.SetToolTip(Me.rbtdate, "Search based on client name")
        Me.rbtdate.UseVisualStyleBackColor = True
        '
        'rbtName
        '
        Me.rbtName.AutoSize = True
        Me.rbtName.Checked = True
        Me.rbtName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbtName.ForeColor = System.Drawing.Color.FromArgb(CType(CType(53, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(147, Byte), Integer))
        Me.rbtName.Location = New System.Drawing.Point(8, 4)
        Me.rbtName.Name = "rbtName"
        Me.rbtName.Size = New System.Drawing.Size(53, 17)
        Me.rbtName.TabIndex = 0
        Me.rbtName.TabStop = True
        Me.rbtName.Text = "Name"
        Me.ToolTip1.SetToolTip(Me.rbtName, "Search based on client name")
        Me.rbtName.UseVisualStyleBackColor = True
        '
        'Panel3
        '
        Me.Panel3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel3.AutoScroll = True
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.lstbxCusname)
        Me.Panel3.Controls.Add(Me.lstbxItemName)
        Me.Panel3.Controls.Add(Me.pnlBankdtls)
        Me.Panel3.Controls.Add(Me.rbtBank)
        Me.Panel3.Controls.Add(Me.rbtPettycash)
        Me.Panel3.Controls.Add(Me.Label23)
        Me.Panel3.Controls.Add(Me.Label24)
        Me.Panel3.Controls.Add(Me.Label21)
        Me.Panel3.Controls.Add(Me.Label20)
        Me.Panel3.Controls.Add(Me.Label17)
        Me.Panel3.Controls.Add(Me.Label16)
        Me.Panel3.Controls.Add(Me.Label15)
        Me.Panel3.Controls.Add(Me.Label13)
        Me.Panel3.Controls.Add(Me.Label10)
        Me.Panel3.Controls.Add(Me.Label22)
        Me.Panel3.Controls.Add(Me.dtpAdvDt)
        Me.Panel3.Controls.Add(Me.btnClear)
        Me.Panel3.Controls.Add(Me.btnSave)
        Me.Panel3.Controls.Add(Me.Label2)
        Me.Panel3.Controls.Add(Me.Label18)
        Me.Panel3.Controls.Add(Me.Label3)
        Me.Panel3.Controls.Add(Me.cmbCessPercent)
        Me.Panel3.Controls.Add(Me.txtTaxpercent)
        Me.Panel3.Controls.Add(Me.Label4)
        Me.Panel3.Controls.Add(Me.Label9)
        Me.Panel3.Controls.Add(Me.Label5)
        Me.Panel3.Controls.Add(Me.txtAdvTotal)
        Me.Panel3.Controls.Add(Me.txtAdvAmt)
        Me.Panel3.Controls.Add(Me.txtItmName)
        Me.Panel3.Controls.Add(Me.Label7)
        Me.Panel3.Controls.Add(Me.txtCusName)
        Me.Panel3.Controls.Add(Me.txtadvdate)
        Me.Panel3.Controls.Add(Me.cmbaccname)
        Me.Panel3.Controls.Add(Me.cmbacctype)
        Me.Panel3.Location = New System.Drawing.Point(12, 32)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(638, 265)
        Me.Panel3.TabIndex = 5
        '
        'lstbxCusname
        '
        Me.lstbxCusname.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lstbxCusname.FormattingEnabled = True
        Me.lstbxCusname.ItemHeight = 16
        Me.lstbxCusname.Items.AddRange(New Object() {"Add New"})
        Me.lstbxCusname.Location = New System.Drawing.Point(138, 32)
        Me.lstbxCusname.Name = "lstbxCusname"
        Me.lstbxCusname.Size = New System.Drawing.Size(188, 132)
        Me.lstbxCusname.TabIndex = 7
        '
        'lstbxItemName
        '
        Me.lstbxItemName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lstbxItemName.FormattingEnabled = True
        Me.lstbxItemName.ItemHeight = 16
        Me.lstbxItemName.Items.AddRange(New Object() {"Add New"})
        Me.lstbxItemName.Location = New System.Drawing.Point(138, 120)
        Me.lstbxItemName.Name = "lstbxItemName"
        Me.lstbxItemName.Size = New System.Drawing.Size(187, 132)
        Me.lstbxItemName.TabIndex = 7
        '
        'pnlBankdtls
        '
        Me.pnlBankdtls.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlBankdtls.Controls.Add(Me.txtChequeNo)
        Me.pnlBankdtls.Controls.Add(Me.txtChequedt)
        Me.pnlBankdtls.Controls.Add(Me.Label27)
        Me.pnlBankdtls.Controls.Add(Me.Label26)
        Me.pnlBankdtls.Controls.Add(Me.cmbBankname)
        Me.pnlBankdtls.Controls.Add(Me.Label25)
        Me.pnlBankdtls.Controls.Add(Me.DtpChequedt)
        Me.pnlBankdtls.Location = New System.Drawing.Point(334, 124)
        Me.pnlBankdtls.Name = "pnlBankdtls"
        Me.pnlBankdtls.Size = New System.Drawing.Size(298, 91)
        Me.pnlBankdtls.TabIndex = 31
        '
        'txtChequeNo
        '
        Me.txtChequeNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtChequeNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtChequeNo.Location = New System.Drawing.Point(138, 30)
        Me.txtChequeNo.Name = "txtChequeNo"
        Me.txtChequeNo.Size = New System.Drawing.Size(156, 23)
        Me.txtChequeNo.TabIndex = 1
        Me.txtChequeNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ToolTip1.SetToolTip(Me.txtChequeNo, "Total amount will be calculated automatically" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "With respect to Tax % & Cess %")
        '
        'txtChequedt
        '
        Me.txtChequedt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtChequedt.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtChequedt.Location = New System.Drawing.Point(138, 56)
        Me.txtChequedt.Name = "txtChequedt"
        Me.txtChequedt.ReadOnly = True
        Me.txtChequedt.Size = New System.Drawing.Size(136, 23)
        Me.txtChequedt.TabIndex = 6
        Me.txtChequedt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ToolTip1.SetToolTip(Me.txtChequedt, "Total amount will be calculated automatically" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "With respect to Tax % & Cess %")
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.ForeColor = System.Drawing.Color.FromArgb(CType(CType(53, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(147, Byte), Integer))
        Me.Label27.Location = New System.Drawing.Point(15, 62)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(91, 17)
        Me.Label27.TabIndex = 5
        Me.Label27.Text = "Cheque Date"
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.ForeColor = System.Drawing.Color.FromArgb(CType(CType(53, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(147, Byte), Integer))
        Me.Label26.Location = New System.Drawing.Point(15, 32)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(79, 17)
        Me.Label26.TabIndex = 4
        Me.Label26.Text = "Cheque No"
        '
        'cmbBankname
        '
        Me.cmbBankname.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbBankname.FormattingEnabled = True
        Me.cmbBankname.Location = New System.Drawing.Point(138, 3)
        Me.cmbBankname.Name = "cmbBankname"
        Me.cmbBankname.Size = New System.Drawing.Size(156, 24)
        Me.cmbBankname.TabIndex = 0
        Me.ToolTip1.SetToolTip(Me.cmbBankname, "Select Account name")
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.ForeColor = System.Drawing.Color.FromArgb(CType(CType(53, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(147, Byte), Integer))
        Me.Label25.Location = New System.Drawing.Point(15, 3)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(122, 17)
        Me.Label25.TabIndex = 3
        Me.Label25.Text = "Credit Bank Name"
        '
        'DtpChequedt
        '
        Me.DtpChequedt.Location = New System.Drawing.Point(273, 56)
        Me.DtpChequedt.Name = "DtpChequedt"
        Me.DtpChequedt.Size = New System.Drawing.Size(18, 23)
        Me.DtpChequedt.TabIndex = 2
        Me.ToolTip1.SetToolTip(Me.DtpChequedt, "Select advance date")
        '
        'rbtBank
        '
        Me.rbtBank.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rbtBank.AutoSize = True
        Me.rbtBank.ForeColor = System.Drawing.Color.FromArgb(CType(CType(53, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(147, Byte), Integer))
        Me.rbtBank.Location = New System.Drawing.Point(579, 100)
        Me.rbtBank.Name = "rbtBank"
        Me.rbtBank.Size = New System.Drawing.Size(58, 21)
        Me.rbtBank.TabIndex = 10
        Me.rbtBank.Text = "Bank"
        Me.rbtBank.UseVisualStyleBackColor = True
        '
        'rbtPettycash
        '
        Me.rbtPettycash.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rbtPettycash.AutoSize = True
        Me.rbtPettycash.Checked = True
        Me.rbtPettycash.ForeColor = System.Drawing.Color.FromArgb(CType(CType(53, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(147, Byte), Integer))
        Me.rbtPettycash.Location = New System.Drawing.Point(477, 100)
        Me.rbtPettycash.Name = "rbtPettycash"
        Me.rbtPettycash.Size = New System.Drawing.Size(94, 21)
        Me.rbtPettycash.TabIndex = 9
        Me.rbtPettycash.TabStop = True
        Me.rbtPettycash.Text = "Petty Cash"
        Me.rbtPettycash.UseVisualStyleBackColor = True
        '
        'Label23
        '
        Me.Label23.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label23.AutoSize = True
        Me.Label23.BackColor = System.Drawing.Color.Transparent
        Me.Label23.Font = New System.Drawing.Font("Arial Rounded MT Bold", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.ForeColor = System.Drawing.Color.Red
        Me.Label23.Location = New System.Drawing.Point(441, 40)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(10, 12)
        Me.Label23.TabIndex = 28
        Me.Label23.Text = "*"
        '
        'Label24
        '
        Me.Label24.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label24.AutoSize = True
        Me.Label24.ForeColor = System.Drawing.Color.FromArgb(CType(CType(53, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(147, Byte), Integer))
        Me.Label24.Location = New System.Drawing.Point(346, 102)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(81, 17)
        Me.Label24.TabIndex = 30
        Me.Label24.Text = "Credit Type"
        '
        'Label21
        '
        Me.Label21.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label21.AutoSize = True
        Me.Label21.ForeColor = System.Drawing.Color.FromArgb(CType(CType(53, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(147, Byte), Integer))
        Me.Label21.Location = New System.Drawing.Point(346, 70)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(100, 17)
        Me.Label21.TabIndex = 29
        Me.Label21.Text = "Account Name"
        '
        'Label20
        '
        Me.Label20.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label20.AutoSize = True
        Me.Label20.ForeColor = System.Drawing.Color.FromArgb(CType(CType(53, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(147, Byte), Integer))
        Me.Label20.Location = New System.Drawing.Point(346, 40)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(95, 17)
        Me.Label20.TabIndex = 27
        Me.Label20.Text = "Account Type"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.BackColor = System.Drawing.Color.Transparent
        Me.Label17.Font = New System.Drawing.Font("Arial Rounded MT Bold", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.Red
        Me.Label17.Location = New System.Drawing.Point(60, 152)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(10, 12)
        Me.Label17.TabIndex = 25
        Me.Label17.Text = "*"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Font = New System.Drawing.Font("Arial Rounded MT Bold", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.Red
        Me.Label16.Location = New System.Drawing.Point(51, 128)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(10, 12)
        Me.Label16.TabIndex = 24
        Me.Label16.Text = "*"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.Font = New System.Drawing.Font("Arial Rounded MT Bold", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.Red
        Me.Label15.Location = New System.Drawing.Point(80, 99)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(10, 12)
        Me.Label15.TabIndex = 23
        Me.Label15.Text = "*"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Font = New System.Drawing.Font("Arial Rounded MT Bold", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.Red
        Me.Label13.Location = New System.Drawing.Point(118, 70)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(10, 12)
        Me.Label13.TabIndex = 22
        Me.Label13.Text = "*"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Arial Rounded MT Bold", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Red
        Me.Label10.Location = New System.Drawing.Point(100, 43)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(10, 12)
        Me.Label10.TabIndex = 20
        Me.Label10.Text = "*"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.BackColor = System.Drawing.Color.Transparent
        Me.Label22.Font = New System.Drawing.Font("Arial Rounded MT Bold", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.ForeColor = System.Drawing.Color.Red
        Me.Label22.Location = New System.Drawing.Point(113, 15)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(10, 12)
        Me.Label22.TabIndex = 19
        Me.Label22.Text = "*"
        '
        'dtpAdvDt
        '
        Me.dtpAdvDt.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtpAdvDt.Location = New System.Drawing.Point(307, 40)
        Me.dtpAdvDt.Name = "dtpAdvDt"
        Me.dtpAdvDt.Size = New System.Drawing.Size(18, 23)
        Me.dtpAdvDt.TabIndex = 1
        Me.ToolTip1.SetToolTip(Me.dtpAdvDt, "Select advance date")
        '
        'btnClear
        '
        Me.btnClear.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnClear.FlatAppearance.BorderSize = 0
        Me.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClear.ForeColor = System.Drawing.Color.Black
        Me.btnClear.Location = New System.Drawing.Point(238, 226)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(75, 30)
        Me.btnClear.TabIndex = 12
        Me.btnClear.Text = "Clear"
        Me.btnClear.UseVisualStyleBackColor = False
        '
        'btnSave
        '
        Me.btnSave.BackColor = System.Drawing.Color.FromArgb(CType(CType(92, Byte), Integer), CType(CType(184, Byte), Integer), CType(CType(92, Byte), Integer))
        Me.btnSave.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(92, Byte), Integer), CType(CType(184, Byte), Integer), CType(CType(92, Byte), Integer))
        Me.btnSave.FlatAppearance.BorderSize = 0
        Me.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSave.ForeColor = System.Drawing.Color.White
        Me.btnSave.Location = New System.Drawing.Point(153, 227)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(75, 29)
        Me.btnSave.TabIndex = 11
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(53, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(147, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(8, 15)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(108, 17)
        Me.Label2.TabIndex = 18
        Me.Label2.Text = "Company Name"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.ForeColor = System.Drawing.Color.FromArgb(CType(CType(53, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(147, Byte), Integer))
        Me.Label18.Location = New System.Drawing.Point(8, 71)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(115, 17)
        Me.Label18.TabIndex = 16
        Me.Label18.Text = "Advance Amount"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(53, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(147, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(8, 43)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(97, 17)
        Me.Label3.TabIndex = 17
        Me.Label3.Text = "Advance Date"
        '
        'cmbCessPercent
        '
        Me.cmbCessPercent.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbCessPercent.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCessPercent.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbCessPercent.FormattingEnabled = True
        Me.cmbCessPercent.Location = New System.Drawing.Point(138, 153)
        Me.cmbCessPercent.Name = "cmbCessPercent"
        Me.cmbCessPercent.Size = New System.Drawing.Size(189, 24)
        Me.cmbCessPercent.TabIndex = 5
        Me.ToolTip1.SetToolTip(Me.cmbCessPercent, "Select Cess %")
        '
        'txtTaxpercent
        '
        Me.txtTaxpercent.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtTaxpercent.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.txtTaxpercent.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTaxpercent.FormattingEnabled = True
        Me.txtTaxpercent.Location = New System.Drawing.Point(138, 124)
        Me.txtTaxpercent.Name = "txtTaxpercent"
        Me.txtTaxpercent.Size = New System.Drawing.Size(190, 24)
        Me.txtTaxpercent.TabIndex = 4
        Me.ToolTip1.SetToolTip(Me.txtTaxpercent, "Select GST %")
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(53, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(147, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(346, 12)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(99, 17)
        Me.Label4.TabIndex = 26
        Me.Label4.Text = "Advance Total"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(53, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(147, Byte), Integer))
        Me.Label9.Location = New System.Drawing.Point(8, 155)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(55, 17)
        Me.Label9.TabIndex = 13
        Me.Label9.Text = "Cess %"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(53, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(147, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(8, 127)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(47, 17)
        Me.Label5.TabIndex = 14
        Me.Label5.Text = "Tax %"
        '
        'txtAdvTotal
        '
        Me.txtAdvTotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtAdvTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAdvTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAdvTotal.Location = New System.Drawing.Point(477, 11)
        Me.txtAdvTotal.Name = "txtAdvTotal"
        Me.txtAdvTotal.ReadOnly = True
        Me.txtAdvTotal.Size = New System.Drawing.Size(156, 23)
        Me.txtAdvTotal.TabIndex = 6
        Me.txtAdvTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ToolTip1.SetToolTip(Me.txtAdvTotal, "Total amount will be calculated automatically" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "With respect to Tax % & Cess %")
        '
        'txtAdvAmt
        '
        Me.txtAdvAmt.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtAdvAmt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAdvAmt.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAdvAmt.Location = New System.Drawing.Point(138, 68)
        Me.txtAdvAmt.Name = "txtAdvAmt"
        Me.txtAdvAmt.Size = New System.Drawing.Size(188, 23)
        Me.txtAdvAmt.TabIndex = 2
        Me.txtAdvAmt.Text = "0.00"
        Me.txtAdvAmt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ToolTip1.SetToolTip(Me.txtAdvAmt, "Enter advance amount")
        '
        'txtItmName
        '
        Me.txtItmName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtItmName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtItmName.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtItmName.Location = New System.Drawing.Point(138, 96)
        Me.txtItmName.Name = "txtItmName"
        Me.txtItmName.Size = New System.Drawing.Size(188, 23)
        Me.txtItmName.TabIndex = 3
        Me.ToolTip1.SetToolTip(Me.txtItmName, "Enter Item name")
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(53, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(147, Byte), Integer))
        Me.Label7.Location = New System.Drawing.Point(8, 99)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(75, 17)
        Me.Label7.TabIndex = 15
        Me.Label7.Text = "Item Name"
        '
        'txtCusName
        '
        Me.txtCusName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCusName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCusName.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCusName.Location = New System.Drawing.Point(138, 12)
        Me.txtCusName.Name = "txtCusName"
        Me.txtCusName.Size = New System.Drawing.Size(188, 23)
        Me.txtCusName.TabIndex = 0
        Me.ToolTip1.SetToolTip(Me.txtCusName, "Enter client name")
        '
        'txtadvdate
        '
        Me.txtadvdate.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtadvdate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtadvdate.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtadvdate.Location = New System.Drawing.Point(138, 40)
        Me.txtadvdate.Name = "txtadvdate"
        Me.txtadvdate.ReadOnly = True
        Me.txtadvdate.Size = New System.Drawing.Size(169, 23)
        Me.txtadvdate.TabIndex = 21
        '
        'cmbaccname
        '
        Me.cmbaccname.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbaccname.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbaccname.FormattingEnabled = True
        Me.cmbaccname.Location = New System.Drawing.Point(476, 69)
        Me.cmbaccname.Name = "cmbaccname"
        Me.cmbaccname.Size = New System.Drawing.Size(156, 24)
        Me.cmbaccname.TabIndex = 8
        '
        'cmbacctype
        '
        Me.cmbacctype.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbacctype.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbacctype.FormattingEnabled = True
        Me.cmbacctype.Location = New System.Drawing.Point(477, 39)
        Me.cmbacctype.Name = "cmbacctype"
        Me.cmbacctype.Size = New System.Drawing.Size(156, 24)
        Me.cmbacctype.TabIndex = 7
        Me.ToolTip1.SetToolTip(Me.cmbacctype, "Select Account name")
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Arial Narrow", 13.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.FromArgb(CType(CType(53, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(147, Byte), Integer))
        Me.Label12.Location = New System.Drawing.Point(290, 326)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(131, 22)
        Me.Label12.TabIndex = 0
        Me.Label12.Text = "Search Advances"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial Narrow", 13.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(53, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(147, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(283, 5)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(125, 22)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Record Advance"
        '
        'txtSearchKeyword
        '
        Me.txtSearchKeyword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSearchKeyword.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSearchKeyword.Location = New System.Drawing.Point(165, 375)
        Me.txtSearchKeyword.Name = "txtSearchKeyword"
        Me.txtSearchKeyword.Size = New System.Drawing.Size(188, 23)
        Me.txtSearchKeyword.TabIndex = 0
        Me.ToolTip1.SetToolTip(Me.txtSearchKeyword, "Enter prefix of selected criteria")
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.ForeColor = System.Drawing.Color.FromArgb(CType(CType(53, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(147, Byte), Integer))
        Me.Label14.Location = New System.Drawing.Point(360, 378)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(61, 17)
        Me.Label14.TabIndex = 1
        Me.Label14.Text = "Criteria :"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.ForeColor = System.Drawing.Color.FromArgb(CType(CType(53, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(147, Byte), Integer))
        Me.Label11.Location = New System.Drawing.Point(100, 378)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(62, 17)
        Me.Label11.TabIndex = 1
        Me.Label11.Text = "Keyword"
        '
        'ToolTip1
        '
        Me.ToolTip1.AutoPopDelay = 30000
        Me.ToolTip1.InitialDelay = 500
        Me.ToolTip1.IsBalloon = True
        Me.ToolTip1.ReshowDelay = 100
        Me.ToolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info
        Me.ToolTip1.ToolTipTitle = "Screen Tips"
        '
        'Advance
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(664, 688)
        Me.Controls.Add(Me.Panel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Advance"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Advance"
        CType(Me.gridAdvance, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PictureBox8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pcbhelp, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.pnlBankdtls.ResumeLayout(False)
        Me.pnlBankdtls.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gridAdvance As System.Windows.Forms.DataGridView
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents rbtdate As System.Windows.Forms.RadioButton
    Friend WithEvents rbtName As System.Windows.Forms.RadioButton
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents btnClear As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtAdvTotal As System.Windows.Forms.TextBox
    Friend WithEvents txtAdvAmt As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtadvdate As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtSearchKeyword As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtCusName As System.Windows.Forms.TextBox
    Friend WithEvents dtpAdvDt As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtTaxpercent As System.Windows.Forms.ComboBox
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents DateTimePicker2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents lstbxCusname As System.Windows.Forms.ListBox
    Friend WithEvents lstbxItemName As System.Windows.Forms.ListBox
    Friend WithEvents txtItmName As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents cmbCessPercent As System.Windows.Forms.ComboBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents lblcode As System.Windows.Forms.Label
    Friend WithEvents cmbacctype As System.Windows.Forms.ComboBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents PictureBox8 As System.Windows.Forms.PictureBox
    Friend WithEvents pcbhelp As System.Windows.Forms.PictureBox
    Friend WithEvents lblcuscode As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents cmbaccname As System.Windows.Forms.ComboBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents lblitemcode As System.Windows.Forms.Label
    Friend WithEvents pnlBankdtls As System.Windows.Forms.Panel
    Friend WithEvents txtChequeNo As System.Windows.Forms.TextBox
    Friend WithEvents txtChequedt As System.Windows.Forms.TextBox
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents cmbBankname As System.Windows.Forms.ComboBox
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents DtpChequedt As System.Windows.Forms.DateTimePicker
    Friend WithEvents rbtBank As System.Windows.Forms.RadioButton
    Friend WithEvents rbtPettycash As System.Windows.Forms.RadioButton
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents advbankid As System.Windows.Forms.Label
End Class
