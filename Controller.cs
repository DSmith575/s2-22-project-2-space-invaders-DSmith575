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
        private Graphics graphics;
        private Timer timer1;
        private Random rand;

        private Player player;
        private AlienFleet alienFleet;
        private MissileList missileList;
        private BombList bomblist;

        private SoundPlayer missileLaunch;
        private SoundPlayer playerHit;
        private SoundPlayer missileHit;
        private Scores scores;


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

        //Method to set up variables for game control
        public void SetVariables(Point boundries)
        {
            rand = new Random();
            playShip = Properties.Resources.Player;
            boundryWidth = boundries.X;
            boundryHeight = boundries.Y;
            missileLaunch = new SoundPlayer(Properties.Resources.blaster);
            missileHit = new SoundPlayer(Properties.Resources.sfxS);
            playerHit = new SoundPlayer(Properties.Resources.bomb);
            scores = new Scores();
        }

        //Main method that runs on every timer tick
        // Draws objects (player, aliens, bombs, missiles
        public void GameRun()
        {
            DrawRun();
            CheckWin();
            MoveObjects();
            CollisionDetection();
            DropBomb();
            missileList.LifeCheck();
            bomblist.LifeCheckBomb();
        }

        //Runs on every timer tick, Draws every "image"
        public void DrawRun()
        {
            player.DrawShips();
            alienFleet.DrawFleet();
            missileList.DrawM();
            bomblist.DrawB();
        }

        //Method that calls each collision method, instead of having multiple different ones in the gameRun method
        public void CollisionDetection()
        {
            AlienCollisionMissile();
            AlienBoundryCollision();
            AlienPlayerCollision();
            PlayerHitByBomb();
            BombMissileCollision();
        }

        //Method containing all objects movement methods
        public void MoveObjects()
        {
            alienFleet.Movement();
            missileList.MoveMissile();
            bomblist.MoveBomb();
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


        //Method to check each alien ship in the fleet list, if alien has the "Alive" status of true, it can drop a bomb
        //Method runs a rand.next and if the value equals 0, that alien will created a bomb and add it to the list.
        public void DropBomb()
        {
            for (int i = 0; i < alienFleet.AlienShips.Count; i++)
            {
                if (alienFleet.AlienShips[i].CanShoot== true)
                {
                    int bombChance = rand.Next(0, 99);
                    if (bombChance == 0)
                    {
                        bomblist.SpawnBombs(graphics, new Point(alienFleet.AlienShips[i].Position.X, alienFleet.AlienShips[i].Position.Y), rand.Next(1, LIFELIMITTIME));
                        missileLaunch.Play();
                    }
                }
            }
        }

        //Checks if alien bombs and player missiles collide, if so removes both from the form
        public void BombMissileCollision()
        {
            for (int i = 0; i < missileList.PlayerMissiles.Count; i++)
            {
                for (int j = 0; j < bomblist.AlienBombs.Count; j++)
                {
                    if (missileList.PlayerMissiles[i].rect().IntersectsWith(bomblist.AlienBombs[j].rect()))
                    {
                        missileHit.Play();
                        missileList.PlayerMissiles.Remove(missileList.PlayerMissiles[i]);
                        bomblist.AlienBombs.Remove(bomblist.AlienBombs[j]);
                        break;
                    }
                }
            }
        }

        //Checks each row and column of alien fleet ships
        //if a missile touches an alien ship, both that missile and the alien ship are removed from their lists
        public void AlienCollisionMissile()
        {
            //Checks each missiles rectangle and if it touches an alien ship will remove both missile and alien from the form.
            //Then checks if the destroyed ship had the Alive bool of true, and if so, passes it to the next ship
            for (int i = 0; i < missileList.PlayerMissiles.Count; i++)
            {
                for (int j = 0; j < alienFleet.AlienShips.Count; j++)
                {
                    if (missileList.PlayerMissiles[i].rect().IntersectsWith(alienFleet.AlienShips[j].rect()))
                    {
                        missileHit.Play();
                        missileList.PlayerMissiles.Remove(missileList.PlayerMissiles[i]);

                        //Using j-1 would out of bounds when hitting the ship[0]
                        //Putting in the if statement below stopped an out of bounds error
                        if (alienFleet.AlienShips[j] == alienFleet.AlienShips[0])
                        {
                            alienFleet.AlienShips.Remove(alienFleet.AlienShips[j]);
                            break;
                        }
                        if (alienFleet.AlienShips[j - 1].CanShoot != true) //(39 > 38) COLS before Rows   && alienFleet.AlienShips[j] != alienFleet.AlienShips[0]
                        {

                            alienFleet.AlienShips[j - 1].CanShoot = true;
                        }

                        alienFleet.AlienShips.Remove(alienFleet.AlienShips[j]);
                        break; //Break here else if keeps running while the list has been altered (out of bounds error)
                    }
                }
            }
        }



        //Checks each alien bombs rectangle touches the players rectangle
        //If true, disables timer and displays you have lost
        public void PlayerHitByBomb()
        {
            for (int i = 0; i < bomblist.AlienBombs.Count; i++)
            {
                if (bomblist.AlienBombs[i].rect().IntersectsWith(player.rect()))
                {
                    playerHit.Play();
                    CheckLose();
                    break;
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
                    CheckLose();
                    break;
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
                    playerHit.Play();
                    CheckLose();
                    break;
                }
            }
        }

        //Checks if the alienFleet List count is 0
        //If true, disables the timer and displays that you have won.
        public void CheckWin()
        {
            if (alienFleet.AlienShips.Count == 0)
            {
                timer1.Enabled = false;
                MessageBox.Show("You Win!");
                scores.StoreScores(0);
                Application.Restart();
            }
        }


        //Method called when some criteria of playing hit collision is triggered
        public void CheckLose()
        {
            timer1.Enabled = false;
            MessageBox.Show("You lose");
            scores.StoreScores(1);
            Application.Restart();
        }


        //Gets and sets X&Y size of screen
        public Point boundries
        {
            get;
            set;
        }

    }
}
