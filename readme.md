# CS-Profile-Backend

*by Derek Mandl, Simone Ruffin, and Stephen Sladek*

### Purpose

This is the backend data supplier for the [CS-Profile](https://github.com/SEMO-Sulky-Penguins/CS-Profile) Angular 6 web app.

### Running the back end
Requirement: Visual Studio

Open the project in Visual studio and click 'ISS Express'.  This builds the project and starts the server.  Once that is running, run the [CS-Profile](https://github.com/SEMO-Sulky-Penguins/CS-Profile) web app (more details in that repo).

### Troubleshooting
+ Make sure that your [CS-Profile](https://github.com/SEMO-Sulky-Penguins/CS-Profile) profile.service.ts getProfile() function points to the correct URL.  The correct URL is found in your launchSettings.json file (in the back end filesystem) under  `iisExpress: { applicationURL: "https://...` except replace the port number with the `sslPort: ...` entry
+ Make sure that your controller functions are working properly with [Postman]
