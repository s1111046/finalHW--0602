namespace 日曆
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            addAccountButton = new Button();
            label1 = new Label();
            accountsDataGridView = new DataGridView();
            NameColumn = new DataGridViewTextBoxColumn();
            Amount = new DataGridViewTextBoxColumn();
            accountNameTextBox = new TextBox();
            initialBalanceTextBox = new TextBox();
            label3 = new Label();
            dateTimePicker1 = new DateTimePicker();
            button1 = new Button();
            savebutton = new Button();
            deletebutton1 = new Button();
            clearButton = new Button();
            chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)accountsDataGridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)chart1).BeginInit();
            SuspendLayout();
            // 
            // addAccountButton
            // 
            addAccountButton.Font = new Font("Microsoft JhengHei UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            addAccountButton.Location = new Point(383, 203);
            addAccountButton.Margin = new Padding(2);
            addAccountButton.Name = "addAccountButton";
            addAccountButton.Size = new Size(92, 40);
            addAccountButton.TabIndex = 0;
            addAccountButton.Text = "添加";
            addAccountButton.UseVisualStyleBackColor = true;
            addAccountButton.Click += addAccountButton_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft JhengHei UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = ColorTranslator.FromHtml("#003E3E");
            label1.BackColor = Color.Transparent;
            label1.Location = new Point(363, 85);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(112, 25);
            label1.TabIndex = 3;
            label1.Text = "開銷名稱：";
            // 
            // accountsDataGridView
            // 
            accountsDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            accountsDataGridView.Columns.AddRange(new DataGridViewColumn[] { NameColumn, Amount });
            accountsDataGridView.Location = new Point(15, 20);
            accountsDataGridView.Margin = new Padding(2);
            accountsDataGridView.Name = "accountsDataGridView";
            accountsDataGridView.RowHeadersWidth = 62;
            accountsDataGridView.RowTemplate.Height = 32;
            accountsDataGridView.Size = new Size(336, 341);
            accountsDataGridView.TabIndex = 4;
            // 
            // NameColumn
            // 
            NameColumn.HeaderText = "開銷名稱";
            NameColumn.MinimumWidth = 8;
            NameColumn.Name = "NameColumn";
            NameColumn.Width = 150;
            // 
            // Amount
            // 
            Amount.HeaderText = "金額";
            Amount.MinimumWidth = 8;
            Amount.Name = "Amount";
            Amount.Width = 150;
            // 
            // accountNameTextBox
            // 
            accountNameTextBox.Location = new Point(471, 83);
            accountNameTextBox.Margin = new Padding(2);
            accountNameTextBox.Name = "accountNameTextBox";
            accountNameTextBox.Size = new Size(158, 27);
            accountNameTextBox.TabIndex = 5;
            // 
            // initialBalanceTextBox
            // 
            initialBalanceTextBox.Location = new Point(471, 140);
            initialBalanceTextBox.Margin = new Padding(2);
            initialBalanceTextBox.Name = "initialBalanceTextBox";
            initialBalanceTextBox.Size = new Size(158, 27);
            initialBalanceTextBox.TabIndex = 6;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft JhengHei UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label3.ForeColor = ColorTranslator.FromHtml("#003E3E");
            label3.BackColor = Color.Transparent;
            label3.Location = new Point(400, 140);
            label3.Margin = new Padding(2, 0, 2, 0);
            label3.Name = "label3";
            label3.Size = new Size(67, 25);
            label3.TabIndex = 10;
            label3.Text = "金額  :";
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(383, 30);
            dateTimePicker1.Margin = new Padding(2);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(246, 27);
            dateTimePicker1.TabIndex = 11;
            dateTimePicker1.ValueChanged += dateTimePicker1_ValueChanged;
            // 
            // button1
            // 
            button1.Font = new Font("Microsoft JhengHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label1.BackColor = Color.Transparent;
            label1.ForeColor = ColorTranslator.FromHtml("#003E3E");
            button1.Location = new Point(27, 381);
            button1.Margin = new Padding(2);
            button1.Name = "button1";
            button1.Size = new Size(92, 43);
            button1.TabIndex = 12;
            button1.Text = "結算";
            button1.UseVisualStyleBackColor = true;
            button1.Click += calculateButton_Click;
            // 
            // savebutton
            // 
            savebutton.Font = new Font("Microsoft JhengHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            savebutton.Location = new Point(140, 381);
            savebutton.Margin = new Padding(2);
            savebutton.Name = "savebutton";
            savebutton.Size = new Size(92, 42);
            savebutton.TabIndex = 13;
            savebutton.Text = "儲存";
            savebutton.UseVisualStyleBackColor = true;
            savebutton.Click += savebutton_Click;
            // 
            // deletebutton1
            // 
            deletebutton1.Font = new Font("Microsoft JhengHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            deletebutton1.Location = new Point(257, 383);
            deletebutton1.Margin = new Padding(2);
            deletebutton1.Name = "deletebutton1";
            deletebutton1.Size = new Size(83, 41);
            deletebutton1.TabIndex = 14;
            deletebutton1.Text = "刪除";
            deletebutton1.UseVisualStyleBackColor = true;
            deletebutton1.Click += deletebutton1_Click;
            // 
            // clearButton
            // 
            clearButton.Font = new Font("Microsoft JhengHei UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            clearButton.Location = new Point(520, 203);
            clearButton.Margin = new Padding(2);
            clearButton.Name = "clearButton";
            clearButton.Size = new Size(92, 40);
            clearButton.TabIndex = 15;
            clearButton.Text = "清空";
            clearButton.UseVisualStyleBackColor = true;
            clearButton.Click += clearButton_Click;
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            chart1.Legends.Add(legend1);
            chart1.Location = new Point(668, 85);
            chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point);
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            chart1.Series.Add(series1);
            chart1.Size = new Size(313, 308);
            chart1.TabIndex = 19;
            chart1.Text = "chart1";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = SystemColors.Control;
            label2.Font = new Font("微軟正黑體", 16.2F, FontStyle.Bold, GraphicsUnit.Point);
            label2.ForeColor = ColorTranslator.FromHtml("#003E3E");
            label2.BackColor = Color.Transparent;
            label2.Location = new Point(726, 21);
            label2.Name = "label2";
            label2.Size = new Size(211, 36);
            label2.TabIndex = 18;
            label2.Text = "花費金額圓餅圖";
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(9F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(1010, 452);
            Controls.Add(label2);
            Controls.Add(chart1);
            Controls.Add(clearButton);
            Controls.Add(deletebutton1);
            Controls.Add(savebutton);
            Controls.Add(button1);
            Controls.Add(dateTimePicker1);
            Controls.Add(label3);
            Controls.Add(initialBalanceTextBox);
            Controls.Add(accountNameTextBox);
            Controls.Add(accountsDataGridView);
            Controls.Add(label1);
            Controls.Add(addAccountButton);
            Margin = new Padding(2);
            Name = "Form2";
            Text = "Form2";
            Paint += Form2_Paint;
            ((System.ComponentModel.ISupportInitialize)accountsDataGridView).EndInit();
            ((System.ComponentModel.ISupportInitialize)chart1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button addAccountButton;
        private Label label1;
        private DataGridView accountsDataGridView;
        private TextBox accountNameTextBox;
        private TextBox initialBalanceTextBox;
        private Label label3;
        private DateTimePicker dateTimePicker1;
        private Button button1;
        private DataGridViewTextBoxColumn NameColumn;
        private DataGridViewTextBoxColumn Amount;
        private Button savebutton;
        private Button deletebutton1;
        private Button clearButton;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private Label label2;
    }
}