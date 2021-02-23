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
    public partial class Products : Form
    {

        SqlConnection con = new SqlConnection("Data Source=DESKTOP-AGPPMFD\\JAMINURSQLSERVER;Initial Catalog=SystemDatabase;Integrated Security=True");
        int edit = 0;
        int Id;
        string userType = "";
        public Products()
        {
            InitializeComponent();
            this.ControlBox = false;
            this.Text = String.Empty;
        }

        private void Products_Load(object sender, EventArgs e)
        {
            dataGridViewOfProduct.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.Fill);
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
            DataTable dt = new DataTable();
            SqlDataAdapter adapt = new SqlDataAdapter("select * from ProductInfo1", con);
            adapt.Fill(dt);
            dataGridViewOfProduct.AutoResizeColumns();
            dataGridViewOfProduct.DataSource = dt;
        }
        private void clearData()
        {
            //prodIdTxt.Text = "";
            prodNameTxt.Text = "";
            prodTypeTxt.Text = "";
            quantityTxt.Text = "";
            priceTxt.Text = "";
        }

        private void save_Btn_Click(object sender, EventArgs e)
        {
            if (prodNameTxt.Text == "" || prodTypeTxt.Text == "" || quantityTxt.Text == "" || priceTxt.Text == "")
            {
                MessageBox.Show("Feilds With are Mandatory ");

            }
            else//For save
            {
                    string idVal = Get8Digits();
                    int ID = int.Parse(idVal);
                    //SqlConnection con = new SqlConnection("Data Source=JAMINUR\\JAMINURSQL;Initial Catalog=MyDbse;Integrated Security=True");
                    //SqlConnection con = new SqlConnection("Data Source=JAMINUR\\JAMINURSQL;Initial Catalog=MyDbse;Integrated Security=True");
                    try
                    {
                        //Starts Modifying Here
                        // con.Open();
                        //SqlCommand check_User_Name = new SqlCommand("select count(*) from ProductInfo where Product_Name=@prodName)", con);
                        // check_User_Name.Parameters.AddWithValue("@prodName", prodNameTxt.Text);
                        //int UserExist = (int)check_User_Name.ExecuteScalar();
                        //con.Open();
                        //int count= (int)check_User_Name.ExecuteScalar();
                        // int count = 0;
                        // con.Close();
                       // SqlDataAdapter adapt = new SqlDataAdapter("select * from ProductInfo where Product_Name='" + prodNameTxt.Text + "'", con);
                       // //adapt.Parameters.AddWithValue("@prodName", prodNameTxt.Text);
                      //  DataTable dt = new DataTable();
                      //  adapt.Fill(dt);
                       // if (dt.Rows.Count > 0)
                     //   {
                         //   MessageBox.Show("Yes Exists");
                         //   string qn = quantityTxt.Text;
                          //  int tmp = int.Parse(qn);
                          //  clearData();
                            /* int tmp1= Convert.ToInt32(dataGridViewOfProduct.SelectedRows[0].Cells[3].Value);
                             dataGridViewOfProduct.SelectedRows[0].Cells[3].Value=tmp+tmp1;
                             //Username exist
                             // SqlCommand cmd = new SqlCommand("update ProductInfo set Quantity=@quantity where Product_Name='"+prodNameTxt.Text+"'", con);
                             */
                            // MessageBox.Show("Yes Updated");
                       // }
                        //else
                      //  {
                            //Username doesn't exist.
                            con.Open();
                            SqlCommand cmd = new SqlCommand();
                            cmd.Connection = con;
                            cmd.CommandText = "insert into ProductInfo1 (Product_ID,Product_Name,Producttype,Quantity,Price) values (@id,'" + this.prodNameTxt.Text + "','" + this.prodTypeTxt.Text + "', @qq ,'" + this.priceTxt.Text + "')";
                            cmd.Parameters.Add("@id", SqlDbType.Int);
                            cmd.Parameters["@id"].Value = ID;
                    //updated 2
                            cmd.Parameters.Add("@qq", SqlDbType.Int);
                            cmd.Parameters["@qq"].Value = int.Parse(quantityTxt.Text);
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Inserted Successfully");
                            DisplayData();
                            clearData();
                            con.Close();
                       // }
                        //

                        /* con.Open();
                         SqlCommand cmd = new SqlCommand();
                         cmd.Connection = con;
                         cmd.CommandText = "insert into ProductInfo (Product_ID,Product_Name,Producttype,Quantity,Price) values (@id,'" + this.prodNameTxt.Text+ "','" + this.prodTypeTxt.Text + "','" + this.quantityTxt.Text + "','" + this.priceTxt.Text + "')";
                         cmd.Parameters.Add("@id", SqlDbType.Int);
                         cmd.Parameters["@id"].Value = ID;
                         cmd.ExecuteNonQuery();
                         MessageBox.Show("Inserted Successfully");
                         DisplayData();
                         clearData();
                         con.Close();
                         */
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                        con.Close();
                    }
                }
            }

        private void dataGridViewOfProduct_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //MessageBox.Show("It Works");
            Id = Convert.ToInt32(dataGridViewOfProduct.SelectedRows[0].Cells[0].Value);
            //prodIdTxt.Text = Id.ToString();
            prodNameTxt.Text = dataGridViewOfProduct.SelectedRows[0].Cells[1].Value.ToString();
            prodTypeTxt.Text = dataGridViewOfProduct.SelectedRows[0].Cells[2].Value.ToString();
            quantityTxt.Text = dataGridViewOfProduct.SelectedRows[0].Cells[3].Value.ToString();
            priceTxt.Text = dataGridViewOfProduct.SelectedRows[0].Cells[4].Value.ToString();
        }

        private void Products_Load_1(object sender, EventArgs e)
        {
            DisplayData();
        }

        private void delete_Btn_Click(object sender, EventArgs e)
        {
            if (prodNameTxt.Text == "" || prodTypeTxt.Text == "" || quantityTxt.Text == "" || priceTxt.Text == "")
            {
                MessageBox.Show("Feilds With are Mandatory ");

            }
            else
            {

                SqlCommand cmd = new SqlCommand("delete ProductInfo1 where Product_ID=@ID", con);
                con.Open();
                cmd.Parameters.AddWithValue("@ID", Id);
                cmd.ExecuteNonQuery();
                DisplayData();
                con.Close();
                MessageBox.Show("Record Deleted Successfully!");
                //nameText.Text = "";
                DisplayData();
                clearData();
            }
        }

        private void edit_Btn_Click(object sender, EventArgs e)
        {
            if ((prodNameTxt.Text != "") && (prodTypeTxt.Text != "") && (quantityTxt.Text != "") && (priceTxt.Text != ""))
            {
                //SqlCommand cmd = new SqlCommand("update UserInfo set name=@naId,username=@unId password=@passId usertype=@typeId phone=@phoneId emai=@emailId  where User_ID=@id", con);
                SqlCommand cmd = new SqlCommand("update ProductInfo1 set Product_Name='" + prodNameTxt.Text + "',Producttype='" + prodTypeTxt.Text + "' ,Quantity=@qq ,Price='" + priceTxt.Text + "' where Product_ID=@id", con);
                con.Open();
                try
                {
                    cmd.Parameters.Add("@id", SqlDbType.Int);
                    cmd.Parameters["@id"].Value = Id;
                    cmd.Parameters.Add("@qq", SqlDbType.Int);
                    cmd.Parameters["@qq"].Value = int.Parse(quantityTxt.Text);
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

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
