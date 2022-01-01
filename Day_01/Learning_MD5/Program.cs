using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning_MD5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Username: ");
                var userInput = Console.ReadLine();

                var result = CryptMD5.EnryptEm(userInput);

                Console.WriteLine(result);
            }
        }
    }
}
