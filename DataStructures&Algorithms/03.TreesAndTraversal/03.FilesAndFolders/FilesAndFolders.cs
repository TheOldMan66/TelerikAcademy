using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace FilesAndFolders
{
    class File
    {
        public string name { get; set; }
        public int size { get; set; }
    }

    class Folder
    {

        string name;
        File[] files;
        Folder[] childFolders;

        DirectoryInfo rootDir;
        private long sumOfAllFiles = 0;

        public Folder(string path)
        {
            this.rootDir = new DirectoryInfo(path);
            WalkDirectoryTree(rootDir);
        }

        public long GetFileSize()
        {
            return sumOfAllFiles;
        }

        void WalkDirectoryTree(DirectoryInfo root)
        {
            FileInfo[] fiFiles = null;
            DirectoryInfo[] subDirs = null;

            try
            {
                fiFiles = root.GetFiles("*.*");
            }
            catch (UnauthorizedAccessException e)
            {
            }

            if (fiFiles != null)
            {
                this.files = new File[fiFiles.Length];
                for (int i = 0; i < files.Length; i++)
                {
                    files[i] = new File();
                    files[i].name = fiFiles[i].Name;
                    files[i].size = (int)fiFiles[i].Length;
                    sumOfAllFiles += fiFiles[i].Length;
                }
            }
            try
            {
                subDirs = root.GetDirectories();
            }
            catch (UnauthorizedAccessException e)
            {
            }

            if (subDirs != null)
            {
                this.childFolders = new Folder[subDirs.Length];
                for (int i = 0; i < childFolders.Length; i++)
                {
                    childFolders[i] = new Folder(this.rootDir + "\\" + subDirs[i].Name);
                    sumOfAllFiles += childFolders[i].GetFileSize();
                }
            }
        }
    }

    class FilesAndFolders
    {
        static void Main(string[] args)
        {
            Folder windows = new Folder("C:\\WINDOWS");
            Console.WriteLine(windows.GetFileSize());
        }
    }
}
