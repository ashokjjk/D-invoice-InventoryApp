Public Class MultiPOSsupply

    Private Sub MultiPOS_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Me.Load
        MaximizeBox = False
        MinimizeBox = False

    End Sub

    Protected Overrides Function ProcessCmdKey(ByRef msg As System.Windows.Forms.Message, ByVal keyData As Keys) As Boolean
        Dim s As String = TabControl1.SelectedTab.Name
        Select Case msg.Msg
            Case &H100, &H104
                Select Case keyData
                    Case Keys.F1
                        If s = "TabPage1" Then
                            Dim t As TabPage = TabControl1.TabPages(1)
                            TabControl1.SelectedTab = t
                        End If
                        If s = "TabPage2" Then
                            Dim t As TabPage = TabControl1.TabPages(2)
                            TabControl1.SelectedTab = t
                        End If
                        If s = "TabPage3" Then
                            Dim t As TabPage = TabControl1.TabPages(3)
                            TabControl1.SelectedTab = t
                        End If
                        If s = "TabPage4" Then
                            Dim t As TabPage = TabControl1.TabPages(0)
                            TabControl1.SelectedTab = t
                        End If
                End Select
                Exit Select
        End Select
        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function



End Class