using System.Data.SqlClient;
using System.Text;
using System.Web;
using SAHARA2.Helpers;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;

namespace SAHARA2
{
    public partial class login : Form
    {
        private SqlConnection connection;
        private string secretKey;
        private static readonly SemaphoreSlim throttler = new SemaphoreSlim(5); // Batas maksimum 5 permintaan dalam waktu bersamaan

        public login()
        {
            InitializeComponent();
            connection = new SqlConnection(@"Data Source=01-19-WILLEMMIC;Initial Catalog=sahara;Integrated Security=True");
            secretKey = GenerateRandomSecretKey(32);
        }

        private string GenerateRandomSecretKey(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var random = new Random();
            var key = new char[length];
            for (int i = 0; i < length; i++)
            {
                key[i] = chars[random.Next(chars.Length)];
            }
            return new string(key);
        }

        private bool showPassword = false;

        private bool ValidateInput(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return false;
            }
            if (HasPotentialXSS(input))
            {
                return false;
            }

            // Melakukan pembersihan atau validasi tambahan sesuai kebutuhan
            // Contoh: memeriksa apakah input hanya mengandung karakter yang valid

            return true;
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            await throttler.WaitAsync();

            string username = txtUsername.Text;
            string password = txtPassword.Text;

            if (!ValidateInput(username) || !ValidateInput(password))
            {
                MessageBox.Show("Input tidak valid.");
                return;
            }
            try
            {
                string query = "SELECT role FROM [user] WHERE username = @username AND password = @password";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@username", username);
                    command.Parameters.AddWithValue("@password", password);

                    connection.Open();
                    object roleObj = command.ExecuteScalar();
                    connection.Close();

                    if (roleObj != null)
                    {
                        string role = roleObj.ToString();
                        UserSession.SetUser(username, role);

                        string tokenString = GenerateToken(username, role);

                        if (role == "admin")
                        {
                            AdminForm adminForm = new AdminForm();
                            adminForm.Token = tokenString; // Set token ke form Admin
                            adminForm.Show();
                            this.Hide();
                        }
                        else if (role == "user")
                        {
                            UserForm userForm = new UserForm();
                            userForm.Token = tokenString; // Set token ke form User
                            userForm.Show();
                            this.Hide();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Username atau password salah.");
                    }
                }
                throttler.Release();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Terjadi kesalahan saat login: " + ex.Message);
            }
            
        }
        

        private bool HasPotentialXSS(string input)
        {
            return !string.IsNullOrEmpty(input) && HttpUtility.HtmlEncode(input) != input;
        }

        private void linkRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            register registerForm = new register();
            registerForm.Show();
            this.Hide();
        }

        private void login_FormClosing(object sender, FormClosingEventArgs e)
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

        private void login_Load(object sender, EventArgs e)
        {
            txtPassword.PasswordChar = '*';
        }

        private void btnShowHidePassword_Click(object sender, EventArgs e)
        {
            txtPassword.PasswordChar = showPassword ? '*' : '\0';
            showPassword = !showPassword;
        }

        private string GenerateToken(string username, string role)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, username),
                new Claim(ClaimTypes.Role, role),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var token = new JwtSecurityToken(
                issuer: "your_issuer",
                audience: "your_audience",
                claims: claims,
                expires: DateTime.UtcNow.AddHours(1),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}