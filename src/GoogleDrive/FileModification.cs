using System;

namespace GoogleDrive
{
    public class FileModification
    {
        public static void FileWriteAll(string path, string[] content)
        {
            System.IO.File.WriteAllLines(path, content);
        }
        public static string[] ReadAllLines(string path)
        {
            string[] lines = System.IO.File.ReadAllLines(path);
            return lines;
        }
    }
}