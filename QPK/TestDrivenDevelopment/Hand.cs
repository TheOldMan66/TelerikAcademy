using System;
using System.Collections.Generic;

namespace Poker
{
    public class Hand : IHand
    {
        private IList<ICard> cards;

        public Hand(IList<ICard> cards)
        {
            this.Cards = cards;
        }
        public IList<ICard> Cards
        {
            get
            {
                return cards;
            }
            private set
            {
                cards = value;
            }
        }

        public override string ToString()
        {
            string result = "";
            for (int i = 0; i < cards.Count; i++)
            {
                result = result + this.cards[i];
                if (i < cards.Count - 1)
                {
                    result = result + ", ";
                }
            }
            return result;
        }
    }
}
