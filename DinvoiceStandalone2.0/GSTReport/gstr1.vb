Public Class gstr1
    Dim obj As New ObjClass
    Private Sub gstr1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        MaximizeBox = False
        MinimizeBox = False
        'cmbCmpNm.Focus()
        cmbfiles.Focus()
    End Sub

    Private Sub cmbfiles_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbfiles.SelectedIndexChanged
        Select Case cmbfiles.Text
            Case Is = "b2b"
                txtdesc.Text = "Details of invoices of Taxable supplies made to other registered taxpayers"
            Case Is = "b2cs"
                txtdesc.Text = "Supplies made to consumers and unregistered persons of the following nature" & vbCrLf & "a) Intra-State: any value" & vbCrLf & "b) Inter-State: Invoice value Rs 2.5 lakh or less"
            Case Is = "b2cl"
                txtdesc.Text = "Invoices for Taxable outward supplies to consumers where" & vbCrLf & "a)The place of supply is outside the state where the supplier is registered and " & vbCrLf & "b)The total invoice value is more that Rs 2,50,000"
            Case Is = "cdnr"
                txtdesc.Text = "Credit/ Debit Notes/Refund vouchers issued to the registered taxpayers during the tax period. Debit or credit note issued against invoice will be reported here against original invoice, hence fill the details of original invoice also which was furnished in B2B,B2CL section of earlier/current period tax period.	"
            Case Is = "cdnur"
                txtdesc.Text = "Credit/ Debit Notes/Refund vouchers issued to the unregistered persons against interstate invoice value is  more than Rs 2.5 lakh"
            Case Is = "at"
                txtdesc.Text = "Tax liability arising on account of receipt of consideration  for which  invoices have not been issued in the same tax period."
            Case Is = "ataj"
                txtdesc.Text = "Adjustment of tax liability for tax already paid  on advance receipt of consideration and invoices issued in the current period for the supplies."
            Case Is = "exemp"
                txtdesc.Text = "Details of Nil Rated, Exempted and Non GST Supplies made during the tax period"
            Case Is = "hsn"
                txtdesc.Text = "HSN wise summary of goods /services supplied during the tax period"
        End Select
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try

       
        Dim exceltype As String
        exceltype = cmbfiles.Text
        If exceltype = "" Then
            MsgBox("Specify Excel Format!!!")
            Exit Sub
        Else
        End If
        Dim folder As New FolderBrowserDialog
        Dim pathtostore As String

        folder.RootFolder = Environment.SpecialFolder.MyComputer

            'Dim userpos As String = obj.GetOneValueFromQuery("select state from login where userid=''")
       
        Select Case exceltype
            Case Is = "b2b"
                If folder.ShowDialog() = Windows.Forms.DialogResult.OK Then
                    pathtostore = folder.SelectedPath & exceltype & Format(Today, "dd-MM-yyyy") & ".csv"
                End If

                obj.ExportToExcel(CreateDataTbForB2B(), pathtostore)
            Case Is = "b2cl"

                If folder.ShowDialog() = Windows.Forms.DialogResult.OK Then
                    pathtostore = folder.SelectedPath & exceltype & Format(Today, "dd-MM-yyyy") & ".csv"
                End If

                obj.ExportToExcel(CreateDataTbForB2CL(), pathtostore)
            Case Is = "b2cs"
                If folder.ShowDialog() = Windows.Forms.DialogResult.OK Then
                    pathtostore = folder.SelectedPath & exceltype & Format(Today, "dd-MM-yyyy") & ".csv"
                End If

                obj.ExportToExcel(CreateDataTbForB2Cs(), pathtostore)
            Case Is = "ataj"
                If folder.ShowDialog() = Windows.Forms.DialogResult.OK Then
                    pathtostore = folder.SelectedPath & exceltype & Format(Today, "dd-MM-yyyy") & ".csv"
                End If

                obj.ExportToExcel(CreateDataTbForADAJ(), pathtostore)
            Case Is = "at"
                If folder.ShowDialog() = Windows.Forms.DialogResult.OK Then
                    pathtostore = folder.SelectedPath & exceltype & Format(Today, "dd-MM-yyyy") & ".csv"
                End If

                obj.ExportToExcel(CreateDataTbForADAT(), pathtostore)

            Case Is = "cdnr"
                If folder.ShowDialog() = Windows.Forms.DialogResult.OK Then
                    pathtostore = folder.SelectedPath & exceltype & Format(Today, "dd-MM-yyyy") & ".csv"
                End If

                obj.ExportToExcel(CreateDataTbForCDR(), pathtostore)
                ' GSTIN/UIN of Recipient	Invoice/Advance Receipt Number	Invoice/Advance Receipt date	Note/Refund Voucher Number	Note/Refund Voucher date	Document Type	Reason For Issuing document	Place Of Supply	Note/Refund Voucher Value	Rate	Taxable Value	Cess Amount	Pre GST
            Case Is = "cdnur"
                'UR Type	Note/Refund Voucher Number	Note/Refund Voucher date	Document Type	Invoice/Advance Receipt Number	Invoice/Advance Receipt date	Reason For Issuing document	Place Of Supply	Note/Refund Voucher Value	Rate	Taxable Value	Cess Amount	Pre GST
                If folder.ShowDialog() = Windows.Forms.DialogResult.OK Then
                    pathtostore = folder.SelectedPath & exceltype & Format(Today, "dd-MM-yyyy") & ".csv"
                End If

                obj.ExportToExcel(CreateDataTbForCDNUR(), pathtostore)
            Case Is = "hsn"
                If folder.ShowDialog() = Windows.Forms.DialogResult.OK Then
                    pathtostore = folder.SelectedPath & exceltype & Format(Today, "dd-MM-yyyy") & ".csv"
                End If

                obj.ExportToExcel(CreateDataTbForHSN(), pathtostore)
            Case Is = "exemp"
                If folder.ShowDialog() = Windows.Forms.DialogResult.OK Then
                    pathtostore = folder.SelectedPath & exceltype & Format(Today, "dd-MM-yyyy") & ".csv"
                End If

                obj.ExportToExcel(CreateDataTbForNILGST(), pathtostore)
            End Select


        Catch ex As Exception

        End Try
    End Sub


    Private Function CreateDataTbForHSN() As DataTable
        Dim dt As New DataTable
        dt.Columns.Add("HSN")
        dt.Columns.Add("Description")
        dt.Columns.Add("UQC")
        dt.Columns.Add("Total Quantity")
        dt.Columns.Add("Total Value")
        dt.Columns.Add("Taxable Value")
        dt.Columns.Add("Integrated Tax Amount")
        dt.Columns.Add("Central Tax Amount")
        dt.Columns.Add("State/UT Tax Amount")
        dt.Columns.Add("Cess Amount")
        Dim k As Integer = 0
        
        Dim invitemdetails = obj.getdatatable("SELECT gst_id, item_desc, item_uom, item_qty,  invoicevalue, item_amount, cgst,  sgst,  igst, cess_amt from HSN where invoice_dt between #" + obj.ConvDtFrmt(txtfromdate.Text, "MM/dd/yyyy") + "# and #" + obj.ConvDtFrmt(txttodate.Text, "MM/dd/yyyy") + "#")
            'HSN	Description	UQC	Total Quantity	Total Value	Taxable Value	Integrated Tax Amount	Central Tax Amount	State/UT Tax Amount	Cess Amount
            For j = 0 To invitemdetails.Rows.Count - 1
                dt.Rows.Add()
                dt.Rows(k)(0) = invitemdetails.Rows(j).Item(0).ToString
                dt.Rows(k)(1) = invitemdetails.Rows(j).Item(1).ToString
                dt.Rows(k)(2) = invitemdetails.Rows(j).Item(2).ToString
                dt.Rows(k)(3) = invitemdetails.Rows(j).Item(3).ToString
                dt.Rows(k)(4) = invitemdetails.Rows(j).Item(4).ToString
                dt.Rows(k)(5) = invitemdetails.Rows(j).Item(5).ToString
            dt.Rows(k)(6) = invitemdetails.Rows(j).Item(6).ToString
            dt.Rows(k)(7) = invitemdetails.Rows(j).Item(7).ToString
            dt.Rows(k)(8) = invitemdetails.Rows(j).Item(8).ToString
            dt.Rows(k)(9) = invitemdetails.Rows(j).Item(9).ToString
                   



                k = k + 1
            Next



        Return dt
    End Function
    Private Function CreateDataTbForNILGST() As DataTable
        Dim dt As New DataTable
        'Description	Nil Rated Supplies	Exempted (other than nil rated/non GST supply )	Non-GST supplies
        dt.Columns.Add("Description")
        dt.Columns.Add("Nil Rated Supplies")
        dt.Columns.Add("Exempted (Other than Nil rated/non-GST supply)")
        dt.Columns.Add("Non GST Supplies")

        
        Dim desc, invtype, gsttreat1, gsttreat2 As New List(Of String)
        desc.Add("Inter-State supplies to registered persons")
        desc.Add("Intra-State supplies to registered persons")
        desc.Add("Inter-State supplies to unregistered persons")
        desc.Add("Intra-State supplies to unregistered persons")
        invtype.Add("IGST")
        invtype.Add("GST")
        invtype.Add("IGST")
        invtype.Add("GST")
        gsttreat1.Add("Registered Business")
        gsttreat1.Add("Registered Business")
        gsttreat1.Add("UnRegistered Business")
        gsttreat1.Add("UnRegistered Business")

        gsttreat2.Add("Composite Taxable Person")
        gsttreat2.Add("Composite Taxable Person")
        gsttreat2.Add("Consumer")
        gsttreat2.Add("Consumer")

        For k = 0 To desc.Count - 1

            dt.Rows.Add()
            dt.Rows(k)(0) = desc(k)
            dt.Rows(k)(1) = obj.GetOneValueFromQuery("select " & _
                                      "    sum(item_amount) from EXEMP where supply_dt between #" + obj.ConvDtFrmt(txtfromdate.Text, "MM/dd/yyyy") + "#" & _
                                      " and #" + obj.ConvDtFrmt(txttodate.Text, "MM/dd/yyyy") + "# and (gst_treatment='" + gsttreat1(k) + "' or" & _
                                      " gst_treatment='" + gsttreat2(k) + "')  and invtype='" + invtype(k) + "' and nilrate_flg=1 and typeinv='INVOICE'")
            dt.Rows(k)(2) = obj.GetOneValueFromQuery("select " & _
                                      "sum(item_amount) from EXEMP where supply_dt between #" + obj.ConvDtFrmt(txtfromdate.Text, "MM/dd/yyyy") + "# " & _
                                      "and #" + obj.ConvDtFrmt(txttodate.Text, "MM/dd/yyyy") + "# and (gst_treatment='" + gsttreat1(k) + "' or" & _
                                      " gst_treatment='" + gsttreat2(k) + "') and invtype='" + invtype(k) + "' and exempt_flg=1 and typeinv='INVOICE'")
            dt.Rows(k)(3) = obj.GetOneValueFromQuery("select " & _
                                      "sum(item_amount) from EXEMP where supply_dt between #" + obj.ConvDtFrmt(txtfromdate.Text, "MM/dd/yyyy") + "# " & _
                                      "and #" + obj.ConvDtFrmt(txttodate.Text, "MM/dd/yyyy") + "# and (gst_treatment='" + gsttreat1(k) + "' or " & _
                                      "gst_treatment='" + gsttreat2(k) + "') and invtype='" + invtype(k) + "' and typeinv='SUPPLY'")


        Next







        Return dt
    End Function

    Private Function CreateDataTbForCDR() As DataTable
        Dim dt As New DataTable
        ' GSTIN/UIN of Recipient	Invoice/Advance Receipt Number	Invoice/Advance Receipt date	Note/Refund Voucher Number	Note/Refund Voucher date	
        'Document Type	Reason For Issuing document	Place Of Supply	Note/Refund Voucher Value	Rate	Taxable Value	Cess Amount	Pre GST
        dt.Columns.Add("GSTIN/UIN of Recipient")
        dt.Columns.Add("Name of Receipt")
        dt.Columns.Add("Invoice/Advance Receipt Number")
        dt.Columns.Add("Invoice/Advance Receipt date")
        dt.Columns.Add("Note/Refund Voucher Number")
        dt.Columns.Add("Note/Refund Voucher date")
        dt.Columns.Add("Document Type")
        dt.Columns.Add("Reason For Issuing document")
        dt.Columns.Add("Place of supply")
        dt.Columns.Add("Note/Refund Voucher Value")
        dt.Columns.Add("Rate")
        dt.Columns.Add("Taxable Value")
        dt.Columns.Add("Cess Amount")
        dt.Columns.Add("Pre GST")

        'select b.voucher_no from Contacts_Tbl a,Credit_debit_hdr b where a.contact_display_name=b.cus_name and a.gst_treatment<>'Registered Business' and voucher_date between #" + txtfromdate.Text + "# and "#" + txttodate.Text + "#"

        Dim query = "select gst_no, company_name, invoice_no, invoice_dt, credit_debit_user_no, " & _
            "credit_debit_no, voucher_dt, voutype, " & _
            "reason, place_supply, refundval," & _
            " item_tax, item_amount, cess_amt, " & _
            "gst_treatment,  invtype from CD where gst_treatment='Registered Business' " & _
            "and invoice_dt between #" + obj.ConvDtFrmt(txtfromdate.Text, "MM/dd/yyyy") + "# and #" + obj.ConvDtFrmt(txttodate.Text, "MM/dd/yyyy") + "#"

        Dim data = obj.getdatatable(query)
        Dim k As Integer = 0
        For i = 0 To data.Rows.Count - 1
            dt.Rows.Add()
            dt.Rows(k)(0) = data.Rows(i).Item(0).ToString
            dt.Rows(k)(1) = data.Rows(i).Item(1).ToString
            dt.Rows(k)(2) = data.Rows(i).Item(2).ToString
            dt.Rows(k)(3) = data.Rows(i).Item(3).ToString
            dt.Rows(k)(4) = data.Rows(i).Item(4).ToString
            dt.Rows(k)(5) = data.Rows(i).Item(6).ToString
            dt.Rows(k)(6) = data.Rows(i).Item(7).ToString
            dt.Rows(k)(7) = data.Rows(i).Item(8).ToString
            dt.Rows(k)(8) = data.Rows(i).Item(9).ToString
            dt.Rows(k)(9) = data.Rows(i).Item(10).ToString
            dt.Rows(k)(10) = data.Rows(i).Item(11).ToString
            dt.Rows(k)(11) = data.Rows(i).Item(12).ToString
            dt.Rows(k)(12) = data.Rows(i).Item(13).ToString
            dt.Rows(k)(13) = ""
            k = k + 1

        Next



        Return dt

    End Function

    Private Function CreateDataTbForCDNUR() As DataTable
          Dim dt As New DataTable
        ' GSTIN/UIN of Recipient	Invoice/Advance Receipt Number	Invoice/Advance Receipt date	Note/Refund Voucher Number	Note/Refund Voucher date	
        'Document Type	Reason For Issuing document	Place Of Supply	Note/Refund Voucher Value	Rate	Taxable Value	Cess Amount	Pre GST
        dt.Columns.Add("GSTIN/UIN of Recipient")
        dt.Columns.Add("Invoice/Advance Receipt Number")
        dt.Columns.Add("Invoice/Advance Receipt date")
        dt.Columns.Add("Note/Refund Voucher Number")
        dt.Columns.Add("Note/Refund Voucher date")
        dt.Columns.Add("Document Type")
        dt.Columns.Add("Reason For Issuing document")
        dt.Columns.Add("Place of supply")
        dt.Columns.Add("Note/Refund Voucher Value")
        dt.Columns.Add("Rate")
        dt.Columns.Add("Taxable Value")
        dt.Columns.Add("Cess Amount")
        dt.Columns.Add("Pre GST")

        'select b.voucher_no from Contacts_Tbl a,Credit_debit_hdr b where a.contact_display_name=b.cus_name and a.gst_treatment<>'Registered Business' and voucher_date between #" + txtfromdate.Text + "# and "#" + txttodate.Text + "#"

        Dim query = "select gst_no, invoice_no, invoice_dt, credit_debit_user_no, " & _
            "credit_debit_no, voucher_dt, voutype, " & _
            "reason, place_supply, refundval," & _
            " item_tax, item_amount, cess_amt, " & _
            "gst_treatment,  invtype from CD where gst_treatment='UnRegistered Business' and invtype='IGST' and refund_value>=250000" & _
            "and invoice_dt between #" + obj.ConvDtFrmt(txtfromdate.Text, "MM/dd/yyyy") + "# and #" + obj.ConvDtFrmt(txttodate.Text, "MM/dd/yyyy") + "#"

        Dim data = obj.getdatatable(query)
        Dim k As Integer = 0
        For i = 0 To data.Rows.Count - 1
            dt.Rows.Add()
            dt.Rows(k)(0) = data.Rows(i).Item(0).ToString
            dt.Rows(k)(1) = data.Rows(i).Item(1).ToString
            dt.Rows(k)(2) = data.Rows(i).Item(2).ToString
            dt.Rows(k)(3) = data.Rows(i).Item(3).ToString
            dt.Rows(k)(4) = data.Rows(i).Item(4).ToString
            dt.Rows(k)(5) = data.Rows(i).Item(6).ToString
            dt.Rows(k)(6) = data.Rows(i).Item(7).ToString
            dt.Rows(k)(7) = data.Rows(i).Item(8).ToString
            dt.Rows(k)(8) = data.Rows(i).Item(9).ToString
            dt.Rows(k)(9) = data.Rows(i).Item(10).ToString
            dt.Rows(k)(10) = data.Rows(i).Item(11).ToString
            dt.Rows(k)(11) = data.Rows(i).Item(12).ToString
            dt.Rows(k)(12) = ""

            k = k + 1

        Next



        Return dt

    End Function


    Private Function CreateDataTbForADAJ() As DataTable
        Dim dt As New DataTable


        dt.Columns.Add("Place Of Supply")
        dt.Columns.Add("Rate")
        dt.Columns.Add("Gross advance Adjusted")
        dt.Columns.Add("Cess Amount")

        Dim getadvdata As New DataTable




        getadvdata = obj.getdatatable("select place_supply, tax_percent, advance_amt, cess_amt from AD where bill_flg=1 and advance_dt between #" + obj.ConvDtFrmt(txtfromdate.Text, "MM/dd/yyyy") + "# and #" + obj.ConvDtFrmt(txttodate.Text, "MM/dd/yyyy") + "#")

        For k = 0 To getadvdata.Rows.Count - 1

            dt.Rows.Add()
            dt.Rows(k)(0) = getadvdata.Rows(k).Item(0).ToString
            dt.Rows(k)(1) = getadvdata.Rows(k).Item(1).ToString
            dt.Rows(k)(2) = getadvdata.Rows(k).Item(2).ToString
            dt.Rows(k)(3) = getadvdata.Rows(k).Item(3).ToString

            k = k + 1
        Next







        Return dt
    End Function

    Private Function CreateDataTbForADAT() As DataTable


        Dim dt As New DataTable


        dt.Columns.Add("Place Of Supply")
        dt.Columns.Add("Rate")
        dt.Columns.Add("Gross advance received")
        dt.Columns.Add("Cess Amount")

        Dim getadvdata As New DataTable




        getadvdata = obj.getdatatable("select place_supply, tax_percent, advance_amt, cess_amt from AD where bill_flg=0 and advance_dt between #" + obj.ConvDtFrmt(txtfromdate.Text, "MM/dd/yyyy") + "# and #" + obj.ConvDtFrmt(txttodate.Text, "MM/dd/yyyy") + "#")

        For k = 0 To getadvdata.Rows.Count - 1

            dt.Rows.Add()
            dt.Rows(k)(0) = getadvdata.Rows(k).Item(0).ToString
            dt.Rows(k)(1) = getadvdata.Rows(k).Item(1).ToString
            dt.Rows(k)(2) = getadvdata.Rows(k).Item(2).ToString
            dt.Rows(k)(3) = getadvdata.Rows(k).Item(3).ToString

            k = k + 1
        Next







        Return dt

    End Function
    Function CreateDataTbForB2Cs() As DataTable
        Dim dt As New DataTable

        dt.Columns.Add("Type")
        dt.Columns.Add("Place Of Supply")
        dt.Columns.Add("Rate")
        dt.Columns.Add("Taxable Value")
        dt.Columns.Add("Cess Amount")
        dt.Columns.Add("E-Commerce GSTIN")
        Dim getinvdata = obj.getdatatable("select  type,place_supply, item_tax, item_amount, cess_amt, '' from B2CS where invtype='GST' and (gst_treatment='Consumer' or gst_treatment='UnRegistered Business') union" & _
                                          " select  type,place_supply, item_tax, item_amount, cess_amt, '' from B2CS where invtype='IGST' and (gst_treatment='Consumer' or gst_treatment='UnRegistered Business') and grand_total <=250000")
        Dim k = 0
            For j = 0 To getinvdata.Rows.Count - 1
               
                dt.Rows.Add()
            dt.Rows(k)(0) = getinvdata.Rows(j).Item(0).ToString
                dt.Rows(k)(1) = getinvdata.Rows(j).Item(1).ToString
                dt.Rows(k)(2) = getinvdata.Rows(j).Item(2).ToString
                dt.Rows(k)(3) = getinvdata.Rows(j).Item(3).ToString
            dt.Rows(k)(4) = getinvdata.Rows(j).Item(4).ToString
            dt.Rows(k)(5) = getinvdata.Rows(j).Item(5).ToString
                k = k + 1
        Next



        Return dt
    End Function
    Function CreateDataTbForB2CL() As DataTable
        Dim dt As New DataTable

        dt.Columns.Add("Invoice Number")
        dt.Columns.Add("Invoice date")
        dt.Columns.Add("Invoice Value")
        dt.Columns.Add("Place Of Supply")
        dt.Columns.Add("Rate")
        dt.Columns.Add("Taxable Value")
        dt.Columns.Add("Cess Amount")
        dt.Columns.Add("E-Commerce GSTIN")
        Dim listinvno As New DataTable
      
        listinvno = obj.getdatatable("select  invoice_no, user_invoice_no, invoice_dt,grand_total, place_supply, item_tax, item_amount, cess_amt, '' from B2CL where " & _
                                            "invoice_dt between #" + txtfromdate.Text + "# and" & _
                                            " #" + txttodate.Text + "#")
       
        Dim k = 0

      
        For j = 0 To listinvno.Rows.Count - 1
            dt.Rows.Add()

            dt.Rows(k)(0) = listinvno.Rows(j).Item(1).ToString
            dt.Rows(k)(1) = listinvno.Rows(j).Item(2).ToString
            dt.Rows(k)(2) = listinvno.Rows(j).Item(3).ToString
            dt.Rows(k)(3) = listinvno.Rows(j).Item(4).ToString
            dt.Rows(k)(4) = listinvno.Rows(j).Item(5).ToString
            dt.Rows(k)(5) = listinvno.Rows(j).Item(6).ToString
            dt.Rows(k)(6) = listinvno.Rows(j).Item(7).ToString
            dt.Rows(k)(7) = listinvno.Rows(j).Item(8).ToString
            k = k + 1
        Next







        Return dt
    End Function
    

    Function CreateDataTbForB2B() As DataTable
        Dim dt As New DataTable
        dt.Columns.Add("GSTIN/UIN of Recipient")
        dt.Columns.Add("Invoice Number")
        dt.Columns.Add("Invoice date")
        dt.Columns.Add("Invoice Value")
        dt.Columns.Add("Place Of Supply")
        dt.Columns.Add("Reverse Charge")
        dt.Columns.Add("Invoice Type")
        dt.Columns.Add("E-Commerce GSTIN")
        dt.Columns.Add("Rate")
        dt.Columns.Add("Taxable Value")
        dt.Columns.Add("Cess Amount")
        Dim listpurno As List(Of String) = obj.getcolumndatafromquery("select distinct invoice_no from B2B where invoice_dt between #" + txtfromdate.Text + "# and #" + txttodate.Text + "# and gst_treatment='Registered Business'")
        Dim getpurdata As New DataTable

        For j = 0 To listpurno.Count - 1
            getpurdata = obj.getdatatable("select gst_no, company_name, user_invoice_no, invoice_no, invoice_dt, grand_total, place_supply, reverse_flg, item_tax, item_amount, cess_amt from " & _
                                                   "B2B where invoice_no='" + listpurno(j) + "'")
            For i = 0 To getpurdata.Rows.Count - 1
                dt.Rows.Add()
                dt.Rows(i)(0) = getpurdata.Rows(i).Item(0).ToString
                dt.Rows(i)(1) = getpurdata.Rows(i).Item(2).ToString
                dt.Rows(i)(2) = obj.ConvDtFrmt(getpurdata.Rows(i).Item(4).ToString, "dd-MMM-yyyy")
                dt.Rows(i)(3) = getpurdata.Rows(i).Item(5).ToString
                dt.Rows(i)(4) = getpurdata.Rows(i).Item(6).ToString
                dt.Rows(i)(5) = If(getpurdata.Rows(i).Item(7).ToString = "0", "N", "Y")
                dt.Rows(i)(6) = "Regular"
                dt.Rows(i)(7) = ""
                dt.Rows(i)(8) = getpurdata.Rows(i).Item(8).ToString
                dt.Rows(i)(9) = getpurdata.Rows(i).Item(9).ToString
                dt.Rows(i)(10) = getpurdata.Rows(i).Item(10).ToString
            Next





        Next



        Return dt

    End Function
    Private Sub DateTimePicker1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DateTimePicker1.ValueChanged
        txtfromdate.Text = Me.DateTimePicker1.Value.Date.ToString("dd/MM/yyyy")
    End Sub

    Private Sub DateTimePicker2_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DateTimePicker2.ValueChanged
        txttodate.Text = Me.DateTimePicker2.Value.Date.ToString("dd/MM/yyyy")
    End Sub
End Class