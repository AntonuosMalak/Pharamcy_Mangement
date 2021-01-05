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
    public partial class UC_AddMedicine : UserControl
    {
        funcation fn = new funcation();
        DataSet ds;
        string query;

        public UC_AddMedicine()
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
            txtname.Clear();
            txtnumber.Clear();
            txtprice.Clear();
            txtqty.Clear();
            dtexpire.ResetText();
            dtmanuf.ResetText();
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            try
            {
                string name = txtname.Text;
                string number = txtnumber.Text;
                string manuf = dtmanuf.Text;
                string expire = dtexpire.Text;
                int qty = int.Parse(txtqty.Text);
                float price = float.Parse(txtprice.Text);
                string sup_name = txtsuppler.Text;
                try
                {
                    query = "insert into medicine (name,number,manufdate,expiredate,qty,price,sup_name) values ('" + name + "','" + number + "', '" + manuf + "', '" + expire + "','" + qty + "', '" + price + "','" + sup_name + "')";
                    fn.setData(query, "تم إضافة المنتج بنجاح");
                }
                catch (Exception)
                {
                    MessageBox.Show("الدواء موجود.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                ClearAll();
            }
           catch(Exception)
            {
                MessageBox.Show("رجاء اكمال بيانات الادخال", "Asterisk", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void txtname_TextChanged(object sender, EventArgs e)
        {
            query = "select * from medicine where name='" + txtname.Text + "'";
            DataSet ds = fn.getData(query);

            if (ds.Tables[0].Rows.Count == 0)
            {
                pictureBox1.Image = Properties.Resources.yes;
            }
            else
            {
                pictureBox1.Image = Properties.Resources.no;
            }
        }

        private void txtqty_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = char.Parse(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyDecimalSeparator);
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != c)
                e.Handled = true;
        }

        private void UC_AddMedicine_Load(object sender, EventArgs e)
        {
            try
            {
                query = "select sup_name from supplers";
                ds = fn.getData(query);
                dgv.DataSource = ds.Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            query = "select sup_name from supplers where sup_name like '" + dgv.CurrentRow.Cells[0].Value.ToString() + "%'";
            ds = fn.getData(query);
            txtsuppler.Text = ds.Tables[0].Rows[0][0].ToString();
        }

        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            query = "select sup_name from supplers where sup_name like '" + txtsearch.Text + "%'";
            ds = fn.getData(query);
            dgv.DataSource = ds.Tables[0];
        }
    }
}
