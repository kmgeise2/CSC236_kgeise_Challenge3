using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CSC236_kgeise_Challenge3;

namespace CSC236_kgeise_Challenge3 
{
    public partial class FormScores : Form
    {
        // Local variables
        string ssep = "|";
        List<int> studentScores = new List<int>(); // Keep track of all score modifications

        // Pass the Student Scores form as a variable to the
        // Update Student Scores Form
        // You can access the original student list and make changes to it
        // Only the reference of Student Scores Form is passed as a field
        // (field has an underscore in the name)

        private FormMain _scoresMainForm; // The field is the underscore variable
        public FormScores(FormMain studentScoresForm) : this()
        {
	        // Update the field reference with the passed form reference
            _scoresMainForm = studentScoresForm;
	    }

        public FormScores()
        {
            InitializeComponent();
        }

        private void FormScores_Load(object sender, EventArgs e)
        {
            // Retrieve the student Name from the invoking Form by
            // creating a new instance of the Student object
            // using data from the students array
            
            Student selectedStudent = _scoresMainForm.students[_scoresMainForm.listBox1.SelectedIndex];
            txtName.Text = selectedStudent.Name;

            // Convert the scores from the selected student Main form listBox
            // I had trouble getting the selectedStudents.Scores from the
            // Student Object, but this worked
            string blah = _scoresMainForm.listBox1.SelectedItem.ToString();

            //Parse the string from the Main Form listBox
            string[] columns = blah.Split(ssep);
            string strName = columns[0]; //Not used for information only

            //Load the integer studentScores array using the parsed data

            if (columns.Length > 1) // there are scores in the string array
            {
                for(int idx = 1; idx < columns.Length; ++idx)
                {
                    if (columns[idx] != "")
                        studentScores.Add(Convert.ToInt32(columns[idx]));
                }
            }
            // The studentScores array now contains the passed scores
            LoadScoresListBox(); 
        }
        // Update the Form with Scores 
        private void LoadScoresListBox()
        {
            scoresListBox.Items.Clear();
            foreach(int score in studentScores)
            {
                scoresListBox.Items.Add(score); //Type int converted to string?
            }
            //Set the selected index to zero
            if (scoresListBox.Items.Count > 0)
                scoresListBox.SelectedIndex = 0;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            studentScores.Clear();
            scoresListBox.Items.Clear();
        }

       
        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Create an instance of the Add Score Form
            FormScoresAdd addScore = new FormScoresAdd();
            DialogResult button = addScore.ShowDialog();

            // Retrieve information if OK is clicked
            if (button == DialogResult.OK)
            {
                //Add new score to local list box using the Tag parameter
                scoresListBox.Items.Add(addScore.Tag); //Tag is string format

                // Update instance of studentScores
                int newscore = Convert.ToInt32(addScore.Tag);
                studentScores.Add(newscore);

                // Update the scoresListBox
                LoadScoresListBox();
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            int idx = scoresListBox.SelectedIndex; 

            // Reset the cursor in the listBox
            scoresListBox.SelectedIndex = 0; 

            // Remove the item from the Form listBox
            scoresListBox.Items.RemoveAt(idx);

            // Remove the item from the scores array
            studentScores.RemoveAt(idx);
        }

        // Create a new temporary Student object
        // Then update the students array in the Main method 
        // with the temporary student data
        private void btnOK_Click(object sender, EventArgs e)
        {
            // Format the temporary data for insertion into students array
            Student tempStudent = new Student();
            tempStudent.Name = txtName.Text;
            tempStudent.Scores = studentScores;

            // Set the student object in the main form to the temporary data
            int idx = _scoresMainForm.listBox1.SelectedIndex;

            if (idx != -1) 
            {
                try
                {
                    _scoresMainForm.students.RemoveAt(idx);
                    _scoresMainForm.students.Insert(idx, tempStudent); 
                }
                catch
                {
                    //Do nothing
                }
            }
            // Close the Update form 
            this.Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            // Retrieve selected score

            string selectedScore = Convert.ToString(scoresListBox.SelectedItem); 

            // Create an instance of the Update Score Form
            // Pass the selected score to initialize the textbox
            FormScoresUpdate updateScore = new FormScoresUpdate(selectedScore);
            DialogResult button = updateScore.ShowDialog();

            // Retrieve information if OK is clicked
            if (button == DialogResult.OK)
            {
                int newscore = Convert.ToInt32(updateScore.Tag);

                //Update score in list box
                scoresListBox.Items[scoresListBox.SelectedIndex] = newscore;

                // Update the temporary scores holding array
                studentScores[scoresListBox.SelectedIndex] = newscore;

                // close the window
                updateScore.Close();
                
            }
        }
    }
}
