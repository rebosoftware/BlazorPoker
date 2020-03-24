using System;
using System.Collections.Generic;
using System.Text;

namespace BPData
{
    public static class BPConstants
    {
        public const short Spade = 1;
        public const string SpadeDescr = "Spade";
        public const string SpadeDescrPlural = "Spades";

        public const short Heart = 2;
        public const string HeartDescr = "Heart";
        public const string HeartDescrPlural = "Hearts";

        public const short Club = 3;
        public const string ClubDescr = "Club";
        public const string ClubDescrPlural = "Clubs";

        public const short Diamond = 4;
        public const string DiamondDescr = "Diamond";
        public const string DiamondDescrPlural = "Diamonds";

        public const short DeckCount = 52;
        public const short SuiteCount = 4;
        public const short CardsInSuite = 13;
        
        public const short AceLow = 1;
        public const short AceHigh = 14;

        public const short Duece = 2;
        public const short Three = 3;
        public const short Four = 4;
        public const short Five = 5;
        public const short Six = 6;
        public const short Seven = 7;
        public const short Eight = 8;
        public const short Nine = 9;
        public const short Ten = 10;
        public const short Jack = 11;
        public const short Queen = 12;
        public const short King = 13;


        public const string AceDescr = "Ace";
        public const string DueceDescr = "Duece";
        public const string ThreeDescr = "Three";
        public const string FourDescr = "Four";
        public const string FiveDescr = "Five";
        public const string SixDescr = "Six";
        public const string SevenDescr = "Seven";
        public const string EightDescr = "Eight";
        public const string NineDescr = "Nine";
        public const string TenDescr = "Ten";
        public const string JackDescr = "Jack";
        public const string QueenDescr = "Queen";
        public const string KingDescr = "King";

        public const string AceDescrPlural = "Aces";
        public const string DueceDescrPlural = "Dueces";
        public const string ThreeDescrPlural = "Threes";
        public const string FourDescrPlural = "Fours";
        public const string FiveDescrPlural = "Fives";
        public const string SixDescrPlural = "Sixes";
        public const string SevenDescrPlural = "Sevens";
        public const string EightDescrPlural = "Eights";
        public const string NineDescrPlural = "Nines";
        public const string TenDescrPlural = "Tens";
        public const string JackDescrPlural = "Jacks";
        public const string QueenDescrPlural = "Queens";
        public const string KingDescrPlural = "Kings";


        public const short GS_PreGame = 14;
        public const short GS_WaitForPlayers = 24;

        public const short GS_ShuffleDeck = 15;
        public const short GS_Deal = 16;
        //todo add betting later
        public const short GS_WaitForDiscard = 17;
        public const short GS_Discard = 17;
        public const short GS_Draw = 18;

        public const short GS_EvaluateHands = 19;
        public const short GS_PickWinner = 20;

        public const short Dealer = 21;
        public const short Computer = 21;

        public const short Player = 22;
        public const short Hidden = 55;
        public const short Unknown = 23;
        public const string UnknownDescr = "Unknown";

        public const string Empty = "";


        public const short InitialValue = 0;

        public const short FiveCards = 5;
        public const short OneCard = 1;

        public const short Rank_HighCard = 1;
        public const string Rank_HighCardDescr = "High Card";

        public const short Rank_Pair = 2;
        public const string Rank_PairDescr = "Pair";

        public const short Rank_2Pair = 3;
        public const string Rank_2PairDescr = "Two Pair";

        public const short Rank_3ofAKind = 4;
        public const string Rank_3ofAKindDescr = "Three of a Kind";

        public const short Rank_Flush = 5;
        public const string Rank_FlushDescr = "Flush";

        public const short Rank_Straight = 6;
        public const string Rank_StraightDescr = "Straight";

        public const short Rank_FullHouse = 7;
        public const string Rank_FullHouseDescr = "Full House";

        public const short Rank_4ofAKind = 8;
        public const string Rank_4ofAKindDescr = "Four of a Kind";

        public const short Rank_StraightFlush = 9;
        public const string Rank_StraightFlushDescr = "Straight Flush";

        public const short Rank_RoyalFlush = 10;
        public const string Rank_RoyalFlushDescr = "Royal Flush";

        public static string GetSuiteName(short value)
        {
            switch (value)
            {
                case BPConstants.Spade:
                    {
                        return BPConstants.SpadeDescr;
                    }

                case BPConstants.Heart:
                    {
                        return BPConstants.HeartDescr;
                    }
                case BPConstants.Diamond:
                    {
                        return BPConstants.DiamondDescr;
                    }
                case BPConstants.Club:
                    {
                        return BPConstants.ClubDescr;
                    }
            }

            return BPConstants.Empty;
        }

        public static string GetSuiteNamePlural(short value)
        {
            switch (value)
            {
                case BPConstants.Spade:
                    {
                        return BPConstants.SpadeDescrPlural;
                    }

                case BPConstants.Heart:
                    {
                        return BPConstants.HeartDescrPlural;
                    }
                case BPConstants.Diamond:
                    {
                        return BPConstants.DiamondDescrPlural;
                    }
                case BPConstants.Club:
                    {
                        return BPConstants.ClubDescrPlural;
                    }
            }

            return BPConstants.Empty;
        }

        public static string GetCardName(short value)
        {
            switch (value)
            {
                case BPConstants.AceHigh:
                case BPConstants.AceLow:
                    {
                        return BPConstants.AceDescr;
                    }
                case BPConstants.Duece:
                    {
                        return BPConstants.DueceDescr;
                    }
                case BPConstants.Three:
                    {
                        return BPConstants.ThreeDescr;
                    }
                case BPConstants.Four:
                    {
                        return BPConstants.FourDescr;
                    }
                case BPConstants.Five:
                    {
                        return BPConstants.FiveDescr;
                    }
                case BPConstants.Six:
                    {
                        return BPConstants.SixDescr;
                    }
                case BPConstants.Seven:
                    {
                        return BPConstants.SevenDescr;
                    }
                case BPConstants.Eight:
                    {
                        return BPConstants.EightDescr;
                    }
                case BPConstants.Nine:
                    {
                        return BPConstants.NineDescr;
                    }
                case BPConstants.Ten:
                    {
                        return BPConstants.TenDescr;
                    }
                case BPConstants.Jack:
                    {
                        return BPConstants.JackDescr;
                    }
                case BPConstants.Queen:
                    {
                        return BPConstants.QueenDescr;
                    }
                case BPConstants.King:
                    {
                        return BPConstants.KingDescr;
                    }
            }

            return BPConstants.Empty;
        }

        public static string GetCardNamePlural(short value)
        {
            switch (value)
            {
                case BPConstants.AceHigh:
                case BPConstants.AceLow:
                    {
                        return BPConstants.AceDescrPlural;
                    }
                case BPConstants.Duece:
                    {
                        return BPConstants.DueceDescrPlural;
                    }
                case BPConstants.Three:
                    {
                        return BPConstants.ThreeDescrPlural;
                    }
                case BPConstants.Four:
                    {
                        return BPConstants.FourDescrPlural;
                    }
                case BPConstants.Five:
                    {
                        return BPConstants.FiveDescrPlural;
                    }
                case BPConstants.Six:
                    {
                        return BPConstants.SixDescrPlural;
                    }
                case BPConstants.Seven:
                    {
                        return BPConstants.SevenDescrPlural;
                    }
                case BPConstants.Eight:
                    {
                        return BPConstants.EightDescrPlural;
                    }
                case BPConstants.Nine:
                    {
                        return BPConstants.NineDescrPlural;
                    }
                case BPConstants.Ten:
                    {
                        return BPConstants.TenDescrPlural;
                    }
                case BPConstants.Jack:
                    {
                        return BPConstants.JackDescrPlural;
                    }
                case BPConstants.Queen:
                    {
                        return BPConstants.QueenDescrPlural;
                    }
                case BPConstants.King:
                    {
                        return BPConstants.KingDescrPlural;
                    }
            }

            return BPConstants.Empty;
        }


    }
}
