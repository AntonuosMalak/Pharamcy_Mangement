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
    public partial class UC_ViewMedicine : UserControl
    {
        funcation fn = new funcation();
        string query;
        DataSet ds;

        public UC_ViewMedicine()
        {
            InitializeComponent();
        }

        private void UC_ViwerMedicine_Load(object sender, EventArgs e)
        {
            query = "select * from medicine";
            ds = fn.getData(query);
            dgv.DataSource = ds.Tables[0];
        }

        private void txtmedicine_TextChanged(object sender, EventArgs e)
        {
            query = "select * from medicine where name like '" + txtmedicine.Text + "%'";
            ds = fn.getData(query);
            dgv.DataSource = ds.Tables[0];
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            string medicine = dgv.CurrentRow.Cells[1].Value.ToString();
            if (MessageBox.Show("هل أنت متأكد", "إتمام الحذف", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                query = "delete from medicine where name='" + medicine + "'";
                fn.setData(query, "تم الحذف بنجاح.");
                UC_ViwerMedicine_Load(this, null);
            }
        }

        private void btnsync_Click(object sender, EventArgs e)
        {
            UC_ViwerMedicine_Load(this, null);
        }
    }
}
