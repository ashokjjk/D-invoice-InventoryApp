<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Payslipprint
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Payslipprint))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.pnlemployee = New System.Windows.Forms.Panel()
        Me.cmbname = New System.Windows.Forms.ComboBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.rbtnname = New System.Windows.Forms.RadioButton()
        Me.rbtnmonyr = New System.Windows.Forms.RadioButton()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.pnlmonyr = New System.Windows.Forms.Panel()
        Me.cmbyear = New System.Windows.Forms.ComboBox()
        Me.cmbmonth = New System.Windows.Forms.ComboBox()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.griddata = New System.Windows.Forms.DataGridView()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        Me.pnlemployee.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.pnlmonyr.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.griddata, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.pnlemployee)
        Me.Panel1.Controls.Add(Me.Panel4)
        Me.Panel1.Controls.Add(Me.Label14)
        Me.Panel1.Controls.Add(Me.pnlmonyr)
        Me.Panel1.Location = New System.Drawing.Point(12, 51)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1279, 96)
        Me.Panel1.TabIndex = 36
        '
        'pnlemployee
        '
        Me.pnlemployee.Controls.Add(Me.cmbname)
        Me.pnlemployee.Controls.Add(Me.Button2)
        Me.pnlemployee.Controls.Add(Me.Label4)
        Me.pnlemployee.Location = New System.Drawing.Point(539, 38)
        Me.pnlemployee.Name = "pnlemployee"
        Me.pnlemployee.Size = New System.Drawing.Size(341, 51)
        Me.pnlemployee.TabIndex = 16
        '
        'cmbname
        '
        Me.cmbname.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbname.FormattingEnabled = True
        Me.cmbname.Items.AddRange(New Object() {"January", "Feburary", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"})
        Me.cmbname.Location = New System.Drawing.Point(168, 3)
        Me.cmbname.Name = "cmbname"
        Me.cmbname.Size = New System.Drawing.Size(170, 21)
        Me.cmbname.TabIndex = 29
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(109, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.Button2.FlatAppearance.BorderSize = 0
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.ForeColor = System.Drawing.Color.White
        Me.Button2.Location = New System.Drawing.Point(187, 25)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 25)
        Me.Button2.TabIndex = 12
        Me.Button2.Text = "Generate"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(53, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(147, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(3, 4)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(110, 16)
        Me.Label4.TabIndex = 26
        Me.Label4.Text = "Employee Name"
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.rbtnname)
        Me.Panel4.Controls.Add(Me.rbtnmonyr)
        Me.Panel4.Location = New System.Drawing.Point(87, 5)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(213, 32)
        Me.Panel4.TabIndex = 15
        '
        'rbtnname
        '
        Me.rbtnname.AutoSize = True
        Me.rbtnname.Location = New System.Drawing.Point(99, 6)
        Me.rbtnname.Name = "rbtnname"
        Me.rbtnname.Size = New System.Drawing.Size(53, 17)
        Me.rbtnname.TabIndex = 0
        Me.rbtnname.Text = "Name"
        Me.rbtnname.UseVisualStyleBackColor = True
        '
        'rbtnmonyr
        '
        Me.rbtnmonyr.AutoSize = True
        Me.rbtnmonyr.Checked = True
        Me.rbtnmonyr.Location = New System.Drawing.Point(3, 6)
        Me.rbtnmonyr.Name = "rbtnmonyr"
        Me.rbtnmonyr.Size = New System.Drawing.Size(82, 17)
        Me.rbtnmonyr.TabIndex = 0
        Me.rbtnmonyr.TabStop = True
        Me.rbtnmonyr.Text = "Month/Year"
        Me.rbtnmonyr.UseVisualStyleBackColor = True
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.ForeColor = System.Drawing.Color.FromArgb(CType(CType(53, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(147, Byte), Integer))
        Me.Label14.Location = New System.Drawing.Point(13, 12)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(68, 13)
        Me.Label14.TabIndex = 14
        Me.Label14.Text = "Search Type"
        '
        'pnlmonyr
        '
        Me.pnlmonyr.Controls.Add(Me.cmbyear)
        Me.pnlmonyr.Controls.Add(Me.cmbmonth)
        Me.pnlmonyr.Controls.Add(Me.btnSearch)
        Me.pnlmonyr.Controls.Add(Me.Label1)
        Me.pnlmonyr.Controls.Add(Me.Label3)
        Me.pnlmonyr.Location = New System.Drawing.Point(306, 4)
        Me.pnlmonyr.Name = "pnlmonyr"
        Me.pnlmonyr.Size = New System.Drawing.Size(213, 87)
        Me.pnlmonyr.TabIndex = 13
        '
        'cmbyear
        '
        Me.cmbyear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbyear.FormattingEnabled = True
        Me.cmbyear.Location = New System.Drawing.Point(83, 31)
        Me.cmbyear.Name = "cmbyear"
        Me.cmbyear.Size = New System.Drawing.Size(104, 21)
        Me.cmbyear.TabIndex = 27
        '
        'cmbmonth
        '
        Me.cmbmonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbmonth.FormattingEnabled = True
        Me.cmbmonth.Items.AddRange(New Object() {"January", "Feburary", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"})
        Me.cmbmonth.Location = New System.Drawing.Point(83, 4)
        Me.cmbmonth.Name = "cmbmonth"
        Me.cmbmonth.Size = New System.Drawing.Size(104, 21)
        Me.cmbmonth.TabIndex = 28
        '
        'btnSearch
        '
        Me.btnSearch.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(109, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.btnSearch.FlatAppearance.BorderSize = 0
        Me.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSearch.ForeColor = System.Drawing.Color.White
        Me.btnSearch.Location = New System.Drawing.Point(99, 58)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(75, 25)
        Me.btnSearch.TabIndex = 12
        Me.btnSearch.Text = "Generate"
        Me.btnSearch.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(53, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(147, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(21, 34)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(37, 16)
        Me.Label1.TabIndex = 26
        Me.Label1.Text = "Year"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(53, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(147, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(21, 7)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(47, 16)
        Me.Label3.TabIndex = 26
        Me.Label3.Text = "Month"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Arial Narrow", 11.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.FromArgb(CType(CType(53, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(147, Byte), Integer))
        Me.Label12.Location = New System.Drawing.Point(610, 19)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(98, 20)
        Me.Label12.TabIndex = 35
        Me.Label12.Text = "Payslip Report"
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.griddata)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 181)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1303, 499)
        Me.Panel2.TabIndex = 37
        '
        'griddata
        '
        Me.griddata.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(225, Byte), Integer), CType(CType(227, Byte), Integer), CType(CType(232, Byte), Integer))
        Me.griddata.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.griddata.Dock = System.Windows.Forms.DockStyle.Fill
        Me.griddata.Location = New System.Drawing.Point(0, 0)
        Me.griddata.Name = "griddata"
        Me.griddata.Size = New System.Drawing.Size(1303, 499)
        Me.griddata.TabIndex = 0
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.White
        Me.Button1.FlatAppearance.BorderSize = 0
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.ForeColor = System.Drawing.Color.White
        Me.Button1.Image = Global.DinvoiceStandalone2._0.My.Resources.Resources.excel1
        Me.Button1.Location = New System.Drawing.Point(1263, 153)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(28, 28)
        Me.Button1.TabIndex = 38
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Payslipprint
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1303, 680)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Label12)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Payslipprint"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Print Payslip"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.pnlemployee.ResumeLayout(False)
        Me.pnlemployee.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.pnlmonyr.ResumeLayout(False)
        Me.pnlmonyr.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        CType(Me.griddata, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents pnlmonyr As System.Windows.Forms.Panel
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents cmbyear As System.Windows.Forms.ComboBox
    Friend WithEvents cmbmonth As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents griddata As System.Windows.Forms.DataGridView
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents pnlemployee As System.Windows.Forms.Panel
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents rbtnname As System.Windows.Forms.RadioButton
    Friend WithEvents rbtnmonyr As System.Windows.Forms.RadioButton
    Friend WithEvents cmbname As System.Windows.Forms.ComboBox
End Class
