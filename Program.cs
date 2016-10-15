using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using static pong.SharedConsoleData;
using System.Threading;

namespace pong
{
    class Program
    {
        // class-wide static data members, will serve as handles to the current game objects
        static LeftPaddle lPaddle;  // handle to the current left paddle
        static RightPaddle rPaddle; // handle to the current right paddle
        static Ball ball;           // handle to the current ball
        static GameObject[] gameObjects = null; // array which holds the game objects - 2 paddles and the ball
        static LeftScoreNumber lScore;  // handle to the left hand score number
        static RightScoreNumber rScore; // handle to the right hand score number
        static ScoreNumber[] scores;    // array to hold both left and right hand score numbers

        static void Main(string[] args)
        {
            // set up console
            SetWindowSize(widthOfConsole, heightOfConsole + 1); // set up console dimensions
            CursorVisible = false;  // make the cursor invisible
            DrawCenterLine();   // draw the center line

            SetUpNewGame();  // set up the new game

            ReadLine();
        }

        private static void SetUpNewGame() // sets the stage for a new game to begin by putting objects in their places on the screen
        {
            // first get new score numbers, initialized to zero
            lScore = new LeftScoreNumber();
            rScore = new RightScoreNumber();
            scores = new ScoreNumber[] { lScore, rScore };

            // and draw them
            foreach (ScoreNumber sn in scores)
            {
                sn.Draw();
            }

            // then erase any existing GameObjects from their current positions
            if (gameObjects != null)
            {
                foreach (GameObject p in gameObjects)
                {
                    p.Erase();
                }
            }

            // then get new GameObjects
            lPaddle = new pong.LeftPaddle();
            rPaddle = new RightPaddle();
            ball = new pong.Ball();
            gameObjects = new GameObject[] { lPaddle, rPaddle, ball };

            // draw the new GameObjects
            foreach (GameObject p in gameObjects)
            {
                p.Draw();
            }
        }

        private static void DrawCenterLine()    // draws the halfway line in the center of the screen
        {
            SetCursorPosition(widthOfConsole / 2, 0);   // go to middle of screen to draw center line
            for (int i = 0; i < heightOfConsole; ++i)   // draw center line
            {
                Write("|");
                ++CursorTop;
                --CursorLeft;
            }
        }
    }
}
