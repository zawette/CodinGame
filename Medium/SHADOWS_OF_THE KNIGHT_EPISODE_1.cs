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
        int W = int.Parse(inputs[0])-1; // width of the building.
        int H = int.Parse(inputs[1])-1; // height of the building.
        int N = int.Parse(Console.ReadLine()); // maximum number of turns before game over.
        inputs = Console.ReadLine().Split(' ');
        int X0 = int.Parse(inputs[0]);
        int Y0 = int.Parse(inputs[1]);
        int xMin = 0;
        int yMin=0;    
        // game loop
        while (true)
        {
            string bombDir = Console.ReadLine(); // the direction of the bombs from batman's current location (U, UR, R, DR, D, DL, L or UL)
            // Write an action using Console.WriteLine()
            // To debug: Console.Error.WriteLine("Debug messages...");
            var outp = dichoto(ref X0,ref Y0,ref W,ref xMin,ref H,ref yMin,bombDir);           

            // the location of the next window Batman should jump to.
            Console.WriteLine($"{outp.x} {outp.y}");
        }
    }
    static (int x ,int y) dichoto(ref int xi,ref int yi ,ref int xmax,ref int xmin,ref int ymax,ref int ymin, string direction) {
        if ( direction.Contains("L") ){
            xi--;
            xmax = xi;
        }
        if (direction.Contains("R")){
           xi++;
           xmin = xi; 
        }
        if (direction.Contains("D")){
           yi++; 
           ymin = yi;
        }
        if (direction.Contains("U")){
           yi--; 
           ymax = yi ;
        }
        xi= xmin+ (xmax-xmin)/2;
        yi= ymin+ (ymax-ymin)/2;

        return (xi,yi);
    }
}
