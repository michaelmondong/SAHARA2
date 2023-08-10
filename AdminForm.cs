using System.Data;
using System.Data.SqlClient;
using iTextSharp.text;
using iTextSharp.text.pdf;
using SAHARA2.Helpers;
using System.Web;

namespace SAHARA2
{
    public partial class AdminForm : Form
    {
        private SqlConnection connection;
        private SqlDataAdapter dataAdapter;
        private SqlCommandBuilder commandBuilder;
        private DataTable dataTable;

        public string Token { get; internal set; }

        public AdminForm()
        {
            InitializeComponent();
            connection = new SqlConnection(@"Data Source=01-19-WILLEMMIC;Initial Catalog=sahara;Integrated Security=True");
            rbNone.CheckedChanged += rbNone_CheckedChanged;
            rbDelete.CheckedChanged += rbDelete_CheckedChanged;
            rbEdit.CheckedChanged += rbEdit_CheckedChanged;
            rbPrint.CheckedChanged += rbPrint_CheckedChanged;
            rbNone.Checked = true;
            rbNone_CheckedChanged(rbNone, EventArgs.Empty);
        }

        private void LogAction(string action)
        {
            string logFilePath = "admin_log.txt";
            string logMessage = $"[{DateTime.Now}] Admin {UserSession.Username} {action}";

            try
            {
                using (StreamWriter writer = File.AppendText(logFilePath))
                {
                    writer.WriteLine(logMessage);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Terjadi kesalahan saat mencatat log: " + ex.Message);
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Apakah Anda yakin ingin logout?", "Konfirmasi Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                UserSession.ClearUser();
                login loginForm = new login();
                loginForm.Show();
                this.Hide();
            }
        }

        private void LoadDataSakit()
        {
            try
            {
                connection.Open();
                string query = "SELECT id, nama, kelas, asrama, keluhan FROM data_sakit";
                dataAdapter = new SqlDataAdapter(query, connection);
                dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                listViewDataSakit.Items.Clear();

                // Menambahkan kolom-kolom ke ListViewDataSakit
                listViewDataSakit.Columns.Clear();
                listViewDataSakit.Columns.Add("No.", 50);
                listViewDataSakit.Columns.Add("Nama", 150);
                listViewDataSakit.Columns.Add("Kelas", 100);
                listViewDataSakit.Columns.Add("Asrama", 100);
                listViewDataSakit.Columns.Add("Keluhan", 320);

                foreach (DataRow row in dataTable.Rows)
                {
                    ListViewItem item = new ListViewItem(row["id"].ToString());
                    item.SubItems.Add(row["nama"].ToString());
                    item.SubItems.Add(row["kelas"].ToString());
                    item.SubItems.Add(row["asrama"].ToString());
                    item.SubItems.Add(row["keluhan"].ToString());

                    listViewDataSakit.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Terjadi kesalahan saat memuat data: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        private void AdminForm_Load(object sender, EventArgs e)
        {
            LoadDataSakit();

            if (!UserSession.IsLoggedIn || UserSession.Role != "admin")
            {
                MessageBox.Show("Anda tidak memiliki izin untuk mengakses halaman ini.");
                this.Close();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

            if (listViewDataSakit.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = listViewDataSakit.SelectedItems[0];

                int id = Convert.ToInt32(selectedItem.SubItems[0].Text);

                try
                {
                    string query = "DELETE FROM data_sakit WHERE id = @id";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@id", id);

                        connection.Open();
                        command.ExecuteNonQuery();
                        connection.Close();
                    }
                    LogAction("deleted data");
                    LoadDataSakit();

                    MessageBox.Show("Data berhasil dihapus.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Terjadi kesalahan saat menghapus data: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Pilih baris data yang ingin dihapus.");
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (listViewDataSakit.SelectedItems.Count == 0)
            {
                MessageBox.Show("Pilih baris data yang ingin diupdate.");
                return;
            }
            int selectedItemId = Convert.ToInt32(listViewDataSakit.SelectedItems[0].SubItems[0].Text);

            string nama = txtNama.Text;
            string kelas = txtKelas.Text;
            string asrama = txtAsrama.Text;
            string keluhan = txtKeluhan.Text;

            if (HasPotentialXSS(nama) || HasPotentialXSS(kelas) || HasPotentialXSS(asrama) || HasPotentialXSS(keluhan))
            {
                MessageBox.Show("Input tidak valid.");
                return;
            }

            if (string.IsNullOrEmpty(nama) || string.IsNullOrEmpty(kelas) || string.IsNullOrEmpty(asrama) || string.IsNullOrEmpty(keluhan))
            {
                MessageBox.Show("Semua field harus diisi.");
                return;
            }
            try
            {
                string query = "UPDATE data_sakit SET nama = @nama, kelas = @kelas, asrama = @asrama, keluhan = @keluhan WHERE id = @id";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", selectedItemId);
                    command.Parameters.AddWithValue("@nama", nama);
                    command.Parameters.AddWithValue("@kelas", kelas);
                    command.Parameters.AddWithValue("@asrama", asrama);
                    command.Parameters.AddWithValue("@keluhan", keluhan);

                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
                LogAction("edited data");
                LoadDataSakit();

                MessageBox.Show("Data berhasil diupdate.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Terjadi kesalahan saat mengupdate data: " + ex.Message);
            }
        }

        private bool HasPotentialXSS(string input)
        {
            return !string.IsNullOrEmpty(input) && HttpUtility.HtmlEncode(input) != input;
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            string nama = txtNama.Text;
            string kelas = txtKelas.Text;
            string asrama = txtAsrama.Text;
            string keluhan = txtKeluhan.Text;
            string obat = txtObat.Text;
            DateTime kontrol = dtpKontrol.Value;

            if (listViewDataSakit.SelectedItems.Count>0)
            {
                try
                {
                    string fileName = string.Format("Laporan_{0}_{1:yyyyMMdd_HHmmss}.pdf", nama, DateTime.Now);
                    string filePath = Path.Combine(Application.StartupPath, fileName);

                    using (FileStream stream = new FileStream(filePath, FileMode.Create))
                    {
                        using (Document document = new Document())
                        {
                            PdfWriter writer = PdfWriter.GetInstance(document, stream);
                            document.Open();

                            Paragraph titleParagraph = new Paragraph("SAHARA", FontFactory.GetFont(FontFactory.HELVETICA, 24));
                            titleParagraph.Alignment = Element.ALIGN_CENTER;
                            document.Add(titleParagraph);

                            Paragraph subtitleParagraph = new Paragraph("Sanapati Health Report Application", FontFactory.GetFont(FontFactory.HELVETICA, 16));
                            subtitleParagraph.Alignment = Element.ALIGN_CENTER;
                            document.Add(subtitleParagraph);

                            document.Add(new Paragraph("\n"));

                            Paragraph identitasParagraph = new Paragraph("IDENTITAS TARUNA/I:", FontFactory.GetFont(FontFactory.HELVETICA, 14));
                            identitasParagraph.Alignment = Element.ALIGN_CENTER;
                            document.Add(identitasParagraph);

                            PdfPTable identitasTable = new PdfPTable(2);
                            identitasTable.SetWidths(new int[] { 1, 4 });

                            identitasTable.AddCell(new PdfPCell(new Phrase("Nama:", FontFactory.GetFont(FontFactory.HELVETICA, 12))));
                            identitasTable.AddCell(new PdfPCell(new Phrase(nama, FontFactory.GetFont(FontFactory.HELVETICA, 12))));

                            identitasTable.AddCell(new PdfPCell(new Phrase("Kelas:", FontFactory.GetFont(FontFactory.HELVETICA, 12))));
                            identitasTable.AddCell(new PdfPCell(new Phrase(kelas, FontFactory.GetFont(FontFactory.HELVETICA, 12))));

                            identitasTable.AddCell(new PdfPCell(new Phrase("Asrama:", FontFactory.GetFont(FontFactory.HELVETICA, 12))));
                            identitasTable.AddCell(new PdfPCell(new Phrase(asrama, FontFactory.GetFont(FontFactory.HELVETICA, 12))));

                            identitasTable.AddCell(new PdfPCell(new Phrase("Keluhan:", FontFactory.GetFont(FontFactory.HELVETICA, 12))));
                            identitasTable.AddCell(new PdfPCell(new Phrase(keluhan, FontFactory.GetFont(FontFactory.HELVETICA, 12))));

                            identitasTable.AddCell(new PdfPCell(new Phrase("Obat:", FontFactory.GetFont(FontFactory.HELVETICA, 12))));
                            identitasTable.AddCell(new PdfPCell(new Phrase(obat, FontFactory.GetFont(FontFactory.HELVETICA, 12))));

                            identitasTable.AddCell(new PdfPCell(new Phrase("Kontrol:", FontFactory.GetFont(FontFactory.HELVETICA, 12))));
                            identitasTable.AddCell(new PdfPCell(new Phrase(kontrol.ToString(), FontFactory.GetFont(FontFactory.HELVETICA, 12))));

                            identitasTable.SpacingBefore = 10f;
                            identitasTable.SpacingAfter = 10f;

                            document.Add(identitasTable);

                            document.Add(new Paragraph("\n"));

                            // Bagian "TABEL KONTROL OBAT TARUNA/I:" yang berada di tengah
                            Paragraph tabelKontrolParagraph = new Paragraph("TABEL KONTROL OBAT TARUNA/I:", FontFactory.GetFont(FontFactory.HELVETICA, 14));
                            tabelKontrolParagraph.Alignment = Element.ALIGN_CENTER;
                            document.Add(tabelKontrolParagraph);

                            string[] obatArray = obat.Split(',');
                            int totalHari = (int)Math.Ceiling((kontrol - DateTime.Now).TotalDays);

                            PdfPTable obatTable = new PdfPTable(obatArray.Length + 1);
                            obatTable.AddCell(new PdfPCell(new Phrase("Hari\\Obat", FontFactory.GetFont(FontFactory.HELVETICA, 12))));
                            for (int i = 0; i < obatArray.Length; i++)
                            {
                                PdfPCell cell = new PdfPCell(new Phrase(obatArray[i], FontFactory.GetFont(FontFactory.HELVETICA, 12)));
                                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                                obatTable.AddCell(cell);
                            }

                            for (int i = 1; i <= totalHari; i++)
                            {
                                PdfPCell dayCell = new PdfPCell(new Phrase(i.ToString(), FontFactory.GetFont(FontFactory.HELVETICA, 12)));
                                dayCell.HorizontalAlignment = Element.ALIGN_CENTER;
                                obatTable.AddCell(dayCell);

                                for (int j = 0; j < obatArray.Length; j++)
                                {
                                    PdfPCell emptyCell = new PdfPCell(new Phrase(""));
                                    emptyCell.HorizontalAlignment = Element.ALIGN_CENTER;
                                    obatTable.AddCell(emptyCell);
                                }
                            }
                            obatTable.SpacingBefore = 10f;
                            obatTable.SpacingAfter = 10f;
                            document.Add(obatTable);
                            document.Add(new Paragraph("\n"));
                            Paragraph signatureParagraph = new Paragraph("Tanda tangan dokter:\n\n\n\n", FontFactory.GetFont(FontFactory.HELVETICA, 12));
                            signatureParagraph.Alignment = Element.ALIGN_RIGHT;
                            document.Add(signatureParagraph);
                            document.Close();
                            LogAction("printed data");

                            MessageBox.Show("Dokumen PDF berhasil disimpan dengan nama file: " + fileName);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Terjadi kesalahan saat menyimpan dokumen PDF: " + ex.Message);
                } 
            }
            else
            {
                MessageBox.Show("Pilih baris data yang ingin di print.");
            }
        }

        private void listViewDataSakit_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewDataSakit.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = listViewDataSakit.SelectedItems[0];
                string nama = selectedItem.SubItems[1].Text;
                string kelas = selectedItem.SubItems[2].Text;
                string asrama = selectedItem.SubItems[3].Text;
                string keluhan = selectedItem.SubItems[4].Text;

                txtNama.Text = nama;
                txtKelas.Text = kelas;
                txtAsrama.Text = asrama;
                txtKeluhan.Text = keluhan;
            }
        }

        private void AdminForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                DialogResult result = MessageBox.Show("Apakah Anda yakin ingin logout?", "Konfirmasi Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    UserSession.ClearUser();
                    login loginForm = new login();
                    loginForm.Show();
                    this.Hide();
                }
            }
            else if (e.CloseReason == CloseReason.WindowsShutDown || e.CloseReason == CloseReason.ApplicationExitCall)
            {
                UserSession.ClearUser();
            }
        }

        private void rbDelete_CheckedChanged(object sender, EventArgs e)
        {
                if (rbDelete.Checked)
                {
                    txtNama.Enabled = false;
                    txtKelas.Enabled = false;
                    txtAsrama.Enabled = false;
                    txtKeluhan.Enabled = false;
                    txtObat.Enabled = false;
                    dtpKontrol.Enabled = false;
                    btnDelete.Enabled = true;
                    btnSave.Enabled = false;
                    btnPrint.Enabled = false;
                }
            
        }

        private void rbEdit_CheckedChanged(object sender, EventArgs e)
        {
            if (rbEdit.Checked)
            {
                txtNama.Enabled = true;
                txtKelas.Enabled = true;
                txtAsrama.Enabled = true;
                txtKeluhan.Enabled = true;
                txtObat.Enabled = false;
                dtpKontrol.Enabled = false;
                btnDelete.Enabled = false;
                btnSave.Enabled = true;
                btnPrint.Enabled = false;
            }
        }

        

        private void rbNone_CheckedChanged(object sender, EventArgs e)
        {
            if (rbNone.Checked)
            {
                txtNama.Enabled = false;
                txtKelas.Enabled = false;
                txtAsrama.Enabled = false;
                txtKeluhan.Enabled = false;
                txtObat.Enabled = false;
                dtpKontrol.Enabled = false;
                btnDelete.Enabled = false;
                btnSave.Enabled = false;
                btnPrint.Enabled = false;
            }
        }

        private void rbPrint_CheckedChanged(object sender, EventArgs e)
        {
            if (rbPrint.Checked)
            {
                txtNama.Enabled = false;
                txtKelas.Enabled = false;
                txtAsrama.Enabled = false;
                txtKeluhan.Enabled = false;
                txtObat.Enabled = true;
                dtpKontrol.Enabled = true;
                btnDelete.Enabled = false;
                btnSave.Enabled = false;
                btnPrint.Enabled = true;
            }
        }
    }
}
