<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class GUI
    Inherits System.Windows.Forms.Form

    'Form remplace la méthode Dispose pour nettoyer la liste des composants.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requise par le Concepteur Windows Form
    Private components As System.ComponentModel.IContainer

    'REMARQUE : la procédure suivante est requise par le Concepteur Windows Form
    'Elle peut être modifiée à l'aide du Concepteur Windows Form.  
    'Ne la modifiez pas à l'aide de l'éditeur de code.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(GUI))
        Me.ScanBtn = New System.Windows.Forms.Button()
        Me.FilesList = New System.Windows.Forms.ComboBox()
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.Title = New System.Windows.Forms.Label()
        Me.CloseBtn = New System.Windows.Forms.PictureBox()
        Me.Output = New System.Windows.Forms.TextBox()
        CType(Me.CloseBtn, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ScanBtn
        '
        Me.ScanBtn.BackColor = System.Drawing.Color.MediumSlateBlue
        Me.ScanBtn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ScanBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ScanBtn.ForeColor = System.Drawing.Color.White
        Me.ScanBtn.Location = New System.Drawing.Point(265, 70)
        Me.ScanBtn.Name = "ScanBtn"
        Me.ScanBtn.Size = New System.Drawing.Size(99, 30)
        Me.ScanBtn.TabIndex = 0
        Me.ScanBtn.Text = "Scan Files"
        Me.ScanBtn.UseVisualStyleBackColor = False
        '
        'FilesList
        '
        Me.FilesList.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.FilesList.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.FilesList.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FilesList.FormattingEnabled = True
        Me.FilesList.ItemHeight = 18
        Me.FilesList.Location = New System.Drawing.Point(15, 70)
        Me.FilesList.Name = "FilesList"
        Me.FilesList.Size = New System.Drawing.Size(210, 26)
        Me.FilesList.TabIndex = 2
        '
        'BackgroundWorker1
        '
        Me.BackgroundWorker1.WorkerSupportsCancellation = True
        '
        'Title
        '
        Me.Title.AutoSize = True
        Me.Title.Font = New System.Drawing.Font("Segoe UI Symbol", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Title.ForeColor = System.Drawing.Color.DimGray
        Me.Title.Location = New System.Drawing.Point(15, 12)
        Me.Title.Name = "Title"
        Me.Title.Size = New System.Drawing.Size(162, 30)
        Me.Title.TabIndex = 5
        Me.Title.Text = "Alarme VB.Net"
        '
        'CloseBtn
        '
        Me.CloseBtn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CloseBtn.Image = Global.AlarmeExcel.My.Resources.Resources.close_
        Me.CloseBtn.Location = New System.Drawing.Point(329, 10)
        Me.CloseBtn.Name = "CloseBtn"
        Me.CloseBtn.Size = New System.Drawing.Size(35, 35)
        Me.CloseBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.CloseBtn.TabIndex = 4
        Me.CloseBtn.TabStop = False
        '
        'Output
        '
        Me.Output.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Output.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Output.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Output.Location = New System.Drawing.Point(15, 106)
        Me.Output.Multiline = True
        Me.Output.Name = "Output"
        Me.Output.ReadOnly = True
        Me.Output.Size = New System.Drawing.Size(349, 90)
        Me.Output.TabIndex = 6
        '
        'GUI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ClientSize = New System.Drawing.Size(376, 208)
        Me.Controls.Add(Me.Output)
        Me.Controls.Add(Me.Title)
        Me.Controls.Add(Me.CloseBtn)
        Me.Controls.Add(Me.FilesList)
        Me.Controls.Add(Me.ScanBtn)
        Me.Cursor = System.Windows.Forms.Cursors.SizeAll
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "GUI"
        Me.Text = "GUI"
        CType(Me.CloseBtn, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ScanBtn As System.Windows.Forms.Button
    Friend WithEvents FilesList As System.Windows.Forms.ComboBox
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents CloseBtn As System.Windows.Forms.PictureBox
    Friend WithEvents Title As System.Windows.Forms.Label
    Friend WithEvents Output As System.Windows.Forms.TextBox
End Class
