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
    public partial class FormMain : Form    
    {
        public List<Student> students = new List<Student>();

        public FormMain()
        {
            InitializeComponent();
        }
        private void FormMain_Load(object sender, EventArgs e)
        {
            Student student1 = new Student("Kathy Geise|98|88|91");
            Student student2 = new Student("Rob Jones|91|95|86");
            Student student3 = new Student("Sally James|97|91|88");
            students.Add(student1);
            students.Add(student2);
            students.Add(student3);

            LoadStudentListBox();
        }

        private void LoadStudentListBox()
        {
            //Clear the listBox
            listBox1.Items.Clear();

            //Add the students from the list to the listBox
            foreach(Student s in students)
            {
                listBox1.Items.Add(s);
            }

            //Set the selected index to zero
            if (listBox1.Items.Count > 0)
                listBox1.SelectedIndex = 0;
            else
                ClearLabels();
        }

        private void ClearLabels()
        {
            this.txtScoreTotal.Text = "";
            this.txtAverage.Text = "";
            this.txtScoreCount.Text = "";
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            // Create an instance of the Add New Student Form
            FormNewStudent addForm = new FormNewStudent();
             DialogResult button = addForm.ShowDialog();

            // Retrieve information if OK is clicked
            if (button == DialogResult.OK)
            {
                students.Add((Student)addForm.Tag);
                LoadStudentListBox();
            }   
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                //Cast the information from the listBox to a Student object
                Student student = (Student)listBox1.SelectedItem;

                txtScoreTotal.Text = student.ScoreTotal.ToString();
                txtScoreCount.Text = student.ScoreCount.ToString();
                txtAverage.Text = student.ScoreAverage.ToString();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                // Create an instance of the Update Student Form
                // Pass the calling form so the called form can update fields
                FormScores updateForm = new FormScores(this);

                //FormScores updateForm = new FormScores();
                DialogResult button = updateForm.ShowDialog();

                // Retrieve information if OK is clicked
                //if (button == DialogResult.OK)
                //{
                //    // Update student data
                //    LoadStudentListBox();
                //}
                LoadStudentListBox();
                
            }
        }

        // Delete a student and the student scores from the listBox
        // Notice this will delete the student even if the User does not press OK
        // There is no way to recover the deleted data
        private void btnDelete_Click(object sender, EventArgs e)
        {
            int idx = listBox1.SelectedIndex;
            // Check the User has selected a student
            if (idx != -1)
            { 
                if (listBox1.Items.Count == 1) // only one student
                {
                    //Clear the listBox
                    listBox1.Items.Clear();
                    // Clear the Average, Count and Total Fields
                    ClearLabels();
                }
                else
                {
                    // Delete the selected student
                    listBox1.Items.RemoveAt(idx);
                    // Reset the listBox cursor
                    listBox1.SelectedIndex = 0;
                    // Calculate the data for the student at index 0
                    // Cast the information from the listBox to a Student object
                    Student student = (Student)listBox1.SelectedItem;

                    txtScoreTotal.Text = student.ScoreTotal.ToString();
                    txtScoreCount.Text = student.ScoreCount.ToString();
                    txtAverage.Text = student.ScoreAverage.ToString();
                }
            }
        }
    }
}
