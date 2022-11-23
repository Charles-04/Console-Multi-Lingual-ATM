
namespace AutoTellerMachine
{
    internal class Account

    {
        private long _accountNumber;
        protected int _pin;
        public string _firstName;
        public string _lastName;

        internal double AccountBalance { get; private set; } = 30000.00;

        public Account()
        {
            _accountNumber = 1232056263;
            _pin = 0222;
            _firstName = "Charles";
            _lastName = "Chibueze";

        }



        public bool Validate(int pin, long accountNumber)
        {
            if (pin == this._pin && accountNumber == this._accountNumber)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        public double GetBalance()
        {
            return this.AccountBalance;
        }

        public void Transfer(double amount, long accountNumber)
        {

            if (amount <= this.AccountBalance)
            {
                this.AccountBalance -= amount;


            }
            else
            {
                Console.WriteLine("Insufficient Funds");
            }

        }

        public void Withdraw(double amount)
        {
            if (amount <= this.AccountBalance)
            {
                this.AccountBalance -= amount;


            }
            else
            {
                Console.WriteLine("Insufficient Funds");
            }
        }


        /*acount number
         * account balance
         * 
         *
         */

    }
    internal interface Itransctions
    {
        void MachineOperations() { }
        void OperationOptions() { }
        void ContinueOptions() { }


    }
}
