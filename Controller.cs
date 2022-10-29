using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space_Invaders
{
    public class Controller
    {
        private Bitmap playShip;
        private Random rand;
        private Player player;

        private int boundryWidth;
        private int boundryHeight;


        public Controller(Point boundries, Graphics graphics)
        {
            rand = new Random();
            playShip = Properties.Resources.Player;
            boundryWidth = boundries.X;
            boundryHeight = boundries.Y;
            player = new Player(playShip, graphics, true, new Point(boundryHeight, boundryWidth), playShip.Width, playShip.Height);
        }

        public void GameRun()
        {
            player.DrawPlayer();
        }

        public Size boundries
        {
            get;
            set;
        }

        //public void MovePlayer(EDirection Direction)
        //{
        //    player.Direction = Direction;
        //    player.Mov
        //}
    }
}
