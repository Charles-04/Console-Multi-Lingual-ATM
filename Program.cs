using System.Text;

namespace AutoTellerMachine
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.OutputEncoding = Encoding.UTF8;
            Atm util = new();
             util.Init();

           /* Account account = new();
            account.GetBalance();
           
            account.GetBalance();
            account.Withdraw(4000);
            account.GetBalance();*/
        }
    }
}