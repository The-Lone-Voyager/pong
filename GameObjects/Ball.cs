using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using static pong.SharedConsoleData;

namespace pong
{
    class Ball : GameObject
    {
        public Ball()
            : base(widthOfConsole/2, heightOfConsole/2, "■")
        {
        }
    }
}
