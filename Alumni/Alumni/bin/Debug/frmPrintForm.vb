Imports MySql.Data.MySqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Data
Public Class frmPrintForm
    Public vReportType As String
    Public mCity As String
    Public vsbtSQL As String

    Private Sub frmPrintForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call ConnectDB()
        Dim ds As New DataSet
        Dim Sql As String = ""
        Dim objRpt As New ReportDocument

        Try
            If vReportType = "vsbt" Then
                Sql = vsbtsql

                Dim tPath As String = ""
                Dim dscmd As New MySqlDataAdapter(Sql, myConn)

                Cursor.Current = Cursors.WaitCursor

                dscmd.Fill(ds, "vsbt")
                tPath = Application.StartupPath + "\rptEnrolledTraineesProfile.rpt"

                myConn.Close()
                objRpt.Load(tPath)
                objRpt.SetDataSource(ds.Tables("vsbt"))
            End If
        

            CrystalReportViewer1.ReportSource = objRpt
            CrystalReportViewer1.Refresh()
            Cursor.Current = Cursors.Default

        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Exclamation, "Error ")
        End Try
    End Sub
    Private Sub frmReportForm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub
    Private Sub CrystalReportViewer1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CrystalReportViewer1.Load

    End Sub


End Class