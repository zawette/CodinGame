using System;
using System.Linq;
using System.IO;
using System.Text;
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
        string[] inputs = Console.ReadLine().Split(' ');
        int h = int.Parse(inputs[0]);
        int w = int.Parse(inputs[1]);
        int n = int.Parse(inputs[2]);
        string alive = Console.ReadLine();
        string dead = Console.ReadLine();
        char[,] graph = new char[w, h];
        for (int j = 0; j < h; j++)
        {
            string line = Console.ReadLine();
            for (int i = 0; i < line.Length; i++)
            {
                graph[i, j] = line[i];
                Console.Error.Write(graph[i, j]);
            }
            Console.Error.WriteLine(" ");
        }


        // Write an answer using Console.WriteLine()
        // To debug: Console.Error.WriteLine("Debug messages...");

        for (int k = 0; k < n; k++)
        {

            char[,] tempGraph = new char[w, h];
            for (int j = 0; j < h; j++)
            {
                for (int i = 0; i < w; i++)
                {

                    // lives
                    if (graph[i, j] == 'O')
                    {
                        bool hasNeighb = false;
                        for (int a = 0; a < alive.Length; a++)
                        {
                            if (alive[a] == '1')
                            {
                                hasNeighb = hasNeighbours(graph, i, j, a);
                                if (hasNeighb) break;
                            }
                        }
                        tempGraph[i, j] = hasNeighb ? 'O' : '.';
                    }

                    //birth
                    if (graph[i, j] == '.')
                    {
                        bool hasNeighb = false;
                        for (int b = 0; b < dead.Length; b++)
                        {
                            if (dead[b] == '1')
                            {
                                hasNeighb = hasNeighbours(graph, i, j, b);
                                if (hasNeighb) break;
                            }
                        }
                        tempGraph[i, j] = hasNeighb ? 'O' : '.';
                    }

                }
            }
            graph = tempGraph;

        }

        for (int j = 0; j < h; j++)
        {
            string output = "";
            for (int i = 0; i < w; i++)
            {
                output += graph[i, j];
            }
            Console.WriteLine(output);
        }
    }

    public static bool hasNeighbours(char[,] graph, int x, int j, int NeighboursNb)
    {
        int count = 0;
        if (x < graph.GetLength(0) - 1 && graph[x + 1, j] == 'O') count++;
        if (x > 0 && graph[x - 1, j] == 'O') count++;
        if (j < graph.GetLength(1) - 1 && graph[x, j + 1] == 'O') count++;
        if (j > 0 && graph[x, j - 1] == 'O') count++;
        if (x < graph.GetLength(0) - 1 && j < graph.GetLength(1) - 1 && graph[x + 1, j + 1] == 'O') count++;
        if (x > 0 && j > 0 && graph[x - 1, j - 1] == 'O') count++;
        if (x > 0 && j < graph.GetLength(1) - 1 && graph[x - 1, j + 1] == 'O') count++;
        if (j > 0 && x < graph.GetLength(0) - 1 && graph[x + 1, j - 1] == 'O') count++;
        return NeighboursNb == count;
    }
}