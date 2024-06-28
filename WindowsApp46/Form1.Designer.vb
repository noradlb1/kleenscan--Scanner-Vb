<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.btnBrowse = New System.Windows.Forms.Button()
        Me.btnScan = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtResult = New System.Windows.Forms.TextBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'btnBrowse
        '
        Me.btnBrowse.Location = New System.Drawing.Point(25, 216)
        Me.btnBrowse.Name = "btnBrowse"
        Me.btnBrowse.Size = New System.Drawing.Size(75, 23)
        Me.btnBrowse.TabIndex = 0
        Me.btnBrowse.Text = "btnBrowse"
        Me.btnBrowse.UseVisualStyleBackColor = True
        '
        'btnScan
        '
        Me.btnScan.Location = New System.Drawing.Point(246, 216)
        Me.btnScan.Name = "btnScan"
        Me.btnScan.Size = New System.Drawing.Size(75, 23)
        Me.btnScan.TabIndex = 1
        Me.btnScan.Text = "btnScan"
        Me.btnScan.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(22, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(39, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Label1"
        '
        'txtResult
        '
        Me.txtResult.Location = New System.Drawing.Point(25, 39)
        Me.txtResult.Multiline = True
        Me.txtResult.Name = "txtResult"
        Me.txtResult.Size = New System.Drawing.Size(296, 119)
        Me.txtResult.TabIndex = 3
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(25, 187)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(296, 20)
        Me.TextBox1.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(22, 169)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(39, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Label2"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(349, 244)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.txtResult)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnScan)
        Me.Controls.Add(Me.btnBrowse)
        Me.Name = "Form1"
        Me.Text = "kleenscan.com"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnBrowse As Button
    Friend WithEvents btnScan As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents txtResult As TextBox
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Label2 As Label
End Class
