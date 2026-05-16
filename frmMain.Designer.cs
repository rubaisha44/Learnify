namespace Learnify
{
    partial class frmMain
    {
        private System.ComponentModel.IContainer components = null;

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
            this.grpUser = new System.Windows.Forms.GroupBox();
            this.btnTeacherLogin = new System.Windows.Forms.Button();
            this.btnRegisterMain = new System.Windows.Forms.Button();
            this.btnLoginMain = new System.Windows.Forms.Button();
            this.grpLevel = new System.Windows.Forms.GroupBox();
            this.rdoAdvanced = new System.Windows.Forms.RadioButton();
            this.rdoIntermediate = new System.Windows.Forms.RadioButton();
            this.rdoBeginner = new System.Windows.Forms.RadioButton();
            this.grpCategory = new System.Windows.Forms.GroupBox();
            this.Available = new System.Windows.Forms.ListBox();
            this.Category = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnEnroll = new System.Windows.Forms.Button();
            this.grpAdditional = new System.Windows.Forms.GroupBox();
            this.chkQuick = new System.Windows.Forms.CheckBox();
            this.chkSelf = new System.Windows.Forms.CheckBox();
            this.grpUser.SuspendLayout();
            this.grpLevel.SuspendLayout();
            this.grpCategory.SuspendLayout();
            this.grpAdditional.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpUser
            // 
            this.grpUser.Controls.Add(this.btnTeacherLogin);
            this.grpUser.Controls.Add(this.btnRegisterMain);
            this.grpUser.Controls.Add(this.btnLoginMain);
            this.grpUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F);
            this.grpUser.Location = new System.Drawing.Point(250, 10);
            this.grpUser.Name = "grpUser";
            this.grpUser.Size = new System.Drawing.Size(230, 110);
            this.grpUser.TabIndex = 0;
            this.grpUser.TabStop = false;
            this.grpUser.Text = "Unregistered User";
            // 
            // btnTeacherLogin
            // 
            this.btnTeacherLogin.Location = new System.Drawing.Point(13, 65);
            this.btnTeacherLogin.Name = "btnTeacherLogin";
            this.btnTeacherLogin.Size = new System.Drawing.Size(200, 27);
            this.btnTeacherLogin.TabIndex = 2;
            this.btnTeacherLogin.Text = " Teacher Login";
            this.btnTeacherLogin.UseVisualStyleBackColor = true;
            this.btnTeacherLogin.Click += new System.EventHandler(this.btnTeacherLogin_Click);
            // 
            // btnRegisterMain
            // 
            this.btnRegisterMain.Location = new System.Drawing.Point(104, 32);
            this.btnRegisterMain.Name = "btnRegisterMain";
            this.btnRegisterMain.Size = new System.Drawing.Size(109, 27);
            this.btnRegisterMain.TabIndex = 1;
            this.btnRegisterMain.Text = "Register";
            this.btnRegisterMain.UseVisualStyleBackColor = true;
            this.btnRegisterMain.Click += new System.EventHandler(this.btnRegisterMain_Click);
            // 
            // btnLoginMain
            // 
            this.btnLoginMain.Location = new System.Drawing.Point(13, 32);
            this.btnLoginMain.Name = "btnLoginMain";
            this.btnLoginMain.Size = new System.Drawing.Size(82, 27);
            this.btnLoginMain.TabIndex = 0;
            this.btnLoginMain.Text = "Login";
            this.btnLoginMain.UseVisualStyleBackColor = true;
            this.btnLoginMain.Click += new System.EventHandler(this.btnLoginMain_Click);
            // 
            // grpLevel
            // 
            this.grpLevel.Controls.Add(this.rdoAdvanced);
            this.grpLevel.Controls.Add(this.rdoIntermediate);
            this.grpLevel.Controls.Add(this.rdoBeginner);
            this.grpLevel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F);
            this.grpLevel.Location = new System.Drawing.Point(10, 11);
            this.grpLevel.Name = "grpLevel";
            this.grpLevel.Size = new System.Drawing.Size(230, 110);
            this.grpLevel.TabIndex = 1;
            this.grpLevel.TabStop = false;
            this.grpLevel.Text = "Level";
            // 
            // rdoAdvanced
            // 
            this.rdoAdvanced.AutoSize = true;
            this.rdoAdvanced.Location = new System.Drawing.Point(16, 75);
            this.rdoAdvanced.Name = "rdoAdvanced";
            this.rdoAdvanced.Size = new System.Drawing.Size(89, 21);
            this.rdoAdvanced.TabIndex = 2;
            this.rdoAdvanced.TabStop = true;
            this.rdoAdvanced.Text = "Advanced";
            this.rdoAdvanced.UseVisualStyleBackColor = true;
            this.rdoAdvanced.CheckedChanged += new System.EventHandler(this.rdoAdvanced_CheckedChanged);
            // 
            // rdoIntermediate
            // 
            this.rdoIntermediate.AutoSize = true;
            this.rdoIntermediate.Location = new System.Drawing.Point(16, 52);
            this.rdoIntermediate.Name = "rdoIntermediate";
            this.rdoIntermediate.Size = new System.Drawing.Size(104, 21);
            this.rdoIntermediate.TabIndex = 1;
            this.rdoIntermediate.TabStop = true;
            this.rdoIntermediate.Text = "Intermediate";
            this.rdoIntermediate.UseVisualStyleBackColor = true;
            this.rdoIntermediate.CheckedChanged += new System.EventHandler(this.rdoIntermediate_CheckedChanged);
            // 
            // rdoBeginner
            // 
            this.rdoBeginner.AutoSize = true;
            this.rdoBeginner.Location = new System.Drawing.Point(16, 29);
            this.rdoBeginner.Name = "rdoBeginner";
            this.rdoBeginner.Size = new System.Drawing.Size(83, 21);
            this.rdoBeginner.TabIndex = 0;
            this.rdoBeginner.TabStop = true;
            this.rdoBeginner.Text = "Beginner";
            this.rdoBeginner.UseVisualStyleBackColor = true;
            this.rdoBeginner.CheckedChanged += new System.EventHandler(this.rdoBeginner_CheckedChanged);
            // 
            // grpCategory
            // 
            this.grpCategory.Controls.Add(this.Available);
            this.grpCategory.Controls.Add(this.Category);
            this.grpCategory.Controls.Add(this.label2);
            this.grpCategory.Controls.Add(this.label1);
            this.grpCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F);
            this.grpCategory.Location = new System.Drawing.Point(10, 130);
            this.grpCategory.Name = "grpCategory";
            this.grpCategory.Size = new System.Drawing.Size(488, 228);
            this.grpCategory.TabIndex = 2;
            this.grpCategory.TabStop = false;
            this.grpCategory.Text = "Courses";
            // 
            // Available
            // 
            this.Available.FormattingEnabled = true;
            this.Available.ItemHeight = 17;
            this.Available.Location = new System.Drawing.Point(166, 59);
            this.Available.Name = "Available";
            this.Available.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.Available.Size = new System.Drawing.Size(308, 140);
            this.Available.TabIndex = 3;
            // 
            // Category
            // 
            this.Category.FormattingEnabled = true;
            this.Category.ItemHeight = 17;
            this.Category.Location = new System.Drawing.Point(20, 59);
            this.Category.Name = "Category";
            this.Category.Size = new System.Drawing.Size(136, 140);
            this.Category.TabIndex = 2;
            this.Category.SelectedIndexChanged += new System.EventHandler(this.lstCategory_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(164, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Available Courses";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Category";
            // 
            // btnEnroll
            // 
            this.btnEnroll.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F);
            this.btnEnroll.Location = new System.Drawing.Point(196, 417);
            this.btnEnroll.Name = "btnEnroll";
            this.btnEnroll.Size = new System.Drawing.Size(113, 29);
            this.btnEnroll.TabIndex = 3;
            this.btnEnroll.Text = "Enroll Now";
            this.btnEnroll.UseVisualStyleBackColor = true;
            this.btnEnroll.Click += new System.EventHandler(this.btnEnroll_Click);
            // 
            // grpAdditional
            // 
            this.grpAdditional.Controls.Add(this.chkQuick);
            this.grpAdditional.Controls.Add(this.chkSelf);
            this.grpAdditional.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F);
            this.grpAdditional.Location = new System.Drawing.Point(10, 365);
            this.grpAdditional.Name = "grpAdditional";
            this.grpAdditional.Size = new System.Drawing.Size(488, 50);
            this.grpAdditional.TabIndex = 4;
            this.grpAdditional.TabStop = false;
            this.grpAdditional.Text = "Additional Materials";
            // 
            // chkQuick
            // 
            this.chkQuick.AutoSize = true;
            this.chkQuick.Location = new System.Drawing.Point(20, 20);
            this.chkQuick.Name = "chkQuick";
            this.chkQuick.Size = new System.Drawing.Size(105, 21);
            this.chkQuick.TabIndex = 1;
            this.chkQuick.Text = "Quick Guide";
            this.chkQuick.UseVisualStyleBackColor = true;
            // 
            // chkSelf
            // 
            this.chkSelf.AutoSize = true;
            this.chkSelf.Location = new System.Drawing.Point(155, 20);
            this.chkSelf.Name = "chkSelf";
            this.chkSelf.Size = new System.Drawing.Size(159, 21);
            this.chkSelf.TabIndex = 0;
            this.chkSelf.Text = "Self Learning Bundle";
            this.chkSelf.UseVisualStyleBackColor = true;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(510, 460);
            this.Controls.Add(this.grpAdditional);
            this.Controls.Add(this.btnEnroll);
            this.Controls.Add(this.grpCategory);
            this.Controls.Add(this.grpLevel);
            this.Controls.Add(this.grpUser);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Learnify";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.grpUser.ResumeLayout(false);
            this.grpLevel.ResumeLayout(false);
            this.grpLevel.PerformLayout();
            this.grpCategory.ResumeLayout(false);
            this.grpCategory.PerformLayout();
            this.grpAdditional.ResumeLayout(false);
            this.grpAdditional.PerformLayout();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.GroupBox grpUser;
        private System.Windows.Forms.Button btnTeacherLogin;
        private System.Windows.Forms.Button btnRegisterMain;
        private System.Windows.Forms.Button btnLoginMain;
        private System.Windows.Forms.GroupBox grpLevel;
        private System.Windows.Forms.RadioButton rdoAdvanced;
        private System.Windows.Forms.RadioButton rdoIntermediate;
        private System.Windows.Forms.RadioButton rdoBeginner;
        private System.Windows.Forms.GroupBox grpCategory;
        private System.Windows.Forms.ListBox Available;
        private System.Windows.Forms.ListBox Category;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnEnroll;
        private System.Windows.Forms.GroupBox grpAdditional;
        private System.Windows.Forms.CheckBox chkQuick;
        private System.Windows.Forms.CheckBox chkSelf;
    }
}