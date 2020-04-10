<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CustomerReport
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CustomerReport))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.txtSearchKeyword = New System.Windows.Forms.TextBox()
        Me.lstbxDetails = New System.Windows.Forms.ListBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.lblGst = New System.Windows.Forms.Label()
        Me.lblgstno = New System.Windows.Forms.Label()
        Me.lblshippingadr = New System.Windows.Forms.Label()
        Me.lblbillingadr = New System.Windows.Forms.Label()
        Me.lblPlaceofSupply = New System.Windows.Forms.Label()
        Me.lblgsttreat = New System.Windows.Forms.Label()
        Me.lblEmailid = New System.Windows.Forms.Label()
        Me.lblPhno = New System.Windows.Forms.Label()
        Me.lblCmpNm = New System.Windows.Forms.Label()
        Me.lblName = New System.Windows.Forms.Label()
        Me.lblType = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.lblcuscode = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.Label11)
        Me.Panel1.Controls.Add(Me.btnSearch)
        Me.Panel1.Controls.Add(Me.txtSearchKeyword)
        Me.Panel1.Location = New System.Drawing.Point(153, 47)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(379, 67)
        Me.Panel1.TabIndex = 30
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
        'btnSearch
        '
        Me.btnSearch.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(109, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.btnSearch.FlatAppearance.BorderSize = 0
        Me.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSearch.ForeColor = System.Drawing.Color.White
        Me.btnSearch.Location = New System.Drawing.Point(267, 12)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(75, 23)
        Me.btnSearch.TabIndex = 12
        Me.btnSearch.Text = "Search"
        Me.btnSearch.UseVisualStyleBackColor = False
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
        'lstbxDetails
        '
        Me.lstbxDetails.FormattingEnabled = True
        Me.lstbxDetails.Location = New System.Drawing.Point(226, 83)
        Me.lstbxDetails.Name = "lstbxDetails"
        Me.lstbxDetails.Size = New System.Drawing.Size(188, 95)
        Me.lstbxDetails.TabIndex = 29
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial Narrow", 11.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(53, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(147, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(328, 5)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(51, 20)
        Me.Label3.TabIndex = 26
        Me.Label3.Text = "Details"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Arial Narrow", 11.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.FromArgb(CType(CType(53, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(147, Byte), Integer))
        Me.Label12.Location = New System.Drawing.Point(222, 9)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(206, 20)
        Me.Label12.TabIndex = 27
        Me.Label12.Text = "Customer/ Vendor Details Report"
        '
        'Panel2
        '
        Me.Panel2.AutoSize = True
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.Label8)
        Me.Panel2.Controls.Add(Me.Label9)
        Me.Panel2.Controls.Add(Me.Label10)
        Me.Panel2.Controls.Add(Me.lblGst)
        Me.Panel2.Controls.Add(Me.lblgstno)
        Me.Panel2.Controls.Add(Me.lblshippingadr)
        Me.Panel2.Controls.Add(Me.lblbillingadr)
        Me.Panel2.Controls.Add(Me.lblPlaceofSupply)
        Me.Panel2.Controls.Add(Me.lblgsttreat)
        Me.Panel2.Controls.Add(Me.lblEmailid)
        Me.Panel2.Controls.Add(Me.lblPhno)
        Me.Panel2.Controls.Add(Me.lblCmpNm)
        Me.Panel2.Controls.Add(Me.lblName)
        Me.Panel2.Controls.Add(Me.lblType)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Controls.Add(Me.Label5)
        Me.Panel2.Controls.Add(Me.Label6)
        Me.Panel2.Controls.Add(Me.Label7)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Location = New System.Drawing.Point(12, 148)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(674, 332)
        Me.Panel2.TabIndex = 31
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(53, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(147, Byte), Integer))
        Me.Label8.Location = New System.Drawing.Point(357, 52)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(96, 13)
        Me.Label8.TabIndex = 35
        Me.Label8.Text = "Place of Supply"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(53, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(147, Byte), Integer))
        Me.Label9.Location = New System.Drawing.Point(357, 86)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(90, 13)
        Me.Label9.TabIndex = 36
        Me.Label9.Text = "Billing Address"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.FromArgb(CType(CType(53, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(147, Byte), Integer))
        Me.Label10.Location = New System.Drawing.Point(357, 132)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(105, 13)
        Me.Label10.TabIndex = 33
        Me.Label10.Text = "Shipping Address"
        '
        'lblGst
        '
        Me.lblGst.AutoSize = True
        Me.lblGst.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGst.ForeColor = System.Drawing.Color.FromArgb(CType(CType(53, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(147, Byte), Integer))
        Me.lblGst.Location = New System.Drawing.Point(357, 182)
        Me.lblGst.Name = "lblGst"
        Me.lblGst.Size = New System.Drawing.Size(52, 13)
        Me.lblGst.TabIndex = 34
        Me.lblGst.Text = "GST No"
        '
        'lblgstno
        '
        Me.lblgstno.AutoSize = True
        Me.lblgstno.ForeColor = System.Drawing.Color.Black
        Me.lblgstno.Location = New System.Drawing.Point(489, 182)
        Me.lblgstno.Name = "lblgstno"
        Me.lblgstno.Size = New System.Drawing.Size(10, 13)
        Me.lblgstno.TabIndex = 30
        Me.lblgstno.Text = "-"
        '
        'lblshippingadr
        '
        Me.lblshippingadr.AutoSize = True
        Me.lblshippingadr.ForeColor = System.Drawing.Color.Black
        Me.lblshippingadr.Location = New System.Drawing.Point(489, 132)
        Me.lblshippingadr.Name = "lblshippingadr"
        Me.lblshippingadr.Size = New System.Drawing.Size(10, 13)
        Me.lblshippingadr.TabIndex = 30
        Me.lblshippingadr.Text = "-"
        '
        'lblbillingadr
        '
        Me.lblbillingadr.AutoSize = True
        Me.lblbillingadr.ForeColor = System.Drawing.Color.Black
        Me.lblbillingadr.Location = New System.Drawing.Point(489, 86)
        Me.lblbillingadr.Name = "lblbillingadr"
        Me.lblbillingadr.Size = New System.Drawing.Size(10, 13)
        Me.lblbillingadr.TabIndex = 30
        Me.lblbillingadr.Text = "-"
        '
        'lblPlaceofSupply
        '
        Me.lblPlaceofSupply.AutoSize = True
        Me.lblPlaceofSupply.ForeColor = System.Drawing.Color.Black
        Me.lblPlaceofSupply.Location = New System.Drawing.Point(489, 52)
        Me.lblPlaceofSupply.Name = "lblPlaceofSupply"
        Me.lblPlaceofSupply.Size = New System.Drawing.Size(10, 13)
        Me.lblPlaceofSupply.TabIndex = 30
        Me.lblPlaceofSupply.Text = "-"
        '
        'lblgsttreat
        '
        Me.lblgsttreat.AutoSize = True
        Me.lblgsttreat.ForeColor = System.Drawing.Color.Black
        Me.lblgsttreat.Location = New System.Drawing.Point(155, 182)
        Me.lblgsttreat.Name = "lblgsttreat"
        Me.lblgsttreat.Size = New System.Drawing.Size(10, 13)
        Me.lblgsttreat.TabIndex = 30
        Me.lblgsttreat.Text = "-"
        '
        'lblEmailid
        '
        Me.lblEmailid.AutoSize = True
        Me.lblEmailid.ForeColor = System.Drawing.Color.Black
        Me.lblEmailid.Location = New System.Drawing.Point(155, 155)
        Me.lblEmailid.Name = "lblEmailid"
        Me.lblEmailid.Size = New System.Drawing.Size(10, 13)
        Me.lblEmailid.TabIndex = 30
        Me.lblEmailid.Text = "-"
        '
        'lblPhno
        '
        Me.lblPhno.AutoSize = True
        Me.lblPhno.ForeColor = System.Drawing.Color.Black
        Me.lblPhno.Location = New System.Drawing.Point(155, 128)
        Me.lblPhno.Name = "lblPhno"
        Me.lblPhno.Size = New System.Drawing.Size(10, 13)
        Me.lblPhno.TabIndex = 30
        Me.lblPhno.Text = "-"
        '
        'lblCmpNm
        '
        Me.lblCmpNm.AutoSize = True
        Me.lblCmpNm.ForeColor = System.Drawing.Color.Black
        Me.lblCmpNm.Location = New System.Drawing.Point(155, 102)
        Me.lblCmpNm.Name = "lblCmpNm"
        Me.lblCmpNm.Size = New System.Drawing.Size(10, 13)
        Me.lblCmpNm.TabIndex = 30
        Me.lblCmpNm.Text = "-"
        '
        'lblName
        '
        Me.lblName.AutoSize = True
        Me.lblName.ForeColor = System.Drawing.Color.Black
        Me.lblName.Location = New System.Drawing.Point(155, 77)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(10, 13)
        Me.lblName.TabIndex = 30
        Me.lblName.Text = "-"
        '
        'lblType
        '
        Me.lblType.AutoSize = True
        Me.lblType.ForeColor = System.Drawing.Color.Black
        Me.lblType.Location = New System.Drawing.Point(155, 52)
        Me.lblType.Name = "lblType"
        Me.lblType.Size = New System.Drawing.Size(10, 13)
        Me.lblType.TabIndex = 30
        Me.lblType.Text = "-"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(53, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(147, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(40, 52)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(35, 13)
        Me.Label2.TabIndex = 30
        Me.Label2.Text = "Type"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(53, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(147, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(40, 77)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(39, 13)
        Me.Label1.TabIndex = 31
        Me.Label1.Text = "Name"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(53, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(147, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(40, 102)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(94, 13)
        Me.Label4.TabIndex = 32
        Me.Label4.Text = "Company Name"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(53, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(147, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(40, 128)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(67, 13)
        Me.Label5.TabIndex = 27
        Me.Label5.Text = "Phone  No"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(53, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(147, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(40, 155)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(51, 13)
        Me.Label6.TabIndex = 28
        Me.Label6.Text = "Email id"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(53, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(147, Byte), Integer))
        Me.Label7.Location = New System.Drawing.Point(40, 182)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(93, 13)
        Me.Label7.TabIndex = 29
        Me.Label7.Text = "GST Treatment"
        '
        'lblcuscode
        '
        Me.lblcuscode.AutoSize = True
        Me.lblcuscode.Location = New System.Drawing.Point(577, 65)
        Me.lblcuscode.Name = "lblcuscode"
        Me.lblcuscode.Size = New System.Drawing.Size(45, 13)
        Me.lblcuscode.TabIndex = 32
        Me.lblcuscode.Text = "Label13"
        Me.lblcuscode.Visible = False
        '
        'CustomerReport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(699, 499)
        Me.Controls.Add(Me.lblcuscode)
        Me.Controls.Add(Me.lstbxDetails)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Panel2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "CustomerReport"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Customer Vendor Report"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents txtSearchKeyword As System.Windows.Forms.TextBox
    Friend WithEvents lstbxDetails As System.Windows.Forms.ListBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents lblGst As System.Windows.Forms.Label
    Friend WithEvents lblgstno As System.Windows.Forms.Label
    Friend WithEvents lblshippingadr As System.Windows.Forms.Label
    Friend WithEvents lblbillingadr As System.Windows.Forms.Label
    Friend WithEvents lblPlaceofSupply As System.Windows.Forms.Label
    Friend WithEvents lblgsttreat As System.Windows.Forms.Label
    Friend WithEvents lblEmailid As System.Windows.Forms.Label
    Friend WithEvents lblPhno As System.Windows.Forms.Label
    Friend WithEvents lblCmpNm As System.Windows.Forms.Label
    Friend WithEvents lblName As System.Windows.Forms.Label
    Friend WithEvents lblType As System.Windows.Forms.Label
    Friend WithEvents lblcuscode As System.Windows.Forms.Label
End Class
