<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MultiPOSsupply
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MultiPOSsupply))
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.TabPage4 = New System.Windows.Forms.TabPage()
        Me.Posusersupply1 = New DinvoiceStandalone2._0.posusersupply()
        Me.Posusersupply2 = New DinvoiceStandalone2._0.posusersupply()
        Me.Posusersupply3 = New DinvoiceStandalone2._0.posusersupply()
        Me.Posusersupply4 = New DinvoiceStandalone2._0.posusersupply()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.TabPage4.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Controls.Add(Me.TabPage4)
        Me.TabControl1.Location = New System.Drawing.Point(-1, 2)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1295, 804)
        Me.TabControl1.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.Posusersupply1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(1287, 778)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Parked 1"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.Posusersupply2)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(1287, 778)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Parked 2"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.Posusersupply3)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(1287, 778)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Parked 3"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'TabPage4
        '
        Me.TabPage4.Controls.Add(Me.Posusersupply4)
        Me.TabPage4.Location = New System.Drawing.Point(4, 22)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Size = New System.Drawing.Size(1287, 778)
        Me.TabPage4.TabIndex = 3
        Me.TabPage4.Text = "Parked 4"
        Me.TabPage4.UseVisualStyleBackColor = True
        '
        'Posusersupply1
        '
        Me.Posusersupply1.BackColor = System.Drawing.Color.White
        Me.Posusersupply1.Location = New System.Drawing.Point(0, 0)
        Me.Posusersupply1.Name = "Posusersupply1"
        Me.Posusersupply1.Size = New System.Drawing.Size(1288, 738)
        Me.Posusersupply1.TabIndex = 0
        '
        'Posusersupply2
        '
        Me.Posusersupply2.BackColor = System.Drawing.Color.White
        Me.Posusersupply2.Location = New System.Drawing.Point(0, 0)
        Me.Posusersupply2.Name = "Posusersupply2"
        Me.Posusersupply2.Size = New System.Drawing.Size(1288, 738)
        Me.Posusersupply2.TabIndex = 0
        '
        'Posusersupply3
        '
        Me.Posusersupply3.BackColor = System.Drawing.Color.White
        Me.Posusersupply3.Location = New System.Drawing.Point(0, 0)
        Me.Posusersupply3.Name = "Posusersupply3"
        Me.Posusersupply3.Size = New System.Drawing.Size(1288, 738)
        Me.Posusersupply3.TabIndex = 0
        '
        'Posusersupply4
        '
        Me.Posusersupply4.BackColor = System.Drawing.Color.White
        Me.Posusersupply4.Location = New System.Drawing.Point(0, 0)
        Me.Posusersupply4.Name = "Posusersupply4"
        Me.Posusersupply4.Size = New System.Drawing.Size(1288, 738)
        Me.Posusersupply4.TabIndex = 0
        '
        'MultiPOSsupply
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1294, 805)
        Me.Controls.Add(Me.TabControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "MultiPOSsupply"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "MultiPOS"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage4.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage4 As System.Windows.Forms.TabPage
    Friend WithEvents Posusersupply1 As DinvoiceStandalone2._0.posusersupply
    Friend WithEvents Posusersupply2 As DinvoiceStandalone2._0.posusersupply
    Friend WithEvents Posusersupply3 As DinvoiceStandalone2._0.posusersupply
    Friend WithEvents Posusersupply4 As DinvoiceStandalone2._0.posusersupply
End Class
