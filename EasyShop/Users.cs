using System;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Windows.Forms;
namespace EasyShop
{
    public partial class Users : Form
    {
        int edit = 0;
        int Id;
        public  int totUserCount = 0;
      //  public static string totUserValue = "100";
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-AGPPMFD\\JAMINURSQLSERVER;Initial Catalog=SystemDatabase;Integrated Security=True");
        public Users()
        {
            InitializeComponent();
            this.ControlBox = false;
            this.Text = String.Empty;
            // tot
            totUserCnt.Text = totUserCount.ToString();
            Users u = new Users();
            
        }
        public string _totUserCnt
        {
            get { return totUserCnt.Text; }
        }
        public string Get8Digits()
        {
            var bytes = new byte[4];
            var rng = RandomNumberGenerator.Create();
            rng.GetBytes(bytes);
            uint random = BitConverter.ToUInt32(bytes, 0) % 100000000;
            return String.Format("{0:D8}", random);
        }
        private void DisplayData()
        {
            //con.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter adapt = new SqlDataAdapter("select * from UserInfo", con);
            adapt.Fill(dt);
            dataGridViewOfUser.DataSource = dt;
            //con.Close();
        }
        private void clearData()
        {
            nameText.Text = "";
            passText.Text = "";
            //gggg.Text = "";
            userTypeTxt.Text = "";
            userText.Text = "";
            emailText.Text = "";
            phoneText.Text = "";
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            edit = 0;

        }

        private void editBtn_Click(object sender, EventArgs e)
        {
            if ((userText.Text != "") && (passText.Text != "") && (userTypeTxt.Text != "") && (phoneText.Text != "") && (nameText.Text != "") && (emailText.Text != ""))
            {
                //SqlCommand cmd = new SqlCommand("update UserInfo set name=@naId,username=@unId password=@passId usertype=@typeId phone=@phoneId emai=@emailId  where User_ID=@id", con);
                SqlCommand cmd = new SqlCommand("update UserInfo set name='" + nameText.Text + "',username='" + userText.Text + "' ,password='" + passText.Text + "' ,usertype=@userTypeVal,phone='" + phoneText.Text + "',email='" + emailText.Text + "'where User_ID=@id", con);
                con.Open();
                //cmd.Parameters.AddWithValue("@id", ID);
                try
                {
                    cmd.Parameters.Add("@id", SqlDbType.Int);
                    cmd.Parameters["@id"].Value = Id;
                    cmd.Parameters.AddWithValue("@userTypeVal", userTypeTxt.SelectedItem);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Record Updated Successfully");
                    DisplayData();
                    clearData();
                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                    con.Close();
                }
            }
            else
            {
                MessageBox.Show("Please Select Record to Update");
            }
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            if (edit == 0)
            {
                totUserCount += 1;
                totUserCnt.Text = totUserCount.ToString();
              //  totUserValue = totUserCount.ToString();
                string idVal = Get8Digits();
                int ID = int.Parse(idVal);
                //SqlConnection con = new SqlConnection("Data Source=JAMINUR\\JAMINURSQL;Initial Catalog=MyDbse;Integrated Security=True");
                //SqlConnection con = new SqlConnection("Data Source=JAMINUR\\JAMINURSQL;Initial Catalog=MyDbse;Integrated Security=True");
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "insert into UserInfo (User_ID,name,username,password,usertype,phone,email) values (@id,'" + this.nameText.Text + "','" + this.userText.Text + "','" + this.passText.Text + "',@userTypeVal,'" + this.phoneText.Text + "','" + this.emailText.Text + "')";
                    cmd.Parameters.Add("@id", SqlDbType.Int);
                    cmd.Parameters["@id"].Value = ID;
                    cmd.Parameters.AddWithValue("@userTypeVal", userTypeTxt.SelectedItem);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Inserted Successfully");
                    DisplayData();
                    clearData();
                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }

        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            totUserCount--;
            if (nameText.Text != "")
            {
                SqlCommand cmd = new SqlCommand("delete UserInfo where User_ID=@ID", con);
                con.Open();
                cmd.Parameters.AddWithValue("@ID", Id);
                cmd.ExecuteNonQuery();
                DisplayData();
                con.Close();
                MessageBox.Show("Record Deleted Successfully!");
                nameText.Text = "";
                DisplayData();
                clearData();
            }
            else
            {
                MessageBox.Show("Please Select Record to Delete");
            }
        }

        private void Users_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter adapt = new SqlDataAdapter("select * from UserInfo", con);
            adapt.Fill(dt);
            dataGridViewOfUser.DataSource = dt;
        }

        private void dataGridViewOfUser_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
           
                MessageBox.Show("It Works");
                Id = Convert.ToInt32(dataGridViewOfUser.SelectedRows[0].Cells[0].Value);
                userText.Text = dataGridViewOfUser.Rows[e.RowIndex].Cells[2].Value.ToString();
                passText.Text = dataGridViewOfUser.Rows[e.RowIndex].Cells[3].Value.ToString();
                userTypeTxt.Text = dataGridViewOfUser.Rows[e.RowIndex].Cells[4].Value.ToString();
                nameText.Text = dataGridViewOfUser.Rows[e.RowIndex].Cells[1].Value.ToString();
                phoneText.Text = dataGridViewOfUser.Rows[e.RowIndex].Cells[5].Value.ToString();
                emailText.Text = dataGridViewOfUser.Rows[e.RowIndex].Cells[6].Value.ToString();
                // MessageBox.Show("It Works");
        }

        private void dataGridViewOfUser_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            foreach (DataGridViewRow row in dataGridViewOfUser.Rows)
            {
               // row.DefaultCellStyle.BackColor = Color.Green;
               // row.DefaultCellStyle.ForeColor = Color.Black;
            }
        }

        private void userTypeTxt_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void gridPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void UserPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridViewOfUser_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }
    }
}
