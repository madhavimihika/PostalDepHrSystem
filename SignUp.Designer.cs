namespace PostalDepHrSystem
{
    partial class Sign_Up
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_nic;
        private System.Windows.Forms.TextBox txt_firstName;
        private System.Windows.Forms.TextBox txt_pw;
        private System.Windows.Forms.TextBox txt_rePw;
        private System.Windows.Forms.Button btn_signIn;
        private System.Windows.Forms.TextBox txt_designation;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox divisionCombo;
        private System.Windows.Forms.Button btn_login;

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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_nic = new System.Windows.Forms.TextBox();
            this.txt_firstName = new System.Windows.Forms.TextBox();
            this.txt_pw = new System.Windows.Forms.TextBox();
            this.txt_rePw = new System.Windows.Forms.TextBox();
            this.btn_signIn = new System.Windows.Forms.Button();
            this.txt_designation = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.divisionCombo = new System.Windows.Forms.ComboBox();
            this.btn_login = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();

            // pictureBox1
            this.pictureBox1.Image = global::PostalDepHrSystem.Resource1.Logo;
            this.pictureBox1.Location = new System.Drawing.Point(41, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(547, 106);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;

            // pictureBox2
            this.pictureBox2.Image = global::PostalDepHrSystem.Properties.Resources.slpost1;
            this.pictureBox2.Location = new System.Drawing.Point(41, 124);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(217, 371);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 18;
            this.pictureBox2.TabStop = false;

            // label2 (First Name)
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(291, 167);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 16);
            this.label2.TabIndex = 20;
            this.label2.Text = "First Name";

            // txt_firstName
            this.txt_firstName.Location = new System.Drawing.Point(389, 164);
            this.txt_firstName.Name = "txt_firstName";
            this.txt_firstName.Size = new System.Drawing.Size(233, 22);
            this.txt_firstName.TabIndex = 24;

            // label1 (NIC)
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(291, 213);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 16);
            this.label1.TabIndex = 19;
            this.label1.Text = "NIC";

            // txt_nic
            this.txt_nic.Location = new System.Drawing.Point(389, 210);
            this.txt_nic.Name = "txt_nic";
            this.txt_nic.Size = new System.Drawing.Size(233, 22);
            this.txt_nic.TabIndex = 23;

            // label5 (Division)
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(291, 254);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(104, 16);
            this.label5.TabIndex = 30;
            this.label5.Text = "Division/Section";

            // divisionCombo
            this.divisionCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.divisionCombo.FormattingEnabled = true;
            this.divisionCombo.Items.AddRange(new object[] {
            "Operations",
            "Sales",
            "Human Resources",
            "Finance",
            "IT Department",
            "Administration"});
            this.divisionCombo.Location = new System.Drawing.Point(400, 251);
            this.divisionCombo.Name = "divisionCombo";
            this.divisionCombo.Size = new System.Drawing.Size(222, 24);
            this.divisionCombo.TabIndex = 32;

            // label6 (Designation)
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(291, 295);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 16);
            this.label6.TabIndex = 31;
            this.label6.Text = "Designation";

            // txt_designation
            this.txt_designation.Location = new System.Drawing.Point(389, 292);
            this.txt_designation.Name = "txt_designation";
            this.txt_designation.Size = new System.Drawing.Size(233, 22);
            this.txt_designation.TabIndex = 28;

            // label3 (Password)
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(291, 335);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 16);
            this.label3.TabIndex = 21;
            this.label3.Text = "Password";

            // txt_pw
            this.txt_pw.Location = new System.Drawing.Point(389, 332);
            this.txt_pw.Name = "txt_pw";
            this.txt_pw.Size = new System.Drawing.Size(233, 22);
            this.txt_pw.TabIndex = 25;

            // label4 (Re-Password)
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(291, 380);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 16);
            this.label4.TabIndex = 22;
            this.label4.Text = "Re-Password";

            // txt_rePw
            this.txt_rePw.Location = new System.Drawing.Point(389, 377);
            this.txt_rePw.Name = "txt_rePw";
            this.txt_rePw.Size = new System.Drawing.Size(233, 22);
            this.txt_rePw.TabIndex = 26;

            // btn_signIn (Create Account)
            this.btn_signIn.BackColor = System.Drawing.Color.DodgerBlue;
            this.btn_signIn.Location = new System.Drawing.Point(308, 418);
            this.btn_signIn.Name = "btn_signIn";
            this.btn_signIn.Size = new System.Drawing.Size(307, 35);
            this.btn_signIn.TabIndex = 27;
            this.btn_signIn.Text = "Create Account";
            this.btn_signIn.UseVisualStyleBackColor = false;
            this.btn_signIn.Click += new System.EventHandler(this.btn_signIn_Click);

            // btn_login (Already have an Account? Log in)
            this.btn_login.BackColor = System.Drawing.Color.LightGray;
            this.btn_login.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_login.Location = new System.Drawing.Point(308, 460);  // KEY: Position after Create Account
            this.btn_login.Name = "btn_login";
            this.btn_login.Size = new System.Drawing.Size(307, 35);
            this.btn_login.TabIndex = 33;
            this.btn_login.Text = "Already have an Account? Log in";
            this.btn_login.UseVisualStyleBackColor = false;
            this.btn_login.Click += new System.EventHandler(this.btn_login_Click);

            // Sign_Up Form
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LavenderBlush;
            this.ClientSize = new System.Drawing.Size(651, 530);  // KEY: Increased height
            this.Controls.Add(this.btn_login);
            this.Controls.Add(this.divisionCombo);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txt_designation);
            this.Controls.Add(this.btn_signIn);
            this.Controls.Add(this.txt_rePw);
            this.Controls.Add(this.txt_pw);
            this.Controls.Add(this.txt_firstName);
            this.Controls.Add(this.txt_nic);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Sign_Up";
            this.Text = "Sign Up";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}