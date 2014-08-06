using System;
using System.Collections.Generic;
using System.Linq;

namespace Poker
{
    public class PokerHandsChecker : IPokerHandsChecker
    {

        private int[] GetSortedCountOfFaces(IHand hand)
        {
            int[] faces = new int[15];
            for (int i = 0; i < hand.Cards.Count; i++)
            {
                faces[(int)hand.Cards[i].Face]++;
            }
            Array.Sort(faces);
            Array.Reverse(faces);
            return faces;
        }

        public bool IsValidHand(IHand hand)
        {
            if (hand.Cards.Count != 5)
            {
                return false;
            }
            for (int i = 0; i < hand.Cards.Count; i++)
            {
                for (int j = 0; j < hand.Cards.Count; j++)
                {
                    if ((i != j) && (hand.Cards[i].Equals(hand.Cards[j])))
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public bool IsStraightFlush(IHand hand)
        {

            return IsStraight(hand) && IsFlush(hand);
        }

        public bool IsFourOfAKind(IHand hand)
        {
            return GetSortedCountOfFaces(hand)[0] == 4;
        }

        public bool IsFullHouse(IHand hand)
        {
            int[] faces = GetSortedCountOfFaces(hand);
            return faces[0] == 3 && faces[1] == 2;
        }

        public bool IsFlush(IHand hand)
        {
            for (int i = 1; i < hand.Cards.Count; i++)
            {
                if (hand.Cards[i].Suit != hand.Cards[0].Suit)
                {
                    return false;
                }
            }
            return true;
        }

        public bool IsStraight(IHand hand)
        {
            CardFace[] faces = new CardFace[5];
            for (int i = 0; i < hand.Cards.Count; i++)
            {
                faces[i] = hand.Cards[i].Face;
            }
            Array.Sort(faces);
            for (int i = 1; i < hand.Cards.Count; i++)
            {
                if (faces[i] - faces[i - 1] != 1)
                {
                    return false;
                }
            }
            return true;
        }

        public bool IsThreeOfAKind(IHand hand)
        {
            return GetSortedCountOfFaces(hand)[0] == 3;
        }

        public bool IsTwoPair(IHand hand)
        {
            int[] faces = GetSortedCountOfFaces(hand);
            return faces[0] == 2 && faces[1] == 2;
        }

        public bool IsOnePair(IHand hand)
        {
            return GetSortedCountOfFaces(hand)[0] == 2;
        }

        public bool IsHighCard(IHand hand)
        {
            return GetSortedCountOfFaces(hand)[0] == 1;
        }

        public int CompareHands(IHand firstHand, IHand secondHand)
        {

            // Sorry, no time for this. I know how to implement, but don't have a time :) JS exam coming.
            throw new NotImplementedException();
        }
    }
}
