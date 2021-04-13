<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class form_codes
    Inherits System.Windows.Forms.Form

    'Form remplace la méthode Dispose pour nettoyer la liste des composants.
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

    'Requise par le Concepteur Windows Form
    Private components As System.ComponentModel.IContainer

    'REMARQUE : la procédure suivante est requise par le Concepteur Windows Form
    'Elle peut être modifiée à l'aide du Concepteur Windows Form.  
    'Ne la modifiez pas à l'aide de l'éditeur de code.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.lbl_code1 = New System.Windows.Forms.Label()
        Me.lbl_code1b = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lbl_code1
        '
        Me.lbl_code1.AutoSize = True
        Me.lbl_code1.Location = New System.Drawing.Point(8, 28)
        Me.lbl_code1.Name = "lbl_code1"
        Me.lbl_code1.Size = New System.Drawing.Size(37, 13)
        Me.lbl_code1.TabIndex = 0
        Me.lbl_code1.Text = "Presté"
        '
        'lbl_code1b
        '
        Me.lbl_code1b.AutoSize = True
        Me.lbl_code1b.Location = New System.Drawing.Point(52, 27)
        Me.lbl_code1b.Name = "lbl_code1b"
        Me.lbl_code1b.Size = New System.Drawing.Size(14, 13)
        Me.lbl_code1b.TabIndex = 1
        Me.lbl_code1b.Text = "P"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.lbl_code1b)
        Me.GroupBox1.Controls.Add(Me.lbl_code1)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(218, 235)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Codes de prestations assimilées"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(8, 48)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(30, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Férie"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(52, 48)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(13, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "F"
        '
        'form_codes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "form_codes"
        Me.Text = "Liste des codes"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents lbl_code1 As Label
    Friend WithEvents lbl_code1b As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
End Class
