using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static pong.SharedConsoleData;

namespace pong
{
    class RightPaddle : Paddle      // represents the paddle on the right of the screen
    {
        public RightPaddle()
            : base((widthOfConsole - 1) - marginFromEdgeOfScreenToPaddle, heightOfConsole / 2)    // initialize the right paddle with the appropriate position
        {
        }
    }
}
