using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamLib
{
    internal class MenuFilters
    {
        public static void MenuForFilters()
        {
            Console.WriteLine("1 - Add book");
            long userChoice = Int64.Parse(Console.ReadLine());
            switch (userChoice)
            {
                case 1:
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please select a valid option.");
                    break;
            }
        }
    }
}
