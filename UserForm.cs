using SAHARA2.Helpers;
using System.Data;
using System.Data.SqlClient;

namespace SAHARA2
{
    public partial class UserForm : Form
    {
        private SqlConnection connection;
        private SqlDataAdapter dataAdapter;
        private DataTable dataTable;
        private static readonly SemaphoreSlim throttler = new SemaphoreSlim(5);

        public string Token { get; internal set; }

        public UserForm()
        {
            InitializeComponent();
            connection = new SqlConnection(@"Data Source=01-19-WILLEMMIC;Initial Catalog=sahara;Integrated Security=True");
        }

        private void LogAction(string action)
        {
            string logFilePath = "user_log.txt";
            string logMessage = $"[{DateTime.Now}] User {UserSession.Username} {action}";

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

        private void UserForm_Load(object sender, EventArgs e)
        {
            LoadDataSakit();

            if (!UserSession.IsLoggedIn || UserSession.Role != "user")
            {
                MessageBox.Show("Anda tidak memiliki izin untuk mengakses halaman ini.");
                this.Close();
            }
        }

        private async void btnSubmit_Click(object sender, EventArgs e)
        {
            await throttler.WaitAsync();
            string nama = txtNama.Text;
            string kelas = txtKelas.Text;
            string asrama = txtAsrama.Text;
            string keluhan = txtKeluhan.Text;

            if (string.IsNullOrEmpty(nama) || string.IsNullOrEmpty(kelas) || string.IsNullOrEmpty(asrama) || string.IsNullOrEmpty(keluhan))
            {
                MessageBox.Show("Semua field harus diisi.");
                return;
            }
            try
            {
                if (!UserSession.IsLoggedIn)
                {
                    // Jika user tidak login, batalkan aksi
                    MessageBox.Show("Anda harus login untuk mengirim data.");
                    return;
                }

                string query = "INSERT INTO data_sakit (nama, kelas, asrama, keluhan) VALUES (@nama, @kelas, @asrama, @keluhan)";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@nama", nama);
                    command.Parameters.AddWithValue("@kelas", kelas);
                    command.Parameters.AddWithValue("@asrama", asrama);
                    command.Parameters.AddWithValue("@keluhan", keluhan);

                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
                LogAction("submitted data");

                LoadDataSakit();

                MessageBox.Show("Input berhasil ditambahkan.");
                ClearFields();
                throttler.Release();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Terjadi kesalahan saat menambahkan input: " + ex.Message);
            }
        }

        private void ClearFields()
        {
            txtNama.Text = string.Empty;
            txtKelas.Text = string.Empty;
            txtAsrama.Text = string.Empty;
            txtKeluhan.Text = string.Empty;
        }

        private void SetListViewAutoSize()
        {
            listViewDataSakit.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            listViewDataSakit.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        private void UserForm_FormClosing(object sender, FormClosingEventArgs e)
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
    }
}
