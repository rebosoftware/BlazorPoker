using System;
using System.Collections.Generic;
using System.Text;
using BPData.Lists;
using BPData.Models;
using BPData.Services;

namespace BPData.Models
{
    public class Rank
    {

        //weighted value of hand
        public short Value { get; set; }

        //total value including tie breaker
        public int TotalValue { get; set; }

        //name ie. Straight
        public string Name { get; set; }

        public bool Winner { get; set; }

        //full name ie: Pair: Aces
        public string FullName 
        {
            get
            {
                string full = Name;
                switch (Value)
                {
                    case BPConstants.Rank_HighCard:
                        {
                            full += ": ";
                            full += BPConstants.GetCardName(this.High);
                            break; 
                        }
                    case BPConstants.Rank_Pair:
                        {
                            full += " of ";
                            full += BPConstants.GetCardNamePlural(this.Pair);
                            break;
                        }
                    case BPConstants.Rank_2Pair:
                        {
                            full += ": ";
                            full += BPConstants.GetCardNamePlural(this.Pair);
                            full += " over ";
                            full += BPConstants.GetCardNamePlural(this.Pair2);
                            break;
                        }

                    case BPConstants.Rank_3ofAKind:
                        {
                            full += ": ";
                            full += BPConstants.GetCardNamePlural(this.Three);
                            break;
                        }

                    case BPConstants.Rank_Flush:
                        {
                            full += ": ";
                            full += BPConstants.GetSuiteNamePlural(this.FlushSuite);
                            full += " ";
                            full += BPConstants.GetCardName(this.Flush);
                            full += " high";

                            break;
                        }

                    case BPConstants.Rank_Straight:
                        {
                            full += ": ";
                            full += BPConstants.GetCardName(this.Straight);
                            full += " high";
                            break;
                        }

                    case BPConstants.Rank_FullHouse:
                        {
                            full += ": ";
                            full += BPConstants.GetCardNamePlural(this.Three);
                            full += " over ";
                            full += BPConstants.GetCardNamePlural(this.Pair);

                            break;
                        }

                    case BPConstants.Rank_4ofAKind:
                        {
                            full += ": ";
                            full += BPConstants.GetCardNamePlural(this.Four);
                            break;
                        }

                    case BPConstants.Rank_StraightFlush:
                        {
                            full += ": ";
                            full += BPConstants.GetCardName(this.Straight);
                            full += " high";
                            break;
                        }

                    case BPConstants.Rank_RoyalFlush:
                        {
                            break;
                        }

                }

                //full += " (Tie Breaker: ";
                //full += BPConstants.GetCardName(this.Tie1);
                //full += ")";

                return full;
            }
        }

        //high card, pair 1, pair 2, 3 of akind and 4 ofa kind
        public short High { get; set; }
        public short Pair { get; set; }
        public short Pair2 { get; set; }
        public short Three { get; set; }
        public short Four { get; set; }
        
        public short Flush { get; set; }
        public short FlushSuite { get; set; }

        public short Straight { get; set; }


        //high cards for tie breakers
        public short Tie1 { get; set; }
        public short Tie2 { get; set; }
        public short Tie3 { get; set; }
        public short Tie4 { get; set; }
        public short Tie5 { get; set; }
        

        public Rank()
        {
            Value = BPConstants.InitialValue;
            Name = BPConstants.Empty;
            
            High = BPConstants.InitialValue;
            Pair = BPConstants.InitialValue;
            Pair2 = BPConstants.InitialValue;
            Three = BPConstants.InitialValue;
            Four = BPConstants.InitialValue;
            Flush = BPConstants.InitialValue;
            FlushSuite = BPConstants.InitialValue;

            Straight = BPConstants.InitialValue;

            Tie1 = BPConstants.InitialValue;
            Tie2 = BPConstants.InitialValue;
            Tie3 = BPConstants.InitialValue;
            Tie4 = BPConstants.InitialValue;
            Tie5 = BPConstants.InitialValue;

            Winner = false;
        }

    }
}
