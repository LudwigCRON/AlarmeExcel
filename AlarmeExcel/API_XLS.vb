Imports Microsoft.Office.Interop
Imports Microsoft.Office.Interop.Excel
Imports System.Net.Mail

Module API_XLS
    Dim count10 As Integer()
    Dim count5 As Integer()
    Dim Sheets As String()

    Public Function GetData(ByRef F As GUI, ByVal n As Integer) As Boolean
        F.Output.Text = F.FilesList.Items.Item(n).ToString() + "   -" + CStr(count10(n) + count5(n)) + "  tâches à verifier :     " + vbCrLf + CStr(count10(n)) + "  avant 10 jrs et " + CStr(count5(n)) + "  avant 5jrs"
        Return True
    End Function

    Public Function GetExt(ByVal path As String)
        Dim ext As String
        Dim i As Integer
        i = path.LastIndexOf(".")
        ext = path.Substring(i, path.Length() - i)
        Return ext
    End Function

    Public Function reseachalarmefile()
        Dim file = FileIO.FileSystem.GetFiles(Environment.CurrentDirectory.ToString(), FileIO.SearchOption.SearchTopLevelOnly)
        Dim filename(0) As String
        Dim i As Integer = 0
        For Each element In file
            If GetExt(element).ToString().Contains("xls") = True Then
                i += 1
                ReDim Preserve filename(i)
                ReDim Preserve Sheets(i)
                filename.SetValue(element, i - 1)
                Dim j = element.LastIndexOf("\")
                Sheets.SetValue(element.Substring(j, element.Length() - j), i - 1)
            End If
        Next
        ReDim count10(i)
        ReDim count5(i)
        For i = 0 To count10.Length() - 1 Step 1
            count10(i) = 0
            count5(i) = 0
        Next
        Return filename
    End Function

    Public Function isCharArray(ByVal chaine As String) As Boolean
        Dim rep As Boolean = True
        If chaine <> vbNullString Then
            Dim cchaine(50) As Char
            cchaine = chaine.ToCharArray(0, chaine.Length())
            For i = 0 To chaine.Length - 1 Step 1
                If Not Char.IsLetter(cchaine(i)) Then
                    rep = False
                End If
            Next i
        Else
            rep = False
        End If
        Return rep
    End Function

    Public Function getColor(ByVal rng As Range)
        Return rng.Font.ColorIndex
    End Function

    Public Sub resetCombo(ByRef F As GUI)
        F.FilesList.Items.Clear()
        F.Output.Text = ""
        ReDim count10(0)
        ReDim count5(0)
    End Sub

    Public Sub WriteCombo(ByRef F As GUI)
        F.Output.Text = ""
        For counter = 0 To Sheets.Length() - 1 Step 1
            If Not Sheets(counter) = vbNullString Then
                F.FilesList.Items.Add(Sheets(counter))
                F.Output.Text = F.Output.Text + vbCrLf + vbCrLf + Sheets(counter) + "  " + CStr(count10(counter)) + " avant 10 jours et " + vbCrLf + CStr(count5(counter)) + " avant 5 jours"
            End If
        Next counter
        If Sheets.Length <= 4 Then
            F.Height = Sheets.Length() * 40 + 160
            F.Output.ScrollBars = System.Windows.Forms.ScrollBars.None
        Else
            F.Height = 320
            F.Output.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        End If
        If F.Location.Y - 40 * Sheets.Length() > 0 Then
            F.SetDesktopLocation(F.Location.X, F.Location.Y - 40 * Sheets.Length())
        End If
    End Sub

    Public Sub Mailer(ByRef F As GUI, ByVal mailAddress As String, ByVal mailSubject As String, ByVal smtpAddress As String, ByVal smtpPort As Integer, ByVal senderAddress As String, ByVal senderPswd As String)
        Dim mail As New System.Net.Mail.MailMessage
        Dim sender As New MailAddress("alarme@quality.com", mailSubject)
        mail.From = sender
        mail.Subject = mailSubject
        mail.Priority = MailPriority.High
        mail.Body = F.Output.Text()
        mail.To.Add(mailAddress)
        Dim SMTPserver As New System.Net.Mail.SmtpClient(smtpAddress)
        SMTPserver.Port = smtpPort
        SMTPserver.Credentials = New System.Net.NetworkCredential(senderAddress , senderPswd)
        SMTPserver.EnableSsl = True
        SMTPserver.DeliveryMethod = SmtpDeliveryMethod.Network
        SMTPserver.Send(mail)
        SMTPserver.Dispose()
    End Sub

    'fonction a detruire, le code a été améliorée est mis dans GetFromFile()
    Public Function GetLine(ByVal exlSht As Excel.Worksheet, ByVal rows As Integer, ByVal counter As Integer)
        Dim data As String = ""
        Dim MaxCols As Integer = exlSht.UsedRange.Columns.Count
        Dim MaxRows As Integer = exlSht.UsedRange.Rows.Count
        For cols = 1 To MaxCols Step 1
            Dim range As Range
            range = exlSht.Cells(rows, cols)
            data += CStr(range.Value)
            If CStr(range.Value) = "0" Or CStr(range.Value) = "o" Or CStr(range.Value) = "O" Then
                If getColor(range) = 44 Or getColor(range) = 45 Or getColor(range) = 46 Then
                    count10(counter) += 1
                ElseIf getColor(range) = 3 Then
                    count5(counter) += 1
                End If
            End If
        Next cols
        Return data
    End Function

    Public Sub GetAllFile(ByVal path As String())
        Dim counter As Integer = 0
        For Each classeur In path
            If Not classeur = vbNullString Then
                GetFromFile(classeur, counter)
            End If
            counter += 1
        Next classeur
    End Sub

    Public Sub GetFromFile(ByVal path As String, ByVal counter As Integer)
        Dim exl As New Excel.Application
        Dim data As String = ""

        exl.DisplayAlerts = False
        exl.Workbooks.Open(path)
        If exl.Sheets.Count() > 1 Then
            Dim exlSht As Excel.Worksheet = exl.Sheets(2)
            Dim MaxCols As Integer = exlSht.UsedRange.Columns.Count
            Dim MaxRows As Integer = exlSht.UsedRange.Rows.Count
            For col = 1 To MaxCols Step 1
                For row = 1 To MaxRows Step 1
                    Dim range As Range
                    range = exlSht.Cells(row, col)
                    data += CStr(range.Value)
                    If CStr(range.Value) = "0" Or CStr(range.Value) = "o" Or CStr(range.Value) = "O" Then
                        If getColor(range) = 44 Or getColor(range) = 45 Or getColor(range) = 46 Then
                            count10(counter) += 1
                        ElseIf getColor(range) = 3 Then
                            count5(counter) += 1
                        End If
                    End If
                Next row
            Next col
        End If
        exl.Workbooks.Close()
        exl.Quit()
    End Sub

    Public Function runAsync() As Integer
        Dim path As String() = reseachalarmefile()
        GetAllFile(path)
        Return 0
    End Function
End Module
