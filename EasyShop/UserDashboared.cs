using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EasyShop
{
    public partial class UserDashboared : Form
    {
        public UserDashboared()
        {
            InitializeComponent();
            usdp.VerticalScroll.Visible = true;
            usdp.AutoScroll = true;

        }

        private void UserDashboared_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

            showForm1.Controls.Clear();
            Transaction myForm1 = new Transaction();
            //Dashboared db = new Dashboared();
            myForm1.TopLevel = false;
           // myForm1.AutoScroll = true;
            showForm1.Controls.Add(myForm1);
            myForm1.Dock = DockStyle.Fill;
            myForm1.Show();
        }

        private void productBtn_Click(object sender, EventArgs e)
        { 
            showForm1.Controls.Clear();
            Products myForm1 = new Products();
            //Dashboared db = new Dashboared();
            myForm1.TopLevel = false;
           // myForm1.AutoScroll = true;
            showForm1.Controls.Add(myForm1);
            myForm1.Dock = DockStyle.Fill ;
            myForm1.Show();
            //this.Hide();
           
        }

        private void showForm_Paint(object sender, PaintEventArgs e)
        {

        }

        private void saleBtn_Click(object sender, EventArgs e)
        {
            showForm1.Controls.Clear();
            Sale myForm1 = new Sale();
            //Dashboared db = new Dashboared();
            myForm1.TopLevel = false;
          //  myForm1.AutoScroll = true;
            showForm1.Controls.Add(myForm1);
            myForm1.Dock = DockStyle.Fill;
            myForm1.Show();
        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel10_Paint(object sender, PaintEventArgs e)
        {

        }

        private void supplierBtn_Click(object sender, EventArgs e)
        {
            showForm1.Controls.Clear();
            Supplier myForm1 = new Supplier();
            //Dashboared db = new Dashboared();
            myForm1.TopLevel = false;
           // myForm1.AutoScroll = true;
            showForm1.Controls.Add(myForm1);
            myForm1.Dock = DockStyle.Fill;
            myForm1.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
