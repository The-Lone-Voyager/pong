using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace pong
{
    static class MyShared                                                                   // this class defines program-wide shared data,
    {                                                                                       // both variables, constants, and methods

        private static readonly ConsoleColor backgroundColor = ConsoleColor.Black;            // background color of console
        private static readonly ConsoleColor textColor = ConsoleColor.White;                  // text color of console

        public static readonly int width = 140;                                              // width of the console, in columns
        public static readonly int height = 40;                                              // height of the console, in rows

        private static readonly int paddleBuffer = 2;                                       // how much space there is
                                                                                            // between paddle and edge of console

        public static readonly int leftPaddleLeftNum = paddleBuffer;                            // console left property of left paddle
        public static readonly int rightPaddleLeftNum = (width - 1) - paddleBuffer;             // console left propoerty of right paddle

        public static readonly int bufferFromMiddleToScores = 20;                            // buffer between middle line and score numbers
        public static readonly int numberHeight = 8;                                        // height of scores

        public static void MakeTextInvisible()                                              // call this to make text invisible
        {
            ForegroundColor = backgroundColor;
        }

        public static void MakeTextVisible()                                                // call this to make text visible
        {
            ForegroundColor = textColor;
        }
    }
}
