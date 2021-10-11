using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSC236_kgeise_Challenge3 
{
    public partial class FormScoresUpdate : Form
    {
        public FormScoresUpdate(string strScore)
        {
            InitializeComponent();
            txtUpdateScore.Text = strScore;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            // Avoid empty score
            if (txtUpdateScore.Text != "")
            {
                int score = Convert.ToInt32(txtUpdateScore.Text);
                // Validate range
                if (Validator.IsWithinRange(txtUpdateScore, 0, 100))
                {
                    // Return the score when user selects Add button
                    this.DialogResult = DialogResult.OK; //Button is Update, not OK
                    this.Tag = txtUpdateScore.Text; // string
                }
            }
        }

        private void FormScoresUpdate_Load(object sender, EventArgs e)
        {
            // Original score is loaded to box see passed parameter above
        }
    }
}
