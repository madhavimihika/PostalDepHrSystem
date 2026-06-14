using System.Windows.Forms;

namespace PostalDepHrSystem
{
    partial class ViewEmployeeDetails
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dataGridView_employees;
        private System.Windows.Forms.TextBox txt_search;
        private System.Windows.Forms.Button btn_search;
        private System.Windows.Forms.Button btn_refresh;
        private System.Windows.Forms.Button btn_export;
        private System.Windows.Forms.Button btn_close;
        private System.Windows.Forms.Label lbl_title;
        private System.Windows.Forms.Label lbl_search;
        private System.Windows.Forms.Label lbl_totalCount;
        private System.Windows.Forms.Panel panel_top;
        private System.Windows.Forms.Panel panel_bottom;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.dataGridView_employees = new System.Windows.Forms.DataGridView();
            this.txt_search = new System.Windows.Forms.TextBox();
            this.btn_search = new System.Windows.Forms.Button();
            this.btn_refresh = new System.Windows.Forms.Button();
            this.btn_export = new System.Windows.Forms.Button();
            this.btn_close = new System.Windows.Forms.Button();
            this.lbl_title = new System.Windows.Forms.Label();
            this.lbl_search = new System.Windows.Forms.Label();
            this.lbl_totalCount = new System.Windows.Forms.Label();
            this.panel_top = new System.Windows.Forms.Panel();
            this.panel_bottom = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_employees)).BeginInit();
            this.panel_top.SuspendLayout();
            this.panel_bottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView_employees
            // 
            this.dataGridView_employees.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView_employees.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView_employees.Location = new System.Drawing.Point(15, 93);
            this.dataGridView_employees.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dataGridView_employees.Name = "dataGridView_employees";
            this.dataGridView_employees.Size = new System.Drawing.Size(645, 284);
            this.dataGridView_employees.TabIndex = 6;
            // 
            // txt_search
            // 
            this.txt_search.Location = new System.Drawing.Point(75, 59);
            this.txt_search.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txt_search.Name = "txt_search";
            this.txt_search.Size = new System.Drawing.Size(188, 20);
            this.txt_search.TabIndex = 2;
            // 
            // btn_search
            // 
            this.btn_search.Location = new System.Drawing.Point(270, 57);
            this.btn_search.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btn_search.Name = "btn_search";
            this.btn_search.Size = new System.Drawing.Size(68, 24);
            this.btn_search.TabIndex = 3;
            this.btn_search.Text = "Search";
            // 
            // btn_refresh
            // 
            this.btn_refresh.Location = new System.Drawing.Point(345, 57);
            this.btn_refresh.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btn_refresh.Name = "btn_refresh";
            this.btn_refresh.Size = new System.Drawing.Size(68, 24);
            this.btn_refresh.TabIndex = 4;
            this.btn_refresh.Text = "Refresh";
            // 
            // btn_export
            // 
            this.btn_export.Location = new System.Drawing.Point(420, 57);
            this.btn_export.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btn_export.Name = "btn_export";
            this.btn_export.Size = new System.Drawing.Size(68, 24);
            this.btn_export.TabIndex = 5;
            this.btn_export.Text = "Export";
            // 
            // btn_close
            // 
            this.btn_close.Location = new System.Drawing.Point(600, 8);
            this.btn_close.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(60, 24);
            this.btn_close.TabIndex = 1;
            this.btn_close.Text = "Close";
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click_1);
            // 
            // lbl_title
            // 
            this.lbl_title.AutoSize = true;
            this.lbl_title.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold);
            this.lbl_title.ForeColor = System.Drawing.Color.White;
            this.lbl_title.Location = new System.Drawing.Point(15, 12);
            this.lbl_title.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_title.Name = "lbl_title";
            this.lbl_title.Size = new System.Drawing.Size(218, 29);
            this.lbl_title.TabIndex = 0;
            this.lbl_title.Text = "Employee Details";
            // 
            // lbl_search
            // 
            this.lbl_search.AutoSize = true;
            this.lbl_search.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lbl_search.Location = new System.Drawing.Point(15, 61);
            this.lbl_search.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_search.Name = "lbl_search";
            this.lbl_search.Size = new System.Drawing.Size(57, 17);
            this.lbl_search.TabIndex = 1;
            this.lbl_search.Text = "Search:";
            // 
            // lbl_totalCount
            // 
            this.lbl_totalCount.AutoSize = true;
            this.lbl_totalCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.lbl_totalCount.Location = new System.Drawing.Point(15, 12);
            this.lbl_totalCount.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_totalCount.Name = "lbl_totalCount";
            this.lbl_totalCount.Size = new System.Drawing.Size(147, 17);
            this.lbl_totalCount.TabIndex = 0;
            this.lbl_totalCount.Text = "Total Employees: 0";
            // 
            // panel_top
            // 
            this.panel_top.BackColor = System.Drawing.Color.Brown;
            this.panel_top.Controls.Add(this.lbl_title);
            this.panel_top.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_top.Location = new System.Drawing.Point(0, 0);
            this.panel_top.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel_top.Name = "panel_top";
            this.panel_top.Size = new System.Drawing.Size(675, 49);
            this.panel_top.TabIndex = 0;
            // 
            // panel_bottom
            // 
            this.panel_bottom.BackColor = System.Drawing.Color.LightGray;
            this.panel_bottom.Controls.Add(this.lbl_totalCount);
            this.panel_bottom.Controls.Add(this.btn_close);
            this.panel_bottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel_bottom.Location = new System.Drawing.Point(0, 390);
            this.panel_bottom.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel_bottom.Name = "panel_bottom";
            this.panel_bottom.Size = new System.Drawing.Size(675, 41);
            this.panel_bottom.TabIndex = 7;
            // 
            // ViewEmployeeDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(675, 431);
            this.Controls.Add(this.panel_bottom);
            this.Controls.Add(this.dataGridView_employees);
            this.Controls.Add(this.btn_export);
            this.Controls.Add(this.btn_refresh);
            this.Controls.Add(this.btn_search);
            this.Controls.Add(this.txt_search);
            this.Controls.Add(this.lbl_search);
            this.Controls.Add(this.panel_top);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "ViewEmployeeDetails";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "View Employee Details";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_employees)).EndInit();
            this.panel_top.ResumeLayout(false);
            this.panel_top.PerformLayout();
            this.panel_bottom.ResumeLayout(false);
            this.panel_bottom.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}