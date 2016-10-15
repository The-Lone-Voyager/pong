using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static pong.SharedConsoleData;
using static System.Console;

namespace pong
{
    abstract class GameObject       // this class is the direct/indirect parent of all of the game objects
    {                               // which include the 2 paddles and the ball
        public GameObject(int lPos, int tPos, string oChar) // initialize position and character to draw
        {
            Left = lPos;
            Top = tPos;
            objectChar = oChar;
        }
        private void GoToPositionOnScreen()     // sets the cursor position to where the object is on screen
        {
            SetCursorPosition(Left, Top);
        }

        public void Draw()  // draws the object on the screen then sets the text back to invisible
        {
            GoToPositionOnScreen();
            MakeTextVisible();
            Write(objectChar);
            MakeTextInvisible();
        }

        private int Top { get; set; }   // the current position of the object character from the top of the console window
                                                                      
        private int Left { get; set; }  // the current position of the object character from the left of the console window

        private string objectChar { get; set; } // character representing this object on screen
    }
}
