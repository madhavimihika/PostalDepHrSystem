using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace PostalDepHrSystem
{
    public partial class adminDashboard : Form
    {
        public adminDashboard()
        {
            InitializeComponent();
        }

        private void btn_addEmp_Click(object sender, EventArgs e)
        {
            form_addEmployeeForm addForm = new form_addEmployeeForm();
            addForm.Show();
            this.Hide();
        }

        // View All Employees
        private void btn_ViewAllEmp_Click(object sender, EventArgs e)
        {
            // Show all employees in the DataGridView
            LoadEmployees();
        }

        // Edit Employee
        private void btn_empEdit_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Select an employee from the list to edit.", "Edit Employee",
                          MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Delete Employee
        private void btn_empDelete_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Select an employee from the list to delete.", "Delete Employee",
                          MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Filter by IT Department
        private void bt_IT_Click(object sender, EventArgs e)
        {
            FilterEmployeesByDepartment("IT Department");
        }

        // Filter by HR
        private void btn_HR_Click(object sender, EventArgs e)
        {
            FilterEmployeesByDepartment("Human Resources");
        }

        // Filter by Finance
        private void btn_finance_Click(object sender, EventArgs e)
        {
            FilterEmployeesByDepartment("Finance");
        }

        // Filter by Operations
        private void btn_operation_Click(object sender, EventArgs e)
        {
            FilterEmployeesByDepartment("Operations");
        }

        // Filter by Admin
        private void btn_Admin_Click(object sender, EventArgs e)
        {
            FilterEmployeesByDepartment("Administration");
        }

        // Show All Employees
        private void btn_it_Click(object sender, EventArgs e)
        {
            LoadEmployees();
        }

        private void LoadEmployees()
        {
            try
            {
                string connStr = "server=localhost;port=3306;username=root;password=;database=Postal_HR_System;";
                using (MySqlConnection conn = new MySqlConnection(connStr))
                {
                    conn.Open();
                    string query = "SELECT FullName as Employee, Department, JobRole, JoinDate, PhoneNumber FROM Employees";
                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                    System.Data.DataTable dt = new System.Data.DataTable();
                    adapter.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading employees: {ex.Message}");
            }
        }

        private void FilterEmployeesByDepartment(string department)
        {
            try
            {
                string connStr = "server=localhost;port=3306;username=root;password=;database=Postal_HR_System;";
                using (MySqlConnection conn = new MySqlConnection(connStr))
                {
                    conn.Open();
                    string query = "SELECT FullName as Employee, Department, JobRole, JoinDate, PhoneNumber FROM Employees WHERE Department = @dept";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@dept", department);
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    System.Data.DataTable dt = new System.Data.DataTable();
                    adapter.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }
    }
}