using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pong
{
    public class HumanPaddle : Paddle
    {
        public HumanPaddle(int leftPos, int topPos)
            : base(leftPos, topPos)
        {
        }

        public override void Move(int direction = 0)
        {
            if (direction == 0)
            {
                MoveUp();
            }

            else if (direction == 1)
            {
                MoveDown();
            }
        }
    }
}
