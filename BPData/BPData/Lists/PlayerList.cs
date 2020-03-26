using System;
using System.Collections.Generic;
using System.Text;
using BPData.Models;
using BPData.Lists;
using System.Linq;
using BPData.Services;

namespace BPData.Lists
{
    public class PlayerList
    {
        //the underlying list
        private List<Player> Players = null;

        
        /// <summary>
        /// defalut ctr
        /// </summary>
        public PlayerList()
        {
            Players = new List<Player>();
        }

        /// <summary>
        /// return the underlying list of players
        /// </summary>
        /// <returns></returns>
        public List<Player> GetPlayers()
        {
            return Players;
        }

        /// <summary>
        /// get a player by seat
        /// </summary>
        /// <param name="seat"></param>
        /// <returns></returns>
        public Player GetPlayerBySeat(int seat)
        {
            foreach(Player player in Players)
            {
                if(player.Seat == seat)
                {
                    return player;
                }
            }

            return null;
        }

        /// <summary>
        /// get the player index into the list by seat
        /// </summary>
        /// <param name="seat"></param>
        /// <returns></returns>
        private int GetPlayerIndexBySeat(int seat)
        {
            int i = 0;
            foreach (Player player in Players)
            {
                if (player.Seat == seat)
                {
                    return i;
                }

                i++;
            }

            return -1;
        }

        /// <summary>
        /// add a player by seat
        /// </summary>
        /// <param name="player"></param>
        /// <returns></returns>
        public bool Add(Player player)
        {
            //check if already added and delete and re-add if thats the case
            int index = -1;
            int i = -1;
            foreach(Player p in Players)
            {
                i++;
                if(p.Seat == player.Seat && p.Name == player.Name)
                {
                    index = i;
                }
            }
            if(index != -1)
            {
                Players.RemoveAt(index);
            }

            Players.Add(player);
            return true;
        }

        /// <summary>
        /// remove a player by seat
        /// </summary>
        /// <param name="seat"></param>
        public void Remove(int seat)
        {
            Players.RemoveAt(GetPlayerIndexBySeat(seat));
        }

        /// <summary>
        /// fold a player by seat
        /// </summary>
        /// <param name="seat"></param>
        public void Fold(int seat)
        {
            Player player = GetPlayerBySeat(seat);
            if(player != null)
            {
                player.HandRank = new Rank();
                player.Discard = new List<Card>();
                player.Hand = new List<Card>();
            }
        }

        /// <summary>
        /// init all players hands
        /// </summary>
        public void InitHand()
        {
            //clear hands of all the players
            foreach (Player p in Players)
            {
                p.InitHand();
            }
        }
        
        /// <summary>
        /// deal cards to all players
        /// </summary>
        /// <param name="deck"></param>
        /// <param name="cardCount"></param>
        public void Deal(ref List<Card> deck, short cardCount)
        {
            DeckService ds = new DeckService();

            //deal hands to all the players
            for (short i = 0; i < cardCount; i++)
            {
                //each player gets 1 card
                foreach (Player p in Players)
                {
                    Deal(p, ds.DealCards(ref deck, BPConstants.OneCard));
                }
            }

            //eval the hand
            EvalService eval = new EvalService();
            //each player gets 1 card
            foreach (Player p in Players)
            {
                p.HandRank = eval.Evaluate(p.Hand);
            }
        }

        /// <summary>
        /// deal 1 player x number of cards
        /// </summary>
        /// <param name="player"></param>
        /// <param name="cards"></param>
        public void Deal(Player player, List<Card> cards)
        {
            if (player != null)
            {
                player.Hand.AddRange(cards);
            }
        }
       
        /// <summary>
        /// discard cards by seat
        /// </summary>
        /// <param name="seat"></param>
        /// <param name="cards"></param>
        public void Discard(int seat, List<Card> cards)
        {
            Player player = GetPlayerBySeat(seat);
            if (player != null)
            {
                Discard(player, cards);
            }
        }

        /// <summary>
        /// discard cards by player
        /// </summary>
        /// <param name="player"></param>
        /// <param name="discards"></param>
        public void Discard(Player player, List<Card> discards)
        {
            if (player != null)
            {
                if (discards != null)
                {
                    if (discards.Count > 0)
                    {
                        //keep the discarded cards
                        player.Discard = discards;

                        //build a new hand minus the discarded cards
                        List<Card> newhand = new List<Card>();
                        foreach (Card card in player.Hand)
                        {
                            if (!card.Discard)
                            {
                                newhand.Add(card);
                            }
                        }

                        player.Hand = newhand;

                        //eval the hand
                        EvalService eval = new EvalService();
                        player.HandRank = eval.Evaluate(player.Hand);
                    }
                }
            }
        }

        /// <summary>
        /// draw cards
        /// </summary>
        /// <param name="player"></param>
        /// <param name="cards"></param>
        public void Draw(Player player, List<Card> cards)
        {
            if (player != null)
            {
                //keep the draw
                player.Draw = cards;

                //add to hand also
                player.Hand.AddRange(cards);

                //eval the hand
                EvalService eval = new EvalService();
                player.HandRank = eval.Evaluate(player.Hand);
            }
        }

        /// <summary>
        /// get players hand by seat
        /// </summary>
        /// <param name="seat"></param>
        /// <returns></returns>
        public List<Card> GetHand(int seat)
        {
            Player player = GetPlayerBySeat(seat);
            if (player != null)
            {
                return player.Hand;
            }

            return null;
        }

        /// <summary>
        /// get player by player?? todo: why do i need this??
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public Player GetPlayer(Player p)
        {
            foreach(Player player in Players)
            {
                if(player.Seat == p.Seat && player.Name == p.Name)
                {
                    return player;
                }

            }

            return null;
        }

        /// <summary>
        /// choose winners
        /// </summary>
        public void ChooseWinners()
        {
            short highestRank = 0;

            foreach (Player player in Players)
            {
                if(player.HandRank.Value > highestRank)
                {
                    highestRank = player.HandRank.Value;
                }
            }

            int totalValue = 0;
            foreach (Player player in Players)
            {
                if (player.HandRank.Value == highestRank)
                {
                    //todo: just a weighted hack of some kind for ties will refine later...
                    player.HandRank.TotalValue =
                        player.HandRank.Value * 1000 +
                        player.HandRank.Four * 10000 +
                        player.HandRank.High * 1000 +
                        player.HandRank.Pair * 1000 +
                        player.HandRank.Pair2 * 100 +
                        player.HandRank.Straight * 1000 +
                        player.HandRank.Three * 10000 +
                        player.HandRank.Flush * 10000 +
                        player.HandRank.Tie1 +
                        player.HandRank.Tie2 +
                        player.HandRank.Tie3 +
                        player.HandRank.Tie4 +
                        player.HandRank.Tie5;

                    if (player.HandRank.TotalValue > totalValue)
                    {
                        totalValue = player.HandRank.TotalValue;
                    }
                }
            }

            int winnerCount = 0;
            foreach (Player player in Players)
            {
                if (player.HandRank.TotalValue == totalValue)
                {
                    winnerCount++;
                    player.HandRank.Winner = true;
                }

                if (player.HandRank.Winner)
                {
                    player.Wins += 1;
                }
                else
                {
                    player.Losses += 1;
                }
            }

        }

    }
}
