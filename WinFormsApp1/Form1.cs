using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        private Parser parser = new Parser();

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                FileReadResult result = parser.ReadCode(openFileDialog1.FileName);

                if (result.ErrorCode == FileReadErrorCode.Success)
                {
                    button2.Enabled = true;
                    richTextBox1.Text = parser.Code;
                    dataGridView1.Rows.Clear();
                    dataGridView2.Rows.Clear();
                    textBoxCL.Text = "";
                    textBoxRel.Text = "";
                    textBoxCLI.Text = "";
                    textBoxN.Text = "";
                }
                else
                {
                    button2.Enabled = false;
                }

                MessageBox.Show(result.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var result = parser.Analyze();

            textBoxCL.Text = result.CL.ToString();
            textBoxRel.Text = result.cl.ToString("F3");
            textBoxCLI.Text = result.CLI.ToString();
            textBoxN.Text = result.N.ToString();

            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            dataGridView1.Columns.Add("Line", "№ Строки");
            dataGridView1.Columns.Add("Operator", "Оператор ветвления");
            dataGridView1.Columns.Add("Text", "Строка кода");

            dataGridView1.Columns["Line"].Width = 90;
            dataGridView1.Columns["Operator"].Width = 180;
            dataGridView1.Columns["Text"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            foreach (var found in result.BranchingStatements)
            {
                dataGridView1.Rows.Add(found.Line, found.Operator, found.Text);
            }

            int totalRowIndex = dataGridView1.Rows.Add("ИТОГО", "CL (Сложность)", result.CL.ToString());
            dataGridView1.Rows[totalRowIndex].DefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dataGridView1.Rows[totalRowIndex].DefaultCellStyle.BackColor = Color.FromArgb(227, 242, 253);

            dataGridView2.Rows.Clear();
            dataGridView2.Columns.Clear();
            dataGridView2.Columns.Add("Name", "Оператор (по спецификации Go)");
            dataGridView2.Columns.Add("Count", "Количество");

            dataGridView2.Columns["Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView2.Columns["Count"].Width = 120;

            foreach (var stat in result.AllStatements)
            {
                dataGridView2.Rows.Add(stat.Name, stat.Count);
            }

            int totalStmtRow = dataGridView2.Rows.Add("ОБЩЕЕ ЧИСЛО ОПЕРАТОРОВ (N)", result.N.ToString());
            dataGridView2.Rows[totalStmtRow].DefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dataGridView2.Rows[totalStmtRow].DefaultCellStyle.BackColor = Color.FromArgb(227, 242, 253);
        }
    }
}