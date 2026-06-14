using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace PostalDepHrSystem
{
    public partial class EditEmployee : Form
    {
        private string connStr = "server=localhost;port=3306;username=root;password=;database=Postal_HR_System;";
        private string currentEmployeePhone = "";
        private string currentEmployeeID = "";

        public EditEmployee()
        {
            InitializeComponent();
            LoadDepartments();
        }

        public EditEmployee(string employeeID, string fullName, string department, string jobRole, string joinDate, string phone)
        {
            InitializeComponent();
            LoadDepartments();

            currentEmployeeID = employeeID;
            currentEmployeePhone = phone;

            txt_fn.Text = fullName;
            combo_department.SelectedItem = department;
            txt_jobRole.Text = jobRole;
            dateTimePicker_joinDate.Value = DateTime.Parse(joinDate);
            txt_phone.Text = phone;
        }

        private void LoadDepartments()
        {
            combo_department.Items.Clear();
            combo_department.Items.Add("IT Department");
            combo_department.Items.Add("Human Resources");
            combo_department.Items.Add("Finance");
            combo_department.Items.Add("Operations");
            combo_department.Items.Add("Administration");
            combo_department.Items.Add("Sales");
            combo_department.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        // CHANGE THIS METHOD NAME to match designer: btn_update_Click_1
        private void btn_update_Click_1(object sender, EventArgs e)
        {
            if (ValidateFields())
            {
                UpdateEmployee();
            }
        }

        private bool ValidateFields()
        {
            if (string.IsNullOrWhiteSpace(txt_fn.Text))
            {
                MessageBox.Show("Please enter Full Name.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_fn.Focus();
                return false;
            }

            if (combo_department.SelectedItem == null)
            {
                MessageBox.Show("Please select a Department.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                combo_department.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txt_jobRole.Text))
            {
                MessageBox.Show("Please enter Job Role.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_jobRole.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txt_phone.Text))
            {
                MessageBox.Show("Please enter Phone Number.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_phone.Focus();
                return false;
            }

            return true;
        }

        private void UpdateEmployee()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connStr))
                {
                    conn.Open();

                    string query = @"UPDATE Employees 
                                    SET FullName = @name, 
                                        Department = @dept, 
                                        JobRole = @role, 
                                        JoinDate = @date, 
                                        PhoneNumber = @phone 
                                    WHERE PhoneNumber = @oldPhone";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@name", txt_fn.Text.Trim());
                        cmd.Parameters.AddWithValue("@dept", combo_department.SelectedItem.ToString());
                        cmd.Parameters.AddWithValue("@role", txt_jobRole.Text.Trim());
                        cmd.Parameters.AddWithValue("@date", dateTimePicker_joinDate.Value.Date);
                        cmd.Parameters.AddWithValue("@phone", txt_phone.Text.Trim());
                        cmd.Parameters.AddWithValue("@oldPhone", currentEmployeePhone);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Employee updated successfully!", "Success",
                                          MessageBoxButtons.OK, MessageBoxIcon.Information);

                            adminDashboard dashboard = new adminDashboard();
                            dashboard.Show();
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("No changes were made.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            adminDashboard dashboard = new adminDashboard();
            dashboard.Show();
            this.Close();
        }

        private void btn_ViewAllEmp_Click(object sender, EventArgs e)
        {
            adminDashboard dashboard = new adminDashboard();
            dashboard.Show();
            this.Close();
        }

        private void btn_empEdit_Click(object sender, EventArgs e)
        {
            MessageBox.Show("You are already on Edit page.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            form_addEmployeeForm addForm = new form_addEmployeeForm();
            addForm.Show();
            this.Close();
        }

        private void Admin_Dashboard_Click(object sender, EventArgs e)
        {
            adminDashboard dashboard = new adminDashboard();
            dashboard.Show();
            this.Close();
        }

        private void label7_Click(object sender, EventArgs e) { }
        private void txt_fn_TextChanged(object sender, EventArgs e) { }
        private void combo_department_SelectedIndexChanged(object sender, EventArgs e) { }
        private void txt_jobRole_TextChanged(object sender, EventArgs e) { }
        private void txt_phone_TextChanged(object sender, EventArgs e) { }
        private void dateTimePicker_joinDate_ValueChanged(object sender, EventArgs e) { }

        private void btn_addEmp_Click(object sender, EventArgs e)
        {
            form_addEmployeeForm addForm = new form_addEmployeeForm();
            addForm.Show();
            this.Hide();
        }

        private void btn_empEdit_Click_1(object sender, EventArgs e)
        {
            findEmployee searchForm = new findEmployee();
            searchForm.Show();
            this.Hide();
        }
    }
}