using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using static pong.SharedConsoleData;
using System.Threading;
using static pong.GameObject;

namespace pong
{
    class Program
    {
        // class-wide static data members, will serve as handles to the current game objects
        public static Paddle lPaddle;  // handle to the current left paddle
        public static Paddle rPaddle; // handle to the current right paddle
        public static Ball ball;    // handle to the current ball
        static GameObject[] gameObjects = null; // array which holds the game objects - 2 paddles and the ball
        static LeftScoreNumber lScore;  // handle to the left hand score number
        static RightScoreNumber rScore; // handle to the right hand score number
        static ScoreNumber[] scores;    // array to hold both left and right hand score numbers

        public delegate void NewBallEventHandler();
        public static event NewBallEventHandler NewBall;
        public delegate void GameOverEventHandler();
        public static event GameOverEventHandler GameOver;

        static void Main(string[] args)
        {
            // set up console
            SetWindowSize(widthOfConsole, heightOfConsole); // set up console dimensions
            ForegroundColor = textColor;
            BackgroundColor = backgroundColor;
            CursorVisible = false;  // make the cursor invisible
            SetScreenSquaresToNull();
            GameOver += GameOverHandler;

            SetUpNewGame();  // set up the new game

            // main game loop
            while (true)
            {
                SetCursorPosition(0, 0);

                if (KeyAvailable)
                {
                    ConsoleKey keyPressed = ReadKey().Key;

                    if (keyPressed == ConsoleKey.UpArrow)
                    {
                        rPaddle.Move(0);
                    }

                    else if (keyPressed == ConsoleKey.DownArrow)
                    {
                        rPaddle.Move(1);
                    }
                }

                lPaddle.Move();

                ball.Move();
            }
        }

        public static void RoundOverTarget(Horizantal sideThatWon)
        {
            PlayPointSound();
            bool gameOver = false;

            Thread.Sleep(1000);

            if (sideThatWon == Horizantal.RIGHT)
            {
                ++rScore.Value;
                rScore.Draw();
            }
            else
            {
                ++lScore.Value;
                lScore.Draw();
            }

            if ((rScore.Value == 11) || (lScore.Value == 11))
            {
                gameOver = true;
                GameOver();
            }

            if (!gameOver)
            {
                ball = new Ball();
                NewBall();
                Thread.Sleep(2000);
                ball.Start();
            }
        }

        private static void GameOverHandler()
        {
            string answer = null;

            while ((answer != "Y") && (answer != "N"))
            {
                Clear();
                DrawCenterLine();
                lScore.Draw();
                rScore.Draw();
                rPaddle.Draw();
                lPaddle.Draw();
                MakeTextVisible();
                CursorTop = ((heightOfConsole / 2) - 1);
                CursorLeft = ((widthOfConsole / 2) - 4);

                WriteLine("GAME OVER");

                CursorLeft = ((widthOfConsole / 2) - 7);
                Write("PLAY AGAIN? Y/N: ");
                answer = ReadLine();
            }

            if (answer == "N")
            {
                Environment.Exit(0);
            }

            else if (answer == "Y")
            {
                Clear();
                SetUpNewGame();
            }
        }

        private static void SetUpNewGame() // sets the stage for a new game to begin by putting objects in their places on the screen
        {
            DrawCenterLine();
            // first get new score numbers, initialized to zero
            lScore = new LeftScoreNumber();
            rScore = new RightScoreNumber();
            scores = new ScoreNumber[] { lScore, rScore };

            // and draw them
            foreach (ScoreNumber sn in scores)
            {
                sn.Draw();
            }

            // then erase any existing GameObjects from their current positions
            if (gameObjects != null)
            {
                foreach (GameObject p in gameObjects)
                {
                    p.Erase();
                }
            }

            // then get new GameObjects
            ball = new pong.Ball();
            lPaddle = new AiPaddle(marginFromSideOfScreenToPaddle, heightOfConsole / 2);
            rPaddle = new HumanPaddle((widthOfConsole - 1) - marginFromSideOfScreenToPaddle, heightOfConsole / 2);
            gameObjects = new GameObject[] { lPaddle, rPaddle, ball };

            rPaddle.Draw();
            lPaddle.Draw();

            Thread.Sleep(2000); // sleep for 4 seconds until game starts
            ball.Start();
        }
    }
}
