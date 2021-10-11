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
    public partial class FormScoresAdd : Form
    {
        //int score = 0;
        public FormScoresAdd()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Avoid empty score
            if (txtAddScore.Text != "")
            {
                int score = Convert.ToInt32(txtAddScore.Text);
                // Validate range
                if (Validator.IsWithinRange(txtAddScore, 0, 100))
                {
                    // Return the score when user selects Add button
                    this.DialogResult = DialogResult.OK; //Button is Add, not OK
                    this.Tag = txtAddScore.Text; // string
                }
            }
            //else
            //{
            //    score = 0;
            //}
            //return;
        }
    }
}
