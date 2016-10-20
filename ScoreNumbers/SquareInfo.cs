using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pong.ScoreNumbers
{
    public class SquareInfo
    {
        public SquareInfo(int type, string charac)
        {
            SquareType = type;
            SquareCharacter = charac;
        }
        public int SquareType { get; set; } // 1 = middle line
                                            // 2 = left number
                                            // 3 = right number
        public string SquareCharacter { get; set; }
    }
}
