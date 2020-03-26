using System;
using System.Collections.Generic;
using System.Text;
using BPData.Models;
using BPData.Lists;
using System.Linq;

namespace BPData.Models
{
    public class Player
    {
        public int Wins { get; set; }
        public int Losses { get; set; }
        public string Name { get; set; }

        //dealer, player, 
        public short Type { get; set; }

        //false if the player is a computer and not a human
        //if not human then they autodiscard
        public bool Human { get; set; }

        //where is the player seated 1 based
        public int Seat { get; set; }

        public List<Card> Hand { get; set; }

        public List<Card> Draw { get; set; }

        public List<Card> Discard { get; set; }

        public Rank HandRank { get; set; }

        /// <summary>
        /// mark a card discarded
        /// </summary>
        /// <param name="card"></param>
        /// <param name="discard"></param>
        public void DiscardCard(Card card, bool discard)
        {
            foreach(Card c in Hand)
            {
                if(c.DeckID == card.DeckID)
                {
                    c.Discard = discard;
                }
            }
        }

        /// <summary>
        /// init hand
        /// </summary>
        public void InitHand()
        {
            Hand.Clear();
            Discard.Clear();
            HandRank = new Rank();
        }

        /// <summary>
        /// default ctr
        /// </summary>
        public Player()
        {
            Name = "";
            Type = BPConstants.Unknown;
            Seat = BPConstants.InitialValue;
            Hand = new List<Card>();
            Discard = new List<Card>();
            HandRank = new Rank();
            Human = true;
            Wins = 0;
            Losses = 0;
        }

    }
}
