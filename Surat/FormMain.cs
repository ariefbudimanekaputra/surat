using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;

namespace Surat
{
    public partial class FormMain : DevComponents.DotNetBar.OfficeForm
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void buttonLogout_Click(object sender, EventArgs e)
        {
            FormLogin login = new FormLogin();
            this.Hide();
            login.Show();
        }

        private void buttonKlasifikasiSurat_Click(object sender, EventArgs e)
        {
            FormKlasifikasiSurat klasifikasi = new FormKlasifikasiSurat();
            klasifikasi.Show();
        }

        private void buttonBidang_Click(object sender, EventArgs e)
        {
            FormBidang bidang = new FormBidang();
            bidang.Show();
        }



    }
}