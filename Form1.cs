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
            timer1.Enabled = true;
            DoubleBuffered = true;
            controller = new Controller(boundries, graphics, rand);


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

                default:
                    break;
            }
        }
    }
}