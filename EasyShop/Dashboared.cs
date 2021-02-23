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
    public partial class Dashboared : Form
    {
        // Fields
        private Button currentButton;
        private Random random;
        private int tempIndex;
        private Form activeForm;
        //Builder
        public Dashboared()
        {
            InitializeComponent();
            this.Text = String.Empty;
           //FormBorderStyle = FormBorderStyle.None;
           // WindowState = FormWindowState.Maximized;
            StartPosition = FormStartPosition.CenterScreen;
           // loggerUsrName.Text=
        }
        public string _tot
        {
            set { totUser.Text = value; }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.F))
            {
                MessageBox.Show("What the Ctrl+F?");
                Dashboared d = new Dashboared();
               // d.FormBorderStyle = FormBorderStyle.None;
               // d.WindowState = FormWindowState.Minimized;
                d.StartPosition = FormStartPosition.CenterScreen;
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        // Methods
        private Color SelectThemeColor()
        {
            int index = random.Next(ThemeColor.ColorList.Count);
            while (tempIndex == index)
            {
                index = random.Next(ThemeColor.ColorList.Count);
            }
            tempIndex = index;
            string color = ThemeColor.ColorList[index];
            return ColorTranslator.FromHtml(color);
        }


        private void ActivateButton(object btnSender)
        {
           /* if (btnSender! = null)
            {
                if (currentButton! = (Button)btnSender)
                {
                   // DisableButton();
                    Color color = SelectThemeColor();
                    currentButton = (Button)btnSender;
                    currentButton.BackColor = color;
                    currentButton.ForeColor = Color.White;
                    currentButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12 .5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                   // panelTitleBar.BackColor = color;
                   // panelLogo.BackColor = ThemeColor.ChangeColorBrightness(color, -0.3);
                    //ThemeColor.PrimaryColor = color;
                  //  ThemeColor.SecondaryColor = ThemeColor.ChangeColorBrightness(color, -0.3);
                   // btnCloseChildForm.Visible = true;
                }
            }
            */
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pageChk.Text = "User";
            showForm.Controls.Clear();
            Users myForm = new Users();
            //Dashboared db = new Dashboared();
            myForm.TopLevel = false;
            myForm.AutoScroll = true;
            showForm.Controls.Add(myForm);
            myForm.Dock = DockStyle.Fill;
            myForm.Show();
        }

        private void productBtn_Click(object sender, EventArgs e)
        {
            pageChk.Text = "Product";
            showForm.Controls.Clear();
            Products myForm1= new Products();
            //Dashboared db = new Dashboared();
            myForm1.TopLevel = false;
            myForm1.AutoScroll = true;
            showForm.Controls.Add(myForm1);
            myForm1.Dock = DockStyle.Fill;
            myForm1.Show();
            //this.Hide();
        }

        private void saleBtn_Click(object sender, EventArgs e)
        {
            pageChk.Text = "Sale";
            showForm.Controls.Clear();
            Sale myForm1 = new Sale();
            //Dashboared db = new Dashboared();
            myForm1.TopLevel = false;
            myForm1.AutoScroll = true;
            showForm.Controls.Add(myForm1);
            myForm1.Dock = DockStyle.Fill;
            myForm1.Show();
        }

        private void supplierBtn_Click(object sender, EventArgs e)
        {
            pageChk.Text = "Supplier";
            showForm.Controls.Clear();
            Supplier myForm1 = new Supplier();
            //Dashboared db = new Dashboared();
            myForm1.TopLevel = false;
           // myForm1.AutoScroll = true;
            showForm.Controls.Add(myForm1);
            myForm1.Dock = DockStyle.Fill;
            myForm1.Show();
        }

        private void transactionBtn_Click(object sender, EventArgs e)
        {
            pageChk.Text = "Transaction";
            showForm.Controls.Clear();
            Transaction myForm1 = new Transaction();
            //Dashboared db = new Dashboared();
            myForm1.TopLevel = false;
            myForm1.AutoScroll = true;
            showForm.Controls.Add(myForm1);
            myForm1.Dock = DockStyle.Fill;
            myForm1.Show();
        }

        private void toggleBtn_Click(object sender, EventArgs e)
        {
            Dashboared dObj = new Dashboared();
           // this.FormBorderStyle = FormBorderStyle.None;
           // this.WindowState = FormWindowState.Maximized;
           // toggleBtn.Dock = DockStyle.Right;
            //toggleBtn.MarginTop
           // dObj.Dashboared();
        }

        private void Dashboared_Load(object sender, EventArgs e)
        {
            loggerUsrName.Text = Form1.loggedUserName;
           // totUser.Text = Users.totUserValue;
        }


        private void showForm_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelLogo_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_MouseHover(object sender, EventArgs e)
        {
            button1.BackColor = Color.FromArgb(10, 102, 58);
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackColor = Color.FromArgb(51,51,76);
        }

        private void productBtn_MouseHover(object sender, EventArgs e)
        {
            productBtn.BackColor = Color.FromArgb(10, 102, 58);
        }

        private void productBtn_MouseLeave(object sender, EventArgs e)
        {
            productBtn.BackColor = Color.FromArgb(51, 51, 76);
        }

        private void saleBtn_MouseHover(object sender, EventArgs e)
        {
            saleBtn.BackColor = Color.FromArgb(10, 102, 58);
        }

        private void saleBtn_MouseLeave(object sender, EventArgs e)
        {
            saleBtn.BackColor = Color.FromArgb(51, 51, 76);
        }

        private void supplierBtn_MouseHover(object sender, EventArgs e)
        {
            supplierBtn.BackColor = Color.FromArgb(10, 102, 58);
        }

        private void supplierBtn_MouseLeave(object sender, EventArgs e)
        {
            supplierBtn.BackColor = Color.FromArgb(51, 51, 76);
        }

        private void transactionBtn_MouseHover(object sender, EventArgs e)
        {
            transactionBtn.BackColor = Color.FromArgb(10, 102, 58);
        }

        private void transactionBtn_MouseLeave(object sender, EventArgs e)
        {
            transactionBtn.BackColor = Color.FromArgb(51, 51, 76);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
