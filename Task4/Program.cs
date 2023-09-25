using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Task4
{
    class MyClass
    {
        public void Operation()
        {
            Thread.Sleep(2000);
            Console.WriteLine("Основная задача");
        }

        public async Task OperationAsync()
        {
            await Task.Factory.StartNew(Operation);
        }

    }

    class Program
    {
        static void Main()
        {
            MyClass my = new MyClass();
            Task task = my.OperationAsync();

            task.ContinueWith(t => Console.WriteLine("\nПродолжение задачи."));

            Console.ReadKey();
        }
    }
}