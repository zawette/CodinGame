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
        int N = int.Parse(Console.ReadLine());
        List<Cell> cells = new List<Cell>(N);
        for (int i = 0; i < N; i++)
        {
            string[] inputs = Console.ReadLine().Split(' ');
            string operation = inputs[0];
            string arg1 = inputs[1];
            string arg2 = inputs[2];
            cells.Add(new Cell(operation, arg1, arg2));
        }
        for (int i = 0; i < N; i++)
        {
            // Write an answer using Console.WriteLine()
            // To debug: Console.Error.WriteLine("Debug messages...");

            Cell.ProcessCell(cells, i);
            int result = cells[i].result;
            Console.WriteLine(result);
        }
    }
    public class Cell
    {
        public string operation;
        public string arg1;
        public string arg2;
        public int result;
        public bool processed = false;
        public Cell() { }
        public Cell(string operation, string arg1, string arg2)
        {
            this.operation = operation;
            this.arg1 = arg1;
            this.arg2 = arg2;
        }
        public static void ProcessCell(List<Cell> cells, int cellIndex)
        {
            if (!cells[cellIndex].processed)
            {
                string operation = cells[cellIndex].operation;
                int arg1 = 0;
                int arg2 = 0;

                if (cells[cellIndex].arg1[0] == '$')
                {
                    int index = int.Parse(cells[cellIndex].arg1.Remove(0, 1));
                    if (cells[index].processed)
                    {
                        arg1 = cells[index].result;
                    }
                    else
                    {
                        ProcessCell(cells, index);
                        arg1 = cells[index].result;
                    }
                }
                else
                {
                    arg1 = int.Parse(cells[cellIndex].arg1);
                }

                if (cells[cellIndex].arg2[0] == '$')
                {
                    int index = int.Parse(cells[cellIndex].arg2.Remove(0, 1));
                    if (cells[index].processed)
                    {
                        arg2 = cells[index].result;
                    }
                    else
                    {
                        ProcessCell(cells, index);
                        arg2 = cells[index].result;
                    }
                }
                else if (cells[cellIndex].arg2[0] != '$' && !operation.Equals("VALUE"))
                {
                    arg2 = int.Parse(cells[cellIndex].arg2);
                }

                switch (operation)
                {
                    case "VALUE":
                        cells[cellIndex].result = arg1;
                        break;
                    case "ADD":
                        cells[cellIndex].result = arg1 + arg2;
                        break;
                    case "SUB":
                        cells[cellIndex].result = arg1 - arg2;
                        break;
                    case "MULT":
                        cells[cellIndex].result = arg1 * arg2;
                        break;
                    default:
                        break;

                }
                cells[cellIndex].processed = true;
            }
        }


    }
}