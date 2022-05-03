using System.IO.Compression;
using TaskService.CommonTypes.Classes;

namespace TaskService.CommonTypes.Helpers
{
    /// <summary>
    /// Helper class for working with files
    /// </summary>
    public static class FileHelper
    {
        /// <summary>
        /// Requires path with fileName
        /// </summary>
        public static bool DownloadAndSaveFile(string url, string pathToSave)
        {
            if (File.Exists(pathToSave))
                return true;

            try
            {
                using (HttpClient client = new())
                {
                    var response = client.GetAsync(url).Result;
                    using (var fs = new FileStream(pathToSave, FileMode.CreateNew))
                    {
                        response.Content.CopyToAsync(fs).Wait();
                    }
                    return true;
                }
            }
            catch 
            {
                return false;
            }

        }

        /// <summary>
        /// Get file by mask, if there are many, returns latest based on date...
        /// </summary>
        public static string GetFileByMask(string path, string fileName)
        {
            var files = Directory.GetFiles(path, fileName);

            if(files.Length > 1)
            {
                files.ToList().Sort((first, second) =>
                {
                    var firstDate = File.GetCreationTime(first);
                    var secDate = File.GetCreationTime(second);

                    return DateTime.Compare(firstDate, secDate);
                });
            }

            return files.FirstOrDefault();
        }

        /// <summary>
        /// UnZip File
        /// </summary>
        public static bool UnZipFile(string filePath, string extractPath)
        {
            int retries = 0;
            while (true)
            {
                if(retries >= 5)
                    return false;

                try
                {
                    ZipFile.ExtractToDirectory(filePath, extractPath, true);
                    return true;

                }
                catch(IOException)
                {
                    retries++;
                    Thread.Sleep(TaskServiceConst.DelayForBlockingExc);
                }
            }
        }
    }
}
