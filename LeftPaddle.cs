using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pong
{
    class LeftPaddle : Paddle                                           // represents the paddle on the left of the screen
    {
        public LeftPaddle()
            : base(MyShared.leftPaddleLeftNum, MyShared.height / 2)     // initialize the left paddle with the appropriate position
        {
        }
    }
}
