# Zoom Meeting Scheduler - KaviMeet

This repository contains a C# application that connects to the Zoom API using OAuth for server-to-server authentication. It retrieves active users from a Zoom account and schedules a meeting for each user.

## Requirements

- .NET 6 or higher
- Zoom API credentials (Client ID, Client Secret, Account ID)
- [ZoomNet](https://github.com/ZoomNet/ZoomNet) library for interacting with Zoom API

## Setup

### 1. Obtain Zoom API Credentials
To use the Zoom API, you must create an application in the [Zoom Marketplace](https://marketplace.zoom.us/) and obtain the following credentials:
- **Account ID**: The ID of the Zoom account from which the application will operate.
- **Client ID**: The client ID to authenticate the application.
- **Client Secret**: The client secret to authenticate the application.

Once you have the credentials, update them in the code below:

```csharp
var accountId = "YOUR_ACCOUNT_ID";
var clientId = "YOUR_CLIENT_ID";
var clientSecret = "YOUR_CLIENT_SECRET";
```

### 2. Configure Your Project

1. Clone the repository or create a new .NET project.
2. Add the **ZoomNet** NuGet package to your project:

   ```bash
   dotnet add package ZoomNet
   ```

3. Add **Microsoft.Extensions.Logging** and **Newtonsoft.Json**:

   ```bash
   dotnet add package Microsoft.Extensions.Logging
   dotnet add package Newtonsoft.Json
   ```

### 3. Run the Application

1. Build and run the application using your preferred method (Visual Studio or command line).
2. The application will:
   - Connect to the Zoom API using the credentials you provided.
   - Retrieve a list of active users.
   - Schedule a meeting titled "Example Meeting" for each user.
3. Monitor the logs to see which users were successfully scheduled for a meeting.

The meeting is created with the following parameters:
- **Topic**: "Example Meeting"
- **Agenda**: "Example Meeting"
- **Start Time**: Current date and time
- **Duration**: 30 minutes
- **Time Zone**: Europe/Istanbul

### Example Output:

The application will output log messages like the following:

```bash
2025-01-06T12:30:45 => Login successful by Akın BİÇER (akin.bicer@outlook.com.tr).
{
  "id": "meeting-id",
  "topic": "Example Meeting",
  "start_time": "2025-01-06T12:30:45",
  "duration": 30,
  "join_url": "https://zoom.us/j/meeting-id"
}
```

## Notes

- This application uses **Server-to-Server OAuth** authentication to securely interact with Zoom API without requiring user interaction.
- The default meeting topic and agenda can be changed in the code.
- Ensure that your Zoom account has access to the appropriate API permissions for creating meetings and retrieving user data.

## License

This project is licensed under the [MIT License](LICENSE). See the license file for details.

## Issues, Feature Requests or Support

Please use the Issue > New Issue button to submit issues, feature requests or support issues directly to me. You can also send an e-mail to akin.bicer@outlook.com.tr.
