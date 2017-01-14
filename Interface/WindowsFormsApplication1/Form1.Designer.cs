namespace WindowsFormsApplication1
{
    partial class Form1
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
            this.loggedAsLabel = new System.Windows.Forms.Label();
            this.SearchLabel = new System.Windows.Forms.Label();
            this.SearchTextBox = new System.Windows.Forms.TextBox();
            this.GoButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // loggedAsLabel
            // 
            this.loggedAsLabel.AutoSize = true;
            this.loggedAsLabel.Location = new System.Drawing.Point(20, 20);
            this.loggedAsLabel.Name = "loggedAsLabel";
            this.loggedAsLabel.Size = new System.Drawing.Size(71, 13);
            this.loggedAsLabel.TabIndex = 0;
            this.loggedAsLabel.Text = "Logged in as:";
            this.loggedAsLabel.Click += new System.EventHandler(this.label1_Click);
            // 
            // SearchLabel
            // 
            this.SearchLabel.AutoSize = true;
            this.SearchLabel.Location = new System.Drawing.Point(20, 42);
            this.SearchLabel.Name = "SearchLabel";
            this.SearchLabel.Size = new System.Drawing.Size(47, 13);
            this.SearchLabel.TabIndex = 1;
            this.SearchLabel.Text = "Search: ";
            // 
            // SearchTextBox
            // 
            this.SearchTextBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.SearchTextBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.SearchTextBox.Location = new System.Drawing.Point(70, 40);
            this.SearchTextBox.Name = "SearchTextBox";
            this.SearchTextBox.Size = new System.Drawing.Size(204, 20);
            this.SearchTextBox.TabIndex = 2;
            this.SearchTextBox.TextChanged += new System.EventHandler(this.SearchTextBox_TextChanged);
            // 
            // GoButton
            // 
            this.GoButton.Location = new System.Drawing.Point(272, 40);
            this.GoButton.Name = "GoButton";
            this.GoButton.Size = new System.Drawing.Size(30, 20);
            this.GoButton.TabIndex = 4;
            this.GoButton.Text = "Go";
            this.GoButton.UseVisualStyleBackColor = true;
            this.GoButton.Click += new System.EventHandler(this.GoButton_Click);
            // 
            // Form1
            // 
            this.AcceptButton = this.GoButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(327, 83);
            this.Controls.Add(this.GoButton);
            this.Controls.Add(this.SearchTextBox);
            this.Controls.Add(this.SearchLabel);
            this.Controls.Add(this.loggedAsLabel);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label loggedAsLabel;
        private System.Windows.Forms.Label SearchLabel;
        private System.Windows.Forms.TextBox SearchTextBox;
        private System.Windows.Forms.Button GoButton;

    }
}

