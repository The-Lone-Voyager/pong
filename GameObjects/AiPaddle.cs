using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static pong.SharedConsoleData;

namespace pong
{
    public class AiPaddle : Paddle
    {
        public AiPaddle(int leftPos, int topPos)   // leftPos value will depend on whether this is a left/right paddle
            : base(leftPos, topPos)
        {
            Program.ball.BallWithinRange += SetDestinationToNull; // register so that when ball direction is reversed destination is set back to null
            Program.NewBall += NewBallHandler;
            Program.GameOver += () =>
            {
                Program.NewBall -= NewBallHandler;
            };
        }

        private void NewBallHandler()
        {
            SetDestinationToNull();
            Program.ball.BallWithinRange += SetDestinationToNull;
        }

        public override void Move(int direction = 0)    // how the AI paddle will move, default arg is ignored
        {
            // determine if ball is moving away or coming towards

            if (BallIsMovingAway() || (!CanMoveTowardsBallPoint()))    // ball is moving away or can't yet move towards ball
            {
                if (Destination == null)    // if there is currently no destination
                {
                    if (IsMoveAvailable())  // if a move is available
                    {
                        GetNewDestination();
                        MoveTowardsDestination();
                        UpdateLastMove();
                    }
                }
                else    // if there is a current destination
                {
                    if (IsMoveAvailable())
                    {
                        if (Destination == CurrentTop) // if on the destination
                        {
                            GetNewDestination();    // get a new destination
                            MoveTowardsDestination();   // and move towards it
                            UpdateLastMove();
                        }

                        else    // if not on the destination
                        {
                            MoveTowardsDestination();
                            UpdateLastMove();
                        }
                    }                  
                }
            }
            else // ball moving towards AI paddle and paddle can start moving towards
            {
                if (Destination != null) // destination set with projected location
                {
                    if (IsMoveAvailable())
                    {
                        if (Destination != CurrentTop) // if not already on the destination
                        {
                            MoveTowardsDestination();
                            UpdateLastMove();
                        }
                    }
                }
                else // destination not set with projected location
                {
                    if (IsMoveAvailable())
                    {
                        Destination = Program.ball.ProjectedRow;
                        MoveTowardsDestination();
                        UpdateLastMove();
                    }
                }
            }
        }

        private bool BallIsMovingAway()
        {
            if (Side != Program.ball.HDirection)
            {
                return true;
            }

            return false;
        }

        private void GetNewDestination() // gets a new destination number, different from the current location
        {
            Random rnd = new Random();  // create Random to generate random destination
            Destination = rnd.Next(marginFromTopOfScreenToPaddle, ((heightOfConsole - marginFromTopOfScreenToPaddle) + 1 ) );    // get a random row as the destination
            while (Destination == CurrentTop)   // if destination picked was the same as current location
            {
                Destination = rnd.Next(heightOfConsole);    // get other destinations until a different one is chosen
            }
        }

        private void MoveTowardsDestination() // moves AI paddle one unit in direction of the destination, assumes it is not on the destination
        {
            if (CurrentTop > Destination)   // if currently above the destination
            {
                MoveUp();
            }
            else if (CurrentTop < Destination)
            {
                MoveDown();
            }
        }

        private bool IsMoveAvailable()  // determines whether or not enough time has passed for the paddle to make a move
        {
            if (((DateTime.Now - TimeOfLastMove).TotalMilliseconds) >= WaitTime)
            {
                return true;
            }

            return false;
        }

        private bool CanMoveTowardsBallPoint() // returns bool indicating whether or not the ball is moving away from paddle
        {
                if (Side == Horizantal.LEFT)
                {
                    if (Program.ball.CurrentLeft <= (widthOfConsole * pointWhenAICanMove))
                    {
                        return true;
                    }

                    else
                    {
                        return false;
                    }
                }

                else
                {
                    if (Program.ball.CurrentLeft >= (widthOfConsole * (1 - pointWhenAICanMove)))
                    {
                        return true;
                    }

                    else
                    {
                        return false;
                    }
                }
        }

        public void SetDestinationToNull()  // resets the Destination to null
        {
            Destination = null;
        }

        private int? Destination { get; set; } = null;  // where the AI is currently trying to get to
                                                        // expressed in terms of the rows property of the console
        private int WaitTime { get; set; } = 100; // increasing this number slows down the paddle, decreasing it will speed it up

    }
}