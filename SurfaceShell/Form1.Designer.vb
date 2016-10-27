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
        Me.components = New System.ComponentModel.Container()
        Me.SecondTimer = New System.Windows.Forms.Timer(Me.components)
        Me.ClockTime = New System.Windows.Forms.Label()
        Me.ClockDate = New System.Windows.Forms.Label()
        Me.PickLauncher = New System.Windows.Forms.Button()
        Me.PrepackLauncher = New System.Windows.Forms.Button()
        Me.GPUpdateButton = New System.Windows.Forms.Button()
        Me.TabletName = New System.Windows.Forms.Label()
        Me.ShutDownButton = New System.Windows.Forms.Button()
        Me.BatteryLife = New System.Windows.Forms.Label()
        Me.PCName = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'SecondTimer
        '
        Me.SecondTimer.Enabled = True
        Me.SecondTimer.Interval = 5000
        '
        'ClockTime
        '
        Me.ClockTime.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ClockTime.BackColor = System.Drawing.Color.Transparent
        Me.ClockTime.Font = New System.Drawing.Font("Segoe UI Light", 72.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ClockTime.ForeColor = System.Drawing.Color.White
        Me.ClockTime.Location = New System.Drawing.Point(620, 587)
        Me.ClockTime.Name = "ClockTime"
        Me.ClockTime.Size = New System.Drawing.Size(677, 158)
        Me.ClockTime.TabIndex = 0
        Me.ClockTime.Text = "00:00:00"
        Me.ClockTime.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'ClockDate
        '
        Me.ClockDate.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ClockDate.BackColor = System.Drawing.Color.Transparent
        Me.ClockDate.Font = New System.Drawing.Font("Segoe UI Light", 36.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ClockDate.ForeColor = System.Drawing.Color.White
        Me.ClockDate.Location = New System.Drawing.Point(559, 728)
        Me.ClockDate.Name = "ClockDate"
        Me.ClockDate.Size = New System.Drawing.Size(721, 71)
        Me.ClockDate.TabIndex = 1
        Me.ClockDate.Text = "Wednesday 29 December"
        Me.ClockDate.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'PickLauncher
        '
        Me.PickLauncher.BackColor = System.Drawing.Color.DimGray
        Me.PickLauncher.FlatAppearance.BorderColor = System.Drawing.Color.Gray
        Me.PickLauncher.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.PickLauncher.Font = New System.Drawing.Font("Segoe UI Light", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PickLauncher.ForeColor = System.Drawing.Color.White
        Me.PickLauncher.Location = New System.Drawing.Point(12, 12)
        Me.PickLauncher.Name = "PickLauncher"
        Me.PickLauncher.Size = New System.Drawing.Size(240, 100)
        Me.PickLauncher.TabIndex = 2
        Me.PickLauncher.Text = "Warehouse Application"
        Me.PickLauncher.UseVisualStyleBackColor = False
        '
        'PrepackLauncher
        '
        Me.PrepackLauncher.BackColor = System.Drawing.Color.DimGray
        Me.PrepackLauncher.FlatAppearance.BorderColor = System.Drawing.Color.Gray
        Me.PrepackLauncher.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.PrepackLauncher.Font = New System.Drawing.Font("Segoe UI Light", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PrepackLauncher.ForeColor = System.Drawing.Color.White
        Me.PrepackLauncher.Location = New System.Drawing.Point(12, 129)
        Me.PrepackLauncher.Name = "PrepackLauncher"
        Me.PrepackLauncher.Size = New System.Drawing.Size(240, 100)
        Me.PrepackLauncher.TabIndex = 3
        Me.PrepackLauncher.Text = "Prepack"
        Me.PrepackLauncher.UseVisualStyleBackColor = False
        '
        'GPUpdateButton
        '
        Me.GPUpdateButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GPUpdateButton.BackColor = System.Drawing.Color.DimGray
        Me.GPUpdateButton.FlatAppearance.BorderColor = System.Drawing.Color.Gray
        Me.GPUpdateButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.GPUpdateButton.Font = New System.Drawing.Font("Segoe UI Light", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GPUpdateButton.ForeColor = System.Drawing.Color.White
        Me.GPUpdateButton.Location = New System.Drawing.Point(1028, 12)
        Me.GPUpdateButton.Name = "GPUpdateButton"
        Me.GPUpdateButton.Size = New System.Drawing.Size(240, 100)
        Me.GPUpdateButton.TabIndex = 4
        Me.GPUpdateButton.Text = "Update Policy"
        Me.GPUpdateButton.UseVisualStyleBackColor = False
        '
        'TabletName
        '
        Me.TabletName.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TabletName.BackColor = System.Drawing.Color.Transparent
        Me.TabletName.Font = New System.Drawing.Font("Segoe UI Light", 36.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabletName.ForeColor = System.Drawing.Color.White
        Me.TabletName.Location = New System.Drawing.Point(12, 728)
        Me.TabletName.Name = "TabletName"
        Me.TabletName.Size = New System.Drawing.Size(352, 71)
        Me.TabletName.TabIndex = 5
        Me.TabletName.Text = "SURFACE-1"
        Me.TabletName.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'ShutDownButton
        '
        Me.ShutDownButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ShutDownButton.BackColor = System.Drawing.Color.DimGray
        Me.ShutDownButton.FlatAppearance.BorderColor = System.Drawing.Color.Gray
        Me.ShutDownButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ShutDownButton.Font = New System.Drawing.Font("Segoe UI Light", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ShutDownButton.ForeColor = System.Drawing.Color.White
        Me.ShutDownButton.Location = New System.Drawing.Point(1028, 129)
        Me.ShutDownButton.Name = "ShutDownButton"
        Me.ShutDownButton.Size = New System.Drawing.Size(240, 100)
        Me.ShutDownButton.TabIndex = 6
        Me.ShutDownButton.Text = "Shut Down"
        Me.ShutDownButton.UseVisualStyleBackColor = False
        '
        'BatteryLife
        '
        Me.BatteryLife.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BatteryLife.BackColor = System.Drawing.Color.Transparent
        Me.BatteryLife.Font = New System.Drawing.Font("Segoe UI Light", 72.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BatteryLife.ForeColor = System.Drawing.Color.White
        Me.BatteryLife.Location = New System.Drawing.Point(1, 587)
        Me.BatteryLife.Name = "BatteryLife"
        Me.BatteryLife.Size = New System.Drawing.Size(429, 158)
        Me.BatteryLife.TabIndex = 7
        Me.BatteryLife.Text = "00:00:00"
        Me.BatteryLife.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'PCName
        '
        Me.PCName.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.PCName.BackColor = System.Drawing.Color.Transparent
        Me.PCName.Font = New System.Drawing.Font("Impact", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PCName.ForeColor = System.Drawing.Color.Gainsboro
        Me.PCName.Location = New System.Drawing.Point(511, 347)
        Me.PCName.Name = "PCName"
        Me.PCName.Size = New System.Drawing.Size(333, 54)
        Me.PCName.TabIndex = 8
        Me.PCName.Text = "SURFACE-1"
        Me.PCName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.Black
        Me.BackgroundImage = Global.SurfaceShell.My.Resources.Resources.Desktop
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1280, 800)
        Me.Controls.Add(Me.ClockTime)
        Me.Controls.Add(Me.PCName)
        Me.Controls.Add(Me.BatteryLife)
        Me.Controls.Add(Me.ShutDownButton)
        Me.Controls.Add(Me.TabletName)
        Me.Controls.Add(Me.GPUpdateButton)
        Me.Controls.Add(Me.PrepackLauncher)
        Me.Controls.Add(Me.PickLauncher)
        Me.Controls.Add(Me.ClockDate)
        Me.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "SurfaceShell"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents SecondTimer As Timer
    Friend WithEvents ClockTime As Label
    Friend WithEvents ClockDate As Label
    Friend WithEvents PickLauncher As Button
    Friend WithEvents PrepackLauncher As Button
    Friend WithEvents GPUpdateButton As Button
    Friend WithEvents TabletName As Label
    Friend WithEvents ShutDownButton As Button
    Friend WithEvents BatteryLife As Label
    Friend WithEvents PCName As Label
End Class
