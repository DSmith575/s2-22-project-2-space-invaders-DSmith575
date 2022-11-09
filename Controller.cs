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
            player = new Player(playShip, graphics, true, new Point(boundryHeight / 2, boundryWidth / 2), playShip.Width, playShip.Height);
            alienFleet = new AlienFleet(graphics);
            missileList = new MissileList(graphics);
        }


        //Main method that runs on every timer tick
        //Draws player
        //
        public void GameRun()
        {
            player.DrawShips();
            alienFleet.DrawFleet();
            missileList.DrawM();
            AlienCollision();
            //alien.DrawAlien();
            //alien.Move();
            alienFleet.Movement();
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


        //On each space bar, creates a missile at the players location, with a random time limit on how long it can stay on screen
        //Each timer tick redues the life value
        public void PlayerFire()
        {
            missileList.SpawnMissile(graphics, new Point(player.Position.X + 2, player.Position.Y), rand.Next(1, LIFELIMITTIME));
        }



        //Checks each row and column of alien fleet ships
        //if a missile touches an alien ship, both that missile and the alien ship are removed from their lists
        public void AlienCollision()
        {
            for (int i = 0; i < missileList.PlayerMissiles.Count; i++)
            {
                for (int j = 0; j < alienFleet.AlienShips.Count; j++)
                {
                    if (missileList.PlayerMissiles[i].rect().IntersectsWith(alienFleet.AlienShips[j].rect()))
                    {
                        missileList.PlayerMissiles.Remove(missileList.PlayerMissiles[i]);
                        alienFleet.AlienShips.Remove(alienFleet.AlienShips[j]);
                        break;
                    }
                }
            }
        }


        //Gets and sets X&Y size of screen
        public Point boundries
        {
            get;
            set;
        }

    }
}
