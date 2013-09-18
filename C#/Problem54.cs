using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace EulerProblem
{
    public static class Problem54
    {
        public static bool DidPlayerOneWin(string onehand)
        {
            var playerOneHands = new Hands(onehand.Substring(0,15));
            var playerTwoHands = new Hands(onehand.Substring(15,14));
            var playerOneHandRank = playerOneHands.HandRank();
            var playerTwoHandRank = playerTwoHands.HandRank();
            if (playerOneHandRank > playerTwoHandRank) return true;
            if (playerOneHandRank < playerTwoHandRank) return false;
            if(playerOneHandRank == 9 || playerOneHandRank == 6 || playerOneHandRank == 5 || playerOneHandRank == 1)
            {
                return Hands.HighestRank(playerOneHands.hands.OrderByDescending(hand => hand.CardNumber).ToList(), playerTwoHands.hands.OrderByDescending(hand => hand.CardNumber).ToList());
            }
            if(playerOneHandRank == 8)
            {
                return Hands.HighestRank(playerOneHands.FourOfAKind(), playerTwoHands.FourOfAKind());
            }
            if(playerOneHandRank == 7 || playerOneHandRank == 4 )
            {
                return Hands.HighestRank(playerOneHands.ThreeOfAKind(), playerTwoHands.ThreeOfAKind());
            }
            if(playerOneHandRank == 2 || playerOneHandRank == 3)
            {
                return Hands.HighestRank(playerOneHands.NumberOfPairs(), playerTwoHands.NumberOfPairs());
            }
            return false;
        }


        public static int PlayerOneWinCount()
        {
            int count = 0;
            var fileStream = File.OpenText("C:\\poker.txt");
            while (!fileStream.EndOfStream)
            {
                if(DidPlayerOneWin(fileStream.ReadLine()))
                {
                    count++;
                }
            }
            return count;
        }
    }

    public class Hands
    {
        public List<Hand> hands;

        public Hands(string hands)
        {
            this.hands = hands.Trim().Split(' ').Select(s => new Hand(s)).OrderBy(hand => hand.CardNumber).ToList();
        }

        public static bool HighestRank(List<Hand> playerOneHands, List<Hand> playerTwoHands)
        {
            for (int i = 0; i < playerOneHands.Count; i++)
            {
                if (playerOneHands[i].CardNumber == playerTwoHands[i].CardNumber) continue;
                return (playerOneHands[i].CardNumber > playerTwoHands[i].CardNumber);
            }
            return true;
        }
        public int HandRank()
        {
            if (RoyalFlush()) return 10;
            if (StraightFlush()) return 9;
            if (FourOfAKind().Count==2) return 8;
            if (FullHouse()) return 7;
            if (Flush()) return 6;
            if (Straight()) return 5;
            if (ThreeOfAKind().Count==3) return 4;
            if (HasTwoPairs()) return 3;
            if (HasOnePair()) return 2;
            return 1;
        }
        public bool HasOnePair()
        {
            return NumberOfPairs().Count == 4;
        }

        public bool HasTwoPairs()
        {
            return NumberOfPairs().Count == 3;
        }

        public List<Hand> NumberOfPairs()
        {
            var pairs = new List<Hand>();
            var temp = new List<Hand>(hands);
            var orderdHands = hands.OrderBy(hand => hand.CardNumber).ToList();
            for (int i = 0; i < orderdHands.Count() - 1; i++)
            {
                if (orderdHands[i].IsSameRank(orderdHands[i + 1]))
                {
                    pairs.Add(orderdHands[i]);
                    temp.RemoveAll(hand => hand.IsSameRank(orderdHands[i]));
                    i += 1;
                }
            }
            var list = pairs.OrderByDescending(hand1 => hand1.CardNumber).ToList();
            list.AddRange(temp.OrderByDescending(hand2 => hand2.CardNumber));
            return list;
        }

        public List<Hand> ThreeOfAKind()
        {
            var list = new List<Hand>();
            var temp = new List<Hand>(hands);
            var orderdHands = hands.OrderBy(hand => hand.CardNumber).ToList();
            for (int i = 0; i < orderdHands.Count() - 2; i++)
            {
                if (orderdHands[i].IsSameRank(orderdHands[i + 1]) && orderdHands[i + 2].IsSameRank(orderdHands[i + 1]))
                {
                    temp.RemoveAll(hand => hand.IsSameRank(orderdHands[i]));
                    list.Add(orderdHands[i]);
                }
            }
            var hands1 = list.OrderByDescending(hand1 => hand1.CardNumber).ToList();
            hands1.AddRange(temp.OrderByDescending(hand2 => hand2.CardNumber));
            return hands1;
        }

        public List<Hand> FourOfAKind()
        {
            var list = new List<Hand>();
            var temp = new List<Hand>(hands);
            var orderdHands = hands.OrderBy(hand => hand.CardNumber).ToList();
            for (int i = 0; i < orderdHands.Count() - 3; i++)
            {
                if (orderdHands[i].IsSameRank(orderdHands[i + 1]) && orderdHands[i + 2].IsSameRank(orderdHands[i + 1]) && orderdHands[i + 3].IsSameRank(orderdHands[i + 1]))
                {
                    temp.RemoveAll(hand => hand.IsSameRank(orderdHands[i]));
                    list.Add(orderdHands[i]);

                }
            }
            var hands1 = list.OrderByDescending(hand1 => hand1.CardNumber).ToList();
            hands1.AddRange(temp.OrderByDescending(hand2 => hand2.CardNumber));
            return hands1;
        }

        public  bool Straight()
        {
            var orderdHands = hands.OrderBy(hand => hand.CardNumber).ToList();
            for (int i = 0; i < orderdHands.Count() - 1; i++)
            {
                if (!orderdHands[i].IsNextRank(orderdHands[i + 1])) return false;
            }
            return true;
        }

        public bool Flush()
        {
            return hands.All(hand => hand.IsSameSuit(hands[0]));
        }

        public bool FullHouse()
        {
            var list = new List<Hand>(hands);
            List<Hand> threeOfAKind = ThreeOfAKind();
            if (threeOfAKind.Count != 0) return false;
            hands.RemoveAll(hand => threeOfAKind.Any(hand1 => hand1.IsSameRank(hand)));
            var hasOnePair = HasOnePair();
            hands = list;
            return hasOnePair;
        }

        public bool StraightFlush()
        {
            return Flush() && Straight();
        }

        public bool RoyalFlush()
        {
            return Flush() && Straight() && hands.OrderBy(hand => hand.CardNumber).First().IsSameRank(new Hand("TD"));
        }
    }

    public class Hand
    {
        public int CardNumber { get; set; }

        public string Suit { get; set; }

        public Hand(int cardNumber, string suit)
        {
            CardNumber = cardNumber;
            Suit = suit;
        }

        public Hand(string hand)
        {
            CardNumber = hand[0]=='J'?11:(hand[0]=='Q'?12:(hand[0]=='K'?13:hand[0]=='A'?14:(hand[0]=='T'?10:int.Parse(hand[0].ToString()))));
            Suit = hand[1].ToString();
        }
        public  bool IsSameRank(Hand hand)
        {
            return hand.CardNumber == CardNumber;
        }

        public  bool IsNextRank(Hand hand)
        {
            return hand.CardNumber - CardNumber == 1 || hand.CardNumber - CardNumber == -12;
        }

        public  bool IsSameSuit(Hand hand)
        {
            return hand.Suit == Suit;
        }
    }


  
}