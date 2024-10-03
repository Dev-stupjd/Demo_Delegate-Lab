namespace Delegate
{
    public class Program
    {
        static int Add(int numOne, int numTwo) => numOne + numTwo;
        static int Subtract(int numOne, int numTwo) => numOne - numTwo;
        static void InvokeDelegate(MyDelegate2 dele, string msg) => dele(msg);
        static Operation<double> add = (a, b) => a + b;
        static Operation<double> subtract = (a, b) => a - b;
        static Operation<double> multiply = (a, b) => a * b;
        static Operation<double> divide = (a, b) => b != 0 ? a / b : throw new DivideByZeroException();

        static void Main(string[] args)
        {
            while (true)
            {
                string msg = string.Empty;
                Console.WriteLine("1. Demo Instantiating Delegates");
                Console.WriteLine("2. Demo Passing Delegate as a Parameter");
                Console.WriteLine("3. Demo Multicast Delegate");
                Console.WriteLine("4. Demo Anonymous Method");
                Console.WriteLine("5. Calculator");
                Console.WriteLine("6. Exit");
                Console.Write("Enter your choice: ");
                int choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Instantiating Delegates");
                        int n1 = 25;
                        int n2 = 15;
                        int result;
                        MyDelegate obj1 = new MyDelegate(Add);
                        result = obj1(n1, n2);
                        Console.WriteLine($"{n1} + {n2} = {result}");
                        MyDelegate obj2 = Subtract;
                        result = obj2(n1, n2);
                        Console.WriteLine($"{n1} - {n2} = {result}");
                        Console.ReadLine();
                        break;
                    case 2:
                        Console.WriteLine("Passing Delegate as a Parameter");
                        msg = "Hello World!";
                        InvokeDelegate(MyClass.Print, msg);
                        InvokeDelegate(MyClass.Show, msg);
                        Console.ReadLine();
                        break;
                    case 3:
                        Console.WriteLine("Multicast Delegate");
                        msg = "Multicast Delegate";
                        MyDelegate2 Mydele01 = MyClass.Print;
                        MyDelegate2 Mydele02 = MyClass.Show;
                        Console.WriteLine("***Combines Mydele01 + Mydele02***");
                        MyDelegate2 Mydele03 = Mydele01 + Mydele02;
                        Mydele03(msg);
                        Console.WriteLine("***Combines Mydele01 + Mydele02 + Mydele03***");
                        MyDelegate2 Mydele04 = MyClass.Display;
                        Mydele03 += Mydele04;
                        Mydele03(msg);
                        Console.WriteLine("----------------------");
                        Console.WriteLine("***Removes Mydele02***");
                        Mydele03 -= Mydele02;
                        Mydele03("Hello World!");
                        Console.ReadLine();                     
                        break;
                    case 4:
                        Console.WriteLine("Anonymous Method");
                        MyDele printValue = delegate (int value)
                        {
                            Console.WriteLine($"Inside Anonymous method. Value: {value}");
                        };
                        printValue += delegate
                        {
                            Console.WriteLine("This is Anonymous Method");
                        };
                        printValue(100);
                        Console.ReadLine();
                        break;
                    case 5:
                        try
                        {
                            Console.WriteLine("Calculation");
                            Console.Write("Enter number 1: ");
                            double x = Convert.ToDouble(Console.ReadLine());
                            Console.Write("Enter number 2: ");
                            double y = Convert.ToDouble(Console.ReadLine());
                            Console.WriteLine($"Addition: {x} + {y} = {add(x, y)}");
                            Console.WriteLine($"Subtraction: {x} - {y} = {subtract(x, y)}");
                            Console.WriteLine($"Multiplication: {x} * {y} = {multiply(x, y)}");
                            Console.WriteLine($"Division: {x} / {y} = {divide(x, y)}");
                            Console.ReadLine();
                        }
                        catch(Exception e)
                        {
                            Console.WriteLine(e);
                        }
                        break;
                    case 6:
                        Environment.Exit(0);
                        break;

                }
            }
        }

    }
}
