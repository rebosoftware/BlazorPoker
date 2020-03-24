using System;
using System.Collections.Generic;
using System.Text;
using BPData.Models;
using BPData.Interfaces;

namespace BPData.Models
{
    public class Card : ICard
    {
        public short DeckID { get; set; }

        public short Value { get; set; }

        public short SuiteID { get; set; }

        public string Name { get; set; }

        public string NamePlural { get; set; }

        public string ImageName { get; set; }

        public string FullName { get; set; }

        public string NickName { get; set; }

        public Guid SortOrder { get; set; }

        public bool Discard { get; set; }

        public Card(short deckid, short value, short suiteid)
        {
            DeckID = deckid;
            Value = value;
            SuiteID = suiteid;
            Name = "";
            NamePlural = "";
            FullName = "";
            ImageName = "";
            NickName = "";
            Discard = false;
        }

        public Card(short deckid, short value, short suiteid, string name, string nameplural, string fullname, string imagename, string nickname, bool discard)
        {
            DeckID = deckid;
            Value = value;
            SuiteID = suiteid;
            Name = name;
            NamePlural = nameplural;
            FullName = fullname;
            ImageName = imagename;
            NickName = nickname;
            Discard = discard;
        }
    }
}
