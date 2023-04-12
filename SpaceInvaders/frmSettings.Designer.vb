<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSettings
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnGo = New System.Windows.Forms.Button()
        Me.txtBombRate = New System.Windows.Forms.NumericUpDown()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtBombSpeed = New System.Windows.Forms.NumericUpDown()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtInvaderSpeed = New System.Windows.Forms.NumericUpDown()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtPlayerSpeed = New System.Windows.Forms.NumericUpDown()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtReloads = New System.Windows.Forms.NumericUpDown()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtBulletSpeed = New System.Windows.Forms.NumericUpDown()
        CType(Me.txtBombRate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtBombSpeed, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtInvaderSpeed, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPlayerSpeed, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtReloads, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtBulletSpeed, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(148, 39)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(111, 45)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Press SPACE to fire" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Use arrows to move" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Press R to reload"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.Label2.Location = New System.Drawing.Point(138, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(135, 30)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "How To Play"
        '
        'btnGo
        '
        Me.btnGo.Location = New System.Drawing.Point(169, 270)
        Me.btnGo.Name = "btnGo"
        Me.btnGo.Size = New System.Drawing.Size(75, 23)
        Me.btnGo.TabIndex = 2
        Me.btnGo.Text = "Go"
        Me.btnGo.UseVisualStyleBackColor = True
        '
        'txtBombRate
        '
        Me.txtBombRate.Location = New System.Drawing.Point(291, 94)
        Me.txtBombRate.Maximum = New Decimal(New Integer() {1661992960, 1808227885, 5, 0})
        Me.txtBombRate.Minimum = New Decimal(New Integer() {50, 0, 0, 0})
        Me.txtBombRate.Name = "txtBombRate"
        Me.txtBombRate.Size = New System.Drawing.Size(120, 23)
        Me.txtBombRate.TabIndex = 3
        Me.txtBombRate.Value = New Decimal(New Integer() {100, 0, 0, 0})
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(202, 96)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(71, 15)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Bomb Rate: "
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(202, 125)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(80, 15)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Bomb Speed: "
        '
        'txtBombSpeed
        '
        Me.txtBombSpeed.Location = New System.Drawing.Point(291, 123)
        Me.txtBombSpeed.Maximum = New Decimal(New Integer() {1661992960, 1808227885, 5, 0})
        Me.txtBombSpeed.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.txtBombSpeed.Name = "txtBombSpeed"
        Me.txtBombSpeed.Size = New System.Drawing.Size(120, 23)
        Me.txtBombSpeed.TabIndex = 5
        Me.txtBombSpeed.Value = New Decimal(New Integer() {10, 0, 0, 0})
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(202, 154)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(87, 15)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Invader Speed: "
        '
        'txtInvaderSpeed
        '
        Me.txtInvaderSpeed.Location = New System.Drawing.Point(291, 152)
        Me.txtInvaderSpeed.Maximum = New Decimal(New Integer() {1661992960, 1808227885, 5, 0})
        Me.txtInvaderSpeed.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.txtInvaderSpeed.Name = "txtInvaderSpeed"
        Me.txtInvaderSpeed.Size = New System.Drawing.Size(120, 23)
        Me.txtInvaderSpeed.TabIndex = 7
        Me.txtInvaderSpeed.Value = New Decimal(New Integer() {5, 0, 0, 0})
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(202, 183)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(80, 15)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "Player Speed: "
        '
        'txtPlayerSpeed
        '
        Me.txtPlayerSpeed.Location = New System.Drawing.Point(291, 181)
        Me.txtPlayerSpeed.Maximum = New Decimal(New Integer() {1661992960, 1808227885, 5, 0})
        Me.txtPlayerSpeed.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.txtPlayerSpeed.Name = "txtPlayerSpeed"
        Me.txtPlayerSpeed.Size = New System.Drawing.Size(120, 23)
        Me.txtPlayerSpeed.TabIndex = 9
        Me.txtPlayerSpeed.Value = New Decimal(New Integer() {6, 0, 0, 0})
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(202, 241)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(54, 15)
        Me.Label7.TabIndex = 12
        Me.Label7.Text = "Reloads: "
        '
        'txtReloads
        '
        Me.txtReloads.Location = New System.Drawing.Point(291, 239)
        Me.txtReloads.Maximum = New Decimal(New Integer() {1661992960, 1808227885, 5, 0})
        Me.txtReloads.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.txtReloads.Name = "txtReloads"
        Me.txtReloads.Size = New System.Drawing.Size(120, 23)
        Me.txtReloads.TabIndex = 11
        Me.txtReloads.Value = New Decimal(New Integer() {3, 0, 0, 0})
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Enabled = False
        Me.Label8.Location = New System.Drawing.Point(202, 212)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(78, 15)
        Me.Label8.TabIndex = 14
        Me.Label8.Text = "Bullet Speed: "
        '
        'txtBulletSpeed
        '
        Me.txtBulletSpeed.Enabled = False
        Me.txtBulletSpeed.Location = New System.Drawing.Point(291, 210)
        Me.txtBulletSpeed.Maximum = New Decimal(New Integer() {1661992960, 1808227885, 5, 0})
        Me.txtBulletSpeed.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.txtBulletSpeed.Name = "txtBulletSpeed"
        Me.txtBulletSpeed.Size = New System.Drawing.Size(120, 23)
        Me.txtBulletSpeed.TabIndex = 13
        Me.txtBulletSpeed.Value = New Decimal(New Integer() {6, 0, 0, 0})
        '
        'frmSettings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(423, 302)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txtBulletSpeed)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtReloads)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtPlayerSpeed)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtInvaderSpeed)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtBombSpeed)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtBombRate)
        Me.Controls.Add(Me.btnGo)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSettings"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Space Invaders"
        CType(Me.txtBombRate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtBombSpeed, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtInvaderSpeed, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPlayerSpeed, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtReloads, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtBulletSpeed, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents btnGo As Button
    Friend WithEvents txtBombRate As NumericUpDown
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents txtBombSpeed As NumericUpDown
    Friend WithEvents Label5 As Label
    Friend WithEvents txtInvaderSpeed As NumericUpDown
    Friend WithEvents Label6 As Label
    Friend WithEvents txtPlayerSpeed As NumericUpDown
    Friend WithEvents Label7 As Label
    Friend WithEvents txtReloads As NumericUpDown
    Friend WithEvents Label8 As Label
    Friend WithEvents txtBulletSpeed As NumericUpDown
End Class
