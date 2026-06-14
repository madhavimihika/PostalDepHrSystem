using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace PostalDepHrSystem
{
    public partial class ViewEmployeeDetails : Form
    {
        private string connStr = "server=localhost;port=3306;username=root;password=;database=Postal_HR_System;";

        public ViewEmployeeDetails()
        {
            InitializeComponent();
            LoadAllEmployees();
        }

        private void LoadAllEmployees()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connStr))
                {
                    conn.Open();
                    string query = @"SELECT 
                                        EmployeeID as 'ID',
                                        FullName as 'Full Name', 
                                        Department, 
                                        JobRole as 'Job Role', 
                                        DATE_FORMAT(JoinDate, '%Y-%m-%d') as 'Join Date', 
                                        PhoneNumber as 'Phone Number' 
                                    FROM Employees 
                                    ORDER BY EmployeeID";

                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dataGridView_employees.DataSource = dt;

                    // Format the DataGridView
                    dataGridView_employees.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dataGridView_employees.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                    dataGridView_employees.AllowUserToAddRows = false;
                    dataGridView_employees.ReadOnly = true;
                    dataGridView_employees.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                    // Update total count
                    lbl_totalCount.Text = $"Total Employees: {dt.Rows.Count}";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading employees: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            string searchTerm = txt_search.Text.Trim();
            if (string.IsNullOrEmpty(searchTerm))
            {
                LoadAllEmployees();
                return;
            }

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connStr))
                {
                    conn.Open();
                    string query = @"SELECT 
                                        EmployeeID as 'ID',
                                        FullName as 'Full Name', 
                                        Department, 
                                        JobRole as 'Job Role', 
                                        DATE_FORMAT(JoinDate, '%Y-%m-%d') as 'Join Date', 
                                        PhoneNumber as 'Phone Number' 
                                    FROM Employees 
                                    WHERE FullName LIKE @search 
                                       OR Department LIKE @search 
                                       OR JobRole LIKE @search
                                    ORDER BY EmployeeID";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@search", "%" + searchTerm + "%");
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dataGridView_employees.DataSource = dt;
                    lbl_totalCount.Text = $"Found: {dt.Rows.Count} Employees";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_refresh_Click(object sender, EventArgs e)
        {
            txt_search.Clear();
            LoadAllEmployees();
        }

        private void btn_export_Click(object sender, EventArgs e)
        {
            // Optional: Export to CSV or Excel
            MessageBox.Show("Export feature coming soon!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_close_Click_1(object sender, EventArgs e)
        {
            adminDashboard dashboard = new adminDashboard();    
            dashboard.Show();
            this.Close();
        }
    }
}