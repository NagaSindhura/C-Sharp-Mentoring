using System;
using System.Configuration;
using DelegatesAndEvents.CustomEvents;

namespace DelegatesAndEvents
{
    public class Program
    {
        public static void Main()
        {
            var fileSystemVisitor = new FileSystemVisitor();
            fileSystemVisitor.MapDirectoriesAndFiles(@"C:\Users\Naga_Pulivarthy\Documents\temp");

            fileSystemVisitor.FileStatusChange += FileStatus;

            fileSystemVisitor.AllFilesAndFoldersSearch();

            fileSystemVisitor.SearchFileOrDirectory(ConfigurationManager.AppSettings["IncludeFilePatteren"], true);
            fileSystemVisitor.SearchFileOrDirectory(ConfigurationManager.AppSettings["ExcludeFolderPatteren"], false);

            Console.WriteLine();
            Console.WriteLine("Files/Folders Deleted including the sub folders if exists");

            var fileSystemVisitor1 = new FileSystemVisitor(@"C:\Users\Naga_Pulivarthy\Documents\temp");
            Console.WriteLine("----------------");

            fileSystemVisitor1.FileStatusChange += FileStatus;
            fileSystemVisitor1.FilesAndFoldersDelete("zip");

            Console.ReadLine();
        }

        public static void FileStatus(object o, FileArgs e)
        {
            Console.WriteLine(e.IsAborted ? "***********Search Aborted due to Timeouts************** \n" : e.Message.ToString());
        }
    }
}