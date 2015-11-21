using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helper.Helper
{
    public static class FileHelper
    {
        public static string SaveFile(string fileName, System.IO.Stream stream)
        {
            try
            {
                var splits = fileName.Split('.');
                var ext = splits.Last();
                var FileName = Guid.NewGuid().ToString() + "." + ext;
                var upload = System.IO.Path.Combine(System.Configuration.ConfigurationManager.AppSettings["UploadFolderPath"] + FileName);
                var fileStream = System.IO.File.Create(upload);
                stream.CopyTo(fileStream);
                fileStream.Flush();
                fileStream.Close();
                return FileName;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public static string GetFileUrl(string filename)
        {
            var upload = System.Configuration.ConfigurationManager.AppSettings["UploadFolderName"] + filename;
            return upload;

        }
    }
}
