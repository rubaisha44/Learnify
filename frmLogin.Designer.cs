namespace Learnify
{
    partial class frmLogin
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
            this.btnCancelLog = new System.Windows.Forms.Button();
            this.btnLogin = new System.Windows.Forms.Button();
            this.txtPassLog = new System.Windows.Forms.TextBox();
            this.txtEmailLog = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lnkRegLog = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // btnCancelLog
            // 
            this.btnCancelLog.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelLog.Location = new System.Drawing.Point(206, 207);
            this.btnCancelLog.Name = "btnCancelLog";
            this.btnCancelLog.Size = new System.Drawing.Size(133, 38);
            this.btnCancelLog.TabIndex = 23;
            this.btnCancelLog.Text = "Cancel";
            this.btnCancelLog.UseVisualStyleBackColor = true;
            this.btnCancelLog.Click += new System.EventHandler(this.btnCancelLog_Click);
            // 
            // btnLogin
            // 
            this.btnLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogin.Location = new System.Drawing.Point(53, 207);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(133, 38);
            this.btnLogin.TabIndex = 22;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // txtPassLog
            // 
            this.txtPassLog.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassLog.Location = new System.Drawing.Point(34, 112);
            this.txtPassLog.Name = "txtPassLog";
            this.txtPassLog.Size = new System.Drawing.Size(332, 27);
            this.txtPassLog.TabIndex = 19;
            this.txtPassLog.UseSystemPasswordChar = true;
            // 
            // txtEmailLog
            // 
            this.txtEmailLog.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmailLog.Location = new System.Drawing.Point(34, 47);
            this.txtEmailLog.Name = "txtEmailLog";
            this.txtEmailLog.Size = new System.Drawing.Size(332, 27);
            this.txtEmailLog.TabIndex = 18;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(30, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 20);
            this.label3.TabIndex = 14;
            this.label3.Text = "Password";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(30, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 20);
            this.label2.TabIndex = 13;
            this.label2.Text = "Email";
            // 
            // lnkRegLog
            // 
            this.lnkRegLog.AutoSize = true;
            this.lnkRegLog.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkRegLog.Location = new System.Drawing.Point(116, 160);
            this.lnkRegLog.Name = "lnkRegLog";
            this.lnkRegLog.Size = new System.Drawing.Size(160, 20);
            this.lnkRegLog.TabIndex = 24;
            this.lnkRegLog.TabStop = true;
            this.lnkRegLog.Text = "New User? Register";
            this.lnkRegLog.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkRegLog_LinkClicked);
            // 
            // frmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(401, 279);
            this.Controls.Add(this.lnkRegLog);
            this.Controls.Add(this.btnCancelLog);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.txtPassLog);
            this.Controls.Add(this.txtEmailLog);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Name = "frmLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.Load += new System.EventHandler(this.frmLogin_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancelLog;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.TextBox txtPassLog;
        private System.Windows.Forms.TextBox txtEmailLog;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.LinkLabel lnkRegLog;
    }
}