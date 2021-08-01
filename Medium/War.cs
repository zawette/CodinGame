using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.Generic;

/**
 * Auto-generated code below aims at helping you parse
 * the standard input according to the problem statement.
 **/
class Solution
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine()); // the number of cards for player 1
        var Player1D = new Queue<string>();
        var Player1TD = new Queue<string>();
        for (int i = 0; i < n; i++)
        {
            string cardp1 = Console.ReadLine(); // the n cards of player 1
            Player1D.Enqueue(cardp1);
        }
        int m = int.Parse(Console.ReadLine()); // the number of cards for player 2
        var Player2D = new Queue<string>();
        var Player2TD = new Queue<string>();
        for (int i = 0; i < m; i++)
        {
            string cardp2 = Console.ReadLine(); // the m cards of player 2
            Player2D.Enqueue(cardp2);
        }

        int round = 1;
        while (Player1D.Count > 0 || Player2D.Count > 0)
        {
            var card1 = Player1D.Dequeue();
            var card2 = Player2D.Dequeue();

            if (card1.getCardValue() == card2.getCardValue())
            {
                if (Player1D.Count < 3 || Player2D.Count < 3)
                {
                    Console.WriteLine("PAT");
                    break;
                }
                else
                {
                    Player1TD.Enqueue(card1);
                    Player1TD.Enqueue(Player1D.Dequeue());
                    Player1TD.Enqueue(Player1D.Dequeue());
                    Player1TD.Enqueue(Player1D.Dequeue());

                    Player2TD.Enqueue(card2);
                    Player2TD.Enqueue(Player2D.Dequeue());
                    Player2TD.Enqueue(Player2D.Dequeue());
                    Player2TD.Enqueue(Player2D.Dequeue());

                }
            }
            else
            {
                Player1TD.Enqueue(card1);
                Player2TD.Enqueue(card2);

                if (card1.getCardValue() > card2.getCardValue())
                {
                    Console.Error.WriteLine("------------------------------");

                    Console.Error.WriteLine($"round : {round}");
                    Player1D = Player1D.merge(Player1TD).merge(Player2TD);
                    Console.Error.WriteLine($" p1 wins : {card1.getCardValue()} vs p2 : {card2.getCardValue()}");
                    Console.Error.WriteLine($"old Player1D count : {Player1D.Count}");

                    Console.Error.WriteLine($"Player1D : {Player1D.Count}");
                    Console.Error.WriteLine($"Player1TD : {Player1TD.Count}");
                    Console.Error.WriteLine($"Player2D : {Player2D.Count}");
                    Console.Error.WriteLine($"Player2TD : {Player2TD.Count}");
                }
                else
                {
                    Console.Error.WriteLine("------------------------------");

                    Console.Error.WriteLine($"round : {round}");

                    Player2D = Player2D.merge(Player1TD).merge(Player2TD);
                    Console.Error.WriteLine($" p1 : {card1.getCardValue()} vs p2  wins: {card2.getCardValue()}");
                    Console.Error.WriteLine($"old Player2D : {Player2D.Count}");

                    Console.Error.WriteLine($"Player1D : {Player1D.Count}");
                    Console.Error.WriteLine($"Player1TD : {Player1TD.Count}");
                    Console.Error.WriteLine($"Player2D : {Player2D.Count}");
                    Console.Error.WriteLine($"Player2TD : {Player2TD.Count}");
                }
                Player1TD.Clear();
                Player2TD.Clear();

                if (Player1D.Count == 0)
                {
                    Console.WriteLine($"2 {round}");
                    break;
                }

                if (Player2D.Count == 0)
                {
                    Console.WriteLine($"1 {round}");
                    break;
                }

                round++;

            }
        }

        // Write an answer using Console.WriteLine()
        // To debug: Console.Error.WriteLine("Debug messages...");

    }


}
public static class DeckUtil
{
    public static int getCardValue(this string val)
    {
        var NumberRegEx = new Regex(@"\d+");
        var containsNumber = NumberRegEx.Match(val);
        if (containsNumber.Success)
        {
            return int.Parse(containsNumber.Value);
        }
        else
        {
            switch (val[0].ToString())
            {
                case "J":
                    return 11;

                case "Q":
                    return 12;
                case "K":
                    return 13;
                case "A":
                    return 14;
                default:
                    return 0;
            }
        }
    }
    public static Queue<string> merge(this Queue<string> first, Queue<string> second ){
        
        for(int i=0 ; i<second.Count; i++){
            first.Enqueue(second.Dequeue());
        }
        return first;
    }
    

}
