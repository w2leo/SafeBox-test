using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SafeBox
{
    public partial class Form1 : Form
    {
        private SafeBox safeBox;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textSize.TextLength > 0)
            {
                safeBox = new SafeBox(int.Parse(textSize.Text));
                //safeBox.MixSafeBox(1);
                // VISUALIZE SAFEBOX
                dataGridView1.RowCount = 0;
                dataGridView1.ColumnCount = 0;

                DataGridViewImageColumn []imgColumn = new DataGridViewImageColumn[safeBox.Size];
                
                for (int i = 0; i < safeBox.Size; i++)
                {
                    imgColumn[i] = new DataGridViewImageColumn();
                    imgColumn[i].Name = "Images"+i;
                    dataGridView1.Columns.Add(imgColumn[i]);
                    
                }
               // dataGridView1.ColumnCount = safeBox.Size;
                dataGridView1.RowCount = safeBox.Size;

                // Image image = new Bitmap("C:\\Users\\Pictures\\elitefon.ru-27204.jpg");

                int imgIndx;
                for (int i = 0; i < safeBox.Size; i++)
                {
                    for (int j = 0; j < safeBox.Size; j++)
                    {
                        if (safeBox.GetData(i, j))
                        {
                            imgIndx = 1;
                        }
                        else imgIndx = 0;

                        int gg = imageList1.Images.Count;
                        MessageBox.Show($"image cont = {gg}");

                        imageList1.Images.Add(imageList1.Images[0]);
                        Image image;
                        image = imageList1.Images[0];

                        dataGridView1.Rows[i].Cells[j].Value = image;


                    }
                }

               // UpdateGridData();
            }
        }

        private void UpdateGridData()
        {
            for (int i = 0; i < safeBox.Size; i++)
            {
                for (int j = 0; j < safeBox.Size; j++)
                {
                    //int newX = safeBox.Size - i - 1;
                    // int newY = safeBox.Size - j - 1;
                 //   dataGridView1[i, j].Value = safeBox.GetData(i, j);

                }
            }
        }

        private void CheckIntInTextBox(TextBox textBox)
        {
            int number;
            string text = textBox.Text;
            if (text.Length > 0 && !int.TryParse(text, out number))
            {
                textBox.Text = text.Remove(text.Length - 1, 1);
                textBox.SelectionStart = textBox.TextLength;
            }
        }

        private void textSize_TextChanged(object sender, EventArgs e)
        {
            CheckIntInTextBox((TextBox)sender);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            CheckIntInTextBox((TextBox)sender);
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            CheckIntInTextBox((TextBox)sender);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int x = int.Parse(textBox1.Text);
            int y = int.Parse(textBox2.Text);
            if (safeBox.Size > 0)
            {
                safeBox.ChangeValue(x, y);
                UpdateGridData();
            }
            if (safeBox.CheckResult())
            {
                MessageBox.Show("YOU WIN");
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //MessageBox.Show($"x = {e.RowIndex}, y = {e.ColumnIndex}");
            safeBox.ChangeValue(e.RowIndex, e.ColumnIndex);
       //     UpdateGridData();
            if (safeBox.CheckResult())
            {
                MessageBox.Show("YOU WIN");
            }

        }
    }
}
