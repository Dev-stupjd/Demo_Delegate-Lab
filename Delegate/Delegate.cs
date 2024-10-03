using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegate
{
    public delegate T Operation<T>(T a, T b);
    public delegate void MyDele(int value);
    public delegate int MyDelegate(int numOne, int numTwo);
    public delegate void MyDelegate2(string msg);
    public class MyClass
    {
        public static void Print(string msg) => Console.WriteLine($"{msg.ToUpper()}");
        public static void Show(string msg) => Console.WriteLine($"{msg.ToLower()}");
        public static void Display(string msg) => Console.WriteLine($"{msg}");
    }
}
