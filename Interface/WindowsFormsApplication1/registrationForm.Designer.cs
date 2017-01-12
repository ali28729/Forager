namespace WindowsFormsApplication1
{
    partial class registrationForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.fnameText = new System.Windows.Forms.TextBox();
            this.lnameText = new System.Windows.Forms.TextBox();
            this.loginIDText = new System.Windows.Forms.TextBox();
            this.passwordText = new System.Windows.Forms.TextBox();
            this.password2Text = new System.Windows.Forms.TextBox();
            this.emailIDText = new System.Windows.Forms.TextBox();
            this.FirstNameLabel = new System.Windows.Forms.Label();
            this.LastNameLabel = new System.Windows.Forms.Label();
            this.loginIDLabel = new System.Windows.Forms.Label();
            this.passwordLabel = new System.Windows.Forms.Label();
            this.password2Label = new System.Windows.Forms.Label();
            this.emailIDLabel = new System.Windows.Forms.Label();
            this.RegisterButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // fnameText
            // 
            this.fnameText.Location = new System.Drawing.Point(90, 20);
            this.fnameText.Name = "fnameText";
            this.fnameText.Size = new System.Drawing.Size(132, 20);
            this.fnameText.TabIndex = 0;
            // 
            // lnameText
            // 
            this.lnameText.Location = new System.Drawing.Point(90, 50);
            this.lnameText.Name = "lnameText";
            this.lnameText.Size = new System.Drawing.Size(132, 20);
            this.lnameText.TabIndex = 1;
            // 
            // loginIDText
            // 
            this.loginIDText.Location = new System.Drawing.Point(90, 80);
            this.loginIDText.Name = "loginIDText";
            this.loginIDText.Size = new System.Drawing.Size(132, 20);
            this.loginIDText.TabIndex = 2;
            // 
            // passwordText
            // 
            this.passwordText.Location = new System.Drawing.Point(90, 110);
            this.passwordText.Name = "passwordText";
            this.passwordText.Size = new System.Drawing.Size(132, 20);
            this.passwordText.TabIndex = 3;
            // 
            // password2Text
            // 
            this.password2Text.Location = new System.Drawing.Point(90, 140);
            this.password2Text.Name = "password2Text";
            this.password2Text.Size = new System.Drawing.Size(132, 20);
            this.password2Text.TabIndex = 4;
            // 
            // emailIDText
            // 
            this.emailIDText.Location = new System.Drawing.Point(90, 170);
            this.emailIDText.Name = "emailIDText";
            this.emailIDText.Size = new System.Drawing.Size(132, 20);
            this.emailIDText.TabIndex = 5;
            // 
            // FirstNameLabel
            // 
            this.FirstNameLabel.AutoSize = true;
            this.FirstNameLabel.Location = new System.Drawing.Point(20, 20);
            this.FirstNameLabel.Name = "FirstNameLabel";
            this.FirstNameLabel.Size = new System.Drawing.Size(57, 13);
            this.FirstNameLabel.TabIndex = 6;
            this.FirstNameLabel.Text = "First Name";
            // 
            // LastNameLabel
            // 
            this.LastNameLabel.AutoSize = true;
            this.LastNameLabel.Location = new System.Drawing.Point(20, 50);
            this.LastNameLabel.Name = "LastNameLabel";
            this.LastNameLabel.Size = new System.Drawing.Size(58, 13);
            this.LastNameLabel.TabIndex = 7;
            this.LastNameLabel.Text = "Last Name";
            this.LastNameLabel.Click += new System.EventHandler(this.label2_Click);
            // 
            // loginIDLabel
            // 
            this.loginIDLabel.AutoSize = true;
            this.loginIDLabel.Location = new System.Drawing.Point(20, 80);
            this.loginIDLabel.Name = "loginIDLabel";
            this.loginIDLabel.Size = new System.Drawing.Size(47, 13);
            this.loginIDLabel.TabIndex = 8;
            this.loginIDLabel.Text = "Login ID";
            // 
            // passwordLabel
            // 
            this.passwordLabel.AutoSize = true;
            this.passwordLabel.Location = new System.Drawing.Point(20, 110);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Size = new System.Drawing.Size(53, 13);
            this.passwordLabel.TabIndex = 9;
            this.passwordLabel.Text = "Password";
            this.passwordLabel.Click += new System.EventHandler(this.label4_Click);
            // 
            // password2Label
            // 
            this.password2Label.AutoSize = true;
            this.password2Label.Location = new System.Drawing.Point(20, 140);
            this.password2Label.Name = "password2Label";
            this.password2Label.Size = new System.Drawing.Size(58, 13);
            this.password2Label.TabIndex = 10;
            this.password2Label.Text = "Re-confirm";
            // 
            // emailIDLabel
            // 
            this.emailIDLabel.AutoSize = true;
            this.emailIDLabel.Location = new System.Drawing.Point(20, 170);
            this.emailIDLabel.Name = "emailIDLabel";
            this.emailIDLabel.Size = new System.Drawing.Size(46, 13);
            this.emailIDLabel.TabIndex = 11;
            this.emailIDLabel.Text = "Email ID";
            // 
            // RegisterButton
            // 
            this.RegisterButton.Location = new System.Drawing.Point(20, 196);
            this.RegisterButton.Name = "RegisterButton";
            this.RegisterButton.Size = new System.Drawing.Size(90, 23);
            this.RegisterButton.TabIndex = 12;
            this.RegisterButton.Text = "Register";
            this.RegisterButton.UseVisualStyleBackColor = true;
            this.RegisterButton.Click += new System.EventHandler(this.RegisterButton_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelButton.Location = new System.Drawing.Point(132, 196);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(90, 23);
            this.CancelButton.TabIndex = 13;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // registrationForm
            // 
            this.AcceptButton = this.RegisterButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(254, 248);
            this.ControlBox = false;
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.RegisterButton);
            this.Controls.Add(this.emailIDLabel);
            this.Controls.Add(this.password2Label);
            this.Controls.Add(this.passwordLabel);
            this.Controls.Add(this.loginIDLabel);
            this.Controls.Add(this.LastNameLabel);
            this.Controls.Add(this.FirstNameLabel);
            this.Controls.Add(this.emailIDText);
            this.Controls.Add(this.password2Text);
            this.Controls.Add(this.passwordText);
            this.Controls.Add(this.loginIDText);
            this.Controls.Add(this.lnameText);
            this.Controls.Add(this.fnameText);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "registrationForm";
            this.Text = "registrationForm";
            this.Load += new System.EventHandler(this.registrationForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox fnameText;
        private System.Windows.Forms.TextBox lnameText;
        private System.Windows.Forms.TextBox loginIDText;
        private System.Windows.Forms.TextBox passwordText;
        private System.Windows.Forms.TextBox password2Text;
        private System.Windows.Forms.TextBox emailIDText;
        private System.Windows.Forms.Label FirstNameLabel;
        private System.Windows.Forms.Label LastNameLabel;
        private System.Windows.Forms.Label loginIDLabel;
        private System.Windows.Forms.Label passwordLabel;
        private System.Windows.Forms.Label password2Label;
        private System.Windows.Forms.Label emailIDLabel;
        private System.Windows.Forms.Button RegisterButton;
        private System.Windows.Forms.Button CancelButton;
    }
}