using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space_Invaders
{
    public class Player : Ships
    {
        public Player(Bitmap bitmap, Graphics graphics, bool isAlive, Point boundries, Point position) : base(bitmap, graphics, isAlive, boundries, position)
        {

        }




        //public override void Move()
        //{
        //    switch(Direction)
        //    {

        //    }
        //}

        //public EDirection EDirection { get => direction; set => edirection = value; }

    }
}
