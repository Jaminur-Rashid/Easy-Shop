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
using DGVPrinterHelper;

namespace EasyShop
{
    public partial class Sale : Form
    {
        double totalCost = 0.0;
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-AGPPMFD\\JAMINURSQLSERVER;Initial Catalog=SystemDatabase;Integrated Security=True");
        public Sale()
        {
            InitializeComponent();
            this.ControlBox = false;
            this.Text = String.Empty;
           // dataGridViewOfCart.RowTemplate.Resizable = DataGridViewTriState.True;
          //  dataGridViewOfCart.RowTemplate.Height = 50;
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
            SqlDataAdapter adapt = new SqlDataAdapter("select * from ProductInfo1", con);
            adapt.Fill(dt);
            dataGridViewOfSale.DataSource = dt;
            DataTable dt1 = new DataTable();
            SqlDataAdapter adapt1= new SqlDataAdapter("select * from Cart_Table", con);
            adapt1.Fill(dt1);
            dataGridViewOfCart.DataSource = dt1;
           // dataGridViewOfSale.AutoResizeColumns();
        }
        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void cusName_Click(object sender, EventArgs e)
        {

        }

        private void dataGridViewOfSale_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Sale_Load(object sender, EventArgs e)
        {
            
            
            
            DisplayData();
        }

        private void dataGridViewOfSale_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            foreach(DataGridViewRow row in dataGridViewOfSale.Rows)
            {
               // row.DefaultCellStyle.BackColor =Color.Green;
                row.DefaultCellStyle.ForeColor=Color.White;
            }
        }

        private void dataGridViewOfSale_CellClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridViewOfSale_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            MessageBox.Show("It");
            try
            {
                int prodId = Convert.ToInt32(dataGridViewOfSale.SelectedRows[0].Cells[0].Value);
                prodID.Text = dataGridViewOfSale.SelectedRows[0].Cells[0].Value.ToString();
                NLabel.Text = dataGridViewOfSale.SelectedRows[0].Cells[1].Value.ToString();
                pquantity.Text = dataGridViewOfSale.Rows[e.RowIndex].Cells[3].Value.ToString();
                string pName = dataGridViewOfSale.Rows[e.RowIndex].Cells[1].Value.ToString();
                string ptype = dataGridViewOfSale.Rows[e.RowIndex].Cells[2].Value.ToString();
                string pQuantity = dataGridViewOfSale.Rows[e.RowIndex].Cells[3].Value.ToString();
                string pPrice = dataGridViewOfSale.Rows[e.RowIndex].Cells[4].Value.ToString();
                pLabel.Text = pPrice;
                type.Text = ptype;
                prodName.Text = pName;
                pprice.Text = pPrice;
                ppQuantity.Text = pQuantity;
                int q = int.Parse(pQuantity);
                int tot = int.Parse(pQuantity) * int.Parse(pPrice);
                int p = int.Parse(pPrice);
            }


            /*  

              using (SqlConnection connection = new SqlConnection("Data Source=DESKTOP-AGPPMFD\\JAMINURSQLSERVER;Initial Catalog=SystemDatabase;Integrated Security=True"))
              {
                  string query = "insert into Cart_Table(Product_ID,Product_Name,Price,Quantity,Total,Type) values (@id,@name,@pricce,@qnty,@total,@type)";
                 // MessageBox.Show("k");
                  using (SqlCommand command = new SqlCommand(query, connection))
                  {
                      command.Parameters.AddWithValue("@id", prodId);
                      command.Parameters.AddWithValue("@name", pName);
                      command.Parameters.AddWithValue("@pricce", p);
                      command.Parameters.AddWithValue("@qnty", q);
                      command.Parameters.AddWithValue("@total", tot);
                      command.Parameters.AddWithValue("@type", ptype);
                      connection.Open();
                      int result = command.ExecuteNonQuery();

                      // Check Error
                      if (result < 0)
                          Console.WriteLine("Error inserting data into Database!");
                  }
              }
              MessageBox.Show("Inserted Successfully");
              DisplayData();
          }
          */
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                con.Close();
            }
            
        }

        private void dataGridViewOfCart_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            foreach (DataGridViewRow row in dataGridViewOfCart.Rows)
            {
              //  row.DefaultCellStyle.BackColor = Color.Green;
                row.DefaultCellStyle.ForeColor = Color.Black;
            }
        }

        private void Vertical(object sender, ScrollEventArgs e)
        {

        }

        private void dataGridViewOfCart_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            MessageBox.Show("clicked");
            int Id = Convert.ToInt32(dataGridViewOfCart.SelectedRows[0].Cells[0].Value);
            int qntityVal = Convert.ToInt32(dataGridViewOfCart.SelectedRows[0].Cells[3].Value);
            int badPrice = Convert.ToInt32(dataGridViewOfCart.SelectedRows[0].Cells[4].Value);
            DialogResult dr = MessageBox.Show("Are you sure to delete row?", "Confirmation", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                totalCost -= (badPrice);
                totalBtn.Text = totalCost.ToString();
                //int Id1 = Convert.ToInt32(dataGridViewOfCart.SelectedRows[0].Cells[0].Value);
                //delete row from database or datagridview...
                try
                {
                    SqlCommand cmd = new SqlCommand("delete Cart_Table where Product_ID=@Id", con);
                    con.Open();
                    cmd.Parameters.AddWithValue("@ID", Id);
                    cmd.ExecuteNonQuery();
                    DisplayData();
                    con.Close();
                    MessageBox.Show("Record Deleted Successfully!");
                    //nameText.Text = "";
                    DisplayData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                try
                {
                    //string conString = "Data Source=DESKTOP-AGPPMFD\\JAMINURSQLSERVER;Initial Catalog=SystemDatabase;Integrated Security=True";
                    // string query = "UPDATE ProductInfo SET Quantity = Quantity + @qnty where Product_ID = @selecteID";
                    using (SqlConnection connection = new SqlConnection("Data Source=DESKTOP-AGPPMFD\\JAMINURSQLSERVER;Initial Catalog=SystemDatabase;Integrated Security=True"))
                    {
                        string query = "UPDATE ProductInfo1 SET Quantity =Quantity+@tmp where Product_ID = @selectedID";
                        // MessageBox.Show("k");
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@selectedID", Id);
                            
                            command.Parameters.AddWithValue("@tmp", qntityVal);
                            connection.Open();
                            int result = command.ExecuteNonQuery();
                            DisplayData();
                            // Check Error
                            if (result < 0)
                                Console.WriteLine("Error inserting data into Database!");
                        }
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        
            else if(dr == DialogResult.No)
            {
                MessageBox.Show("Record Was Not Updated");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int ppID = int.Parse(prodID.Text);
        }
        private void addCart()
        {

        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            string selected = ppQuantity.Text;
            int q1 = int.Parse(selected);
            if (int.Parse(pquantity.Text) < q1)
            {
                MessageBox.Show("Selected quantity is greater than stock");
            }
            else
            {
                int q = int.Parse(pquantity.Text);
                int updatedQuantity = q - q1;
                string p = pLabel.Text;
               // int tot = int.Parse(ppQuantity.Text) * int.Parse(pLabel.Text);
                int tot = int.Parse(ppQuantity.Text)*int.Parse(pLabel.Text);
                //int tot1 = int.Parse(pprice.Text);
                // totalBtn.Text = (Int32.Parse(textBox1.Text) * Double.Parse(textBox2.Text)).ToString();
                totalCost = totalCost+(double)tot;
                //totalCost *= tot1;
                //totalCost += (tot)*(1.0);
                totalBtn.Text = totalCost.ToString();
                SqlCommand cmd = new SqlCommand("update ProductInfo1 set Product_ID=@Id ,Product_Name='" + prodName.Text + "',Producttype='" + type.Text + "' ,Quantity=@pqq,Price=@prodPrice where Product_ID=@Id", con);
                con.Open();
                try
                {
                    cmd.Parameters.Add("@Id", SqlDbType.Int);
                    cmd.Parameters["@Id"].Value = int.Parse(prodID.Text);
                    cmd.Parameters.Add("@pqq", SqlDbType.Int);
                    cmd.Parameters["@pqq"].Value = updatedQuantity;
                    cmd.Parameters.Add("@prodPrice", SqlDbType.VarChar);
                    cmd.Parameters["@prodPrice"].Value = p;
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Record Updated Successfully");
                    DisplayData();
                    // clearData();
                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                    con.Close();
                }
                try
                {
                    using (SqlConnection connection = new SqlConnection("Data Source=DESKTOP-AGPPMFD\\JAMINURSQLSERVER;Initial Catalog=SystemDatabase;Integrated Security=True"))
                    {
                        string query = "insert into Cart_Table(Product_ID,Product_Name,Price,Quantity,Total,Type) values (@id,@name,@pricce,@qnty,@total,@type)";
                        // MessageBox.Show("k");
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@id", int.Parse(prodID.Text));
                            command.Parameters.AddWithValue("@name", prodName.Text);
                            command.Parameters.AddWithValue("@pricce", int.Parse(pLabel.Text));
                            command.Parameters.AddWithValue("@qnty", q1);
                            command.Parameters.AddWithValue("@total", tot);
                            command.Parameters.AddWithValue("@type", type.Text);
                            connection.Open();
                            int result = command.ExecuteNonQuery();
                            DisplayData();
                            // Check Error
                            if (result < 0)
                                Console.WriteLine("Error inserting data into Database!");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }

            }
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Are you sure To Confirm The Entry?", "Confirmation", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {

                //Code to Print Bill
                DGVPrinter printer = new DGVPrinter();
                printer.Title = "Easy Shop.Ltd\r\r\nAshugonj , B-Baria\r\n";
                printer.SubTitle = "Customer Name : " +nameTxtofCus.Text+ "\r\r\n Customer Address : " +cusAddress.Text+ " ";
              //  printer.SubTitle = "Name : Jaminur Rashid \n";
               // printer.n
                printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
                printer.PageNumbers = true;
                printer.PageNumberInHeader = false;
                printer.PorportionalColumns = true;
                printer.HeaderCellAlignment = StringAlignment.Near;
                printer.Footer = " Total : " +totalBtn.Text+ "\r\n ";
                printer.PrintDataGridView(dataGridViewOfCart);
                printer.FooterSpacing = 15;
               // printer.page
                SqlCommand cmd = new SqlCommand("delete  from Cart_Table", con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                DisplayData();
                //Inserting Transaction Entry into Transaction Table
                string Invoice_Id="EBC"+Get8Digits();
                MessageBox.Show(Invoice_Id);

                try
                {
                    //getting current Date
                    DateTime now = DateTime.Now;
                    string date = now.GetDateTimeFormats('d')[0];
                    string time = now.GetDateTimeFormats('t')[0];


                    MessageBox.Show("1");
                    using (SqlConnection connection = new SqlConnection("Data Source=DESKTOP-AGPPMFD\\JAMINURSQLSERVER;Initial Catalog=SystemDatabase;Integrated Security=True"))
                    {
                        string query = "insert into Transaction_Table(Invoice_NO,Name,Address,Date,Total) values (@id,@name,@addrs,@date,@total)";
                        // MessageBox.Show("k");
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                           // MessageBox.Show("2");
                            command.Parameters.AddWithValue("@id", Invoice_Id);
                            command.Parameters.AddWithValue("@name", nameTxtofCus.Text);
                            command.Parameters.AddWithValue("@addrs", cusAddress.Text);
                          //  MessageBox.Show("3");
                            command.Parameters.AddWithValue("@date", time);
                          //  MessageBox.Show("4");
                            command.Parameters.AddWithValue("@total",int.Parse(totalBtn.Text));
                            // command.Parameters.AddWithValue("@type", type.Text);
                            connection.Open();
                            int result = command.ExecuteNonQuery();
                            DisplayData();
                            MessageBox.Show("5");
                            // Check Error
                            if (result < 0)
                                Console.WriteLine("Error inserting data into Database!");
                        }
                    }
                    
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }

            }
            else
            {
                
            }
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void totLabel_Click(object sender, EventArgs e)
        {

        }

        private void prodID_Click(object sender, EventArgs e)
        {

        }

        private void nameTxtofCus_TextChanged(object sender, EventArgs e)
        {

        }

        private void ppQuantity_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}