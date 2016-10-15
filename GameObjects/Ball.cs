using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using static pong.MyShared;

namespace pong
{
    class Ball : GameObject
    {
        public Ball()
            : base(width/2, height/2, "■", 0)
        {

        }

        public void Move()
        {
            switch (vDir)
            {
                case VerticalDirection.None:
                    {
                        switch (hDir)
                        {
                            case HorizantalDirection.None:
                                {
                                    return;
                                }

                            case HorizantalDirection.Left:
                                {
                                    MoveLeft();
                                    return;
                                }

                            case HorizantalDirection.Right:
                                {
                                    MoveRight();
                                    return;
                                }
                        }
                        return;
                    }

                case VerticalDirection.Up:
                    {
                        switch (hDir)
                        {
                            case HorizantalDirection.None:
                                {
                                    MoveUp();
                                    return;
                                }

                            case HorizantalDirection.Left:
                                {
                                    MoveUp();
                                    MoveLeft();
                                    return;
                                }

                            case HorizantalDirection.Right:
                                {
                                    MoveUp();
                                    MoveRight();
                                    return;
                                }
                        }
                        return;
                    }

                case VerticalDirection.Down:
                    {
                        switch (hDir)
                        {
                            case HorizantalDirection.None:
                                {
                                    MoveDown();
                                    return;
                                }

                            case HorizantalDirection.Left:
                                {
                                    MoveDown();
                                    MoveLeft();
                                    return;
                                }

                            case HorizantalDirection.Right:
                                {
                                    MoveDown();
                                    MoveRight();
                                    return;
                                }
                        }
                        return;
                    }
            }
        }
    }
}
