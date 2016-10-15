using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static pong.SharedConsoleData;

namespace pong
{
    class LeftScoreNumber : ScoreNumber // represents the left score number
    {
        public LeftScoreNumber()
            : base((widthOfConsole/2) - marginFromMiddleToScores - heightOfScoreNumbers)
        {
        }
    }
}
