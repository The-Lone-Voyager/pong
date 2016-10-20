using pong.ScoreNumbers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace pong
{
    static class SharedConsoleData  // class to represent shared data about the console and its contents                                                              
    {
        // width/height of console
        public static readonly int widthOfConsole = 90;            // width of the console, in columns
        public static readonly int heightOfConsole = 40;            // height of the console, in rows

        public static SquareInfo[,] screenSquares = new SquareInfo[heightOfConsole, widthOfConsole];

        public static void SetScreenSquaresToNull()
        {
            for (int i = 0; i < screenSquares.GetLength(0); ++i)
            {
                for (int j = 0; j < screenSquares.GetLength(1); ++j)
                {
                    screenSquares[i, j] = null;
                }
            }
        }

        public static void DeleteAllScreenSquaresWithSquareType(int squareType)
        {
            for (int i = 0; i < screenSquares.GetLength(0); ++i)
            {
                for (int j = 0; j < screenSquares.GetLength(1); ++j)
                {
                    if (screenSquares[i,j]?.SquareType == squareType)
                    {
                        screenSquares[i, j] = null;
                    }
                }
            }
        }

        public static void PlayWallSound()
        {
            Beep(226, 16);
        }

        public static void PlayPaddleSound()
        {
            Beep(459, 96);
        }

        public static void PlayPointSound()
        {
            Beep(490, 257);
        }

        // margins to format objects on scren
        public static readonly int marginFromMiddleToScores = 20;   // buffer between middle line and score numbers
        public static readonly int marginFromTopOfScreenToPaddle = 2;    // defines the furthest each paddle can go horizantally toward the edge of the screen
        public static readonly int marginFromSideOfScreenToPaddle = 5;

        public static readonly double pointWhenAICanMove = 0.3;

        // height of the numbers at the top
        public static readonly int heightOfScoreNumbers = 8;        // height of the scoring numbers

        public static readonly ConsoleColor backgroundColor = ConsoleColor.Black;  // background color of console
        public static readonly ConsoleColor textColor = ConsoleColor.White;        // text color of console

        public static void MakeTextVisible()
        {
            ForegroundColor = textColor;
        }

        public static void MakeTextInvisible()
        {
            ForegroundColor = backgroundColor;
        }

        public static void DrawCenterLine()    // draws the halfway line in the center of the screen
        {
            MakeTextVisible();
            SetCursorPosition(widthOfConsole / 2, 0);   // go to middle of screen to draw center line
            for (int i = 0; i < heightOfConsole; ++i)   // draw center line
            {
                Write("|");
                screenSquares[i, widthOfConsole / 2] = new ScoreNumbers.SquareInfo(1, "|");
                if (i < (heightOfConsole - 1))
                {
                    ++CursorTop;
                    --CursorLeft;
                }
            }

            MakeTextInvisible();
        }
    }
}
