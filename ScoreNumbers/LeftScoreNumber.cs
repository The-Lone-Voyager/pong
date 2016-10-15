using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static pong.MyShared;

namespace pong
{
    class LeftScoreNumber : ScoreNumber
    {
        public LeftScoreNumber()
            : base((width/2) - bufferFromMiddleToScores - numberHeight)
        {
        }
    }
}
