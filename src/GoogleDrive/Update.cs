using Google.Apis.Drive.v3;
using System;
using System.Collections.Generic;

namespace GoogleDrive
{
    public class UpdateFiles
    {
        public static void UpdateFile(string _uploadFile, Google.Apis.Drive.v3.Data.File _file)
        {
            var service = GoogleDriveService.Instance.Service;

            if (System.IO.File.Exists(_uploadFile))
            {
                Google.Apis.Drive.v3.Data.File body = new Google.Apis.Drive.v3.Data.File();
                body.Name = _file.Name;
                body.Description = "";
                body.MimeType = _file.MimeType;

                byte[] byteArray = System.IO.File.ReadAllBytes(_uploadFile);
                System.IO.MemoryStream stream = new System.IO.MemoryStream(byteArray);
                try
                {
                    FilesResource.UpdateMediaUpload request = service.Files.Update(body, _file.Id, stream, body.MimeType);
                    request.Upload();
                }
                catch (Exception e)
                {
                    Console.WriteLine("An error occurred: " + e.Message);
                }
            }
            else
            {
                Console.WriteLine("File does not exist: " + _uploadFile);
            }
        }
    }
}