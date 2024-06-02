using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Windows.Forms;

namespace 日曆
{
    public partial class diarycs : Form
    {
        private DateTime selectedDate; // 選擇的日期
        private List<PictureBox> pictureBoxes = new List<PictureBox>(); // 存儲 PictureBox 的列表
        private int totalphoto = 0; // 計數器，用於計算添加的照片數量
        public Color selectedColor; // 存儲用戶選擇的顏色

        public diarycs(DateTime diaryDate)
        {
            InitializeComponent();
            selectedDate = diaryDate;
            pictureBoxes.Add(pictureBox1);
            pictureBoxes.Add(pictureBox2);
            pictureBoxes.Add(pictureBox3);
            pictureBoxes.Add(pictureBox4);
            pictureBoxes.Add(pictureBox5);
            pictureBoxes.Add(pictureBox6);
        }

        // 心情下拉框選擇改變事件處理方法
        private void moodcomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox moodComboBox = new ComboBox();
            moodComboBox.Items.AddRange(new string[] { "😊", "😔", "😡", "😄", "😢" });
        }

        // 天氣下拉框選擇改變事件處理方法
        private void weathercomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox weathercomboBox = new ComboBox();
            weathercomboBox.Items.AddRange(new string[] { "☀️", "☁️", "🌧️", "❄️", "🌈" });
        }

        // 添加照片按鈕點擊事件處理方法
        private void addbutton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files (*.jpg, *.jpeg, *.png, *.gif, *.bmp)|*.jpg; *.jpeg; *.png; *.gif; *.bmp";
            openFileDialog.Multiselect = false; // 僅允許選擇一個文件
            DialogResult result = openFileDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                // 獲取所選圖片的路徑
                string selectedImagePath = openFileDialog.FileName;

                // 將所選圖片放入 PictureBox 中，依次放入 PictureBox1, PictureBox2, PictureBox3, PictureBox4, PictureBox5, PictureBox6
                if (pictureBox1.Image == null)
                {
                    pictureBox1.Image = Image.FromFile(selectedImagePath);
                    totalphoto++;
                }
                else if (pictureBox2.Image == null)
                {
                    pictureBox2.Image = Image.FromFile(selectedImagePath);
                    totalphoto++;
                }
                else if (pictureBox3.Image == null)
                {
                    pictureBox3.Image = Image.FromFile(selectedImagePath);
                    totalphoto++;
                }
                else if (pictureBox4.Image == null)
                {
                    pictureBox4.Image = Image.FromFile(selectedImagePath);
                    totalphoto++;
                }
                else if (pictureBox5.Image == null)
                {
                    pictureBox5.Image = Image.FromFile(selectedImagePath);
                    totalphoto++;
                }
                else if (pictureBox6.Image == null)
                {
                    pictureBox6.Image = Image.FromFile(selectedImagePath);
                    totalphoto++;
                }
                else if (totalphoto >= 6)
                {
                    MessageBox.Show("最多只能放六張照片歐!!", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        // 移除照片按鈕點擊事件處理方法
        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("確定要移除照片嗎？", "移除照片", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                totalphoto--;
                pictureBox1.Image = null;
                pictureBox1.Image = pictureBox2.Image;
                pictureBox2.Image = pictureBox3.Image;
                pictureBox3.Image = pictureBox4.Image;
                pictureBox4.Image = pictureBox5.Image;
                pictureBox5.Image = pictureBox6.Image;
                pictureBox6.Image = null;
            }
        }

        // 移除照片按鈕點擊事件處理方法
        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("確定要移除照片嗎？", "移除照片", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                totalphoto--;
                pictureBox2.Image = null;
                pictureBox2.Image = pictureBox3.Image;
                pictureBox3.Image = pictureBox4.Image;
                pictureBox4.Image = pictureBox5.Image;
                pictureBox5.Image = pictureBox6.Image;
                pictureBox6.Image = null;
            }
        }

        // 移除照片按鈕點擊事件處理方法
        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("確定要移除照片嗎？", "移除照片", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                totalphoto--;
                pictureBox3.Image = null;
                pictureBox3.Image = pictureBox4.Image;
                pictureBox4.Image = pictureBox5.Image;
                pictureBox5.Image = pictureBox6.Image;
                pictureBox6.Image = null;
            }
        }

        // 移除照片按鈕點擊事件處理方法
        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("確定要移除照片嗎？", "移除照片", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                totalphoto--;
                pictureBox4.Image = null;
                pictureBox4.Image = pictureBox5.Image;
                pictureBox5.Image = pictureBox6.Image;
                pictureBox6.Image = null;
            }
        }

        // 移除照片按鈕點擊事件處理方法
        private void button5_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("確定要移除照片嗎？", "移除照片", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                totalphoto--;
                pictureBox5.Image = null;
                pictureBox5.Image = pictureBox6.Image;
                pictureBox6.Image = null;
            }
        }

        // 移除照片按鈕點擊事件處理方法
        private void button6_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("確定要移除照片嗎？", "移除照片", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                totalphoto--;
                pictureBox6.Image = null;
            }
        }

        // 設置日期選擇器的值
        public void SetDateTimePickerValue(DateTime date)
        {
            dateTimePicker1.Value = date;
        }

        // 保存日記按鈕點擊事件處理方法
        private void savebutton_Click(object sender, EventArgs e)
        {
            // 創建日記條目對象
            DiaryEntry entry = new DiaryEntry
            {
                Date = dateTimePicker1.Value,
                Mood = moodcomboBox.SelectedItem?.ToString(),
                Weather = weathercomboBox.SelectedItem?.ToString(),
                Context = context.Text,
                SelectedColor = selectedColor,
                PhotoFileNames = new List<string>()
            };

            // 保存每張照片
            for (int i = 0; i < totalphoto; i++)
            {
                if (pictureBoxes[i].Image != null)
                {
                    string photoFileName = $"{entry.Date.ToString("yyyy-MM-dd")}_photo{(i + 1)}.jpg";
                    string photoFilePath = Path.Combine(DairyManager.DiariesFolder, selectedDate.ToString("yyyy-MM-dd"), photoFileName);

                    try
                    {
                        // 如果文件存在，先删除
                        if (File.Exists(photoFilePath))
                        {
                            File.Delete(photoFilePath);
                        }

                        // 保存圖片到文件
                        pictureBoxes[i].Image.Save(photoFilePath, System.Drawing.Imaging.ImageFormat.Jpeg);
                        entry.PhotoFileNames.Add(photoFileName);
                    }
                    catch (Exception ex)
                    {
                       entry.PhotoFileNames.Add(photoFileName);
                    }
                }
            }

            // 保存日記條目到文件
            DairyManager.SaveToFile(entry, selectedDate);
            MessageBox.Show("日記儲存成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // 打開日記表單方法
        public void OpenDiaryForm(DateTime selectedDate)
        {
            // 清空現有數據
            moodcomboBox.SelectedItem = null;
            weathercomboBox.SelectedItem = null;
            context.Text = string.Empty;
            BackColor = SystemColors.Control; // 重置背景色
            foreach (var pictureBox in pictureBoxes)
            {
                pictureBox.Image = null;
            }

            // 生成文件名（使用日期作為文件名）
            string fileName = selectedDate.ToString("yyyy-MM-dd") + ".json";
            string filePath = Path.Combine(DairyManager.DiariesFolder, selectedDate.ToString("yyyy-MM-dd"), fileName);

            try
            {
                if (File.Exists(filePath))
                {
                    // 讀取 JSON 文件內容
                    string json = File.ReadAllText(filePath);

                    // 將 JSON 反序列化為 DiaryEntry 對象
                    DiaryEntry diaryEntry = JsonConvert.DeserializeObject<DiaryEntry>(json);

                    // 設置日記內容到界面
                    dateTimePicker1.Value = diaryEntry.Date;
                    moodcomboBox.SelectedItem = diaryEntry.Mood;
                    weathercomboBox.SelectedItem = diaryEntry.Weather;
                    context.Text = diaryEntry.Context;
                    BackColor = diaryEntry.SelectedColor;

                    totalphoto = diaryEntry.PhotoFileNames.Count;

                    // 加載照片
                    for (int i = 0; i < diaryEntry.PhotoFileNames.Count && i < pictureBoxes.Count; i++)
                    {
                        string photoFileName = diaryEntry.PhotoFileNames[i];
                        string photoFilePath = Path.Combine(DairyManager.DiariesFolder, selectedDate.ToString("yyyy-MM-dd"), photoFileName);
                        if (File.Exists(photoFilePath))
                        {
                            Image image = Image.FromFile(photoFilePath);
                            pictureBoxes[i].Image = image;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"打開 JSON 文件時出錯: {ex.Message}");
            }
        }

        // 顏色選擇按鈕點擊事件處理方法
        private void colorbutton_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();

            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                selectedColor = colorDialog.Color; // 設置選擇的顏色
                this.BackColor = Color.White;
                this.Invalidate(); // 觸發重繪
            }
        }

        // 重寫 OnPaint 方法，自定義背景漸變效果
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            using (LinearGradientBrush brush = new LinearGradientBrush(this.ClientRectangle, Color.White, selectedColor, LinearGradientMode.Vertical))
            {
                e.Graphics.FillRectangle(brush, this.ClientRectangle); // 用漸變顏色填充背景
            }
        }

        // 日期選擇器值改變事件處理方法
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            if (selectedDate != dateTimePicker1.Value)
            {
                selectedDate = dateTimePicker1.Value;
                if (DairyManager.DiaryExists(selectedDate))
                {
                    OpenDiaryForm(selectedDate);
                }
                else
                {
                    OpenNewDiaryForm(selectedDate);
                }
            }
        }

        // 打開新日記表單方法
        public void OpenNewDiaryForm(DateTime selectedDate)
        {
            // 清空心情和天氣下拉框
            moodcomboBox.SelectedItem = null;
            moodcomboBox.Text = "心情";
            weathercomboBox.SelectedItem = null;
            weathercomboBox.Text = "天氣";

            // 清空文本框
            context.Text = string.Empty;

            // 清空背景顏色
            BackColor = SystemColors.Control;

            // 清空所有圖片框
            foreach (var pictureBox in pictureBoxes)
            {
                pictureBox.Image = null;
            }

            // 重置照片計數器
            totalphoto = 0;
        }
    }
}
