
using static AutoTellerMachine.Atm;

namespace AutoTellerMachine
{
    internal class EnglishLanguageSelection : Itransctions
    {

        Account account = new();
        Atm atm = new();
        public event Action<string> InsufficientFund;

        public void AddInsufficientFundMethod(Action<string> method)
        {
            InsufficientFund += method;
        }

        internal void Validate()
        {
            Console.WriteLine("Enter your account Number");
            long.TryParse(Console.ReadLine(), out long accountNumber);
            Console.WriteLine("Enter your pin");
            int.TryParse(Console.ReadLine(), out int pin);

            if (account.Validate(pin, accountNumber))
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
                Validate();
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
                    Withdraw();
                   
                   
                    break;

                case 2:
                    Console.Clear();
                    Transfer();
                    break;

                case 3:
                    Console.Clear();
                    GetBalance();
                    break;
                case 4:
                    Console.WriteLine("Thanks For Using our services");
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


     

        void Withdraw()
        {
            Console.WriteLine("Withdrawal ");
            Console.WriteLine("Enter amount");
            bool isAmountValid = double.TryParse((Console.ReadLine()), out double amount);
            if (amount <= account.AccountBalance && isAmountValid && amount > (int)CommonNumbers.zero)
            {
                account.Withdraw(amount);
                Console.WriteLine("Withdrawal sucessful");
                Console.WriteLine($"Your balance remains {account.AccountBalance} ");
                ContinueTransaction();
            }
            else
            {
                OnInsufficientFund("Insufficient funds or Invalid amount");
                ContinueTransaction();
            }
        }

        void Transfer()
        {
            Console.WriteLine(" Enter beneficiary account Number");
            var isNumberValid = long.TryParse((Console.ReadLine()), out long beneficiaryAccountNumber);
            Console.WriteLine(" Enter amount");

            var isTransferAmountValid = double.TryParse((Console.ReadLine()), out double transferAmount);
            if (isNumberValid && isTransferAmountValid && transferAmount > (int)CommonNumbers.zero)
            {


                if (transferAmount <= account.AccountBalance)
                {
                    account.Transfer(transferAmount, beneficiaryAccountNumber);
                    Console.WriteLine($"👌👌You have successfully made a Transfer of {transferAmount} to {beneficiaryAccountNumber}");
                    ContinueTransaction();
                }
                else
                {
                    OnInsufficientFund("Insufficient funds");
                    ContinueTransaction();
                }
            }
            else
            {
                Console.WriteLine("Invalid transfer amount or Account Number");
                ContinueTransaction();
            }
        }

        void GetBalance()
        {
            Console.WriteLine($"Your balance is 💲 {account.GetBalance()}");
            ContinueTransaction();
        }

        public virtual void OnInsufficientFund(string message)
        {
            InsufficientFund?.Invoke(message);
        }
       
    }
}
