Imports System.ComponentModel
Imports System.Windows
Imports System.Windows.Forms
Imports System.Drawing
Imports System.Diagnostics
Imports System.IO.Directory

Public Class GUI
    Private mailAddress, mailSubject As String
    Private start As System.Windows.Point
    Private drag As Boolean

    Shared Sub Main()
        System.Windows.Forms.Application.Run(New GUI())
    End Sub

    Private Sub GUI_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.mailAddress = My.Settings.mailAddress
        Me.mailSubject = My.Settings.mailSubject
        Me.Title.Text = My.Settings.mailSubject
        Me.drag = False

        resetCombo(Me)
        BackgroundWorker1.RunWorkerAsync()
        Me.Output.Text = "Scan en Cours"
    End Sub

    Private Sub ScanBtn_Click(sender As Object, e As EventArgs) Handles ScanBtn.Click
        If Me.ScanBtn.Text = "Scan Files" Then
            Me.Output.Text = "Annulation de la précédente recherche..."
            BackgroundWorker1.CancelAsync()
            resetCombo(Me)
            BackgroundWorker1.RunWorkerAsync()
            Me.Output.Text = "Scan en Cours"
        ElseIf Me.ScanBtn.Text = "Open File" Then
            Dim psi As New ProcessStartInfo()
            With psi
                .FileName = Environment.CurrentDirectory.ToString() + Me.FilesList.SelectedItem.ToString()
                Console.WriteLine(psi.FileName)
                .UseShellExecute = True
            End With
            Process.Start(psi)
        End If
    End Sub

    Private Sub FilesList_SelectedIndexChanged(sender As Object, e As EventArgs) Handles FilesList.SelectedIndexChanged
        If Me.FilesList.SelectedIndex <> -1 Then
            GetData(Me, Me.FilesList.SelectedIndex)
            Me.ScanBtn.Text = "Open File"
        End If
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Dim bw As BackgroundWorker = CType(sender, BackgroundWorker)
        e.Result = AlarmeExcel.runAsync()

        ' If the operation was canceled by the user, 
        ' set the DoWorkEventArgs.Cancel property to true.
        If bw.CancellationPending Then
            e.Cancel = True
        End If
    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        If e.Cancelled Then
            ' The user canceled the operation.
            System.Windows.MessageBox.Show("Operation was canceled")
        ElseIf (e.Error IsNot Nothing) Then
            ' There was an error during the operation.
            Dim msg As String = String.Format("An error occurred: {0}", e.Error.Message)
            System.Windows.MessageBox.Show(msg)
        Else
            ' The operation completed normally.
            WriteCombo(Me)
            Try
                AlarmeExcel.Mailer(Me, My.Settings.mailAddress, My.Settings.mailSubject, My.Settings.smtpAddress, CInt(My.Settings.smtpPort), My.Settings.senderAddress, My.Settings.senderPassword)
                System.Windows.MessageBox.Show("email bien envoyée")
            Catch ex As Exception
                System.Windows.MessageBox.Show(ex.Message)
            End Try
        End If
    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
        BackgroundWorker1.CancelAsync()
    End Sub

    Private Sub CloseBtn_Click(sender As Object, e As EventArgs) Handles CloseBtn.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub CloseBtn_MouseHover(sender As Object, e As EventArgs) Handles CloseBtn.MouseHover
        Me.CloseBtn.Image = My.Resources.close_hover
    End Sub

    Private Sub CloseBtn_MouseLeave(sender As Object, e As EventArgs) Handles CloseBtn.MouseLeave
        Me.CloseBtn.Image = My.Resources.close_
    End Sub

    Private Sub ScanBtn_MouseHover(sender As Object, e As EventArgs) Handles ScanBtn.MouseHover
        Me.ScanBtn.BackColor = Drawing.Color.White
    End Sub

    Private Sub ScanBtn_MouseLeave(sender As Object, e As EventArgs) Handles ScanBtn.MouseLeave
        Me.ScanBtn.BackColor = Drawing.Color.MediumSlateBlue
    End Sub

    Private Sub GUI_MouseDown(sender As Object, e As Forms.MouseEventArgs) Handles MyBase.MouseDown
        Me.start.X = e.X
        Me.start.Y = e.Y
        Me.drag = True
    End Sub

    Private Sub GUI_MouseMove(sender As Object, e As Forms.MouseEventArgs) Handles MyBase.MouseMove
        If Me.drag Then
            Me.SetDesktopLocation(e.X - Me.start.X + Me.Location.X, e.Y - Me.start.Y + Me.Location.Y)
        End If
    End Sub

    Private Sub GUI_MouseUp(sender As Object, e As Forms.MouseEventArgs) Handles MyBase.MouseUp
        Me.drag = False
    End Sub
End Class