using System;
using System.Collections.Generic;
using System.Text;
using BPData.Models;
using BPData.Lists;

namespace BPData.Services
{
    public class GameService
    {
        //current state of the game
        public short State = BPConstants.GS_PreGame;

        //deck, its stored here only and passed to the DeckService etc.. as needed
        private List<Card> Deck = null;

        //players
        private PlayerList PlayersList = null;

        /// <summary>
        /// init the game
        /// </summary>
        public void Init()
        {
            //start with an unsorted pristine deck
            Deck = new DeckService().GetDeck();

            //now wait for players
            State = BPConstants.GS_WaitForPlayers;
        }

        /// <summary>
        /// default ctr sets up the game
        /// </summary>
        public GameService()
        {
            //game is in pre-game mode to start
            State = BPConstants.GS_PreGame;

            //empty players list
            PlayersList = new PlayerList();
        }
                
        //add a player to the game
        public bool AddPlayer(Player player)
        {
            if(!PlayersList.Add(player))
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// start the game
        /// </summary>
        /// <returns></returns>
        public bool StartGame()
        {
            //shuffle the deck
            State = BPConstants.GS_ShuffleDeck;
            //use the deck service to shuffle the carda
            DeckService ds = new DeckService();
            Deck = ds.ShuffleDeck(Deck);

            //clear the players current hand
            PlayersList.InitHand();

            //deal hands to all the players
            State = BPConstants.GS_Deal;
            PlayersList.Deal(ref Deck, BPConstants.FiveCards);

            State = BPConstants.GS_WaitForDiscard;
                       
            return true;
        }

        //end the game
        public void EndGame()
        {
            Init();
        }

        //remove a player from the game
        public void RemovePlayer(int seat)
        {
            PlayersList.Remove(seat);            
        }

        //player folded
        public void FoldPlayer(int seat)
        {
            PlayersList.Fold(seat);
        }
       
        public void DiscardPlayersCards()
        {
            //todo: dealer should get card last
            foreach(Player p in PlayersList.GetPlayers())
            {
                if(!p.Human)
                {
                    AutoDiscardPlayerCards(p);
                }
                else
                {
                    DiscardPlayerCards(p);
                }
            }

            State = BPConstants.GS_Discard;
        }

        /// <summary>
        /// remove discarded cards from the players hand
        /// </summary>
        /// <param name="seat"></param>
        public void DiscardPlayerCards(Player p)
        {
            List<Card> discards = new List<Card>();
            if (p != null)
            {
                foreach (Card c in p.Hand)
                {
                    if (c.Discard)
                    {
                        discards.Add(c);
                    }
                }

                PlayersList.Discard(p, discards);
            }
        }

        /// <summary>
        /// auto discard for a computer player
        /// </summary>
        /// <param name="seat"></param>
        public void AutoDiscardPlayerCards(Player p)
        {
            List<Card> discards = new List<Card>();
            if (p != null)
            {
                EvalService eval = new EvalService();
                Rank rank = eval.Evaluate(p.Hand);

                //nothing to discard so just return
                if (rank.Value == BPConstants.Rank_RoyalFlush ||
                    rank.Value == BPConstants.Rank_Flush ||
                    rank.Value == BPConstants.Rank_StraightFlush ||
                    rank.Value == BPConstants.Rank_Straight ||
                    rank.Value == BPConstants.Rank_FullHouse)
                {
                    return;
                }

                //if high card, then keep the second highest card too and discard all others
                if (rank.Value == BPConstants.Rank_HighCard)
                {
                    foreach (Card c in p.Hand)
                    {
                        if (c.Value != rank.Tie1 && c.Value != rank.High)
                        {
                            c.Discard = true;
                        }
                    }
                }

                //pair then keep the pair and any aces or kings
                if (rank.Value == BPConstants.Rank_Pair)
                {
                    foreach (Card c in p.Hand)
                    {
                        if (c.Value != rank.Pair)
                        {
                            if (c.Value != BPConstants.AceHigh)
                            {
                                if (c.Value != BPConstants.King)
                                {
                                    c.Discard = true;
                                }
                            }
                        }
                    }
                }

                //2 pair then dicard the 1 card thats not part of the pair
                if (rank.Value == BPConstants.Rank_2Pair)
                {
                    foreach (Card c in p.Hand)
                    {
                        if (c.Value != rank.Pair)
                        {
                            if (c.Value != rank.Pair2)
                            {
                                c.Discard = true;
                            }
                        }
                    }
                }

                //call the original discard
                DiscardPlayerCards(p);
            }
        }


        /// <summary>
        /// remove discarded cards from the players hand
        /// </summary>
        /// <param name="seat"></param>
        public void DiscardPlayerCards(int seat)
        {
            List<Card> discards = new List<Card>();
            Player p = PlayersList.GetPlayerBySeat(seat);
            if(p != null)
            {
                DiscardPlayerCards(p);                
            }            
        }

        /// <summary>
        /// auto discard for a computer player
        /// </summary>
        /// <param name="seat"></param>
        public void AutoDiscardPlayerCards(int seat)
        {
            List<Card> discards = new List<Card>();
            Player p = PlayersList.GetPlayerBySeat(seat);
            if (p != null)
            {
                AutoDiscardPlayerCards(p);
            }
        }

        public void DealPlayersDraw()
        {
            //todo: dealer should go last
            foreach(Player p in PlayersList.GetPlayers())
            {
                //puill cards from the deck
                List<Card> cards = new DeckService().DealCards(ref Deck, p.Discard.Count);

                //pass the draw onto the player
                PlayersList.Draw(p, cards);

            }

            State = BPConstants.GS_Draw;            
        }

        public void ChooseWinners()
        {
            PlayersList.ChooseWinners();
        }


        /// <summary>
        /// deal draw after player discards
        /// </summary>
        /// <param name="seat"></param>
        public void DealPlayerDraw(int seat)
        {
            List<Card> discards = new List<Card>();
            Player p = PlayersList.GetPlayerBySeat(seat);
            if (p != null)
            {
                //puill cards from the deck
                List<Card> cards = new DeckService().DealCards(ref Deck, p.Discard.Count);

                //pass the draw onto the player
                PlayersList.Draw(p, cards);
            }
        }

        //get the players hand by seat
        public List<Card> GetPlayerHand(int seat)
        {
            return PlayersList.GetHand(seat);
        }

        public List<Player> GetPlayers()
        {
            return PlayersList.GetPlayers();
        }

    }
}
