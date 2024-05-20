using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tempo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = Choose;
        }

        private void btnVerder_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = Ticket;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = Admin;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = help;
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = Choose;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = Ticket2;
        }
    }
}
