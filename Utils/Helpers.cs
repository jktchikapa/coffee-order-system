using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeManagementSystem.Utils
{
    internal class Helpers
    {
        public void GenerateMenu(string[] options)
        {
            if (options.Length > 0)
            {
                Console.WriteLine("Please select an option : ");
                for (int i = 0; i < options.Length; i++)
                {
                    Console.WriteLine($"{i + 1}. {options[i]}");
                }
                Console.WriteLine("Your choice : ");
            }
        }
    }
}
