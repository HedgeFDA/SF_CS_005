using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SF_CS_005
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Напишите вразу");
            string SomeString = Console.ReadLine();

            Console.WriteLine("Укажите глубину эха");
            var Deep = int.Parse(Console.ReadLine());

            Echo(SomeString, Deep);

            Console.ReadKey();
        }

        static void Echo(string IncomeString, int Deep, int Step = 1)
        {
            string NextString = IncomeString;

            if (NextString.Length > 1)
            {
                NextString = NextString.Remove(0, Math.Min(NextString.Length, 1));
            }
            else
            {
                return;
            }

            string MissingLetters = "";
            for (int i = 0; i < Step; i++)
            {
                MissingLetters = MissingLetters + ".";
            }

            Console.WriteLine("{0}{1}", MissingLetters, NextString);

            if (Deep > 1)
            {
                Echo(NextString, Deep - 1, Step + 1);
            }
        }
    }
}
