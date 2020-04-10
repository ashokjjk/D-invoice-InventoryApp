<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LedgerStatement
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(LedgerStatement))
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lstbxDetails = New System.Windows.Forms.ListBox()
        Me.txtSearchKeyword = New System.Windows.Forms.TextBox()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.txtfromdate = New System.Windows.Forms.TextBox()
        Me.txttodate = New System.Windows.Forms.TextBox()
        Me.dtptodate = New System.Windows.Forms.DateTimePicker()
        Me.dtpfromdate = New System.Windows.Forms.DateTimePicker()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.lblcuscode = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.ForeColor = System.Drawing.Color.FromArgb(CType(CType(53, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(147, Byte), Integer))
        Me.Label11.Location = New System.Drawing.Point(5, 18)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(64, 13)
        Me.Label11.TabIndex = 9
        Me.Label11.Text = "Client Name"
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.lstbxDetails)
        Me.Panel1.Controls.Add(Me.Button1)
        Me.Panel1.Controls.Add(Me.Label11)
        Me.Panel1.Controls.Add(Me.txtSearchKeyword)
        Me.Panel1.Controls.Add(Me.Panel3)
        Me.Panel1.Location = New System.Drawing.Point(9, 32)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(276, 144)
        Me.Panel1.TabIndex = 30
        '
        'lstbxDetails
        '
        Me.lstbxDetails.FormattingEnabled = True
        Me.lstbxDetails.Location = New System.Drawing.Point(72, 36)
        Me.lstbxDetails.Name = "lstbxDetails"
        Me.lstbxDetails.Size = New System.Drawing.Size(188, 95)
        Me.lstbxDetails.TabIndex = 29
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
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.txtfromdate)
        Me.Panel3.Controls.Add(Me.txttodate)
        Me.Panel3.Controls.Add(Me.dtptodate)
        Me.Panel3.Controls.Add(Me.dtpfromdate)
        Me.Panel3.Controls.Add(Me.Label4)
        Me.Panel3.Controls.Add(Me.Label6)
        Me.Panel3.Location = New System.Drawing.Point(4, 39)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(257, 55)
        Me.Panel3.TabIndex = 13
        '
        'txtfromdate
        '
        Me.txtfromdate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtfromdate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtfromdate.Location = New System.Drawing.Point(68, 5)
        Me.txtfromdate.Name = "txtfromdate"
        Me.txtfromdate.ReadOnly = True
        Me.txtfromdate.Size = New System.Drawing.Size(166, 20)
        Me.txtfromdate.TabIndex = 18
        '
        'txttodate
        '
        Me.txttodate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txttodate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txttodate.Location = New System.Drawing.Point(68, 28)
        Me.txttodate.Name = "txttodate"
        Me.txttodate.ReadOnly = True
        Me.txttodate.Size = New System.Drawing.Size(166, 20)
        Me.txttodate.TabIndex = 15
        '
        'dtptodate
        '
        Me.dtptodate.Location = New System.Drawing.Point(232, 28)
        Me.dtptodate.Name = "dtptodate"
        Me.dtptodate.Size = New System.Drawing.Size(19, 20)
        Me.dtptodate.TabIndex = 17
        '
        'dtpfromdate
        '
        Me.dtpfromdate.Location = New System.Drawing.Point(231, 5)
        Me.dtpfromdate.Name = "dtpfromdate"
        Me.dtpfromdate.Size = New System.Drawing.Size(19, 20)
        Me.dtpfromdate.TabIndex = 16
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(53, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(147, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(3, 31)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(52, 13)
        Me.Label4.TabIndex = 13
        Me.Label4.Text = "To Date :"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(53, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(147, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(3, 8)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(62, 13)
        Me.Label6.TabIndex = 14
        Me.Label6.Text = "From Date :"
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(109, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.Button1.FlatAppearance.BorderSize = 0
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.ForeColor = System.Drawing.Color.White
        Me.Button1.Location = New System.Drawing.Point(141, 100)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 25)
        Me.Button1.TabIndex = 30
        Me.Button1.Text = "Generate"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Arial Narrow", 11.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.FromArgb(CType(CType(53, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(147, Byte), Integer))
        Me.Label12.Location = New System.Drawing.Point(96, 9)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(115, 20)
        Me.Label12.TabIndex = 27
        Me.Label12.Text = "Ledger Statement"
        '
        'lblcuscode
        '
        Me.lblcuscode.AutoSize = True
        Me.lblcuscode.Location = New System.Drawing.Point(390, 68)
        Me.lblcuscode.Name = "lblcuscode"
        Me.lblcuscode.Size = New System.Drawing.Size(0, 13)
        Me.lblcuscode.TabIndex = 31
        '
        'LedgerStatement
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(297, 192)
        Me.Controls.Add(Me.lblcuscode)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Label12)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "LedgerStatement"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Ledger Statement"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents txtfromdate As System.Windows.Forms.TextBox
    Friend WithEvents txttodate As System.Windows.Forms.TextBox
    Friend WithEvents dtptodate As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpfromdate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtSearchKeyword As System.Windows.Forms.TextBox
    Friend WithEvents lstbxDetails As System.Windows.Forms.ListBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents lblcuscode As System.Windows.Forms.Label
End Class
