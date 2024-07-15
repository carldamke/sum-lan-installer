using System;
using System.Windows.Forms;

namespace sum_lan_installer
{
    public partial class Form2 : Form
    {
        public string SelectedGame { get; private set; }

        public Form2()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (rbtnSuM1.Checked)
                SelectedGame = "BFME1";
            else if (rbtnSuM2.Checked)
                SelectedGame = "BFME2";
            else if (rbtnSuM3.Checked)
                SelectedGame = "BFME25";

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
