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
class Player
{
    static void Main(string[] args)
    {
        string[] inputs;
        inputs = Console.ReadLine().Split(' ');
        int N = int.Parse(inputs[0]); // the total number of nodes in the level, including the gateways
        int L = int.Parse(inputs[1]); // the number of links
        int E = int.Parse(inputs[2]); // the number of exit gateways
        List<Node> graph = new List<Node>(N);
        graph.AddRange(Enumerable.Range(0, N).Select(i => new Node(i)));
        for (int i = 0; i < L; i++)
        {
            inputs = Console.ReadLine().Split(' ');
            int N1 = int.Parse(inputs[0]); // N1 and N2 defines a link between these nodes
            int N2 = int.Parse(inputs[1]);
            graph[N1].ChildNodes.Add(N2);
            graph[N2].ParentNodes.Add(N1);
        }
        for (int i = 0; i < E; i++)
        {
            int EI = int.Parse(Console.ReadLine()); // the index of a gateway node
            graph[EI].IsGatewayNode = true;
        }

        // game loop
        while (true)
        {
            int SI = int.Parse(Console.ReadLine()); // The index of the node on which the Skynet agent is positioned this turn

            // Write an action using Console.WriteLine()
            // To debug: Console.Error.WriteLine("Debug messages...");

            var output = Node.search(graph, SI);
            // Example: 0 1 are the indices of the nodes you wish to sever the link between
            Console.WriteLine(output);
        }
    }
}
public class Node
{
    public HashSet<int> ChildNodes = new HashSet<int>();
    public HashSet<int> ParentNodes = new HashSet<int>();
    public bool IsGatewayNode = false;
    public int index;

    public Node() { }
    public Node(int i) => index = i;

    public static string search(List<Node> graph, int s)
    {
        bool[] visited = new bool[graph.Count];
        string linkToSever = "";
        Queue<Node> q = new Queue<Node>();
        q.Enqueue(graph[s]);
        while (q.Count > 0)
        {
            Node currentN = q.Dequeue();
            visited[currentN.index] = true;
            foreach (int cN in currentN.ChildNodes)
            {
                if (!visited[cN])
                {
                    var cNode = graph[cN];
                    q.Enqueue(cNode);
                    visited[cN] = true;
                    if (cNode.IsGatewayNode)
                    {
                        return linkToSever = $"{currentN.index} {cN}";
                    }
                }
            }
            foreach (int pN in currentN.ParentNodes)
            {
                if (!visited[pN])
                {
                    var pNode = graph[pN];
                    q.Enqueue(pNode);
                    visited[pN] = true;
                    if (pNode.IsGatewayNode)
                    {
                        return linkToSever = $"{pN} {currentN.index}";
                    }
                }
            }


        }
        return linkToSever;

    }

}