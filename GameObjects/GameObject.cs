using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static pong.MyShared;
using static System.Console;

namespace pong
{
    public enum VerticalDirection { Up, Down, None };
    public enum HorizantalDirection { Left, Right, None };

    abstract class GameObject                            // this class is the parent of all of the game objects
    {                                                   // which include the 2 paddles and the ball
        public delegate void OffScreenEventHandler(HorizantalDirection h);
        static public event OffScreenEventHandler OffScreen;

        public GameObject(int lPos, int tPos, string oChar, int vBuffer)       // initialize position and character to draw
        {
            CurrentLeft = lPos;
            CurrentTop = tPos;
            NewLeft = lPos;
            NewTop = tPos;
            objectChar = oChar;
            VerticalBuffer = vBuffer;
        }
        private void GoToPositionOnScreen()                   // sets the cursor position to where the object is on screen
        {
            SetCursorPosition(CurrentLeft, CurrentTop);
        }

        public void Draw()                                  // draws the object on the screen
        {
            GoToPositionOnScreen();
            MakeTextVisible();
            Write(objectChar);
            MakeTextInvisible();
        }

        public void ClearGameObject()
        {
            GoToPositionOnScreen();
            MakeTextInvisible();
            Write(" ");
        }

        public void Update()
        {
            if ((CurrentTop == NewTop) && (CurrentLeft == NewLeft))
            {
                return;
            }

            else
            {
                GoToPositionOnScreen();
                MakeTextInvisible();
                Write(" ");
                CurrentTop = NewTop;
                CurrentLeft = NewLeft;
                Draw();
            }
        }

        public void MoveUp()                                // moves the object character up one unit
        {
            if (CurrentTop > VerticalBuffer)
            {
                --NewTop;                                          // move cursor position marker up one  
            }
        }

        public void MoveDown()                              // moves the object character down one unit
        {
            if (CurrentTop < (height - VerticalBuffer))
            {
                ++NewTop;                                          // move cursor position marker down one  

            }
        }

        public void MoveLeft()
        {
            if (CurrentLeft > 0)
            {
                --NewLeft;                                           

            }

            else if (CurrentLeft == 0)
            {
                OffScreen(HorizantalDirection.Left);
            }
        }

        public void MoveRight()                              
        {
            if (CurrentLeft < (width - 1))
            {
                ++NewLeft;                                           
            }

            else if (CurrentLeft == (width - 1))
            {
                OffScreen(HorizantalDirection.Right);
            }
        }

        private int CurrentTop { get; set; }                       // the current position of the object character from the top of the console window
                                                                      
        private int CurrentLeft { get; set; }                      // the current position of the object character from the left of the console window

        private int NewTop { get; set; }
        private int NewLeft { get; set; }

        private string objectChar { get; set; }               // character representing this object on screen

        private int VerticalBuffer { get; set; }            // top/bottom buffer - only applies to paddles

        public VerticalDirection vDir { get; set; } = VerticalDirection.None;
        public HorizantalDirection hDir { get; set; } = HorizantalDirection.None;
    }
}
