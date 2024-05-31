namespace 日曆
{
    partial class choice
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(choice));
            diarybutton = new Button();
            accountingbutton = new Button();
            label1 = new Label();
            pictureBox1 = new PictureBox();
            StarTimer = new System.Windows.Forms.Timer(components);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // diarybutton
            // 
            diarybutton.Font = new Font("Microsoft JhengHei UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point);
            diarybutton.Location = new Point(335, 164);
            diarybutton.Name = "diarybutton";
            diarybutton.Size = new Size(142, 64);
            diarybutton.TabIndex = 0;
            diarybutton.Text = "日記";
            diarybutton.UseVisualStyleBackColor = true;
            diarybutton.Click += diarybutton_Click;
            // 
            // accountingbutton
            // 
            accountingbutton.Font = new Font("Microsoft JhengHei UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point);
            accountingbutton.Location = new Point(335, 260);
            accountingbutton.Name = "accountingbutton";
            accountingbutton.RightToLeft = RightToLeft.No;
            accountingbutton.Size = new Size(142, 64);
            accountingbutton.TabIndex = 1;
            accountingbutton.Text = "記帳";
            accountingbutton.UseVisualStyleBackColor = true;
            accountingbutton.Click += accountingbutton_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft JhengHei UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = Color.LightBlue;
            label1.Location = new Point(340, 86);
            label1.Name = "label1";
            label1.Size = new Size(211, 36);
            label1.TabIndex = 2;
            label1.Text = "請選擇服務項目";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(266, 67);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(79, 70);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 3;
            pictureBox1.TabStop = false;
            // 
            // StarTimer
            // 
            StarTimer.Tick += StarTimer_Tick;
            // 
            // choice
            // 
            AutoScaleDimensions = new SizeF(9F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(pictureBox1);
            Controls.Add(label1);
            Controls.Add(accountingbutton);
            Controls.Add(diarybutton);
            Name = "choice";
            Text = "服務項目";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button diarybutton;
        private Button accountingbutton;
        private Label label1;
        private PictureBox pictureBox1;
        private System.Windows.Forms.Timer StarTimer;
    }
}