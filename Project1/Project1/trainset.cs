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
    public partial class trainset : UserControl
    {
        SqlConnection con = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Project1\Project1\ProjectTSP.mdf;Integrated Security = True; Connect Timeout = 30");
        SqlCommand command = new SqlCommand();
        trainsetModel model = new trainsetModel();
        public trainset()
        {
            InitializeComponent();
        }

        private void trainset_Load(object sender, EventArgs e)
        {
            command.Connection = con;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            con.Open();
            String query = "SELECT  * FROM  TrainSetModel ";
            SqlDataAdapter SDA = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            SDA.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].HeaderText = "TRAINSET MODEL NAME";


            con.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "")
            {
                con.Open();
                command.CommandText = "insert into TrainSetModel (train_set_model_name) values(' " + textBox2.Text + " ') ";
                command.ExecuteNonQuery();
                con.Close();
                model.train_set_model_id = 0;
                MessageBox.Show("Save Complete");
                textBox2.Clear();



            }
            else
            {
                MessageBox.Show("Please enter data");
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox2.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (model.train_set_model_id != 0)
            {
                con.Open();

                command.CommandText = "update TrainSetModel set train_set_model_name=' " + textBox2.Text + " '    where train_set_model_id=' " + model.train_set_model_id + " '  ";
                command.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Edit Complete");
                model.train_set_model_id = 0;
                textBox2.Clear();



            }
            else
            {
                MessageBox.Show("Please select data");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (model.train_set_model_id != 0)
            {
                con.Open();

                command.CommandText = "delete from TrainSetModel  where train_set_model_id=' " + model.train_set_model_id+ " '  ";
                command.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Delete Complete");
                model.train_set_model_id = 0;
                textBox2.Clear();



            }
            else
            {
                MessageBox.Show("Plese select data");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                model.train_set_model_id = (int)row.Cells["train_set_model_id"].Value;
                model.train_set_model_name= row.Cells["train_set_model_name"].Value.ToString();

                textBox2.Text = row.Cells["train_set_model_name"].Value.ToString();
                dataGridView1.Columns[0].HeaderText = "TRAINSET MODEL NAME";

            }
        }
    }
}
