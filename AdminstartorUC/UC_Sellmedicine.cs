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
    public partial class UC_Sellmedicine : UserControl
    {
        funcation fn = new funcation();
        DataSet ds;
        string query;
        int bill = 0;

        public UC_Sellmedicine()
        {
            InitializeComponent();
        }

        private void btnsync_Click(object sender, EventArgs e)
        {
            ClearAll();
            dgv.Rows.Clear();
        }

        // reset texts
        private void ClearAll()
        {
            txtid.Clear();
            txtname.Clear();
            txtprice.Clear();
            txtqty.Clear();
            txtexpire.ResetText();
            txtsaerch.Clear();
        }

        private void UC_Sellmedicine_Load(object sender, EventArgs e)
        {
            btnadd.Enabled = false;
            btnremove.Enabled = false;
            btnsell.Enabled = false;
            try
            {
                query = "select name from medicine where convert(datetime, expiredate,101)  > getdate()";
                ds = fn.getData(query);
                dgvnames.DataSource = ds.Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtsaerch_TextChanged(object sender, EventArgs e)
        {
            query = "select name from medicine where convert(datetime, expiredate,101)  > getdate() and name like '" + txtsaerch.Text + "%'";
            ds = fn.getData(query);
            dgvnames.DataSource = ds.Tables[0];
        }

        private void dgvnames_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            query = "select * from medicine where name like '" + dgvnames.CurrentRow.Cells[0].Value.ToString() + "%'";
            ds = fn.getData(query);
            txtid.Text = ds.Tables[0].Rows[0][0].ToString();
            txtname.Text = ds.Tables[0].Rows[0][1].ToString();
            txtexpire.Text = ds.Tables[0].Rows[0][4].ToString();
            txtprice.Text = ds.Tables[0].Rows[0][6].ToString();
        }

        private void txtqty_TextChanged(object sender, EventArgs e)
        {
            string qty = "";
            if(txtqty.Text != string.Empty)
            {
                query = "select qty from medicine where name='" + txtname.Text + "'";
                ds = fn.getData(query);
                qty = ds.Tables[0].Rows[0][0].ToString();
            }
            if (txtqty.Text == string.Empty)
            {
                txtall.Text = "";
            }
            else if(int.Parse(txtqty.Text) <= 0)
            {
                MessageBox.Show("يجب ادخال كمية صحيحة موجبة.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtqty.Clear();
                txtall.Clear();
                txtqty.Focus();
            }
            else if(int.Parse(qty) < int.Parse(txtqty.Text))
            {
                MessageBox.Show("عذرا الكمية المتاحة تساوى  " + qty + "", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtqty.Clear();
                txtall.Clear();
                txtqty.Focus();
            }
            else
            {
                txtall.Text = (int.Parse(txtqty.Text) * int.Parse(txtprice.Text)).ToString();
            }
            btnadd.Enabled = true;
        }

        private void txtqty_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = char.Parse(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyDecimalSeparator);
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != c)
                e.Handled = true;
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            try
            {
                int qty = int.Parse(txtqty.Text);
                query = "update medicine set qty-='" + qty + "' where name='" + txtname.Text + "'";
                fn.setData(query);
                dgv.Rows.Add(txtid.Text, txtname.Text, txtexpire.Text, txtprice.Text, txtqty.Text, txtall.Text);
                bill += int.Parse(txtall.Text);
                txtbill.Text = bill.ToString();
                btnremove.Enabled = true;
                btnsell.Enabled = true;
                ClearAll();
            }
            catch (Exception)
            {
                MessageBox.Show("رجاء اكمال اختيار دواء.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnremove_Click(object sender, EventArgs e)
        {
            try
            {
                int qty = int.Parse(dgv.CurrentRow.Cells[4].Value.ToString());
                string medicine = dgv.CurrentRow.Cells[1].Value.ToString();
                if (MessageBox.Show("هل أنت متأكد", "إتمام الحذف", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {

                    query = "update medicine set qty+='" + qty + "'";
                    fn.setData(query);
                    dgv.Rows.RemoveAt(dgv.SelectedRows[0].Index);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnsell_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();
            ClearAll();
            dgv.Rows.Clear();
            bill = 0;
            txtbill.Text = "RS. 00";
            UC_Sellmedicine_Load(null, null);
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            DateTime dt = DateTime.Now;
            Bitmap bm = new Bitmap(this.dgv.Width, this.dgv.Height);
            dgv.DrawToBitmap(bm, new Rectangle(0, 0, this.dgv.Width, this.dgv.Height));
            e.Graphics.DrawImage(bm, 23, 100);
            e.Graphics.DrawString(("The Bill in date " + dt), new Font("verdana", 16, FontStyle.Bold), Brushes.DarkBlue, new Point(200, 20));
            e.Graphics.DrawString("Pharamcy Mangement System", new Font("verdana", 16, FontStyle.Bold), Brushes.DarkBlue, new Point(240, 40));
            e.Graphics.DrawString(("RS. " + txtbill.Text), new Font("verdana", 22, FontStyle.Bold), Brushes.DarkRed, new Point(350, 1000));
        }
    }
}
