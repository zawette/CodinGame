using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;

/**
 * Don't let the machines win. You are humanity's last hope...
 **/
class Node
{
    public string current = "-1 -1";
    public string rightNode = "-1 -1";
    public string bottomNode = "-1 -1";

    public Node()
    {
    }
    public Node(string current, string right, string bottom)
    {
        this.current = current;
        this.rightNode = right;
        this.bottomNode = bottom;
    }

    public string getCoord() => $"{current} {rightNode} {bottomNode}";
}
class Player
{
    static void Main(string[] args)
    {
        int width = int.Parse(Console.ReadLine()); // the number of cells on the X axis
        int height = int.Parse(Console.ReadLine()); // the number of cells on the Y axis
        char[][] grid = new char[width][];
        for (int i = 0; i < height; i++)
        {
            string line = Console.ReadLine(); // width characters, each either 0 or .
            grid[i] = line.ToCharArray();
        }

        for (int i = 0; i < height; i++)
        {
            for (int x = 0; x < width; x++)
            {
                if (grid[i][x] == Char.Parse("."))
                {
                    continue;
                }
                else
                {
                    var node = new Node();
                    int nextWIndex = x + 1;
                    int nextHIndex = i + 1;
                    node.current = $"{x} {i}";

                    while (nextWIndex < width )
                    {
                        if (grid[i][nextWIndex] == Char.Parse("0"))
                        {
                            node.rightNode = $"{nextWIndex} {i}";
                            break;
                        }
                        nextWIndex++;
                    }
                    while (nextHIndex < height )
                    {
                        if (grid[nextHIndex][x] == Char.Parse("0"))
                        {
                            node.bottomNode= $"{x} {nextHIndex}";
                            break;
                        }
                        nextHIndex++;
                    }
                    Console.WriteLine(node.getCoord());
                }
            }
        }

        // Write an action using Console.WriteLine()
        // To debug: Console.Error.WriteLine("Debug messages...");


        // Three coordinates: a node, its right neighbor, its bottom neighbor

    }
}

