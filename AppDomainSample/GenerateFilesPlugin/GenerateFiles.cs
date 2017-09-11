using System;
using System.IO;

namespace GenerateFilesPlugin
{
    public class GenerateFiles
    {
        public bool CreateFile(string path, string file)
        {
            if (path == null || file == null)
            {
                Console.WriteLine("Invalid Input");

                return false;
            }

            try
            {
                File.Create(Path.Combine(path, file));

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return false;
        }
    }
}