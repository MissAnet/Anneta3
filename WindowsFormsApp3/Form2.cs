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
    public partial class Form2 : Form
    {
        private Class1 subd = new Class1();

        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = subd.DGW_table();
            //ListBox1 Kafedr
            dataGridView2.DataSource = subd.GetKaf();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            textBox6.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[0].Value);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //Вывод информации в textBox
            label13.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[0].Value);
            textBox1.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[1].Value);
            textBox2.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[2].Value);
            textBox3.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[3].Value);
            textBox4.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[4].Value);
            textBox5.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[5].Value);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Редактирование
            subd.UpdateDB(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text, label13.Text);
            dataGridView1.DataSource = subd.DGW_table();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Удаление
            string text = textBox6.Text;
            if (text == "")
                MessageBox.Show("ВВедите корректный ID");
            else
            {
                DialogResult dialogResult = MessageBox.Show("Вы уверенны что хотите удалить " + text + "? Если данного id нет , будет удален 1-ый", "Sure?", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    subd.DeleteBD(textBox6.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[0].Value));
                }
                else if (dialogResult == DialogResult.No)
                {
                }
            }
            dataGridView1.DataSource = subd.DGW_table();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (textBox7.Text == "" || textBox8.Text == "" || textBox9.Text == "" || textBox10.Text == "")
                MessageBox.Show("Введите все значения");
            else
            {
                //Select kafedr(по умолчанию 1)
                int number = (Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value));
                //id - работает вроде бы норм
                int i = 0;
                int numb = 0; 
                int id = 0;

                foreach (DataGridViewRow dr in dataGridView1.Rows)
                {
                    id = Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value);
                    if(id>numb)
                        numb = id;
                    i++;
                }

                //Добавление данных
                subd.InsertBD(textBox7.Text, textBox8.Text, textBox9.Text, textBox10.Text, number + 1, numb + 1);
            }

            dataGridView1.DataSource = subd.DGW_table();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = subd.DGW_table();
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            //ввод только цифр и удаления
            char number = e.KeyChar;

            if (!Char.IsDigit(number) && number != 8 )
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

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;

            if (!Char.IsDigit(number) && number != 8)
            {
                e.Handled = true;
            }
        }
        private void textBox8_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;

            if (!Char.IsDigit(number) && number != 8)
            {
                e.Handled = true;
            }
        }
        private void textBox9_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;

            if (!Char.IsDigit(number) && number != 8)
            {
                e.Handled = true;
            }
        }
    }
}
