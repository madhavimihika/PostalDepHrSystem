using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PostalDepHrSystem
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void lbl_countEmployee_Click(object sender, EventArgs e)
        {
            string connStr = @"Data Source=MIHIKA;InitialCatalog=PostalHRSystem;Integrated Security=True;";
            int employeeCount = 0;

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                string query = "SELECT COUNT(*) FROM Employees";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    employeeCount = (int)cmd.ExecuteScalar(); // gets a single value (the count)
                }
                conn.Close();
            }

            lbl_countEmployee.Text = employeeCount.ToString(); // set the label to show the count
        }

        
    
    }
}
