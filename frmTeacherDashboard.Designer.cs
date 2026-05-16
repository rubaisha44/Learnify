using System;

namespace Learnify
{
    partial class frmTeacherDashboard
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
            this.dgvCourses = new System.Windows.Forms.DataGridView();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btEdit = new System.Windows.Forms.Button();
            this.btnToggleReg = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCourses)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvCourses
            // 
            this.dgvCourses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCourses.Location = new System.Drawing.Point(50, 30);
            this.dgvCourses.Name = "dgvCourses";
            this.dgvCourses.Size = new System.Drawing.Size(700, 300);
            this.dgvCourses.TabIndex = 0;
            this.dgvCourses.SelectionChanged += new System.EventHandler(this.dgvCourses_SelectionChanged);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(150, 360);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(100, 35);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "Add Course";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btEdit
            // 
            this.btEdit.Location = new System.Drawing.Point(300, 360);
            this.btEdit.Name = "btEdit";
            this.btEdit.Size = new System.Drawing.Size(100, 35);
            this.btEdit.TabIndex = 2;
            this.btEdit.Text = "Edit Course";
            this.btEdit.UseVisualStyleBackColor = true;
            this.btEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnToggleReg
            // 
            this.btnToggleReg.Location = new System.Drawing.Point(450, 360);
            this.btnToggleReg.Name = "btnToggleReg";
            this.btnToggleReg.Size = new System.Drawing.Size(150, 35);
            this.btnToggleReg.TabIndex = 3;
            this.btnToggleReg.Text = "Toggle Registration";
            this.btnToggleReg.UseVisualStyleBackColor = true;
            this.btnToggleReg.Click += new System.EventHandler(this.btnToggleReg_Click);
            // 
            // frmTeacherDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnToggleReg);
            this.Controls.Add(this.btEdit);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.dgvCourses);
            this.Name = "frmTeacherDashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Teacher Dashboard";
            ((System.ComponentModel.ISupportInitialize)(this.dgvCourses)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.DataGridView dgvCourses;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btEdit;
        private System.Windows.Forms.Button btnToggleReg;
    }
}