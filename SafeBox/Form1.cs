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
                safeBox.MixSafeBox(int.Parse(textBoxLevel.Text));
                ClearGridData();
                AddGridTable();
                UpdateGridData();
                DrawGridImage();                            
            }
        }

        private void ClearGridData()
        {
            dataGridView1.RowCount = 0;
            dataGridView1.ColumnCount = 0;
        }

        private void AddGridTable()
        {
            DataGridViewImageColumn[] imgColumn = new DataGridViewImageColumn[safeBox.Size];
            for (int i = 0; i < safeBox.Size; i++)
            {
                imgColumn[i] = new DataGridViewImageColumn();
                imgColumn[i].Name = "Images" + i;
                dataGridView1.Columns.Add(imgColumn[i]);

            }
            dataGridView1.RowCount = safeBox.Size;
        }

        private void DrawGridImage()
        {
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

                    dataGridView1.Rows[i].Cells[j].Value = imageList1.Images[imgIndx];
                }
            }
            AutoSizeGrid();
        }

        private void AutoSizeGrid()
        {
            int width = dataGridView1.ColumnCount * dataGridView1.Columns[0].Width;
            int height = dataGridView1.RowCount * dataGridView1.Rows[0].Height;
            dataGridView1.Size = new Size(width, height);
        }

        private void UpdateGridData()
        {
            for (int i = 0; i < safeBox.Size; i++)
            {
                for (int j = 0; j < safeBox.Size; j++)
                {
                     DrawGridImage();
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

        private void textBoxLevel_TextChanged(object sender, EventArgs e)
        {
            CheckIntInTextBox((TextBox)sender);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            safeBox.ChangeValue(e.RowIndex, e.ColumnIndex);
            UpdateGridData();
            if (safeBox.CheckResult())
            {
                MessageBox.Show("YOU WIN");
            }

        }
    }
}
