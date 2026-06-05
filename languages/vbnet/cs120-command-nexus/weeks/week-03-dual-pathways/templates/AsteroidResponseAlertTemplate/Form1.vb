Imports System.Drawing
Imports System.Windows.Forms

' DEBUG STARTER NOTE
' This template is intentionally not ready to run yet.
' The student must make 3 fixes before the app will run.
' They should use the Error List, read the messages, and repair the marked lines.
' This is part of the lesson: sometimes you enter a project that is not fully
' explained, and you still have to orient yourself and make progress.

' This class is the main code container for the form.
' The matching End Class is at the bottom of the file.
Public Class Form1
    ' These variables store labels and panels we will update later.
    Private statusLabel As Label
    Private outputLabel As Label
    Private hotspotGuidePanel As Panel

    ' This constructor runs when the form is first created.
    ' It calls the setup procedures in order.
    Public Sub New()
        InitializeComponent()
        ConfigureForm()
        BuildTemplateInterface()
    End Sub

    ' This procedure sets the form title, size, color, and font.
    Private Sub ConfigureForm()
        ' FIX 1 OF 3:
        ' Replace TEMPLATE_TITLE_HERE with a real text string in quotes.
        Text = TEMPLATE_TITLE_HERE
        StartPosition = FormStartPosition.CenterScreen
        MinimumSize = New Size(1140, 760)
        BackColor = Color.FromArgb(7, 14, 28)
        Font = New Font("Segoe UI", 10.0F, FontStyle.Regular, GraphicsUnit.Point)
    End Sub

    ' This procedure builds the visible interface.
    ' The student does not need to fully understand every line yet.
    ' In real project work, it is normal to begin working inside code that still feels partly unfamiliar.
    ' The important skill is learning how to stay oriented, test changes, and debug.
    Private Sub BuildTemplateInterface()
        Controls.Clear()

        ' This is the outer layout for the full form.
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
        Controls.Add(root)

        ' FIX 2 OF 3:
        ' Replace MAS_HEADER_COPY_HERE with a real text string in quotes.
        root.Controls.Add(BuildHeader(
            "MAS Template // Asteroid Response Alert",
            MAS_HEADER_COPY_HERE
        ), 0, 0)

        ' The body holds the workspace on the left and the teaching notes on the right.
        Dim body As New TableLayoutPanel With {
            .Dock = DockStyle.Fill,
            .ColumnCount = 2,
            .Margin = New Padding(0, 14, 0, 14)
        }
        body.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 62.0F))
        body.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 38.0F))
        root.Controls.Add(body, 0, 1)

        ' This left panel is the visual work area for the asteroid field.
        Dim workspace As New Panel With {
            .Dock = DockStyle.Fill,
            .BackColor = Color.FromArgb(10, 21, 40),
            .Padding = New Padding(12)
        }
        body.Controls.Add(workspace, 0, 0)

        ' This panel is intentionally a placeholder instead of a finished image.
        ' The student will learn how to assign the background image during the tutorial.
        Dim fieldPlaceholder As New Panel With {
            .Dock = DockStyle.Fill,
            .BorderStyle = BorderStyle.FixedSingle,
            .BackColor = Color.FromArgb(8, 16, 29),
            .Padding = New Padding(22)
        }
        workspace.Controls.Add(fieldPlaceholder)

        Dim imageTitle As New Label With {
            .AutoSize = True,
            .Text = "Background Image Placeholder",
            .ForeColor = Color.White,
            .Font = New Font("Segoe UI", 16.0F, FontStyle.Bold, GraphicsUnit.Point),
            .Location = New Point(22, 22)
        }
        fieldPlaceholder.Controls.Add(imageTitle)

        Dim imageCopy As New Label With {
            .Text = "The student will place the asteroid field image here during the tutorial. This keeps the template active instead of silently doing that step for them.",
            .ForeColor = Color.FromArgb(204, 217, 235),
            .MaximumSize = New Size(760, 0),
            .AutoSize = True,
            .Location = New Point(22, 64)
        }
        fieldPlaceholder.Controls.Add(imageCopy)

        ' This transparent panel sits on top of the image area.
        ' It shows where future hotspot buttons can be created.
        hotspotGuidePanel = New Panel With {
            .Dock = DockStyle.Fill,
            .BackColor = Color.Transparent
        }
        workspace.Controls.Add(hotspotGuidePanel)
        hotspotGuidePanel.BringToFront()

        CreateGuideBox("Create hotspot button here", 120, 80)
        CreateGuideBox("Create hotspot button here", 430, 140)
        CreateGuideBox("Create hotspot button here", 220, 300)
        CreateGuideBox("Create hotspot button here", 500, 350)

        ' The side panel explains what the template is trying to teach.
        Dim sidePanel As New TableLayoutPanel With {
            .Dock = DockStyle.Fill,
            .ColumnCount = 1,
            .RowCount = 10,
            .Padding = New Padding(18),
            .BackColor = Color.FromArgb(10, 21, 40),
            .Margin = New Padding(18, 0, 0, 0)
        }
        For index As Integer = 0 To 9
            sidePanel.RowStyles.Add(New RowStyle(SizeType.AutoSize))
        Next
        body.Controls.Add(sidePanel, 1, 0)

        sidePanel.Controls.Add(BuildSectionLabel("Tutorial Goal"), 0, 0)
        sidePanel.Controls.Add(BuildCopyLabel("Teach hotspot placement, naming, styling, conditional output, and the Week 4 idea that procedures and functions help organize the same logic."), 0, 1)

        sidePanel.Controls.Add(BuildSectionLabel("Status Label"), 0, 2)
        ' FIX 3 OF 3:
        ' Replace START_STATUS_HERE with a real text string in quotes.
        statusLabel = BuildResultLabel(START_STATUS_HERE)
        sidePanel.Controls.Add(statusLabel, 0, 3)

        sidePanel.Controls.Add(BuildSectionLabel("Output Label"), 0, 4)
        outputLabel = BuildResultLabel("This label will show the station response after the student writes code.")
        sidePanel.Controls.Add(outputLabel, 0, 5)

        sidePanel.Controls.Add(BuildSectionLabel("Week 4 Planning"), 0, 6)
        sidePanel.Controls.Add(BuildCopyLabel("Recommended procedure name: ApplyAsteroidSelection. Recommended function name: GetAsteroidResponse. Keep asteroid state private inside the form."), 0, 7)

        sidePanel.Controls.Add(BuildSectionLabel("Debugging Note"), 0, 8)
        sidePanel.Controls.Add(BuildCopyLabel("Students should get used to seeing code and properties they do not fully understand yet. If something breaks, read the error message, go to the line it names, and ask what changed since the last working version."), 0, 9)

        Dim footer As Label = BuildCopyLabel("This template is intentionally unfinished. The tutorial should guide the student through building hotspot input and sending the right output message.")
        footer.ForeColor = Color.FromArgb(141, 176, 214)
        root.Controls.Add(footer, 0, 2)
    End Sub

    ' This procedure creates one guide box for the hotspot area.
    ' Later, a real button can be placed in that area by the student.
    Private Sub CreateGuideBox(textValue As String, leftValue As Integer, topValue As Integer)
        Dim guide As New Label With {
            .Text = textValue,
            .ForeColor = Color.FromArgb(87, 210, 255),
            .BackColor = Color.FromArgb(18, 38, 67),
            .BorderStyle = BorderStyle.FixedSingle,
            .TextAlign = ContentAlignment.MiddleCenter,
            .Width = 150,
            .Height = 48,
            .Left = leftValue,
            .Top = topValue
        }
        hotspotGuidePanel.Controls.Add(guide)
    End Sub

    ' This procedure updates the status label.
    ' That makes it one example of visible output.
    Private Sub ShowStatus(message As String)
        statusLabel.Text = message
    End Sub

    ' This function returns the message that should appear for a selected asteroid type.
    ' A function is useful when we want code to send back an answer.
    Private Function GetAsteroidResponse(asteroidType As String) As String
        Select Case asteroidType
            Case "Threat"
                Return "Destroy the threat before impact."
            Case "Harvest"
                Return "Preserve the body for recovery."
            Case "Ice"
                Return "Scan the ice shell before firing."
            Case "Bio"
                Return "Hold fire and protect the signature."
            Case Else
                Return "Select an asteroid hotspot."
        End Select
    End Function

    ' This procedure connects the user's input to the visible output.
    ' In a finished version, a hotspot click event would call this procedure.
    Private Sub ApplyAsteroidSelection(asteroidType As String)
        ShowStatus("Hotspot clicked: " & asteroidType)
        outputLabel.Text = GetAsteroidResponse(asteroidType)
    End Sub

    ' The helper builders below are intentionally supplied as structure.
    ' Students can work in a project even when not every helper is fully familiar yet.
    Private Function BuildHeader(titleText As String, copyText As String) As Panel
        Dim panel As New Panel With {
            .Dock = DockStyle.Top,
            .Height = 110,
            .BackColor = Color.FromArgb(10, 21, 40),
            .Padding = New Padding(18)
        }

        Dim eyebrow As New Label With {
            .AutoSize = True,
            .Text = "Week 3 Starter Template",
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
            .Size = New Size(980, 28)
        }
        panel.Controls.Add(copy)

        Return panel
    End Function

    Private Function BuildSectionLabel(textValue As String) As Label
        Return New Label With {
            .Text = textValue,
            .ForeColor = Color.FromArgb(87, 210, 255),
            .Font = New Font("Segoe UI", 9.0F, FontStyle.Bold, GraphicsUnit.Point),
            .Padding = New Padding(0, 8, 0, 4),
            .AutoSize = True
        }
    End Function

    Private Function BuildCopyLabel(textValue As String) As Label
        Return New Label With {
            .Text = textValue,
            .ForeColor = Color.FromArgb(219, 228, 240),
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
End Class
