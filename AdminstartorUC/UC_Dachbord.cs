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
    public partial class UC_Dachbord : UserControl
    {
        funcation fn = new funcation();
        string query;
        DataSet ds;

        public UC_Dachbord()
        {
            InitializeComponent();
        }

        private void UC_Dachbord_Load(object sender, EventArgs e)
        {
            query = "select count(userRole) from users where userRole = 'Adminstrator'";
            ds = fn.getData(query);
            setlabel(ds, lbladmin);

            query = "select count(userRole) from users where userRole = 'Pharmacist'";
            ds = fn.getData(query);
            setlabel(ds, lblpharma);
        }

        private void setlabel(DataSet ds, Label lbl)
        {
            if (ds.Tables[0].Rows.Count != 0)
            {
                lbl.Text = ds.Tables[0].Rows[0][0].ToString();
            }
            else
            {
                lbl.Text = "0";
            }
        }

        private void btnsync_Click(object sender, EventArgs e)
        {
            UC_Dachbord_Load(null, null);
        }
    }
}
