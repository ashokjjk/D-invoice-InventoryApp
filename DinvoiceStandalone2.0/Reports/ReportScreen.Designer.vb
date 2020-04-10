<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ReportScreen
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ReportScreen))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnpurchase = New System.Windows.Forms.Button()
        Me.btnsupply = New System.Windows.Forms.Button()
        Me.btnquotation = New System.Windows.Forms.Button()
        Me.btninvoice = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(136, Byte), Integer), CType(CType(187, Byte), Integer), CType(CType(216, Byte), Integer))
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.btnpurchase)
        Me.Panel1.Controls.Add(Me.btnsupply)
        Me.Panel1.Controls.Add(Me.btnquotation)
        Me.Panel1.Controls.Add(Me.btninvoice)
        Me.Panel1.Controls.Add(Me.Button3)
        Me.Panel1.Controls.Add(Me.Button1)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel1.Location = New System.Drawing.Point(0, 1)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(247, 739)
        Me.Panel1.TabIndex = 1
        Me.Panel1.Visible = False
        '
        'btnpurchase
        '
        Me.btnpurchase.BackColor = System.Drawing.Color.FromArgb(CType(CType(249, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnpurchase.FlatAppearance.BorderSize = 0
        Me.btnpurchase.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnpurchase.Font = New System.Drawing.Font("Arial Black", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnpurchase.ForeColor = System.Drawing.Color.White
        Me.btnpurchase.Image = CType(resources.GetObject("btnpurchase.Image"), System.Drawing.Image)
        Me.btnpurchase.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnpurchase.Location = New System.Drawing.Point(124, 279)
        Me.btnpurchase.Name = "btnpurchase"
        Me.btnpurchase.Size = New System.Drawing.Size(117, 41)
        Me.btnpurchase.TabIndex = 6
        Me.btnpurchase.Text = "Bill"
        Me.btnpurchase.UseVisualStyleBackColor = False
        '
        'btnsupply
        '
        Me.btnsupply.BackColor = System.Drawing.Color.FromArgb(CType(CType(49, Byte), Integer), CType(CType(178, Byte), Integer), CType(CType(42, Byte), Integer))
        Me.btnsupply.FlatAppearance.BorderSize = 0
        Me.btnsupply.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnsupply.Font = New System.Drawing.Font("Arial Black", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnsupply.ForeColor = System.Drawing.Color.White
        Me.btnsupply.Image = CType(resources.GetObject("btnsupply.Image"), System.Drawing.Image)
        Me.btnsupply.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnsupply.Location = New System.Drawing.Point(3, 279)
        Me.btnsupply.Name = "btnsupply"
        Me.btnsupply.Size = New System.Drawing.Size(117, 41)
        Me.btnsupply.TabIndex = 6
        Me.btnsupply.Text = "Supply"
        Me.btnsupply.UseVisualStyleBackColor = False
        '
        'btnquotation
        '
        Me.btnquotation.BackColor = System.Drawing.Color.FromArgb(CType(CType(153, Byte), Integer), CType(CType(124, Byte), Integer), CType(CType(82, Byte), Integer))
        Me.btnquotation.FlatAppearance.BorderSize = 0
        Me.btnquotation.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnquotation.Font = New System.Drawing.Font("Arial Black", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnquotation.ForeColor = System.Drawing.Color.White
        Me.btnquotation.Image = CType(resources.GetObject("btnquotation.Image"), System.Drawing.Image)
        Me.btnquotation.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnquotation.Location = New System.Drawing.Point(124, 232)
        Me.btnquotation.Name = "btnquotation"
        Me.btnquotation.Size = New System.Drawing.Size(117, 41)
        Me.btnquotation.TabIndex = 6
        Me.btnquotation.Text = "Quotation"
        Me.btnquotation.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnquotation.UseVisualStyleBackColor = False
        '
        'btninvoice
        '
        Me.btninvoice.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btninvoice.FlatAppearance.BorderSize = 0
        Me.btninvoice.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btninvoice.Font = New System.Drawing.Font("Arial Black", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btninvoice.ForeColor = System.Drawing.Color.Black
        Me.btninvoice.Image = CType(resources.GetObject("btninvoice.Image"), System.Drawing.Image)
        Me.btninvoice.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btninvoice.Location = New System.Drawing.Point(3, 232)
        Me.btninvoice.Name = "btninvoice"
        Me.btninvoice.Size = New System.Drawing.Size(117, 41)
        Me.btninvoice.TabIndex = 6
        Me.btninvoice.Text = "Invoice"
        Me.btninvoice.UseVisualStyleBackColor = False
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(142, 109)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(50, 64)
        Me.Button3.TabIndex = 5
        Me.Button3.Text = "A5"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(61, 92)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 81)
        Me.Button1.TabIndex = 5
        Me.Button1.Text = "A4"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 10.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(57, 35)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(139, 16)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Report Preference"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(7, 206)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(74, 13)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Quick Links"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(7, 76)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(87, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Report Layout"
        '
        'ReportViewer1
        '
        Me.ReportViewer1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ReportViewer1.Location = New System.Drawing.Point(248, 1)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.Size = New System.Drawing.Size(831, 739)
        Me.ReportViewer1.TabIndex = 2
        '
        'ReportScreen
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1081, 745)
        Me.Controls.Add(Me.ReportViewer1)
        Me.Controls.Add(Me.Panel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "ReportScreen"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "View Screen"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnpurchase As System.Windows.Forms.Button
    Friend WithEvents btnsupply As System.Windows.Forms.Button
    Friend WithEvents btnquotation As System.Windows.Forms.Button
    Friend WithEvents btninvoice As System.Windows.Forms.Button
End Class
