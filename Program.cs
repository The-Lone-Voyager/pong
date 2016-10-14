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
            SetWindowSize(width, height);
            CursorVisible = false;

            SetCursorPosition(0, 8);
            for (int i = 0; i < width; ++i)
            {
                Write('-');
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

            GameObject[] gameObjects = { lPaddle, rPaddle, ball };

            foreach (GameObject p in gameObjects)
            {
                p.Draw();
            }

            ReadLine();
        }
    }
}
