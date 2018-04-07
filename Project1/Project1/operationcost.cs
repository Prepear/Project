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
    public partial class operationcost : UserControl
    {

        SqlConnection con = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Project1\Project1\ProjectTSP.mdf;Integrated Security = True; Connect Timeout = 30");
        SqlCommand command = new SqlCommand();
        operationcostModel model = new operationcostModel();
       
       


        public operationcost()
        {
            InitializeComponent();
            FIllcombo1();
            FIllcombo2();
            FIllcombo3();

        }

        private void operationcost_Load(object sender, EventArgs e)
        {
            command.Connection = con;

            comboBox1.SelectedIndex = -1;
            comboBox2.SelectedIndex = -1;
            comboBox3.SelectedIndex = -1;
            comboBox4.SelectedIndex = -1;
        }

        void FIllcombo1()
        {
            con.Open();

            DataSet ds = new DataSet();
            SqlDataAdapter da1 = new SqlDataAdapter("SELECT * FROM Station", con);
            da1.Fill(ds, "combolist");
            comboBox1.DataSource = ds;//กำหนด DataSet
            comboBox1.DisplayMember = "combolist.station_name";
            comboBox1.ValueMember = "combolist.station_id";
            con.Close();
        }

        void FIllcombo2()
        {
            con.Open();

            DataSet ds = new DataSet();
            SqlDataAdapter da2 = new SqlDataAdapter("SELECT * FROM Station", con);
            da2.Fill(ds, "combolist");
            comboBox2.DataSource = ds;//กำหนด DataSet
            comboBox2.DisplayMember = "combolist.station_name";
            comboBox2.ValueMember = "combolist.station_id";
            con.Close();
        }

        void FIllcombo3()
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

        private void button6_Click(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = -1;
            comboBox2.SelectedIndex = -1;
            comboBox3.SelectedIndex = -1;
            comboBox4.SelectedIndex = -1;
            textBox4.Clear();
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                var x = comboBox3.SelectedValue;

                if (x is int)
                {
                    model.train_set_model_id = (int)x;
                }



            }
            catch (Exception error)
            {
                throw error;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                var x = comboBox1.SelectedValue;
                
                if (x is int)
                {
                    model.station_id = (int)x;

                }



            }
            catch (Exception error)
            {
                throw error;
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                var y = comboBox2.SelectedValue;

                if (y is int)
                {
                    model.station_id2 = (int)y;
                }



            }
            catch (Exception error)
            {
                throw error;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (textBox4.Text != "" & comboBox1.Text != "" & comboBox2.Text != "" & comboBox3.Text != "" & comboBox4.Text != "")
            {
                con.Open();
                command.CommandText = @"insert into OperationCost (o_station,d_station,train_set_model_id,train_set_type,cost)  values( ' " + model.station_id + " ',' " + model.station_id2 + " ', '" + model.train_set_model_id + "' , ' " + comboBox4.Text + " ' , ' " + textBox4.Text + "  ') ";
                command.ExecuteNonQuery();
                con.Close();
               model.operation_cost_id = 0;
                model.train_set_model_id = 0;
                model.station_id = 0;
                MessageBox.Show("Save Complete");

                textBox4.Clear();
                comboBox1.SelectedIndex = -1;
                comboBox2.SelectedIndex = -1;
                comboBox3.SelectedIndex = -1;
                comboBox4.SelectedIndex = -1;

            }
            else
            {
                MessageBox.Show("Plese enter data");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox4.Text != "" & comboBox1.Text != "" & comboBox2.Text != "" & comboBox3.Text != "" & comboBox4.Text != "")
            {
                con.Open();
                 command.CommandText = "update OperationCost set o_station= ' " + model.station_id + " ' ,d_station=' " + model.station_id2 + " ' , train_set_model_id=' " + model.train_set_model_id + "' ,train_set_type= '  " + comboBox4.Text + "   ' , cost = ' "+textBox4.Text+ "    '  where operation_cost_id=' " + model.operation_cost_id + " '  ";
                command.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Edit Complete");
                model.operation_cost_id = 0;
                model.train_set_model_id = 0;
                model.station_id = 0;

                textBox4.Clear();
                comboBox1.SelectedIndex = -1;
                comboBox2.SelectedIndex = -1;
                comboBox3.SelectedIndex = -1;
                comboBox4.SelectedIndex = -1;

            }
            else
            {
                MessageBox.Show("Plese enter data");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox4.Text != "" & comboBox1.Text != "" & comboBox2.Text != "" & comboBox3.Text != "" & comboBox4.Text != "")
            {
                con.Open();
                 command.CommandText = "delete from OperationCost  where operation_cost_id=' " + model.operation_cost_id + " '  ";
                command.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Delete Complete");
                model.operation_cost_id = 0;
                model.train_set_model_id = 0;
               model.station_id = 0;


                textBox4.Clear();
                comboBox1.SelectedIndex = -1;
                comboBox2.SelectedIndex = -1;
                comboBox3.SelectedIndex = -1;
                comboBox4.SelectedIndex = -1;

            }
            else
            {
                MessageBox.Show("Plese select data");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            con.Open();
            String query = @"select operation_cost_id,a.station_name as origin ,b.station_name as destination,o_station ,
			d_station ,train_set_model_name,OperationCost.train_set_model_id as train_set_model_id,train_set_type,cost
          FROM OperationCost
		 JOIN  Station a ON  a.station_id = OperationCost.o_station
		 JOIN  Station b ON  b.station_id = OperationCost.d_station
		JOIN TrainSetModel ON TrainSetModel.train_set_model_id = OperationCost.train_set_model_id";
            SqlDataAdapter SDA = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            SDA.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].HeaderText = "ORIGIN ";
            dataGridView1.Columns[2].HeaderText = "DESTINATION ";
            dataGridView1.Columns[3].Visible = false;
            dataGridView1.Columns[4].Visible = false;
            dataGridView1.Columns[5].HeaderText = "TRAINSET MODEL";
            dataGridView1.Columns[6].Visible = false;
            dataGridView1.Columns[7].HeaderText = "TRAINSET TYPE";
            dataGridView1.Columns[8].HeaderText = "COST";


            con.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
                if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                
                   model.operation_cost_id = (int)row.Cells["operation_cost_id"].Value;
                   model.train_set_model_id = (int)row.Cells["train_set_model_id"].Value;
                   model.station_id = (int)row.Cells["o_station"].Value;
                model.station_id2 = (int)row.Cells["d_station"].Value;


                /*  DataGridView row = this.dataGridView1;
                  comboBox1.Text = row[1, e.RowIndex].Value.ToString();
                  comboBox2.Text = row[2, e.RowIndex].Value.ToString();
                  comboBox3.Text = row[5, e.RowIndex].Value.ToString();
                  comboBox4.Text = row[7, e.RowIndex].Value.ToString();
                  textBox4.Text = row[8, e.RowIndex].Value.ToString();*/


                comboBox1.Text = row.Cells["origin"].Value.ToString();
                comboBox2.Text = row.Cells["destination"].Value.ToString();
                 comboBox3.Text = row.Cells["train_set_model_name"].Value.ToString();
                 comboBox4.Text = row.Cells["train_set_type"].Value.ToString();
                 textBox4.Text = row.Cells["cost"].Value.ToString();

                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[1].HeaderText = "ORIGIN ";
                dataGridView1.Columns[2].HeaderText = "DESTINATION ";
                dataGridView1.Columns[3].Visible = false;
                dataGridView1.Columns[4].Visible = false;
                dataGridView1.Columns[5].HeaderText = "TRAINSET MODEL";
                dataGridView1.Columns[6].Visible = false;
                dataGridView1.Columns[7].HeaderText = "TRAINSET TYPE";
                dataGridView1.Columns[8].HeaderText = "COST";



            }
        }
    }
}
