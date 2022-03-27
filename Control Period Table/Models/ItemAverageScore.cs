using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Control_Period_Table.Models
{
    public class ItemAverageScore
    {
        double score;
        string color;

        public ItemAverageScore()
        {
            score = 0;
            color = "Red";
        }

        public double Score 
        {
            get => score;
            set => score = value;
        }

        public string Color
        {
            get => color;
            set => color = value;
        }
    }
}
