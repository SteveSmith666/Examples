namespace DataDemoService
{
    using System;
    using System.Diagnostics;
    using System.Globalization;
    using System.IO;

    public class DataDemoService : IDataStreaming, IMediaStreaming
    {
        Stream IDataStreaming.GetDataFileAsStream(string dataFileName)
        {
            string dataFile = string.Format("{0}\\{1}", System.Configuration.ConfigurationManager.AppSettings["dataPath"], dataFileName);
            Console.WriteLine("File Requested: " + dataFile);
            
            var fileInfo = new FileInfo(dataFile);

            if (!fileInfo.Exists)
            {
                throw new FileNotFoundException("File does not exist: {0}. Check host configuration for 'dataPath' setting.", dataFileName);
            }

            FileStream fileStream = null;
            try
            {
                fileStream = new FileStream(dataFile, FileMode.Open, FileAccess.Read, FileShare.Read);
            }
            catch
            {
                if (fileStream != null)
                {
                    fileStream.Close();
                }
            }

            return fileStream;
        }

        Stream IMediaStreaming.GetMediaAsStream(string mediaFileName)
        {
            string mediaFile = string.Format("{0}\\{1}", System.Configuration.ConfigurationManager.AppSettings["mediaPath"], mediaFileName);
            Console.WriteLine("File Requested: " + mediaFile);
            
            var fileInfo = new FileInfo(mediaFile);

            if (!fileInfo.Exists)
            {
                throw new FileNotFoundException("File does not exist: {0}. Check host configuration for 'mediaPath' setting.", mediaFileName);
            }

            FileStream fileStream = null;

            var sw = new Stopwatch();
            sw.Start();

            try
            {
                fileStream = new FileStream(mediaFile, FileMode.Open, FileAccess.Read, FileShare.Read);
                //byte[] buffer = new byte[] { };
                //int count = 1;
                //int offset = 0;
                //while (fileStream.Read(buffer, offset, count) > 0)
                //{
                //    offset += count;
                //}

                //Console.WriteLine("Stopwatch_1: " + sw.ElapsedMilliseconds.ToString(CultureInfo.InvariantCulture));
            }
            catch
            {
                if (fileStream != null)
                {
                    fileStream.Close();
                }
            }

            sw.Stop();
            Console.WriteLine("Stopwatch_2: " + sw.ElapsedMilliseconds.ToString(CultureInfo.InvariantCulture));
            
            return fileStream;
        }
    }
}
