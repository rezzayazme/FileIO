using System;
using static System.Console;
using System.IO;
using System.Collections.Generic;
using System.Net;

namespace FileIO
{
    class Program
    {
        public static void Main(string[] args)
        {
            const string FILENAME = "Numbers.txt";
            string line;

            StreamReader reader = new StreamReader(FILENAME);

            string[] recordIn = File.ReadAllLines(FILENAME);

            while ((line = reader.ReadLine()) != null)
            {
                int i = 0;
                recordIn[i] = line;
                i++;
            }

            int numberIn;
            reader.Close();

            List<int> odd = new List<int>();
            List<int> even = new List<int>();


            for (int i = 0; i < recordIn.Length; i++)
            {

                numberIn = Convert.ToInt32(recordIn[i]);

                if (numberIn % 2 == 0)
                {
                    even.Add(numberIn);

                }
                else
                {
                    odd.Add(numberIn);
                }

            }




            string Odd = string.Join(",", odd.ToArray());
            string Even = string.Join(",", even.ToArray());

            Console.WriteLine("Odd Numbers are: ");
            using (FileStream fs = File.OpenWrite("Odd.txt"))
            {
                StreamWriter sw = new StreamWriter(fs);

                for (int i = 0; i < Odd.Length; i++)
                {
                    Console.Write(Odd[i]);
                }
            }
            File.WriteAllText(@"Odd.txt", Odd);


            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("Even Numbers are: ");
            using (FileStream fs = File.OpenWrite("Even.txt"))
            {
                StreamWriter sw = new StreamWriter(fs);

                for (int i = 0; i < Even.Length; i++)
                {
                    Console.Write(Even[i]);
                }
            }
            File.WriteAllText(@"Even.txt", Even);

        }
    }
}
