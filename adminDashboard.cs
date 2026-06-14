using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace PostalDepHrSystem
{
    public partial class adminDashboard : Form
    {
        private string connStr = "server=localhost;port=3306;username=root;password=;database=Postal_HR_System;";

        public adminDashboard()
        {
            InitializeComponent();
            LoadTotalEmployees();
            LoadDepartmentChart();
        }

        private void LoadTotalEmployees()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connStr))
                {
                    conn.Open();
                    string query = "SELECT COUNT(*) FROM Employees";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        int totalEmployees = Convert.ToInt32(cmd.ExecuteScalar());
                        textBox1.Text = totalEmployees.ToString();
                        lbl_tot.Text = "Total: " + totalEmployees;
                    }
                }
            }
            catch (Exception ex)
            {
                textBox1.Text = "0";
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void LoadDepartmentChart()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connStr))
                {
                    conn.Open();
                    string query = "SELECT Department, COUNT(*) as Count FROM Employees GROUP BY Department";
                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    chart_totEmp.Series.Clear();
                    Series series = new Series("Employees");
                    series.ChartType = SeriesChartType.Pie;

                    foreach (DataRow row in dt.Rows)
                    {
                        string dept = row["Department"].ToString();
                        int count = Convert.ToInt32(row["Count"]);
                        series.Points.AddXY(dept, count);
                        series.Points[series.Points.Count - 1].Label = dept + ": " + count;
                    }

                    chart_totEmp.Series.Add(series);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Chart Error: " + ex.Message);
            }
        }

        // Add Employee Button
        private void btn_addEmp_Click(object sender, EventArgs e)
        {
            form_addEmployeeForm addForm = new form_addEmployeeForm();
            addForm.Show();
            this.Hide();
        }

        // View All Employees Button
        private void btn_ViewAllEmp_Click(object sender, EventArgs e)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connStr))
                {
                    conn.Open();
                    string query = "SELECT FullName, Department, JobRole, PhoneNumber FROM Employees";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataReader reader = cmd.ExecuteReader();

                    string message = "===== EMPLOYEES =====\n\n";

                    while (reader.Read())
                    {
                        message += "Name: " + reader["FullName"] + "\n";
                        message += "Dept: " + reader["Department"] + "\n";
                        message += "Role: " + reader["JobRole"] + "\n";
                        message += "Phone: " + reader["PhoneNumber"] + "\n";
                        message += "------------------------\n";
                    }
                    reader.Close();

                    MessageBox.Show(message, "All Employees", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        // Edit Employee Button - Uses findEmployee popup
        private void btn_empEdit_Click(object sender, EventArgs e)
        {
            using (findEmployee searchForm = new findEmployee())
            {
                if (searchForm.ShowDialog() == DialogResult.OK)
                {
                    string employeeName = searchForm.EmployeeName;

                    try
                    {
                        using (MySqlConnection conn = new MySqlConnection(connStr))
                        {
                            conn.Open();
                            string query = "SELECT EmployeeID, FullName, Department, JobRole, DATE_FORMAT(JoinDate, '%Y-%m-%d') as JoinDate, PhoneNumber FROM Employees WHERE FullName LIKE @name";
                            using (MySqlCommand cmd = new MySqlCommand(query, conn))
                            {
                                cmd.Parameters.AddWithValue("@name", "%" + employeeName + "%");
                                using (MySqlDataReader reader = cmd.ExecuteReader())
                                {
                                    if (reader.Read())
                                    {
                                        string id = reader["EmployeeID"].ToString();
                                        string fullName = reader["FullName"].ToString();
                                        string dept = reader["Department"].ToString();
                                        string role = reader["JobRole"].ToString();
                                        string date = reader["JoinDate"].ToString();
                                        string phone = reader["PhoneNumber"].ToString();
                                        reader.Close();

                                        //Edit_Employee editForm = new Edit_Employee(id, fullName, dept, role, date, phone);
                                        //editForm.ShowDialog();

                                        // Refresh dashboard after edit
                                        LoadTotalEmployees();
                                        LoadDepartmentChart();
                                    }
                                    else
                                    {
                                        MessageBox.Show($"Employee '{employeeName}' not found!", "Not Found",
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
            }
        }

        // Delete Employee Button
        private void btn_empDelete_Click(object sender, EventArgs e)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connStr))
                {
                    conn.Open();
                    string query = "SELECT EmployeeID, FullName, Department, PhoneNumber FROM Employees";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataReader reader = cmd.ExecuteReader();

                    string employeeList = "SELECT AN EMPLOYEE TO DELETE:\n\n";
                    int index = 1;
                    var employees = new System.Collections.Generic.List<string[]>();

                    while (reader.Read())
                    {
                        string[] emp = new string[3];
                        emp[0] = reader["EmployeeID"].ToString();
                        emp[1] = reader["FullName"].ToString();
                        emp[2] = reader["PhoneNumber"].ToString();

                        employees.Add(emp);
                        employeeList += index + ". " + emp[1] + " - " + emp[0] + "\n";
                        index++;
                    }
                    reader.Close();

                    if (employees.Count == 0)
                    {
                        MessageBox.Show("No employees found.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    string input = Microsoft.VisualBasic.Interaction.InputBox(employeeList, "Delete Employee", "1");

                    if (int.TryParse(input, out int selected) && selected >= 1 && selected <= employees.Count)
                    {
                        var emp = employees[selected - 1];
                        DialogResult result = MessageBox.Show("Are you sure you want to delete " + emp[1] + "?",
                                                              "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            DeleteEmployee(emp[2]);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Invalid selection.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void DeleteEmployee(string phone)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connStr))
                {
                    conn.Open();
                    string query = "DELETE FROM Employees WHERE PhoneNumber = @phone";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@phone", phone);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Employee deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadTotalEmployees();
                        LoadDepartmentChart();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        // Filter buttons
        private void bt_IT_Click(object sender, EventArgs e)
        {
            ShowEmployeesByDepartment("IT Department");
        }

        private void btn_HR_Click(object sender, EventArgs e)
        {
            ShowEmployeesByDepartment("Human Resources");
        }

        private void btn_finance_Click(object sender, EventArgs e)
        {
            ShowEmployeesByDepartment("Finance");
        }

        private void btn_operation_Click(object sender, EventArgs e)
        {
            ShowEmployeesByDepartment("Operations");
        }

        private void btn_Admin_Click(object sender, EventArgs e)
        {
            ShowEmployeesByDepartment("Administration");
        }

        private void btn_it_Click(object sender, EventArgs e)
        {
            LoadTotalEmployees();
            LoadDepartmentChart();
            MessageBox.Show("Showing all departments", "Filter", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ShowEmployeesByDepartment(string department)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connStr))
                {
                    conn.Open();
                    string query = "SELECT FullName, JobRole, PhoneNumber FROM Employees WHERE Department = @dept";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@dept", department);
                    MySqlDataReader reader = cmd.ExecuteReader();

                    string message = "===== " + department + " EMPLOYEES =====\n\n";
                    int count = 0;

                    while (reader.Read())
                    {
                        count++;
                        message += "Name: " + reader["FullName"] + "\n";
                        message += "Role: " + reader["JobRole"] + "\n";
                        message += "Phone: " + reader["PhoneNumber"] + "\n";
                        message += "------------------------\n";
                    }
                    reader.Close();

                    if (count == 0)
                    {
                        message = "No employees found in " + department;
                    }

                    MessageBox.Show(message, department + " Department", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void chart_totEmp_Click(object sender, EventArgs e)
        {
            LoadTotalEmployees();
            LoadDepartmentChart();
        }

        private void lbl_tot_Click(object sender, EventArgs e)
        {
            LoadTotalEmployees();
            LoadDepartmentChart();
        }

        private void btn_empEdit_Click_1(object sender, EventArgs e)
        {
            findEmployee searchForm = new findEmployee();
            searchForm.ShowDialog();
            this.Show();

        }
    }
}