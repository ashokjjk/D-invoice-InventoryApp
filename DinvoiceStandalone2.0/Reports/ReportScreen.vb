Imports Microsoft.Reporting.WinForms
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class ReportScreen
    Dim obj As New ObjClass
    Dim S As New SharedData
    Dim id As String = ""
    Dim invtype As String = ""

    Private Sub ReportScreen_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        S.ClearReportinvoiceno()
        S.ClearReportsupplyno()
        S.ClearReportQuotationno()
        S.ClearReportpurchaseno()
        S.ClearReportIndentno()
        S.ClearReportAdvanceno()
        S.ClearReportVoucherno()
        S.ClearLedgerData()
        S.ClearplData()
        S.CleardbData()
        S.ClearOutStandType()
        S.ClearBSData()
        S.ClearCDData()
        S.ClearPayslipNo()
    End Sub
    Private Sub ReportScreen_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        MaximizeBox = False
        MinimizeBox = False
        Me.BringToFront()

        Dim papertype As String = obj.FindPaperFormat
        Select Case papertype
            Case Is = "ALL"
                Button3.Enabled = True
            Case Else
                Button3.Enabled = False
        End Select
        If S.GetReportinvoiceno() <> "" Then
            InvoiceReport(S.GetReportinvoiceno(), "A4")
            id = S.GetReportinvoiceno()
            invtype = "INV"
        End If
        If S.GetReportsupplyno() <> "" Then
            SupplyReport(S.GetReportsupplyno(), "A4")
            id = S.GetReportsupplyno()
            invtype = "SUP"
        End If
        If S.GetReportQuotationno() <> "" Then
            QuotationReport(S.GetReportQuotationno(), "A4")
            id = S.GetReportQuotationno()
            invtype = "QUO"
        End If
        If S.GetReportpurchaseno() <> "" Then
            PurchaseReport(S.GetReportpurchaseno(), "A4")
            id = S.GetReportpurchaseno()
            invtype = "PUR"
        End If
        If S.GetReportIndentno() <> "" Then
            IndentReport(S.GetReportIndentno())

        End If
        If S.GetReportAdvanceno() <> "" Then
            AdvanceReport(S.GetReportAdvanceno())

        End If

        If S.GetReportVoucherno() <> "" Then
            VoucherReport(S.GetReportVoucherno(), S.Type(), S.AccType())

        End If
        If S.GetContactcode() <> "" Then
            LedgerReport(S.GetContactcode(), S.fnfromdate(), S.fntodate())

        End If
        If S.fnplfromdate() <> "" Then
            PLReport(S.GetCompanyId(), S.fnplfromdate(), S.fnpltodate())

        End If
        If S.fndbfromdate() <> "" Then
            DayBookReport(S.GetCompanyId(), S.fndbfromdate(), S.fndbtodate())
        End If
        If (id = "") Then
            Panel1.Visible = False
        Else
            Panel1.Visible = True
        End If
        If S.GetOutStandType() <> "" Then
            OutStanding(S.GetOutStandType)
        End If
        If S.Getbsfromdate() <> "" Then
            BalanceSheet(S.Getbsfromdate, S.Getbstodate)
        End If
        If S.GetCDData() <> "" Then
            CreDebRpt(S.GetCDData)
        End If
        If S.GetPayslipNo() <> "" Then
            PaySlipReport(S.GetPayslipNo)
        End If

        Me.ReportViewer1.RefreshReport()
    End Sub
    Sub PaySlipReport(ByVal p1 As String)
        Try

            Dim listdata As New List(Of String)
            listdata = obj.GetMoreValueFromQuery("SELECT company_name, billing_address, billing_state, " & _
                                                 "billing_pincode, phone_no, gst_no, Monyr, employee_name, " & _
                                                 "employee_no, salarygroup_name, state, bank_name, account_no," & _
                                                 " branch_name, DOJ, PF_no, ESI_no, basic, da, hra, others," & _
                                                 " bonus, esi, pf, trs, otherdeduction, advance, netsalary, " & _
                                                 "  totearning,  totdeductions " & _
                                                 "FROM PaySlipRpt where payslip_no='" + p1 + "'", 30)



            Try


                ReportViewer1.LocalReport.ReportPath = "" + Application.StartupPath + "\PaySlip.rdlc"
               
                Dim myParam1 As New ReportParameter("companyname", listdata(0))
                ReportViewer1.LocalReport.SetParameters(myParam1)
                Dim myParam2 As New ReportParameter("companyaddr", listdata(1))
                ReportViewer1.LocalReport.SetParameters(myParam2)
                Dim myParam3 As New ReportParameter("companyphoneno", listdata(4))
                ReportViewer1.LocalReport.SetParameters(myParam3)
                Dim myParam4 As New ReportParameter("companygstno", listdata(5))
                ReportViewer1.LocalReport.SetParameters(myParam4)

                Dim myParam5 As New ReportParameter("paymonth", "Pay Slip For " + listdata(6))
                ReportViewer1.LocalReport.SetParameters(myParam5)
                Dim myParam6 As New ReportParameter("empname", listdata(7))
                ReportViewer1.LocalReport.SetParameters(myParam6)
                Dim myParam7 As New ReportParameter("empno", listdata(8))
                ReportViewer1.LocalReport.SetParameters(myParam7)
                Dim myParam8 As New ReportParameter("designation", listdata(9))
                ReportViewer1.LocalReport.SetParameters(myParam8)

                Dim myParam9 As New ReportParameter("location", listdata(10))
                ReportViewer1.LocalReport.SetParameters(myParam9)
                Dim myParam10 As New ReportParameter("bankdetails", listdata(11) + "," + listdata(12) + "," + listdata(13))
                ReportViewer1.LocalReport.SetParameters(myParam10)
                Dim myParam11 As New ReportParameter("doj", listdata(14))
                ReportViewer1.LocalReport.SetParameters(myParam11)
                Dim myParam12 As New ReportParameter("esino", listdata(16))
                ReportViewer1.LocalReport.SetParameters(myParam12)
                Dim myParam13 As New ReportParameter("pfno", listdata(15))
                ReportViewer1.LocalReport.SetParameters(myParam13)


                Dim myParam14 As New ReportParameter("basic", listdata(17))
                ReportViewer1.LocalReport.SetParameters(myParam14)
                Dim myParam15 As New ReportParameter("da", listdata(18))
                ReportViewer1.LocalReport.SetParameters(myParam15)
                Dim myParam16 As New ReportParameter("hra", listdata(19))
                ReportViewer1.LocalReport.SetParameters(myParam16)
                Dim myParam17 As New ReportParameter("others", listdata(20))
                ReportViewer1.LocalReport.SetParameters(myParam17)
                Dim myParam18 As New ReportParameter("bonus", listdata(21))
                ReportViewer1.LocalReport.SetParameters(myParam18)


                Dim myParam19 As New ReportParameter("esi", listdata(22))
                ReportViewer1.LocalReport.SetParameters(myParam19)
                Dim myParam20 As New ReportParameter("pf", listdata(23))
                ReportViewer1.LocalReport.SetParameters(myParam20)
                Dim myParam21 As New ReportParameter("tds", listdata(24))
                ReportViewer1.LocalReport.SetParameters(myParam21)
                Dim myParam22 As New ReportParameter("otherdeductions", listdata(25))
                ReportViewer1.LocalReport.SetParameters(myParam22)
                Dim myParam23 As New ReportParameter("advance", listdata(26))
                ReportViewer1.LocalReport.SetParameters(myParam23)

                Dim myParam24 As New ReportParameter("netsalary", listdata(27))
                ReportViewer1.LocalReport.SetParameters(myParam24)
                Dim myParam25 As New ReportParameter("totearning", listdata(28))
                ReportViewer1.LocalReport.SetParameters(myParam25)
                Dim myParam26 As New ReportParameter("totdeduction", listdata(29))
                ReportViewer1.LocalReport.SetParameters(myParam26)

                Dim myParam27 As New ReportParameter("words", obj.AmountInWords(listdata(27)))
                ReportViewer1.LocalReport.SetParameters(myParam27)


                




                Dim logoimg As New Logo
                Dim dr2 As Data.DataRow
                Dim dtsubreport, dtlogo As New DataTable

                Dim img As Byte() = obj.GetImage("select company_logo from company_tbl where company_id=" + SharedData.companyid + "")
                dr2 = logoimg.Tables("Image").NewRow()
                dr2("company_id") = SharedData.companyid
                dr2("company_logo") = img
                logoimg.Tables("Image").Rows.Add(dr2)
                Dim rptDataSource2 As ReportDataSource
                rptDataSource2 = New ReportDataSource("DataSet2", logoimg.Tables("Image"))

                ReportViewer1.LocalReport.Refresh()
                ReportViewer1.LocalReport.DataSources.Add(rptDataSource2)




            Catch ex As Exception

            End Try






        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Sub CreDebRpt(ByVal vouno As String)
        Try

            Dim dssub As New VoucherSubReport
            Dim logoimg As New Logo
            Dim listdata As New List(Of String)
            Dim dr1, dr2 As Data.DataRow
            Dim dtsubreport, dtlogo As New DataTable

            listdata = obj.GetMoreValueFromQuery("select company_name, billing_address, billing_city, phone_no," & _
                                                 " gst_no, credit_debit_user_no, credit_debit_no, voucher_dt, contact_name," & _
                                                 " contact_addr, contact_phone, contact_gstno, invoice_no, invoice_dt, refund_value, " & _
                                                 "ref_no, notes, voucher_type, account_head from CreditDebitRpt " & _
                                                 "where credit_debit_no='" + vouno + "'", 19)
            Dim rptDataSource2 As ReportDataSource
            Try
                dr1 = dssub.Tables("VoucherTail").NewRow()
                dr1("No") = "1"
                dr1("BillNo") = listdata(12)
                dr1("BillDate") = listdata(13)
                dr1("RefNo") = listdata(15)
                dr1("BillAmt") = listdata(14)
                dssub.Tables("VoucherTail").Rows.Add(dr1)

                Dim rptDataSource1 As New ReportDataSource
                rptDataSource1 = New ReportDataSource("DataSet1", dssub.Tables("VoucherTail"))
                ReportViewer1.ProcessingMode = ProcessingMode.Local
                ReportViewer1.LocalReport.ReportPath = "" + Application.StartupPath + "\CreditdebitNoteRpt.rdlc"
                ReportViewer1.LocalReport.DataSources.Add(rptDataSource1)

                Dim myParam1 As New ReportParameter("invoiceno", listdata(5))
                ReportViewer1.LocalReport.SetParameters(myParam1)
                Dim myParam2 As New ReportParameter("invoicedt", obj.ConvDtFrmt(listdata(7), "dd/MM/yyyy"))
                ReportViewer1.LocalReport.SetParameters(myParam2)
                Dim myParam4 As New ReportParameter("companyname", listdata(0))
                ReportViewer1.LocalReport.SetParameters(myParam4)
                Dim myParam5 As New ReportParameter("companyaddr", listdata(1))
                ReportViewer1.LocalReport.SetParameters(myParam5)
                Dim myParam6 As New ReportParameter("companyphoneno", listdata(2))
                ReportViewer1.LocalReport.SetParameters(myParam6)
                Dim myParam7 As New ReportParameter("contactname", listdata(8))
                ReportViewer1.LocalReport.SetParameters(myParam7)
                Dim myParam8 As New ReportParameter("contactbilladdr", listdata(9))
                ReportViewer1.LocalReport.SetParameters(myParam8)

                Dim myParam10 As New ReportParameter("contactgstno", listdata(11))
                ReportViewer1.LocalReport.SetParameters(myParam10)
                Dim myParam11 As New ReportParameter("contactphone", listdata(10))
                ReportViewer1.LocalReport.SetParameters(myParam11)


                Dim myParam12 As New ReportParameter("accname", listdata(18))
                ReportViewer1.LocalReport.SetParameters(myParam12)
                Dim myParam14 As New ReportParameter("grandtotal", listdata(14))
                ReportViewer1.LocalReport.SetParameters(myParam14)
                Dim myParam15 As New ReportParameter("notes", listdata(16))
                ReportViewer1.LocalReport.SetParameters(myParam15)
                Dim myParam16 As New ReportParameter("companygstno", listdata(4))
                ReportViewer1.LocalReport.SetParameters(myParam16)

                Dim bankdata As New List(Of String)
                bankdata = obj.GetMoreValueFromQuery("select bank_name,acc_name,acc_no from bankview where company_id=" + SharedData.companyid + "", 3)
             
                If listdata(18) = "Credit" Then
                    Dim myParam19 As New ReportParameter("bankname", bankdata(0))
                    ReportViewer1.LocalReport.SetParameters(myParam19)
                    Dim myParam20 As New ReportParameter("chequeno", bankdata(1))
                    ReportViewer1.LocalReport.SetParameters(myParam20)
                    Dim myParam21 As New ReportParameter("chequedate", bankdata(2))
                    ReportViewer1.LocalReport.SetParameters(myParam21)
                    Dim myParam34 As New ReportParameter("CreDebType", "Credit Note")
                    ReportViewer1.LocalReport.SetParameters(myParam34)

                Else
                    Dim myParam19 As New ReportParameter("bankname", "NIL")
                    ReportViewer1.LocalReport.SetParameters(myParam19)
                    Dim myParam20 As New ReportParameter("chequeno", "NIL")
                    ReportViewer1.LocalReport.SetParameters(myParam20)
                    Dim myParam21 As New ReportParameter("chequedate", "NIL")
                    ReportViewer1.LocalReport.SetParameters(myParam21)
                    Dim myParam34 As New ReportParameter("CreDebType", "Debit Note")
                    ReportViewer1.LocalReport.SetParameters(myParam34)
                End If
                Dim myParam29 As New ReportParameter("amountinwords", obj.AmountInWords(listdata(14)))
                ReportViewer1.LocalReport.SetParameters(myParam29)

                Dim myParam32 As New ReportParameter("companystate", "")
                ReportViewer1.LocalReport.SetParameters(myParam32)
                Dim myParam33 As New ReportParameter("companycity", listdata(3))
                ReportViewer1.LocalReport.SetParameters(myParam33)
               
                Dim img As Byte() = obj.GetImage("select company_logo from company_tbl where company_id=" + SharedData.companyid + "")
                dr2 = logoimg.Tables("Image").NewRow()
                dr2("company_id") = SharedData.companyid
                dr2("company_logo") = img
                logoimg.Tables("Image").Rows.Add(dr2)
                rptDataSource2 = New ReportDataSource("DataSet2", logoimg.Tables("Image"))

                ReportViewer1.LocalReport.Refresh()
                ReportViewer1.LocalReport.DataSources.Add(rptDataSource2)
                ReportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.Normal)


            Catch ex As Exception

            End Try






        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Sub BalanceSheet(ByVal fd As String, ByVal td As String)
        Dim dt1 As New Asset
        Dim dt2 As New Liability
        Dim dr1, dr2 As Data.DataRow
        Dim listassetacc = obj.getcolumndatafromquery("select distinct account_type from BalanceSheet where BS_Type='Asset' and voucher_dt between #" + obj.ConvDtFrmt(fd, "MM/dd/yyyy") + "# and #" + obj.ConvDtFrmt(td, "MM/dd/yyyy") + "#")
        ' Dim dtledger As DataTable = obj.getdatatable("select ")
        Dim assetbalanceAmt As Double = 0
        Dim liabalanceAmt As Double = 0
        For i = 0 To listassetacc.Count - 1
            Dim ldt = obj.getdatatable("select account_head,sum(voucher_amt) from BalanceSheet where BS_Type='Asset' and account_type='" + listassetacc(i) + "' and voucher_dt between #" + fd + "# and #" + td + "# group by account_head")
            dr1 = dt1.Tables("Asset").NewRow()
            dr1("Type") = listassetacc(i)
            dr1("Amt") = ""
            dt1.Tables("Asset").Rows.Add(dr1)
            For lj = 0 To ldt.Rows.Count - 1
                dr1 = dt1.Tables("Asset").NewRow()
                dr1("Type") = ldt.Rows(lj).Item(0).ToString
                dr1("Amt") = ldt.Rows(lj).Item(1).ToString
                assetbalanceAmt = assetbalanceAmt + CDbl(ldt.Rows(lj).Item(1).ToString)
                dt1.Tables("Asset").Rows.Add(dr1)
            Next
        Next

        Dim listliabilityacc = obj.getcolumndatafromquery("select distinct account_type from BalanceSheet where BS_Type='Liability' and voucher_dt between #" + fd + "# and #" + td + "#")

        For i = 0 To listliabilityacc.Count - 1

            Dim ldt = obj.getdatatable("select account_head,sum(voucher_amt) from BalanceSheet where BS_Type='Liability' and account_type='" + listliabilityacc(i) + "' and voucher_dt between #" + fd + "# and #" + td + "# group by account_head")
            dr2 = dt2.Tables("Liability").NewRow()
            dr2("Type") = listliabilityacc(i)
            dr2("Amt") = ""
            dt2.Tables("Liability").Rows.Add(dr2)
            For lj = 0 To ldt.Rows.Count - 1
                dr2 = dt2.Tables("Liability").NewRow()
                dr2("Type") = ldt.Rows(lj).Item(0).ToString
                dr2("Amt") = ldt.Rows(lj).Item(1).ToString
                liabalanceAmt = liabalanceAmt + CDbl(ldt.Rows(lj).Item(1).ToString)
                dt2.Tables("Liability").Rows.Add(dr2)
            Next
           
        Next
        If assetbalanceAmt > liabalanceAmt Then
            dr2 = dt2.Tables("Liability").NewRow()
            dr2("Type") = "Equity"
            dr2("Amt") = ""
            dt2.Tables("Liability").Rows.Add(dr2)


            Dim listequityacc = obj.getcolumndatafromquery("select distinct account_type from BalanceSheet where BS_Type='Equity' and voucher_dt between #" + fd + "# and #" + td + "#")

            For i = 0 To listequityacc.Count - 1

                Dim ldt = obj.getdatatable("select account_head,sum(voucher_amt) from BalanceSheet where BS_Type='Equity' and account_type='" + listequityacc(i) + "' and voucher_dt between #" + fd + "# and #" + td + "# group by account_head")
                dr2 = dt2.Tables("Liability").NewRow()
                dr2("Type") = listliabilityacc(i)
                dr2("Amt") = ""
                dt2.Tables("Liability").Rows.Add(dr2)
                For lj = 0 To ldt.Rows.Count - 1
                    dr2 = dt2.Tables("Liability").NewRow()
                    dr2("Type") = ldt.Rows(lj).Item(0).ToString
                    dr2("Amt") = ldt.Rows(lj).Item(1).ToString
                    liabalanceAmt = liabalanceAmt + CDbl(ldt.Rows(lj).Item(1).ToString)
                    dt2.Tables("Liability").Rows.Add(dr2)
                Next

            Next
            dr2 = dt2.Tables("Liability").NewRow()
            dr2("Type") = "ShareHolder Equity"
            dr2("Amt") = assetbalanceAmt - liabalanceAmt
            dt2.Tables("Liability").Rows.Add(dr2)
        Else
            MsgBox("Liability is Greater Than Asset , Balance Sheet Don't be Created", MsgBoxStyle.Critical)
            Exit Sub
        End If

        Dim rptDataSource1, rptDataSource2, rptDataSource3 As ReportDataSource



        rptDataSource1 = New ReportDataSource("DataSet1", dt1.Tables("Asset"))
        rptDataSource3 = New ReportDataSource("DataSet3", dt2.Tables("Liability"))
        ReportViewer1.ProcessingMode = ProcessingMode.Local
        ReportViewer1.LocalReport.ReportPath = "" + Application.StartupPath + "\BalanceSheet.rdlc"
        Dim img As Byte() = obj.GetImage("select company_logo from company_tbl where company_id=" + SharedData.companyid + "")
        Dim logoimg As New Logo
        dr2 = logoimg.Tables("Image").NewRow()
        dr2("company_id") = SharedData.companyid
        dr2("company_logo") = img
        logoimg.Tables("Image").Rows.Add(dr2)
        rptDataSource2 = New ReportDataSource("DataSet2", logoimg.Tables("Image"))

        Dim listdata = obj.GetMoreValueFromQuery("select company_name,billing_address,phone_no,gst_no " & _
                                         "from company_tbl where company_id=" + SharedData.companyid + "", 4)

        Try
            Dim myParam7 As New ReportParameter("companyname", listdata(0))
            ReportViewer1.LocalReport.SetParameters(myParam7)
            Dim myParam8 As New ReportParameter("companyaddr", listdata(1))
            ReportViewer1.LocalReport.SetParameters(myParam8)
            Dim myParam9 As New ReportParameter("companyphoneno", listdata(2))
            ReportViewer1.LocalReport.SetParameters(myParam9)
            Dim myParam11 As New ReportParameter("companygstno", listdata(3))
            ReportViewer1.LocalReport.SetParameters(myParam11)
            Dim myParam12 As New ReportParameter("balanceamount", assetbalanceAmt)
            ReportViewer1.LocalReport.SetParameters(myParam12)
            Dim myParam13 As New ReportParameter("fromdate", fd)
            ReportViewer1.LocalReport.SetParameters(myParam13)
            Dim myParam14 As New ReportParameter("todate", td)
            ReportViewer1.LocalReport.SetParameters(myParam14)
            ReportViewer1.LocalReport.Refresh()
            ReportViewer1.LocalReport.DataSources.Add(rptDataSource1)
            ReportViewer1.LocalReport.DataSources.Add(rptDataSource2)
            ReportViewer1.LocalReport.DataSources.Add(rptDataSource3)
            ReportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.Normal)
        Catch ex As Exception

        End Try
    End Sub
    Sub OutStanding(ByVal type As String)
        Dim dt As New OutStandingDS
        Dim dr1, dr2 As Data.DataRow
        Dim dtledger As DataTable = obj.getdatatable("select company_name, user_invoice_no, invoice_dt, ref_no, total_tax, total_cess, grand_total from OutStanding" & _
                                                     " where company_id=" + SharedData.companyid + " and type='" + type + "' order by invoice_dt")

        For i = 0 To dtledger.Rows.Count - 1

            dr1 = dt.Tables("OutStandingDS").NewRow()
            dr1("SNo") = i + 1
            dr1("cusname") = dtledger.Rows(i).Item(0).ToString
            dr1("invno") = dtledger.Rows(i).Item(1).ToString
            dr1("invdt") = obj.ConvDtFrmt(dtledger.Rows(i).Item(2).ToString, "dd/MM/yyyy")
            dr1("refno") = dtledger.Rows(i).Item(3).ToString
            dr1("tax") = dtledger.Rows(i).Item(4).ToString
            dr1("cess") = dtledger.Rows(i).Item(5).ToString
            dr1("amt") = dtledger.Rows(i).Item(6).ToString
            dt.Tables("OutStandingDS").Rows.Add(dr1)
        Next


        Dim rptDataSource1, rptDataSource2 As ReportDataSource



        rptDataSource1 = New ReportDataSource("DataSet1", dt.Tables("OutStandingDS"))
        ReportViewer1.ProcessingMode = ProcessingMode.Local
        ReportViewer1.LocalReport.ReportPath = "" + Application.StartupPath + "\OutStandingRpt.rdlc"
        Dim img As Byte() = obj.GetImage("select company_logo from company_tbl where company_id=" + SharedData.companyid + "")
        Dim logoimg As New Logo
        dr2 = logoimg.Tables("Image").NewRow()
        dr2("company_id") = SharedData.companyid
        dr2("company_logo") = img
        logoimg.Tables("Image").Rows.Add(dr2)
        rptDataSource2 = New ReportDataSource("DataSet2", logoimg.Tables("Image"))

        Dim listdata = obj.GetMoreValueFromQuery("select company_name,billing_address,phone_no,gst_no " & _
                                         "from company_tbl where company_id=" + SharedData.companyid + "", 4)

        Try
            Dim myParam7 As New ReportParameter("companyname", listdata(0))
            ReportViewer1.LocalReport.SetParameters(myParam7)
            Dim myParam8 As New ReportParameter("companyaddr", listdata(1))
            ReportViewer1.LocalReport.SetParameters(myParam8)
            Dim myParam9 As New ReportParameter("companyphoneno", listdata(2))
            ReportViewer1.LocalReport.SetParameters(myParam9)
            Dim myParam11 As New ReportParameter("companygstno", listdata(3))
            ReportViewer1.LocalReport.SetParameters(myParam11)
            Dim myParam12 As New ReportParameter("type", If(type = "SALE", "OutStanding Receivables", "OutStanding Payable"))
            ReportViewer1.LocalReport.SetParameters(myParam12)
            Dim myParam13 As New ReportParameter("totamt", obj.GetOneValueFromQuery("select sum(grand_total) from OutStanding where company_id=" + SharedData.companyid + " and type='" + type + "'"))
            ReportViewer1.LocalReport.SetParameters(myParam13)
            ReportViewer1.LocalReport.Refresh()
            ReportViewer1.LocalReport.DataSources.Add(rptDataSource1)
            ReportViewer1.LocalReport.DataSources.Add(rptDataSource2)
            ReportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.Normal)
        Catch ex As Exception

        End Try
    End Sub

    Sub DayBookReport(ByVal cid As String, ByVal fd As String, ByVal td As String)
        Dim dt As New Ledger
        Dim dr1, dr2 As Data.DataRow
        Dim dtledger As DataTable = obj.getdatatable("select dt,notes,	voutype,	invoice_no,	debit,	credit from DayBookRpt where dt between #" + fd + "# and #" + td + "# and company_id=" + cid + " order by dt")
        For i = 0 To dtledger.Rows.Count - 1
            dr1 = dt.Tables("Ledger").NewRow()
            dr1("Date") = obj.ConvDtFrmt(dtledger.Rows(i).Item(0).ToString, "dd/MM/yyyy")
            dr1("Particulars") = dtledger.Rows(i).Item(1).ToString
            dr1("VoucherType") = dtledger.Rows(i).Item(2).ToString
            dr1("VoucherNo") = dtledger.Rows(i).Item(3).ToString
            dr1("Debit") = dtledger.Rows(i).Item(4).ToString
            dr1("Credit") = dtledger.Rows(i).Item(5).ToString
            dt.Tables("Ledger").Rows.Add(dr1)
        Next


        Dim rptDataSource1, rptDataSource2 As ReportDataSource



        rptDataSource1 = New ReportDataSource("DataSet1", dt.Tables("Ledger"))
        ReportViewer1.ProcessingMode = ProcessingMode.Local
        ReportViewer1.LocalReport.ReportPath = "" + Application.StartupPath + "\DayBookRpt.rdlc"


        Dim debit = obj.GetOneValueFromQuery("select sum(credit) from DayBookRpt where  " & _
                                             " dt between #" + fd + "# and #" + td + "# and company_id=" + cid + "")
        Dim myParam1 As New ReportParameter("Income", debit)
        ReportViewer1.LocalReport.SetParameters(myParam1)
        Dim myParam4 As New ReportParameter("Expense", obj.GetOneValueFromQuery("select sum(debit) from DayBookRpt" & _
                                             " where  dt between #" + fd + "# and #" + td + "#" & _
                                             " and company_id=" + cid + ""))
        ReportViewer1.LocalReport.SetParameters(myParam4)

        Dim img As Byte() = obj.GetImage("select company_logo from company_tbl where company_id=" + SharedData.companyid + "")
        Dim logoimg As New Logo
        dr2 = logoimg.Tables("Image").NewRow()
        dr2("company_id") = SharedData.companyid
        dr2("company_logo") = img
        logoimg.Tables("Image").Rows.Add(dr2)
        rptDataSource2 = New ReportDataSource("DataSet2", logoimg.Tables("Image"))

        Dim listdata = obj.GetMoreValueFromQuery("select company_name,billing_address,phone_no,gst_no " & _
                                         "from company_tbl where company_id=" + SharedData.companyid + "", 4)

        Try
            Dim myParam7 As New ReportParameter("companyname", listdata(0))
            ReportViewer1.LocalReport.SetParameters(myParam7)
            Dim myParam8 As New ReportParameter("companyaddr", listdata(1))
            ReportViewer1.LocalReport.SetParameters(myParam8)
            Dim myParam9 As New ReportParameter("companyphoneno", listdata(2))
            ReportViewer1.LocalReport.SetParameters(myParam9)
            Dim myParam11 As New ReportParameter("companygstno", listdata(3))
            ReportViewer1.LocalReport.SetParameters(myParam11)

            Dim myParam13 As New ReportParameter("fromdate", fd)
            ReportViewer1.LocalReport.SetParameters(myParam13)
            Dim myParam14 As New ReportParameter("todate", td)
            ReportViewer1.LocalReport.SetParameters(myParam14)


            Dim bankdata = obj.GetOneValueFromQuery("select sum(bank_closebalance) from bank_tbl where company_id=" + SharedData.companyid + "")
            Dim cashdata = obj.GetOneValueFromQuery("select pettycash_closingbalance from bank_tbl where company_id=" + SharedData.companyid + "")

            Dim myParam15 As New ReportParameter("bankcash", bankdata)
            ReportViewer1.LocalReport.SetParameters(myParam15)
            Dim myParam16 As New ReportParameter("pettycash", cashdata)
            ReportViewer1.LocalReport.SetParameters(myParam16)


           


            ReportViewer1.LocalReport.Refresh()
            ReportViewer1.LocalReport.DataSources.Add(rptDataSource1)
            ReportViewer1.LocalReport.DataSources.Add(rptDataSource2)
            ReportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.Normal)
        Catch ex As Exception

        End Try
    End Sub

    Sub PLReport(ByVal cid As String, ByVal fd As String, ByVal td As String)
        Dim dt As New Ledger
        Dim dr1, dr2 As Data.DataRow
        Dim dtledger As DataTable = obj.getdatatable("select voucher_dt, acctype,  voutype, voucher_no, total_amt from ProfitLossRpt where voucher_dt between #" + fd + "# and #" + td + "# and company_id=" + cid + " order by voucher_dt")
        For i = 0 To dtledger.Rows.Count - 1
            dr1 = dt.Tables("Ledger").NewRow()
            dr1("Date") = obj.ConvDtFrmt(dtledger.Rows(i).Item(0).ToString, "dd/MM/yyyy")
            dr1("Particulars") = dtledger.Rows(i).Item(1).ToString
            dr1("VoucherType") = dtledger.Rows(i).Item(2).ToString
            dr1("VoucherNo") = dtledger.Rows(i).Item(3).ToString
            dr1("Debit") = If(dtledger.Rows(i).Item(2).ToString = "Sale", dtledger.Rows(i).Item(4).ToString, "0")
            dr1("Credit") = If(dtledger.Rows(i).Item(2).ToString = "Purchase", dtledger.Rows(i).Item(4).ToString, "0")
            dt.Tables("Ledger").Rows.Add(dr1)
        Next


        Dim rptDataSource1, rptDataSource2 As ReportDataSource



        rptDataSource1 = New ReportDataSource("DataSet1", dt.Tables("Ledger"))
        ReportViewer1.ProcessingMode = ProcessingMode.Local
        ReportViewer1.LocalReport.ReportPath = "" + Application.StartupPath + "\ProfitLossRpt.rdlc"

      
        Dim debit = obj.GetOneValueFromQuery("select sum(total_amt) from ProfitLossRpt where voutype='Sale' and " & _
                                             " voucher_dt between #" + fd + "# and #" + td + "# and company_id=" + cid + "")
                Dim myParam1 As New ReportParameter("Income", debit)
                ReportViewer1.LocalReport.SetParameters(myParam1)
        Dim myParam4 As New ReportParameter("Expense", obj.GetOneValueFromQuery("select sum(total_amt) from ProfitLossRpt" & _
                                             " where voutype='Purchase'  and voucher_dt between #" + fd + "# and #" + td + "#" & _
                                             " and company_id=" + cid + ""))
                ReportViewer1.LocalReport.SetParameters(myParam4)

        Dim img As Byte() = obj.GetImage("select company_logo from company_tbl where company_id=" + SharedData.companyid + "")
        Dim logoimg As New Logo
        dr2 = logoimg.Tables("Image").NewRow()
        dr2("company_id") = SharedData.companyid
        dr2("company_logo") = img
        logoimg.Tables("Image").Rows.Add(dr2)
        rptDataSource2 = New ReportDataSource("DataSet2", logoimg.Tables("Image"))

        Dim listdata = obj.GetMoreValueFromQuery("select company_name,billing_address,phone_no,gst_no " & _
                                         "from company_tbl where company_id=" + SharedData.companyid + "", 4)

        Try
            Dim myParam7 As New ReportParameter("companyname", listdata(0))
            ReportViewer1.LocalReport.SetParameters(myParam7)
            Dim myParam8 As New ReportParameter("companyaddr", listdata(1))
            ReportViewer1.LocalReport.SetParameters(myParam8)
            Dim myParam9 As New ReportParameter("companyphoneno", listdata(2))
            ReportViewer1.LocalReport.SetParameters(myParam9)
            Dim myParam11 As New ReportParameter("companygstno", listdata(3))
            ReportViewer1.LocalReport.SetParameters(myParam11)

            Dim myParam13 As New ReportParameter("fromdate", fd)
            ReportViewer1.LocalReport.SetParameters(myParam13)
            Dim myParam14 As New ReportParameter("todate", td)
            ReportViewer1.LocalReport.SetParameters(myParam14)

            ReportViewer1.LocalReport.Refresh()
            ReportViewer1.LocalReport.DataSources.Add(rptDataSource1)
            ReportViewer1.LocalReport.DataSources.Add(rptDataSource2)
            ReportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.Normal)
        Catch ex As Exception

        End Try
    End Sub
    Sub VoucherReport(ByVal vouno As String, ByVal type As String, ByVal acctype As String)
        Try

            Dim dssub As New VoucherSubReport
            Dim logoimg As New Logo
            Dim listdata As New List(Of String)
            Dim dr1, dr2 As Data.DataRow
            Dim dtsubreport, dtlogo As New DataTable

            Select Case acctype
                Case Is = "WS"
                    Select Case type
                        Case Is = "Sale"
                            ReportViewer1.LocalReport.ReportPath = "" + Application.StartupPath + "\VchrRcptOnAccRpt.rdlc"
                        Case Is = "Purchase"
                            ReportViewer1.LocalReport.ReportPath = "" + Application.StartupPath + "\VchrPayOnAccRpt.rdlc"
                    End Select
                Case Is = "B2B"

                    Select Case type
                        Case Is = "Sale"
                            ReportViewer1.LocalReport.ReportPath = "" + Application.StartupPath + "\VchrRcptBillWiseRpt.rdlc"
                            dtsubreport = obj.getdatatable("select user_invoice_no, invoice_dt, ref_no, grand_total from VoucherSaleSubReport where voucher_no='" + vouno + "'")
                        Case Is = "Purchase"
                            ReportViewer1.LocalReport.ReportPath = "" + Application.StartupPath + "\VchrPayBillWiseRpt.rdlc"
                            dtsubreport = obj.getdatatable("select user_purchase_no, purchase_dt, ref_no, grand_total from VoucherPaySubReport where voucher_no='" + vouno + "'")
                    End Select
                    For i = 0 To dtsubreport.Rows.Count - 1
                        dr1 = dssub.Tables("VoucherTail").NewRow()
                        dr1("No") = i + 1
                        dr1("BillNo") = dtsubreport.Rows(i).Item(0).ToString
                        dr1("BillDate") = obj.ConvDtFrmt(dtsubreport.Rows(i).Item(1).ToString, "dd/MM/yyyy")
                        dr1("RefNo") = dtsubreport.Rows(i).Item(2).ToString
                        dr1("BillAmt") = dtsubreport.Rows(i).Item(3).ToString
                        dssub.Tables("VoucherTail").Rows.Add(dr1)
                    Next
                    Dim rptDataSource1 As New ReportDataSource
                    rptDataSource1 = New ReportDataSource("DataSet1", dssub.Tables("VoucherTail"))
                    ReportViewer1.ProcessingMode = ProcessingMode.Local
                    ReportViewer1.LocalReport.DataSources.Add(rptDataSource1)
            End Select

            listdata = obj.GetMoreValueFromQuery("select comp_name," & _
                                               "  comp_addr,billing_city," & _
                                               " comp_phone_no, comp_gst_no," & _
                                               " voucher_user_no, voucher_dt,cont_name," & _
                                               " cont_addr,cont_phone_no," & _
                                               "  cont_gst_no, account_head, voucher_amt," & _
                                               " tds_percent,total_amt, notes, voucher_no, company_id," & _
                                               " contact_no,credit_debit_bank,cheque_no,cheque_dt,billing_state " & _
                                               "from VoucherMainReport where voucher_no='" + vouno + "'", 23)
            Dim rptDataSource2 As ReportDataSource
            Try


                Dim myParam1 As New ReportParameter("invoiceno", listdata(5))
                ReportViewer1.LocalReport.SetParameters(myParam1)
                Dim myParam2 As New ReportParameter("invoicedt", obj.ConvDtFrmt(listdata(6), "dd/MM/yyyy"))
                ReportViewer1.LocalReport.SetParameters(myParam2)
                Dim myParam4 As New ReportParameter("companyname", listdata(0))
                ReportViewer1.LocalReport.SetParameters(myParam4)
                Dim myParam5 As New ReportParameter("companyaddr", listdata(1))
                ReportViewer1.LocalReport.SetParameters(myParam5)
                Dim myParam6 As New ReportParameter("companyphoneno", listdata(3))
                ReportViewer1.LocalReport.SetParameters(myParam6)
                Dim myParam7 As New ReportParameter("contactname", listdata(7))
                ReportViewer1.LocalReport.SetParameters(myParam7)
                Dim myParam8 As New ReportParameter("contactbilladdr", listdata(8))
                ReportViewer1.LocalReport.SetParameters(myParam8)

                Dim myParam10 As New ReportParameter("contactgstno", listdata(10))
                ReportViewer1.LocalReport.SetParameters(myParam10)
                Dim myParam11 As New ReportParameter("contactphone", listdata(9))
                ReportViewer1.LocalReport.SetParameters(myParam11)


                Dim myParam12 As New ReportParameter("accname", listdata(11))
                ReportViewer1.LocalReport.SetParameters(myParam12)
                Dim myParam14 As New ReportParameter("grandtotal", listdata(14))
                ReportViewer1.LocalReport.SetParameters(myParam14)
                Dim myParam15 As New ReportParameter("notes", listdata(15))
                ReportViewer1.LocalReport.SetParameters(myParam15)
                Dim myParam16 As New ReportParameter("companygstno", listdata(10))
                ReportViewer1.LocalReport.SetParameters(myParam16)

                Dim bankdata As String
                bankdata = If(listdata(19) = "", "", obj.GetOneValueFromQuery("select bank_name from bank_tbl where ID=" + listdata(19) + ""))
                Dim myParam19 As New ReportParameter("bankname", bankdata)
                ReportViewer1.LocalReport.SetParameters(myParam19)
                If bankdata = "" Then
                    Dim myParam20 As New ReportParameter("chequeno", "")
                    ReportViewer1.LocalReport.SetParameters(myParam20)
                    Dim myParam21 As New ReportParameter("chequedate", "")
                    ReportViewer1.LocalReport.SetParameters(myParam21)
                Else
                    Dim myParam20 As New ReportParameter("chequeno", listdata(20))
                    ReportViewer1.LocalReport.SetParameters(myParam20)
                    Dim myParam21 As New ReportParameter("chequedate", listdata(21))
                    ReportViewer1.LocalReport.SetParameters(myParam21)
                End If
                Dim myParam29 As New ReportParameter("amountinwords", obj.AmountInWords(listdata(14)))
                ReportViewer1.LocalReport.SetParameters(myParam29)

                Dim myParam32 As New ReportParameter("companystate", listdata(22))
                ReportViewer1.LocalReport.SetParameters(myParam32)
                Dim myParam33 As New ReportParameter("companycity", listdata(2))
                ReportViewer1.LocalReport.SetParameters(myParam33)
                Dim img As Byte() = obj.GetImage("select company_logo from company_tbl where company_id=" + listdata(17) + "")
                dr2 = logoimg.Tables("Image").NewRow()
                dr2("company_id") = listdata(17)
                dr2("company_logo") = img
                logoimg.Tables("Image").Rows.Add(dr2)
                rptDataSource2 = New ReportDataSource("DataSet2", logoimg.Tables("Image"))

                ReportViewer1.LocalReport.Refresh()
                ReportViewer1.LocalReport.DataSources.Add(rptDataSource2)
                ReportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.Normal)


            Catch ex As Exception

            End Try






        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Sub InvoiceHTMLReport(ByVal s As String)
        Try
            Dim dssub As New SubReport
            Dim listdata As New List(Of String)
            Dim dr1 As Data.DataRow
            Dim dtsubreport As New DataTable
            dtsubreport = obj.getdatatable("select item_name, gst_id, uom, item_qty, item_rate, item_disc, item_amount,item_tax,item_cess,tax_amt,cess_amt from InvoiceSubReport where invoice_no='" + s + "'")
            For i = 0 To dtsubreport.Rows.Count - 1
                dr1 = dssub.Tables("InvoiceTail").NewRow()
                dr1("No") = i + 1
                dr1("Name") = dtsubreport.Rows(i).Item(0).ToString
                dr1("HSNSAC") = dtsubreport.Rows(i).Item(1).ToString
                dr1("UOM") = dtsubreport.Rows(i).Item(2).ToString
                dr1("Qty") = dtsubreport.Rows(i).Item(3).ToString
                dr1("Rate") = dtsubreport.Rows(i).Item(4).ToString
                dr1("discpercent") = dtsubreport.Rows(i).Item(5).ToString
                dr1("Amount") = dtsubreport.Rows(i).Item(6).ToString
                dr1("taxpercent") = dtsubreport.Rows(i).Item(7).ToString
                dr1("TotalAmt") = (CDbl(dtsubreport.Rows(i).Item(6).ToString) + CDbl(dtsubreport.Rows(i).Item(9).ToString) + CDbl(dtsubreport.Rows(i).Item(10).ToString)).ToString
                dssub.Tables("InvoiceTail").Rows.Add(dr1)
            Next
            listdata = obj.GetMoreValueFromQuery("select user_invoice_no, invoice_dt, " & _
                                               "ref_no,  billing_state," & _
                                               " pan_no, comp_company_name, " & _
                                               "comp_billing_address, billing_city, " & _
                                               "billing_state, comp_phone_no," & _
                                               "  comp_gst_no, company_name," & _
                                               "  cont_billing_address,ship_address, " & _
                                               " cont_gst_no, cont_place_supply, " & _
                                               "cont_phone_no, email_id, customer_notes," & _
                                               " sub_total, overall_disc_amt,total_tax," & _
                                               " shpcost_amt,advance_flg, roundoff_amt," & _
                                               " grand_total,reverse_flg,company_id," & _
                                               " invoice_no, contact_no " & _
                                               "from InvoiceMainReport where invoice_no='" + s + "'", 30)

            Dim StrHTML As String

            StrHTML = "<html>" & _
"<head>" & _
 "   <title></title>" & _
  "  <style type ='text/css' >" & _
   " .page_layout{width:210mm; height:277mm; border:1px solid black; position:absolute; top:0mm; left:0mm; font-family:Arial;}" & _
   " .header_layout{width:200mm; height:60mm; position:absolute; top:0mm; left:5mm; font-family:Arial;  }" & _
   " .heading{ position:absolute; top:0mm; left:90mm; font-size:15px; font-weight:bold;  }" & _
   " .additional_text{position:absolute; top:15mm; left:87mm; font-size:10px; }" & _
   " .invno_dtls{position:absolute; top:5mm; right:0mm; font-size:13px; }" & _
   " .company_logo{ width:30mm; height:25mm; position:absolute; top: 1mm; left:1mm; background:url('" + listdata(27) + ".jpg'); background-repeat:no-repeat;   }" & _
   " .company_dtls{ position:absolute; top:27mm; left:0mm; font-family:Arial; width:66mm; height:33mm; font-size:11px; border:1px solid black; border-right:none; border-bottom :none; }" & _
   " .company_name{ font-weight:bold; font-size:14px; } p { margin:5px; }      " & _
   " .billedto_dtls{position:absolute; top:27mm; left:66mm; font-family:Arial; width:66mm; height:33mm; font-size:11px; border:1px solid black; border-right:none; border-bottom :none;  }" & _
   " .shippedto_dtls{position:absolute; top:27mm; left:132mm; font-family:Arial; width:67mm; height:33mm; font-size:11px; border:1px solid black; border-bottom :none; }" & _
   " .item_layout{ position:absolute; top: 60mm; left: 5mm; height:147mm; width:199mm; font-family:Arial; font-size:11px; }" & _
   " .item_table_layout{ position:absolute; left:0mm; top:0mm; width:199.5mm; height:147mm; border-collapse:collapse;  }    " & _
   " .item_table_layout td{ border:1px solid black; } .item_table_layout tr:first-child{ height:5mm; }" & _
   " .item_table_layout tr:first-child{ font-size:12px; text-align:center; font-weight:bold; border-top:none;    }" & _
   " .subtotal_layout{ position:absolute; top:147mm; left:99.7mm; width:100mm; height:45.3mm; font-size:12px; border:1px solid black; border-top:none; border-left:none; }" & _
   " .taxwords_layout{position:absolute; top:147mm; left:0mm; width:100mm; font-size:11px; border:1px solid black; border-top:none;}" & _
   " .taxwords_layout td:first-child{ width:25mm;}" & _
   " .authorized_layout{position:absolute; bottom:0mm; right:10mm; font-size:11px;}.authorized_layout table tr:first-child {line-height:20mm;  }.authorized_layout table td:last-child {text-align:center; }" & _
   " .reverse_charge{position:absolute; bottom:15mm; left:5mm; font-weight:bold; font-size:13px;  }" & _
   " .notifications_layout{position:absolute; bottom:0mm; left:5mm; width:100mm; font-size:11px;  }" & _
   " </style>" & _
"</head>" & _
"<body>" & _
"<div class='page_layout'>" & _
"<div class='header_layout' >" & _
"<div class='heading'><u>TAX INVOICE</u></div>" & _
"<div class='company_logo'></div>" & _
"<div class='additional_text'>"


            Dim GStType As String = If(listdata(8) = listdata(15), "GST", "IGST")
            StrHTML = StrHTML + "<table>" & _
"<tr><td>PAN</td><td>:</td><td>" + listdata(4) + "</td></tr>" & _
"</table></div>" & _
"<div class='invno_dtls' >" & _
"<table>" & _
"<tr><td><b>Invoice No</b></td><td>:</td><td><b>" + listdata(0) + "</b></td></tr>" & _
"<tr><td>Date</td><td>:</td><td>" + listdata(1) + "</td></tr>" & _
"<tr><td>Place of Supply</td><td>:</td><td>" + listdata(3) + "</td></tr>" & _
"<tr><td>Ref No #</td><td>:</td><td>" + listdata(2) + "</td></tr>" & _
"</table>" & _
"</div>" & _
"<div class='company_dtls'>" & _
"<div class='company_name'>" & _
"" + listdata(5) + "<br />" & _
"</div>" & _
"<p>" + listdata(6) + "<br />" & _
"State : " + listdata(8) + "<br />" & _
"Phone No: " + listdata(9) + "<br />" & _
"<b>GST No: " + listdata(10) + "</b>" & _
"</div>" & _
"<div class='billedto_dtls'>" & _
"<u>Billed To</u><br />" & _
"<div class='company_name'>" & _
"" + listdata(11) + "<br />" & _
"</div>" & _
"<p>" + listdata(12) + "<br />" & _
"State : " + listdata(15) + "<br />" & _
"Phone No: " + listdata(16) + "<br />" & _
"Mail Id : " + listdata(17) + "<br />" & _
"<b>GST No: " + listdata(14) + "</b>" & _
"</div>" & _
"<div class='shippedto_dtls'>" & _
"<u>Shipped To</u><br />" & _
"<div class='company_name'>" & _
"" + listdata(11) + "<br />" & _
"</div>" & _
"<p>" + listdata(13) + "<br />" & _
"State : " + listdata(15) + "<br />" & _
"Phone No:" + listdata(16) + "<br />" & _
"            Mail(Id) : " + listdata(17) + "" & _
"</div>" & _
"</div>" & _
"<div class='item_layout'>" & _
"<table class='item_table_layout'>" & _
"<tr><td>No</td><td>Item Name</td><td>HSN/SAC</td><td>UOM</td><td>Qty</td><td>Rate</td><td>Disc (%)</td><td>TaxableValue</td><td>Tax(%)</td><td>Total &#8377;</td></tr>"
            For i = 0 To dssub.Tables("InvoiceTail").Rows.Count - 1
                StrHTML = StrHTML + "<tr style='vertical-align:top; '><td>" + dssub.Tables("InvoiceTail").Rows(i).Item(0).ToString + "</td><td>" + dssub.Tables("InvoiceTail").Rows(i).Item(1).ToString + "<br />" & _
"</td><td>" + dssub.Tables("InvoiceTail").Rows(i).Item(2).ToString + "</td><td>" + dssub.Tables("InvoiceTail").Rows(i).Item(3).ToString + "</td><td>" + dssub.Tables("InvoiceTail").Rows(i).Item(4).ToString + "</td><td>" + dssub.Tables("InvoiceTail").Rows(i).Item(5).ToString + "" & _
"</td><td>" + dssub.Tables("InvoiceTail").Rows(i).Item(6).ToString + "</td><td>" + dssub.Tables("InvoiceTail").Rows(i).Item(7).ToString + "</td><td>" + dssub.Tables("InvoiceTail").Rows(i).Item(8).ToString + "</td><td>" + dssub.Tables("InvoiceTail").Rows(i).Item(9).ToString + "</td></tr>"
            Next

            StrHTML = StrHTML + "</table>" & _
"<table class='subtotal_layout'>" & _
"<tr><td>Sub Total Before Tax</td><td>:</td><td><b>" + listdata(19) + "</b></td><td>&#8377;</td> </tr>" & _
"<tr><td>Overall discount(%)</td><td>:</td><td><b>" + listdata(20) + "</b></td><td>&#8377;</td> </tr>"


            Select Case GStType
                Case Is = "GST"
                    StrHTML = StrHTML + "<tr><td>CGST</td><td>:</td><td><b>" & CDbl(listdata(21)) / 2 & "</b></td><td>&#8377;</td> </tr>" & _
"<tr><td>SGST</td><td>:</td><td><b>" & CDbl(listdata(21)) / 2 & "</b></td><td>&#8377;</td> </tr>" & _
"<tr><td>IGST</td><td>:</td><td><b>0</b></td><td>&#8377;</td> </tr>"
                Case Is = "IGST"
                    StrHTML = StrHTML + "<tr><td>CGST</td><td>:</td><td><b>0</b></td><td>&#8377;</td> </tr>" & _
"<tr><td>SGST</td><td>:</td><td><b>0</b></td><td>&#8377;</td> </tr>" & _
"<tr><td>IGST</td><td>:</td><td><b>" + listdata(21) + "</b></td><td>&#8377;</td> </tr>"
            End Select





            StrHTML = StrHTML + "<tr><td>Additional Charges</td><td>:</td><td><b>" + listdata(22) + "</b></td><td>&#8377;</td> </tr>" & _
"<tr><td>Advance Recieved</td><td>:</td><td><b>" + If(listdata(23) = "1", obj.GetOneValueFromQuery("select sum(advance_amt) from advance_tbl where bill_no='" + listdata(28) + "'"), "0") + "</b></td><td>&#8377;</td> </tr>" & _
"<tr><td>Round Off</td><td>:</td><td><b>" + listdata(24) + "</b></td><td>&#8377;</td> </tr>" & _
"<tr><td>Net Payable</td><td>:</td><td><b>" + listdata(25) + "</b></td><td>&#8377;</td> </tr>" & _
"</table>" & _
"<table class='taxwords_layout'>" & _
"<tr><td><b>Total in Words</b></td><td>:</td><td>Twenty six thousand fivehundred and sixteen twenty three paise only</td> </tr>" & _
"<tr><td><b>Tax in Words</b></td><td>:</td><td>Twenty six thousand fivehundred and sixteen twenty three paise only</td> </tr>" & _
"<tr><td><b>Notes</b></td><td>:</td><td>" + listdata(18) + "</td> </tr>"
            Dim bankdata As New List(Of String)
            bankdata = obj.GetMoreValueFromQuery("select bank_name,acc_name,acc_no,'' from bankview where company_id=" + listdata(27) + "", 4)


            StrHTML = StrHTML + "<tr><td></td><td></td><td><b><u>Bank Information</u></b></td></tr>" & _
"<tr><td><b>Bank Name</b></td><td>:</td><td>" + bankdata(0) + "</td> </tr>" & _
"<tr><td><b>Account Name</b></td><td>:</td><td>" + bankdata(1) + "</td> </tr>" & _
"<tr><td><b>Account No</b></td><td>:</td><td>" + bankdata(2) + "</td> </tr>" & _
"</table>" & _
"</div>" & _
"<div class='reverse_charge'>" + If(listdata(26) = "1", "Reverse Charge Applied", "") + "</div>" & _
"<div class='notifications_layout'>" & _
"<table>" & _
"<tr><td><u><b>Notifications</b></u></td></tr>" & _
"<tr><td></td></tr>" & _
"</table> " & _
"</div>" & _
"<div class='authorized_layout'>" & _
"<table>" & _
"<tr><td>For " + listdata(5) + "</td></tr>" & _
"<tr><td><b>Authorized Signatory</b></td></tr>" & _
"</table>" & _
"</div>" & _
"</div>" & _
"</body>" & _
"</html>"

            '.DocumentText = StrHTML
        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try


    End Sub

    Sub SupplyHTMLReport(ByVal s As String)
        Try
            Dim dssub As New SubReport
            Dim listdata As New List(Of String)
            Dim dr1 As Data.DataRow
            Dim dtsubreport As New DataTable

            dtsubreport = obj.getdatatable("select item_name, gst_id, uom, item_qty, item_rate, item_disc, item_amount from SupplySubReport where supply_no='" + s + "'")
            For i = 0 To dtsubreport.Rows.Count - 1
                dr1 = dssub.Tables("InvoiceTail").NewRow()
                dr1("No") = i + 1
                dr1("Name") = dtsubreport.Rows(i).Item(0).ToString
                dr1("HSNSAC") = dtsubreport.Rows(i).Item(1).ToString
                dr1("UOM") = dtsubreport.Rows(i).Item(2).ToString
                dr1("Qty") = dtsubreport.Rows(i).Item(3).ToString
                dr1("Rate") = dtsubreport.Rows(i).Item(4).ToString
                dr1("discpercent") = dtsubreport.Rows(i).Item(5).ToString
                dr1("Amount") = dtsubreport.Rows(i).Item(6).ToString
                dr1("taxpercent") = 0
                dr1("TotalAmt") = 0
                dssub.Tables("InvoiceTail").Rows.Add(dr1)
            Next
            listdata = obj.GetMoreValueFromQuery("select user_supply_no, supply_dt, " & _
                                               "ref_no,  billing_state," & _
                                               " pan_no, comp_company_name, " & _
                                               "comp_billing_address, billing_city, " & _
                                               "billing_state, comp_phone_no," & _
                                               "  comp_gst_no, company_name," & _
                                               "  cont_billing_address,ship_address, " & _
                                               " cont_gst_no, cont_place_supply, " & _
                                               "cont_phone_no, email_id, customer_notes," & _
                                               " sub_total, overall_disc_amt,''," & _
                                               " shpcost_amt,advance_flg, roundoff_amt," & _
                                               " grand_total,'0',company_id," & _
                                               " supply_no, contact_no " & _
                                               "from SupplyMainReport where supply_no='" + s + "'", 30)

            Dim StrHTML As String

            StrHTML = "<html>" & _
"<head>" & _
 "   <title></title>" & _
  "  <style type ='text/css' >" & _
   " .page_layout{width:210mm; height:277mm; border:1px solid black; position:absolute; top:0mm; left:0mm; font-family:Arial;}" & _
   " .header_layout{width:200mm; height:60mm; position:absolute; top:0mm; left:5mm; font-family:Arial;  }" & _
   " .heading{ position:absolute; top:0mm; left:90mm; font-size:15px; font-weight:bold;  }" & _
   " .additional_text{position:absolute; top:15mm; left:87mm; font-size:10px; }" & _
   " .invno_dtls{position:absolute; top:5mm; right:0mm; font-size:13px; }" & _
   " .company_logo{ width:30mm; height:25mm; position:absolute; top: 1mm; left:1mm; background:url('" + listdata(27) + ".jpg'); background-repeat:no-repeat;   }" & _
   " .company_dtls{ position:absolute; top:27mm; left:0mm; font-family:Arial; width:66mm; height:33mm; font-size:11px; border:1px solid black; border-right:none; border-bottom :none; }" & _
   " .company_name{ font-weight:bold; font-size:14px; } p { margin:5px; }      " & _
   " .billedto_dtls{position:absolute; top:27mm; left:66mm; font-family:Arial; width:66mm; height:33mm; font-size:11px; border:1px solid black; border-right:none; border-bottom :none;  }" & _
   " .shippedto_dtls{position:absolute; top:27mm; left:132mm; font-family:Arial; width:67mm; height:33mm; font-size:11px; border:1px solid black; border-bottom :none; }" & _
   " .item_layout{ position:absolute; top: 60mm; left: 5mm; height:147mm; width:199mm; font-family:Arial; font-size:11px; }" & _
   " .item_table_layout{ position:absolute; left:0mm; top:0mm; width:199.5mm; height:147mm; border-collapse:collapse;  }    " & _
   " .item_table_layout td{ border:1px solid black; } .item_table_layout tr:first-child{ height:5mm; }" & _
   " .item_table_layout tr:first-child{ font-size:12px; text-align:center; font-weight:bold; border-top:none;    }" & _
   " .subtotal_layout{ position:absolute; top:147mm; left:99.7mm; width:100mm; height:45.3mm; font-size:12px; border:1px solid black; border-top:none; border-left:none; }" & _
   " .taxwords_layout{position:absolute; top:147mm; left:0mm; width:100mm; font-size:11px; border:1px solid black; border-top:none;}" & _
   " .taxwords_layout td:first-child{ width:25mm;}" & _
   " .authorized_layout{position:absolute; bottom:0mm; right:10mm; font-size:11px;}.authorized_layout table tr:first-child {line-height:20mm;  }.authorized_layout table td:last-child {text-align:center; }" & _
   " .reverse_charge{position:absolute; bottom:15mm; left:5mm; font-weight:bold; font-size:13px;  }" & _
   " .notifications_layout{position:absolute; bottom:0mm; left:5mm; width:100mm; font-size:11px;  }" & _
   " </style>" & _
"</head>" & _
"<body>" & _
"<div class='page_layout'>" & _
"<div class='header_layout' >" & _
"<div class='heading'><u>TAX INVOICE</u></div>" & _
"<div class='company_logo'></div>" & _
"<div class='additional_text'>"


            Dim GStType As String = If(listdata(8) = listdata(15), "GST", "IGST")
            StrHTML = StrHTML + "<table>" & _
"<tr><td>PAN</td><td>:</td><td>" + listdata(4) + "</td></tr>" & _
"</table></div>" & _
"<div class='invno_dtls' >" & _
"<table>" & _
"<tr><td><b>Invoice No</b></td><td>:</td><td><b>" + listdata(0) + "</b></td></tr>" & _
"<tr><td>Date</td><td>:</td><td>" + listdata(1) + "</td></tr>" & _
"<tr><td>Place of Supply</td><td>:</td><td>" + listdata(3) + "</td></tr>" & _
"<tr><td>Ref No #</td><td>:</td><td>" + listdata(2) + "</td></tr>" & _
"</table>" & _
"</div>" & _
"<div class='company_dtls'>" & _
"<div class='company_name'>" & _
"" + listdata(5) + "<br />" & _
"</div>" & _
"<p>" + listdata(6) + "<br />" & _
"State : " + listdata(8) + "<br />" & _
"Phone No: " + listdata(9) + "<br />" & _
"<b>GST No: " + listdata(10) + "</b>" & _
"</div>" & _
"<div class='billedto_dtls'>" & _
"<u>Billed To</u><br />" & _
"<div class='company_name'>" & _
"" + listdata(11) + "<br />" & _
"</div>" & _
"<p>" + listdata(12) + "<br />" & _
"State : " + listdata(15) + "<br />" & _
"Phone No: " + listdata(16) + "<br />" & _
"Mail Id : " + listdata(17) + "<br />" & _
"<b>GST No: " + listdata(14) + "</b>" & _
"</div>" & _
"<div class='shippedto_dtls'>" & _
"<u>Shipped To</u><br />" & _
"<div class='company_name'>" & _
"" + listdata(11) + "<br />" & _
"</div>" & _
"<p>" + listdata(13) + "<br />" & _
"State : " + listdata(15) + "<br />" & _
"Phone No:" + listdata(16) + "<br />" & _
"            Mail(Id) : " + listdata(17) + "" & _
"</div>" & _
"</div>" & _
"<div class='item_layout'>" & _
"<table class='item_table_layout'>" & _
"<tr><td>No</td><td>Item Name</td><td>HSN/SAC</td><td>UOM</td><td>Qty</td><td>Rate</td><td>Disc (%)</td><td>Total &#8377;</td></tr>"
            For i = 0 To dssub.Tables("InvoiceTail").Rows.Count - 1
                StrHTML = StrHTML + "<tr style='vertical-align:top; '><td>" + dssub.Tables("InvoiceTail").Rows(i).Item(0).ToString + "</td><td>" + dssub.Tables("InvoiceTail").Rows(i).Item(1).ToString + "<br />" & _
"</td><td>" + dssub.Tables("InvoiceTail").Rows(i).Item(2).ToString + "</td><td>" + dssub.Tables("InvoiceTail").Rows(i).Item(3).ToString + "</td><td>" + dssub.Tables("InvoiceTail").Rows(i).Item(4).ToString + "</td><td>" + dssub.Tables("InvoiceTail").Rows(i).Item(5).ToString + "" & _
"</td><td>" + dssub.Tables("InvoiceTail").Rows(i).Item(6).ToString + "</td><td>" + dssub.Tables("InvoiceTail").Rows(i).Item(7).ToString + "</td></tr>"
            Next

            StrHTML = StrHTML + "</table>" & _
"<table class='subtotal_layout'>" & _
"<tr><td>Sub Total Before Tax</td><td>:</td><td><b>" + listdata(19) + "</b></td><td>&#8377;</td> </tr>" & _
"<tr><td>Overall discount(%)</td><td>:</td><td><b>" + listdata(20) + "</b></td><td>&#8377;</td> </tr>"
            StrHTML = StrHTML + "<tr><td>Additional Charges</td><td>:</td><td><b>" + listdata(22) + "</b></td><td>&#8377;</td> </tr>" & _
"<tr><td>Advance Recieved</td><td>:</td><td><b>" + If(listdata(23) = "1", obj.GetOneValueFromQuery("select sum(advance_amt) from advance_tbl where bill_no='" + listdata(28) + "'"), "0") + "</b></td><td>&#8377;</td> </tr>" & _
"<tr><td>Round Off</td><td>:</td><td><b>" + listdata(24) + "</b></td><td>&#8377;</td> </tr>" & _
"<tr><td>Net Payable</td><td>:</td><td><b>" + listdata(25) + "</b></td><td>&#8377;</td> </tr>" & _
"</table>" & _
"<table class='taxwords_layout'>" & _
"<tr><td><b>Total in Words</b></td><td>:</td><td>Twenty six thousand fivehundred and sixteen twenty three paise only</td> </tr>" & _
"<tr><td><b>Tax in Words</b></td><td>:</td><td>Twenty six thousand fivehundred and sixteen twenty three paise only</td> </tr>" & _
"<tr><td><b>Notes</b></td><td>:</td><td>" + listdata(18) + "</td> </tr>"
            Dim bankdata As New List(Of String)
            bankdata = obj.GetMoreValueFromQuery("select bank_name,acc_name,acc_no,'' from bankview where company_id=" + listdata(27) + "", 4)


            StrHTML = StrHTML + "<tr><td></td><td></td><td><b><u>Bank Information</u></b></td></tr>" & _
"<tr><td><b>Bank Name</b></td><td>:</td><td>" + bankdata(0) + "</td> </tr>" & _
"<tr><td><b>Account Name</b></td><td>:</td><td>" + bankdata(1) + "</td> </tr>" & _
"<tr><td><b>Account No</b></td><td>:</td><td>" + bankdata(2) + "</td> </tr>" & _
"</table>" & _
"</div>" & _
"<div class='reverse_charge'>" + If(listdata(26) = "1", "Reverse Charge Applied", "") + "</div>" & _
"<div class='notifications_layout'>" & _
"<table>" & _
"<tr><td><u><b>Notifications</b></u></td></tr>" & _
"<tr><td></td></tr>" & _
"</table> " & _
"</div>" & _
"<div class='authorized_layout'>" & _
"<table>" & _
"<tr><td>For " + listdata(5) + "</td></tr>" & _
"<tr><td><b>Authorized Signatory</b></td></tr>" & _
"</table>" & _
"</div>" & _
"</div>" & _
"</body>" & _
"</html>"

            'WebBrowser1.DocumentText = StrHTML





        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Sub QuotationHTMLReport(ByVal s As String)
        Try
            Dim dssub As New SubReport
            Dim listdata As New List(Of String)
            Dim dr1 As Data.DataRow
            Dim dtsubreport As New DataTable
            dtsubreport = obj.getdatatable("select item_name, gst_id, uom, item_qty, item_rate, item_disc, item_amount,item_tax,item_cess,tax_amt,cess_amt from QuotationSubReport where quotation_no='" + s + "'")
            For i = 0 To dtsubreport.Rows.Count - 1
                dr1 = dssub.Tables("InvoiceTail").NewRow()
                dr1("No") = i + 1
                dr1("Name") = dtsubreport.Rows(i).Item(0).ToString
                dr1("HSNSAC") = dtsubreport.Rows(i).Item(1).ToString
                dr1("UOM") = dtsubreport.Rows(i).Item(2).ToString
                dr1("Qty") = dtsubreport.Rows(i).Item(3).ToString
                dr1("Rate") = dtsubreport.Rows(i).Item(4).ToString
                dr1("discpercent") = dtsubreport.Rows(i).Item(5).ToString
                dr1("Amount") = dtsubreport.Rows(i).Item(6).ToString
                dr1("taxpercent") = dtsubreport.Rows(i).Item(7).ToString
                dr1("TotalAmt") = (CDbl(dtsubreport.Rows(i).Item(6).ToString) + CDbl(dtsubreport.Rows(i).Item(9).ToString) + CDbl(dtsubreport.Rows(i).Item(10).ToString)).ToString
                dssub.Tables("InvoiceTail").Rows.Add(dr1)
            Next
            listdata = obj.GetMoreValueFromQuery("select user_quotation_no, quotation_dt, " & _
                                               "ref_no,  billing_state," & _
                                               " pan_no, comp_company_name, " & _
                                               "comp_billing_address, billing_city, " & _
                                               "billing_state, comp_phone_no," & _
                                               "  comp_gst_no, company_name," & _
                                               "  cont_billing_address,ship_address, " & _
                                               " cont_gst_no, cont_place_supply, " & _
                                               "cont_phone_no, email_id, customer_notes," & _
                                               " sub_total, overall_disc_amt,total_tax," & _
                                               " shpcost_amt,'0', roundoff_amt," & _
                                               " grand_total,'0',company_id," & _
                                               " quotation_no, contact_no " & _
                                               "from QuotationMainReport where quotation_no='" + s + "'", 30)

            Dim StrHTML As String

            StrHTML = "<html>" & _
"<head>" & _
 "   <title></title>" & _
  "  <style type ='text/css' >" & _
   " .page_layout{width:210mm; height:277mm; border:1px solid black; position:absolute; top:0mm; left:0mm; font-family:Arial;}" & _
   " .header_layout{width:200mm; height:60mm; position:absolute; top:0mm; left:5mm; font-family:Arial;  }" & _
   " .heading{ position:absolute; top:0mm; left:90mm; font-size:15px; font-weight:bold;  }" & _
   " .additional_text{position:absolute; top:15mm; left:87mm; font-size:10px; }" & _
   " .invno_dtls{position:absolute; top:5mm; right:0mm; font-size:13px; }" & _
   " .company_logo{ width:30mm; height:25mm; position:absolute; top: 1mm; left:1mm; background:url('" + listdata(27) + ".jpg'); background-repeat:no-repeat;   }" & _
   " .company_dtls{ position:absolute; top:27mm; left:0mm; font-family:Arial; width:66mm; height:33mm; font-size:11px; border:1px solid black; border-right:none; border-bottom :none; }" & _
   " .company_name{ font-weight:bold; font-size:14px; } p { margin:5px; }      " & _
   " .billedto_dtls{position:absolute; top:27mm; left:66mm; font-family:Arial; width:66mm; height:33mm; font-size:11px; border:1px solid black; border-right:none; border-bottom :none;  }" & _
   " .shippedto_dtls{position:absolute; top:27mm; left:132mm; font-family:Arial; width:67mm; height:33mm; font-size:11px; border:1px solid black; border-bottom :none; }" & _
   " .item_layout{ position:absolute; top: 60mm; left: 5mm; height:147mm; width:199mm; font-family:Arial; font-size:11px; }" & _
   " .item_table_layout{ position:absolute; left:0mm; top:0mm; width:199.5mm; height:147mm; border-collapse:collapse;  }    " & _
   " .item_table_layout td{ border:1px solid black; } .item_table_layout tr:first-child{ height:5mm; }" & _
   " .item_table_layout tr:first-child{ font-size:12px; text-align:center; font-weight:bold; border-top:none;    }" & _
   " .subtotal_layout{ position:absolute; top:147mm; left:99.7mm; width:100mm; height:45.3mm; font-size:12px; border:1px solid black; border-top:none; border-left:none; }" & _
   " .taxwords_layout{position:absolute; top:147mm; left:0mm; width:100mm; font-size:11px; border:1px solid black; border-top:none;}" & _
   " .taxwords_layout td:first-child{ width:25mm;}" & _
   " .authorized_layout{position:absolute; bottom:0mm; right:10mm; font-size:11px;}.authorized_layout table tr:first-child {line-height:20mm;  }.authorized_layout table td:last-child {text-align:center; }" & _
   " .reverse_charge{position:absolute; bottom:15mm; left:5mm; font-weight:bold; font-size:13px;  }" & _
   " .notifications_layout{position:absolute; bottom:0mm; left:5mm; width:100mm; font-size:11px;  }" & _
   " </style>" & _
"</head>" & _
"<body>" & _
"<div class='page_layout'>" & _
"<div class='header_layout' >" & _
"<div class='heading'><u>TAX INVOICE</u></div>" & _
"<div class='company_logo'></div>" & _
"<div class='additional_text'>"


            Dim GStType As String = If(listdata(8) = listdata(15), "GST", "IGST")
            StrHTML = StrHTML + "<table>" & _
"<tr><td>PAN</td><td>:</td><td>" + listdata(4) + "</td></tr>" & _
"</table></div>" & _
"<div class='invno_dtls' >" & _
"<table>" & _
"<tr><td><b>Invoice No</b></td><td>:</td><td><b>" + listdata(0) + "</b></td></tr>" & _
"<tr><td>Date</td><td>:</td><td>" + listdata(1) + "</td></tr>" & _
"<tr><td>Place of Supply</td><td>:</td><td>" + listdata(3) + "</td></tr>" & _
"<tr><td>Ref No #</td><td>:</td><td>" + listdata(2) + "</td></tr>" & _
"</table>" & _
"</div>" & _
"<div class='company_dtls'>" & _
"<div class='company_name'>" & _
"" + listdata(5) + "<br />" & _
"</div>" & _
"<p>" + listdata(6) + "<br />" & _
"State : " + listdata(8) + "<br />" & _
"Phone No: " + listdata(9) + "<br />" & _
"<b>GST No: " + listdata(10) + "</b>" & _
"</div>" & _
"<div class='billedto_dtls'>" & _
"<u>Billed To</u><br />" & _
"<div class='company_name'>" & _
"" + listdata(11) + "<br />" & _
"</div>" & _
"<p>" + listdata(12) + "<br />" & _
"State : " + listdata(15) + "<br />" & _
"Phone No: " + listdata(16) + "<br />" & _
"Mail Id : " + listdata(17) + "<br />" & _
"<b>GST No: " + listdata(14) + "</b>" & _
"</div>" & _
"<div class='shippedto_dtls'>" & _
"<u>Shipped To</u><br />" & _
"<div class='company_name'>" & _
"" + listdata(11) + "<br />" & _
"</div>" & _
"<p>" + listdata(13) + "<br />" & _
"State : " + listdata(15) + "<br />" & _
"Phone No:" + listdata(16) + "<br />" & _
"            Mail(Id) : " + listdata(17) + "" & _
"</div>" & _
"</div>" & _
"<div class='item_layout'>" & _
"<table class='item_table_layout'>" & _
"<tr><td>No</td><td>Item Name</td><td>HSN/SAC</td><td>UOM</td><td>Qty</td><td>Rate</td><td>Disc (%)</td><td>TaxableValue</td><td>Tax(%)</td><td>Total &#8377;</td></tr>"
            For i = 0 To dssub.Tables("InvoiceTail").Rows.Count - 1
                StrHTML = StrHTML + "<tr style='vertical-align:top; '><td>" + dssub.Tables("InvoiceTail").Rows(i).Item(0).ToString + "</td><td>" + dssub.Tables("InvoiceTail").Rows(i).Item(1).ToString + "<br />" & _
"</td><td>" + dssub.Tables("InvoiceTail").Rows(i).Item(2).ToString + "</td><td>" + dssub.Tables("InvoiceTail").Rows(i).Item(3).ToString + "</td><td>" + dssub.Tables("InvoiceTail").Rows(i).Item(4).ToString + "</td><td>" + dssub.Tables("InvoiceTail").Rows(i).Item(5).ToString + "" & _
"</td><td>" + dssub.Tables("InvoiceTail").Rows(i).Item(6).ToString + "</td><td>" + dssub.Tables("InvoiceTail").Rows(i).Item(7).ToString + "</td><td>" + dssub.Tables("InvoiceTail").Rows(i).Item(8).ToString + "</td><td>" + dssub.Tables("InvoiceTail").Rows(i).Item(9).ToString + "</td></tr>"
            Next

            StrHTML = StrHTML + "</table>" & _
"<table class='subtotal_layout'>" & _
"<tr><td>Sub Total Before Tax</td><td>:</td><td><b>" + listdata(19) + "</b></td><td>&#8377;</td> </tr>" & _
"<tr><td>Overall discount(%)</td><td>:</td><td><b>" + listdata(20) + "</b></td><td>&#8377;</td> </tr>"


            Select Case GStType
                Case Is = "GST"
                    StrHTML = StrHTML + "<tr><td>CGST</td><td>:</td><td><b>" & CDbl(listdata(21)) / 2 & "</b></td><td>&#8377;</td> </tr>" & _
"<tr><td>SGST</td><td>:</td><td><b>" & CDbl(listdata(21)) / 2 & "</b></td><td>&#8377;</td> </tr>" & _
"<tr><td>IGST</td><td>:</td><td><b>0</b></td><td>&#8377;</td> </tr>"
                Case Is = "IGST"
                    StrHTML = StrHTML + "<tr><td>CGST</td><td>:</td><td><b>0</b></td><td>&#8377;</td> </tr>" & _
"<tr><td>SGST</td><td>:</td><td><b>0</b></td><td>&#8377;</td> </tr>" & _
"<tr><td>IGST</td><td>:</td><td><b>" + listdata(21) + "</b></td><td>&#8377;</td> </tr>"
            End Select





            StrHTML = StrHTML + "<tr><td>Additional Charges</td><td>:</td><td><b>" + listdata(22) + "</b></td><td>&#8377;</td> </tr>" & _
"<tr><td>Advance Recieved</td><td>:</td><td><b>" + If(listdata(23) = "1", obj.GetOneValueFromQuery("select sum(advance_amt) from advance_tbl where bill_no='" + listdata(28) + "'"), "0") + "</b></td><td>&#8377;</td> </tr>" & _
"<tr><td>Round Off</td><td>:</td><td><b>" + listdata(24) + "</b></td><td>&#8377;</td> </tr>" & _
"<tr><td>Net Payable</td><td>:</td><td><b>" + listdata(25) + "</b></td><td>&#8377;</td> </tr>" & _
"</table>" & _
"<table class='taxwords_layout'>" & _
"<tr><td><b>Total in Words</b></td><td>:</td><td>Twenty six thousand fivehundred and sixteen twenty three paise only</td> </tr>" & _
"<tr><td><b>Tax in Words</b></td><td>:</td><td>Twenty six thousand fivehundred and sixteen twenty three paise only</td> </tr>" & _
"<tr><td><b>Notes</b></td><td>:</td><td>" + listdata(18) + "</td> </tr>"
            Dim bankdata As New List(Of String)
            bankdata = obj.GetMoreValueFromQuery("select bank_name,acc_name,acc_no,'' from bankview where company_id=" + listdata(27) + "", 4)


            StrHTML = StrHTML + "<tr><td></td><td></td><td><b><u>Bank Information</u></b></td></tr>" & _
"<tr><td><b>Bank Name</b></td><td>:</td><td>" + bankdata(0) + "</td> </tr>" & _
"<tr><td><b>Account Name</b></td><td>:</td><td>" + bankdata(1) + "</td> </tr>" & _
"<tr><td><b>Account No</b></td><td>:</td><td>" + bankdata(2) + "</td> </tr>" & _
"</table>" & _
"</div>" & _
"<div class='reverse_charge'>" + If(listdata(26) = "1", "Reverse Charge Applied", "") + "</div>" & _
"<div class='notifications_layout'>" & _
"<table>" & _
"<tr><td><u><b>Notifications</b></u></td></tr>" & _
"<tr><td></td></tr>" & _
"</table> " & _
"</div>" & _
"<div class='authorized_layout'>" & _
"<table>" & _
"<tr><td>For " + listdata(5) + "</td></tr>" & _
"<tr><td><b>Authorized Signatory</b></td></tr>" & _
"</table>" & _
"</div>" & _
"</div>" & _
"</body>" & _
"</html>"

            '  WebBrowser1.DocumentText = StrHTML





        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Sub InvoiceReport(ByVal p1 As String, ByVal papertype As String)
        Try
            Dim dssub As New SubReport
            Dim logoimg As New Logo
            Dim listdata As New List(Of String)
            Dim dr1, dr2 As Data.DataRow
            Dim dtsubreport, dtlogo As New DataTable
            dtsubreport = obj.getdatatable("select item_name & '-' & item_desc, gst_id, unit_format, item_qty, item_rate, item_disc, item_amount,item_tax,item_cess,tax_amt,cess_amt from InvoiceSubReport where invoice_no='" + p1 + "'")
            For i = 0 To dtsubreport.Rows.Count - 1
                dr1 = dssub.Tables("InvoiceTail").NewRow()
                dr1("No") = i + 1
                dr1("Name") = dtsubreport.Rows(i).Item(0).ToString
                dr1("HSNSAC") = dtsubreport.Rows(i).Item(1).ToString
                dr1("UOM") = dtsubreport.Rows(i).Item(2).ToString
                dr1("Qty") = dtsubreport.Rows(i).Item(3).ToString
                dr1("Rate") = dtsubreport.Rows(i).Item(4).ToString
                dr1("discpercent") = dtsubreport.Rows(i).Item(5).ToString
                dr1("Amount") = dtsubreport.Rows(i).Item(6).ToString
                dr1("taxpercent") = dtsubreport.Rows(i).Item(7).ToString
                dr1("TotalAmt") = (CDbl(dtsubreport.Rows(i).Item(6).ToString) + CDbl(dtsubreport.Rows(i).Item(9).ToString) + CDbl(dtsubreport.Rows(i).Item(10).ToString)).ToString
                dssub.Tables("InvoiceTail").Rows.Add(dr1)
            Next

            'ReportViewer1.ProcessingMode = ProcessingMode.Local
            'ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Report.rdlc")
            'Dim dsCustomers As Customers = GetData("select top 20 * from customers")
            'Dim datasource As New ReportDataSource("Customers", dsCustomers.Tables(0))
            'ReportViewer1.LocalReport.DataSources.Clear()
            'ReportViewer1.LocalReport.DataSources.Add(datasource)

            listdata = obj.GetMoreValueFromQuery("select user_invoice_no, invoice_dt, " & _
                                               "ref_no,  billing_state," & _
                                               " pan_no, comp_company_name, " & _
                                               "comp_billing_address, billing_city, " & _
                                               "billing_state, comp_phone_no," & _
                                               "  comp_gst_no, company_name," & _
                                               "  cont_billing_address,ship_address, " & _
                                               " cont_gst_no, cont_place_supply, " & _
                                               "cont_phone_no, email_id, customer_notes," & _
                                               " sub_total, overall_disc_amt,total_tax," & _
                                               " shpcost_amt,advance_flg, roundoff_amt," & _
                                               " grand_total,reverse_flg,company_id," & _
                                               " invoice_no, contact_no,total_cess ,ewaybill_no " & _
                                               "from InvoiceMainReport where invoice_no='" + p1 + "'", 32)


            Dim rptDataSource1, rptDataSource2 As ReportDataSource
            Try
                rptDataSource1 = New ReportDataSource("DataSet1", dssub.Tables("InvoiceTail"))
                ReportViewer1.ProcessingMode = ProcessingMode.Local

                Select Case papertype
                    Case Is = "A4"
                        ReportViewer1.LocalReport.ReportPath = "" + Application.StartupPath + "\InvoiceRpt.rdlc"
                    Case Is = "A5"
                        ReportViewer1.LocalReport.ReportPath = "" + Application.StartupPath + "\InvoiceRptA5.rdlc"
                End Select





                Dim myParam1 As New ReportParameter("invoiceno", listdata(0))
                ReportViewer1.LocalReport.SetParameters(myParam1)
                Dim myParam2 As New ReportParameter("invoicedt", listdata(1))
                ReportViewer1.LocalReport.SetParameters(myParam2)
                Dim myParam3 As New ReportParameter("duedate", Format(CDate(listdata(1)).AddDays(15), "dd/MM/yyyy"))
                ReportViewer1.LocalReport.SetParameters(myParam3)
                Dim myParam4 As New ReportParameter("companyname", listdata(5))
                ReportViewer1.LocalReport.SetParameters(myParam4)
                Dim myParam5 As New ReportParameter("companyaddr", listdata(6))
                ReportViewer1.LocalReport.SetParameters(myParam5)
                Dim myParam6 As New ReportParameter("companyphoneno", listdata(9))
                ReportViewer1.LocalReport.SetParameters(myParam6)
                Dim myParam7 As New ReportParameter("contactname", listdata(11))
                ReportViewer1.LocalReport.SetParameters(myParam7)
                Dim myParam8 As New ReportParameter("contactbilladdr", listdata(12))
                ReportViewer1.LocalReport.SetParameters(myParam8)
                Dim myParam9 As New ReportParameter("contactshipaddr", listdata(13))
                ReportViewer1.LocalReport.SetParameters(myParam9)
                Dim myParam10 As New ReportParameter("contactgstno", listdata(14))
                ReportViewer1.LocalReport.SetParameters(myParam10)
                Dim myParam11 As New ReportParameter("contactphone", listdata(16))
                ReportViewer1.LocalReport.SetParameters(myParam11)


                Dim myParam12 As New ReportParameter("subtotal", listdata(19))
                ReportViewer1.LocalReport.SetParameters(myParam12)

                Dim myParam14 As New ReportParameter("grandtotal", listdata(25))
                ReportViewer1.LocalReport.SetParameters(myParam14)

                Dim myParam15 As New ReportParameter("refno", listdata(2))
                ReportViewer1.LocalReport.SetParameters(myParam15)
                Dim myParam16 As New ReportParameter("companygstno", listdata(10))
                ReportViewer1.LocalReport.SetParameters(myParam16)

                Dim bankdata As New List(Of String)
                bankdata = obj.GetMoreValueFromQuery("select bank_name,acc_name,acc_no,'' from bankview where company_id=" + listdata(27) + "", 4)
                Dim myParam17 As New ReportParameter("accountno", bankdata(2))
                ReportViewer1.LocalReport.SetParameters(myParam17)
                Dim myParam18 As New ReportParameter("accountname", bankdata(1))
                ReportViewer1.LocalReport.SetParameters(myParam18)
                Dim myParam19 As New ReportParameter("bankname", bankdata(0))
                ReportViewer1.LocalReport.SetParameters(myParam19)

                Dim myParam20 As New ReportParameter("overalldiscamt", listdata(20))
                ReportViewer1.LocalReport.SetParameters(myParam20)
                Dim myParam21 As New ReportParameter("shipcost", listdata(22))
                ReportViewer1.LocalReport.SetParameters(myParam21)
                Dim myParam22 As New ReportParameter("roundoff", listdata(24))
                ReportViewer1.LocalReport.SetParameters(myParam22)

                Dim gsttype As String = If(listdata(3) = listdata(15), "GST", "IGST")

                Select Case gsttype
                    Case Is = "GST"
                        Dim myParam23 As New ReportParameter("cgst", CDbl(listdata(21)) / 2)
                        ReportViewer1.LocalReport.SetParameters(myParam23)
                        Dim myParam24 As New ReportParameter("sgst", CDbl(listdata(21)) / 2)
                        ReportViewer1.LocalReport.SetParameters(myParam24)
                        Dim myParam25 As New ReportParameter("igst", 0)
                        ReportViewer1.LocalReport.SetParameters(myParam25)
                    Case Is = "IGST"
                        Dim myParam23 As New ReportParameter("cgst", 0)
                        ReportViewer1.LocalReport.SetParameters(myParam23)
                        Dim myParam24 As New ReportParameter("sgst", 0)
                        ReportViewer1.LocalReport.SetParameters(myParam24)
                        Dim myParam25 As New ReportParameter("igst", listdata(21))
                        ReportViewer1.LocalReport.SetParameters(myParam25)
                End Select
                Dim myParam26 As New ReportParameter("reversecharge", If(listdata(26) = "1", "Reverse Charge Applied", ""))
                ReportViewer1.LocalReport.SetParameters(myParam26)

                Dim myParam27 As New ReportParameter("advanceamt", If(listdata(23) = "1", obj.GetOneValueFromQuery("select sum(advance_amt) from advance_tbl where bill_no='" + listdata(28) + "'"), "0"))
                ReportViewer1.LocalReport.SetParameters(myParam27)
                Dim myParam28 As New ReportParameter("notes", listdata(18))
                ReportViewer1.LocalReport.SetParameters(myParam28)

                Dim myParam29 As New ReportParameter("amountinwords", obj.AmountInWords(listdata(25)))
                ReportViewer1.LocalReport.SetParameters(myParam29)
                Dim cess As Double = listdata(30)
                Dim myParam30 As New ReportParameter("taxinwords", obj.AmountInWords(CDbl(listdata(21)) + cess))
                ReportViewer1.LocalReport.SetParameters(myParam30)
                Dim myParam31 As New ReportParameter("cess", cess)
                ReportViewer1.LocalReport.SetParameters(myParam31)
                Dim myParam32 As New ReportParameter("companystate", listdata(3))
                ReportViewer1.LocalReport.SetParameters(myParam32)
                Dim myParam33 As New ReportParameter("companycity", listdata(7))
                ReportViewer1.LocalReport.SetParameters(myParam33)
                Dim myParam34 As New ReportParameter("ewaybillno", listdata(31))
                ReportViewer1.LocalReport.SetParameters(myParam34)


                Dim img As Byte() = obj.GetImage("select company_logo from company_tbl where company_id=" + listdata(27) + "")

                dr2 = logoimg.Tables("Image").NewRow()
                dr2("company_id") = listdata(27)
                dr2("company_logo") = img
                logoimg.Tables("Image").Rows.Add(dr2)
                rptDataSource2 = New ReportDataSource("DataSet2", logoimg.Tables("Image"))
                'Dim myParam15 As New ReportParameter("logo", Convert.ToBase64String(ByteToImage(listdata(30))))
                'ReportViewer1.LocalReport.SetParameters(myParam15)



                ReportViewer1.LocalReport.Refresh()
                ReportViewer1.LocalReport.DataSources.Add(rptDataSource1)
                ReportViewer1.LocalReport.DataSources.Add(rptDataSource2)
                ReportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.Normal)


            Catch ex As Exception

            End Try






        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub SupplyReport(ByVal p1 As String, ByVal papertype As String)
        Try
            Dim dssub As New SubReport
            Dim logoimg As New Logo
            Dim listdata As New List(Of String)
            Dim dr1, dr2 As Data.DataRow
            Dim dtsubreport, dtlogo As New DataTable
            dtsubreport = obj.getdatatable("select item_name & '-' & item_desc, gst_id, unit_format, item_qty, item_rate, item_disc, item_amount,'0','0','0','0' from SupplySubReport where supply_no='" + p1 + "'")
            For i = 0 To dtsubreport.Rows.Count - 1
                dr1 = dssub.Tables("InvoiceTail").NewRow()
                dr1("No") = i + 1
                dr1("Name") = dtsubreport.Rows(i).Item(0).ToString
                dr1("HSNSAC") = dtsubreport.Rows(i).Item(1).ToString
                dr1("UOM") = dtsubreport.Rows(i).Item(2).ToString
                dr1("Qty") = dtsubreport.Rows(i).Item(3).ToString
                dr1("Rate") = dtsubreport.Rows(i).Item(4).ToString
                dr1("discpercent") = dtsubreport.Rows(i).Item(5).ToString
                dr1("Amount") = dtsubreport.Rows(i).Item(6).ToString
                dr1("taxpercent") = dtsubreport.Rows(i).Item(7).ToString
                dr1("TotalAmt") = (CDbl(dtsubreport.Rows(i).Item(6).ToString) + CDbl(dtsubreport.Rows(i).Item(9).ToString) + CDbl(dtsubreport.Rows(i).Item(10).ToString)).ToString
                dssub.Tables("InvoiceTail").Rows.Add(dr1)
            Next

            'ReportViewer1.ProcessingMode = ProcessingMode.Local
            'ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Report.rdlc")
            'Dim dsCustomers As Customers = GetData("select top 20 * from customers")
            'Dim datasource As New ReportDataSource("Customers", dsCustomers.Tables(0))
            'ReportViewer1.LocalReport.DataSources.Clear()
            'ReportViewer1.LocalReport.DataSources.Add(datasource)

            listdata = obj.GetMoreValueFromQuery("select user_Supply_no, Supply_dt, " & _
                                               "ref_no,  billing_state," & _
                                               " pan_no, comp_company_name, " & _
                                               "comp_billing_address, billing_city, " & _
                                               "billing_state, comp_phone_no," & _
                                               "  comp_gst_no, company_name," & _
                                               "  cont_billing_address,ship_address, " & _
                                               " cont_gst_no, cont_place_supply, " & _
                                               "cont_phone_no, email_id, customer_notes," & _
                                               " sub_total, overall_disc_amt,'0'," & _
                                               " shpcost_amt,advance_flg, roundoff_amt," & _
                                               " grand_total,'0',company_id," & _
                                               " Supply_no, contact_no,'0'  " & _
                                               "from SupplyMainReport where Supply_no='" + p1 + "'", 31)


            Dim rptDataSource1, rptDataSource2 As ReportDataSource
            Try
                rptDataSource1 = New ReportDataSource("DataSet1", dssub.Tables("InvoiceTail"))
                ReportViewer1.ProcessingMode = ProcessingMode.Local
                Select Case papertype
                    Case Is = "A4"
                        ReportViewer1.LocalReport.ReportPath = "" + Application.StartupPath + "\SupplyRpt.rdlc"
                    Case Is = "A5"
                        ReportViewer1.LocalReport.ReportPath = "" + Application.StartupPath + "\SupplyRptA5.rdlc"
                End Select



                Dim myParam1 As New ReportParameter("invoiceno", listdata(0))
                ReportViewer1.LocalReport.SetParameters(myParam1)
                Dim myParam2 As New ReportParameter("invoicedt", listdata(1))
                ReportViewer1.LocalReport.SetParameters(myParam2)
                Dim myParam3 As New ReportParameter("duedate", Format(CDate(listdata(1)).AddDays(15), "dd/MM/yyyy"))
                ReportViewer1.LocalReport.SetParameters(myParam3)
                Dim myParam4 As New ReportParameter("companyname", listdata(5))
                ReportViewer1.LocalReport.SetParameters(myParam4)
                Dim myParam5 As New ReportParameter("companyaddr", listdata(6))
                ReportViewer1.LocalReport.SetParameters(myParam5)
                Dim myParam6 As New ReportParameter("companyphoneno", listdata(9))
                ReportViewer1.LocalReport.SetParameters(myParam6)
                Dim myParam7 As New ReportParameter("contactname", listdata(11))
                ReportViewer1.LocalReport.SetParameters(myParam7)
                Dim myParam8 As New ReportParameter("contactbilladdr", listdata(12))
                ReportViewer1.LocalReport.SetParameters(myParam8)
                Dim myParam9 As New ReportParameter("contactshipaddr", listdata(13))
                ReportViewer1.LocalReport.SetParameters(myParam9)
                Dim myParam10 As New ReportParameter("contactgstno", listdata(14))
                ReportViewer1.LocalReport.SetParameters(myParam10)
                Dim myParam11 As New ReportParameter("contactphone", listdata(16))
                ReportViewer1.LocalReport.SetParameters(myParam11)


                Dim myParam12 As New ReportParameter("subtotal", listdata(19))
                ReportViewer1.LocalReport.SetParameters(myParam12)

                Dim myParam14 As New ReportParameter("grandtotal", listdata(25))
                ReportViewer1.LocalReport.SetParameters(myParam14)

                Dim myParam15 As New ReportParameter("refno", listdata(2))
                ReportViewer1.LocalReport.SetParameters(myParam15)
                Dim myParam16 As New ReportParameter("companygstno", listdata(10))
                ReportViewer1.LocalReport.SetParameters(myParam16)

                Dim bankdata As New List(Of String)
                bankdata = obj.GetMoreValueFromQuery("select bank_name,acc_name,acc_no,'' from bankview where company_id=" + listdata(27) + "", 4)
                Dim myParam17 As New ReportParameter("accountno", bankdata(2))
                ReportViewer1.LocalReport.SetParameters(myParam17)
                Dim myParam18 As New ReportParameter("accountname", bankdata(1))
                ReportViewer1.LocalReport.SetParameters(myParam18)
                Dim myParam19 As New ReportParameter("bankname", bankdata(0))
                ReportViewer1.LocalReport.SetParameters(myParam19)

                Dim myParam20 As New ReportParameter("overalldiscamt", listdata(20))
                ReportViewer1.LocalReport.SetParameters(myParam20)
                Dim myParam21 As New ReportParameter("shipcost", listdata(22))
                ReportViewer1.LocalReport.SetParameters(myParam21)
                Dim myParam22 As New ReportParameter("roundoff", listdata(24))
                ReportViewer1.LocalReport.SetParameters(myParam22)

                Dim gsttype As String = If(listdata(3) = listdata(15), "GST", "IGST")

                Select Case gsttype
                    Case Is = "GST"
                        Dim myParam23 As New ReportParameter("cgst", CDbl(listdata(21)) / 2)
                        ReportViewer1.LocalReport.SetParameters(myParam23)
                        Dim myParam24 As New ReportParameter("sgst", CDbl(listdata(21)) / 2)
                        ReportViewer1.LocalReport.SetParameters(myParam24)
                        Dim myParam25 As New ReportParameter("igst", 0)
                        ReportViewer1.LocalReport.SetParameters(myParam25)
                    Case Is = "IGST"
                        Dim myParam23 As New ReportParameter("cgst", 0)
                        ReportViewer1.LocalReport.SetParameters(myParam23)
                        Dim myParam24 As New ReportParameter("sgst", 0)
                        ReportViewer1.LocalReport.SetParameters(myParam24)
                        Dim myParam25 As New ReportParameter("igst", listdata(21))
                        ReportViewer1.LocalReport.SetParameters(myParam25)
                End Select
                Dim myParam26 As New ReportParameter("reversecharge", If(listdata(26) = "1", "Reverse Charge Applied", ""))
                ReportViewer1.LocalReport.SetParameters(myParam26)

                Dim myParam27 As New ReportParameter("advanceamt", If(listdata(23) = "1", obj.GetOneValueFromQuery("select sum(advance_amt) from advance_tbl where bill_no='" + listdata(28) + "'"), "0"))
                ReportViewer1.LocalReport.SetParameters(myParam27)
                Dim myParam28 As New ReportParameter("notes", listdata(18))
                ReportViewer1.LocalReport.SetParameters(myParam28)

                Dim myParam29 As New ReportParameter("amountinwords", obj.AmountInWords(listdata(25)))
                ReportViewer1.LocalReport.SetParameters(myParam29)
                Dim cess As Double = listdata(30)
                Dim myParam30 As New ReportParameter("taxinwords", obj.AmountInWords(CDbl(listdata(21)) + cess))
                ReportViewer1.LocalReport.SetParameters(myParam30)
                Dim myParam31 As New ReportParameter("cess", cess)
                ReportViewer1.LocalReport.SetParameters(myParam31)
                Dim myParam32 As New ReportParameter("companystate", listdata(3))
                ReportViewer1.LocalReport.SetParameters(myParam32)
                Dim myParam33 As New ReportParameter("companycity", listdata(7))
                ReportViewer1.LocalReport.SetParameters(myParam33)


                Dim img As Byte() = obj.GetImage("select company_logo from company_tbl where company_id=" + listdata(27) + "")

                dr2 = logoimg.Tables("Image").NewRow()
                dr2("company_id") = listdata(27)
                dr2("company_logo") = img
                logoimg.Tables("Image").Rows.Add(dr2)
                rptDataSource2 = New ReportDataSource("DataSet2", logoimg.Tables("Image"))
                ReportViewer1.LocalReport.Refresh()
                ReportViewer1.LocalReport.DataSources.Add(rptDataSource1)
                ReportViewer1.LocalReport.DataSources.Add(rptDataSource2)
                ReportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.Normal)


            Catch ex As Exception

            End Try
        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub QuotationReport(ByVal p1 As String, ByVal papertype As String)
        Try
            Dim dssub As New SubReport
            Dim logoimg As New Logo
            Dim listdata As New List(Of String)
            Dim dr1, dr2 As Data.DataRow
            Dim dtsubreport, dtlogo As New DataTable
            dtsubreport = obj.getdatatable("select item_name & '-' & item_desc, gst_id, unit_format, item_qty, item_rate, item_disc, item_amount,item_tax,item_cess,tax_amt,cess_amt from QuotationSubReport where Quotation_no='" + p1 + "'")
            For i = 0 To dtsubreport.Rows.Count - 1
                dr1 = dssub.Tables("InvoiceTail").NewRow()
                dr1("No") = i + 1
                dr1("Name") = dtsubreport.Rows(i).Item(0).ToString
                dr1("HSNSAC") = dtsubreport.Rows(i).Item(1).ToString
                dr1("UOM") = dtsubreport.Rows(i).Item(2).ToString
                dr1("Qty") = dtsubreport.Rows(i).Item(3).ToString
                dr1("Rate") = dtsubreport.Rows(i).Item(4).ToString
                dr1("discpercent") = dtsubreport.Rows(i).Item(5).ToString
                dr1("Amount") = dtsubreport.Rows(i).Item(6).ToString
                dr1("taxpercent") = dtsubreport.Rows(i).Item(7).ToString
                dr1("TotalAmt") = (CDbl(dtsubreport.Rows(i).Item(6).ToString) + CDbl(dtsubreport.Rows(i).Item(9).ToString) + CDbl(dtsubreport.Rows(i).Item(10).ToString)).ToString
                dssub.Tables("InvoiceTail").Rows.Add(dr1)
            Next

            'ReportViewer1.ProcessingMode = ProcessingMode.Local
            'ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Report.rdlc")
            'Dim dsCustomers As Customers = GetData("select top 20 * from customers")
            'Dim datasource As New ReportDataSource("Customers", dsCustomers.Tables(0))
            'ReportViewer1.LocalReport.DataSources.Clear()
            'ReportViewer1.LocalReport.DataSources.Add(datasource)

            listdata = obj.GetMoreValueFromQuery("select user_Quotation_no, Quotation_dt, " & _
                                               "ref_no,  billing_state," & _
                                               " pan_no, comp_company_name, " & _
                                               "comp_billing_address, billing_city, " & _
                                               "billing_state, comp_phone_no," & _
                                               "  comp_gst_no, company_name," & _
                                               "  cont_billing_address,ship_address, " & _
                                               " cont_gst_no, cont_place_supply, " & _
                                               "cont_phone_no, email_id, customer_notes," & _
                                               " sub_total, overall_disc_amt,total_tax," & _
                                               " shpcost_amt,'0', roundoff_amt," & _
                                               " grand_total,'0',company_id," & _
                                               " Quotation_no, contact_no,total_cess,validuntil_dt  " & _
                                               "from QuotationMainReport where Quotation_no='" + p1 + "'", 32)


            Dim rptDataSource1, rptDataSource2 As ReportDataSource
            Try
                rptDataSource1 = New ReportDataSource("DataSet1", dssub.Tables("InvoiceTail"))
                ReportViewer1.ProcessingMode = ProcessingMode.Local

                Select Case papertype
                    Case Is = "A4"
                        ReportViewer1.LocalReport.ReportPath = "" + Application.StartupPath + "\QuotationRpt.rdlc"
                    Case Is = "A5"
                        ReportViewer1.LocalReport.ReportPath = "" + Application.StartupPath + "\QuotationRptA5.rdlc"
                End Select




                Dim myParam1 As New ReportParameter("invoiceno", listdata(0))
                ReportViewer1.LocalReport.SetParameters(myParam1)
                Dim myParam2 As New ReportParameter("invoicedt", listdata(1))
                ReportViewer1.LocalReport.SetParameters(myParam2)
                Dim myParam3 As New ReportParameter("duedate", listdata(31))
                ReportViewer1.LocalReport.SetParameters(myParam3)
                Dim myParam4 As New ReportParameter("companyname", listdata(5))
                ReportViewer1.LocalReport.SetParameters(myParam4)
                Dim myParam5 As New ReportParameter("companyaddr", listdata(6))
                ReportViewer1.LocalReport.SetParameters(myParam5)
                Dim myParam6 As New ReportParameter("companyphoneno", listdata(9))
                ReportViewer1.LocalReport.SetParameters(myParam6)
                Dim myParam7 As New ReportParameter("contactname", listdata(11))
                ReportViewer1.LocalReport.SetParameters(myParam7)
                Dim myParam8 As New ReportParameter("contactbilladdr", listdata(12))
                ReportViewer1.LocalReport.SetParameters(myParam8)
                Dim myParam9 As New ReportParameter("contactshipaddr", listdata(13))
                ReportViewer1.LocalReport.SetParameters(myParam9)
                Dim myParam10 As New ReportParameter("contactgstno", listdata(14))
                ReportViewer1.LocalReport.SetParameters(myParam10)
                Dim myParam11 As New ReportParameter("contactphone", listdata(16))
                ReportViewer1.LocalReport.SetParameters(myParam11)


                Dim myParam12 As New ReportParameter("subtotal", listdata(19))
                ReportViewer1.LocalReport.SetParameters(myParam12)

                Dim myParam14 As New ReportParameter("grandtotal", listdata(25))
                ReportViewer1.LocalReport.SetParameters(myParam14)

                Dim myParam15 As New ReportParameter("refno", listdata(2))
                ReportViewer1.LocalReport.SetParameters(myParam15)
                Dim myParam16 As New ReportParameter("companygstno", listdata(10))
                ReportViewer1.LocalReport.SetParameters(myParam16)

                Dim bankdata As New List(Of String)
                bankdata = obj.GetMoreValueFromQuery("select bank_name,acc_name,acc_no,'' from bankview where company_id=" + listdata(27) + "", 4)
                Dim myParam17 As New ReportParameter("accountno", bankdata(2))
                ReportViewer1.LocalReport.SetParameters(myParam17)
                Dim myParam18 As New ReportParameter("accountname", bankdata(1))
                ReportViewer1.LocalReport.SetParameters(myParam18)
                Dim myParam19 As New ReportParameter("bankname", bankdata(0))
                ReportViewer1.LocalReport.SetParameters(myParam19)

                Dim myParam20 As New ReportParameter("overalldiscamt", listdata(20))
                ReportViewer1.LocalReport.SetParameters(myParam20)
                Dim myParam21 As New ReportParameter("shipcost", listdata(22))
                ReportViewer1.LocalReport.SetParameters(myParam21)
                Dim myParam22 As New ReportParameter("roundoff", listdata(24))
                ReportViewer1.LocalReport.SetParameters(myParam22)

                Dim gsttype As String = If(listdata(3) = listdata(15), "GST", "IGST")

                Select Case gsttype
                    Case Is = "GST"
                        Dim myParam23 As New ReportParameter("cgst", CDbl(listdata(21)) / 2)
                        ReportViewer1.LocalReport.SetParameters(myParam23)
                        Dim myParam24 As New ReportParameter("sgst", CDbl(listdata(21)) / 2)
                        ReportViewer1.LocalReport.SetParameters(myParam24)
                        Dim myParam25 As New ReportParameter("igst", 0)
                        ReportViewer1.LocalReport.SetParameters(myParam25)
                    Case Is = "IGST"
                        Dim myParam23 As New ReportParameter("cgst", 0)
                        ReportViewer1.LocalReport.SetParameters(myParam23)
                        Dim myParam24 As New ReportParameter("sgst", 0)
                        ReportViewer1.LocalReport.SetParameters(myParam24)
                        Dim myParam25 As New ReportParameter("igst", listdata(21))
                        ReportViewer1.LocalReport.SetParameters(myParam25)
                End Select
                Dim myParam26 As New ReportParameter("reversecharge", If(listdata(26) = "1", "Reverse Charge Applied", ""))
                ReportViewer1.LocalReport.SetParameters(myParam26)

                Dim myParam27 As New ReportParameter("advanceamt", If(listdata(23) = "1", obj.GetOneValueFromQuery("select sum(advance_amt) from advance_tbl where bill_no='" + listdata(28) + "'"), "0"))
                ReportViewer1.LocalReport.SetParameters(myParam27)
                Dim myParam28 As New ReportParameter("notes", listdata(18))
                ReportViewer1.LocalReport.SetParameters(myParam28)

                Dim myParam29 As New ReportParameter("amountinwords", obj.AmountInWords(listdata(25)))
                ReportViewer1.LocalReport.SetParameters(myParam29)
                Dim cess As Double = listdata(30)
                Dim myParam30 As New ReportParameter("taxinwords", obj.AmountInWords(CDbl(listdata(21)) + cess))
                ReportViewer1.LocalReport.SetParameters(myParam30)
                Dim myParam31 As New ReportParameter("cess", cess)
                ReportViewer1.LocalReport.SetParameters(myParam31)
                Dim myParam32 As New ReportParameter("companystate", listdata(3))
                ReportViewer1.LocalReport.SetParameters(myParam32)
                Dim myParam33 As New ReportParameter("companycity", listdata(7))
                ReportViewer1.LocalReport.SetParameters(myParam33)


                Dim img As Byte() = obj.GetImage("select company_logo from company_tbl where company_id=" + listdata(27) + "")

                dr2 = logoimg.Tables("Image").NewRow()
                dr2("company_id") = listdata(27)
                dr2("company_logo") = img
                logoimg.Tables("Image").Rows.Add(dr2)
                rptDataSource2 = New ReportDataSource("DataSet2", logoimg.Tables("Image"))
                'Dim myParam15 As New ReportParameter("logo", Convert.ToBase64String(ByteToImage(listdata(30))))
                'ReportViewer1.LocalReport.SetParameters(myParam15)



                ReportViewer1.LocalReport.Refresh()
                ReportViewer1.LocalReport.DataSources.Add(rptDataSource1)
                ReportViewer1.LocalReport.DataSources.Add(rptDataSource2)
                ReportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.Normal)


            Catch ex As Exception

            End Try






        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Sub PurchaseReport(ByVal p1 As String, ByVal papertype As String)
        Try
            Dim dssub As New SubReport
            Dim logoimg As New Logo
            Dim listdata As New List(Of String)
            Dim dr1, dr2 As Data.DataRow
            Dim dtsubreport, dtlogo As New DataTable
            dtsubreport = obj.getdatatable("select item_name & '-' & item_desc, gst_id, unit_format, item_qty, item_rate, item_disc, item_amount,item_tax,item_cess,tax_amt,cess_amt from PurchaseSubReport where Purchase_no='" + p1 + "'")
            For i = 0 To dtsubreport.Rows.Count - 1
                dr1 = dssub.Tables("InvoiceTail").NewRow()
                dr1("No") = i + 1
                dr1("Name") = dtsubreport.Rows(i).Item(0).ToString
                dr1("HSNSAC") = dtsubreport.Rows(i).Item(1).ToString
                dr1("UOM") = dtsubreport.Rows(i).Item(2).ToString
                dr1("Qty") = dtsubreport.Rows(i).Item(3).ToString
                dr1("Rate") = dtsubreport.Rows(i).Item(4).ToString
                dr1("discpercent") = dtsubreport.Rows(i).Item(5).ToString
                dr1("Amount") = dtsubreport.Rows(i).Item(6).ToString
                dr1("taxpercent") = dtsubreport.Rows(i).Item(7).ToString
                dr1("TotalAmt") = (CDbl(dtsubreport.Rows(i).Item(6).ToString) + CDbl(dtsubreport.Rows(i).Item(9).ToString) + CDbl(dtsubreport.Rows(i).Item(10).ToString)).ToString
                dssub.Tables("InvoiceTail").Rows.Add(dr1)
            Next

            'ReportViewer1.ProcessingMode = ProcessingMode.Local
            'ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Report.rdlc")
            'Dim dsCustomers As Customers = GetData("select top 20 * from customers")
            'Dim datasource As New ReportDataSource("Customers", dsCustomers.Tables(0))
            'ReportViewer1.LocalReport.DataSources.Clear()
            'ReportViewer1.LocalReport.DataSources.Add(datasource)

            listdata = obj.GetMoreValueFromQuery("select user_Purchase_no, Purchase_dt, " & _
                                               "ref_no,  billing_state," & _
                                               " pan_no, comp_company_name, " & _
                                               "comp_billing_address, billing_city, " & _
                                               "billing_state, comp_phone_no," & _
                                               "  comp_gst_no, company_name," & _
                                               "  cont_billing_address,ship_address, " & _
                                               " cont_gst_no, cont_place_supply, " & _
                                               "cont_phone_no, email_id, vendor_notes," & _
                                               " sub_total, overall_disc_amt,total_tax," & _
                                               " shpcost_amt,'0', roundoff_amt," & _
                                               " grand_total,reverse_flg,company_id," & _
                                               " Purchase_no, contact_no,total_cess  " & _
                                               "from PurchaseMainReport where Purchase_no='" + p1 + "'", 31)


            Dim rptDataSource1, rptDataSource2 As ReportDataSource
            Try
                rptDataSource1 = New ReportDataSource("DataSet1", dssub.Tables("InvoiceTail"))
                ReportViewer1.ProcessingMode = ProcessingMode.Local

                Select Case papertype
                    Case Is = "A4"
                        ReportViewer1.LocalReport.ReportPath = "" + Application.StartupPath + "\PurchaseRpt.rdlc"
                    Case Is = "A5"
                        ReportViewer1.LocalReport.ReportPath = "" + Application.StartupPath + "\PurchaseRptA5.rdlc"
                End Select




                Dim myParam1 As New ReportParameter("invoiceno", listdata(0))
                ReportViewer1.LocalReport.SetParameters(myParam1)
                Dim myParam2 As New ReportParameter("invoicedt", listdata(1))
                ReportViewer1.LocalReport.SetParameters(myParam2)
                'Dim myParam3 As New ReportParameter("duedate", Format(CDate(listdata(1)).AddDays(15), "dd/MM/yyyy"))
                'ReportViewer1.LocalReport.SetParameters(myParam3)
                Dim myParam4 As New ReportParameter("companyname", listdata(5))
                ReportViewer1.LocalReport.SetParameters(myParam4)
                Dim myParam5 As New ReportParameter("companyaddr", listdata(6))
                ReportViewer1.LocalReport.SetParameters(myParam5)
                Dim myParam6 As New ReportParameter("companyphoneno", listdata(9))
                ReportViewer1.LocalReport.SetParameters(myParam6)
                Dim myParam7 As New ReportParameter("contactname", listdata(11))
                ReportViewer1.LocalReport.SetParameters(myParam7)
                Dim myParam8 As New ReportParameter("contactbilladdr", listdata(12))
                ReportViewer1.LocalReport.SetParameters(myParam8)
                Dim myParam9 As New ReportParameter("contactshipaddr", listdata(13))
                ReportViewer1.LocalReport.SetParameters(myParam9)
                Dim myParam10 As New ReportParameter("contactgstno", listdata(14))
                ReportViewer1.LocalReport.SetParameters(myParam10)
                Dim myParam11 As New ReportParameter("contactphone", listdata(16))
                ReportViewer1.LocalReport.SetParameters(myParam11)


                Dim myParam12 As New ReportParameter("subtotal", listdata(19))
                ReportViewer1.LocalReport.SetParameters(myParam12)

                Dim myParam14 As New ReportParameter("grandtotal", listdata(25))
                ReportViewer1.LocalReport.SetParameters(myParam14)

                Dim myParam15 As New ReportParameter("refno", listdata(2))
                ReportViewer1.LocalReport.SetParameters(myParam15)
                Dim myParam16 As New ReportParameter("companygstno", listdata(10))
                ReportViewer1.LocalReport.SetParameters(myParam16)

                Dim bankdata As New List(Of String)
                bankdata = obj.GetMoreValueFromQuery("select bank_name,acc_name,acc_no,'' from bankview where company_id=" + listdata(27) + "", 4)
                Dim myParam17 As New ReportParameter("accountno", bankdata(2))
                ReportViewer1.LocalReport.SetParameters(myParam17)
                Dim myParam18 As New ReportParameter("accountname", bankdata(1))
                ReportViewer1.LocalReport.SetParameters(myParam18)
                Dim myParam19 As New ReportParameter("bankname", bankdata(0))
                ReportViewer1.LocalReport.SetParameters(myParam19)

                Dim myParam20 As New ReportParameter("overalldiscamt", listdata(20))
                ReportViewer1.LocalReport.SetParameters(myParam20)
                Dim myParam21 As New ReportParameter("shipcost", listdata(22))
                ReportViewer1.LocalReport.SetParameters(myParam21)
                Dim myParam22 As New ReportParameter("roundoff", listdata(24))
                ReportViewer1.LocalReport.SetParameters(myParam22)

                Dim gsttype As String = If(listdata(3) = listdata(15), "GST", "IGST")

                Select Case gsttype
                    Case Is = "GST"
                        Dim myParam23 As New ReportParameter("cgst", CDbl(listdata(21)) / 2)
                        ReportViewer1.LocalReport.SetParameters(myParam23)
                        Dim myParam24 As New ReportParameter("sgst", CDbl(listdata(21)) / 2)
                        ReportViewer1.LocalReport.SetParameters(myParam24)
                        Dim myParam25 As New ReportParameter("igst", 0)
                        ReportViewer1.LocalReport.SetParameters(myParam25)
                    Case Is = "IGST"
                        Dim myParam23 As New ReportParameter("cgst", 0)
                        ReportViewer1.LocalReport.SetParameters(myParam23)
                        Dim myParam24 As New ReportParameter("sgst", 0)
                        ReportViewer1.LocalReport.SetParameters(myParam24)
                        Dim myParam25 As New ReportParameter("igst", listdata(21))
                        ReportViewer1.LocalReport.SetParameters(myParam25)
                End Select
                Dim myParam26 As New ReportParameter("reversecharge", If(listdata(26) = "1", "Reverse Charge Applied", ""))
                ReportViewer1.LocalReport.SetParameters(myParam26)

                Dim myParam27 As New ReportParameter("advanceamt", If(listdata(23) = "1", obj.GetOneValueFromQuery("select sum(advance_amt) from advance_tbl where bill_no='" + listdata(28) + "'"), "0"))
                ReportViewer1.LocalReport.SetParameters(myParam27)
                Dim myParam28 As New ReportParameter("notes", listdata(18))
                ReportViewer1.LocalReport.SetParameters(myParam28)

                Dim myParam29 As New ReportParameter("amountinwords", obj.AmountInWords(listdata(25)))
                ReportViewer1.LocalReport.SetParameters(myParam29)
                Dim cess As Double = listdata(30)
                Dim myParam30 As New ReportParameter("taxinwords", obj.AmountInWords(CDbl(listdata(21)) + cess))
                ReportViewer1.LocalReport.SetParameters(myParam30)
                Dim myParam31 As New ReportParameter("cess", cess)
                ReportViewer1.LocalReport.SetParameters(myParam31)
                Dim myParam32 As New ReportParameter("companystate", listdata(3))
                ReportViewer1.LocalReport.SetParameters(myParam32)
                Dim myParam33 As New ReportParameter("companycity", listdata(7))
                ReportViewer1.LocalReport.SetParameters(myParam33)


                Dim img As Byte() = obj.GetImage("select company_logo from company_tbl where company_id=" + listdata(27) + "")

                dr2 = logoimg.Tables("Image").NewRow()
                dr2("company_id") = listdata(27)
                dr2("company_logo") = img
                logoimg.Tables("Image").Rows.Add(dr2)
                rptDataSource2 = New ReportDataSource("DataSet2", logoimg.Tables("Image"))
                'Dim myParam15 As New ReportParameter("logo", Convert.ToBase64String(ByteToImage(listdata(30))))
                'ReportViewer1.LocalReport.SetParameters(myParam15)



                ReportViewer1.LocalReport.Refresh()
                ReportViewer1.LocalReport.DataSources.Add(rptDataSource1)
                ReportViewer1.LocalReport.DataSources.Add(rptDataSource2)
                ReportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.Normal)


            Catch ex As Exception

            End Try






        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Sub IndentReport(ByVal p1 As String)
        Try
            Dim dssub As New SubReport
            Dim logoimg As New Logo
            Dim listdata As New List(Of String)
            Dim dr1, dr2 As Data.DataRow
            Dim dtsubreport, dtlogo As New DataTable
            dtsubreport = obj.getdatatable("select item_name,item_desc,	pattern,qty	,notes,	gatepass_no,bill_no from Indent_dtl where indent_no='" + p1 + "'")
            For i = 0 To dtsubreport.Rows.Count - 1
                dr1 = dssub.Tables("InvoiceTail").NewRow()
                dr1("No") = i + 1
                dr1("Name") = dtsubreport.Rows(i).Item(0).ToString
                dr1("HSNSAC") = dtsubreport.Rows(i).Item(1).ToString
                dr1("UOM") = dtsubreport.Rows(i).Item(2).ToString
                dr1("Qty") = dtsubreport.Rows(i).Item(3).ToString
                dr1("Rate") = dtsubreport.Rows(i).Item(4).ToString
                dr1("discpercent") = dtsubreport.Rows(i).Item(5).ToString
                dr1("Amount") = dtsubreport.Rows(i).Item(6).ToString
                dr1("taxpercent") = "0"
                dr1("TotalAmt") = "0"
                dssub.Tables("InvoiceTail").Rows.Add(dr1)
            Next

            'ReportViewer1.ProcessingMode = ProcessingMode.Local
            'ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Report.rdlc")
            'Dim dsCustomers As Customers = GetData("select top 20 * from customers")
            'Dim datasource As New ReportDataSource("Customers", dsCustomers.Tables(0))
            'ReportViewer1.LocalReport.DataSources.Clear()
            'ReportViewer1.LocalReport.DataSources.Add(datasource)

            listdata = obj.GetMoreValueFromQuery("select  indent_user_no, company_name, " & _
                                               "phone_no, billing_address, job_no," & _
                                               " indent_dt, indent_no, cont_company_name, " & _
                                               "billing_address AS comp_billing_addr,company_id " & _
                                               "from IndentMainReport where Indent_no='" + p1 + "'", 10)


            Dim rptDataSource1, rptDataSource2 As ReportDataSource
            Try
                rptDataSource1 = New ReportDataSource("DataSet1", dssub.Tables("InvoiceTail"))
                ReportViewer1.ProcessingMode = ProcessingMode.Local
                ReportViewer1.LocalReport.ReportPath = "" + Application.StartupPath + "\IndentRpt.rdlc"
                Dim myParam1 As New ReportParameter("invoiceno", listdata(0))
                ReportViewer1.LocalReport.SetParameters(myParam1)
                Dim myParam2 As New ReportParameter("invoicedt", listdata(5))
                ReportViewer1.LocalReport.SetParameters(myParam2)
                'Dim myParam3 As New ReportParameter("duedate", Format(CDate(listdata(1)).AddDays(15), "dd/MM/yyyy"))
                'ReportViewer1.LocalReport.SetParameters(myParam3)
                Dim myParam4 As New ReportParameter("companyname", listdata(1))
                ReportViewer1.LocalReport.SetParameters(myParam4)
                Dim myParam5 As New ReportParameter("companyaddr", listdata(3))
                ReportViewer1.LocalReport.SetParameters(myParam5)
                Dim myParam6 As New ReportParameter("contactphone", listdata(2))
                ReportViewer1.LocalReport.SetParameters(myParam6)
                Dim myParam7 As New ReportParameter("contactname", listdata(7))
                ReportViewer1.LocalReport.SetParameters(myParam7)
                Dim myParam8 As New ReportParameter("contactbilladdr", listdata(8))
                ReportViewer1.LocalReport.SetParameters(myParam8)
                Dim myParam9 As New ReportParameter("jobno", listdata(4))
                ReportViewer1.LocalReport.SetParameters(myParam9)
               
               


                Dim img As Byte() = obj.GetImage("select company_logo from company_tbl where company_id=" + listdata(9) + "")

                dr2 = logoimg.Tables("Image").NewRow()
                dr2("company_id") = listdata(9)
                dr2("company_logo") = img
                logoimg.Tables("Image").Rows.Add(dr2)
                rptDataSource2 = New ReportDataSource("DataSet2", logoimg.Tables("Image"))
                
                ReportViewer1.LocalReport.Refresh()
                ReportViewer1.LocalReport.DataSources.Add(rptDataSource1)
                ReportViewer1.LocalReport.DataSources.Add(rptDataSource2)
                ReportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.Normal)


            Catch ex As Exception

            End Try
        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub AdvanceReport(ByVal p1 As String)
        
        Try

            Dim logoimg As New Logo
            Dim listdata As New List(Of String)
            Dim dr2 As Data.DataRow
            Dim dtlogo As New DataTable
          

          
            listdata = obj.GetMoreValueFromQuery("select  user_advance_no," & _
                                                 " company_name,  comp_company_name," & _
                                                 " advance_dt, advance_amt, tax_amt, " & _
                                                 "cess_amt, total_amt,bill_no, voucher_no," & _
                                                 " comp_phone_no, comp_gst_no, comp_billing_address, gst_no," & _
                                                 " billing_address, billing_state, billing_city, billing_pincode," & _
                                                 " phone_no, company_id, " & _
                                                 "advance_no,contact_no,item_no,tax_percent,place_supply from AdvanceMainReport where advance_no='" + p1 + "'", 25)


            Dim rptDataSource2 As ReportDataSource
            Try
                ReportViewer1.ProcessingMode = ProcessingMode.Local
                ReportViewer1.LocalReport.ReportPath = "" + Application.StartupPath + "\AdvanceRpt.rdlc"
                Dim myParam1 As New ReportParameter("invoiceno", listdata(0))
                ReportViewer1.LocalReport.SetParameters(myParam1)
                Dim myParam2 As New ReportParameter("invoicedt", listdata(3))
                ReportViewer1.LocalReport.SetParameters(myParam2)
                'Dim myParam3 As New ReportParameter("duedate", Format(CDate(listdata(1)).AddDays(15), "dd/MM/yyyy"))
                'ReportViewer1.LocalReport.SetParameters(myParam3)
                Dim myParam4 As New ReportParameter("companyname", listdata(2))
                ReportViewer1.LocalReport.SetParameters(myParam4)
                Dim myParam5 As New ReportParameter("companyaddr", listdata(12))
                ReportViewer1.LocalReport.SetParameters(myParam5)

                Dim myParam6 As New ReportParameter("contactphone", listdata(18))
                ReportViewer1.LocalReport.SetParameters(myParam6)
                Dim myParam7 As New ReportParameter("contactname", listdata(1))
                ReportViewer1.LocalReport.SetParameters(myParam7)
                Dim myParam8 As New ReportParameter("contactbilladdr", listdata(14))
                ReportViewer1.LocalReport.SetParameters(myParam8)
                Dim myParam9 As New ReportParameter("companygstno", listdata(11))
                ReportViewer1.LocalReport.SetParameters(myParam9)
                Dim myParam10 As New ReportParameter("companyphoneno", listdata(10))
                ReportViewer1.LocalReport.SetParameters(myParam10)



                Dim myParam11 As New ReportParameter("itemname", obj.GetOneValueFromQuery("select item_name from item_tbl where item_no='" + listdata(22) + "'"))
                ReportViewer1.LocalReport.SetParameters(myParam11)
                Dim myParam12 As New ReportParameter("advanceamt", listdata(4))
                ReportViewer1.LocalReport.SetParameters(myParam12)
                If (listdata(24) = listdata(15)) Then
                    Dim myParam13 As New ReportParameter("cgst", CDbl(listdata(5)) / 2)
                    ReportViewer1.LocalReport.SetParameters(myParam13)
                    Dim myParam14 As New ReportParameter("sgst", CDbl(listdata(5)) / 2)
                    ReportViewer1.LocalReport.SetParameters(myParam14)
                    Dim myParam15 As New ReportParameter("igst", 0)
                    ReportViewer1.LocalReport.SetParameters(myParam15)
                Else
                    Dim myParam13 As New ReportParameter("cgst", 0)
                    ReportViewer1.LocalReport.SetParameters(myParam13)
                    Dim myParam14 As New ReportParameter("sgst", 0)
                    ReportViewer1.LocalReport.SetParameters(myParam14)
                    Dim myParam15 As New ReportParameter("igst", listdata(5))
                    ReportViewer1.LocalReport.SetParameters(myParam15)
                End If

              
                Dim myParam16 As New ReportParameter("gstpercent", listdata(23))
                ReportViewer1.LocalReport.SetParameters(myParam16)
                Dim myParam17 As New ReportParameter("cess", listdata(6))
                ReportViewer1.LocalReport.SetParameters(myParam17)
                Dim myParam18 As New ReportParameter("totalamount", listdata(7))
                ReportViewer1.LocalReport.SetParameters(myParam18)


                Dim img As Byte() = obj.GetImage("select company_logo from company_tbl where company_id=" + listdata(19) + "")

                dr2 = logoimg.Tables("Image").NewRow()
                dr2("company_id") = listdata(19)
                dr2("company_logo") = img
                logoimg.Tables("Image").Rows.Add(dr2)
                rptDataSource2 = New ReportDataSource("DataSet2", logoimg.Tables("Image"))

                ReportViewer1.LocalReport.Refresh()
                ReportViewer1.LocalReport.DataSources.Add(rptDataSource2)
                ReportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.Normal)


            Catch ex As Exception

            End Try
        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Sub StockCurrentReport()
        Dim dssub As New CurrentStock

        Dim stockdt As DataTable
        stockdt = obj.getdatatable("select item_name, qty,sale_rate, item_no from currentstock")
        Dim rate, qty, value As Double
        For i = 0 To stockdt.Rows.Count - 1
            qty = stockdt.Rows(i).Item(1).ToString
            rate = stockdt.Rows(i).Item(2).ToString
            value = qty * rate
            dssub.Tables("stocktbl").Rows.Add(i + 1, stockdt.Rows(i).Item(0).ToString, qty.ToString, rate.ToString, value.ToString)
        Next
        Dim listdata As New List(Of String)
        listdata = obj.GetMoreValueFromQuery("select  billing_state," & _
                                                "  company_name, " & _
                                                "billing_address, billing_city, " & _
                                                " phone_no," & _
                                                "  gst_no from company_tbl where company_id=" + S.GetCompanyId + "", 6)


        Dim rptDataSource1, rptDataSource2 As ReportDataSource
        Try
            rptDataSource1 = New ReportDataSource("DataSet1", dssub.Tables("stocktbl"))
            ReportViewer1.ProcessingMode = ProcessingMode.Local
            ReportViewer1.LocalReport.ReportPath = "" + Application.StartupPath + "\StockSummaryRpt.rdlc"



            Dim myParam1 As New ReportParameter("state", listdata(0))
            ReportViewer1.LocalReport.SetParameters(myParam1)
            Dim myParam2 As New ReportParameter("name", listdata(1))
            ReportViewer1.LocalReport.SetParameters(myParam2)
            Dim myParam3 As New ReportParameter("address", listdata(2))
            ReportViewer1.LocalReport.SetParameters(myParam3)
            'Dim myParam4 As New ReportParameter("city", listdata(3))
            'ReportViewer1.LocalReport.SetParameters(myParam4)
            Dim myParam5 As New ReportParameter("phoneno", listdata(4))
            ReportViewer1.LocalReport.SetParameters(myParam5)
            Dim myParam6 As New ReportParameter("gstno", listdata(5))
            ReportViewer1.LocalReport.SetParameters(myParam6)
           


            Dim img As Byte() = obj.GetImage("select company_logo from company_tbl where company_id=" + S.GetCompanyId + "")
            Dim logoimg As New Logo
            Dim dr2 As DataRow
            dr2 = logoimg.Tables("Image").NewRow()
            dr2("company_id") = S.GetCompanyId
            dr2("company_logo") = img
            logoimg.Tables("Image").Rows.Add(dr2)
            rptDataSource2 = New ReportDataSource("DataSet2", logoimg.Tables("Image"))
        



            ReportViewer1.LocalReport.Refresh()
            ReportViewer1.LocalReport.DataSources.Add(rptDataSource1)
            ReportViewer1.LocalReport.DataSources.Add(rptDataSource2)
            ReportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.Normal)
        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub LedgerReport(ByVal code As String, ByVal fd As String, ByVal td As String)
        Try

       
            Dim GetOpeningStockFromdate As String = Format(CDate(obj.GetOneValueFromQuery("select min(invoice_dt) from WholeInvoice where contact_no='" + code + "'")).AddDays(-1), "dd/MM/yyyy")
            Dim GetOpeningStockTodate As String = Format(CDate(td).AddDays(-1), "dd/MM/yyyy")

            Dim strsalespaid As String = obj.GetOneValueFromQuery("select sum(grand_total) from WholeInvoice where contact_no='" + code + "' and invoice_dt between #" + obj.ConvDtFrmt(GetOpeningStockFromdate, "MM/dd/yyyy") + "# and #" + obj.ConvDtFrmt(GetOpeningStockTodate, "MM/dd/yyyy") + "# and payment_status=1")
            Dim salespaid As Double = If(strsalespaid = "", 0, strsalespaid)
            Dim StrSalesnotpay As String = obj.GetOneValueFromQuery("select sum(grand_total) from WholeInvoice where contact_no='" + code + "' and invoice_dt between #" + GetOpeningStockFromdate + "# and #" + GetOpeningStockTodate + "# and payment_status=0")
            Dim Salesnotpay As Double = If(StrSalesnotpay = "", 0, StrSalesnotpay)

            Dim OpeningStock As Double = If(Salesnotpay >= salespaid, Salesnotpay - salespaid, salespaid - Salesnotpay)
            If (CDate(fd) < CDate(GetOpeningStockFromdate)) Then
                OpeningStock = 0
            Else
                OpeningStock = If(Salesnotpay >= salespaid, Salesnotpay - salespaid, salespaid - Salesnotpay)
            End If



            Dim query1, query2, query3, query4, query5 As String




            query1 = "select  IIf(invtype='SUPPLY', 'SUPPLY', 'INVOICE') as voucher_type,Format(invoice_dt,'dd/MM/yyyy') as voucher_date,'0' " & _
              "as credit_amt,grand_total as debit_amt,invoice_no from" & _
                " wholeinvoice where contact_no='" + code + "' and invoice_dt between #" + obj.ConvDtFrmt(fd, "MM/dd/yyyy") + "# and #" + obj.ConvDtFrmt(td, "MM/dd/yyyy") + "#"

            query2 = "select  'Receipt' as voucher_type,Format(voucher_dt,'dd/MM/yyyy') as voucher_date,voucher_amt as credit_amt,'0' as debit_amt,voucher_no from" & _
              " voucher_tbl where contact_no='" + code + "' and voucher_dt between #" + obj.ConvDtFrmt(fd, "MM/dd/yyyy") + "# and #" + obj.ConvDtFrmt(td, "MM/dd/yyyy") + "# and vouchercpt_flg=1"

            query4 = "select  'Payment' as voucher_type,Format(voucher_dt,'dd/MM/yyyy') as voucher_date,'0' as credit_amt,voucher_amt as debit_amt,voucher_no from" & _
              " voucher_tbl where contact_no='" + code + "' and voucher_dt between #" + obj.ConvDtFrmt(fd, "MM/dd/yyyy") + "# and #" + obj.ConvDtFrmt(td, "MM/dd/yyyy") + "# and voucherpaymt_flg=1"

            query5 = "select  'Purchase' as voucher_type,Format(purchase_dt,'dd/MM/yyyy') as voucher_date,grand_total as credit_amt,'0' as debit_amt,purchase_no from" & _
             " purchase_hdr where contact_no='" + code + "' and purchase_dt between #" + obj.ConvDtFrmt(fd, "MM/dd/yyyy") + "# and #" + obj.ConvDtFrmt(td, "MM/dd/yyyy") + "#"

            query3 = "select  voucher_type,Format(voucher_dt,'dd/MM/yyyy') as voucher_date,IIf(voucher_type='Credit', refund_value, '0') as credit_amt,IIf(voucher_type='Debit',  refund_value, '0') as debit_amt,credit_debit_no from" & _
              " Credit_debit_tbl where contact_no='" + code + "' and voucher_dt between #" + obj.ConvDtFrmt(fd, "MM/dd/yyyy") + "# and #" + obj.ConvDtFrmt(td, "MM/dd/yyyy") + "#"


            Dim query As String
            query = query1 + " union " + query2 + " union " + query3 + " union " + query4 + " union " + query5

            Dim dtcollection As New DataTable
            Dim querylist As New List(Of String)
            dtcollection = obj.getdatatable(query)



            Dim c As Integer = 1

            If OpeningStock = 0 Then
                querylist.Add("insert into ledger_tbl( transaction_dt, account_id, contact_no, voucher_type, vou_inv_no, credit_amt, debit_amt) values" & _
                               "('" + fd + "','To Opening Balance'," & _
                               "'" + code + "',''," & _
                               "'',0," + OpeningStock.ToString + ")")
            Else
                If Salesnotpay - salespaid > 0 Then
                    querylist.Add("insert into ledger_tbl( transaction_dt, account_id, contact_no, voucher_type, vou_inv_no, credit_amt, debit_amt) values" & _
                                 "('" + fd + "','To Opening Balance'," & _
                                 "'" + code + "',''," & _
                                 "'',0," + OpeningStock.ToString + ")")
                Else
                    querylist.Add("insert into ledger_tbl( transaction_dt, account_id, contact_no, voucher_type, vou_inv_no, credit_amt, debit_amt) values" & _
                                "('" + fd + "','By Opening Balance'," & _
                                "'" + code + "',''," & _
                                "''," + OpeningStock.ToString + ",0)")
                End If

            End If

           

            Dim getdata
            For ab = 0 To dtcollection.Rows.Count - 1
                getdata = getaccountid(dtcollection.Rows(ab).Item(4).ToString, dtcollection.Rows(ab).Item(0).ToString)
                querylist.Add("insert into ledger_tbl( transaction_dt, account_id, contact_no, voucher_type, vou_inv_no, credit_amt, debit_amt) values" & _
                              "('" + dtcollection.Rows(ab).Item(1).ToString + "','" + getdata(0) + "'," & _
                              "'" + code + "','" + getdata(1) + "'," & _
                              "'" + dtcollection.Rows(ab).Item(4).ToString + "'," + dtcollection.Rows(ab).Item(2).ToString + "," + dtcollection.Rows(ab).Item(3).ToString + ")")
            Next

            Dim result As Boolean = obj.TransactionInsert(querylist)
            Select Case result
                Case True

                Case Else
                    MsgBox("Ledger Not Inserted suceessfully , Please check")
                    Exit Sub
            End Select

            Dim dt As New Ledger
            Dim dr1, dr2 As Data.DataRow
            Dim dtledger As DataTable = obj.getdatatable("select transaction_dt, account_id, voucher_type, vou_inv_no,debit_amt, credit_amt from ledger_tbl")
            For i = 0 To dtledger.Rows.Count - 1
                dr1 = dt.Tables("Ledger").NewRow()
                dr1("Date") = obj.ConvDtFrmt(dtledger.Rows(i).Item(0).ToString, "dd/MM/yyyy")
                dr1("Particulars") = dtledger.Rows(i).Item(1).ToString
                dr1("VoucherType") = dtledger.Rows(i).Item(2).ToString
                dr1("VoucherNo") = dtledger.Rows(i).Item(3).ToString
                dr1("Debit") = dtledger.Rows(i).Item(4).ToString
                dr1("Credit") = dtledger.Rows(i).Item(5).ToString
                dt.Tables("Ledger").Rows.Add(dr1)
            Next


            Dim rptDataSource1, rptDataSource2 As ReportDataSource



            rptDataSource1 = New ReportDataSource("DataSet1", dt.Tables("Ledger"))
            ReportViewer1.ProcessingMode = ProcessingMode.Local
            ReportViewer1.LocalReport.ReportPath = "" + Application.StartupPath + "\LedgerStmtRpt.rdlc"

            Dim closestock As Double = obj.GetOneValueFromQuery("select sum(debit_amt)-sum(credit_amt) from ledger_tbl ")
            Select Case closestock
                Case Is > 0
                    Dim debit = obj.GetOneValueFromQuery("select sum(debit_amt) from ledger_tbl ")
                    Dim myParam1 As New ReportParameter("closedebit", debit)
                    ReportViewer1.LocalReport.SetParameters(myParam1)
                    Dim myParam4 As New ReportParameter("closecredit", obj.GetOneValueFromQuery("select sum(credit_amt) from ledger_tbl "))
                    ReportViewer1.LocalReport.SetParameters(myParam4)
                    Dim myParam5 As New ReportParameter("closefinaldebit", "")
                    ReportViewer1.LocalReport.SetParameters(myParam5)
                    Dim myParam6 As New ReportParameter("closefinalcredit", closestock)
                    ReportViewer1.LocalReport.SetParameters(myParam6)
                    Dim myParam15 As New ReportParameter("closedebitgrand", debit)
                    ReportViewer1.LocalReport.SetParameters(myParam15)
                    Dim myParam16 As New ReportParameter("closecreditgrand", debit)
                    ReportViewer1.LocalReport.SetParameters(myParam16)

                Case Else
                    Dim credit = obj.GetOneValueFromQuery("select sum(credit_Amt) from ledger_tbl ")
                    Dim myParam1 As New ReportParameter("closedebit", obj.GetOneValueFromQuery("select sum(debit_amt) from ledger_tbl "))
                    ReportViewer1.LocalReport.SetParameters(myParam1)
                    Dim myParam4 As New ReportParameter("closecredit", credit)
                    ReportViewer1.LocalReport.SetParameters(myParam4)
                    Dim myParam5 As New ReportParameter("closefinaldebit", closestock)
                    ReportViewer1.LocalReport.SetParameters(myParam5)
                    Dim myParam6 As New ReportParameter("closefinalcredit", "")
                    ReportViewer1.LocalReport.SetParameters(myParam6)
                    Dim myParam15 As New ReportParameter("closedebitgrand", credit)
                    ReportViewer1.LocalReport.SetParameters(myParam15)
                    Dim myParam16 As New ReportParameter("closecreditgrand", credit)
                    ReportViewer1.LocalReport.SetParameters(myParam16)
            End Select


            Dim img As Byte() = obj.GetImage("select company_logo from company_tbl where company_id=" + SharedData.companyid + "")
            Dim logoimg As New Logo
            dr2 = logoimg.Tables("Image").NewRow()
            dr2("company_id") = SharedData.companyid
            dr2("company_logo") = img
            logoimg.Tables("Image").Rows.Add(dr2)
            rptDataSource2 = New ReportDataSource("DataSet2", logoimg.Tables("Image"))




            Dim listdata = obj.GetMoreValueFromQuery("select company_name,billing_address,phone_no,gst_no " & _
                                                 "from company_tbl where company_id=" + SharedData.companyid + "", 4)



            Try
                Dim myParam7 As New ReportParameter("companyname", listdata(0))
                ReportViewer1.LocalReport.SetParameters(myParam7)
                Dim myParam8 As New ReportParameter("companyaddr", listdata(1))
                ReportViewer1.LocalReport.SetParameters(myParam8)
                Dim myParam9 As New ReportParameter("companyphoneno", listdata(2))
                ReportViewer1.LocalReport.SetParameters(myParam9)
                Dim myParam11 As New ReportParameter("companygstno", listdata(3))
                ReportViewer1.LocalReport.SetParameters(myParam11)

                Dim myParam12 As New ReportParameter("contactname", obj.GetOneValueFromQuery("select company_name from contact_tbl where contact_no='" + code + "'"))
                ReportViewer1.LocalReport.SetParameters(myParam12)
                Dim myParam13 As New ReportParameter("fromdate", fd)
                ReportViewer1.LocalReport.SetParameters(myParam13)
                Dim myParam14 As New ReportParameter("todate", td)
                ReportViewer1.LocalReport.SetParameters(myParam14)

                ReportViewer1.LocalReport.Refresh()
                ReportViewer1.LocalReport.DataSources.Add(rptDataSource1)
                ReportViewer1.LocalReport.DataSources.Add(rptDataSource2)
                ReportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.Normal)
            Catch ex As Exception

            End Try
            obj.QueryExecution("delete from ledger_tbl")
        Catch ex As Exception

        End Try
    End Sub
    Function getaccountid(ByVal id As String, ByVal type As String) As List(Of String)
        Dim result As New List(Of String)
        Select Case type
            Case Is = "Purchase"
                result.Add("From Purchase(Invoice)")
                result.Add("Purchase")
            Case Is = "INVOICE"
                result.Add("To Sales(Invoice)")
                result.Add("Sales")
            Case Is = "SUPPLY"
                result.Add("To Sales(Supply)")
                result.Add("Sales")
            Case Is = "Credit"
                result.Add(type + " Note (" + id + ")")
                result.Add(type)
            Case Is = "Debit"
                result.Add(type + " Note (" + id + ")")
                result.Add(type)
            Case Is = "Receipt"
                Select Case obj.GetOneValueFromQuery("select voucher_type from voucher_tbl where voucher_no='" + id + "'")
                    Case Is = "WS"
                        If (obj.GetOneValueFromQuery("select payment_type from voucher_tbl where voucher_no='" + id + "'") = "Cash") Then
                            result.Add("By Voucher(On Account)")
                            result.Add("RECEIPT(CASH)")
                        Else
                            Dim getdata = obj.GetMoreValueFromQuery("SELECT bank_tbl.bank_name, bank_tbl.acc_no FROM bank_tbl INNER JOIN voucher_tbl ON bank_tbl.ID =Val(voucher_tbl.credit_debit_bank) where voucher_tbl.voucher_no='" + id + "'", 2)
                            result.Add("By Voucher(On Account) - " + getdata(0) + "  A/C No  " + getdata(1) + "")
                            result.Add("RECEIPT(BANK)")
                        End If
                    Case Is = "B2B"

                        If (obj.GetOneValueFromQuery("select payment_type from voucher_tbl where voucher_no='" + id + "'") = "Cash") Then
                            result.Add("By Voucher(Bill No: " + obj.getcolumndatafromquerywithcommas("select invoice_no from WholeInvoice where voucher_no='" + id + "'") + ") ")
                            result.Add("RECEIPT(CASH)")
                        Else
                            Dim getdata = obj.GetMoreValueFromQuery("SELECT bank_tbl.bank_name, bank_tbl.acc_no FROM bank_tbl INNER JOIN voucher_tbl ON bank_tbl.ID =Val(voucher_tbl.credit_debit_bank) where voucher_tbl.voucher_no='" + id + "'", 2)
                            result.Add("By Voucher(Bill No: " + obj.getcolumndatafromquerywithcommas("select invoice_no from WholeInvoice where voucher_no='" + id + "'") + ")  - " + getdata(0) + "  A/C No  " + getdata(1) + "")
                            result.Add("RECEIPT(BANK)")
                        End If
                End Select
            Case Is = "Payment"
                Select Case obj.GetOneValueFromQuery("select voucher_type from voucher_tbl where voucher_no='" + id + "'")
                    Case Is = "WS"
                        If (obj.GetOneValueFromQuery("select payment_type from voucher_tbl where voucher_no='" + id + "'") = "Cash") Then
                            result.Add("By Voucher(On Account)")
                            result.Add("PAYMENT(CASH)")
                        Else
                            Dim getdata = obj.GetMoreValueFromQuery("SELECT bank_tbl.bank_name, bank_tbl.acc_no FROM bank_tbl INNER JOIN voucher_tbl ON bank_tbl.ID =Val(voucher_tbl.credit_debit_bank) where voucher_tbl.voucher_no='" + id + "'", 2)
                            result.Add("By Voucher(On Account) - " + getdata(0) + "  A/C No  " + getdata(1) + "")
                            result.Add("PAYMENT(BANK)")
                        End If
                    Case Is = "B2B"

                        If (obj.GetOneValueFromQuery("select payment_type from voucher_tbl where voucher_no='" + id + "'") = "Cash") Then
                            result.Add("By Voucher(Bill No: " + obj.getcolumndatafromquerywithcommas("select purchase_no from purchase_hdr where voucher_no='" + id + "'") + ") ")
                            result.Add("PAYMENT(CASH)")
                        Else
                            Dim getdata = obj.GetMoreValueFromQuery("SELECT bank_tbl.bank_name, bank_tbl.acc_no FROM bank_tbl INNER JOIN voucher_tbl ON bank_tbl.ID =Val(voucher_tbl.credit_debit_bank) where voucher_tbl.voucher_no='" + id + "'", 2)
                            result.Add("By Voucher(Bill No: " + obj.getcolumndatafromquerywithcommas("select purchase_no from purchase_hdr where voucher_no='" + id + "'") + ")  - " + getdata(0) + "  A/C No  " + getdata(1) + "")
                            result.Add("PAYMENT(BANK)")
                        End If
                End Select
        End Select

        Return result
    End Function
    Sub GatePassReport(ByVal p1 As String)
        Try
            Dim dssub As New SubReport
            Dim logoimg As New Logo
            Dim listdata As New List(Of String)
            Dim dr1, dr2 As Data.DataRow
            Dim dtsubreport, dtlogo As New DataTable

            dtsubreport = obj.getdatatable("select item_name,item_desc,	pattern,qty	,notes,	gatepass_no,bill_no from Indent_dtl where gatepass_no='" + p1 + "'")
            For i = 0 To dtsubreport.Rows.Count - 1
                dr1 = dssub.Tables("InvoiceTail").NewRow()
                dr1("No") = i + 1
                dr1("Name") = dtsubreport.Rows(i).Item(0).ToString
                dr1("HSNSAC") = dtsubreport.Rows(i).Item(1).ToString
                dr1("UOM") = dtsubreport.Rows(i).Item(2).ToString
                dr1("Qty") = dtsubreport.Rows(i).Item(3).ToString
                dr1("Rate") = dtsubreport.Rows(i).Item(4).ToString
                dr1("discpercent") = dtsubreport.Rows(i).Item(5).ToString
                dr1("Amount") = dtsubreport.Rows(i).Item(6).ToString
                dr1("taxpercent") = "0"
                dr1("TotalAmt") = "0"
                dssub.Tables("InvoiceTail").Rows.Add(dr1)
            Next

            'ReportViewer1.ProcessingMode = ProcessingMode.Local
            'ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Report.rdlc")
            'Dim dsCustomers As Customers = GetData("select top 20 * from customers")
            'Dim datasource As New ReportDataSource("Customers", dsCustomers.Tables(0))
            'ReportViewer1.LocalReport.DataSources.Clear()
            'ReportViewer1.LocalReport.DataSources.Add(datasource)

            listdata = obj.GetMoreValueFromQuery("select company_name,billing_address" & _
                                               "from company_tbl where company_id='" + SharedData.companyid + "'", 2)


            Dim rptDataSource1, rptDataSource2 As ReportDataSource
            Try
                rptDataSource1 = New ReportDataSource("DataSet1", dssub.Tables("InvoiceTail"))
                ReportViewer1.ProcessingMode = ProcessingMode.Local
                ReportViewer1.LocalReport.ReportPath = "" + Application.StartupPath + "\IndentRpt.rdlc"
                Dim myParam1 As New ReportParameter("invoiceno", p1)
                ReportViewer1.LocalReport.SetParameters(myParam1)


                Dim myParam4 As New ReportParameter("companyname", listdata(0))
                ReportViewer1.LocalReport.SetParameters(myParam4)
                Dim myParam5 As New ReportParameter("companyaddr", listdata(1))
                ReportViewer1.LocalReport.SetParameters(myParam5)


                Dim img As Byte() = obj.GetImage("select company_logo from company_tbl where company_id=" + SharedData.companyid + "")

                dr2 = logoimg.Tables("Image").NewRow()
                dr2("company_id") = SharedData.companyid
                dr2("company_logo") = img
                logoimg.Tables("Image").Rows.Add(dr2)
                rptDataSource2 = New ReportDataSource("DataSet2", logoimg.Tables("Image"))








                ReportViewer1.LocalReport.Refresh()
                ReportViewer1.LocalReport.DataSources.Add(rptDataSource1)
                ReportViewer1.LocalReport.DataSources.Add(rptDataSource2)
                ReportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.Normal)
            Catch ex As Exception

            End Try
        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Select Case invtype
            Case Is = "INV"
                InvoiceReport(id, "A4")
            Case Is = "SUP"
                SupplyReport(id, "A4")
            Case Is = "QUO"
                QuotationReport(id, "A4")
            Case Is = "PUR"
                PurchaseReport(id, "A4")
        End Select

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Select Case invtype
            Case Is = "INV"
                InvoiceReport(id, "A5")
            Case Is = "SUP"
                SupplyReport(id, "A5")
            Case Is = "QUO"
                QuotationReport(id, "A5")
            Case Is = "PUR"
                PurchaseReport(id, "A5")
        End Select
    End Sub

    Private Sub btninvoice_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btninvoice.Click
        
        Invoice.Show()
        Me.Close()
        Invoice.BringToFront()


    End Sub

    Private Sub btnquotation_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnquotation.Click
        Quotation.Show()
        Me.Close()
        Quotation.BringToFront()
    End Sub

    Private Sub btnsupply_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsupply.Click
        BillOfSupply.Show()
        Me.Close()
        BillOfSupply.BringToFront()
    End Sub

    Private Sub btnpurchase_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnpurchase.Click
        Purchase.Show()
        Me.Close()
        Purchase.BringToFront()
    End Sub
End Class