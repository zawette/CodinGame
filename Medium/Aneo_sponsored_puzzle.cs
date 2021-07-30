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
        int speed = int.Parse(Console.ReadLine());
        int lightCount = int.Parse(Console.ReadLine());
        for (int i = 0; i < lightCount; i++)
        {
            string[] inputs = Console.ReadLine().Split(' ');
            int distance = int.Parse(inputs[0]);
            int duration = int.Parse(inputs[1]);
            float SpeedMps = (float)speed * 1000 / 3600;
            float TimeToTrafficLight = distance / SpeedMps ; 

            while(!((TimeToTrafficLight / duration) % 2 >= 0 && (TimeToTrafficLight / duration) % 2 <1)  ){
                speed--;
            SpeedMps = (float) speed * 1000 / 3600;
            TimeToTrafficLight = distance / SpeedMps ; 
            }
        }

        // Write an answer using Console.WriteLine()
        // To debug: Console.Error.WriteLine("Debug messages...");

        Console.WriteLine(speed);
    }
}