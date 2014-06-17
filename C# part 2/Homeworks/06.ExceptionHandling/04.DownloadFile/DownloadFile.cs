using System;
using System.IO;
using System.Net;

/* Write a program that downloads a file from Internet (e.g. http://www.devbg.org/img/Logo-BASD.jpg) 
 * and stores it the current directory. Find in Google how to download files in C#. 
 * Be sure to catch all exceptions and to free any used resources in the finally block. */

namespace _04.DownloadFile
{
    class DownloadFile
    {
        static void Main()
        {
            string sourceResource = "http://www.devbg.org/img/Logo-BASD.jpg";
            string localFileName = Path.GetFileName(sourceResource);
            using (WebClient myWebClient = new WebClient())
            {
                try
                {
                    Console.WriteLine("Start downloading {0}", sourceResource);
                    myWebClient.DownloadFile(sourceResource, localFileName);
                    Console.WriteLine("Download succesfull.");
                }
                catch (WebException ex)
                {
                    Console.Write(ex.Message);
                    if (ex.InnerException != null)
                        Console.WriteLine(" " + ex.InnerException.Message);
                    else
                        Console.WriteLine();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Something going wrong. Details: " + ex.Message);
                }
            }

        }
    }
}
