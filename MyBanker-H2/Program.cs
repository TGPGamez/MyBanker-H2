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

            AccountManager accountManager = new AccountManager("Tobias Prang", 18);
            Card mastercard = new MasterCard(accountManager.Account);
            Card visa = new Visa(accountManager.Account);
            Card maestro = new Maestro(accountManager.Account);
            Card visaElectron = new VisaElectron(accountManager.Account);
            Card haevekort = new Haevekort(accountManager.Account);
            
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
            foreach (Card card in accountManager.Cards)
            {
                Console.WriteLine(card.ToString());
            }

            Card useCard = accountManager.GetCard(visa.CardNumber);
            
            useCard.DepositToCard(500);
            Console.WriteLine(useCard.ToString());
            Console.WriteLine(useCard.Account.Balance);
            useCard.WithdrawFromCard(300);
            Console.WriteLine(useCard.ToString());
            Console.WriteLine(useCard.Account.Balance);

            Console.ReadKey();
        }
    }
}
