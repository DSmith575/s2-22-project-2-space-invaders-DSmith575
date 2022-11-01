﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space_Invaders
{
    public class Controller
    {
        private Bitmap playShip;
        private Bitmap alienS;
        private Random rand;
        private Player player;
        private AlienShip alien;

        private int boundryWidth;
        private int boundryHeight;


        public Controller(Point boundries, Graphics graphics, Random rand)
        {
            SetVariables(boundries);
            player = new Player(playShip, graphics, true, new Point(boundryHeight/2, boundryWidth/2), playShip.Width, playShip.Height);
            alien = new AlienShip(alienS, graphics, true, new Point(0, 0+alienS.Height), alienS.Width, alienS.Height);
        }


        //Main method that runs on every timer tick
        //Draws player
        //
        public void GameRun()
        {
            player.DrawPlayer();
            alien.DrawAlien();
        }

        //Method to set up variables for game control
        public void SetVariables(Point boundries)
        {
            rand = new Random();
            playShip = Properties.Resources.Player;
            alienS = Properties.Resources.EnemyShip;
            boundryWidth = boundries.X; //Sets player X position to the value of boundries
            boundryHeight = boundries.Y;
        }

        //Method to move the player left and right
        public void PlayerMovement(EDirection direction)
        {
            player.Direction = direction;
            player.Move();
        }



        //Gets and sets X&Y size of screen
        public Point boundries
        {
            get;
            set;
        }

    }
}