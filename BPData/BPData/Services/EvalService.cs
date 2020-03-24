using System;
using System.Collections.Generic;
using System.Text;
using BPData.Models;
using BPData.Lists;
using System.Linq;

namespace BPData.Services
{
    public class EvalService
    {
        /// <summary>
        /// evaluates a 5 card hand and returns info about the ranking
        /// </summary>
        /// <param name="hand"></param>
        /// <returns></returns>
        public Rank Evaluate(List<Card> hand)
        {
            //info about the ranking of the hand
            Rank rank = new Rank();

            //basic check for null and 5 cards
            if (!CheckHand(hand))
            {
                return rank;
            }

            //ace is 1 only if its a 5 4 2 3 1 straight
            //it defaults to 14 so we adjust it here for this one specific case
            //where the ace is not the high card in the hand
            AdjustForAceLowStraight(ref hand);
            
            //sort the cards descending
            List<Card> sortedhand = hand.OrderByDescending(x => x.Value).ToList();

            if (IsRoyalFlush(sortedhand, ref rank)) { return rank; }
            if (IsStraightFlush(sortedhand, ref rank)) { return rank; }
            if (Is4ofAKind(sortedhand, ref rank)) { return rank; }
            if (IsFullHouse(sortedhand, ref rank)) { return rank; }
            if (IsFlush(sortedhand, ref rank)) { return rank; }
            if (IsStraight(sortedhand, ref rank)) { return rank; }
            if (Is3ofAKind(sortedhand, ref rank)) { return rank; }
            if (Is2Pair(sortedhand, ref rank)) { return rank; }
            if (IsPair(sortedhand, ref rank)) { return rank; }
            if (IsHighCard(sortedhand, ref rank)) { return rank; }
                       
            return rank;
        }

        /// <summary>
        /// helper to check the hand basics
        /// </summary>
        /// <param name="hand"></param>
        /// <returns></returns>
        private bool CheckHand(List<Card> hand)
        {
            if (hand == null) { return false; }
            if (hand.Count != 5) { return false; }

            return true;
        }

        /// <summary>
        /// is the hand an ace low straight
        /// </summary>
        /// <param name="hand"></param>
        /// <returns></returns>
        private void AdjustForAceLowStraight(ref List<Card> hand)
        {
            //sort the cards for comparison
            List<Card> sortedhand = hand.OrderByDescending(x => x.Value).ToList();

            if (sortedhand[0].Value != BPConstants.AceHigh) { return; }//14
            if (sortedhand[1].Value != BPConstants.Five) { return; }
            if (sortedhand[2].Value != BPConstants.Four) { return; }
            if (sortedhand[3].Value != BPConstants.Three) { return; }
            if (sortedhand[4].Value != BPConstants.Duece) { return; }

            //its a 1,2,3,4,5 straight so switch the ace value
            sortedhand[0].Value = BPConstants.AceLow;
        }

        /// <summary>
        /// high card
        /// </summary>
        /// <param name="hand"></param>
        /// <param name="rank"></param>
        /// <returns></returns>
        private bool IsHighCard(List<Card> hand, ref Rank rank)
        {
            rank.Value = BPConstants.Rank_HighCard;
            rank.Name = "High Card";

            rank.High = hand[0].Value;

            rank.Tie1 = hand[1].Value;
            rank.Tie2 = hand[2].Value;
            rank.Tie3 = hand[3].Value;
            rank.Tie4 = hand[4].Value;

            return true;
        }

        /// <summary>
        /// pair
        /// </summary>
        /// <param name="hand"></param>
        /// <param name="rank"></param>
        /// <returns></returns>
        private bool IsPair(List<Card> hand, ref Rank rank)
        {
            Card first = hand[0];
            foreach (Card c in hand)
            {
                short value = c.Value;
                int count = 0;
             
                foreach (Card c2 in hand)
                {
                    if (c2.Value == c.Value)
                    {
                        count++;
                    }
                }

                if (count == 2)
                {
                    rank.Pair = value;
                    rank.Name = BPConstants.Rank_PairDescr;
                    rank.Value = BPConstants.Rank_Pair;

                    //3 remaining cards used for compares
                    int nFind = 1;
                    foreach (Card c3 in hand)
                    {
                        if (c3.Value != rank.Pair)
                        {
                            if (nFind == 1)
                            {
                                rank.Tie1 = c3.Value;
                                nFind++;
                            }
                            else if(nFind == 2)
                            {
                                rank.Tie2 = c3.Value;
                                nFind++;
                            }
                            else 
                            {
                                rank.Tie3 = c3.Value;
                            }
                        }
                    }

                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// is 2 pair
        /// </summary>
        /// <param name="hand"></param>
        /// <param name="rank"></param>
        /// <returns></returns>
        private bool Is2Pair(List<Card> hand, ref Rank rank)
        {
            short pair1HighCardValue = 0;
            int pairCount = 0;
            short lastPairVal = 0;

            Card first = hand[0];
            foreach (Card c in hand)
            {
                short value = c.Value;
                int count = 0;
                

                foreach (Card c2 in hand)
                {
                    if (c2.Value == c.Value)
                    {
                        if (c2.Value != lastPairVal)
                        {
                            count++;
                        }
                    }
                }

                if (count == 2)
                {
                    pairCount += 1;
                    lastPairVal = c.Value;

                    if (pairCount == 1)
                    {
                        pair1HighCardValue = value;
                    }
                    else
                    {
                        rank.Pair = pair1HighCardValue;
                        rank.Pair2 = value;
                        rank.Name = BPConstants.Rank_2PairDescr;
                        rank.Value = BPConstants.Rank_2Pair;

                        foreach (Card c3 in hand)
                        {
                            if (c3.Value != rank.Pair)
                            {
                                if (c3.Value != rank.Pair2)
                                {
                                    //high cards for tie compares can only be 1 for 2 pair
                                    rank.Tie1 = c3.Value;
                                    break;
                                }
                            }
                        }

                        return true;
                    }
                }
            }
            
            return false;
        }

        /// <summary>
        /// three of a kind
        /// </summary>
        /// <param name="hand"></param>
        /// <param name="rank"></param>
        /// <returns></returns>
        private bool Is3ofAKind(List<Card> hand, ref Rank rank)
        {
            Card first = hand[0];
            foreach (Card c in hand)
            {
                short value = c.Value;
                int count = 0;

                foreach (Card c2 in hand)
                {
                    if(c2.Value == c.Value)
                    {
                        count++;
                    }
                }

                if(count == 3)
                {
                    rank.Three = value;
                    rank.Name = BPConstants.Rank_3ofAKindDescr;
                    rank.Value = BPConstants.Rank_3ofAKind;

                    //2 remaining cards used for compares
                    bool bFirst = true;
                    foreach (Card c3 in hand)
                    {
                        if (c3.Value != value)
                        {
                            if (bFirst)
                            {
                                rank.Tie1 = c3.Value;
                                bFirst = false;
                            }
                            else
                            {
                                rank.Tie2 = c3.Value;
                            }                           
                        }
                    }

                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// all 5 cards in order
        /// </summary>
        /// <param name="hand"></param>
        /// <returns></returns>
        private bool IsStraight(List<Card> hand, ref Rank rank)
        {
            Card first = hand[0];
            short check = first.Value;

            for (int i = 1; i < hand.Count; i++)
            {
                if ((hand[i].Value + 1) != check)
                {
                    return false;
                }

                check = hand[i].Value;
            }

            rank.Name = BPConstants.Rank_StraightDescr;
            rank.Value = BPConstants.Rank_Straight;

            //all 5 cards used, sorted desc so first one is the high card of the straight
            rank.Straight = hand[0].Value;
            rank.Tie1 = hand[1].Value;

            return true;
        }
        
        /// <summary>
        /// all 5 cards same suite
        /// </summary>
        /// <param name="hand"></param>
        /// <returns></returns>
        private bool IsFlush(List<Card> hand, ref Rank rank)
        {
            Card first = hand[0];
            foreach(Card c in hand)
            {
                if(c.SuiteID != first.SuiteID)
                {
                    return false;
                }
            }

            rank.Name = BPConstants.Rank_FlushDescr;
            rank.Value = BPConstants.Rank_Flush;

            rank.FlushSuite = first.SuiteID;

            //all five cards used for a flush and they are already sorted desc
            //so all five in order for a compare
            rank.Flush = hand[0].Value;

            rank.Tie1 = hand[1].Value;
            rank.Tie2 = hand[2].Value;
            rank.Tie3 = hand[3].Value;
            rank.Tie4 = hand[4].Value;

            return true;
        }

    
        /// <summary>
        /// full house
        /// </summary>
        /// <param name="hand"></param>
        /// <param name="rank"></param>
        /// <returns></returns>
        private bool IsFullHouse(List<Card> hand, ref Rank rank)
        {
            //will set rank.threeOfAKindHighCardValue
            if (Is3ofAKind(hand, ref rank))
            {
                //remove the 3 cards
                List<Card> hand2 = new List<Card>();
                foreach (Card c in hand)
                {
                    if (c.Value != rank.Three)
                    {
                        hand2.Add(c);
                    }
                }

                //will set rank.Tie1, Three set above
                if (IsPair(hand2, ref rank))
                {
                    rank.Value = BPConstants.Rank_FullHouse;
                    rank.Name = BPConstants.Rank_FullHouseDescr;

                    //all 5 cards used so no reason to set highcard1value etc...
                    //ThreeOfAKindHighCardValue and Pair1HighCardValue are already set for compares

                    return true;
                }
            }

             return false;
        }

        /// <summary>
        /// four of a kind
        /// </summary>
        /// <param name="hand"></param>
        /// <param name="rank"></param>
        /// <returns></returns>
        private bool Is4ofAKind(List<Card> hand, ref Rank rank)
        {
            Card first = hand[0];
            foreach (Card c in hand)
            {
                short value = c.Value;
                int count = 0;

                foreach (Card c2 in hand)
                {
                    if (c2.Value == c.Value)
                    {
                        count++;
                    }
                }

                if (count == 4)
                {
                    rank.Four = value;
                    rank.Name = BPConstants.Rank_4ofAKindDescr;
                    rank.Value = BPConstants.Rank_4ofAKind;

                    foreach (Card c3 in hand)
                    {
                        if (c3.Value != value)
                        {
                            //high cards for tie compares can only be 1 for 4 of a kind
                            rank.Tie1 = c3.Value;
                            break;
                        }
                    }

                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// straight flush
        /// </summary>
        /// <param name="hand"></param>
        /// <param name="rank"></param>
        /// <returns></returns>
        private bool IsStraightFlush(List<Card> hand, ref Rank rank)
        {
            if (IsFlush(hand, ref rank))
            {
                if (IsStraight(hand, ref rank))
                {
                    rank.Name = BPConstants.Rank_StraightFlushDescr;
                    rank.Value = BPConstants.Rank_StraightFlush;

                    //high cards for tie compares, straight so can only be 1 the high card of the straight
                    rank.Tie1 = hand[0].Value;
                    
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// royal flush
        /// </summary>
        /// <param name="hand"></param>
        /// <param name="rank"></param>
        /// <returns></returns>
        private bool IsRoyalFlush(List<Card> hand, ref Rank rank)
        {
            if (IsFlush(hand, ref rank))
            {
                if (IsStraight(hand, ref rank))
                {
                    if (hand[0].Value != BPConstants.AceHigh) { return false; }
                    if (hand[1].Value != BPConstants.King) { return false; }
                    if (hand[2].Value != BPConstants.Queen) { return false; }
                    if (hand[3].Value != BPConstants.Jack) { return false; }
                    if (hand[4].Value != BPConstants.Ten) { return false; }
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }

            rank.Name = BPConstants.Rank_RoyalFlushDescr;
            rank.Value = BPConstants.Rank_RoyalFlush;

            //no tie breaker possible, this is the highest hand possible
            //and no suite out ranks another so if 2 royal flushes its a tie

            return true;
        }
    }
}
