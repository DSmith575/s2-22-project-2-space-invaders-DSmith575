using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space_Invaders
{
    public class Controller
    {
        private const int PLAYERPOSX = 2000;
        private const int PLAYERPOSY = 500;

        private Random rand;
        private Player player;


        public Controller(Point boundries, Graphics graphics)
        {
            rand = new Random();
            player = new Player(Properties.Resources.Player, graphics, true, boundries, new Point(PLAYERPOSX, PLAYERPOSY));
        }

        public void GameRun()
        {
            player.DrawPlayer();
        }

        //public void MovePlayer(EDirection Direction)
        //{
        //    player.Direction = Direction;
        //    player.Mov
        //}
    }
}
