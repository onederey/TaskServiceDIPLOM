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
        public static bool DownloadAndFile(string url, string pathToSave)
        {
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

        public static bool UnZipFile(string filePath, string extractPath)
        {
            int retries = 0;
            while (true)
            {
                if(retries >= 5)
                    return false;

                try
                {
                    ZipFile.ExtractToDirectory(filePath, extractPath);
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
