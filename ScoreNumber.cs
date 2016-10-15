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
                        LineAcross();

                        ++CursorTop;
                        CursorLeft = LeftStart;

                        LineDown(numberHeight - 2);

                        GoToTopLeftOfBox();
                        ++CursorTop;
                        CursorLeft += (NumberWidth - 1);

                        LineDown(numberHeight - 2);

                        CursorLeft = LeftStart;

                        LineAcross();
                        break;
                    }

                case 1:
                    {
                        CursorLeft += (NumberWidth / 2);
                        LineDown(numberHeight);
                        break;
                    }

                case 2:
                    {
                        int blocksLeft = numberHeight - 3;
                        int half = blocksLeft / 2;
                        int upper = 0;
                        int lower = 0;

                        if (blocksLeft % 2 == 0)
                        {
                            upper = half - 1;
                        }

                        else
                        {
                            upper = half;                            
                        }

                        lower = half + 1;

                        LineAcross();

                        ++CursorTop;
                        --CursorLeft;

                        LineDown(upper);

                        CursorLeft = LeftStart;

                        LineAcross();

                        ++CursorTop;
                        CursorLeft = LeftStart;

                        LineDown(lower);

                        CursorLeft = LeftStart;

                        LineAcross();

                        break;
                    }

                case 3:
                    {
                        int blocksLeft = numberHeight - 3;
                        int half = blocksLeft / 2;
                        int upper = 0;
                        int lower = 0;

                        if (blocksLeft % 2 == 0)
                        {
                            upper = half - 1;
                        }

                        else
                        {
                            upper = half;
                        }

                        lower = half + 1;

                        LineAcross();

                        ++CursorTop;
                        --CursorLeft;

                        LineDown(upper);

                        CursorLeft = LeftStart;

                        LineAcross();

                        ++CursorTop;
                        --CursorLeft;

                        LineDown(lower);

                        CursorLeft = LeftStart;

                        LineAcross();

                        break;
                    }

                case 4:
                    {
                        int blocksLeft = numberHeight - 1;
                        int half = blocksLeft / 2;
                        int upper = 0;
                        int lower = 0;

                        if (blocksLeft % 2 == 0)
                        {
                            upper = half - 1;
                        }

                        else
                        {
                            upper = half;
                        }

                        lower = half + 1;

                        LineDown(upper);

                        GoToTopLeftOfBox();
                        CursorLeft += (NumberWidth - 1);

                        LineDown(NumberWidth);

                        GoToTopLeftOfBox();

                        CursorTop += (upper - 1);

                        LineAcross();
                        break;
                    }

                case 5:
                    {
                        int blocksLeft = numberHeight - 3;
                        int half = blocksLeft / 2;
                        int upper = 0;
                        int lower = 0;

                        if (blocksLeft % 2 == 0)
                        {
                            upper = half - 1;
                        }

                        else
                        {
                            upper = half;
                        }

                        lower = half + 1;

                        LineAcross();

                        ++CursorTop;
                        CursorLeft = LeftStart;

                        LineDown(upper);

                        LineAcross();

                        ++CursorTop;
                        --CursorLeft;

                        LineDown(lower);

                        CursorLeft = LeftStart;

                        LineAcross();
                        break;
                    }

                case 6:
                    {
                        int blocksLeft = numberHeight - 2;
                        int half = blocksLeft / 2;
                        int upper = 0;
                        int lower = 0;

                        if (blocksLeft % 2 == 0)
                        {
                            upper = half;
                        }

                        else
                        {
                            upper = half + 1;
                        }

                        lower = half;

                        LineDown(numberHeight);

                        GoToTopLeftOfBox();
                        CursorTop += upper;
                        LineAcross();

                        ++CursorTop;
                        --CursorLeft;

                        LineDown(lower);

                        CursorLeft = LeftStart;

                        LineAcross();
                        break;
                    }

                case 7:
                    {
                        LineAcross();
                        ++CursorTop;
                        --CursorLeft;
                        LineDown(numberHeight - 1);
                        break;
                    }

                case 8:
                    {
                        int blocksLeft = numberHeight - 3;
                        int half = blocksLeft / 2;
                        int upper = 0;
                        int lower = 0;

                        if (blocksLeft % 2 == 0)
                        {
                            upper = half - 1;
                        }

                        else
                        {
                            upper = half;
                        }

                        lower = half + 1;

                        LineDown(numberHeight);
                        GoToTopLeftOfBox();
                        LineAcross();

                        --CursorLeft;
                        ++CursorTop;

                        LineDown(numberHeight - 1);

                        GoToTopLeftOfBox();
                        CursorTop += (upper + 1);
                        LineAcross();

                        CursorTop += (lower + 1);
                        CursorLeft = LeftStart;
                        LineAcross();
                        break;
                    }

                case 9:
                    {
                        int blocksLeft = numberHeight - 3;
                        int half = blocksLeft / 2;
                        int upper = 0;
                        int lower = 0;

                        if (blocksLeft % 2 == 0)
                        {
                            upper = half - 1;
                        }

                        else
                        {
                            upper = half;
                        }

                        lower = half + 1;

                        LineAcross();
                        ++CursorTop;
                        --CursorLeft;

                        LineDown(numberHeight - 1);

                        GoToTopLeftOfBox();
                        ++CursorTop;
                        LineDown(upper);
                        LineAcross();
                        break;
                    }

                case 10:
                    {
                        CursorLeft += (NumberWidth / 2);
                        LineDown(numberHeight);

                        int temp = LeftStart;

                        LeftStart += ((NumberWidth - 1) + secondDigitBuffer);

                        GoToTopLeftOfBox();

                        LineAcross();

                        ++CursorTop;
                        CursorLeft = LeftStart;

                        LineDown(numberHeight - 2);

                        GoToTopLeftOfBox();
                        ++CursorTop;
                        CursorLeft += (NumberWidth - 1);

                        LineDown(numberHeight - 2);

                        CursorLeft = LeftStart;

                        LineAcross();

                        LeftStart = temp;
                        break;
                    }

                case 11:
                    {
                        CursorLeft += (NumberWidth / 2);
                        LineDown(numberHeight);

                        int temp = LeftStart;

                        LeftStart += ((NumberWidth - 1) + secondDigitBuffer);

                        GoToTopLeftOfBox();

                        CursorLeft += (NumberWidth / 2);
                        LineDown(numberHeight);

                        LeftStart = temp;
                        break;
                    }
            }
            MakeTextInvisible();
        }

        private void LineDown(int num)
        {
            for (int i = 0; i < num; ++i)
            {
                Write(numChar2);
                ++CursorTop;
                --CursorLeft;
            }
        }

        private void LineAcross()
        {
            for (int i = 0; i < NumberWidth; ++i)
            {
                Write(numChar1);
            }
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

                ++CursorTop;
                CursorLeft = LeftStart;
            }
        }

        int Value { get; set; } = 0;         // value of this score number, initialized to 0
        int TopBuffer { get; set; } = 1;         // TopBuffer of score number
        int NumberWidth { get; set; } = 6;      // width of numbers
        int LeftStart { get; set; }     // number of columns from left where this number's box starts
        string numChar1 = "■";
        string numChar2 = "█";
        int secondDigitBuffer = 2;
    }
}
