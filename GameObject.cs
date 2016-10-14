using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static pong.MyShared;
using static System.Console;

namespace pong
{
    abstract class GameObject                            // this class is the parent of all of the game objects
    {                                                   // which include the 2 paddles and the ball
        public GameObject(int lPos, int tPos, string oChar)       // initialize position and character to draw
        {
            Left = lPos;
            Top = tPos;
            objectChar = oChar;
        }
        private void GoToPositionOnScreen()                   // sets the cursor position to where the object is on screen
        {
            SetCursorPosition(Left, Top);
        }

        public void Draw()                                  // draws the object on the screen
        {
            GoToPositionOnScreen();
            MakeTextVisible();
            Write(objectChar);
            MakeTextInvisible();
        }

        public void MoveUp()                                // moves the object character up one unit
        {
            GoToPositionOnScreen();                           // go to where the object character currently is

            MakeTextInvisible();                            // set text color to same as background so it is not visible

            Write(" ");                                     // output a space to get rid of current object character

            --Top;                                          // move cursor position marker up one  

            GoToPositionOnScreen();                           // move cursor to new position, which is up one row

            MakeTextVisible();                              // set text color to visible

            Draw();                                         // output object character in new position

            MakeTextInvisible();                            // make any new text invisible again
        }

        public void MoveDown()                              // moves the object character down one unit
        {
            GoToPositionOnScreen();                           // go to where the object character currently is

            MakeTextInvisible();                            // set text color to same as background so it is not visible

            Write(" ");                                     // output a space to get rid of current object character

            ++Top;                                          // move cursor position marker down one  

            GoToPositionOnScreen();                           // move cursor to new position, which is down one row

            MakeTextVisible();                              // set text color to visible

            Draw();                                         // output object character in new position

            MakeTextInvisible();                            // make any new text invisible again
        }

        private int Top { get; set; }                       // the current position of the object character from the top of the console window
                                                                      
        private int Left { get; set; }                      // the current position of the object character from the left of the console window

        private string objectChar { get; set; }               // character representing this object on screen
    }
}
