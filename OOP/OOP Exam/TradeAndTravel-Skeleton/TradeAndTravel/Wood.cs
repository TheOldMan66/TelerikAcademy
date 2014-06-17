using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeAndTravel
{
    public class Wood : Item
    {
        int woodValue = 2;

        public Wood(string name, Location location = null)
            : base(name, 2, ItemType.Wood, location)
        {
        }

        //static List<ItemType> GetComposingItems()
        //{
        //    return new List<ItemType>() { ItemType.Iron,ItemType.Wood };
        //}

        public override void UpdateWithInteraction(string interaction)
        {
            if (interaction == "drop" && woodValue >= 0)
            {
                woodValue--;
            }
        }
    }
}
