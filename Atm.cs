namespace AutoTellerMachine
{
    internal class Atm

    {
        public enum CommonNumbers
        {
            sleepTimer = 2000
        }

        public void Init()
        {

            IgboLanguageSelection igbo = new();
            EnglishLanguageSelection english = new();

            Console.WriteLine("Select your preferred language");
            Console.WriteLine("\n1: Igbo \n2: English \n3: French");

            int.TryParse((Console.ReadLine()), out int Option);
            switch (Option)
            {
                case 1:
                    Console.WriteLine("I hooro asusu Igbo");
                    Thread.Sleep((int)CommonNumbers.sleepTimer);
                    Console.Clear();
                    igbo.MachineOperations();

                    break;
                case 2:
                    Console.WriteLine("You Chose English");
                    Thread.Sleep((int)CommonNumbers.sleepTimer);
                    Console.Clear();
                    english.MachineOperations();
                    break;
                case 3:
                    Console.WriteLine("Vous avez choisi le français");
                    break;
                default:
                    Console.WriteLine("Incorrect Option");
                    Thread.Sleep((int)CommonNumbers.sleepTimer);
                    Console.Clear();
                    Init();
                    break;
            }

        }
    }
}
