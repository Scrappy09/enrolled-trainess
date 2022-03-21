Imports MySql.Data.MySqlClient
Public Class FormPrint
    Public Mcity As String


    Private Sub loadRecords(ByVal phase As String)
        Dim myCmd As New MySqlCommand
        If phase <> "" Then
            myCmd.CommandText = "SELECT Fname, Sex, Age, Bday, Stat, HomeA, City, Num, Email, Tribe, Religion, EA, TA, Phase, Yearg FROM vsbt WHERE (Sex LIKE '" & txtSearch.Text & "%' OR Yearg LIKE '" & txtYear.Text & "%' )AND City LIKE '%" & Mcity & "%' AND phase = " & phase & " ;"
        Else
            myCmd.CommandText = "SELECT Fname, Sex, Age, Bday, Stat, HomeA, City, Num, Email, Tribe, Religion, EA, TA, Phase, Yearg FROM vsbt WHERE City LIKE '%" & Mcity & "%';"
        End If

        myCmd.Connection = myConn


        Dim myRead As MySqlDataReader = Nothing
        Dim mItem As ListViewItem

        lvPrint.Items.Clear()

        If myConn.State = ConnectionState.Closed Then
            Call ConnectDB()
        End If

        Try
            myRead = myCmd.ExecuteReader()
            If myRead.HasRows = True Then
                Do While myRead.Read()
                    mItem = New ListViewItem()
                    mItem = lvPrint.Items.Add(myRead.GetString("Fname"))

                    mItem.SubItems.Add(myRead.GetString("Sex"))
                    mItem.SubItems.Add(myRead.GetString("Age"))
                    mItem.SubItems.Add(myRead.GetString("Bday"))
                    mItem.SubItems.Add(myRead.GetString("Stat"))
                    mItem.SubItems.Add(myRead.GetString("HomeA"))
                    mItem.SubItems.Add(myRead.GetString("City"))
                    mItem.SubItems.Add(myRead.GetString("Num"))
                    mItem.SubItems.Add(myRead.GetString("Email"))
                    mItem.SubItems.Add(myRead.GetString("Tribe"))
                    mItem.SubItems.Add(myRead.GetString("Religion"))
                    mItem.SubItems.Add(myRead.GetString("EA"))
                    mItem.SubItems.Add(myRead.GetString("TA"))
                    mItem.SubItems.Add(myRead.GetString("Phase"))
                    mItem.SubItems.Add(myRead.GetString("Yearg"))
                Loop
            End If

            myRead.Close()
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Exclamation, "Error: Load Records")
        End Try
        myCmd = Nothing
        myRead = Nothing

    End Sub

    Private Sub FormPrint_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.loadRecords("")
        lblStudentName.Text = Mcity
    End Sub

    Private Sub searchStudent()
        Dim myCmd As New MySqlCommand
        If txtYear.Text <> "" Then
            myCmd.CommandText = "SELECT Fname, Sex, Stat, Age, Bday, HomeA, City, Tribe, TA, Religion, Num, Yearg, EA, Email, Phase FROM vsbt WHERE (Fname LIKE '%" & txtSearch.Text & "%' OR Tribe LIKE '" & txtSearch.Text & "%' OR Religion LIKE '" & txtSearch.Text & "%' OR EA LIKE '" & txtSearch.Text & "%' OR TA LIKE '" & txtSearch.Text & "%' OR Stat LIKE '" & txtSearch.Text & "%' OR HomeA LIKE '" & txtSearch.Text & "%' OR Yearg LIKE '%" & txtYear.Text & "%' OR Age LIKE '" & txtSearch.Text & "%' OR Sex LIKE '" & txtSearch.Text & "%' )AND Yearg LIKE '" & txtYear.Text & "%' OR City LIKE '" & Mcity & "' ORDER BY Fname ;"
        Else
            myCmd.CommandText = "SELECT Fname, Sex, Stat, Age, Bday, HomeA, City, Tribe, TA, Religion, Num, Yearg, EA, Email, Phase FROM vsbt WHERE (Fname LIKE '%" & txtSearch.Text & "%' Or Stat LIKE '" & txtSearch.Text & "%' OR Tribe LIKE '" & txtSearch.Text & "%' OR Religion LIKE '" & txtSearch.Text & "%' OR TA LIKE '" & txtSearch.Text & "%' OR EA LIKE '" & txtSearch.Text & "%' OR HomeA LIKE '" & txtSearch.Text & "%' OR City LIKE '" & txtSearch.Text & "%' OR Age LIKE '" & txtSearch.Text & "%' OR Sex LIKE '" & txtSearch.Text & "%') ORDER BY Fname ;"
        End If

        myCmd.Connection = myConn

        Dim myRead As MySqlDataReader = Nothing
        Dim mItem As ListViewItem

        lvPrint.Items.Clear()

        If myConn.State = ConnectionState.Closed Then
            Call ConnectDB()
        End If

        Try
            myRead = myCmd.ExecuteReader()
            If myRead.HasRows = True Then
                Do While myRead.Read()
                    mItem = New ListViewItem()
                    mItem = lvPrint.Items.Add(myRead.GetString("Fname"))

                    mItem.SubItems.Add(myRead.GetString("Sex"))
                    mItem.SubItems.Add(myRead.GetString("Age"))
                    mItem.SubItems.Add(myRead.GetString("Bday"))
                    mItem.SubItems.Add(myRead.GetString("Stat"))
                    mItem.SubItems.Add(myRead.GetString("HomeA"))
                    mItem.SubItems.Add(myRead.GetString("City"))
                    mItem.SubItems.Add(myRead.GetString("Num"))
                    mItem.SubItems.Add(myRead.GetString("Email"))
                    mItem.SubItems.Add(myRead.GetString("Tribe"))
                    mItem.SubItems.Add(myRead.GetString("Religion"))
                    mItem.SubItems.Add(myRead.GetString("EA"))
                    mItem.SubItems.Add(myRead.GetString("TA"))
                    mItem.SubItems.Add(myRead.GetString("Phase"))
                    mItem.SubItems.Add(myRead.GetString("Yearg"))
                Loop
            End If

            myRead.Close()
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Exclamation, "Error: Load Student")
        End Try
        myCmd = Nothing
        myRead = Nothing

    End Sub
    Private Sub BtnPhase1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPhase1.Click
        Me.loadRecords(1)
    End Sub

    Private Sub BtnPhase2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPhase2.Click
        loadRecords(2)

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub txtSearch_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSearch.TextChanged, txtYear.TextChanged
        If Not txtSearch.Text = "" Then
            Me.searchStudent()

        Else
            Me.loadRecords("")

        End If

    End Sub
End Class