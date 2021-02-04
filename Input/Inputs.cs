using System;

namespace Inputs
{
    public class NumbersInput
    {
        public static int Integer(string inputName)
        {
            int number;
            do
            {
                if (int.TryParse(Console.ReadLine(), out number)) break;
                else
                {
                    Console.WriteLine("Error! Rewrite number!");
                    Console.Write($"{inputName}: ");
                }
            } while (true);

            return number;
        }

        public static double Double(string inputName)
        {
            double number;
            do
            {
                if (double.TryParse(Console.ReadLine(), out number)) break;
                else
                {
                    Console.WriteLine("Error! Rewrite number!");
                    Console.Write($"{inputName}: ");
                }
            } while (true);

            return number;
        }
    }

    public class StringInput
    {
        public static string InputGender()
        {
            do
            {
                string text = InputStringWithLettersOnly("Gender: ");
                text = text.ToLower();
                if(text.Equals("male") || text.Equals("man") || text.Equals("m"))
                {
                    return "Male";
                }
                else if(text.Equals("female") || text.Equals("woman") || text.Equals("w") || text.Equals("f"))
                {
                    return "Female";
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Error!");
                    Console.ResetColor();
                    Console.WriteLine("Please input gender of the person");
                }
            } while (true);
            
            
        }

        public static string InputStringWithLettersOnly(string inputName)
        {
            string text;
            do
            {
                text = Console.ReadLine();
                if (IsLettersInStringOnly(text)) break;
                else
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Error!");
                    Console.ResetColor();
                    Console.Write($"{inputName}: ");
                }
            } while (true);
            return text;
        }

        private static bool IsLettersInStringOnly(string text)
        {
            bool isLettersOnly = true;
            for (int i = 0; i < text.Length - 1; i++)
            {
                bool isDigit = Char.IsDigit(text[i]);
                if (isDigit)
                {
                    isLettersOnly = false;
                    break;
                }
            }
            return isLettersOnly;
        }
    }

    public class BoolInput
    {
        public static bool YesOrNo()
        {
            do
            {
                string choice;
                choice = StringInput.InputStringWithLettersOnly("Choice: ");

                choice.ToLower();
                if (choice.Equals("yes") || choice.Equals("y"))
                {
                    return true;
                }
                else if(choice.Equals("no") || choice.Equals("n"))
                {
                    return false;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Error!");
                    Console.ResetColor();
                }
            } while (true);

        }
    }
}