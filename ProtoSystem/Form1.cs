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

namespace ProtoSystem
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data Source=thesqldatabase.database.windows.net;Initial Catalog=PrototypeDB;User ID=sqladmin;Password=Okoser31!");
        private void button1_Click(object sender, EventArgs e)
        {
            
            con.Open();
            SqlCommand command = new SqlCommand("insert into Asset values ('"+int.Parse(textBox1.Text)+ "','"+textBox2.Text+ "','"+textBox3.Text+ "','"+textBox4.Text+"', getdate(), getdate())", con);
            command.ExecuteNonQuery();
            MessageBox.Show("Successfully Inserted.");
            con.Close();
            BindData();
        }
        void BindData()
        {
            SqlCommand command = new SqlCommand("select * from Asset", con);
            SqlDataAdapter sd = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            sd.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.ReadOnly = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            BindData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand command = new SqlCommand("update Asset set AssetName = '"+textBox2.Text+ "', AssetType = '"+textBox3.Text+ "', AssetLocation = '"+textBox4.Text+"',UpdateDate = '"+DateTime.Parse(dateTimePicker1.Text)+"' where AssetID='"+int.Parse(textBox1.Text)+"'", con);
            command.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Successfully Updated.");
            BindData();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete?", "Delete  Record", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
            con.Open();
            SqlCommand command = new SqlCommand("Delete Asset where AssetID= '" + int.Parse(textBox1.Text) + "'", con);
            command.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Successfully Deleted.");
            BindData();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
          
        }
    }
}
