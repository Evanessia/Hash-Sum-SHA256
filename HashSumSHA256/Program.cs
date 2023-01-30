using System;
using System.IO;

using System.Security.Cryptography;

namespace HashSumSHA256
{
    class Program
    {
        static void Main(string[] args)
        {
            //args = new string[1];

            //args[0] = "Sample.jpg";
            
            if (args.Length == 0)
            {
                Console.WriteLine("No arguments passed to the program!");

                Console.WriteLine("Press key...");

                Console.ReadKey();

                Environment.Exit(0);
            }

            if (!File.Exists(args[0]))
            {
                Console.WriteLine("File does not exist at the specified path!");

                Console.WriteLine("Press key...");

                Console.ReadKey();

                Environment.Exit(0);
            }
            
            SHA256 MyHash = SHA256.Create();

            byte[] HashSum = MyHash.ComputeHash(new StreamReader(args[0]).BaseStream);

            string str = "";

            foreach(byte k in HashSum)
            {
                str += $"{k:X2}";
            }
            
            Console.Write("Hash sum:");

            for(int i = 0; i < str.Length; i++)
            {
                if (i % 4 == 0)
                {
                    Console.Write(" ");
                }

                Console.Write(str[i]);
            }

            //

            MyHash.Dispose();

            //
            
            Console.WriteLine("\n==============================");

            Console.Write("Save result to file (Y-Yes, N-No)? ");

            bool t = false;

            ConsoleKeyInfo keyNow;

            int left = Console.CursorLeft;

            int top = Console.CursorTop;
            
            do
            {
                keyNow = Console.ReadKey();

                switch (keyNow.Key)
                {

                    case ConsoleKey.Y:
                        {
                            t = true;

                            string name = "Results " + DateTime.Now.ToShortDateString() + ".txt";

                            StreamWriter _file = new StreamWriter(name, true);

                            _file.WriteLineAsync(DateTime.Now.ToLongTimeString() + " (" + Path.GetFileName(args[0]) + ") " + str);

                            _file.Close();

                            _file.Dispose();
                        }
                        break;
                    case ConsoleKey.N:
                        {
                            t = true;
                        }
                        break;
                    default:
                        {
                            Console.SetCursorPosition(left, top);
                        }
                        break;
                }

            } while (!t);
            
            Console.WriteLine("\nPress key...");

            Console.ReadKey();
        }
    }
}