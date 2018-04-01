using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Project1
{
    public partial class line : UserControl
    {
        SqlConnection con = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Project1\Project1\ProjectTSP.mdf;Integrated Security = True; Connect Timeout = 30");
        SqlCommand command = new SqlCommand();
        lineModel model = new lineModel();
     
     
       
        public line()
        {
            InitializeComponent();
        }

        private void line_Load(object sender, EventArgs e)
        {
            command.Connection = con;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            con.Open();
            String query = "SELECT  * FROM  Line ";
            SqlDataAdapter SDA = new SqlDataAdapter(query,con);
            DataTable dt = new DataTable();
            SDA.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].HeaderText = "LINE NAME";
           

            con.Close();


        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "")
            {
                con.Open();
                command.CommandText = "insert into Line (line_name) values(' " + textBox2.Text + " ') ";
                command.ExecuteNonQuery();
                con.Close();
                model.line_id = 0;
                MessageBox.Show("Save Complete");
                textBox1.Clear();



            }
            else
            {
                MessageBox.Show("Please enter data");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >=0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                model.line_id =(int) row.Cells["line_id"].Value;
                model.line_name = row.Cells["line_name"].Value.ToString();
                textBox2.Text = row.Cells["line_name"].Value.ToString();
                dataGridView1.Columns[0].HeaderText = "LINE NAME";
              


            }

      
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "")
            {
                con.Open();

                command.CommandText = "update Line set line_name=' " + textBox2.Text + " '    where line_id=' " + model.line_id + " '  ";
                command.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Edit Complete");
                model.line_id = 0;
                textBox2.Clear();



            }
            else
            {
                MessageBox.Show("Please select data");
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "")
            {
                con.Open();

                command.CommandText = "delete from Line  where line_id=' " + model.line_id + " '  ";
                command.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Delete Complete");
                model.line_id = 0;
                textBox2.Clear();
               

              
            }
            else
            {
                MessageBox.Show("Plese select data");
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
