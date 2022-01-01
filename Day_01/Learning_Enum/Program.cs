using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning_Enum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(LearningEnum.Roles.GodMode);
            Console.WriteLine(LearningEnum.Roles.Admin);
            Console.WriteLine(LearningEnum.Roles.User.GetType());

            Console.Read();
        }
    }
}
