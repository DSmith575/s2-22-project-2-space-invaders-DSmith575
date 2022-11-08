using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space_Invaders
{
    public class Controller
    {
        private const int LIFELIMITTIME = 70;

        private Bitmap playShip;
        private Bitmap alienS;
        private Random rand;
        private Player player;
        private AlienShip alien;
        private AlienFleet alienFleet;
        private MissileList missileList;
        private Graphics graphics;

        private int boundryWidth;
        private int boundryHeight;


        public Controller(Point boundries, Graphics graphics, Random rand)
        {
            this.graphics = graphics;
            this.rand = rand;
            SetVariables(boundries);
            player = new Player(playShip, graphics, true, new Point(boundryHeight/2, boundryWidth/2), playShip.Width, playShip.Height);
            alienFleet = new AlienFleet(graphics);
            missileList = new MissileList(graphics);
        }


        //Main method that runs on every timer tick
        //Draws player
        //
        public void GameRun()
        {
            player.DrawPlayer();
            //alien.DrawAlien();
            //alien.Move();

            alienFleet.Movement();
            missileList.DrawM();
            alienFleet.DrawFleet();
            missileList.MoveMissile();
            missileList.LifeCheck();


        }

        //Method to set up variables for game control
        public void SetVariables(Point boundries)
        {
            rand = new Random();
            playShip = Properties.Resources.Player;
            boundryWidth = boundries.X; //Sets player X position to the value of boundries
            boundryHeight = boundries.Y;

        }

        //Method to move the player left and right
        public void PlayerMovement(EDirection direction)
        {
            player.Direction = direction;
            player.Move();

        }

        public void PlayerFire()
        {
            missileList.SpawnMissile(graphics, new Point(player.Position.X + 2, player.Position.Y), rand.Next(1, LIFELIMITTIME));
        }

        //Gets and sets X&Y size of screen
        public Point boundries
        {
            get;
            set;
        }

    }
}
