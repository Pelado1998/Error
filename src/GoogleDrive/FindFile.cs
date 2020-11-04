using Google.Apis.Drive.v3;
using System;
using System.Collections.Generic;

namespace GoogleDrive
{
    public class FindFile
    {
        public static bool Match(string name)
        {
            var service = GoogleDriveService.Instance.Service;
            FilesResource.ListRequest listRequest = service.Files.List();
            listRequest.PageSize = 10;
            listRequest.Fields = "nextPageToken, files(id, name)";
            IList<Google.Apis.Drive.v3.Data.File> files = listRequest.Execute()
                .Files;
            if (files != null && files.Count > 0)
            {
                foreach (var file in files)
                {
                    if (file.Name == name)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public static Google.Apis.Drive.v3.Data.File GetFile(string name)
        {
            var service = GoogleDriveService.Instance.Service;
            Google.Apis.Drive.v3.Data.File file = new Google.Apis.Drive.v3.Data.File();
            FilesResource.ListRequest listRequest = service.Files.List();
            listRequest.PageSize = 10;
            listRequest.Fields = "nextPageToken, files(id, name)";
            IList<Google.Apis.Drive.v3.Data.File> files = listRequest.Execute()
                .Files;
            if (files != null && files.Count > 0)
            {
                foreach (var _file in files)
                {
                    if (_file.Name == name)
                    {
                        file = _file;
                    }
                }
            }
            return file;
        }
    }
}