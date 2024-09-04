using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SF_CS_005
{
    internal class Program
    {
        static string[] GetAvailableColors() => new string[3] { "red", "cyan", "green" };

        static bool IsCorrectColorValue(string Color) => (Array.IndexOf(GetAvailableColors(), Color) >= 0);

        static bool IsCorrectIntegerValue(string StringValue, out int IntegerValue) => int.TryParse(StringValue, out IntegerValue);

        static string InputStringValue(string Message)
        {
            Console.Write(Message);
            return Console.ReadLine();
        }

        static int InputIntegerValue(string Message, bool NeedCheckZero = false)
        {
            int Value = 0;

            do 
            {
                bool CorrectIntegerValue = IsCorrectIntegerValue(InputStringValue(Message), out Value);
                
                if (!CorrectIntegerValue)
                    Console.WriteLine("   необходимо ввести числовое значение");
                else if (NeedCheckZero & Value <= 0) 
                    Console.WriteLine("   введенное значение должно быть больше 0");
                else break;
            } while (true);

            return Value;
        }

        static bool InputBooleanValue(string Message)
        {
            string Value = "";

            do
            {
                Value = InputStringValue(Message).ToLower();

                if (Value != "да" & Value != "нет")
                    Console.WriteLine("   необходимо ввести значение Да или Нет");
                else break;
            } while (true);

            return (Value == "да");
        }

        static string[] GetPetNames(int NumberOfPets)
        {
            string[] Pets = new string[NumberOfPets];

            for (int i = 0; i < NumberOfPets; i++) Pets[i] = InputStringValue($"Введите имя питомца {i + 1}: ");
            
            return Pets;
        }

        static string[] GetColors(int NumberOfPets)
        {
            string[] Colors = new string[NumberOfPets];

            for (int i = 0; i < NumberOfPets; i++)
            {
                string Value = "";

                do
                {
                    Value = InputStringValue($"Напишите свой любимый цвет {i + 1} (red, cyan, green): ").ToLower();

                    if (!IsCorrectColorValue(Value))
                        Console.WriteLine("   необходимо ввести название цвета (red, cyan, green)");
                    else break;
                } while (true);

                Colors[i] = Value;
            }

            return Colors;
        }

        static (string Name, string Surname, int Age, bool HaveAPets, string[] PetNames, string[] Colors) GetUserData()
        {
            string Name         = InputStringValue("Введите имя: ");
            string Surname      = InputStringValue("Введите фамилию: ");
            int Age             = InputIntegerValue("Введите возраст: ", true);
            bool HaveAPets      = InputBooleanValue("Есть домашние животные (да или нет): ");
            string[] PetNames   = new string[0];
            string[] Colors     = new string[0];

            if (HaveAPets) PetNames = GetPetNames(InputIntegerValue("Количество домашних животных: ", true));

            int NumberOfColors = InputIntegerValue("Количество любимых цветов: ");

            if (NumberOfColors > 0) Colors = GetColors(NumberOfColors);

            return (Name, Surname, Age, HaveAPets, PetNames, Colors);
        }

        static void ShowUserData((string Name, string Surname, int Age, bool HaveAPets, string[] PetNames, string[] Colors) User)
        {
            Console.WriteLine($"\nИмя: {User.Name}\nФамилия: {User.Surname}\nВозраст: {User.Age}");
            
            if (User.HaveAPets)
            {
                Console.WriteLine("Домашние животные:");

                for (int i = 0; i < User.PetNames.Length; i++) Console.WriteLine($"   {i + 1}: {User.PetNames[i]}");
            } else Console.WriteLine("Домашних животных нет.");

            if (User.Colors.Length > 0)
            {
                Console.WriteLine("Любимые цвета:");

                Console.ForegroundColor = ConsoleColor.Black;
                for (int i = 0; i < User.Colors.Length; i++)
                {
                    switch (User.Colors[i])
                    {
                        case "red":
                            Console.BackgroundColor = ConsoleColor.Red;
                            Console.ForegroundColor = ConsoleColor.Black;
                            break;
                        case "green":
                            Console.BackgroundColor = ConsoleColor.Green;
                            Console.ForegroundColor = ConsoleColor.Black;
                            break;
                        case "cyan":
                            Console.BackgroundColor = ConsoleColor.Cyan;
                            Console.ForegroundColor = ConsoleColor.Black;
                            break;
                        default:
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.ForegroundColor = ConsoleColor.White;
                            break;
                    }

                    Console.WriteLine($"   {i + 1}: {User.Colors[i]}");
                }
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        static void Main(string[] args)
        {
            var User = GetUserData();

            ShowUserData(User);
            
            Console.ReadKey();
        }

       }
}
