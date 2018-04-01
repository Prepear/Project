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
using Project1.Models;

namespace Project1
{
    public partial class car : UserControl
    {
        SqlConnection con = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Project1\Project1\ProjectTSP.mdf;Integrated Security = True; Connect Timeout = 30");
        SqlCommand command = new SqlCommand();
        carModel model = new carModel();
        trainsetModel _trainsetModel = new trainsetModel();

        public static int car_id { get; set; }
        public car()
        {
            InitializeComponent();
            FIllcombo();
        }

        private void car_Load(object sender, EventArgs e)
        {
            command.Connection = con;
            comboBox3.SelectedIndex = -1;
        }

        void FIllcombo()
        {
            con.Open();

            DataSet ds = new DataSet();
            SqlDataAdapter da1 = new SqlDataAdapter("SELECT * FROM TrainSetModel", con);
            da1.Fill(ds, "combolist");
            comboBox3.DataSource = ds;//กำหนด DataSet
            comboBox3.DisplayMember = "combolist.train_set_model_name";
            comboBox3.ValueMember = "combolist.train_set_model_id";
            con.Close();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox3.Text != "" & textBox4.Text != ""& comboBox3.Text!=""&comboBox4.Text!="")
            {
                con.Open();
                command.CommandText = "insert into Car (car_serial,seat_type,seat_capacity,train_set_model_id) values( ' " + textBox3.Text + " ',' " + comboBox4.Text + " ', '"+ textBox4.Text+"' , ' "+_trainsetModel.train_set_model_id+" ') ";
                command.ExecuteNonQuery();
                con.Close();
                model.car_id = 0;
                _trainsetModel.train_set_model_id = 0;
                MessageBox.Show("Save Complete");
                textBox1.Clear();
                textBox2.Clear();
                comboBox1.SelectedIndex = -1;
                comboBox2.SelectedIndex = -1;

            }
            else
            {
                MessageBox.Show("Plese enter data");
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox3.Clear();
            textBox4.Clear();
            comboBox4.SelectedIndex = -1;
            comboBox3.SelectedIndex = -1;
        
    }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                
                model.car_id = (int)row.Cells["car_id"].Value;
                model.car_serial = row.Cells["car_serial"].Value.ToString();
                textBox3.Text = row.Cells["car_serial"].Value.ToString();
                textBox4.Text = row.Cells["seat_capacity"].Value.ToString();
                comboBox4.Text = row.Cells["seat_type"].Value.ToString();
                comboBox3.Text = row.Cells["train_set_model_name"].Value.ToString();
                _trainsetModel.train_set_model_id = (int)row.Cells["train_set_model_id"].Value;
                _trainsetModel.train_set_model_name = row.Cells["train_set_model_name"].Value.ToString();
                dataGridView1.Columns[0].HeaderText = "SERIAL ID";
                dataGridView1.Columns[1].HeaderText = "SEAT TYPE";
                dataGridView1.Columns[2].HeaderText = "SEAT CAPACITY";
                dataGridView1.Columns[3].HeaderText = "TRAINSET MODEL NAME";

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox3.Text != "" & textBox4.Text != "" & comboBox4.Text != "" &comboBox3.Text!="")
            {
                con.Open();
                command.CommandText = "update Car set car_serial= ' "+textBox3.Text+ " ' ,seat_type=' " + comboBox4.Text + "',seat_capacity=' " + textBox4.Text + " '   ,train_set_model_id= '  "+ _trainsetModel.train_set_model_id + "   '  where car_id=' " +model.car_id + " '  ";
                command.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Edit Complete");
                model.car_id = 0;
                _trainsetModel.train_set_model_id = 0;
                    textBox1.Clear();
                textBox2.Clear();
                comboBox1.SelectedIndex = -1;
                comboBox2.SelectedIndex = -1;

            }
            else
            {
                MessageBox.Show("Plese enter data");
            }

           
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox3.Text != "" & textBox4.Text != "" & comboBox4.Text !="" & comboBox3.Text !="")
            {
                con.Open();
                command.CommandText = "delete from Car  where car_id=' " + model.car_id + " '  ";
                command.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Delete Complete");
                model.car_id = 0;
                _trainsetModel.train_set_model_id = 0;
                textBox1.Clear();
                textBox2.Clear();
                comboBox1.SelectedIndex = -1;
                comboBox2.SelectedIndex = -1;

            }
            else
            {
                MessageBox.Show("Plese select data");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            con.Open();
            String query = @"select car_id,car_serial,seat_type,seat_capacity,train_set_model_name,Car.train_set_model_id as train_set_model_id
                                    from Car
                                    inner join TrainSetModel on Car.train_set_model_id = TrainSetModel.train_set_model_id";
            SqlDataAdapter SDA = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            SDA.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].HeaderText = "SERIAL ID";
            dataGridView1.Columns[2].HeaderText = "SEAT TYPE";
            dataGridView1.Columns[3].HeaderText = "SEAT CAPACITY";
            dataGridView1.Columns[4].HeaderText = "TRAINSET MODEL NAME";
            dataGridView1.Columns[5].Visible = false;


            con.Close();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                var x = comboBox3.SelectedValue;

                if (x is int)
                {
                    _trainsetModel.train_set_model_id = (int)x;
                }



            }
            catch (Exception error)
            {
                throw error;
            }
        }
    }
}
