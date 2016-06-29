using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MineSweeper_Project_Gyak
{
    public partial class Form1 : Form
    {
        Game G = new Game();

        public Form1()
        {
            InitializeComponent();
        }

        private Button createButton(int x, int y, int gridX, int gridY)
        {
            Button bttn = new Button();

            bttn.Text = "";
            bttn.Name = gridX.ToString() + " " + gridY.ToString();
            bttn.Size = new System.Drawing.Size(24, 24);
            bttn.Location = new System.Drawing.Point(x, y);
            //Controls.AddRange(new System.Windows.Forms.Control[] { bttn, });
            bttn.Click += new System.EventHandler(bttnOnclick);
            //bttn.MouseClick += new System.Windows.Forms.MouseEventHandler(this.bttnOnRightClick);

            return bttn;
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            G.ClearGame();
            G.NewGame();
        }
    }
}
