namespace WinFormsApp1
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            label1 = new Label();
            button1 = new Button();
            openFileDialog1 = new OpenFileDialog();
            dataGridView1 = new DataGridView();
            dataGridView2 = new DataGridView();
            label4 = new Label();
            label6 = new Label();
            label8 = new Label();
            labelCL = new Label();
            textBoxCL = new TextBox();
            textBoxRel = new TextBox();
            textBoxCLI = new TextBox();
            textBoxN = new TextBox();
            button2 = new Button();
            richTextBox1 = new RichTextBox();
            labelTitle = new Label();
            labelFound = new Label();
            labelStatements = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10F);
            label1.Location = new Point(20, 955);
            label1.Name = "label1";
            label1.Size = new Size(132, 23);
            label1.TabIndex = 36;
            label1.Text = "Выберите файл:";
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            button1.BackColor = Color.FromArgb(30, 144, 255);
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            button1.ForeColor = Color.White;
            button1.Location = new Point(160, 948);
            button1.Name = "button1";
            button1.Size = new Size(160, 38);
            button1.TabIndex = 35;
            button1.Text = "Открыть файл";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // openFileDialog1
            // 
            openFileDialog1.Filter = "Go Files (*.go)|*.go|Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(240, 248, 255);
            dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView1.BackgroundColor = Color.White;
            dataGridView1.BorderStyle = BorderStyle.Fixed3D;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(144, 202, 249);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(33, 33, 33);
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.GridColor = Color.FromArgb(224, 224, 224);
            dataGridView1.Location = new Point(660, 50);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.RowTemplate.Height = 28;
            dataGridView1.Size = new Size(650, 880);
            dataGridView1.TabIndex = 3;
            // 
            // dataGridView2
            // 
            dataGridViewCellStyle3.BackColor = Color.FromArgb(240, 248, 255);
            dataGridView2.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            dataGridView2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            dataGridView2.BackgroundColor = Color.White;
            dataGridView2.BorderStyle = BorderStyle.Fixed3D;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = Color.FromArgb(144, 202, 249);
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dataGridViewCellStyle4.ForeColor = Color.FromArgb(33, 33, 33);
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            dataGridView2.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.EnableHeadersVisualStyles = false;
            dataGridView2.GridColor = Color.FromArgb(224, 224, 224);
            dataGridView2.Location = new Point(1330, 50);
            dataGridView2.Name = "dataGridView2";
            dataGridView2.RowHeadersVisible = false;
            dataGridView2.RowHeadersWidth = 51;
            dataGridView2.RowTemplate.Height = 28;
            dataGridView2.Size = new Size(560, 680);
            dataGridView2.TabIndex = 4;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 11F);
            label4.Location = new Point(1330, 830);
            label4.Name = "label4";
            label4.Size = new Size(278, 25);
            label4.TabIndex = 31;
            label4.Text = "Относительная сложность (cl):";
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 11F);
            label6.Location = new Point(1330, 870);
            label6.Name = "label6";
            label6.Size = new Size(228, 25);
            label6.TabIndex = 30;
            label6.Text = "Макс. вложенность (CLI):";
            // 
            // label8
            // 
            label8.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 11F);
            label8.Location = new Point(1330, 910);
            label8.Name = "label8";
            label8.Size = new Size(274, 25);
            label8.TabIndex = 29;
            label8.Text = "Общее число операторов (N):";
            // 
            // labelCL
            // 
            labelCL.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            labelCL.AutoSize = true;
            labelCL.Font = new Font("Segoe UI", 11F);
            labelCL.Location = new Point(1330, 790);
            labelCL.Name = "labelCL";
            labelCL.Size = new Size(259, 25);
            labelCL.TabIndex = 32;
            labelCL.Text = "Абсолютная сложность (CL):";
            // 
            // textBoxCL
            // 
            textBoxCL.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            textBoxCL.BackColor = Color.FromArgb(240, 248, 255);
            textBoxCL.BorderStyle = BorderStyle.FixedSingle;
            textBoxCL.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            textBoxCL.ForeColor = Color.FromArgb(30, 136, 229);
            textBoxCL.Location = new Point(1640, 785);
            textBoxCL.Name = "textBoxCL";
            textBoxCL.ReadOnly = true;
            textBoxCL.Size = new Size(120, 34);
            textBoxCL.TabIndex = 28;
            textBoxCL.TextAlign = HorizontalAlignment.Right;
            // 
            // textBoxRel
            // 
            textBoxRel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            textBoxRel.BackColor = Color.FromArgb(240, 248, 255);
            textBoxRel.BorderStyle = BorderStyle.FixedSingle;
            textBoxRel.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            textBoxRel.ForeColor = Color.FromArgb(30, 136, 229);
            textBoxRel.Location = new Point(1640, 825);
            textBoxRel.Name = "textBoxRel";
            textBoxRel.ReadOnly = true;
            textBoxRel.Size = new Size(120, 34);
            textBoxRel.TabIndex = 27;
            textBoxRel.TextAlign = HorizontalAlignment.Right;
            // 
            // textBoxCLI
            // 
            textBoxCLI.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            textBoxCLI.BackColor = Color.FromArgb(240, 248, 255);
            textBoxCLI.BorderStyle = BorderStyle.FixedSingle;
            textBoxCLI.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            textBoxCLI.ForeColor = Color.FromArgb(30, 136, 229);
            textBoxCLI.Location = new Point(1640, 865);
            textBoxCLI.Name = "textBoxCLI";
            textBoxCLI.ReadOnly = true;
            textBoxCLI.Size = new Size(120, 34);
            textBoxCLI.TabIndex = 26;
            textBoxCLI.TextAlign = HorizontalAlignment.Right;
            // 
            // textBoxN
            // 
            textBoxN.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            textBoxN.BackColor = Color.FromArgb(240, 248, 255);
            textBoxN.BorderStyle = BorderStyle.FixedSingle;
            textBoxN.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            textBoxN.ForeColor = Color.FromArgb(30, 136, 229);
            textBoxN.Location = new Point(1640, 905);
            textBoxN.Name = "textBoxN";
            textBoxN.ReadOnly = true;
            textBoxN.Size = new Size(120, 34);
            textBoxN.TabIndex = 25;
            textBoxN.TextAlign = HorizontalAlignment.Right;
            // 
            // button2
            // 
            button2.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            button2.BackColor = Color.FromArgb(30, 144, 255);
            button2.Enabled = false;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            button2.ForeColor = Color.White;
            button2.Location = new Point(1330, 950);
            button2.Name = "button2";
            button2.Size = new Size(430, 50);
            button2.TabIndex = 34;
            button2.Text = "Рассчитать метрики Джилба";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // richTextBox1
            // 
            richTextBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            richTextBox1.BackColor = Color.White;
            richTextBox1.BorderStyle = BorderStyle.FixedSingle;
            richTextBox1.Font = new Font("Consolas", 10F);
            richTextBox1.ForeColor = Color.FromArgb(33, 33, 33);
            richTextBox1.Location = new Point(20, 50);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.ReadOnly = true;
            richTextBox1.Size = new Size(620, 880);
            richTextBox1.TabIndex = 21;
            richTextBox1.Text = "";
            // 
            // labelTitle
            // 
            labelTitle.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            labelTitle.AutoSize = true;
            labelTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            labelTitle.ForeColor = Color.FromArgb(30, 136, 229);
            labelTitle.Location = new Point(1330, 745);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(248, 32);
            labelTitle.TabIndex = 33;
            labelTitle.Text = "Итоговые метрики";
            // 
            // labelFound
            // 
            labelFound.AutoSize = true;
            labelFound.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            labelFound.ForeColor = Color.FromArgb(30, 136, 229);
            labelFound.Location = new Point(660, 15);
            labelFound.Name = "labelFound";
            labelFound.Size = new Size(335, 28);
            labelFound.TabIndex = 24;
            labelFound.Text = "Таблица 1. Ветвления (Джилб)";
            // 
            // labelStatements
            // 
            labelStatements.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            labelStatements.AutoSize = true;
            labelStatements.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            labelStatements.ForeColor = Color.FromArgb(30, 136, 229);
            labelStatements.Location = new Point(1330, 15);
            labelStatements.Name = "labelStatements";
            labelStatements.Size = new Size(365, 28);
            labelStatements.TabIndex = 22;
            labelStatements.Text = "Таблица 2. Операторы языка Go";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(9F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(250, 252, 255);
            ClientSize = new Size(1920, 1055);
            Controls.Add(richTextBox1);
            Controls.Add(labelStatements);
            Controls.Add(labelFound);
            Controls.Add(dataGridView2);
            Controls.Add(dataGridView1);
            Controls.Add(textBoxN);
            Controls.Add(textBoxCLI);
            Controls.Add(textBoxRel);
            Controls.Add(textBoxCL);
            Controls.Add(label8);
            Controls.Add(label6);
            Controls.Add(label4);
            Controls.Add(labelCL);
            Controls.Add(labelTitle);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label1);
            Font = new Font("Segoe UI", 10F);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Метрики сложности потока управления (Метрика Джилба - Go)";
            WindowState = FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private Label label1;
        private Button button1;
        private OpenFileDialog openFileDialog1;
        private DataGridView dataGridView1;
        private DataGridView dataGridView2;
        private Label label4;
        private Label label6;
        private Label label8;
        private Label labelCL;
        private TextBox textBoxCL;
        private TextBox textBoxRel;
        private TextBox textBoxCLI;
        private TextBox textBoxN;
        private Button button2;
        private RichTextBox richTextBox1;
        private Label labelTitle;
        private Label labelFound;
        private Label labelStatements;
    }
}