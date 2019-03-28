using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TTT
{
    public partial class TTTstart : Form
    {
        public bool returnIsSingleplayer { get; set; } //{get; set;} damit die Variable gelesen werden kann
        public bool returnStory { get; set; } //{get; set;} damit die Variable gelesen werden kann
        public bool returnExitGame { get; set; } //{get; set;} damit die Variable gelesen werden kann


        public TTTstart()
        {
            InitializeComponent();
        }
        private void TTTstart_Load(object sender, EventArgs e)
        {
            this.returnStory = false; //Standardmäßig ist der Storymodus ausgeschaltet
            this.returnIsSingleplayer = true;
            this.returnExitGame = false;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (rdoSingleplayer.Checked) //Die entsprechenden Werte werden in die Variablen eingetragen
            {
                this.returnIsSingleplayer = true;

                if (chkStorymodus.Checked)
                    this.returnStory = true;
                else
                    this.returnStory = false;
            }
            else
            {
                this.returnIsSingleplayer = false;
                this.returnStory = false;
            }
            this.Close();
        }

        private void überToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var TTTcredits = new TTTcredits())
            {
                TTTcredits.ShowDialog();
            }
        }

        private void rdoMultiplayer_CheckedChanged(object sender, EventArgs e)
        {
            chkStorymodus.Enabled = false;
            chkStorymodus.Checked = false;
        }

        private void rdoSingleplayer_CheckedChanged(object sender, EventArgs e)
        {
            chkStorymodus.Enabled = true;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.returnExitGame = true;
            this.Close();
        }
    }
}
