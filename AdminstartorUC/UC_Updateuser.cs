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
    public partial class UC_Updateuser : UserControl
    {
        funcation fn = new funcation();
        DataSet ds;
        string query;

        public UC_Updateuser()
        {
            InitializeComponent();
        }

        private void btnreset_Click(object sender, EventArgs e)
        {
            ClearAll();
        }

        // reset texts
        private void ClearAll()
        {
            txtid.Clear();
            txtname.Clear();
            txtmobilenumber.Clear();
            txtusername.Clear();
            txtuserrole.ResetText();
            txtpassword.Clear();
            txtdob.ResetText();
        }

        private void btnsearch_Click(object sender, EventArgs e)
        {
            try
            {
                query = "select * from users where name like '" + txtname.Text + "%'";
                ds = fn.getData(query);
                txtid.Text = ds.Tables[0].Rows[0][0].ToString();
                txtuserrole.Text = ds.Tables[0].Rows[0][1].ToString();
                txtdob.Text = ds.Tables[0].Rows[0][3].ToString();
                txtmobilenumber.Text = ds.Tables[0].Rows[0][4].ToString();
                txtusername.Text = ds.Tables[0].Rows[0][5].ToString();
                txtpassword.Text = ds.Tables[0].Rows[0][6].ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("لا يوجد مستخدم بهذا الاسم", "Asterisk", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void txtmobilenumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = char.Parse(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyDecimalSeparator);
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != c)
                e.Handled = true;
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(txtid.Text);
                string role = txtuserrole.Text;
                string name = txtname.Text;
                string dob = txtdob.Text;
                int mobile = int.Parse(txtmobilenumber.Text);
                string username = txtusername.Text;
                string password = txtpassword.Text;
                try
                {
                    query = "update users set userRole='" + role + "', name='" + name + "',dob='" + dob + "',mobile='" + mobile + "',username='" + username + "',pass='" + password + "' where id='" + id + "'";
                    fn.setData(query, "تم التعديل بنجاح.");
                }
                catch (Exception)
                {
                    MessageBox.Show("Username Aleardy exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                ClearAll();
            }
            catch (Exception)
            {
                MessageBox.Show("رجاء اكمال بيانات الادخال", "Asterisk", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void txtusername_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
