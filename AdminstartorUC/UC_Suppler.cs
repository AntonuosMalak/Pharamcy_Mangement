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
    public partial class UC_Suppler : UserControl
    {
        funcation fn = new funcation();
        string query;
        public UC_Suppler()
        {
            InitializeComponent();
        }

        private void ClearAll()
        {
            txtname.Clear();
            txtmobilenumber.Clear();
            txttotalincome.Clear();
            txtmod.Clear();
        }
        private void btnreset_Click(object sender, EventArgs e)
        {
            ClearAll();
        }

        private void btnsignup_Click(object sender, EventArgs e)
        {
            try
            {
                string name = txtname.Text;
                int mobile = int.Parse(txtmobilenumber.Text);
                int total = int.Parse(txttotalincome.Text);
                int mod = int.Parse(txtmod.Text);
                try
                {
                    query = "insert into supplers (name,mobile,total,mod) values ('" + name + "', '" + mobile + "', '" + total + "','" + mod + "')";
                    fn.setData(query, "Sign Up Successful.");
                    ClearAll();
                }
                catch (Exception)
                {
                    MessageBox.Show("الاسم موجود بالفعل", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("رجاء اكمال بيانات الادخال", "Asterisk", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void txtmobilenumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = char.Parse(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyDecimalSeparator);
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != c)
                e.Handled = true;
        }

        private void txtname_TextChanged(object sender, EventArgs e)
        {
            query = "select * from supplers where name='" + txtname.Text + "'";
            DataSet ds = fn.getData(query);

            if (ds.Tables[0].Rows.Count == 0)
            {
                pictureBox2.Image = Properties.Resources.yes;
            }
            else
            {
                pictureBox2.Image = Properties.Resources.no;
                MessageBox.Show("الاسم موجود بالفعل", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtname.Focus();
            }
        }
    }
}