using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace CardApi
{
    public class Deck : IEnumerable<Card>
    {
        private List<Card> _cards;
        private int[] _cardOrder;

        private Deck()
        {
            CreateCards();
            Sort();
        }

        public static Deck Create()
        {
            return new Deck();
        }

        private void CreateCards()
        {
            _cards = new List<Card>();
            foreach (var suit in Enum.GetValues(typeof(CardSuit)))
            {
                foreach (var rank in Enum.GetValues(typeof(CardRank)))
                {
                    _cards.Add(new Card { Suit = (CardSuit)suit, Rank = (CardRank)rank });
                }
            }
        }

        public void Sort()
        {
            _cardOrder = MakeOrderedCardNumbersArray();
        }

        public void Shuffle()
        {
            Random randomGenerator = new Random();
            var cardsToChooseFrom = MakeOrderedCardNumbersArray().ToList();
            for (var i = 0; i < 52; i++)
            {
                var cardChoice = randomGenerator.Next(cardsToChooseFrom.Count);
                _cardOrder[i] = cardsToChooseFrom[cardChoice];
                cardsToChooseFrom.Remove(cardChoice);
            }
        }

        private static int[] MakeOrderedCardNumbersArray()
        {
            var cardNumbers =  new int[52];
            for (var i = 0; i< 52; i++)
            {
                cardNumbers[i] = i;
            }
            return cardNumbers;
        }

        public IEnumerator<Card> GetEnumerator()
        {
            foreach (var cardIndex in _cardOrder)
            {
                yield return _cards[cardIndex];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
