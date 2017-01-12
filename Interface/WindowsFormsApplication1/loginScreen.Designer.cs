namespace WindowsFormsApplication1
{
    partial class loginScreen
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
            this.loginButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.loginIDtxt = new System.Windows.Forms.TextBox();
            this.passwordtxt = new System.Windows.Forms.TextBox();
            this.loginlabel = new System.Windows.Forms.Label();
            this.passlabel = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // loginButton
            // 
            this.loginButton.Location = new System.Drawing.Point(12, 66);
            this.loginButton.Name = "loginButton";
            this.loginButton.Size = new System.Drawing.Size(90, 23);
            this.loginButton.TabIndex = 0;
            this.loginButton.Text = "Login";
            this.loginButton.UseVisualStyleBackColor = true;
            this.loginButton.Click += new System.EventHandler(this.loginButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(108, 66);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cancelButton.Size = new System.Drawing.Size(90, 23);
            this.cancelButton.TabIndex = 1;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // loginIDtxt
            // 
            this.loginIDtxt.Location = new System.Drawing.Point(70, 10);
            this.loginIDtxt.Name = "loginIDtxt";
            this.loginIDtxt.Size = new System.Drawing.Size(127, 20);
            this.loginIDtxt.TabIndex = 2;
            // 
            // passwordtxt
            // 
            this.passwordtxt.Location = new System.Drawing.Point(70, 40);
            this.passwordtxt.Name = "passwordtxt";
            this.passwordtxt.Size = new System.Drawing.Size(127, 20);
            this.passwordtxt.TabIndex = 3;
            // 
            // loginlabel
            // 
            this.loginlabel.AutoSize = true;
            this.loginlabel.Location = new System.Drawing.Point(10, 13);
            this.loginlabel.Name = "loginlabel";
            this.loginlabel.Size = new System.Drawing.Size(50, 13);
            this.loginlabel.TabIndex = 4;
            this.loginlabel.Text = "Login  ID";
            this.loginlabel.Click += new System.EventHandler(this.label1_Click);
            // 
            // passlabel
            // 
            this.passlabel.AutoSize = true;
            this.passlabel.Location = new System.Drawing.Point(10, 43);
            this.passlabel.Name = "passlabel";
            this.passlabel.Size = new System.Drawing.Size(53, 13);
            this.passlabel.TabIndex = 5;
            this.passlabel.Text = "Password";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(12, 92);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(52, 13);
            this.linkLabel1.TabIndex = 6;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Register?";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // loginScreen
            // 
            this.AcceptButton = this.loginButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(207, 113);
            this.ControlBox = false;
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.passlabel);
            this.Controls.Add(this.loginlabel);
            this.Controls.Add(this.passwordtxt);
            this.Controls.Add(this.loginIDtxt);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.loginButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "loginScreen";
            this.Text = "User Login";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.loginScreen_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button loginButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.TextBox loginIDtxt;
        private System.Windows.Forms.TextBox passwordtxt;
        private System.Windows.Forms.Label loginlabel;
        private System.Windows.Forms.Label passlabel;
        private System.Windows.Forms.LinkLabel linkLabel1;
    }
}