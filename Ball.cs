using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using static pong.MyShared;

namespace pong
{
    class Ball : GameObject
    {
        public Ball()
            : base(width/2, height/2, "■")
        {

        }
    }
}
