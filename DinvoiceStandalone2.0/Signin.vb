Imports System.IO

Public Class Signin
    Dim obj As New ObjClass
    Dim share As New SharedData

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSignin.Click
        Dim username, password, company_id As String
        company_id = obj.GetOneValueFromQuery("select company_id from company_tbl where company_name='" + cmbCompany.Text + "' and company_yr='" + cmbAccountYr.Text + "'")
        username = Me.txtUsername.Text
        password = Me.txtPassword.Text 'CAST(Username as varbinary(100)) = CAST(@Username as varbinary))
        ' Select Case obj.FindDuplicate("select count(*) from user_tbl where user_name='" + username + "' and pass_word='" + password + "' and company_id=" & Val(company_id) & "")
        Select Case obj.FindDuplicate("select count(*) from user_tbl where  instr(1,user_name,'" + username + "',0)>0 and  instr(1,pass_word,'" + password + "',0)>0 and company_id=" & Val(company_id) & "")

            Case Is = 0

                Select Case obj.FindDuplicate("select count(*) from user_tbl")
                    Case Is = 0
                        Settings.Show()
                    Case Else
                        MsgBox("Username or password doesn't exist", MsgBoxStyle.Exclamation)
                End Select

            Case Else
                share.SetSessiondata(company_id, username)

                Home.Close()
                Home.Show()
                Me.Hide()
        End Select



        'Home.BringToFront()
        'Home.TopMost = True

    End Sub
   

   
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
        Splash.Close()
    End Sub


    Private Sub Signin_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim softtype As String = share.getsoftwaretype
        Select Case softtype
            Case Is = ""
                MessageBox.Show("Activation Pending!!! " & vbCrLf & "Contact Dara Corp", "Activation", MessageBoxButtons.OK, MessageBoxIcon.None,
                                 MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification, False)
                Me.Close()
                Splash.Close()
                Exit Sub
            Case Else

        End Select

        txtUsername.Focus()
        Dim dt As New DataTable

        dt = obj.getdatatable("select distinct company_name from company_tbl")
        For i = 0 To dt.Rows.Count - 1
            cmbCompany.Items.Add(dt.Rows(i).Item(0).ToString)
        Next

        'txtUsername.Text = "Ashok"
        'txtPassword.Text = "kumar"
        'cmbCompany.Text = "Dara Corporation"
        'cmbAccountYr.Text = "01-04-2017 to 31-03-2018"
    End Sub

    Private Sub cmbCompany_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbCompany.SelectedIndexChanged
        cmbAccountYr.Items.Clear()
        Dim value As String = cmbCompany.Text
        Dim lstcmpyr As New List(Of String)
        lstcmpyr = obj.getcolumndatafromquery("select company_yr from company_tbl where company_name='" + value + "'")
        For i = 0 To lstcmpyr.Count - 1
            cmbAccountYr.Items.Add(lstcmpyr(i))
        Next
    End Sub
End Class