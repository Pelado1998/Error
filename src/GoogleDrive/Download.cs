using System;

namespace GoogleDrive
{
    public class Download
    {
        public static void DownloadFile(Google.Apis.Drive.v3.Data.File file, string path)
        {
            var service = GoogleDriveService.Instance.Service;
            var saveTo = path;
            var request = service.Files.Get(file.Id);
            var stream = new System.IO.MemoryStream();

            request.MediaDownloader.ProgressChanged += (Google.Apis.Download.IDownloadProgress progress) =>
               {
                   switch (progress.Status)
                   {
                       case Google.Apis.Download.DownloadStatus.Downloading:
                           {
                               Console.WriteLine(progress.BytesDownloaded);
                               break;
                           }
                       case Google.Apis.Download.DownloadStatus.Completed:
                           {
                               Console.WriteLine("Google Drive Download complete.");
                               SaveStream(stream, saveTo);
                               break;
                           }
                       case Google.Apis.Download.DownloadStatus.Failed:
                           {
                               Console.WriteLine("Google Drive Download failed.");
                               break;
                           }
                   }
               };
            request.Download(stream);

        }
        private static void SaveStream(System.IO.MemoryStream stream, string saveTo)
        {
            using (System.IO.FileStream file = new System.IO.FileStream(saveTo, System.IO.FileMode.Create, System.IO.FileAccess.Write))
            {
                stream.WriteTo(file);
            }
        }
    }
}