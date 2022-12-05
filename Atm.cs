namespace AutoTellerMachine
{
    internal class Atm

    {
        public enum CommonNumbers
        {
            sleepTimer = 2000,
            zero = 0,
        }

        public void Init()
        {

            IgboLanguageSelection igbo = new();
            igbo.AddInsufficientFundMethod(InsufficentFundsAlert);

            EnglishLanguageSelection english = new();
            english.AddInsufficientFundMethod(InsufficentFundsAlert);

            FrenchLanguageSelection french = new();
            french.AddInsufficientFundMethod(InsufficentFundsAlert);

            Console.WriteLine("Select your preferred language");
            Console.WriteLine("\n1: Igbo \n2: English \n3: French");


            int.TryParse((Console.ReadLine()), out int Option);
            switch (Option)
            {
                case 1:
                    Console.WriteLine("I hooro asusu Igbo");
                    Thread.Sleep((int)CommonNumbers.sleepTimer);
                    Console.Clear();
                    igbo.Validate();

                    break;
                case 2:
                    Console.WriteLine("You Chose English");
                    Thread.Sleep((int)CommonNumbers.sleepTimer);
                    Console.Clear();
                    english.Validate();
                    break;
                case 3:
                    Console.WriteLine("Vous avez choisi le français");
                    Thread.Sleep((int)CommonNumbers.sleepTimer);
                    Console.Clear();
                    french.Validate();

                    break;
                default:
                    Console.WriteLine("Incorrect Option");
                    Thread.Sleep((int)CommonNumbers.sleepTimer);
                    Console.Clear();
                    Init();
                    break;
            }

            
        }
        static void InsufficentFundsAlert( string message)
        {
            Console.WriteLine(message);
        }
    }
}
