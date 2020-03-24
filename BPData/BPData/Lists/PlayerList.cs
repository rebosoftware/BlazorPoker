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

        //default ctr builds a list of suites
        public PlayerList()
        {
            Players = new List<Player>();
        }

        //return the underlying list of suites
        public List<Player> GetPlayers()
        {
            return Players;
        }

        //get a player by seat
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

        //get a player index by seat
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

        //add a player
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

        //remove a player by seat
        public void Remove(int seat)
        {
            Players.RemoveAt(GetPlayerIndexBySeat(seat));
        }

        //fold a player by seat
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

        //init the players hand
        public void InitHand()
        {
            //clear hands of all the players
            foreach (Player p in Players)
            {
                p.InitHand();
            }
        }
        
        //deal cards to the players
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

        //deal 1 player a list of cards
        public void Deal(Player player, List<Card> cards)
        {
            if (player != null)
            {
                player.Hand.AddRange(cards);
            }
        }
       

        public void Discard(int seat, List<Card> cards)
        {
            Player player = GetPlayerBySeat(seat);
            if (player != null)
            {
                Discard(player, cards);
            }
        }

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

        //draw cards
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

        //hand is made up of hand and draw cards
        public List<Card> GetHand(int seat)
        {
            Player player = GetPlayerBySeat(seat);
            if (player != null)
            {
                return player.Hand;
            }

            return null;
        }

        //todo
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
            }

        }

    }
}
