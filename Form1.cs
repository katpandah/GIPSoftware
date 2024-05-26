using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using MailKit.Net.Smtp;
using MimeKit;
using System.Net.Mail;
using System.Net;
using MySqlX.XDevAPI;
using MailKit.Security;
using Org.BouncyCastle.Crypto.Macs;

namespace tempo
{

    public partial class Form1 : Form
    { 
        public static string connectionString = $"server=127.0.0.1;userid=root;password=kolva;database=db_leerlingen";
        MySqlConnection connection = new MySqlConnection(connectionString);
        string ouderid = "1";
        public Form1()
        {
            InitializeComponent();
        }
        #region Main
        private void button1_Click(object sender, EventArgs e)
        {
            TabControl1.SelectedTab = Choose; //Verandert naar Choose tab
        }
        #endregion
        #region Choose
        private void btnVerder_Click(object sender, EventArgs e)
        {
            TabControl1.SelectedTab = Ticket; //Verandert naar Ticket tab
        }

        private void button3_Click(object sender, EventArgs e)
        {
            TabControl1.SelectedTab = Admin;
        }
        #endregion
        #region Help pagina
        private void button2_Click(object sender, EventArgs e)
        {
            TabControl1.SelectedTab = help;
        }
        private void button4_Click(object sender, EventArgs e)
        {
            TabControl1.SelectedTab = Choose;
        }
        #endregion
        #region Ticket
        private void button6_Click(object sender, EventArgs e)
        {
            connection.Open();
            MySqlCommand cmd = new MySqlCommand(SQLScripts.leerlingen, connection);
            DataSet DS = new DataSet();
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            adapter.Fill(DS, "tblleerlingen");
            DataTable newTable = DS.Tables["tblleerlingen"];
            connection.Close();
            bool correct = false;
            foreach (DataRow dr in newTable.Rows)
            {
                if (dr["kindnaam"].ToString() == txtNaam.Text && dr["kindvoornaam"].ToString() == txtVoornaam.Text && dr["kindid"].ToString() == txtKindid.Text) 
                {
                    correct = true;
                }
            }
            if (!correct)
            {
                Environment.Exit(0);
            }
            string kindid = txtKindid.Text;
            connection.Open();
            cmd = new MySqlCommand(SQLScripts.ouder, connection);
            cmd.Parameters.AddWithValue("@kindid", kindid);
            DS = new DataSet();
            adapter = new MySqlDataAdapter(cmd);
            adapter.Fill(DS, "tblouders");
            newTable = DS.Tables["tblouders"];
            connection.Close();
            foreach (DataRow dr in newTable.Rows)
            {
                if (dr["kindid"].ToString() == kindid)
                {
                    ouderid = dr["ouderid"].ToString();
                }
            }
            if (correct)
            {
                TabControl1.SelectedTab = Ticket2;
            }
            lblOuderid.Text = "Ouderid: " + ouderid;
        }
        #endregion
        /*ZETEL WERKT NOG NIET, SKIP*/
        #region Zetel
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedValue = comboBox2.SelectedItem.ToString();
            comboBox3.Items.Clear();
            switch (selectedValue)              //Alle mogelijke opties voor stoelen T-T
            {
                case "1":
                    comboBox3.Items.AddRange(new String[] {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "17", "19", "21", "23", "25" });
                    comboBox4.Items.AddRange(new String[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "17", "19", "21", "23", "25" });
                    comboBox5.Items.AddRange(new String[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "17", "19", "21", "23", "25" });
                    comboBox6.Items.AddRange(new String[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "17", "19", "21", "23", "25" });
                    break;
                case "2":
                    comboBox3.Items.AddRange(new String[] {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "19", "21", "23", "25", "27", "29" });
                    comboBox4.Items.AddRange(new String[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "19", "21", "23", "25", "27", "29" });
                    comboBox5.Items.AddRange(new String[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "19", "21", "23", "25", "27", "29" });
                    comboBox6.Items.AddRange(new String[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "19", "21", "23", "25", "27", "29" });
                    break;
                case "3":
                    comboBox3.Items.AddRange(new String[] {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18","19", "21", "23", "25", "27", "29","31","33" });
                    comboBox4.Items.AddRange(new String[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "21", "23", "25", "27", "29", "31", "33" });
                    comboBox5.Items.AddRange(new String[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "21", "23", "25", "27", "29", "31", "33" });
                    comboBox6.Items.AddRange(new String[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "21", "23", "25", "27", "29", "31", "33" });
                    break;
                case "4":
                    comboBox3.Items.AddRange(new String[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19","20", "21", "23", "25", "27", "29", "31", "33","35","37" });
                    comboBox4.Items.AddRange(new String[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "23", "25", "27", "29", "31", "33", "35", "37" });
                    comboBox5.Items.AddRange(new String[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "23", "25", "27", "29", "31", "33", "35", "37" });
                    comboBox6.Items.AddRange(new String[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "23", "25", "27", "29", "31", "33", "35", "37" });
                    break;
                case "5":
                    comboBox3.Items.AddRange(new String[] { "1", "3", "5", "7", "9", "11", "13", "15", "17", "19", "21", "23", "25", "27", "29", "31", "33", "35", "37", "39" });
                    comboBox4.Items.AddRange(new String[] { "1", "3", "5", "7", "9", "11", "13", "15", "17", "19", "21", "23", "25", "27", "29", "31", "33", "35", "37", "39" });
                    comboBox5.Items.AddRange(new String[] { "1", "3", "5", "7", "9", "11", "13", "15", "17", "19", "21", "23", "25", "27", "29", "31", "33", "35", "37", "39" });
                    comboBox6.Items.AddRange(new String[] { "1", "3", "5", "7", "9", "11", "13", "15", "17", "19", "21", "23", "25", "27", "29", "31", "33", "35", "37", "39" });
                    break;
                case "6":
                    comboBox3.Items.AddRange(new string[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31", "32", "33", "34" });
                    comboBox4.Items.AddRange(new string[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31", "32", "33", "34" });
                    comboBox5.Items.AddRange(new string[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31", "32", "33", "34" });
                    comboBox6.Items.AddRange(new string[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31", "32", "33", "34" });
                    break;
                case "7":
                    comboBox3.Items.AddRange(new string[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31", "32", "33", "34", "35", "36" });
                    comboBox4.Items.AddRange(new string[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31", "32", "33", "34", "35", "36" });
                    comboBox5.Items.AddRange(new string[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31", "32", "33", "34", "35", "36" });
                    comboBox6.Items.AddRange(new string[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31", "32", "33", "34", "35", "36" });
                    break;
                case "8":
                    comboBox3.Items.AddRange(new string[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31", "32", "33", "34", "35", "36", "37", "38" });
                    comboBox4.Items.AddRange(new string[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31", "32", "33", "34", "35", "36", "37", "38" });
                    comboBox5.Items.AddRange(new string[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31", "32", "33", "34", "35", "36", "37", "38" });
                    comboBox6.Items.AddRange(new string[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31", "32", "33", "34", "35", "36", "37", "38" });
                    break;
                case "9":
                    comboBox3.Items.AddRange(new string[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31", "32", "33", "34", "35", "36" });
                    comboBox4.Items.AddRange(new string[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31", "32", "33", "34", "35", "36" });
                    comboBox5.Items.AddRange(new string[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31", "32", "33", "34", "35", "36" });
                    comboBox6.Items.AddRange(new string[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31", "32", "33", "34", "35", "36" });
                    break;;
                case "10":
                    comboBox3.Items.AddRange(new string[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31", "32"});
                    comboBox4.Items.AddRange(new string[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31", "32" });
                    comboBox5.Items.AddRange(new string[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31", "32" });
                    comboBox6.Items.AddRange(new string[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31", "32" });
                    break;
                case "11":
                    comboBox3.Items.AddRange(new string[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "20", "41", "43", "45", "47"});
                    comboBox4.Items.AddRange(new string[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "20", "41", "43", "45", "47" });
                    comboBox5.Items.AddRange(new string[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "20", "41", "43", "45", "47" });
                    comboBox6.Items.AddRange(new string[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "20", "41", "43", "45", "47" });
                    break;
                case "12":
                    comboBox3.Items.AddRange(new string[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19","20" });
                    comboBox4.Items.AddRange(new string[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20" });
                    comboBox5.Items.AddRange(new string[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20" });
                    comboBox6.Items.AddRange(new string[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20" });
                    break;
                case "13":
                    comboBox3.Items.AddRange(new string[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "40", "42", "44", "46" });
                    comboBox4.Items.AddRange(new string[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "40", "42", "44", "46" });
                    comboBox5.Items.AddRange(new string[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "40", "42", "44", "46" });
                    comboBox6.Items.AddRange(new string[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "40", "42", "44", "46" });
                    break;
                case "14":
                    comboBox3.Items.AddRange(new string[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20","21", "22", "40", "42", "44", "46" });
                    comboBox4.Items.AddRange(new string[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "40", "42", "44", "46" });
                    comboBox5.Items.AddRange(new string[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "40", "42", "44", "46" });
                    comboBox6.Items.AddRange(new string[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "40", "42", "44", "46" });
                    break;
                case "15":
                    comboBox3.Items.AddRange(new string[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31", "40", "42", "44", "46" });
                    break;
                case "16":
                    comboBox3.Items.AddRange(new string[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31", "32", "33", "34", "35", "36", "37", "38" });
                    comboBox4.Items.AddRange(new string[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31", "32", "33", "34", "35", "36", "37", "38" });
                    comboBox5.Items.AddRange(new string[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31", "32", "33", "34", "35", "36", "37", "38" });
                    comboBox6.Items.AddRange(new string[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31", "32", "33", "34", "35", "36", "37", "38" });
                    break;
                case "17":
                    comboBox3.Items.AddRange(new string[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31", "32", "33", "34", "35", "36", "37", "39" });
                    comboBox4.Items.AddRange(new string[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31", "32", "33", "34", "35", "36", "37", "39" });
                    comboBox5.Items.AddRange(new string[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31", "32", "33", "34", "35", "36", "37", "39" });
                    comboBox6.Items.AddRange(new string[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31", "32", "33", "34", "35", "36", "37", "39" });
                    break;
                case "18":
                    comboBox3.Items.AddRange(new string[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "40", "41", "42", "43", "44", "45", "46", "47", "48", "49", "50", "51", "52", "53", "54", "55", "56", "57", "58", "59", "60" });
                    comboBox4.Items.AddRange(new string[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "40", "41", "42", "43", "44", "45", "46", "47", "48", "49", "50", "51", "52", "53", "54", "55", "56", "57", "58", "59", "60" });
                    comboBox5.Items.AddRange(new string[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "40", "41", "42", "43", "44", "45", "46", "47", "48", "49", "50", "51", "52", "53", "54", "55", "56", "57", "58", "59", "60" });
                    comboBox6.Items.AddRange(new string[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "40", "41", "42", "43", "44", "45", "46", "47", "48", "49", "50", "51", "52", "53", "54", "55", "56", "57", "58", "59", "60" });
                    break;
                case "19":
                    comboBox3.Items.AddRange(new string[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "40", "41", "42", "43", "44", "45", "46", "47", "48", "49", "50", "51", "52", "53", "54", "55", "56", "57", "58", "59"});
                    comboBox4.Items.AddRange(new string[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "40", "41", "42", "43", "44", "45", "46", "47", "48", "49", "50", "51", "52", "53", "54", "55", "56", "57", "58", "59" });
                    comboBox5.Items.AddRange(new string[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "40", "41", "42", "43", "44", "45", "46", "47", "48", "49", "50", "51", "52", "53", "54", "55", "56", "57", "58", "59" });
                    comboBox6.Items.AddRange(new string[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "40", "41", "42", "43", "44", "45", "46", "47", "48", "49", "50", "51", "52", "53", "54", "55", "56", "57", "58", "59" });
                    break;
                case "20":
                    comboBox3.Items.AddRange(new string[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18","20" });
                    comboBox4.Items.AddRange(new string[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "20" });
                    comboBox5.Items.AddRange(new string[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "20" });
                    comboBox6.Items.AddRange(new string[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "20" });
                    break;
            }
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "1")
            {
                comboBox3.Visible = true;
                comboBox4.Visible = false;
                comboBox5.Visible = false;
                comboBox6.Visible = false;
            }
            if (comboBox1.Text == "2")
            {
                comboBox3.Visible = true;
                comboBox4.Visible = true;
                comboBox5.Visible = false;
                comboBox6.Visible = false;
            }
            if (comboBox1.Text == "3")
            {
                comboBox3.Visible = true;
                comboBox4.Visible = true;
                comboBox5.Visible = true;
                comboBox6.Visible = false;
            }
            if (comboBox1.Text == "4")
            {
                comboBox3.Visible = true;
                comboBox4.Visible = true;
                comboBox5.Visible = true;
                comboBox6.Visible = true;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {

            string zetelid = comboBox2.Text + "." + comboBox3.Text;
            if (comboBox2.Text == "2")
            {
                string zetelid2 = comboBox2.Text + "." + comboBox4.Text;
                connection.Open();
                MySqlCommand info = new MySqlCommand("SELECT ouderid FROM tbltickets WHERE zetelid='"+zetelid + "'", connection);
                DataSet DS = new DataSet();
                MySqlDataAdapter adapter = new MySqlDataAdapter(info);
                adapter.Fill(DS, "tbltickets");
                DataTable newTable = DS.Tables["tbltickets"];
                foreach (DataRow dr in newTable.Rows)
                {
                    if (dr["ouderid"].ToString() == null)
                    {
                        MySqlCommand sqlCommand = new MySqlCommand("UPDATE tbltickets SET ouderid = " + ouderid + " WHERE zetelid='" + zetelid + "'", connection);
                        sqlCommand.ExecuteNonQuery();
                        MySqlCommand sqlCommand2 = new MySqlCommand("UPDATE tbltickets SET ouderid = " + ouderid + " WHERE zetelid='" + zetelid2 + "'", connection);
                        sqlCommand2.ExecuteNonQuery();
                        connection.Close();
                        TabControl1.SelectedTab = Payment;
                    }
                    else
                    {
                        lblFout.Visible = true;
                        connection.Close();
                        comboBox1.Text = string.Empty;
                        comboBox2.Text = string.Empty;
                        comboBox3.Text = string.Empty;
                        comboBox4.Text = string.Empty;
                        TabControl1.SelectedTab = Ticket2;
                    }
                }
            }
            if (comboBox2.Text == "3")
            {
                string zetelid2 = comboBox2.Text + "." + comboBox4.Text;
                string zetelid3 = comboBox2.Text + "." + comboBox5.Text;
                connection.Open();
                MySqlCommand info = new MySqlCommand("SELECT ouderid FROM tbltickets WHERE zetelid='" + zetelid + "'", connection);
                DataSet DS = new DataSet();
                MySqlDataAdapter adapter = new MySqlDataAdapter(info);
                adapter.Fill(DS, "tbltickets");
                DataTable newTable = DS.Tables["tbltickets"];
                foreach (DataRow dr in newTable.Rows)
                {
                    if (dr["ouderid"].ToString() == null)
                    {
                        MySqlCommand sqlCommand = new MySqlCommand("UPDATE tbltickets SET ouderid = " + ouderid + " WHERE zetelid='" + zetelid + "'", connection);
                        sqlCommand.ExecuteNonQuery();
                        MySqlCommand sqlCommand2 = new MySqlCommand("UPDATE tbltickets SET ouderid = " + ouderid + " WHERE zetelid='" + zetelid2 + "'", connection);
                        sqlCommand2.ExecuteNonQuery();
                        MySqlCommand sqlCommand3 = new MySqlCommand("UPDATE tbltickets SET ouderid = " + ouderid + " WHERE zetelid='" + zetelid3 + "'", connection);
                        sqlCommand3.ExecuteNonQuery();
                        connection.Close();
                        TabControl1.SelectedTab = Payment;
                    }
                    else
                    {
                        lblFout.Visible = true;
                        connection.Close();
                        comboBox1.Text = string.Empty;
                        comboBox2.Text = string.Empty;
                        comboBox3.Text = string.Empty;
                        comboBox4.Text = string.Empty;
                        comboBox5.Text = string.Empty;
                        TabControl1.SelectedTab = Ticket2;
                    }
                }
            }
            if (comboBox2.Text == "4")
            {
                string zetelid2 = comboBox2.Text + "." + comboBox4.Text;
                string zetelid3 = comboBox2.Text + "." + comboBox5.Text;
                string zetelid4 = comboBox2.Text + "." + comboBox6.Text;
                connection.Open();
                MySqlCommand info = new MySqlCommand("SELECT ouderid FROM tbltickets WHERE zetelid='" + zetelid +"'", connection);
                DataSet DS = new DataSet();
                MySqlDataAdapter adapter = new MySqlDataAdapter(info);
                adapter.Fill(DS, "tbltickets");
                DataTable newTable = DS.Tables["tbltickets"];
                foreach (DataRow dr in newTable.Rows)
                {
                    if (dr["ouderid"].ToString() == null)
                    {
                        MySqlCommand sqlCommand = new MySqlCommand("UPDATE tbltickets SET ouderid = " + ouderid + " WHERE zetelid='" + zetelid + "'", connection);
                        sqlCommand.ExecuteNonQuery();
                        MySqlCommand sqlCommand2 = new MySqlCommand("UPDATE tbltickets SET ouderid = " + ouderid + " WHERE zetelid='" + zetelid2 + "'", connection);
                        sqlCommand2.ExecuteNonQuery();
                        MySqlCommand sqlCommand3 = new MySqlCommand("UPDATE tbltickets SET ouderid = " + ouderid + " WHERE zetelid='" + zetelid3 + "'", connection);
                        sqlCommand3.ExecuteNonQuery();
                        MySqlCommand sqlCommand4 = new MySqlCommand("UPDATE tbltickets SET ouderid = " + ouderid + " WHERE zetelid='" + zetelid4 + "'", connection);
                        sqlCommand4.ExecuteNonQuery();
                        connection.Close();
                        TabControl1.SelectedTab = Payment;
                    }
                    else
                    {
                        lblFout.Visible = true;
                        connection.Close();
                        comboBox1.Text = string.Empty;
                        comboBox2.Text = string.Empty;
                        comboBox3.Text = string.Empty;
                        comboBox4.Text = string.Empty;
                        comboBox5.Text = string.Empty;
                        comboBox6.Text = string.Empty;
                        TabControl1.SelectedTab = Ticket2;
                    }
                }
            }
        }
        #endregion
        #region AdminLogIn
        private void button5_Click(object sender, EventArgs e)              //Wanneer login geclickt wordt:
        {
            if (txtAdminUser.Text == "User" && txtAdminPassw.Text == "Passw") //Checkt gebruikersnaam en wachtwoord
            {
                TabControl1.SelectedTab = AdminPanel;                       //Verandert tab als het juist is
            }
            else
            {
                lblWrong.Visible = true;                                    //Bij een fout wachtwoord of gebruikersnaam, geeft het een foutmelding.
            }
        }
        #endregion
        #region AdminPanel
        private void button8_Click(object sender, EventArgs e)
        {

            string keuze = cmbKeuze.Text;                                   //Keuze uit combobox opslaan in variabele en dan gebruiken in switch om te zien welke waarde is gekozen.
            switch (keuze)
            {
                case "select":                                              //Wanneer het select is
                    string select = "SELECT * FROM " + txtTabel.Text;
                    if (txtWaarden.Text == "") //Zonder where statement
                    {
                        MySqlCommand normalSelect = new MySqlCommand(select, connection);
                        connection.Open();
                        MySqlDataAdapter adapter = new MySqlDataAdapter(normalSelect);
                        DataSet ds = new DataSet();
                        adapter.Fill(ds, txtTabel.Text);
                        dgvInfo.DataSource = ds.Tables[txtTabel.Text];
                        connection.Close();
                    }
                    else                      //Met where statement
                    {
                        string where = txtWaarden.Text.Substring(0, txtWaarden.Text.IndexOf('='));                                                                  //Kolomnaam
                        string whereat = txtWaarden.Text.Substring(txtWaarden.Text.IndexOf('=') + 1, txtWaarden.Text.Length - 1 - txtWaarden.Text.IndexOf('='));    //Kolom parameter
                        string select1 = "SELECT * FROM " + txtTabel.Text;
                        MySqlCommand whereSelect = new MySqlCommand(select1 + " WHERE " + where + "=" +whereat, connection);
                        connection.Open();
                        MySqlDataAdapter adapter0 = new MySqlDataAdapter(whereSelect);
                        adapter0.SelectCommand.Parameters.AddWithValue(where, whereat);
                        DataSet ds0 = new DataSet();
                        adapter0.Fill(ds0, txtTabel.Text);
                        dgvInfo.DataSource = ds0.Tables[txtTabel.Text];
                        connection.Close();
                    }
                    break;
                case "update":
                    string where2 = txtWaarden.Text.Substring(0, txtWaarden.Text.IndexOf('='));                                                                     //kolom
                    string whereat2 = txtWaarden.Text.Substring(txtWaarden.Text.IndexOf('=') + 1, txtWaarden.Text.Length - 1 - txtWaarden.Text.IndexOf('='));       //kolom parameter
                    MySqlCommand update = new MySqlCommand("UPDATE " + txtTabel.Text + " SET " + txtSET.Text + " WHERE " + where2 + "=" + whereat2, connection);
                    connection.Open();
                    MySqlDataAdapter adapter1 = new MySqlDataAdapter(update);
                    adapter1.SelectCommand.Parameters.AddWithValue(where2, whereat2);
                    update.ExecuteNonQuery();
                    System.Windows.Forms.MessageBox.Show("Actie is uitgevoerd");                                                                                    //Confirmatie van de update functie
                    connection.Close();
                    break;
                case "delete":
                    string where1 = txtWaarden.Text.Substring(0, txtWaarden.Text.IndexOf('='));                                                                     //kolom
                    string whereat1 = txtWaarden.Text.Substring(txtWaarden.Text.IndexOf('=') + 1, txtWaarden.Text.Length - 1 - txtWaarden.Text.IndexOf('='));       //kolom parameter
                    MySqlCommand delete = new MySqlCommand("DELETE FROM " + txtTabel.Text + " WHERE " + where1 + "=" + whereat1, connection);
                    connection.Open();
                    MySqlDataAdapter adapter2 = new MySqlDataAdapter(delete);
                    adapter2.SelectCommand.Parameters.AddWithValue(where1, whereat1);
                    delete.ExecuteNonQuery();
                    System.Windows.Forms.MessageBox.Show("Actie is uitgevoerd");                                                                                    //Confirmatie van de delete functie
                    connection.Close();
                    break;
                case "insert":
                    MySqlCommand insert = new MySqlCommand("INSERT INTO " + txtTabel.Text + " VALUES " + txtWaarden.Text, connection);
                    connection.Open();
                    insert.ExecuteNonQuery();
                    System.Windows.Forms.MessageBox.Show("Actie is uitgevoerd");                                                                                    //Confirmatie van de insert functie
                    connection.Close();
                    break;
            }

        }

        private void button10_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.MessageBox.Show("Je kan kiezen uit: tblKlas, tblLeerlingen, tblOuders en tblTickets" + Environment.NewLine + "Bij insert functie bv: tblleerlingen (kindid,kindvoornaam)");                //Info als ze de vraagteken knop klikken
        }

        private void button9_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.MessageBox.Show("Bij select en delete bv: kindid='23587'" + Environment.NewLine + "Bij update bv:kindid='23587'" + Environment.NewLine + "Bij insert bv: (23587,'Jarno','De Lannoy')");    //Info als ze de vraagteken knop klikken
        }

        private void btnSET_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.MessageBox.Show("bv:kindid=1, kindnaam='Jarno'");                                                                                                                                          //Info als ze de vraagteken knop klikken
        }

        private void cmbKeuze_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbKeuze.Text == "update") //extra Set voor update functie
            {
                lblSET.Visible = true;
                txtSET.Visible = true;
                btnSET.Visible = true;
            }
            if (cmbKeuze.Text == "select")  //extra dingen weghalen wanneer het geen update is
            {
                lblSET.Visible = false;
                txtSET.Visible = false;
                btnSET.Visible = false;
            }
            if (cmbKeuze.Text == "delete")
            {
                lblSET.Visible = false;
                txtSET.Visible = false;
                btnSET.Visible = false;
            }
            if (cmbKeuze.Text == "insert")
            {
                lblSET.Visible = false;
                txtSET.Visible = false;
                btnSET.Visible = false;
            }
            //Alles leegmaken zodra ze het type veranderen
            txtTabel.Text = string.Empty;
            txtWaarden.Text = string.Empty;
        }
        #endregion
        #region Payment
        private void button11_Click(object sender, EventArgs e)
        {
            TabControl1.SelectedTab = Email;
        }
        #endregion
        #region Email
        private void button12_Click(object sender, EventArgs e)
        {
            txtemail.Visible = true;
            label22.Visible = true;
            label23.Visible = true;
            textBox1.Visible = true;
            if (txtemail.Text != "")
            {
                email();
            }
        }
        private void email()
        {
            connection.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT zetelid, ticketid FROM tbltickets WHERE ouderid=" + ouderid, connection);
            DataSet DS = new DataSet();
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            adapter.Fill(DS, "tbltickets");
            DataTable newTable = DS.Tables["tbltickets"];
            connection.Close();
            string ticketid = "";
            string zetelid = "";
            foreach (DataRow dr in newTable.Rows)
            {
                ticketid = dr["ticketid"].ToString();
                zetelid = dr["zetelid"].ToString();
            }
            connection.Close();

            System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient();
            smtp.Host = "smtp.office365.com";
            smtp.Port = 587;
            smtp.UseDefaultCredentials = false;
            smtp.EnableSsl = true;
            smtp.TargetName = "STARTTLS/smtp.office365.com";
            smtp.Credentials = new NetworkCredential { UserName = "sparkytickets@outlook.com", Password = "PasswordForSparky123" };


            MailMessage mail = new MailMessage()
            {
                To = { new MailAddress(txtemail.Text) },
                From = new MailAddress("sparkytickets@outlook.com", "Sparky Tickets"),
                Subject = "Bestelling nr. " + ticketid,
                IsBodyHtml = true,
                Body = "Bedankt " + textBox1.Text + " voor Sparky Tickets te gebruiken, Jouw ticket is besteld! Je hebt de volgende zetels gereserveerd:" + zetelid,
                BodyEncoding = System.Text.Encoding.UTF8,
                SubjectEncoding = System.Text.Encoding.UTF8
            };

            try
            {
                smtp.Send(mail);
            }
            catch (Exception ex)
            {
                lblResultEmail.Text = ex.ToString();
                lblResultEmail.ForeColor = System.Drawing.Color.Red;
            }
            TabControl1.SelectedTab = End;
        }
        #endregion
        #region End
        private void button13_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
        #endregion
        #region Useless
        private void Form1_Load(object sender, EventArgs e) { }
        private void label6_Click(object sender, EventArgs e) { }
        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e) { }
        private void Admin_Click(object sender, EventArgs e) { }
        private void label21_Click(object sender, EventArgs e) { }
        private void Ticket2_Click(object sender, EventArgs e) { }
        private void AdminPanel_Click(object sender, EventArgs e) { }
        private void label24_Click(object sender, EventArgs e) { }
        #endregion

    }
}
