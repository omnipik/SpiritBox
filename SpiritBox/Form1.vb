Imports System.IO
Imports System.Runtime.Serialization.Formatters.Binary
Imports System.Math
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Text.RegularExpressions

Public Class MainForm
    Dim sColor(4) As Color
    Dim drag As Boolean
    Dim mousex As Integer
    Dim mousey As Integer
    Dim nCount As Integer = 0
    Dim nLast As Integer = 0
    Dim nTotal As Integer = 0
    Dim zTotal As Integer = 0
    Dim oTotal As Integer = 0
    Dim marg As Integer = 112 / 100
    Dim ymarg As Integer = 112 / 25
    Dim fMarg As Single = 114.0F / 100.0F
    Dim nClock As Integer
    Dim wProb As Integer
    Dim sSign() As String = {"^", "_", "`", "a", "b", "c", "d", "e", "f", "g", "h", "i"}
    Dim gCDyel As Color = cColor(255, 100, 100, 0)
    Dim gCDred As Color = cColor(255, 100, 0, 0)
    Dim gCDgrn As Color = cColor(255, 0, 100, 0)
    Dim gCIwht As Color = cColor(255, 255, 255, 255)
    Dim gCIred As Color = cColor(255, 255, 0, 0)
    Dim gCIgrn As Color = cColor(255, 0, 255, 0)
    Dim gCIblu As Color = cColor(255, 0, 0, 255)
    Dim gCIyel As Color = cColor(255, 255, 255, 0)
    Dim gCImag As Color = cColor(255, 255, 0, 255)
    Dim gCIcyn As Color = cColor(255, 0, 255, 255)
    Dim gCwht As Color = cColor(255, 200, 200, 200)
    Dim gCgry As Color = cColor(255, 100, 100, 100)
    Dim gCred As Color = cColor(255, 200, 0, 0)
    Dim gCgrn As Color = cColor(255, 0, 200, 0)
    Dim gCblu As Color = cColor(255, 0, 0, 200)
    Dim gCyel As Color = cColor(255, 200, 200, 0)
    Dim gCmag As Color = cColor(255, 200, 0, 200)
    Dim gCcyn As Color = cColor(255, 0, 200, 200)
    Dim dartifact As Bitmap = New Bitmap(40, 40)
    Dim gLine(99) As PointF
    Dim WordBank() As String = My.Resources.wordlistcaps.Trim(" ").Split(Environment.NewLine)
    Dim KJV() As SCRIPTURE
    Dim Bible() As String = My.Resources.bible.Split(Environment.NewLine)
    Dim Codex()()() As String = Nothing
    Dim LetterBank(8)() As String
    Dim Mark1 As XYZ = vCompile(0, 54, 0)
    Dim Mark2 As XYZ = vCompile(54, 0, 0)
    Dim Mark3 As XYZ = vCompile(0, -54, 0)
    Dim MarkS As XYZ = vCompile(0, 40, 0)
    Dim Mark1p As XYZ = vCompile(0, 40, 0)
    Dim Mark2p As XYZ = vCompile(40, 0, 0)
    Dim Mark3p As XYZ = vCompile(0, -40, 0)

    Dim _S(5, 5) As Integer
    Dim Center As XYZ = vCompile(0, 0, 0)
    Dim mM As MTX = MI()

#Region "object structures"
    <Serializable()> Public Structure XYZ
        Public Property X As Double
        Public Property Y As Double
        Public Property Z As Double
        Public Property W As Double
        Public Property G As PointF
    End Structure
    <Serializable()> Public Structure MTX2
        Public Property c1r1 As Double
        Public Property c1r2 As Double
        Public Property c2r1 As Double
        Public Property c2r2 As Double
    End Structure

    <Serializable()> Public Structure MDATA
        Public Property Mesh As XYZ()
        Public Property Origin As XYZ
        Public Property AvgVec As XYZ
        Public Property Center As XYZ
        Public Property Texture As Bitmap()
        Public Property Distance As Double
        Public Property LineColor As Color
        Public Property FillColor As Color
        Public Property Line As Boolean
        Public Property Fill As Boolean
        Public Property Curve As Boolean
        Public Property SpinIO As Boolean
        Public Property SpinAngleX As Double
        Public Property SpinAngleY As Double
        Public Property SpinAngleZ As Double
        Public Property OrbitIO As Boolean
        Public Property OrbitAngleX As Double
        Public Property OrbitAngleY As Double
        Public Property OrbitAngleZ As Double
        Public Property TranslateIO As Boolean
        Public Property TranslateX As Double
        Public Property TranslateY As Double
        Public Property TranslateZ As Double
    End Structure

    <Serializable()> Public Structure MODEL
        Public Property M As MDATA()
        Public Property Camera As XYZ
    End Structure
    <Serializable()> Public Structure ZONE
        Public Property Z As MDATA()()
        Public Property Camera As XYZ
    End Structure

    <Serializable()> Public Structure MTX
        Public Property c1r1 As Double
        Public Property c1r2 As Double
        Public Property c1r3 As Double
        Public Property c1r4 As Double
        Public Property c2r1 As Double
        Public Property c2r2 As Double
        Public Property c2r3 As Double
        Public Property c2r4 As Double
        Public Property c3r1 As Double
        Public Property c3r2 As Double
        Public Property c3r3 As Double
        Public Property c3r4 As Double
        Public Property c4r1 As Double
        Public Property c4r2 As Double
        Public Property c4r3 As Double
        Public Property c4r4 As Double
    End Structure
    <Serializable()> Public Structure SCRIPTURE
        Public Property Book As String
        Public Property Number As Integer
        Public Property Index As String()()()
        Public Property Text() As String
    End Structure
#End Region
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        sColor = cStyle(255, 0, 0, 250, 250, 0, 0, 50)
        Randomize(PI)
        tbMainDisplay.Text = ""
        eRunTime.Interval = 100
        nClock = eRunTime.Interval
        tbRate.Text = nClock.ToString
        wProb = 50
        tbChance.Text = wProb.ToString
        Dim t As Single = 0
        For x = 0 To 99
            gLine(x).X = 7 + t : gLine(x).Y = 64
            t += fMarg
        Next
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        Me.MinimizeBox = False
        Me.MaximizeBox = False
        Me.ControlBox = False
        intLetterBank()
        intSqaure()
        KJV = intBible(Bible)
        tbMainDisplay.Focus()
    End Sub

    Private Function intBible(ByVal B() As String) As SCRIPTURE()
        Dim BK(0) As SCRIPTURE
        Dim r As New Regex("\d*:\d*")
        Dim vcs() As String
        Dim s() As String
        Dim book As Integer = 0
        Dim chapter As Integer = 0
        Dim verse As Integer = 0
        Dim tb As String = B(0).Substring(0, B(0).IndexOf(" "))
        BK(book).Book = tb
        BK(book).Number = 1
        For Each l As String In B
            s = l.Split(" ")
            vcs = r.Match(l).ToString.Split(":")
            If l.StartsWith(tb) = False Then
                book += 1
                tb = l.Substring(0, l.IndexOf(" "))
                ReDim Preserve BK(book)
                BK(book).Book = tb
                BK(book).Number = book
                chapter = 0 : verse = 0
            End If
            If vcs(0) <> chapter Then
                chapter += 1 : verse = 0
                ReDim Preserve BK(book).Index(chapter)
            End If
            ReDim Preserve BK(book).Index(chapter)(verse)
            BK(book).Index(chapter)(verse) = s
            verse += 1
        Next
        Return BK
    End Function
    Function intLetterBank() As Boolean
        LetterBank(0) = {"A", "A", "A", "J", "S"}
        LetterBank(1) = {"B", "K", "T", " "}
        LetterBank(2) = {"C", "L", "U", "U", "U"}
        LetterBank(3) = {"D", "M", "V", " "}
        LetterBank(4) = {"E", "E", "E", "N", "W"}
        LetterBank(5) = {"F", "O", "O", "O", "X"}
        LetterBank(6) = {"G", "P", "Y", "Y", "Y"}
        LetterBank(7) = {"H", "Q", "Z", " "}
        LetterBank(8) = {"I", "I", "I", "R", " "}
        Return True
    End Function
    Function intSqaure() As Boolean
        Dim i As Integer = 1
        For x = 0 To 5
            For y = 0 To 5
                _S(x, y) = i
                i += 1
            Next
        Next
        Return True
    End Function
    Function shfSqaure() As Boolean
        Dim i1, j1, i2, j2 As Integer
        Dim t As Integer
        Do Until i1 <> j1 Or i2 <> j2
            i1 = rrNum(0, 6) : j1 = rrNum(0, 6)
            i2 = rrNum(0, 6) : j2 = rrNum(0, 6)
        Loop
        t = _S(i1, i2)
        _S(i1, i2) = _S(j1, j2)
        _S(j1, j2) = t
        Return True
    End Function
    Function calSquare(ByVal s As Integer(,)) As Integer
        Dim n As Integer = 0
        Dim nSum(13) As Integer
        nSum(0) = s(0, 0) + s(0, 1) + s(0, 2) + s(0, 3) + s(0, 4) + s(0, 5)
        nSum(1) = s(1, 0) + s(1, 1) + s(1, 2) + s(1, 3) + s(1, 4) + s(1, 5)
        nSum(2) = s(2, 0) + s(2, 1) + s(2, 2) + s(2, 3) + s(2, 4) + s(2, 5)
        nSum(3) = s(3, 0) + s(3, 1) + s(3, 2) + s(3, 3) + s(3, 4) + s(3, 5)
        nSum(4) = s(4, 0) + s(4, 1) + s(4, 2) + s(4, 3) + s(4, 4) + s(4, 5)
        nSum(5) = s(5, 0) + s(5, 1) + s(5, 2) + s(5, 3) + s(5, 4) + s(5, 5)
        nSum(6) = s(0, 0) + s(1, 0) + s(2, 0) + s(3, 0) + s(4, 0) + s(5, 0)
        nSum(7) = s(0, 1) + s(1, 1) + s(2, 1) + s(3, 1) + s(4, 1) + s(5, 1)
        nSum(8) = s(0, 2) + s(1, 2) + s(2, 2) + s(3, 2) + s(4, 2) + s(5, 2)
        nSum(9) = s(0, 3) + s(1, 3) + s(2, 3) + s(3, 3) + s(4, 3) + s(5, 3)
        nSum(10) = s(0, 4) + s(1, 4) + s(2, 4) + s(3, 4) + s(4, 4) + s(5, 4)
        nSum(11) = s(0, 5) + s(1, 5) + s(2, 5) + s(3, 5) + s(4, 5) + s(5, 5)
        nSum(12) = s(0, 0) + s(1, 1) + s(2, 2) + s(3, 3) + s(4, 4) + s(5, 5)
        nSum(13) = s(0, 5) + s(1, 4) + s(2, 3) + s(3, 2) + s(4, 1) + s(5, 0)
        For i = 0 To 13
            If nSum(i) = 111 Then n += 1
        Next
        Return n
    End Function
    Private Function rNum(ByVal min As Integer, ByVal max As Integer) As Integer
        Static r As Random = New Random()
        Return r.Next(min, max)
    End Function
    Private Function rrNum(ByVal min As Integer, ByVal max As Integer) As Integer
        Dim r As Random = New Random(rNum(0, 32767))
        Return r.Next(min, max)
    End Function
    Private Function cColor(ByVal a As Integer, ByVal r As Integer, ByVal g As Integer, ByVal b As Integer) As Color
        Dim C As Color = Color.FromArgb(a, r, g, b)
        Return C
    End Function
    Function cStyle(ByVal aMax As Integer, ByVal rMax As Integer, ByVal gMax As Integer, ByVal bMax As Integer, _
                    ByVal aMin As Integer, ByVal rMin As Integer, ByVal gMin As Integer, ByVal bMin As Integer) As Color()
        Dim ta(4) As Color
        Dim aT, rT, gT, bT, aP, rP, gP, bP As Integer
        aT = ((aMax - aMin) / 4) - 1 : rT = ((rMax - rMin) / 4) - 1 : gT = ((gMax - gMin) / 4) - 1 : bT = ((bMax - bMin) / 4) - 1
        aP = aMax : rP = rMax : gP = gMax : bP = bMax
        For i = 0 To 4
            ta(i) = cColor(255, rP, gP, bP)
            aP -= aT : rP -= rT : gP -= gT : bP -= bT
        Next
        ta(4) = cColor(255, 0, 0, 0)
        Return ta
    End Function
    Function Process() As Boolean
        Dim nVortex() As String = Nothing
        Dim a As Double = ((2 * PI) / 36)

        Dim n = rrNum(0, 2)
        If n = 0 Then
            Mark1 = mXv(ROZ(-a), Mark1)
            Mark1p = mXv(ROZ(-a), Mark1p)
        End If
        If n = 1 Then
            Mark1 = mXv(ROZ(a), Mark1)
            Mark1p = mXv(ROZ(a), Mark1p)
        End If
        If n = nLast Then
            nCount += 1
            nTotal += 1
            nCount = vSum(nCount)
            If n = 0 Then
                zTotal += 1
                If zTotal = 3 Then
                    Mark2 = mXv(ROZ(-a), Mark2)
                    Mark2p = mXv(ROZ(-a), Mark2p)
                End If
                If zTotal = 6 Then
                    Mark3 = mXv(ROZ(-a), Mark3)
                    Mark3p = mXv(ROZ(-a), Mark3p)
                End If
            ElseIf n = 1 Then
                oTotal += 1
                If oTotal = 3 Then
                    Mark2 = mXv(ROZ(a), Mark2)
                    Mark2p = mXv(ROZ(a), Mark2p)
                End If
                If zTotal = 6 Then
                    Mark3 = mXv(ROZ(a), Mark3)
                    Mark3p = mXv(ROZ(a), Mark3p)
                End If
            End If
        ElseIf nLast <> n Then
            nCount = 0
            nTotal = 0
            zTotal = 0
            oTotal = 0
        End If
        nLast = n
        '================================
        shfSqaure()
        Dim sD As Integer = calSquare(_S)
        With tbMainDisplay
            If sD = 0 Then
                .SelectionColor = gCgry
            ElseIf sD = 1 Then
                .SelectionColor = gCIgrn
            ElseIf sD = 2 Then
                .SelectionColor = gCIcyn
            ElseIf sD = 3 Then
                .SelectionColor = gCIblu
            ElseIf sD = 4 Then
                .SelectionColor = gCImag
            ElseIf sD = 5 Then
                .SelectionColor = gCIyel
            ElseIf sD = 6 Then
                .SelectionColor = gCIred
            ElseIf sD = 7 Then
                .SelectionColor = gCIred
            ElseIf sD = 8 Then
                .SelectionColor = gCIred
            ElseIf sD = 9 Then
                .SelectionColor = gCIred
            ElseIf sD = 10 Then
                .SelectionColor = gCIred
            ElseIf sD = 11 Then
                .SelectionColor = gCIred
            ElseIf sD = 12 Then
                .SelectionColor = gCred
            ElseIf sD = 13 Then
                .SelectionColor = gCIred
            ElseIf sD = 14 Then
                .SelectionColor = gCIred
            End If
            .AppendText(sD.ToString)
        End With
        '================================
        Dim t As PointF = gLine(99)
        For i = 99 To 1 Step -1
            gLine(i).Y = gLine(i - 1).Y
        Next
        If zTotal > 0 Then
            gLine(0).X = 7 : gLine(0).Y = 64 - (-zTotal * ymarg)
        ElseIf oTotal < 0 Then
            gLine(0).X = 7 : gLine(0).Y = 64 - (oTotal * ymarg)
        Else
            gLine(0).X = 7 : gLine(0).Y = 64 - (nTotal * ymarg)
        End If
        'gLine(0).X = 6 : gLine(0).Y = 64 - (nTotal * ymarg)
        '================================
        sD = nCount
        With tbMainDisplay
            If sD = 0 Then
                .SelectionColor = gCgry
            ElseIf sD = 1 Then
                .SelectionColor = gCgrn
            ElseIf sD = 2 Then
                .SelectionColor = gCcyn
            ElseIf sD = 3 Then
                .SelectionColor = gCblu
            ElseIf sD = 4 Then
                .SelectionColor = gCmag
            ElseIf sD = 5 Then
                .SelectionColor = gCyel
            ElseIf sD = 6 Then
                .SelectionColor = gCred
            ElseIf sD = 7 Then
                .SelectionColor = gCred
            ElseIf sD = 8 Then
                .SelectionColor = gCred
            ElseIf sD = 9 Then
                .SelectionColor = gCred
            ElseIf sD = 10 Then
                .SelectionColor = gCred
            ElseIf sD = 11 Then
                .SelectionColor = gCred
            ElseIf sD = 12 Then
                .SelectionColor = gCred
            ElseIf sD = 13 Then
                .SelectionColor = gCred
            ElseIf sD = 14 Then
                .SelectionColor = gCred
            ElseIf sD = 15 Then
                .SelectionColor = gCred
            ElseIf sD = 16 Then
                .SelectionColor = gCred
            ElseIf sD = 17 Then
                .SelectionColor = gCred
            ElseIf sD = 18 Then
                .SelectionColor = gCred
            ElseIf sD = 19 Then
                .SelectionColor = gCred
            ElseIf sD = 20 Then
                .SelectionColor = gCred
            ElseIf sD = 21 Then
                .SelectionColor = gCred
            ElseIf sD = 22 Then
                .SelectionColor = gCred
            Else
                .SelectionColor = gCred
            End If
            .AppendText(sD.ToString + " ")
        End With
        '================================
        If wProb <> 0 Then
            nVortex = WordGen(wProb).Split(" ")
            For Each w As String In nVortex
                If WordCheck(w, WordBank) = True Then
                    With tbMainDisplay
                        .SelectionColor = gCIwht
                        .AppendText(w + " ")
                    End With
                End If
            Next
        End If
        Return True
    End Function
    Function wScripture()
        Dim nc As Integer = 0 : Dim nv As Integer = 0
        'For b = 0 To KJV.Length - 1
        '    For c = 0 To KJV(b).Index.GetUpperBound(0)
        '        For v = 0 To KJV(b).Index(c).Length - 1
        '            For Each w As String In KJV(b).Index(c)(v)
        '                With tbMainDisplay
        '                    .SelectionColor = gCIwht
        '                    .AppendText(w + " ")
        '                End With
        '            Next
        '        Next
        '    Next
        'Next
        For b = 0 To KJV.Length - 1
            For Each c As Array In KJV(b).Index
                For Each v As Array In KJV(b).Index(nc)
                    For Each w As String In KJV(b).Index(nc)(nv)
                        With tbMainDisplay
                            .SelectionColor = gCIwht
                            .AppendText(w + " ")
                        End With
                    Next
                    nv += 1
                Next
                nc += 1 : nv = 0
            Next
            nc = 0 : nv = 0
        Next
        'With tbMainDisplay
        '    .SelectionColor = gCIwht
        '    .AppendText(KJV(2).Index(2)(2)(2))
        'End With
        Return True
    End Function
    '-------------------
    '|1|2|3|4|5|6|7|8|9|
    '|A|B|C|D|E|F|G|H|I|
    '|J|K|L|M|N|O|P|Q|R|
    '|S|T|U|V|W|X|Y|Z| |
    '-------------------
    '---------------------------------
    '|111| 1 | 2 | 3 | 4 | 5 | 6 |111|
    '| 1 | 6 | 32| 3 | 34| 35| 1 |111|
    '| 2 | 7 | 11| 27| 28| 8 | 30|111|
    '| 3 | 19| 14| 16| 15| 23| 24|111|
    '| 4 | 18| 20| 22| 21| 17| 13|111|
    '| 5 | 25| 29| 10| 9 | 26| 12|111|
    '| 6 | 36| 5 | 33| 4 | 2 | 31|111|
    '|111|111|111|111|111|111|111|666|
    '---------------------------------
    Function WordCheck(ByVal s As String, ByVal b As String()) As Boolean
        For Each w As String In b
            If w.Trim = s Then
                Return True
                Exit Function
            End If
        Next
        Return False
    End Function
    Function WordGen(ByVal l As Integer) As String
        Dim s As String = ""
        Dim n As Integer = Nothing
        For i = 0 To l - 1
            n = rrNum(0, 9)
            s = s + LetterBank(n)(rrNum(0, LetterBank(n).Length))
        Next
        Return s
    End Function

    Private Function ExpIO(ByVal e As String, ByRef t As RichTextBox, ByVal c1 As Color, ByVal c2 As Color) As Boolean
        Dim r As New Regex(e, RegexOptions.None)
        Dim Matches As MatchCollection = Regex.Matches(tbMainDisplay.Text, e)
        If Not Matches.Count <> 0 Then
            Return False
        End If
        Dim CaretPosition As Integer = tbMainDisplay.SelectionStart
        tbMainDisplay.SuspendLayout()
        For Each Match As Match In Matches
            tbMainDisplay.Select(Match.Index, Match.Length)
            tbMainDisplay.SelectionColor = c1
        Next Match
        tbMainDisplay.Select(CaretPosition, 0)
        tbMainDisplay.ResumeLayout()
        Return True
    End Function
    Private Function UpdateLog() As Boolean
        ExpIO("[A-Z]*", tbMainDisplay, sColor(0), sColor(2))
        ExpIO("[9]*", tbMainDisplay, sColor(0), sColor(2))
        Return True
    End Function
    Private Function SumDigits(ByVal i As Integer) As Integer
        Dim sum As Integer = 0, n As Integer
        While i > 0
            n = i
            i \= 10
            sum += n - (i * 10)
        End While
        Return sum
    End Function
    Function vSum(ByVal n As Integer) As Integer
        Do
            n = SumDigits(n)
        Loop While Math.Log(n, 10) > 1
        Return n
    End Function
    Function nFlip(ByVal l As Integer, ByVal h As Integer) As Integer
        Dim n As Integer = rrNum(l, h)
        Return n
    End Function
    Private Function artifact(ByVal b As Bitmap) As Bitmap
        Dim bc As Color = Nothing
        For x As Integer = 0 To b.Width - 1
            For y As Integer = 0 To b.Height - 1
                bc = cColor(255, rrNum(0, 255), rrNum(0, 255), rrNum(0, 255))
                b.SetPixel(x, y, bc)
            Next y
        Next x
        Return b
    End Function


    Private Sub eRunTime_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles eRunTime.Tick
        'Process()
        'pbBR.Refresh()
        'pbBL.Refresh()
        'pbTR.Refresh()
        'pbTL.Refresh()
        wScripture()
    End Sub
    Private Function ValueC(ByVal v As Integer, ByVal c As Integer, ByVal min As Integer, ByVal max As Integer) As Integer
        Dim tV As Integer = v
        tV += c
        If tV < min Then tV = min
        If tV > max Then tV = max
        Return tV
    End Function



#Region "Main form"
    Private Sub Form1_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pControlTop.MouseDown
        drag = True
        mousex = Windows.Forms.Cursor.Position.X - Me.Left
        mousey = Windows.Forms.Cursor.Position.Y - Me.Top
    End Sub

    Private Sub Form1_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pControlTop.MouseMove
        If drag Then
            Me.Top = Windows.Forms.Cursor.Position.Y - mousey
            Me.Left = Windows.Forms.Cursor.Position.X - mousex
        End If
    End Sub

    Private Sub Form1_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pControlTop.MouseUp
        drag = False
    End Sub
    Private Sub MainForm_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        Me.Refresh()
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
    Private Sub MainForm_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

    End Sub
    Private Sub MainForm_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint

    End Sub
    Private Sub btnMinBox_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMinBox.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub
#End Region

#Region "Paint"
    Private Sub btnStyle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStyle.Click
        sColor = cStyle(255, rrNum(125, 255), rrNum(125, 255), rrNum(125, 255), 255, rrNum(1, 124), rrNum(1, 124), rrNum(1, 124))
        pControlBottom.BackColor = sColor(4)
        pControlTop.BackColor = sColor(4)
        pControlLeft.BackColor = sColor(4)
        pControlRight.BackColor = sColor(4)
        pControlCenter.BackColor = sColor(4)
        tbChance.BackColor = sColor(4)
        tbChance.ForeColor = sColor(0)
        tbRate.BackColor = sColor(4)
        tbRate.ForeColor = sColor(0)
        tbMainDisplay.BackColor = sColor(4)
        'tbMainDisplay.ForeColor = sColor(2)
        pbBL.BackColor = sColor(4)
        pbTL.BackColor = sColor(4)
        pbBR.BackColor = sColor(4)
        pbTR.BackColor = sColor(4)

        btnClear.BackColor = sColor(4)
        btnClear.ForeColor = sColor(0)
        btnClear.FlatAppearance.BorderColor = sColor(0)
        btnClear.FlatAppearance.MouseDownBackColor = sColor(1)
        btnClear.FlatAppearance.MouseOverBackColor = sColor(2)

        btnStart.BackColor = sColor(4)
        btnStart.ForeColor = sColor(0)
        btnStart.FlatAppearance.BorderColor = sColor(0)
        btnStart.FlatAppearance.MouseDownBackColor = sColor(1)
        btnStart.FlatAppearance.MouseOverBackColor = sColor(2)

        btnStop.BackColor = sColor(4)
        btnStop.ForeColor = sColor(0)
        btnStop.FlatAppearance.BorderColor = sColor(0)
        btnStop.FlatAppearance.MouseDownBackColor = sColor(1)
        btnStop.FlatAppearance.MouseOverBackColor = sColor(2)

        btnSave.BackColor = sColor(4)
        btnSave.ForeColor = sColor(0)
        btnSave.FlatAppearance.BorderColor = sColor(0)
        btnSave.FlatAppearance.MouseDownBackColor = sColor(1)
        btnSave.FlatAppearance.MouseOverBackColor = sColor(2)

        btnProbRight.BackColor = sColor(4)
        btnProbRight.ForeColor = sColor(0)
        btnProbRight.FlatAppearance.BorderColor = sColor(0)
        btnProbRight.FlatAppearance.MouseDownBackColor = sColor(1)
        btnProbRight.FlatAppearance.MouseOverBackColor = sColor(2)

        btnProbLeft.BackColor = sColor(4)
        btnProbLeft.ForeColor = sColor(0)
        btnProbLeft.FlatAppearance.BorderColor = sColor(0)
        btnProbLeft.FlatAppearance.MouseDownBackColor = sColor(1)
        btnProbLeft.FlatAppearance.MouseOverBackColor = sColor(2)

        btnTimeLeft.BackColor = sColor(4)
        btnTimeLeft.ForeColor = sColor(0)
        btnTimeLeft.FlatAppearance.BorderColor = sColor(0)
        btnTimeLeft.FlatAppearance.MouseDownBackColor = sColor(1)
        btnTimeLeft.FlatAppearance.MouseOverBackColor = sColor(2)

        btnTimeRight.BackColor = sColor(4)
        btnTimeRight.ForeColor = sColor(0)
        btnTimeRight.FlatAppearance.BorderColor = sColor(0)
        btnTimeRight.FlatAppearance.MouseDownBackColor = sColor(1)
        btnTimeRight.FlatAppearance.MouseOverBackColor = sColor(2)

        btnClose.BackColor = sColor(4)
        btnClose.ForeColor = sColor(0)
        btnClose.FlatAppearance.BorderColor = sColor(0)


        btnMinBox.BackColor = sColor(4)
        btnMinBox.ForeColor = sColor(0)
        btnMinBox.FlatAppearance.BorderColor = sColor(0)


        btnStyle.BackColor = sColor(4)
        btnStyle.ForeColor = sColor(0)
        btnStyle.FlatAppearance.BorderColor = sColor(0)
        'UpdateLog()
        Me.Refresh()
        tbMainDisplay.Focus()
    End Sub
    Private Sub pControlTop_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles pControlTop.Paint
        Dim g As Graphics = e.Graphics
        Dim gpen As Pen = New Pen(sColor(0), 0)
        g.DrawRectangle(gpen, 0, 0, pControlTop.Width - 1, pControlTop.Height - 1)
        gpen.Color = sColor(1)
        g.DrawRectangle(gpen, 1, 1, pControlTop.Width - 3, pControlTop.Height - 3)
        gpen.Color = sColor(2)
        g.DrawRectangle(gpen, 2, 2, pControlTop.Width - 5, pControlTop.Height - 5)
        gpen.Color = sColor(3)
        g.DrawRectangle(gpen, 3, 3, pControlTop.Width - 7, pControlTop.Height - 7)
        gpen.Color = sColor(4)
        g.DrawRectangle(gpen, 4, 4, pControlTop.Width - 9, pControlTop.Height - 9)
        g.SmoothingMode = SmoothingMode.AntiAlias
        g.TextRenderingHint = Drawing.Text.TextRenderingHint.AntiAlias
        Dim pen1 As Pen = New Pen(sColor(0), 2)
        pen1.SetLineCap(LineCap.Round, LineCap.Round, DashCap.Round)
        Dim pen2 As Pen = New Pen(sColor(1), 0)
        Dim pen3 As Pen = New Pen(sColor(2), 0)
        Dim pen4 As Pen = New Pen(sColor(3), 0)
        Dim pen5 As Pen = New Pen(sColor(4), 0)
        Dim brush4 As Brush = New SolidBrush(sColor(1))
        '---------------------------------------
        g.DrawString("Ouija Box", New Font("Times New Roman", 12, FontStyle.Bold), brush4, 8, 5)
        '---------------------------------------
        pen1.Dispose()
        pen2.Dispose()
        pen3.Dispose()
        pen4.Dispose()
        pen5.Dispose()
        brush4.Dispose()
        gpen.Dispose()
    End Sub

    Private Sub pControlBottom_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles pControlBottom.Paint
        Dim g As Graphics = e.Graphics
        Dim gpen As Pen = New Pen(sColor(0), 0)
        g.DrawRectangle(gpen, 0, 0, pControlBottom.Width - 1, pControlBottom.Height - 1)
        gpen.Color = sColor(1)
        g.DrawRectangle(gpen, 1, 1, pControlBottom.Width - 3, pControlBottom.Height - 3)
        gpen.Color = sColor(2)
        g.DrawRectangle(gpen, 2, 2, pControlBottom.Width - 5, pControlBottom.Height - 5)
        gpen.Color = sColor(3)
        g.DrawRectangle(gpen, 3, 3, pControlBottom.Width - 7, pControlBottom.Height - 7)
        gpen.Color = sColor(4)
        g.DrawRectangle(gpen, 4, 4, pControlBottom.Width - 9, pControlBottom.Height - 9)
        gpen.Dispose()
    End Sub

    Private Sub pControlLeft_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles pControlLeft.Paint
        Dim g As Graphics = e.Graphics
        Dim gpen As Pen = New Pen(sColor(0), 0)
        g.DrawRectangle(gpen, 0, 0, pControlLeft.Width - 1, pControlLeft.Height - 1)
        gpen.Color = sColor(1)
        g.DrawRectangle(gpen, 1, 1, pControlLeft.Width - 3, pControlLeft.Height - 3)
        gpen.Color = sColor(2)
        g.DrawRectangle(gpen, 2, 2, pControlLeft.Width - 5, pControlLeft.Height - 5)
        gpen.Color = sColor(3)
        g.DrawRectangle(gpen, 3, 3, pControlLeft.Width - 7, pControlLeft.Height - 7)
        gpen.Color = sColor(4)
        g.DrawRectangle(gpen, 4, 4, pControlLeft.Width - 9, pControlLeft.Height - 9)
        gpen.Dispose()
    End Sub

    Private Sub pControlRight_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles pControlRight.Paint
        Dim g As Graphics = e.Graphics
        Dim gpen As Pen = New Pen(sColor(0), 0)
        g.DrawRectangle(gpen, 0, 0, pControlRight.Width - 1, pControlRight.Height - 1)
        gpen.Color = sColor(1)
        g.DrawRectangle(gpen, 1, 1, pControlRight.Width - 3, pControlRight.Height - 3)
        gpen.Color = sColor(2)
        g.DrawRectangle(gpen, 2, 2, pControlRight.Width - 5, pControlRight.Height - 5)
        gpen.Color = sColor(3)
        g.DrawRectangle(gpen, 3, 3, pControlRight.Width - 7, pControlRight.Height - 7)
        gpen.Color = sColor(4)
        g.DrawRectangle(gpen, 4, 4, pControlRight.Width - 9, pControlRight.Height - 9)
        gpen.Dispose()
    End Sub

    Private Sub pControlCenter_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles pControlCenter.Paint
        Dim g As Graphics = e.Graphics
        Dim gpen As Pen = New Pen(sColor(0), 0)
        g.DrawRectangle(gpen, 0, 0, pControlCenter.Width - 1, pControlCenter.Height - 1)
        gpen.Color = sColor(1)
        g.DrawRectangle(gpen, 1, 1, pControlCenter.Width - 3, pControlCenter.Height - 3)
        gpen.Color = sColor(2)
        g.DrawRectangle(gpen, 2, 2, pControlCenter.Width - 5, pControlCenter.Height - 5)
        gpen.Color = sColor(3)
        g.DrawRectangle(gpen, 3, 3, pControlCenter.Width - 7, pControlCenter.Height - 7)
        gpen.Color = sColor(4)
        g.DrawRectangle(gpen, 4, 4, pControlCenter.Width - 9, pControlCenter.Height - 9)
        gpen.Dispose()
    End Sub
#End Region


    Private Sub btnStart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStart.Click
        eRunTime.Start()
        tbMainDisplay.Focus()
    End Sub

    Private Sub btnStop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStop.Click
        eRunTime.Stop()
        tbMainDisplay.Focus()
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim SD As New SaveFileDialog
        SD.Filter = "Text Log|*.txt"
        SD.Title = "Save Log"
        SD.RestoreDirectory = True
        eRunTime.Stop()
        SD.ShowDialog()
        If Not SD.FileName = "" Then
            Try
                Dim objWriter As New System.IO.StreamWriter(SD.FileName)
                objWriter.Write(tbMainDisplay.Text)
                objWriter.Close()
            Catch ex As Exception
                MessageBox.Show(ex.ToString)
            Finally

            End Try
        End If
        eRunTime.Start()
        tbMainDisplay.Focus()
    End Sub

    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click

        tbMainDisplay.Text = ""
        tbMainDisplay.Focus()
    End Sub


    Private Sub btnTimeRight_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTimeRight.Click
        nClock = ValueC(nClock, 5, 5, 1000)
        eRunTime.Interval = nClock
        tbRate.Text = nClock.ToString
        tbMainDisplay.Focus()
    End Sub

    Private Sub btnTimeLeft_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTimeLeft.Click
        nClock = ValueC(nClock, -5, 5, 1000)
        eRunTime.Interval = nClock
        tbRate.Text = nClock.ToString
        tbMainDisplay.Focus()
    End Sub

    Private Sub btnProbRight_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnProbRight.Click
        wProb = ValueC(wProb, 5, 0, 1000)
        tbChance.Text = wProb.ToString
        tbMainDisplay.Focus()
    End Sub

    Private Sub btnProbLeft_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnProbLeft.Click
        wProb = ValueC(wProb, -5, 0, 1000)
        tbChance.Text = wProb.ToString
        tbMainDisplay.Focus()

    End Sub
#Region "Math Functions"
    Private Function oPress(ByVal v As XYZ, ByVal w As XYZ()) As XYZ()
        Dim M As MTX = mXm(ROX(v.X), mXm(ROY(v.Y), (ROZ(v.Z))))
        Dim tWv() As XYZ = w
        For x = 0 To w.Length - 1
            tWv(x) = mXv(M, tWv(x))
        Next
        Return tWv
    End Function
    Private Function rPress(ByVal v As XYZ, ByVal w As XYZ(), ByVal o As XYZ) As XYZ()
        Dim M As MTX = mXm(ROX(v.X), mXm(ROY(v.Y), (ROZ(v.Z))))
        Dim tWv() As XYZ = w
        For x = 0 To w.Length - 1
            tWv(x) = mXv(MTR(o), mXv(M, mXv(MTB(o), tWv(x))))
        Next
        Return tWv
    End Function
    Private Function tPress(ByVal v As XYZ, ByVal w As XYZ()) As XYZ()
        Dim tWv(w.Length - 1) As XYZ
        For x = 0 To w.Length - 1
            tWv(x) = norm(mXv(MTR(v), w(x)))
        Next
        Return tWv
    End Function
    Private Function cross(ByVal a As XYZ, ByVal b As XYZ) As XYZ
        Dim cp As XYZ
        cp.X = a.Y * b.Z - b.Y * a.Z
        cp.Y = a.Z * b.X - b.Z * a.X
        cp.Z = a.X * b.Y - b.X * a.Y
        cp.W = 1
        Return cp
    End Function
    Private Function dot(ByVal a As XYZ, ByVal b As XYZ) As Double
        Dim dp As Double
        dp = a.X * b.X + a.Y * b.Y + a.Z * b.Z
        Return dp
    End Function
    Private Function minus(ByVal A As XYZ, ByVal B As XYZ) As XYZ
        Dim C As XYZ
        C.X = A.X - B.X
        C.Y = A.Y - B.Y
        C.Z = A.Z - B.Z
        C.W = 1
        Return C
    End Function
    Private Function norm(ByVal A As XYZ) As XYZ
        Dim C As XYZ
        C.X = A.X / A.W
        C.Y = A.Y / A.W
        C.Z = A.Z / A.W
        C.W = 1
        Return C
    End Function
    Private Function distance(ByVal p1 As XYZ, ByVal p2 As XYZ) As Double
        Dim d As Double
        Dim td As Double
        td = (Math.Sqrt(((p1.X - p2.X) ^ 2) + ((p1.Y - p2.Y) ^ 2) + ((p1.Z - p2.Z) ^ 2)))
        d = Abs(td)
        Return d
    End Function
    Private Function m2Xp(ByVal A As MTX, ByVal B As PointF) As PointF
        Dim P As PointF
        P.X = (A.c1r1 * B.X) + (A.c2r1 * B.Y)
        P.Y = (A.c1r2 * B.X) + (A.c2r2 * B.Y)
        Return P
    End Function
    Private Function mXv(ByVal A As MTX, ByVal B As XYZ) As XYZ
        Dim v As XYZ
        v.X = (A.c1r1 * B.X) + (A.c2r1 * B.Y) + (A.c3r1 * B.Z) + (A.c4r1 * B.W)
        v.Y = (A.c1r2 * B.X) + (A.c2r2 * B.Y) + (A.c3r2 * B.Z) + (A.c4r2 * B.W)
        v.Z = (A.c1r3 * B.X) + (A.c2r3 * B.Y) + (A.c3r3 * B.Z) + (A.c4r3 * B.W)
        v.W = (A.c1r4 * B.X) + (A.c2r4 * B.Y) + (A.c3r4 * B.Z) + (A.c4r4 * B.W)
        Return v
    End Function
    Private Function m2Xm2(ByVal A As MTX, ByVal B As MTX2) As MTX2
        Dim C As MTX2
        C.c1r1 = (A.c1r1 * B.c1r1) + (A.c2r1 * B.c1r2)
        C.c1r2 = (A.c1r2 * B.c1r1) + (A.c2r2 * B.c1r2)
        C.c2r1 = (A.c1r1 * B.c2r1) + (A.c2r1 * B.c2r2)
        C.c2r2 = (A.c1r2 * B.c2r1) + (A.c2r2 * B.c2r2)
        Return C
    End Function
    Private Function mXm(ByVal A As MTX, ByVal B As MTX) As MTX
        Dim C As MTX
        C.c1r1 = (A.c1r1 * B.c1r1) + (A.c2r1 * B.c1r2) + (A.c3r1 * B.c1r3) + (A.c4r1 * B.c1r4)
        C.c1r2 = (A.c1r2 * B.c1r1) + (A.c2r2 * B.c1r2) + (A.c3r2 * B.c1r3) + (A.c4r2 * B.c1r4)
        C.c1r3 = (A.c1r3 * B.c1r1) + (A.c2r3 * B.c1r2) + (A.c3r3 * B.c1r3) + (A.c4r3 * B.c1r4)
        C.c1r4 = (A.c1r4 * B.c1r1) + (A.c2r4 * B.c1r2) + (A.c3r4 * B.c1r3) + (A.c4r4 * B.c1r4)
        C.c2r1 = (A.c1r1 * B.c2r1) + (A.c2r1 * B.c2r2) + (A.c3r1 * B.c2r3) + (A.c4r1 * B.c2r4)
        C.c2r2 = (A.c1r2 * B.c2r1) + (A.c2r2 * B.c2r2) + (A.c3r2 * B.c2r3) + (A.c4r2 * B.c2r4)
        C.c2r3 = (A.c1r3 * B.c2r1) + (A.c2r3 * B.c2r2) + (A.c3r3 * B.c2r3) + (A.c4r3 * B.c2r4)
        C.c2r4 = (A.c1r4 * B.c2r1) + (A.c2r4 * B.c2r2) + (A.c3r4 * B.c2r3) + (A.c4r4 * B.c2r4)
        C.c3r1 = (A.c1r1 * B.c3r1) + (A.c2r1 * B.c3r2) + (A.c3r1 * B.c3r3) + (A.c4r1 * B.c3r4)
        C.c3r2 = (A.c1r2 * B.c3r1) + (A.c2r2 * B.c3r2) + (A.c3r2 * B.c3r3) + (A.c4r2 * B.c3r4)
        C.c3r3 = (A.c1r3 * B.c3r1) + (A.c2r3 * B.c3r2) + (A.c3r3 * B.c3r3) + (A.c4r3 * B.c3r4)
        C.c3r4 = (A.c1r4 * B.c3r1) + (A.c2r4 * B.c3r2) + (A.c3r4 * B.c3r3) + (A.c4r4 * B.c3r4)
        C.c4r1 = (A.c1r1 * B.c4r1) + (A.c2r1 * B.c4r2) + (A.c3r1 * B.c4r3) + (A.c4r1 * B.c4r4)
        C.c4r2 = (A.c1r2 * B.c4r1) + (A.c2r2 * B.c4r2) + (A.c3r2 * B.c4r3) + (A.c4r2 * B.c4r4)
        C.c4r3 = (A.c1r3 * B.c4r1) + (A.c2r3 * B.c4r2) + (A.c3r3 * B.c4r3) + (A.c4r3 * B.c4r4)
        C.c4r4 = (A.c1r4 * B.c4r1) + (A.c2r4 * B.c4r2) + (A.c3r4 * B.c4r3) + (A.c4r4 * B.c4r4)
        Return C
    End Function
    Private Function project(ByVal V As XYZ) As PointF
        Dim P As PointF
        Dim px, py As Double
        py = V.Y
        px = V.X

        P = New PointF(px, py)
        P.X = P.X + pbTR.Width / 2
        P.Y = -P.Y + pbTR.Height / 2
        Return P
    End Function
    Private Function MI() As MTX
        Dim C As MTX
        C.c1r1 = 1 : C.c2r1 = 0 : C.c3r1 = 0 : C.c4r1 = 0
        C.c1r2 = 0 : C.c2r2 = 1 : C.c3r2 = 0 : C.c4r2 = 0
        C.c1r3 = 0 : C.c2r3 = 0 : C.c3r3 = 1 : C.c4r3 = 0
        C.c1r4 = 0 : C.c2r4 = 0 : C.c3r4 = 0 : C.c4r4 = 1
        Return C
    End Function

    Private Function ROX(ByVal a As Double)
        Dim C As MTX
        C.c1r1 = 1 : C.c2r1 = 0 : C.c3r1 = 0 : C.c4r1 = 0
        C.c1r2 = 0 : C.c2r2 = Cos(a) : C.c3r2 = Sin(a) : C.c4r2 = 0
        C.c1r3 = 0 : C.c2r3 = -Sin(a) : C.c3r3 = Cos(a) : C.c4r3 = 0
        C.c1r4 = 0 : C.c2r4 = 0 : C.c3r4 = 0 : C.c4r4 = 1
        Return C
    End Function
    Private Function ROY(ByVal a As Double)
        Dim C As MTX
        C.c1r1 = Cos(a) : C.c2r1 = 0 : C.c3r1 = -Sin(a) : C.c4r1 = 0
        C.c1r2 = 0 : C.c2r2 = 1 : C.c3r2 = 0 : C.c4r2 = 0
        C.c1r3 = Sin(a) : C.c2r3 = 0 : C.c3r3 = Cos(a) : C.c4r3 = 0
        C.c1r4 = 0 : C.c2r4 = 0 : C.c3r4 = 0 : C.c4r4 = 1
        Return C
    End Function
    Private Function ROZ(ByVal a As Double)
        Dim C As MTX
        C.c1r1 = Cos(a) : C.c2r1 = Sin(a) : C.c3r1 = 0 : C.c4r1 = 0
        C.c1r2 = -Sin(a) : C.c2r2 = Cos(a) : C.c3r2 = 0 : C.c4r2 = 0
        C.c1r3 = 0 : C.c2r3 = 0 : C.c3r3 = 1 : C.c4r3 = 0
        C.c1r4 = 0 : C.c2r4 = 0 : C.c3r4 = 0 : C.c4r4 = 1
        Return C
    End Function
    Private Function MTR(ByVal V As XYZ) As MTX
        Dim C As MTX
        C.c1r1 = 1 : C.c2r1 = 0 : C.c3r1 = 0 : C.c4r1 = V.X
        C.c1r2 = 0 : C.c2r2 = 1 : C.c3r2 = 0 : C.c4r2 = V.Y
        C.c1r3 = 0 : C.c2r3 = 0 : C.c3r3 = 1 : C.c4r3 = V.Z
        C.c1r4 = 0 : C.c2r4 = 0 : C.c3r4 = 0 : C.c4r4 = 1
        Return C
    End Function
    Private Function MTB(ByVal V As XYZ) As MTX
        Dim C As MTX
        C.c1r1 = 1 : C.c2r1 = 0 : C.c3r1 = 0 : C.c4r1 = V.X * -1
        C.c1r2 = 0 : C.c2r2 = 1 : C.c3r2 = 0 : C.c4r2 = V.Y * -1
        C.c1r3 = 0 : C.c2r3 = 0 : C.c3r3 = 1 : C.c4r3 = V.Z * -1
        C.c1r4 = 0 : C.c2r4 = 0 : C.c3r4 = 0 : C.c4r4 = 1
        Return C
    End Function
    Private Function MSC(ByVal V As XYZ) As MTX
        Dim C As MTX
        C.c1r1 = V.X : C.c2r1 = 0 : C.c3r1 = 0 : C.c4r1 = 0
        C.c1r2 = 0 : C.c2r2 = V.Y : C.c3r2 = 0 : C.c4r2 = 0
        C.c1r3 = 0 : C.c2r3 = 0 : C.c3r3 = V.Z : C.c4r3 = 0
        C.c1r4 = 0 : C.c2r4 = 0 : C.c3r4 = 0 : C.c4r4 = 1
        Return C

    End Function
    Private Function vCompile(ByVal x As Double, ByVal y As Double, ByVal z As Double) As XYZ
        Dim tV As XYZ
        tV.X = x : tV.Y = y : tV.Z = z : tV.W = 1
        Return tV
    End Function
#End Region



    Private Sub pbBR_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles pbBR.Paint
        Dim g As Graphics = e.Graphics
        g.SmoothingMode = SmoothingMode.AntiAlias
        g.TextRenderingHint = Drawing.Text.TextRenderingHint.AntiAlias
        Dim pen1 As Pen = New Pen(sColor(0), 0)
        Dim pen2 As Pen = New Pen(sColor(1), 0)
        Dim pen3 As Pen = New Pen(sColor(2), 0)
        pen3.DashStyle = DashStyle.Dash
        Dim pen4 As Pen = New Pen(sColor(3), 0)

        Dim brush4 As Brush = New SolidBrush(sColor(1))
        Dim pen5 As Pen = New Pen(gCDred)
        pen5.DashStyle = DashStyle.Dash
        '---------------------------------------
        g.DrawRectangle(pen2, 1, 1, 125, 125)
        g.DrawRectangle(pen1, 0, 0, 127, 127)
        g.DrawRectangle(pen1, 6, 6, 115, 115)
        g.DrawLine(pen5, 7, 64 - ymarg * 10, 120, 64 - (ymarg * 10))
        g.DrawLine(pen5, 7, 64 - ymarg * -10, 120, 64 - (ymarg * -10))
        pen5.Color = gCDyel
        g.DrawLine(pen5, 7, 64 - ymarg * 5, 120, 64 - (ymarg * 5))
        g.DrawLine(pen5, 7, 64 - ymarg * -5, 120, 64 - (ymarg * -5))
        pen5.Color = gCDgrn
        pen1.Color = gCIblu
        g.DrawString(" 10", New Font("Lucida Console", 8), brush4, 6, 64 - (ymarg * 10) - 15)
        g.DrawString("-10", New Font("Lucida Console", 8), brush4, 6, 64 - (ymarg * -10) + 5)

        g.DrawLine(pen5, 7, 64, 114, 64)
        'g.DrawLine(pen1, 2, 64, 6, 64)
        'g.DrawLine(pen1, New Point(6, 64), gLine(0))
        g.DrawLines(pen1, gLine)
        pen1.Color = sColor(0)


        '---------------------------------------
        '---------------------------------------
        '---------------------------------------
        pen1.Dispose()
        pen2.Dispose()
        pen3.Dispose()
        pen4.Dispose()
        pen5.Dispose()
        brush4.Dispose()
    End Sub

    Private Sub pbBL_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles pbBL.Paint
        Dim g As Graphics = e.Graphics
        g.SmoothingMode = SmoothingMode.AntiAlias
        g.TextRenderingHint = Drawing.Text.TextRenderingHint.AntiAlias
        Dim pen1 As Pen = New Pen(sColor(0), 0)
        Dim pen2 As Pen = New Pen(sColor(1), 0)
        Dim pen3 As Pen = New Pen(sColor(2), 0)
        Dim pen4 As Pen = New Pen(sColor(3), 0)
        Dim pen5 As Pen = New Pen(sColor(4), 0)
        Dim brushr As Brush = New SolidBrush(sColor(1))
        '---------------------------------------
        g.DrawRectangle(pen2, 1, 1, 125, 125)
        g.DrawRectangle(pen1, 0, 0, 127, 127)
        g.DrawRectangle(pen3, 6, 6, 115, 115)
        g.DrawRectangle(pen3, 12, 12, 103, 103)
        g.SmoothingMode = SmoothingMode.HighSpeed
        For x As Integer = 0 To 99 Step 4
            For y As Integer = 0 To 99 Step 4
                brushr = New SolidBrush(cColor(rrNum(0, 255), rrNum(0, 255), rrNum(0, 255), rrNum(0, 255)))
                'brushr = New SolidBrush(sColor(rrNum(0, 5)))
                g.FillRectangle(brushr, x + 14, y + 14, 4, 4)
            Next y
        Next x
        '---------------------------------------
        pen1.Dispose()
        pen2.Dispose()
        pen3.Dispose()
        pen4.Dispose()
        pen5.Dispose()
        brushr.Dispose()
    End Sub

    Private Sub pbTR_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles pbTR.Paint
        Dim g As Graphics = e.Graphics
        g.SmoothingMode = SmoothingMode.AntiAlias
        g.TextRenderingHint = Drawing.Text.TextRenderingHint.AntiAlias
        Dim gFont As Font = New Font("Wingdings", 8)
        Dim a As Double = ((2 * PI) / 12)
        Dim pen1 As Pen = New Pen(sColor(0), 0)
        Dim pen2 As Pen = New Pen(sColor(1), 0)
        Dim pen3 As Pen = New Pen(sColor(2), 0)
        Dim pen4 As Pen = New Pen(sColor(3), 0)
        Dim pen5 As Pen = New Pen(sColor(4), 0)
        Dim brush1 As Brush = New SolidBrush(sColor(0))
        Dim brush2 As Brush = New SolidBrush(sColor(1))
        Dim brush3 As Brush = New SolidBrush(sColor(2))
        '---------------------------------------
        g.DrawRectangle(pen2, 1, 1, 125, 125)
        g.DrawRectangle(pen1, 0, 0, 127, 127)
        g.DrawRectangle(pen3, 6, 6, 115, 115)
        pen1.Width = 2
        pen4.DashStyle = DashStyle.Dash
        pen2.DashStyle = DashStyle.Dash
        For i = 0 To 50 Step 10
            g.DrawEllipse(pen4, 10 + i, 10 + i, 107 - (i * 2), 107 - (i * 2))

        Next



        g.DrawLine(pen4, 64, 10, 64, 115)
        g.DrawLine(pen4, 10, 64, 115, 64)

        g.DrawLine(pen4, 26, 26, 102, 102)
        g.DrawLine(pen4, 102, 26, 26, 102)
        For i = 0 To 11
            g.DrawString(sSign(i), gFont, brush1, project(MarkS).X - 7, project(MarkS).Y - 7)
            MarkS = mXv(ROZ(a), MarkS)
        Next
        g.DrawEllipse(pen1, 10, 10, 107, 107)
        g.FillEllipse(brush3, project(Center).X - 2, project(Center).Y - 2, 4, 4)
        g.DrawLine(pen2, project(Mark1p), project(Center))
        g.DrawLine(pen2, project(Mark2p), project(Center))
        g.DrawLine(pen2, project(Mark3p), project(Center))
        pen1.Width = 0
        g.DrawLine(pen1, project(Mark1p), project(Mark2p))
        g.DrawLine(pen1, project(Mark2p), project(Mark3p))
        g.DrawLine(pen1, project(Mark3p), project(Mark1p))

        pen1.Width = 0
        pen1.EndCap = LineCap.Triangle
        g.DrawLine(pen1, project(Mark1), project(Mark1p))
        g.DrawLine(pen1, project(Mark2), project(Mark2p))
        g.DrawLine(pen1, project(Mark3), project(Mark3p))
        g.FillEllipse(brush1, project(Mark1).X - 3, project(Mark1).Y - 3, 6, 6)
        g.FillEllipse(brush1, project(Mark2).X - 3, project(Mark2).Y - 3, 6, 6)
        g.FillEllipse(brush1, project(Mark3).X - 3, project(Mark3).Y - 3, 6, 6)
        pen1.Color = gCIgrn
        g.DrawEllipse(pen1, project(Mark1p).X - 6, project(Mark1p).Y - 6, 12, 12)
        pen1.Color = gCIyel
        g.DrawEllipse(pen1, project(Mark2p).X - 6, project(Mark2p).Y - 6, 12, 12)
        pen1.Color = gCIred
        g.DrawEllipse(pen1, project(Mark3p).X - 6, project(Mark3p).Y - 6, 12, 12)
        'g.FillEllipse(brush1, project(Mark1p).X - 3, project(Mark1p).Y - 3, 6, 6)

        '---------------------------------------
        pen1.Dispose()
        pen2.Dispose()
        pen3.Dispose()
        pen4.Dispose()
        pen5.Dispose()
        brush1.Dispose()
        brush2.Dispose()
        brush3.Dispose()
    End Sub

    Private Sub pbTL_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles pbTL.Paint
        Dim g As Graphics = e.Graphics
        g.SmoothingMode = SmoothingMode.AntiAlias
        g.TextRenderingHint = Drawing.Text.TextRenderingHint.AntiAlias
        Dim pen1 As Pen = New Pen(sColor(0), 0)
        Dim pen2 As Pen = New Pen(sColor(1), 0)
        Dim pen3 As Pen = New Pen(sColor(2), 0)
        Dim pen4 As Pen = New Pen(sColor(3), 0)
        Dim pen5 As Pen = New Pen(sColor(4), 0)
        Dim brush1 As Brush = New SolidBrush(sColor(0))
        Dim brush2 As Brush = New SolidBrush(sColor(1))
        Dim brush3 As Brush = New SolidBrush(sColor(2))
        '---------------------------------------
        g.DrawRectangle(pen2, 1, 1, 125, 125)
        g.DrawRectangle(pen1, 0, 0, 127, 127)
        g.DrawRectangle(pen3, 6, 6, 115, 115)
        '---------------------------------------
        Dim gFont As Font = New Font("Lucida Console", 8)
        Dim mar = 114 / 6
        Dim stepx As Integer = 8
        Dim stepy As Integer = 12
        For x As Integer = 7 To 121 Step mar
            g.DrawLine(pen3, 7, x, 121, x)
        Next
        For y As Integer = 7 To 121 Step mar
            g.DrawLine(pen3, y, 7, y, 121)
        Next
        For x = 0 To 5
            For y = 0 To 5
                If _S(x, y) <= 10 Then
                    brush1 = New SolidBrush(gCIgrn)
                End If
                If _S(x, y) >= 11 And _S(x, y) <= 20 Then
                    brush1 = New SolidBrush(gCIblu)
                End If
                If _S(x, y) >= 21 And _S(x, y) <= 30 Then
                    brush1 = New SolidBrush(gCIyel)
                End If
                If _S(x, y) >= 31 Then
                    brush1 = New SolidBrush(gCIred)
                End If
                g.DrawString(_S(x, y).ToString, gFont, brush1, stepx, stepy)
                stepy += mar
            Next
            stepy = 12
            stepx += mar
        Next
        '---------------------------------------

        '---------------------------------------
        pen1.Dispose()
        pen2.Dispose()
        pen3.Dispose()
        pen4.Dispose()
        pen5.Dispose()
        brush1.Dispose()
        brush2.Dispose()
        brush3.Dispose()
    End Sub

    Private Sub btnClose_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles btnClose.Paint
        Dim g As Graphics = e.Graphics
        g.SmoothingMode = SmoothingMode.AntiAlias
        g.TextRenderingHint = Drawing.Text.TextRenderingHint.AntiAlias
        Dim pen1 As Pen = New Pen(sColor(0), 2)
        pen1.SetLineCap(LineCap.Round, LineCap.Round, DashCap.Round)
        Dim pen2 As Pen = New Pen(sColor(1), 0)
        Dim pen3 As Pen = New Pen(sColor(2), 0)
        Dim pen4 As Pen = New Pen(sColor(3), 0)
        Dim pen5 As Pen = New Pen(sColor(4), 0)
        '---------------------------------------
        g.DrawLine(pen1, 4, 4, btnClose.Width - 5, btnClose.Height - 5)
        g.DrawLine(pen1, btnClose.Width - 5, 4, 4, btnClose.Height - 5)
        '---------------------------------------
        pen1.Dispose()
        pen2.Dispose()
        pen3.Dispose()
        pen4.Dispose()
        pen5.Dispose()
    End Sub

    Private Sub btnMinBox_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles btnMinBox.Paint
        Dim g As Graphics = e.Graphics
        g.SmoothingMode = SmoothingMode.AntiAlias
        g.TextRenderingHint = Drawing.Text.TextRenderingHint.AntiAlias
        Dim pen1 As Pen = New Pen(sColor(0), 2)
        pen1.SetLineCap(LineCap.Round, LineCap.Round, DashCap.Round)
        Dim pen2 As Pen = New Pen(sColor(1), 0)
        Dim pen3 As Pen = New Pen(sColor(2), 0)
        Dim pen4 As Pen = New Pen(sColor(3), 0)
        Dim pen5 As Pen = New Pen(sColor(4), 0)
        '---------------------------------------
        g.DrawLine(pen1, 4, btnClose.Height - 5, btnClose.Width - 5, btnClose.Height - 5)
        '---------------------------------------
        pen1.Dispose()
        pen2.Dispose()
        pen3.Dispose()
        pen4.Dispose()
        pen5.Dispose()
    End Sub

    Private Sub btnStyle_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles btnStyle.Paint
        Dim g As Graphics = e.Graphics
        g.SmoothingMode = SmoothingMode.AntiAlias
        g.TextRenderingHint = Drawing.Text.TextRenderingHint.AntiAlias
        Dim pen1 As Pen = New Pen(sColor(0), 2)
        pen1.SetLineCap(LineCap.Round, LineCap.Round, DashCap.Round)
        Dim pen2 As Pen = New Pen(sColor(1), 0)
        Dim pen3 As Pen = New Pen(sColor(2), 0)
        Dim pen4 As Pen = New Pen(sColor(3), 0)
        Dim pen5 As Pen = New Pen(sColor(4), 0)
        Dim brush4 As Brush = New SolidBrush(sColor(1))
        '---------------------------------------
        'g.DrawLine(pen1, 4, btnClose.Height - 5, btnClose.Width - 5, btnClose.Height - 5)
        g.DrawString("¢", New Font("Webdings", 10), brush4, 0, 2)
        '---------------------------------------
        pen1.Dispose()
        pen2.Dispose()
        pen3.Dispose()
        pen4.Dispose()
        pen5.Dispose()
        brush4.Dispose()
    End Sub

    Private Sub tbMainDisplay_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbMainDisplay.TextChanged
        'tbMainDisplay.ScrollToCaret()
    End Sub
End Class
