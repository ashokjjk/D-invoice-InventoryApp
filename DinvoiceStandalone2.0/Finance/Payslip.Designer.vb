<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Payslip
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Payslip))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label38 = New System.Windows.Forms.Label()
        Me.pnlBankdtls = New System.Windows.Forms.Panel()
        Me.Label39 = New System.Windows.Forms.Label()
        Me.cmbBankname = New System.Windows.Forms.ComboBox()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.txtChqdt = New System.Windows.Forms.TextBox()
        Me.txtChqno = New System.Windows.Forms.TextBox()
        Me.dtpChqDt = New System.Windows.Forms.DateTimePicker()
        Me.cmbPaymode = New System.Windows.Forms.ComboBox()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.griddata = New System.Windows.Forms.DataGridView()
        Me.cmbyear = New System.Windows.Forms.ComboBox()
        Me.cmbmonth = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Panelindgroup = New System.Windows.Forms.Panel()
        Me.cmbname = New System.Windows.Forms.ComboBox()
        Me.lblname = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.rbtnall = New System.Windows.Forms.RadioButton()
        Me.rbtnind = New System.Windows.Forms.RadioButton()
        Me.rbtngroup = New System.Windows.Forms.RadioButton()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.lbltotalsalary = New System.Windows.Forms.Label()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.pnlBankdtls.SuspendLayout()
        CType(Me.griddata, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panelindgroup.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.Panelindgroup)
        Me.Panel1.Controls.Add(Me.Label38)
        Me.Panel1.Controls.Add(Me.pnlBankdtls)
        Me.Panel1.Controls.Add(Me.cmbPaymode)
        Me.Panel1.Controls.Add(Me.Label28)
        Me.Panel1.Controls.Add(Me.griddata)
        Me.Panel1.Controls.Add(Me.cmbyear)
        Me.Panel1.Controls.Add(Me.cmbmonth)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Button1)
        Me.Panel1.Controls.Add(Me.Panel3)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 63)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(917, 560)
        Me.Panel1.TabIndex = 0
        '
        'Label38
        '
        Me.Label38.AutoSize = True
        Me.Label38.BackColor = System.Drawing.Color.Transparent
        Me.Label38.Font = New System.Drawing.Font("Arial Rounded MT Bold", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label38.ForeColor = System.Drawing.Color.Red
        Me.Label38.Location = New System.Drawing.Point(722, 9)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(10, 12)
        Me.Label38.TabIndex = 74
        Me.Label38.Text = "*"
        '
        'pnlBankdtls
        '
        Me.pnlBankdtls.Controls.Add(Me.Label39)
        Me.pnlBankdtls.Controls.Add(Me.cmbBankname)
        Me.pnlBankdtls.Controls.Add(Me.Label32)
        Me.pnlBankdtls.Controls.Add(Me.Label31)
        Me.pnlBankdtls.Controls.Add(Me.Label30)
        Me.pnlBankdtls.Controls.Add(Me.txtChqdt)
        Me.pnlBankdtls.Controls.Add(Me.txtChqno)
        Me.pnlBankdtls.Controls.Add(Me.dtpChqDt)
        Me.pnlBankdtls.Location = New System.Drawing.Point(615, 31)
        Me.pnlBankdtls.Name = "pnlBankdtls"
        Me.pnlBankdtls.Size = New System.Drawing.Size(279, 87)
        Me.pnlBankdtls.TabIndex = 72
        '
        'Label39
        '
        Me.Label39.AutoSize = True
        Me.Label39.BackColor = System.Drawing.Color.Transparent
        Me.Label39.Font = New System.Drawing.Font("Arial Rounded MT Bold", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label39.ForeColor = System.Drawing.Color.Red
        Me.Label39.Location = New System.Drawing.Point(86, 7)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(10, 12)
        Me.Label39.TabIndex = 8
        Me.Label39.Text = "*"
        '
        'cmbBankname
        '
        Me.cmbBankname.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbBankname.FormattingEnabled = True
        Me.cmbBankname.Location = New System.Drawing.Point(168, 4)
        Me.cmbBankname.Name = "cmbBankname"
        Me.cmbBankname.Size = New System.Drawing.Size(101, 21)
        Me.cmbBankname.TabIndex = 5
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.ForeColor = System.Drawing.Color.FromArgb(CType(CType(53, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(147, Byte), Integer))
        Me.Label32.Location = New System.Drawing.Point(5, 60)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(70, 13)
        Me.Label32.TabIndex = 4
        Me.Label32.Text = "Cheque Date"
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.ForeColor = System.Drawing.Color.FromArgb(CType(CType(53, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(147, Byte), Integer))
        Me.Label31.Location = New System.Drawing.Point(5, 35)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(61, 13)
        Me.Label31.TabIndex = 3
        Me.Label31.Text = "Cheque No"
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.ForeColor = System.Drawing.Color.FromArgb(CType(CType(53, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(147, Byte), Integer))
        Me.Label30.Location = New System.Drawing.Point(5, 7)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(63, 13)
        Me.Label30.TabIndex = 1
        Me.Label30.Text = "Bank Name"
        '
        'txtChqdt
        '
        Me.txtChqdt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtChqdt.Location = New System.Drawing.Point(168, 58)
        Me.txtChqdt.Name = "txtChqdt"
        Me.txtChqdt.ReadOnly = True
        Me.txtChqdt.Size = New System.Drawing.Size(89, 20)
        Me.txtChqdt.TabIndex = 1
        '
        'txtChqno
        '
        Me.txtChqno.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtChqno.Location = New System.Drawing.Point(168, 33)
        Me.txtChqno.Name = "txtChqno"
        Me.txtChqno.Size = New System.Drawing.Size(101, 20)
        Me.txtChqno.TabIndex = 0
        '
        'dtpChqDt
        '
        Me.dtpChqDt.Location = New System.Drawing.Point(255, 58)
        Me.dtpChqDt.Name = "dtpChqDt"
        Me.dtpChqDt.Size = New System.Drawing.Size(17, 20)
        Me.dtpChqDt.TabIndex = 2
        '
        'cmbPaymode
        '
        Me.cmbPaymode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPaymode.FormattingEnabled = True
        Me.cmbPaymode.Items.AddRange(New Object() {"Cash", "Cheque"})
        Me.cmbPaymode.Location = New System.Drawing.Point(782, 6)
        Me.cmbPaymode.Name = "cmbPaymode"
        Me.cmbPaymode.Size = New System.Drawing.Size(101, 21)
        Me.cmbPaymode.TabIndex = 73
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.ForeColor = System.Drawing.Color.FromArgb(CType(CType(53, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(147, Byte), Integer))
        Me.Label28.Location = New System.Drawing.Point(619, 9)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(78, 13)
        Me.Label28.TabIndex = 75
        Me.Label28.Text = "Payment Mode"
        '
        'griddata
        '
        Me.griddata.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.griddata.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(225, Byte), Integer), CType(CType(227, Byte), Integer), CType(CType(232, Byte), Integer))
        Me.griddata.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.griddata.Location = New System.Drawing.Point(3, 124)
        Me.griddata.Name = "griddata"
        Me.griddata.Size = New System.Drawing.Size(909, 356)
        Me.griddata.TabIndex = 26
        '
        'cmbyear
        '
        Me.cmbyear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbyear.FormattingEnabled = True
        Me.cmbyear.Location = New System.Drawing.Point(218, 81)
        Me.cmbyear.Name = "cmbyear"
        Me.cmbyear.Size = New System.Drawing.Size(83, 21)
        Me.cmbyear.TabIndex = 25
        '
        'cmbmonth
        '
        Me.cmbmonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbmonth.FormattingEnabled = True
        Me.cmbmonth.Items.AddRange(New Object() {"January", "Feburary", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"})
        Me.cmbmonth.Location = New System.Drawing.Point(108, 81)
        Me.cmbmonth.Name = "cmbmonth"
        Me.cmbmonth.Size = New System.Drawing.Size(104, 21)
        Me.cmbmonth.TabIndex = 25
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(53, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(147, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(12, 83)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(84, 16)
        Me.Label3.TabIndex = 24
        Me.Label3.Text = "Month/ Year"
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.FromArgb(CType(CType(92, Byte), Integer), CType(CType(184, Byte), Integer), CType(CType(92, Byte), Integer))
        Me.Button1.FlatAppearance.BorderSize = 0
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.White
        Me.Button1.Location = New System.Drawing.Point(307, 81)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(69, 23)
        Me.Button1.TabIndex = 18
        Me.Button1.Text = "List"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Panelindgroup
        '
        Me.Panelindgroup.Controls.Add(Me.cmbname)
        Me.Panelindgroup.Controls.Add(Me.lblname)
        Me.Panelindgroup.Location = New System.Drawing.Point(314, 9)
        Me.Panelindgroup.Name = "Panelindgroup"
        Me.Panelindgroup.Size = New System.Drawing.Size(295, 47)
        Me.Panelindgroup.TabIndex = 27
        '
        'cmbname
        '
        Me.cmbname.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbname.FormattingEnabled = True
        Me.cmbname.Location = New System.Drawing.Point(120, 17)
        Me.cmbname.Name = "cmbname"
        Me.cmbname.Size = New System.Drawing.Size(172, 21)
        Me.cmbname.TabIndex = 26
        '
        'lblname
        '
        Me.lblname.AutoSize = True
        Me.lblname.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblname.ForeColor = System.Drawing.Color.FromArgb(CType(CType(53, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(147, Byte), Integer))
        Me.lblname.Location = New System.Drawing.Point(6, 20)
        Me.lblname.Name = "lblname"
        Me.lblname.Size = New System.Drawing.Size(110, 16)
        Me.lblname.TabIndex = 22
        Me.lblname.Text = "Employee Name"
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.rbtnall)
        Me.Panel3.Controls.Add(Me.rbtnind)
        Me.Panel3.Controls.Add(Me.rbtngroup)
        Me.Panel3.Location = New System.Drawing.Point(101, 26)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(200, 23)
        Me.Panel3.TabIndex = 23
        '
        'rbtnall
        '
        Me.rbtnall.AutoSize = True
        Me.rbtnall.Location = New System.Drawing.Point(143, 4)
        Me.rbtnall.Name = "rbtnall"
        Me.rbtnall.Size = New System.Drawing.Size(36, 17)
        Me.rbtnall.TabIndex = 22
        Me.rbtnall.Text = "All"
        Me.rbtnall.UseVisualStyleBackColor = True
        '
        'rbtnind
        '
        Me.rbtnind.AutoSize = True
        Me.rbtnind.Checked = True
        Me.rbtnind.Location = New System.Drawing.Point(7, 4)
        Me.rbtnind.Name = "rbtnind"
        Me.rbtnind.Size = New System.Drawing.Size(70, 17)
        Me.rbtnind.TabIndex = 22
        Me.rbtnind.TabStop = True
        Me.rbtnind.Text = "Individual"
        Me.rbtnind.UseVisualStyleBackColor = True
        '
        'rbtngroup
        '
        Me.rbtngroup.AutoSize = True
        Me.rbtngroup.Location = New System.Drawing.Point(83, 4)
        Me.rbtngroup.Name = "rbtngroup"
        Me.rbtngroup.Size = New System.Drawing.Size(54, 17)
        Me.rbtngroup.TabIndex = 22
        Me.rbtngroup.Text = "Group"
        Me.rbtngroup.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(53, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(147, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(12, 30)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(83, 16)
        Me.Label2.TabIndex = 21
        Me.Label2.Text = "Salary Type"
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.lbltotalsalary)
        Me.Panel2.Controls.Add(Me.btnClear)
        Me.Panel2.Controls.Add(Me.Button2)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 486)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(915, 72)
        Me.Panel2.TabIndex = 0
        '
        'lbltotalsalary
        '
        Me.lbltotalsalary.AutoSize = True
        Me.lbltotalsalary.Location = New System.Drawing.Point(648, 24)
        Me.lbltotalsalary.Name = "lbltotalsalary"
        Me.lbltotalsalary.Size = New System.Drawing.Size(39, 13)
        Me.lbltotalsalary.TabIndex = 15
        Me.lbltotalsalary.Text = "Label5"
        Me.lbltotalsalary.Visible = False
        '
        'btnClear
        '
        Me.btnClear.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClear.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnClear.FlatAppearance.BorderSize = 0
        Me.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClear.ForeColor = System.Drawing.Color.Black
        Me.btnClear.Location = New System.Drawing.Point(460, 24)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(75, 25)
        Me.btnClear.TabIndex = 14
        Me.btnClear.Text = "Clear"
        Me.btnClear.UseVisualStyleBackColor = False
        '
        'Button2
        '
        Me.Button2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button2.BackColor = System.Drawing.Color.FromArgb(CType(CType(92, Byte), Integer), CType(CType(184, Byte), Integer), CType(CType(92, Byte), Integer))
        Me.Button2.FlatAppearance.BorderSize = 0
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.ForeColor = System.Drawing.Color.White
        Me.Button2.Location = New System.Drawing.Point(379, 24)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 24)
        Me.Button2.TabIndex = 13
        Me.Button2.Text = "Save"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'btnSave
        '
        Me.btnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSave.BackColor = System.Drawing.Color.FromArgb(CType(CType(92, Byte), Integer), CType(CType(184, Byte), Integer), CType(CType(92, Byte), Integer))
        Me.btnSave.FlatAppearance.BorderSize = 0
        Me.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSave.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.ForeColor = System.Drawing.Color.White
        Me.btnSave.Location = New System.Drawing.Point(780, 19)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(125, 33)
        Me.btnSave.TabIndex = 18
        Me.btnSave.Text = "Add Employee"
        Me.btnSave.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial Narrow", 13.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(53, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(147, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(405, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(117, 22)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Salary Register"
        '
        'Payslip
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(917, 623)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Panel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Payslip"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Payslip"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.pnlBankdtls.ResumeLayout(False)
        Me.pnlBankdtls.PerformLayout()
        CType(Me.griddata, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panelindgroup.ResumeLayout(False)
        Me.Panelindgroup.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents rbtngroup As System.Windows.Forms.RadioButton
    Friend WithEvents rbtnind As System.Windows.Forms.RadioButton
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents cmbyear As System.Windows.Forms.ComboBox
    Friend WithEvents cmbmonth As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents rbtnall As System.Windows.Forms.RadioButton
    Friend WithEvents griddata As System.Windows.Forms.DataGridView
    Friend WithEvents btnClear As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Panelindgroup As System.Windows.Forms.Panel
    Friend WithEvents cmbname As System.Windows.Forms.ComboBox
    Friend WithEvents lblname As System.Windows.Forms.Label
    Friend WithEvents lbltotalsalary As System.Windows.Forms.Label
    Friend WithEvents Label38 As System.Windows.Forms.Label
    Friend WithEvents pnlBankdtls As System.Windows.Forms.Panel
    Friend WithEvents Label39 As System.Windows.Forms.Label
    Friend WithEvents cmbBankname As System.Windows.Forms.ComboBox
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents txtChqdt As System.Windows.Forms.TextBox
    Friend WithEvents txtChqno As System.Windows.Forms.TextBox
    Friend WithEvents dtpChqDt As System.Windows.Forms.DateTimePicker
    Friend WithEvents cmbPaymode As System.Windows.Forms.ComboBox
    Friend WithEvents Label28 As System.Windows.Forms.Label
End Class
