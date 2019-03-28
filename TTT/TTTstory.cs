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
    public partial class TTTstory : Form
    {
        public TTTstory()
        {
            InitializeComponent();
        }

        private void btnWeiter_story_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
