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
using System.Security.Cryptography;
namespace EasyShop
{
    public partial class Supplier : Form
    {
        int Id;
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-AGPPMFD\\JAMINURSQLSERVER;Initial Catalog=SystemDatabase;Integrated Security=True");
        public Supplier()
        {
            InitializeComponent();
            this.ControlBox = false;
            this.Text = String.Empty;
        }
        //function to generete random supplier Id
        public string Get8Digits()
        {
            var bytes = new byte[4];
            var rng = RandomNumberGenerator.Create();
            rng.GetBytes(bytes);
            uint random = BitConverter.ToUInt32(bytes, 0) % 100000000;
            return String.Format("{0:D8}", random);
        }
        //function to display Supplier Info
        private void DisplayData()
        {
            //con.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter adapt = new SqlDataAdapter("select * from SupplierInfo", con);
            adapt.Fill(dt);
         dataGridViewOfSupplier.DataSource = dt;
            //con.Close();
        }
        //function to clear Textbox data after operation
        private void clearData()
        {
            snameTxt.Text = "";
            supAddressTxt.Text = "";
            totAmuntTxt.Text = "";
            sDateTxt.Text = "";
            paidAmountTxt.Text = "";

        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("update SupplierInfo set Name='" + snameTxt.Text + "',Address='" + supAddressTxt.Text + "',Date=@birthDay,Amount='" + totAmuntTxt.Text + "' ,Paid='" + paidAmountTxt.Text + "',Due=@newDue where SID=@id", con);
            if ((snameTxt.Text == "") || (supAddressTxt.Text == "") || (totAmuntTxt.Text == "") || (paidAmountTxt.Text == ""))
            {
                MessageBox.Show("Details Are Mandatory!!");
            }
            else
            {
                try
                {
                    con.Open();
                    cmd.Parameters.Add("@id", SqlDbType.Int);
                    cmd.Parameters["@id"].Value = Id;
                    cmd.Parameters.Add("@birthDay", SqlDbType.Date).Value = sDateTxt.Value.Date;
                    int tot = int.Parse(totAmuntTxt.Text) - int.Parse(paidAmountTxt.Text);
                    cmd.Parameters.Add("@newDue", SqlDbType.Int);
                    cmd.Parameters["@newDue"].Value = tot;
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
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sId = Get8Digits();
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "insert into SupplierInfo (SID,Name,Address,Date,Amount,Due,Paid) values (@id,'" + this.snameTxt.Text + "','" + this.supAddressTxt.Text + "',@birthDay,'" + this.totAmuntTxt.Text + "',@dueAmount,'" + paidAmountTxt.Text + "')";
                    cmd.Parameters.Add("@id", SqlDbType.Int);
                    cmd.Parameters["@id"].Value = sId;
                    cmd.Parameters.Add("@birthDay", SqlDbType.Date).Value = sDateTxt.Value.Date;
                    int tot = int.Parse(totAmuntTxt.Text) - int.Parse(paidAmountTxt.Text);
                    cmd.Parameters.Add("@dueAmount", SqlDbType.Int);
                    cmd.Parameters["@dueAmount"].Value = tot;
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Inserted Successfully");
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

        private void Supplier_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter adapt = new SqlDataAdapter("select * from SupplierInfo", con);
            adapt.Fill(dt);
            dataGridViewOfSupplier.DataSource = dt;
        }

        private void dataGridViewOfSupplier_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            MessageBox.Show("It Works");
            Id = Convert.ToInt32(dataGridViewOfSupplier.SelectedRows[0].Cells[0].Value);
            snameTxt.Text = dataGridViewOfSupplier.Rows[e.RowIndex].Cells[1].Value.ToString();
            supAddressTxt.Text = dataGridViewOfSupplier.Rows[e.RowIndex].Cells[2].Value.ToString();
            totAmuntTxt.Text = dataGridViewOfSupplier.Rows[e.RowIndex].Cells[4].Value.ToString();
            paidAmountTxt.Text = dataGridViewOfSupplier.Rows[e.RowIndex].Cells[6].Value.ToString();
            sDateTxt.Text = dataGridViewOfSupplier.Rows[e.RowIndex].Cells[3].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if ((snameTxt.Text != "") || (supAddressTxt.Text != "") || (totAmuntTxt.Text != "") || (paidAmountTxt.Text != ""))
            {
                SqlCommand cmd = new SqlCommand("delete SupplierInfo where SID=@ID", con);
                con.Open();
                cmd.Parameters.AddWithValue("@ID", Id);
                cmd.ExecuteNonQuery();
                DisplayData();
                con.Close();
                MessageBox.Show("Record Deleted Successfully!");
                DisplayData();
                clearData();
            }
            else
            {
                MessageBox.Show("Please Select Record to Delete");
            }
        }

        private void dataGridViewOfSupplier_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
