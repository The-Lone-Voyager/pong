using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pong
{
    class RightPaddle : Paddle                                          // represents the paddle on the right of the screen
    {
        public RightPaddle()
            : base(MyShared.rightPaddleLeftNum, MyShared.height / 2)    // initialize the right paddle with the appropriate position
        {
        }
    }
}
