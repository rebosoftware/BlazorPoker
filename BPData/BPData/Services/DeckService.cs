using System;
using System.Collections.Generic;
using System.Text;
using BPData.Models;
using BPData.Lists;

namespace BPData.Services
{
    public class DeckService
    {
    
        /// <summary>
        /// gets a deck of 52 cards unsorted
        /// </summary>
        /// <returns></returns>
        public List<Card> GetDeck()
        {
            return new CardList().GetCards();
        }

        /// <summary>
        /// sorts the deck passed in, if deck is null sorts a pristine deck
        /// </summary>
        /// <param name="cards"></param>
        /// <returns></returns>
        public List<Card> ShuffleDeck(List<Card> deck)
        {
            if (deck == null)
            {
                deck = new CardList().GetCards();
            }

            return new CardList().ShuffleCards();
        }

        /// <summary>
        /// return x number of cards and remove them from the deck
        /// </summary>
        /// <param name="deck"></param>
        /// <param name="cardCount"></param>
        /// <returns></returns>
        public List<Card> DealCards(ref List<Card> deck, int cardCount)
        {
            List<Card> cards = new List<Card>();
            for(int i=0; i< cardCount; i++)
            {
                cards.Add(deck[i]);
            }

            deck.RemoveRange(0, cardCount);

            return cards;            
        }

    }
}
