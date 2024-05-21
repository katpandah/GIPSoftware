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
        public static string connectionString = $"server=127.0.0.1;userid=root;password=kolva;database=db_leerlingen";
        MySqlConnection connection = new MySqlConnection(connectionString);
        string ouderid = "";
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
                if (dr["kindnaam"].ToString() == txtNaam.Text && dr["kindvoornaam"].ToString() == txtVoornaam.Text) 
                {
                    ouderid = dr["ouderid"].ToString();
                    correct = true; break; 
                }
            }
            if (correct)
            {
                tabControl1.SelectedTab = Ticket2;
            }
            lblOuderid.Text = "Ouderid: " + ouderid;
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedValue = comboBox2.SelectedItem.ToString();
            comboBox3.Items.Clear();
            switch (selectedValue)
            {
                case "1":
                    comboBox3.Items.AddRange(new String[] {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "17", "19", "21", "23", "25" }); 
                    break;
                case "2":
                    comboBox3.Items.AddRange(new String[] {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "19", "21", "23", "25", "27", "29" });
                    break;
                case "3":
                    comboBox3.Items.AddRange(new String[] {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18","19", "21", "23", "25", "27", "29","31","33" });
                    break;
                case "4":
                    comboBox3.Items.AddRange(new String[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19","20", "21", "23", "25", "27", "29", "31", "33","35","37" });
                    break;
                case "5":
                    comboBox3.Items.AddRange(new String[] { "1", "3", "5", "7", "9", "11", "13", "15", "17", "19", "21", "23", "25", "27", "29", "31", "33", "35", "37", "39" });
                    break;
                case "6":
                    comboBox3.Items.AddRange(new string[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31", "32", "33", "34" });
                    break;
                case "7":
                    comboBox3.Items.AddRange(new string[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31", "32", "33", "34", "35", "36" });
                    break;
                case "8":
                    comboBox3.Items.AddRange(new string[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31", "32", "33", "34", "35", "36", "37", "38" });
                    break;
                case "9":
                    comboBox3.Items.AddRange(new string[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31", "32", "33", "34", "35", "36" });
                    break;
                case "10":
                    comboBox3.Items.AddRange(new string[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31", "32"});
                    break;
                case "11":
                    comboBox3.Items.AddRange(new string[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "20", "41", "43", "45", "47"});
                    break;
                case "12":
                    comboBox3.Items.AddRange(new string[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19","20" });
                    break;
                case "13":
                    comboBox3.Items.AddRange(new string[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "40", "42", "44", "46" });
                    break;
                case "14":
                    comboBox3.Items.AddRange(new string[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20","21", "22", "40", "42", "44", "46" });
                    break;
                case "15":
                    comboBox3.Items.AddRange(new string[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31", "40", "42", "44", "46" });
                    break;
                case "16":
                    comboBox3.Items.AddRange(new string[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31", "32", "33", "34", "35", "36", "37", "38" });   
                    break;
                case "17":
                    comboBox3.Items.AddRange(new string[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31", "32", "33", "34", "35", "36", "37", "39" });
                    break;
                case "18":
                    comboBox3.Items.AddRange(new string[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "40", "41", "42", "43", "44", "45", "46", "47", "48", "49", "50", "51", "52", "53", "54", "55", "56", "57", "58", "59", "60" });
                    break;
                case "19":
                    comboBox3.Items.AddRange(new string[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "40", "41", "42", "43", "44", "45", "46", "47", "48", "49", "50", "51", "52", "53", "54", "55", "56", "57", "58", "59"});
                    break;
                case "20":
                    comboBox3.Items.AddRange(new string[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18","20" });
                    break;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {

            string zetelid = comboBox2.Text + "." + comboBox3.Text;
            connection.Open();
            MySqlCommand sqlCommand = new MySqlCommand("UPDATE tbltickets SET zetelid = @zetelid WHERE ouderid=@ouderid;", connection);
            sqlCommand.Parameters.AddWithValue("@zetelid", zetelid);
            sqlCommand.Parameters.AddWithValue("@ouderid", ouderid);
            sqlCommand.ExecuteNonQuery();
            connection.Close();
            tabControl1.SelectedTab = Main;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (txtAdminUser.Text == "User" && txtAdminPassw.Text == "Passw")
            {
                tabControl1.SelectedTab = AdminPanel;
            }
            else
            {
                lblWrong.Visible = true;
            }
        }

        private void Admin_Click(object sender, EventArgs e)
        {

        }
    }
}
