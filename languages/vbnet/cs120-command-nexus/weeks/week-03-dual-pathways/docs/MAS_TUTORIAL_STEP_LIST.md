# MAS Tutorial Step List

Use this as the simple production list for the person recording the MAS tutorial.

## Build Goal

Create a Windows Forms VB.NET app called `AsteroidResponseAlertConsole` that teaches:

- placing hotspot buttons on an image
- naming and styling controls
- reading input from button clicks
- showing output in labels
- condition checks
- simple procedures
- simple functions
- keeping alert logic organized

## Tutorial Flow

1. Open the starter template project.
2. Show the included asteroid field image.
3. Explain that the guide boxes mark suggested hotspot areas.
4. Add hotspot buttons on the UI where the asteroids should be selected.
5. Name the buttons clearly. Suggested labels:
   - Threat
   - Harvest
   - Ice
   - Bio
6. Style the buttons so they stand out on the background image.
7. Explain that clicking a hotspot is the user's input.
8. Create one click event for each hotspot button.
9. Introduce the procedure name:
   - `ApplyAsteroidSelection`
10. Explain that the procedure gathers repeated UI steps together.
11. Introduce the function name:
   - `GetAsteroidResponse`
12. Explain that the function returns the correct station response text.
13. Write a simple `Select Case` block inside the function.
14. Connect each hotspot button to the procedure by passing the asteroid type.
15. Update the output label with the function result.
16. Add clear beginner comments above each block.
17. Test every hotspot.
18. Show that each asteroid type creates a different response.
19. Close by explaining:
    - front end = hotspot buttons and labels
    - back end = the logic inside the procedure and function

## Suggested Response Messages

- Threat = destroy before impact
- Harvest = preserve and recover useful material
- Ice = scan before firing
- Bio = hold fire and protect the signature

## Teaching Reminder

Keep the language beginner-friendly. The point is not combat complexity. The point is showing that the same programming structure can drive a different story context.
