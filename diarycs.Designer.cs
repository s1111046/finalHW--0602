using System.Globalization;

namespace 日曆
{
    partial class diarycs
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>

        private void InitializeComponent()
        {
            dateTimePicker1 = new DateTimePicker();
            moodcomboBox = new ComboBox();
            savebutton = new Button();
            context = new RichTextBox();
            weathercomboBox = new ComboBox();
            pictureBox1 = new PictureBox();
            label1 = new Label();
            pictureBox2 = new PictureBox();
            pictureBox3 = new PictureBox();
            pictureBox4 = new PictureBox();
            addbutton = new Button();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            pictureBox5 = new PictureBox();
            pictureBox6 = new PictureBox();
            button5 = new Button();
            button6 = new Button();
            colorbutton = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).BeginInit();
            SuspendLayout();
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.CalendarFont = new Font("Microsoft JhengHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            dateTimePicker1.Location = new Point(44, 34);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(220, 27);
            dateTimePicker1.TabIndex = 0;
            dateTimePicker1.Value = new DateTime(2024, 5, 11, 0, 0, 0, 0);
            dateTimePicker1.ValueChanged += dateTimePicker1_ValueChanged;
            // 
            // moodcomboBox
            // 
            moodcomboBox.Font = new Font("Microsoft JhengHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            moodcomboBox.FormattingEnabled = true;
            moodcomboBox.Items.AddRange(new object[] { "😊", "😔", "😡", "😄", "😢" });
            moodcomboBox.Location = new Point(304, 30);
            moodcomboBox.Name = "moodcomboBox";
            moodcomboBox.Size = new Size(164, 33);
            moodcomboBox.TabIndex = 1;
            moodcomboBox.Text = "心情";
            moodcomboBox.SelectedIndexChanged += moodcomboBox_SelectedIndexChanged;
            // 
            // savebutton
            // 
            savebutton.Font = new Font("Microsoft JhengHei UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            savebutton.Location = new Point(687, 29);
            savebutton.Name = "savebutton";
            savebutton.Size = new Size(110, 34);
            savebutton.TabIndex = 4;
            savebutton.Text = "儲存";
            savebutton.UseVisualStyleBackColor = true;
            savebutton.Click += savebutton_Click;
            // 
            // context
            // 
            context.EnableAutoDragDrop = true;
            context.Font = new Font("Microsoft JhengHei UI", 14.8000011F, FontStyle.Regular, GraphicsUnit.Point);
            context.Location = new Point(24, 80);
            context.Name = "context";
            context.Size = new Size(781, 608);
            context.TabIndex = 5;
            context.Text = "";
            // 
            // weathercomboBox
            // 
            weathercomboBox.Font = new Font("Microsoft JhengHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            weathercomboBox.FormattingEnabled = true;
            weathercomboBox.Items.AddRange(new object[] { "☀️", "☁️", "🌧️", "❄️", "🌈" });
            weathercomboBox.Location = new Point(500, 29);
            weathercomboBox.Name = "weathercomboBox";
            weathercomboBox.Size = new Size(150, 33);
            weathercomboBox.TabIndex = 6;
            weathercomboBox.Text = "天氣";
            weathercomboBox.SelectedIndexChanged += weathercomboBox_SelectedIndexChanged;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = SystemColors.ControlLight;
            pictureBox1.BackgroundImageLayout = ImageLayout.Center;
            pictureBox1.BorderStyle = BorderStyle.Fixed3D;
            pictureBox1.Location = new Point(834, 114);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(238, 176);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 8;
            pictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("微軟正黑體", 18F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = SystemColors.ControlText;
            label1.Location = new Point(1054, 47);
            label1.Name = "label1";
            label1.Size = new Size(77, 38);
            label1.TabIndex = 12;
            label1.Text = "照片";
            // 
            // pictureBox2
            // 
            pictureBox2.BackColor = SystemColors.ControlLight;
            pictureBox2.BackgroundImageLayout = ImageLayout.Center;
            pictureBox2.BorderStyle = BorderStyle.Fixed3D;
            pictureBox2.Location = new Point(1106, 114);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(238, 176);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 13;
            pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            pictureBox3.BackColor = SystemColors.ControlLight;
            pictureBox3.BackgroundImageLayout = ImageLayout.Center;
            pictureBox3.BorderStyle = BorderStyle.Fixed3D;
            pictureBox3.Location = new Point(834, 312);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(238, 176);
            pictureBox3.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox3.TabIndex = 14;
            pictureBox3.TabStop = false;
            // 
            // pictureBox4
            // 
            pictureBox4.BackColor = SystemColors.ControlLight;
            pictureBox4.BackgroundImageLayout = ImageLayout.Center;
            pictureBox4.BorderStyle = BorderStyle.Fixed3D;
            pictureBox4.Location = new Point(1106, 312);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(238, 176);
            pictureBox4.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox4.TabIndex = 15;
            pictureBox4.TabStop = false;
            // 
            // addbutton
            // 
            addbutton.Font = new Font("Microsoft JhengHei UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            addbutton.Location = new Point(1281, 67);
            addbutton.Name = "addbutton";
            addbutton.Size = new Size(63, 38);
            addbutton.TabIndex = 16;
            addbutton.Text = "+";
            addbutton.UseVisualStyleBackColor = true;
            addbutton.Click += addbutton_Click;
            // 
            // button1
            // 
            button1.Location = new Point(837, 118);
            button1.Name = "button1";
            button1.Size = new Size(32, 29);
            button1.TabIndex = 17;
            button1.Text = "X";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(1110, 117);
            button2.Name = "button2";
            button2.Size = new Size(32, 29);
            button2.TabIndex = 18;
            button2.Text = "X";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(838, 314);
            button3.Name = "button3";
            button3.Size = new Size(32, 29);
            button3.TabIndex = 19;
            button3.Text = "X";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.Location = new Point(1110, 317);
            button4.Name = "button4";
            button4.Size = new Size(32, 29);
            button4.TabIndex = 20;
            button4.Text = "X";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // pictureBox5
            // 
            pictureBox5.BackColor = SystemColors.ControlLight;
            pictureBox5.BackgroundImageLayout = ImageLayout.Center;
            pictureBox5.BorderStyle = BorderStyle.Fixed3D;
            pictureBox5.Location = new Point(834, 512);
            pictureBox5.Name = "pictureBox5";
            pictureBox5.Size = new Size(238, 176);
            pictureBox5.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox5.TabIndex = 21;
            pictureBox5.TabStop = false;
            // 
            // pictureBox6
            // 
            pictureBox6.BackColor = SystemColors.ControlLight;
            pictureBox6.BackgroundImageLayout = ImageLayout.Center;
            pictureBox6.BorderStyle = BorderStyle.Fixed3D;
            pictureBox6.Location = new Point(1106, 512);
            pictureBox6.Name = "pictureBox6";
            pictureBox6.Size = new Size(238, 176);
            pictureBox6.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox6.TabIndex = 22;
            pictureBox6.TabStop = false;
            // 
            // button5
            // 
            button5.Location = new Point(838, 517);
            button5.Name = "button5";
            button5.Size = new Size(32, 29);
            button5.TabIndex = 23;
            button5.Text = "X";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // button6
            // 
            button6.Location = new Point(1110, 517);
            button6.Name = "button6";
            button6.Size = new Size(32, 29);
            button6.TabIndex = 24;
            button6.Text = "X";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // colorbutton
            // 
            colorbutton.Font = new Font("Microsoft JhengHei UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            colorbutton.Location = new Point(1281, 16);
            colorbutton.Name = "colorbutton";
            colorbutton.Size = new Size(63, 45);
            colorbutton.TabIndex = 25;
            colorbutton.Text = "color";
            colorbutton.UseVisualStyleBackColor = true;
            colorbutton.Click += colorbutton_Click;
            // 
            // diarycs
            // 
            AutoScaleDimensions = new SizeF(9F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            ClientSize = new Size(1374, 710);
            Controls.Add(colorbutton);
            Controls.Add(button6);
            Controls.Add(button5);
            Controls.Add(pictureBox6);
            Controls.Add(pictureBox5);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(addbutton);
            Controls.Add(pictureBox4);
            Controls.Add(pictureBox3);
            Controls.Add(pictureBox2);
            Controls.Add(label1);
            Controls.Add(pictureBox1);
            Controls.Add(weathercomboBox);
            Controls.Add(context);
            Controls.Add(savebutton);
            Controls.Add(moodcomboBox);
            Controls.Add(dateTimePicker1);
            Name = "diarycs";
            Text = "日記";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DateTimePicker dateTimePicker1;
        private ComboBox moodcomboBox;
        private Button savebutton;
        private RichTextBox context;
        private ComboBox weathercomboBox;
        private PictureBox pictureBox1;
        private Label label1;
        private PictureBox pictureBox2;
        private PictureBox pictureBox3;
        private PictureBox pictureBox4;
        private Button addbutton;
        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private PictureBox pictureBox5;
        private PictureBox pictureBox6;
        private Button button5;
        private Button button6;
        private Button colorbutton;
    }
}
