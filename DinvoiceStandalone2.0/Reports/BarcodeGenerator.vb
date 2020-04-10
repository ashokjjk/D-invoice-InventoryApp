Imports Microsoft.Reporting.WinForms
Imports System.IO

Public Class BarcodeGenerator
    Dim obj As New ObjClass

    Private Sub GenerateBarCodeInHtml(ByVal p1 As String, ByVal item As String, ByVal rate As String)
        Try
            Dim strHtml As String
            Dim i As Integer
            i = Convert.ToInt32(InputBox("Enter Number :-> ", "User Input", "0"))
            'MsgBox("Your Entered Value Is : " & i)
            If i > 70 Then
                MsgBox("Maximum Printing only 70 at the time")
                Exit Sub
            End If
            strHtml = "<html><head></head><body>" & _
        "<table cellspacing='20'>"




            For j = 0 To (i / 6) - 1
                strHtml = strHtml + "<tr>"
                For k = 0 To 5
                    strHtml = strHtml + "<td><label style='font-size:7px; font-family:arial; font-weight:bold;'>" + item + "</label><br/><img alt='' src='" + p1 + "' width='100' height='40' /><br/><label style='font-size:7px; font-family:arial; font-weight:bold;'> Rs - " + rate + "</label></td>"
                Next
                strHtml = strHtml + "</tr>"
            Next

            strHtml = strHtml + "</table>" & _
           "</body>" & _
           "</html>"

            WebBrowser1.DocumentText = strHtml
        Catch ex As Exception
            MsgBox(ex.Message)
            Exit Sub
        End Try
    End Sub

    Private Sub BarcodeGenerator_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        MaximizeBox = False
        MinimizeBox = False
        cmbItemName.Focus()

        Dim listitemname As New DataTable
        cmbItemName.DataSource = Nothing

        listitemname = obj.getdatatable("select item_name,item_no from item_tbl where  item_type='Goods'")
        cmbItemName.DisplayMember = "item_name"
        cmbItemName.ValueMember = "item_no"
        cmbItemName.DataSource = listitemname
        cmbItemName.Visible = True


        Me.ReportViewer1.RefreshReport()
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        Try
            If Me.cmbItemName.Text = "" Then
                MsgBox("Specify Item Name")
                Exit Sub
            Else
            End If
            Dim barcode As OnBarcode.Barcode.Linear
            ' Create linear barcode object
            barcode = New OnBarcode.Barcode.Linear()
            ' Set barcode symbology type to Code-39
            barcode.Type = OnBarcode.Barcode.BarcodeType.CODE39
            ' Set barcode data to encode
            Dim barcodedata As New List(Of String)
            barcodedata = obj.GetMoreValueFromQuery("select barcode_no,item_name,sale_rate from item_tbl where item_no='" + Me.cmbItemName.SelectedValue + "'", 3)
            barcode.Data = barcodedata(0)
            ' Set barcode bar width (X    dimension) in pixel
            barcode.X = 0.3
            ' Set barcode bar height (Y dimension) in pixel
            barcode.Y = 40
            ' Draw & print generated barcode to png image file
            'barcode.drawBarcode("D://vbnet-code39.png")
            barcode.drawBarcode(Application.StartupPath + "//barcode.jpg")
            'GenerateBarCodeInHtml(Application.StartupPath + "//" + barcodedata(0) + ".png", barcodedata(1), barcodedata(2))

            Try

                Dim logoimg As New Logo
                Dim dtlogo As New DataTable
                Dim dr2 As DataRow
                Dim rptDataSource2 As New ReportDataSource

                Dim img As Image = Image.FromFile(Application.StartupPath + "\barcode.jpg")
                Dim bArr As Byte() = imgToByteArray(img)

                'Dim img As Byte() = obj.GetImage("select barcode_no from item_tbl where item_no=" + Me.cmbItemName.SelectedValue + "")

                Dim i As Integer
                i = Convert.ToInt32(InputBox("Enter Number :-> ", "User Input", "0"))
                For j = 1 To i
                    dr2 = logoimg.Tables("Image").NewRow()
                    dr2("company_id") = barcodedata(1) + " :  Rs :- " + barcodedata(2)
                    dr2("company_logo") = bArr
                    logoimg.Tables("Image").Rows.Add(dr2)
                Next








                ReportViewer1.LocalReport.DataSources.Clear()
                rptDataSource2 = New ReportDataSource("DataSet2", logoimg.Tables("Image"))
                ReportViewer1.ProcessingMode = ProcessingMode.Local
                ReportViewer1.LocalReport.ReportPath = "" + Application.StartupPath + "\BarCode.rdlc"
                ReportViewer1.LocalReport.Refresh()
                ReportViewer1.LocalReport.DataSources.Add(rptDataSource2)
                ReportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.Normal)


                


            Catch ex As Exception

            End Try
        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try




    End Sub
    Public Function imgToByteArray(ByVal img As Image) As Byte()
        Using mStream As New MemoryStream()
            img.Save(mStream, img.RawFormat)
            Return mStream.ToArray()
        End Using
    End Function
    Private Sub btnprint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnprint.Click
        Try
            WebBrowser1.ShowPrintDialog()
        Catch ex As Exception
            MsgBox(ex.Message)
            Exit Sub
        End Try
    End Sub
End Class