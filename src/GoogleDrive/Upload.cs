using Google.Apis.Drive.v3;
using MimeTypes;
using System.IO;

namespace GoogleDrive
{
    public class Upload
    {
        public static void UploadFile(string path)
        {
            var service = GoogleDriveService.Instance.Service;
            var fileMetadata = new Google.Apis.Drive.v3.Data.File();
            fileMetadata.Name = Path.GetFileName(path);
            fileMetadata.MimeType = MimeTypeMap.GetMimeType(Path.GetExtension(path).ToLower());
            if (FindFile.Match(fileMetadata.Name))
            {
                FilesResource.CreateMediaUpload request;
                using (var stream = new System.IO.FileStream(path, System.IO.FileMode.Open))
                {
                    request = service.Files.Create(fileMetadata, stream, MimeTypeMap.GetMimeType("txt"));
                    request.Fields = "id";
                    request.Upload();
                    System.Console.ReadLine();
                }
            }
            else
            {
                System.Console.WriteLine("File already exists");
                System.Console.WriteLine("Updating...");
                UpdateFiles.UpdateFile(path, FindFile.GetFile(fileMetadata.Name));
            }
        }
    }
}