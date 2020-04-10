
Imports System.Net.Mail
Imports System.Security.Cryptography
Imports System.IO
Imports System.Data.OleDb
Imports Excel = Microsoft.Office.Interop.Excel

Public Class ObjClass
    'Dim strcon As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Application.StartupPath + "\dinvoice_db.accdb" + ";Persist Security Info=False; Jet OLEDB:Database Password=dara@1965;"
    Dim strcon As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Application.StartupPath + "\dinvoice_db.mdb" + ";Persist Security Info=False; Jet OLEDB:Database Password=dara@1965;"
    Dim share As New SharedData
    Function GetCountInvoice() As Boolean
        Dim i As Integer = 0
        Dim softtype = share.getsoftwaretype()
        If softtype = "FREE" Then
            i = FindDuplicate("select count(*) from invoice_hdr")
            If (i > 360) Then
                Return False
            Else
                Return True
            End If
        Else
            Return True
        End If
    End Function
    Function GetCountPurchase() As Boolean
        Dim i As Integer = 0
        Dim softtype = share.getsoftwaretype()
        If softtype = "FREE" Then
            i = FindDuplicate("select count(*) from purchase_hdr")
            If (i > 360) Then
                Return False
            Else
                Return True
            End If
        Else
            Return True
        End If
    End Function
    Function GetCountItem() As Boolean
        Dim i As Integer = 0
        i = FindDuplicate("select count(*) from item_tbl")
        Dim softtype = share.getsoftwaretype()
        If softtype = "FREE" Then
            If (i >= 30) Then
                Return False
            Else
                Return True
            End If
        ElseIf softtype = "STD" Then
            If (i >= 100) Then
                Return False
            Else
                Return True
            End If
        Else
            Return True
        End If
    End Function
    Function FindPaperFormat() As String
        Dim softtype = share.getsoftwaretype()
        If softtype = "FREE" Then
            Return "A4"
        ElseIf softtype = "STD" Then
            Return "A4"
        Else
            Return "ALL"
        End If
    End Function
    Function inapos(ByVal s As String) As String
        Dim output As String = s.Replace("'", "''")
        Return output
    End Function
    Function validItem(ByVal s As String) As Boolean
        'must be countdata as a fieldname
        Try
            Dim i As Boolean = False
            Dim conn As New OleDbConnection(strcon)
            Dim cmd As New OleDbCommand("select count(*) from  item_tbl where item_no='" + s + "'", conn)
            cmd.CommandType = Data.CommandType.Text
            conn.Open()
            Dim dr As OleDbDataReader = cmd.ExecuteReader()
            If dr.Read() Then
                i = True
            End If
            conn.Close()
            Return i
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try
    End Function
    Function validContact(ByVal s As String) As Boolean
        'must be countdata as a fieldname
        Try
            Dim i As Boolean = False
            Dim conn As New OleDbConnection(strcon)
            Dim cmd As New OleDbCommand("select count(*) from  contact_tbl where contact_no='" + s + "'", conn)
            cmd.CommandType = Data.CommandType.Text
            conn.Open()
            Dim dr As OleDbDataReader = cmd.ExecuteReader()
            If dr.Read() Then
                i = True
            End If
            conn.Close()
            Return i
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try
    End Function
    Function TextBoxValidate(ByVal list As List(Of String)) As Boolean
        Dim output As Boolean = True
        For i = 0 To list.Count - 1
            If list(i) = "" Then
                output = False
                Exit For
            End If
        Next
        Return output
    End Function
    Sub ContactOpen()
        ContactEdit.Show()
        ContactEdit.BringToFront()
        ContactEdit.Focus()
    End Sub
    Function StrToDouble(ByVal s As String) As Double
        Try
            Return CDbl(s)
        Catch ex As Exception
            Return 0
        End Try
    End Function
    Sub NoApos(ByVal e As System.Windows.Forms.KeyPressEventArgs)
        e.Handled = (Asc(e.KeyChar) = 39)
    End Sub
    Sub TodayDate(ByVal s As TextBox)
        Try
            s.Text = Format(Today, "dd/MM/yyyy")
        Catch ex As Exception
            s.Text = ""
        End Try
    End Sub
    Sub AllCaps(ByVal e As System.Windows.Forms.KeyPressEventArgs, ByVal txt As TextBox)
        If Char.IsLower(e.KeyChar) Then
            'Convert to uppercase, and put at the caret position in the TextBox.
            txt.SelectedText = Char.ToUpper(e.KeyChar)
            e.Handled = True
        End If

    End Sub
    Sub OnlyNoS(ByVal e As System.Windows.Forms.KeyPressEventArgs)
        e.Handled = Not (Char.IsDigit(e.KeyChar) Or e.KeyChar = "." Or Asc(e.KeyChar) = 8)
    End Sub
    Function FdPercCalc(ByVal Amt As Double, ByVal percent As String, Optional ByVal frmt As String = "0.00") As Double
        Try
            Return Format(Amt * (percent / 100), frmt)
        Catch ex As Exception
            Return Format(0, frmt)
        End Try
    End Function
    Function twopt(ByVal s As Double) As Double
        Try
            'Return Decimal.Round(CDec(s), 2) 'Format(, "0.00") Decimal
            Return Math.Round(s, 2, MidpointRounding.AwayFromZero)
        Catch ex As Exception
            Return Math.Round(0.0, 2, MidpointRounding.AwayFromZero)
        End Try
    End Function

    Sub SKUAlert()

        Dim listitems As New List(Of String)
        Dim strmsg As String = ""
        listitems = getcolumndatafromquery("select item_no from item_tbl where skualert_flg=1")
        If listitems.Count = 0 Then
            Exit Sub
        Else
            Dim stockqty, skuqty As Double
            For i = 0 To listitems.Count - 1
                stockqty = GetOneValueFromQuery("select qty from stock_tbl where company_id=" + SharedData.companyid + " and item_no='" + listitems(i) + "'")
                skuqty = GetOneValueFromQuery("select sku_qty from item_tbl where  item_no='" + listitems(i) + "'")
                If stockqty <= skuqty Then
                    strmsg = strmsg + GetOneValueFromQuery("select item_name from item_tbl where item_no='" + listitems(i) + "'") + vbCrLf
                Else
                    Exit Sub
                End If
            Next
        End If
        strmsg = "Stock Quantity for " + vbCrLf + strmsg + " is Low!!!"
        MsgBox(strmsg, MsgBoxStyle.Information)
    End Sub


    Function GetOneRowDT() As DataTable
        Dim dt As New DataTable
        dt.Columns.Add("Item", GetType(String))
        dt.Columns.Add("value", GetType(String))
        For i = 0 To 0
            dt.Rows.Add("Add New", "0")
        Next
        Return dt
    End Function
    Function GetCompanyName_yr() As List(Of String)
        Dim cmpdts As New List(Of String)
        cmpdts = GetMoreValueFromQuery("select company_name,company_yr from company_tbl where company_id=" & Val(share.GetCompanyId) & "", 2)
        cmpdts.Add(share.GetUserId)
        Return cmpdts
    End Function
    Function GetTaxType(ByVal contactno As String) As Integer
        Try
            Select Case GetOneValueFromQuery("select billing_state from company_tbl " & _
                                                        "where company_id=" & SharedData.companyid & "") =
                                                    GetOneValueFromQuery("select place_supply  from contact_tbl " & _
                                                        "where contact_no='" + contactno + "'")
                Case True
                    Return 1
                Case False
                    Return 0
            End Select
        Catch ex As Exception
            Return -1
        End Try
    End Function
    Public Sub ClearTextBox(ByVal root As Control)
        For Each ctrl As Control In root.Controls
            ClearTextBox(ctrl)
            If TypeOf ctrl Is TextBox Then
                CType(ctrl, TextBox).Text = String.Empty
            End If
        Next ctrl
    End Sub
    Public Function ClearCheckBox(ByRef form As Control)

        Dim allTxt As New List(Of Control)
        For Each txt As CheckBox In FindControlRecursive(allTxt, form, GetType(CheckBox))
            'txt.Enabled = False
            txt.Checked = False
        Next
        Return form
    End Function
    Public Shared Function FindControlRecursive(ByVal list As List(Of Control), ByVal parent As Control, ByVal ctrlType As System.Type) As List(Of Control)
        If parent Is Nothing Then Return list
        If parent.GetType Is ctrlType Then
            list.Add(parent)
        End If
        For Each child As Control In parent.Controls
            FindControlRecursive(list, child, ctrlType)
        Next
        Return list
    End Function
    Function ConvDtFrmt(ByVal strdate As String, ByVal dtformat As String) As String
        Try
            Return Format(CDate(strdate), dtformat)
        Catch ex As Exception
            Return Nothing

        End Try
    End Function
    Function saveimage(ByVal img As System.Drawing.Image, ByVal Query As String) As Integer
        Try
            Dim bytImage() As Byte
            Dim ms As New System.IO.MemoryStream
            Dim bmpImage As New Bitmap(img)
            bmpImage.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg)
            bytImage = ms.ToArray()
            ms.Close()
            Dim i As Integer = savephototoDB(Query, bytImage)
            Select Case i
                Case Is >= 1
                    Return 1
                Case Else
                    Return 0
            End Select
        Catch ex As Exception
            Return 0
        End Try
    End Function
    Function TransactionInsert(ByVal QueryCollection As List(Of String)) As Boolean
        Dim Result As String
        Dim myConnection As New OleDbConnection(strcon)
        myConnection.Open()

        ' Start a local transaction
        Dim myTrans As OleDbTransaction = myConnection.BeginTransaction()

        Dim myCommand As New OleDbCommand()
        myCommand.Connection = myConnection
        myCommand.Transaction = myTrans

        Try
            For i = 0 To QueryCollection.Count - 1
                myCommand.CommandText = QueryCollection(i)
                myCommand.ExecuteNonQuery()
            Next
            'commit

            myTrans.Commit()
            Result = True
            Return Result
        Catch ep As Exception
            ' Attempt to roll back the transaction. 
            myTrans.Rollback()
            Result = False
            Return Result
        Finally
            myConnection.Close()
        End Try
    End Function
    Function QueryExecution(ByVal Sql As String) As Integer
        Try
            Dim conn As New OleDbConnection(strcon)
            Dim cmd As New OleDbCommand(Sql, conn)
            cmd.CommandType = Data.CommandType.Text
            conn.Open()
            Dim i As Integer = cmd.ExecuteNonQuery()
            conn.Close()
            Return i
        Catch ex As Exception
            Return 0
            MsgBox(ex.Message)

        End Try
    End Function

    Function FindDuplicate(ByVal Sql As String) As Integer
        'must be countdata as a fieldname
        Try
            Dim i As Integer
            Dim conn As New OleDbConnection(strcon)
            Dim cmd As New OleDbCommand(Sql, conn)
            cmd.CommandType = Data.CommandType.Text
            conn.Open()
            Dim dr As OleDbDataReader = cmd.ExecuteReader()
            If dr.Read() Then
                i = Val(dr(0))
            End If
            conn.Close()
            Return i
        Catch ex As Exception
            MsgBox(ex.Message)
            Return 0
        End Try
    End Function
    Function GetImage(ByVal Sql As String) As Byte()
        'must be countdata as a fieldname
        Try
            Dim i As Byte()
            Dim conn As New OleDbConnection(strcon)
            Dim cmd As New OleDbCommand(Sql, conn)
            cmd.CommandType = Data.CommandType.Text
            conn.Open()
            Dim dr As OleDbDataReader = cmd.ExecuteReader()
            If dr.Read() Then
                i = dr(0)
            End If
            conn.Close()
            Return i
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function
    Function GetOneValueFromQuery(ByVal Sql As String) As String
        'must be countdata as a fieldname
        Try



            Dim i As String
            i = ""
            Dim conn As New OleDbConnection(strcon)
            Dim cmd As New OleDbCommand(Sql, conn)
            cmd.CommandType = Data.CommandType.Text
            conn.Open()
            Dim dr As OleDbDataReader = cmd.ExecuteReader()
            If dr.Read() Then
                Select Case IsDBNull(dr(0))
                    Case Is = True
                        i = ""
                    Case Else
                        i = dr(0)
                End Select

            End If
            conn.Close()
            Return i
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function
    Function GetMoreValueFromQuery(ByVal Sql As String, ByVal countvalue As Integer) As List(Of String)
        Try


            Dim i As New List(Of String)
            Dim conn As New OleDbConnection(strcon)
            Dim cmd As New OleDbCommand(Sql, conn)
            cmd.CommandType = Data.CommandType.Text
            conn.Open()
            Dim dr As OleDbDataReader = cmd.ExecuteReader()
            If dr.Read() Then
                For j = 0 To countvalue - 1
                    Select Case IsDBNull(dr(j))
                        Case Is = True
                            i.Add("")
                        Case Else
                            i.Add(dr(j))
                    End Select

                Next
            End If
            conn.Close()
            Return i
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Function getdataset(ByVal sql As String) As DataSet
        Try

            Dim conn As New OleDbConnection(strcon)
            conn.Open()
            Dim cmd As New OleDbCommand(sql, conn)
            Dim da As New OleDbDataAdapter(cmd)
            Dim ds As New DataSet()
            da.Fill(ds)
            conn.Close()
            Return ds
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function
    Function getdatatable(ByVal sql As String) As DataTable
        Try
            Dim conn As New OleDbConnection(strcon)
            conn.Open()
            Dim cmd As New OleDbCommand(sql, conn)
            Dim da As New OleDbDataAdapter(cmd)
            Dim ds As New DataTable()
            da.Fill(ds)
            conn.Close()
            Return ds
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function
    Function getcolumndatafromquerywithcommas(ByVal sql As String) As String
        Try
            Return String.Join(",", getcolumndatafromquery(sql).ToArray())
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function
    Function getcolumndatafromquery(ByVal sql As String) As List(Of String)

        Try


            Dim list As New List(Of String)

            Dim conn As New OleDbConnection(strcon)
            conn.Open()
            Dim cmd As New OleDbCommand(sql, conn)
            Dim dr As OleDbDataReader = cmd.ExecuteReader()
            While dr.Read()
                Select Case IsDBNull(dr(0))
                    Case Is = True

                    Case Else
                        list.Add(dr(0))
                End Select

            End While
            conn.Close()
            Return list
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try

    End Function
    Function savephototoDB(ByVal sql As String, ByVal bytImage As Byte()) As Integer
        Dim Result As Boolean = True
        Try
            Dim conn As New OleDbConnection(strcon)
            conn.Open()
            Dim cmd As New OleDbCommand(sql, conn)
            cmd.Parameters.AddWithValue("@image", bytImage)
            Dim i As Integer = cmd.ExecuteNonQuery()
            conn.Close()
            Return i
        Catch ex As Exception
            Return 0
        End Try

    End Function
    Function retrievephotofromDB(ByVal sql As String) As Byte()

        Try
            Dim conn As New OleDbConnection(strcon)
            conn.Open()
            Dim command As New System.Data.OleDb.OleDbCommand(sql, conn)
            Dim pictureData As Byte() = DirectCast(command.ExecuteScalar(), Byte())
            conn.Close()
            Return pictureData

        Catch ex As Exception
            Return Nothing
        End Try


    End Function
    Public Function NumberToWords(ByVal number As Integer)
        Dim words As String = ""
        If number = 0 Then
            Return "zero"
        ElseIf number = 100 Then
            Return "One Hundred Only"
        ElseIf number = 1000 Then
            Return "One Thousand Only"
        ElseIf number = 100000 Then
            Return "One Lakh Only"
        ElseIf number = 10000000 Then
            Return "One Crore Only"
        Else
            words = DigitToWords(number)
        End If
        Return words + ""

    End Function

    Private Function DigitToWords(ByVal number As Integer) As String
        Dim numwords As String = ""
        Dim unitsMap As String() = {"", "One", "Two", "Three", "Four", "Five", _
 "Six", "Seven", "Eight", "Nine", "Ten", "Eleven", _
 "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", _
 "Eighteen", "Nineteen"}
        Dim tensMap As String() = {"", "Ten", "Twenty", "Thirty", "Forty", "Fifty", _
"Sixty", "Seventy", "Eighty", "Ninety", ""}
        If number < 20 Then
            Return unitsMap(number)
        ElseIf 20 < number And number < 100 Then
            numwords = tensMap(Math.Truncate(number / 10)) + " " + unitsMap(number Mod 10)
        ElseIf 100 <= number And number < 1000 Then
            numwords = DigitToWords(Math.Truncate(number / 100)) + " Hundred " & _
            "" + tensMap(Math.Truncate((number Mod 100) / 10)) + " " + unitsMap(number Mod 10)
        ElseIf 1000 <= number And number < 100000 Then
            numwords = DigitToWords(Math.Truncate(number / 1000)) + " Thousand " & _
            "" + If(Math.Truncate((number Mod 1000) / 100) = 0, "", DigitToWords(Math.Truncate((number Mod 1000) / 100)) + " Hundred ") & _
            "" + tensMap(Math.Truncate((number Mod 100) / 10)) + " " + unitsMap(number Mod 10)
        ElseIf 100000 <= number And number < 10000000 Then
            numwords = DigitToWords(Math.Truncate(number / 100000)) + " Lakhs " & _
            "" + If(Math.Truncate((number Mod 100000) / 1000) = 0, "", DigitToWords(Math.Truncate((number Mod 100000) / 1000)) + " Thousand ") & _
            "" + If(Math.Truncate((number Mod 1000) / 100) = 0, "", DigitToWords(Math.Truncate((number Mod 1000) / 100)) + " Hundred ") & _
            "" + tensMap(Math.Truncate((number Mod 100) / 10)) + " " + unitsMap(number Mod 10)
        End If
        Return numwords
    End Function

    'Function getreporttype() As String
    '    'must be countdata as a fieldname
    '    Try
    '        Dim i As String
    '        i = ""
    '        Dim conn As New OleDbConnection(strcon)
    '        Dim cmd As New OleDbCommand("select reporttype from login where userid='" + Signin.userid + "'", conn)
    '        cmd.CommandType = Data.CommandType.Text
    '        conn.Open()
    '        Dim dr As OleDbDataReader = cmd.ExecuteReader()
    '        If dr.Read() Then
    '            Select Case IsDBNull(dr(0))
    '                Case Is = True
    '                    i = ""
    '                Case Else
    '                    i = dr(0)
    '            End Select

    '        End If
    '        conn.Close()
    '        Return i
    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '        Return Nothing
    '    End Try
    'End Function

    Function getheadString() As String
        Dim StrHtml As String = "<html xmlns='http://www.w3.org/1999/xhtml'>" & _
"<head>" & _
    "<style> " & _
"#invoice-POS " & _
"{" & _
 " box-shadow: 0 0 1in -0.25in rgba(0, 0, 0, 0.5);" & _
  " padding: 2mm;" & _
   "position:absolute ;" & _
   "top:0px;" & _
   "left:0px;" & _
    " width:44mm; " & _
     "background: #FFF;" & _
      "}" & _
      "#invoice-POS ::selection" & _
       "{ background: #f31544; color: #FFF; }" & _
        "#invoice-POS ::moz-selection" & _
         "{ background: #f31544; color: #FFF; }" & _
          "#invoice-POS h1 { font-size: 1.5em; color: #222; }" & _
           "#invoice-POS h2 { font-size: .9em; } " & _
           "#invoice-POS h3 { font-size: 1.2em; font-weight: 300; line-height: 2em; }" & _
            "#invoice-POS p { font-size: .7em; color: #666; line-height: 1.2em; } " & _
            "#invoice-POS #top, #invoice-POS #mid, #invoice-POS #bot { border-bottom: 1px solid #EEE; }" & _
             "#invoice-POS #top { min-height: 100px; }" & _
              "#invoice-POS #mid { min-height: 80px; }" & _
              "#invoice-POS #bot { min-height: 50px; }" & _
               "#invoice-POS #top .logo " & _
               "{ height: 60px; width: 60px; background: url(http://michaeltruong.ca/images/logo1.png) no-repeat; background-size: 60px 60px; }" & _
                "#invoice-POS .clientlogo" & _
                 "{ float: left; height: 60px; width: 60px; background: url(http://michaeltruong.ca/images/client.jpg) no-repeat; background-size: 60px 60px; border-radius: 50px; }" & _
                  "#invoice-POS .info { display: block; margin-left: 0; }" & _
                   "#invoice-POS .title { float: right; }" & _
                    "#invoice-POS .title p { text-align: right; } " & _
                   " #invoice-POS table { width: 100%; border-collapse: collapse; }" & _
                    " #invoice-POS .tabletitle { font-size: .5em; background: #EEE; }" & _
                     " #invoice-POS .service { border-bottom: 1px solid #EEE; } " & _
                      "#invoice-POS .item { width: 24mm; }" & _
                       "#invoice-POS .itemtext { font-size: .5em; }" & _
                        "#invoice-POS #legalcopy table tr { line-height:1px; } " & _
                        "#invoice-POS #sign { margin-top:10mm; right:0px; font-size:.7em; }" & _
                       "#invoice-POS .invdtl table tr td{ font-size:.7em;font-family:Arial; width:200px; text-align:left;   }" & _
    "</style>" & _
"</head>"

        Return StrHtml
    End Function
    'Public Sub ExportToExcel(ByVal dtTemp As DataTable, ByVal filepath As String)
    '    Dim strFileName As String = filepath
    '    If System.IO.File.Exists(strFileName) Then
    '        If (MessageBox.Show("Do you want to replace from the existing file?", "Export to Excel", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = System.Windows.Forms.DialogResult.Yes) Then
    '            System.IO.File.Delete(strFileName)
    '        Else
    '            Return
    '        End If

    '    End If
    '    Dim _excel As New Excel.Application
    '    Dim wBook As Excel.Workbook
    '    Dim wSheet As Excel.Worksheet

    '    wBook = _excel.Workbooks.Add()
    '    wSheet = wBook.ActiveSheet()

    '    Dim dt As System.Data.DataTable = dtTemp
    '    Dim dc As System.Data.DataColumn
    '    Dim dr As System.Data.DataRow
    '    Dim colIndex As Integer = 0
    '    Dim rowIndex As Integer = 0
    '    'If CheckBox1.Checked Then
    '    For Each dc In dt.Columns
    '        colIndex = colIndex + 1
    '        wSheet.Cells(1, colIndex) = dc.ColumnName
    '    Next
    '    ' End If
    '    For Each dr In dt.Rows
    '        rowIndex = rowIndex + 1
    '        colIndex = 0
    '        For Each dc In dt.Columns
    '            colIndex = colIndex + 1
    '            wSheet.Cells(rowIndex + 1, colIndex) = dr(dc.ColumnName)
    '        Next
    '    Next
    '    wSheet.Columns.AutoFit()
    '    wBook.SaveAs(strFileName)

    '    ReleaseObject(wSheet)
    '    wBook.Close(False)
    '    ReleaseObject(wBook)
    '    _excel.Quit()
    '    ReleaseObject(_excel)
    '    GC.Collect()

    '    MessageBox.Show("File Export Successfully!")
    'End Sub
    'Private Sub ReleaseObject(ByVal o As Object)
    '    Try
    '        While (System.Runtime.InteropServices.Marshal.ReleaseComObject(o) > 0)
    '        End While
    '    Catch
    '    Finally
    '        o = Nothing
    '    End Try
    'End Sub
    Public Sub GVExportToExcel(ByVal dtTemp As DataGridView, ByVal filepath As String)
        Try

        
        Dim xlApp As New Excel.Application
        Dim xlWorkBook As Excel.Workbook
        Dim xlWorkSheet As Excel.Worksheet
        Dim misValue As Object = System.Reflection.Missing.Value

        Dim i As Int16, j As Int16


        xlWorkBook = xlApp.Workbooks.Add(misValue)
        xlWorkSheet = xlWorkBook.Sheets("sheet1")


        For i = 0 To dtTemp.RowCount - 2
            For j = 0 To dtTemp.ColumnCount - 1
                xlWorkSheet.Cells(i + 1, j + 1) = dtTemp(j, i).Value.ToString()
            Next
        Next

        xlWorkBook.SaveAs(filepath, Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, _
         Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue)
        xlWorkBook.Close(True, misValue, misValue)
        xlApp.Quit()

        releaseObjectGV(xlWorkSheet)
        releaseObjectGV(xlWorkBook)
        releaseObjectGV(xlApp)
        Catch ex As Exception

        End Try

    End Sub


    Private Sub releaseObjectGV(ByVal obj As Object)
        Try
            System.Runtime.InteropServices.Marshal.ReleaseComObject(obj)
            obj = Nothing
        Catch ex As Exception
            obj = Nothing
            MessageBox.Show("Exception Occured while releasing object " + ex.ToString())
        Finally
            GC.Collect()
        End Try
    End Sub
#Region "Convert To Words Function"

    Public Function AmountInWords(ByVal nAmount As String, Optional ByVal wAmount As String = vbNullString, Optional ByVal nSet As Object = Nothing) As String

        If Not IsNumeric(nAmount) Then Return "Please enter numeric values only."




        Dim tempDecValue As String = String.Empty : If InStr(nAmount, ".") Then tempDecValue = nAmount.Substring(nAmount.IndexOf("."))


        nAmount = Replace(nAmount, tempDecValue, String.Empty)

        Try

            Dim intAmount As Long = nAmount


            If intAmount > 0 Then

                nSet = IIf((intAmount.ToString.Trim.Length / 3) > (CLng(intAmount.ToString.Trim.Length / 3)), CLng(intAmount.ToString.Trim.Length / 3) + 1, CLng(intAmount.ToString.Trim.Length / 3))


                Dim eAmount As Long = Microsoft.VisualBasic.Left(intAmount.ToString.Trim, (intAmount.ToString.Trim.Length - ((nSet - 1) * 3)))


                Dim multiplier As Long = 10 ^ (((nSet - 1) * 3))


                Dim Ones() As String = {"", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine"}
                Dim Teens() As String = {"", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen"}
                Dim Tens() As String = {"", "Ten", "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety"}
                Dim HMBT() As String = {"", "", "Thousand", "Million", "Billion", "Trillion", "Quadrillion", "Quintillion"}


                intAmount = eAmount


                Dim nHundred As Integer = intAmount \ 100 : intAmount = intAmount Mod 100
                Dim nTen As Integer = intAmount \ 10 : intAmount = intAmount Mod 10
                Dim nOne As Integer = intAmount \ 1


                If nHundred > 0 Then wAmount = wAmount & Ones(nHundred) & " Hundred "
                If nTen > 0 Then
                    If nTen = 1 And nOne > 0 Then
                        wAmount = wAmount & Teens(nOne) & " "
                    Else
                        wAmount = wAmount & Tens(nTen) & IIf(nOne > 0, "-", " ")
                        If nOne > 0 Then wAmount = wAmount & Ones(nOne) & " "
                    End If
                Else
                    If nOne > 0 Then wAmount = wAmount & Ones(nOne) & " "
                End If

                wAmount = wAmount & HMBT(nSet) & " "

                wAmount = AmountInWords(CStr(CLng(nAmount) - (eAmount * multiplier)).Trim & tempDecValue, wAmount, nSet - 1)

            Else
                If Val(nAmount) = 0 Then nAmount = nAmount & tempDecValue : tempDecValue = String.Empty

                If (Math.Round(Val(nAmount), 2) * 100) > 0 Then wAmount = Trim(AmountInWords(CStr(Math.Round(Val(nAmount), 2) * 100), IIf(wAmount Is Nothing, "", wAmount.Trim & " Rupees And "), 1)) & " Paise"
            End If
        Catch ex As Exception

            'Messagebox("Error Encountered: " & ex.Message, "Convert Numbers To Words", MessageBoxButtons.OK, MessageBoxIcon.Error))
            'Return "!#ERROR_ENCOUNTERED"
        End Try


        If IsNothing(wAmount) = True Then
            If CDbl(nAmount) < 1 Then
                wAmount = NumberToWords(CDbl(nAmount) * 100) + " Paise Only"
            Else
                wAmount = String.Empty
            End If

        Else
            wAmount = IIf(InStr(wAmount.Trim.ToLower, "Rupess only"), wAmount.Trim, wAmount.Trim & "")
        End If

        Return wAmount
    End Function

#End Region

    Public Sub ExportToExcel(ByVal dtTemp As DataTable, ByVal filepath As String)
        Dim strFileName As String = filepath
        If System.IO.File.Exists(strFileName) Then
            If (MessageBox.Show("Do you want to replace from the existing file?", "Export to Excel", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = System.Windows.Forms.DialogResult.Yes) Then
                System.IO.File.Delete(strFileName)
            Else
                Return
            End If

        End If
        Dim _excel As New Excel.Application
        Dim wBook As Excel.Workbook
        Dim wSheet As Excel.Worksheet

        wBook = _excel.Workbooks.Add()
        wSheet = wBook.ActiveSheet()

        Dim dt As System.Data.DataTable = dtTemp
        Dim dc As System.Data.DataColumn
        Dim dr As System.Data.DataRow
        Dim colIndex As Integer = 0
        Dim rowIndex As Integer = 0
        'If CheckBox1.Checked Then
        For Each dc In dt.Columns
            colIndex = colIndex + 1
            wSheet.Cells(1, colIndex) = dc.ColumnName
        Next
        ' End If
        For Each dr In dt.Rows
            rowIndex = rowIndex + 1
            colIndex = 0
            For Each dc In dt.Columns
                colIndex = colIndex + 1
                wSheet.Cells(rowIndex + 1, colIndex) = dr(dc.ColumnName)
            Next
        Next
        wSheet.Columns.AutoFit()
        wBook.SaveAs(strFileName)

        ReleaseObject(wSheet)
        wBook.Close(False)
        ReleaseObject(wBook)
        _excel.Quit()
        ReleaseObject(_excel)
        GC.Collect()

        MessageBox.Show("File Export Successfully!")
    End Sub
    Private Sub ReleaseObject(ByVal o As Object)
        Try
            While (System.Runtime.InteropServices.Marshal.ReleaseComObject(o) > 0)
            End While
        Catch
        Finally
            o = Nothing
        End Try
    End Sub

    Sub dtpick(ByVal txtfromdate As TextBox, ByVal DateTimePicker1 As DateTimePicker)
        txtfromdate.Text = DateTimePicker1.Value.Date.ToString("dd/MM/yyyy")
    End Sub


End Class
