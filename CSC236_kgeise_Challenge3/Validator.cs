using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSC236_kgeise_Challenge3 
{
    public static class Validator
    {
        // Class is static so field must be static
        private static string title = "Entry Error";

        // This is a property
        public static string Title
        {
            get { return title; }
            set { title = value; }
        }
        //Check to see if user entered a value 
        public static bool IsPresent(TextBox textBox)
        {
            if(textBox.Text == "")
            {
                MessageBox.Show(textBox.Tag + " must enter a name.", Title);
                return false;
            }
            else
            {
                return true;
            }
        }
        //Check that an integer is present
        public static bool IsInt32(TextBox textBox)
        {
            int number = 0;
            if (Int32.TryParse(textBox.Text, out number))
            {
                return true;
            }
            else
            {
                MessageBox.Show(textBox.Tag + " must be an integer.", Title);
                textBox.Focus();
                return false;
            }
        }
        // Check to see if entry is between a specified range
        public static bool IsWithinRange(TextBox textBox, decimal min, decimal max)
        {
            decimal number = Convert.ToDecimal(textBox.Text);
            if (number < min || number > max)
            {
                MessageBox.Show(textBox.Tag + " must be between " + min + " and " + max + ".", Title);
                textBox.Focus();
                return false;
            }
            else
            {
                return true;
            }
            
        }


    }
}
