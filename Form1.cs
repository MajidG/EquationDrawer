using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            equationDrawer1.Draw(x => x*x);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            equationDrawer1.Draw(PostfixTree.Compile(textBox1.Text));
        }
    }
}
