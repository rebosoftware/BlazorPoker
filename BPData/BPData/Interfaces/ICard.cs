using System;
using System.Collections.Generic;
using System.Text;

namespace BPData.Interfaces
{
    interface ICard
    {
        short DeckID { get; set; }

        short Value { get; set; }

        short SuiteID { get; set; }
      
        string Name { get; set; }

        string NamePlural { get; set; }

        string ImageName { get; set; }

        string FullName { get; set; }

        Guid SortOrder { get; set; }
    }
}
