namespace Space_Invaders
{
    public partial class Form1 : Form
    {

        private Graphics graphics;
        private Graphics bufferGraphics;
        private Image bufferImage;
        private Point boundries;
        private Controller controller;

        public Form1()
        {
            InitializeComponent();
            Width = ClientSize.Width;
            Height = ClientSize.Height;
            boundries = new Point(Width, Height);

            graphics = CreateGraphics();
            bufferImage = new Bitmap(ClientSize.Width, ClientSize.Height);
            bufferGraphics = Graphics.FromImage(bufferImage);
            timer1.Enabled = true;
            DoubleBuffered = true;
            controller = new Controller(boundries, graphics);
            controller.boundries = ClientSize;


        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            graphics.FillRectangle(Brushes.Black, 0, 0, Width, Height);
            controller.GameRun();

        }
    }
}