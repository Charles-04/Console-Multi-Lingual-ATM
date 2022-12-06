using System.Text;

namespace AutoTellerMachine
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.OutputEncoding = Encoding.UTF8;
            Console.Title = "Truthy Bank";
            Atm util = new();
            util.Init();

           
        }
    }
}