using BlackJack.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlackJack.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {         
            return View();
        }

        public ActionResult Start(int bet=0)
        {
            MvcApplication.CardList = GenerateCardList();

            //New game
            if (MvcApplication.Game ==null || MvcApplication.Game.Balance <= 0)
            {
                MvcApplication.Game = new Game();
                MvcApplication.Game.Balance = 500;
            }

            MvcApplication.Game.Bet = bet;
            MvcApplication.Game.PlayerScore = 0;
            MvcApplication.Game.DealerScore = 0;
            MvcApplication.Game.Status = "";
            MvcApplication.Game.IsStand = false;



            //Randomize the cards 
            MvcApplication.CardList = MvcApplication.CardList.OrderBy(i => Guid.NewGuid()).ToList();

            //Assign two cards to dealer 
            MvcApplication.DealerCardList = AssignInitCard();
            MvcApplication.DealerCardList[0].IsHidden = true;


            //Assign two cards to player 
            MvcApplication.PlayerCardList = AssignInitCard();

            MvcApplication.Game.Dealer = MvcApplication.DealerCardList;
            MvcApplication.Game.Player = MvcApplication.PlayerCardList;

            //Check the game result
            CheckResult();

            return PartialView("_Board", MvcApplication.Game);
        }

        public ActionResult Hit()
        {
            Card card = MvcApplication.CardList.First();
            MvcApplication.Game.Player.Add(card);
            
            MvcApplication.CardList.RemoveAt(0);



            //Check the game result
            CheckResult();

            return PartialView("_Board", MvcApplication.Game);
        }

        public ActionResult Stand()
        {
            MvcApplication.Game.IsStand = true;

            int dealerPoints = MvcApplication.Game.Dealer.Sum(i => i.Point);

            while (dealerPoints<17)
            {
                //Add new card for dealer
                Card card = MvcApplication.CardList.First();
                MvcApplication.Game.Dealer.Add(card);

                MvcApplication.CardList.RemoveAt(0);

                dealerPoints = MvcApplication.Game.Dealer.Sum(i => i.Point);
            }

            if (dealerPoints>21 || dealerPoints <= MvcApplication.Game.PlayerScore)
            {
                MvcApplication.Game.Balance = MvcApplication.Game.Balance + MvcApplication.Game.Bet;
                MvcApplication.Game.Status = "Won !";
            }
            else
            {
                if (dealerPoints > MvcApplication.Game.PlayerScore)
                {
                    MvcApplication.Game.Balance = MvcApplication.Game.Balance - MvcApplication.Game.Bet;
                    if (MvcApplication.Game.Balance <= 0)
                    {
                        MvcApplication.Game.Status = "Game over !";
                    }
                    else
                    {
                        MvcApplication.Game.Status = "Loose !";
                    }
                }
            }

            MvcApplication.Game.DealerScore = dealerPoints;

            return PartialView("_Board", MvcApplication.Game);
        }

        public ActionResult NewGame()
        {
            MvcApplication.Game = new Game();
            MvcApplication.Game.Balance = 500;

            return PartialView("_Board", MvcApplication.Game);
        }


        private List<Card> GenerateCardList()
        {
            List<Card> cards = new List<Card>();

            //Set Clubs pattren
            cards.Add(new Card(CardPattern.Clubs, CardName.One, 11));
            cards.Add(new Card(CardPattern.Clubs, CardName.Two, 2));
            cards.Add(new Card(CardPattern.Clubs, CardName.Three, 3));
            cards.Add(new Card(CardPattern.Clubs, CardName.Four, 4));
            cards.Add(new Card(CardPattern.Clubs, CardName.Five, 5));
            cards.Add(new Card(CardPattern.Clubs, CardName.Six, 6));
            cards.Add(new Card(CardPattern.Clubs, CardName.Seven, 7));
            cards.Add(new Card(CardPattern.Clubs, CardName.Eight, 8));
            cards.Add(new Card(CardPattern.Clubs, CardName.Nine, 9));
            cards.Add(new Card(CardPattern.Clubs, CardName.Ten, 10));
            cards.Add(new Card(CardPattern.Clubs, CardName.Jack, 10));
            cards.Add(new Card(CardPattern.Clubs, CardName.Queen, 10));
            cards.Add(new Card(CardPattern.Clubs, CardName.King, 10));

            //Set Clubs pattren
            cards.Add(new Card(CardPattern.Diamonds, CardName.One, 11));
            cards.Add(new Card(CardPattern.Diamonds, CardName.Two, 2));
            cards.Add(new Card(CardPattern.Diamonds, CardName.Three, 3));
            cards.Add(new Card(CardPattern.Diamonds, CardName.Four, 4));
            cards.Add(new Card(CardPattern.Diamonds, CardName.Five, 5));
            cards.Add(new Card(CardPattern.Diamonds, CardName.Six, 6));
            cards.Add(new Card(CardPattern.Diamonds, CardName.Seven, 7));
            cards.Add(new Card(CardPattern.Diamonds, CardName.Eight, 8));
            cards.Add(new Card(CardPattern.Diamonds, CardName.Nine, 9));
            cards.Add(new Card(CardPattern.Diamonds, CardName.Ten, 10));
            cards.Add(new Card(CardPattern.Diamonds, CardName.Jack, 10));
            cards.Add(new Card(CardPattern.Diamonds, CardName.Queen, 10));
            cards.Add(new Card(CardPattern.Diamonds, CardName.King, 10));

            //Set Hearts pattren
            cards.Add(new Card(CardPattern.Hearts, CardName.One, 11));
            cards.Add(new Card(CardPattern.Hearts, CardName.Two, 2));
            cards.Add(new Card(CardPattern.Hearts, CardName.Three, 3));
            cards.Add(new Card(CardPattern.Hearts, CardName.Four, 4));
            cards.Add(new Card(CardPattern.Hearts, CardName.Five, 5));
            cards.Add(new Card(CardPattern.Hearts, CardName.Six, 6));
            cards.Add(new Card(CardPattern.Hearts, CardName.Seven, 7));
            cards.Add(new Card(CardPattern.Hearts, CardName.Eight, 8));
            cards.Add(new Card(CardPattern.Hearts, CardName.Nine, 9));
            cards.Add(new Card(CardPattern.Hearts, CardName.Ten, 10));
            cards.Add(new Card(CardPattern.Hearts, CardName.Jack, 10));
            cards.Add(new Card(CardPattern.Hearts, CardName.Queen, 10));
            cards.Add(new Card(CardPattern.Hearts, CardName.King, 10));

            //Set Spades pattren
            cards.Add(new Card(CardPattern.Spades, CardName.One, 11));
            cards.Add(new Card(CardPattern.Spades, CardName.Two, 2));
            cards.Add(new Card(CardPattern.Spades, CardName.Three, 3));
            cards.Add(new Card(CardPattern.Spades, CardName.Four, 4));
            cards.Add(new Card(CardPattern.Spades, CardName.Five, 5));
            cards.Add(new Card(CardPattern.Spades, CardName.Six, 6));
            cards.Add(new Card(CardPattern.Spades, CardName.Seven, 7));
            cards.Add(new Card(CardPattern.Spades, CardName.Eight, 8));
            cards.Add(new Card(CardPattern.Spades, CardName.Nine, 9));
            cards.Add(new Card(CardPattern.Spades, CardName.Ten, 10));
            cards.Add(new Card(CardPattern.Spades, CardName.Jack, 10));
            cards.Add(new Card(CardPattern.Spades, CardName.Queen, 10));
            cards.Add(new Card(CardPattern.Spades, CardName.King, 10));

            return cards;
        }

        //Method AssignInitCard()
        private List<Card> AssignInitCard()
        {
            List<Card> cards = new List<Card>();

            cards.Add(MvcApplication.CardList[0]);
            cards.Add(MvcApplication.CardList[1]);

            MvcApplication.CardList.RemoveRange(0,2);

            return cards;
        }


        //Method CheckResult()
        private void CheckResult()
        {
            //Calculate player score
            var playerPoints = MvcApplication.Game.Player.Sum(i => i.Point);
            MvcApplication.Game.PlayerScore = playerPoints;

            if (playerPoints == 21)
            {
                if (MvcApplication.Game.Player.Count !=2)
                {
                    MvcApplication.Game.Balance = MvcApplication.Game.Balance + MvcApplication.Game.Bet;
                    MvcApplication.Game.Status = "Won !";
                }
                else
                {
                    MvcApplication.Game.Status = "Black Jack !";
                    MvcApplication.Game.Balance = MvcApplication.Game.Balance + (MvcApplication.Game.Bet + (MvcApplication.Game.Bet/2));
                }
            }
            else if (playerPoints > 21 )
            {
                MvcApplication.Game.Balance = MvcApplication.Game.Balance - MvcApplication.Game.Bet;

                if (MvcApplication.Game.Balance <= 0)
                {
                    MvcApplication.Game.Status = "Game over !";
                }
                else
                {
                    MvcApplication.Game.Status = "Loose !";
                }  
            }
        }
    }
}