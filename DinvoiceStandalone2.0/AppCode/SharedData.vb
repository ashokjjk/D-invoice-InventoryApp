Imports System.IO

Public Class SharedData
    Public Shared companyid As String
    Public Shared userid As String
    Public Shared purchaseno As String
    Public Shared Quotationno As String
    Public Shared supplyno As String
    Public Shared posno As String
    Public Shared invoiceno As String

    Sub SetSessiondata(ByVal cid As String, ByVal uid As String)
        companyid = cid
        userid = uid
    End Sub
    Function GetCompanyId() As String
        Return companyid
    End Function

    Function GetUserId() As String
        Return userid
    End Function
    Sub ClearSession()
        companyid = ""
        userid = ""
    End Sub


    Sub SetPurchaseno(ByVal purno As String)
        purchaseno = purno
    End Sub

    Function GetPurchaseno() As String
        Return purchaseno
    End Function

    Sub ClearPurchaseno()
        purchaseno = ""
    End Sub
    Sub SetQuotationno(ByVal purno As String)
        Quotationno = purno
    End Sub

    Function GetQuotationno() As String
        Return Quotationno
    End Function

    Sub ClearQuotationno()
        Quotationno = ""
    End Sub
    Sub SetSupplyno(ByVal purno As String)
        supplyno = purno
    End Sub

    Function GetSupplyno() As String
        Return supplyno
    End Function

    Sub ClearSupplyno()
        supplyno = ""
    End Sub
    Sub SetInvoiceno(ByVal purno As String)
        invoiceno = purno
    End Sub

    Function GetInvoiceno() As String
        Return invoiceno
    End Function

    Sub ClearInvoiceno()
        invoiceno = ""
    End Sub
    Sub SetPOSno(ByVal purno As String)
        posno = purno
    End Sub

    Function GetPOSno() As String
        Return posno
    End Function

    Sub ClearPOSno()
        posno = ""
    End Sub
    Public Shared ReportQuotationno As String
    Public Shared Reportsupplyno As String
    Public Shared Reportinvoiceno As String

    Sub SetReportsupplyno(ByVal purno As String)
        Reportsupplyno = purno
    End Sub

    Function GetReportsupplyno() As String
        Return Reportsupplyno
    End Function

    Sub ClearReportsupplyno()
        Reportsupplyno = ""
    End Sub


    Sub SetReportinvoiceno(ByVal purno As String)
        Reportinvoiceno = purno
    End Sub

    Function GetReportinvoiceno() As String
        Return Reportinvoiceno
    End Function

    Sub ClearReportinvoiceno()
        Reportinvoiceno = ""
    End Sub
    Public Shared Reportpurchaseno As String
    Sub SetReportpurchaseno(ByVal purno As String)
        Reportpurchaseno = purno
    End Sub

    Function GetReportpurchaseno() As String
        Return Reportpurchaseno
    End Function

    Sub ClearReportpurchaseno()
        Reportpurchaseno = ""
    End Sub



    Sub SetReportQuotationno(ByVal purno As String)
        ReportQuotationno = purno
    End Sub

    Function GetReportQuotationno() As String
        Return ReportQuotationno
    End Function

    Sub ClearReportQuotationno()
        ReportQuotationno = ""
    End Sub


    Public Shared ReportIndentno As String
    Sub SetReportIndentno(ByVal purno As String)
        ReportIndentno = purno
    End Sub

    Function GetReportIndentno() As String
        Return ReportIndentno
    End Function

    Sub ClearReportIndentno()
        ReportIndentno = ""
    End Sub



    Public Shared ReportAdvanceno As String
    Sub SetReportAdvanceno(ByVal purno As String)
        ReportAdvanceno = purno
    End Sub

    Function GetReportAdvanceno() As String
        Return ReportAdvanceno
    End Function

    Sub ClearReportAdvanceno()
        ReportAdvanceno = ""
    End Sub


    Public Shared ReportVoucherno As String
    Public Shared ReportVoucherType As String
    Public Shared ReportVoucherAccType As String
    Sub SetReportVoucherno(ByVal a As String, ByVal b As String, ByVal c As String)
        ReportVoucherno = a
        ReportVoucherType = b
        ReportVoucherAccType = c
    End Sub

    Function GetReportVoucherno() As String
        Return ReportVoucherno
    End Function
    Function Type() As String
        Return ReportVoucherType
    End Function
    Function AccType() As String
        Return ReportVoucherAccType
    End Function

    Sub ClearReportVoucherno()
        ReportVoucherno = ""
        ReportVoucherType = ""
        ReportVoucherAccType = ""
    End Sub


    Public Shared contact_code As String
    Public Shared fromdate As String
    Public Shared todate As String
    Sub SetLedgerData(ByVal a As String, ByVal b As String, ByVal c As String)
        contact_code = a
        fromdate = b
        todate = c
    End Sub

    Function GetContactcode() As String
        Return contact_code
    End Function
    Function fnfromdate() As String
        Return fromdate
    End Function
    Function fntodate() As String
        Return todate
    End Function

    Sub ClearLedgerData()
        contact_code = ""
        fromdate = ""
        todate = ""
    End Sub
    Public Shared plfromdate As String
    Public Shared pltodate As String
    Sub SetPlData(ByVal from_date As String, ByVal to_date As String)
        plfromdate = from_date
        pltodate = to_date
    End Sub
    Function fnplfromdate() As String
        Return plfromdate
    End Function
    Function fnpltodate() As String
        Return pltodate
    End Function

    Sub ClearplData()
        plfromdate = ""
        pltodate = ""
    End Sub
    Public Shared dbfromdate As String
    Public Shared dbtodate As String
    Sub SetDayBookData(ByVal from_date As String, ByVal to_date As String)
        dbfromdate = from_date
        dbtodate = to_date
    End Sub
    Function fndbfromdate() As String
        Return dbfromdate
    End Function
    Function fndbtodate() As String
        Return dbtodate
    End Function

    Sub CleardbData()
        dbfromdate = ""
        dbtodate = ""
    End Sub




    Public Shared POSReportInvoiceno As String
    Sub SetPOSReportInvoiceno(ByVal purno As String)
        POSReportInvoiceno = purno
    End Sub

    Function GetPOSReportInvoiceno() As String
        Return POSReportInvoiceno
    End Function

    Sub ClearPOSReportInvoiceno()
        POSReportInvoiceno = ""
    End Sub

    Function getsoftwaretype() As String
        Dim free As String = "c:\windows\System32\dc1800.txt"
        Dim std As String = "c:\windows\System32\dc1801.txt"
        Dim premium As String = "c:\windows\System32\dc1802.txt"
        Dim softtype As String
        Dim s As Integer = If(File.Exists(free), 1, 0) + If(File.Exists(std), 1, 0) + If(File.Exists(premium), 1, 0)
        Select Case s
            Case Is = 0
                softtype = ""
            Case Else
                softtype = If(File.Exists(free), "FREE", "") + If(File.Exists(std), "STD", "") + If(File.Exists(premium), "PREMIUM", "")
        End Select
        Return softtype
    End Function
    Public Shared OutStandType As String
    Sub SetOutStandType(ByVal purno As String)
        OutStandType = purno
    End Sub

    Function GetOutStandType() As String
        Return OutStandType
    End Function

    Sub ClearOutStandType()
        OutStandType = ""
    End Sub


    Public Shared bsfromdate, bstodate As String
    Sub SetBSData(ByVal fd As String, ByVal td As String)
        bsfromdate = fd
        bstodate = td
    End Sub

    Function Getbsfromdate() As String
        Return bsfromdate
    End Function
    Function Getbstodate() As String
        Return bstodate
    End Function

    Sub ClearBSData()
        bsfromdate = ""
        bstodate = ""
    End Sub

    Public Shared CreditDebitNo As String
    Sub SetCDData(ByVal billno As String)
        CreditDebitNo = billno
    End Sub

    Function GetCDData() As String
        Return CreditDebitNo
    End Function


    Sub ClearCDData()
        CreditDebitNo = ""
    End Sub
    

   
    Public Shared POSReportSupplyno As String
    Sub SetPOSReportSupplyno(ByVal purno As String)
        POSReportSupplyno = purno
    End Sub

    Function GetPOSReportSupplyno() As String
        Return POSReportSupplyno
    End Function

    Sub ClearPOSReportSupplyno()
        POSReportSupplyno = ""
    End Sub

    Public Shared PayslipNo As String
    Sub SetPayslipNo(ByVal billno As String)
        PayslipNo = billno
    End Sub

    Function GetPayslipNo() As String
        Return PayslipNo
    End Function
    Sub ClearPayslipNo()
        PayslipNo = ""
    End Sub
   
End Class
