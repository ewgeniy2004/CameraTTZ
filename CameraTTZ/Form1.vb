Imports System.Linq.Expressions
Imports System.IO
Imports System.Globalization
Imports System.Configuration

'Imports System.Windows.
Public Class Form1

    Dim w As Integer = 12
    Dim h As Integer = 12

    Dim TTZ As New Camera(w - 1, h - 1)

    Dim t_heater, t_wall, t_space As Double
    Dim t_heater_max As Double = 300
    Dim t_heater_min As Double = -300
    Dim dt_heater_max As Double
    Dim SetItem As Camera.V
    Dim Type_V(,) As Integer
    Dim WR As Integer
    Dim HR As Integer
    Dim pid As New PID_CL
    Dim first_tik As Boolean = True
    Dim it As Integer = 0

    Dim At As New List(Of Double)

    Dim stpr As Boolean = False

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick




        Dim dt_heater As Double

        If first_tik Then

            it = 0
            first_tik = False

        End If

        it += 1

        TTZ.CalculationT()

        If Int(it / 10) = it / 10 Then
            PictureBox1.Image = TTZ.CreatePictureSkin
            PictureBox1.Image = TTZ.CreatePicture()
        End If


        dt_heater = pid.Calculation(TTZ.Average_T, TTZ.Set_T)

        If Math.Abs(dt_heater) > dt_heater_max And dt_heater_max > 0 Then dt_heater = dt_heater_max * Math.Abs(dt_heater) / dt_heater
        t_heater += dt_heater

        If t_heater > t_heater_max Then t_heater = t_heater_max
        If t_heater < t_heater_min Then t_heater = t_heater_min

        TTZ.T_Heater = t_heater



        Chart1.Series("Temperature").Points.AddXY(it, TTZ.Average_T)
        Chart3.Series("THeater").Points.AddXY(it, t_heater)

        At.Add(TTZ.Average_T)
        If it > 300 Then At.RemoveAt(0)

        If it > 300 And Int(it / 2) = it / 2 Then
            Chart1.Series("Temperature").Points.RemoveAt(0)
            Chart1.Series("Temperature").Points.RemoveAt(0)

            Chart3.Series("THeater").Points.RemoveAt(0)
            Chart3.Series("THeater").Points.RemoveAt(0)

            'Chart2.Series("P").Points.RemoveAt(0)
            'Chart2.Series("P").Points.RemoveAt(0)

            'Chart2.Series("I").Points.RemoveAt(0)
            'Chart2.Series("I").Points.RemoveAt(0)

        End If

        Me.Text = "it = " & it & " dT_Max = " & TTZ.Delta_T_Max.ToString("0.0 E-00") & " T_Grad = " & TTZ.Grad_t.ToString("0.00") & " A = " & (At.Max - At.Min).ToString("0.00")

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Timer1.Enabled = Not Timer1.Enabled
    End Sub

    Private Sub PictureBox2_MouseClick(sender As Object, e As MouseEventArgs) Handles PictureBox2.MouseClick
        Dim w, h As Integer

        w = Int(e.X / WR)
        h = Int(e.Y / HR)

        If (w = 0 Or h = 0) And SetItem = Camera.V.Space Then
            MsgBox("it can only be a Wall or a Heater")
        Else
            Type_V(w, h) = SetItem
            Initial()
            Write_to_file(Type_V)
        End If



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

    Private Sub T_Wall_Set_ValueChanged(sender As Object, e As EventArgs) Handles T_Wall_Set.ValueChanged
        t_wall = T_Wall_Set.Value
        'initial()
    End Sub

    Private Sub T_Heater_Set_ValueChanged(sender As Object, e As EventArgs) Handles T_Heater_Set.ValueChanged
        t_heater = T_Heater_Set.Value
        'initial()
    End Sub

    Private Sub T_Space_Set_ValueChanged(sender As Object, e As EventArgs) Handles T_Space_Set.ValueChanged
        t_space = T_Space_Set.Value
        'initial()
    End Sub

    Private Sub Kd_Set_ValueChanged(sender As Object, e As EventArgs) Handles Kd_Set.ValueChanged
        pid.Set_Kd = Kd_Set.Value
        If stpr Then Write_to_file(Type_V)
    End Sub

    Private Sub T_Set_ValueChanged(sender As Object, e As EventArgs) Handles T_Set.ValueChanged
        TTZ.Set_T = T_Set.Value
    End Sub

    Private Sub Kp_Set_ValueChanged(sender As Object, e As EventArgs) Handles Kp_Set.ValueChanged
        pid.Set_Kp = Kp_Set.Value
        If stpr Then Write_to_file(Type_V)
    End Sub

    Private Sub Ki_Set_ValueChanged(sender As Object, e As EventArgs) Handles Ki_Set.ValueChanged
        pid.Set_Ki = Ki_Set.Value
        If stpr Then Write_to_file(Type_V)
    End Sub

    Private Sub Max_dt_Heater_ValueChanged(sender As Object, e As EventArgs) Handles Max_dt_Heater.ValueChanged
        dt_heater_max = Max_dt_Heater.Value
        If stpr Then Write_to_file(Type_V)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If Timer1.Enabled Then
            Timer1.Stop()
            Default_Set()
            Initial()
            first_tik = True
            Timer1.Start()
        Else
            Default_Set()
            Initial()
            first_tik = True
        End If

        Chart1.Series("Temperature").Points.Clear()
        Chart3.Series("THeater").Points.Clear()


        PictureBox1.Image = TTZ.CreatePictureSkin
        PictureBox1.Image = TTZ.CreatePicture()

        At.Clear()

    End Sub

    Private Sub Default_Set()

        t_wall = T_Wall_Set.Value
        t_space = T_Space_Set.Value
        t_heater = T_Heater_Set.Value

    End Sub

    Sub Initial()


        TTZ.Type_S = Type_V

        TTZ.T_wall = t_wall
        TTZ.T_Space = t_space
        TTZ.T_Heater = t_heater

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

        If Not File.Exists("options.txt") Then

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

            Write_to_file(Type_V)

        Else

            Read_to_file(Type_V)

        End If





        Default_Set()

        Initial()


        WR = 792 / w
        HR = 792 / h

        stpr = True

    End Sub

    Sub Write_to_file(ByRef Type_V(,) As Integer)

        Dim Write As New StreamWriter("options.txt")

        Write.WriteLine(w)
        Write.WriteLine(h)

        Write.WriteLine(Kp_Set.Value)
        Write.WriteLine(Ki_Set.Value)
        Write.WriteLine(Kd_Set.Value)
        Write.WriteLine(Max_dt_Heater.Value)

        For i As Integer = 0 To w - 1
            For j As Integer = 0 To h - 1
                Write.WriteLine(Type_V(i, j))
            Next
        Next

        Write.Close()
    End Sub

    Sub Read_to_file(ByRef Type_V(,) As Integer)

        Dim Read As New StreamReader("options.txt")

        w = Read.ReadLine
        h = Read.ReadLine

        Kp_Set.Value = Read.ReadLine
        Ki_Set.Value = Read.ReadLine
        Kd_Set.Value = Read.ReadLine
        Max_dt_Heater.Value = Read.ReadLine

        ReDim Type_V(w - 1, h - 1)

        For i As Integer = 0 To w - 1
            For j As Integer = 0 To h - 1
                Type_V(i, j) = Read.ReadLine()
            Next
        Next

        Read.Close()
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
    Dim T_Set, T_Grad As Double

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

    Public Property Set_T As Double
        Set(value As Double)
            T_Set = value
        End Set
        Get
            Return T_Set
        End Get
    End Property

    Public ReadOnly Property Grad_t As Double
        Get
            Return T_Grad
        End Get
    End Property

    Sub CalculationT()

        Dim new_t As Double
        Dim Tt(w, h) As Double
        Dim dt As Double
        Dim t_max, t_min As Double
        Dim f As Boolean = True

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
                If Type_V(i, j) = V.Space Then
                    T(i, j) = Tt(i, j)
                    If f Then
                        t_max = T(i, j)
                        t_min = T(i, j)
                        f = False
                    End If
                    If t_max < T(i, j) Then t_max = T(i, j)
                    If t_min > T(i, j) Then t_min = T(i, j)
                End If
            Next
        Next

        T_Grad = t_max - t_min

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

Public Class PID_CL
    Private P, I, D As Double
    Private e As Double
    Private Kp, Ki, Kd As Double

    Public Property Set_Kp As Double
        Set(value As Double)
            Kp = value
        End Set
        Get
            Return Kp
        End Get
    End Property

    Public Property Set_Ki As Double
        Set(value As Double)
            Ki = value
        End Set
        Get
            Return Ki
        End Get
    End Property

    Public Property Set_Kd As Double
        Set(value As Double)
            Kd = value
        End Set
        Get
            Return Kd
        End Get
    End Property

    Public ReadOnly Property Get_P As Double
        Get
            Return P
        End Get
    End Property

    Public ReadOnly Property Get_I As Double
        Get
            Return I
        End Get
    End Property

    Public ReadOnly Property Get_D As Double
        Get
            Return D
        End Get
    End Property

    Function Calculation(ByVal t As Double, ByVal set_t As Double) As Double
        P = set_t - t
        e = P
        D = P - e
        I += P
        Return P * Kp + I * Ki + D * Kd
    End Function
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