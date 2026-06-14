using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace PostalDepHrSystem
{
    public partial class form_addEmployeeForm : Form
    {
        // Database connection string
        private string connStr = "server=localhost;port=3306;username=root;password=;database=Postal_HR_System;";

        public form_addEmployeeForm()
        {
            InitializeComponent();
            SetupForm();
            LoadDepartments();

            // Connect button events
            this.btn_addNewEmp.Click += new System.EventHandler(this.btn_addNewEmp_Click);
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            this.btn_ViewAllEmp.Click += new System.EventHandler(this.btn_ViewAllEmp_Click);
            this.btn_empEdit.Click += new System.EventHandler(this.btn_empEdit_Click);
            this.btn_empDelete.Click += new System.EventHandler(this.btn_empDelete_Click);
            this.button1.Click += new System.EventHandler(this.button1_Click);
        }

        private void SetupForm()
        {
            this.Text = "Add New Employee";
            this.StartPosition = FormStartPosition.CenterScreen;
            ClearForm();
            dateTimePicker_joinDate.Value = DateTime.Now;
        }

        private void LoadDepartments()
        {
            combo_department.Items.Clear();
            combo_department.Items.Add("IT");
            combo_department.Items.Add("HR");
            combo_department.Items.Add("Operations");
            combo_department.Items.Add("Finance");
            combo_department.Items.Add("Administrative");
            combo_department.Items.Add("Sales");
            combo_department.DropDownStyle = ComboBoxStyle.DropDownList;
            combo_department.SelectedIndex = -1;
        }

        private void ClearForm()
        {
            txt_fn.Clear();
            combo_department.SelectedIndex = -1;
            txt_jobRole.Clear();
            dateTimePicker_joinDate.Value = DateTime.Now;
            txt_phone.Clear();
        }

        // Handle TextBox TextChanged event (to remove placeholder text)
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // This handles the text change event - leave empty or add logic if needed
        }

        // Add New Employee Button
        private void btn_addNewEmp_Click(object sender, EventArgs e)
        {
            if (!ValidateFields())
                return;

            SaveEmployee();
        }

        private bool ValidateFields()
        {
            if (string.IsNullOrWhiteSpace(txt_fn.Text))
            {
                MessageBox.Show("Please enter Full Name.", "Validation Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_fn.Focus();
                return false;
            }

            if (combo_department.SelectedItem == null)
            {
                MessageBox.Show("Please select a Department.", "Validation Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                combo_department.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txt_jobRole.Text))
            {
                MessageBox.Show("Please enter Job Role.", "Validation Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_jobRole.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txt_phone.Text))
            {
                MessageBox.Show("Please enter Phone Number.", "Validation Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_phone.Focus();
                return false;
            }

            return true;
        }

        private void SaveEmployee()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connStr))
                {
                    conn.Open();

                    // Check if employee already exists
                    string checkQuery = "SELECT COUNT(*) FROM Employees WHERE PhoneNumber = @phone";
                    using (MySqlCommand checkCmd = new MySqlCommand(checkQuery, conn))
                    {
                        checkCmd.Parameters.AddWithValue("@phone", txt_phone.Text.Trim());
                        int count = Convert.ToInt32(checkCmd.ExecuteScalar());

                        if (count > 0)
                        {
                            MessageBox.Show("Employee with this phone number already exists!",
                                          "Duplicate", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }

                    // Generate Employee ID
                    string employeeID = GenerateEmployeeID(conn);

                    string query = @"INSERT INTO Employees (EmployeeID, FullName, Department, JobRole, JoinDate, PhoneNumber) 
                                    VALUES (@id, @name, @dept, @role, @joindate, @phone)";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", employeeID);
                        cmd.Parameters.AddWithValue("@name", txt_fn.Text.Trim());
                        cmd.Parameters.AddWithValue("@dept", combo_department.SelectedItem.ToString());
                        cmd.Parameters.AddWithValue("@role", txt_jobRole.Text.Trim());
                        cmd.Parameters.AddWithValue("@joindate", dateTimePicker_joinDate.Value.Date);
                        cmd.Parameters.AddWithValue("@phone", txt_phone.Text.Trim());

                        int result = cmd.ExecuteNonQuery();

                        if (result > 0)
                        {
                            MessageBox.Show($"Employee added successfully!\n\nEmployee ID: {employeeID}\nName: {txt_fn.Text}",
                                          "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            ClearForm();
                            txt_fn.Focus();
                        }
                        else
                        {
                            MessageBox.Show("Failed to add employee.", "Error",
                                          MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Database Error: {ex.Message}\n\nMake sure XAMPP MySQL is running.\n\nTable 'Employees' must exist.",
                              "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string GenerateEmployeeID(MySqlConnection conn)
        {
            string prefix = "EMP";
            int nextNumber = 1;

            try
            {
                string query = "SELECT COUNT(*) FROM Employees";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    nextNumber = count + 1;
                }
            }
            catch (Exception)
            {
                nextNumber = 1;
            }

            return $"{prefix}{nextNumber:D3}"; // EMP001, EMP002, etc.
        }

        // Cancel Button
        private void btn_cancel_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to cancel?\nUnsaved data will be lost.",
                                                  "Confirm Cancel", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        // Dashboard Button (button1)
        private void button1_Click(object sender, EventArgs e)
        {
            adminDashboard adminDash = new adminDashboard();
            adminDash.Show();
            this.Hide();
        }

        // View All Employees Button - Show in MessageBox instead
        private void btn_ViewAllEmp_Click(object sender, EventArgs e)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connStr))
                {
                    conn.Open();
                    string query = "SELECT EmployeeID, FullName, Department, JobRole, PhoneNumber FROM Employees";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataReader reader = cmd.ExecuteReader();

                    string employeeList = "========== EMPLOYEES LIST ==========\n\n";
                    int count = 0;

                    while (reader.Read())
                    {
                        count++;
                        employeeList += $"ID: {reader["EmployeeID"]}\n";
                        employeeList += $"Name: {reader["FullName"]}\n";
                        employeeList += $"Department: {reader["Department"]}\n";
                        employeeList += $"Job Role: {reader["JobRole"]}\n";
                        employeeList += $"Phone: {reader["PhoneNumber"]}\n";
                        employeeList += "-----------------------------------\n";
                    }
                    reader.Close();

                    if (count == 0)
                    {
                        employeeList = "No employees found in database.";
                    }
                    else
                    {
                        employeeList += $"\nTotal Employees: {count}";
                    }

                    MessageBox.Show(employeeList, "All Employees", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading employees: {ex.Message}\n\nMake sure 'Employees' table exists.",
                              "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Edit Employee Button
        private void btn_empEdit_Click(object sender, EventArgs e)
        {
            MessageBox.Show("To edit an employee:\n\n" +
                          "1. Click 'View All Employees'\n" +
                          "2. Note the Employee ID\n" +
                          "3. Use the Employee ID to update records\n\n" +
                          "(Edit feature coming soon)",
                          "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Delete Employee Button
        private void btn_empDelete_Click(object sender, EventArgs e)
        {
            MessageBox.Show("To delete an employee:\n\n" +
                          "1. Click 'View All Employees'\n" +
                          "2. Note the Employee ID\n" +
                          "3. Use the Employee ID to delete records\n\n" +
                          "(Delete feature coming soon)",
                          "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}