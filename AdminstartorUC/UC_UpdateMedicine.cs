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
    public partial class UC_UpdateMedicine : UserControl
    {
        funcation fn = new funcation();
        DataSet ds;
        string query;

        public UC_UpdateMedicine()
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
            txtnumber.Clear();
            txtprice.Clear();
            txtqty.Clear();
            txtaddqty.Clear();
            dtexpire.ResetText();
            dtmanuf.ResetText();
        }

        private void btnsearch_Click(object sender, EventArgs e)
        {
            try
            {
                query = "select * from medicine where name like '" + txtname.Text + "%'";
                ds = fn.getData(query);
                txtid.Text = ds.Tables[0].Rows[0][0].ToString();
                txtnumber.Text = ds.Tables[0].Rows[0][2].ToString();
                dtmanuf.Text = ds.Tables[0].Rows[0][3].ToString();
                dtexpire.Text = ds.Tables[0].Rows[0][4].ToString();
                txtqty.Text = ds.Tables[0].Rows[0][5].ToString();
                txtprice.Text = ds.Tables[0].Rows[0][6].ToString();
                txtsuppler.Text = ds.Tables[0].Rows[0][7].ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("عذرا لا يوجد دواء بهذا الاسم", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txtqty_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = char.Parse(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyDecimalSeparator);
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != c)
                e.Handled = true;
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            try
            {
                string id = txtid.Text;
                string name = txtname.Text;
                string number = txtnumber.Text;
                string manuf = dtmanuf.Text;
                string expire = dtexpire.Text;
                int addqty = int.Parse(txtaddqty.Text);
                float price = float.Parse(txtprice.Text);
                try
                {
                    query = "update medicine set name='" + name + "', number='" + number + "',manufdate='" + manuf + "',expiredate='" + expire + "',qty+='" + addqty + "',price='" + price + "' where med_id='" + id + "'";
                    fn.setData(query, "تم تعديل بيانات المنتج بنجاح");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                ClearAll();
            }
            catch (Exception)
            {
                MessageBox.Show("رجاء اكمال بيانات الادخال", "Asterisk", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }
    }
}
