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
    public partial class serviceroute : UserControl
    {
        SqlConnection con = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Project1\Project1\ProjectTSP.mdf;Integrated Security = True; Connect Timeout = 30");
        SqlCommand command = new SqlCommand();
        servicerouteModel model = new servicerouteModel();
        

        public serviceroute()
        {
            InitializeComponent();
        }

        private void serviceroute_Load(object sender, EventArgs e)
        {
            command.Connection = con;
            FIllcombo();
            comboBox2.SelectedIndex = -1;
            FIllchecklist();
            

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

        private void button1_Click(object sender, EventArgs e)
        {
            if ( textBox1.Text != "" & checkedListBox1.Text!="" & comboBox2.Text != "")
            {
                con.Open();
             //   command.CommandText = "insert into ServiceRoute (service_route_name,line_id,station_id) values( ' " + textBox1.Text + " ',' " + model.line_id + " ', '" + model.station_id + " ' ) ";
                command.ExecuteNonQuery();
                con.Close();
               // model.car_id = 0;
              //  model.train_set_model_id = 0;
                MessageBox.Show("Save Complete");
                textBox1.Clear();
              //  textBox2.Clear();
              //  comboBox1.SelectedIndex = -1;
                comboBox2.SelectedIndex = -1;
              


                foreach (int i in checkedListBox1.CheckedIndices)
                {
                    checkedListBox1.SetItemCheckState(i, CheckState.Unchecked);
                }


            }
            else
            {
                MessageBox.Show("Plese enter data");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            comboBox2.SelectedIndex = -1;
            foreach (int i in checkedListBox1.CheckedIndices)
            {
                checkedListBox1.SetItemCheckState(i, CheckState.Unchecked);
            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           /* if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                model.car_id = (int)row.Cells["car_id"].Value;
                textBox2.Text = row.Cells["car_serial"].Value.ToString();
                textBox1.Text = row.Cells["seat_capacity"].Value.ToString();
                comboBox1.Text = row.Cells["seat_type"].Value.ToString();
                comboBox2.Text = row.Cells["train_set_model_name"].Value.ToString();
                _trainsetModel.train_set_model_id = (int)row.Cells["train_set_model_id"].Value;
                dataGridView1.Columns[0].HeaderText = "SERIAL ID";
                dataGridView1.Columns[1].HeaderText = "SEAT TYPE";
                dataGridView1.Columns[2].HeaderText = "SEAT CAPACITY";
                dataGridView1.Columns[3].HeaderText = "TRAINSET MODEL NAME";

            }*/
        }

        private void button5_Click(object sender, EventArgs e)
        {
            /*con.Open();
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


            con.Close();*/
        }

        private void button4_Click(object sender, EventArgs e)
        {
           /* if (textBox2.Text != "" & textBox1.Text != "" & comboBox1.Text != "" & comboBox2.Text != "")
            {
                con.Open();
                command.CommandText = "delete from Car  where car_id=' " + model.car_id + " '  ";
                command.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Delete Complete");
                model.car_id = 0;
                model.train_set_model_id = 0;
                textBox1.Clear();
                textBox2.Clear();
                comboBox1.SelectedIndex = -1;
                comboBox2.SelectedIndex = -1;

            }
            else
            {
                MessageBox.Show("Plese select data");
            }*/
        }

        private void button3_Click(object sender, EventArgs e)
        {
            /*if (textBox2.Text != "" & textBox1.Text != "" & comboBox1.Text != "" & comboBox2.Text != "")
            {
                con.Open();
                command.CommandText = "update Car set car_serial= ' " + textBox2.Text + " ' ,seat_capacity=' " + textBox1.Text + " ' , seat_type=' " + comboBox1.Text + "' ,train_set_model_id= '  " + model.train_set_model_id + "   '  where car_id=' " + model.car_id + " '  ";
                command.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Edit Complete");
                model.car_id = 0;
                model.train_set_model_id = 0;
                textBox1.Clear();
                textBox2.Clear();
                comboBox1.SelectedIndex = -1;
                comboBox2.SelectedIndex = -1;

            }
            else
            {
                MessageBox.Show("Plese enter data");
            }*/
        }

        /*  private void fill_checkListBox()
          {


              try
              {
                  con.Open();

                  //for reading purpose, I break down by long statement 
                  //In this statement, I left join 3 table (Teacher_Detail,  AppUser_Detail, and Application_Detail table). My AppUser_Detail contains all 3 id (teacherId, applicationId, and AppUserId). I then set filter the table using `where` keyWord to make the applicationId = the comboBox text 

                  string query = @"SELECT
                                    td.chineseName,
                                    ad.applicationId,
                                    aud.applicationId,
                                    ad.applicationName
                                FROM[AppUser_Detail] as aud
                                LEFT JOIN[Teacher_Detail] as td
                                ON aud.teacherId = td.teacherId
                                LEFT JOIN[Application_Detail] as ad
                                ON aud.applicationId = ad.applicationId
                                where aud.applicationId = '" + applicationComboBox.Text + "' AND NOT(td.teacherId IS NULL)
  ";
                  myCommand = new SqlCommand(query, con);


                  //reading the value from the query
                  SqlDataReader dr = myCommand.ExecuteReader();

                  //Reading all the value one by one
                  while (dr.Read())
                  {
                      //column is 0 where the teacherName belong in my Teacher_Detail table

                      string name = dr.GetString(0);

                      //I tried to set the text of the checkListBox as the teacherName, but I can't somehow
                      teacherCheckListBox.Text = name;

                  }
                  con.Close();
              }
              catch (Exception ex)
              {
                  MessageBox.Show(ex.Message);
              }
          }*/
        void FIllchecklist()
        {

            con.Open();

            DataSet ds = new DataSet();
            SqlDataAdapter da1 = new SqlDataAdapter("SELECT * FROM Station", con);
            da1.Fill(ds, "checklist");
            checkedListBox1.DataSource = ds;//กำหนด DataSet
            checkedListBox1.DisplayMember = "checklist.station_name";
            checkedListBox1.ValueMember = "checklist.station_id";
            con.Close();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                var x = comboBox2.SelectedValue;
                if(x  is int)
                {
                    checkedListBox1.Items.Clear();
                    checkedListBox1.Items.Add(x);

                
                    string query = @"SELECT
                                station_name,station_id
                                FROM Station,Line
                                where line_id = '" + comboBox2.Text + " ' " ;
                }

                if (x is int)

                {
                    model.line_id = (int)x;
                }

            }
            catch (Exception error)
            {
                throw error;
            }
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
