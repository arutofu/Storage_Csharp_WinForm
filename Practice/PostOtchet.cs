using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Main
{
    public partial class PostOtchet : Form
    {
        public PostOtchet()
        {
            InitializeComponent();
        }

        private void tovarBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Owner.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }
    }
}
