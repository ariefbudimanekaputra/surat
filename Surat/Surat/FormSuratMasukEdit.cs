using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using DevComponents.DotNetBar;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace Surat
{
    public partial class FormSuratMasukEdit : DevComponents.DotNetBar.OfficeForm
    {
        private string query, strconn;
        private string nomor_surat, perihal, tanggal_surat, tanggal_terima, 
                        id_jenis, jenis_surat, sifat_surat, pengirim, alamat_pengirim, 
                        penerima, jabatan_tertanda, tertanda, distribusi_tanggal, 
                        isi_singkat, keterangan, gambar_surat, lokasi_gambar, nama_gambar, bidang;
        private readonly FormSuratMasuk frm1;

        public FormSuratMasukEdit(FormSuratMasuk frm)
        {
            InitializeComponent();
            frm1 = frm;
        }

        private bool cekValid()
        {
            bool error = false;
            if (textBoxNomorSuratMasuk.Text == "")
            {
                error = true;
                MessageBox.Show("Nomor surat belum diisi. Penyimpanan data dibatalkan.", "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxNomorSuratMasuk.Focus();
            }
            return error;
        }

        private void getDistribusi()
        {
            Database db = new Database();
            strconn = db.getString();
            MySqlConnection conn = new MySqlConnection(strconn);
            conn.Open();
            try
            {
                query = "SELECT nomor_surat_masuk, detail_bagian_bidang_surat_masuk.id_bagian_bidang, bagian_bidang.nama_bagian_bidang AS nama FROM detail_bagian_bidang_surat_masuk JOIN bagian_bidang USING(id_bagian_bidang) "+
                        "WHERE  detail_bagian_bidang_surat_masuk.nomor_surat_masuk = @nomor_surat";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@nomor_surat", nomor_surat);
                MySqlDataReader reader = cmd.ExecuteReader();
                
                while (reader.Read())
                {
                    if (reader["nama"].ToString().Equals("Tata Usaha"))
                    {
                        checkBoxTataUsaha.Checked = true;
                    }
                    if (reader["nama"].ToString().Equals("Programa Siaran"))
                    {
                        checkBoxProgramaSiaran.Checked = true;
                    }
                    if (reader["nama"].ToString().Equals("Pemberitaan"))
                    {
                        checkBoxPemberitaan.Checked = true;
                    }
                    if (reader["nama"].ToString().Equals("Teknologi dan Media Baru"))
                    {
                        checkBoxTeknologi.Checked = true;
                    }
                    if (reader["nama"].ToString().Equals("Layanan dan Pengembangan"))
                    {
                        checkBoxLayanan.Checked = true;
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            conn.Close();
        }

        private void getAllJenisSurat()
        {
            Database db = new Database();
            strconn = db.getString();
            MySqlConnection conn = new MySqlConnection(strconn);
            conn.Open();
            query = "SELECT nama_jenis FROM jenis_surat";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                comboBoxJenisSuratMasuk.Items.Add(reader[0]);
            }
            conn.Close();
        }

        private void getJenisSurat(string id_jenis)
        {
            Database db = new Database();
            strconn = db.getString();
            MySqlConnection conn = new MySqlConnection(strconn);
            conn.Open();
            try
            {
                query = "SELECT * FROM jenis_surat WHERE id_jenis = @id_jenis";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id_jenis", id_jenis);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    jenis_surat = reader["nama_jenis"].ToString();
                }
                comboBoxJenisSuratMasuk.SelectedText = jenis_surat;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            conn.Close();
        }

        private void getSifatSurat(string nomor_surat)
        {
            Database db = new Database();
            strconn = db.getString();
            MySqlConnection conn = new MySqlConnection(strconn);
            conn.Open();
            try
            {
                query = "SELECT sifat_surat FROM surat_masuk WHERE nomor_surat_masuk = @nomor_surat";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@nomor_surat", nomor_surat);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    sifat_surat = reader["sifat_surat"].ToString();
                }
                comboBoxSifatSuratMasuk.SelectedText = sifat_surat;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            conn.Close();
        }

        private void getSuratMasuk()
        {
            Database db = new Database();
            strconn = db.getString();
            MySqlConnection conn = new MySqlConnection(strconn);
            conn.Open();
            try
            {
                query = "SELECT * FROM surat_masuk WHERE nomor_surat_masuk = @nomor_surat";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@nomor_surat", nomor_surat);
                MySqlDataReader reader = cmd.ExecuteReader();
                while(reader.Read())
                {
                    perihal = reader[1].ToString();
                    tanggal_surat = reader[2].ToString();
                    tanggal_terima = reader["tanggal_terima"].ToString();
                    id_jenis = reader["id_jenis"].ToString();
                    pengirim = reader["pengirim"].ToString();
                    alamat_pengirim = reader["pengirim"].ToString();
                    penerima = reader["penerima"].ToString();
                    jabatan_tertanda = reader["jabatan_tertanda"].ToString();
                    tertanda = reader["tertanda"].ToString();
                    distribusi_tanggal = reader["distribusi_tanggal"].ToString();
                    isi_singkat = reader["isi_singkat"].ToString();
                    keterangan = reader["keterangan"].ToString();
                    gambar_surat = reader["gambar_surat"].ToString();
                }
                textBoxNomorSuratMasuk.Text = nomor_surat;
                textBoxPerihalSuratMasuk.Text = perihal;
                dateTimeInputTanggalSuratMasuk.Value = DateTime.Parse(tanggal_surat);
                dateTimeInputTanggalTerimaSuratMasuk.Value = DateTime.Parse(tanggal_terima);
                textBoxInstansiPengirimSuratMasuk.Text = pengirim;
                textBoxAlamatPengirimSuratMasuk.Text = alamat_pengirim;
                textBoxPenerimaSuratMasuk.Text = penerima;
                textBoxJabatanTertandaSuratMasuk.Text = jabatan_tertanda;
                textBoxTertandaPengirimSuratMasuk.Text = tertanda;
                dateTimeInputTanggalDistribusiSuratMasuk.Value = DateTime.Parse(distribusi_tanggal);
                textBoxKeteranganSuratMasuk.Text = keterangan;
                textBoxIsiSuratMasuk.Text = isi_singkat;
                pictureBoxGambarSuratMasuk.Image = new Bitmap(Application.StartupPath  + "\\image_surat_masuk\\"+gambar_surat);
                textBoxNomorSuratMasuk.SelectionStart = 0;
                textBoxNomorSuratMasuk.SelectionLength = textBoxNomorSuratMasuk.Text.Length;
                nama_gambar = gambar_surat;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            conn.Close();
        }

        public string getIdJenisSurat(string nama_jenis)
        {
            string id_jenis = "";
            Database db = new Database();
            strconn = db.getString();
            MySqlConnection conn = new MySqlConnection(strconn);
            conn.Open();
            query = "SELECT id_jenis FROM jenis_surat WHERE nama_jenis = @nama_jenis";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@nama_jenis", nama_jenis);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                id_jenis = reader[0].ToString();
            }
            conn.Close();
            return id_jenis;
        }

        private void tambahDistribusi(string nomor_surat, string bidang)
        {
            Database db = new Database();
            strconn = db.getString();
            MySqlConnection conn = new MySqlConnection(strconn);
            conn.Open();
            try
            {
                query = "INSERT INTO detail_bagian_bidang_surat_masuk VALUES(@nomor_surat, " +
                        "(SELECT id_bagian_bidang FROM bagian_bidang WHERE nama_bagian_bidang = @bagian_bidang))";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@nomor_surat", nomor_surat);
                cmd.Parameters.AddWithValue("@bagian_bidang", bidang);
                cmd.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            conn.Close();
        }

        private void hapusDistribusi(string nomor_surat, string bidang)
        {
            Database db = new Database();
            strconn = db.getString();
            MySqlConnection conn = new MySqlConnection(strconn);
            conn.Open();
            try
            {
                query = "DELETE FROM detail_bagian_bidang_surat_masuk WHERE nomor_surat = @nomor_surat AND id_bagian_bidang = " +
                        "(SELECT id_bagian_bidang FROM bagian_bidang WHERE nama_bagian_bidang = @bagian_bidang)";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@nomor_surat", nomor_surat);
                cmd.Parameters.AddWithValue("@bagian_bidang", bidang);
                cmd.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            conn.Close();
        }

        private void editSuratMasuk()
        {
            string lokasi_tujuan;
            nomor_surat = textBoxNomorSuratMasuk.Text;
            tanggal_surat = dateTimeInputTanggalSuratMasuk.Value.Date.ToString("dd-MM-yyyy");
            tanggal_terima = dateTimeInputTanggalTerimaSuratMasuk.Value.Date.ToString("dd-MM-yyyy");
            jenis_surat = comboBoxJenisSuratMasuk.Text;
            sifat_surat = comboBoxSifatSuratMasuk.Text;
            perihal = textBoxPerihalSuratMasuk.Text;
            keterangan = textBoxKeteranganSuratMasuk.Text;
            isi_singkat = textBoxIsiSuratMasuk.Text;
            pengirim = textBoxInstansiPengirimSuratMasuk.Text;
            alamat_pengirim = textBoxAlamatPengirimSuratMasuk.Text;
            penerima = textBoxPenerimaSuratMasuk.Text;
            jabatan_tertanda = textBoxJabatanTertandaSuratMasuk.Text;
            tertanda = textBoxTertandaPengirimSuratMasuk.Text;
            distribusi_tanggal = dateTimeInputTanggalDistribusiSuratMasuk.Value.Date.ToString("dd-MM-yyyy");
            lokasi_tujuan = "";

            Database db = new Database();
            strconn = db.getString();
            MySqlConnection conn = new MySqlConnection(strconn);
            using (conn)
            {
                conn.Open();

                if (pictureBoxGambarSuratMasuk.Image != null)
                {
                    lokasi_tujuan = Application.StartupPath + "\\image_surat_masuk";
                    if (!Directory.Exists(lokasi_tujuan))
                    {
                        Directory.CreateDirectory(lokasi_tujuan);
                    }
                    if (!File.Exists(Application.StartupPath + "\\image_surat_masuk\\" + gambar_surat))
                    {
                        File.Copy(lokasi_gambar, lokasi_tujuan + "\\" + nama_gambar, true);
                    }
                }

                try
                {
                    query = "UPDATE surat_masuk SET nomor_surat_masuk = @nomor_surat, perihal = @perihal_surat, " +
                                                    "tanggal_surat = STR_TO_DATE(@tanggal_surat, '%d-%m-%Y'), " +
                                                    "tanggal_terima = STR_TO_DATE(@tanggal_terima, '%d-%m-%Y'), " +
                                                    "id_jenis = @id_jenis, " +
                                                    "sifat_surat = @sifat_surat, pengirim = @pengirim, " +
                                                    "alamat_pengirim = @alamat_pengirim, penerima = @penerima, " +
                                                    "jabatan_tertanda = @jabatan_tertanda, tertanda = @tertanda, " +
                                                    "distribusi_tanggal = STR_TO_DATE(@distribusi_tanggal, '%d-%m-%Y'), " +
                                                    "isi_singkat = @isi_singkat, keterangan = @keterangan, " +
                                                    "gambar_surat = @gambar_surat, id_user = @id_user, tanggal_update = NOW() " +
                            "WHERE nomor_surat_masuk = @nomor_surat_sebelumnya";
                    // MessageBox.Show(nama_gambar);
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@nomor_surat", nomor_surat);
                    cmd.Parameters.AddWithValue("@sifat_surat", sifat_surat);
                    cmd.Parameters.AddWithValue("@id_jenis", getIdJenisSurat(jenis_surat));
                    cmd.Parameters.AddWithValue("@gambar_surat", nama_gambar);
                    cmd.Parameters.AddWithValue("@perihal_surat", perihal);
                    cmd.Parameters.AddWithValue("@tanggal_surat", tanggal_surat);
                    cmd.Parameters.AddWithValue("@tanggal_terima", tanggal_terima);
                    cmd.Parameters.AddWithValue("@pengirim", pengirim);
                    cmd.Parameters.AddWithValue("@alamat_pengirim", alamat_pengirim);
                    cmd.Parameters.AddWithValue("@penerima", penerima);
                    cmd.Parameters.AddWithValue("@jabatan_tertanda", jabatan_tertanda);
                    cmd.Parameters.AddWithValue("@tertanda", tertanda);
                    cmd.Parameters.AddWithValue("@distribusi_tanggal", distribusi_tanggal);
                    cmd.Parameters.AddWithValue("@isi_singkat", isi_singkat);
                    cmd.Parameters.AddWithValue("@keterangan", keterangan);
                    cmd.Parameters.AddWithValue("@nomor_surat_sebelumnya", FormSuratMasuk.nomor_surat);
                    cmd.Parameters.AddWithValue("@id_user", FormMain.id_user);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Edit Surat Masuk berhasil", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show(ex.ToString());
                }

                conn.Close();
            }
        }

        private void FormSuratMasukEdit_Load(object sender, EventArgs e)
        {
            nomor_surat = FormSuratMasuk.nomor_surat;
            getAllJenisSurat();
            getSuratMasuk();
            getJenisSurat(id_jenis);
            getSifatSurat(nomor_surat);

            checkBoxTataUsaha.CheckedChanged -= checkBoxTataUsaha_CheckedChanged;
            checkBoxLayanan.CheckedChanged -= checkBoxLayanan_CheckedChanged;
            checkBoxPemberitaan.CheckedChanged -= checkBoxPemberitaan_CheckedChanged;
            checkBoxProgramaSiaran.CheckedChanged -= checkBoxProgramaSiaran_CheckedChanged;
            checkBoxTeknologi.CheckedChanged -= checkBoxTeknologi_CheckedChanged;

            getDistribusi();

            checkBoxTataUsaha.CheckedChanged += checkBoxTataUsaha_CheckedChanged;
            checkBoxLayanan.CheckedChanged += checkBoxLayanan_CheckedChanged;
            checkBoxPemberitaan.CheckedChanged += checkBoxPemberitaan_CheckedChanged;
            checkBoxProgramaSiaran.CheckedChanged += checkBoxProgramaSiaran_CheckedChanged;
            checkBoxTeknologi.CheckedChanged += checkBoxTeknologi_CheckedChanged;

        }

        private void buttonKembaliSuratMasuk_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonLampiranSuratMasuk_Click(object sender, EventArgs e)
        {
            FormSuratMasukLampiran form_lampiran = new FormSuratMasukLampiran();
            form_lampiran.ShowDialog();
        }

        private void FormSuratMasukEdit_FormClosed(object sender, FormClosedEventArgs e)
        {
            FormSuratMasukLampiran.list_lampiran.Clear();
            FormSuratMasukTembusan.list_tembusan.Clear();
            this.Dispose();
        }

        private void buttonTembusanSuratMasuk_Click(object sender, EventArgs e)
        {
            FormSuratMasukTembusan form_tembusan = new FormSuratMasukTembusan();
            form_tembusan.ShowDialog();
        }

        private void buttonEditSuratMasuk_Click(object sender, EventArgs e)
        {
            if (cekValid())
            {
                return;
            }
            else
            {
                editSuratMasuk();
            }
            frm1.getAllSuratMasuk();
        }

        private void buttonGambarSuratMasuk_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                lokasi_gambar = dialog.FileName;
                nama_gambar = Path.GetFileName(dialog.FileName);
                pictureBoxGambarSuratMasuk.Image = new Bitmap(dialog.FileName);
            }
            else
            {
                nama_gambar = gambar_surat;
            }
        }

        private void checkBoxTataUsaha_CheckedChanged(object sender, EventArgs e)
        {
            bidang = "Tata Usaha";
            if (checkBoxTataUsaha.Checked)
            {
                tambahDistribusi(nomor_surat, bidang);
            }
            else
            {
                hapusDistribusi(nomor_surat, bidang);
            }
        }

        private void checkBoxProgramaSiaran_CheckedChanged(object sender, EventArgs e)
        {
            bidang = "Programa Siaran";
            if (checkBoxProgramaSiaran.Checked)
            {
                tambahDistribusi(nomor_surat, bidang);
            }
            else
            {
                hapusDistribusi(nomor_surat, bidang);
            }
        }

        private void checkBoxPemberitaan_CheckedChanged(object sender, EventArgs e)
        {
            bidang = "Pemberitaan";
            if (checkBoxPemberitaan.Checked)
            {
                tambahDistribusi(nomor_surat, bidang);
            }
            else
            {
                hapusDistribusi(nomor_surat, bidang);
            }
        }

        private void checkBoxTeknologi_CheckedChanged(object sender, EventArgs e)
        {
            bidang = "Teknologi dan Media Baru";
            if (checkBoxTeknologi.Checked)
            {
                tambahDistribusi(nomor_surat, bidang);
            }
            else
            {
                hapusDistribusi(nomor_surat, bidang);
            }
        }

        private void checkBoxLayanan_CheckedChanged(object sender, EventArgs e)
        {
            bidang = "Layanan dan Pengembangan";
            if (checkBoxLayanan.Checked)
            {
                tambahDistribusi(nomor_surat, bidang);
            }
            else
            {
                hapusDistribusi(nomor_surat, bidang);
            }
        }
    }
}