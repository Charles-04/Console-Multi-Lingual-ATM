
using static AutoTellerMachine.Atm;

namespace AutoTellerMachine
{
    internal class FrenchLanguageSelection : Itransctions
    {
        Account account = new();
        Atm atm = new();

        internal void MachineOperations()
        {
            Console.WriteLine("Entrez votre numéro de compte");
            long.TryParse(Console.ReadLine(), out long accountNumber);
            Console.WriteLine("Entrez votre NIP");
            int.TryParse(Console.ReadLine(), out int pin);

            if (account.Validate(pin, accountNumber))
            {
                Console.Clear();
                Console.WriteLine($"Bien venu {account._lastName} {account._firstName} \n");
               
                OperationOptions();
            }
            else
            {
                Console.WriteLine("NIP incorrect ! Réessayer");
                Thread.Sleep((int)CommonNumbers.sleepTimer);
                Console.Clear();
                MachineOperations();
            }
        }
        internal void OperationOptions()
        {
            Console.WriteLine("Choisissez l'opération bancaire\n");
            Console.WriteLine("\n1 : Retrait \n2 : Transferts \n3 : Vérification du solde \n4 : sortir  \n0 : Menu précédent");
            int.TryParse((Console.ReadLine()), out int Option);

            switch (Option)
            {
                case 0:
                    Console.Clear();
                    atm.Init();
                    break;

                case 1:
                    Console.Clear();
                    Console.WriteLine("Retrait ");
                    Console.WriteLine("Entrer le montant");
                    bool isAmountValid = double.TryParse((Console.ReadLine()), out double amount);
                    if (amount <= account.AccountBalance && isAmountValid && amount > (int)CommonNumbers.zero)
                    {
                        account.Withdraw(amount);
                        Console.WriteLine("Retrait réussi ✅✅");
                        Console.WriteLine($"Votre solde reste {account.AccountBalance} ");
                        ContinueTransaction();
                    }
                    else
                    {
                        Console.WriteLine("Fonds insuffisants  ou Numéro invalide 😒😒");
                        ContinueTransaction();
                    }
                   
                   
                    break;

                case 2:
                    Console.Clear();
                    Console.WriteLine("Transferts\n");
                    Console.WriteLine("Entrez le numéro de compte du bénéficiaire");
                    bool isNumberValid = long.TryParse((Console.ReadLine()), out long beneficiaryAccountNumber);

                    Console.WriteLine("Entrer le montant");
                    bool isTransferAmountValid = double.TryParse((Console.ReadLine()), out double transferAmount);

                    if (isNumberValid && isTransferAmountValid && transferAmount > (int)CommonNumbers.zero)
                    {


                        if (transferAmount <= account.AccountBalance )
                        {
                            account.Transfer(transferAmount, beneficiaryAccountNumber);
                            Console.WriteLine($"👌👌Vous avez effectué avec succès un transfert de {transferAmount} à {beneficiaryAccountNumber}");
                            ContinueTransaction();
                        }
                        else
                        {
                            Console.WriteLine("Fonds insuffisants 😒😒");
                            ContinueTransaction();
                        }
                    }
                    else
                    {
                        Console.WriteLine("le montant du transfert ou le numéro de compte est invalide");
                    }
                    break;

                case 3:
                    Console.Clear();
                    Console.WriteLine($"Votre solde est {account.GetBalance()}");
                    ContinueTransaction();
                    break;
                case 4:
                    return;

                default:
                    Console.WriteLine("Option incorrecte 😒😒");
                    Thread.Sleep((int)CommonNumbers.sleepTimer);
                    Console.Clear();
                    OperationOptions();
                    break;
            }
        }
        internal void ContinueTransaction() => OperationOptions();
    }
}
