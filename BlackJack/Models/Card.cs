using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlackJack.Models
{
    public class Card
    {
        public CardPattern Pattern { get; set; }
        public CardName Name { get; set; }
        public int Point { get; set; }
        public bool IsHidden { get; set; }

        public Card(CardPattern pattern, CardName name,int point)
        {           
            this.Pattern = pattern;
            this.Name = name;
            this.Point = point;
        }
    }

    public enum CardPattern
    {
        Clubs,
        Diamonds,
        Hearts,
        Spades
    }

    public enum CardName
    {
        One,
        Two,
        Three,
        Four,
        Five,
        Six,
        Seven,
        Eight,
        Nine,
        Ten,
        Jack,
        Queen,
        King
    }
}