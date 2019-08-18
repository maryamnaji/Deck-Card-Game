using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlackJack.Models
{
    public class Game
    {
        public List<Card> Dealer { get; set; }
        public List<Card> Player { get; set; }

        public int Bet { get; set; }
        public int Balance { get; set; }

        public int PlayerScore { get; set; }
        public string Status { get; set; }

        public bool IsStand { get; set; }
        public int DealerScore { get; set; }


        public Game()
        {
            this.Dealer = new List<Card>();
            this.Player = new List<Card>();
        }
    }
}