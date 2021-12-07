using MyBanker_H2.OldLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBanker_H2
{
    public class GUI
    {
        private string[] menuItems = new string[] { "Insert money", "Withdraw money", "Card Information" };
        private int selectedItem = 0;

        public Person Person { get; private set; }

        public bool Status { get; private set; }
        public GUI(bool status, Person person)
        {
            Status = status;
            Person = person;
        }

        public void StartMenu()
        {
            Bank bank = new MyBankerBank();
            Card card = null;
            do
            {
                Console.Clear();
                string offers = bank.ShowOfferedCards(50);
                Console.WriteLine(offers);
                Console.Write("What card do you want? ");
                string cardChoice = Console.ReadLine();
                card = bank.GiveCard(cardChoice, Person.Name, offers);
                if (card == null)
                {
                    Console.WriteLine("You can't have that card or wrong input");
                    Console.WriteLine("Press any key to continue..");
                    Console.ReadKey();
                }
            } while (card == null);
            Person.SetCard(card);
            MainMenu();

        }

        private void MainMenu()
        {
            while (Status == true)
            {
                Console.Clear();
                Console.CursorVisible = false;
                Console.SetCursorPosition(0, 0);
                SetChar('#', 40, ConsoleColor.White, ConsoleColor.White);
                for (int i = 0; i < menuItems.Length; i++)
                {
                    Console.WriteLine();
                    if (i == selectedItem)
                        WriteWithColor(" - " + menuItems[i], ConsoleColor.Red, ConsoleColor.Black);
                    else
                        WriteWithColor(" - " + menuItems[i], ConsoleColor.White, ConsoleColor.Black);
                }
                Console.WriteLine();
                SetChar('#', 40, ConsoleColor.White, ConsoleColor.White);
                Console.SetCursorPosition(0, 0);
                ConsoleKeyInfo consoleKey = Console.ReadKey();
                CheckInput(consoleKey);

            }
        }


        private void CardInformationMenu()
        {
            Console.Clear();
            Console.CursorVisible = false;
            Console.SetCursorPosition(0, 0);
            SetChar('#', 40, ConsoleColor.White, ConsoleColor.White);
            Console.WriteLine("Card information");
            Console.WriteLine(Person.Card.ToString());
            Console.WriteLine();
            Console.WriteLine("Press any key to continue..");
            Console.WriteLine();
            SetChar('#', 40, ConsoleColor.White, ConsoleColor.White);
            Console.SetCursorPosition(0, 0);
            Console.ReadKey();
        }


        private void SetChar(char cha, int amount, ConsoleColor foreground, ConsoleColor background)
        {
            Console.ForegroundColor = foreground;
            Console.BackgroundColor = background;
            for (int i = 0; i < amount; i++)
            {
                Console.Write(cha);
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write("\n");
        }

        private void CheckInput(ConsoleKeyInfo consoleKey)
        {
            switch (consoleKey.Key)
            {
                case ConsoleKey.UpArrow:
                case ConsoleKey.W:
                    if (selectedItem > 0)
                        selectedItem--;
                    break;
                case ConsoleKey.DownArrow:
                case ConsoleKey.S:
                    if (selectedItem < menuItems.Length - 1)
                        selectedItem++;
                    break;
                case ConsoleKey.Enter:
                    switch (selectedItem)
                    {
                        case 0:
                            //InsertMenu();
                            break;
                        case 1:
                            //WithdrawMenu();
                            break;
                        case 2:
                            CardInformationMenu();
                            break;
                        default:
                            break;
                    }
                    break;
                case ConsoleKey.Escape:
                    //Status = false;
                    //MainMenu();
                    break;
            }
        }

        private void WriteWithColor(string text, ConsoleColor foreground, ConsoleColor background)
        {
            Console.WriteLine(text, Console.ForegroundColor = foreground, Console.BackgroundColor = background);
        }
    }
}
