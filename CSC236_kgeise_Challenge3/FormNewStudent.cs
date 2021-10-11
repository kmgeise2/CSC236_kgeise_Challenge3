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
    public partial class FormNewStudent : Form
    {
        Student student = new Student();
        public FormNewStudent()
        {
            InitializeComponent();
        }

        private void btnAddScore_Click(object sender, EventArgs e)
        {
            if (IsValidData())
            {
                int score = Convert.ToInt32(txtScore.Text);
                student.Scores.Add(score);
                DisplayScores();
                txtScore.Focus();
            }
        }

        private void DisplayScores()
        {
            txtDisplayScores.Text = "";
            foreach (var score in student.Scores)
            {
                txtDisplayScores.Text += score.ToString() + " ";
            }
        }

        private bool IsValidData()
        {
            return
                //Validate that the name text box has data
                Validator.IsPresent(txtName) &&

                //Validate the score textbox
                Validator.IsPresent(txtScore) &&
                Validator.IsInt32(txtScore) &&
                Validator.IsWithinRange(txtScore, 0, 100);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            student.Scores.Clear();
            DisplayScores();
            txtScore.Focus();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (Validator.IsPresent(txtName))
            {
                student.Name = txtName.Text;
                this.DialogResult = DialogResult.OK;
                this.Tag = student;
            }
        }
    }
}
