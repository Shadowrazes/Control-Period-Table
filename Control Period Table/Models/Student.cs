using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Avalonia.Media;

namespace Control_Period_Table.Models
{
    public class Student : INotifyPropertyChanged
    {
        string math = "0";
        string visualProgramming = "0";
        string siaod = "0";
        double average = 0;

        string mathColor;
        string visualProgrammingColor;
        string siaodColor;
        string averageColor;

        public Student(string _Fio = "Я Саня Битс", string _Math = "0,5", string _VisualProgramming = "0,5", string _Siaod = "1")
        {
            Fio = _Fio;
            Math = _Math;
            VisualProgramming = _VisualProgramming;
            Siaod = _Siaod;
            MathColor = VisualProgrammingColor = SiaodColor = AverageColor = "OrangeRed";
        }

        public string MathColor 
        { 
            get => mathColor; 
            set => mathColor = value; 
        }
        public string VisualProgrammingColor
        {
            get => visualProgrammingColor;
            set => visualProgrammingColor = value;
        }
        public string SiaodColor
        {
            get => siaodColor;
            set => siaodColor = value;
        }
        public string AverageColor
        {
            get => averageColor;
            set => averageColor = value;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public bool IsSelected { get; set; }
        public string Color { get; set; }

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void RefreshAverage()
        {
            if(math != "" && visualProgramming != "" && siaod != "")
                Average = (Convert.ToDouble(math) + Convert.ToDouble(visualProgramming) + Convert.ToDouble(siaod)) / 3.0;
        }

        private void SetCScolor(ref string color, string discipline)
        {
            if (discipline != "")
            {
                if (Convert.ToDouble(discipline) == 0)
                    color = "OrangeRed";
                if (Convert.ToDouble(discipline) == 1)
                    color = "Yellow";
                if (Convert.ToDouble(discipline) == 2)
                    color = "LightGreen";
            }
        }

        public string Fio { get; set; }
        public string Math
        {
            get => math;
            set
            {
                math = value;
                SetCScolor(ref mathColor, Math);
                RefreshAverage();
            }
        }
        public string VisualProgramming
        {
            get => visualProgramming;
            set
            {
                visualProgramming = value;
                SetCScolor(ref visualProgrammingColor, VisualProgramming);
                RefreshAverage();
            }
        }
        public string Siaod
        {
            get => siaod;
            set
            {
                siaod = value;
                SetCScolor(ref siaodColor, Siaod);
                RefreshAverage();
            }
        }
        public double Average 
        { 
            get => average;
            set
            {
                average = value;
                if (average < 1)
                    AverageColor = "OrangeRed";
                else if (average < 1.5)
                    AverageColor = "Yellow";
                else
                    AverageColor = "LightGreen";
                NotifyPropertyChanged();
            } 
        }
    }
}
