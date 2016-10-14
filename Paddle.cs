using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using static pong.MyShared;

namespace pong
{
    class Paddle : GameObject                                                    // this class represents a paddle, specifically the two that appear on                                                                 
    {                                                                           // each side of the screen
        public Paddle(int leftPos, int tPos)                                    // initialize base with paddle character                                                                                  
            : base(leftPos, tPos, "█")
        {
        }                   
    }
}
