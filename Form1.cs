using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace CustomerInformationSystem
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-8NH2GBN;Initial Catalog=cisdb;Integrated Security=True;Encrypt=False"))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("INSERT INTO cis (customerid, customername, p1, p2, p3, total) VALUES (@CustomerID, @CustomerName, @P1, @P2, @P3, @Total)", con))
                {
                    cmd.Parameters.AddWithValue("@CustomerID", int.Parse(textBox1.Text));
                    cmd.Parameters.AddWithValue("@CustomerName", textBox2.Text);
                    cmd.Parameters.AddWithValue("@P1", textBox3.Text);
                    cmd.Parameters.AddWithValue("@P2", textBox4.Text);
                    cmd.Parameters.AddWithValue("@P3", textBox5.Text);
                    cmd.Parameters.AddWithValue("@Total", textBox6.Text);
                    cmd.ExecuteNonQuery();
                }
                MessageBox.Show("Record Added Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            BindData();
        }

        private void BindData()
        {
            using (SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-8NH2GBN;Initial Catalog=cisdb;Integrated Security=True;Encrypt=False"))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM cis", con))
                {
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dataGridView1.DataSource = dt;
                    }
                }
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-8NH2GBN;Initial Catalog=cisdb;Integrated Security=True;Encrypt=False"))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("DELETE FROM cis WHERE customerid=@CustomerID", con))
                {
                    cmd.Parameters.AddWithValue("@CustomerID", int.Parse(textBox1.Text));
                    cmd.ExecuteNonQuery();
                }
                MessageBox.Show("Record Deleted Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            BindData();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            BindData();
        }
    }
}
