using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static pong.SharedConsoleData;
using static System.Console;

namespace pong
{
    public abstract class GameObject       // this class is the direct/indirect parent of all of the game objects
    {                                      // which include the 2 paddles and the ball
        public enum Vertical { UP, DOWN, NONE };   // vertical directions
        public enum Horizantal { LEFT, RIGHT };    // horizantal directions
        public GameObject(int lPos, int tPos, string oChar) // initialize position and character to draw
        {
            CurrentLeft = lPos;
            CurrentTop = tPos;
            objectChar = oChar;
        }

        private void GoToPositionOnScreen()     // sets the cursor position to where the object is on screen
        {
            SetCursorPosition(CurrentLeft, CurrentTop);
        }

        public void Draw()  // draws the object on the screen then sets the text back to invisible
        {
            MakeTextVisible();
            GoToPositionOnScreen();
            Write(objectChar);
            MakeTextInvisible();
        }

        public void Erase() // erases the GameObject from the screen
        {
            GoToPositionOnScreen();
            if (screenSquares[CursorTop, CursorLeft] != null)
            {
                MakeTextVisible();
                Write(screenSquares[CurrentTop, CurrentLeft].SquareCharacter);
                MakeTextInvisible();
            }
            else
            {
                Write(" ");
            }
        }

        protected virtual void MoveUp() // move up one position
        {
            --CurrentTop;
        }

        protected virtual void MoveDown() // move down one position
        {
            ++CurrentTop;
        }

        protected virtual void MoveLeft() // move left one position
        {
            --CurrentLeft;
        }

        protected virtual void MoveRight() // move right one position
        {
            ++CurrentLeft;
        }

        protected void UpdateLastMove()   // updates the TimeOfLastMove to the current time
        {
            TimeOfLastMove = DateTime.Now;
        }

        public abstract void Move(int direction = 0);    // AiPaddle, HumanPaddle, and Ball will all implement their moving through this method

        public int CurrentTop { get; set; }   // the current position of the object character from the top of the console window
                                                                      
        public int CurrentLeft { get; set; }  // the current position of the object character from the left of the console window

        public DateTime TimeOfLastMove = DateTime.MinValue;  // the last time this object moved, initalized to MinValue
        private string objectChar { get; set; } // character representing this object on screen
    }
}
