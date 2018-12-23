using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Dice
{
    /// <summary>
    /// Thow dice.
    /// -----------------------------------------------------------
    /// Equation used in this task: xDy+z
    /// Where:
    /// x - number of throws
    /// y - dice type (D10)
    /// z - number added or substacted from sum of throws
    /// -----------------------------------------------------------
    /// Further to do:
    /// - input validation
    /// - dice validation (0 or 1)
    /// - omit parameter diceThrows in equestion if diceThrow == 1
    /// - solve issue with '+', '-' signs
    /// </summary>
    class Program
    {
        static string diceType = string.Empty;
        static string diceModyficator = string.Empty;
        static int diceThrows = 0;


        static void Main(string[] args)
        {
            // --------------------------------------------------
            // Simple Interface:
            // (- No input validation! -)
            //
            Console.WriteLine("Throw A Dice");
            Console.WriteLine("================================");
            Console.WriteLine("Enter type of a dice (ex. D10):  "); 
            diceType = Console.ReadLine();
            Console.WriteLine("--------------------------------");
            Console.WriteLine("Enter number of throws:  ");
            diceThrows = Int32.Parse(Console.ReadLine());
            Console.WriteLine("--------------------------------");
            Console.WriteLine("Enter dice modyficator (ex. +10 or -1):  ");
            diceModyficator = Console.ReadLine();
            Console.WriteLine("================================");

            // --------------------------------------------------
            // Make a dice...
            //

            // convert string into int, remove "D"
            diceType = Regex.Replace(diceType, @"(D)", "");
            int diceTypeInt = Int32.Parse(diceType);

            // No validation if a dice starts from 0 or 1,
            // On the purpose of this example assume dice starts from 0.
            List<string> diceWalls = new List<string>();
            for (int i = 0; i < diceTypeInt ; i++)
            {
                diceWalls.Add(i.ToString());
            }

            // --------------------------------------------------
            // Thow a dice
            // 
            int throwsSum = 0;
            for (int i = 0; i < diceThrows; i++)
            {
                throwsSum = throwsSum + ThrowADice(diceWalls);
            }

            // --------------------------------------------------
            // Get a modificator
            // 
            string sign = GetSign(diceModyficator);
            int modificatorNumber = GetNumber(diceModyficator);

            // --------------------------------------------------
            // Simulation: equation: xDy+z
            // 
            int equation = 0;
            switch (sign)
            {
                case "+":
                    equation = throwsSum + modificatorNumber;
                    break;
                case "-":
                    equation = throwsSum - modificatorNumber;
                    break;
                default:
                    equation = 0;
                    break;
            }

            // --------------------------------------------------
            // Return equation: 
            // 
            Console.WriteLine(string.Format("Throwed number is: {0}", equation));

            // --------------------------------------------------
            // Stop terminating window...
            //
            Console.WriteLine();
            Console.WriteLine("Hit <Enter> to close the program.");
            Console.ReadLine();
        }


        static int ThrowADice(List<String> walls)
        {

            Random r = new Random();

            int throwing = r.Next(walls.Count);
            String mesh = walls[throwing];

            int meshInt = Int32.Parse(mesh);

            return meshInt;
        }

        static string GetSign(string diceModyficator) {

            return diceModyficator[0].ToString();
        }

        static int GetNumber(string diceModyficator)
        {
            int number = 0;
            if(diceModyficator[0] == '+' || diceModyficator[0] == '-')
            {
                number = Int32.Parse(diceModyficator.Remove(0, 1));
            }

            return number;
        }

    }
}
