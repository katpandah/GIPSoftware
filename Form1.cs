using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace tempo
{
    public partial class Form1 : Form
    {
        string connectionString = $"server=127.0.0.1;userid=root;password=kolva;database=db_leerlingen";
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
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            MySqlCommand cmd = new MySqlCommand(SQLScripts.leerlingen, connection);
            DataSet DS = new DataSet();
            MySqlDataAdapter adapter = new MySqlDataAdapter(SQLScripts.leerlingen, connection);
            adapter.Fill(DS, "table");
            DataTable newTable = DS.Tables["table"];
            connection.Close();
            bool correct = false;
            foreach (DataRow dr in newTable.Rows)
            {
                if (dr["kindnaam"].ToString() == txtNaam.Text && dr["kindvoornaam"].ToString() == txtVoornaam.Text) { correct = true; break; }
            }
            if (correct)
            {
                tabControl1.SelectedTab = Ticket2;
            }
        }
    }
}
