using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Minesweeper_Project
{
    public partial class Form1 : Form
    {
        Button[,] bns = new Button[4,4];
        Game G = new Game();

        public Form1()
        {
            InitializeComponent();
            CreateButtons();
            G.ClearGame();
            G.NewGame();
            ResetButtons();
        }

        private void CreateButtons()
        {
            for (int i = 1; i <= 4; i++)
            {
                for (int j = 1; j <= 4; j++)
                {
                    Button button = new Button();
                    button.Size = new Size(30, 30);
                    button.Location = new Point(i * 30, j * 30);
                    button.Visible = true;
                    button.Name = "bn" + (i-1).ToString() + (j-1).ToString();
                    button.Click += new EventHandler(ButtonClick);
                    this.Controls.Add(button);
                    bns[i - 1, j - 1] = button;
                }
            }
        }

        private void ResetButtons()
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    bns[i, j].Enabled = true;
                    bns[i, j].Text = "";
                }
            }
        }

        private void GameOver()
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    bns[i,j].Enabled = false;
                    bns[i, j].Text = G.Check(i,j);
                }
            }
            MessageBox.Show("Game Over!", "Game Over", MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
        }

        private void Win()
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    bns[i, j].Enabled = false;
                    bns[i, j].Text = G.Check(i, j);
                }
            }
            MessageBox.Show("Ön nyert!","Ön nyert",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            G.ClearGame();
            G.NewGame();
            ResetButtons();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ButtonClick(object sender, EventArgs e)
        {
            ((Button)sender).Enabled = false;
            //MessageBox.Show((((Button)sender).Name).Substring((((Button)sender).Name).Length - 2, 1));
            //MessageBox.Show((((Button)sender).Name).Substring((((Button)sender).Name).Length - 1, 1));
            // G.Check(int.Parse((((Button)sender).Name).Substring((((Button)sender).Name).Length - 2, 1)), int.Parse((((Button)sender).Name).Substring((((Button)sender).Name).Length - 1, 1)))
            if (G.Check(int.Parse((((Button)sender).Name).Substring((((Button)sender).Name).Length - 2, 1)), int.Parse((((Button)sender).Name).Substring((((Button)sender).Name).Length - 1, 1))) == "*")
            {
                ((Button)sender).Text = "*";
                GameOver();
            }
            else
            {
                ((Button)sender).Text = G.Check(int.Parse((((Button)sender).Name).Substring((((Button)sender).Name).Length - 2, 1)), int.Parse((((Button)sender).Name).Substring((((Button)sender).Name).Length - 1, 1)));
                if (G.Click())
                {
                    Win();
                }
            }
        }


    }
}
