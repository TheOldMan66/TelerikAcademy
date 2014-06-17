using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeAndTravel
{
    class Forest : Location, IGatheringLocation
    {
        public Forest(string name)
            : base(name, LocationType.Forest)
        {

        }
        public ItemType GatheredType
        {
            get { return ItemType.Wood; }
        }

        public ItemType RequiredItem
        {
            get { return ItemType.Weapon; }
        }

        public Item ProduceItem(string name)
        {
            throw new NotImplementedException("Forest produce item not implemented");
        }
    }
}
