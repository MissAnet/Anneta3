using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LiveCharts;
using LiveCharts.Wpf;

namespace WindowsFormsApp3
{

    public partial class Form1 : Form
    {
        private Class1 subd = new Class1();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = subd.DGW_table();
            grafik();
        }

        private void grafik()
        {
            List<string> x_values = new List<string>();
            ChartValues<int> y_values = new ChartValues<int>();


            int[] nameCount = new int[dataGridView1.Rows.Count];
            if (dataGridView1 != null)
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Cells[4].Value != null && row.Cells[4].Value.ToString() == "Высшее")
                    {
                        nameCount[0] += 1;
                    }
                    if (row.Cells[4].Value != null && row.Cells[4].Value.ToString() == "Среднее")
                    {
                        nameCount[1] += 1;
                    }
                    if (row.Cells[4].Value != null && row.Cells[4].Value.ToString() == "Высшее-специальное")
                    {
                        nameCount[2] += 1;
                    }
                    if (row.Cells[4].Value != null && row.Cells[4].Value.ToString() == "Высшее-военное")
                    {
                        nameCount[3] += 1;
                    }
                }
            }

            for (int j = 0; j < 4; j++)
                y_values.Add(int.Parse(nameCount[j].ToString()));

            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                x_values.Add(dataGridView1[4, i].Value.ToString());
            }

            cartesianChart1.AxisX.Clear();
            cartesianChart1.AxisX.Add(new Axis()
            {
                Title = "Образование",
                Labels = new[] { "Высшее", "Среднее", "Высшее-спецальное", "Высшее-военное" }
            });
            LineSeries line = new LineSeries();
            line.Title = "";
            line.Values = y_values;

            SeriesCollection series = new SeriesCollection();
            series.Add(line);

            cartesianChart1.Series = series;
            cartesianChart1.LegendLocation = LegendLocation.Top;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            Hide();
            form2.ShowDialog();
            Show();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = subd.DGW_table();
            grafik();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            Hide();
            form3.ShowDialog();
            Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4();
            Hide();
            form4.ShowDialog();
            Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form5 form5 = new Form5();
            Hide();
            form5.ShowDialog();
            Show();
        }
    }
}
