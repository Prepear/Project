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

namespace Project1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void cOMPONANTToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void rAILWAYINFRASTUCTUREToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void lINEToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void rAILWAYINFRASTUCTUREToolStripMenuItem_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            string menu = e.ClickedItem.Text;
            this.panel1.Controls.Clear();
            switch (menu)
            {
                case "LINE":
                    var ctr1 = new line();
                    this.panel1.Controls.Add(ctr1);
                    break;
                 case "STATION":
                    var ctr2 = new station();
                    this.panel1.Controls.Add(ctr2);
                    break;
            }

        }

        private void rOLLINGSTOCKToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void rOLLINGSTOCKToolStripMenuItem_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            string menu = e.ClickedItem.Text;
            this.panel1.Controls.Clear();
            switch (menu)
            {
                case "CAR STOCK":
                    var ctr1 = new car();
                    this.panel1.Controls.Add(ctr1);
                    break;
                     case "TRAIN SET":
                         var ctr2 = new trainset();
                         this.panel1.Controls.Add(ctr2);
                         break;
            }
        }

        private void sERVICEROUTEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void cOMPONANTToolStripMenuItem_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            string menu = e.ClickedItem.Text;
            this.panel1.Controls.Clear();
            switch (menu)
            {
                case "SERVICE ROUTE":
                    var ctr1 = new serviceroute();
                    this.panel1.Controls.Add(ctr1);
                    break;
                case "OPERATION COST":
                    var ctr2 = new operationcost();
                    this.panel1.Controls.Add(ctr2);
                    break;

            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
