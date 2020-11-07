Imports System.Linq.Expressions
Imports System.IO
'Imports System.Windows.
Public Class Form1

    Private Enum V
        wall
        space
        heater
    End Enum

    Dim ii As Integer = 0

    Dim T(10 + 1, 10 + 1) As Double
    Dim C(10 + 1, 10 + 1) As Double

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Const w As Integer = 10
        Const h As Integer = 10

        Const t_wall As Double = 25
        Const t_space As Double = 30
        Const t_heater As Double = 100

        Const c_wall As Double = 200
        Const c_space As Double = 1
        Const c_heater As Double = 200

        Dim dt_max As Double


        Dim Type_V(,) As Integer = {{V.wall, V.heater, V.wall, V.wall, V.wall, V.heater, V.heater, V.wall, V.wall, V.wall, V.heater, V.wall},
            {V.wall, V.space, V.space, V.space, V.space, V.space, V.space, V.space, V.space, V.space, V.space, V.wall},
            {V.wall, V.space, V.space, V.space, V.space, V.space, V.space, V.space, V.space, V.space, V.space, V.wall},
            {V.wall, V.space, V.space, V.space, V.space, V.space, V.space, V.space, V.space, V.space, V.space, V.wall},
            {V.heater, V.space, V.space, V.space, V.space, V.space, V.space, V.space, V.space, V.space, V.space, V.heater},
            {V.heater, V.space, V.space, V.space, V.space, V.space, V.space, V.space, V.space, V.space, V.space, V.heater},
            {V.heater, V.space, V.space, V.space, V.space, V.space, V.space, V.space, V.space, V.space, V.space, V.heater},
            {V.heater, V.space, V.space, V.space, V.space, V.space, V.space, V.space, V.space, V.space, V.space, V.heater},
            {V.wall, V.space, V.space, V.space, V.space, V.space, V.space, V.space, V.space, V.space, V.space, V.wall},
            {V.wall, V.space, V.space, V.space, V.space, V.space, V.space, V.space, V.space, V.space, V.space, V.wall},
            {V.wall, V.space, V.space, V.space, V.space, V.space, V.space, V.space, V.space, V.space, V.space, V.wall},
            {V.wall, V.heater, V.wall, V.wall, V.wall, V.heater, V.heater, V.wall, V.wall, V.wall, V.heater, V.wall}}

        Dim T(w + 1, h + 1) As Double
        Dim C(w + 1, h + 1) As Double

        For i As Integer = 0 To w + 1
            For j As Integer = 0 To h + 1
                Select Case Type_V(i, j)
                    Case V.wall
                        T(i, j) = t_wall
                        C(i, j) = c_wall
                    Case V.space
                        T(i, j) = t_space
                        C(i, j) = c_space
                    Case V.heater
                        T(i, j) = t_heater
                        C(i, j) = c_heater
                End Select
            Next
        Next

        Dim it As Integer = 0
        Do
            it += 1

            dt_max = 0

            Dim new_t As Double = 0
            Dim dt As Double
            Dim Tt(w, h) As Double

            For i As Integer = 1 To w
                For j As Integer = 1 To h

                    new_t = 0

                    For k As Integer = i - 1 To i + 1 Step 2
                        new_t = new_t + (T(k, j) - T(i, j)) * 0.25 / C(k, j) + T(i, j) * 0.25
                    Next

                    For k As Integer = j - 1 To j + 1 Step 2
                        new_t = new_t + (T(i, k) - T(i, j)) * 0.25 / C(i, k) + T(i, j) * 0.25
                    Next

                    dt = Math.Abs(T(i, j) - new_t)

                    If dt > dt_max Then dt_max = dt

                    Tt(i - 1, j - 1) = new_t

                Next
            Next

            For i As Integer = 1 To w
                For j As Integer = 1 To h
                    T(i, j) = Tt(i - 1, j - 1)
                Next
            Next

            'PictureBox1.Image = CreatePicture(T)

        Loop While it < 30

        'Loop While dt_max > 0.0001

        Dim Write As New StreamWriter("Rez.txt")

        For i As Integer = 0 To w + 1
            For j As Integer = 0 To h + 1
                Write.Write("{0};", T(i, j))
            Next
            Write.WriteLine()
        Next

        Write.Close()

        Me.Text = it
        PictureBox1.Image = CreatePicture(T)

    End Sub


    Function CreatePicture(ByVal T(,) As Double) As Bitmap

        Dim Image As New Bitmap(800, 800)
        Dim Screen As Graphics = Graphics.FromImage(Image)

        Dim w As Integer = T.GetLength(0) - 1
        Dim h As Integer = T.GetLength(1) - 1

        Dim WR As Integer = 800 / (w - 1)
        Dim HR As Integer = 800 / (h - 1)

        Dim R, G, B As Integer

        Dim t_min As Double = T(1, 1)
        Dim t_max As Double = T(1, 1)
        Dim t_aver As Double
        Dim t_int As Double

        Dim kolor As Color
        Dim Color1 As Color = Color.Yellow
        Dim color2 As Color = Color.Red

        'For i As Integer = 1 To w - 1
        '    For j As Integer = 1 To h - 1
        '        T(i, j) = i + (j - 1) * 10
        '    Next
        'Next
        'Dim M() As Integer
        'Dim n As Integer = 0

        For i As Integer = 1 To w - 1
            For j As Integer = 1 To h - 1
                If t_min > T(i, j) Then t_min = T(i, j)
                If t_max < T(i, j) Then t_max = T(i, j)
            Next
        Next

        t_aver = t_max * 0.5 + t_min * 0.5
        t_int = t_max - t_min

        'Dim x As Integer = 0

        For i As Integer = 1 To w - 1
            For j As Integer = 1 To h - 1

                Dim tt As Double = T(i, j)

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

                kolor = Color1 - color2

                Dim brush = New Drawing.SolidBrush(Color.FromArgb(R, G, B))
                Screen.FillRectangle(brush, (i - 1) * WR, (j - 1) * HR, WR, HR)

                'Screen.DrawImage(Image, (i - 1) * WR, (j - 1) * HR, WR, HR)
            Next
        Next

        Dim z As Int16 = 0
        Return Image
    End Function

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

        Static first As Boolean = True

        Const w As Integer = 10
        Const h As Integer = 10

        Const t_wall As Double = 25
        Const t_space As Double = 30
        Const t_heater As Double = 100

        Const c_wall As Double = 200
        Const c_space As Double = 1
        Const c_heater As Double = 200

        Dim dt_max As Double

        Dim Type_V(,) As Integer = {{V.wall, V.heater, V.wall, V.wall, V.wall, V.heater, V.heater, V.wall, V.wall, V.wall, V.heater, V.wall},
    {V.wall, V.space, V.space, V.space, V.space, V.space, V.space, V.space, V.space, V.space, V.space, V.wall},
    {V.wall, V.space, V.space, V.space, V.space, V.space, V.space, V.space, V.space, V.space, V.space, V.wall},
    {V.wall, V.space, V.space, V.space, V.space, V.space, V.space, V.space, V.space, V.space, V.space, V.wall},
    {V.heater, V.space, V.space, V.space, V.space, V.space, V.space, V.space, V.space, V.space, V.space, V.heater},
    {V.heater, V.space, V.space, V.space, V.space, V.space, V.space, V.space, V.space, V.space, V.space, V.heater},
    {V.heater, V.space, V.space, V.space, V.space, V.space, V.space, V.space, V.space, V.space, V.space, V.heater},
    {V.heater, V.space, V.space, V.space, V.space, V.space, V.space, V.space, V.space, V.space, V.space, V.heater},
    {V.wall, V.space, V.space, V.space, V.space, V.space, V.space, V.space, V.space, V.space, V.space, V.wall},
    {V.wall, V.space, V.space, V.space, V.space, V.space, V.space, V.space, V.space, V.space, V.space, V.wall},
    {V.wall, V.space, V.space, V.space, V.space, V.space, V.space, V.space, V.space, V.space, V.space, V.wall},
    {V.wall, V.heater, V.wall, V.wall, V.wall, V.heater, V.heater, V.wall, V.wall, V.wall, V.heater, V.wall}}



        If first Then
            For i As Integer = 0 To w + 1
                For j As Integer = 0 To h + 1
                    Select Case Type_V(i, j)
                        Case V.wall
                            T(i, j) = t_wall
                            C(i, j) = c_wall
                        Case V.space
                            T(i, j) = t_space
                            C(i, j) = c_space
                        Case V.heater
                            T(i, j) = t_heater
                            C(i, j) = c_heater
                    End Select
                Next
            Next
            first = False
        End If


        CalculationT(T, C)
        PictureBox1.Image = CreatePicture(T)

        ii += 1
        Me.Text = ii

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Timer1.Enabled = Not Timer1.Enabled
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
    Private w, h As Integer
    Private DTMax As Double

    Sub New(ByVal Weidght As Integer, ByVal Height As Integer)

        w = Weidght
        h = Height

        ReDim T(w - 1, h - 1)
        ReDim C(w - 1, h - 1)
        ReDim Type_V(w - 1, h - 1)

    End Sub

    Public WriteOnly Property Type_S As Integer(,)
        Set(value As Integer(,))

            For i As Integer = 0 To w - 1
                For j As Integer = 0 To h - 1
                    Type_V(i, j) = value(i, j)
                Next
            Next

        End Set
    End Property

    Public WriteOnly Property T_wall As Integer
        Set(value As Integer)

            For i As Integer = 0 To w - 1
                For j As Integer = 0 To h - 1
                    If Type_V(i, j) = V.Wall Then T(i, j) = value
                Next
            Next

        End Set
    End Property

    Public WriteOnly Property T_Heater As Integer
        Set(value As Integer)

            For i As Integer = 0 To w - 1
                For j As Integer = 0 To h - 1
                    If Type_V(i, j) = V.Heater Then T(i, j) = value
                Next
            Next

        End Set
    End Property

    Public WriteOnly Property T_Space As Integer
        Set(value As Integer)

            For i As Integer = 0 To w - 1
                For j As Integer = 0 To h - 1
                    If Type_V(i, j) = V.Space Then T(i, j) = value
                Next
            Next

        End Set
    End Property

    Public WriteOnly Property C_Wall As Integer
        Set(value As Integer)

            For i As Integer = 0 To w - 1
                For j As Integer = 0 To h - 1
                    If Type_V(i, j) = V.Wall Then C(i, j) = value
                Next
            Next

        End Set
    End Property

    Public WriteOnly Property C_Heater As Integer
        Set(value As Integer)

            For i As Integer = 0 To w - 1
                For j As Integer = 0 To h - 1
                    If Type_V(i, j) = V.Heater Then C(i, j) = value
                Next
            Next

        End Set
    End Property

    Public WriteOnly Property C_Space As Integer
        Set(value As Integer)

            For i As Integer = 0 To w - 1
                For j As Integer = 0 To h - 1
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

            For i As Integer = 0 To w - 1
                For j As Integer = 0 To h - 1
                    If Type_V(i, j) = V.Space Then
                        tt += T(i, j)
                        n += 1
                    End If
                Next
            Next

            Return tt / n
        End Get
    End Property

    Sub CalculationT(ByRef T(,) As Double)

        Dim new_t As Double = 0
        Dim Tt(w, h) As Double
        Dim dt As Double = 0

        For i As Integer = 1 To w
            For j As Integer = 1 To h

                new_t = 0

                For k As Integer = i - 1 To i + 1 Step 2
                    new_t = new_t + (T(k, j) - T(i, j)) * 0.25 / C(k, j) + T(i, j) * 0.25
                Next

                For k As Integer = j - 1 To j + 1 Step 2
                    new_t = new_t + (T(i, k) - T(i, j)) * 0.25 / C(i, k) + T(i, j) * 0.25
                Next

                Tt(i - 1, j - 1) = new_t

                dt = Math.Abs(T(i, j) - new_t)

                If dt > DTMax Then DTMax = dt
            Next
        Next

        For i As Integer = 1 To w
            For j As Integer = 1 To h
                T(i, j) = Tt(i - 1, j - 1)
            Next
        Next

    End Sub

End Class
