/* Program name:          Space Invaders
 * Project file name:     Space Invaders
 * Author:                Deacon Smith
 * Date:                  
 * Language:              C#
 * Platform:              Microsoft Visual Studio 2022
 *
 * Purpose:               Recreating Space Invaders for Programming 2 assessment 2.
 *
 * Description:           Alien ships will move from right to left, shifting down towards the player when they hit each side
 *                        Aliens in the front row have the ability to shoot the player, these missiles can be destroyed with your own
 *                        If an alien in the front row is destroyed, it passes the ability to shoot to the alien behind it
 *                        The goal is to destroy all ships before you get hit by a missile or the aliens reach the bottom of the screen
 *                        
 *                        Player can move using the left and right keys
 *                        Player can shoot a missile using the space bar
 *  
 *                        
 *                         
 *                     
 * Known bugs:            Flickering still appearing on my monitors
 *                        
 *                        
 *  
 * Additional features:   Sound Effects
 *                        Simple scoring system
 *                        Ability to pause, restart, resume and exit game
 *                        
 */

namespace Space_Invaders
{
    public partial class Form1 : Form
    {
        private Random rand;
        private Graphics graphics;
        private Graphics bufferGraphics;
        private Image bufferImage;
        private Point boundries;
        private Controller controller;

        public Form1()
        {
            InitializeComponent();
            timer1.Enabled = false;
            DoubleBuffered = true;
            resume.Visible = false;
            menu.Visible = false;

            Width = Screen.PrimaryScreen.Bounds.Width;
            Height = Screen.PrimaryScreen.Bounds.Height;
            boundries = new Point(Width, Height);

            graphics = CreateGraphics();
            bufferImage = new Bitmap(Width, Height);
            bufferGraphics = Graphics.FromImage(bufferImage);

            rand = new Random();
            controller = new Controller(boundries, graphics, rand, timer1);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            graphics.FillRectangle(Brushes.Black, 0, 0, Width, Height);
            controller.GameRun();
            graphics.DrawImage(bufferImage, 0, 0, Width, Height);
        }



        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    controller.PlayerMovement(EDirection.Left);
                    break;

                case Keys.Right:
                    controller.PlayerMovement(EDirection.Right);
                    break;

                case Keys.Space:
                    controller.PlayerFire();
                    break;

                case Keys.P:
                    PauseMenu();
                    break;

                default:
                    break;
            }
        }

        public void MenuReturn()
        {
            timer1.Enabled = false;
            newGame.Visible = true;
            quit.Visible = true;
            resume.Visible = false;
            menu.Visible = false;
        }

        public void PauseMenu()
        {
            timer1.Enabled = false;
            resume.Visible = true;
            menu.Visible = true;
        }

        private void newGame_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            newGame.Visible = false;
            quit.Visible = false;
            Focus();
        }

        private void resume_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            resume.Visible = false;
            menu.Visible = false;
            Focus();
        }

        private void menu_Click(object sender, EventArgs e)
        {
            MenuReturn();

        }

        private void quit_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    }
}