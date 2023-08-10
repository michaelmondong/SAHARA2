using System.Data.SqlClient;
using System.Web;

namespace SAHARA2
{
    public partial class register : Form
    {
        private SqlConnection connection;
        public register()
        {
            InitializeComponent();
            connection = new SqlConnection(@"Data Source=01-19-WILLEMMIC;Initial Catalog=sahara;Integrated Security=True");
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string email = txtEmail.Text;
            string password = txtPassword.Text;
            string confirmPassword = txtConfirmPassword.Text;

            if (HasPotentialXSS(username) || HasPotentialXSS(email) || HasPotentialXSS(password) || HasPotentialXSS(confirmPassword))
            {
                MessageBox.Show("Input tidak valid.");
                return;
            }

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(confirmPassword))
            {
                MessageBox.Show("Semua field harus diisi.");
                return;
            }
            if (password != confirmPassword)
            {
                MessageBox.Show("Password dan Konfirmasi Password tidak cocok.");
                return;
            }

            try
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "INSERT INTO [user] (username, email, password, role) VALUES (@username, @email, @password, @role)";
                    command.Parameters.AddWithValue("@username", username);
                    command.Parameters.AddWithValue("@email", email);
                    command.Parameters.AddWithValue("@password", password);
                    command.Parameters.AddWithValue("@role", "user");

                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }

                MessageBox.Show("Registrasi berhasil. Anda dapat login menggunakan akun baru Anda.");
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Terjadi kesalahan saat mendaftar: " + ex.Message);
            }
        }

        private bool HasPotentialXSS(string input)
        {
            return !string.IsNullOrEmpty(input) && HttpUtility.HtmlEncode(input) != input;
        }

        private void ClearFields()
        {
            txtUsername.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtPassword.Text = string.Empty;
            txtConfirmPassword.Text = string.Empty;
        }

        private void linkLogin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            login loginForm = new login();
            loginForm.Show();
            this.Hide();
        }

        private void register_Load(object sender, EventArgs e)
        {

        }

        private void register_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                DialogResult result = MessageBox.Show("Apakah Anda yakin ingin keluar dari aplikasi?", "Konfirmasi Keluar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    Application.Exit();
                }
            }
        }
    }
}
