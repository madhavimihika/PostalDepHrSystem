using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace PostalDepHrSystem
{
    public partial class Login : Form
    {
        // Database connection string
        private string connStr = "server=localhost;port=3306;username=root;password=;database=Postal_HR_System;";

        public Login()
        {
            InitializeComponent();

            // Set password character to hide password
            if (txt_pw != null)
            {
                txt_pw.PasswordChar = '*';
            }
            this.btn_login.Click += new System.EventHandler(this.btn_login_Click);
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            string nic = txt_nic.Text.Trim();
            string password = txt_pw.Text.Trim();

            // Check if fields are empty
            if (string.IsNullOrEmpty(nic) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter both NIC and Password.", "Validation Required",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_nic.Focus();
                return;
            }

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connStr))
                {
                    conn.Open();

                    // Get user details including Division
                    string query = "SELECT * FROM Users WHERE NIC = @nic AND Password = @password";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@nic", nic);
                        cmd.Parameters.AddWithValue("@password", password);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Get user info
                                string firstName = reader["FirstName"].ToString();
                                string division = reader["Division"].ToString();
                                string designation = reader["Designation"].ToString();

                                // Login successful
                                MessageBox.Show($"Welcome {firstName}!", "Login Successful",
                                              MessageBoxButtons.OK, MessageBoxIcon.Information);

                                // Redirect based on Division
                                RedirectUserByDivision(division, firstName, designation, nic);
                                this.Hide();
                            }
                            else
                            {
                                // Login failed
                                MessageBox.Show("Invalid NIC or Password!\n\nMake sure you entered:\nNIC: " + nic + "\nPassword: " + password,
                                              "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);

                                // Clear fields
                                txt_nic.Clear();
                                txt_pw.Clear();
                                txt_nic.Focus();
                            }
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Database Error: {ex.Message}\n\nMake sure XAMPP MySQL is running.",
                              "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RedirectUserByDivision(string division, string firstName, string designation, string nic)
        {
            // Debug - Show what division we got
            MessageBox.Show($"Debug: Division from database is: '{division}'", "Debug");

            // Check for Administration (Admin)
            if (division == "Administration")
            {
                MessageBox.Show("Opening Admin Dashboard...", "Debug");
                adminDashboard adminForm = new adminDashboard();
                adminForm.Show();
            }
            else if (division == "IT Department" || division == "IT")
            {
                MessageBox.Show($"Welcome {firstName} from IT Department!\n\nOpening IT Dashboard...", "Information");
                // Open IT Dashboard or Admin Dashboard temporarily
                adminDashboard adminForm = new adminDashboard();
                adminForm.Show();
            }
            else if (division == "Human Resources" || division == "HR")
            {
                MessageBox.Show($"Welcome {firstName} from HR Department!\n\nOpening HR Dashboard...", "Information");
                adminDashboard adminForm = new adminDashboard();
                adminForm.Show();
            }
            else if (division == "Finance")
            {
                MessageBox.Show($"Welcome {firstName} from Finance Department!\n\nOpening Finance Dashboard...", "Information");
                adminDashboard adminForm = new adminDashboard();
                adminForm.Show();
            }
            else if (division == "Operations")
            {
                MessageBox.Show($"Welcome {firstName} from Operations Department!\n\nOpening Operations Dashboard...", "Information");
                adminDashboard adminForm = new adminDashboard();
                adminForm.Show();
            }
            else if (division == "Sales")
            {
                MessageBox.Show($"Welcome {firstName} from Sales Department!\n\nOpening Sales Dashboard...", "Information");
                adminDashboard adminForm = new adminDashboard();
                adminForm.Show();
            }
            else
            {
                MessageBox.Show($"Welcome {firstName} from {division}!\n\nOpening General Dashboard...", "Information");
                adminDashboard adminForm = new adminDashboard();
                adminForm.Show();
            }
        }

        // Press Enter key to login
        private void txt_pw_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btn_login_Click(sender, e);
            }
        }

        // Form Load event
        private void Form1_Load(object sender, EventArgs e)
        {
            txt_nic.Focus();
        }
    }
}