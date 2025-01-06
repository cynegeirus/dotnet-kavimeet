using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using ZoomNet;
using ZoomNet.Models;
using ZoomNet.Utilities;

namespace KaviMeet;

class Program
{
    static async Task Main(string[] args)
    {
        var loggerFactory = LoggerFactory.Create(builder =>
        {
            builder
                .AddConsole()
                .SetMinimumLevel(LogLevel.Information);
        });

        var logger = loggerFactory.CreateLogger<Program>();

        /*
         * We obtain the necessary credentials by creating an application with "Server To Server" functionality through the Zoom Marketplace.
         *
         *   => AccountId: Specifies which user will use the API.
         *   => ClientId: Required to obtain permissions for the application and perform other operations.
         *   => ClientSecret: Necessary for authenticating and accessing the application's APIs.
         *
         */
        var accountId = "ZOOM_ACCOUNT_ID";
        var clientId = "ZOOM_CLIENT_ID";
        var clientSecret = "ZOOM_CLIENT_SECRET";

        var connectionInfo = OAuthConnectionInfo.ForServerToServer(clientId, clientSecret, accountId);

        var clientOptions = new ZoomClientOptions
        {
            LogLevelFailedCalls = LogLevel.Warning,
            LogLevelSuccessfulCalls = LogLevel.Information
        };

        var zoomClient = new ZoomClient(connectionInfo, clientOptions);

        try
        {
            var users = await zoomClient.Users.GetAllAsync(UserStatus.Active, null, 30, null, CancellationToken.None);

            if (users != null && users.Records.Any())
            {
                foreach (var user in users.Records)
                {
                    logger.LogInformation($"Login successful by {user.FirstName} {user.LastName} ({user.Email}).");

                    var meetingResult = await zoomClient.Meetings.CreateScheduledMeetingAsync(userId: user.Email, topic: "Example Meeting", agenda: "Example Meeting", start: DateTime.Now, duration: 30, timeZone: TimeZones.Europe_Istanbul);
                    logger.LogInformation(JsonConvert.SerializeObject(meetingResult, Formatting.Indented));
                }
            }
        }
        catch (Exception ex)
        {
            logger.LogError(ex.ToString());
        }

        Console.ReadLine();
    }
}
