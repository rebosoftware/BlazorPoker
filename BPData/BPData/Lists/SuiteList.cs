using System;
using System.Collections.Generic;
using System.Text;
using BPData.Models;

namespace BPData.Lists
{
    public class SuiteList 
    {
        //the underlying suite list
        private List<Suite> Suites = null;
        
        //default ctr builds a list of suites
        public SuiteList()
        {
            Suites = new List<Suite>();

            Suite spades = new Suite(BPConstants.Spade, "Spade", "Spades");
            Suite hearts = new Suite(BPConstants.Heart, "Heart", "Hearts");
            Suite clubs = new Suite(BPConstants.Club, "Club", "Clubs");
            Suite diamonds = new Suite(BPConstants.Diamond, "Diamond", "Diamonds");

            Suites.Add(spades);
            Suites.Add(hearts);
            Suites.Add(clubs);
            Suites.Add(diamonds);
        }

        //return the underlying list of suites
        public List<Suite> GetSuites()
        {
            return Suites;
        }

        //get a suite by its id
        public Suite GetSuite(short id)
        {
            foreach(Suite suite in Suites)
            {
                if(suite.ID == id)
                {
                    return suite;
                }
            }

            return null;
        }
    }
}
