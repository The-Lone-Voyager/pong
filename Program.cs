using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using static pong.MyShared;

namespace pong
{
    class Program
    {   
        static void Main(string[] args)
        {
            SetWindowSize(width, height + 1);
            CursorVisible = false;

            SetCursorPosition(width / 2, 0);

            for (int i = 0; i < height; ++i)
            {
                MakeTextVisible();
                Write("|");
                ++CursorTop;
                --CursorLeft;
            }

            //WriteLine("█");

            /*while (true)
            {
                ForegroundColor = backgroundColor;
                if (KeyAvailable)
                {
                    ConsoleKeyInfo keyPressed = ReadKey();
                    CursorLeft = 0;
                    ForegroundColor = textColor;
                    WriteLine("Got the key " + keyPressed.KeyChar);
                    ForegroundColor = backgroundColor;
                }
            }*/

            LeftPaddle lPaddle = new LeftPaddle();
            RightPaddle rPaddle = new RightPaddle();
            Ball ball = new Ball();
            LeftScoreNumber lScore = new LeftScoreNumber();
            RightScoreNumber rScore = new RightScoreNumber();

            ScoreNumber[] scores = { lScore, rScore };

            GameObject[] gameObjects = { lPaddle, rPaddle, ball };

            foreach (ScoreNumber sn in scores)
            {
                sn.Draw();
            }

            foreach (GameObject p in gameObjects)
            {
                p.Draw();
            }

            ReadLine();
        }
    }
}
