using System;
using AutoTellerMachine;
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

            Console.WriteLine("Tinye pin gị ebe a");
            int.TryParse(Console.ReadLine(), out int pin);
            if (account.Validate(pin, accountNumber))
            {
                Console.Clear();
                Console.WriteLine($"Nnoo {account._lastName} {account._firstName} \n");
                
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
                    int.TryParse((Console.ReadLine()), out int amount);
                    account.Withdraw(amount);

                    Console.WriteLine("Mwepu gara nke oma");
                    Console.WriteLine($"Ego gi foro {account.AccountBalance} ");

                    ContinueTransaction();
                    break;

                case 2:
                    Console.Clear();
                    Console.WriteLine(" Tinye akauntu nomba onye i na-etinyere ego");
                    long.TryParse((Console.ReadLine()), out long beneficiaryAccountNumber);
                    Console.WriteLine("Ego ole ");

                    int.TryParse((Console.ReadLine()), out int transferAmount);
                    account.Transfer(transferAmount, beneficiaryAccountNumber);
                    Console.WriteLine($"I tinyere {beneficiaryAccountNumber} ego na akauntu ya");

                    ContinueTransaction();
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
