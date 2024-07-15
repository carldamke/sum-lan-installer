using System.Windows.Forms;

namespace sum_lan_installer
{
    partial class Form2
    {
        private System.ComponentModel.IContainer components = null;
        private RadioButton rbtnSuM1;
        private RadioButton rbtnSuM2;
        private RadioButton rbtnSuM3;
        private Button btnOk;
        private Button btnCancel;

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
            this.rbtnSuM1 = new System.Windows.Forms.RadioButton();
            this.rbtnSuM2 = new System.Windows.Forms.RadioButton();
            this.rbtnSuM3 = new System.Windows.Forms.RadioButton();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // rbtnSuM1
            // 
            this.rbtnSuM1.AutoSize = true;
            this.rbtnSuM1.Location = new System.Drawing.Point(12, 12);
            this.rbtnSuM1.Name = "rbtnSuM1";
            this.rbtnSuM1.Size = new System.Drawing.Size(55, 17);
            this.rbtnSuM1.TabIndex = 0;
            this.rbtnSuM1.TabStop = true;
            this.rbtnSuM1.Text = "SuM 1";
            this.rbtnSuM1.UseVisualStyleBackColor = true;
            // 
            // rbtnSuM2
            // 
            this.rbtnSuM2.AutoSize = true;
            this.rbtnSuM2.Location = new System.Drawing.Point(12, 35);
            this.rbtnSuM2.Name = "rbtnSuM2";
            this.rbtnSuM2.Size = new System.Drawing.Size(55, 17);
            this.rbtnSuM2.TabIndex = 1;
            this.rbtnSuM2.TabStop = true;
            this.rbtnSuM2.Text = "SuM 2";
            this.rbtnSuM2.UseVisualStyleBackColor = true;
            // 
            // rbtnSuM3
            // 
            this.rbtnSuM3.AutoSize = true;
            this.rbtnSuM3.Location = new System.Drawing.Point(12, 58);
            this.rbtnSuM3.Name = "rbtnSuM3";
            this.rbtnSuM3.Size = new System.Drawing.Size(55, 17);
            this.rbtnSuM3.TabIndex = 2;
            this.rbtnSuM3.TabStop = true;
            this.rbtnSuM3.Text = "SuM 3";
            this.rbtnSuM3.UseVisualStyleBackColor = true;
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(12, 81);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 3;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(93, 81);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Abbrechen";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // GameSelectionForm
            // 
            this.ClientSize = new System.Drawing.Size(250, 116);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.rbtnSuM3);
            this.Controls.Add(this.rbtnSuM2);
            this.Controls.Add(this.rbtnSuM1);
            this.Name = "GameSelectionForm";
            this.Text = "Spielauswahl";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
