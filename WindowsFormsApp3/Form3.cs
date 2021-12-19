using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace WindowsFormsApp3
{
    public partial class Form3 : Form
    {
        private Class2 subd = new Class2();
        public Form3()
        {
            InitializeComponent();
        }
        public void Form3_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = subd.DGW_table();
        }
        public void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[1].Value);
            textBox2.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[2].Value);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Редактирование
            subd.UpdateDB(textBox1.Text, textBox2.Text, dataGridView1.CurrentRow.Cells[0].Value.ToString());
            dataGridView1.DataSource = subd.DGW_table();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox3.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[0].Value);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //Удаление
            string text = textBox3.Text;
            if (text == "")
                MessageBox.Show("ВВедите корректный ID");
            else
            {
                DialogResult dialogResult = MessageBox.Show("Вы уверенны что хотите удалить " + text + "? Если данного id нет , будет удален 1-ый", "Sure?", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    subd.DeleteBD(textBox3.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[0].Value));
                }
                else if (dialogResult == DialogResult.No)
                {
                }
            }
            dataGridView1.DataSource = subd.DGW_table();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //id
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

            //Добавление данных
            subd.InsertBD(textBox4.Text, textBox5.Text, numb + 1);

            dataGridView1.DataSource = subd.DGW_table();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = subd.DGW_table();
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;

            if (!Char.IsDigit(number) && number != 8)
            {
                e.Handled = true;
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;

            if (!Char.IsDigit(number) && number != 8)
            {
                e.Handled = true;
            }
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;

            if (!Char.IsDigit(number) && number != 8)
            {
                e.Handled = true;
            }
        }
    }
}
