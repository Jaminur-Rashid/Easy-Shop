using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace EasyShop
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            // this.ControlBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
        }
        public static string loggedIn;
        public static string loggedIn1;
        public static string loggedUserName="";
        public static string loggedInUserType;

        private void button1_Click(object sender, EventArgs e)
        {
            bool flag = false;
            if ((userTxt.Text == "") || (PassTxt.Text == "") || (comboTxt.SelectedItem.ToString() == ""))//check wheather data field is empty or not
            {
                MessageBox.Show("Please Insert Your Account Information To Login");
            }
            else
            {
                SqlConnection con = new SqlConnection("Data Source=DESKTOP-AGPPMFD\\JAMINURSQLSERVER;Initial Catalog=SystemDatabase;Integrated Security=True");
                //SqlConnection con = new SqlConnection("Data Source=JAMINUR\\JAMINURSQL;Initial Catalog=MyDbse;Integrated Security=True");
                SqlCommand cmd = new SqlCommand("select * from UserInfo where username='" + userTxt.Text + "' and password='" + PassTxt.Text + "' and usertype='" + comboTxt.SelectedItem.ToString() + "'", con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                try
                {
                    con.Open();
                    // MessageBox.Show("se");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                // MessageBox.Show("have data");
                if ((userTxt.Text == "") || (PassTxt.Text == "") || (comboTxt.SelectedItem.ToString() == ""))
                {
                    MessageBox.Show("Please Insert Your Account Information To Login");
                }
                if (dt.Rows.Count > 0)
                {
                    // MessageBox.Show("ddddd");
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if ((userTxt.Text == dt.Rows[i]["username"].ToString()) && (PassTxt.Text == dt.Rows[i]["password"].ToString()) && (comboTxt.SelectedItem.ToString() == dt.Rows[i]["usertype"].ToString()) && (comboTxt.SelectedItem.ToString() == "Admin"))
                        {
                            flag = true;
                            loggedUserName = userTxt.Text;
                            if (comboTxt.Text.ToString() == "Admin")
                            {
                                var confirmResult = MessageBox.Show("Hey Admin do you want to login as User??",
                                     "Confirm Please!!",
                                     MessageBoxButtons.YesNo);
                                if (confirmResult == DialogResult.Yes)
                                {
                                    // If 'Yes', do something here.
                                    // Home h = new Home();
                                    // loggedIn = userTxt.Text;//To display Logged In user
                                    // MainClass.showWindow(h, this, Form1.ActiveForm);
                                    UserDashboared us = new UserDashboared();
                                    this.Hide();
                                    us.Show();
                                }
                                else
                                {
                                    Dashboared db = new Dashboared();
                                    this.Hide();
                                    db.Show();
                                    // If 'No', do something here.
                                    //  Admin_Panel ap5 = new Admin_Panel();
                                    //  loggedIn = comboTxt.Text;//To display Logged In user
                                    //  //loggedIn1 =comboTxt.Text;
                                    //    MainClass.showWindow(ap5, this, Form1.ActiveForm);
                                    // this.Hide();
                                }
                            }
                        }
                        else
                        {
                            if (comboTxt.SelectedItem.ToString() == "User")
                            {
                                if ((userTxt.Text == dt.Rows[i]["username"].ToString()) && (PassTxt.Text == dt.Rows[i]["password"].ToString()))
                                {
                                    flag = true;
                                    UserDashboared us = new UserDashboared();
                                    this.Hide();
                                    us.Show();
                                    //  Home h = new Home();
                                    // loggedIn = comboTxt.Text;
                                    //MainClass.showWindow(h, this, Form1.ActiveForm);
                                    // this.Hide();
                                }
                            }
                        }
                    }
                }
            }
            if (!flag)
            {
                MessageBox.Show("You Are not Allowed To Login");
            }
        }

        private void userTxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //  PassTxt.Text = "";
            
        }

        private void PassTxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void PassTxt_MouseHover(object sender, EventArgs e)
        {
            PassTxt.Text = "";
        }
    }
}


