
using static AutoTellerMachine.Atm;

namespace AutoTellerMachine
{
    internal class IgboLanguageSelection
    {
        Account account = new();
        Atm atm = new();
        
       internal void MachineOperations()
        {
            Console.WriteLine("tinye nomba akauntu gi");
            long.TryParse(Console.ReadLine(), out long accountNumber);

            Console.WriteLine("Tinye pin gi ebe a");
            int.TryParse(Console.ReadLine(), out int pin);
            if (account.Validate(pin, accountNumber))
            {
                Console.Clear();
                Console.WriteLine($"Nnoo  {account._lastName} {account._firstName} \n");
                
                OperationOptions();
            }
            else
            {
                Console.WriteLine("pin maobu akauntu nomba gi ezighi ezi, Tinye ya ozo");
                MachineOperations();
            }
        }
        internal void OperationOptions()
        {
            Console.WriteLine("Gini ka I choro I me\n");
            Console.WriteLine("\n1 : I nweputa Ego \n2 : Itinyere mmadu ego \n3 : I choputa ego ole I nwere \n4 : Puo \n0 : Laghachie azu");

            int.TryParse((Console.ReadLine()), out int Option);

            switch (Option)
            {
                case 0:
                    Console.Clear();
                    atm.Init();
                    break;

                case 1:
                    Console.Clear();
                    Console.WriteLine("I nweputa ego ");
                    Console.WriteLine("Ego one ka I choro I nweputa");
                    var isAmountValid = double.TryParse((Console.ReadLine()), out double amount);
                    if (amount <= account.AccountBalance && isAmountValid && amount > (int)CommonNumbers.zero)
                    {
                        account.Withdraw(amount);

                        Console.WriteLine("Mwepu gara nke oma ✅✅");
                        Console.WriteLine($"Ego gi foro {account.AccountBalance} ");

                    }
                    else
                    {
                        Console.WriteLine("Ego gi ezugi ezu😒😒 maobu ozighi ezi");
                        ContinueTransaction();
                    }
                     break;

                case 2:
                    Console.Clear();
                    Console.WriteLine(" Tinye akauntu nomba onye i na-etinyere ego");
                     var isNumberValid = long.TryParse((Console.ReadLine()), out long beneficiaryAccountNumber);
                    Console.WriteLine("Ego ole ");

                    var isTransferAmountValid =double.TryParse((Console.ReadLine()), out double transferAmount);
                    if (isNumberValid && isTransferAmountValid && transferAmount > (int)CommonNumbers.zero)
                    {


                        if (transferAmount <= account.AccountBalance)
                        {
                            account.Transfer(transferAmount, beneficiaryAccountNumber);
                            Console.WriteLine($"😁😁I tinyere {beneficiaryAccountNumber} ego na akauntu ya");
                            ContinueTransaction();
                        }
                        else
                        {
                            Console.WriteLine("Ego gi ezugi ezu");
                            ContinueTransaction();
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid transfer amount or account number");
                        ContinueTransaction();
                    }
                    break;

                case 3:
                    Console.Clear();
                    Console.WriteLine($"Ego gi foro {account.GetBalance()}");
                   
                    ContinueTransaction();
                    break;

                case 4:
                    return;

                default:
                    Console.WriteLine("Ihe i hooro ezighi ezi");
                    Thread.Sleep((int)CommonNumbers.sleepTimer);
                    Console.Clear();
                    OperationOptions();
                    break;
            }

        }
        internal void ContinueTransaction()
        {

            OperationOptions();
        }
    }
}
