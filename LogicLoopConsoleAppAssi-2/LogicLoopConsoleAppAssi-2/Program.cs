using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLoopConsoleAppAssi_2
{
    class Program
    {
        static void Main(string[] args)
        {
            int i, number, fact;
            Console.WriteLine("Enter the Number");
            number = int.Parse(Console.ReadLine());
            fact = number;
            string factor = "";
            for (i = number - 1; i >= 1; i--)
            {
                fact = fact * i;
                //set factor for first value
                if (i == (number - 1))
                {
                    factor = Convert.ToString(number) + "*" + i;
                }
                else
                {
                    factor = factor + "*" + i;
                }

            }
            Console.WriteLine("\nFactorial of " + number + " is " + factor + " = " + fact);
            Console.ReadLine();
        }
    }
}
