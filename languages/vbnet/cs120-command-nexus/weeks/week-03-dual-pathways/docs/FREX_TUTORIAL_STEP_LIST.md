# Frex Tutorial Step List

Use this as the simple production list for the person recording the Frex tutorial.

## Build Goal

Create a Windows Forms VB.NET app called `AgraRouteRecallConsole` that teaches:

- adding buttons
- adding a background image
- labels for visible output
- button click events
- simple procedures
- simple functions
- keeping route logic organized

## Tutorial Flow

1. Open the starter template project.
2. Show the included agra map image.
3. Explain the title label and output labels already on screen.
4. Add four buttons to the build area:
   - North
   - East
   - South
   - West
5. Rename each button clearly.
6. Style the buttons so they look consistent.
7. Explain that a button click is the user's input.
8. Create one click event for each button.
9. Introduce the procedure name:
   - `ApplyDirectionSelection`
10. Explain that the procedure gathers repeated steps in one place.
11. Introduce the function name:
   - `GetRouteMessage`
12. Explain that the function returns the text that should appear in the output label.
13. Write a simple `Select Case` block inside the function.
14. Connect each button to the procedure by passing the direction text.
15. Update the output label with the function result.
16. Add clear beginner comments above each step.
17. Test all four buttons.
18. Show that different inputs create different outputs.
19. Close by explaining:
    - front end = buttons and labels
    - back end = the logic inside the procedure and function

## Suggested Route Messages

- North = intake checkpoint waiting
- East = cleared toward Agra Farm Seven
- South = looped back into maintenance
- West = sent toward the wrong gate and must be corrected

## Teaching Reminder

Keep the code simple, visible, and well commented. This tutorial is for extreme beginners, so every button should feel like one understandable action.
