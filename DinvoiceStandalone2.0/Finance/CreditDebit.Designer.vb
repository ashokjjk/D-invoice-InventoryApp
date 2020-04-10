<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CreditDebit
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CreditDebit))
        Me.lstClientName = New System.Windows.Forms.ListBox()
        Me.cmbAcctype = New System.Windows.Forms.ComboBox()
        Me.txtNotes = New System.Windows.Forms.TextBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblcuscode = New System.Windows.Forms.Label()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.dtpSearchtodt = New System.Windows.Forms.DateTimePicker()
        Me.dtpSearchfromdt = New System.Windows.Forms.DateTimePicker()
        Me.txtSearchtodt = New System.Windows.Forms.TextBox()
        Me.txtSearchfromdt = New System.Windows.Forms.TextBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.gridVoucher = New System.Windows.Forms.DataGridView()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.rbtDate = New System.Windows.Forms.RadioButton()
        Me.rbtName = New System.Windows.Forms.RadioButton()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtSearchKeyword = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.lblcode = New System.Windows.Forms.Label()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.lstbxInvNo = New System.Windows.Forms.ListBox()
        Me.cmbReason = New System.Windows.Forms.ComboBox()
        Me.txtCess = New System.Windows.Forms.TextBox()
        Me.txtTaxableValue = New System.Windows.Forms.TextBox()
        Me.txtTaxRate = New System.Windows.Forms.TextBox()
        Me.txtPlaceofSupply = New System.Windows.Forms.TextBox()
        Me.txtInvno = New System.Windows.Forms.TextBox()
        Me.cmbVouType = New System.Windows.Forms.ComboBox()
        Me.cmbAccName = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.txtRefundValue = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtClientName = New System.Windows.Forms.TextBox()
        Me.txtinvdate = New System.Windows.Forms.TextBox()
        Me.txtDate = New System.Windows.Forms.TextBox()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.dtpDate = New System.Windows.Forms.DateTimePicker()
        Me.txtVouNo = New System.Windows.Forms.TextBox()
        Me.Panel1.SuspendLayout()
        Me.Panel5.SuspendLayout()
        CType(Me.gridVoucher, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel4.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'lstClientName
        '
        Me.lstClientName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lstClientName.FormattingEnabled = True
        Me.lstClientName.ItemHeight = 16
        Me.lstClientName.Location = New System.Drawing.Point(145, 27)
        Me.lstClientName.Name = "lstClientName"
        Me.lstClientName.Size = New System.Drawing.Size(187, 116)
        Me.lstClientName.TabIndex = 10
        '
        'cmbAcctype
        '
        Me.cmbAcctype.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbAcctype.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbAcctype.FormattingEnabled = True
        Me.cmbAcctype.Location = New System.Drawing.Point(143, 153)
        Me.cmbAcctype.Name = "cmbAcctype"
        Me.cmbAcctype.Size = New System.Drawing.Size(189, 24)
        Me.cmbAcctype.TabIndex = 4
        '
        'txtNotes
        '
        Me.txtNotes.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtNotes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNotes.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNotes.Location = New System.Drawing.Point(143, 210)
        Me.txtNotes.Multiline = True
        Me.txtNotes.Name = "txtNotes"
        Me.txtNotes.Size = New System.Drawing.Size(189, 46)
        Me.txtNotes.TabIndex = 6
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.ForeColor = System.Drawing.Color.FromArgb(CType(CType(53, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(147, Byte), Integer))
        Me.Label22.Location = New System.Drawing.Point(12, 219)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(45, 17)
        Me.Label22.TabIndex = 11
        Me.Label22.Text = "Notes"
        '
        'btnClear
        '
        Me.btnClear.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnClear.FlatAppearance.BorderSize = 0
        Me.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClear.ForeColor = System.Drawing.Color.Black
        Me.btnClear.Location = New System.Drawing.Point(586, 219)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(75, 25)
        Me.btnClear.TabIndex = 15
        Me.btnClear.Text = "Clear"
        Me.btnClear.UseVisualStyleBackColor = False
        '
        'btnSave
        '
        Me.btnSave.BackColor = System.Drawing.Color.FromArgb(CType(CType(92, Byte), Integer), CType(CType(184, Byte), Integer), CType(CType(92, Byte), Integer))
        Me.btnSave.FlatAppearance.BorderSize = 0
        Me.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSave.ForeColor = System.Drawing.Color.White
        Me.btnSave.Location = New System.Drawing.Point(505, 219)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(75, 24)
        Me.btnSave.TabIndex = 14
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(53, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(147, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(13, 7)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(84, 17)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Client Name"
        '
        'Panel1
        '
        Me.Panel1.AutoScroll = True
        Me.Panel1.AutoSize = True
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Controls.Add(Me.lblcuscode)
        Me.Panel1.Controls.Add(Me.Panel5)
        Me.Panel1.Controls.Add(Me.gridVoucher)
        Me.Panel1.Controls.Add(Me.Panel4)
        Me.Panel1.Controls.Add(Me.btnSearch)
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
        Me.Panel1.Size = New System.Drawing.Size(752, 750)
        Me.Panel1.TabIndex = 7
        '
        'lblcuscode
        '
        Me.lblcuscode.AutoSize = True
        Me.lblcuscode.Location = New System.Drawing.Point(223, 19)
        Me.lblcuscode.Name = "lblcuscode"
        Me.lblcuscode.Size = New System.Drawing.Size(59, 17)
        Me.lblcuscode.TabIndex = 11
        Me.lblcuscode.Text = "Label33"
        Me.lblcuscode.Visible = False
        '
        'Panel5
        '
        Me.Panel5.Controls.Add(Me.dtpSearchtodt)
        Me.Panel5.Controls.Add(Me.dtpSearchfromdt)
        Me.Panel5.Controls.Add(Me.txtSearchtodt)
        Me.Panel5.Controls.Add(Me.txtSearchfromdt)
        Me.Panel5.Controls.Add(Me.Label20)
        Me.Panel5.Controls.Add(Me.Label21)
        Me.Panel5.Location = New System.Drawing.Point(614, 323)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(101, 86)
        Me.Panel5.TabIndex = 10
        '
        'dtpSearchtodt
        '
        Me.dtpSearchtodt.Location = New System.Drawing.Point(79, 59)
        Me.dtpSearchtodt.Name = "dtpSearchtodt"
        Me.dtpSearchtodt.Size = New System.Drawing.Size(16, 23)
        Me.dtpSearchtodt.TabIndex = 3
        '
        'dtpSearchfromdt
        '
        Me.dtpSearchfromdt.Location = New System.Drawing.Point(79, 18)
        Me.dtpSearchfromdt.Name = "dtpSearchfromdt"
        Me.dtpSearchfromdt.Size = New System.Drawing.Size(16, 23)
        Me.dtpSearchfromdt.TabIndex = 3
        '
        'txtSearchtodt
        '
        Me.txtSearchtodt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSearchtodt.Location = New System.Drawing.Point(3, 59)
        Me.txtSearchtodt.Name = "txtSearchtodt"
        Me.txtSearchtodt.ReadOnly = True
        Me.txtSearchtodt.Size = New System.Drawing.Size(76, 23)
        Me.txtSearchtodt.TabIndex = 2
        '
        'txtSearchfromdt
        '
        Me.txtSearchfromdt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSearchfromdt.Location = New System.Drawing.Point(3, 18)
        Me.txtSearchfromdt.Name = "txtSearchfromdt"
        Me.txtSearchfromdt.ReadOnly = True
        Me.txtSearchfromdt.Size = New System.Drawing.Size(76, 23)
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
        'gridVoucher
        '
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSkyBlue
        Me.gridVoucher.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.gridVoucher.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gridVoucher.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.gridVoucher.BackgroundColor = System.Drawing.SystemColors.Info
        Me.gridVoucher.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gridVoucher.Location = New System.Drawing.Point(18, 429)
        Me.gridVoucher.Name = "gridVoucher"
        Me.gridVoucher.RowHeadersVisible = False
        Me.gridVoucher.Size = New System.Drawing.Size(715, 311)
        Me.gridVoucher.TabIndex = 7
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.rbtDate)
        Me.Panel4.Controls.Add(Me.rbtName)
        Me.Panel4.Location = New System.Drawing.Point(488, 385)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(123, 23)
        Me.Panel4.TabIndex = 6
        '
        'rbtDate
        '
        Me.rbtDate.AutoSize = True
        Me.rbtDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbtDate.ForeColor = System.Drawing.Color.FromArgb(CType(CType(53, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(147, Byte), Integer))
        Me.rbtDate.Location = New System.Drawing.Point(67, 3)
        Me.rbtDate.Name = "rbtDate"
        Me.rbtDate.Size = New System.Drawing.Size(48, 17)
        Me.rbtDate.TabIndex = 0
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
        'btnSearch
        '
        Me.btnSearch.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(109, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.btnSearch.FlatAppearance.BorderSize = 0
        Me.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSearch.ForeColor = System.Drawing.Color.White
        Me.btnSearch.Location = New System.Drawing.Point(349, 385)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(75, 23)
        Me.btnSearch.TabIndex = 5
        Me.btnSearch.Text = "Search"
        Me.btnSearch.UseVisualStyleBackColor = False
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Arial Narrow", 11.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.FromArgb(CType(CType(53, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(147, Byte), Integer))
        Me.Label12.Location = New System.Drawing.Point(320, 343)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(157, 20)
        Me.Label12.TabIndex = 0
        Me.Label12.Text = "Search Credit Debit Note"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial Narrow", 11.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(53, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(147, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(333, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(115, 20)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Credit/ Debit Note"
        '
        'txtSearchKeyword
        '
        Me.txtSearchKeyword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSearchKeyword.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSearchKeyword.Location = New System.Drawing.Point(154, 386)
        Me.txtSearchKeyword.Name = "txtSearchKeyword"
        Me.txtSearchKeyword.Size = New System.Drawing.Size(188, 23)
        Me.txtSearchKeyword.TabIndex = 0
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.ForeColor = System.Drawing.Color.FromArgb(CType(CType(53, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(147, Byte), Integer))
        Me.Label14.Location = New System.Drawing.Point(429, 388)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(61, 17)
        Me.Label14.TabIndex = 1
        Me.Label14.Text = "Criteria :"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.ForeColor = System.Drawing.Color.FromArgb(CType(CType(53, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(147, Byte), Integer))
        Me.Label11.Location = New System.Drawing.Point(87, 391)
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
        Me.Panel3.Controls.Add(Me.lblcode)
        Me.Panel3.Controls.Add(Me.Label32)
        Me.Panel3.Controls.Add(Me.Label31)
        Me.Panel3.Controls.Add(Me.Label30)
        Me.Panel3.Controls.Add(Me.Label29)
        Me.Panel3.Controls.Add(Me.Label28)
        Me.Panel3.Controls.Add(Me.Label27)
        Me.Panel3.Controls.Add(Me.Label26)
        Me.Panel3.Controls.Add(Me.Label25)
        Me.Panel3.Controls.Add(Me.Label19)
        Me.Panel3.Controls.Add(Me.Label17)
        Me.Panel3.Controls.Add(Me.Label16)
        Me.Panel3.Controls.Add(Me.Label10)
        Me.Panel3.Controls.Add(Me.lstbxInvNo)
        Me.Panel3.Controls.Add(Me.cmbReason)
        Me.Panel3.Controls.Add(Me.txtCess)
        Me.Panel3.Controls.Add(Me.txtTaxableValue)
        Me.Panel3.Controls.Add(Me.txtTaxRate)
        Me.Panel3.Controls.Add(Me.txtPlaceofSupply)
        Me.Panel3.Controls.Add(Me.txtInvno)
        Me.Panel3.Controls.Add(Me.txtNotes)
        Me.Panel3.Controls.Add(Me.Label22)
        Me.Panel3.Controls.Add(Me.lstClientName)
        Me.Panel3.Controls.Add(Me.cmbVouType)
        Me.Panel3.Controls.Add(Me.cmbAccName)
        Me.Panel3.Controls.Add(Me.cmbAcctype)
        Me.Panel3.Controls.Add(Me.btnClear)
        Me.Panel3.Controls.Add(Me.btnSave)
        Me.Panel3.Controls.Add(Me.Label2)
        Me.Panel3.Controls.Add(Me.Label5)
        Me.Panel3.Controls.Add(Me.Label3)
        Me.Panel3.Controls.Add(Me.Label18)
        Me.Panel3.Controls.Add(Me.Label33)
        Me.Panel3.Controls.Add(Me.txtRefundValue)
        Me.Panel3.Controls.Add(Me.Label13)
        Me.Panel3.Controls.Add(Me.Label24)
        Me.Panel3.Controls.Add(Me.Label23)
        Me.Panel3.Controls.Add(Me.Label15)
        Me.Panel3.Controls.Add(Me.Label9)
        Me.Panel3.Controls.Add(Me.Label8)
        Me.Panel3.Controls.Add(Me.Label6)
        Me.Panel3.Controls.Add(Me.Label4)
        Me.Panel3.Controls.Add(Me.Label7)
        Me.Panel3.Controls.Add(Me.txtClientName)
        Me.Panel3.Controls.Add(Me.txtinvdate)
        Me.Panel3.Controls.Add(Me.txtDate)
        Me.Panel3.Controls.Add(Me.DateTimePicker1)
        Me.Panel3.Controls.Add(Me.dtpDate)
        Me.Panel3.Controls.Add(Me.txtVouNo)
        Me.Panel3.Location = New System.Drawing.Point(14, 38)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(719, 279)
        Me.Panel3.TabIndex = 5
        '
        'lblcode
        '
        Me.lblcode.AutoSize = True
        Me.lblcode.Location = New System.Drawing.Point(369, 236)
        Me.lblcode.Name = "lblcode"
        Me.lblcode.Size = New System.Drawing.Size(59, 17)
        Me.lblcode.TabIndex = 14
        Me.lblcode.Text = "Label33"
        Me.lblcode.Visible = False
        '
        'Label32
        '
        Me.Label32.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label32.AutoSize = True
        Me.Label32.BackColor = System.Drawing.Color.Transparent
        Me.Label32.Font = New System.Drawing.Font("Arial Rounded MT Bold", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label32.ForeColor = System.Drawing.Color.Red
        Me.Label32.Location = New System.Drawing.Point(415, 188)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(10, 12)
        Me.Label32.TabIndex = 8
        Me.Label32.Text = "*"
        '
        'Label31
        '
        Me.Label31.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label31.AutoSize = True
        Me.Label31.BackColor = System.Drawing.Color.Transparent
        Me.Label31.Font = New System.Drawing.Font("Arial Rounded MT Bold", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label31.ForeColor = System.Drawing.Color.Red
        Me.Label31.Location = New System.Drawing.Point(438, 160)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(10, 12)
        Me.Label31.TabIndex = 8
        Me.Label31.Text = "*"
        '
        'Label30
        '
        Me.Label30.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label30.AutoSize = True
        Me.Label30.BackColor = System.Drawing.Color.Transparent
        Me.Label30.Font = New System.Drawing.Font("Arial Rounded MT Bold", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label30.ForeColor = System.Drawing.Color.Red
        Me.Label30.Location = New System.Drawing.Point(471, 126)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(10, 12)
        Me.Label30.TabIndex = 8
        Me.Label30.Text = "*"
        '
        'Label29
        '
        Me.Label29.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label29.AutoSize = True
        Me.Label29.BackColor = System.Drawing.Color.Transparent
        Me.Label29.Font = New System.Drawing.Font("Arial Rounded MT Bold", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label29.ForeColor = System.Drawing.Color.Red
        Me.Label29.Location = New System.Drawing.Point(476, 94)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(10, 12)
        Me.Label29.TabIndex = 8
        Me.Label29.Text = "*"
        '
        'Label28
        '
        Me.Label28.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label28.AutoSize = True
        Me.Label28.BackColor = System.Drawing.Color.Transparent
        Me.Label28.Font = New System.Drawing.Font("Arial Rounded MT Bold", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label28.ForeColor = System.Drawing.Color.Red
        Me.Label28.Location = New System.Drawing.Point(433, 69)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(10, 12)
        Me.Label28.TabIndex = 8
        Me.Label28.Text = "*"
        '
        'Label27
        '
        Me.Label27.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label27.AutoSize = True
        Me.Label27.BackColor = System.Drawing.Color.Transparent
        Me.Label27.Font = New System.Drawing.Font("Arial Rounded MT Bold", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.ForeColor = System.Drawing.Color.Red
        Me.Label27.Location = New System.Drawing.Point(460, 38)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(10, 12)
        Me.Label27.TabIndex = 8
        Me.Label27.Text = "*"
        '
        'Label26
        '
        Me.Label26.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label26.AutoSize = True
        Me.Label26.BackColor = System.Drawing.Color.Transparent
        Me.Label26.Font = New System.Drawing.Font("Arial Rounded MT Bold", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.ForeColor = System.Drawing.Color.Red
        Me.Label26.Location = New System.Drawing.Point(448, 6)
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
        Me.Label25.Location = New System.Drawing.Point(105, 129)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(10, 12)
        Me.Label25.TabIndex = 8
        Me.Label25.Text = "*"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.BackColor = System.Drawing.Color.Transparent
        Me.Label19.Font = New System.Drawing.Font("Arial Rounded MT Bold", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.ForeColor = System.Drawing.Color.Red
        Me.Label19.Location = New System.Drawing.Point(104, 97)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(10, 12)
        Me.Label19.TabIndex = 8
        Me.Label19.Text = "*"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.BackColor = System.Drawing.Color.Transparent
        Me.Label17.Font = New System.Drawing.Font("Arial Rounded MT Bold", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.Red
        Me.Label17.Location = New System.Drawing.Point(103, 66)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(10, 12)
        Me.Label17.TabIndex = 8
        Me.Label17.Text = "*"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Font = New System.Drawing.Font("Arial Rounded MT Bold", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.Red
        Me.Label16.Location = New System.Drawing.Point(99, 31)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(10, 12)
        Me.Label16.TabIndex = 8
        Me.Label16.Text = "*"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Arial Rounded MT Bold", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Red
        Me.Label10.Location = New System.Drawing.Point(94, 6)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(10, 12)
        Me.Label10.TabIndex = 8
        Me.Label10.Text = "*"
        '
        'lstbxInvNo
        '
        Me.lstbxInvNo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lstbxInvNo.FormattingEnabled = True
        Me.lstbxInvNo.ItemHeight = 16
        Me.lstbxInvNo.Location = New System.Drawing.Point(488, 28)
        Me.lstbxInvNo.Name = "lstbxInvNo"
        Me.lstbxInvNo.Size = New System.Drawing.Size(191, 116)
        Me.lstbxInvNo.TabIndex = 10
        '
        'cmbReason
        '
        Me.cmbReason.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbReason.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbReason.FormattingEnabled = True
        Me.cmbReason.Location = New System.Drawing.Point(489, 64)
        Me.cmbReason.Name = "cmbReason"
        Me.cmbReason.Size = New System.Drawing.Size(189, 24)
        Me.cmbReason.TabIndex = 9
        '
        'txtCess
        '
        Me.txtCess.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCess.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCess.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCess.Location = New System.Drawing.Point(489, 180)
        Me.txtCess.Name = "txtCess"
        Me.txtCess.Size = New System.Drawing.Size(189, 23)
        Me.txtCess.TabIndex = 13
        '
        'txtTaxableValue
        '
        Me.txtTaxableValue.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtTaxableValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTaxableValue.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTaxableValue.Location = New System.Drawing.Point(489, 124)
        Me.txtTaxableValue.Name = "txtTaxableValue"
        Me.txtTaxableValue.Size = New System.Drawing.Size(189, 23)
        Me.txtTaxableValue.TabIndex = 11
        '
        'txtTaxRate
        '
        Me.txtTaxRate.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtTaxRate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTaxRate.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTaxRate.Location = New System.Drawing.Point(489, 153)
        Me.txtTaxRate.Name = "txtTaxRate"
        Me.txtTaxRate.Size = New System.Drawing.Size(189, 23)
        Me.txtTaxRate.TabIndex = 12
        '
        'txtPlaceofSupply
        '
        Me.txtPlaceofSupply.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtPlaceofSupply.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPlaceofSupply.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPlaceofSupply.Location = New System.Drawing.Point(489, 94)
        Me.txtPlaceofSupply.Name = "txtPlaceofSupply"
        Me.txtPlaceofSupply.Size = New System.Drawing.Size(189, 23)
        Me.txtPlaceofSupply.TabIndex = 10
        '
        'txtInvno
        '
        Me.txtInvno.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtInvno.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtInvno.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtInvno.Location = New System.Drawing.Point(488, 5)
        Me.txtInvno.Name = "txtInvno"
        Me.txtInvno.Size = New System.Drawing.Size(191, 23)
        Me.txtInvno.TabIndex = 7
        '
        'cmbVouType
        '
        Me.cmbVouType.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbVouType.AutoCompleteCustomSource.AddRange(New String() {"Credit", "Debit"})
        Me.cmbVouType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbVouType.FormattingEnabled = True
        Me.cmbVouType.Items.AddRange(New Object() {"Credit", "Debit"})
        Me.cmbVouType.Location = New System.Drawing.Point(144, 92)
        Me.cmbVouType.Name = "cmbVouType"
        Me.cmbVouType.Size = New System.Drawing.Size(189, 24)
        Me.cmbVouType.TabIndex = 2
        '
        'cmbAccName
        '
        Me.cmbAccName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbAccName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbAccName.FormattingEnabled = True
        Me.cmbAccName.Location = New System.Drawing.Point(143, 182)
        Me.cmbAccName.Name = "cmbAccName"
        Me.cmbAccName.Size = New System.Drawing.Size(189, 24)
        Me.cmbAccName.TabIndex = 5
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(53, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(147, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(377, 39)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(86, 17)
        Me.Label5.TabIndex = 1
        Me.Label5.Text = "Invoice Date"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(53, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(147, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(13, 68)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(95, 17)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "Voucher Date"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.ForeColor = System.Drawing.Color.FromArgb(CType(CType(53, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(147, Byte), Integer))
        Me.Label18.Location = New System.Drawing.Point(12, 37)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(91, 17)
        Me.Label18.TabIndex = 1
        Me.Label18.Text = "Voucher No#"
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.ForeColor = System.Drawing.Color.FromArgb(CType(CType(53, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(147, Byte), Integer))
        Me.Label33.Location = New System.Drawing.Point(13, 182)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(100, 17)
        Me.Label33.TabIndex = 1
        Me.Label33.Text = "Account Name"
        '
        'txtRefundValue
        '
        Me.txtRefundValue.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtRefundValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtRefundValue.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRefundValue.Location = New System.Drawing.Point(144, 124)
        Me.txtRefundValue.Name = "txtRefundValue"
        Me.txtRefundValue.Size = New System.Drawing.Size(188, 23)
        Me.txtRefundValue.TabIndex = 3
        Me.txtRefundValue.Text = "0.0"
        Me.txtRefundValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.ForeColor = System.Drawing.Color.FromArgb(CType(CType(53, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(147, Byte), Integer))
        Me.Label13.Location = New System.Drawing.Point(13, 156)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(95, 17)
        Me.Label13.TabIndex = 1
        Me.Label13.Text = "Account Type"
        '
        'Label24
        '
        Me.Label24.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label24.AutoSize = True
        Me.Label24.ForeColor = System.Drawing.Color.FromArgb(CType(CType(53, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(147, Byte), Integer))
        Me.Label24.Location = New System.Drawing.Point(378, 187)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(39, 17)
        Me.Label24.TabIndex = 1
        Me.Label24.Text = "Cess"
        '
        'Label23
        '
        Me.Label23.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label23.AutoSize = True
        Me.Label23.ForeColor = System.Drawing.Color.FromArgb(CType(CType(53, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(147, Byte), Integer))
        Me.Label23.Location = New System.Drawing.Point(378, 126)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(98, 17)
        Me.Label23.TabIndex = 1
        Me.Label23.Text = "Taxable Value"
        '
        'Label15
        '
        Me.Label15.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label15.AutoSize = True
        Me.Label15.ForeColor = System.Drawing.Color.FromArgb(CType(CType(53, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(147, Byte), Integer))
        Me.Label15.Location = New System.Drawing.Point(378, 158)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(65, 17)
        Me.Label15.TabIndex = 1
        Me.Label15.Text = "Tax Rate"
        '
        'Label9
        '
        Me.Label9.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label9.AutoSize = True
        Me.Label9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(53, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(147, Byte), Integer))
        Me.Label9.Location = New System.Drawing.Point(378, 99)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(106, 17)
        Me.Label9.TabIndex = 1
        Me.Label9.Text = "Place of Supply"
        '
        'Label8
        '
        Me.Label8.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label8.AutoSize = True
        Me.Label8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(53, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(147, Byte), Integer))
        Me.Label8.Location = New System.Drawing.Point(378, 68)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(57, 17)
        Me.Label8.TabIndex = 1
        Me.Label8.Text = "Reason"
        '
        'Label6
        '
        Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(53, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(147, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(377, 7)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(74, 17)
        Me.Label6.TabIndex = 1
        Me.Label6.Text = "Invoice No"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(53, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(147, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(13, 128)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(94, 17)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "Refund Value"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(53, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(147, Byte), Integer))
        Me.Label7.Location = New System.Drawing.Point(12, 97)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(97, 17)
        Me.Label7.TabIndex = 1
        Me.Label7.Text = "Voucher Type"
        '
        'txtClientName
        '
        Me.txtClientName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtClientName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtClientName.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtClientName.Location = New System.Drawing.Point(144, 4)
        Me.txtClientName.Name = "txtClientName"
        Me.txtClientName.Size = New System.Drawing.Size(188, 23)
        Me.txtClientName.TabIndex = 0
        '
        'txtinvdate
        '
        Me.txtinvdate.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtinvdate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtinvdate.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtinvdate.Location = New System.Drawing.Point(488, 35)
        Me.txtinvdate.Name = "txtinvdate"
        Me.txtinvdate.ReadOnly = True
        Me.txtinvdate.Size = New System.Drawing.Size(173, 23)
        Me.txtinvdate.TabIndex = 2
        '
        'txtDate
        '
        Me.txtDate.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDate.Location = New System.Drawing.Point(144, 62)
        Me.txtDate.Name = "txtDate"
        Me.txtDate.ReadOnly = True
        Me.txtDate.Size = New System.Drawing.Size(175, 23)
        Me.txtDate.TabIndex = 2
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DateTimePicker1.Location = New System.Drawing.Point(662, 34)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(16, 23)
        Me.DateTimePicker1.TabIndex = 8
        '
        'dtpDate
        '
        Me.dtpDate.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtpDate.Location = New System.Drawing.Point(319, 62)
        Me.dtpDate.Name = "dtpDate"
        Me.dtpDate.Size = New System.Drawing.Size(14, 23)
        Me.dtpDate.TabIndex = 1
        '
        'txtVouNo
        '
        Me.txtVouNo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtVouNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtVouNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtVouNo.Location = New System.Drawing.Point(144, 33)
        Me.txtVouNo.Name = "txtVouNo"
        Me.txtVouNo.Size = New System.Drawing.Size(188, 23)
        Me.txtVouNo.TabIndex = 2
        '
        'CreditDebit
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.AutoSize = True
        Me.ClientSize = New System.Drawing.Size(752, 750)
        Me.Controls.Add(Me.Panel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "CreditDebit"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "CreditDebit"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        CType(Me.gridVoucher, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lstClientName As System.Windows.Forms.ListBox
    Friend WithEvents cmbAcctype As System.Windows.Forms.ComboBox
    Friend WithEvents txtNotes As System.Windows.Forms.TextBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents btnClear As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents dtpSearchtodt As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpSearchfromdt As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtSearchtodt As System.Windows.Forms.TextBox
    Friend WithEvents txtSearchfromdt As System.Windows.Forms.TextBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents gridVoucher As System.Windows.Forms.DataGridView
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents rbtDate As System.Windows.Forms.RadioButton
    Friend WithEvents rbtName As System.Windows.Forms.RadioButton
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtSearchKeyword As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents cmbReason As System.Windows.Forms.ComboBox
    Friend WithEvents lstbxInvNo As System.Windows.Forms.ListBox
    Friend WithEvents txtCess As System.Windows.Forms.TextBox
    Friend WithEvents txtTaxRate As System.Windows.Forms.TextBox
    Friend WithEvents txtPlaceofSupply As System.Windows.Forms.TextBox
    Friend WithEvents txtInvno As System.Windows.Forms.TextBox
    Friend WithEvents cmbVouType As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents txtRefundValue As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtClientName As System.Windows.Forms.TextBox
    Friend WithEvents txtDate As System.Windows.Forms.TextBox
    Friend WithEvents dtpDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtVouNo As System.Windows.Forms.TextBox
    Friend WithEvents txtTaxableValue As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtinvdate As System.Windows.Forms.TextBox
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents lblcuscode As System.Windows.Forms.Label
    Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblcode As System.Windows.Forms.Label
    Friend WithEvents cmbAccName As System.Windows.Forms.ComboBox
    Friend WithEvents Label33 As System.Windows.Forms.Label
End Class
