Imports MySql.Data.MySqlClient
Public Class Form1
    Public loginStatus As Boolean = False

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        End

    End Sub
    Private Sub BtnLogin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnLogin.Click
        Dim myCmd As New MySqlCommand

        myCmd.CommandText = "SELECT Username , Password  FROM user Where Username = '" & TxtUsername.Text & "' AND Password = '" & Txtpassword.Text & "';"
        myCmd.Connection = myConn

        Dim myRead As MySqlDataReader = Nothing

        If myConn.State = ConnectionState.Closed Then
            Call ConnectDB()
        End If

        Try
            myRead = myCmd.ExecuteReader()
            If myRead.HasRows = True Then
                loginStatus = True
            End If

            myRead.Close()
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Exclamation, "Error: Login")
        End Try

        myCmd = Nothing
        myRead = Nothing

        If loginStatus = True Then
            Me.Hide()
            Dim Main As New Formmain
            Main.ShowDialog()

        Else
            MsgBox("User Authentication Error!", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly)
        End If
    End Sub

    Private Sub Form1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then
            Call BtnLogin_Click("", e)
        End If
    End Sub

End Class
