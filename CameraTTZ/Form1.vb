Imports System.Linq.Expressions
Imports System.IO
Imports System.Globalization
Imports System.Configuration

'Imports System.Windows.
Public Class Form1

    Const w As Integer = 12
    Const h As Integer = 12
    Dim TTZ As New Camera(w - 1, h - 1)
    Dim it As Integer = 0
    Dim sw As New Stopwatch
    Dim SetT As Double
    Dim t_heater As Double
    Dim t_heater_max As Double = 200
    Dim t_heater_min As Double = -200
    Dim P, I, D As Double
    Dim SetItem As Camera.V
    Dim Type_V(,) As Integer
    Dim WR As Integer
    Dim HR As Integer

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        initial()

        Dim it As Integer = 0

        Do
            it += 1

            TTZ.CalculationT()
            'PictureBox1.Image = TTZ.CreatePicture()

        Loop While it < 1000

        'Loop While TTZ.Delta_T_Max > 0.0001

        'TTZ.Write("Rez.txt")

        Me.Text = it
        PictureBox1.Image = TTZ.CreatePictureSkin
        PictureBox1.Image = TTZ.CreatePicture()

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

        Static first As Boolean = True
        Dim err As Double


        If first Then

            it = 0
            'sw.Start()

            SetT = 100
            t_heater = 25


            TTZ.T_Heater = t_heater


            first = False

        End If

        it += 1

        TTZ.CalculationT()
        PictureBox1.Image = TTZ.CreatePictureSkin
        PictureBox1.Image = TTZ.CreatePicture()


        err = SetT - TTZ.Average_T

        Dim dt_heater As Double

        dt_heater = pid(it, err, TTZ.Delta_T_Max)
        'If dt_heater > 10 Then dt_heater = 10

        t_heater += dt_heater

        If t_heater > t_heater_max Then t_heater = t_heater_max
        If t_heater < t_heater_min Then t_heater = t_heater_min

        TTZ.T_Heater = t_heater



        Chart1.Series("Temperature").Points.AddXY(it, TTZ.Average_T)
        Chart1.Series("THeater").Points.AddXY(it, t_heater)

        If it > 100 And Int(it / 2) = it / 2 Then
            Chart1.Series("Temperature").Points.RemoveAt(0)
            Chart1.Series("Temperature").Points.RemoveAt(0)

            Chart1.Series("THeater").Points.RemoveAt(0)
            Chart1.Series("THeater").Points.RemoveAt(0)

            Chart2.Series("P").Points.RemoveAt(0)
            Chart2.Series("P").Points.RemoveAt(0)

            Chart2.Series("I").Points.RemoveAt(0)
            Chart2.Series("I").Points.RemoveAt(0)

        End If

        Me.Text = "it = " & it & " dT_Max = " & TTZ.Delta_T_Max

        'If it = 1000 Then
        '    sw.Stop()
        '    MsgBox(1000 * 1000 / sw.ElapsedMilliseconds)
        'End If

        'Chart1.

    End Sub

    Function pid(it As Integer, Err As Double, dt As Double)
        Dim kp As Double = 1
        Dim ki As Double = 0

        P = Err
        I += Err * dt

        Chart2.Series("P").Points.AddXY(it, P * kp)
        Chart2.Series("I").Points.AddXY(it, I * ki)

        Return P * kp + I * ki
    End Function

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Timer1.Enabled = Not Timer1.Enabled
    End Sub

    Private Sub PictureBox2_MouseClick(sender As Object, e As MouseEventArgs) Handles PictureBox2.MouseClick
        Dim w, h As Integer

        w = Int(e.X / WR)
        h = Int(e.Y / HR)

        Type_V(w, h) = SetItem

        initial()

    End Sub

    Private Sub Wall_CheckedChanged(sender As Object, e As EventArgs) Handles Wall.CheckedChanged
        SetItem = Camera.V.Wall
    End Sub

    Private Sub Space_CheckedChanged(sender As Object, e As EventArgs) Handles Space.CheckedChanged
        SetItem = Camera.V.Space
    End Sub

    Private Sub Heater_CheckedChanged(sender As Object, e As EventArgs) Handles Heater.CheckedChanged
        SetItem = Camera.V.Heater
    End Sub

    Sub initial()


        TTZ.Type_S = Type_V

        TTZ.T_wall = 25
        TTZ.T_Space = 30
        TTZ.T_Heater = 100

        TTZ.C_Wall = 2000
        TTZ.C_Space = 5
        TTZ.C_Heater = 10


        PictureBox2.Image = TTZ.CreatePictureSkin
        PictureBox2.Image = TTZ.CreatePicture


    End Sub

    Sub New()

        ' Этот вызов является обязательным для конструктора.
        InitializeComponent()

        ' Добавить код инициализации после вызова InitializeComponent().


        Type_V = {{Camera.V.Wall, Camera.V.Heater, Camera.V.Wall, Camera.V.Wall, Camera.V.Wall, Camera.V.Heater, Camera.V.Heater, Camera.V.Wall, Camera.V.Wall, Camera.V.Wall, Camera.V.Heater, Camera.V.Wall},
            {Camera.V.Wall, Camera.V.Space, Camera.V.Space, Camera.V.Space, Camera.V.Space, Camera.V.Space, Camera.V.Space, Camera.V.Space, Camera.V.Space, Camera.V.Space, Camera.V.Space, Camera.V.Wall},
            {Camera.V.Wall, Camera.V.Space, Camera.V.Space, Camera.V.Space, Camera.V.Space, Camera.V.Space, Camera.V.Space, Camera.V.Space, Camera.V.Space, Camera.V.Space, Camera.V.Space, Camera.V.Wall},
            {Camera.V.Wall, Camera.V.Space, Camera.V.Space, Camera.V.Space, Camera.V.Space, Camera.V.Space, Camera.V.Space, Camera.V.Space, Camera.V.Space, Camera.V.Space, Camera.V.Space, Camera.V.Wall},
            {Camera.V.Heater, Camera.V.Space, Camera.V.Space, Camera.V.Space, Camera.V.Space, Camera.V.Space, Camera.V.Space, Camera.V.Space, Camera.V.Space, Camera.V.Space, Camera.V.Space, Camera.V.Heater},
            {Camera.V.Heater, Camera.V.Space, Camera.V.Space, Camera.V.Space, Camera.V.Space, Camera.V.Space, Camera.V.Space, Camera.V.Space, Camera.V.Space, Camera.V.Space, Camera.V.Space, Camera.V.Heater},
            {Camera.V.Heater, Camera.V.Space, Camera.V.Space, Camera.V.Space, Camera.V.Space, Camera.V.Space, Camera.V.Space, Camera.V.Space, Camera.V.Space, Camera.V.Space, Camera.V.Space, Camera.V.Heater},
            {Camera.V.Heater, Camera.V.Space, Camera.V.Space, Camera.V.Space, Camera.V.Space, Camera.V.Space, Camera.V.Space, Camera.V.Space, Camera.V.Space, Camera.V.Space, Camera.V.Space, Camera.V.Heater},
            {Camera.V.Wall, Camera.V.Space, Camera.V.Space, Camera.V.Space, Camera.V.Space, Camera.V.Space, Camera.V.Space, Camera.V.Space, Camera.V.Space, Camera.V.Space, Camera.V.Space, Camera.V.Wall},
            {Camera.V.Wall, Camera.V.Space, Camera.V.Space, Camera.V.Space, Camera.V.Space, Camera.V.Space, Camera.V.Space, Camera.V.Space, Camera.V.Space, Camera.V.Space, Camera.V.Space, Camera.V.Wall},
            {Camera.V.Wall, Camera.V.Space, Camera.V.Space, Camera.V.Space, Camera.V.Space, Camera.V.Space, Camera.V.Space, Camera.V.Space, Camera.V.Space, Camera.V.Space, Camera.V.Space, Camera.V.Wall},
            {Camera.V.Wall, Camera.V.Heater, Camera.V.Wall, Camera.V.Wall, Camera.V.Wall, Camera.V.Heater, Camera.V.Heater, Camera.V.Wall, Camera.V.Wall, Camera.V.Wall, Camera.V.Heater, Camera.V.Wall}}

        For i As Integer = 0 To w - 1
            For j As Integer = i To h - 1
                Dim k As Double = Type_V(i, j)
                Type_V(i, j) = Type_V(j, i)
                Type_V(j, i) = k
            Next
        Next


        initial()


        WR = 792 / w
        HR = 792 / h
    End Sub


End Class

Public Class Camera

    Public Enum V
        Wall
        Space
        Heater
    End Enum

    Private T(,) As Double
    Private C(,) As Double
    Private Type_V(,) As Integer
    Private ReadOnly w, h As Integer
    Private DTMax As Double
    Dim Image As New Bitmap(792, 792)
    Dim Screen As Graphics = Graphics.FromImage(Image)
    Dim WR As Integer
    Dim HR As Integer

    Sub New(ByVal Weidght As Integer, ByVal Height As Integer)

        w = Weidght
        h = Height

        ReDim T(w, h)
        ReDim C(w, h)
        ReDim Type_V(w, h)

        WR = 792 / (w + 1)
        HR = 792 / (h + 1)


    End Sub

    Public WriteOnly Property Type_S As Integer(,)
        Set(value As Integer(,))

            For i As Integer = 0 To w
                For j As Integer = 0 To h
                    Type_V(i, j) = value(i, j)
                Next
            Next

        End Set
    End Property

    Public WriteOnly Property T_wall As Integer
        Set(value As Integer)

            For i As Integer = 0 To w
                For j As Integer = 0 To h
                    If Type_V(i, j) = V.Wall Then T(i, j) = value
                Next
            Next

        End Set
    End Property

    Public WriteOnly Property T_Heater As Integer
        Set(value As Integer)

            For i As Integer = 0 To w
                For j As Integer = 0 To h
                    If Type_V(i, j) = V.Heater Then T(i, j) = value
                Next
            Next

        End Set
    End Property

    Public WriteOnly Property T_Space As Integer
        Set(value As Integer)

            For i As Integer = 0 To w
                For j As Integer = 0 To h
                    If Type_V(i, j) = V.Space Then T(i, j) = value
                Next
            Next

        End Set
    End Property

    Public WriteOnly Property C_Wall As Integer
        Set(value As Integer)

            For i As Integer = 0 To w
                For j As Integer = 0 To h
                    If Type_V(i, j) = V.Wall Then C(i, j) = value
                Next
            Next

        End Set
    End Property

    Public WriteOnly Property C_Heater As Integer
        Set(value As Integer)

            For i As Integer = 0 To w
                For j As Integer = 0 To h
                    If Type_V(i, j) = V.Heater Then C(i, j) = value
                Next
            Next

        End Set
    End Property

    Public WriteOnly Property C_Space As Integer
        Set(value As Integer)

            For i As Integer = 0 To w
                For j As Integer = 0 To h
                    If Type_V(i, j) = V.Space Then C(i, j) = value
                Next
            Next

        End Set
    End Property

    Public ReadOnly Property Delta_T_Max As Double
        Get
            Return DTMax
        End Get
    End Property

    Public ReadOnly Property Average_T As Double
        Get
            Dim n As Integer = 0
            Dim tt As Integer = 0

            For i As Integer = 0 To w
                For j As Integer = 0 To h
                    If Type_V(i, j) = V.Space Then
                        tt += T(i, j)
                        n += 1
                    End If
                Next
            Next

            Return tt / n
        End Get
    End Property

    Public ReadOnly Property GetT(w As Integer, h As Integer) As Double
        Get
            Return T(w, h)
        End Get
    End Property

    Sub CalculationT()

        Dim new_t As Double = 0
        Dim Tt(w, h) As Double
        Dim dt As Double = 0

        DTMax = 0

        For i As Integer = 0 To w
            For j As Integer = 0 To w
                If Type_V(i, j) = V.Space Then

                    new_t = 0

                    For k As Integer = i - 1 To i + 1 Step 2
                        new_t = new_t + (T(k, j) - T(i, j)) * 0.25 / C(k, j) + T(i, j) * 0.25
                    Next

                    For k As Integer = j - 1 To j + 1 Step 2
                        new_t = new_t + (T(i, k) - T(i, j)) * 0.25 / C(i, k) + T(i, j) * 0.25
                    Next

                    Tt(i, j) = new_t

                    dt = Math.Abs(T(i, j) - new_t)

                    If dt > DTMax Then DTMax = dt

                End If
            Next
        Next

        For i As Integer = 0 To w
            For j As Integer = 0 To h
                If Type_V(i, j) = V.Space Then T(i, j) = Tt(i, j)
            Next
        Next

    End Sub

    Function CreatePicture() As Bitmap

        Dim t_min As Double = T(1, 1)
        Dim t_max As Double = T(1, 1)

        Dim DrawFont = New Font("Arial", 16)
        Dim BrushFont = New Drawing.SolidBrush(Color.Black)

        For i As Integer = 1 To w - 1
            For j As Integer = 1 To h - 1
                If t_min > T(i, j) Then t_min = T(i, j)
                If t_max < T(i, j) Then t_max = T(i, j)
            Next
        Next

        For i As Integer = 1 To w - 1
            For j As Integer = 1 To h - 1

                Dim brush = New Drawing.SolidBrush(GetColor(T(i, j), t_min, t_max))
                Screen.FillRectangle(BrushFont, (i) * WR, (j) * HR, WR, HR)
                Screen.FillRectangle(brush, (i) * WR + 1, (j) * HR + 1, WR - 2, HR - 2)

                Dim ts As Double = Int(T(i, j) * 10) / 10
                Screen.DrawString(ts, DrawFont, BrushFont, (i) * WR + WR * 0.1, (j) * HR + HR * 0.25)

            Next
        Next

        Return Image
    End Function

    Function CreatePictureSkin()

        Dim t_min As Double = T(0, 0)
        Dim t_max As Double = T(0, 0)

        Dim DrawFont = New Font("Arial", 16)
        Dim BrushFont = New Drawing.SolidBrush(Color.Black)

        For i As Integer = 0 To w
            For j As Integer = 0 To h Step h
                If t_min > T(i, j) Then t_min = T(i, j)
                If t_max < T(i, j) Then t_max = T(i, j)
            Next
        Next

        For i As Integer = 0 To w Step w
            For j As Integer = 0 To h
                If t_min > T(i, j) Then t_min = T(i, j)
                If t_max < T(i, j) Then t_max = T(i, j)
            Next
        Next

        For i As Integer = 0 To w
            For j As Integer = 0 To h Step h
                Dim brush = New Drawing.SolidBrush(GetColor(T(i, j), t_min, t_max))
                Screen.FillRectangle(BrushFont, (i) * WR, (j) * HR, WR, HR)
                Screen.FillRectangle(brush, (i) * WR + 1, (j) * HR + 1, WR - 2, HR - 2)
                Dim ts As Double = Int(T(i, j) * 10) / 10
                Screen.DrawString(ts, DrawFont, BrushFont, (i) * WR + WR * 0.1, (j) * HR + HR * 0.25)
            Next
        Next

        For i As Integer = 0 To w Step w
            For j As Integer = 0 To h
                Dim brush = New Drawing.SolidBrush(GetColor(T(i, j), t_min, t_max))
                Screen.FillRectangle(BrushFont, (i) * WR, (j) * HR, WR, HR)
                Screen.FillRectangle(brush, (i) * WR + 1, (j) * HR + 1, WR - 2, HR - 2)
                Dim ts As Double = Int(T(i, j) * 10) / 10
                Screen.DrawString(ts, DrawFont, BrushFont, (i) * WR + WR * 0.1, (j) * HR + HR * 0.25)
            Next
        Next

        Return Image
    End Function

    Function GetColor(t As Double, t_min As Double, t_max As Double) As Color

        Dim R, G, B As Integer

        If t_min = t_max Then t_max += 0.00001

        Dim pct As Double = 1 - (t - t_min) / (t_max - t_min)

        Dim Color1 As Color = Color.Yellow
        Dim color2 As Color = Color.Red

        If pct < 0.34 Then
            R = (128 + (127 * Math.Min(3 * pct, 1)))
            G = 0
            B = 0
        ElseIf pct < 0.67 Then
            R = 255
            G = (255 * Math.Min(3 * (pct - 0.333333), 1))
            B = 0
        Else
            R = (255 * Math.Min(3 * (1 - pct), 1))
            G = 255
            B = 0
        End If

        Return Color.FromArgb(R, G, B)
    End Function

    Sub Write(Path As String)
        Dim Write As New StreamWriter(Path)

        For i As Integer = 0 To w
            For j As Integer = 0 To h
                If j < h + 1 Then
                    Write.Write("{0};", T(i, j))
                Else
                    Write.WriteLine("{0}", T(i, j))
                End If
            Next
        Next

        Write.Close()
    End Sub

End Class


'For i As Integer = 1 To w - 1
'    For j As Integer = 1 To h - 1
'        T(i, j) = i + (j - 1) * 10
'    Next
'Next
'Dim M() As Integer
'Dim n As Integer = 0

'R = tt * 255 / (t_min - t_max) + (255 - t_min * 255 / (t_min - t_max))
'G = tt * 255 / (t_max - t_min) + (255 - t_max * 255 / (t_max - t_min))

'If tt > t_aver Then
'    B = tt * 255 / (t_aver - t_max) + (255 - t_aver * 255 / (t_aver - t_max))
'Else
'    B = tt * 255 / (t_aver - t_min) + (255 - t_aver * 255 / (t_aver - t_min))
'End If

'R = NumericUpDown1.Value
'G = 255.0 * (tt - t_min) / (t_max - t_min)
'B = G
'B = -(G - 255)


'Dim val As Double = (tt - t_min) / (t_max - t_min)

'R = 255 * val
'G = 255 * (1 - val)
'B = 0