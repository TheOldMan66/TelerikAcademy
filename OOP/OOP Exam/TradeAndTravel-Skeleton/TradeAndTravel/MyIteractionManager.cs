using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeAndTravel
{
    public class MyIteractionManager : InteractionManager
    {
        protected override Item CreateItem(string itemTypeString, string itemNameString, Location itemLocation, Item item)
        {
            item = base.CreateItem(itemTypeString, itemNameString, itemLocation, item);
            if (item != null)
                return item;
            switch (itemTypeString)
            {
                case "weapon":
                    item = new Weapon(itemNameString, itemLocation);
                    break;
                case "wood":
                    item = new Wood(itemNameString, itemLocation);
                    break;
                case "iron":
                    item = new Iron(itemNameString, itemLocation);
                    break;
                default:
                    break;
            }
            return item;
        }
        protected override Location CreateLocation(string locationTypeString, string locationName)
        {
            Location location = base.CreateLocation(locationTypeString, locationName);
            if (location != null)
                return location;
            switch (locationTypeString)
            {
                case "mine":
                    location = new Mine(locationName);
                    break;
                case "forest":
                    location = new Forest(locationName);
                    break;
                default:
                    break;
            }
            return location;
        }
        protected override void HandlePersonCommand(string[] commandWords, Person actor)
        {
            base.HandlePersonCommand(commandWords, actor);
            switch (commandWords[1])
            {
                case "gather":
                    HandleGatherInteraction(actor);
                    break;
                default:
                    break;
            }
        }

        private void HandleGatherInteraction(Person actor)
        {
            foreach (var item in strayItemsByLocation[actor.Location])
            {
                this.AddToPerson(actor, item);
                item.UpdateWithInteraction("gather");
            }
            strayItemsByLocation[actor.Location].Clear();
        }
        protected override Person CreatePerson(string personTypeString, string personNameString, Location personLocation)
        {
            Person person = base.CreatePerson(personTypeString, personNameString, personLocation);
            if (person != null)
            {
                return person;
            }
            switch (personTypeString)
            {
                case "merchant":
                    person = new Merchant(personNameString, personLocation);
                    break;
                default:
                    break;
            }
            return person;
        }
    }
}
