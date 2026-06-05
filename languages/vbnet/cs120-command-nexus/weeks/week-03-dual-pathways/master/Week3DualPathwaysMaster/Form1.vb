Imports System.Collections.Generic
Imports System.Drawing
Imports System.IO
Imports System.Windows.Forms

Public Class Form1
    Private ReadOnly frexButtons As New Dictionary(Of String, Button)(StringComparer.OrdinalIgnoreCase)
    Private ReadOnly masButtons As New Dictionary(Of String, Button)(StringComparer.OrdinalIgnoreCase)

    Private frexStatusLabel As Label
    Private frexResultLabel As Label
    Private frexStructureLabel As Label
    Private masStatusLabel As Label
    Private masResultLabel As Label
    Private masStructureLabel As Label

    Private currentDirection As String = ""
    Private currentAsteroidType As String = ""

    Public Sub New()
        InitializeComponent()
        ConfigureForm()
        BuildInterface()
    End Sub

    Private Sub ConfigureForm()
        Text = "Week 3 Dual Pathways Master"
        StartPosition = FormStartPosition.CenterScreen
        MinimumSize = New Size(1220, 820)
        BackColor = Color.FromArgb(7, 14, 28)
        Font = New Font("Segoe UI", 10.0F, FontStyle.Regular, GraphicsUnit.Point)
    End Sub

    Private Sub BuildInterface()
        Controls.Clear()

        Dim tabs As New TabControl With {
            .Dock = DockStyle.Fill,
            .Alignment = TabAlignment.Top,
            .ItemSize = New Size(250, 34),
            .SizeMode = TabSizeMode.Fixed
        }

        Dim frexTab As New TabPage("Frex // Agra Route Recall") With {
            .BackColor = Color.FromArgb(7, 14, 28)
        }
        Dim masTab As New TabPage("MAS // Asteroid Response Alert") With {
            .BackColor = Color.FromArgb(7, 14, 28)
        }

        tabs.TabPages.Add(frexTab)
        tabs.TabPages.Add(masTab)
        Controls.Add(tabs)

        BuildFrexTab(frexTab)
        BuildMasTab(masTab)
    End Sub

    Private Sub BuildFrexTab(host As TabPage)
        Dim root As New TableLayoutPanel With {
            .Dock = DockStyle.Fill,
            .ColumnCount = 1,
            .RowCount = 3,
            .Padding = New Padding(18),
            .BackColor = Color.FromArgb(7, 14, 28)
        }
        root.RowStyles.Add(New RowStyle(SizeType.AutoSize))
        root.RowStyles.Add(New RowStyle(SizeType.Percent, 100.0F))
        root.RowStyles.Add(New RowStyle(SizeType.AutoSize))
        host.Controls.Add(root)

        root.Controls.Add(BuildHeader(
            "Frex // Agra Route Recall Console",
            "Completed reference build. This version demonstrates variables, input/output, button events, procedures, functions, and simple encapsulation through a map-routing assignment."
        ), 0, 0)

        Dim body As New TableLayoutPanel With {
            .Dock = DockStyle.Fill,
            .ColumnCount = 2,
            .Margin = New Padding(0, 14, 0, 14)
        }
        body.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 64.0F))
        body.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 36.0F))
        root.Controls.Add(body, 0, 1)

        Dim picture As New PictureBox With {
            .Dock = DockStyle.Fill,
            .BorderStyle = BorderStyle.FixedSingle,
            .BackColor = Color.Black,
            .SizeMode = PictureBoxSizeMode.Zoom,
            .Image = LoadProjectImage("agra_map.png")
        }
        body.Controls.Add(picture, 0, 0)

        Dim sidePanel As New TableLayoutPanel With {
            .Dock = DockStyle.Fill,
            .ColumnCount = 1,
            .RowCount = 6,
            .Padding = New Padding(18),
            .BackColor = Color.FromArgb(10, 21, 40),
            .Margin = New Padding(18, 0, 0, 0)
        }
        For index As Integer = 0 To 5
            sidePanel.RowStyles.Add(New RowStyle(SizeType.AutoSize))
        Next
        body.Controls.Add(sidePanel, 1, 0)

        sidePanel.Controls.Add(BuildSectionLabel("Current Input"), 0, 0)

        frexStatusLabel = BuildCopyLabel("Choose a direction button to send HARVI through the agra map.")
        sidePanel.Controls.Add(frexStatusLabel, 0, 1)

        sidePanel.Controls.Add(BuildSectionLabel("Current Output"), 0, 2)

        frexResultLabel = BuildResultLabel("Waiting for route selection.")
        sidePanel.Controls.Add(frexResultLabel, 0, 3)

        sidePanel.Controls.Add(BuildSectionLabel("Week 4 Structure"), 0, 4)

        frexStructureLabel = BuildCopyLabel("Procedure: ApplyFrexDirection. Function: GetFrexRouteMessage. Encapsulation: route state and button highlighting stay inside this form.")
        sidePanel.Controls.Add(frexStructureLabel, 0, 5)

        Dim buttonRow As New FlowLayoutPanel With {
            .Dock = DockStyle.Fill,
            .AutoSize = True,
            .WrapContents = True,
            .Padding = New Padding(0),
            .Margin = New Padding(0)
        }
        root.Controls.Add(buttonRow, 0, 2)

        CreateFrexButton(buttonRow, "North")
        CreateFrexButton(buttonRow, "East")
        CreateFrexButton(buttonRow, "South")
        CreateFrexButton(buttonRow, "West")

        ShowFrexStatus("Use the route buttons as the app input.")
    End Sub

    Private Sub BuildMasTab(host As TabPage)
        Dim root As New TableLayoutPanel With {
            .Dock = DockStyle.Fill,
            .ColumnCount = 1,
            .RowCount = 3,
            .Padding = New Padding(18),
            .BackColor = Color.FromArgb(7, 14, 28)
        }
        root.RowStyles.Add(New RowStyle(SizeType.AutoSize))
        root.RowStyles.Add(New RowStyle(SizeType.Percent, 100.0F))
        root.RowStyles.Add(New RowStyle(SizeType.AutoSize))
        host.Controls.Add(root)

        root.Controls.Add(BuildHeader(
            "MAS // Asteroid Response Alert Console",
            "Completed reference build. This version shows UI hotspots, condition checks, output labels, and the same Week 4 structure through asteroid classification."
        ), 0, 0)

        Dim body As New TableLayoutPanel With {
            .Dock = DockStyle.Fill,
            .ColumnCount = 2,
            .Margin = New Padding(0, 14, 0, 14)
        }
        body.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 64.0F))
        body.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 36.0F))
        root.Controls.Add(body, 0, 1)

        Dim imageHost As New Panel With {
            .Dock = DockStyle.Fill,
            .BorderStyle = BorderStyle.FixedSingle,
            .BackColor = Color.Black
        }
        body.Controls.Add(imageHost, 0, 0)

        Dim picture As New PictureBox With {
            .Dock = DockStyle.Fill,
            .BackColor = Color.Black,
            .SizeMode = PictureBoxSizeMode.Zoom,
            .Image = LoadProjectImage("asteroid_field.png")
        }
        imageHost.Controls.Add(picture)

        CreateMasHotspot(imageHost, "Threat", 120, 80)
        CreateMasHotspot(imageHost, "Harvest", 420, 140)
        CreateMasHotspot(imageHost, "Ice", 220, 290)
        CreateMasHotspot(imageHost, "Bio", 500, 320)

        Dim sidePanel As New TableLayoutPanel With {
            .Dock = DockStyle.Fill,
            .ColumnCount = 1,
            .RowCount = 6,
            .Padding = New Padding(18),
            .BackColor = Color.FromArgb(10, 21, 40),
            .Margin = New Padding(18, 0, 0, 0)
        }
        For index As Integer = 0 To 5
            sidePanel.RowStyles.Add(New RowStyle(SizeType.AutoSize))
        Next
        body.Controls.Add(sidePanel, 1, 0)

        sidePanel.Controls.Add(BuildSectionLabel("Current Input"), 0, 0)

        masStatusLabel = BuildCopyLabel("Click a hotspot to classify the asteroid.")
        sidePanel.Controls.Add(masStatusLabel, 0, 1)

        sidePanel.Controls.Add(BuildSectionLabel("Current Output"), 0, 2)

        masResultLabel = BuildResultLabel("Waiting for asteroid selection.")
        sidePanel.Controls.Add(masResultLabel, 0, 3)

        sidePanel.Controls.Add(BuildSectionLabel("Week 4 Structure"), 0, 4)

        masStructureLabel = BuildCopyLabel("Procedure: ApplyMasSelection. Function: GetMasResponse. Encapsulation: asteroid state and hotspot styling stay inside this form.")
        sidePanel.Controls.Add(masStructureLabel, 0, 5)

        Dim footer As Label = BuildCopyLabel("Hotspots act as the UI input. The label on the right is the visible output.")
        footer.ForeColor = Color.FromArgb(141, 176, 214)
        footer.Padding = New Padding(6, 10, 6, 0)
        root.Controls.Add(footer, 0, 2)

        ShowMasStatus("Use a hotspot as the app input.")
    End Sub

    Private Function BuildHeader(titleText As String, copyText As String) As Panel
        Dim panel As New Panel With {
            .Dock = DockStyle.Top,
            .Height = 110,
            .BackColor = Color.FromArgb(10, 21, 40),
            .Padding = New Padding(18)
        }

        Dim eyebrow As New Label With {
            .AutoSize = True,
            .Text = "Week 3 + Week 4 Combined Skills",
            .ForeColor = Color.FromArgb(87, 210, 255),
            .Font = New Font("Segoe UI", 9.0F, FontStyle.Bold, GraphicsUnit.Point),
            .Location = New Point(18, 16)
        }
        panel.Controls.Add(eyebrow)

        Dim title As New Label With {
            .AutoSize = True,
            .Text = titleText,
            .ForeColor = Color.White,
            .Font = New Font("Segoe UI", 18.0F, FontStyle.Bold, GraphicsUnit.Point),
            .Location = New Point(18, 40)
        }
        panel.Controls.Add(title)

        Dim copy As New Label With {
            .AutoSize = False,
            .Text = copyText,
            .ForeColor = Color.FromArgb(204, 217, 235),
            .Font = New Font("Segoe UI", 10.0F, FontStyle.Regular, GraphicsUnit.Point),
            .Location = New Point(18, 76),
            .Size = New Size(1040, 28)
        }
        panel.Controls.Add(copy)

        Return panel
    End Function

    Private Function BuildSectionLabel(textValue As String) As Label
        Return New Label With {
            .AutoSize = True,
            .Text = textValue,
            .ForeColor = Color.FromArgb(87, 210, 255),
            .Font = New Font("Segoe UI", 9.0F, FontStyle.Bold, GraphicsUnit.Point),
            .Padding = New Padding(0, 8, 0, 4)
        }
    End Function

    Private Function BuildCopyLabel(textValue As String) As Label
        Return New Label With {
            .Text = textValue,
            .ForeColor = Color.FromArgb(219, 228, 240),
            .Font = New Font("Segoe UI", 10.0F, FontStyle.Regular, GraphicsUnit.Point),
            .MaximumSize = New Size(420, 0),
            .AutoSize = True
        }
    End Function

    Private Function BuildResultLabel(textValue As String) As Label
        Return New Label With {
            .Text = textValue,
            .ForeColor = Color.White,
            .BackColor = Color.FromArgb(19, 38, 67),
            .BorderStyle = BorderStyle.FixedSingle,
            .Padding = New Padding(12),
            .MaximumSize = New Size(420, 0),
            .AutoSize = True
        }
    End Function

    Private Sub CreateFrexButton(host As FlowLayoutPanel, direction As String)
        Dim button As New Button With {
            .Text = direction,
            .Tag = direction,
            .Width = 140,
            .Height = 46,
            .FlatStyle = FlatStyle.Flat,
            .BackColor = Color.FromArgb(18, 54, 92),
            .ForeColor = Color.White,
            .Margin = New Padding(0, 0, 14, 0)
        }
        button.FlatAppearance.BorderColor = Color.FromArgb(87, 210, 255)
        button.FlatAppearance.BorderSize = 1
        AddHandler button.Click, AddressOf OnFrexDirectionClick
        frexButtons(direction) = button
        host.Controls.Add(button)
    End Sub

    Private Sub CreateMasHotspot(host As Panel, asteroidType As String, leftValue As Integer, topValue As Integer)
        Dim button As New Button With {
            .Text = asteroidType,
            .Tag = asteroidType,
            .Width = 116,
            .Height = 42,
            .FlatStyle = FlatStyle.Flat,
            .BackColor = Color.FromArgb(15, 60, 105),
            .ForeColor = Color.White,
            .Parent = host
        }
        button.FlatAppearance.BorderColor = Color.FromArgb(87, 210, 255)
        button.FlatAppearance.BorderSize = 1
        button.SetBounds(leftValue, topValue, button.Width, button.Height)
        AddHandler button.Click, AddressOf OnMasHotspotClick
        masButtons(asteroidType) = button
        host.Controls.Add(button)
        button.BringToFront()
    End Sub

    Private Sub OnFrexDirectionClick(sender As Object, e As EventArgs)
        Dim selectedButton As Button = DirectCast(sender, Button)
        ApplyFrexDirection(CStr(selectedButton.Tag))
    End Sub

    Private Sub OnMasHotspotClick(sender As Object, e As EventArgs)
        Dim selectedButton As Button = DirectCast(sender, Button)
        ApplyMasSelection(CStr(selectedButton.Tag))
    End Sub

    Private Sub ApplyFrexDirection(direction As String)
        currentDirection = direction
        ResetFrexButtonStyles()
        HighlightFrexButton(direction)
        ShowFrexStatus("Input received: " & direction & " route button clicked.")
        frexResultLabel.Text = GetFrexRouteMessage(direction)
        frexStructureLabel.Text = "Procedure: ApplyFrexDirection(""" & direction & """). Function: GetFrexRouteMessage. Encapsulation: currentDirection stays private inside the form."
    End Sub

    Private Function GetFrexRouteMessage(direction As String) As String
        Select Case direction
            Case "North"
                Return "North route selected. HARVI moves toward the intake checkpoint and waits for lane confirmation."
            Case "East"
                Return "East route selected. HARVI is redirected into the agra corridor and cleared for Agra Farm Seven."
            Case "South"
                Return "South route selected. HARVI loops back into maintenance and the service line remains blocked."
            Case "West"
                Return "West route selected. HARVI reaches the wrong gate and requires a new route check before deployment."
            Case Else
                Return "Choose a route to display the next system message."
        End Select
    End Function

    Private Sub ResetFrexButtonStyles()
        For Each routeButton As Button In frexButtons.Values
            routeButton.BackColor = Color.FromArgb(18, 54, 92)
        Next
    End Sub

    Private Sub HighlightFrexButton(direction As String)
        If frexButtons.ContainsKey(direction) Then
            frexButtons(direction).BackColor = Color.FromArgb(32, 106, 172)
        End If
    End Sub

    Private Sub ShowFrexStatus(message As String)
        frexStatusLabel.Text = message
    End Sub

    Private Sub ApplyMasSelection(asteroidType As String)
        currentAsteroidType = asteroidType
        ResetMasHotspots()
        HighlightMasHotspot(asteroidType)
        ShowMasStatus("Input received: " & asteroidType & " hotspot clicked.")
        masResultLabel.Text = GetMasResponse(asteroidType)
        masStructureLabel.Text = "Procedure: ApplyMasSelection(""" & asteroidType & """). Function: GetMasResponse. Encapsulation: currentAsteroidType stays private inside the form."
    End Sub

    Private Function GetMasResponse(asteroidType As String) As String
        Select Case asteroidType
            Case "Threat"
                Return "Threat confirmed. Human turrets should destroy the incoming body before impact."
            Case "Harvest"
                Return "Harvestable body confirmed. Redirect recovery drones and preserve useful material."
            Case "Ice"
                Return "Ice shell detected. Hold direct fire and scan for the resource core before choosing a response."
            Case "Bio"
                Return "Protected ecosystem signature detected. Hold fire, quarantine the zone, and alert command."
            Case Else
                Return "Click a hotspot to show the station response."
        End Select
    End Function

    Private Sub ResetMasHotspots()
        For Each hotspot As Button In masButtons.Values
            hotspot.BackColor = Color.FromArgb(15, 60, 105)
        Next
    End Sub

    Private Sub HighlightMasHotspot(asteroidType As String)
        If masButtons.ContainsKey(asteroidType) Then
            masButtons(asteroidType).BackColor = Color.FromArgb(194, 70, 55)
        End If
    End Sub

    Private Sub ShowMasStatus(message As String)
        masStatusLabel.Text = message
    End Sub

    Private Function LoadProjectImage(fileName As String) As Image
        Dim imagePath As String = Path.Combine(AppContext.BaseDirectory, "Assets", fileName)

        If File.Exists(imagePath) Then
            Using sourceImage As Image = Image.FromFile(imagePath)
                Return New Bitmap(sourceImage)
            End Using
        End If

        Dim placeholder As New Bitmap(960, 540)
        Using graphics As Graphics = Graphics.FromImage(placeholder)
            graphics.Clear(Color.FromArgb(10, 21, 40))
            Using titleBrush As New SolidBrush(Color.White)
                Using bodyBrush As New SolidBrush(Color.FromArgb(141, 176, 214))
                    graphics.DrawString("Missing asset", New Font("Segoe UI", 26.0F, FontStyle.Bold), titleBrush, 28, 26)
                    graphics.DrawString(fileName, New Font("Segoe UI", 14.0F, FontStyle.Regular), bodyBrush, 28, 72)
                End Using
            End Using
        End Using

        Return placeholder
    End Function
End Class
