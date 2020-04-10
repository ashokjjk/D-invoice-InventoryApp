<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class VoucherReciepts
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(VoucherReciepts))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblcuscode = New System.Windows.Forms.Label()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.txtSearchtodt = New System.Windows.Forms.TextBox()
        Me.txtSearchfromdt = New System.Windows.Forms.TextBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.dtpSearchfromdt = New System.Windows.Forms.DateTimePicker()
        Me.dtpSearchtodt = New System.Windows.Forms.DateTimePicker()
        Me.pnlBills = New System.Windows.Forms.Panel()
        Me.dtpTodt = New System.Windows.Forms.DateTimePicker()
        Me.dtpFromdt = New System.Windows.Forms.DateTimePicker()
        Me.gridBills = New System.Windows.Forms.DataGridView()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtToDt = New System.Windows.Forms.TextBox()
        Me.txtFromDt = New System.Windows.Forms.TextBox()
        Me.btnList = New System.Windows.Forms.Button()
        Me.gridVoucher = New System.Windows.Forms.DataGridView()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.rdnvouno = New System.Windows.Forms.RadioButton()
        Me.rbtDate = New System.Windows.Forms.RadioButton()
        Me.rbtName = New System.Windows.Forms.RadioButton()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtSearchKeyword = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.lstClientName = New System.Windows.Forms.ListBox()
        Me.cmbAcctype = New System.Windows.Forms.ComboBox()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.txtNotes = New System.Windows.Forms.TextBox()
        Me.pnlrecievebank = New System.Windows.Forms.Panel()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.pnlCheque = New System.Windows.Forms.Panel()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.txtChequeDt = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.dtpChequeDt = New System.Windows.Forms.DateTimePicker()
        Me.txtChequeNo = New System.Windows.Forms.TextBox()
        Me.txtChequeBank = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.CmbCompanyBank = New System.Windows.Forms.ComboBox()
        Me.cmbAccName = New System.Windows.Forms.ComboBox()
        Me.cmbPayType = New System.Windows.Forms.ComboBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.rbtWholesum = New System.Windows.Forms.RadioButton()
        Me.rbtBill2Bill = New System.Windows.Forms.RadioButton()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.txtAmount = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtClientName = New System.Windows.Forms.TextBox()
        Me.txtDate = New System.Windows.Forms.TextBox()
        Me.dtpDate = New System.Windows.Forms.DateTimePicker()
        Me.txtVouNo = New System.Windows.Forms.TextBox()
        Me.Panel1.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.pnlBills.SuspendLayout()
        CType(Me.gridBills, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridVoucher, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel4.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.pnlrecievebank.SuspendLayout()
        Me.pnlCheque.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.AutoScroll = True
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Controls.Add(Me.lblcuscode)
        Me.Panel1.Controls.Add(Me.Panel5)
        Me.Panel1.Controls.Add(Me.pnlBills)
        Me.Panel1.Controls.Add(Me.gridVoucher)
        Me.Panel1.Controls.Add(Me.Panel4)
        Me.Panel1.Controls.Add(Me.Label12)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.txtSearchKeyword)
        Me.Panel1.Controls.Add(Me.Label14)
        Me.Panel1.Controls.Add(Me.Label11)
        Me.Panel1.Controls.Add(Me.Panel3)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(743, 750)
        Me.Panel1.TabIndex = 5
        '
        'lblcuscode
        '
        Me.lblcuscode.AutoSize = True
        Me.lblcuscode.Location = New System.Drawing.Point(188, 9)
        Me.lblcuscode.Name = "lblcuscode"
        Me.lblcuscode.Size = New System.Drawing.Size(59, 17)
        Me.lblcuscode.TabIndex = 11
        Me.lblcuscode.Text = "Label33"
        Me.lblcuscode.Visible = False
        '
        'Panel5
        '
        Me.Panel5.Controls.Add(Me.txtSearchtodt)
        Me.Panel5.Controls.Add(Me.txtSearchfromdt)
        Me.Panel5.Controls.Add(Me.Label20)
        Me.Panel5.Controls.Add(Me.Label21)
        Me.Panel5.Controls.Add(Me.dtpSearchfromdt)
        Me.Panel5.Controls.Add(Me.dtpSearchtodt)
        Me.Panel5.Location = New System.Drawing.Point(550, 402)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(133, 86)
        Me.Panel5.TabIndex = 10
        '
        'txtSearchtodt
        '
        Me.txtSearchtodt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSearchtodt.Location = New System.Drawing.Point(3, 59)
        Me.txtSearchtodt.Name = "txtSearchtodt"
        Me.txtSearchtodt.ReadOnly = True
        Me.txtSearchtodt.Size = New System.Drawing.Size(106, 23)
        Me.txtSearchtodt.TabIndex = 2
        '
        'txtSearchfromdt
        '
        Me.txtSearchfromdt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSearchfromdt.Location = New System.Drawing.Point(3, 18)
        Me.txtSearchfromdt.Name = "txtSearchfromdt"
        Me.txtSearchfromdt.ReadOnly = True
        Me.txtSearchfromdt.Size = New System.Drawing.Size(106, 23)
        Me.txtSearchfromdt.TabIndex = 2
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.ForeColor = System.Drawing.Color.FromArgb(CType(CType(53, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(147, Byte), Integer))
        Me.Label20.Location = New System.Drawing.Point(3, 46)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(20, 13)
        Me.Label20.TabIndex = 1
        Me.Label20.Text = "To"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.ForeColor = System.Drawing.Color.FromArgb(CType(CType(53, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(147, Byte), Integer))
        Me.Label21.Location = New System.Drawing.Point(3, 4)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(30, 13)
        Me.Label21.TabIndex = 1
        Me.Label21.Text = "From"
        '
        'dtpSearchfromdt
        '
        Me.dtpSearchfromdt.Location = New System.Drawing.Point(107, 18)
        Me.dtpSearchfromdt.Name = "dtpSearchfromdt"
        Me.dtpSearchfromdt.Size = New System.Drawing.Size(16, 23)
        Me.dtpSearchfromdt.TabIndex = 3
        '
        'dtpSearchtodt
        '
        Me.dtpSearchtodt.Location = New System.Drawing.Point(107, 59)
        Me.dtpSearchtodt.Name = "dtpSearchtodt"
        Me.dtpSearchtodt.Size = New System.Drawing.Size(16, 23)
        Me.dtpSearchtodt.TabIndex = 3
        '
        'pnlBills
        '
        Me.pnlBills.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlBills.AutoScroll = True
        Me.pnlBills.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.pnlBills.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlBills.Controls.Add(Me.dtpTodt)
        Me.pnlBills.Controls.Add(Me.dtpFromdt)
        Me.pnlBills.Controls.Add(Me.gridBills)
        Me.pnlBills.Controls.Add(Me.Label6)
        Me.pnlBills.Controls.Add(Me.Label9)
        Me.pnlBills.Controls.Add(Me.Label8)
        Me.pnlBills.Controls.Add(Me.txtToDt)
        Me.pnlBills.Controls.Add(Me.txtFromDt)
        Me.pnlBills.Controls.Add(Me.btnList)
        Me.pnlBills.Location = New System.Drawing.Point(383, 38)
        Me.pnlBills.Name = "pnlBills"
        Me.pnlBills.Size = New System.Drawing.Size(348, 354)
        Me.pnlBills.TabIndex = 8
        '
        'dtpTodt
        '
        Me.dtpTodt.Location = New System.Drawing.Point(261, 32)
        Me.dtpTodt.Name = "dtpTodt"
        Me.dtpTodt.Size = New System.Drawing.Size(20, 23)
        Me.dtpTodt.TabIndex = 1
        '
        'dtpFromdt
        '
        Me.dtpFromdt.Location = New System.Drawing.Point(123, 33)
        Me.dtpFromdt.Name = "dtpFromdt"
        Me.dtpFromdt.Size = New System.Drawing.Size(20, 23)
        Me.dtpFromdt.TabIndex = 0
        '
        'gridBills
        '
        Me.gridBills.AllowUserToAddRows = False
        Me.gridBills.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.gridBills.BackgroundColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.gridBills.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gridBills.Location = New System.Drawing.Point(7, 60)
        Me.gridBills.Name = "gridBills"
        Me.gridBills.RowHeadersVisible = False
        Me.gridBills.Size = New System.Drawing.Size(333, 284)
        Me.gridBills.TabIndex = 2
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(53, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(147, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(120, 4)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(120, 16)
        Me.Label6.TabIndex = 1
        Me.Label6.Text = "Raised Invoices"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(53, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(147, Byte), Integer))
        Me.Label9.Location = New System.Drawing.Point(149, 37)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(20, 13)
        Me.Label9.TabIndex = 1
        Me.Label9.Text = "To"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(53, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(147, Byte), Integer))
        Me.Label8.Location = New System.Drawing.Point(5, 39)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(30, 13)
        Me.Label8.TabIndex = 1
        Me.Label8.Text = "From"
        '
        'txtToDt
        '
        Me.txtToDt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtToDt.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtToDt.Location = New System.Drawing.Point(175, 32)
        Me.txtToDt.Name = "txtToDt"
        Me.txtToDt.ReadOnly = True
        Me.txtToDt.Size = New System.Drawing.Size(86, 23)
        Me.txtToDt.TabIndex = 2
        '
        'txtFromDt
        '
        Me.txtFromDt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFromDt.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFromDt.Location = New System.Drawing.Point(37, 33)
        Me.txtFromDt.Name = "txtFromDt"
        Me.txtFromDt.ReadOnly = True
        Me.txtFromDt.Size = New System.Drawing.Size(86, 23)
        Me.txtFromDt.TabIndex = 2
        '
        'btnList
        '
        Me.btnList.BackColor = System.Drawing.Color.FromArgb(CType(CType(92, Byte), Integer), CType(CType(184, Byte), Integer), CType(CType(92, Byte), Integer))
        Me.btnList.FlatAppearance.BorderSize = 0
        Me.btnList.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnList.ForeColor = System.Drawing.Color.White
        Me.btnList.Location = New System.Drawing.Point(285, 31)
        Me.btnList.Name = "btnList"
        Me.btnList.Size = New System.Drawing.Size(50, 24)
        Me.btnList.TabIndex = 2
        Me.btnList.Text = "List"
        Me.btnList.UseVisualStyleBackColor = False
        '
        'gridVoucher
        '
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSkyBlue
        Me.gridVoucher.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.gridVoucher.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gridVoucher.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.gridVoucher.BackgroundColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.gridVoucher.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gridVoucher.Location = New System.Drawing.Point(12, 494)
        Me.gridVoucher.Name = "gridVoucher"
        Me.gridVoucher.RowHeadersVisible = False
        Me.gridVoucher.Size = New System.Drawing.Size(719, 246)
        Me.gridVoucher.TabIndex = 7
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.rdnvouno)
        Me.Panel4.Controls.Add(Me.rbtDate)
        Me.Panel4.Controls.Add(Me.rbtName)
        Me.Panel4.Location = New System.Drawing.Point(355, 460)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(170, 28)
        Me.Panel4.TabIndex = 6
        '
        'rdnvouno
        '
        Me.rdnvouno.AutoSize = True
        Me.rdnvouno.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdnvouno.ForeColor = System.Drawing.Color.FromArgb(CType(CType(53, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(147, Byte), Integer))
        Me.rdnvouno.Location = New System.Drawing.Point(109, 3)
        Me.rdnvouno.Name = "rdnvouno"
        Me.rdnvouno.Size = New System.Drawing.Size(61, 17)
        Me.rdnvouno.TabIndex = 2
        Me.rdnvouno.Text = "Vch No"
        Me.rdnvouno.UseVisualStyleBackColor = True
        '
        'rbtDate
        '
        Me.rbtDate.AutoSize = True
        Me.rbtDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbtDate.ForeColor = System.Drawing.Color.FromArgb(CType(CType(53, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(147, Byte), Integer))
        Me.rbtDate.Location = New System.Drawing.Point(61, 3)
        Me.rbtDate.Name = "rbtDate"
        Me.rbtDate.Size = New System.Drawing.Size(48, 17)
        Me.rbtDate.TabIndex = 1
        Me.rbtDate.Text = "Date"
        Me.rbtDate.UseVisualStyleBackColor = True
        '
        'rbtName
        '
        Me.rbtName.AutoSize = True
        Me.rbtName.Checked = True
        Me.rbtName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbtName.ForeColor = System.Drawing.Color.FromArgb(CType(CType(53, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(147, Byte), Integer))
        Me.rbtName.Location = New System.Drawing.Point(8, 3)
        Me.rbtName.Name = "rbtName"
        Me.rbtName.Size = New System.Drawing.Size(53, 17)
        Me.rbtName.TabIndex = 0
        Me.rbtName.TabStop = True
        Me.rbtName.Text = "Name"
        Me.rbtName.UseVisualStyleBackColor = True
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Arial Narrow", 11.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.FromArgb(CType(CType(53, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(147, Byte), Integer))
        Me.Label12.Location = New System.Drawing.Point(324, 419)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(153, 20)
        Me.Label12.TabIndex = 0
        Me.Label12.Text = "Search Voucher Reciept"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial Narrow", 11.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(53, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(147, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(321, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(108, 20)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Voucher Reciept"
        '
        'txtSearchKeyword
        '
        Me.txtSearchKeyword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSearchKeyword.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSearchKeyword.Location = New System.Drawing.Point(96, 463)
        Me.txtSearchKeyword.Name = "txtSearchKeyword"
        Me.txtSearchKeyword.Size = New System.Drawing.Size(188, 23)
        Me.txtSearchKeyword.TabIndex = 0
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.ForeColor = System.Drawing.Color.FromArgb(CType(CType(53, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(147, Byte), Integer))
        Me.Label14.Location = New System.Drawing.Point(288, 465)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(61, 17)
        Me.Label14.TabIndex = 1
        Me.Label14.Text = "Criteria :"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.ForeColor = System.Drawing.Color.FromArgb(CType(CType(53, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(147, Byte), Integer))
        Me.Label11.Location = New System.Drawing.Point(29, 466)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(62, 17)
        Me.Label11.TabIndex = 1
        Me.Label11.Text = "Keyword"
        '
        'Panel3
        '
        Me.Panel3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.lstClientName)
        Me.Panel3.Controls.Add(Me.cmbAcctype)
        Me.Panel3.Controls.Add(Me.Label33)
        Me.Panel3.Controls.Add(Me.Label28)
        Me.Panel3.Controls.Add(Me.Label34)
        Me.Panel3.Controls.Add(Me.Label27)
        Me.Panel3.Controls.Add(Me.Label26)
        Me.Panel3.Controls.Add(Me.Label25)
        Me.Panel3.Controls.Add(Me.Label24)
        Me.Panel3.Controls.Add(Me.Label23)
        Me.Panel3.Controls.Add(Me.txtNotes)
        Me.Panel3.Controls.Add(Me.pnlrecievebank)
        Me.Panel3.Controls.Add(Me.cmbAccName)
        Me.Panel3.Controls.Add(Me.cmbPayType)
        Me.Panel3.Controls.Add(Me.Panel2)
        Me.Panel3.Controls.Add(Me.btnClear)
        Me.Panel3.Controls.Add(Me.btnSave)
        Me.Panel3.Controls.Add(Me.Label2)
        Me.Panel3.Controls.Add(Me.Label3)
        Me.Panel3.Controls.Add(Me.Label18)
        Me.Panel3.Controls.Add(Me.txtAmount)
        Me.Panel3.Controls.Add(Me.Label5)
        Me.Panel3.Controls.Add(Me.Label13)
        Me.Panel3.Controls.Add(Me.Label4)
        Me.Panel3.Controls.Add(Me.Label22)
        Me.Panel3.Controls.Add(Me.Label7)
        Me.Panel3.Controls.Add(Me.txtClientName)
        Me.Panel3.Controls.Add(Me.txtDate)
        Me.Panel3.Controls.Add(Me.dtpDate)
        Me.Panel3.Controls.Add(Me.txtVouNo)
        Me.Panel3.Location = New System.Drawing.Point(14, 38)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(359, 356)
        Me.Panel3.TabIndex = 5
        '
        'lstClientName
        '
        Me.lstClientName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lstClientName.FormattingEnabled = True
        Me.lstClientName.ItemHeight = 16
        Me.lstClientName.Location = New System.Drawing.Point(145, 22)
        Me.lstClientName.Name = "lstClientName"
        Me.lstClientName.Size = New System.Drawing.Size(187, 116)
        Me.lstClientName.TabIndex = 10
        '
        'cmbAcctype
        '
        Me.cmbAcctype.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbAcctype.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbAcctype.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbAcctype.FormattingEnabled = True
        Me.cmbAcctype.Location = New System.Drawing.Point(144, 112)
        Me.cmbAcctype.Name = "cmbAcctype"
        Me.cmbAcctype.Size = New System.Drawing.Size(188, 21)
        Me.cmbAcctype.TabIndex = 3
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label33.ForeColor = System.Drawing.Color.FromArgb(CType(CType(53, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(147, Byte), Integer))
        Me.Label33.Location = New System.Drawing.Point(14, 116)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(74, 13)
        Me.Label33.TabIndex = 45
        Me.Label33.Text = "Account Type"
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.BackColor = System.Drawing.Color.Transparent
        Me.Label28.Font = New System.Drawing.Font("Arial Rounded MT Bold", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label28.ForeColor = System.Drawing.Color.Red
        Me.Label28.Location = New System.Drawing.Point(82, 157)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(10, 12)
        Me.Label28.TabIndex = 8
        Me.Label28.Text = "*"
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.BackColor = System.Drawing.Color.Transparent
        Me.Label34.Font = New System.Drawing.Font("Arial Rounded MT Bold", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label34.ForeColor = System.Drawing.Color.Red
        Me.Label34.Location = New System.Drawing.Point(86, 114)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(10, 12)
        Me.Label34.TabIndex = 8
        Me.Label34.Text = "*"
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.BackColor = System.Drawing.Color.Transparent
        Me.Label27.Font = New System.Drawing.Font("Arial Rounded MT Bold", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.ForeColor = System.Drawing.Color.Red
        Me.Label27.Location = New System.Drawing.Point(55, 95)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(10, 12)
        Me.Label27.TabIndex = 8
        Me.Label27.Text = "*"
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.BackColor = System.Drawing.Color.Transparent
        Me.Label26.Font = New System.Drawing.Font("Arial Rounded MT Bold", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.ForeColor = System.Drawing.Color.Red
        Me.Label26.Location = New System.Drawing.Point(84, 71)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(10, 12)
        Me.Label26.TabIndex = 8
        Me.Label26.Text = "*"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.BackColor = System.Drawing.Color.Transparent
        Me.Label25.Font = New System.Drawing.Font("Arial Rounded MT Bold", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.ForeColor = System.Drawing.Color.Red
        Me.Label25.Location = New System.Drawing.Point(41, 50)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(10, 12)
        Me.Label25.TabIndex = 8
        Me.Label25.Text = "*"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.BackColor = System.Drawing.Color.Transparent
        Me.Label24.Font = New System.Drawing.Font("Arial Rounded MT Bold", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.ForeColor = System.Drawing.Color.Red
        Me.Label24.Location = New System.Drawing.Point(82, 25)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(10, 12)
        Me.Label24.TabIndex = 8
        Me.Label24.Text = "*"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.BackColor = System.Drawing.Color.Transparent
        Me.Label23.Font = New System.Drawing.Font("Arial Rounded MT Bold", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.ForeColor = System.Drawing.Color.Red
        Me.Label23.Location = New System.Drawing.Point(74, 3)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(10, 12)
        Me.Label23.TabIndex = 8
        Me.Label23.Text = "*"
        '
        'txtNotes
        '
        Me.txtNotes.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtNotes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNotes.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNotes.Location = New System.Drawing.Point(142, 285)
        Me.txtNotes.Name = "txtNotes"
        Me.txtNotes.Size = New System.Drawing.Size(188, 20)
        Me.txtNotes.TabIndex = 6
        '
        'pnlrecievebank
        '
        Me.pnlrecievebank.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlrecievebank.Controls.Add(Me.Label29)
        Me.pnlrecievebank.Controls.Add(Me.pnlCheque)
        Me.pnlrecievebank.Controls.Add(Me.Label19)
        Me.pnlrecievebank.Controls.Add(Me.CmbCompanyBank)
        Me.pnlrecievebank.Location = New System.Drawing.Point(7, 182)
        Me.pnlrecievebank.Name = "pnlrecievebank"
        Me.pnlrecievebank.Size = New System.Drawing.Size(330, 102)
        Me.pnlrecievebank.TabIndex = 9
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.BackColor = System.Drawing.Color.Transparent
        Me.Label29.Font = New System.Drawing.Font("Arial Rounded MT Bold", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label29.ForeColor = System.Drawing.Color.Red
        Me.Label29.Location = New System.Drawing.Point(87, 2)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(10, 12)
        Me.Label29.TabIndex = 8
        Me.Label29.Text = "*"
        '
        'pnlCheque
        '
        Me.pnlCheque.Controls.Add(Me.Label32)
        Me.pnlCheque.Controls.Add(Me.Label31)
        Me.pnlCheque.Controls.Add(Me.Label30)
        Me.pnlCheque.Controls.Add(Me.txtChequeDt)
        Me.pnlCheque.Controls.Add(Me.Label16)
        Me.pnlCheque.Controls.Add(Me.Label17)
        Me.pnlCheque.Controls.Add(Me.Label15)
        Me.pnlCheque.Controls.Add(Me.dtpChequeDt)
        Me.pnlCheque.Controls.Add(Me.txtChequeNo)
        Me.pnlCheque.Controls.Add(Me.txtChequeBank)
        Me.pnlCheque.Location = New System.Drawing.Point(3, 28)
        Me.pnlCheque.Name = "pnlCheque"
        Me.pnlCheque.Size = New System.Drawing.Size(330, 74)
        Me.pnlCheque.TabIndex = 9
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.BackColor = System.Drawing.Color.Transparent
        Me.Label32.Font = New System.Drawing.Font("Arial Rounded MT Bold", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label32.ForeColor = System.Drawing.Color.Red
        Me.Label32.Location = New System.Drawing.Point(72, 49)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(10, 12)
        Me.Label32.TabIndex = 8
        Me.Label32.Text = "*"
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.BackColor = System.Drawing.Color.Transparent
        Me.Label31.Font = New System.Drawing.Font("Arial Rounded MT Bold", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label31.ForeColor = System.Drawing.Color.Red
        Me.Label31.Location = New System.Drawing.Point(62, 28)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(10, 12)
        Me.Label31.TabIndex = 8
        Me.Label31.Text = "*"
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.BackColor = System.Drawing.Color.Transparent
        Me.Label30.Font = New System.Drawing.Font("Arial Rounded MT Bold", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label30.ForeColor = System.Drawing.Color.Red
        Me.Label30.Location = New System.Drawing.Point(73, 5)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(10, 12)
        Me.Label30.TabIndex = 8
        Me.Label30.Text = "*"
        '
        'txtChequeDt
        '
        Me.txtChequeDt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtChequeDt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtChequeDt.Location = New System.Drawing.Point(135, 49)
        Me.txtChequeDt.Name = "txtChequeDt"
        Me.txtChequeDt.ReadOnly = True
        Me.txtChequeDt.Size = New System.Drawing.Size(170, 20)
        Me.txtChequeDt.TabIndex = 2
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.FromArgb(CType(CType(53, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(147, Byte), Integer))
        Me.Label16.Location = New System.Drawing.Point(5, 29)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(61, 13)
        Me.Label16.TabIndex = 1
        Me.Label16.Text = "Cheque No"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.FromArgb(CType(CType(53, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(147, Byte), Integer))
        Me.Label17.Location = New System.Drawing.Point(5, 49)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(70, 13)
        Me.Label17.TabIndex = 1
        Me.Label17.Text = "Cheque Date"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.FromArgb(CType(CType(53, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(147, Byte), Integer))
        Me.Label15.Location = New System.Drawing.Point(5, 7)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(72, 13)
        Me.Label15.TabIndex = 1
        Me.Label15.Text = "Drawee Bank"
        '
        'dtpChequeDt
        '
        Me.dtpChequeDt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpChequeDt.Location = New System.Drawing.Point(303, 49)
        Me.dtpChequeDt.Name = "dtpChequeDt"
        Me.dtpChequeDt.Size = New System.Drawing.Size(20, 20)
        Me.dtpChequeDt.TabIndex = 3
        '
        'txtChequeNo
        '
        Me.txtChequeNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtChequeNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtChequeNo.Location = New System.Drawing.Point(135, 26)
        Me.txtChequeNo.Name = "txtChequeNo"
        Me.txtChequeNo.Size = New System.Drawing.Size(188, 20)
        Me.txtChequeNo.TabIndex = 1
        '
        'txtChequeBank
        '
        Me.txtChequeBank.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtChequeBank.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtChequeBank.Location = New System.Drawing.Point(135, 3)
        Me.txtChequeBank.Name = "txtChequeBank"
        Me.txtChequeBank.Size = New System.Drawing.Size(188, 20)
        Me.txtChequeBank.TabIndex = 0
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.ForeColor = System.Drawing.Color.FromArgb(CType(CType(53, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(147, Byte), Integer))
        Me.Label19.Location = New System.Drawing.Point(8, 5)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(83, 13)
        Me.Label19.TabIndex = 1
        Me.Label19.Text = "Recieving Bank"
        '
        'CmbCompanyBank
        '
        Me.CmbCompanyBank.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbCompanyBank.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmbCompanyBank.FormattingEnabled = True
        Me.CmbCompanyBank.Location = New System.Drawing.Point(138, 3)
        Me.CmbCompanyBank.Name = "CmbCompanyBank"
        Me.CmbCompanyBank.Size = New System.Drawing.Size(189, 21)
        Me.CmbCompanyBank.TabIndex = 0
        '
        'cmbAccName
        '
        Me.cmbAccName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbAccName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbAccName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbAccName.FormattingEnabled = True
        Me.cmbAccName.Location = New System.Drawing.Point(143, 135)
        Me.cmbAccName.Name = "cmbAccName"
        Me.cmbAccName.Size = New System.Drawing.Size(189, 21)
        Me.cmbAccName.TabIndex = 4
        '
        'cmbPayType
        '
        Me.cmbPayType.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbPayType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPayType.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbPayType.FormattingEnabled = True
        Me.cmbPayType.Items.AddRange(New Object() {"Cash", "Cheque"})
        Me.cmbPayType.Location = New System.Drawing.Point(143, 158)
        Me.cmbPayType.Name = "cmbPayType"
        Me.cmbPayType.Size = New System.Drawing.Size(189, 21)
        Me.cmbPayType.TabIndex = 5
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel2.Controls.Add(Me.rbtWholesum)
        Me.Panel2.Controls.Add(Me.rbtBill2Bill)
        Me.Panel2.Location = New System.Drawing.Point(144, 70)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(189, 19)
        Me.Panel2.TabIndex = 7
        '
        'rbtWholesum
        '
        Me.rbtWholesum.AutoSize = True
        Me.rbtWholesum.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbtWholesum.Location = New System.Drawing.Point(100, 0)
        Me.rbtWholesum.Name = "rbtWholesum"
        Me.rbtWholesum.Size = New System.Drawing.Size(82, 17)
        Me.rbtWholesum.TabIndex = 1
        Me.rbtWholesum.Text = "On Account"
        Me.rbtWholesum.UseVisualStyleBackColor = True
        '
        'rbtBill2Bill
        '
        Me.rbtBill2Bill.AutoSize = True
        Me.rbtBill2Bill.Checked = True
        Me.rbtBill2Bill.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbtBill2Bill.Location = New System.Drawing.Point(8, 0)
        Me.rbtBill2Bill.Name = "rbtBill2Bill"
        Me.rbtBill2Bill.Size = New System.Drawing.Size(65, 17)
        Me.rbtBill2Bill.TabIndex = 0
        Me.rbtBill2Bill.TabStop = True
        Me.rbtBill2Bill.Text = "Invoices"
        Me.rbtBill2Bill.UseVisualStyleBackColor = True
        '
        'btnClear
        '
        Me.btnClear.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnClear.FlatAppearance.BorderSize = 0
        Me.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClear.ForeColor = System.Drawing.Color.Black
        Me.btnClear.Location = New System.Drawing.Point(231, 319)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(75, 25)
        Me.btnClear.TabIndex = 8
        Me.btnClear.Text = "Clear"
        Me.btnClear.UseVisualStyleBackColor = False
        '
        'btnSave
        '
        Me.btnSave.BackColor = System.Drawing.Color.FromArgb(CType(CType(92, Byte), Integer), CType(CType(184, Byte), Integer), CType(CType(92, Byte), Integer))
        Me.btnSave.FlatAppearance.BorderSize = 0
        Me.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSave.ForeColor = System.Drawing.Color.White
        Me.btnSave.Location = New System.Drawing.Point(150, 319)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(75, 24)
        Me.btnSave.TabIndex = 7
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(53, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(147, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(14, 5)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(64, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Client Name"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(53, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(147, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(14, 51)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(30, 13)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "Date"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.FromArgb(CType(CType(53, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(147, Byte), Integer))
        Me.Label18.Location = New System.Drawing.Point(14, 28)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(71, 13)
        Me.Label18.TabIndex = 1
        Me.Label18.Text = "Voucher No#"
        '
        'txtAmount
        '
        Me.txtAmount.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAmount.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAmount.Location = New System.Drawing.Point(144, 90)
        Me.txtAmount.Name = "txtAmount"
        Me.txtAmount.Size = New System.Drawing.Size(188, 20)
        Me.txtAmount.TabIndex = 2
        Me.txtAmount.Text = "0.00"
        Me.txtAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(53, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(147, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(14, 159)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(75, 13)
        Me.Label5.TabIndex = 1
        Me.Label5.Text = "Payment Type"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.FromArgb(CType(CType(53, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(147, Byte), Integer))
        Me.Label13.Location = New System.Drawing.Point(14, 138)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(78, 13)
        Me.Label13.TabIndex = 1
        Me.Label13.Text = "Account Name"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(53, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(147, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(14, 96)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(43, 13)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "Amount"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.ForeColor = System.Drawing.Color.FromArgb(CType(CType(53, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(147, Byte), Integer))
        Me.Label22.Location = New System.Drawing.Point(14, 287)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(50, 13)
        Me.Label22.TabIndex = 1
        Me.Label22.Text = "Narration"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(53, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(147, Byte), Integer))
        Me.Label7.Location = New System.Drawing.Point(14, 73)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(74, 13)
        Me.Label7.TabIndex = 1
        Me.Label7.Text = "Voucher Type"
        '
        'txtClientName
        '
        Me.txtClientName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtClientName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtClientName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtClientName.Location = New System.Drawing.Point(144, 2)
        Me.txtClientName.Name = "txtClientName"
        Me.txtClientName.Size = New System.Drawing.Size(188, 20)
        Me.txtClientName.TabIndex = 0
        '
        'txtDate
        '
        Me.txtDate.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDate.Location = New System.Drawing.Point(144, 45)
        Me.txtDate.Name = "txtDate"
        Me.txtDate.ReadOnly = True
        Me.txtDate.Size = New System.Drawing.Size(175, 20)
        Me.txtDate.TabIndex = 2
        '
        'dtpDate
        '
        Me.dtpDate.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtpDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpDate.Location = New System.Drawing.Point(313, 45)
        Me.dtpDate.Name = "dtpDate"
        Me.dtpDate.Size = New System.Drawing.Size(20, 20)
        Me.dtpDate.TabIndex = 1
        '
        'txtVouNo
        '
        Me.txtVouNo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtVouNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtVouNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtVouNo.Location = New System.Drawing.Point(144, 24)
        Me.txtVouNo.Name = "txtVouNo"
        Me.txtVouNo.Size = New System.Drawing.Size(188, 20)
        Me.txtVouNo.TabIndex = 2
        '
        'VoucherReciepts
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(743, 750)
        Me.Controls.Add(Me.Panel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "VoucherReciepts"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Voucher Reciepts"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        Me.pnlBills.ResumeLayout(False)
        Me.pnlBills.PerformLayout()
        CType(Me.gridBills, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gridVoucher, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.pnlrecievebank.ResumeLayout(False)
        Me.pnlrecievebank.PerformLayout()
        Me.pnlCheque.ResumeLayout(False)
        Me.pnlCheque.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents gridVoucher As System.Windows.Forms.DataGridView
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents rbtDate As System.Windows.Forms.RadioButton
    Friend WithEvents rbtName As System.Windows.Forms.RadioButton
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents btnClear As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents txtVouNo As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtClientName As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtSearchKeyword As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtDate As System.Windows.Forms.TextBox
    Friend WithEvents dtpDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents rbtWholesum As System.Windows.Forms.RadioButton
    Friend WithEvents rbtBill2Bill As System.Windows.Forms.RadioButton
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtAmount As System.Windows.Forms.TextBox
    Friend WithEvents cmbPayType As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents pnlBills As System.Windows.Forms.Panel
    Friend WithEvents gridBills As System.Windows.Forms.DataGridView
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents dtpTodt As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpFromdt As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtToDt As System.Windows.Forms.TextBox
    Friend WithEvents txtFromDt As System.Windows.Forms.TextBox
    Friend WithEvents pnlrecievebank As System.Windows.Forms.Panel
    Friend WithEvents pnlCheque As System.Windows.Forms.Panel
    Friend WithEvents txtChequeDt As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents dtpChequeDt As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtChequeNo As System.Windows.Forms.TextBox
    Friend WithEvents txtChequeBank As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents CmbCompanyBank As System.Windows.Forms.ComboBox
    Friend WithEvents cmbAccName As System.Windows.Forms.ComboBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents btnList As System.Windows.Forms.Button
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents dtpSearchtodt As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpSearchfromdt As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtSearchtodt As System.Windows.Forms.TextBox
    Friend WithEvents txtSearchfromdt As System.Windows.Forms.TextBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents lstClientName As System.Windows.Forms.ListBox
    Friend WithEvents txtNotes As System.Windows.Forms.TextBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents lblcuscode As System.Windows.Forms.Label
    Friend WithEvents cmbAcctype As System.Windows.Forms.ComboBox
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents rdnvouno As System.Windows.Forms.RadioButton
End Class
