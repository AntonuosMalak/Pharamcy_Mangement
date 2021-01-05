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
    public partial class Adminstrator : Form
    {
        string user = "";

        public Adminstrator()
        {
            InitializeComponent();
        }

        public string id
        {
            get { return user.ToString(); }
        }

        public Adminstrator(string username)
        {
            InitializeComponent();
            lblusername.Text = username;
            user = username;
            uC_Viewuser1.id = id;
        }

        private void btnlogout_Click(object sender, EventArgs e)
        {
            Sign fm = new Sign();
            fm.Show();
            this.Hide();
        }

        private void btndashbord_Click(object sender, EventArgs e)
        {
            uC_Dachbord1.Visible = true;
            uC_Dachbord1.BringToFront();
        }

        private void Adminstrator_Load(object sender, EventArgs e)
        {
            uC_Dachbord1.Visible = false;
            uC_AddUser1.Visible = false;
            uC_Viewuser1.Visible = false;
            uC_Updateuser1.Visible = false;
            uC_Suppler1.Visible = false;
            btndashbord.PerformClick();
        }

        private void btnadduser_Click(object sender, EventArgs e)
        {
            uC_AddUser1.Visible = true;
            uC_AddUser1.BringToFront();
        }

        private void btnviewuser_Click(object sender, EventArgs e)
        {
            uC_Viewuser1.Visible = true;
            uC_Viewuser1.BringToFront();
        }

        private void btnprofile_Click(object sender, EventArgs e)
        {
            uC_Updateuser1.Visible = true;
            uC_Updateuser1.BringToFront();
        }

        private void btnaddsuppler_Click(object sender, EventArgs e)
        {
            uC_Suppler1.Visible = true;
            uC_Suppler1.BringToFront();
        }
    }
}
