using System;
using System.IO;
using System.Net;

namespace YesNoParser.Cli
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("missing parameter: path_to_resource (web or local)");
                Console.WriteLine("press any key to quit");
                Console.ReadKey();
                return;
            }
            var path = args[0];
            var text = GetString(path);
            var decoded = WebUtility.HtmlDecode(text);
            var parser = new YesNoParser('>', '<');
            var parsed = parser.Parse(decoded);
            var fileName = GetSafeFileName(path) + ".txt";
            File.WriteAllText(fileName, parsed);
            Console.WriteLine(fileName);
            Console.WriteLine("press any key to quit");
            Console.ReadKey();
        }

        static string GetSafeFileName(string path)
        {
            foreach (var c in Path.GetInvalidFileNameChars())
            {
                path = path.Replace(c, '-');
            }
            return path;
        }

        static string GetString(string path)
        {
            if (path.StartsWith("http://") || path.StartsWith("https://"))
            {
                return GetWebString(path);
            }
            else
            {
                return GetLocalString(path);
            }
        }

        static string GetWebString(string url)
        {
            var webRequest = WebRequest.Create(url);
            using (var response = webRequest.GetResponse())
            using (var content = response.GetResponseStream())
            using (var reader = new StreamReader(content))
            {
                return reader.ReadToEnd();
            }
        }

        static string GetLocalString(string fileName)
        {
            return File.ReadAllText(fileName);
        }
    }
}
