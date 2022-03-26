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

        public Student(string _Fio = "Я Саня Битс", string _Math = "0", string _VisualProgramming = "0", string _Siaod = "0")
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
            set
            {
                mathColor = value;
                NotifyPropertyChanged();
            }
        }
        public string VisualProgrammingColor
        {
            get => visualProgrammingColor;
            set
            {
                visualProgrammingColor = value;
                NotifyPropertyChanged();
            }
        }
        public string SiaodColor
        {
            get => siaodColor;
            set
            {
                siaodColor = value;
                NotifyPropertyChanged();
            }
        }
        public string AverageColor
        {
            get => averageColor;
            set
            {
                averageColor = value;
                NotifyPropertyChanged();
            }
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
            try
            {
                Average = (Convert.ToDouble(math) + Convert.ToDouble(visualProgramming) + Convert.ToDouble(siaod)) / 3.0;
            }
            catch
            {
                Average = 0;
            }
        }

        private void SetCScolor(ref string color, string discipline)
        {
            try
            {
                if (discipline == "math")
                {
                    if (Convert.ToDouble(math) == 0)
                        MathColor = "OrangeRed";
                    else if (Convert.ToDouble(math) == 1)
                        MathColor = "Yellow";
                    else if (Convert.ToDouble(math) == 2)
                        MathColor = "LightGreen";
                    else
                    {
                        MathColor = "White";
                        Math = "#ERROR";
                    }
                }
                else if (discipline == "visual")
                {
                    if (Convert.ToDouble(visualProgramming) == 0)
                        VisualProgrammingColor = "OrangeRed";
                    else if (Convert.ToDouble(visualProgramming) == 1)
                        VisualProgrammingColor = "Yellow";
                    else if (Convert.ToDouble(visualProgramming) == 2)
                        VisualProgrammingColor = "LightGreen";
                    else
                    {
                        VisualProgrammingColor = "White";
                        VisualProgramming = "#ERROR";
                    }
                }
                else if (discipline == "siaod")
                {
                    if (Convert.ToDouble(siaod) == 0)
                        SiaodColor = "OrangeRed";
                    else if (Convert.ToDouble(siaod) == 1)
                        SiaodColor = "Yellow";
                    else if (Convert.ToDouble(siaod) == 2)
                        SiaodColor = "LightGreen";
                    else
                    {
                        SiaodColor = "White";
                        Siaod = "#ERROR";
                    }
                }
                else
                {

                }
            }
            catch
            {
                if (discipline == "math")
                {
                    MathColor = "White";
                    Math = "#ERROR";
                }
                else if (discipline == "visual")
                {
                    VisualProgrammingColor = "White";
                    VisualProgramming = "#ERROR";
                }
                else if (discipline == "siaod")
                {
                    SiaodColor = "White";
                    Siaod = "#ERROR";
                }
                else
                {

                }
            }
        }

        public string Fio { get; set; }
        public string Math
        {
            get => math;
            set
            {
                math = value;
                if (math != "" && math != "#ERROR")
                {
                    SetCScolor(ref mathColor, "math");
                }
                RefreshAverage();
                NotifyPropertyChanged();
            }
        }
        public string VisualProgramming
        {
            get => visualProgramming;
            set
            {
                visualProgramming = value;
                if (visualProgramming != "" && visualProgramming != "#ERROR")
                {
                    SetCScolor(ref visualProgrammingColor, "visual");
                }
                RefreshAverage();
                NotifyPropertyChanged();
            }
        }
        public string Siaod
        {
            get => siaod;
            set
            {
                siaod = value;
                if (siaod != ""  && siaod != "#ERROR")
                {
                    SetCScolor(ref siaodColor, "siaod");
                }
                RefreshAverage();
                NotifyPropertyChanged();
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
