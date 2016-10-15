using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using static pong.SharedConsoleData;

namespace pong
{
    class Program
    {   
        static void Main(string[] args)
        {
            // set up console
            SetWindowSize(widthOfConsole, heightOfConsole + 1); // set up console dimensions
            CursorVisible = false;  // make the cursor invisible
            SetCursorPosition(widthOfConsole / 2, 0);   // go to middle of screen to draw center line
            for (int i = 0; i < heightOfConsole; ++i)   // draw center line
            {
                MakeTextVisible();
                Write("|");
                ++CursorTop;
                --CursorLeft;
            }
            MakeTextInvisible();    // set text back to invisible after drawing center line

            // initialize objects on screen
            LeftPaddle lPaddle = new LeftPaddle();  // create the left paddle
            RightPaddle rPaddle = new RightPaddle(); // create the right paddle
            Ball ball = new Ball(); // create the ball
            LeftScoreNumber lScore = new LeftScoreNumber(); // create the left number
            RightScoreNumber rScore = new RightScoreNumber();   // create the right number
            ScoreNumber[] scores = { lScore, rScore };  // array which holds both score numbers
            GameObject[] gameObjects = { lPaddle, rPaddle, ball }; // array which holds the game objects - 2 paddles and the ball

            // draw all objects initially on screen

            // draw score numbers
            foreach (ScoreNumber sn in scores)
            {
                sn.Draw();
            }

            // draw game objects
            foreach (GameObject p in gameObjects)
            {
                p.Draw();
            }

            ReadLine();
        }
    }
}
