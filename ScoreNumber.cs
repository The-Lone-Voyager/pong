using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static pong.MyShared;
using static System.Console;

namespace pong
{
    class ScoreNumber
    {
        public ScoreNumber(int lStart)              // initialize the left margin for this number
        {                                           // will differ between left/right number
            LeftStart = lStart;
        }

        private void GoToTopLeftOfBox()             // goes to the top left of the number's box
        {
            SetCursorPosition(LeftStart, TopBuffer);
        }
        public void Draw()                          // Draw the number
        {
            ClearNumberBox();
            GoToTopLeftOfBox();
            MakeTextVisible();
            switch (Value)
            {
                case 0:
                    {
                        for (int i = 0; i < NumberWidth; ++i)
                        {
                            Write(numChar1);
                        }

                        for (int i = 0; i < numberHeight - 2; ++i)
                        {
                            ++CursorTop;
                            CursorLeft = LeftStart;
                            Write(numChar2);
                            CursorLeft += NumberWidth - 2;
                            Write(numChar2);
                        }

                        CursorLeft = LeftStart;
                        CursorTop = (numberHeight - 1) + TopBuffer;

                        for (int i = 0; i < NumberWidth; ++i)
                        {
                            Write(numChar1);
                        }
                        break;
                    }
            }
            MakeTextInvisible();
        }

        private void ClearNumberBox()                // clears the number box of anything that might have been in there before
        {
            GoToTopLeftOfBox();
            MakeTextInvisible();
            for (int i = 0; i < numberHeight; ++i)
            {
                for (int j = 0; j < NumberWidth; ++j)
                {
                    Write(" ");
                }
            }
        }

        int Value { get; set; } = 0;         // value of this score number, initialized to 0
        int TopBuffer { get; set; } = 1;         // TopBuffer of score number
        int NumberWidth { get; set; } = 6;      // width of numbers
        int LeftStart { get; set; }     // number of columns from left where this number's box starts
        string numChar1 = "■";
        string numChar2 = "█";
    }
}
