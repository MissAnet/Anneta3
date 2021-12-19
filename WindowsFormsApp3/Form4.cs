using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public partial class Form4 : Form
    {
        private Class3 subd = new Class3();

        public Form4()
        {
            InitializeComponent();
            dataGridView2.DataSource = subd.GetKor();
            dataGridView3.DataSource = subd.GetOt();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = subd.DGW_table();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[1].Value);
            textBox2.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[2].Value);
            textBox3.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[3].Value);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int i = 0;
            int j = 0;
            int corpus = 1;
            int otvet = 1;
            int nucor = int.Parse(textBox2.Text);
            int nuot = int.Parse(textBox3.Text);
            bool tr = false;
            bool tr2 = false;
            foreach (DataGridViewRow dr in dataGridView2.Rows)
            {
                corpus = Convert.ToInt32(dataGridView2.Rows[i].Cells[0].Value);
                if (corpus == nucor)
                {
                    tr = true;
                    break;
                }    
                i++;
            }
            foreach (DataGridViewRow dr2 in dataGridView3.Rows)
                {
                    otvet = Convert.ToInt32(dataGridView3.Rows[j].Cells[0].Value);
                    if (otvet == nuot)
                    {
                        tr2 = true;
                        break;
                    }
                        j++;
                }
            if (tr == false || tr2 == false)
                MessageBox.Show("ВВедите корректный данные");
            else
            {
                subd.UpdateDB(int.Parse(textBox1.Text), nucor, otvet, dataGridView1.CurrentRow.Cells[0].Value.ToString());
                dataGridView1.DataSource = subd.DGW_table();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox4.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[0].Value);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string text = textBox4.Text;
            if (text == "")
                MessageBox.Show("ВВедите корректный ID");
            else
            {
                DialogResult dialogResult = MessageBox.Show("Вы уверенны что хотите удалить " + text + "? Если данного id нет , будет удален 1-ый", "Sure?", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    subd.DeleteBD(textBox4.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[0].Value));
                }
                else if (dialogResult == DialogResult.No)
                {
                }
            }
            dataGridView1.DataSource = subd.DGW_table();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int number1 = Convert.ToInt32(dataGridView2.CurrentRow.Cells[0].Value);
            int number2 = Convert.ToInt32(dataGridView3.CurrentRow.Cells[0].Value);
            int i = 0;
            int numb = 0;
            int id = 0;

            foreach (DataGridViewRow dr in dataGridView1.Rows)
            {
                id = Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value);
                if (id > numb)
                    numb = id;
                i++;
            }

            subd.InsertBD(int.Parse(textBox5.Text), number1, number2, numb + 1);

            dataGridView1.DataSource = subd.DGW_table();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = subd.DGW_table();
        }
    }
}
