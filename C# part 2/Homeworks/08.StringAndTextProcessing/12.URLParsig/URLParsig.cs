using System;

/* Write a program that parses an URL address given in the format:
 *      
 * [protocol]://[server]/[resource]
 * 
 * and extracts from it the [protocol], [server] and [resource] elements. For example 
 * from the URL http://www.devbg.org/forum/index.php the following information should be extracted:
		[protocol] = "http"
		[server] = "www.devbg.org"
		[resource] = "/forum/index.php" */

    class URLParsig
    {
        static void Main()
        {
            string url = @"http://www.devbg.org/forum/index.php";
//            string url = @"ftp://stackoverflow.com/questions/2715710";
            Console.WriteLine("[URL] = {0}",url);
            int protocolIndex= url.IndexOf("://");
            string protocol = url.Substring(0, protocolIndex);
            Console.WriteLine("[protocol] = {0}",protocol );
            int serverIndex = url.IndexOf("/",protocolIndex+3);
            string server = url.Substring(protocolIndex + 3, serverIndex - protocolIndex - 3);
            Console.WriteLine("[server] = {0}", server);
            string resource = url.Substring(serverIndex);
            Console.WriteLine("[resource] = {0}", resource);
            

            // or simple way to do all this :)

            Console.WriteLine();
            Console.WriteLine("Alterantive way to do this:");
            Uri myUri = new Uri(url);
            Console.WriteLine("[protocol] = {0}", myUri.Scheme);
            Console.WriteLine("[server] = {0}", myUri.Host);
            Console.WriteLine("[resource] = {0}", myUri.AbsolutePath);
        }
    }