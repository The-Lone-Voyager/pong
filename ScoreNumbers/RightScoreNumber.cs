using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static pong.SharedConsoleData;

namespace pong
{
    class RightScoreNumber : ScoreNumber // represents the right score number
    {
        public RightScoreNumber()
            : base (widthOfConsole/2 + marginFromMiddleToScores + 1)
        {

        }
    }
}
