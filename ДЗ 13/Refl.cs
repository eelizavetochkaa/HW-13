using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ДЗ_13
{
    internal class Refl
    {
        static void Main(string[] args)
        {
            Refl refl = new Refl();
            GetMethods(refl);
        }

        public static void GetMethods(object obj)
        {
            Type type = obj.GetType();
            MethodInfo[] methods = type.GetMethods();

            foreach (MethodInfo method in methods)
            {
                Console.WriteLine(method.Name);
            }
        }

        public string Output()
        {
            return "Результат";
        }

        public int AddInts(int a, int b)
        {
            return a + b;
        }
    }
}
