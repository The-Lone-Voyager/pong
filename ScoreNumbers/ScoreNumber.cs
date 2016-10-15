using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static pong.SharedConsoleData;
using static System.Console;

namespace pong
{
    class ScoreNumber // represents a scoring number, numbers are formatted centered in an invisible box of ScoreNumberWidth width
    {
        public ScoreNumber(int lStart)              // initialize the left margin for this number
        {                                           // will differ between left/right number
            MarginLeftForScoreNumber = lStart;
        }

        private void GoToTopLeftOfBox()             // goes to the top left of the number's box
        {
            SetCursorPosition(MarginLeftForScoreNumber, MarginTopForScoreNumber);
        }
        public void Draw()      // Draw the number, draws scores 0-11 then makes text invisible again
        {
            ClearNumberBox();
            GoToTopLeftOfBox();
            switch (Value)
            {
                case 0:
                    {
                        LineAcross();

                        ++CursorTop;
                        CursorLeft = MarginLeftForScoreNumber;

                        LineDown(heightOfScoreNumbers - 2);

                        GoToTopLeftOfBox();
                        ++CursorTop;
                        CursorLeft += (ScoreNumberWidth - 1);

                        LineDown(heightOfScoreNumbers - 2);

                        CursorLeft = MarginLeftForScoreNumber;

                        LineAcross();
                        break;
                    }

                case 1:
                    {
                        CursorLeft += (ScoreNumberWidth / 2);
                        LineDown(heightOfScoreNumbers);
                        break;
                    }

                case 2:
                    {
                        int blocksLeft = heightOfScoreNumbers - 3;
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

                        CursorLeft = MarginLeftForScoreNumber;

                        LineAcross();

                        ++CursorTop;
                        CursorLeft = MarginLeftForScoreNumber;

                        LineDown(lower);

                        CursorLeft = MarginLeftForScoreNumber;

                        LineAcross();

                        break;
                    }

                case 3:
                    {
                        int blocksLeft = heightOfScoreNumbers - 3;
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

                        CursorLeft = MarginLeftForScoreNumber;

                        LineAcross();

                        ++CursorTop;
                        --CursorLeft;

                        LineDown(lower);

                        CursorLeft = MarginLeftForScoreNumber;

                        LineAcross();

                        break;
                    }

                case 4:
                    {
                        int blocksLeft = heightOfScoreNumbers - 1;
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
                        CursorLeft += (ScoreNumberWidth - 1);

                        LineDown(ScoreNumberWidth);

                        GoToTopLeftOfBox();

                        CursorTop += (upper - 1);

                        LineAcross();
                        break;
                    }

                case 5:
                    {
                        int blocksLeft = heightOfScoreNumbers - 3;
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
                        CursorLeft = MarginLeftForScoreNumber;

                        LineDown(upper);

                        LineAcross();

                        ++CursorTop;
                        --CursorLeft;

                        LineDown(lower);

                        CursorLeft = MarginLeftForScoreNumber;

                        LineAcross();
                        break;
                    }

                case 6:
                    {
                        int blocksLeft = heightOfScoreNumbers - 2;
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

                        LineDown(heightOfScoreNumbers);

                        GoToTopLeftOfBox();
                        CursorTop += upper;
                        LineAcross();

                        ++CursorTop;
                        --CursorLeft;

                        LineDown(lower);

                        CursorLeft = MarginLeftForScoreNumber;

                        LineAcross();
                        break;
                    }

                case 7:
                    {
                        LineAcross();
                        ++CursorTop;
                        --CursorLeft;
                        LineDown(heightOfScoreNumbers - 1);
                        break;
                    }

                case 8:
                    {
                        int blocksLeft = heightOfScoreNumbers - 3;
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

                        LineDown(heightOfScoreNumbers);
                        GoToTopLeftOfBox();
                        LineAcross();

                        --CursorLeft;
                        ++CursorTop;

                        LineDown(heightOfScoreNumbers - 1);

                        GoToTopLeftOfBox();
                        CursorTop += (upper + 1);
                        LineAcross();

                        CursorTop += (lower + 1);
                        CursorLeft = MarginLeftForScoreNumber;
                        LineAcross();
                        break;
                    }

                case 9:
                    {
                        int blocksLeft = heightOfScoreNumbers - 3;
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

                        LineDown(heightOfScoreNumbers - 1);

                        GoToTopLeftOfBox();
                        ++CursorTop;
                        LineDown(upper);
                        LineAcross();
                        break;
                    }

                case 10:
                    {
                        CursorLeft += (ScoreNumberWidth / 2);
                        LineDown(heightOfScoreNumbers);

                        int temp = MarginLeftForScoreNumber;

                        MarginLeftForScoreNumber += ((ScoreNumberWidth - 1) + MarginBetweenFirstAndSecondDigit);

                        GoToTopLeftOfBox();

                        LineAcross();

                        ++CursorTop;
                        CursorLeft = MarginLeftForScoreNumber;

                        LineDown(heightOfScoreNumbers - 2);

                        GoToTopLeftOfBox();
                        ++CursorTop;
                        CursorLeft += (ScoreNumberWidth - 1);

                        LineDown(heightOfScoreNumbers - 2);

                        CursorLeft = MarginLeftForScoreNumber;

                        LineAcross();

                        MarginLeftForScoreNumber = temp;
                        break;
                    }

                case 11:
                    {
                        CursorLeft += (ScoreNumberWidth / 2);
                        LineDown(heightOfScoreNumbers);

                        int temp = MarginLeftForScoreNumber;

                        MarginLeftForScoreNumber += ((ScoreNumberWidth - 1) + MarginBetweenFirstAndSecondDigit);

                        GoToTopLeftOfBox();

                        CursorLeft += (ScoreNumberWidth / 2);
                        LineDown(heightOfScoreNumbers);

                        MarginLeftForScoreNumber = temp;
                        break;
                    }
            }
        }

        private void LineDown(int num)  // aid in number drawing - draw line down for specified height
        {
            for (int i = 0; i < num; ++i)
            {
                Write(numChar2);
                ++CursorTop;
                --CursorLeft;
            }
        }

        private void LineAcross()   // aid in number drawing - draw line horizantally across width of number
        {
            for (int i = 0; i < ScoreNumberWidth; ++i)
            {
                Write(numChar1);
            }
        }

        private void ClearNumberBox()   // clears the number box of anything that might have been in there before
        {
            GoToTopLeftOfBox();
            for (int i = 0; i < heightOfScoreNumbers; ++i)
            {
                for (int j = 0; j < ScoreNumberWidth; ++j)
                {
                    Write(" ");
                }

                ++CursorTop;
                CursorLeft = MarginLeftForScoreNumber;
            }
        }

        // public property
        public int Value { get; set; } = 0;         // value of this score number, initialized to 0

        // formatting information
        private int MarginTopForScoreNumber { get; set; } = 1; // margin from top of screen to scoring numbers
        private int ScoreNumberWidth { get; set; } = 6; // width of scoring numbers
        private int MarginLeftForScoreNumber { get; set; } // left margin of this score number
        private int MarginBetweenFirstAndSecondDigit { get; set; } = 2;  // margin between digits for 10 and 11

        // characters numbers made out of
        private string numChar1 = "■";  // drawing the scores utilizes these two
        private string numChar2 = "█";  // ascii characters       
    }
}
