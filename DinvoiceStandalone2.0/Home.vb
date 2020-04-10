Imports System.ComponentModel
Public Class Home

    Private Sub ContactsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ContactsToolStripMenuItem.Click
        Contacts.Show()
        'Contacts.TopMost = True
        Contacts.BringToFront()
        Contacts.Focus()
    End Sub

    Private Sub Home_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        'Splash.Close()
        Signin.Close()
    End Sub

    Private Sub Home_MinimumSizeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.MinimumSizeChanged

    End Sub

    Private Sub Home_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        'If FormWindowState.Minimized Then
        '    For Each frm As Form In Application.OpenForms
        '        frm.WindowState = FormWindowState.Minimized
        '    Next
        'End If
    End Sub

    Private Sub SettingsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SettingsToolStripMenuItem.Click
        Settings.Show()
        'Settings.TopMost = True
        Settings.BringToFront()
    End Sub



    Private Sub ItemsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ItemsToolStripMenuItem.Click
        Items.Show()
        Items.BringToFront()
        'Items.TopMost = True
        Items.Focus()
    End Sub

    Private Sub PurchaseBillsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PurchaseBillsToolStripMenuItem.Click
        Purchase.Show()
        Purchase.BringToFront()
        'Purchase.TopMost = True
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnpurbill.Click
        Purchase.Show()
        Purchase.BringToFront()
        'Purchase.TopMost = True
    End Sub

    Private Sub AboutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AboutToolStripMenuItem.Click
        about.Show()
        about.BringToFront()
        about.TopMost = True
    End Sub

    Private Sub AdvanceToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AdvanceToolStripMenuItem.Click
        Advance.Show()
        Advance.BringToFront()
        'Advance.TopMost = True
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnadv.Click
        Advance.Show()
        Advance.BringToFront()
        'Advance.TopMost = True
    End Sub

    Private Sub IntendToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IntendToolStripMenuItem.Click
        Indent.Show()
        Indent.BringToFront()
        'Indent.TopMost = True
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnintend.Click
        Indent.Show()
        Indent.BringToFront()
        'Indent.TopMost = True
    End Sub

    Private Sub InventoryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InventoryToolStripMenuItem.Click
        Inventory.Show()
        Inventory.BringToFront()
        'Inventory.TopMost = True
    End Sub

    Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btninven.Click
        Inventory.Show()
        Inventory.BringToFront()
        'Inventory.TopMost = True
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnquot.Click
        Quotation.Show()
        Quotation.BringToFront()
        'QuotationReport.TopMost = True
    End Sub

    Private Sub QuotationToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles QuotationToolStripMenuItem.Click
        Quotation.Show()
        Quotation.BringToFront()
        'QuotationReport.TopMost = True
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnnewinvoice.Click
        Invoice.Show()
        Invoice.BringToFront()
        'Invoice.TopMost = True
    End Sub

    Private Sub NewInvoiceToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewInvoiceToolStripMenuItem.Click
        Invoice.Show()
        Invoice.BringToFront()
        'Invoice.TopMost = True
    End Sub

    Private Sub BillOfSupplyToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BillOfSupplyToolStripMenuItem.Click
        BillOfSupply.Show()
        BillOfSupply.BringToFront()
        'BillOfSupply.TopMost = True
    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnbos.Click
        BillOfSupply.Show()
        BillOfSupply.BringToFront()
        'BillOfSupply.TopMost = True
    End Sub

    Private Sub AccountHeadsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AccountHeadsToolStripMenuItem.Click
        Accounts.Show()
        Accounts.BringToFront()
        'Accounts.TopMost = True
    End Sub

    Private Sub VoucherRecieptsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VoucherRecieptsToolStripMenuItem.Click
        VoucherReciepts.Show()
        VoucherReciepts.BringToFront()
        'VoucherReciepts.TopMost = True
    End Sub

    Private Sub VoucherPaymentToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VoucherPaymentToolStripMenuItem.Click
        VoucherPayments.Show()
        VoucherPayments.BringToFront()
        'VoucherPayments.TopMost = True
    End Sub

    Private Sub CreditDebitNoteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CreditDebitNoteToolStripMenuItem.Click
        CreditDebit.Show()
        CreditDebit.BringToFront()
        'CreditDebit.TopMost = True
    End Sub

    Private Sub InvoicesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        InvoiceRpt.Show()
        InvoiceRpt.BringToFront()
        'InvoiceRpt.TopMost = True
    End Sub

    Private Sub CustomersToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CustomersToolStripMenuItem.Click
        CustomerWiseSale.Show()
        CustomerWiseSale.BringToFront()
        'CustomerWiseSale.TopMost = True
    End Sub

    Private Sub ItemWiseSaleToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ItemWiseSaleToolStripMenuItem.Click
        ItemwiseSale.Show()
        ItemwiseSale.BringToFront()
        'ItemwiseSale.TopMost = True
    End Sub

    Private Sub CustomerVendorToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CustomerVendorToolStripMenuItem.Click
        CustomerReport.Show()
        CustomerReport.BringToFront()
        'CustomerReport.TopMost = True
    End Sub

    Private Sub ItemsToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ItemsToolStripMenuItem1.Click
        ItemsReport.Show()
        ItemsReport.BringToFront()
        'ItemsReport.TopMost = True
    End Sub

    Private Sub lnkPurBills_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkPurBills.LinkClicked
        PurchaseReport.Show()
        PurchaseReport.BringToFront()
        'PurchaseReport.TopMost = True
    End Sub
    Private Sub PurchaseBillsToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PurchaseBillsToolStripMenuItem2.Click
        PurchaseReport.Show()
        PurchaseReport.BringToFront()
        'PurchaseReport.TopMost = True
    End Sub

    Private Sub lnkVendors_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkVendors.LinkClicked
        CustomerReport.Show()
        CustomerReport.BringToFront()
        'CustomerReport.TopMost = True
    End Sub

    Private Sub SwitchCompanyToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SwitchCompanyToolStripMenuItem.Click
        Signin.Show()
        Signin.BringToFront()
        Signin.TopMost = True
    End Sub
    Private Sub AdvancesToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AdvancesToolStripMenuItem1.Click
        AdvanceReport.Show()
        AdvanceReport.BringToFront()
        'AdvanceReport.TopMost = True
    End Sub
    Private Sub IndentsToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IndentsToolStripMenuItem1.Click
        IndentReport.Show()
        IndentReport.BringToFront()
        'IndentReport.TopMost = True
    End Sub

    Private Sub lnkIndent_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkIndent.LinkClicked
        IndentReport.Show()
        IndentReport.BringToFront()
        'IndentReport.TopMost = True
    End Sub
    Private Sub QuotationsToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles QuotationsToolStripMenuItem1.Click
        QuotationRpt.Show()
        QuotationRpt.BringToFront()
        'QuotationRpt.TopMost = True
    End Sub

    Private Sub lnkQuotation_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkQuotation.LinkClicked
        QuotationRpt.Show()
        QuotationRpt.BringToFront()
        'QuotationRpt.TopMost = True
    End Sub

    Private Sub SupplyBillsToolStripMenuItem1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SupplyBillsToolStripMenuItem1.Click
        BillOfSupplyRpt.Show()
        BillOfSupplyRpt.BringToFront()
        'BillOfSupplyRpt.TopMost = True
    End Sub
    Private Sub SupplyBillsToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        BillOfSupplyRpt.Show()
        BillOfSupplyRpt.BringToFront()
        'BillOfSupplyRpt.TopMost = True
    End Sub
    Private Sub InvoicesToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InvoicesToolStripMenuItem1.Click
        InvoiceRpt.Show()
        InvoiceRpt.BringToFront()
        'InvoiceRpt.TopMost = True
    End Sub
    Private Sub VouchersToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VouchersToolStripMenuItem.Click
        VoucherRpt.Show()
        VoucherRpt.BringToFront()
    End Sub
    Private Sub lnkInvoice_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkInvoice.LinkClicked
        InvoiceRpt.Show()
        InvoiceRpt.BringToFront()
        'InvoiceRpt.TopMost = True
    End Sub

    Private Sub lnkCompanyYr_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkCompanyYr.LinkClicked
        Settings.Show()
        'Settings.TopMost = True
        Settings.BringToFront()
    End Sub
    Dim s As New SharedData
    Private Sub lnkSwitchCompany_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkSwitchCompany.LinkClicked
        Signin.Show()
        Signin.BringToFront()
        Signin.TopMost = True


        s.ClearSession()
    End Sub

    Private Sub lnkCmpProf_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkCmpProf.LinkClicked
        CmpyProfile.Show()
        CmpyProfile.TopMost = True
        CmpyProfile.BringToFront()
    End Sub

    Private Sub GSTR1ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GSTR1ToolStripMenuItem.Click
        gstr1.Show()
        'gstr1.TopMost = True
        gstr1.BringToFront()
    End Sub

    Private Sub GSTR3BToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GSTR3BToolStripMenuItem.Click
        gstr3b.Show()
        'gstr3b.TopMost = True
        gstr3b.BringToFront()
    End Sub
    Private Sub BalanceSheetToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BalanceSheetToolStripMenuItem1.Click
        BalanceSheet.Show()
        'gstr3b.TopMost = True
        BalanceSheet.BringToFront()
    End Sub

    Private Sub LedgerStatementToolStripMenuItem1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LedgerStatementToolStripMenuItem1.Click
        LedgerStatement.Show()
        'LedgerStatement.TopMost = True
        LedgerStatement.BringToFront()
    End Sub

    Private Sub DayBookToolStripMenuItem1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DayBookToolStripMenuItem1.Click
        DayBookReport.Show()
        'DayBookReport.TopMost = True
        DayBookReport.BringToFront()
    End Sub
    Private Sub PLStatementToolStripMenuItem1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PLStatementToolStripMenuItem1.Click
        ProfitLossReport.Show()
        'ProfitLossReport.TopMost = True
        ProfitLossReport.BringToFront()
    End Sub
    Private Sub GatepassToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GatepassToolStripMenuItem.Click
        Gatepass.Show()
        'Gatepass.TopMost = True
        Gatepass.BringToFront()
    End Sub

    Private Sub BarcodeGeneratorToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BarcodeGeneratorToolStripMenuItem.Click
        BarcodeGenerator.Show()
        'BarcodeGenerator.TopMost = True
        BarcodeGenerator.BringToFront()
    End Sub

    Private Sub StockSummaryToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StockSummaryToolStripMenuItem1.Click
        StockSummary.Show()
        'BarcodeGenerator.TopMost = True
        StockSummary.BringToFront()
    End Sub

    Private Sub TrialBalanceToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TrialBalanceToolStripMenuItem.Click

    End Sub
    Private Sub POSToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles POSToolStripMenuItem.Click
        MultiPOS.Show()
        'Pos.TopMost = True
        MultiPOS.BringToFront()
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnpos.Click
        MultiPOS.Show()
        'Pos.TopMost = True
        MultiPOS.BringToFront()
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btngst.Click
        gstr1.Show()
        'gstr1.TopMost = True
        gstr1.BringToFront()
    End Sub

    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnrcpt.Click
        VoucherReciepts.Show()
        'VoucherReciepts.TopMost = True
        VoucherReciepts.BringToFront()
    End Sub

    Private Sub Home_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Timer1.Start()
        Dim companydetails As New List(Of String)
        Dim obj As New ObjClass
        companydetails = obj.GetCompanyName_yr()
        Me.Text = "Welcome to d-Invoice | COMPANY NAME: " + companydetails(0) + " | FISCAL YR: " + companydetails(1) + " | USER: " + companydetails(2) + ""
       
       
        ContactsToolStripMenuItem.Visible = False
        ItemsToolStripMenuItem.Visible = False
        PurchaseBillsToolStripMenuItem.Visible = False
        AdvanceToolStripMenuItem.Visible = False
        IntendToolStripMenuItem.Visible = False
        InventoryToolStripMenuItem.Visible = False
        POSToolStripMenuItem.Visible = False
        QuotationToolStripMenuItem.Visible = False
        BillOfSupplyToolStripMenuItem.Visible = False
        NewInvoiceToolStripMenuItem.Visible = False
        GatepassToolStripMenuItem.Visible = False
        GSTFilingToolStripMenuItem.Visible = False
        AccountHeadsToolStripMenuItem.Visible = False
        VoucherRecieptsToolStripMenuItem.Visible = False
        VoucherPaymentToolStripMenuItem.Visible = False
        CreditDebitNoteToolStripMenuItem.Visible = False
        AccountsToolStripMenuItem.Visible = False
        ReportsToolStripMenuItem.Visible = False
        SettingsToolStripMenuItem.Visible = False
        FinanceReportsToolStripMenuItem.Visible = False
        btnadv.Enabled = False
        btninven.Enabled = False
        btnnewinvoice.Enabled = False
        btnquot.Enabled = False
        btnpurbill.Enabled = False
        btnbos.Enabled = False
        btnpos.Enabled = False
        btngst.Enabled = False
        btnrcpt.Enabled = False
        btnintend.Enabled = False
        rptpanel.Enabled = False
        settpnl.Enabled = False
        Panel2.Visible = False

      

        Dim softtype As String = s.getsoftwaretype()

        If softtype = "FREE" Then
            ContactsToolStripMenuItem.Visible = True
            ItemsToolStripMenuItem.Visible = True
            PurchaseBillsToolStripMenuItem.Visible = True
            AdvanceToolStripMenuItem.Visible = False
            IntendToolStripMenuItem.Visible = False
            InventoryToolStripMenuItem.Visible = True
            POSToolStripMenuItem.Visible = False
            QuotationToolStripMenuItem.Visible = False
            BillOfSupplyToolStripMenuItem.Visible = False
            NewInvoiceToolStripMenuItem.Visible = True
            GatepassToolStripMenuItem.Visible = False
            GSTFilingToolStripMenuItem.Visible = False
            AccountHeadsToolStripMenuItem.Visible = False
            VoucherRecieptsToolStripMenuItem.Visible = False
            VoucherPaymentToolStripMenuItem.Visible = False
            CreditDebitNoteToolStripMenuItem.Visible = False
            ReportsToolStripMenuItem.Visible = True
            SettingsToolStripMenuItem.Visible = True
            AccountsToolStripMenuItem.Visible = False
            IndentsToolStripMenuItem1.Visible = False
            AdvancesToolStripMenuItem1.Visible = False
            StockSummaryToolStripMenuItem1.Visible = False
            BarcodeGeneratorToolStripMenuItem.Visible = False
            SupplyBillsToolStripMenuItem1.Visible = False
            VouchersToolStripMenuItem.Visible = False
            FinanceReportsToolStripMenuItem.Visible = False
            OutStandingPayableToolStripMenuItem.Visible = False
            OutStandingReceivableToolStripMenuItem.Visible = False
            btnadv.Enabled = False
            btninven.Enabled = False
            btnnewinvoice.Enabled = True
            btnquot.Enabled = False
            btnpurbill.Enabled = True
            btnbos.Enabled = False
            btnpos.Enabled = False
            btngst.Enabled = False
            btnrcpt.Enabled = False
            btnintend.Enabled = False
            rptpanel.Enabled = True
            settpnl.Enabled = True
            lnkQuotation.Enabled = False
            lnkIndent.Enabled = False
            Panel2.Visible = True
            Label5.Text = "You are using Free version, where some features are disabled. Get Premium version by visiting www.daracorporation.com"
        End If

        If softtype = "STD" Then
            ContactsToolStripMenuItem.Visible = True
            ItemsToolStripMenuItem.Visible = True
            PurchaseBillsToolStripMenuItem.Visible = True
            AdvanceToolStripMenuItem.Visible = True
            IntendToolStripMenuItem.Visible = False
            InventoryToolStripMenuItem.Visible = True
            POSToolStripMenuItem.Visible = False
            QuotationToolStripMenuItem.Visible = False
            BillOfSupplyToolStripMenuItem.Visible = False
            NewInvoiceToolStripMenuItem.Visible = True
            GatepassToolStripMenuItem.Visible = False
            GSTFilingToolStripMenuItem.Visible = True
            AccountsToolStripMenuItem.Visible = True
            AccountHeadsToolStripMenuItem.Visible = True
            VoucherRecieptsToolStripMenuItem.Visible = True
            VoucherPaymentToolStripMenuItem.Visible = True
            CreditDebitNoteToolStripMenuItem.Visible = True
            ReportsToolStripMenuItem.Visible = True
            SettingsToolStripMenuItem.Visible = True
            FinanceReportsToolStripMenuItem.Visible = True
            OutStandingPayableToolStripMenuItem.Visible = True
            OutStandingReceivableToolStripMenuItem.Visible = True
            IndentsToolStripMenuItem1.Visible = False
            StockSummaryToolStripMenuItem1.Visible = False
            BarcodeGeneratorToolStripMenuItem.Visible = False
            SupplyBillsToolStripMenuItem1.Visible = False
            VouchersToolStripMenuItem.Visible = True
            btnadv.Enabled = True
            btninven.Enabled = True
            btnnewinvoice.Enabled = True
            btnquot.Enabled = False
            btnpurbill.Enabled = True
            btnbos.Enabled = False
            btnpos.Enabled = False
            btngst.Enabled = True
            btnrcpt.Enabled = True
            btnintend.Enabled = False
            rptpanel.Enabled = True
            settpnl.Enabled = True
            lnkQuotation.Enabled = False
            lnkIndent.Enabled = False
            Panel2.Visible = True
            Label5.Text = "You are using Standard version when some features are disabled. Get Premium version by visiting www.daracorporation.com"
        End If

        If softtype = "PREMIUM" Then
            ContactsToolStripMenuItem.Visible = True
            ItemsToolStripMenuItem.Visible = True
            PurchaseBillsToolStripMenuItem.Visible = True
            AdvanceToolStripMenuItem.Visible = True
            IntendToolStripMenuItem.Visible = True
            InventoryToolStripMenuItem.Visible = True
            POSToolStripMenuItem.Visible = True
            QuotationToolStripMenuItem.Visible = True
            BillOfSupplyToolStripMenuItem.Visible = True
            NewInvoiceToolStripMenuItem.Visible = True
            GatepassToolStripMenuItem.Visible = True
            GSTFilingToolStripMenuItem.Visible = True
            AccountHeadsToolStripMenuItem.Visible = True
            VoucherRecieptsToolStripMenuItem.Visible = True
            VoucherPaymentToolStripMenuItem.Visible = True
            CreditDebitNoteToolStripMenuItem.Visible = True
            AccountsToolStripMenuItem.Visible = True
            ReportsToolStripMenuItem.Visible = True
            SupplyBillsToolStripMenuItem1.Visible = True
            SettingsToolStripMenuItem.Visible = True
            FinanceReportsToolStripMenuItem.Visible = True
            OutStandingPayableToolStripMenuItem.Visible = True
            OutStandingReceivableToolStripMenuItem.Visible = True
            TrialBalanceToolStripMenuItem.Visible = False
            BalanceSheetToolStripMenuItem1.Visible = True
            btnadv.Enabled = True
            btninven.Enabled = True
            btnnewinvoice.Enabled = True
            btnquot.Enabled = True
            btnpurbill.Enabled = True
            btnbos.Enabled = True
            btnpos.Enabled = True
            btngst.Enabled = True
            btnrcpt.Enabled = True
            btnintend.Enabled = True
            rptpanel.Enabled = True
            settpnl.Enabled = True
            lnkIndent.Enabled = True

            Dim assrole As New List(Of String)
            assrole = obj.getcolumndatafromquery("select menus from user_roles where company_id=" + s.GetCompanyId + " and user_name='" + companydetails(2) + "'")
            For i = 0 To assrole.Count - 1
                If assrole(i) = "Contacts" Then
                    ContactsToolStripMenuItem.Visible = True

                End If
                If assrole(i) = "Items" Then
                    ItemsToolStripMenuItem.Visible = True

                End If
                If assrole(i) = "Purchase Bill" = True Then
                    PurchaseBillsToolStripMenuItem.Visible = True
                    btnpurbill.Enabled = True

                End If
                If assrole(i) = "Advance" Then
                    AdvanceToolStripMenuItem.Visible = True
                    btnadv.Enabled = True


                End If
                If assrole(i) = "Indent" Then
                    IntendToolStripMenuItem.Visible = True
                    btnintend.Enabled = True

                End If
                If assrole(i) = "Inventory" Then
                    InventoryToolStripMenuItem.Visible = True
                    btninven.Enabled = True

                End If
                If assrole(i) = "Quotation" Then

                    QuotationToolStripMenuItem.Visible = True
                    btnquot.Enabled = True

                End If
                If assrole(i) = "Bill of Supply" Then
                    BillOfSupplyToolStripMenuItem.Visible = True
                    btnbos.Enabled = True

                End If
                If assrole(i) = "Invoice" Then
                    NewInvoiceToolStripMenuItem.Visible = True
                    btnnewinvoice.Enabled = True

                End If
                If assrole(i) = "POS" Then
                    POSToolStripMenuItem.Visible = True
                    btnpos.Enabled = True

                End If
                If assrole(i) = "Gatepass" Then
                    GatepassToolStripMenuItem.Visible = True

                End If
                If assrole(i) = "Finance Main" Then
                    FinanceReportsToolStripMenuItem.Visible = True
                End If
                If assrole(i) = "Acc Head" Then
                    AccountHeadsToolStripMenuItem.Visible = True

                End If
                If assrole(i) = "Reciept" Then
                    VoucherRecieptsToolStripMenuItem.Visible = True
                    btnrcpt.Enabled = True

                End If
                If assrole(i) = "Payment" Then
                    VoucherPaymentToolStripMenuItem.Visible = True

                End If
                If assrole(i) = "Cr/Dr Note" Then
                    CreditDebitNoteToolStripMenuItem.Visible = True

                End If
                If assrole(i) = "Report Main" Then
                    ReportsToolStripMenuItem.Visible = True
                    rptpanel.Enabled = True

                End If
                If assrole(i) = "GST" Then
                    GSTFilingToolStripMenuItem.Visible = True
                    btngst.Enabled = True

                End If
                If assrole(i) = "Settings" Then
                    SettingsToolStripMenuItem.Visible = True
                    settpnl.Enabled = True
                End If
            Next

        End If




      
    End Sub

    Private Sub lnkInvoice_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkInvoice.MouseHover
        lnkInvoice.LinkColor = Color.Blue
    End Sub
    Private Sub lnkInvoice_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkInvoice.MouseLeave
        lnkInvoice.LinkColor = Color.Black
    End Sub

    Private Sub lnkCmpProf_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCmpProf.MouseHover
        lnkCmpProf.LinkColor = Color.Blue
    End Sub

    Private Sub lnkCmpProf_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCmpProf.MouseLeave
        lnkCmpProf.LinkColor = Color.Black
    End Sub

    Private Sub lnkCompanyYr_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCompanyYr.MouseHover
        lnkCompanyYr.LinkColor = Color.Blue
    End Sub

    Private Sub lnkCompanyYr_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCompanyYr.MouseLeave
        lnkCompanyYr.LinkColor = Color.Black
    End Sub

    Private Sub lnkIndent_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkIndent.MouseHover
        lnkIndent.LinkColor = Color.Blue
    End Sub

    Private Sub lnkIndent_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkIndent.MouseLeave
        lnkIndent.LinkColor = Color.Black
    End Sub

    Private Sub lnkPurBills_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkPurBills.MouseHover
        lnkPurBills.LinkColor = Color.Blue
    End Sub

    Private Sub lnkPurBills_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkPurBills.MouseLeave
        lnkPurBills.LinkColor = Color.Black
    End Sub

    Private Sub lnkSwitchCompany_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkSwitchCompany.MouseHover
        lnkSwitchCompany.LinkColor = Color.Blue
    End Sub

    Private Sub lnkSwitchCompany_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkSwitchCompany.MouseLeave
        lnkSwitchCompany.LinkColor = Color.Black
    End Sub

    Private Sub lnkVendors_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkVendors.MouseHover
        lnkVendors.LinkColor = Color.Blue
    End Sub

    Private Sub lnkVendors_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkVendors.MouseLeave
        lnkVendors.LinkColor = Color.Black
    End Sub

    Private Sub lnkQuotation_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkQuotation.MouseHover
        lnkQuotation.LinkColor = Color.Blue
    End Sub

    Private Sub lnkQuotation_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkQuotation.MouseLeave
        lnkQuotation.LinkColor = Color.Black
    End Sub

    
    Private Sub BackupToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BackupToolStripMenuItem.Click
        Dim folder As New FolderBrowserDialog
        Dim path As String
        folder.RootFolder = Environment.SpecialFolder.MyComputer
        If folder.ShowDialog() = Windows.Forms.DialogResult.OK Then
            path = folder.SelectedPath
        Else
            Exit Sub
        End If
        Dim path1 As String = Application.StartupPath
        FileCopy(path1 & "\dinvoice_db.mdb", path & "\dinvoice_db" + Format(Today, "dd-MM-yyyy") + ".dara")
        MsgBox("Backup successful")
    End Sub

    Private Sub LogoutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LogoutToolStripMenuItem.Click
        If (Not System.IO.Directory.Exists("D:\backup")) Then
            System.IO.Directory.CreateDirectory("D:\backup")
        End If
        Dim path As String = "D:\backup\dinvoice_db" + Format(Now, "dd-MM-yyyy-hh-mm-ss") + ".dara"
        Dim path1 As String = Application.StartupPath
        FileCopy(path1 & "\dinvoice_db.mdb", path)
        Me.Close()
        Signin.Close()
        Splash.Close()
    End Sub
    Protected Overrides ReadOnly Property CreateParams() As CreateParams
        Get
            Dim param As CreateParams = MyBase.CreateParams
            param.ClassStyle = param.ClassStyle Or &H200
            Return param
        End Get
    End Property

    Private Sub OutStandingReceivableToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OutStandingReceivableToolStripMenuItem.Click
        s.SetOutStandType("SALE")
        ReportScreen.Show()
        ReportScreen.BringToFront()
    End Sub

    Private Sub OutStandingPayableToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OutStandingPayableToolStripMenuItem.Click
        s.SetOutStandType("PURCHASE")
        ReportScreen.Show()
        ReportScreen.BringToFront()
    End Sub
    Dim obj As New ObjClass

    Dim j As Integer = 0
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        j = j + 1
        If j Mod 36000 = 0 Then
            obj.SKUAlert()
        End If



    End Sub

    Private Sub POSSupplyToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles POSSupplyToolStripMenuItem.Click
        MultiPOSsupply.Show()
        MultiPOSsupply.BringToFront()
    End Sub

    Private Sub PayslipToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles PayslipToolStripMenuItem.Click
        Payslip.Show()
        Payslip.BringToFront()
    End Sub

    Private Sub PayslipPrintToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles PayslipPrintToolStripMenuItem.Click
        Payslipprint.Show()
        Payslipprint.BringToFront()
    End Sub
End Class
