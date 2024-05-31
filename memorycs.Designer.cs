namespace 日曆
{
    partial class memorycs
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
            memoListBox = new ListBox();
            title = new TextBox();
            label1 = new Label();
            Memo = new TextBox();
            btnSave = new Button();
            deletebutton3 = new Button();
            addbutton = new Button();
            SuspendLayout();
            // 
            // memoListBox
            // 
            memoListBox.DrawMode = DrawMode.OwnerDrawFixed;
            memoListBox.Font = new Font("Microsoft JhengHei UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point);
            memoListBox.FormattingEnabled = true;
            memoListBox.ItemHeight = 35;
            memoListBox.Location = new Point(40, 53);
            memoListBox.Margin = new Padding(4, 5, 4, 5);
            memoListBox.Name = "memoListBox";
            memoListBox.Size = new Size(394, 494);
            memoListBox.TabIndex = 1;
            memoListBox.Click += MemoListBox_Click;
            memoListBox.DrawItem += memoListBox_DrawItem;
            // 
            // title
            // 
            title.Font = new Font("Microsoft JhengHei UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            title.Location = new Point(609, 38);
            title.Name = "title";
            title.Size = new Size(377, 37);
            title.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft JhengHei UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = ColorTranslator.FromHtml("#003E3E");
            label1.BackColor = Color.Transparent;
            label1.Location = new Point(504, 39);
            label1.Name = "label1";
            label1.Size = new Size(99, 36);
            label1.TabIndex = 4;
            label1.Text = "標題：";
            // 
            // Memo
            // 
            Memo.Font = new Font("Microsoft JhengHei UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            Memo.Location = new Point(504, 99);
            Memo.Margin = new Padding(4);
            Memo.Multiline = true;
            Memo.Name = "Memo";
            Memo.Size = new Size(494, 432);
            Memo.TabIndex = 5;
            // 
            // btnSave
            // 
            btnSave.Font = new Font("Microsoft JhengHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnSave.Location = new Point(609, 542);
            btnSave.Margin = new Padding(4);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(112, 34);
            btnSave.TabIndex = 6;
            btnSave.Text = "儲存";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // deletebutton3
            // 
            deletebutton3.Font = new Font("Microsoft JhengHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            deletebutton3.Location = new Point(782, 544);
            deletebutton3.Name = "deletebutton3";
            deletebutton3.Size = new Size(112, 34);
            deletebutton3.TabIndex = 7;
            deletebutton3.Text = "刪除";
            deletebutton3.UseVisualStyleBackColor = true;
            deletebutton3.Click += deletebutton3_Click;
            // 
            // addbutton
            // 
            addbutton.Font = new Font("Microsoft JhengHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            addbutton.Location = new Point(40, 8);
            addbutton.Name = "addbutton";
            addbutton.Size = new Size(94, 38);
            addbutton.TabIndex = 8;
            addbutton.Text = "新增";
            addbutton.UseVisualStyleBackColor = true;
            addbutton.Click += addbutton_Click;
            // 
            // memorycs
            // 
            AutoScaleDimensions = new SizeF(9F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1046, 613);
            Controls.Add(addbutton);
            Controls.Add(deletebutton3);
            Controls.Add(btnSave);
            Controls.Add(Memo);
            Controls.Add(label1);
            Controls.Add(title);
            Controls.Add(memoListBox);
            Margin = new Padding(4, 5, 4, 5);
            Name = "memorycs";
            Text = "備忘錄";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        private ListBox memoListBox;
        private TextBox title;
        private Label label1;
        private TextBox Memo;
        private Button btnSave;
        private Button deletebutton3;
        private Button addbutton;
    }
}