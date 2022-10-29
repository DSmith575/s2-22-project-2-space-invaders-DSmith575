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


        public Controller(Point boundries, Graphics graphics, Random rand)
        {
            SetVariables(boundries);
            player = new Player(playShip, graphics, true, new Point(boundryHeight, boundryWidth), playShip.Width, playShip.Height);
        }

        public void GameRun()
        {
            player.DrawPlayer();
        }

        public void SetVariables(Point boundries)
        {
            rand = new Random();
            playShip = Properties.Resources.Player;
            boundryWidth = boundries.X + playShip.Height;
            boundryHeight = boundries.Y;
        }

        //Method to move the player left and right
        public void PlayerMovement(EDirection direction)
        {
            player.Direction = direction;
            player.Move();
        }


        public Point boundries
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
