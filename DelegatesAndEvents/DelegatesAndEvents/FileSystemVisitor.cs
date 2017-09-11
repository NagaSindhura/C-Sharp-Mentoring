using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Collections.Generic;
using DelegatesAndEvents.CustomEvents;
using System.Threading;

namespace DelegatesAndEvents
{
    public class FileSystemVisitor
    {
        public List<KeyValuePair<string, string>> Files { get; set; }
        public List<string> Directories { get; set; }

        public event FileStatusEventHandler FileStatusChange;

        public FileSystemVisitor()
        {
            ParamsInitialization();
            Files = new List<KeyValuePair<string, string>>();
            Directories = new List<string>();
        }

        public FileSystemVisitor(string directoryPth)
        {
            ParamsInitialization();
            MapDirectoriesAndFiles(directoryPth);
        }

        public void ParamsInitialization()
        {
            Files = new List<KeyValuePair<string, string>>();
            Directories = new List<string>();
        }

        public void MapDirectoriesAndFiles(string directoryPath)
        {
            if (directoryPath == null)
            {
                Console.WriteLine("can't Operate on Empths");
            }

            try
            {
                Directories.Add(directoryPath);
                Directories.AddRange(
                    Directory.GetDirectories(directoryPath, "*", SearchOption.AllDirectories)?.ToList());

                MapAllFiles();
            }
            catch (DirectoryNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private void MapAllFiles()
        {
            if (Directories == null)
            {
                Console.WriteLine("Directory should not be Empty");
            }

            foreach (var directory in Directories)
            {
                foreach (var file in GetFilesToMap(directory))
                {
                    Files.Add(new KeyValuePair<string, string>(directory, file));
                }
            }
        }

        private static IEnumerable<string> GetFilesToMap(string directoryPath)
        {
            var fileInfo = Directory.EnumerateFiles(directoryPath);

            foreach (var file in fileInfo)
            {
                yield return file;
            }
        }

        public void AllFilesAndFoldersSearch()
        {
            var fileArgs = new FileArgs(null);

            if (Directories == null)
            {
                fileArgs.Message = new StringBuilder("Search Can't be Operate on Empty Directory");
                OnFileStatusChange(fileArgs);
                return;
            }

            fileArgs.Message = new StringBuilder("Search Started");
            OnFileStatusChange(fileArgs);

            var executionTime = DateTime.Now;
            var maxTimeLimit = int.Parse(ConfigurationManager.AppSettings["MaxSearchExecutionTimeInSeconds"]);

            //Abort the search if it takes more than the expexted time which is defined in the App.config file
            foreach (var direcory in Directories)
            {
                if ((DateTime.Now - executionTime).Seconds > maxTimeLimit)
                {
                    fileArgs = new FileArgs(true);
                    OnFileStatusChange(fileArgs);
                    return;
                }

                //for testing as we deal with less data
                Thread.Sleep(200);
                Console.WriteLine(direcory);
                Console.WriteLine("------------");

                try
                {
                    Directory.EnumerateFiles(direcory)
                        .Select(Path.GetFileName)
                        .Where(file => file != null)?.ToList()
                        .ForEach(Console.WriteLine);
                }
                catch (DirectoryNotFoundException e)
                {
                    Console.WriteLine(e.Message);
                }

                Console.WriteLine();
            }

            OnFileStatusChange(new FileArgs(new StringBuilder("Search Completed")));
        }

        public void FilesAndFoldersDelete(string searchKey)
        {

            if (Directories == null)
            {
                return;
            }

            var files = GetMatchedFiles(searchKey, true);

            files.ToList().ForEach(
                p =>
                    {
                        OnFileStatusChange(new FileArgs(new StringBuilder(p + "id deleted")));
                        new FileInfo(p).Delete();
                    });

            var dir1 = GetMatchedDirectories(searchKey, true);

            try
            {
                dir1.ToList().ForEach(
                    p =>
                        {
                            OnFileStatusChange(new FileArgs(new StringBuilder(p + "id deleted")));
                            var dir = new DirectoryInfo(p);
                            dir.Attributes = dir.Attributes & ~FileAttributes.ReadOnly;

                            dir.Delete(true);
                        });
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void SearchFileOrDirectory(string searchKey, bool include)
        {
            if (Files == null && Directories == null)
            {
                OnFileStatusChange(new FileArgs(new StringBuilder("Empty Dierectory")));
            }

            Console.WriteLine("Matched Files");
            Console.WriteLine("--------------");

            var filesList = GetMatchedFiles(searchKey, include);

            if (filesList.ToList().Count == 0)
            {
                OnFileStatusChange(new FileArgs(new StringBuilder("Empty Matched Folders")));
            }
            else
            {
                filesList.ToList()
                    .ForEach(p => OnFileStatusChange(new FileArgs(new StringBuilder(p))));
            }

            Console.WriteLine("Matched Directories");
            Console.WriteLine("--------------");

            var directoryList = GetMatchedDirectories(searchKey, include);

            if (directoryList.ToList().Count == 0)
            {
                OnFileStatusChange(new FileArgs(new StringBuilder("Empty Matched Directories")));
            }
            else
            {
                directoryList.ToList().ForEach(p => OnFileStatusChange(new FileArgs(new StringBuilder(p))));
            }
        }

        public IEnumerable<string> GetMatchedFiles(string searchKey, bool IsInclude)
        {
            return
                 Files.Where(
                         file =>
                             IsInclude
                             && file.Value.IndexOf(Path.GetFileName(searchKey), StringComparison.OrdinalIgnoreCase) > 0)
                     .Select(p => Path.Combine(p.Key, p.Value));
        }

        public IEnumerable<string> GetMatchedDirectories(string searchKey, bool IsInclude)
        {
            return
                Directories.Where(
                    Directory =>
                        IsInclude
                        && new DirectoryInfo(Directory).Name.IndexOf(searchKey, StringComparison.OrdinalIgnoreCase) >= 0);
        }

        public virtual void OnFileStatusChange(FileArgs e)
        {
            if (FileStatusChange != null)
            {
                FileStatusChange(this, e);
            }
        }
    }
}