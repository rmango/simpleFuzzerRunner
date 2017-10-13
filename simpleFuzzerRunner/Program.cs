using System;
using System.Net;
using System.IO;
using System.Text;
using System.Diagnostics;
using System.Threading;

namespace simpleFuzzerRunner
{
    class Program
    {
        public static int index = 0;

        //Webserver taken from: https://codehosting.net/blog/BlogEngine/post/Simple-C-Web-Server
        static void Main(string[] args)
        {
            //creates 5 new files
            Process.Start("C:\\Users\\Morga\\Documents\\Github\\simpleFuzzer\\simpleFuzzer\\obj\\Debug\\simpleFuzzer.exe");
            Console.ReadKey();
            //does this 5 times w/5 different files
            for (int i = 0; i < 5; i++)
            {
                WebServer ws = new WebServer(SendResponse, "http://DESKTOP-KH1JALG:28876/");
                ws.Run();
                Console.WriteLine("A simple webserver. Press a key to quit.");
                Process.Start("C:\\Users\\Morga\\Documents\\Github\\BugId\\BugId.cmd", "msie --nApplicationMaxRunTime=10");

                //wait for 12 seconds
                Thread.Sleep(12000);

                ws.Stop();
                index++;
            }
        }

        public static string SendResponse(HttpListenerRequest request)
        {
            Console.WriteLine("Running on fuzzTest_" + index + ".html");
            return System.IO.File.ReadAllText(@"C:\Users\Morga\Documents\Github\simpleFuzzer\fuzzTest_" + index + ".html");
        }
    }
}
