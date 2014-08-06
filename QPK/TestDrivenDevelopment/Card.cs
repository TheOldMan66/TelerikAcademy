using System;

namespace Poker
{
    public class Card : ICard, IEquatable<Card>
    {
        private CardFace face;
        private CardSuit suit;


        public Card(CardFace face, CardSuit suit)
        {
            this.Face = face;
            this.Suit = suit;
        }

        public CardFace Face { 
            get
            {
                return this.face;
            }
            private set
            {
                if((value < CardFace.Two) || (value > CardFace.Ace))
                {
                    throw new ArgumentOutOfRangeException("Invalid card face.");
                }
                this.face = value;
            }
        }
        public CardSuit Suit {
            get
            {
                return this.suit;
            }
            private set
            {
                if ((value < CardSuit.Clubs) || (value > CardSuit.Spades))
                {
                    throw new ArgumentOutOfRangeException("Invalid card suit.");
                }
                this.suit = value;
            }
        }

        public override string ToString()
        {
            return String.Format("{0} of {1}", this.Face, this.Suit);
        }

        public override bool Equals(object obj)
        {
            Card other = obj as Card;
            return this.Equals(other);
        }
        public bool Equals(Card other)
        {
            return this.Face == other.face && this.Suit == other.Suit;
        } 
    }
}
