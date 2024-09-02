using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SF_CS_005
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Напишите фразу");
            string SomeString = Console.ReadLine();

            Console.WriteLine("Укажите глубину эха");
            var Deep = int.Parse(Console.ReadLine());

            Console.WriteLine(SomeString);
            Echo(SomeString, Deep);

            Console.ReadKey();
        }

        static void Echo(string IncomeString, int Deep, string MissingLetters = "")
        {
            string NextString = IncomeString;

            if (NextString.Length > 1)
            {
                if (NextString.Length == 1)
                {
                    MissingLetters = MissingLetters + ".";
                } else
                {
                    MissingLetters = MissingLetters + "..";
                }

                NextString = NextString.Remove(0, Math.Min(NextString.Length, 2));
            }
            else
            {
                return;
            }

            Console.WriteLine("{0}{1}", MissingLetters, NextString);

            if (Deep > 1)
            {
                Echo(NextString, Deep - 1, MissingLetters);
            }
        }
    }
}
