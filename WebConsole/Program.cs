using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using WebConsole.CRUD;

namespace WebConsole
{
    class Program
    {
        public const string APP_PATH = "http://localhost:49277/api/Data";
        static void Main(string[] args)
        {
            MenuLoop();
        }

        static void MenuLoop()
        {

            bool isExit = true;

            while (isExit)
            {
                Console.Clear();
                Console.WriteLine("Choose an option:");
                Console.WriteLine("1) Add the datetime range");
                Console.WriteLine("2) Request datetime range");
                Console.WriteLine("3) Request all dates");
                Console.WriteLine("4) Exit");
                Console.Write("\r\nSelect an option: ");
                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        Add(new PutAction().Call(Input()));
                        break;
                    case "2":
                        GetRange(new PostAction().Call(Input()));
                        break;
                    case "3":
                        GetRange(new GetAction().Call());                      
                        break;
                    case "4":
                    default: isExit = false; break;
                }
            }
        }

        private static void Add(List<string> lists)
        {
            foreach (var item in lists)
            {
                Console.WriteLine(item);
            }
            Pause(); 
        }

        private static string Input()
        {          
            Console.Write("\r\nInput range date divided by / [ 1999-01-01/1999-01-02 ] : ");
            return Console.ReadLine();
        }
        static void GetRange(List<string> listRange)
        {
            if (listRange == null || listRange.Count == 0)
            {
                Console.WriteLine("No records");
                Pause();
                return;
            }
            foreach (var item in listRange)
            {
                Console.WriteLine(item);
            }
            Pause();
        }

        private static void Pause()
        {
            Console.ReadKey();
        }

        public static void Messages(string message)
        {
            Console.WriteLine(message);
            Pause();
        }
    }
}
