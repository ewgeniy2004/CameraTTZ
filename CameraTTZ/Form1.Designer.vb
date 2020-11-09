<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Форма переопределяет dispose для очистки списка компонентов.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Является обязательной для конструктора форм Windows Forms
    Private components As System.ComponentModel.IContainer

    'Примечание: следующая процедура является обязательной для конструктора форм Windows Forms
    'Для ее изменения используйте конструктор форм Windows Form.  
    'Не изменяйте ее в редакторе исходного кода.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim ChartArea1 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend1 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series1 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim ChartArea2 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend2 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series2 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim ChartArea3 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend3 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series3 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim Series4 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Button2 = New System.Windows.Forms.Button()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Max_dt_Heater = New System.Windows.Forms.NumericUpDown()
        Me.Chart3 = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.T_Set = New System.Windows.Forms.NumericUpDown()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Kd_Set = New System.Windows.Forms.NumericUpDown()
        Me.Ki_Set = New System.Windows.Forms.NumericUpDown()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Kp_Set = New System.Windows.Forms.NumericUpDown()
        Me.Chart1 = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.T_Heater_Set = New System.Windows.Forms.NumericUpDown()
        Me.T_Space_Set = New System.Windows.Forms.NumericUpDown()
        Me.T_Wall_Set = New System.Windows.Forms.NumericUpDown()
        Me.Heater = New System.Windows.Forms.RadioButton()
        Me.Space = New System.Windows.Forms.RadioButton()
        Me.Wall = New System.Windows.Forms.RadioButton()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.Chart2 = New System.Windows.Forms.DataVisualization.Charting.Chart()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.Max_dt_Heater, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Chart3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.T_Set, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Kd_Set, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Ki_Set, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Kp_Set, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        CType(Me.T_Heater_Set, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.T_Space_Set, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.T_Wall_Set, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage3.SuspendLayout()
        CType(Me.Chart2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PictureBox1
        '
        Me.PictureBox1.Location = New System.Drawing.Point(6, 6)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(800, 800)
        Me.PictureBox1.TabIndex = 1
        Me.PictureBox1.TabStop = False
        '
        'Timer1
        '
        Me.Timer1.Interval = 1
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(1211, 6)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 49)
        Me.Button2.TabIndex = 3
        Me.Button2.Text = "Старт / Стоп"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Location = New System.Drawing.Point(12, 12)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1297, 850)
        Me.TabControl1.TabIndex = 6
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.Label5)
        Me.TabPage1.Controls.Add(Me.Max_dt_Heater)
        Me.TabPage1.Controls.Add(Me.Chart3)
        Me.TabPage1.Controls.Add(Me.Button1)
        Me.TabPage1.Controls.Add(Me.T_Set)
        Me.TabPage1.Controls.Add(Me.Label4)
        Me.TabPage1.Controls.Add(Me.Label3)
        Me.TabPage1.Controls.Add(Me.Label2)
        Me.TabPage1.Controls.Add(Me.Kd_Set)
        Me.TabPage1.Controls.Add(Me.Ki_Set)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Controls.Add(Me.Kp_Set)
        Me.TabPage1.Controls.Add(Me.Chart1)
        Me.TabPage1.Controls.Add(Me.PictureBox1)
        Me.TabPage1.Controls.Add(Me.Button2)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(1289, 824)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "TabPage1"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(995, 10)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(72, 13)
        Me.Label5.TabIndex = 20
        Me.Label5.Text = "Max dt heater"
        '
        'Max_dt_Heater
        '
        Me.Max_dt_Heater.Location = New System.Drawing.Point(1073, 8)
        Me.Max_dt_Heater.Maximum = New Decimal(New Integer() {600, 0, 0, 0})
        Me.Max_dt_Heater.Name = "Max_dt_Heater"
        Me.Max_dt_Heater.Size = New System.Drawing.Size(120, 20)
        Me.Max_dt_Heater.TabIndex = 19
        Me.Max_dt_Heater.Value = New Decimal(New Integer() {10, 0, 0, 0})
        '
        'Chart3
        '
        ChartArea1.Name = "ChartArea1"
        Me.Chart3.ChartAreas.Add(ChartArea1)
        Legend1.Name = "Legend1"
        Me.Chart3.Legends.Add(Legend1)
        Me.Chart3.Location = New System.Drawing.Point(822, 459)
        Me.Chart3.Name = "Chart3"
        Series1.ChartArea = "ChartArea1"
        Series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline
        Series1.Legend = "Legend1"
        Series1.Name = "THeater"
        Me.Chart3.Series.Add(Series1)
        Me.Chart3.Size = New System.Drawing.Size(461, 347)
        Me.Chart3.TabIndex = 18
        Me.Chart3.Text = "Chart3"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(1211, 58)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 49)
        Me.Button1.TabIndex = 17
        Me.Button1.Text = "Заново"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'T_Set
        '
        Me.T_Set.DecimalPlaces = 1
        Me.T_Set.Location = New System.Drawing.Point(849, 84)
        Me.T_Set.Maximum = New Decimal(New Integer() {200, 0, 0, 0})
        Me.T_Set.Minimum = New Decimal(New Integer() {200, 0, 0, -2147483648})
        Me.T_Set.Name = "T_Set"
        Me.T_Set.Size = New System.Drawing.Size(120, 20)
        Me.T_Set.TabIndex = 16
        Me.T_Set.Value = New Decimal(New Integer() {100, 0, 0, 0})
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(823, 86)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(16, 13)
        Me.Label4.TabIndex = 15
        Me.Label4.Text = "tз"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(823, 34)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(16, 13)
        Me.Label3.TabIndex = 14
        Me.Label3.Text = "Ki"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(823, 60)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(20, 13)
        Me.Label2.TabIndex = 13
        Me.Label2.Text = "Kd"
        '
        'Kd_Set
        '
        Me.Kd_Set.DecimalPlaces = 1
        Me.Kd_Set.Location = New System.Drawing.Point(849, 58)
        Me.Kd_Set.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.Kd_Set.Minimum = New Decimal(New Integer() {1000, 0, 0, -2147483648})
        Me.Kd_Set.Name = "Kd_Set"
        Me.Kd_Set.Size = New System.Drawing.Size(120, 20)
        Me.Kd_Set.TabIndex = 12
        '
        'Ki_Set
        '
        Me.Ki_Set.DecimalPlaces = 1
        Me.Ki_Set.Location = New System.Drawing.Point(849, 32)
        Me.Ki_Set.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.Ki_Set.Minimum = New Decimal(New Integer() {1000, 0, 0, -2147483648})
        Me.Ki_Set.Name = "Ki_Set"
        Me.Ki_Set.Size = New System.Drawing.Size(120, 20)
        Me.Ki_Set.TabIndex = 11
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(823, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(20, 13)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "Kp"
        '
        'Kp_Set
        '
        Me.Kp_Set.DecimalPlaces = 1
        Me.Kp_Set.Location = New System.Drawing.Point(849, 6)
        Me.Kp_Set.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.Kp_Set.Minimum = New Decimal(New Integer() {1000, 0, 0, -2147483648})
        Me.Kp_Set.Name = "Kp_Set"
        Me.Kp_Set.Size = New System.Drawing.Size(120, 20)
        Me.Kp_Set.TabIndex = 9
        '
        'Chart1
        '
        ChartArea2.Name = "ChartArea1"
        Me.Chart1.ChartAreas.Add(ChartArea2)
        Legend2.Name = "Legend1"
        Me.Chart1.Legends.Add(Legend2)
        Me.Chart1.Location = New System.Drawing.Point(822, 110)
        Me.Chart1.Name = "Chart1"
        Series2.ChartArea = "ChartArea1"
        Series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline
        Series2.Legend = "Legend1"
        Series2.MarkerBorderWidth = 10
        Series2.Name = "Temperature"
        Me.Chart1.Series.Add(Series2)
        Me.Chart1.Size = New System.Drawing.Size(461, 343)
        Me.Chart1.TabIndex = 8
        Me.Chart1.Text = "Chart1"
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.T_Heater_Set)
        Me.TabPage2.Controls.Add(Me.T_Space_Set)
        Me.TabPage2.Controls.Add(Me.T_Wall_Set)
        Me.TabPage2.Controls.Add(Me.Heater)
        Me.TabPage2.Controls.Add(Me.Space)
        Me.TabPage2.Controls.Add(Me.Wall)
        Me.TabPage2.Controls.Add(Me.PictureBox2)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(1289, 824)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "TabPage2"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'T_Heater_Set
        '
        Me.T_Heater_Set.Location = New System.Drawing.Point(920, 94)
        Me.T_Heater_Set.Maximum = New Decimal(New Integer() {200, 0, 0, 0})
        Me.T_Heater_Set.Minimum = New Decimal(New Integer() {200, 0, 0, -2147483648})
        Me.T_Heater_Set.Name = "T_Heater_Set"
        Me.T_Heater_Set.Size = New System.Drawing.Size(120, 20)
        Me.T_Heater_Set.TabIndex = 6
        Me.T_Heater_Set.Value = New Decimal(New Integer() {100, 0, 0, 0})
        '
        'T_Space_Set
        '
        Me.T_Space_Set.Location = New System.Drawing.Point(920, 70)
        Me.T_Space_Set.Maximum = New Decimal(New Integer() {200, 0, 0, 0})
        Me.T_Space_Set.Minimum = New Decimal(New Integer() {200, 0, 0, -2147483648})
        Me.T_Space_Set.Name = "T_Space_Set"
        Me.T_Space_Set.Size = New System.Drawing.Size(120, 20)
        Me.T_Space_Set.TabIndex = 6
        Me.T_Space_Set.Value = New Decimal(New Integer() {30, 0, 0, 0})
        '
        'T_Wall_Set
        '
        Me.T_Wall_Set.Location = New System.Drawing.Point(920, 46)
        Me.T_Wall_Set.Maximum = New Decimal(New Integer() {200, 0, 0, 0})
        Me.T_Wall_Set.Minimum = New Decimal(New Integer() {200, 0, 0, -2147483648})
        Me.T_Wall_Set.Name = "T_Wall_Set"
        Me.T_Wall_Set.Size = New System.Drawing.Size(120, 20)
        Me.T_Wall_Set.TabIndex = 6
        Me.T_Wall_Set.Value = New Decimal(New Integer() {25, 0, 0, 0})
        '
        'Heater
        '
        Me.Heater.AutoSize = True
        Me.Heater.Location = New System.Drawing.Point(839, 94)
        Me.Heater.Name = "Heater"
        Me.Heater.Size = New System.Drawing.Size(57, 17)
        Me.Heater.TabIndex = 5
        Me.Heater.Text = "Heater"
        Me.Heater.UseVisualStyleBackColor = True
        '
        'Space
        '
        Me.Space.AutoSize = True
        Me.Space.Location = New System.Drawing.Point(839, 70)
        Me.Space.Name = "Space"
        Me.Space.Size = New System.Drawing.Size(56, 17)
        Me.Space.TabIndex = 4
        Me.Space.Text = "Space"
        Me.Space.UseVisualStyleBackColor = True
        '
        'Wall
        '
        Me.Wall.AutoSize = True
        Me.Wall.Checked = True
        Me.Wall.Location = New System.Drawing.Point(839, 46)
        Me.Wall.Name = "Wall"
        Me.Wall.Size = New System.Drawing.Size(46, 17)
        Me.Wall.TabIndex = 3
        Me.Wall.TabStop = True
        Me.Wall.Text = "Wall"
        Me.Wall.UseVisualStyleBackColor = True
        '
        'PictureBox2
        '
        Me.PictureBox2.Location = New System.Drawing.Point(6, 3)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(800, 800)
        Me.PictureBox2.TabIndex = 2
        Me.PictureBox2.TabStop = False
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.Chart2)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(1289, 824)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "TabPage3"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'Chart2
        '
        ChartArea3.Name = "ChartArea1"
        Me.Chart2.ChartAreas.Add(ChartArea3)
        Legend3.Name = "Legend1"
        Me.Chart2.Legends.Add(Legend3)
        Me.Chart2.Location = New System.Drawing.Point(414, 231)
        Me.Chart2.Name = "Chart2"
        Series3.ChartArea = "ChartArea1"
        Series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline
        Series3.Legend = "Legend1"
        Series3.Name = "P"
        Series4.ChartArea = "ChartArea1"
        Series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline
        Series4.Legend = "Legend1"
        Series4.Name = "I"
        Me.Chart2.Series.Add(Series3)
        Me.Chart2.Series.Add(Series4)
        Me.Chart2.Size = New System.Drawing.Size(461, 362)
        Me.Chart2.TabIndex = 6
        Me.Chart2.Text = "Chart2"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1321, 874)
        Me.Controls.Add(Me.TabControl1)
        Me.Name = "Form1"
        Me.Text = "Form1"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        CType(Me.Max_dt_Heater, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Chart3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.T_Set, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Kd_Set, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Ki_Set, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Kp_Set, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        CType(Me.T_Heater_Set, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.T_Space_Set, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.T_Wall_Set, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage3.ResumeLayout(False)
        CType(Me.Chart2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Timer1 As Timer
    Friend WithEvents Button2 As Button
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents Space As RadioButton
    Friend WithEvents Wall As RadioButton
    Friend WithEvents Heater As RadioButton
    Friend WithEvents T_Wall_Set As NumericUpDown
    Friend WithEvents T_Heater_Set As NumericUpDown
    Friend WithEvents T_Space_Set As NumericUpDown
    Friend WithEvents Chart1 As DataVisualization.Charting.Chart
    Friend WithEvents Kp_Set As NumericUpDown
    Friend WithEvents TabPage3 As TabPage
    Friend WithEvents Chart2 As DataVisualization.Charting.Chart
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Kd_Set As NumericUpDown
    Friend WithEvents Ki_Set As NumericUpDown
    Friend WithEvents Label1 As Label
    Friend WithEvents T_Set As NumericUpDown
    Friend WithEvents Label4 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents Chart3 As DataVisualization.Charting.Chart
    Friend WithEvents Label5 As Label
    Friend WithEvents Max_dt_Heater As NumericUpDown
End Class
