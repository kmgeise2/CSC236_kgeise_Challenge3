/*
 * CSC236 C# Programming Challenge #3
 * Class definition for the Student Class
 * 
 * Define a new class within the challenge Project
 * The namespace will be the namespace of the Project
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSC236_kgeise_Challenge3   // Your namespace will be different
{
    // Student Class
    public class Student
    {
        // Default is private
        private string name;
        private List<int> scoresList = new List<int>();
        private char sep = '|';

        /// <summary>
        /// method <c>Student</c>  
        /// </summary>
        public Student()
        {
        }

        /// <summary>
        /// method <c>Student</c> This method has the same name as the method 
        /// above but requires a passed string
        /// </summary>
        public Student(string studentAndScores)
        {
            string[] columns = studentAndScores.Split(sep);

            // Set name
            this.name = columns[0];

            // Set scores list  
            for (int i = 1; i < columns.Length; ++i)
            {
                if (columns[i] != "")
                    this.scoresList.Add(Convert.ToInt32(columns[i]));
            }
        }

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }
        public List<int> Scores
        {
            get
            {
                return scoresList;
            }
            set
            {
                scoresList = value;
            }
        }

        public char Sep
        {
            get { return sep; }
            set { sep = value; }
        }

        public int ScoreCount => scoresList.Count;

        public int ScoreTotal
        {
            get
            {
                int total = 0;
                for (int i = 0; i<scoresList.Count; ++i)
                {
                    // Plus equals sign means add and place result in same variable
                    total += Convert.ToInt32(scoresList[i]);
                }
                return total;
            }
        }
        public int ScoreAverage
        {
            get
            {
                double average = 0.0;
                double castTotal = ScoreTotal; //recast to double for rounding
                if (this.ScoreTotal > 0)
                    average = castTotal / ScoreCount;
                int rounded = (int)Math.Round(average);
                // else average = 0

                return rounded;
            }
        }
        public string GetScoresString()
        {
            string scoresString = "";
            foreach(int idx in scoresList)
            {
                // Notice the concatenation plus equals 
                // Place the separator | between each score
                //    and convert to string
                scoresString += sep.ToString() + idx.ToString();
            }
            return scoresString;
        }
        public override string ToString() => name + this.GetScoresString();

        #region ICloneable Members
        // For more information about the ICloneable Interface and the Clone()
        // method, see Microsoft Docs ICloneable Interface
        public object Clone()
        {
            Student s = new Student();
            s.Name = this.Name;
            foreach(int idx in this.Scores)
            {
                s.scoresList.Add(idx);
            }
            s.Sep = this.Sep;
            return s;
        }
        #endregion

    }
}
 