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


            //Checks if the image is > 0 then moves the image left, else stops at position 0
            //If position.X is less than or equal to the screen width minus the image height. stops the image from moving off the right of screen
            switch (direction)
            {
                case EDirection.Left:
                    if (position.X > 0)
                    position.X -= 20;
                    break;
                case EDirection.Right:
                    if (position.X <= Screen.PrimaryScreen.Bounds.Width - height)
                        position.X += 20;
                    break;

                default:
                    break;
            }
        }



        public EDirection Direction
        {
            get { return direction; }
            set { direction = value; }
        }

    }
}
