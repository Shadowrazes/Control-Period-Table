using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Control_Period_Table.Models
{
    public class Student
    {
        string math = "0";
        string visualProgramming = "0";
        string siaod = "0";
        double average = 0;

        public Student(string _Fio = "Я Саня Битс", string _Math = "0,5", string _VisualProgramming = "0,5", string _Siaod = "1")
        {
            Fio = _Fio;
            Math = _Math;
            VisualProgramming = _VisualProgramming;
            Siaod = _Siaod;
        }

        private void RefreshAverage()
        {
            Average = (Convert.ToDouble(math) + Convert.ToDouble(visualProgramming) + Convert.ToDouble(siaod)) / 3.0;
        }

        public string Fio { get; set; }
        public string Math
        {
            get => math;
            set
            {
                math = value;
                RefreshAverage();
            }
        }
        public string VisualProgramming
        {
            get => visualProgramming;
            set
            {
                visualProgramming = value;
                RefreshAverage();
            }
        }
        public string Siaod
        {
            get => siaod;
            set
            {
                siaod = value;
                RefreshAverage();
            }
        }
        public double Average 
        { 
            get => average;
            set
            {
                average = value;
            } 
        }
    }
}
