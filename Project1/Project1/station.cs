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
    public partial class station : UserControl
    {
        SqlConnection con = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Project1\Project1\ProjectTSP.mdf;Integrated Security = True; Connect Timeout = 30");
        SqlCommand command = new SqlCommand();
        stationModel model = new stationModel();
        
        public station()
        {
            InitializeComponent();
            FIllcombo();
        }

        private void station_Load(object sender, EventArgs e)
        {
            command.Connection = con;
            comboBox2.SelectedIndex = -1;

        }

        void FIllcombo()
        {
           con.Open();

            DataSet ds = new DataSet();
            SqlDataAdapter da1 = new SqlDataAdapter("SELECT * FROM Line", con);
            da1.Fill(ds, "combolist");
            comboBox2.DataSource = ds;//กำหนด DataSet
            comboBox2.DisplayMember = "combolist.line_name";
            comboBox2.ValueMember = "combolist.line_id";
            con.Close();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                var x = comboBox2.SelectedValue;
      
                if(x is int)
                {
                    model.line_id = (int) x;
                }
               
              
          
            }
            catch (Exception error) {
                throw error;
            }
           


        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != ""  & textBox3.Text!="" &comboBox1.Text!=""&comboBox2.Text!="")
            {
                con.Open();
                command.CommandText = "insert into Station (station_name,station_type,line_id,sequence) values( ' " + textBox1.Text + " ' , ' " +comboBox1.Text+" ' , '  " +model.line_id+" ' , ' " +textBox3.Text+ " ') ";
                command.ExecuteNonQuery();
                
                con.Close();
                MessageBox.Show("Save Complete");
                model.station_id = 0;
                model.line_id = 0;
                textBox1.Clear();
               
                textBox3.Clear();
                comboBox1.SelectedIndex = -1;
                comboBox2.SelectedIndex = -1;

            }
            else
            {
                MessageBox.Show("Plese enter data");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
         
            textBox3.Clear();
            comboBox1.SelectedIndex = -1;
            comboBox2.SelectedIndex = -1;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            con.Open();
            String query = @"select station_id,station_name,station_type,line_name,sequence,Station.line_id as line_id
                                    from Station
                                    inner join Line on Station.line_id = Line.line_id";
            SqlDataAdapter SDA = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            SDA.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].HeaderText = "STATION NAME";
            dataGridView1.Columns[2].HeaderText = "STATION TYPE";
            dataGridView1.Columns[3].HeaderText = "LINE NAME";
            dataGridView1.Columns[4].HeaderText = "SEQUENCE";
            dataGridView1.Columns[5].Visible = false;

            con.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                model.station_id = (int)row.Cells["station_id"].Value;
                textBox1.Text = row.Cells["station_name"].Value.ToString();
                comboBox1.Text = row.Cells["station_type"].Value.ToString();
                model.line_id = (int)row.Cells["line_id"].Value;

                comboBox2.Text = row.Cells["line_name"].Value.ToString();
                textBox3.Text = row.Cells["sequence"].Value.ToString();
                
                dataGridView1.Columns[0].HeaderText = "STATION NAME";
                dataGridView1.Columns[1].HeaderText = "STATION TYPE";
                dataGridView1.Columns[2].HeaderText = "LINE NAME";
                dataGridView1.Columns[3].HeaderText = "SEQUENCE";

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (model.station_id !=0)
            {
                con.Open();

                command.CommandText = "delete from Station  where station_id=' " + model.station_id + " '  ";
                command.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Delete Complete");
                textBox1.Clear();
                model.station_id = 0;
                textBox3.Clear();
                comboBox1.SelectedIndex = -1;
                comboBox2.SelectedIndex = -1;
                model.line_id = 0;


            }
            else
            {
                MessageBox.Show("Plese selected data");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != ""  & textBox3.Text != "" & comboBox1.Text != "" & comboBox2.Text != "")
            {
                con.Open();

                command.CommandText = "update Station set station_name=' " + textBox1.Text + " ' ,  station_type=' " + comboBox1.Text + " ' , line_id=' " + model.line_id + " ' , sequence=' " + textBox3.Text + " ' where station_id=' " + model.station_id + " '  ";
                command.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Edit Complete");
                model.station_id = 0;
                textBox1.Clear();
                model.line_id = 0;
                textBox3.Clear();
                comboBox1.SelectedIndex = -1;
                comboBox2.SelectedIndex = -1;


            }
            else
            {
                MessageBox.Show("Plese enter data");
            }
        }
    }
}
