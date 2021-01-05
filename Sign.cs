using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pharamcy_Mangement
{
    public partial class Sign : Form
    {
        funcation fn = new funcation();
        string query;
        DataSet ds;

        public Sign()
        {
            InitializeComponent();
        }

        //Exit Application
        private void btncancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // Minimized Application
        private void btnmin_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnreset_Click(object sender, EventArgs e)
        {
            txtusername.Clear();
            txtpassword.Clear();
        }

        private void btnsignin_Click(object sender, EventArgs e)
        {

            try
            {
                query = "select * from users";
                ds = fn.getData(query);
                if (ds.Tables[0].Rows.Count == 0)
                {
                    if (txtusername.Text == "root" && txtpassword.Text == "root")
                    {
                        Adminstrator admin = new Adminstrator();
                        admin.Show();
                        this.Hide();
                    }
                }
                else
                {
                    query = "select * from users where username ='" + txtusername.Text + "' and pass='" + txtpassword.Text + "'";
                    ds = fn.getData(query);
                    if (ds.Tables[0].Rows.Count != 0)
                    {
                        string role = ds.Tables[0].Rows[0][1].ToString();
                        if (role == "Adminstrator")
                        {
                            Adminstrator admin = new Adminstrator(txtusername.Text);
                            admin.Show();
                            this.Hide();
                        }
                        else if (role == "Pharmacist")
                        {
                            Pharmacist phram = new Pharmacist();
                            phram.Show();
                            this.Hide();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Wrong user name or password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
