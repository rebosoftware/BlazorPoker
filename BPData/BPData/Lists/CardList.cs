using System;
using System.Collections.Generic;
using System.Text;
using BPData.Models;
using BPData.Lists;
using System.Linq;

namespace BPData.Lists
{
    public class CardList
    {
        //the underlying list
        private List<Card> Cards = null;

        /// <summary>
        /// default ctr builds an unsorted deck of 52 cards
        /// </summary>
        public CardList()
        {
            Cards = new List<Card>();
            SuiteList suites = new SuiteList();
            short deckid = 1;

            //4 suites
            foreach (Suite suite in suites.GetSuites())
            {
                //A 2 3 4 5 6 7 8 9 10  J  Q  K
                //1 2 3 4 5 6 7 8 9 10 11 12 13
                //13 cards each suite
                for(short val=1; val<= BPConstants.CardsInSuite; val++ )
                {
                    //basic card
                    Card card = new Card(deckid, val, suite.ID);

                    //remaining properties
                    SetCardProperties(ref card, deckid, val, suite);

                    Cards.Add(card);
                    
                    deckid++;
                }
            }
        }

        /// <summary>
        /// sets remaining properties of the card
        /// </summary>
        /// <param name="card"></param>
        /// <param name="deckid"></param>
        /// <param name="val"></param>
        /// <param name="suite"></param>
        private void SetCardProperties(ref Card card, short deckid, short val, Suite suite)
        {
            switch (val)
            {
                case BPConstants.AceLow:
                    card.Name = BPConstants.AceDescr;
                    card.NamePlural = BPConstants.AceDescrPlural;
                    card.NickName = "";

                    //default the ace value to ace high instead of low
                    card.Value = BPConstants.AceHigh;
                    break;
                case BPConstants.Duece:
                    card.Name = BPConstants.DueceDescr;
                    card.NamePlural = BPConstants.DueceDescrPlural;
                    card.NickName = "";
                    break;
                case BPConstants.Three:
                    card.Name = BPConstants.ThreeDescr;
                    card.NamePlural = BPConstants.ThreeDescrPlural;
                    card.NickName = "";
                    break;
                case BPConstants.Four:
                    card.Name = BPConstants.FourDescr;
                    card.NamePlural = BPConstants.FourDescrPlural;
                    card.NickName = "";
                    break;
                case BPConstants.Five:
                    card.Name = BPConstants.FiveDescr;
                    card.NamePlural = BPConstants.FiveDescrPlural;
                    card.NickName = "";
                    break;
                case BPConstants.Six:
                    card.Name = BPConstants.SixDescr;
                    card.NamePlural = BPConstants.SixDescrPlural;
                    card.NickName = "";
                    break;
                case BPConstants.Seven:
                    card.Name = BPConstants.SevenDescr;
                    card.NamePlural = BPConstants.SevenDescrPlural;
                    card.NickName = "";
                    break;
                case BPConstants.Eight:
                    card.Name = BPConstants.EightDescr;
                    card.NamePlural = BPConstants.EightDescrPlural;
                    card.NickName = "";
                    break;
                case BPConstants.Nine:
                    card.Name = BPConstants.NineDescr;
                    card.NamePlural = BPConstants.NineDescrPlural;
                    card.NickName = "";
                    break;
                case BPConstants.Ten:
                    card.Name = BPConstants.TenDescr;
                    card.NamePlural = BPConstants.TenDescrPlural;
                    card.NickName = "";
                    break;
                case BPConstants.Jack:
                    card.Name = BPConstants.JackDescr;
                    card.NamePlural = BPConstants.JackDescrPlural;
                    card.NickName = "";
                    break;
                case BPConstants.Queen:
                    card.Name = BPConstants.QueenDescr;
                    card.NamePlural = BPConstants.QueenDescrPlural;
                    card.NickName = "";
                    break;
                case BPConstants.King:
                    card.Name = BPConstants.KingDescr;
                    card.NamePlural = BPConstants.KingDescrPlural;
                    card.NickName = "";
                    break;
            }

            card.FullName = card.Name + " of " + suite.NamePlural;
            card.ImageName = Convert.ToString(deckid) + ".png";

        }

        /// <summary>
        /// returns the underlying list of cards
        /// </summary>
        /// <returns></returns>
        public List<Card> GetCards()
        {
            return Cards;
        }

        /// <summary>
        /// sorts the underlying list of cards
        /// todo: guids may be unique but they are not particuraly random
        /// will re-work this later
        /// </summary>
        /// <returns></returns>
        public List<Card> ShuffleCards()
        {
            //lame shuffle 3 times, works for now...
            for (int i = 0; i < 3; i++)
            {
                foreach (Card card in Cards)
                {
                    card.SortOrder = Guid.NewGuid();
                }

                if (i == 0)
                {
                    Cards = Cards.OrderBy(x => x.SortOrder).ToList();
                }

                if (i == 1)
                {
                    Cards = Cards.OrderByDescending(x => x.SortOrder).ToList();
                }

                if (i == 2)
                {
                    Cards = Cards.OrderBy(x => x.SortOrder).ToList();
                }

            }

            return Cards;
        }

    }
}
