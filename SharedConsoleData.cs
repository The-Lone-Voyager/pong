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
        // public data

        // width/height of console
        public static readonly int widthOfConsole = 140;            // width of the console, in columns
        public static readonly int heightOfConsole = 40;            // height of the console, in rows

        // margins to format objects on scren
        public static readonly int marginFromMiddleToScores = 20;   // buffer between middle line and score numbers
        public static readonly int marginFromEdgeOfScreenToPaddle = 2;    // defines the furthest each paddle can go horizantally toward the edge of the screen

        // height of the numbers at the top
        public static readonly int heightOfScoreNumbers = 8;        // height of the scoring numbers

        // private data
        private static readonly ConsoleColor backgroundColor = ConsoleColor.Black;  // background color of console
        private static readonly ConsoleColor textColor = ConsoleColor.White;        // text color of console
    }
}
