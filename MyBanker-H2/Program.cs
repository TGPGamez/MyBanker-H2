using System;
using MyBanker_H2.Lib;

namespace MyBanker_H2
{
    class Program
    {
        static void Main(string[] args)
        {
            //GUI gui = new GUI(true, new Person("Tobias", 20));
            //gui.StartMenu();

            //Creates a instance of our AccountManager
            AccountManager accountManager = new AccountManager("Tobias Prang", 18);
            
            //Create some cards
            Card mastercard = new MasterCard(accountManager.Account);
            Card visa = new Visa(accountManager.Account);
            Card maestro = new Maestro(accountManager.Account);
            Card visaElectron = new VisaElectron(accountManager.Account);
            Card haevekort = new Haevekort(accountManager.Account);
            
            //Adds above cards to our Card list in AccountManager
            accountManager.AddCard(mastercard);
            accountManager.AddCard(visa);
            accountManager.AddCard(maestro);
            accountManager.AddCard(visaElectron);
            accountManager.AddCard(haevekort);

            //Console.WriteLine(mastercard.ToString());
            //Console.WriteLine(visa.ToString());
            //Console.WriteLine(maestro.ToString());
            //Console.WriteLine(visaElectron.ToString());
            //Console.WriteLine(haevekort.ToString());

            //Writes out information for each of our cards
            foreach (Card card in accountManager.Cards)
            {
                Console.WriteLine(card.ToString());
            }

            //Finds vis card from Card list in AccountManager
            Card useCard = accountManager.GetCard(visa.CardNumber);
            
            //Deposits to Account balance through card
            useCard.DepositToCard(500);
            //Displays changed information
            Console.WriteLine(useCard.ToString());
            Console.WriteLine(useCard.Account.Balance);
            //Withdraws from Account balance through card
            useCard.WithdrawFromCard(300);
            //Displays changed information
            Console.WriteLine(useCard.ToString());
            Console.WriteLine(useCard.Account.Balance);

            Console.ReadKey();
        }
    }
}
