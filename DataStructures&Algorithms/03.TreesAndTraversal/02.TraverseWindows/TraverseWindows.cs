using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FindAllExe_s
{

    /* Write a program to traverse the directory C:\WINDOWS and all its subdirectories recursively and to display 
     * all files matching the mask *.exe. Use the class System.IO.Directory. */

    public class RecursiveFileSearch
    {
        static void WalkDirectoryTree(DirectoryInfo root)
        {
            FileInfo[] files = null;
            DirectoryInfo[] subDirs = null;

            try
            {
                files = root.GetFiles("*.EXE");
            }
            catch (UnauthorizedAccessException e)
            {
            }

            if (files != null)
            {
                foreach (FileInfo fi in files)
                {
                    Console.WriteLine(fi.FullName);
                }

                subDirs = root.GetDirectories();
                foreach (DirectoryInfo dirInfo in subDirs)
                {
                    WalkDirectoryTree(dirInfo);
                }
            }
        }
        static void Main()
        {
            DirectoryInfo rootDir = new DirectoryInfo("C:\\WINDOWS");
            WalkDirectoryTree(rootDir);
        }
    }
}
