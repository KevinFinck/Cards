using System;
using CardApi;

namespace Cards
{
    class Program
    {
        private enum MenuChoice
        {
            SortDeck,
            ShuffleDeck,
            Exit,
            InvalidChoice
        }

        static void Main(string[] args)
        {
            DemoCardApiFunctionality();
        }

        private static void DemoCardApiFunctionality()
        {
            var deck = Deck.Create();
            var menuChoice = GetMenuChoice();

            while (menuChoice != MenuChoice.Exit)
            {
                switch (menuChoice)
                {
                    case MenuChoice.SortDeck:
                        deck.Sort();
                        break;

                    case MenuChoice.ShuffleDeck:
                        deck.Shuffle();
                        break;
                }

                DisplayDeck(deck);
                menuChoice = GetMenuChoice();
            }
        }

        private static MenuChoice GetMenuChoice()
        {
            DisplayMenuOptions();

            MenuChoice choice;
            do
            {
                choice = MapKeyToMenuChoice(Console.ReadKey(true));
            } while (choice == MenuChoice.InvalidChoice);

            return choice;
        }

        private static void DisplayMenuOptions()
        {
            Console.WriteLine("1) Display sorted deck.");
            Console.WriteLine("2) Display shuffled deck.");
            Console.WriteLine("Esc) Exit.");
            Console.Write($"{Environment.NewLine}Selection: ");
        }

        private static MenuChoice MapKeyToMenuChoice(ConsoleKeyInfo key)
        {
            switch ((int)key.KeyChar)
            {
                case 49: return MenuChoice.SortDeck;
                case 50: return MenuChoice.ShuffleDeck;
                case 27: return MenuChoice.Exit;
            }
            return MenuChoice.InvalidChoice;
        }

        private static void DisplayDeck(Deck deck)
        {
            Console.Clear();
            foreach (var card in deck)
            {
                Console.WriteLine(card.Title);
            }
            Console.WriteLine($"{Environment.NewLine}");
        }
    }
}
