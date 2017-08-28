namespace CardApi
{
    public class Card
    {
        public CardSuit Suit { get; set; }
        public CardRank Rank { get; set; }
        public int OrdinalValue => (int)Rank + (((int)Suit - 1) * 13);
        public string Title => $"({OrdinalValue:00}) {Rank} of {Suit}";
    }
}
