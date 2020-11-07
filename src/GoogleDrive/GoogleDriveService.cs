using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using System;
using System.IO;
using System.Threading;


namespace GoogleDrive
{
    public class GoogleDriveService
    {
        public DriveService Service;
        private static GoogleDriveService instance;
        public static GoogleDriveService Instance
        {
            get
            {
                if (instance == null) instance = new GoogleDriveService();
                return instance;
            }
        }

        private GoogleDriveService()
        {
            this.Service = Start();
        }
        private string ApplicationName = "Drive API .NET Quickstart";
        private string[] Scopes = { DriveService.Scope.Drive, DriveService.Scope.DriveFile };
        public DriveService Start()
        {
            UserCredential credential;

            using (var stream =
                new FileStream(@".\..\GoogleDrive\credentials.json", FileMode.Open, FileAccess.Read))
            {
                // The file token.json stores the user's access and refresh tokens, and is created
                // automatically when the authorization flow completes for the first time.
                string credPath = @".\..\GoogleDrive\token.json";
                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(stream).Secrets,
                    Scopes,
                    "user",
                    CancellationToken.None,
                    new FileDataStore(credPath, true)).Result;
            }

            // Create Drive API service.
            var service = new DriveService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = ApplicationName,
            });

            return service;
        }
    }
}