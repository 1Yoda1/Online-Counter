using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Online_Counter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
            string[] arrayDays = onlineBox.Lines;
            hours.Text = Convert.ToString(Counter(arrayDays));
        }

        private int Counter(string[] box)
        {
            var mainList = new List<string>();
            var hoursList = new List<string>();
            var minutesList = new List<string>();
            for (var  i = 0; i <= 6; i++)
            {
                var array = box[i].Split();
                mainList.Add(array[1].Remove(9).Substring(1));
            }
            for (var i = 0; i <= 6; i++)
            {
                string[] final = mainList[i].Split(':');
                hoursList.Add(final[0]);
                minutesList.Add(final[1]);
            }
            var allDayHours = new List<int>();
            var allDaysMinutes = new List<int>();
            int sumHours = 0, sumMinutes = 0;
            for (var i = 0; i <= 6; i++)
            {
                allDayHours.Add(Convert.ToInt32(hoursList[i]));
                allDaysMinutes.Add(Convert.ToInt32(minutesList[i]));
                sumHours += allDayHours[i];
                sumMinutes += allDaysMinutes[i];
            }
            var minutesToHours = Convert.ToDouble(sumMinutes) / 60;
            var result = Convert.ToString(minutesToHours).Split(',');
            return sumHours + Convert.ToInt32(result[0]);
        }
    }
}
