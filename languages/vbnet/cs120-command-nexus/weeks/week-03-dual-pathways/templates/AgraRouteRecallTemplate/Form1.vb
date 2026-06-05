Imports System.Drawing
Imports System.Windows.Forms

' DEBUG STARTER NOTE
' This template is intentionally not ready to run yet.
' The student must make 3 fixes before the app will run.
' They should use the Error List, read the messages, and repair the marked lines.
' This is part of the lesson: sometimes you enter a project that is not fully
' explained, and you still have to orient yourself and make progress.

' This class is the main code container for the form.
' Visual Basic reads everything inside this class as part of one form.
' The matching End Class is at the bottom of the file.
Public Class Form1
    ' These variables store references to labels we want to update later.
    ' We keep them here so multiple procedures can use the same controls.
    Private statusLabel As Label
    Private outputLabel As Label

    ' This is the constructor for the form.
    ' It runs when the form is first created.
    ' The constructor calls smaller setup procedures so the file stays organized.
    Public Sub New()
        InitializeComponent()
        ConfigureForm()
        BuildTemplateInterface()
    End Sub

    ' A procedure is a named block of code that performs an action.
    ' This procedure sets the basic properties of the form itself.
    Private Sub ConfigureForm()
        ' FIX 1 OF 3:
        ' Replace TEMPLATE_TITLE_HERE with a real text string in quotes.
        Text = TEMPLATE_TITLE_HERE
        StartPosition = FormStartPosition.CenterScreen
        MinimumSize = New Size(1140, 760)
        BackColor = Color.FromArgb(7, 14, 28)
        Font = New Font("Segoe UI", 10.0F, FontStyle.Regular, GraphicsUnit.Point)
    End Sub

    ' This procedure builds the visible interface at run time.
    ' The student is not expected to understand every line yet.
    ' That is part of the lesson:
    ' sometimes we work inside a project before every piece feels familiar.
    ' The goal is to stay oriented enough to keep building and debugging.
    Private Sub BuildTemplateInterface()
        Controls.Clear()

        ' The root panel is the outer layout for the whole form.
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
        ' Replace FREX_HEADER_COPY_HERE with a real text string in quotes.
        root.Controls.Add(BuildHeader(
            "Frex Template // Agra Route Recall",
            FREX_HEADER_COPY_HERE
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

        ' The workspace is where the student-facing UI is staged.
        Dim workspace As New TableLayoutPanel With {
            .Dock = DockStyle.Fill,
            .ColumnCount = 1,
            .RowCount = 2,
            .BackColor = Color.FromArgb(10, 21, 40),
            .Padding = New Padding(12)
        }
        workspace.RowStyles.Add(New RowStyle(SizeType.Absolute, 440.0F))
        workspace.RowStyles.Add(New RowStyle(SizeType.Percent, 100.0F))
        body.Controls.Add(workspace, 0, 0)

        ' This panel is intentionally a placeholder instead of a finished image.
        ' The student will learn how to assign the background image during the tutorial.
        Dim imagePlaceholder As New Panel With {
            .Dock = DockStyle.Fill,
            .BorderStyle = BorderStyle.FixedSingle,
            .BackColor = Color.FromArgb(8, 16, 29),
            .Padding = New Padding(22)
        }
        workspace.Controls.Add(imagePlaceholder, 0, 0)

        Dim imageTitle As New Label With {
            .AutoSize = True,
            .Text = "Map Image Placeholder",
            .ForeColor = Color.White,
            .Font = New Font("Segoe UI", 16.0F, FontStyle.Bold, GraphicsUnit.Point),
            .Location = New Point(22, 22)
        }
        imagePlaceholder.Controls.Add(imageTitle)

        Dim imageCopy As New Label With {
            .Text = "The student will place the Agra Farm image here during the tutorial. This helps them practice changing a project instead of only observing a finished one.",
            .ForeColor = Color.FromArgb(204, 217, 235),
            .MaximumSize = New Size(760, 0),
            .AutoSize = True,
            .Location = New Point(22, 64)
        }
        imagePlaceholder.Controls.Add(imageCopy)

        ' This lower area reminds the student where the buttons will be created.
        Dim stagingPanel As New Panel With {
            .Dock = DockStyle.Fill,
            .BorderStyle = BorderStyle.FixedSingle,
            .BackColor = Color.FromArgb(9, 17, 31),
            .Padding = New Padding(14),
            .Margin = New Padding(0, 12, 0, 0)
        }
        workspace.Controls.Add(stagingPanel, 0, 1)

        Dim stagingTitle As New Label With {
            .AutoSize = True,
            .Text = "Tutorial Build Area",
            .ForeColor = Color.FromArgb(87, 210, 255),
            .Font = New Font("Segoe UI", 10.0F, FontStyle.Bold, GraphicsUnit.Point),
            .Location = New Point(14, 14)
        }
        stagingPanel.Controls.Add(stagingTitle)

        Dim stagingCopy As New Label With {
            .Text = "Add four buttons here: North, East, South, and West. Then connect each button to a click event and update the output label.",
            .ForeColor = Color.FromArgb(219, 228, 240),
            .MaximumSize = New Size(560, 0),
            .AutoSize = True,
            .Location = New Point(14, 46)
        }
        stagingPanel.Controls.Add(stagingCopy)

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
        sidePanel.Controls.Add(BuildCopyLabel("Teach buttons, labels, simple condition messages, and the Week 4 idea that named procedures and functions keep code organized."), 0, 1)

        sidePanel.Controls.Add(BuildSectionLabel("Status Label"), 0, 2)
        ' FIX 3 OF 3:
        ' Replace START_STATUS_HERE with a real text string in quotes.
        statusLabel = BuildResultLabel(START_STATUS_HERE)
        sidePanel.Controls.Add(statusLabel, 0, 3)

        sidePanel.Controls.Add(BuildSectionLabel("Output Label"), 0, 4)
        outputLabel = BuildResultLabel("This label will show the route result after the student writes code.")
        sidePanel.Controls.Add(outputLabel, 0, 5)

        sidePanel.Controls.Add(BuildSectionLabel("Week 4 Planning"), 0, 6)
        sidePanel.Controls.Add(BuildCopyLabel("Recommended procedure name: ApplyDirectionSelection. Recommended function name: GetRouteMessage. Keep route state private inside the form."), 0, 7)

        sidePanel.Controls.Add(BuildSectionLabel("Debugging Note"), 0, 8)
        sidePanel.Controls.Add(BuildCopyLabel("Students should get used to seeing code they do not fully understand yet. If something breaks, read the error message, go to the line it names, and compare the current code to the last working version."), 0, 9)

        Dim footer As Label = BuildCopyLabel("This template is intentionally unfinished. The tutorial should guide the student through adding controls and writing the beginner logic.")
        footer.ForeColor = Color.FromArgb(141, 176, 214)
        root.Controls.Add(footer, 0, 2)
    End Sub

    ' This procedure updates the status label.
    ' That makes it a simple output action.
    Private Sub ShowStatus(message As String)
        statusLabel.Text = message
    End Sub

    ' A function returns a value back to the caller.
    ' In this template, the returned value is the message that should appear for a route.
    Private Function GetRouteMessage(direction As String) As String
        Select Case direction
            Case "North"
                Return "North route selected."
            Case "East"
                Return "East route selected."
            Case "South"
                Return "South route selected."
            Case "West"
                Return "West route selected."
            Case Else
                Return "Choose a direction."
        End Select
    End Function

    ' This procedure is the bridge between input and output.
    ' A finished button click event could call this procedure and pass in the chosen direction.
    Private Sub ApplyDirectionSelection(direction As String)
        ShowStatus("Button clicked: " & direction)
        outputLabel.Text = GetRouteMessage(direction)
    End Sub

    ' The helper builders below are intentionally already supplied.
    ' The student may not understand every helper yet, and that is okay.
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
