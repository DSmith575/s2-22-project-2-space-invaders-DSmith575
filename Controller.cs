using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Timer = System.Windows.Forms.Timer;

namespace Space_Invaders
{
    public class Controller
    {
        //const variable dicating the last possible duration limit set by the rand for the value for missile/bomb "lifeLimit"
        private const int LIFELIMITTIME = 70;

        private Bitmap playShip;
        private Random rand;
        private Player player;
        private AlienFleet alienFleet;
        private MissileList missileList;
        private BombList bomblist;
        private Graphics graphics;
        private Timer timer1;


        private int boundryWidth;
        private int boundryHeight;

        
        public Controller(Point boundries, Graphics graphics, Random rand, Timer timer1)
        {
            this.graphics = graphics;
            this.rand = rand;
            this.timer1 = timer1;
            SetVariables(boundries);
            player = new Player(playShip, graphics, true, new Point(boundryHeight / 2, boundryWidth / 2), playShip.Width, playShip.Height);
            alienFleet = new AlienFleet(graphics);
            missileList = new MissileList(graphics);
            bomblist = new BombList(graphics);
        }


        //Main method that runs on every timer tick
        //Draws player, the alien/missile fleet/list collision dection, and movement
        public void GameRun()
        {
            DrawRun();
            alienFleet.Movement();
            missileList.MoveMissile();
            missileList.LifeCheck();
            CollisionDetection();
\
        }

        public void DrawRun()
        {
            player.DrawShips();
            alienFleet.DrawFleet();
            missileList.DrawM();
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


        //Method that calls each collision method, instead of having multiple different ones in the gameRun method
        public void CollisionDetection()
        {
            AlienCollisionMissile();
            AlienBoundryCollision();
            AlienPlayerCollision();
        }

        //Checks each row and column of alien fleet ships
        //if a missile touches an alien ship, both that missile and the alien ship are removed from their lists
        public void AlienCollisionMissile()
        {

            //Checks each missiles rectangle and if it touches an alien ship will remove both missile and alien from the form.
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

        //Method to check if any alien ship in the fleet has hit the bottom of the screen
        //Stops the timer and runs the scoring method.
        //Player loses
        public void AlienBoundryCollision()
        {

            for (int i = 0; i < alienFleet.AlienShips.Count; i++)
            {
                if (alienFleet.AlienShips[i].Position.Y + alienFleet.AlienShips[i].Width >= boundryHeight)
                {
                    timer1.Enabled = false;
                    //MoveToScoring
                }
            }
        }


        //Checks if anyalien Ships rectangle touches the players rectangle, disables the timer and moves the scoring method
        //Player loses
        public void AlienPlayerCollision()
        {

            for (int i = 0; i < alienFleet.AlienShips.Count; i++)
            {
                if (alienFleet.AlienShips[i].rect().IntersectsWith(player.rect()))
                {
                    timer1.Enabled=false;
                    MessageBox.Show("Hit");
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
