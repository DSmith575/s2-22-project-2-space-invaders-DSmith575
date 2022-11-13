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
            Width = Screen.PrimaryScreen.Bounds.Width;
            Height = Screen.PrimaryScreen.Bounds.Height;
            boundries = new Point(Width, Height);
            graphics = CreateGraphics();
            bufferImage = new Bitmap(Width, Height);
            bufferGraphics = Graphics.FromImage(bufferImage);
            timer1.Enabled = false;
            DoubleBuffered = true;
            rand = new Random();
            controller = new Controller(boundries, graphics, rand, timer1);

            resume.Visible = false;
            menu.Visible = false;

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