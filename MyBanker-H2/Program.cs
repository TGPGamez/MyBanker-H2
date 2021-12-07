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

            AccountManager accountManager = new AccountManager("Tobias Prang");
            Card mastercard = new MasterCard(accountManager.Account);
            Card visa = new Visa(accountManager.Account);
            Card maestro = new Maestro(accountManager.Account);
            Card visaElectron = new VisaElectron(accountManager.Account);
            Card haevekort = new Haevekort(accountManager.Account);
            //accountManager.AddCard(new MasterCard(accountManager.Account));

            Console.WriteLine(mastercard.ToString());
            Console.WriteLine(visa.ToString());
            Console.WriteLine(maestro.ToString());
            Console.WriteLine(visaElectron.ToString());
            Console.WriteLine(haevekort.ToString());
            //foreach (Card card in accountManager.Cards)
            //{
            //    Console.WriteLine(card.ToString());
            //}

            Console.ReadKey();
        }
    }
}
