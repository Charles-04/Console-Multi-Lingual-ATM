
using static AutoTellerMachine.Atm;

namespace AutoTellerMachine
{
    internal class EnglishLanguageSelection
    {

        Account account = new();
        Atm atm = new();

        internal void MachineOperations()
        {
            Console.WriteLine("Enter your account Number");
            long.TryParse(Console.ReadLine(), out long accountNumber);
            Console.WriteLine("Enter your pin");
            int.TryParse(Console.ReadLine(), out int pin);
            
            if (account.Validate(pin,accountNumber))
            {
                Console.Clear();
                Console.WriteLine($"Welcome {account._lastName} {account._firstName} \n");
               
                OperationOptions();
            }
            else
            {
                Console.WriteLine("Incorrect pin! Try again");
                Thread.Sleep((int)CommonNumbers.sleepTimer);
                Console.Clear();
                MachineOperations();
            }
        }
        internal void OperationOptions()
        {
            Console.WriteLine("Choose banking operation\n");
            Console.WriteLine("\n1 : Withdrawal \n2 : Transfers \n3 : Balance Check \n4 : exit  \n0 : Previous Menu");
            int.TryParse((Console.ReadLine()), out int Option);

            switch (Option)
            {
                case 0:
                    Console.Clear();
                    atm.Init();
                    break;

                case 1:
                    Console.Clear();
                    Console.WriteLine("Withdrawal ");
                    Console.WriteLine(" Enter amount");
                    int.TryParse((Console.ReadLine()), out int amount);
                    account.Withdraw(amount);
                    Console.WriteLine("Withdrawal sucessful");
                    Console.WriteLine($"Your balance remains {account.AccountBalance} ");
                    ContinueTransaction();
                    break;

                case 2:
                    Console.Clear();
                    Console.WriteLine(" Enter beneficiary account Number");
                    long.TryParse((Console.ReadLine()), out long beneficiaryAccountNumber);
                    Console.WriteLine(" Enter amount");

                    int.TryParse((Console.ReadLine()), out int transferAmount);
                    account.Transfer(transferAmount,beneficiaryAccountNumber);
                    Console.WriteLine($"You have successfully made a Transfer to {beneficiaryAccountNumber}");

                    ContinueTransaction();
                    break;

                case 3:
                    Console.Clear();
                    Console.WriteLine($"Your balance is {account.GetBalance()}");
                    ContinueTransaction();
                    break;
                case 4:
                    return;
                    
                default:
                    Console.WriteLine("Incorrect Option");
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
