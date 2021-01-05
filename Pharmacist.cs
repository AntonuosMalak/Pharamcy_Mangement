using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pharamcy_Mangement
{
    public partial class Pharmacist : Form
    {
        public Pharmacist()
        {
            InitializeComponent();
        }

        private void Pharmacist_Load(object sender, EventArgs e)
        {
            uC_AddMedicine1.Visible = false;
            uC_Sellmedicine1.Visible = false;
            uC_UpdateMedicine1.Visible = false;
            uC_Validmedicine1.Visible = false;
            uC_ViwerMedicine1.Visible = false;
        }

        private void btnaddmedicine_Click(object sender, EventArgs e)
        {
            uC_AddMedicine1.Visible = true;
            uC_AddMedicine1.BringToFront();
        }

        private void btnviewmedicine_Click(object sender, EventArgs e)
        {
            uC_ViwerMedicine1.Visible = true;
            uC_ViwerMedicine1.BringToFront();
        }

        private void btnupdatemedicine_Click(object sender, EventArgs e)
        {
            uC_UpdateMedicine1.Visible = true;
            uC_UpdateMedicine1.BringToFront();
        }

        private void btnvalidmedicine_Click(object sender, EventArgs e)
        {
            uC_Validmedicine1.Visible = true;
            uC_Validmedicine1.BringToFront();
        }

        private void btnsellmedicine_Click(object sender, EventArgs e)
        {
            uC_Sellmedicine1.Visible = true;
            uC_Sellmedicine1.BringToFront();
        }

        private void btnlogout_Click(object sender, EventArgs e)
        {
            Sign frm = new Sign();
            this.Hide();
            frm.Show();
        }
    }
}
