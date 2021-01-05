using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pharamcy_Mangement.AdminstartorUC
{
    public partial class UC_AddUser : UserControl
    {
        funcation fn = new funcation();
        string query;

        public UC_AddUser()
        {
            InitializeComponent();
        }

        private void btnsignup_Click(object sender, EventArgs e)
        {
            try
            {
                string role = txtuserrole.Text;
                string name = txtname.Text;
                string dob = txtdob.Text;
                int mobile = int.Parse(txtmobilenumber.Text);
                string username = txtusername.Text;
                string password = txtpassword.Text;
                try
                {
                    query = "insert into users (userRole,name,dob,mobile,username,pass) values ('" + role + "','" + name + "', '" + dob + "', '" + mobile + "', '" + username + "','" + password + "')";
                    fn.setData(query, "Sign Up Successful.");
                    ClearAll();
                }
                catch (Exception)
                {
                    MessageBox.Show("اسم المستخدم موجود بالفعل", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("رجاء اكمال بيانات الادخال", "Asterisk", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void btnreset_Click(object sender, EventArgs e)
        {
            ClearAll();
        }

        // reset all items
        public void ClearAll()
        {
            txtname.Clear();
            txtdob.ResetText();
            txtmobilenumber.Clear();
            txtpassword.Clear();
            txtusername.Clear();
            txtuserrole.SelectedIndex = -1;
            pictureBox1.Hide();
        }

        private void txtmobilenumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = char.Parse(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyDecimalSeparator);
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != c)
                e.Handled = true;
        }

        private void txtusername_TextChanged(object sender, EventArgs e)
        {
            query = "select * from users where username='" + txtusername.Text + "'";
            DataSet ds = fn.getData(query);

            if (ds.Tables[0].Rows.Count == 0)
            {
                pictureBox1.Image = Properties.Resources.yes;
            }
            else
            {
                pictureBox1.Image = Properties.Resources.no;
                MessageBox.Show("اسم المستخدم موجود بالفعل", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtusername.Focus();
            }
        }
    }
}
