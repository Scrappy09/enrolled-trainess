Imports MySql.Data.MySqlClient
Public Class FrmChangePassword

    Private Sub FrmChangePassword_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        lvlUsername.Text = vUserName
        lvlName.Text = vName
        txtNewPass.Text = vUserpass
    End Sub
    Private Function updatePassword(ByVal vpassword As String) As Boolean
        On Error GoTo Errtrap

        Dim myAdapter As New MySqlDataAdapter
        Dim myCommand As New MySqlCommand()

        Call ConnectDB()

        If myConn.State = ConnectionState.Open Then
            myCommand.Connection = myConn
            myCommand.CommandText = "UPDATE user SET Password = '" & vpassword & "' WHERE Username = '" & vUserName & "'; "
            myAdapter.SelectCommand = myCommand
            myCommand.ExecuteReader()
        End If
        myConn.Close()

        Return True
        Exit Function
Errtrap:
        MsgBox(Err.Description, MsgBoxStyle.Exclamation)
        myConn.Close()
    End Function

    Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOk.Click
        If updatePassword(txtNewPass.Text) = True Then
            MsgBox("Password change!", MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
        End If
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub
End Class