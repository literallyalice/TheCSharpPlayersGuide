using System.ComponentModel;

List<Card> deck = new List<Card>();

foreach (CardColor color in Enum.GetValues(typeof(CardColor))) {
    foreach (CardRank rank in Enum.GetValues(typeof(CardRank))) {
        deck.Add(new Card(color, rank));
    } 
}

foreach(Card card in deck){
    Console.WriteLine($"The {card.Color} {card.Rank}");
}

class Card
{
    public CardColor Color { get; }
    public CardRank Rank { get; }

    public bool IsSymbol => (int)Rank > 10;
    public Card(CardColor cardColor, CardRank cardRank) {
        Color = cardColor;
        Rank = cardRank;
    }
    
    
}

enum CardColor
{
    Red,
    Green,
    Blue,
    Yellow
}

enum CardRank
{
    One = 1,
    Two = 2,
    Three = 3,
    Four = 4,
    Five = 5,
    Six = 6,
    Seven = 7,
    Eight = 8,
    Nine = 9,
    Ten = 10,
    [Description("$")]Dollar = 11,
    [Description("%")]Percent = 12,
    [Description("^")]Caret = 13,
    [Description("&")]Ampersand = 14
}