using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space_Invaders
{
    public class Player : Ships
    {

        private EDirection direction;

        public Player(Bitmap bitmap, Graphics graphics, bool isAlive, Point position, int width, int height)
            : base(bitmap, graphics, isAlive, position, width, height)
        {

        }



        //Moves the player X amount of pixels depending if Left or Right keys have been
        //Pressed or held

        public override void Move()
        {



            switch (direction)
            {
                case EDirection.Left:
                    if (position.X > 0)
                    position.X -= 20;
                    break;
                case EDirection.Right:
                    //if (position.X + width < boundries.Width)
                        position.X += 20;
                    break;

                default:
                    break;
            }
        }

        public Size boundries
        {
            get;
            set;
        }


        public EDirection Direction
        {
            get { return direction; }
            set { direction = value; }
        }

    }
}
