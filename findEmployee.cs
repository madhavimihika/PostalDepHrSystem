using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace PostalDepHrSystem
{
    public partial class findEmployee : Form
    {
        private string connStr = "server=localhost;port=3306;username=root;password=;database=Postal_HR_System;";
        public string EmployeeName { get; private set; }

        public findEmployee()
        {
            InitializeComponent();
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_fn.Text))
            {
                MessageBox.Show("Please enter an employee name.", "Input Required",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string searchName = txt_fn.Text.Trim();

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connStr))
                {
                    conn.Open();
                    string query = "SELECT EmployeeID, FullName, Department, JobRole, DATE_FORMAT(JoinDate, '%Y-%m-%d') as JoinDate, PhoneNumber FROM Employees WHERE FullName LIKE @name";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@name", "%" + searchName + "%");
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Get employee data
                                string empId = reader["EmployeeID"].ToString();
                                string fullName = reader["FullName"].ToString();
                                string dept = reader["Department"].ToString();
                                string role = reader["JobRole"].ToString();
                                string joinDate = reader["JoinDate"].ToString();
                                string phone = reader["PhoneNumber"].ToString();
                                reader.Close();

                                // Close this form
                                this.Hide();

                                // Open EditEmployee form with the data
                                EditEmployee editForm = new EditEmployee(empId, fullName, dept, role, joinDate, phone);
                                editForm.ShowDialog();

                                // After edit form closes, close this search form
                                this.Close();
                            }
                            else
                            {
                                MessageBox.Show($"Employee '{searchName}' not found!", "Not Found",
                                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}