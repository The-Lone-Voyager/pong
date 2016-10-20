using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using static pong.SharedConsoleData;

namespace pong
{
    class Ball : GameObject
    {
        public delegate void RoundOverEventHandler(Horizantal sideThatWon); // delegate to handle round over event
        public event RoundOverEventHandler RoundOver;   // event that fires when the ball goes out of bounds

        public delegate void BallDirectionReversedEventHandler();   // delegate to handle when ball is reversed
        public event BallDirectionReversedEventHandler BallDirectionReversed;    // fires when the ball direction is reversed

        public delegate void BallWithinRangeEventHandler();
        public event BallWithinRangeEventHandler BallWithinRange;

        public Ball()
            : base(widthOfConsole/2, heightOfConsole/2, "■")
        {
            Random rnd = new Random();
            CurrentTop = rnd.Next(marginFromTopOfScreenToPaddle, (heightOfConsole - marginFromTopOfScreenToPaddle));
            BallDirectionReversed += new BallDirectionReversedEventHandler(SetProjectedPosition);
            RoundOver += new RoundOverEventHandler(Program.RoundOverTarget);
        }

        public void Start()
        {
            RandomizeHDirection();
            RandomizeVDirection();
            SetProjectedPosition();
            Draw();
            Move();
        }

        public void SetProjectedPosition()
        {
            Ball testBall = new Ball();
            testBall.CurrentTop = CurrentTop;
            testBall.CurrentLeft = CurrentLeft;
            testBall.HDirection = HDirection;
            testBall.VDirection = VDirection;

            if (testBall.HDirection == Horizantal.RIGHT)
            {
                while (testBall.CurrentLeft < ((widthOfConsole - 1) - marginFromSideOfScreenToPaddle))
                {
                    testBall.Move(1);
                }

                ProjectedColumn = testBall.CurrentLeft;
                ProjectedRow = testBall.CurrentTop;
            }

            else if (testBall.HDirection == Horizantal.LEFT)
            {
                while (testBall.CurrentLeft >  marginFromSideOfScreenToPaddle)
                {
                    testBall.Move(1);
                }

                ProjectedColumn = testBall.CurrentLeft;
                ProjectedRow = testBall.CurrentTop;
            }
        }

        public void RandomizeHDirection()
        {
            Random rnd = new Random();
            HDirection = (Horizantal)rnd.Next(2);
        }

        public void RandomizeVDirection()
        {
            Random rnd = new Random();
            VDirection = (Vertical)rnd.Next(3);
        }

        public override void Move(int direction = 0)    // ball's implementation of move, ignores arg
        {
            if (direction == 0)
            {
                bool roundOver = false;
                if (IsMoveAvailable())
                {
                    UpdateLastMove();
                    switch (VDirection)
                    {
                        case Vertical.NONE:
                            {
                                switch (HDirection)
                                {
                                    case Horizantal.LEFT:
                                        {
                                            if (IsNextToLeftBoundary())
                                            {
                                                Erase();
                                                roundOver = true;
                                                RoundOver(Horizantal.RIGHT);
                                            }

                                            else if (IsRightOfLeftPaddle())
                                            {
                                                PlayPaddleSound();
                                                ReverseHDirection();
                                                RandomizeVDirection();
                                                BallDirectionReversed();
                                            }
                                            break;
                                        }

                                    case Horizantal.RIGHT:
                                        {
                                            if (IsNextToRightBoundary())
                                            {
                                                Erase();
                                                roundOver = true;
                                                RoundOver(Horizantal.LEFT);
                                            }

                                            else if (IsLeftOfRightPaddle())
                                            {
                                                PlayPaddleSound();
                                                ReverseHDirection();
                                                RandomizeVDirection();
                                                BallDirectionReversed();
                                            }
                                            break;
                                        }
                                }
                                break;
                            }
                        case Vertical.UP:
                            {
                                switch (HDirection)
                                {
                                    case Horizantal.LEFT:
                                        {
                                            if (IsNextToLeftBoundary())
                                            {
                                                Erase();
                                                roundOver = true;
                                                RoundOver(Horizantal.RIGHT);
                                            }

                                            else if (IsRightOfLeftPaddle())
                                            {
                                                PlayPaddleSound();
                                                ReverseHDirection();
                                                RandomizeVDirection();
                                                BallDirectionReversed();
                                            }

                                            else if (IsNextToUpperWall())
                                            {
                                                PlayWallSound();
                                                ReverseVDirection();
                                            }

                                            else if (IsSEOfLeftPaddle())
                                            {
                                                PlayPaddleSound();
                                                ReverseHDirection();
                                                RandomizeVDirection();
                                                BallDirectionReversed();
                                            }

                                            else if (IsSEOfRightPaddle())
                                            {
                                                PlayPaddleSound();
                                                ReverseHDirection();
                                                RandomizeVDirection();
                                                BallDirectionReversed();
                                            }

                                            else if (IsBeneathRightPaddle())
                                            {
                                                PlayPaddleSound();
                                                ReverseVDirection();
                                                RandomizeHDirection();
                                                BallDirectionReversed();
                                            }

                                            else if (IsBeneathLeftPaddle())
                                            {
                                                PlayPaddleSound();
                                                ReverseVDirection();
                                                RandomizeHDirection();
                                                BallDirectionReversed();
                                            }

                                            break;
                                        }

                                    case Horizantal.RIGHT:
                                        {
                                            if (IsNextToRightBoundary())
                                            {
                                                roundOver = true;
                                                Erase();
                                                RoundOver(Horizantal.LEFT);
                                            }

                                            else if (IsLeftOfRightPaddle())
                                            {
                                                PlayPaddleSound();
                                                ReverseHDirection();
                                                RandomizeVDirection();
                                                BallDirectionReversed();
                                            }

                                            else if (IsNextToUpperWall())
                                            {
                                                PlayWallSound();
                                                ReverseVDirection();
                                            }

                                            else if (IsSWOfLeftPaddle())
                                            {
                                                PlayPaddleSound();
                                                ReverseVDirection();
                                                RandomizeHDirection();
                                                BallDirectionReversed();
                                            }

                                            else if (IsSWOfRightPaddle())
                                            {
                                                PlayPaddleSound();
                                                ReverseVDirection();
                                                RandomizeHDirection();
                                                BallDirectionReversed();
                                            }

                                            else if (IsBeneathLeftPaddle())
                                            {
                                                PlayPaddleSound();
                                                ReverseVDirection();
                                                RandomizeHDirection();
                                                BallDirectionReversed();
                                            }

                                            else if (IsBeneathRightPaddle())
                                            {
                                                PlayPaddleSound();
                                                ReverseVDirection();
                                                RandomizeHDirection();
                                                BallDirectionReversed();
                                            }
                                            break;
                                        }
                                }
                                break;
                            }
                        case Vertical.DOWN:
                            {
                                switch (HDirection)
                                {
                                    case Horizantal.LEFT:
                                        {
                                            if (IsNextToLeftBoundary())
                                            {
                                                Erase();
                                                roundOver = true;
                                                RoundOver(Horizantal.RIGHT);
                                            }

                                            else if (IsRightOfLeftPaddle())
                                            {
                                                PlayPaddleSound();
                                                RandomizeVDirection();
                                                ReverseHDirection();
                                                BallDirectionReversed();
                                            }

                                            else if (IsNextToLowerWall())
                                            {
                                                PlayWallSound();
                                                ReverseVDirection();
                                            }

                                            else if (IsNEOfLeftPaddle())
                                            {
                                                PlayPaddleSound();
                                                ReverseVDirection();
                                                RandomizeHDirection();
                                                BallDirectionReversed();
                                            }

                                            else if (IsNEOfRightPaddle())
                                            {
                                                PlayPaddleSound();
                                                ReverseVDirection();
                                                RandomizeHDirection();
                                                BallDirectionReversed();
                                            }

                                            else if (IsOnTopOfLeftPaddle())
                                            {
                                                PlayPaddleSound();
                                                ReverseVDirection();
                                                RandomizeHDirection();
                                                BallDirectionReversed();
                                            }

                                            else if (IsOnTopOfRightPaddle())
                                            {
                                                PlayPaddleSound();
                                                ReverseVDirection();
                                                RandomizeHDirection();
                                                BallDirectionReversed();
                                            }

                                            break;
                                        }

                                    case Horizantal.RIGHT:
                                        {
                                            if (IsNextToRightBoundary())
                                            {
                                                Erase();
                                                roundOver = true;
                                                RoundOver(Horizantal.LEFT);
                                            }

                                            else if (IsLeftOfRightPaddle())
                                            {
                                                PlayPaddleSound();
                                                ReverseHDirection();
                                                RandomizeVDirection();
                                                BallDirectionReversed();
                                            }

                                            else if (IsNextToLowerWall())
                                            {
                                                PlayWallSound();
                                                ReverseVDirection();
                                            }

                                            else if (IsNWOfLeftPaddle())
                                            {
                                                PlayPaddleSound();
                                                ReverseVDirection();
                                                RandomizeHDirection();
                                                BallDirectionReversed();
                                            }

                                            else if (IsNWOfRightPaddle())
                                            {
                                                PlayPaddleSound();
                                                ReverseVDirection();
                                                RandomizeHDirection();
                                                BallDirectionReversed();
                                            }

                                            else if (IsOnTopOfLeftPaddle())
                                            {
                                                PlayPaddleSound();
                                                ReverseVDirection();
                                                RandomizeHDirection();
                                                BallDirectionReversed();
                                            }

                                            else if (IsOnTopOfRightPaddle())
                                            {
                                                PlayPaddleSound();
                                                ReverseVDirection();
                                                RandomizeHDirection();
                                                BallDirectionReversed();
                                            }

                                            break;
                                        }
                                }
                                break;
                            }
                    }

                    if (!roundOver)
                    {
                        AdjustPositionAndReDraw();
                    }
                }
            }

            else if (direction == 1)
            {
                switch (VDirection)
                {
                    case Vertical.UP:
                        {
                            switch (HDirection)
                            {
                                case Horizantal.LEFT:
                                    {
                                        if (IsNextToUpperWall())
                                        {
                                            ReverseVDirection();
                                        }

                                        break;
                                    }

                                case Horizantal.RIGHT:
                                    {
                                        if (IsNextToUpperWall())
                                        {
                                            ReverseVDirection();
                                        }

                                        break;
                                    }
                            }
                            break;
                        }
                    case Vertical.DOWN:
                        {
                            switch (HDirection)
                            {
                                case Horizantal.LEFT:
                                    {
                                        if (IsNextToLowerWall())
                                        {
                                            ReverseVDirection();
                                        }

                                        break;
                                    }

                                case Horizantal.RIGHT:
                                    {
                                        if (IsNextToLowerWall())
                                        {
                                            ReverseVDirection();
                                        }

                                        break;
                                    }
                            }
                            break;
                        }
                }

                switch (VDirection)
                {
                    case Vertical.UP:
                        {
                            MoveUp();
                            break;
                        }

                    case Vertical.DOWN:
                        {
                            MoveDown();
                            break;
                        }
                }

                switch (HDirection)
                {
                    case Horizantal.LEFT:
                        {
                            MoveLeft();
                            break;
                        }
                    case Horizantal.RIGHT:
                        {
                            MoveRight();
                            break;
                        }
                }
            }
        }

        public void AdjustPositionAndReDraw()
        {
            switch (VDirection)
            {
                case Vertical.UP:
                    {
                        Erase();
                        MoveUp();
                        break;
                    }

                case Vertical.DOWN:
                    {
                        Erase();
                        MoveDown();
                        break;
                    }
            }

            switch (HDirection)
            {
                case Horizantal.LEFT:
                    {
                        Erase();
                        MoveLeft();
                        break;
                    }
                case Horizantal.RIGHT:
                    {
                        Erase();
                        MoveRight();
                        break;
                    }
            }

            if (HDirection == Horizantal.LEFT)
            {
                if (CurrentLeft <= (widthOfConsole * pointWhenAICanMove))
                {
                    BallWithinRange();
                }

            }

            else
            {
                if (CurrentLeft >= (widthOfConsole * (1 - pointWhenAICanMove)))
                {
                    BallWithinRange();
                }
            }

            Draw();
        }

        private bool IsNextToLeftBoundary()
        {
            if (CurrentLeft == 0)
            {
                return true;
            }

            return false;
        }

        private bool IsNextToRightBoundary()
        {
            if (CurrentLeft == (widthOfConsole - 1))
            { return true; }

            return false;
        }

        private bool IsNextToUpperWall()
        {
            if (CurrentTop == 0)
            {
                return true;
            }

            return false;
        }

        private bool IsNextToLowerWall()
        {
            if (CurrentTop == (heightOfConsole - 1))
            {
                return true;
            }

            return false;
        }
        public void ReverseVDirection()
        {
            switch(VDirection)
            {
                case Vertical.DOWN:
                    {
                        VDirection = Vertical.UP;
                        break;
                    }

                case Vertical.UP:
                    {
                        VDirection = Vertical.DOWN;
                        break;
                    }

                default:
                    break;
            }
        }

        public void ReverseHDirection()
        {
            switch (HDirection)
            {
                case Horizantal.RIGHT:
                    {
                        HDirection = Horizantal.LEFT;
                        break;
                    }

                case Horizantal.LEFT:
                    {
                        HDirection = Horizantal.RIGHT;
                        break;
                    }

                default:
                    break;
            }
        }

        private bool IsOnTopOfRightPaddle()
        {
            if (IsInSameColumnAsRightPaddle())
            {
                if ((CurrentTop + 1) == (Program.rPaddle.CurrentTop))
                {
                    return true;
                }

                return false;
            }

            return false;
        }

        private bool IsOnTopOfLeftPaddle()
        {
            if (IsInSameColumnAsLeftPaddle())
            {
                if ((CurrentTop + 1) == (Program.lPaddle.CurrentTop))
                {
                    return true;
                }

                return false;
            }
            return false;
        }

        private bool IsBeneathRightPaddle()
        {
            if (IsInSameColumnAsRightPaddle())
            {
                if ((CurrentTop - 1) == (Program.rPaddle.CurrentTop))
                {
                    return true;
                }

                return false;
            }

            return false;
        }

        private bool IsBeneathLeftPaddle()
        {
            if (IsInSameColumnAsLeftPaddle())
            {
                if ((CurrentTop - 1) == (Program.lPaddle.CurrentTop))
                {
                    return true;
                }

                return false;
            }

            return false;
        }

        private bool IsRightOfLeftPaddle()
        {
            if (IsInSameRowAsLeftPaddle() && ((CurrentLeft - 1) == (Program.lPaddle.CurrentLeft)))
            {
                return true;
            }

            return false;
        }

        private bool IsRightOfRightPaddle()
        {
            if (IsInSameRowAsRightPaddle() && ((CurrentLeft - 1) == (Program.rPaddle.CurrentLeft)))
            {
                return true;
            }

            return false;
        }

        private bool IsLeftOfRightPaddle()
        {
            if (IsInSameRowAsRightPaddle() && ((CurrentLeft + 1) == (Program.rPaddle.CurrentLeft)))
            {
                return true;
            }

            return false;
        }

        private bool IsLeftOfLeftPaddle()
        {
            if (IsInSameRowAsLeftPaddle() && ((CurrentLeft + 1) == (Program.lPaddle.CurrentLeft)))
            {
                return true;
            }

            return false;
        }

        private bool IsNEOfLeftPaddle()
        {
            if (((CurrentTop + 1) == (Program.lPaddle.CurrentTop)) && ((CurrentLeft - 1) == (Program.lPaddle.CurrentLeft)))
            {
                return true;
            }

            return false;
        }

        private bool IsNEOfRightPaddle()
        {
            if (((CurrentTop + 1) == (Program.rPaddle.CurrentTop)) && ((CurrentLeft - 1) == (Program.rPaddle.CurrentLeft)))
            {
                return true;
            }

            return false;
        }

        private bool IsNWOfRightPaddle()
        {
            if (((CurrentTop + 1) == (Program.rPaddle.CurrentTop)) && ((CurrentLeft + 1) == (Program.rPaddle.CurrentLeft)))
            {
                return true;
            }

            return false;
        }

        private bool IsNWOfLeftPaddle()
        {
            if (((CurrentTop + 1) == (Program.lPaddle.CurrentTop)) && ((CurrentLeft + 1) == (Program.lPaddle.CurrentLeft)))
            {
                return true;
            }

            return false;
        }

        private bool IsSEOfRightPaddle()
        {
            if (((CurrentTop - 1) == (Program.rPaddle.CurrentTop)) && ((CurrentLeft - 1) == (Program.rPaddle.CurrentLeft)))
            {
                return true;
            }

            return false;
        }

        private bool IsSEOfLeftPaddle()
        {
            if (((CurrentTop - 1) == (Program.lPaddle.CurrentTop)) && ((CurrentLeft - 1) == (Program.lPaddle.CurrentLeft)))
            {
                return true;
            }

            return false;
        }

        private bool IsSWOfRightPaddle()
        {
            if (((CurrentTop - 1) == (Program.rPaddle.CurrentTop)) && ((CurrentLeft + 1) == (Program.rPaddle.CurrentLeft)))
            {
                return true;
            }

            return false;
        }

        private bool IsSWOfLeftPaddle()
        {
            if (((CurrentTop - 1) == (Program.lPaddle.CurrentTop)) && ((CurrentLeft + 1) == (Program.lPaddle.CurrentLeft)))
            {
                return true;
            }

            return false;
        }

        private bool IsInSameColumnAsLeftPaddle()
        {
            if (CurrentLeft == Program.lPaddle.CurrentLeft)
            {
                return true;
            }

            return false;
        }

        private bool IsInSameColumnAsRightPaddle()
        {
            if (CurrentLeft == Program.rPaddle.CurrentLeft)
            {
                return true;
            }

            return false;
        }

        private bool IsInSameRowAsLeftPaddle()
        {
            if (CurrentTop == Program.lPaddle.CurrentTop)
            {
                return true;
            }

            return false;
        }

        private bool IsInSameRowAsRightPaddle()
        {
            if (CurrentTop == Program.rPaddle.CurrentTop)
            {
                return true;
            }

            return false;
        }

        public void BallReversedFromPaddle() // resets the ball in the center of the field
        {
            BallDirectionReversed();
        }

        private bool IsMoveAvailable()  // determines whether or not enough time has passed for the ball to make a move
        {
            if (((DateTime.Now - TimeOfLastMove).TotalMilliseconds) >= WaitTime)
            {
                return true;
            }

            return false;
        }

        public int ProjectedRow { get; set; }
        public int ProjectedColumn { get; set; }

        public Horizantal HDirection { get; set; }  // horizantal direction the ball is traveling
        public Vertical VDirection { get; set; }    // vertical direction the ball is traveling
        private int WaitTime { get; set; } = 50; // increasing this number slows down the ball, decreasing it will speed it up
    }
}
