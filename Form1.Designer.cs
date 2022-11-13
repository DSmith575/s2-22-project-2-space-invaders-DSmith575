namespace Space_Invaders
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.newGame = new System.Windows.Forms.Button();
            this.quit = new System.Windows.Forms.Button();
            this.resume = new System.Windows.Forms.Button();
            this.menu = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // newGame
            // 
            this.newGame.Location = new System.Drawing.Point(12, 92);
            this.newGame.Name = "newGame";
            this.newGame.Size = new System.Drawing.Size(234, 64);
            this.newGame.TabIndex = 0;
            this.newGame.Text = "New Game";
            this.newGame.UseVisualStyleBackColor = true;
            this.newGame.Click += new System.EventHandler(this.newGame_Click);
            // 
            // quit
            // 
            this.quit.Location = new System.Drawing.Point(12, 422);
            this.quit.Name = "quit";
            this.quit.Size = new System.Drawing.Size(234, 64);
            this.quit.TabIndex = 1;
            this.quit.Text = "Quit Game";
            this.quit.UseVisualStyleBackColor = true;
            this.quit.Click += new System.EventHandler(this.quit_Click);
            // 
            // resume
            // 
            this.resume.Location = new System.Drawing.Point(12, 199);
            this.resume.Name = "resume";
            this.resume.Size = new System.Drawing.Size(234, 64);
            this.resume.TabIndex = 2;
            this.resume.Text = "Resume";
            this.resume.UseVisualStyleBackColor = true;
            this.resume.Click += new System.EventHandler(this.resume_Click);
            // 
            // menu
            // 
            this.menu.Location = new System.Drawing.Point(12, 312);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(234, 64);
            this.menu.TabIndex = 3;
            this.menu.Text = "Main Menu";
            this.menu.UseVisualStyleBackColor = true;
            this.menu.Click += new System.EventHandler(this.menu_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "(P)AUSE";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(319, 613);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menu);
            this.Controls.Add(this.resume);
            this.Controls.Add(this.quit);
            this.Controls.Add(this.newGame);
            this.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private Button newGame;
        private Button quit;
        private Button resume;
        private Button menu;
        private Label label1;
    }
}