using System.Linq;
using CardApi;
using FluentAssertions;
using NUnit.Framework;

namespace CardApiUnitTests
{
    [TestFixture]
    public class DeckTests
    {
        [Test]
        public void Create_returns_a_valid_deck_of_cards()
        {
            var deck = Deck.Create();
            AssertDeckIsValid(deck);
        }

        [Test]
        public void Sort_puts_the_deck_in_order_by_suit_and_rank()
        {
            var deck = Deck.Create();

            deck.Sort();

            AssertDeckIsValid(deck);
            AssertDeckIsSorted(deck);
        }
        private static void AssertDeckIsSorted(Deck deck)
        {
            deck.ToList()
                .Select((value, index) => new {Index = index, Card = value})
                .Any(indexed => indexed.Card.OrdinalValue != indexed.Index + 1)
                .Should().BeFalse("Cards should be in order of their Ordinal value.");
        }

        [Test]
        public void Shuffle_puts_the_deck_into_random_order()
        {
            var deck = Deck.Create();

            deck.Shuffle();

            AssertDeckIsValid(deck);
            AssertDeckIsNotSorted(deck);
        }
        private static void AssertDeckIsNotSorted(Deck deck)
        {
            deck.ToList()
                .Select((value, index) => new {Index = index, Card = value})
                .Any(indexed => indexed.Card.OrdinalValue != indexed.Index + 1)
                .Should().BeTrue("At least one card should be out of order.");
        }

        private static void AssertDeckIsValid(Deck deck)
        {
            deck.Should().NotBeNull();
            deck.Count().Should().Be(52);
        }
    }
}
