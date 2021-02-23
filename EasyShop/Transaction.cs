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
    public partial class Transaction : Form
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-AGPPMFD\\JAMINURSQLSERVER;Initial Catalog=SystemDatabase;Integrated Security=True");
        public Transaction()
        {
            InitializeComponent();
            this.ControlBox = false;
            this.Text = String.Empty;
           
            //dataGridViewOfTransaction.CaptionBackColor=
        }
        //Method which returns Invoice No
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
            SqlDataAdapter adapt = new SqlDataAdapter("select * from Transaction_Table", con);
            adapt.Fill(dt);
            dataGridViewOfTransaction.DataSource = dt;
        }

        private void Transaction_Load(object sender, EventArgs e)
        { 
            DisplayData();
            dataGridViewOfTransaction.ColumnHeadersDefaultCellStyle.BackColor = Color.Black;
        }
    

        private void dataGridViewOfTransaction_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridViewOfTransaction_CellFormatting_1(object sender, DataGridViewCellFormattingEventArgs e)
        {
            foreach (DataGridViewRow row in dataGridViewOfTransaction.Rows)
            {
               // row.DefaultCellStyle.BackColor = Color.FromArgb(156, 48, 63);
               // row.DefaultCellStyle.ForeColor = Color.Black;
            }
        }
        public Color CaptionBackColor { get; set; }
    }
}
