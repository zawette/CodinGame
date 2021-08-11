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
        int surfaceN = int.Parse(Console.ReadLine()); // the number of points used to draw the surface of Mars.
        int[] groundX = Enumerable.Range(0, surfaceN).ToArray();
        int[] groundY = Enumerable.Range(0, surfaceN).ToArray();

        for (int i = 0; i < surfaceN; i++)
        {
            inputs = Console.ReadLine().Split(' ');
            int landX = int.Parse(inputs[0]); // X coordinate of a surface point. (0 to 6999)
            int landY = int.Parse(inputs[1]); // Y coordinate of a surface point. By linking all the points together in a sequential fashion, you form the surface of Mars.
            Console.Error.WriteLine("i: " + i);
            Console.Error.WriteLine("X: " + landX);
            Console.Error.WriteLine("Y: " + landY);
            groundX[i] = landX;
            groundY[i] = landY;
        }

            int flatGroundIndex = findFlatGround(groundY); 
            dir direction ;
            int desiredAngle = 40;
            int DesiredRotation ;
            int DesiredPower = 4;
        // game loop
        while (true)
        {
            inputs = Console.ReadLine().Split(' ');
            int X = int.Parse(inputs[0]);
            int Y = int.Parse(inputs[1]);
            int hSpeed = int.Parse(inputs[2]); // the horizontal speed (in m/s), can be negative.
            int vSpeed = int.Parse(inputs[3]); // the vertical speed (in m/s), can be negative.
            int fuel = int.Parse(inputs[4]); // the quantity of remaining fuel in liters.
            int rotate = int.Parse(inputs[5]); // the rotation angle in degrees (-90 to 90).
            int power = int.Parse(inputs[6]); // the thrust power (0 to 4).

            // Write an action using Console.WriteLine()
            // To debug: Console.Error.WriteLine("Debug messages...");

            direction = findDirToFlatGround(groundY,groundX,X);
            DesiredRotation = direction == dir.RIGHT ? -desiredAngle : desiredAngle;

            if(closeToFlatGround(groundX,groundY,X)){
                DesiredPower = 4;
                if(Math.Abs(hSpeed)>0){
                    desiredAngle=desiredAngle - 8;
                   desiredAngle= Math.Clamp(desiredAngle,-80,80);
            DesiredRotation = direction == dir.RIGHT ? -desiredAngle : desiredAngle;
                }
                else {
                    desiredAngle=desiredAngle + 5;
                    desiredAngle = Math.Clamp(desiredAngle,-80,80);
            DesiredRotation = direction == dir.RIGHT ? -desiredAngle : desiredAngle;
                }
            }

            if(isAboveFlatGround(groundX,groundY,X)){
               //if(X> (groundX[flatGroundIndex+1]+groundX[flatGroundIndex])/2){
                //DesiredRotation = direction == dir.RIGHT ? DesiredRotation - 15 : DesiredRotation + 15;
                //DesiredPower = 4;
                //}
                //else{
                DesiredRotation=0;
                DesiredPower=4;
                //}

            }
            
            Console.Error.WriteLine($"{DesiredRotation} {DesiredPower}");
            // rotate power. rotate is the desired rotation angle. power is the desired thrust power.
            Console.WriteLine($"{DesiredRotation} {DesiredPower}");
        }
    }

    enum dir
    {
        LEFT,
        RIGHT
    }

    static bool closeToFlatGround(int[] groundX, int[] groundY, int posX){
        int Distance=1700;
        int midOfFlatGround = findMidOfFlatGround(groundX,groundY); 
        Console.Error.WriteLine(Math.Abs(midOfFlatGround-posX));
        return Math.Abs(midOfFlatGround-posX)<=Distance;
    }

    static int findMidOfFlatGround(int[] groundX, int[] groundY){
         int flatGroundIndex = findFlatGround(groundY); 
         return (groundX[flatGroundIndex] + groundX[flatGroundIndex+1])/2;
    }
    static bool isAboveFlatGround(int[] groundX, int[] groundY, int posX){
         int flatGroundIndex = findFlatGround(groundY); 
         return posX >= groundX[flatGroundIndex] && posX <= groundX[flatGroundIndex+1];
    }

    static bool obstacleExists(int[] ground, int posX, int posY)
        => ground[posX + 1] >= posY;

    static int findFlatGround(int[] groundY)
        => groundY
                .Select((y, index) => (y, index))
                .First((item) => groundY[item.index + 1] == item.y)
                .index;

    static dir findDirToFlatGround(int[] groundY, int[] groundX, int posX){
        int flatGroundIndex = findFlatGround(groundY); 
        return posX<=groundX[flatGroundIndex] ? dir.RIGHT : dir.LEFT;
    }

}