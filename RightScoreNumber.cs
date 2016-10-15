using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static pong.MyShared;

namespace pong
{
    class RightScoreNumber : ScoreNumber
    {
        public RightScoreNumber()
            : base (width/2 + bufferFromMiddleToScores + 1)
        {

        }
    }
}
