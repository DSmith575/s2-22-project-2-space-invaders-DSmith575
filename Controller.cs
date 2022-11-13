using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Runtime.CompilerServices;
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
        private SoundPlayer missileLaunch;
        private SoundPlayer playerHit;
        private SoundPlayer missileHit;


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
            CheckWin();
            alienFleet.Movement();
            missileList.MoveMissile();
            missileList.LifeCheck();
            CollisionDetection();
            DropBomb();
            bomblist.MoveBomb();
            bomblist.LifeCheckBomb();


        }

        public void DrawRun()
        {
            player.DrawShips();
            alienFleet.DrawFleet();
            missileList.DrawM();
            bomblist.DrawB();


        }

        //Method to set up variables for game control
        public void SetVariables(Point boundries)
        {
            rand = new Random();
            playShip = Properties.Resources.Player;
            boundryWidth = boundries.X; //Sets player X position to the value of boundries
            boundryHeight = boundries.Y;
            missileLaunch = new SoundPlayer(Properties.Resources.blaster);
            missileHit = new SoundPlayer(Properties.Resources.sfxS);
            playerHit = new SoundPlayer(Properties.Resources.bomb);
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
            missileLaunch.Play();
        }

        public void DropBomb()
        {
            for( int i = 0; i < alienFleet.AlienShips.Count; i++)
            {
                if (alienFleet.AlienShips[i].Alive == true)
                {
                    int bombChance = rand.Next(0, 9);
                    if (bombChance == 0)
                    {
                        bomblist.SpawnBombs(graphics, new Point(alienFleet.AlienShips[i].Position.X, alienFleet.AlienShips[i].Position.Y), rand.Next(1, LIFELIMITTIME));
                        missileLaunch.Play();
                    }
                }
            }
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
                        missileHit.Play();
                        missileList.PlayerMissiles.Remove(missileList.PlayerMissiles[i]);
                        if (alienFleet.AlienShips[alienFleet.AlienShips.Count-1].Alive != true)
                        {
                            alienFleet.AlienShips[alienFleet.AlienShips.Count-1].Alive = true;
                        }
                        alienFleet.AlienShips.Remove(alienFleet.AlienShips[j]);



                        break; //Break here else if keeps running while the list has been altered (out of bounds error)
                        /*
                         * 
                         * j-10 bombDrop = true; (out of bounds)
                         * if j-10 = nul
                         * break;
                         */
                    }
                }
            }
        }



        public void CheckWin()
        {
            if (alienFleet.AlienShips.Count == 0)
            {
                timer1.Enabled = false;
                MessageBox.Show("You Win!");
            }
        }

        public void PlayerHitByBomb()
        {
            playerHit.Play();
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
                    timer1.Enabled = false;
                    MessageBox.Show("Hit");
                    playerHit.Play();
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
