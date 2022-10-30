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
            player = new Player(playShip, graphics, true, new Point(boundryHeight/2, boundryWidth/2), playShip.Width, playShip.Height);
        }


        //Main method that runs on every timer tick
        //Draws player
        //
        public void GameRun()
        {
            player.DrawPlayer();
        }

        //Method to set up variables for game control
        public void SetVariables(Point boundries)
        {
            rand = new Random();
            playShip = Properties.Resources.Player;
            boundryWidth = boundries.X - playShip.Height; //Sets player X position to the value of boundries - the image height to display above taskbar
            boundryHeight = boundries.Y;
        }

        //Method to move the player left and right
        public void PlayerMovement(EDirection direction)
        {
            player.Direction = direction;
            player.Move();
        }



        //Gets and sets X&Y size of screen
        public Point boundries
        {
            get;
            set;
        }

    }
}
