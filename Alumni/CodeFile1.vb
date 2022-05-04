Imports MySql.Data.MySqlClient


Module CodeFile1
    Public svrHost, svrPort, svrUname, svrPwd, svrDB As String
    Public myConn As New MySqlConnection

    Public vUserName As String
    Public vUserType As String
    Public vName As String
    Public vUserpass As String
    Public vSelCustomerNo As Integer
    Public vSelCustomerName As String
    Public vSelContactPerson As String
    Public vSelPhone As String
    Public vSelCity As String
    Public vSelCredLimit As Decimal


    Public Sub ConnectDB()
        svrHost = "localhost"
        svrPort = "3306"
        svrUname = "root"
        svrPwd = ""
        svrDB = "alumni"

        Try
            If myConn.State = 0 Then
                myConn.ConnectionString = "Server=" & svrHost & "; Port=" & svrPort & "; Database=" & svrDB & "; user id=" & svrUname & "; password=" & svrPwd & ";"
                myConn.Open()
            End If
        Catch Er As Exception
            MsgBox("Error connecting to the database!", MsgBoxStyle.Critical, "Connect")
        End Try
    End Sub


End Module
