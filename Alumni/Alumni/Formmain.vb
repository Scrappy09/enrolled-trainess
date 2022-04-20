Imports MySql.Data.MySqlClient

Public Class Formmain

    Dim selFirstName As String
    Dim selSex As String
    Dim selCivilStatus As String
    Dim selBirthDate As String
    Dim selHomeAddress As String
    Dim selCityMunicipality As String
    Dim selTribe As String
    Dim selTradeArea As String
    Dim selReligion As String
    Dim selContactNumber As String
    Dim selYearGraduated As String
    Dim selAge As String
    Dim selEA As String
    Dim selEmail As String
    Dim vSelStudID As Integer
    Dim selPhase As String

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If MsgBox("Are you sure you want to log out?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            Me.Hide()
        Else

            Dim LoginForm As New Form1
            LoginForm.loginStatus = False
            LoginForm.ShowDialog()

        End If
    End Sub


    Private Sub GroupBox1_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Logout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Logout.Click
        If MsgBox("Are you sure you want to log out?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            Me.Hide()
            Dim LoginForm As New Form1
            LoginForm.loginStatus = False
            LoginForm.ShowDialog()
        Else
            Dim MAIN As New Formmain
            Me.Close()
            MAIN.Show()
        End If

    End Sub

    Private Sub BrowseRecordsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BrowseRecordsToolStripMenuItem.Click
        Formaddedit.ShowDialog()
        Call loadRecord()
    End Sub

    Private Sub lvMain_ItemSelectionChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.ListViewItemSelectionChangedEventArgs)
        selFirstName = lvMain.FocusedItem.SubItems(1).Text
        selSex = lvMain.FocusedItem.SubItems(2).Text
        selAge = lvMain.FocusedItem.SubItems(3).Text
        selBirthDate = lvMain.FocusedItem.SubItems(4).Text
        selCivilStatus = lvMain.FocusedItem.SubItems(5).Text
        selHomeAddress = lvMain.FocusedItem.SubItems(6).Text
        selCityMunicipality = lvMain.FocusedItem.SubItems(7).Text
        selContactNumber = lvMain.FocusedItem.SubItems(8).Text
        selEmail = lvMain.FocusedItem.SubItems(9).Text
        selTribe = lvMain.FocusedItem.SubItems(10).Text
        selReligion = lvMain.FocusedItem.SubItems(11).Text
        selEA = lvMain.FocusedItem.SubItems(12).Text
        selTradeArea = lvMain.FocusedItem.SubItems(13).Text
        selPhase = lvMain.FocusedItem.SubItems(14).Text
        selYearGraduated = lvMain.FocusedItem.SubItems(15).Text

    End Sub
    Private Sub loadRecord()
        Dim myCmd As New MySqlCommand
        myCmd.CommandText = "SELECT Stud, Fname, Sex, Age, Bday, Stat, HomeA, City, Num, Email, Tribe, Religion, EA, TA, Phase, Yearg FROM vsbt ;"
        myCmd.Connection = myConn


        Dim myRead As MySqlDataReader = Nothing
        Dim mItem As ListViewItem

        lvMain.Items.Clear()

        If myConn.State = ConnectionState.Closed Then
            Call ConnectDB()
        End If

        Try
            myRead = myCmd.ExecuteReader()
            If myRead.HasRows = True Then
                Do While myRead.Read()
                    mItem = New ListViewItem()
                    mItem = lvMain.Items.Add(myRead.GetString("Fname"))
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
            MsgBox(ex.ToString, MsgBoxStyle.Exclamation, "Error: Load Customers")
        End Try
        myCmd = Nothing
        myRead = Nothing

    End Sub

    Private Sub Formmain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.loadRecord()
    End Sub

    Private Sub ReportsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReportsToolStripMenuItem.Click
        FormReports.Show()
        Call loadRecord()
    End Sub
End Class