using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space_Invaders
{
    public class Scores
    {
        private const int MAXSCORELIST = 5;
        private const int NEWSCORE = 4; //Array position for inserting newest score to txt file

        private string[] addScore = new string[1];

        //Shifts the lineReader array to the left to make room for new highscores
        private string[] lineReader = new string[MAXSCORELIST];
        private string[] lineReaderShift = new string[MAXSCORELIST];
        private string result = " ";
        private string displayScores = " ";

        private int lineCount; //variable for n lines in txt file

        //Pulls the variables from controller class and adds them to an array
        public void StoreScores(int winner)
        {
            CreateScoreBoard();
            if (winner == 0)
            {
                result = "Player Win";
            }
            else
            {
                result = "Computer Win";
            }
            
            addScore[0] = $"{result}";
            SaveScores();
            LoadScoreToMessageBoxHighScores();

        }

        //Creates on startup if no file exists
        public void CreateScoreBoard()
        {
            StreamWriter sw = new StreamWriter(@"../../HighScores.txt", true);
            sw.Close();
        }

        //Writes from array to text file.
        public void SaveScores()
        {
            //Checks how many lines there are in txt file and stores in variable
            lineCount = File.ReadAllLines(@"../../HighScores.txt").Count();

            if (lineCount < MAXSCORELIST) //If less than 5 lines, appends file to insert new value(score)
            {
                StreamWriter sw = new StreamWriter(@"../../HighScores.txt", true);
                sw.WriteLine($"{addScore[0]}");
                sw.Close();
            }

            if (lineCount >= MAXSCORELIST) //If there are more than 5 lines of text, sorts the arrays into a new array shifted left (remove first line)
            {
                lineReader = File.ReadAllLines(@"../../HighScores.txt");

                for (int i = 1; i < lineReader.Length; i++)
                {
                    lineReaderShift[i - 1] = lineReader[i];
                }
                //Adds the latest score to the last slot of the array
                lineReaderShift[NEWSCORE] = addScore[0];

                StreamWriter sw = new StreamWriter(@"../../HighScores.txt");
                {
                    for (int i = 0; i < lineReaderShift.Length; i++)
                    {
                        sw.WriteLine(lineReaderShift[i]);
                    }
                }
                sw.Close();
            }
        }

        public void LoadScoreToMessageBoxHighScores()
        {
            if (lineCount < MAXSCORELIST)
            {
                lineReader = File.ReadAllLines(@"../../HighScores.txt");

                displayScores = string.Join(Environment.NewLine, lineReader);
                string scoreBoard = "ScoreBoard";
                MessageBox.Show(displayScores, scoreBoard);
            }
            else if (lineCount >= MAXSCORELIST)
            {
                displayScores = string.Join(Environment.NewLine, lineReaderShift);
                string scoreBoard = "ScoreBoard";
                MessageBox.Show(displayScores, scoreBoard);
            }


        }
    }
}