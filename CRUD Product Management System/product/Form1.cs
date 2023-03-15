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

namespace product
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                abccomm dbase = new abccomm();
                lbl.ForeColor = Color.PowderBlue;
            }
            catch
            {
                lbl.ForeColor = Color.Red;
            }


        }

        private void Save_Click(object sender, EventArgs e)
        {
            abccomm dtbase = new abccomm();
            string sql = "insert into  abc  values ('" + txtid.Text + "', '" + txtdescription.Text + "','" + txtunit.Text + "','" + txtstocks.Text + "')";
            if (dtbase.CUDCmd(sql) > 0)
                MessageBox.Show("Inserted Successfully");
            else
                MessageBox.Show("Error");


            //database dbase = new database();
            string nsql = "select * from  abc";
            dataGridView1.DataSource = dtbase.SelectCmd(nsql);

            txtid.Clear();
            txtdescription.Clear();
            txtunit.Clear();
            txtstocks.Clear();

        }

        private void Update_Click(object sender, EventArgs e)
        {
            abccomm dtbase = new abccomm();
            string sql = "update abc set proID = '" + txtnewid.Text + "'where proID = '" + txtid.Text + "'";
            if (dtbase.CUDCmd(sql) > 0)
                MessageBox.Show("Updated Successfully");
            else
                MessageBox.Show("Error");

            string nsql = "select * from  abc";
            dataGridView1.DataSource = dtbase.SelectCmd(nsql);
            txtid.Clear();
            txtdescription.Clear();
            txtunit.Clear();
            txtstocks.Clear();
   

        }

        private void Delete_Click(object sender, EventArgs e)
        {

            abccomm dtbase = new abccomm();
            string sql = "delete from  abc where proID = '" + txtid.Text + "'";
            if (dtbase.CUDCmd(sql) > 0)
                MessageBox.Show("Deleted Successfully");
            else
                MessageBox.Show("Error");

            string nsql = "select * from  abc";
            dataGridView1.DataSource = dtbase.SelectCmd(nsql);
            txtid.Clear();
            txtdescription.Clear();
            txtunit.Clear();
            txtstocks.Clear();
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            txtid.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            txtdescription.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            txtunit.Text = dataGridView1.SelectedRows[1].Cells[2].Value.ToString();
            txtstocks.Text = dataGridView1.SelectedRows[2].Cells[3].Value.ToString();
        }

        private void Search_Click(object sender, EventArgs e)
        {

            abccomm dtbase = new abccomm();
            string sql = "select * from abc where  proID = '" + txtsearch.Text + "'";
            dataGridView1.DataSource = dtbase.SelectCmd(sql);
        }
    }
}
