using MySql.Data.MySqlClient;
using PostalDepHrSystem;
using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace PostalDepHrSystem
{
    public partial class Sign_Up : Form
    {
        // Database connection
        private string connStr = "server=localhost;port=3306;username=root;password=;database=Postal_HR_System;";

        public Sign_Up()
        {
            InitializeComponent();
            LoadComboBoxData();

            // Connect events
            this.btn_signIn.Click += new System.EventHandler(this.btn_signIn_Click);
            this.btn_login.Click += new System.EventHandler(this.btn_login_Click);

            // Ensure button is visible
            this.btn_login.BringToFront();
            this.btn_login.Visible = true;
        }

        private void LoadComboBoxData()
        {
            divisionCombo.Items.Clear();
            divisionCombo.Items.Add("Operations");
            divisionCombo.Items.Add("Sales");
            divisionCombo.Items.Add("Human Resources");
            divisionCombo.Items.Add("Finance");
            divisionCombo.Items.Add("IT Department");
            divisionCombo.Items.Add("Administration");
            divisionCombo.DropDownStyle = ComboBoxStyle.DropDownList;
            divisionCombo.SelectedIndex = -1;
        }

        private void btn_signIn_Click(object sender, EventArgs e)
        {
            // Validate all required fields
            if (string.IsNullOrWhiteSpace(txt_firstName.Text))
            {
                MessageBox.Show("Please enter your full name.", "Validation Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_firstName.Focus();
                return;
            }

            if (divisionCombo.SelectedItem == null)
            {
                MessageBox.Show("Please select a division.", "Validation Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                divisionCombo.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txt_designation.Text))
            {
                MessageBox.Show("Please enter your designation.", "Validation Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_designation.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txt_nic.Text))
            {
                MessageBox.Show("Please enter your NIC number.", "Validation Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_nic.Focus();
                return;
            }

            // Validate NIC format
            if (!Regex.IsMatch(txt_nic.Text, @"^[0-9]{9,12}[vV]?$"))
            {
                MessageBox.Show("Please enter a valid NIC number (9-12 digits, optional v/V).",
                              "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_nic.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txt_pw.Text))
            {
                MessageBox.Show("Please enter a password.", "Validation Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_pw.Focus();
                return;
            }

            if (txt_pw.Text.Length < 6)
            {
                MessageBox.Show("Password must be at least 6 characters long.", "Validation Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_pw.Focus();
                return;
            }

            if (txt_pw.Text != txt_rePw.Text)
            {
                MessageBox.Show("Passwords do not match.", "Validation Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_rePw.Focus();
                return;
            }

            // Save to database
            SaveToDatabase();
        }

        private void SaveToDatabase()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connStr))
                {
                    conn.Open();

                    // Check if user already exists
                    string checkQuery = "SELECT COUNT(*) FROM Users WHERE NIC = @nic";
                    using (MySqlCommand checkCmd = new MySqlCommand(checkQuery, conn))
                    {
                        checkCmd.Parameters.AddWithValue("@nic", txt_nic.Text.Trim());
                        int existingCount = Convert.ToInt32(checkCmd.ExecuteScalar());

                        if (existingCount > 0)
                        {
                            MessageBox.Show("User with this NIC already exists.", "Registration Failed",
                                          MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

                    // Insert new user
                    string query = @"INSERT INTO Users (FirstName, Division, Designation, NIC, Password) 
                                    VALUES (@fname, @div, @desig, @nic, @pass)";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@fname", txt_firstName.Text.Trim());
                        cmd.Parameters.AddWithValue("@div", divisionCombo.SelectedItem.ToString());
                        cmd.Parameters.AddWithValue("@desig", txt_designation.Text.Trim());
                        cmd.Parameters.AddWithValue("@nic", txt_nic.Text.Trim());
                        cmd.Parameters.AddWithValue("@pass", txt_pw.Text);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("SignUp Successful!", "Success",
                                          MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Navigate to Login form
                            Login login = new Login();
                            login.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Registration failed. Please try again.", "Error",
                                          MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Database error: {ex.Message}\n\nMake sure XAMPP MySQL is running.\n\nDetails: {ex.Number}",
                              "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // THIS IS THE NAVIGATION TO LOGIN FORM
        private void btn_login_Click(object sender, EventArgs e)
        {
            Login loginForm = new Login();
            loginForm.Show();
            this.Hide();
        }
    }
}