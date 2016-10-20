using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using static pong.SharedConsoleData;

namespace pong
{
    public abstract class Paddle : GameObject   // this class represents a paddle, specifically the two that appear on                                                                 
    {                                           // each side of the screen
        public Paddle(int leftPos, int tPos)    // initialize base with paddle character                                                                                  
            : base(leftPos, tPos, "█")
        {
            if (CurrentLeft == marginFromSideOfScreenToPaddle) // determine whether this paddle is on the right or left side
            {
                Side = Horizantal.LEFT;
            }
            else
            {
                Side = Horizantal.RIGHT;
            }
        }
        protected Horizantal Side { get; set; }  // side that this paddle is on    

        private bool BallIsInSameRow()
        {
            if (CurrentTop == Program.ball.CurrentTop)
            {
                return true;
            }

            return false;
        }

        private bool BallIsInSameColumn()
        {
            if (CurrentLeft == Program.ball.CurrentLeft)
            {
                return true;
            }

            return false;
        }

        private bool BallIsOnTop()
        {
            if (BallIsInSameColumn())
            {
                if ((CurrentTop - 1) == (Program.ball.CurrentTop))
                {
                    return true;
                }
            }

            return false;
        }

        private bool BallIsBeneath()
        {
            if (BallIsInSameColumn())
            {
                if ((CurrentTop + 1) == (Program.ball.CurrentTop))
                {
                    return true;
                }
            }

            return false;
        }

        private bool BallIsNE()
        {
            if (((CurrentTop - 1) == (Program.ball.CurrentTop)) && ((CurrentLeft + 1) == (Program.ball.CurrentLeft)))
            {
                return true;
            }

            return false;
        }

        private bool BallIsNW()
        {
            if (((CurrentTop - 1) == (Program.ball.CurrentTop)) && ((CurrentLeft - 1) == (Program.ball.CurrentLeft)))
            {
                return true;
            }

            return false;
        }

        private bool BallIsSW()
        {
            if (((CurrentTop + 1) == (Program.ball.CurrentTop)) && ((CurrentLeft - 1) == (Program.ball.CurrentLeft)))
            {
                return true;
            }

            return false;
        }

        private bool BallIsSE()
        {
            if (((CurrentTop + 1) == (Program.ball.CurrentTop)) && ((CurrentLeft + 1) == (Program.ball.CurrentLeft)))
            {
                return true;
            }

            return false;
        }

        protected override void MoveUp()
        {
            if (CurrentTop > marginFromTopOfScreenToPaddle)
            {
                bool ballChanged = false;

                if (BallIsOnTop())
                {
                    Program.ball.VDirection = Vertical.UP;
                    Program.ball.RandomizeHDirection();
                    ballChanged = true;
                }

                else if (BallIsNE())
                {
                    Program.ball.RandomizeVDirection();
                    Program.ball.HDirection = Horizantal.RIGHT;
                    ballChanged = true;
                }

                else if (BallIsNW())
                {
                    Program.ball.RandomizeVDirection();
                    Program.ball.HDirection = Horizantal.LEFT;
                    ballChanged = true;
                }

                if (ballChanged)
                {
                    PlayPaddleSound();
                    Program.ball.BallReversedFromPaddle();
                    Program.ball.AdjustPositionAndReDraw();
                }

                Erase();
                base.MoveUp();
                Draw();
            }
        }

        protected override void MoveDown()
        {
            if (CurrentTop < ((heightOfConsole - 1) - marginFromTopOfScreenToPaddle))
            {
                bool ballChanged = false;

                if (BallIsBeneath())
                {
                    Program.ball.VDirection = Vertical.DOWN;
                    Program.ball.RandomizeHDirection();
                    ballChanged = true;
                }

                else if (BallIsSE())
                {
                    Program.ball.RandomizeVDirection();
                    Program.ball.HDirection = Horizantal.RIGHT;
                    ballChanged = true;
                }

                else if (BallIsSW())
                {
                    Program.ball.RandomizeVDirection();
                    Program.ball.HDirection = Horizantal.LEFT;
                    ballChanged = true;
                }

                if (ballChanged)
                {
                    PlayPaddleSound();
                    Program.ball.BallReversedFromPaddle();
                    Program.ball.AdjustPositionAndReDraw();
                }

                Erase();
                base.MoveDown();
                Draw();
            }
        }

    }
}
