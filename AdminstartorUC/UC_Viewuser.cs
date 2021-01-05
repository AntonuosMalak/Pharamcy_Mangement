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
    public partial class UC_Viewuser : UserControl
    {
        funcation fn = new funcation();
        string query;
        DataSet ds;
        string currentuser = "";

        public UC_Viewuser()
        {
            InitializeComponent();
        }

        public string id
        {
            set { currentuser = value; }
        }

        private void UC_Viewuser_Load(object sender, EventArgs e)
        {
            query = "select * from users";
            ds = fn.getData(query);
            dgv.DataSource = ds.Tables[0];
        }

        private void txtusername_TextChanged(object sender, EventArgs e)
        {
            query = "select * from users where username like '" + txtusername.Text + "%'";
            ds = fn.getData(query);
            dgv.DataSource = ds.Tables[0];
        }

        string username;

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                username = dgv.Rows[e.RowIndex].Cells[5].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("هل أنت متأكد", "إتمام الحذف", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                if (currentuser != username)
                {
                    query = "delete from users where username='" + username + "'";
                    fn.setData(query, "تم الحذف بنجاح.");
                    UC_Viewuser_Load(this, null);
                }
                else
                {
                    MessageBox.Show("أنت الان تحذف ملفك الشخصى", "Eroor", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btnsync_Click(object sender, EventArgs e)
        {
            UC_Viewuser_Load(this, null);
        }
    }
}
