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
    public partial class UC_Validmedicine : UserControl
    {
        funcation fn = new funcation();
        string query;
        DataSet ds;

        public UC_Validmedicine()
        {
            InitializeComponent();
        }

        private void UC_Validmedicine_Load(object sender, EventArgs e)
        {
            query = "select * from medicine";
            ds = fn.getData(query);
            dgv.DataSource = ds.Tables[0];
        }

        private void txtcheck_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtcheck.Text == "عرض الصلاحية المتاحة")
                {
                    query = "select * from medicine where convert(datetime, expiredate,101)  > getdate() ";
                    ds = fn.getData(query);
                    dgv.DataSource = ds.Tables[0];
                }
                else if (txtcheck.Text == "عرض الصلاحية المنتهية")
                {
                    query = "select * from medicine where convert(datetime, expiredate,101)  < getdate() ";
                    ds = fn.getData(query);
                    dgv.DataSource = ds.Tables[0];
                }
                else if (txtcheck.Text == "عرض الأدوية الباقى لها اقل من 30 يوم")
                {
                    query = "select * from medicine where (convert(datetime, expiredate,101)-getdate())<30 and (convert(datetime, expiredate,101)>getdate())";
                    ds = fn.getData(query);
                    dgv.DataSource = ds.Tables[0];
                }
                else
                {
                    UC_Validmedicine_Load(this, null);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnsync_Click(object sender, EventArgs e)
        {
            UC_Validmedicine_Load(null, null);
        }
    }
}
